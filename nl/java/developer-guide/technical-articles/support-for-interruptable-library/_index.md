---
title: Ondersteuning voor onderbreekbare bibliotheek
type: docs
weight: 120
url: /nl/java/support-for-interruptable-library/
keywords:
- onderbreekbare bibliotheek
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- taak onderbreken
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Maak langlopende taken annuleerbaar met Aspose.Slides voor Java. Onderbreek het renderen en de conversies voor PowerPoint en OpenDocument veilig, met voorbeelden."
---
## **Overzicht**

Aspose.Slides biedt een onderbreekbare verwerkingsmechanisme voor langdurige presentatietaken, zoals deserialisatie, serialisatie en rendering. Dit mechanisme is gebaseerd op de `InterruptionToken`- en `InterruptionTokenSource`-klassen.

Een `InterruptionToken` kan toegewezen worden aan `LoadOptions` en doorgegeven aan de `Presentation`‑constructor. Wanneer `InterruptionTokenSource.interrupt()` wordt aangeroepen, wordt de bijbehorende langdurige taak onderbroken.

## **Onderbreekbare bibliotheek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/nl/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), hebben we de klassen [InterruptionToken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/) geïntroduceerd. Ze stellen u in staat om langdurige taken, zoals deserialisatie, serialisatie en rendering, te onderbreken.

- [InterruptionTokenSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/) is de bron van de token(s) die worden doorgegeven aan [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Wanneer [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) is ingesteld en de [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/)‑instantie wordt doorgegeven aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑constructor, onderbreekt het aanroepen van [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/#interrupt--) elke langdurige taak die aan die [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) is gekoppeld.

De volgende codefragment toont hoe een lopende taak onderbroken kan worden:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // voer de actie uit in een aparte thread
Thread.sleep(10000);     // tijdslimiet
tokenSource.interrupt(); // stop de conversie
```

## **FAQ**

**Wat is het doel van de Aspose.Slides onderbreekbibliotheek?**

Het biedt een mechanisme om langdurige bewerkingen—zoals het laden, opslaan of renderen van presentaties—onder te breken voordat ze voltooid zijn. Dit is handig wanneer de verwerkingstijd beperkt moet worden of de taak niet langer nodig is.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` wordt doorgegeven aan de Aspose.Slides‑API en tijdens langdurige bewerkingen gecontroleerd.
- `InterruptionTokenSource` wordt in uw code gebruikt om tokens aan te maken en onderbrekingen te activeren door `Interrupt()` aan te roepen.

**Welke taken kunnen worden onderbroken?**

Elke Aspose.Slides‑taak die een [InterruptionToken](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontoken/) accepteert—zoals het laden van een presentatie met `Presentation(path, loadOptions)` of opslaan met `Presentation.save(...)`—kan onderbroken worden.

**Wordt onderbreking direct uitgevoerd?**

Nee. Onderbreking is coöperatief: de bewerking controleert periodiek de token en stopt zodra wordt geconstateerd dat [Interrupt()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/#interrupt--) is aangeroepen.

**Wat gebeurt er als ik [Interrupt()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/#interrupt--) aanroep nadat een taak al voltooid is?**

Niets—de aanroep heeft geen effect als de betreffende taak al voltooid is.

**Kan ik dezelfde [InterruptionTokenSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/) hergebruiken voor meerdere taken?**

Ja—maar nadat u [Interrupt()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/interruptiontokensource/#interrupt--) op die bron hebt aangeroepen, zullen alle taken die zijn tokens gebruiken worden onderbroken. Gebruik afzonderlijke token‑bronnen om taken onafhankelijk te beheren.