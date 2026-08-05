---
title: 使用 Java 於講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/java/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides 匯出為 PDF 或影像，提供 Java 範例程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 允許您將簡報轉換為支援講義模式的輸出格式。在此模式下，多張投影片會排列在同一頁面上，這對於列印會議、研討會及類似活動的簡報資料非常有用。

講義模式是透過 `setSlidesLayoutOptions` 方法設定的，該方法可在[IPdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihtmloptions/)、以及[ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/)中取得。若要定義講義版面，請使用[HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/)物件。

## **講義模式匯出**

若要在講義模式下匯出簡報，請為目標匯出選項設定`setSlidesLayoutOptions`方法，並指派一個定義每頁投影片數量及相關顯示參數的[HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/)實例。

以下程式碼示範如何在講義模式下將簡報轉換為 PDF。

```java
// 載入簡報.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 設定匯出選項.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每頁水平排列 4 張投影片
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // 列印投影片編號
    slidesLayoutOptions.setPrintFrameSlide(true);                     // 在投影片周圍列印框線
    slidesLayoutOptions.setPrintComments(false);                      // 不列印備註

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 使用選擇的版面將簡報匯出為 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
請記住，`setSlidesLayoutOptions` 方法僅適用於特定輸出格式，例如 PDF、HTML、TIFF，以及渲染為影像時。
{{% /alert %}} 

## **常見問題**

**在講義模式中每頁可顯示的投影片縮圖上限是多少？**

Aspose.Slides 支援最高 9 個縮圖的[預設設定](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/)，以水平或垂直排列方式呈現：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格局，例如每頁 5 或 8 張投影片嗎？**

不能。縮圖的數量與排列方式完全由[HandoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/)類別控制，不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。 在目標格式的匯出設定中使用`setShowHiddenSlides`方法啟用隱藏投影片，例如[PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/)、或[TiffOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/)。