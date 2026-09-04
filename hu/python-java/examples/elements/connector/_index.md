---
title: Csatlakozó
type: docs
weight: 190
url: /hu/python-java/examples/elements/connector/
keywords:
- kódpélda
- csatlakozó
- csatlakozó hozzáadása
- csatlakozó elérése
- csatlakozó eltávolítása
- alakzatok újrakapcsolása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tudja meg, hogyan lehet csatlakozókkal alakzatokat hozzáadni, elérni, eltávolítani és újból összekapcsolni az Aspose.Slides for Python via Java segítségével PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja, hogyan lehet összekötni alakzatokat csatlakozókkal és megváltoztatni a célpontjaikat az **Aspose.Slides for Python via Java** használatával.

Telepítse a csomagot a [Installation](/slides/hu/python-java/installation/) útmutató szerint. Minden példa a JVM indítása előtt importálja a `asposeslides`‑t, majd a JVM futása közben importálja az API‑t.

## **Csatlakozó hozzáadása**

Illesszen be egy csatlakozó alakzatot a diáron két pont között.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)
finally:
    presentation.dispose()
```

## **Csatlakozó elérése**

Hozza elő az elsőként a diára hozzáadott csatlakozó alakzatot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # A dián lévő első csatlakozó elérése.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Csatlakozó eltávolítása**

Törölje a csatlakozót a diáról.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    slide.getShapes().remove(connector)
finally:
    presentation.dispose()
```

## **Alakzatok újbóli összekapcsolása**

Csatlakoztassa a csatlakozót két alakzathoz a kezdeti és végpont célpontok beállításával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    connector.setStartShapeConnectedTo(shape1)
    connector.setEndShapeConnectedTo(shape2)
finally:
    presentation.dispose()
```