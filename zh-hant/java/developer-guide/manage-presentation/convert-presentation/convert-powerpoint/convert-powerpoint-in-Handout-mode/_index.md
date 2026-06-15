---
title: 使用 Java 於講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/java/convert-powerpoint-in-Handout-mode/
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
description: "使用 Java 將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides 匯出為 PDF 或影像，並提供範例 Java 程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 允許您將簡報轉換為支援講義模式的輸出格式。在此模式下，多張投影片會排列在同一頁面上，適用於列印會議、研討會及類似活動的簡報資料。

透過 `setSlidesLayoutOptions` 方法可設定講義模式，此方法可用於 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihtmloptions/) 以及 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/)。若要定義講義版面配置，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/) 物件。

## **講義模式匯出**

若要以講義模式匯出簡報，請於目標匯出選項上設定 `setSlidesLayoutOptions` 方法，並指派一個定義每頁投影片數量及相關顯示參數的 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/) 實例。

以下為將簡報轉換為 PDF 講義模式的程式碼範例。

```java
// 載入簡報。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 設定匯出選項。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 每頁水平排列 4 張投影片
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // 列印投影片編號
    slidesLayoutOptions.setPrintFrameSlide(true);                     // 在投影片周圍列印框線
    slidesLayoutOptions.setPrintComments(false);                      // 無註解

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 以所選版面將簡報匯出為 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
請留意，`setSlidesLayoutOptions` 方法僅在特定輸出格式（如 PDF、HTML、TIFF）以及以影像形式渲染時可用。 
{{% /alert %}} 

## **FAQ**

**在講義模式中，每頁可顯示的投影片縮圖上限是多少？**

Aspose.Slides 支援最多 9 張縮圖的[預設配置](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/)，可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自行定義格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式完全受 [HandoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/) 類別控制；不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。使用目標格式的匯出設定（例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/)）中的 `setShowHiddenSlides` 方法即可啟用隱藏投影片。