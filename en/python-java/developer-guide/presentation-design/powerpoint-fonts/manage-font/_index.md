---
title: Manage Fonts in Presentations Using Python via Java
linktitle: Manage Fonts
type: docs
weight: 10
url: /python-java/manage-fonts/
keywords:
- manage fonts
- font properties
- paragraph
- text formatting
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Control fonts in Python via Java with Aspose.Slides: embed, substitute, and load custom fonts to keep PPT, PPTX and ODP presentations clear, brand-safe, and consistent."
---

## **Overview**

Aspose.Slides allows you to manage font properties in presentation text directly from your code. You can access text in slides through shapes, text frames, paragraphs, and portions, and then apply formatting to the selected text.

This article explains how to configure font-related properties for existing text in a presentation, including font family, bold and italic styles, paragraph alignment, and font color. It also shows how to create a text box, add text to it, and set font properties such as font family, bold, italic, underline, font size, and color before saving the result as a PPTX file.

## **Manage Font-Related Properties**
{{% alert color="info" title="Note" %}} 

Presentations usually contain both text and images. The text can be formatted in various ways, either to highlight specific sections and words or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Python via Java to configure the font properties of paragraphs of text on slides.

{{% /alert %}} 

To manage font properties of a paragraph using Aspose.Slides for Python via Java:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Obtain a slide's reference by using its index.
1. Access the [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) shapes in the slide as [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
1. Get the [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) from the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) exposed by [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
1. Justify the paragraph.
1. Access a [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)'s text [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/).
1. Define the font using [FontData](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/) and set the **Font** of the text [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/) exposed by the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) object.
1. Save the modified presentation to a PPTX file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides. The screenshots that follow show the input file and how the code snippets change it. The code changes the font, the color, and the font style.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: The text in the input file**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: The same text with updated formatting**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Load the presentation.
presentation = Presentation("FontProperties.pptx")
try:
    # Access the first slide and the text frames of its first two placeholders.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Access the first paragraph in each text frame.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Access the first portion in each paragraph.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Define and assign new fonts.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Set the fonts to bold and italic.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Set the font colors.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Save the presentation.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set Text Font Properties**
{{% alert color="info" title="Note" %}} 

As mentioned in **Manage Font-Related Properties**, a [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) is used to hold text with a similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Python via Java to create a text box with some text and then define a particular font and various other font properties.

{{% /alert %}} 

To create a text box and set font properties of the text in it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Obtain the reference of a slide by using its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of the type **Rectangle** to the slide.
1. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
1. Access the [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/)'s [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
1. Add some text to the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
1. Access the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) object associated with the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).
1. Define the font to be used for the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/).
1. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) object.
1. Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Text with some font properties set by Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Get the first slide and add a rectangle.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Remove the shape fill.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Add text to the shape's text frame.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Set the font family.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Set bold, italic, underline, and font size.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Set the font color.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Save the presentation.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
