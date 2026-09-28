---
title: Format Presentation Text in Python
linktitle: Text Formatting
type: docs
weight: 50
url: /python-net/text-formatting/
keywords:
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
description: "Format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET. Customize fonts, colors, alignment, and more."
---

## **Overview**

This article shows how to format text in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET. It covers background colors, transparency, character spacing, font properties, rotation, paragraph spacing, autofit behavior, text anchoring, tab stops, and language settings.

Unless stated otherwise, the examples use [sample.pptx](sample.pptx). The first shape on its first slide is a text box, and its first paragraph contains the text shown below. Both slide and shape indices are zero-based. Examples that select bold portions use effective formatting, including inherited bold formatting:

![Sample text](sample_text.png)

To find and highlight literal text or regular-expression matches, see [Search and Replace Text](/slides/python-net/search-and-replace-text/).

## **Set Text Background Color**

Use [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) to set the default highlight color for a paragraph, or use [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) for individual text portions.

The following example sets a light gray highlight as the default for the first paragraph. Explicit highlight colors on individual portions take precedence over this default:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Set the highlight color for the entire paragraph.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The gray paragraph](gray_paragraph.png)

The code example below demonstrates how to set the background color for **text portions with a bold font**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Set the highlight color for the text portion.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

Use [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) to set paragraph alignment within a text frame. The value can be centered, left-aligned, right-aligned, justified, and so on.

The following code example shows how to align the paragraph to the **center**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Set the alignment of the paragraph to center.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

Text transparency is controlled through the alpha component of the color assigned to [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). In the examples below, `alpha = 50` is an ARGB alpha-channel value on the 0–255 scale, not a transparency percentage.

The code example below shows how to apply transparency to the **entire paragraph**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Set a semitransparent black fill for the text.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The transparent paragraph](transparent_paragraph.png)

The following code example shows how to apply transparency to **text portions with a bold font**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Set the transparency of the text portion.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

Use [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) to expand or condense spacing between characters in a text box. The examples add 3 points of spacing; negative values condense the text.

The following Python code shows how to expand the character spacing in the **entire paragraph**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Note: Use negative values to compress the character spacing.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Expand character spacing.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

The code example below shows how to expand the character spacing in **text portions with a bold font**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Note: Use negative values to compress the character spacing.
            portion.portion_format.spacing = 3  # Expand character spacing.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

In some cases, text rendered by Aspose.Slides may look slightly tighter than the same text displayed in PowerPoint. This can happen because PowerPoint may ignore kerning data for certain fonts, even when the font contains valid kerning information and kerning is enabled in PowerPoint settings.

To make the rendered output closer to PowerPoint in such cases, you can disable kerning for text portions that use the affected font. Set [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) to a value larger than the actual font size. This example requires "presentation.pptx" with a text box as the first shape on the first slide. It checks effective font names, including inherited fonts, and sets a 100-point threshold for portions that use Roboto. This disables kerning for matching portions with a font size below 100 points:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

For matching text below the threshold, this setting prevents kerning and can help align Aspose.Slides rendering with PowerPoint’s visual output for fonts affected by this PowerPoint-specific behavior.

## **Manage Text Font Properties**

Font properties can be set at the paragraph level through [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) or on individual portions through [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

The following example sets the first paragraph’s default font to 12-point Times New Roman with bold, italic, and dotted underline formatting. Explicit formatting on individual portions takes precedence over these defaults.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Set the font properties for the paragraph.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The font properties for the paragraph](font_properties_for_paragraph.png)

The following example applies 13-point Times New Roman, italic formatting, and a dotted underline to portions whose effective formatting is bold:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Set the font properties for the text portion.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

Use [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) to set a predefined text orientation within a shape.

The following code example sets the text orientation in the shape to [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), which rotates the text **90 degrees counterclockwise**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

Use [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) to set a custom rotation angle for a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

The code example below rotates the text frame by 3 degrees clockwise within the shape:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides provides [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), and [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) to control paragraph spacing. These properties are used as follows:

* Use a positive value to specify line spacing as a percentage of the line height.
* Use a negative value to specify line spacing in points.

The following example sets spacing within the first paragraph to 200% of the line height (double spacing):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The line spacing within the paragraph](line_spacing.png)

