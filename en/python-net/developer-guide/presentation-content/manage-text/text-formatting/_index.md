---
title: Format PowerPoint Text in Python
linktitle: Text Formatting
type: docs
weight: 50
url: /python-net/text-formatting/
keywords:
- highlight text
- regular expression
- align paragraph
- text style
- text background
- text transparency
- character spacing
- font properties
- font family
- text rotation
- rotation angle
- text frame
- line spacing
- autofit property
- text frame anchor
- text tabulation
- default language
- Python
- Aspose.Slides for Python
description: "Learn how to format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET. Customize fonts, colors, alignment, and more with powerful Python code examples."
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

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor).

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


## **Set Text Background Color**

Aspose.Slides allows you to specify your preferred color for the background of a text.

This Python code shows you how to set the background color for an entire text: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```

This Python code shows you how to set the background color for only a portion of a text:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Align Text Paragraphs**
Text formatting is one of the key elements while creating any kind of documents or presentations. We know that Aspose.Slides for Python via .NET supports adding text to slides but in this topic, we will see that how can we control the alignment of the text paragraphs in a slide. Please follow the steps below to align text paragraphs using Aspose.Slides for Python via .NET :

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Obtain the reference of a slide by using its Index.
3. Access the Placeholder shapes present in the slide and typecast them as a AutoShape.
4. Get the Paragraph (that needs to be aligned) from the TextFrame exposed by AutoShape.
5. Align the Paragraph. A paragraph can be aligned to Right, Left, Center & Justify.
6. Write the modified presentation as a PPTX file.

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

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get the reference of a slide.
3. Set shadow color
4. Write the presentation as a PPTX file.

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


## **Set Character Spacing for Text**

Aspose.Slides allows you to set the space between letters in a textbox. This way, you get to adjust the visual density of a line or block of text by expanding or condensing the spacing between characters.

This Python code shows you how to expand the spacing for one line of text and condense the spacing for another line: 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # expand
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condense

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Manage Paragraph's Font Properties**
Presentations usually contain both text and images. The text can be formatted in a various ways, either to highlight specific sections and words, or to conform with corporate styles. Text formatting helps users vary the look and feel of the presentation content. This article shows how to use Aspose.Slides for Python via .NET to configure the font properties of paragraphs of text on slides. To manage font properties of a paragraph using Aspose.Slides for Python via .NET :

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
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
A Portion is used to hold text with similar formatting style in a paragraph. This article shows how to use Aspose.Slides for Python to create a textbox with some text and then define a particular font, and various other properties of the font family category. To create a textbox and set font properties of the text in it::

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Obtain the reference of a slide by using its index.
3. Add an AutoShape of the type Rectangle to the slide.
4. Remove the fill style associated with the AutoShape.
5. Access the AutoShape's TextFrame.
6. Add some text to the TextFrame.
7. Access the Portion object associated with the TextFrame.
8. Define the font to be used for the Portion.
9. Set other font properties like bold, italic, underline, color and height using the relevant properties as exposed by the Portion object.
10. Write the modified presentation as a PPTX file.

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


## **Set Font Size for Text**

Aspose.Slides allows you to choose your preferred font size for existing text in a paragraph and other texts that may be added to the paragraph later.

This Python code shows you how to set the font size for texts contained in a paragraph: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Gets the first shape, for example.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Gets the first paragraph, for example.
        paragraph = shape.text_frame.paragraphs[0]

        # Sets the default font size to 20 pt for all text portions in the paragraph. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Sets the font size to 20 pt for current text portions in the paragraph. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Set Text Rotation**
Aspose.Slides for Python via .NET allows developers to rotate the text. Text could be set to appear as Horizontal, Vertical, Vertical270, WordArtVertical, EastAsianVertical, MongolianVertical or WordArtVerticalRightToLeft. To rotate the text of any TextFrame, please follow the steps below:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Add any Shape to the slide.
4. Access the TextFrame.
5. Rotate the text.
6. Save file to disk.

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

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
2. Add a chart on slide.
3. Set RotationAngle property.
4. Write the presentation as a PPTX file.

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
Aspose.Slides provides properties under `paragraph_format`—`space_after`, `space_before` and `space_within`—that allow you to manage the line spacing for a paragraph. The three properties are used this way:

* To specify the line spacing for a paragraph in percentage, use a positive value. 
* To specify the line spacing for a paragraph in points, use a negative value.

For example, you can apply a 16pt line spacing for a paragraph by setting the `space_before` property to -16.

This is how you specify the line spacing for a specific paragraph:

1. Load a presentation containing an AutoShape with some text in it.
2. Get a slide's reference through its index.
3. Access the TextFrame.
4. Access the Paragraph.
5. Set the Paragraph properties.
6. Save the presentation.

This Python code shows you how to specify the line spacing for a paragraph:

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

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set the AutofitType of the TextFrame.
6. Save file to disk.

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

1. Create an instance of [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Access the first slide.
3. Add any shape to the slide.
4. Access the TextFrame.
5. Set TextAnchorType of the TextFrame.
6. Save file to disk.

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


## **Set Default Text Style**

If you need to apply the same default text formatting to all text elements of a presentation at once, then you can use the `default_text_style` property from the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and set the preferred formatting. The code example below shows how to set the default bold font (14 pt) for the text on all slides in a new presentation.

```py
with slides.Presentation() as presentation:
    # Get the top level paragraph format.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```
