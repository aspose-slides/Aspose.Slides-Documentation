---
title: Gruppform
type: docs
weight: 170
url: /sv/python-java/examples/elements/group-shape/
keywords:
- kodexempel
- gruppform
- lägg till gruppform
- åtkomst till gruppform
- ta bort gruppform
- avgruppera former
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera gruppformer i presentationer med Aspose.Slides för Python via Java: lägg till, få åtkomst till, ta bort och avgruppera former i PowerPoint- och OpenDocument-filer."
---
Den här artikeln visar hur du skapar grupper av former, får åtkomst till dem, tar bort dem och avgrupperar deras innehåll med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två enkla former.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50)
finally:
    presentation.dispose()
```

## **Få åtkomst till en gruppform**

Hämta den första gruppformen från en bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    first_group = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, GroupShape):
            first_group = shape
            break
finally:
    presentation.dispose()
```

## **Ta bort en gruppform**

Radera en gruppform från bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()

    slide.getShapes().remove(group)
finally:
    presentation.dispose()
```

## **Avgruppera former**

Flytta en form ur en gruppbehållare.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    group = slide.getShapes().addGroupShape()
    rectangle = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)

    # Flytta formen ur gruppen.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```