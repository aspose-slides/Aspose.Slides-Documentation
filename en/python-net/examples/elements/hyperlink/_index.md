---
title: Hyperlink
type: docs
weight: 130
url: /python-net/examples/elements/hyperlink/
keywords:
- hyperlink
- add hyperlink
- access hyperlink
- remove hyperlink
- update hyperlink
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Add, edit, and remove hyperlinks in Python with Aspose.Slides: link text, shapes, slides, URLs and email; set targets and actions for PPT, PPTX and ODP."
---

Demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for Python via .NET**.

## **Add a Hyperlink**

Create a rectangle shape with a hyperlink pointing to an external website.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Hyperlink**

Read hyperlink information from a shape's text portion.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Remove a Hyperlink**

Clear the hyperlink from a shape's text.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Update a Hyperlink**

Change the target of an existing hyperlink. Use `HyperlinkManager` to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Changing a hyperlink inside existing text should be done via
        # HyperlinkManager rather than setting the property directly.
        # This mimics how PowerPoint safely updates hyperlinks.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```
