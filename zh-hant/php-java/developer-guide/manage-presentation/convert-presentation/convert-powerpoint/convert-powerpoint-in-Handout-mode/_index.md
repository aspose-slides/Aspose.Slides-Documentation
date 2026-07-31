---
title: 使用 PHP 以講義模式轉換 PowerPoint 簡報
linktitle: 講義模式
type: docs
weight: 150
url: /zh-hant/php-java/convert-powerpoint-in-handout-mode/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 講義模式
- 講義
- PPT
- PPTX
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 PHP 將簡報轉換為講義。設定每頁投影片數量、保留備註，並使用 Aspose.Slides for PHP 匯出為 PDF 或影像，附帶示範程式碼。免費試用。"
---
## **簡介**

Aspose.Slides 提供將簡報轉換為各種格式的功能，包括在講義模式下建立列印用的講義。此模式允許您配置多張投影片在單一頁面上出現的方式，對於會議、研討會及其他活動非常實用。您可以透過在 [PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/)、以及 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別中設定 `setSlidesLayoutOptions` 方法來啟用此模式。

## **講義模式匯出**

若要設定講義模式，請使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handoutlayoutingoptions/) 物件，它決定單一頁面上放置多少張投影片以及其他顯示參數。

以下為將簡報以講義模式轉換為 PDF 的程式碼範例。

```php
// 載入簡報.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 每頁水平顯示 4 張投影片
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // 列印投影片編號
$slidesLayoutOptions->setPrintFrameSlide(true);                      // 在投影片周圍列印框線
$slidesLayoutOptions->setPrintComments(false);                       // 不列印註解

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// 以選擇的版面配置將簡報匯出為 PDF。
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
請記住，`setSlidesLayoutOptions` 方法僅在特定輸出格式中可用，例如 PDF、HTML、TIFF，以及以影像方式呈現時。
{{% /alert %}} 

## **常見問答**

**在講義模式下每頁最大幻燈片縮圖數量是多少？**

Aspose.Slides 支援最多 9 個縮圖每頁的[預設](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handouttype/)，可水平或垂直排列：1、2、3、4（水平/垂直）、6（水平/垂直）以及 9（水平/垂直）。

**我可以自訂格線，例如每頁 5 或 8 張投影片嗎？**

不能。縮圖的數量與排列方式嚴格由 [HandoutType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/handouttype/) 類別控制；不支援任意布局。

**我可以在講義輸出中包含隱藏的投影片嗎？**

可以。在目標格式的匯出設定中使用 `setShowHiddenSlides` 方法啟用隱藏投影片，例如 [PdfOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/)。