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
description: 使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與設計文字。自訂字型、顏色、對齊方式等更多設定。
---
## **總覽**

本文說明如何使用 Aspose.Slides for .NET 於 PowerPoint 與 OpenDocument 簡報中格式化文字。內容涵蓋背景顏色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點，以及語言設定。

除非另有說明，範例皆使用 [sample.pptx](sample.pptx)。其第一張投影片的第一個圖案是一個文字框，且第一個段落包含下方顯示的文字。投影片與圖案的索引皆為零基礎。選取粗體部份的範例使用有效的格式設定，包含繼承的粗體格式：

![範例文字](sample_text.png)

請參閱 [搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/)。

## **設定文字背景顏色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 來設定段落的預設醒目顏色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) 針對個別文字部份設定。

以下範例將淡灰色醒目標記設為第一個段落的預設。個別部份的明確醒目顏色會優先於此預設：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 設定整段落的突出顏色。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

結果如下：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體字型的文字部份** 設定背景顏色：

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
        // 設定文字部份的突出顏色。
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

結果如下：

![灰色文字部份](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 於文字框內設定段落對齊方式。其值可為置中、左對齊、右對齊、兩端對齊等。

以下程式碼示範如何將段落對齊到 **置中**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 將段落的對齊方式設定為置中。
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

結果如下：

![已對齊的段落](aligned_paragraph.png)

## **對齊行內字型**

使用 [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) 於行內垂直對齊不同字型大小的文字部份。此設定套用於整個段落，並控制每行內的對齊方式。

以下自包含範例在同一張投影片上建立四個帶標籤的文字框。每個段落以 18、36、54 點大小呈現相同文字，且使用不同的字型對齊。範例使用 Arial、停用自動調整與換行，並保持文字框足夠寬以容納單行。

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

結果如下：

![基線、頂端、置中與底部字型對齊的比較（混合字型大小）](font_alignment.png)

字型對齊依據字型度量，因此個別字母的可見邊緣未必完全對齊。範例同時包含大寫字母與下行字元，以說明基線與底部對齊的差異。字型可用性與替代、所使用的字元以及字型大小的差異皆會影響結果。框架尺寸、邊距、行距、換行與自動調整亦會影響版面；在比較不同模式時請使用相同的字型與版面設定。

此設定與 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) 不同，後者控制水平段落對齊；亦不同於 [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)，後者將文字區塊在形狀內垂直定位。透過 [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) 進行上標與下標格式化時，會將個別部份相對於基線移動，而非設定段落行的字型對齊。

## **設定文字透明度**

文字透明度透過指派給 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) 的顏色之 alpha 成分來控制。以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB alpha 通道值，並非透明度百分比。

以下程式碼示範如何將透明度套用至 **整段文字**：

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

結果如下：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何將透明度套用至 **粗體字型的文字部份**：

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
        // 設定文字部份的透明度。
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

結果如下：

![透明文字部份](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) 來在文字框中擴張或收縮字元間距。以下範例加入 3 點間距；負值則會收縮文字。

以下 C# 程式碼示範如何在 **整段文字** 中展開字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 註：使用負值可壓縮字元間距。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 展開字元間距。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果如下：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼示範如何在 **粗體字型的文字部份** 中展開字元間距：

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
        // 註：使用負值可壓縮字元間距。
        portion.PortionFormat.Spacing = 3;  // 展開字元間距。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果如下：

![文字部份中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 呈現的文字可能會比 PowerPoint 顯示的同一文字稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型包含有效的字距微調資訊，且在 PowerPoint 設定中已啟用字距微調。

為使渲染結果更接近 PowerPoint，可對使用受影響字型的文字部份停用字距微調。將 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為大於實際字型大小的值。本範例需要名為 "presentation.pptx"、其第一張投影片的第一個圖形為文字框的簡報。它會檢查有效的字型名稱（包括繼承的字型），並對使用 Roboto 的部份設定 100 點的門檻值：

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

對於低於此門檻的符合文字，此設定會阻止字距微調，並有助於使受此 PowerPoint 特定行為影響的字型之 Aspose.Slides 呈現更貼近 PowerPoint 的視覺輸出。

## **管理文字字型屬性**

字型屬性可透過段落層級的 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) 設定，或在個別部份上使用 [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) 設定。

以下範例將第一段的預設字型設為 12 點 Times New Roman，並套用粗體、斜體與點線底線格式。個別部份的明確格式會優先於此預設值。

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

結果如下：

![段落的字型屬性](font_properties_for_paragraph.png)

以下範例將 13 點 Times New Roman、斜體格式與點線底線套用至有效格式為粗體的部份：

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
        // 設定文字部份的字型屬性。
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

