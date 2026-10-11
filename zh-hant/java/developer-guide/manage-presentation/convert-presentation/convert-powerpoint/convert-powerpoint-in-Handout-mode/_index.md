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
description: "在 Java 中將簡報轉換為講義。設定每頁投影片數量、保留註解，使用 Aspose.Slides 匯出為 PDF 或影像，提供範例 Java 程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 允許您將簡報轉換為支援講義模式的輸出格式。在此模式下，多張投影片會排列在同一頁上，這對於列印會議、研討會及類似活動的簡報資料非常有用。

Handout 模式透過 `setSlidesLayoutOptions` 方法設定，該方法可在 [IPdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ihtmloptions/) 以及 [ITiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiffoptions/) 中使用。若要定義講義版面配置，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/) 物件。

若要在匯出前設定講義頁面的尺寸和方向，請參閱 [註解頁面大小](/slides/zh-hant/java/notes-size/)。

## **講義模式匯出**

若要以講義模式匯出簡報，請對目標匯出選項設定 `setSlidesLayoutOptions` 方法，並指派一個定義每頁投影片數量及相關顯示參數的 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handoutlayoutingoptions/) 實例。

以下是一個程式碼範例，示範如何將簡報轉換為講義模式的 PDF。

```java
import com.aspose.slides.*;

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

    // 使用選定的版面配置將簡報匯出為 PDF。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
請注意，`setSlidesLayoutOptions` 方法僅適用於特定的輸出格式，例如 PDF、HTML、TIFF，及以影像形式呈現時。
{{% /alert %}} 

## **常見問題**

**Handout 模式中每頁最多能顯示多少張投影片縮圖？**

Aspose.Slides 支援最多 9 張縮圖的[預設配置](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/)，可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不行。縮圖的數量與排列方式嚴格由 [HandoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/handouttype/) 類別控制；不支援任意版面配置。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中使用 `setShowHiddenSlides` 方法啟用隱藏投影片，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/)。