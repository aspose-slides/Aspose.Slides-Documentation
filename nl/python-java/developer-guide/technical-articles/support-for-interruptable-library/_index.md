---
title: Onderbreek langlopende presentatiebewerkingen in Python
linktitle: Onderbreek presentatiebewerkingen
type: docs
weight: 120
url: /nl/python-java/support-for-interruptable-library/
keywords:
- onderbreekbare bewerkingen
- onderbrekingstoken
- annuleringstoken
- langlopende taak
- onderbreek taak
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u langlopende presentatiebewerkingen in Aspose.Slides voor Python via Java kunt annuleren en een gedeeltelijk resultaat kunt retourneren bij het exporteren van dia's in een lus."
---
## **Overzicht**

Aspose.Slides for Python via Java kan langlopende bewerkingen zoals het laden, opslaan en renderen van presentaties onderbreken. Uw toepassing kan dezelfde interruption‑token gebruiken om een lus te stoppen voordat deze de volgende dia verwerkt.

## **Een presentatie‑bewerking onderbreken**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), verkrijg de token met [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) en geef de token door aan [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Geef de load‑opties door aan de [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Om annulering aan te vragen, roep [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) aan op de bron. Een onderbreekbare bewerking stopt wanneer hij het verzoek waarneemt. Gebruik `jpype.JClass` om de Java‑exceptie `com.aspose.slides.exceptions.OperationCanceledException` in Python af te vangen.

Het voorbeeld converteert `sample.pptx` naar `sample.ppt` op een achtergrondthread. De aanroepende thread wacht tot 10 seconden op het voltooien van de conversie. Als de conversie nog steeds draait, vraagt hij annulering aan en wacht tot de worker stopt.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Een Python‑timeout verbinden met Aspose.Slides**

Om een tijdslimiet op een presentatie‑bewerking in te stellen, gebruik een [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) om [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) aan te roepen wanneer de timeout verloopt. Het voorbeeld staat 20 seconden toe om `sample.pptx` te laden en te exporteren naar `sample.pdf`. Als de export eerder klaar is, annuleert de toepassing het geplande verzoek.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Stoppen vóór het verwerken van de volgende dia**

Gebruik dezelfde [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) voor de presentatie en de lus die haar dia’s exporteert. Controleer [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) vóór elke export. Als de aanroeper een gedeeltelijk resultaat kan gebruiken, retourneer dan de dia‑nummers van de exporten die succesvol zijn voltooid.

Gebruik een presentatie met de naam `sample.pptx` met ten minste twee dia’s. De overload van [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) die een Java `int[]` accepteert, gebruikt dia‑nummers beginnend bij 1. Gebruik `jpype.JArray(jpype.JInt)` om die array in Python op te bouwen. Het voorbeeld slaat elke dia op als een apart PDF‑bestand en vraagt onmiddellijk na de eerste succesvolle export om annulering.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Het voorbeeld schrijft `slide-1.pdf` en toont `Starting slide 1` gevolgd door `Completed: [1]`. De lus merkt het verzoek op voordat dia 2 wordt gestart. Als annulering tijdens een opslaan binnenkomt, verlaat de lus de lus voordat die dia als voltooid wordt gemarkeerd.

Als de aanroeper annulering moet verwerken, vervang dan de controle en de `break` aan het begin van de lus door `token.throwIfInterruptionRequested()`. Verwijder de `try`/`except` rond het opslaan zodat annulering tijdens een export ook de aanroeper bereikt. Met dezelfde invoer toont het voorbeeld alleen `Starting slide 1` en schrijft `slide-1.pdf`. Aan het begin van de tweede iteratie werpt [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) `com.aspose.slides.exceptions.OperationCanceledException` voordat de volgende export start. De exceptie wordt naar de aanroeper doorgegeven voordat de functie de lijst kan retourneren.

## **FAQ**

**Wanneer moet ik een annuleringsverzoek indienen?**

Vraag annulering aan wanneer een bewerking uw tijdslimiet overschrijdt of wanneer uw toepassing het resultaat niet meer nodig heeft.

**Wat is het verschil tussen [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) en [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

De bron laat uw toepassing een annuleringsverzoek indienen. De token laat Aspose.Slides en uw toepassing dat verzoek controleren.

**Kan ik een bewerking annuleren vanuit een Python‑timer?**

Ja. Plan een oproep naar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) op de bron die aan de presentatie is gekoppeld.

**Welke bewerkingen kan ik onderbreken?**

U kunt het laden, opslaan en renderen onderbreken. Geef de token door aan de [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) via [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). De presentatie kan dan tijdens latere bewerkingen, zoals opslaan naar PDF, annulering waarnemen.

**Stopt een bewerking onmiddellijk?**

Annulering is coöperatief. Een bewerking controleert periodiek de token en stopt wanneer hij het verzoek waarneemt.

**Wat gebeurt er als ik [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) aanroep nadat een bewerking is voltooid?**

De voltooide bewerking behoudt zijn resultaat.

**Kunnen meerdere bewerkingen een [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/) delen?**

Ja. Het aanroepen van [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) vraagt annulering voor elke bewerking die een token van die bron gebruikt. Gebruik een aparte bron voor elke bewerking die u onafhankelijk wilt kunnen annuleren.