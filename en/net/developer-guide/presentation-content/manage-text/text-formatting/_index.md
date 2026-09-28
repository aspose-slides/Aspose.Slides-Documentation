---
title: Format Presentation Text in .NET
linktitle: Text Formatting
type: docs
weight: 50
url: /net/text-formatting/
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
- .NET
- C#
- Aspose.Slides
description: "Format and style text in PowerPoint and OpenDocument presentations using Aspose.Slides for .NET. Customize fonts, colors, alignment, and more."
---

## **Overview**

This article shows how to format text in PowerPoint and OpenDocument presentations using Aspose.Slides for .NET. It covers background colors, transparency, character spacing, font properties, rotation, paragraph spacing, autofit behavior, text anchoring, tab stops, and language settings.

Unless stated otherwise, the examples use [sample.pptx](sample.pptx). The first shape on its first slide is a text box, and its first paragraph contains the text shown below. Both slide and shape indices are zero-based. Examples that select bold portions use effective formatting, including inherited bold formatting:

![Sample text](sample_text.png)

To find and highlight literal text or regular-expression matches, see [Search and Replace Text](/slides/net/search-and-replace-text/).

## **Set Text Background Color**

Use [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) to set the default highlight color for a paragraph, or use [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) for individual text portions.

The following example sets a light gray highlight as the default for the first paragraph. Explicit highlight colors on individual portions take precedence over this default:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Set the highlight color for the entire paragraph.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

The result:

![The gray paragraph](gray_paragraph.png)

The code example below demonstrates how to set the background color for **text portions with a bold font**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Set the highlight color for the text portion.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

The result:

![The gray text portions](gray_text_portions.png)

## **Align Text Paragraphs**

Use [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) to set paragraph alignment within a text frame. The value can be centered, left-aligned, right-aligned, justified, and so on.

The following code example shows how to align the paragraph to the **center**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Set the alignment of the paragraph to center.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

The result:

![The aligned paragraph](aligned_paragraph.png)

## **Set Transparency for Text**

Text transparency is controlled through the alpha component of the color assigned to [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). In the examples below, `alpha = 50` is an ARGB alpha-channel value on the 0–255 scale, not a transparency percentage.

The code example below shows how to apply transparency to the **entire paragraph**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Set a semitransparent black fill for the text.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

The result:

![The transparent paragraph](transparent_paragraph.png)

The following code example shows how to apply transparency to **text portions with a bold font**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Set the transparency of the text portion.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

The result:

![The transparent text portions](transparent_text_portions.png)

## **Set Character Spacing for Text**

Use [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) to expand or condense spacing between characters in a text box. The examples add 3 points of spacing; negative values condense the text.

The following C# code shows how to expand the character spacing in the **entire paragraph**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Note: Use negative values to compress the character spacing.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Expand character spacing.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

The result:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

The code example below shows how to expand the character spacing in **text portions with a bold font**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Note: Use negative values to compress the character spacing.
        portion.PortionFormat.Spacing = 3;  // Expand character spacing.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

The result:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Disable Kerning for Specific Fonts**

In some cases, text rendered by Aspose.Slides may look slightly tighter than the same text displayed in PowerPoint. This can happen because PowerPoint may ignore kerning data for certain fonts, even when the font contains valid kerning information and kerning is enabled in PowerPoint settings.

To make the rendered output closer to PowerPoint in such cases, you can disable kerning for text portions that use the affected font. Set [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) to a value larger than the actual font size. This example requires "presentation.pptx" with a text box as the first shape on the first slide. It checks effective font names, including inherited fonts, and sets a 100-point threshold for portions that use Roboto. This disables kerning for matching portions with a font size below 100 points:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

For matching text below the threshold, this setting prevents kerning and can help align Aspose.Slides rendering with PowerPoint’s visual output for fonts affected by this PowerPoint-specific behavior.

## **Manage Text Font Properties**

Font properties can be set at the paragraph level through [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) or on individual portions through [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

The following example sets the first paragraph’s default font to 12-point Times New Roman with bold, italic, and dotted underline formatting. Explicit formatting on individual portions takes precedence over these defaults.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Set the font properties for the paragraph.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

The result:

![The font properties for the paragraph](font_properties_for_paragraph.png)

The following example applies 13-point Times New Roman, italic formatting, and a dotted underline to portions whose effective formatting is bold:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Set the font properties for the text portion.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

The result:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Set Text Rotation**

Use [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) to set a predefined text orientation within a shape.

The following code example sets the text orientation in the shape to [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), which rotates the text **90 degrees counterclockwise**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

The result:

![The text rotation](text_rotation.png)

## **Set Custom Rotation for Text Frames**

Use [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) to set a custom rotation angle for an [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

The code example below rotates the text frame by 3 degrees clockwise within the shape:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

The result:

![The custom text rotation](custom_text_rotation.png)

## **Set Line Spacing of Paragraphs**

Aspose.Slides provides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), and [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) to control paragraph spacing. These properties are used as follows:

* Use a positive value to specify line spacing as a percentage of the line height.
* Use a negative value to specify line spacing in points.

The following example sets spacing within the first paragraph to 200% of the line height (double spacing):

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

The result:

![The line spacing within the paragraph](line_spacing.png)

## **Control Line Breaking**

Paragraph line-breaking rules are useful in narrow text blocks and presentations that mix Latin and East Asian text. The following properties belong to [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), so they apply to an entire paragraph:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) controls Latin line-breaking rules. In mixed text, changing it can also change where adjacent East Asian text and punctuation wrap.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) controls East Asian line-breaking rules, including restrictions on characters at the beginning and end of a line.

