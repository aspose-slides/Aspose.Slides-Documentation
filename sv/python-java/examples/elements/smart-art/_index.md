---
title: SmartArt
type: docs
weight: 140
url: /sv/python-java/examples/elements/smart-art/
keywords:
- kodexempel
- SmartArt
- lägga till SmartArt
- komma åt SmartArt
- ta bort SmartArt
- SmartArt-layout
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Arbeta med SmartArt i Aspose.Slides för Python via Java: lägga till, komma åt, ta bort och ändra diagramlayouter i PowerPoint- och OpenDocument-presentationer."
---
Den här artikeln demonstrerar hur man lägger till SmartArt-grafik, får åtkomst till dem, tar bort dem och ändrar layouter med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar API:n efter att JVM körs.

## **Lägg till SmartArt**

Infoga en SmartArt-grafik med hjälp av en av de inbyggda layouterna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)
finally:
    presentation.dispose()
```

## **Kom åt SmartArt**

Hämta det första SmartArt-objektet på en bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    first_smart_art = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, SmartArt):
            first_smart_art = shape
            break
finally:
    presentation.dispose()
```

## **Ta bort SmartArt**

Ta bort en SmartArt-form från bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess)

    slide.getShapes().remove(smart_art)
finally:
    presentation.dispose()
```

## **Ändra SmartArt‑layout**

Uppdatera layouttypen för en befintlig SmartArt-grafik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.VerticalPictureList)
finally:
    presentation.dispose()
```