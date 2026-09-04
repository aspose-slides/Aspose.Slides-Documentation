---
title: Connector
type: docs
weight: 190
url: /nl/python-java/examples/elements/connector/
keywords:
- codevoorbeeld
- connector
- connector toevoegen
- connector benaderen
- connector verwijderen
- vormen opnieuw verbinden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u vormen met connectoren kunt toevoegen, benaderen, verwijderen en opnieuw verbinden met behulp van Aspose.Slides for Python via Java in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe je vormen kunt verbinden met connectoren en hun doelpunten kunt wijzigen met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installatie](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API zodra de JVM draait.

## **Connector toevoegen**

Voeg een connectorvorm in tussen twee punten op de dia.

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

## **Connector benaderen**

Haal de eerste connectorvorm op die aan een dia is toegevoegd.

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

    # Toegang tot de eerste connector op de dia.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Connector verwijderen**

Verwijder een connector van de dia.

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

## **Vormen opnieuw verbinden**

Koppel een connector aan twee vormen door start- en einddoelen toe te wijzen.

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