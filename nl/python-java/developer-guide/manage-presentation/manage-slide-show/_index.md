---
title: Beheer diavoorstellingen in Python via Java
linktitle: Diavoorstelling
type: docs
weight: 90
url: /nl/python-java/manage-slide-show/
keywords:
- showtype
- gepresenteerd door spreker
- bekeken door individu
- bekeken op kiosk
- showopties
- continue herhalen
- show zonder vertelling
- show zonder animatie
- penkleur
- toon dia's
- aangepaste show
- dia's vooruit
- handmatig
- met timings
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u diavoorstellingen kunt beheren in Aspose.Slides voor Python via Java. Beheer dia-overgangen, timing en meer in PPT-, PPTX- en ODP-formats met gemak."
---
## **Inleiding**

Microsoft PowerPoint's **Set Up Show**-opties laten u het showtype kiezen, looping inschakelen, dia's selecteren en bepalen hoe dia's worden voortgezet. Met Aspose.Slides for Python via Java kunt u deze opties programmatisch configureren en opslaan in een presentatiebestand.

De [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSlideShowSettings) methode retourneert een [SlideShowSettings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/) object dat deze opties beheert. De onderstaande voorbeelden vereisen Aspose.Slides for Python via Java en een compatibele Java-runtime. Elk voorbeeld start de JVM indien nodig en maakt de presentatie vrij wanneer deze is voltooid.

## **Selecteer showtype**

De [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setSlideShowType) definieert het type diavoorstelling, dat een instantie kan zijn van de volgende klassen: [PresentedBySpeaker](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nl/python-java/aspose.slides/browsedbyindividual/), of [BrowsedAtKiosk](https://reference.aspose.com/slides/nl/python-java/aspose.slides/browsedatkiosk/). Het gebruik van deze methode stelt u in staat de presentatie aan te passen aan verschillende gebruiksscenario's, zoals geautomatiseerde kiosken of handmatige presentaties.

Het code‑voorbeeld hieronder maakt een nieuwe presentatie en stelt het showtype in op “Browsed by an individual” zonder de schuifbalk weer te geven.

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

## **Schakel showopties in**

De [SlideShowSettings.setLoop](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setLoop) bepaalt of de diavoorstelling moet herhalen in een lus totdat deze handmatig wordt gestopt. Dit is handig voor geautomatiseerde presentaties die continu moeten draaien. De [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowNarration) bepaalt of stemvertellingen moeten worden afgespeeld tijdens de diavoorstelling. Het is nuttig voor geautomatiseerde presentaties die spraakbegeleiding voor het publiek bevatten. De [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowAnimation) bepaalt of animaties die aan dia‑objecten zijn toegevoegd moeten worden afgespeeld. Dit is handig om het volledige visuele effect van de presentatie te bieden.

Het volgende code‑voorbeeld maakt een nieuwe presentatie en laat de diavoorstelling herhalen.

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

De [SlideShowSettings.setSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setSlides) methode stelt u in staat een bereik van dia's te selecteren die tijdens de presentatie worden getoond. Dit is handig wanneer u slechts een deel van de presentatie wilt tonen in plaats van alle dia's. Het volgende code‑voorbeeld maakt een presentatie met negen dia's en selecteert dia's 2 tot en met 9. Het bereik gebruikt één‑gebaseerde dia‑nummers.

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

## **Beheer dia‑voortgang**

De [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setUseTimings) methode stelt u in staat het gebruik van vooraf ingestelde timing voor elke dia in of uit te schakelen. Dit is handig om dia's automatisch te tonen met vooraf gedefinieerde weergaveduur. Het code‑voorbeeld hieronder maakt een nieuwe presentatie en schakelt het gebruik van timing uit.

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

## **Toon mediabedieningen**

De [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) methode bepaalt of mediabedieningen (zoals afspelen, pauzeren en stoppen) moeten worden weergegeven tijdens de diavoorstelling wanneer multimedia‑inhoud (bijv. video of audio) wordt afgespeeld. Dit is handig wanneer u de presentator controle wilt geven over het afspelen van media tijdens de presentatie.

Het volgende code‑voorbeeld maakt een nieuwe presentatie en schakelt weergeven van mediabedieningen in.

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

## **Veelgestelde vragen**

**Kan ik een presentatie opslaan zodat deze direct in de diavoorstellingsmodus wordt geopend?**

Ja. Sla het bestand op als PPSX of PPSM; deze formaten worden direct in de diavoorstellingsmodus gestart wanneer ze in PowerPoint worden geopend. In Aspose.Slides kiest u het overeenkomstige opslagformaat [tijdens export](/slides/nl/python-java/save-presentation/).

**Kan ik individuele dia's uitsluiten van de show zonder ze uit het bestand te verwijderen?**

Ja. Markeer een dia als [hidden](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#setHidden). Verborgen dia's blijven in de presentatie, maar worden niet getoond tijdens de diavoorstelling.

**Kan Aspose.Slides een diavoorstelling afspelen of een livepresentatie op het scherm regelen?**

Nee. Aspose.Slides bewerkt, analyseert en converteert presentatiebestanden; de daadwerkelijke weergave wordt verzorgd door een viewer‑applicatie zoals PowerPoint.