## **Control Line Breaking**

Paragraph line-breaking rules are useful in narrow text blocks and presentations that mix Latin and East Asian text. The following properties belong to [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), so they apply to an entire paragraph:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) controls Latin line-breaking rules. In mixed text, changing it can also change where adjacent East Asian text and punctuation wrap.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) controls East Asian line-breaking rules, including restrictions on characters at the beginning and end of a line.

These rules do not replace [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), which enables automatic wrapping within a text frame. They influence the layout when wrapping occurs; they do not insert line-break characters. An explicit line break forces a new line within the paragraph independently of the available width.

The following self-contained example creates a narrow text block containing Chinese and Latin text. It sets both line-breaking properties explicitly and saves "line_breaking.pptx". To experiment with either rule, change that property's value while keeping the other settings fixed. The example uses 24-point Arial and SimSun with a 160-point frame width and zero horizontal text-frame margins. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) is set to [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) so that text size and frame dimensions remain fixed.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Control Hanging Punctuation**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) allows eligible punctuation to extend beyond the text line's right edge instead of occupying the next line. It applies to the entire paragraph and is different from a hanging indent.

The following self-contained example enables hanging punctuation in a 100-point-wide text frame and saves "hanging_punctuation.pptx". With 24-point Arial and zero horizontal text-frame margins, the final period stays after "sentence" and extends beyond the right text edge. Set the property to [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) to compare: with these settings, the period occupies a separate line. Wrapping is enabled and autofit is disabled to keep the available width fixed.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Not every punctuation mark can hang. The visible result depends on font and layout conditions: changing the font, available width, margins, or autofit settings can remove the visible difference.

## **Set Autofit Type for Text Frames**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) determines how text behaves when it exceeds the boundaries of its container. Use it to control whether the text shrinks, overflows, or resizes the shape automatically. The following example configures the shape to resize to fit its text and saves the result to "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

To count lines after automatic wrapping and see how text or shape width changes the result, see [Count Rendered Lines](/slides/python-net/manage-paragraph/). Line count alone does not indicate whether text overflows its container.

## **Set Anchor of Text Frames**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) defines how text is positioned vertically inside a shape, for example, at the top, middle, or bottom. The following example anchors the text to the bottom of the first shape and saves the result to "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Text Tabulation**

Use [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) and [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) to configure tab stops in a paragraph. The following example sets the default tab interval to 100 points and adds a left-aligned tab stop at 30 points. These settings affect text containing tab characters.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides provides [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), which allows you to set the proofing language for a text portion. The proofing language determines the language used for spelling and grammar checks in PowerPoint.

The following example requires "presentation.pptx" with a text box as the first shape on the first slide and at least one paragraph. It replaces the first paragraph’s contents with "1。", sets SimSun as its font, and assigns the Simplified Chinese proofing language (`zh-CN`). It saves the result to "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Set the proofing language to Simplified Chinese.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Default Language**

Use [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) to define the default language for text created while loading or creating a presentation. The following example creates a presentation with US English as the default text language, adds a text box, and prints `en-US` for its first text portion.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Add a new rectangle shape with text.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Check the first portion language.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Set Default Text Style**

To apply default text formatting at the presentation level, use [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

The following example sets a 14-point bold font as the default for top-level paragraphs in a new presentation and saves it to "default_text_style.pptx". Text can inherit these defaults unless more specific formatting overrides them.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Get the top level paragraph format.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extract Text with the All-Caps Effect**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To match the displayed text, check [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) and convert the returned string to uppercase when the value is `ALL`.

This example requires "sample2.pptx" with a text box as the first shape on the first slide. Its first paragraph’s first portion contains "Hello, Aspose!" with the All Caps effect applied, as shown below.

![The All Caps effect](all_caps_effect.png)

The code example below shows how to extract the text with the **All Caps** effect applied:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **FAQ**

**How do I modify text in a table on a slide?**

To modify text in a table on a slide, use [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Iterate through the cells and update each cell through [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) and paragraph formatting through [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**How do I apply a gradient color to text on a PowerPoint slide?**

To apply a gradient color to text, use [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Set [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) to [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) and configure the gradient stops, direction, and transparency.