結果如下：

![文字部份的字型屬性](font_properties_for_text_portions.png)

## **控制文字高度正規化**

使用 [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) 於重新產生範本排版或調查字元高度差異時使用。在 PowerPoint 中，啟用正規化會垂直拉伸或壓縮個別字元，使其在文字部份內呈現統一的可見高度。它不保證不同字型之間的文字高度相等。

將屬性設為 [NullableBool.True 或 False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 以明確啟用或停用正規化。`NullableBool.NotDefined` 會保留本地設定未設定，讓部份從上層（例如段落的 [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)）繼承其值，且不等同於 `False`。使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 並讀取 [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) 以取得解析後的布林值。

以下自包含範例需要安裝 **Arial**。它會建立兩個文字區塊，內容包含相同的大寫字母、小寫字母、下行字元與重音字元，字型大小為 54 點。兩個段落預設皆啟用正規化。上方部份明確停用；下方部份則繼承。框架尺寸、邊距與段落間距皆相同，且停用換行與自動調整以保持比較一致。範例會輸出 `False: False` 與 `NotDefined: True`，然後儲存為 "text_height_normalization.pptx"。

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

以下比較圖自已儲存的簡報匯出。上列的正規化已停用 (`False`)；下列則繼承啟用的設定 (`NotDefined` → `True`)。請保持安裝 Arial 以重現此外觀。

![Arial 54 點文字，上方正規化停用、下方正規化繼承啟用](text_height_normalization.png)

正規化會在不變更指派的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/)（字型大小）值的情況下改變字元高度。段落的 [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 控制行距，而文字框的 [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 則控制文字或其容器的調整方式。這些設定用途不同，且會獨立影響整體版面配置。欲了解更多段落格式與繼承資訊，請參閱 [管理段落](/slides/zh-hant/net/manage-paragraph/)。

## **套用與移除刪除線**

使用 [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) 於文字部份上顯示修訂、取消的詞語或先前的價格，而不刪除原始文字。將其設定為 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) 即可在文字上加上一條或兩條刪除線。

要移除刪除線，將其指派為 `TextStrikethroughType.None`。此設定會明確停用效果，即使周圍的格式指定刪除線。相較之下，`TextStrikethroughType.NotDefined` 會保留本地設定未定義，允許部份從段落等上層繼承格式，並不保證刪除線被移除。使用 [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) 可讀取最終的格式，包括繼承值。

以下自包含範例建立三個價格比較。每個段落都有標籤、先前價格與目前價格的獨立部份，僅先前價格會受到影響。首列先套用再移除刪除線；其餘列分別保留單一與雙重刪除線。變更此屬性會保留文字及其他格式，包括粗體的先前價格。

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

結果（由上至下）：無刪除線、單一刪除線與雙重刪除線。

![先前價格（無刪除線、單一刪除線、雙重刪除線）](strikethrough.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) 於形狀內設定預定義的文字方向。以下程式碼將形狀內的文字方向設為 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/)，此設定會使文字 **逆時針旋轉 90 度**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

結果如下：

![文字旋轉](text_rotation.png)

## **在直排文字中並排顯示數字**

要在直排日文標籤中將兩位數字保持在一起，請將兩個數字放在同一文字部份，並於該部份設定 [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/)。範例使用 [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) 以及 40 點 MS Gothic 於兩個標籤。唯一不同的是指派給數字部份的 [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

在 PowerPoint 中，左側標籤 (`True`) 會在 和 與 年 之間以直立方式並排顯示數字。右側標籤 (`False`) 則會將該組數字順時針旋轉 90 度。兩個標籤的周圍日文字元皆保持直立。

![PowerPoint 直排日期標籤比較：左側數字直立，右側數字旋轉](vertical_date.png)

## **設定文字框的自訂旋轉**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 來設定 [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) 的自訂旋轉角度。以下程式碼於形狀內將文字框順時針旋轉 3 度：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

結果如下：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)、以及 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以行高的百分比指定行距。
* 使用負值以點數指定行距。

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

結果如下：

![段落內的行距](line_spacing.png)

## **控制換行**

段落換行規則在窄文字區塊與混合拉丁文與東亞文字的簡報中相當有用。以下屬性屬於 [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/)，因此套用於整個段落：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) 控制拉丁文字的換行規則。在混合文字中，變更此設定也可能影響相鄰東亞文字與標點符號的換行位置。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) 控制東亞文字的換行規則，包含行首與行尾字元的限制。

這些規則不會取代 [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)，後者啟用文字框內的自動換行。它們會在換行發生時影響版面配置，並不會插入換行字元。明確的換行會在段落內強制另起新行，且不受可用寬度限制。

