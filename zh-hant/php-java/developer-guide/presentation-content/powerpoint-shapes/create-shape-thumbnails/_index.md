---
title: 在 PHP 中建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/php-java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀圖像
- 渲染形狀
- 形狀渲染
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 從 PowerPoint 投影片產生高品質的形狀縮圖──輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立簡報檔案，每頁都是投影片。這些投影片可以使用 Microsoft PowerPoint 開啟來檢視。但有時開發人員可能需要在圖像檢視器中單獨查看形狀的圖像。在此情況下，Aspose.Slides 可協助您產生投影片形狀的縮圖圖像。如何使用此功能請參閱本文章。

本文說明了如何以不同方式產生投影片縮圖：

- 在投影片內產生形狀縮圖。
- 針對具有使用者自訂尺寸的投影片形狀產生形狀縮圖。
- 在形狀外觀的邊界內產生形狀縮圖。

## **從投影片產生形狀縮圖**
若要使用 Aspose.Slides for PHP via Java 從任何投影片產生形狀縮圖，請按以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 在預設比例下，取得參考投影片的[取得形狀縮圖圖像](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)。
4. 將縮圖圖像儲存為您偏好的圖像格式。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```php
  # 實例化一個代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立完整比例的影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 將影像以 PNG 格式儲存至磁碟
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **產生使用者自訂縮放比例縮圖**
若要使用 Aspose.Slides for PHP via Java 產生投影片的形狀縮圖，請按以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 取得參考投影片的[取得形狀縮圖圖像](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)，並使用使用者自訂的尺寸。
4. 將縮圖圖像儲存為您偏好的圖像格式。

以下範例程式碼示範如何根據自訂縮放比例產生形狀縮圖：

```php
  # 實例化一個代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立完整比例的影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 將影像以 PNG 格式儲存至磁碟
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **建立以邊界為基礎的形狀外觀縮圖**
此建立形狀縮圖的方法允許開發人員在形狀外觀的邊界內產生縮圖。它會考慮所有形狀效果。產生的形狀縮圖受投影片邊界限制。若要在外觀的邊界內產生投影片形狀的縮圖，請按以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。
2. 使用 ID 或索引取得任意投影片的參考。
3. 取得參考投影片的縮圖圖像，使用形狀邊界作為外觀。
4. 將縮圖圖像儲存為您偏好的圖像格式。

以下範例程式碼基於上述步驟：

```php
  # 實例化一個代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立完整比例的影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 將影像以 PNG 格式儲存至磁碟
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**儲存形狀縮圖時可使用哪些圖像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/)，以及其他格式。形狀也可以透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**

`Shape` 使用形狀的幾何；`Appearance` 會考慮[視覺效果](/slides/zh-hant/php-java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會被渲染為縮圖嗎？**

隱藏的形狀仍屬於模型的一部份，且可以被渲染；隱藏旗標會影響簡報播放時的顯示，但不會阻止產生形狀的圖像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**

是的。任何以[Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 形式表示的物件（包括[GroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)以及[SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字體會影響文字形狀縮圖的品質嗎？**

會。您應該[提供必要的字體](/slides/zh-hant/php-java/custom-font/)（或[設定字體替代](/slides/zh-hant/php-java/font-substitution/)），以避免不必要的回退及文字重新排版。