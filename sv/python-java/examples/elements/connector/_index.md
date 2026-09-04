---
title: Koppling
type: docs
weight: 190
url: /sv/python-java/examples/elements/connector/
keywords:
- kodexempel
- anslutning
- lägg till anslutning
- åtkomst till anslutning
- ta bort anslutning
- återanslut former
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till, får åtkomst till, tar bort och återansluter former med anslutningar med hjälp av Aspose.Slides för Python via Java i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du kopplar samman former med anslutningar och ändrar deras mål med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:t efter att JVM körs.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

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

## **Åtkomst till en anslutning**

Hämta den första anslutningsformen som lagts till på en bild.

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

    # Åtkomst till den första anslutningen på bilden.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Ta bort en anslutning**

Ta bort en anslutning från bilden.

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

## **Återanslut former**

Fäst en anslutning till två former genom att tilldela start- och slutmål.

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