以下自包含範例建立一個包含中文與拉丁文字的窄文字區塊。它明確設定兩個換行屬性，並儲存為 "line_breaking.pptx"。若要測試任一規則，可變更該屬性的值，同時保持其他設定不變。範例使用 24 點 Arial 與 SimSun，框寬 160 點且水平文字框邊距為 0。[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 設為 [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/)，以使文字大小與框尺寸固定。

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) 允許符合條件的標點符號延伸至文字行的右邊緣之外，而非佔用下一行。此設定套用於整個段落，且不同於懸掛縮排。

以下自包含範例於寬度 100 點的文字框中啟用懸掛標點，並儲存為 "hanging_punctuation.pptx"。使用 24 點 Arial 且水平文字框邊距為 0 時，最後的句點會留在 "sentence" 後方，並延伸至文字右邊緣之外。若將屬性設為 [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)，則句點會佔據單獨一行。為保持可用寬度固定，已啟用換行並停用自動調整。

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

並非所有標點符號皆能懸掛。[上述字型與版面條件](#control-line-breaking)同樣適用於此比較：變更字型、可用寬度、邊距或自動調整設定皆可能消除可見差異。

## **設定文字框的自動調整類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) 決定文字超出容器邊界時的行為，用於控制文字是縮小、溢出，或自動調整形狀大小。以下範例將形狀設定為自動調整以符合文字，並將結果儲存為 "autofit_type.pptx"。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

若要在自動換行後計算行數並觀察文字或形狀寬度變化，請參閱 [計算已呈現行數](/slides/zh-hant/net/manage-paragraph/)。僅行數並無法判斷文字是否溢出容器。

## **設定文字框的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在形狀內的垂直定位，例如置於頂部、居中或底部。以下範例將文字錨定於第一個圖形的底部，並將結果儲存為 "text_anchor.pptx"。

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

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) 與 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) 於段落中設定定位點。以下範例將預設定位間距設為 100 點，並於 30 點處新增左對齊的定位點。這些設定會影響包含定位字元的文字。

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

結果如下：

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/)，可設定文字部份的校對語言。校對語言決定 PowerPoint 進行拼字與文法檢查時使用的語言。

以下範例需要名為 "presentation.pptx" 的簡報，第一張投影片的第一個圖形為文字框，且至少包含一個段落。它會將第一段的內容替換為 "1。", 將字型設定為 SimSun，並指派簡體中文校對語言 (`zh-CN`)。最終將結果儲存為 "proofing_language.pptx"：

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

從範本複製多語言文字時，請保留 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) 與 [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) 兩項資訊。以下自包含範例建立一個來源部份，其語言為美式英語，備用語言為法語，並將文字與這些識別碼複製至新簡報中的部份。

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
// 如果來源沒有備用語言，null 會清除目標的值。
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

若想測試沒有備用語言的來源，只需省略 "fr-FR" 的指派。此時備用識別碼為 `null`，相同的複製語句會保留此缺失，而不會產生預設值，即使目標先前已指派備用語言。

這些識別碼屬於語言中繼資料。保留它們並不會決定 PowerPoint 使用哪個字典進行拼字或文法檢查。

## **設定預設語言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) 定義載入或建立簡報時所產生文字的預設語言。以下範例建立一個預設文字語言為美式英語的簡報，加入文字框，並輸出其第一文字部份的語言代碼 `en-US`。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 添加一個帶文字的矩形形狀。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 檢查第一個部份的語言。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，可使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下範例在新簡報的頂層段落設定 14 點粗體字型為預設，並儲存為 "default_text_style.pptx"。文字會在未有更具體的格式時繼承這些預設值。

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

## **擷取具有全部大寫效果的文字**

在 PowerPoint 中，套用 **All Caps**（全部大寫）字型效果會讓文字在投影片上以大寫方式顯示，即使原本是以小寫輸入。使用 Aspose.Slides 取得此類文字部份時，函式庫會回傳原始輸入的文字。若要匹配顯示的文字，請檢查 [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/)，並在其值為 `All` 時將回傳的字串轉為大寫。

此範例需要名為 "sample2.pptx" 的簡報，第一張投影片的第一個圖形為文字框。其第一段的第一部份包含使用 All Caps 效果的 "Hello, Aspose!"，如下所示。

![全部大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取套用 **All Caps** 效果的文字：

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

要在投影片的表格中修改文字，請使用 [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) 更新每個儲存格，並使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) 進行段落格式設定。

**如何在 PowerPoint 投影片的文字上套用漸層顏色？**

要在文字上套用漸層顏色，請使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，並設定漸層停止點、方向與透明度。

相關功能：[在投影片中格式化文字](/slides/zh-hant/features/text-formatting/).