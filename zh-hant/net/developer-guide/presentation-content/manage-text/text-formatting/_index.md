---
title: 在 .NET 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/net/text-formatting/
keywords:
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型家族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動適應屬性
- 文字框錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 簡報中格式化與設定文字樣式。自訂字型、顏色、對齊方式等。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 簡報中格式化文字。內容涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點以及語言設定。

除非另有說明，範例均使用 [sample.pptx](sample.pptx)。第一張投影片的第一個形狀是一個文字方塊，其第一段落包含下方顯示的文字。投影片與形狀的索引均為零基。選取粗體部份的範例使用有效格式，包括繼承的粗體格式：

![Sample text](sample_text.png)

若要尋找並標示文字字面值或正規表達式匹配項，請參閱 [搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/)。

## **設定文字背景色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 設定段落的預設醒目色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) 為單獨的文字片段設定醒目色。

下列範例將淡灰色醒目色設為第一段落的預設。個別片段上明確設定的醒目色會覆蓋此預設值：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定整段落的醒目顏色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![The gray paragraph](gray_paragraph.png)

以下程式碼示範如何為 **粗體字體** 的文字片段設定背景色：

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
        // 設定文字片段的醒目顏色。
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![The gray text portions](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 在文字框內設定段落對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

下列程式碼示範如何將段落對齊至 **置中**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定段落的對齊方式為置中。
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![The aligned paragraph](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) 在同一行內垂直對齊不同字型大小的文字片段。此設定套用於整個段落，並控制每行內的對齊方式。

下列獨立範例在同一張投影片上建立四個帶標籤的文字方塊。每個段落均使用相同文字，字型大小分別為 18、36、54 點，且字型對齊方式不同。範例使用 Arial，停用自動適應與換行，並將文字框調整至足以容納單行文字的大小。

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

結果：

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

字型對齊使用字型度量資訊，因此個別字母的可見邊緣未必完全對齊。範例同時包含大寫字母與下行字元，以說明基線與底部對齊的差異。字型的可用性與替代、所使用的字元以及字型大小的差異都會影響最終結果。文字框尺寸、邊距、行距、換行與自動適應亦會影響版面；在比較模式時請使用相同的字型與版面設定。

此設定與 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)（控制水平段落對齊）以及 [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)（在形狀內垂直定位文字區塊）不同。透過 [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) 進行上下標格式設定時，會相對於基線移動個別片段，而非設定段落行的字型對齊。

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) 的顏色之 alpha 成分來控制。以下範例中的 `alpha = 50` 為 ARGB alpha 通道值，範圍為 0–255，並非百分比。

下列程式碼示範如何將 **整段落** 設為透明：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定文字的半透明黑色填充。
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![The transparent paragraph](transparent_paragraph.png)

以下程式碼示範如何將 **粗體字體** 的文字片段設為透明：

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
        // 設定文字片段的透明度。
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![The transparent text portions](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) 來在文字方塊內擴張或收縮字元間距。範例將間距增加 3 點；負值則會收縮文字。

下列 C# 程式碼示範如何在 **整段落** 內擴張字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注意：使用負值可壓縮字元間距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 擴展字元間距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

下列程式碼示範如何在 **粗體字體** 的文字片段內擴張字元間距：

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
        // 注意：使用負值可壓縮字元間距。
        portion.PortionFormat.Spacing = 3;  // 擴展字元間距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 渲染的文字可能比 PowerPoint 中顯示的稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型本身具備有效的字距微調資訊且 PowerPoint 設定已啟用。

若要使渲染結果更接近 PowerPoint，可針對使用受影響字型的文字片段停用字距微調。將 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為大於實際字型尺寸的值。本範例需要「presentation.pptx」且第一張投影片的第一個形狀為文字方塊。程式會檢查有效字型名稱（包括繼承字型），並對使用 Roboto 且字型尺寸低於 100 點的片段設定 100 點的門檻，以停用其字距微調：

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

對於符合門檻的文字，此設定會阻止字距微調，協助 Aspose.Slides 的渲染與 PowerPoint 針對受此 PowerPoint 特定行為影響的字型之視覺輸出更為一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) 在個別片段層級設定。

下列範例將第一段落的預設字型設為 12 點 Times New Roman，且同時套用粗體、斜體與點狀底線。個別片段的明確格式會優先於這些預設值：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定段落的字型屬性。
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

下列範例對有效格式為粗體的片段套用 13 點 Times New Roman、斜體與點狀底線：

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
        // 設定文字片段的字型屬性。
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) 於形狀內設定預定義的文字方向。

