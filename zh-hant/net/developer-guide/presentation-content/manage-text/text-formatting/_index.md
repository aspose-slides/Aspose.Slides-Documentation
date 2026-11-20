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
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與美化文字。自訂字型、顏色、對齊方式等多項設定。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化文字。它涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動適應行為、文字錨點、定位點以及語言設定。

除非另有說明，範例使用 [sample.pptx](sample.pptx)。其第一張投影片的第一個圖形是一個文字方塊，第一段文字如下所示。投影片與圖形的索引皆為零基礎。選取粗體部分的範例使用有效格式，包括繼承的粗體格式：

![範例文字](sample_text.png)

若要尋找並強調文字字面值或正規表達式符合項目，請參閱 [Search and Replace Text](/slides/zh-hant/net/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 設定段落的預設突顯顏色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) 為個別文字片段設定突顯顏色。

以下範例將淡灰色突顯設定為第一段的預設。個別片段的明確突顯顏色會優先於此預設：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定整段文字的突顯顏色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **字體為粗體的文字片段** 設定背景顏色：

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
        // 設定文字片段的突顯顏色。
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 設定文字框內段落的對齊方式。可選值包括置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊至 **置中**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定段落的對齊為置中。
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **在同一行內對齊字型**

使用 [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) 垂直對齊同一行中不同字型大小的文字片段。此設定套用於整個段落，並控制其每行內的對齊方式。

以下自足範例在同一張投影片上建立四個帶標籤的文字方塊。每個段落以 18、36、54 點大小的相同文字呈現，並使用不同的字型對齊。範例使用 Arial，停用自動調整與換行，並將文字框尺寸保持足以容納單行。

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

![基線、頂端、置中與底端字型對齊比較（混合字型大小）](font_alignment.png)

字型對齊使用字型度量，因此個別字母的可見邊緣不一定完全對齊。範例同時包含大寫字母與下伸部，以說明基線與底端對齊的差異。字型可用性與替代、使用的字元以及字型大小差異都會影響結果。框架尺寸、邊距、行距、換行與自動調整亦會影響版面配置；比較模式時請使用相同的字型與版面設定。

此設定與 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)（水平段落對齊）以及 [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)（文字區塊在圖形內的垂直位置）不同。透過 [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) 進行的上標與下標格式會相對基線移動，而非為段落行設定字型對齊。

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) 的顏色之 alpha 元件來控制。以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何對 **整個段落** 套用透明度：

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

以下程式碼示範如何對 **字體為粗體的文字片段** 套用透明度：

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

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) 來調整文字方塊中字元之間的間距。範例加入 3 點間距；負值則會壓縮文字。

以下 C# 程式碼示範如何在 **整個段落** 中展開字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注意：使用負值來壓縮字元間距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 展開字元間距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **字體為粗體的文字片段** 中展開字元間距：

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
        // 注意：使用負值來壓縮字元間距。
        portion.PortionFormat.Spacing = 3;  // 展開字元間距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果：

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **為特定字型停用字距調整 (Kerning)**

在某些情況下，Aspose.Slides 所渲染的文字會比 PowerPoint 中的同樣文字略為緊湊。這可能是因為 PowerPoint 會忽略某些字型的字距資訊，即使該字型包含有效的字距資料且在 PowerPoint 設定中已啟用字距。

若要使渲染結果更貼近 PowerPoint，可對使用受影響字型的文字片段停用字距。將 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為大於實際字型大小的值。本範例需要「presentation.pptx」且其第一張投影片的第一個圖形為文字方塊。它會檢查有效的字型名稱（包括繼承的字型），並對使用 Roboto 且字型大小低於 100 點的片段設定閾值為 100 點，從而停用字距：

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

對於低於閾值的符合文字，此設定會阻止字距調整，並有助於使 Aspose.Slides 的渲染與 PowerPoint 針對受此 PowerPoint 特定行為影響的字型之視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) 在個別片段層級設定。

以下範例將第一段的預設字型設定為 12 點 Times New Roman，並使用粗體、斜體與點狀底線。個別片段的明確格式會優先於這些預設：

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

以下範例對有效格式為粗體的片段套用 13 點 Times New Roman、斜體與點狀底線：

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

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

