---
title: 使用 PHP 管理簡報中的圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/php-java/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 新增圖像
- 建立圖像
- 擷取圖像
- 點陣圖像
- 向量圖像
- 裁剪圖像
- 裁剪區域
- StretchOff 屬性
- 圖片框架格式設定
- 圖片框架屬性
- 相對比例
- 圖像效果
- 長寬比例
- 圖像透明度
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，將圖片框架新增至 PowerPoint 與 OpenDocument 簡報。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框架是一種包含圖像的形狀——它就像一幅相片放在框中。  

您可以透過圖片框架將圖像加入投影片。如此一來，您即可透過格式化圖片框架來格式化圖像。

{{% alert  title="提示" color="primary" %}} 
Aspose 提供免費的轉換器——[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)——讓使用者能快速從圖像建立簡報。 
{{% /alert %}} 

## **建立圖片框架**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 以加入圖像至與簡報物件關聯的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件，該圖像將用於填充形狀。  
4. 指定圖像的寬度與高度。  
5. 透過參考投影片的形狀物件所公開的 `addPictureFrame` 方法，依圖像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)。  
6. 將包含圖片的圖片框架加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。

此 PHP 程式碼示範如何建立圖片框架：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 實例化 Image 類別
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 新增一個圖片框架，其高度與寬度與圖片等同
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
圖片框架讓您能快速以圖像建立簡報投影片。結合 Aspose.Slides 的儲存選項，即可在輸入/輸出操作中將圖像從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/image-to-jpg/); 轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-image/); 轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/jpg-to-png/)，轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-jpg/); 轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/php-java/conversion/png-to-svg/)，轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/php-java/conversion/svg-to-png/)。 
{{% /alert %}}

## **建立具有相對比例的圖片框架**

透過調整圖像的相對縮放，您可以建立更複雜的圖片框架。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 將圖像加入簡報的圖像集合。  
4. 以加入圖像至與簡報物件關聯的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件，該圖像將用於填充形狀。  
5. 為圖片框架指定圖像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。

此 PHP 程式碼示範如何建立具有相對比例的圖片框架：

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 實例化 Image 類別
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 新增圖片框架，其高度與寬度與圖片等同
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 設定相對比例的寬度與高度
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **從圖片框架提取點陣圖像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 物件提取點陣圖像，並以 PNG、JPG 等格式儲存。以下程式碼範例示範如何從檔案「sample.pptx」中提取圖像並以 PNG 格式儲存。

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **從圖片框架提取 SVG 圖像**

當簡報的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 形狀內放置了 SVG 圖形時，Aspose.Slides for PHP via Java 允許您以完整保真度取得原始向量圖像。透過遍歷投影片的形狀集合，您可以識別每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)，檢查其底層的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 是否包含 SVG 內容，然後將該圖像以原生 SVG 格式儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框架提取 SVG 圖像：

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **取得圖像的透明度**

Aspose.Slides 允許您取得套用於圖像的透明度效果。以下 PHP 程式碼示範此操作：

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **取得圖像的亮度與對比度**

Aspose.Slides 允許您取得套用於圖像的亮度與對比度效果。[Luminance](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/luminance/) 類別代表此圖像轉換效果。

以下 PHP 程式碼示範如何從圖片框架取得亮度與對比度設定：

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **圖片框架格式設定**

Aspose.Slides 提供許多可套用於圖片框架的格式設定選項。使用這些選項，您可以調整圖片框架以符合特定需求。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 以加入圖像至與簡報物件關聯的 [ImageCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/imagecollection/) 來建立 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件，該圖像將用於填充形狀。  
4. 指定圖像的寬度與高度。  
5. 透過 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/) 物件所公開的 [addPictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapecollection/addpictureframe/) 方法，依圖像的寬度與高度建立 `PictureFrame`。  
6. 將包含圖片的圖片框架加入投影片。  
7. 設定圖片框架的線條顏色。  
8. 設定圖片框架的線條寬度。  
9. 以正值或負值旋轉圖片框架。  
   * 正值會順時針旋轉圖像。  
   * 負值會逆時針旋轉圖像。  
10. 再次將包含圖片的圖片框架加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。

