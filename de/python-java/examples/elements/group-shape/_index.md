---
title: Gruppenform
type: docs
weight: 170
url: /de/python-java/examples/elements/group-shape/
keywords:
- Codebeispiel
- Gruppenform
- Gruppenform hinzufügen
- Zugriff auf Gruppenform
- Gruppenform entfernen
- Gruppierung aufheben
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Gruppenformen in Präsentationen mit Aspose.Slides für Python via Java: Hinzufügen, Zugriff, Entfernen und Aufheben von Gruppierungen in PowerPoint- und OpenDocument-Dateien."
---
Dieser Artikel zeigt, wie man Gruppen von Formen erstellt, auf sie zugreift, sie entfernt und deren Inhalte auflöst, wobei **Aspose.Slides for Python via Java** verwendet wird.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

## **Gruppenform hinzufügen**

Erstellen Sie eine Gruppe, die zwei grundlegende Formen enthält.

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

## **Zugriff auf eine Gruppenform**

Rufen Sie die erste Gruppenform aus einer Folie ab.

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

## **Entfernen einer Gruppenform**

Löschen Sie eine Gruppenform von der Folie.

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

## **Gruppierung aufheben**

Verschieben Sie eine Form aus einem Gruppenkontainer.

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

    # Verschiebe die Form aus der Gruppe.
    slide.getShapes().addClone(rectangle)
    group.getShapes().remove(rectangle)
finally:
    presentation.dispose()
```