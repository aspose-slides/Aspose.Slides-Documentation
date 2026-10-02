---
title: Μορφοποίηση Κειμένου Παρουσίασης σε .NET
linktitle: Διαμόρφωση Κειμένου
type: docs
weight: 50
url: /el/net/text-formatting/
keywords:
- στοίχιση παραγράφου
- στυλ κειμένου
- φόντο κειμένου
- διαφάνεια κειμένου
- διάστημα χαρακτήρων
- ιδιότητες γραμματοσειράς
- οικογένεια γραμματοσειράς
- περιστροφή κειμένου
- γωνία περιστροφής
- πλαίσιο κειμένου
- διάστημα γραμμών
- ιδιότητα αυτόματης προσαρμογής
- άγκυρα πλαισίου κειμένου
- καρτέλες κειμένου
- προεπιλεγμένη γλώσσα
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μορφοποιήστε και διαμορφώστε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Προσαρμόστε γραμματοσειρές, χρώματα, στοίχιση και άλλα."
---
## **Επισκόπηση**

Αυτό το άρθρο δείχνει πώς να μορφοποιήσετε κείμενο σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας το Aspose.Slides για .NET. Καλύπτει τα χρώματα φόντου, τη διαφάνεια, το διάστημα χαρακτήρων, τις ιδιότητες γραμματοσειράς, την περιστροφή, το διάστημα παραγράφων, τη συμπεριφορά αυτόματης προσαρμογής, την αγκύρωση κειμένου, τις στάσεις καρτέλας και τις ρυθμίσεις γλώσσας.

Unless stated otherwise, the examples use [sample.pptx](sample.pptx). The first shape on its first slide is a text box, and its first paragraph contains the text shown below. Both slide and shape indices are zero-based. Examples that select bold portions use effective formatting, including inherited bold formatting:

![Δειγματικό κείμενο](sample_text.png)

To find and highlight literal text or regular-expression matches, see [Αναζήτηση και Αντικατάσταση Κειμένου](/slides/el/net/search-and-replace-text/).

## **Ορισμός Χρώματος Φόντου Κειμένου**

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

// Ορίστε το χρώμα επισήμανσης για ολόκληρη την παράγραφο.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η γκρι παράγραφος](gray_paragraph.png)

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
        // Ορίστε το χρώμα επισήμανσης για το τμήμα κειμένου.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Τα γκρι τμήματα κειμένου](gray_text_portions.png)

## **Στοίχιση Παραγράφων Κειμένου**

Use [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) to set paragraph alignment within a text frame. The value can be centered, left-aligned, right-aligned, justified, and so on.

The following code example shows how to align the paragraph to the **center**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε τη στοίχιση της παραγράφου στο κέντρο.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η στοιχισμένη παράγραφος](aligned_paragraph.png)

## **Στοίχιση Γραμματοσειρών Εντός Γραμμής**

Use [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) to vertically align text portions of different font sizes within a line. This setting applies to the entire paragraph and controls alignment within each of its lines.

The following self-contained example creates four labeled text boxes on one slide. Each paragraph contains the same text at 18, 36, and 54 points, with a different font alignment. It uses Arial, disables autofit and wrapping, and keeps the text frames large enough for a single line.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Σύγκριση στοίχισης γραμματοσειρών Βάσης, Πάνω, Κέντρο και Κάτω με μικτά μεγέθη γραμματοσειρών](font_alignment.png)

Font alignment uses font metrics, so the visible edges of individual letters do not necessarily line up exactly. The example includes both an uppercase letter and a descender to help show the difference between baseline and bottom alignment. Font availability and substitution, the characters used, and the difference in font sizes affect the result. Frame dimensions, margins, line spacing, wrapping, and autofit also affect layout; use the same fonts and layout settings when comparing modes.

This setting differs from [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), which controls horizontal paragraph alignment, and [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), which positions the text block vertically within its shape. Superscript and subscript formatting through [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) shifts individual portions relative to the baseline instead of setting font alignment for the paragraph's lines.

## **Ορισμός Διαφάνειας για Κείμενο**

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

// Ορίστε μισοδιαφανές μαύρο γέμισμα για το κείμενο.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Η διαφανής παράγραφος](transparent_paragraph.png)

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
        // Ορίστε τη διαφάνεια του τμήματος κειμένου.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Τα διαφανή τμήματα κειμένου](transparent_text_portions.png)

## **Ορισμός Διαστήματος Χαρακτήρων για Κείμενο**

Use [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) to expand or condense spacing between characters in a text box. The examples add 3 points of spacing; negative values condense the text.

