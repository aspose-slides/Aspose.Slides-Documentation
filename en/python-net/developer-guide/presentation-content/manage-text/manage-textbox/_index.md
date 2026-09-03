---
title: Manage Text Boxes in Presentations with Python
linktitle: Manage Text Box
type: docs
weight: 20
url: /python-net/manage-textbox/
keywords:
- text box
- text frame
- add text
- update text
- create text box
- check text box
- add text column
- add hyperlink
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create, identify, format, and update text boxes in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET."
---

## **Introduction**

In Aspose.Slides for Python via .NET, slide text is stored in text frames that belong to shapes. The [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) class represents the most common text-bearing shape and exposes its text through the [AutoShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) property.

{{% alert color="info" title="Note" %}}

Every auto shape inherits from [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), but not every shape is an auto shape or supports a text frame. When processing an existing presentation, use `isinstance(shape, slides.AutoShape)` to check the shape type before accessing its text.

{{% /alert %}}

## **Create a Text Box on a Slide**

To create a text box, add an auto shape to a slide, add text to its text frame, and save the presentation. The following example creates a rectangular text box:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

The coordinates and dimensions passed to [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) are measured in points. [AutoShape.add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/) initializes the text frame with the supplied text.

## **Check for a Text Box Shape**

Use the [AutoShape.is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) property to determine whether an auto shape is treated as a text box. This is useful when a presentation contains both text-bearing and purely graphical auto shapes.

![A text box and a shape](istextbox.png)

The following example inspects every auto shape in a presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

A newly added auto shape is not considered a text box until it contains non-empty text. You can supply that text through [AutoShape.add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/) or [TextFrame.text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/). Adding or assigning an empty string leaves [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) set to `False`:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

The first two calls print `True`; the last two print `False`.

## **Find the Shape That Owns a Text Frame**

Generic text-processing code may receive a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) without knowing which presentation object contains it. Use the read-only [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) property to navigate back to its owning [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

For a text frame owned by an auto shape or another text-bearing shape, [parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) contains the owner and [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) is `None`. Check the returned value before accessing it. To identify both shape and table-cell owners, including shapes associated with SmartArt nodes, see [Search and Replace Text](/slides/python-net/search-and-replace-text/).

## **Add Columns to a Text Box**

The [TextFrameFormat.column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) property divides the text frame into columns, while [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) sets the gap between columns in points. Both settings belong to [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) and can be changed through the text frame of an existing text box. Text reflows between columns inside the same shape; it does not continue into another shape.

The following example creates a three-column text box with 10 points between columns, saves the presentation, and reads the stored settings back from the output file:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Extract Text from Individual Columns**

Use [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/split_text_by_columns/) to retrieve the text assigned to each visual column in an existing text frame. The method returns one string for each column, in column-based reading order. A single-column text frame produces a list with one element, and an empty column is represented by an empty string. The strings contain plain text only; portion-level formatting is not preserved.

This is useful when you need to:

- Extract text while preserving its column-based reading order.
- Index or compare the content of multi-column slides.
- Export each column to a separate file, database field, or other destination.
- Inspect how text is redistributed after changing [TextFrameFormat.column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/), the font, or the text-frame size.

The method reports the text distributed within the current [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/); it does not automatically flow text between separate shapes or text boxes. Column distribution can depend on available fonts and other text-layout settings, so make sure that the required fonts are available when consistent results are important.

The following example loads a presentation, finds the first multi-column auto shape with a text frame, reads its configured column count, and writes the text from every column to a separate file. Shapes that do not provide a text frame are skipped.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Update Text**

To update text throughout a presentation, iterate through the slides and shapes, select auto shapes, and then edit their text portions. Working at the portion level lets you change both text and character formatting.

The following example replaces every occurrence of `years` with `months` in auto-shape text and makes each affected portion bold:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

This traversal updates text only in auto shapes. Text stored in tables, charts, SmartArt, or grouped shapes requires traversal of those objects' own collections.

## **Add a Text Box with a Hyperlink**

A hyperlink can be assigned to a specific text portion, so only that text acts as the clickable link. Use [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) to associate the portion with an external URL.

The following example creates linked text and saves it to a presentation:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What is the difference between a text box and a text placeholder on a master or layout slide?**

A [placeholder](/slides/python-net/manage-placeholder/) can inherit its position and formatting from a [master slide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) or [layout slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/). A regular text box is an independent shape on the slide where it was created and does not acquire placeholder behavior when the layout changes.

**How can I replace text without changing text in charts, tables, or SmartArt?**

Limit the traversal to [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) instances, as shown in the Update Text example. Charts, tables, and SmartArt store text in their own object models, so they are not modified by that loop.
