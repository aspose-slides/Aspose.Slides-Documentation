---
title: 在 PHP 中將 PowerPoint 投影片轉換為 PNG
linktitle: PowerPoint 轉 PNG
type: docs
weight: 30
url: /zh-hant/php-java/convert-powerpoint-to-png/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 PNG
- 簡報轉 PNG
- 投影片轉 PNG
- PPT 轉 PNG
- PPTX 轉 PNG
- 將 PPT 儲存為 PNG
- 将 PPTX 儲存為 PNG
- 匯出 PPT 為 PNG
- 匯出 PPTX 為 PNG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，快速將 PowerPoint 簡報轉換為高品質 PNG 圖像，確保精確且自動化的結果。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 PNG 圖像。它展示了如何載入 PPT、PPTX 和 ODP 等格式的簡報檔案、將投影片渲染為圖像，並以 PNG 格式儲存結果。本文亦示範如何透過設定比例值或指定所需的寬度與高度來自訂產生的 PNG 圖像。

## **將 PowerPoint 轉換為 PNG**

請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 從 [Presentation.getSlides()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlides) 集合中取得 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 類別的投影片物件。
3. 使用 [Slide.getImage()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage) 方法取得每張投影片的縮圖。
4. 使用 [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save) 方法將投影片縮圖儲存為 PNG 格式。

以下 PHP 程式碼示範如何將 PowerPoint 簡報轉換為 PNG：

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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

## **將 PowerPoint 轉換為 PNG（自訂尺寸）**

如果您希望取得特定比例的 PNG 檔案，您可以設定 `desiredX` 和 `desiredY` 的值，這些值決定產生的縮圖之尺寸。

此程式碼示範上述操作：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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

## **將 PowerPoint 轉換為 PNG（自訂大小）**

如果您希望取得特定大小的 PNG 檔案，您可以為 `ImageSize` 傳遞您偏好的 `width` 和 `height` 參數。

以下程式碼示範如何在指定圖像大小的情況下，將 PowerPoint 轉換為 PNG：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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

## **常見問題**

**如何僅匯出特定圖形（例如圖表或圖片）而非整張投影片？**

Aspose.Slides 支援 [產生單一圖形的縮圖](/slides/zh-hant/php-java/create-shape-thumbnails/)；您可以將圖形渲染為 PNG 圖像。

**伺服器上是否支援平行轉換？**

是的，但請 [不要共用](/slides/zh-hant/php-java/multithreading/) 同一個簡報實例於多執行緒之間。每個執行緒或程序請使用獨立的實例。

**匯出 PNG 時，試用版有何限制？**

評估模式會在輸出圖像上加上浮水印，並在授權授予前強制執行 [其他限制](/slides/zh-hant/php-java/licensing/)。