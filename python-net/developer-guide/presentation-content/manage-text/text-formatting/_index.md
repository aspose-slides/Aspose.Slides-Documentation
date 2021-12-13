---
title: Text Formatting
type: docs
weight: 50
url: /python-net/text-formatting/
keywords: "Highlight text, Regular expression, Align text paragraphs, Text transparency, Paragraph font properties, font family, text rotation, custom angle rotation, text frame, line spacing, Autofit property, text frame anchor, text tabulation, Python, Aspose.Slides for Python via .NET"
description: "Manage and manipulate text and text frame properties in Python"
---

## **Highlight Text**
New HighlightText method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using text sample, similar to Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor)

{{% /alert %}} 


## **Highlight Text using Regular Expression**
New HighlightRegex method has been added to ITextFrame interface and TextFrame class.

It allows to highlight text part with background color using regex, similar to Text Highlight Color tool in PowerPoint 2019.


The code snippet below shows how to use this feature:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```




## **Align Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Python via .NET supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Python via .NET :

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its Index.
- Access the Placeholder shapes present in the slide and typecast them as a AutoShape.
- Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
- Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Accessing first slide
    slide = presentation.slides[0]

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Change the text in both placeholders
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # Getting the first paragraph of the placeholders
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Aligning the text paragraph to center
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    #Writing the presentation as a PPTX file
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Transparency for Text**
This article demonstrates how to set transparency property to any text shape using Aspose.Slides for Python via .NET. In order to set the transparency to text. Please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Get the reference of a slide.
- Set shadow color
- Write the presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # set transparency to zero percent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```




## **Manage Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Python via .NET to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Python via .NET :

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
1. Obtain a slide's reference by using its index.
1. Access the Placeholder shapes in the slide and typecast them to AutoShape.
1. Get the Paragraph from the TextFrame exposed by AutoShape.
1. Justify the paragraph.
1. Access a Paragraph's text Portion.
1. Define the font using FontData and set the Font of the text Portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the FillFormat exposed by the Portion object.
1. Write the modified presentation to a [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

The implementation of the above steps is given below. It takes an unadorned presentation and formats the fonts on one of the slides.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Accessing a slide using its slide position
    slide = pres.slides[0]

    # Accessing the first and second placeholder in the slide and typecasting it as AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Accessing the first Paragraph
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Accessing the first portion
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Define new fonts
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Assign new fonts to portion
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Set font to Bold
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Set font to Italic
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Set font color
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Write the PPTX to disk
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Manage Font Family of Text**
As mentioned in Managing Font Related Properties a Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Python via .NET to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it:

- Create an instance of the [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of the type Rectangle to the slide.
- Remove the fill style associated with the AutoShape.
- Access the AutoShape's TextFrame.
- Add some text to the TextFrame.
- Access the Portion object associated with the TextFrame.
- Define the font to be used for the Portion.
- Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Presentation
with slides.Presentation() as presentation:
    # Get first slide
    sld = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Remove any fill style associated with the AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Access the TextFrame associated with the AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Access the Portion associated with the TextFrame
    port = tf.paragraphs[0].portions[0]

    # Set the Font for the Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Set Bold property of the Font
    port.portion_format.font_bold = 1

    # Set Italic property of the Font
    port.portion_format.font_italic = 1

    # Set Underline property of the Font
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Set the Height of the Font
    port.portion_format.font_height = 25

    # Set the color of the Font
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Write the PPTX to disk 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Text Rotation**
Aspose.Slides for Python via .NET allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Access the first slide.
- Add any Shape to the slide.
- Access the TextFrame.
- Rotate the text.
- Save file to disk.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Get the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Custom Rotation Angle for TextFrame**
Aspose.Slides for Python via .NET now supports, Setting custom rotation angle for textframe. In this topic, we will see with example how to set the RotationAngle property in Aspose.Slides. The new property RotationAngle has been added to IChartTextBlockFormat and ITextFrameFormat interfaces, allows to set the custom rotation angle for textframe. In order to set the RotationAngle property, Please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation)class.
- Add a chart on slide.
- Set RotationAngle property.
- Write the presentation as a PPTX file.

In the example given below, we set the RotationAngle property.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # Save Presentation
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Line Spacing of Paragraph**
Aspose.Slides for Python via .NET lets developers to set the properties of ParagraphFormat to deal with line spacing of the paragraph. The properties SpaceAfter, SpaceBefore and SpaceWithin could be set for different line spacing. This article explains how to set these properties of ParagraphFormat. Aspose.Slides for Python via .NET provides a simple API for setting properties of ParagraphFormat:

- Load a presentation with an AutoShape having some text in it.
- Obtain a slide's reference by its index.
- Access the TextFrame.
- Access the Paragraph.
- Set properties of Paragraph.
- Save the presentation to disk.

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Obtain a slide's reference by its index
    sld = presentation.slides[0]

    # Access the TextFrame
    tf1 = sld.shapes[0].text_frame

    # Access the Paragraph
    para1 = tf1.paragraphs[0]

    # Set properties of Paragraph
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Save Presentation
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set the AutofitType Property for TextFrame**
In this topic, we will explore the different formatting properties of text frame. This article covers how to Set the AutofitType property of text frame, anchor of text and rotating the text in presentation. Aspose.Slides for Python via .NET allows developers to set AutofitType property of any text frame. AutofitType could be set to Normal or Shape. If set to Normal then shape will remain the same whereas the text will be adjusted without causing the shape to change itself whereas If AutofitType is set to shape, then shape will be modified such that only required text is contained in it. To set the AutofitType property of a text frame, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation)class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set the AutofitType of the TextFrame.
- Save file to disk.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    # Access the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Set Anchor of TextFrame**
Aspose.Slides for Python via .NET allows developers to Anchor of any TextFrame. TextAnchorType specifies that where is that text placed in the shape. TextAnchorType could be set to Top, Center, Bottom, Justified or Distributed. To set Anchor of any TextFrame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/python-net/aspose.slides/presentation) class.
- Access the first slide.
- Add any shape to the slide.
- Access the TextFrame.
- Set TextAnchorType of the TextFrame.
- Save file to disk.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Create an instance of Presentation class
with slides.Presentation() as presentation:
    # Get the first slide 
    slide = presentation.slides[0]

    # Add an AutoShape of Rectangle type
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Add TextFrame to the Rectangle
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Accessing the text frame
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Create the Paragraph object for text frame
    para = txtFrame.paragraphs[0]

    # Create Portion object for paragraph
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Save Presentation
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Text Tabulation**
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs collection includes all tabs (from Tabs collection and default tabs)
- EffectiveTabs.ExplicitTabCount (2 in our case) property is equal to Tabs.Count.
- EffectiveTabs.DefaultTabSize (294) property shows distance between default tabs (3 and 4 in our example).
- EffectiveTabs.GetTabByIndex(index) with index = 0 will return first explicit tab (Position = 731), index = 1 - second tab (Position = 1241). If you try to get next tab with index = 2 it will return first default tab (Position = 1470) and etc.
- EffectiveTabs.GetTabAfterPosition(pos) used for getting next tabulation after some text. For example you have text: "Helloworld!". To render such text you should know where to start draw "world!". At first, you should calculate length of "Hello" in pixels and call GetTabAfterPosition with this value. You will get next tab position to draw "world!".