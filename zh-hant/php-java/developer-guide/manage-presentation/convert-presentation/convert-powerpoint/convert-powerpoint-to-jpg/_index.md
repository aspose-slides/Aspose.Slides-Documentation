---
title: 在 PHP 中將 PPT 與 PPTX 轉換為 JPG
linktitle: PowerPoint 轉 JPG
type: docs
weight: 60
url: /zh-hant/php-java/convert-powerpoint-to-jpg/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 JPG
- 簡報 轉 JPG
- 投影片 轉 JPG
- PPT 轉 JPG
- PPTX 轉 JPG
- 將 PowerPoint 儲存為 JPG
- 將 簡報 儲存為 JPG
- 將 投影片 儲存為 JPG
- 將 PPT 儲存為 JPG
- 將 PPTX 儲存為 JPG
- 匯出 PPT 為 JPG
- 匯出 PPTX 為 JPG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP，在 PHP 中將 PowerPoint（PPT、PPTX）投影片轉換為高品質 JPG 影像，提供快速可靠的程式碼範例。"
---
## **簡介**

將 PowerPoint 與 OpenDocument 簡報轉換為 JPG 影像，可協助分享投影片、最佳化效能，並將內容嵌入網站或應用程式中。Aspose.Slides 允許您將 PPTX、PPT 與 ODP 檔案轉換為高品質的 JPEG 影像。本指南說明各種轉換方法。

使用這些功能，您可以輕鬆實作自己的簡報檢視器，並為每張投影片建立縮圖。如果需要防止投影片被複製或以唯讀模式展示簡報，這將相當有用。Aspose.Slides 可讓您將整個簡報或特定投影片轉換為影像格式。

## **將 PowerPoint PPT/PPTX 轉換為 JPG**

以下為將 PPT/PPTX 轉換為 JPG 的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類型的執行個體。
2. 從 [Presentation::getSlides()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#getSlides--) 集合取得 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 類型的投影片物件。
3. 為每張投影片建立縮圖，然後將其轉換為 JPG。使用 **[Slide::getImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage)** 方法取得投影片的縮圖。必須從所需的 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 物件呼叫 `getImage` 方法，並將縮放比例傳入該方法。
4. 取得投影片縮圖後，從縮圖物件呼叫 **[IImage::save(String formatName, int imageFormat)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))** 方法，傳入產生的檔名與影像格式。

{{% alert color="primary" %}}

**注意**：PPT/PPTX 轉換為 JPG 的方式與 Aspose.Slides API 中其他類型的轉換不同。對於其他類型，通常使用 **[Presentation::Save(String fname, int format, SaveOptions options)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/save/)** 方法，但此處需使用 **[IImage::save(String formatName, int imageFormat)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))** 方法。

{{% /alert %}} 

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # 建立完整比例的影像
      $slideImage = $sld->getImage(1.0, 1.0);
      # 將影像以 JPEG 格式儲存至磁碟
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將 PowerPoint PPT/PPTX 轉換為 JPG（自訂尺寸）**
若要變更產生的縮圖與 JPG 影像的尺寸，可透過將 *ScaleX* 與 *ScaleY* 值傳入 **[Slide::getImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage)** 方法來設定：

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 定義尺寸
    $desiredX = 1200;
    $desiredY = 800;
    # 取得 X 與 Y 的縮放值
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # 建立完整比例的影像
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # 將影像以 JPEG 格式儲存至磁碟
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **儲存投影片為影像時渲染註解**
Aspose.Slides for PHP via Java 提供了在將投影片轉換為影像時渲染註解的功能。以下 PHP 程式碼示範了此操作：

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="提示" color="primary" %}}

Aspose 提供一個 [免費的 Collage 網路應用程式](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG to PNG 影像、建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid) 等。

依照本文所述的相同原理，您也能將影像從一種格式轉換為另一種格式。更多資訊請參閱以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/svg-to-png/)。

{{% /alert %}}

## **常見問題**

**此方法是否支援批次轉換？**

是的，Aspose.Slides 可在單一次操作中批次將多張投影片轉換為 JPG。

**轉換是否支援 SmartArt、圖表及其他複雜物件？**

是的，Aspose.Slides 會呈現所有內容，包括 SmartArt、圖表、表格、圖形等。但與 PowerPoint 相比，渲染精確度可能會因使用自訂或缺少的字型而略有差異。

**處理的投影片數量是否有限制？**

Aspose.Slides 本身對可處理的投影片數量沒有嚴格限制。然而，處理大型簡報或高解析度影像時，可能會遇到記憶體不足的錯誤。

## **另請參閱**

其他將 PPT/PPTX 轉換為影像的選項包括：

- [PPT/PPTX to SVG conversion](/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)。