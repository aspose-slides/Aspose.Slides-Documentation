---
title: Spojka
type: docs
weight: 190
url: /cs/python-java/examples/elements/connector/
keywords:
- příklad kódu
- spojka
- přidat spojku
- přístup ke spojce
- odstranit spojku
- znovu propojit tvary
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro Python via Java přidávat, přistupovat, odstraňovat a znovu propojit tvary se spojkami v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje, jak propojit tvary pomocí spojnic a změnit jejich cíle pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat spojku**

Vložte tvar spoje mezi dva body na snímku.

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

## **Přístup ke spojce**

Získejte první tvar spoje přidaný do snímku.

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

    # Přístup k prvnímu spojce na snímku.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Odstranit spojku**

Odstraňte spojku ze snímku.

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

## **Znovu propojit tvary**

Připojte spojku ke dvěma tvarům přiřazením počátečního a koncového cíle.

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