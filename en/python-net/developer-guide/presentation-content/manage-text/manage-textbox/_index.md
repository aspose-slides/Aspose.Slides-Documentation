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
description: "Aspose.Slides for Python via .NET makes it easy to create, edit, and clone text boxes in PowerPoint and OpenDocument files, enhancing your presentation automation."
---

## **Overview**

Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for Python provides the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) class that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) class. However, not all shapes can hold text.

{{% /alert %}}

{{% alert title="Note" color="warning" %}}

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) class. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), which is a property under [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). See the [Update Text](/slides/python-net/manage-textbox/#update-text) section on this page.

{{% /alert %}}

## **Create Text Boxes on Slides**

To create a text box on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the first slide.
3. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with `ShapeType.RECTANGLE` at the desired position on the slide.
4. Set the text in the shape’s [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
5. Save the presentation as a PPTX file.

The following Python example implements these steps:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # Save the presentation to disk.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **Check Whether a Shape Is a Text Box**

Aspose.Slides provides the [is_text_box](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/is_text_box/) property on the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) class, which allows you to determine whether a shape is a text box.

![Text box and shape](istextbox.png)

This Python example shows how to check whether a shape was created as a text box:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

Note that if you add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) using the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class, the shape’s `is_text_box` property returns `False`. However, after you add text—either with the `add_text_frame` method or by setting the `text` property—`is_text_box` returns `True`.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box is false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box is true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box is false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box is true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box is false
    shape3.add_text_frame("")
    # shape3.is_text_box is false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box is false
    shape4.text_frame.text = ""
    # shape4.is_text_box is false
```

## **Add Columns to Text Boxes**

Aspose.Slides provides the [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_count/) and [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/column_spacing/) properties on the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class to add columns to text boxes. You can specify the number of columns and set the spacing (in points) between columns.

The following Python code demonstrates this operation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# Get the first slide in the presentation.
	slide = presentation.slides[0]

	# Add an AutoShape of type RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add a TextFrame to the rectangle.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# Get the text format of the TextFrame.
	format = shape.text_frame.text_frame_format

	# Specify the number of columns in the TextFrame.
	format.column_count = 3

	# Specify the spacing between columns.
	format.column_spacing = 10

	# Save the presentation.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Update Text**

Aspose.Slides allows you to update the text in a single text box or across an entire presentation. 

The following Python example demonstrates how to update all text in a presentation:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Save the modified presentation.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Text Boxes with Hyperlinks** 

You can insert a link in a text box. When the text box is clicked, the link opens.

To add a text box that contains a hyperlink, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get a reference to the first slide.
3. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with `ShapeType.RECTANGLE` at the desired position on the slide.
4. Set the text in the shape’s [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
5. Get a reference to the [HyperlinkManager](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/).
6. Use the `hyperlink_manager` property to set an external click hyperlink.
7. Save the presentation as a PPTX file.

This Python example shows how to add a text box with a hyperlink to a slide:

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide in the presentation.
    slide = presentation.slides[0]

    # Add an AutoShape of type RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # Add text to the frame.
    text_portion.text = "Aspose.Slides"

    # Set a hyperlink for the portion text.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # Save the presentation as a PPTX file.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What’s the difference between a text box and a text placeholder when working with master slides?**

A [placeholder](/slides/python-net/manage-placeholder/) inherits style/position from the [master](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) and can be overridden on [layouts](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), whereas a regular text box is an independent object on a specific slide and doesn’t change when you switch layouts.

**How can I perform a bulk text replacement across the presentation without touching text inside charts, tables, and SmartArt?**

Limit your iteration to auto-shapes that have text frames and exclude embedded objects ([charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)) by traversing their collections separately or skipping those object types.
