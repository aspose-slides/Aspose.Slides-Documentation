---
title: Beheer diavoorstellingen in Python via Java
linktitle: Diavoorstelling
type: docs
weight: 90
url: /nl/python-java/manage-slide-show/
keywords:
- type voorstelling
- gepresenteerd door spreker
- bekeken door individu
- bekeken op kiosk
- voorstellingsopties
- doorlopend herhalen
- voorstelling zonder vertelling
- voorstelling zonder animatie
- penkleur
- dia's tonen
- aangepaste voorstelling
- dia's voortbewegen
- handmatig
- met timing
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u diavoorstellingen beheert in Aspose.Slides voor Python via Java. Controleer diaovergangen, timing en meer in PPT-, PPTX- en ODP-formaten met gemak."
---
## **Introductie**

De **Set Up Show**-opties van Microsoft PowerPoint stellen je in staat om het type voorstelling te kiezen, looping in te schakelen, dia's te selecteren en te bepalen hoe dia's worden voortbewogen. Met Aspose.Slides voor Python via Java kun je deze opties programmatisch configureren en opslaan in een presentatiebestand.

De [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlideShowSettings) methode retourneert een [SlideShowSettings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/) object dat deze opties beheert. De voorbeelden hieronder vereisen Aspose.Slides voor Python via Java en een compatibele Java-runtime. Elk voorbeeld start de JVM indien nodig en geeft de presentatie vrij wanneer het voltooid is.

## **Selecteer type voorstelling**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setSlideShowType) bepaalt het type diavoorstelling, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/python-java/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/browsedatkiosk/). Het gebruik van deze methode maakt het mogelijk om de presentatie aan te passen aan verschillende gebruiksscenario's, zoals geautomatiseerde kiosken of handmatige presentaties.

Het code-voorbeeld hieronder maakt een nieuwe presentatie aan en stelt het type voorstelling in op “Browsed by an individual” zonder de schuifbalk te tonen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Inschakelen van voorstellingsopties**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setLoop) bepaalt of de diavoorstelling in een lus moet worden herhaald totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowNarration) bepaalt of voice-narraties tijdens de diavoorstelling moeten worden afgespeeld. Dit is nuttig voor geautomatiseerde presentaties die spraakinstructies voor het publiek bevatten. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowAnimation) bepaalt of animaties die aan dia-objecten zijn toegevoegd, moeten worden afgespeeld. Dit is nuttig om het volledige visuele effect van de presentatie te leveren.

Het volgende code-voorbeeld maakt een nieuwe presentatie aan en laat de diavoorstelling herhalen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Selecteer dia's om te tonen**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setSlides) methode stelt je in staat om een bereik van dia's te selecteren die tijdens de presentatie getoond worden. Dit is handig wanneer je slechts een deel van de presentatie wilt laten zien in plaats van alle dia's. Het volgende code-voorbeeld maakt een presentatie met negen dia's en selecteert dia's 2 t/m 9. Het bereik gebruikt één-gebaseerde dia-nummers.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Maak negen dia's zodat het geselecteerde bereik bestaat.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controleer dia-voortgang**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setUseTimings) methode maakt het mogelijk om het gebruik van vooraf ingestelde timing per dia in of uit te schakelen. Dit is handig om dia's automatisch weer te geven met vooraf gedefinieerde weergaveduur. Het code-voorbeeld hieronder maakt een nieuwe presentatie aan en schakelt het gebruik van timing uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Media-bedieningsknoppen weergeven**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) methode bepaalt of mediabedieningen (zoals afspelen, pauzeren en stoppen) tijdens de diavoorstelling moeten worden weergegeven wanneer multimediacontent (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer je de presentator controle wilt geven over de weergave van media tijdens de presentatie.

Het volgende code-voorbeeld maakt een nieuwe presentatie aan en schakelt het weergeven van mediabedieningen in.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een presentatie opslaan zodat deze direct in diavoorstellingsmodus opent?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten starten direct in diavoorstelling wanneer ze in PowerPoint worden geopend. In Aspose.Slides selecteer je het overeenkomstige opslagformaat[tijdens export](/slides/nl/python-java/save-presentation/).

**Kan ik individuele dia's uitsluiten van de voorstelling zonder ze te verwijderen uit het bestand?**

Ja. Markeer een dia als [verborgen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setHidden). Verborgen dia's blijven in de presentatie, maar worden niet getoond tijdens de diavoorstelling.

**Kan Aspose.Slides een diavoorstelling afspelen of een livepresentatie op het scherm beheren?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt afgehandeld door een viewer-applicatie zoals PowerPoint.