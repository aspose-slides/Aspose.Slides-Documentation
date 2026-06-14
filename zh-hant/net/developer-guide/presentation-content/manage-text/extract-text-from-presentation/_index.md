---
title: 在 .NET 中的簡報進階文字提取
linktitle: 提取文字
type: docs
weight: 90
url: /zh-hant/net/extract-text-from-presentation/
keywords:
- 提取文字
- 從投影片提取文字
- 從簡報提取文字
- 從 PowerPoint 提取文字
- 從 OpenDocument 提取文字
- 從 PPT 提取文字
- 從 PPTX 提取文字
- 從 ODP 提取文字
- 取得文字
- 從投影片取得文字
- 從簡報取得文字
- 從 PowerPoint 取得文字
- 從 OpenDocument 取得文字
- 從 PPT 取得文字
- 從 PPTX 取得文字
- 從 ODP 取得文字
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速從 PowerPoint 與 OpenDocument 簡報中提取文字。遵循我們簡單、一步一步的指南以節省時間。"
---
## **概觀**

從簡報中提取文字是開發人員處理投影片內容時常見且必要的工作。無論您是處理 Microsoft PowerPoint 的 PPT 或 PPTX 格式，亦或是 OpenDocument 簡報（ODP），存取與取得文字資料對於分析、自動化、索引或內容遷移等目的都可能至關重要。

本文提供了一份完整指南，說明如何使用 Aspose.Slides for .NET 有效地從各種簡報格式（包括 PPT、PPTX 和 ODP）中提取文字。您將學會如何系統性地遍歷簡報元素，以精確取得所需的文字內容。

## **從投影片提取文字**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/) 命名空間，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/) 類別。此類別公布了多個重載的靜態方法，用於從簡報或投影片中提取所有文字。若要從簡報中的投影片提取文字，請使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受類型為 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/) 的物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 類型的物件陣列，保留所有文字格式。

以下程式碼片段會從簡報的第一張投影片提取所有文字：

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **從簡報提取文字**

若要掃描整個簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/) 類別所提供的靜態方法 [GetAllTextFrames](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextframes/)。它接受兩個參數：

1. 第一個參數為 [IPresentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/) 物件，代表要從中提取文字的 PowerPoint 或 OpenDocument 簡報。
1. 第二個參數為 `Boolean` 值，指示在掃描簡報文字時是否要包含母版投影片。

此方法會回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 類型的物件陣列，內含文字格式資訊。以下程式碼會掃描簡報的文字與格式細節，包含母版投影片。

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **分類與快速文字提取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/) 類別也提供了從簡報中提取所有文字的方法：

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textextractionarrangingmode/) 列舉參數表示文字提取結果的組織模式，可設定為以下值：
- `Unarranged` - 原始文字，不考慮其在投影片上的位置。
- `Arranged` - 文字依投影片上的順序排列。

當速度關鍵時，可使用未排列模式；其速度快於排列模式。

[IPresentationText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationtext/) 代表從簡報中提取的原始文字。其 `SlidesText` 屬性回傳一個 [ISlideText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidetext/) 類型的物件陣列。每個物件代表相對投影片上的文字。類型為 [ISlideText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidetext/) 的物件具有以下屬性：

- `Text` - 投影片形狀內的文字。
- `MasterText` - 與此投影片相關聯的母版投影片形狀內的文字。
- `LayoutText` - 與此投影片相關聯的版面投影片形狀內的文字。
- `NotesText` - 與此投影片相關聯的備註投影片形狀內的文字。
- `CommentsText` - 與此投影片相關聯的評論內的文字。

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **常見問題**

**Aspose.Slides 在文字提取期間處理大型簡報的速度如何？**

Aspose.Slides 已針對高效能進行最佳化，即使是 [大型簡報](/slides/zh-hant/net/open-presentation/)，也能順利處理，適合即時或批量處理情境。

**Aspose.Slides 能從簡報中的表格和圖表提取文字嗎？**

是的。Aspose.Slides 能從多種投影片元素（包括表格和圖表相關物件）提取文字，讓您能存取並分析常見簡報結構中的文字內容。

**我需要特別的 Aspose.Slides 授權才能提取簡報文字嗎？**

您可以使用 Aspose.Slides 的免費試用版進行文字提取，儘管它會有 [特定限制](/slides/zh-hant/net/licensing/)，例如只能處理有限數量的投影片。若需無限制使用並處理更大的簡報，建議購買正式授權。