---
title: Ondersteuning voor een onderbreekbare bibliotheek
type: docs
weight: 120
url: /nl/python-java/support-for-interruptable-library/
keywords:
- onderbreekbare bibliotheek
- onderbrekingstoken
- annuleringstoken
- langdurige taak
- taak onderbreken
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak langdurige taken annuleerbaar met Aspose.Slides for Python via Java. Onderbreek veilig het renderen en de conversies voor PowerPoint en OpenDocument, met voorbeelden."
---
## **Overzicht**

Aspose.Slides biedt een onderbreekbaar verwerkingsmechanisme voor langdurige presentatietaken, zoals deserialisatie, serialisatie en rendering. Dit mechanisme is gebaseerd op de [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/) klassen.

Een [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) kan worden toegewezen aan [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) en doorgegeven aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/). Wanneer [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) wordt aangeroepen, wordt de bijbehorende langdurige taak onderbroken.

## **Onderbreekbare bibliotheek**

Aspose.Slides for Python via Java biedt de [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/) klassen. Ze stellen u in staat om langdurige taken, zoals deserialisatie, serialisatie en rendering, te onderbreken.

- [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/) is de bron van de token(s) die worden doorgegeven aan [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Wanneer [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/#setInterruptionToken) wordt aangeroepen en de [LoadOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/loadoptions/) instantie wordt doorgegeven aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/), onderbreekt het aanroepen van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) elke langdurige taak die aan die [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) is gekoppeld.

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Voer de actie uit in een aparte thread.
    time.sleep(10)  # Time-out.
    token_source.interrupt()  # Stop de conversie.
    conversion_task.result()
```

## **FAQ**

**Wat is het doel van de Aspose.Slides onderbreekbibliotheek?**

Het biedt een mechanisme om langdurige bewerkingen — zoals het laden, opslaan of renderen van presentaties — te onderbreken voordat ze voltooid zijn. Dit is handig wanneer de verwerkingstijd beperkt moet worden of de taak niet meer nodig is.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) wordt doorgegeven aan de Aspose.Slides API en tijdens langdurige bewerkingen gecontroleerd.
- [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/) wordt in uw code gebruikt om tokens te maken en onderbrekingen te activeren door [interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) aan te roepen.

**Welke taken kunnen worden onderbroken?**

Elke Aspose.Slides-taak die een [InterruptionToken](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontoken/) accepteert — bijvoorbeeld het laden van een presentatie met [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) of het opslaan met [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) — kan worden onderbroken.

**Wordt onderbreking onmiddellijk uitgevoerd?**

Nee. Onderbreking is coöperatief: de operatie controleert periodiek het token en stopt zodra wordt gedetecteerd dat [interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) is aangeroepen.

**Wat gebeurt er als ik [interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) aanroep nadat een taak al is voltooid?**

Niets — de aanroep heeft geen effect als de betreffende taak al is voltooid.

**Kan ik dezelfde [InterruptionTokenSource](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/) voor meerdere taken hergebruiken?**

Ja — maar nadat u [interrupt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/interruptiontokensource/#interrupt) op die bron aanroept, worden alle taken die zijn tokens gebruiken onderbroken. Gebruik afzonderlijke tokenbronnen om taken onafhankelijk te beheren.