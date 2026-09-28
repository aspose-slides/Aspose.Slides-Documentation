---
title: 於 .NET 中格式化簡報文字
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
- 字型族
- 文字旋轉
- 旋轉角度
- 文字框
- 行距
- 自動調整屬性
- 文字框錨點
- 文字定位
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與設計文字。自訂字型、顏色、對齊方式等多項設定。"
---
## **概觀**

本篇說明如何使用 Aspose.Slides for .NET 以 PowerPoint 與 OpenDocument 簡報中格式化文字。內容包含背景色彩、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

除非另有說明，範例使用 [sample.pptx](sample.pptx)。第一張投影片的第一個圖形是一個文字方塊，其第一段落包含以下顯示的文字。投影片和圖形的索引皆為零基礎。選取粗體部分的範例使用有效格式，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要尋找並標記文字字面值或正規表示式相符項目，請參閱 [搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/)。

## **設定文字背景色彩**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 設定段落的預設底色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/highlightcolor/) 為單一文字區塊設定底色。

以下範例將第一段落的預設底色設定為淺灰色。個別文字區塊的明確底色會優先於此預設：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定整段落的底色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型** 的文字區塊設定背景色：

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
        // 設定文字區塊的底色。
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![灰色文字部分](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 設定文字框內段落的對齊方式。可設定為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊至 **置中**：

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

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/fillformat/) 的顏色之 Alpha 成分控制。以下範例中，`alpha = 50` 為 ARGB 透明度通道值，範圍 0–255，並非百分比。

以下程式碼示範如何將 **整段落** 設為透明：

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

![透明段落](transparent_paragraph.png)

以下程式碼示範如何將 **粗體字型** 的文字區塊設為透明：

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
        // 設定文字區塊的透明度。
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![透明文字部分](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/spacing/) 調整文字方塊中字元之間的間距。以下範例在 **整段落** 增加 3 點間距；負值則會壓縮文字。

以下 C# 程式碼示範如何在 **整段落** 展開字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注意：使用負值可壓縮字元間距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 展開字元間距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型** 的文字區塊展開字元間距：

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
        portion.PortionFormat.Spacing = 3;  // 展開字元間距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![文字部分的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 渲染的文字可能比 PowerPoint 顯示的稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型內含有效的字距微調資訊且在 PowerPoint 設定中已啟用。

若要使渲染結果更貼近 PowerPoint，可對使用受影響字型的文字區塊停用字距微調。將 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為大於實際字型大小的值。本範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包含繼承的字型），並對使用 Roboto 且字型大小低於 100 點的區塊設定門檻，從而停用字距微調：

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

對於低於門檻的匹配文字，此設定會阻止字距微調，協助將 Aspose.Slides 的渲染與 PowerPoint 在受此 PowerPoint 特定行為影響的字型上保持一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/) 在單一文字區塊設定。

以下範例將第一段落的預設字型設定為 12 點 Times New Roman，並套用粗體、斜體及點狀底線。個別文字區塊的明確格式會優先於此預設：

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

![段落的字型屬性](font_properties_for_paragraph.png)

以下範例對有效格式為粗體的文字區塊套用 13 點 Times New Roman、斜體及點狀底線：

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
        // 設定文字區塊的字型屬性。
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![文字部分的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/textverticaltype/) 可在圖形內設定預定義的文字方向。

以下程式碼將圖形內的文字方向設定為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textverticaltype/)，即 **逆時針旋轉 90 度**：

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

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/rotationangle/) 可為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼在圖形內將文字框順時針旋轉 3 度：

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

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacebefore/) 以及 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值表示以點數指定行距。

以下範例將第一段落的行內間距設定為行高的 200%（雙倍行距）：

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

![段落內的行距](line_spacing.png)

## **控制換行**

段落換行規則在窄幅文字區塊以及混合拉丁與東亞文字的簡報中特別有用。以下屬性屬於 [IParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/)，因此會套用於整個段落：

