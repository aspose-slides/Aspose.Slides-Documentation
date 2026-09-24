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
- 文字製表
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊等更多設定。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for .NET 於 PowerPoint 與 OpenDocument 簡報中格式化文字。它涵蓋背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為「sample.pptx」的檔案，該檔案在第一張投影片上包含一個文字方塊，文字內容如下：

![範例文字](sample_text.png)

要尋找並突顯文字字面值或正規表示式匹配，請參閱[搜尋與取代文字](/slides/zh-hant/net/search-and-replace-text/)。

## **設定文字背景色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 來設定段落的預設醒目顏色，或使用 [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/highlightcolor/) 針對單一文字區段設定。

以下程式碼範例示範如何為 **整段** 設定背景色：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定整段的醒目顏色。
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼範例示範如何為 **粗體字的文字區段** 設定背景色：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 設定文字區段的醒目顏色。
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

結果：

![灰色文字區段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 於文字框內設定段落對齊方式。其值可為置中、左對齊、右對齊、兩端對齊等。

以下程式碼範例示範如何將段落對齊至 **置中**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定段落的對齊方式為置中。
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![已對齊的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度是透過指派給 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/fillformat/) 的顏色之 Alpha 成分來控制。在以下範例中，`alpha = 50` 為 0–255 範圍的 ARGB Alpha 通道值，而非透明度百分比。

以下程式碼範例示範如何將透明度套用至 **整段**：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定文字的填充顏色為透明顏色。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼範例示範如何將透明度套用至 **粗體字的文字區段**：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 設定文字區段的透明度。
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

結果：

![透明文字區段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/spacing/) 以擴大或縮小文字方塊中字元之間的間距。

以下 C# 程式碼示範如何在 **整段** 中擴大字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 註：使用負值來壓縮字元間距。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 展開字元間距。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![段落中的字元間距](character_spacing_in_paragraph.png)

以下程式碼範例示範如何在 **粗體字的文字區段** 中擴大字元間距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 註：使用負值來壓縮字元間距。
            portion.PortionFormat.Spacing = 3;  // 展開字元間距。
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

結果：

![文字區段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調**

在某些情況下，Aspose.Slides 呈現的文字看起來可能比 PowerPoint 中顯示的相同文字略為緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即便該字型包含有效的字距微調資訊且在 PowerPoint 設定中已啟用字距微調。

為了在此類情況下使渲染結果更接近 PowerPoint，您可以對使用受影響字型的文字區段停用字距微調。將 [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為遠大於實際字型大小的值：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

此設定會防止對符合條件的文字區段套用字距微調，並有助於將 Aspose.Slides 的渲染結果與 PowerPoint 在受此 PowerPoint 專屬行為影響的字型的視覺輸出對齊。

## **管理文字字型屬性**

可透過 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落層級設定字型屬性，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/) 在個別文字區段設定。

以下程式碼為整段設定字型與文字樣式：它將字型大小、粗體、斜體、點狀底線以及 Times New Roman 字型套用到段落中的所有區段。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定段落的字型屬性。
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![段落的字型屬性](font_properties_for_paragraph.png)

以下程式碼範例將類似屬性套用至 **粗體字的文字區段**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 為文字區段設定字型屬性。
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

結果：

![文字區段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/textverticaltype/) 以在形狀內設定預定義的文字方向。

以下程式碼範例將形狀內的文字方向設定為 `Vertical270`，此設定會使文字 **逆時針旋轉 90 度**：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![文字旋轉](text_rotation.png)

## **為文字框設定自訂旋轉**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/rotationangle/) 為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼範例將文字框在形狀內順時針旋轉 3 度：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacebefore/) 以及 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以行距百分比（相對於行高）指定行距。
* 使用負值以點數指定行距。

以下程式碼範例示範如何在段落內指定行距：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

結果：

![段落內的行距](line_spacing.png)

## **設定文字框的自動調整類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/autofittype/) 決定文字在超出容器邊界時的處理方式。使用它可控制文字是縮小、溢出，或自動調整形狀大小。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

若要在自動換行後計算行數，並觀察文字或形狀寬度變化對結果的影響，請參閱[計算已渲染行數](/slides/zh-hant/net/manage-paragraph/)。僅行數並不足以判斷文字是否溢出其容器。

## **設定文字框的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在形狀內的垂直定位方式，例如位於頂部、中央或底部。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **設定文字製表**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaulttabsize/) 及 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/tabs/) 來設定段落中的定位點（Tab）。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

結果：

![段落的製表位](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/languageid/)，可設定文字區段的校對語言。校對語言決定在 PowerPoint 中進行拼寫與文法檢查時使用的語言。

以下程式碼範例示範如何為文字區段設定校對語言：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // 設定校對語言的 Id。
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **設定預設語言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/) 來定義在載入或建立簡報時所建立文字的預設語言。

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // 新增一個帶文字的矩形形狀。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 檢查第一個文字區段的語言。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，請使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下程式碼範例示範如何在新簡報中為所有投影片的文字設定預設的粗體字型，字型大小為 14 點。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // 取得頂層段落格式。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **擷取套用全大寫效果的文字**

在 PowerPoint 中，套用 **All Caps**（全大寫）字型效果會使投影片上的文字以大寫顯示，即使原本是以小寫輸入。當使用 Aspose.Slides 取得此類文字區段時，函式庫會回傳原始輸入的文字。若要與顯示的文字一致，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textcaptype/)，當其值為 `All` 時，將回傳的字串轉換為大寫。

假設我們在 sample2.pptx 檔案的第一張投影片上有如下文字方塊。

![全大寫效果](all_caps_effect.png)

以下程式碼範例示範如何擷取套用 **All Caps** 效果的文字：

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

輸出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常見問題**

**如何在投影片上的表格中修改文字？**

要在投影片上的表格中修改文字，請使用 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/textframe/) 以及 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/paragraphformat/) 來更新每個儲存格的文字與段落格式。

**如何在 PowerPoint 投影片中的文字套用漸層顏色？**

若要為文字套用漸層顏色，請使用 [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，並配置漸層停點、方向與透明度。