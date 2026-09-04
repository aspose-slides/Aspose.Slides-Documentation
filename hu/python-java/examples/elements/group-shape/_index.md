---
title: Csoportos alakzat
type: docs
weight: 170
url: /hu/python-java/examples/elements/group-shape/
keywords:
- kódpélda
- csoportos alakzat
- csoportos alakzat hozzáadása
- csoportos alakzat elérése
- csoportos alakzat eltávolítása
- alakzatcsoport felbontása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Csoportos alakzatok kezelése prezentációkban az Aspose.Slides for Python via Java segítségével: csoportos alakzatok hozzáadása, elérése, eltávolítása és felbontása PowerPoint és OpenDocument fájlokban."
---
Ez a cikk bemutatja, hogyan hozhatók létre alakzatcsoportok, hogyan érhetők el, hogyan távolíthatók el, és hogyan bonthatók fel a tartalmuk a **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a `asposeslides` modult importálja a JVM indítása előtt, majd a JVM futása közben importálja az API-t.

## **Csoportos alakzat hozzáadása**

Hozzon létre egy csoportot, amely két alap alakzatot tartalmaz.

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

## **Csoportos alakzat elérése**

Nyújtsa le az első csoportos alakzatot a diáról.

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

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

## **Csoportos alakzat eltávolítása**

Törölje a csoportos alakzatot a diáról.

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

## **Alakzatcsoport felbontása**

Mozgassa ki az alakzatot a csoportkapszulából.

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

    # Áthelyezi az alakzatot a csoportból.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```