---
title: 在 Android 上以講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Java 中將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides for Android 匯出為 PDF 或影像，並附有範例程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，甚至可以在 Handout 模式下建立列印用的講義。此模式允許您設定多張投影片在同一頁上的顯示方式，非常適用於會議、研討會及其他活動。您可以透過在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ihtmloptions/)、以及 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiffoptions/) 介面中設定 `setSlidesLayoutOptions` 方法來啟用此模式。

## **Handout 模式匯出**

若要設定 Handout 模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/handoutlayoutingoptions/) 物件，它決定單頁放置的投影片數量以及其他顯示參數。

以下是一個將簡報轉換為 PDF 並以 Handout 模式匯出的程式碼範例。

```java
// 載入簡報。
Presentation presentation = new Presentation("sample.pptx");
try {
	// 設定匯出選項。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每頁水平排列 4 張投影片
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // 列印投影片編號
	slidesLayoutOptions.setPrintFrameSlide(true);                     // 在投影片周圍列印框線
	slidesLayoutOptions.setPrintComments(false);                      // 不列印註解

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 依所選布局將簡報匯出為 PDF。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
請注意，`setSlidesLayoutOptions` 方法僅在特定輸出格式下可用，例如 PDF、HTML、TIFF，或在渲染為影像時。
{{% /alert %}} 

## **常見問題**

**Handout 模式下每頁的投影片縮圖最大數量為多少？**

Aspose.Slides 支援每頁最多 9 個縮圖的 [presets](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/handouttype/) ，可使用水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不能。縮圖的數量與排列嚴格受 [HandoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/handouttype/) 類別控制；不支援任意布局。

**我可以在 Handout 輸出中包含隱藏的投影片嗎？**

可以。使用 `setShowHiddenSlides` 方法在目標格式的匯出設定中啟用隱藏投影片，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/)。