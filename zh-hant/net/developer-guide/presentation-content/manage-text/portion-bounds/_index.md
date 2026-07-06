---
title: 從 .NET 簡報取得文字區段邊界
linktitle: 區段邊界
type: docs
weight: 47
url: /zh-hant/net/portion-bounds/
keywords:
- 文字區段邊界
- 文字區段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中取得文字區段邊界。"
---
## **概觀**

文字區段代表段落內特定的文字片段，允許您獨立於周圍內容操作該片段。在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更細緻的層級控制文字行為時，可使用區段。

本文說明如何使用[IPortion.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/getrect/)取得區段的邊框矩形，並說明如何使用[IPortion.GetCoordinates](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/getcoordinates/)取得區段起始位置的座標。此外，還會介紹常見的區段相關情境，例如對單一文字片段套用超連結、了解格式如何透過區段、段落、文字框與佈景主題繼承解析，以及處理指定字型不存在的情況。

## **取得文字區段的邊界**

使用[IPortion.GetRect](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/getrect/)取得文字區段的邊框矩形：

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **取得文字區段的座標**

使用[IPortion.GetCoordinates](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/getcoordinates/)取得文字區段起始位置的座標：

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**我可以只在單一段落的部分文字套用超連結嗎？**

是的，您可以[指派超連結](/slides/zh-hant/net/manage-hyperlinks/)給個別的區段；只有該片段會是可點擊的，而不是整段文字。

**樣式繼承如何運作：區段會覆寫哪些屬性，哪些屬性會從段落或文字框繼承？**

區段層級的屬性具有最高優先權。如果在[IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/)上未設定某屬性，Aspose.Slides 會從[IParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iparagraph/)取得。若段落也未設定，則會使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.theme/theme/)的樣式。

**如果區段指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

會套用[字型替代規則](/slides/zh-hant/net/font-selection-sequence/)。文字可能會重新排列：度量、斷字與寬度都可能變化，這對精確定位非常重要。

**我可以為區段單獨設定文字填色透明度或漸層，而不影響段落的其他部分嗎？**

可以，[IPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iportion/)層級的文字顏色、填色與透明度可以與相鄰片段不同。