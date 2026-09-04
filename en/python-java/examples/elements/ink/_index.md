---
title: Ink
type: docs
weight: 180
url: /python-java/examples/elements/ink/
keywords:
- code example
- ink
- access ink
- remove ink
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Access and remove ink shapes in Aspose.Slides for Python via Java presentations, including PPT, PPTX, and ODP files."
---

This article provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

{{% alert color="info" title="Note" %}}
Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.
{{% /alert %}}

## **Access Ink**

Read the tags from the first ink shape on a slide.

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
            # Use tag_name as needed.
finally:
    presentation.dispose()
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

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
