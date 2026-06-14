---
title: 在 PHP 中管理簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/php-java/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 Interop 圖形 ID
- 圖形替代文字
- 圖形版面配置
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "學習如何在 Aspose.Slides for PHP via Java 中建立、編輯與最佳化圖形，並交付高效能的 PowerPoint 簡報。"
---
## **概述**

本文說明如何在簡報中使用 Aspose.Slides 處理圖形。內容包括如何在投影片上找到圖形、複製圖形、刪除圖形、隱藏圖形、更改圖形的順序、取得 Interop 圖形 ID，以及設定替代文字以便辨識和後續處理。

此外，本文還涵蓋如何存取圖形的版面配置、將圖形渲染為 SVG、對投影片上的圖形對齊，以及使用翻轉屬性進行水平和垂直鏡像。最後，文章提供了關於圖形合併、堆疊順序與圖形鎖定的簡短 FAQ。

## **在投影片上尋找圖形**
本章節將說明一種簡易技術，讓開發人員在不使用內部 Id 的情況下，輕鬆在投影片上找到特定圖形。必須了解 PowerPoint 簡報檔案只有內部唯一 Id 能辨識投影片上的圖形，使用該 Id 進行搜尋對開發人員而言相當困難。所有加入投影片的圖形皆具備替代文字（Alt Text），建議開發人員使用替代文字來搜尋特定圖形。您可以使用 Microsoft PowerPoint 為未來可能變更的物件設定替代文字。

設定完目標圖形的替代文字後，即可使用 Aspose.Slides for PHP via Java 開啟簡報，並遍歷投影片上所有圖形。在每次遍歷時檢查圖形的替代文字，符合條件的圖形即為您需要的圖形。為了更好地示範此技術，我們建立了 [findShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) 方法，可在投影片中找出特定圖形並直接回傳該圖形。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 要尋找的圖形的替代文字
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **複製圖形**
使用 Aspose.Slides for PHP via Java 複製圖形至投影片的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 依索引取得投影片參考。
1. 取用來源投影片的圖形集合。
1. 新增投影片至簡報。
1. 將來源投影片圖形集合的圖形複製至新投影片。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下範例會在投影片中新增一個群組圖形。

```php
  # 實例化 Presentation 類別
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # 將 PPTX 檔案寫入磁碟
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **移除圖形**
Aspose.Slides for PHP via Java 允許開發人員移除任意圖形。若要從投影片中移除圖形，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 以特定 AlternativeText 找到圖形。
1. 移除該圖形。
1. 將檔案儲存至磁碟。

```php
  # 建立 Presentation 物件
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增矩形類型的自動圖形
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # 將簡報儲存至磁碟
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **隱藏圖形**
Aspose.Slides for PHP via Java 允許開發人員隱藏任意圖形。若要在投影片中隱藏圖形，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 以特定 AlternativeText 找到圖形。
1. 隱藏該圖形。
1. 將檔案儲存至磁碟。

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增矩形類型的自動圖形
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # 將簡報儲存至磁碟
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **變更圖形順序**
Aspose.Slides for PHP via Java 允許開發人員重新排列圖形。重新排列圖形可決定哪個圖形位於前端、哪個圖形位於後端。若要在投影片中重新排列圖形，請依照下列步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 新增一個圖形。
1. 在圖形的文字框內加入文字。
1. 再新增另一個座標相同的圖形。
1. 重新排列圖形順序。
1. 將檔案儲存至磁碟。

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **取得 Interop 圖形 ID**
Aspose.Slides for PHP via Java 允許開發人員取得投影片範圍內的唯一圖形識別碼，與 [getUniqueId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getuniqueid/) 只能取得簡報範圍內的唯一識別碼不同。已於 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別加入 [getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getofficeinteropshapeid/) 方法。[getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getofficeinteropshapeid/) 方法回傳的值對應 Microsoft.Office.Interop.PowerPoint.Shape 物件的 Id。以下提供範例程式碼。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 取得投影片範圍內的唯一圖形識別碼
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **設定圖形的替代文字**
Aspose.Slides for PHP via Java 允許開發人員設定任意圖形的 AlternateText。簡報中的圖形可透過 `Alternative Text` 或 [Shape Name](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/setname/) 方法加以辨識。`setAlternativeText` 與 `getAlternativeText` 方法可使用 Aspose.Slides 或 Microsoft PowerPoint 讀寫。使用此方法，您可以為圖形加上標籤，並執行如移除圖形、隱藏圖形或重新排列投影片上圖形等不同操作。設定圖形的 AlternateText 步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 在投影片上新增任意圖形。
1. 對新加入的圖形執行相應操作。
1. 遍歷圖形集合以尋找目標圖形。
1. 設定 AlternativeText。
1. 將檔案儲存至磁碟。

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增矩形類型的自動圖形
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # 將簡報儲存至磁碟
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **存取圖形的版面配置**
Aspose.Slides for PHP via Java 提供簡易 API 以存取圖形的版面配置。本文示範如何取得版面配置。