- [LatinLineBreak](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文字的換行規則。在混合文字中，修改此屬性也會影響相鄰東亞文字與標點的換行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制東亞文字的換行規則，包括行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/wraptext/)，後者會在文字框內自動換行。上述規則只會在換行發生時影響版面佈局，且不會插入換行字元。明確的換行會強制段落於該處另起新行，與可用寬度無關。

以下完整範例建立一個包含中文與拉丁文字的窄幅文字區塊，明確設定兩項換行屬性，並儲存為「line_breaking.pptx」。若要測試任一規則，只需變更該屬性值，同時保留另一設定不變。範例使用 24 點 Arial 與 SimSun、框寬 160 點，且水平文字框邊距為 0。將 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/autofittype/) 設為 [TextAutofitType.None](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textautofittype/) 以固定文字大小與框尺寸。

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
paragraph.Text = "中文排版測試，PowerPoint 中文演示。";

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允許符合條件的標點超出文字行的右邊緣，而非佔用下一行。此屬性適用於整段落，且與懸掛縮排不同。

以下完整範例在寬度 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial、水平文字框邊距為 0，最終句點會留在「sentence」之後，並超出文字右邊緣。將屬性設為 [NullableBool.False](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/nullablebool/) 以比較：此設定下，句點會佔用獨立一行。範例同時啟用自動換行並停用自動調整，以固定可用寬度。

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

並非所有標點皆可懸掛。上述的[字型與版面條件](#conditions-and-limitations)同樣適用於此比較：變更字型、可用寬度、邊距或自動調整設定，都可能使可見差異消失。

## **設定文字框的自動調整類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/autofittype/) 決定文字超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整圖形大小。以下範例將圖形設定為依文字自動調整大小，並儲存為「autofit_type.pptx」。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自動換行後計算行數，並觀察文字或圖形寬度變化的結果，請參閱 [Count Rendered Lines](/slides/zh-hant/net/manage-paragraph/)。僅憑行數無法判斷文字是否溢出容器。

## **設定文字框的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在圖形內的垂直定位方式，例如置頂、置中或置底。以下範例將文字錨定於第一個圖形的底部，並儲存為「text_anchor.pptx」。

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

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaulttabsize/) 與 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/tabs/) 來設定段落中的定位點。以下範例將預設定位間距設為 100 點，並在 30 點處加入左對齊的定位點。這些設定會影響包含定位字元的文字。

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

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/)，可為文字區塊設定校對語言。校對語言決定 PowerPoint 中拼寫與文法檢查所使用的語言。

以下範例需要「presentation.pptx」且第一張投影片的第一個圖形為文字方塊，且至少有一個段落。它會將第一段落的內容取代為「1。」、將字型設為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。結果儲存為「proofing_language.pptx」：

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

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/) 可為載入或建立簡報時所產生的文字定義預設語言。以下範例建立一份預設文字語言為美式英語的簡報，加入文字方塊，並輸出其第一個文字區塊的語言代碼 `en-US`。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 新增一個帶文字的矩形形狀。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 檢查第一個文字區塊的語言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下範例為新簡報的最高層段落設定 14 點粗體字型作為預設，並儲存為「default_text_style.pptx」。除非有更具體的格式覆寫，文字會繼承這些預設。

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

## **擷取帶全形大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** (全形大寫) 字型效果會使文字在投影片上以全大寫顯示，即使原本輸入的是小寫。使用 Aspose.Slides 取得此類文字區塊時，函式庫會回傳原始輸入的文字。若要與顯示結果相符，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textcaptype/)，當值為 `All` 時，將回傳的字串轉換為大寫。

此範例需要「sample2.pptx」且第一張投影片的第一個圖形為文字方塊。其第一段落的第一個文字區塊含有「Hello, Aspose!」並套用 All Caps 效果，如下圖所示。

![全形大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取帶 **All Caps** 效果的文字：

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

請使用 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)，遍歷儲存格並透過 [ICell.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/textframe/) 更新每個儲存格的文字，並使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/paragraphformat/) 調整段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

請使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，並設定漸層停點、方向與透明度。