The following C# code shows how to expand the character spacing in the **entire paragraph**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Επέκταση διαστήματος χαρακτήρων.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στην παράγραφο](character_spacing_in_paragraph.png)

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
        // Σημείωση: Χρησιμοποιήστε αρνητικές τιμές για να συμπιέσετε το διάστημα χαρακτήρων.
        portion.PortionFormat.Spacing = 3;  // Επέκταση διαστήματος χαρακτήρων.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Το διάστημα χαρακτήρων στα τμήματα κειμένου](character_spacing_in_text_portions.png)

### **Απενεργοποίηση Kerning για Συγκεκριμένες Γραμματοσειρές**

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

## **Διαχείριση Ιδιοτήτων Γραμματοσειράς Κειμένου**

Font properties can be set at the paragraph level through [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) or on individual portions through [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

The following example sets the first paragraph’s default font to 12-point Times New Roman with bold, italic, and dotted underline formatting. Explicit formatting on individual portions takes precedence over these defaults.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Ορίστε τις ιδιότητες γραμματοσειράς για την παράγραφο.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για την παράγραφο](font_properties_for_paragraph.png)

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
        // Ορίστε τις ιδιότητες γραμματοσειράς για το τμήμα κειμένου.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Το αποτέλεσμα:

![Οι ιδιότητες γραμματοσειράς για τα τμήματα κειμένου](font_properties_for_text_portions.png)

## **Ορισμός Περιστροφής Κειμένου**

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

Το αποτέλεσμα:

![Η περιστροφή του κειμένου](text_rotation.png)

## **Ορισμός Προσαρμοσμένης Περιστροφής για Πλαίσια Κειμένου**

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

Το αποτέλεσμα:

![Η προσαρμοσμένη περιστροφή κειμένου](custom_text_rotation.png)

## **Ορισμός Διαστήματος Γραμμών Παραγράφων**

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

Το αποτέλεσμα:

![Το διάστημα γραμμών μέσα στην παράγραφο](line_spacing.png)

## **Έλεγχος Σπασίματος Γραμμής**

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

## **Έλεγχος Κρεμαπούσας Στίξης**

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

Not every punctuation mark can hang. The [font and layout conditions described above](#control-line-breaking) also apply to this comparison: changing the font, available width, margins, or autofit settings can remove the visible difference.

## **Ορισμός Τύπου Αυτοπροσαρμογής για Πλαίσια Κειμένου**

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

To count lines after automatic wrapping and see how text or shape width changes the result, see [Count Rendered Lines](/slides/el/net/manage-paragraph/). Line count alone does not indicate whether text overflows its container.

## **Ορισμός Άγκυρας Πλαισίων Κειμένου**

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

## **Ορισμός Καρτέλας Κειμένου**

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

Το αποτέλεσμα:

![Οι καρτέλες της παραγράφου](paragraph_tabs.png)

## **Ορισμός Γλώσσας Ελέγχου Ορθογραφίας**

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

// Ορίστε τη γλώσσα ελέγχου ορθογραφίας σε απλοποιημένα κινέζικα.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Ορισμός Προεπιλεγμένης Γλώσσας**

Use [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) to define the default language for text created while loading or creating a presentation. The following example creates a presentation with US English as the default text language, adds a text box, and prints `en-US` for its first text portion.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Προσθέστε ένα νέο σχήμα ορθογωνίου με κείμενο.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ελέγξτε τη γλώσσα του πρώτου τμήματος.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Ορισμός Προεπιλεγμένου Στυλ Κειμένου**

To apply default text formatting at the presentation level, use [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

The following example sets a 14-point bold font as the default for top-level paragraphs in a new presentation and saves it to "default_text_style.pptx". Text can inherit these defaults unless more specific formatting overrides them.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Ανάκτηση της μορφοποίησης παραγράφου υψηλότερου επιπέδου.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Ανάκτηση Κειμένου με το Εφέ Όλων-Κεφαλαίων**

In PowerPoint, applying the **All Caps** font effect makes text appear in uppercase on the slide even when it was originally typed in lowercase. When you retrieve such a text portion with Aspose.Slides, the library returns the text exactly as it was entered. To match the displayed text, check [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) and convert the returned string to uppercase when the value is `All`.

This example requires "sample2.pptx" with a text box as the first shape on the first slide. Its first paragraph’s first portion contains "Hello, Aspose!" with the All Caps effect applied, as shown below.

![Το εφέ Όλων-Κεφαλαίων](all_caps_effect.png)

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

## **Συχνές Ερωτήσεις**

**How do I modify text in a table on a slide?**

To modify text in a table on a slide, use [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Iterate through the cells and update each cell through [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) and paragraph formatting through [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**How do I apply a gradient color to text on a PowerPoint slide?**

To apply a gradient color to text, use [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Set [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) to [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) and configure the gradient stops, direction, and transparency.