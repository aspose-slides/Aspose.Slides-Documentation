---
title: 在 .NET 中以講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/net/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PowerPoint
- 簡報
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中將簡報轉換為講義。設定每頁投影片數量、保留註釋，使用 Aspose.Slides 匯出為 PDF 或影像，並提供範例 C# 程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 允許您將簡報轉換為支援講義模式的輸出格式。在此模式下，多張投影片會排列在同一頁面上，方便列印會議、研討會及類似活動的簡報資料。

講義模式透過 `SlidesLayoutOptions` 屬性設定，可在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/itiffoptions/) 中取得。若要定義講義版面配置，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handoutlayoutingoptions/) 物件。

## **講義模式匯出**

若要以講義模式匯出簡報，請於目標匯出選項設定 `SlidesLayoutOptions` 屬性，並指派一個定義每頁投影片數量及相關顯示參數的 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handoutlayoutingoptions/) 實例。

以下程式碼範例示範如何在講義模式下將簡報轉換為 PDF。

```c#
// 載入簡報.
using var presentation = new Presentation("sample.pptx");

// 設定匯出選項.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // 每頁水平排列 4 張投影片
        PrintSlideNumbers = true,                   // 列印投影片編號
        PrintFrameSlide = true,                     // 在投影片周圍列印框線
        PrintComments = false                       // 不列印註解
    }
};

// 匯出簡報為 PDF 並使用選擇的版面配置.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 

請注意，`SlidesLayoutOptions` 屬性僅在某些輸出格式（例如 PDF、HTML、TIFF，以及以影像方式呈現）中可用。

{{% /alert %}} 

## **常見問題**

**在講義模式下，每頁最多可以顯示多少張投影片縮圖？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handouttype/) 最多可在每頁顯示 9 張縮圖，且可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式完全受 [HandoutType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handouttype/) 列舉控制，不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中啟用 `ShowHiddenSlides` 選項，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/)，或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 。