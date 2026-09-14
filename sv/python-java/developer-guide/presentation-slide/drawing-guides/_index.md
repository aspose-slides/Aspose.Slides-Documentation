---
title: Hantera ritningsguider i presentationer i Python
linktitle: Ritningsguider
type: docs
weight: 85
url: /sv/python-java/drawing-guides/
keywords:
- ritningsguide
- horisontell guide
- vertikal guide
- justeringsguide
- bildvy
- masterbild
- layoutbild
- anteckningsmaster
- utdelningsmaster
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lägg till, hämta och rensa horisontella och vertikala ritningsguider i PowerPoint-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Ritningsguider är justerbara horisontella och vertikala linjer som hjälper användare att justera former konsekvent medan de redigerar en presentation i PowerPoint. De är särskilt användbara när en applikation genererar en presentation som senare ska finjusteras manuellt: applikationen kan spara samma justeringshjälpmedel som författare bör följa när de lägger till eller flyttar innehåll.

Ritningsguider är hjälpmedel för redigering, inte bildinnehåll. De visas inte i en bildspelsvisa eller renderad output. Aspose.Slides for Python via Java exponerar dem via klassen [DrawingGuidesCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/). En guide representeras av [DrawingGuide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguide/) och har en orientering, en position och en färg.

Positionen mäts i punkter från det övre vänstra hörnet på den aktuella bilden eller masteren. En vertikal guide använder en horisontell koordinat, vanligtvis mellan noll och bildens bredd. En horisontell guide använder en vertikal koordinat, vanligtvis mellan noll och bildens höjd.

## **Lägg till guider i bildvyn**

Använd [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) för att hantera guider som visas under redigering av vanliga bilder. Anropa [DrawingGuidesCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/#add) med ett [Orientation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/orientation/)‑värde och en position i punkter.

Följande exempel lägger till en vertikal guide till höger om bildens centrum och en horisontell guide nedanför den:

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

## **Åtkomst till ritningsguider**

Metoderna [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/#getCount) och [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/#get_Item) ger åtkomst till befintliga guider. Metoderna [DrawingGuide.getOrientation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguide/#getPosition) och [DrawingGuide.getColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguide/#getColor) returnerar värden som också kan ändras via motsvarande setter‑metoder.

Följande exempel läser bildvyguidarna från presentationen som skapades ovan:

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

## **Lägg till guider i master‑ och layoutbilder**

En slide‑master och var och en av dess layoutbilder kan ha sina egna samlingar av ritningsguider. Använd [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/#getDrawingGuides) för en master‑bild och [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/layoutslide/#getDrawingGuides) för en layout‑bild.

Följande exempel lägger till en vertikal guide till den första master‑bilden och en horisontell guide till den första layout‑bilden:

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

## **Lägg till guider i antecknings‑ och utdelnings‑masters**

Antecknings‑masters och utdelnings‑masters stödjer också ritningsguider. Använd [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masternotesslide/#getDrawingGuides) och [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) för att komma åt deras samlingar. Om en presentation inte innehåller någon av dessa masters skapar `MasterNotesSlideManager.setDefaultMasterNotesSlide` eller `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` standard‑mastern och returnerar den.

Följande exempel lägger till en horisontell guide till en antecknings‑master och en vertikal guide till en utdelnings‑master:

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

## **Rensa ritningsguider**

Anropa [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/#clear) för att ta bort varje guide från en viss samling. Att rensa en samling påverkar inte guider som lagras i ett annat område.

Följande exempel rensar bildvyguiden och alla guider på slide‑masters, layout‑bilder, antecknings‑mastern och utdelnings‑mastern utan att skapa saknade masters:

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

**Visas ritningsguider i ett bildspel eller exporterade bilder?**

Nej. Ritningsguider är justeringshjälpmedel för redigering och renderas inte som presentationsinnehåll.

**Kan en ritningsguide läggas till direkt på en enskild normal bild?**

Redigeringsguider för normal‑bild lagras i presentationens slide‑view‑egenskaper. Separata guidsamlingar finns för slide‑masters, layout‑bilder, antecknings‑masters och utdelnings‑masters.

**Vilka enheter används för guidpositioner?**

Positioner anges i punkter, där 72 punkter motsvarar en tum. Vertikala positioner mäts från vänstra kanten och horisontella positioner mäts från överkanten.

**Tar rensning av ritningsguider bort former eller ändrar bildinnehåll?**

Nej. Metoden [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/drawingguidescollection/#clear) tar bara bort guiderna i den valda samlingen. Former och annat bildinnehåll förblir oförändrat.