下列程式碼將文字方向設為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)，即將文字 **逆時針旋轉 90 度**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

結果：

![The text rotation](text_rotation.png)

## **為文字框設定自訂旋轉角度**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 為 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 設定自訂旋轉角度。

下列程式碼將文字框在形狀內順時針旋轉 3 度：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

結果：

![The custom text rotation](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) 與 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。使用方式如下：

* 使用正值以百分比方式指定行距（相對於行高）。
* 使用負值以點數方式指定行距。

下列範例將第一段落的內部間距設為行高的 200%（雙倍行距）：

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

結果：

![The line spacing within the paragraph](line_spacing.png)

## **控制換行規則**

段落換行規則在窄文字區塊以及混合拉丁與東亞文字的簡報中相當有用。以下屬性屬於 [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)，因而套用於整段落：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文字的換行規則。於混合文字中變更此屬性亦會影響相鄰的東亞文字與標點換行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制東亞文字的換行規則，包括行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)，後者啟用文字框內的自動換行。規則會影響換行發生時的版面布局，但不會插入換行字元。明確的換行符號會強制在段落內產生新行，且不受可用寬度限制。

下列獨立範例建立包含中文與拉丁文字的窄文字區塊，明確設定兩項換行屬性，並儲存為「line_breaking.pptx」。若要實驗任一規則，只需變更該屬性的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點且水平文字框邊距為 0。將 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 設為 [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/)，以固定文字大小與框尺寸：

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

## **控制懸掛標點**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允許符合條件的標點延伸至文字行的右側邊緣，而不是占據下一行。此屬性套用於整段落，且不同於懸掛縮排。

下列獨立範例在寬度為 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 與水平文字框邊距為 0 時，最後的句點會留在「sentence」之後，並延伸超出文字右邊緣。將屬性設為 [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 可作比較：此設定下，句點會佔據單獨一行。開啟換行且停用自動適應，以保持可用寬度固定。

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

並非所有標點皆可懸掛。上述 [字型與版面條件](#control-line-breaking) 亦適用於此比較：變更字型、可用寬度、邊距或自動適應設定皆可能消除可見差異。

## **設定文字框的自動適應類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 決定文字超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整形狀大小。下列範例將形狀設定為依文字自動調整尺寸，並將結果儲存為「autofit_type.pptx」：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自動換行後計算行數並觀察文字或形狀寬度變化的結果，請參閱 [計算呈現行數](/slides/zh-hant/net/manage-paragraph/)。僅行數並不足以判斷文字是否溢出容器。

## **設定文字框的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在形狀內的垂直定位，例如頂部、中央或底部。下列範例將文字錨定於第一個形狀的底部，並將結果儲存為「text_anchor.pptx」：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **設定文字定位點**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) 與 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) 於段落內配置定位點。下列範例將預設定位點間距設為 100 點，並在 30 點處加入左對齊的定位點。此設定會影響含有定位字元的文字。

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

結果：

![The paragraph tabs](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)，可為文字片段設定校對語言。校對語言決定 PowerPoint 進行拼字與文法檢查時使用的語言。

下列範例需要「presentation.pptx」，且第一張投影片的第一個形狀為文字方塊，且至少有一個段落。範例將第一段落內容取代為「1。」、將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)，最後儲存為「proofing_language.pptx」：

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

// 設定校對語言為簡體中文。
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **設定預設語言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) 定義在載入或建立簡報時所建立文字的預設語言。下列範例建立一個預設文字語言為美式英語的簡報，加入文字方塊，並輸出其第一個文字片段的語言代碼 `en-US`：

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 新增具有文字的矩形形狀。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 檢查第一個文字片段的語言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)。

下列範例將新簡報中最高層段落的預設字型設為 14 點粗體，並將其儲存為「default_text_style.pptx」。文字會繼承這些預設值，除非有更具體的格式覆寫它們。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// 取得頂層段落格式。
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **提取全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps**（全部大寫）字型效果會讓文字在投影片上以大寫顯示，即使原始輸入為小寫。使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要與顯示的文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，且第一張投影片的第一個形狀為文字方塊。其第一段落的第一片段包含「Hello, Aspose!」且套用 All Caps 效果，如下圖所示。

![The All Caps effect](all_caps_effect.png)

以下程式碼示範如何在提取文字時套用 **All Caps** 效果：

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

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何在投影片的表格中修改文字？**

要在投影片的表格中修改文字，請使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 更新每個儲存格，並使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要為文字套用漸層顏色，請使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。