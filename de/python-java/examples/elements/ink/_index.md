---
title: Tinte
type: docs
weight: 180
url: /de/python-java/examples/elements/ink/
keywords:
- Codebeispiel
- Tinte
- Tinte zugreifen
- Tinte entfernen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Zugriff auf und Entfernen von Tintenformen in Aspose.Slides für Python via Java‑Präsentationen, einschließlich PPT-, PPTX‑ und ODP‑Dateien."
---
Dieser Artikel enthält Beispiele für den Zugriff auf vorhandene Tintenformen und deren Entfernung mit **Aspose.Slides for Python via Java**.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jede Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, nachdem die JVM läuft.

{{% alert color="info" title="Note" %}}
Die Tintenformen stellen Benutzereingaben von spezialisierten Geräten dar. Aspose.Slides kann keine neuen Tintenstriche programmgesteuert erstellen, aber Sie können vorhandene Tinte lesen und bearbeiten.
{{% /alert %}}

## **Zugriff auf Tinte**

Lesen Sie die Tags der ersten Tintenform auf einer Folie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Verwenden Sie tag_name nach Bedarf.
finally:
    presentation.dispose()
```

## **Tinte entfernen**

Löschen Sie eine Tintenform von der Folie, falls vorhanden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```