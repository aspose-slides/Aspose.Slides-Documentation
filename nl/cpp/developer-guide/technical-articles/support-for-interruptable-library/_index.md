---
title: Ondersteuning voor onderbreekbare bibliotheek
type: docs
weight: 150
url: /nl/cpp/support-for-interruptable-library/
keywords:
- onderbreekbare bibliotheek
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- onderbreekbare taak
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak langdurige taken annuleerbaar met Aspose.Slides voor C++. Onderbreek veilig het renderen en de conversies voor PowerPoint en OpenDocument, met voorbeelden."
---
## **Overzicht**

Aspose.Slides biedt een onderbreekbare verwerkingsmechanisme voor langdurige presentatietaken, zoals deserialisatie, serialisatie en rendering. Dit mechanisme is gebaseerd op de klassen `InterruptionToken` en `InterruptionTokenSource`.

`InterruptionToken` kan worden toegewezen aan `LoadOptions` en doorgegeven aan de constructor van `Presentation`. Wanneer `InterruptionTokenSource::Interrupt()` wordt aangeroepen, wordt de bijbehorende langdurige taak onderbroken.

## **Onderbreekbare bibliotheek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/nl/cpp/release-notes/2018/aspose-slides-for-cpp-18-4-release-notes/), hebben we de klassen [InterruptionToken](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/) geïntroduceerd. Ze stellen u in staat om langdurige taken zoals deserialisatie, serialisatie en rendering te onderbreken.

- [InterruptionTokenSource](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/) is de bron van het token of de tokens die worden doorgegeven aan [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_interruptiontoken/).
- Wanneer [ILoadOptions::set_InterruptionToken](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_interruptiontoken/) is ingesteld en de [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/)‑instantie wordt doorgegeven aan de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑constructor, onderbreekt het aanroepen van [InterruptionTokenSource::Interrupt()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/interrupt/) elke langdurige taak die aan die [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) is gekoppeld.

De volgende code‑fragment toont hoe een draaiende taak kan worden onderbroken:

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
    
    Run(action, tokenSource->get_Token()); // voer de actie uit in een aparte thread
    Threading::Thread::Sleep(10000);       // time‑out
    tokenSource->Interrupt();              // stop de conversie
}
```

## **FAQ**

**Wat is het doel van de Aspose.Slides-interruptiebibliotheek?**

Het biedt een mechanisme om langdurige bewerkingen—zoals het laden, opslaan of renderen van presentaties—onder te breken voordat ze voltooid zijn. Dit is nuttig wanneer de verwerkingstijd beperkt moet worden of de taak niet meer nodig is.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` wordt doorgegeven aan de Aspose.Slides‑API en gecontroleerd tijdens langdurige bewerkingen.
- `InterruptionTokenSource` wordt in uw code gebruikt om tokens te maken en onderbrekingen te activeren door `Interrupt()` aan te roepen.

**Welke taken kunnen worden onderbroken?**

Elke Aspose.Slides‑taak die een [InterruptionToken](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontoken/) accepteert—bijvoorbeeld het laden van een presentatie met `Presentation(path, loadOptions)` of het opslaan met `Presentation::Save(...)`—kan worden onderbroken.

**Gebeuren onderbrekingen onmiddellijk?**

Nee. Onderbreking is coöperatief: de bewerking controleert periodiek het token en stopt zodra wordt gedetecteerd dat [Interrupt()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/interrupt/) is aangeroepen.

**Wat gebeurt er als ik [Interrupt()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/interrupt/) aanroep nadat een taak al voltooid is?**

Geen effect—de aanroep heeft geen invloed als de betreffende taak al voltooid is.

**Kan ik dezelfde [InterruptionTokenSource](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/) opnieuw gebruiken voor meerdere taken?**

Ja—maar nadat u [Interrupt()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/interruptiontokensource/interrupt/) op die bron hebt aangeroepen, worden alle taken die haar tokens gebruiken onderbroken. Gebruik aparte token‑bronnen om taken onafhankelijk te beheren.