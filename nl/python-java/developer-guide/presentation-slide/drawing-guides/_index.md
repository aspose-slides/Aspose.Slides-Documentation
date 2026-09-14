---
title: Beheer tekenrichtlijnen in presentaties in Python
linktitle: Tekenrichtlijnen
type: docs
weight: 85
url: /nl/python-java/drawing-guides/
keywords:
- tekenrichtlijn
- horizontale richtlijn
- verticale richtlijn
- uitlijningsrichtlijn
- diaweergave
- masterdia
- lay-outdia
- notitiemaster
- handout‑master
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Voeg horizontale en verticale tekenrichtlijnen toe, benader ze en maak ze leeg in PowerPoint‑presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Tekenrichtlijnen zijn verstelbare horizontale en verticale lijnen die gebruikers helpen vormen consistent uit te lijnen tijdens het bewerken van een presentatie in PowerPoint. Ze zijn vooral handig wanneer een toepassing een presentatie genereert die later handmatig moet worden verfijnd: de toepassing kan dezelfde uitlijningshulpmiddelen opslaan die auteurs moeten volgen bij het toevoegen of verplaatsen van inhoud.

Tekenrichtlijnen zijn bewerkingstools, geen dia‑inhoud. Ze verschijnen niet in een diavoorstelling of in gerenderde uitvoer. Aspose.Slides for Python via Java maakt ze beschikbaar via de [DrawingGuidesCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/)‑klasse. Een richtlijn wordt weergegeven door [DrawingGuide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguide/) en heeft een oriëntatie, een positie en een kleur.

De positie wordt gemeten in punten vanaf de linkerbovenhoek van de betreffende dia of master. Een verticale richtlijn gebruikt een horizontale coördinaat, meestal tussen nul en de breedte van de dia. Een horizontale richtlijn gebruikt een verticale coördinaat, meestal tussen nul en de hoogte van de dia.

## **Richtlijnen toevoegen aan de diaweergave**

Gebruik [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) om richtlijnen te beheren die tijdens het bewerken van normale dia's worden weergegeven. Roep [DrawingGuidesCollection.add](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/#add) aan met een [Orientation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/orientation/)-waarde en een positie in punten.

Het volgende voorbeeld voegt één verticale richtlijn toe rechts van het midden van de dia en één horizontale richtlijn eronder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekenrichtlijnen benaderen**

De methoden [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/#getCount) en [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/#get_Item) geven toegang tot bestaande richtlijnen. De methoden [DrawingGuide.getOrientation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguide/#getPosition) en [DrawingGuide.getColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguide/#getColor) retourneren waarden die ook kunnen worden gewijzigd via de bijbehorende setter‑methoden.

Het volgende voorbeeld leest de richtlijnen in de diaweergave uit de presentatie die hierboven is aangemaakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Richtlijnen toevoegen aan master‑ en lay-outdia's**

Een master‑dia en elk van zijn lay‑outdia’s kunnen hun eigen collecties tekenrichtlijnen hebben. Gebruik [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/#getDrawingGuides) voor een master‑dia en [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/layoutslide/#getDrawingGuides) voor een lay‑outdia.

Het volgende voorbeeld voegt een verticale richtlijn toe aan de eerste master‑dia en een horizontale richtlijn aan de eerste lay‑outdia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Richtlijnen toevoegen aan notitie‑ en handout‑masters**

Notitiemasters en handout‑masters ondersteunen ook tekenrichtlijnen. Gebruik [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masternotesslide/#getDrawingGuides) en [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) om hun collecties te benaderen. Als een presentatie geen van deze masters bevat, maakt `MasterNotesSlideManager.setDefaultMasterNotesSlide` of `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` de standaard‑master aan en retourneert deze.

Het volgende voorbeeld voegt een horizontale richtlijn toe aan een notitiemaster en een verticale richtlijn aan een handout‑master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekenrichtlijnen wissen**

Roep [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/#clear) aan om alle richtlijnen uit een bepaalde collectie te verwijderen. Het wissen van één collectie heeft geen invloed op richtlijnen die in een andere scope zijn opgeslagen.

Het volgende voorbeeld wist de richtlijnen in de diaweergave en alle richtlijnen op dia‑masters, lay‑outdia’s, de notitiemaster en de handout‑master zonder ontbrekende masters aan te maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Worden tekenrichtlijnen weergegeven in een diavoorstelling of geëxporteerde afbeeldingen?**

Nee. Tekenrichtlijnen zijn uitlijningshulpmiddelen voor bewerking en worden niet gerenderd als presentatiedeling.

**Kan een tekenrichtlijn rechtstreeks aan een individuele normale dia worden toegevoegd?**

Normale‑dia‑bewerkingsrichtlijnen worden opgeslagen in de diaweergave‑eigenschappen van de presentatie. Er zijn aparte richtlijncollecties beschikbaar voor dia‑masters, lay‑outdia’s, notitiemasters en handout‑masters.

**Welke eenheden worden gebruikt voor de posities van richtlijnen?**

Posities worden opgegeven in punten, waarbij 72 punten gelijk is aan één inch. Verticale posities worden gemeten vanaf de linkerrand, en horizontale posities vanaf de bovenzijde.

**Verwijdert het wissen van tekenrichtlijnen vormen of verandert het de dia‑inhoud?**

Nee. De methode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/drawingguidescollection/#clear) verwijdert alleen de richtlijnen in de geselecteerde collectie. Vormen en andere dia‑inhoud blijven ongewijzigd.