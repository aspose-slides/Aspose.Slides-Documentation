---
title: 在 .NET 中的簡報進階文字擷取
linktitle: 擷取文字
type: docs
weight: 90
url: /zh-hant/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/zh-hant/
keywords:
- 擷取文字
- 從投影片擷取文字
- 從簡報擷取文字
- 從 PowerPoint 擷取文字
- 從 OpenDocument 擷取文字
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
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
description: "快速使用 Aspose.Slides for .NET 從 PowerPoint 與 OpenDocument 簡報擷取文字。遵循我們的簡易步驟指南，即可節省時間。"
---
## **概述**

從簡報中擷取文字是開發人員在處理投影片內容時常見且必不可少的工作。無論您正在處理 Microsoft PowerPoint 的 PPT 或 PPTX 檔案，或是 OpenDocument 簡報 (ODP)，存取與取得文字資料對於分析、自動化、索引或內容遷移等目的都相當重要。

本文提供一份完整指南，說明如何使用 Aspose.Slides for .NET 高效地從各種簡報格式（包括 PPT、PPTX 與 ODP）擷取文字。您將學會系統性地遍歷簡報元素，精確取得所需的文字內容。

## **從投影片擷取文字**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/) 命名空間，其中包含 [SlideUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/) 類別。此類別提供多個重載的靜態方法，用於從簡報或投影片中擷取所有文字。若要從簡報的投影片中擷取文字，請使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。此方法接受一個類型為 [IBaseSlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/) 的物件作為參數。執行時，該方法會掃描整個投影片的文字，並回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 型別的物件陣列，保留所有文字格式。

以下程式碼片段可擷取簡報第一張投影片的全部文字：

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

## **從簡報擷取文字**

若要掃描整份簡報的文字，請使用由 [SlideUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/) 類別提供的靜態方法 [GetAllTextFrames](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/getalltextframes/)。它接受兩個參數：

1. 首先，一個代表 PowerPoint 或 OpenDocument 簡報的 [IPresentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/) 物件，將從中擷取文字。
2. 其次，一個 `Boolean` 值，指示在掃描簡報文字時是否應包含母片投影片。

此方法會回傳一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/itextframe/) 類型的物件陣列，包含文字格式資訊。以下程式碼會掃描簡報（包括母片投影片）的文字與格式細節。

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

## **分類與快速文字擷取**

[PresentationFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/) 類別同樣提供用於從簡報中擷取全部文字的方法：

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/textextractionarrangingmode/) 列舉參數表示文字擷取結果的排序模式，可設定為以下值：
- `Unarranged` - 未排列的原始文字，未考慮其在投影片上的位置。
- `Arranged` - 文字依投影片上的順序排列。

在速度至關重要時，可使用未排列模式；它比排列模式更快。

[IPresentationText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationtext/) 代表從簡報擷取的原始文字。其 `SlidesText` 屬性回傳一個 [ISlideText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidetext/) 類型的物件陣列。每個物件對應於相應投影片上的文字。類型為 [ISlideText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidetext/) 的物件具備以下屬性：

- `Text` - 投影片形狀內的文字。
- `MasterText` - 與此投影片相關的母片形狀內的文字。
- `LayoutText` - 與此投影片相關的版面配置形狀內的文字。
- `NotesText` - 投影片備註形狀內的文字。
- `CommentsText` - 與此投影片相關的註解內的文字。

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

**Aspose.Slides 在文字擷取時處理大型簡報的速度有多快？**

Aspose.Slides 已針對高效能進行最佳化，甚至可以處理[大型簡報](/slides/zh-hant/net/open-presentation/)，因此適用於即時或批次處理情境。

**Aspose.Slides 能從簡報中的表格與圖表擷取文字嗎？**

可以。Aspose.Slides 能從多種投影片元素擷取文字，包括表格與圖表相關的物件，讓您能存取並分析常見簡報結構中的文字內容。

**擷取簡報文字是否需要特別的 Aspose.Slides 授權？**

您可以使用 Aspose.Slides 的免費試用版進行文字擷取，但它會有[某些限制](/slides/zh-hant/net/licensing/)，例如只能處理有限數量的投影片。若需無限制使用且處理較大簡報，建議購買完整授權。