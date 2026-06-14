---
title: 在 .NET 中格式化簡報文字
linktitle: 文字格式化
type: docs
weight: 50
url: /zh-hant/net/text-formatting/
keywords:
- 突顯文字
- 正則表達式
- 對齊段落
- 文字樣式
- 文字背景
- 文字透明度
- 字元間距
- 字型屬性
- 字型族
- 文字旋轉
- 旋轉角度
- 文字方塊
- 行距
- 自動調整屬性
- 文字方塊錨點
- 文字定位點
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中格式化與樣式化文字。自訂字型、顏色、對齊方式等。"
---
## **概覽**

本文說明如何在 PowerPoint 與 OpenDocument 簡報中使用 Aspose.Slides for .NET 進行文字格式化。內容包含突顯、背景色、透明度、字元間距、字型屬性、旋轉、段落間距、自動調整行為、文字錨點、定位點以及語言設定。

在以下範例中，我們將使用名為 **"sample.pptx"** 的檔案，該檔案的第一張投影片上有一個文字方塊，內容如下：

![樣本文字](sample_text.png)

## **突顯文字**

當需要突顯文字方塊中符合特定樣本的文字時，使用 [ITextFrame.HighlightText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlighttext/) 方法。此方法會對符合條件的文字片段套用突顯顏色，並可搭配 [TextSearchOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textsearchoptions/) 來控制搜尋方式，例如僅匹配完整單字。

以下程式碼範例先突顯所有 **"try"** 字元，再僅突顯完整單字 **"to"**。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // 取得第一張投影片中的第一個圖形。
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // 在圖形中突顯單字「try」。
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // 在圖形中突顯單字「to」。
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

結果：

![已突顯的文字](highlighted_text.png)

## **使用正則式突顯文字**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/highlightregex/) 方法會突顯正則表達式找到的文字匹配項目。在 .NET 中，此 API 以 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 形式公開。

以下程式碼範例會突顯所有 **包含七個或以上字元的單字**：

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // 突顯所有包含七個或以上字元的單字。
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

結果：

![使用正則式突顯的文字](highlighted_text_using_regex.png)

## **設定文字背景色**

使用 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 來設定段落的預設突顯顏色，或使用 [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/highlightcolor/) 針對單一文字片段設定。

以下程式碼示範如何為 **整個段落** 設定背景色：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定整個段落的突顯顏色。
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![灰色段落](gray_paragraph.png)

以下程式碼示範如何為 **粗體文字片段** 設定背景色：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

結果：

![灰色文字片段](gray_text_portions.png)

## **對齊文字段落**

使用 [IParagraphFormat.Alignment](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/alignment/) 來設定文字方塊內段落的對齊方式，值可以是置中、靠左、靠右、兩端對齊等。

以下程式碼示範如何將段落 **置中**：

```cs
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

![已置中的段落](aligned_paragraph.png)

## **設定文字透明度**

文字透明度透過指派給 [IPortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/fillformat/) 的色彩之 alpha 成分來控制。下面範例中的 `alpha = 50` 為 0–255 範圍的 ARGB alpha 值，並非透明度百分比。

以下程式碼示範如何為 **整個段落** 套用透明度：

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 設定文字的填充顏色為透明色。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

結果：

![透明段落](transparent_paragraph.png)

以下程式碼示範如何為 **粗體文字片段** 套用透明度：

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

結果：

![透明文字片段](transparent_text_portions.png)

## **設定文字字元間距**

使用 [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/spacing/) 來放大或縮小文字方塊中字元之間的間距。

以下 C# 程式碼示範如何為 **整個段落** 擴展字元間距：

```cs
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

以下程式碼示範如何為 **粗體文字片段** 擴展字元間距：

```cs
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

![文字片段中的字元間距](character_spacing_in_text_portions.png)

### **停用特定字型的字距微調 (Kerning)**

在某些情況下，Aspose.Slides 產生的文字可能比 PowerPoint 顯示的稍微緊密。這可能是因為 PowerPoint 會忽略某些字型的字距微調資料，即使該字型本身包含有效的字距微調資訊且在 PowerPoint 設定中已啟用。

若要讓渲染結果更接近 PowerPoint，可對使用受影響字型的文字片段停用字距微調。將 [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseportionformat/kerningminimalsize/) 設為遠大於實際字型大小的值：

```cs
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

