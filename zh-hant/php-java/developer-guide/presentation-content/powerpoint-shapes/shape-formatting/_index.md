---
title: 在 PHP 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/php-java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 草圖圖形線條
- 格式化連接樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形渲染
- 灰階圖形渲染
- 旋轉圖形
- 3D 倒角效果
- 3D 旋轉效果
- 重設格式化
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整控制 PPT、PPTX 與 ODP 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化其輪廓。另外，您亦能透過指定設定來控制圖形內部的填滿方式，以格式化圖形。

![PowerPoint 中的圖形格式化](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供類別與方法，讓您使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明其程序：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 設定圖形的 [線條樣式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linestyle/)。
5. 設定線條寬度。
6. 設定 [虛線樣式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linedashstyle/)。
7. 設定圖形的線條顏色。
8. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何格式化矩形 `AutoShape`：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填充顏色。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 套用格式至矩形的線條。
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // 設定矩形線條的顏色。
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![簡報中已格式化的線條](formatted-lines.png)

## **將草圖效果套用於圖形線條**

草圖效果會使圖形線條看起來像手繪。使用 `Shape.getLineFormat` 取得線條設定，`LineFormat.getSketchFormat` 取得草圖設定，並使用 `SketchFormat.setSketchType` 從 `LineSketchType` 列舉中選取值。

以下 PHP 程式碼示範如何套用 `LineSketchType.Curved` 效果、讀取明確指派的值，並以 `LineSketchType.None` 移除效果：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // 存取圖形的線條格式及其草圖格式。
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // 套用草圖效果。
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // 讀取直接指派給圖形的草圖效果。
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // 移除草圖效果。
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

`SketchFormat.getSketchType` 回傳的值代表直接指派給圖形的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 `LineFormat.getEffective`，存取回傳物件的 `getSketchFormat` 方法，並讀取其 `getSketchType` 值。有效值會在繼承解析後反映實際套用的格式：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **設定連接樣式**

以下是三種連接類型選項：

* 圓角
* 斜角
* 倒角

預設情況下，PowerPoint 在角度（例如圖形的角落）處連接兩條線時，使用 **圓角** 設定。然而，若您繪製的圖形具有銳利角度，可能會較喜歡 **斜角** 選項。

![投影片中的連接樣式](join-style-powerpoint.png)

以下 PHP 程式碼示範如圖所示的三個矩形分別使用斜角、倒角與圓角連接樣式建立：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增三個矩形類型的自動圖形。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 設定每個矩形圖形的填充顏色。
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // 設定線條寬度。
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // 設定每個矩形線條的顏色。
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 設定連接樣式。
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // 為每個矩形新增文字。
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，允許您將連續的顏色混合套用至圖形。例如，您可以以一種顏色逐漸淡入另一種顏色的方式填滿圖形。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Gradient`。
5. 使用由 [GradientFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/gradientformat/) 類別所公開的漸層停止集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
6. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何為橢圓套用漸層填色效果：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個橢圓類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式化。
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // 設定漸層方向。
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // 新增兩個漸層停止點。
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![套用漸層填色的橢圓](gradient-fill.png)

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，讓您將兩色設計（如點、條紋、交叉陰影或格線）套用至圖形。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預先定義的圖案樣式，您可將其套用於圖形以提升簡報的視覺效果。即使選取預定義圖案後，仍可指定其使用的確切顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖案填色：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Pattern`。
5. 從預先定義的選項中選擇圖案樣式。
6. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getBackColor)。
7. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getForeColor)。
8. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何為矩形套用圖案填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // 設定圖案樣式。
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // 設定圖案的背景色與前景色。
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![套用圖案填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入影像——實際上是將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Picture`。
5. 將圖片填色模式設為 `Tile`（或其他您偏好的模式）。
6. 從您欲使用的影像建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件。
7. 將影像傳遞給 `SlidesPicture.setImage` 方法。
8. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖案如下：

![蓮花圖片](lotus.png)

以下 PHP 程式碼示範如何以圖片填滿圖形：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 設定填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 設定圖片填充模式。
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // 載入圖片並將其加入簡報資源。
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // 設定圖片。
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![套用圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

若希望將平鋪的圖片作為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 類別的以下方法：

- `setPictureFillMode`：設定圖片填色模式——`Tile` 或 `Stretch`。
- `setTileAlignment`：指定圖形內平鋪圖塊的對齊方式。
- `setTileFlip`：控制圖塊是否水平、垂直或同時翻轉。
- `setTileOffsetX`：設定圖塊相對於圖形原點的水平偏移（以點為單位）。
- `setTileOffsetY`：設定圖塊相對於圖形原點的垂直偏移（以點為單位）。
- `setTileScaleX`：以百分比定義圖塊的水平縮放。
- `setTileScaleY`：以百分比定義圖塊的垂直縮放。

以下程式碼範例示範如何新增具平鋪圖片填色的矩形，並設定平鋪選項：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形自動圖形。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // 設定圖形的填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 載入圖片並將其加入簡報資源。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 將圖片指派給圖形。
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // 設定圖片填充模式與平鋪屬性。
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![平鋪選項示意圖](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，會以單一、均勻的顏色填滿圖形。此背景顏色不包含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為圖形套用純色填色，請依以下步驟操作：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
5. 為圖形指定您偏好的填色。
6. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何在 PowerPoint 投影片中的矩形套用純色填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Solid。
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // 設定填充顏色。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![套用純色填色的圖形](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的不透明程度。較高的透明度會使圖形更透，讓背景或底層物件部分可見。

Aspose.Slides 讓您透過調整填色顏色的 alpha 值來設定透明度。操作方式如下：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
5. 使用 `Color` 定義具透明度的顏色（alpha 成分控制透明度）。
6. 儲存簡報。

以下 PHP 程式碼示範如何為矩形套用透明填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個實心矩形自動圖形。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 在實心圖形上新增一個透明矩形自動圖形。
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![具有透明度的圖形](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求時相當實用。

若要在投影片上旋轉圖形，請依以下步驟操作：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 將圖形的旋轉屬性設定為所需角度。
5. 儲存簡報。

以下 PHP 程式碼示範如何將圖形旋轉 5 度：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 旋轉圖形 5 度。
    $shape->setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![圖形旋轉示意圖](shape-rotation.png)

## **新增 3D 倒角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 倒角效果。

若要為圖形加入 3D 倒角效果，請依以下步驟操作：

1. 實例化 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 以定義倒角設定。
5. 儲存簡報。

以下 PHP 程式碼示範如何為圖形套用 3D 倒角效果：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 在投影片上新增圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // 設定圖形的 ThreeDFormat 屬性。
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // 將簡報儲存為 PPTX 檔案。
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![3D 倒角效果示意圖](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

若要為圖形套用 3D 旋轉：

1. 建立 [簡報](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 依索引取得投影片的參考。
3. 在投影片上新增 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 使用 `setCameraType` 與 `setLightType` 定義 3D 旋轉。
5. 儲存簡報。

以下 PHP 程式碼示範如何為圖形套用 3D 旋轉效果：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // 將簡報儲存為 PPTX 檔案。
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![3D 旋轉效果示意圖](3D-rotation-effect.png)

## **控制圖形的黑白渲染**

`Shape::setBlackWhiteMode` 方法指定個別圖形在以黑白模式檢視或處理簡報時的渲染方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下變更圖形的填色、線條或其他格式。

使用來自 `BlackWhiteMode` 類別的值以選取所需行為。例如，`Automatic` 讓渲染應用程式自行選擇轉換方式，`Gray` 與 `LightGray` 使用灰階，`BlackWhite` 僅使用黑白，`Black` 與 `White` 强制單色，`Color` 保持正常彩色，`Hidden` 在黑白模式下隱藏圖形，`NotDefined` 表示未指定圖形層級模式。

以下 PHP 程式碼建立一個彩色圖形，並使其在黑白顯示模式下呈現灰色：

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // 在彩色模式下保留橙色填充，但在黑白模式下以灰色渲染圖形。
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在正常彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因模式設定為 `Gray`，故使用灰色呈現。此功能讓您在保留全彩投影片的同時，為列印、預覽或其他尊重簡報黑白顯示設定的工作流程定義特定外觀。

## **重設格式化**

以下 Java 程式碼示範如何重設版面投影片上的所有佔位圖形的定位、大小與格式，將其恢復為預設設定：

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // 重設投影片上在版面配置中具有佔位符的每個圖形。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的影像與媒體占用了大部分檔案空間，而圖形參數如顏色、效果與漸層僅以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形以便將它們群組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有相應的值皆相同，則視為樣式相同，可在邏輯上將這些圖形群組，從而簡化後續的樣式管理。

**是否可以將自訂圖形樣式集合儲存為獨立檔案，以便在其他簡報中重複使用？**

可以。將帶有所需樣式的範例圖形存於模板簡報或 .POTX 模板檔。建立新簡報時，開啟該模板，複製所需的樣式圖形，並在需要的地方重新套用其格式。