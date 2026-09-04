---
title: Layout Slide
type: docs
weight: 20
url: /sv/python-java/examples/elements/layout-slide/
keywords:
- kodexempel
- layoutbild
- lägg till layoutbild
- åtkomst till layoutbild
- ta bort layoutbild
- oanvänd layoutbild
- klona layoutbild
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera layoutbilder med Aspose.Slides för Python via Java: lägga till, komma åt, ta bort, rensa och klona layouter i PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln visar hur du arbetar med **layoutbilder** med Aspose.Slides för Python via Java. En layoutbild definierar designen och formateringen som ärvs av vanliga bilder. Du kan lägga till, komma åt, klona och ta bort layoutbilder, samt rensa bort oanvända för att minska presentationens storlek.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar API:et efter att JVM körs.

## **Lägg till en layoutbild**

Skapa en anpassad layoutbild för att definiera återanvändbar formatering. Följande exempel lägger till en textruta i en ny layout och skapar sedan två bilder som använder den.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Skapa en layoutbild med en tom layouttyp och ett anpassat namn.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Lägg till en textruta i layoutbilden.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Lägg till två bilder som ärver texten från layouten.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Obs 1:** Layoutbilder fungerar som mallar för enskilda bilder. Du kan definiera gemensamma element en gång och återanvända dem i många bilder.
> 
> 💡 **Obs 2:** När du lägger till former eller text i en layoutbild visas det delade innehållet automatiskt i alla bilder som är baserade på den layouten.  
> Skärmbilden nedan visar två bilder som ärver en textruta från samma layoutbild.

![Bilder som ärver layoutinnehåll](layout-slide-result.png)

## **Kom åt en layoutbild**

Kom åt layoutbilder med index eller efter layouttyp, till exempel tom, titel eller sektionsrubrik.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Åtkomst till en layoutbild efter index.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Åtkomst till en layoutbild efter typ.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Ta bort en layoutbild**

Ta bort en specifik layoutbild när den inte längre behövs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Ta bort oanvända layoutbilder**

Ta bort layoutbilder som inte används av någon vanlig bild för att minska presentationens storlek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Klona en layoutbild**

Duplicera en layoutbild och lägg till kopian i slutet av samlingen av layoutbilder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Sammanfattning:** Layoutbilder hjälper till att behålla en enhetlig formatering i en presentation. Aspose.Slides låter dig skapa, hantera, återanvända och rensa upp layouter vid behov.