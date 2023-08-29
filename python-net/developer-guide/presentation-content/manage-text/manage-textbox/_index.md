---
title: Manage TextBox
type: docs
weight: 20
url: /python-net/manage-textbox/
keywords: "Textbox, Text frame, Add textbox, Textbox with hyperlink, Python, Aspose.Slides for Python via .NET"
description: "Add textbox or text frame to PowerPoint presentations in Python or ,NET"
---

Texts on slides typically exist in text boxes or shapes. Therefore, to add a text to a slide, you have to add a text box and then put some text inside the textbox. Aspose.Slides for Python via .NET provides the [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) interface that allows you to add a shape containing some text.

{{% alert title="Info" color="info" %}}

Aspose.Slides also provides the [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) interface that allows you to add shapes to slides. However, not all shapes added through the `IShape` interface can hold text. But shapes added through the [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) interface may contain text. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Therefore, when dealing with a shape to which you want to add text, you may want to check and confirm that it was cast through the `IAutoShape` interface. Only then will you be able to work with [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), which is a property under `IAutoShape`. See the [Update Text](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) section on this page. 

{{% /alert %}}

## **Create Text Box on Slide**

To create a textbox on a slide, go through these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) object with [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) set as `RECTANGLE` at a specified position on the slide and obtain the reference for the newly added `IAutoShape` object. 
4. Add a `text_frame` property to the `IAutoShape` object that will contain a text. In the example below, we added this text: *Aspose TextBox*
5. Finally, write the PPTX file through the `Presentation` object. 

This Python code—an implementation of the steps above—shows you how to add text to a slide:

```py
import aspose.slides as slides

# Instantiates PresentationEx
with slides.Presentation() as pres:

    # Gets the first slide in the presentation
    sld = pres.slides[0]

    # Adds an AutoShape with type set as Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Adds TextFrame to the Rectangle
    ashp.add_text_frame(" ")

    # Accesses the text frame
    txtFrame = ashp.text_frame

    # Creates the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Creates a Portion object for paragraph
    portion = para.portions[0]

    # Sets Text
    portion.text = "Aspose TextBox"

    # Saves the presentation to disk
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Check for Text Box Shape**

Aspose.Slides provides the `is_text_box` property (from the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) class) to allow you to examine shapes and find text boxes.

![Text box and shape](istextbox.png)

This Python code shows you how to check whether a shape was created as a text box: xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("shape is text box" if shape.is_text_box else "shape is text not box")
```

## **Add Column In Text Box**

Aspose.Slides provides the [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) and [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) properties (from the [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) interface and [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class) that allow you to add columns to textboxes. You get to specify the number of columns in a text box and set the amount spacing in points between columns. 

This code in Python demonstrates the described operation: 

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	# Gets the first slide in the presentation
	slide = presentation.slides[0]

	# Add an AutoShape with type set as Rectangle
	aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Add TextFrame to the Rectangle
	aShape.add_text_frame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!")

	# Gets the text format of TextFrame
	format = aShape.text_frame.text_frame_format

	# Specifies the number of columns in TextFrame
	format.column_count = 3

	# Specifies the spacing between columns
	format.column_spacing = 10

	# Saves the presentation
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```


## **Add Column In Text Frame**
Aspose.Slides for Python via .NET provides the [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) property (from the [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) interface) that allows you to add columns in text frames. Through this property, you can specify your preferred number of columns in a text frame. 

 This Python code shows you how to add a column inside a text frame:

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """All these columns are forced to stay within a single text container -- 
        you can add or delete text - and the new or remaining text automatically adjusts 
        itself to stay within the container. You cannot have text spill over from one container 
        to other, though -- because PowerPoint's column options for text are limited!
        pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)"""

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **Update Text**

Aspose.Slides allows you to change or update the text contained in a text box or all the texts contained in a presentation. 

This Python code demonstrates an operation where all the texts in a presentation are updated or changed:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Saves modified presentation
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Text Box with Hyperlink** 

You can insert a link inside a text box. When the text box is clicked, users are directed to open the link. 

 To add a text box containing a link, go through these steps:

1. Create an instance of the `Presentation` class. 
2. Obtain a reference for the first slide in the newly created presentation. 
3. Add an `AutoShape` object with `ShapeType` set as `RECTANGLE` at a specified position on the slide and obtain a reference of the newly added AutoShape object.
4. Add a `text_frame` to the `AutoShape` object that contains *Aspose TextBox* as its default text. 
5. Instantiate the `hyperlink_manager` class. 
6. Assign the `hyperlink_manager` object to the [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) property associated with your preferred portion of the `TextFrame`. 
7. Finally, write the PPTX file through the `Presentation` object. 

This Python code—an implementation of the steps above—shows you how to add a text box with a hyperlink to a slide:

```py
import aspose.slides as slides

# Instantiates a Presentation class that represents a PPTX
with slides.Presentation() as pptxPresentation:
    # Gets the first slide in the presentation
    slide = pptxPresentation.slides[0]

    # Adds an AutoShape object with type set as Rectangle
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # Accesses the ITextFrame property associated with the AutoShape
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # Adds some text to the frame
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # Sets the Hyperlink for the portion text
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # Saves the PPTX Presentation
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```