---
title: Stöd för avbrottsbibliotek
type: docs
weight: 150
url: /sv/cpp/support-for-interruptable-library/
keywords:
- avbrottsbibliotek
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Gör långvariga uppgifter avbrytbara med Aspose.Slides för C++. Avbryt rendering och konverteringar för PowerPoint och OpenDocument på ett säkert sätt, med exempel."
---
## **Översikt**

Aspose.Slides tillhandahåller en avbrottbar bearbetningsmekanism för långvariga presentationsuppgifter, såsom deserialisering, serialisering och rendering. Denna mekanism baseras på klasserna `InterruptionToken` och `InterruptionTokenSource`.

Ett `InterruptionToken` kan tilldelas `LoadOptions` och skickas till `Presentation`‑konstruktorn. När `InterruptionTokenSource::Interrupt()` anropas avbryts den associerade långvariga uppgiften.

## **Avbrottsbibliotek**

I [Aspose.Slides 18.4](https://releases.aspose.com/slides/sv/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/) introducerade vi klasserna [InterruptionToken](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/). De gör det möjligt att avbryta långvariga uppgifter såsom deserialisering, serialisering och rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/) är källan till token(s) som skickas till [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- När [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/set_interruptiontoken/) är inställt och [LoadOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/loadoptions/)-instansen skickas till [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)-konstruktorn, avbryter ett anrop av [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/interrupt/) alla långvariga uppgifter som är kopplade till den [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).

Följande kodsnutt demonstrerar hur en pågående uppgift avbryts:

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
    
    Run(action, tokenSource->get_Token()); // kör åtgärden i en separat tråd
    Threading::Thread::Sleep(10000);       // tidsgräns
    tokenSource->Interrupt();              // stoppa konverteringen
}
```

## **Vanliga frågor**

**Vad är syftet med Aspose.Slides avbrottsbibliotek?**

Det ger en mekanism för att avbryta långvariga operationer—såsom att läsa in, spara eller rendera presentationer—innan de är slutförda. Detta är användbart när bearbetningstiden måste begränsas eller när uppgiften inte längre behövs.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` skickas till Aspose.Slides‑API:et och kontrolleras under långvariga operationer.
- `InterruptionTokenSource` används i din kod för att skapa token och utlösa avbrott genom att anropa `Interrupt()`.

**Vilka uppgifter kan avbrytas?**

Alla Aspose.Slides‑uppgifter som accepterar ett [InterruptionToken](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontoken/)—såsom att läsa in en presentation med `Presentation(path, loadOptions)` eller att spara med `Presentation::Save(...)`—kan avbrytas.

**Sker avbrottet omedelbart?**

Nej. Avbrottet är samarbetsinriktat: operationen kontrollerar periodiskt token och stoppar så snart den upptäcker att [Interrupt()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/interrupt/) har anropats.

**Vad händer om jag anropar [Interrupt()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/interrupt/) efter att en uppgift redan har slutförts?**

Ingenting—anropet har ingen effekt om den motsvarande uppgiften redan är färdig.

**Kan jag återanvända samma [InterruptionTokenSource](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/) för flera uppgifter?**

Ja—men efter att du har anropat [Interrupt()](https://reference.aspose.com/slides/sv/cpp/aspose.slides/interruptiontokensource/interrupt/) på den källan kommer alla uppgifter som använder dess token att avbrytas. Använd separata token‑källor för att hantera uppgifter oberoende av varandra.