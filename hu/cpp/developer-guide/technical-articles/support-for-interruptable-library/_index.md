---
title: Támogatás a megszakítható könyvtárhoz
type: docs
weight: 150
url: /hu/cpp/support-for-interruptable-library/
keywords:
- megszakítható könyvtár
- megszakítási token
- lemondási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Tegye a hosszú ideig futó feladatokat lemondhatóvá az Aspose.Slides for C++ segítségével. Biztonságosan szakítsa meg a renderelést és az átalakításokat PowerPoint és OpenDocument esetén, példákkal."
---
## **Áttekintés**

Aspose.Slides egy megszakítható feldolgozási mechanizmust biztosít hosszú ideig futó prezentációs feladatokhoz, például deszerializáláshoz, szerializáláshoz és rendereléshez. Ez a mechanizmus az `InterruptionToken` és `InterruptionTokenSource` osztályokon alapul.

Egy `InterruptionToken` hozzárendelhető a `LoadOptions`-hoz, és átadható a `Presentation` konstruktorának. Amikor a `InterruptionTokenSource::Interrupt()` hívódik, a kapcsolódó hosszú ideig futó feladat megszakad.

## **Megszakítható könyvtár**

Az [Aspose.Slides 18.4](https://releases.aspose.com/slides/hu/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) bevezetésével megjelentek az [InterruptionToken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontoken/) és [InterruptionTokenSource](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/) osztályok. Ezek lehetővé teszik a hosszú ideig futó feladatok, például a deszerializálás, szerializálás és renderelés megszakítását.

- [InterruptionTokenSource](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/) a token(ek) forrása, amely a [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_interruptiontoken/)‑hez kerül átadásra.
- Amikor a [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_interruptiontoken/) be van állítva, és a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) példány át van adva a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) konstruktorának, a [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/interrupt/) hívása megszakítja az ehhez a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) kapcsolódó bármely hosszú ideig futó feladatot.

A következő kódrészlet bemutatja egy futó feladat megszakítását:

```cpp
void Run(Action<SharedPtr<IInterruptionToken>> action, SharedPtr<IInterruptionToken> token)
{
    auto threadFunction = std::function<void()>([&action, &token]() -> void
    {
        action(token);
    });

    auto thread = System::MakeObject<Threading::Thread>(threadFunction);
    thread->Start();
}

void Run()
{
    String dataDir = GetDataPath();

    auto function = std::function<void(SharedPtr<IInterruptionToken> token)> ([&dataDir](SharedPtr<IInterruptionToken> token) -> void
    {
        auto options = System::MakeObject<LoadOptions>();
        options->set_InterruptionToken(token);

        auto presentation = System::MakeObject<Presentation>(dataDir + u"sample.pptx", options);
        presentation->Save(dataDir + u"sample.ppt", Export::SaveFormat::Ppt);
    });

    auto action = System::Action<SharedPtr<IInterruptionToken>>(function);
    auto tokenSource = System::MakeObject<InterruptionTokenSource>();
    
    Run(action, tokenSource->get_Token()); // a művelet futtatása külön szálban
    Threading::Thread::Sleep(10000);       // időtúllépés
    tokenSource->Interrupt();              // a konverzió leállítása
}
```

## **GYIK**

**Mi a célja az Aspose.Slides megszakító könyvtárának?**

Egy mechanizmust biztosít a hosszú ideig futó műveletek—például a prezentációk betöltése, mentése vagy renderelése—megszakítására, még mielőtt befejeződnének. Ez akkor hasznos, ha a feldolgozási időt korlátozni kell, vagy a feladat már nem szükséges.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/) között?**

- `InterruptionToken` átadásra kerül az Aspose.Slides API-nak, és a hosszú ideig futó műveletek során ellenőrzésre kerül.
- `InterruptionTokenSource` a kódban használható tokenek létrehozására és a megszakítások előidézésére a `Interrupt()` hívásával.

**Milyen feladatok szakíthatók meg?**

Bármely Aspose.Slides feladat, amely elfogad egy [InterruptionToken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontoken/)—például egy prezentáció betöltése a `Presentation(path, loadOptions)` vagy mentése a `Presentation::Save(...)`—megszakítható.

**A megszakítás azonnal megtörténik?**

Nem. A megszakítás együttműködő: a művelet időközönként ellenőrzi a tokent, és leáll, amint észleli, hogy a [Interrupt()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/interrupt/) meghívásra került.

**Mi történik, ha a [Interrupt()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/interrupt/) hívást egy már befejezett feladat után hívom meg?**

Semmi — a hívásnak nincs hatása, ha a megfelelő feladat már befejeződött.

**Újra felhasználhatom ugyanazt a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/) több feladathoz?**

Igen — de miután meghívja a [Interrupt()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/interruptiontokensource/interrupt/) ezen a forráson, az összes tokenjét használó feladat megszakad. Használjon külön tokenforrásokat a feladatok független kezeléséhez.