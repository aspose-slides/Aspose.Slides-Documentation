---
title: Text Box
type: docs
weight: 40
url: /python-net/examples/elements/text-box/
keywords:
- text box
- add text box
- access text box
- remove text box
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Create and format text boxes in Python with Aspose.Slides: set fonts, alignment, wrapping, autofit, and links to polish slides for PowerPoint and OpenDocument."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Create a rectangle shape (defaults to filled with border and no text).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Remove fill and border to make it look like a typical text box.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Set text formatting.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Assign the actual text content.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Only AutoShapes can contain editable text.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Do something with the matching text box.
                    pass
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Find shapes to remove that are AutoShapes containing the word "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Remove each matching shape from the slide.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
