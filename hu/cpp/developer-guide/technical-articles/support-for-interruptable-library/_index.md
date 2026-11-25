---
title: Hosszú ideig futó prezentációs műveletek megszakítása C++-ban
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 150
url: /hu/cpp/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- leállítási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan szakíthatja meg a hosszú ideig futó prezentációs műveleteket az Aspose.Slides for C++-ban, és hogyan adhat vissza részleges eredményt a diákat egy ciklusban exportálva."
---
## **Áttekintés**

Az Aspose.Slides for C++ képes megszakítani hosszú ideig futó műveleteket, például a bemutatók betöltését, mentését és renderelését. Az alkalmazás ugyanazt a megszakítási tokent használhatja egy ciklus leállításához, mielőtt a következő diát feldolgozná.

## **Prezentációművelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/), szerezze meg a tokenjét a [get_Token](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/get_token/) segítségével, adja át a tokent a [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) metódusnak, és adja át a betöltési beállításokat a [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) számára. A leállítás kéréséhez hívja meg a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metódust a forráson. Egy megszakítható művelet leáll, amikor észleli a kérést.

A példa a `sample.pptx` fájlt `sample.ppt`-re alakítja át egy háttérfeladatban, és 10 másodperc után kér leállítást, ha a feladat még fut. Ha a konvertálás korábban befejeződik, a kimenet már elkészült.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.ppt", Export::SaveFormat::Ppt);
});

if (conversion.wait_for(std::chrono::seconds(10)) == std::future_status::timeout)
    source->Interrupt();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
```

## **Az alkalmazás leállításának összekapcsolása az Aspose.Slides-szal**

Ha az alkalmazása egy [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) használ, alkalmazza a [Register](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/register/) metódust a leállítási kérések továbbításához a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) felé. A példa a `sample.pptx` fájlt `sample.pdf`-re exportálja egy háttérfeladatban. Ha az export 20 másodperc után is fut, az alkalmazás meghívja a [CancellationTokenSource::Cancel](https://reference.aspose.com/slides/cpp/system.threading/cancellationtokensource/cancel/) metódust, amely aktiválja a regisztrált visszahívást.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <system/threading/cancellation_token.h>
#include <system/threading/cancellation_token_source.h>
#include <chrono>
#include <future>
#include <iostream>

using namespace Aspose::Slides;
using namespace System;

auto cancellation = MakeObject<Threading::CancellationTokenSource>();
auto cancellationToken = cancellation->get_Token();
auto source = MakeObject<InterruptionTokenSource>();
auto token = source->get_Token();
auto interrupt = Action<>([source]() { source->Interrupt(); });
auto registration = cancellationToken.Register(interrupt);

auto conversion = std::async(std::launch::async, [token]()
{
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(u"sample.pptx", options);
    presentation->Save(u"sample.pdf", Export::SaveFormat::Pdf);
});

if (conversion.wait_for(std::chrono::seconds(20)) == std::future_status::timeout)
    cancellation->Cancel();

try
{
    conversion.get();
}
catch (const OperationCanceledException&)
{
    if (!token->get_IsInterruptionRequested())
        throw;
    std::cout << "Conversion canceled\n";
}
registration.Dispose();
```

## **Állítsa le a következő dia feldolgozása előtt**

Használja ugyanazt a [IInterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/) példányt a prezentáció és a diákat exportáló ciklus számára. Ellenőrizze a [get_IsInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/get_isinterruptionrequested/) értékét minden export indítása előtt. Ha a hívó felhasználhat részleges eredményt, adja vissza azoknak a diáknak a számait, amelyek exportja sikeresen befejeződött.

Használjon egy `sample.pptx` nevű prezentációt, amely legalább két diát tartalmaz. A példa azonnal kér leállítást, miután rögzítette az első sikeres exportot.