使用 [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) 來在復刻範本排版或調查字元高度差異時進行正規化。於 PowerPoint 中，啟用正規化會垂直拉伸或壓縮個別字元，使其在文字片段內呈現統一的可見高度。此設定不會保證不同字型之間的文字高度相等。

將屬性設定為 [NullableBool.True 或 False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool.NotDefined` 會保留本地設定未設定，讓片段繼承其值，例如自段落的 [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)。它並不等同於 `False`。可使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 並讀取 [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) 取得解析後的布林值。

以下自足範例需要安裝 **Arial**。它建立兩個文字區塊，內容皆為相同的大寫字母、小寫字母、下伸部與重音字元，字型大小為 54 點。兩段皆預設啟用正規化。上方片段明確停用；下方片段繼承設定。框架尺寸、邊距與段落間距相同，且停用換行與自動調整以保持比較一致。範例會輸出 `False: False` 與 `NotDefined: True`，然後儲存為「text_height_normalization.pptx」。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

以下比較圖自已儲存的簡報匯出。上列為正規化停用 (`False`)；下列為繼承啟用 (`NotDefined` → `True`)。請保持安裝 Arial 以重現此外觀。

![Arial 54 點文字，上方正規化停用、下方繼承正規化啟用](text_height_normalization.png)

正規化會在不變更指派的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) 值（即字型大小）下改變字元高度。段落的 [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 控制行距，而文字框的 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 控制文字或其容器如何自動調整以適配。這些設定各有用途，且會獨立影響整體版面布局。欲了解更多段落格式與繼承，請參閱 [Manage Paragraph](/slides/zh-hant/net/manage-paragraph/)。

## **套用與移除刪除線**

對文字片段使用 [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) 可顯示更正、取消的詞語或先前的價格，而不必刪除原始文字。將其設定為 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) 可在文字上方加上一條或兩條線。

若要移除刪除線，請指派 `TextStrikethroughType.None`。此設定會明確停用效果，即使周圍的格式指定了刪除線。相較之下，`TextStrikethroughType.NotDefined` 會保留本地設定未定義，讓片段繼承格式（例如自段落），但不保證刪除線已被移除。可使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 讀取最終格式，包括繼承值。

以下自足範例建立三個價格比較。每段皆有標籤、先前價格與目前價格的獨立片段，僅先前價格會受到影響。第一列先套用再移除刪除線；其餘列分別保留單線與雙線刪除線。變更此屬性可在保留文字及其他格式（包括粗體先前價格）的同時，呈現不同效果。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// 套用刪除線，然後明確移除第一個先前價格的刪除線。
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

結果（自上而下）：無刪除線、單線刪除線與雙線刪除線。

![先前價格分別為無刪除線、單線刪除線與雙線刪除線的示意圖](strikethrough.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) 可在圖形內設定預定義的文字方向。

以下程式碼將圖形內的文字方向設定為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)，即文字 **逆時針旋轉 90 度**：

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

![文字旋轉效果](text_rotation.png)

## **為文字框設定自訂旋轉角度**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 可為 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 設定自訂旋轉角度。

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

![自訂文字旋轉效果](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。這些屬性的使用方式如下：

* 正值表示以行高的百分比指定行距。
* 負值表示以點數指定行距。

以下範例將第一段的內部間距設為行高的 200%（雙倍行距）：

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

## **控制換行規則**

段落換行規則在窄幅文字區塊以及混合拉丁文與東亞文字的簡報中非常有用。以下屬性屬於 [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)，因此會套用於整個段落：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文的換行規則。在混合文字中，變更此設定亦可能影響相鄰東亞文字與標點符號的換行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制東亞文字的換行規則，包含行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)，後者會在文字框內啟用自動換行。換行規則會影響文字框換行時的版面配置，但不會插入換行字元。顯式的換行會強制段落內產生新行，與可用寬度無關。

以下自足範例建立包含中文與拉丁文字的窄幅文字區塊。它明確設定兩項換行屬性，並儲存為「line_breaking.pptx」。若要測試任一規則，可在保持其他設定不變的情況下變更該屬性的值。範例使用 24 點 Arial 與 SimSun，框寬 160 點且水平文字框邊距為 0。將 [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 設為 [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/)，以固定文字大小與框架尺寸。

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允許符合條件的標點符號超出文字行的右邊緣，而不是佔用下一行。它套用於整個段落，且與懸掛縮排不同。

以下自足範例在寬度 100 點的文字框中啟用懸掛標點，並儲存為「hanging_punctuation.pptx」。使用 24 點 Arial 且水平文字框邊距為 0 時，最後的句點會停留在「sentence」之後並超出文字右邊緣。將屬性設定為 [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 以作比較：此設定下，句點會佔據單獨一行。啟用換行並停用自動調整，以固定可用寬度。

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

並非所有標點符號都能懸掛。上述的 [字型與版面條件](#control-line-breaking) 同樣適用於此比較：變更字型、可用寬度、邊距或自動調整設定都可能消除可見差異。

## **設定文字框的自動調整類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 決定文字超出容器邊界時的行為。可用它控制文字是否縮小、溢出，或自動調整圖形大小。以下範例設定圖形在文字超出時自動調整大小，並將結果儲存為「autofit_type.pptx」。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自動換行後計算行數並觀察文字或圖形寬度變化對結果的影響，請參閱 [Count Rendered Lines](/slides/zh-hant/net/manage-paragraph/)。僅行數不足以判斷文字是否溢出容器。

## **設定文字框的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在圖形內的垂直位置，例如置頂、置中或置底。以下範例將文字錨點設定為第一個圖形的底部，並將結果儲存為「text_anchor.pptx」。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **設定文字定位點 (Tab)**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) 與 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) 來配置段落中的定位點。以下範例將預設定位點間距設定為 100 點，並在 30 點處加入左對齊的定位點。這些設定會影響包含定位字元的文字。

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

![段落的定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)，可為文字片段設定校對語言。校對語言決定 PowerPoint 中的拼寫與文法檢查語言。

以下範例需要「presentation.pptx」，其第一張投影片的第一個圖形為文字方塊且至少有一段文字。它會將第一段內容替換為「1。」，將字型設定為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。然後將結果儲存為「proofing_language.pptx」：

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

### **複製語言中繼資料**

在從範本複製多語言文字時，請同時保留 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) 與 [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/)。以下自足範例建立一個來源片段，其語言為美式英語，替代語言為法語，並將文字與識別碼複製到新簡報中的片段。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// 如果來源沒有替代語言，null 會清除目的端的值。
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

若要測試沒有替代語言的來源，請省略 `"fr-FR"` 的指派。此時替代識別碼為 `null`，相同的複製語句會保留其缺失而不會插入預設值，即使目的地先前已指派替代語言。

這些識別碼屬於語言中繼資料。保留它們不會決定 PowerPoint 為拼寫或文法檢查選擇哪個字典。

## **設定預設語言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) 可定義在載入或建立簡報時所建立文字的預設語言。以下範例建立一個預設文字語言為美式英語的簡報，新增一個文字方塊，並列印其第一個文字片段的語言為 `en-US`。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 加入帶文字的新矩形形狀。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 檢查第一個文字片段的語言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下範例將 14 點粗體字型設定為新簡報中頂層段落的預設，並將其儲存為「default_text_style.pptx」。文字可以繼承這些預設，除非更具體的格式覆寫它們。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// 取得最高層級的段落格式。
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **擷取帶全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps** 字型效果會讓文字在投影片上以大寫顯示，即使實際輸入時是小寫。使用 Aspose.Slides 取得此類文字片段時，程式庫會回傳原始輸入的文字。若要與顯示文字相符，請檢查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉為大寫。

此範例需要「sample2.pptx」，其第一張投影片的第一個圖形為文字方塊。其第一段的第一片段包含「Hello, Aspose!」且套用了 All Caps 效果，如下圖所示。

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取已套用 **All Caps** 效果的文字：

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

要在投影片的表格中修改文字，可使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 更新每個儲存格，並使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 調整段落格式。

**如何在 PowerPoint 投影片上的文字套用漸層顏色？**

要為文字套用漸層顏色，請使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，並配置漸層停止點、方向與透明度。

相關功能：[Format text within slides](/slides/zh-hant/features/text-formatting/).