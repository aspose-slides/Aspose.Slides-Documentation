---
title: "使用 PHP 於 Handout 模式轉換 PowerPoint 簡報"
linktitle: "Handout 模式"
type: docs
weight: 150
url: /zh-hant/php-java/convert-powerpoint-in-handout-mode/
keywords:
- "轉換 PowerPoint"
- "轉換 簡報"
- "Handout 模式"
- "講義"
- PPT
- PPTX
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中將簡報轉換為講義。設定每頁投影片數量、保留備註，使用 Aspose.Slides for PHP 匯出為 PDF 或圖像，並提供範例程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包含在 Handout 模式下建立列印用的講義。此模式讓您設定多張投影片在單一頁面上的排列方式，適用於會議、研討會等活動。您可以透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/)、以及 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別中設定 `setSlidesLayoutOptions` 方法來啟用此模式。

若要在匯出前設定講義頁面的尺寸與方向，請參閱 [Notes Page Size](/slides/zh-hant/php-java/notes-size/)。

## **Handout 模式匯出**

要設定 Handout 模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handoutlayoutingoptions/) 物件，該物件決定單一頁面上放置的投影片數量及其他顯示參數。

以下是將簡報以 Handout 模式轉換為 PDF 的程式碼範例。

```php
// 載入簡報.
$presentation = new Presentation("sample.pptx");

// 設定輸出選項.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 每頁水平放置 4 張投影片
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 列印投影片編號
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 為投影片列印框線
$slidesLayoutOptions->setPrintComments(false);                       // 不列印備註

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// 使用所選布局將簡報匯出為 PDF.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
請記住，`setSlidesLayoutOptions` 方法僅在某些輸出格式（例如 PDF、HTML、TIFF 以及以圖像方式呈現時）可用。
{{% /alert %}} 

## **常見問題**

**Handout 模式下每頁最多可以顯示多少張投影片縮圖？**

Aspose.Slides 支援的 [presets](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handouttype/) 最多每頁 9 張縮圖，且可使用水平或垂直排序：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 張或 8 張投影片嗎？**

不能。縮圖的數量與排序嚴格由 [HandoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handouttype/) 類別控制；不支援任意版面配置。

**我可以在 Handout 輸出中包含隱藏的投影片嗎？**

可以。請在目標格式的匯出設定中啟用 `setShowHiddenSlides` 方法，例如在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/)、或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 中。