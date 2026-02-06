---
title: SmartArt
type: docs
weight: 140
url: /python-net/examples/elements/smartart/
keywords:
- SmartArt
- add SmartArt
- access SmartArt
- remove SmartArt
- SmartArt layout
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Build and edit SmartArt in Python with Aspose.Slides: add nodes, change layouts and styles, convert to shapes with precision, and export for PPT, PPTX and ODP."
---

Shows how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for Python via .NET**.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Access the first SmartArt shape.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a SmartArt object.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a SmartArt object.
        smart_art = slide.shapes[0]

        # Change the SmartArt layout.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```
