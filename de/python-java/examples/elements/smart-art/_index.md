---
title: SmartArt
type: docs
weight: 140
url: /de/python-java/examples/elements/smart-art/
keywords:
- Codebeispiel
- SmartArt
- SmartArt hinzufügen
- Zugriff auf SmartArt
- SmartArt entfernen
- SmartArt-Layout
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Arbeiten Sie mit SmartArt in Aspose.Slides für Python über Java: Hinzufügen, Zugreifen, Entfernen und Ändern von Diagramm-Layouts in PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel zeigt, wie Sie SmartArt‑Grafiken hinzufügen, darauf zugreifen, sie entfernen und Layouts ändern, wobei **Aspose.Slides for Python via Java** verwendet wird.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

## **SmartArt hinzufügen**

Fügen Sie eine SmartArt‑Grafik ein, indem Sie eines der integrierten Layouts verwenden.

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

## **Zugriff auf SmartArt**

Rufen Sie das erste SmartArt‑Objekt auf einer Folie ab.

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

## **SmartArt entfernen**

Löschen Sie eine SmartArt‑Form von der Folie.

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

## **SmartArt‑Layout ändern**

Aktualisieren Sie den Layouttyp einer vorhandenen SmartArt‑Grafik.

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