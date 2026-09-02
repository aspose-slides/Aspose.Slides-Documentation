---
title: 使用 PHP 建立簡報形狀縮圖
linktitle: 形狀縮圖
type: docs
weight: 70
url: /zh-hant/php-java/create-shape-thumbnails/
keywords:
- 形狀縮圖
- 形狀影像
- 呈現形狀
- 形狀渲染
- 視覺邊界
- 形狀邊界
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，從 PowerPoint 投影片產生高品質的形狀縮圖──輕鬆建立並匯出簡報縮圖。"
---
## **簡介**

Aspose.Slides 用於建立每頁皆為投影片的簡報檔案。這些投影片可以使用 Microsoft PowerPoint 開啟來檢視。但有時開發人員可能需要在影像檢視器中單獨查看形狀的圖像。此時，Aspose.Slides 可協助您產生投影片形狀的縮圖影像。如何使用此功能請參閱本文。  
本文說明了以不同方式產生投影片縮圖的方法：

- 在投影片內產生形狀縮圖。  
- 為投影片形狀產生具有使用者自訂尺寸的形狀縮圖。  
- 在形狀外觀的邊界內產生形狀縮圖。

## **從投影片產生形狀縮圖**

使用 Aspose.Slides for PHP via Java 從任何投影片產生形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 使用其 ID 或索引取得任意投影片的參考。  
1. 在預設比例下，取得參考投影片的[形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)。  
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼示範如何從投影片產生形狀縮圖：

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立全尺寸影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 以 PNG 格式將影像儲存至磁碟
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

## **產生使用者自訂縮放係數的縮圖**

使用 Aspose.Slides for PHP via Java 產生投影片形狀縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 使用其 ID 或索引取得任意投影片的參考。  
1. 以使用者自訂尺寸取得參考投影片的[形狀縮圖影像](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage)。  
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼示範如何根據定義的縮放係數產生形狀縮圖：

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立全尺寸影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 以 PNG 格式將影像儲存至磁碟
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

## **建立基於邊界的形狀外觀縮圖**

此方法允許開發人員在形狀外觀的邊界內產生縮圖，會考慮所有形狀效果。產生的形狀縮圖受到投影片邊界的限制。若要在外觀的邊界內產生投影片形狀的縮圖，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 使用其 ID 或索引取得任意投影片的參考。  
1. 以形狀外觀的邊界取得參考投影片的縮圖影像。  
1. 以您偏好的影像格式儲存縮圖。

以下範例程式碼根據上述步驟：

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 建立全尺寸影像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 以 PNG 格式將影像儲存至磁碟
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

## **取得形狀的實際視覺邊界**

[Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 的框架屬性——`Shape::getX()`、`Shape::getY()`、`Shape::getWidth()` 和 `Shape::getHeight()`——描述了儲存在簡報模型中的矩形。實際呈現的內容可能會超出該框架或佔用不同的軸對齊矩形。旋轉、輪廓、箭頭、文字版面配置與溢位、產生的 SmartArt 幾何形狀以及其他渲染效果皆可能改變佔用的區域。  
使用 [Shape::getVisualBounds](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getVisualBounds) 來計算此佔用區域，而無需建立圖像。此方法會以投影片座標返回一個 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。返回的矩形不會被投影片裁切，若內容延伸至投影片原點之外，其座標可能為負值。  

以下範例取得並比較框架與視覺邊界：

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

相同的 [Rectangle2D.Float] 可用於將相鄰形狀對齊至其左側、右側、上側或下側邊緣；在產生的版面配置中保留足夠空間；或偵測超出允許區域的內容。視覺邊界對於 SmartArt、文字方塊、箭頭、圖片、旋轉形狀與群組形狀特別有用，因為儲存的框架可能未完整呈現最終結果。  

當您需要布局或驗證的座標且不需要位圖時，請使用 [Shape::getVisualBounds]。當您需要渲染形狀時，請使用 [Shape::getImage]。使用 [ShapeThumbnailBounds] 時，`ShapeThumbnailBounds::Shape` 會根據形狀框架（包括輪廓設定）調整圖片大小；而 `ShapeThumbnailBounds::Appearance` 則根據形狀的外觀調整，並將結果限制於投影片邊界。相較之下，`Shape::getVisualBounds` 只返回計算出的矩形且不會裁切至投影片。

## **常見問題**

**儲存形狀縮圖時可使用哪些影像格式？**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imageformat/)，以及其他格式。形狀亦可透過將形狀內容儲存為 SVG 來[匯出為向量 SVG](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/)。

**在渲染縮圖時，Shape 與 Appearance 邊界有何差異？**  
`Shape` 使用形狀的幾何結構；`Appearance` 則會考慮[視覺效果](/slides/zh-hant/php-java/shape-effect/)（陰影、發光等）。

**如果形狀被標記為隱藏，會發生什麼情況？它仍會顯示為縮圖嗎？**  
隱藏的形狀仍保留在模型中並且可以渲染；隱藏旗標僅影響投影片放映的顯示，並不會阻止產生形狀影像。

**是否支援群組形狀、圖表、SmartArt 以及其他複雜物件？**  
是。任何以 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 表示的物件（包括 [GroupShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/)以及 [SmartArt](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartart/)）皆可儲存為縮圖或 SVG。

**系統安裝的字型會影響文字形狀縮圖的品質嗎？**  
會。您應該[提供所需的字型](/slides/zh-hant/php-java/custom-font/)（或[設定字型替代](/slides/zh-hant/php-java/font-substitution/)），以避免不必要的備用字型和文字重排。