---
title: Ink
type: docs
weight: 180
url: /python-net/examples/elements/ink/
keywords:
- ink
- access ink
- remove ink
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Handle digital ink on slides in Python with Aspose.Slides: add pen strokes, edit paths, set color and width, and export results for PowerPoint and OpenDocument."
---

Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for Python via .NET**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## **Access Ink**

Get the first ink shape from a slide.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Remove Ink**

Delete an ink shape from the slide.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the fist shape is an Ink object.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```
