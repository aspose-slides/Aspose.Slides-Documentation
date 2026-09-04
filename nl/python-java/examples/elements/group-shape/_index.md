---
title: Groepsvorm
type: docs
weight: 170
url: /nl/python-java/examples/elements/group-shape/
keywords:
- codevoorbeeld
- groepsvorm
- groepsvorm toevoegen
- toegang tot groepsvorm
- groepsvorm verwijderen
- vormen ontgroeperen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer groepsvormen in presentaties met Aspose.Slides for Python via Java: voeg toe, krijg toegang tot, verwijder en ontgroepeer vormen in PowerPoint- en OpenDocument-bestanden."
---
Dit artikel laat zien hoe je groepen van vormen maakt, er toegang toe krijgt, ze verwijdert en de inhoud ervan ontgroepeert met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` vóór het starten van de JVM en importeert daarna de API wanneer de JVM draait.

## **Groepvorm toevoegen**

Maak een groep met twee basale vormen.

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

## **Toegang tot een groepsvorm**

Haal de eerste groepsvorm op van een dia.

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

## **Groepsvorm verwijderen**

Verwijder een groepsvorm van de dia.

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

## **Groepsvormen ontgroeperen**

Verplaats een vorm uit een groepscontainer.

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

    # Verplaats de vorm uit de groep.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```