此設定會阻止對符合條件的文字片段套用字距微調，協助使 Aspose.Slides 的渲染與 PowerPoint 在此類字型的視覺輸出保持一致。

## **管理文字字型屬性**

字型屬性可透過 [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaultportionformat/) 在段落層級設定，或透過 [IPortionFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/) 在個別文字片段層級設定。

以下程式碼為整個段落設定字型與文字樣式：套用字型大小、粗體、斜體、點狀底線以及 Times New Roman 字型至段落內所有片段。

```cs
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

以下程式碼示範對 **粗體文字片段** 套用相同屬性：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

結果：

![文字片段的字型屬性](font_properties_for_text_portions.png)

## **設定文字旋轉**

使用 [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/textverticaltype/) 可在形狀內設定預定義的文字方向。

以下程式碼將文字方向設定為 `Vertical270`，即將文字 **逆時針旋轉 90 度**：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![文字旋轉](text_rotation.png)

## **為文字方塊設定自訂旋轉角度**

使用 [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/rotationangle/) 可為 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 設定自訂旋轉角度。

以下程式碼在形狀內將文字方塊順時針旋轉 3 度：

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

結果：

![自訂文字旋轉](custom_text_rotation.png)

## **設定段落的行距**

Aspose.Slides 提供 [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacebefore/) 與 [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/spacewithin/) 以控制段落間距。這些屬性的使用方式如下：

* 使用正值以百分比表示行高的行距。
* 使用負值以點 (pt) 表示行距。

以下程式碼示範如何在段落內指定行距：

```cs
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

## **設定文字方塊的自動調整類型**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/autofittype/) 決定文字超出容器邊界時的行為。可用來控制文字是縮小、溢出，或自動調整形狀大小。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **設定文字方塊的錨點**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframeformat/anchoringtype/) 定義文字在形狀內的垂直位置，例如置頂、置中或置底。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **設定文字定位點 (Tab)**

使用 [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/defaulttabsize/) 與 [IParagraphFormat.Tabs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraphformat/tabs/) 來配置段落中的定位點。

```cs
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

![段落定位點](paragraph_tabs.png)

## **設定校對語言**

Aspose.Slides 提供 [IPortionFormat.LanguageId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/languageid/)，可為文字片段設定校對語言。校對語言決定在 PowerPoint 中執行拼寫與文法檢查時使用的語言。

以下程式碼示範如何為文字片段設定校對語言：

```cs
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

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/defaulttextlanguage/) 可定義在載入或建立簡報時新產生文字的預設語言。

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // 新增一個含文字的矩形形狀。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 檢查第一個文字片段的語言。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **設定預設文字樣式**

若要在簡報層級套用預設文字格式，使用 [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/defaulttextstyle/)。

以下程式碼示範如何在新簡報中為所有投影片的文字設定 **粗體、14 點大小** 的預設字型。

```cs
using (var presentation = new Presentation())
{
    // 取得最高層級的段落格式。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **擷取帶有全大寫效果的文字**

在 PowerPoint 中，套用 **全大寫** 字型效果會使投影片上呈現的文字全部為大寫，即使原本是小寫。當使用 Aspose.Slides 取得此類文字片段時，函式庫會回傳原始輸入的文字。若要顯示與投影片相同的結果，請檢查 [TextCapType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textcaptype/) 並在值為 `All` 時將回傳的字串轉換為大寫。

假設我們在 sample2.pptx 的第一張投影片上有以下文字方塊：

![全大寫效果](all_caps_effect.png)

以下程式碼示範如何擷取已套用 **全大寫** 效果的文字：

```cs
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

**如何修改投影片上表格中的文字？**  

要修改投影片上表格的文字，請使用 [ITable](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itable/)。遍歷儲存格，並透過 [ICell.TextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/textframe/) 更新每個儲存格的文字，並使用 [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/paragraphformat/) 變更段落格式。

**如何在 PowerPoint 投影片的文字上套用漸層色彩？**  

要為文字套用漸層色彩，使用 [IPortionFormat.FillFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportionformat/fillformat/)。將 [IFillFormat.FillType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifillformat/filltype/) 設為 [FillType.Gradient](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，並配置漸層停點、方向與透明度。