---
title: 使用 JavaScript 於講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "將簡報轉換為講義。設定每頁投影片數量，保留備註，使用 Aspose.Slides for Node.js 匯出為 PDF 或影像，並提供範例程式碼。立即免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包含以講義模式列印的講義。此模式允許您設定多張投影片在單一頁面上的排列方式，適用於會議、研討會等活動。您可以透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/)、以及 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別中設定 `setSlidesLayoutOptions` 方法來啟用此模式。

## **講義模式匯出**

若要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/handoutlayoutingoptions/) 物件，它決定單頁放置多少張投影片以及其他顯示參數。

以下是將簡報以講義模式匯出為 PDF 的程式碼範例。

```js
// 載入簡報。
let presentation = new asposeSlides.Presentation("sample.pptx");

// 設定匯出選項。
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 每頁水平放置 4 張投影片
slidesLayoutOptions.setPrintSlideNumbers(true);                                // 列印投影片編號
slidesLayoutOptions.setPrintFrameSlide(true);                                  // 在投影片周圍列印框線
slidesLayoutOptions.setPrintComments(false);                                   // 無註解

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// 以選擇的版面配置將簡報匯出為 PDF。
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
請留意，`setSlidesLayoutOptions` 方法僅在特定輸出格式（例如 PDF、HTML、TIFF，或以影像方式呈現）中可用。 
{{% /alert %}} 

## **常見問題**

**在講義模式中每頁的投影片縮圖最大數量是多少？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/handouttype/) 最多可在每頁顯示 9 個縮圖，排列方式可為水平或垂直：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式由 [HandoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/handouttype/) 列舉嚴格控制；不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中使用 `setShowHiddenSlides` 方法，例如在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/)、或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 中。