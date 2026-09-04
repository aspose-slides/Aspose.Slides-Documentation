---
title: Verbindungsstück
type: docs
weight: 190
url: /de/python-java/examples/elements/connector/
keywords:
- Codebeispiel
- Verbindungsstück
- Verbindungsstück hinzufügen
- Verbindungsstück zugreifen
- Verbindungsstück entfernen
- Formen erneut verbinden
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen mit Verbindungsstücken hinzufügen, darauf zugreifen, entfernen und erneut verbinden, indem Sie Aspose.Slides für Python via Java in PPT-, PPTX- und ODP-Präsentationen verwenden."
---
Dieser Artikel demonstriert, wie man Formen mit Verbindungsstücken verbindet und deren Ziele mithilfe von **Aspose.Slides for Python via Java** ändert.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jedes Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

## **Verbindungsstück hinzufügen**

Fügen Sie ein Verbindungsstück zwischen zwei Punkten auf der Folie ein.

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

## **Zugriff auf ein Verbindungsstück**

Rufen Sie das erste hinzugefügte Verbindungsstück auf einer Folie ab.

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Connector, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100)

    # Greifen Sie auf das erste Verbindungsstück auf der Folie zu.
    connector = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Connector):
            connector = shape
            break
finally:
    presentation.dispose()
```

## **Verbindungsstück entfernen**

Löschen Sie ein Verbindungsstück von der Folie.

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

## **Formen erneut verbinden**

Verbinden Sie ein Verbindungsstück mit zwei Formen, indem Sie Start‑ und Endziele zuweisen.

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