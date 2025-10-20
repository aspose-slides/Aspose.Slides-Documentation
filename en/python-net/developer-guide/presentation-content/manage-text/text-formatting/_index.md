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
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET. Customize fonts, colors, alignment, and more with powerful Python code examples."
---

## **Highlight Text**

The `highlight_text` method in the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) class allows you to highlight a part of the text with a background color using a text sample, similar to the Text Highlight Color tool in PowerPoint 2019.

The following code snippet shows how to use this feature:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

## **Highlight Text Using Regular Expressions**

The `highlight_regex` method of the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) class lets you highlight a portion of text with a background color using a regular expression, similar to the Text Highlight Color tool in PowerPoint 2019.

The code snippet below shows how to use this feature:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Background Color**

Aspose.Slides allows you to specify your preferred background color for text. The Python code below shows how to set the background color for the entire text:

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

This Python code shows how to set the background color for only a portion of the text:

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

Text formatting is a key element when creating documents or presentations. Aspose.Slides for Python via .NET supports adding text to slides; in this section, we’ll see how to control paragraph alignment in a slide. Follow these steps to align text paragraphs using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Access the placeholder shapes on the slide and cast them to [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. From the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) exposed by the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), get the paragraph that needs to be aligned.
1. Align the paragraph. A paragraph can be aligned `LEFT`, `RIGHT`, `CENTER`, `JUSTIFY`, `JUSTIFY_LOW`, or `DISTRIBUTED`.
1. Save the modified presentation as a PPTX file.

The implementation of these steps is shown below.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
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

## **Set Text Transparency**

This section demonstrates how to set the transparency property for any text shape using Aspose.Slides for Python via .NET. To set text transparency, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide.
1. Set the shadow color.
1. Save the presentation as a PPTX file.

The implementation of these steps is given below.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # set transparency to zero percent
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Character Spacing**

Aspose.Slides lets you adjust the spacing between letters in a text box. This allows you to control the visual density of a line or block of text by expanding or condensing the spacing between characters.

The Python example below shows how to expand the spacing for one line of text and condense it for another:

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # expand
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # condense

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **Manage Paragraph Font Properties**

Presentations usually contain both text and images. The text can be formatted in various ways—either to highlight specific sections and words or to conform to corporate styles. Text formatting helps users change the look and feel of the presentation content.

This section demonstrates how to use Aspose.Slides for Python via .NET to configure the font properties of paragraphs in slide text. To manage a paragraph’s font properties using Aspose.Slides for Python via .NET:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by using its index.
1. Access the placeholder shapes on the slide and cast them to [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Get the paragraph from the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) exposed by [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Justify the paragraph.
1. Access the paragraph’s text portion.
1. Define the font using [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) and set the font of the text portion accordingly.
   1. Set the font to bold.
   1. Set the font to italic.
1. Set the font color using the [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) exposed by the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) object.
1. Save the modified presentation as a PPTX file.

The implementation of the above steps is shown below. It takes a plain presentation and applies font formatting to one of the slides.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate a Presentation object that represents a PPTX file
with slides.Presentation("FontProperties.pptx") as pres:
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

## **Manage the Font Family of Text**

[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) objects are used to hold text with a similar formatting style within a paragraph. This section demonstrates how to use Aspose.Slides for Python to create a text box, add text to it, and then define a specific font along with various other font family properties.

To create a text box and set the font properties of the text inside it:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to a slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) of type `RECTANGLE` to the slide.
1. Remove the fill style associated with the [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Access the AutoShape’s [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Add text to the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Access the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) object associated with the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Define the font to be used for the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Set other font properties such as bold, italic, underline, color, and height using the relevant properties exposed by the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) object.
1. Save the modified presentation as a PPTX file.

The implementation of the above steps is shown below.

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


## **Set the Font Size for Text**

Aspose.Slides allows you to set your preferred font size for existing text in a paragraph, as well as for any text that may be added to the paragraph later.

This Python example demonstrates how to set the font size for text contained in a paragraph:

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

Aspose.Slides for Python via .NET allows developers to rotate text. Text can be set to appear as `HORIZONTAL`, `VERTICAL`, `VERTICAL270`, `WORD_ART_VERTICAL`, `EAST_ASIAN_VERTICAL`, `MONGOLIAN_VERTICAL`, or `WORD_ART_VERTICAL_RIGHT_TO_LEFT`.