```cpp
#include <DOM/InterruptionTokenSource.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IInterruptionToken.h>
#include <system/exceptions.h>
#include <DOM/ISlideCollection.h>
#include <system/array.h>
#include <iostream>
#include <vector>

using namespace Aspose::Slides;
using namespace System;

auto exportSlides = [](String path, SharedPtr<InterruptionTokenSource> source)
{
    std::vector<int32_t> completed;
    auto token = source->get_Token();
    auto options = MakeObject<LoadOptions>();
    options->set_InterruptionToken(token);
    auto presentation = MakeObject<Presentation>(path, options);
    auto slideCount = presentation->get_Slides()->get_Count();

    for (auto number = 1; number <= slideCount; ++number)
    {
        if (token->get_IsInterruptionRequested())
            break;

        std::cout << "Starting slide " << number << '\n';
        auto filename = String::Format(u"slide-{0}.pdf", number);
        auto slides = MakeArray<int32_t>({number});
        try
        {
            presentation->Save(filename, slides, Export::SaveFormat::Pdf);
        }
        catch (const OperationCanceledException&)
        {
            if (!token->get_IsInterruptionRequested())
                throw;
            break;
        }

        completed.push_back(number);
        if (number == 1)
            source->Interrupt();
    }
    return completed;
};

auto source = MakeObject<InterruptionTokenSource>();
auto completed = exportSlides(u"sample.pptx", source);
std::cout << "Completed: [";
for (size_t i = 0; i < completed.size(); ++i)
    std::cout << (i == 0 ? "" : ", ") << completed[i];
std::cout << "]\n";
```

A példa `slide-1.pdf` fájlt ír, és a konzolra kiírja a `Starting slide 1` üzenetet, majd a `Completed: [1]` szöveget. A ciklus a kérés észlelése előtt még nem kezdi el a 2. diát. Ha a leállítás a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) során történik egy export közben, a `catch` blokk kilép a ciklusból, mielőtt a kód a jelenlegi diát befejezettként jelölné.

Ha a hívónak kezelnie kell a leállítást, cserélje le a ciklus elején lévő `if` ellenőrzést és a `break` utasítást egy [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/cpp/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) hívásra a tokenen. Távolítsa el az `try`/`catch` blokkokat az export körül, így a mentés közbeni leállítás is eléri a hívót. Ugyanazzal a bemenettel a példa csak a `Starting slide 1` üzenetet írja ki, és csak a `slide-1.pdf` fájlt hozza létre. A második iteráció elején a hívó egy [System::OperationCanceledException](https://reference.aspose.com/slides/cpp/system/details_operationcanceledexception/) kivételt kap, mielőtt az export elindulna. A hívó nem kap listát a befejezett diákról.

## **GYIK**

**Mikor kell kérni a leállítást?**

Kérjen leállítást, ha egy művelet meghaladja az időkorlátját, vagy ha az alkalmazása már nem igényli az eredményt.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) között?**

A forrás lehetővé teszi az alkalmazás számára a leállítás kérését. A token pedig azt teszi lehetővé, hogy az Aspose.Slides és az alkalmazása ellenőrizze ezt a kérést.

**Használhatok [System::Threading::CancellationToken](https://reference.aspose.com/slides/cpp/system.threading/cancellationtoken/) tokent az Aspose.Slides-szal?**

Igen. Amikor az alkalmazás tokenje leállítást jelez, hívja meg a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) metódust a prezentációhoz kapcsolódó forráson.

**Mely műveleteket lehet megszakítani?**

A betöltést, mentést és renderelést tudja megszakítani. Adja át a tokent a [Presentation constructor](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/presentation/) számára a [LoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_interruptiontoken/) használatával. Ezután a prezentáció a későbbi műveletek, például a [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) során is észlelheti a leállítást.

**Azonnal leáll a művelet?**

A leállítás együttműködésen alapul. A művelet időnként ellenőrzi a tokent, és a kérés észlelésekor leáll.

**Mi történik, ha a [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) hívást egy művelet befejezése után végzem?**

A befejezett művelet megtartja az eredményét.

**Több művelet megoszthatja ugyanazt a [InterruptionTokenSource](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/) példányt?**

Igen. A [InterruptionTokenSource::Interrupt](https://reference.aspose.com/slides/cpp/aspose.slides/interruptiontokensource/interrupt/) minden olyan művelethez leállítást kér, amely a forrás tokenjét használja. Ha külön-külön szeretne műveleteket leállítani, használjon külön forrást minden művelethez.