此 PHP 程式碼示範圖片框架的格式設定流程：

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 實例化 Image 類別
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # 新增圖片框架，其高度與寬度與圖片等同
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # 為 PictureFrameEx 套用一些格式設定
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="提示" color="primary" %}}
Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖像、[從照片建立格子圖](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，即可使用此服務。 
{{% /alert %}}

## **將圖像作為連結加入**

為了避免簡報檔案過大，您可以透過連結加入圖像（或影片），而不是直接將檔案內嵌於簡報中。此 PHP 程式碼示範如何將圖像與影片加入占位區：

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **裁剪圖像**

此 PHP 程式碼示範如何在投影片上裁剪既有圖像：

```php
  $pres = new Presentation();
  # 建立新的圖像物件
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 將 PictureFrame 新增至投影片
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # 裁剪圖像（百分比值）
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # 儲存結果
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **刪除圖片的裁剪區域**

若您想刪除框架中圖像的裁剪區域，可使用 [deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 方法。若不需要裁剪，此方法會回傳原始圖像。

此 PHP 程式碼示範此操作：

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 取得第一張投影片的 PictureFrame
    $picFrame = $slide->getShapes()->get_Item(0);
    # 刪除 PictureFrame 圖像的裁剪區域並回傳裁剪後的圖像
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # 儲存結果
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 
[deletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 方法會將裁剪後的圖像加入簡報的圖像集合。若該圖像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 中使用，這種設定可減少簡報檔案大小。否則，最終簡報的圖像數量會增加。  

此方法在裁剪操作中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 圖像。 
{{% /alert %}}

## **壓縮圖像**

您可以使用 [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮小圖像尺寸，並可選擇刪除裁剪區域。

它的運作方式類似於 PowerPoint 的 **圖片格式 → 壓縮圖片 → 解析度** 功能。

以下 PHP 範例示範如何透過指定目標解析度並可選擇移除裁剪區域來壓縮簡報中的圖像：

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 以目標解析度 150 DPI（網頁解析度）壓縮圖像並移除裁剪區域。
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # 檢查壓縮結果。
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

或直接使用自訂 DPI 值：

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # 將圖像壓縮至 150 DPI（網頁解析度），並移除裁剪區域。
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="注意" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 將圖像轉換為較低解析度。裁剪區域亦可被刪除以優化檔案大小。  
若圖像為中繪圖檔（WMF/EMF）或 SVG，則不會套用壓縮。JPEG 的品質則會根據解析度略為下降，與 PowerPoint 處理高解析度 JPEG 的方式相同。 
{{% /alert %}}

## **鎖定長寬比例**

若您希望包含圖像的形狀在變更圖像尺寸後仍保留長寬比例，可使用 [setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) 方法設定 *鎖定長寬比例*。

此 PHP 程式碼示範如何鎖定形狀的長寬比例：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # 設定形狀在調整大小時保留長寬比例
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 
此 *鎖定長寬比例* 設定僅保留形狀的比例，並不會鎖定其中的圖像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

透過 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 類別的 [setStretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/)、[setStretchOffsetTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/setstretchoffsettop/)、[setStretchOffsetRight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) 以及 [setStretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) 方法，您可以指定填充矩形。

當為圖像指定拉伸時，來源矩形會被縮放以符合指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界框相應邊的百分比偏移定義。正值百分比表示內縮，負值表示外延。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的執行個體。  
2. 透過索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立圖像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 加入圖像以填充形狀。  
8. 依形狀邊界框的相應邊設定圖像的偏移。  
9. 將修改後的簡報寫入為 PPTX 檔案。  

此 PHP 程式碼示範使用 StretchOff 屬性的流程：

```php
  # 實例化代表 PPTX 檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 實例化 ImageEx 類別
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 新增 AutoShape 並設定為矩形
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # 設定形狀的填充類型
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # 設定形狀的圖片填充模式
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # 設定圖像以填充形狀
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 指定圖像相對於形狀邊界框相應邊的偏移量
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如何找出支援的圖片框架圖像格式？**  
Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 的圖像物件，同時支援點陣圖（PNG、JPEG、BMP、GIF 等）與向量圖（例如 SVG）。支援的格式清單大致與投影片及圖像轉換引擎的能力相重疊。

**加入大量大型圖像會如何影響 PPTX 檔案大小與效能？**  
內嵌大型圖像會增加檔案大小與記憶體使用量；以連結方式加入圖像可減少簡報大小，但需確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入圖像的功能，以降低檔案大小。

**如何防止圖像物件被意外移動或調整大小？**  
使用 [shape locks](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/getpictureframelock/) 來鎖定 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)（例如停用移動或調整大小）。此鎖定機制支援多種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/)。

**在將簡報匯出為 PDF/影像時，SVG 向量的保真度是否會被保留？**  
Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pictureframe/) 中提取原始 SVG 向量。當 [匯出為 PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 時，結果可能會根據匯出設定被點陣化；然而，原始 SVG 仍以向量形式儲存，這可透過提取行為得到驗證。