To rotate the text in any [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a shape to the slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Apply the desired text rotation.
1. Save the file to disk.

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

## **Set a Custom Rotation Angle for a TextFrame**

Aspose.Slides for Python via .NET supports setting a custom rotation angle for a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). In this section, we will demonstrate how to use the `rotation_angle` property in Aspose.Slides.

To set the `rotation_angle` property, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Add a chart to the slide.
1. Set the `rotation_angle` property.
1. Save the presentation as a PPTX file.

In the example below, we set the `rotation_angle` property.

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

## **Set the Line Spacing of Paragraphs**

Aspose.Slides provides the `space_after`, `space_before`, and `space_within` properties under the [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) class to control a paragraph’s line spacing. These properties work as follows:

* To specify line spacing as a percentage, use a positive value.
* To specify line spacing in points, use a negative value.

For example, to apply a 16 pt line spacing before a paragraph, set the `space_before` property to `-16`.

Here’s how to set the line spacing for a specific paragraph:

1. Load a presentation that contains an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with text.
1. Get a reference to the slide by its index.
1. Access the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Access the [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Set the desired paragraph properties.
1. Save the presentation.

The following Python example demonstrates how to set the line spacing for a paragraph:

```py
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation("Fonts.pptx") as presentation:

    # Get a slide's reference by its index
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

In this section, we will explore various formatting properties of a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), including how to set its `autofit_type`, adjust the text anchor, and rotate text in a presentation.

Aspose.Slides for Python via .NET allows developers to set the `autofit_type` property of any [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). The `autofit_type` can be set to either `NORMAL` or `SHAPE`:

* If set to `NORMAL`, the shape remains unchanged while the text is adjusted to fit within it.
* If set to `SHAPE`, the shape is resized so that it contains only the required text.

To set the `autofit_type` property of a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a shape to the slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Set the `autofit_type` for the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Save the file to disk.

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

## **Set the Anchor of a TextFrame**

Aspose.Slides for Python via .NET allows developers to set the anchor position of any [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). The [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) property specifies where the text is placed within the shape. It can be set to `TOP`, `CENTER`, `BOTTOM`, `JUSTIFIED`, or `DISTRIBUTED`.

To set the anchor of a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the first slide.
1. Add a shape to the slide.
1. Access the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Set the [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) for the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Save the file to disk.

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

## **Set the Default Text Style**

If you need to apply the same default text formatting to all text elements in a presentation, you can use the `default_text_style` property of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and set the desired formatting.

The example below demonstrates how to set the default font to bold, with a size of 14 pt, for all text across every slide in a new presentation.

```py
with slides.Presentation() as presentation:
    # Get the top level paragraph format.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Text with the All-Caps Effect**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To handle this, check [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)—if it indicates `ALL`, simply convert the returned string to uppercase so that your output matches what users see on the slide.

Let’s say we have the following text box on the first slide of the sample2.pptx file.

![The All Caps effect](all_caps_effect.png)

 The code example below shows how to extract the text with the **All Caps** effect aplyied:

```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

{{% alert color="primary" %}}

Aspose provides a simple, [free online PowerPoint editing service](https://products.aspose.app/slides/editor).

{{% /alert %}}

## **FAQ**

**Can I apply different formatting to specific parts of text within a single paragraph (e.g., bold just a couple of words), and how does that interact with styles inherited from layouts and themes?**

Yes. Formatting is set at the “text portion” level inside a paragraph and overrides the theme/layout style only for those selected fragments. When the theme changes, only regions without explicit local formatting will update.

**How do fonts work on Linux and in Docker containers that don’t have system fonts installed?**

The library uses font discovery/substitution. On systems without fonts, you should explicitly [point to font directories](/slides/python-net/custom-font/) and/or configure a [substitution table](/slides/python-net/font-substitution/) to avoid fallback to unsuitable typefaces and layout shifts.

**How does text formatting in placeholders differ from formatting in regular autoshapes?**

Placeholders inherit styles from the slide master and layout more strongly than regular autoshapes. Local changes in placeholders are possible, but when the layout changes they’re more likely to revert to theme styles unless you’ve hard-overridden formatting at the text-portion level.