These rules do not replace [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), which enables automatic wrapping within a text frame. They influence the layout when wrapping occurs; they do not insert line-break characters. An explicit line break forces a new line within the paragraph independently of the available width.

The following self-contained example creates a narrow text block containing Chinese and Latin text. It sets both line-breaking properties explicitly and saves "line_breaking.pptx". To experiment with either rule, change that property's value while keeping the other settings fixed. The example uses 24-point Arial and SimSun with a 160-point frame width and zero horizontal text-frame margins. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) is set to [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) so that text size and frame dimensions remain fixed.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Control Hanging Punctuation**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) allows eligible punctuation to extend beyond the text line's right edge instead of occupying the next line. It applies to the entire paragraph and is different from a hanging indent.

The following self-contained example enables hanging punctuation in a 100-point-wide text frame and saves "hanging_punctuation.pptx". With 24-point Arial and zero horizontal text-frame margins, the final period stays after "sentence" and extends beyond the right text edge. Set the property to [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) to compare: with these settings, the period occupies a separate line. Wrapping is enabled and autofit is disabled to keep the available width fixed.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Not every punctuation mark can hang. The [font and layout conditions described above](#conditions-and-limitations) also apply to this comparison: changing the font, available width, margins, or autofit settings can remove the visible difference.

## **Set Autofit Type for Text Frames**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) determines how text behaves when it exceeds the boundaries of its container. Use it to control whether the text shrinks, overflows, or resizes the shape automatically. The following example configures the shape to resize to fit its text and saves the result to "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

To count lines after automatic wrapping and see how text or shape width changes the result, see [Count Rendered Lines](/slides/net/manage-paragraph/). Line count alone does not indicate whether text overflows its container.

## **Set Anchor of Text Frames**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) defines how text is positioned vertically inside a shape, for example, at the top, middle, or bottom. The following example anchors the text to the bottom of the first shape and saves the result to "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Set Text Tabulation**

Use [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) and [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) to configure tab stops in a paragraph. The following example sets the default tab interval to 100 points and adds a left-aligned tab stop at 30 points. These settings affect text containing tab characters.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

The result:

![The paragraph tabs](paragraph_tabs.png)

## **Set Proofing Language**

Aspose.Slides provides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), which allows you to set the proofing language for a text portion. The proofing language determines the language used for spelling and grammar checks in PowerPoint.

The following example requires "presentation.pptx" with a text box as the first shape on the first slide and at least one paragraph. It replaces the first paragraph’s contents with "1。", sets SimSun as its font, and assigns the Simplified Chinese proofing language (`zh-CN`). It saves the result to "proofing_language.pptx":

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Set the proofing language to Simplified Chinese.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Set Default Language**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) to define the default language for text created while loading or creating a presentation. The following example creates a presentation with US English as the default text language, adds a text box, and prints `en-US` for its first text portion.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Add a new rectangle shape with text.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Check the first portion language.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Set Default Text Style**

To apply default text formatting at the presentation level, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

The following example sets a 14-point bold font as the default for top-level paragraphs in a new presentation and saves it to "default_text_style.pptx". Text can inherit these defaults unless more specific formatting overrides them.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Get the top level paragraph format.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extract Text with the All-Caps Effect**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To match the displayed text, check [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) and convert the returned string to uppercase when the value is `All`.

This example requires "sample2.pptx" with a text box as the first shape on the first slide. Its first paragraph’s first portion contains "Hello, Aspose!" with the All Caps effect applied, as shown below.

![The All Caps effect](all_caps_effect.png)

The code example below shows how to extract the text with the **All Caps** effect applied:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**How do I modify text in a table on a slide?**

To modify text in a table on a slide, use [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Iterate through the cells and update each cell through [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) and paragraph formatting through [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**How do I apply a gradient color to text on a PowerPoint slide?**

To apply a gradient color to text, use [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Set [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) to [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) and configure the gradient stops, direction, and transparency.