以下提供範例程式碼。

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **將圖形渲染為 SVG**
現在 Aspose.Slides for PHP via Java 已支援將圖形渲染為 SVG。已於 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別加入 [writeAsSvg](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/writeassvg/) 方法（及其重載），此方法可將圖形內容儲存為 SVG 檔案。以下程式碼示範如何將投影片的圖形匯出為 SVG 檔案。

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **對齊圖形**
Aspose.Slides 允許將圖形相對於投影片邊界或彼此之間對齊。為此，已加入重載方法 [SlidesUtil::alignShapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/alignshapes/)。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapesalignmenttype/) 列舉定義了可能的對齊選項。

**範例 1**

以下原始碼會將索引為 1、2、4 的圖形對齊至投影片上緣。

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**範例 2**

以下範例示範如何將整個圖形集合相對於集合中最底部的圖形進行對齊。

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **翻轉屬性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/) 類別提供 `flipH` 與 `flipV` 屬性，以控制圖形的水平與垂直鏡像。兩個屬性皆為 [NullableBool](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/nullablebool/) 型別，可接受 `True`（翻轉）、`False`（不翻轉）或 `NotDefined`（使用預設行為）。這些值可從圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getFrame) 取得。

若要修改翻轉設定，可使用圖形目前的位置與大小、欲設定的 `flipH` 與 `flipV` 值以及旋轉角度，建立新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shapeframe/) 實例。將此實例指派給圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getFrame) 並儲存簡報，即可套用鏡像轉換並寫入輸出檔案。

假設我們有一個 sample.pptx 檔案，其第一張投影片僅包含一個使用預設翻轉設定的圖形，如下所示。

![要翻轉的圖形](shape_to_be_flipped.png)

以下程式碼範例取得圖形目前的翻轉屬性，並同時水平與垂直翻轉該圖形。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // 取得圖形的水平翻轉屬性。
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // 取得圖形的垂直翻轉屬性。
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // 水平翻轉。
    $flipV = NullableBool::True; // 水平翻轉。
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果如下：

![翻轉後的圖形](flipped_shape.png)

## **FAQ**

**我可以在投影片上像桌面編輯器一樣合併圖形（union/intersect/subtract）嗎？**

目前沒有內建的布林運算 API。您可以自行構建所需的輪廓，例如計算結果幾何（透過 [GeometryPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/geometrypath/)）並建立具有該輪廓的新圖形，必要時移除原始圖形。

**我要如何控制堆疊順序（z-order），讓圖形永遠位於「最上層」？**

變更投影片的 [shapes](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getShapes) 集合中的插入/移動順序。為取得可預測的結果，請在完成其他所有投影片修改後最後確定 z-order。

**我可以「鎖定」圖形，防止使用者在 PowerPoint 中編輯它嗎？**

可以。設定圖形層級的保護旗標（例如鎖定選取、移動、調整大小、文字編輯）。必要時，可在母版或版面配置上鏡像相同限制。請注意這僅是 UI 級別的保護，非安全機制；若需更高保護，可結合檔案層級的限制，如 [唯讀建議或密碼保護](/slides/zh-hant/php-java/password-protected-presentation/)。