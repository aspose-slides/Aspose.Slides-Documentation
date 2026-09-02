---
title: 在 PHP 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/php-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完整控制 PPT、PPTX 與 ODP 檔案的填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上新增圖形。由於圖形是由線條組成，您可以透過修改或套用效果到其輪廓來格式化它們。此外，您還可以透過指定控制內部填充方式的設定來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供了可讓您使用與 PowerPoint 相同選項格式化圖形的類別與方法。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明整個程序：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 設定圖形的 [線條樣式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [虛線樣式](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何格式化矩形 `AutoShape`：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Rectangle 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填色。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 對矩形的線條套用格式化。
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

![The formatted lines in the presentation](formatted-lines.png)

## **將草圖效果套用至圖形線條**

草圖效果會讓圖形線條看起來像手繪。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 取得線條設定，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/lineformat/) 取得草圖設定，並使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linesketchtype/) 列舉中選擇值。

以下 PHP 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linesketchtype/) 效果、讀取明確指定的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linesketchtype/) 移除效果：

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

由 [SketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sketchformat/) 回傳的值代表直接指派給圖形的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [LineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/lineformat/)，取得回傳物件的 `getSketchFormat` 方法，並讀取其 `getSketchType` 值。有效值會反映在繼承解析後實際套用的格式：

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

## **格式化接合樣式**

以下是三種接合類型選項：

* Round（圓角）
* Miter（斜接）
* Bevel（斜面）

預設情況下，PowerPoint 在以角度（例如圖形角落）連接兩條線時，使用 **Round** 設定。然而，若您繪製的圖形具有尖銳角度，可能會較偏好 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 PHP 程式碼示範如何使用 Miter、Bevel 與 Round 接合樣式建立三個矩形（如上圖所示）：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增三個類型為 Rectangle 的自動圖形。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 設定每個矩形圖形的填色。
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

    // 設定接合樣式。
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // 為每個矩形加入文字。
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

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您對圖形套用連續的顏色混合。例如，您可以以逐漸過渡的方式將兩種或多種顏色應用於圖形。

以下示範如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/gradientformat/) 類別所公開的漸層停止集合的 `add` 方法，加入您偏好的兩個顏色並設定其位置。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何對橢圓套用漸層填色效果：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Ellipse 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // 套用漸層格式至橢圓。
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // 設定漸層的方向。
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

![The ellipse with gradient fill](gradient-fill.png)

## **圖樣填色**

在 PowerPoint 中，圖樣填色是一種格式化選項，可讓您對圖形套用兩色圖案——例如點、條紋、交叉陰影或格子。您可以為圖樣的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖樣樣式，您可以將其套用至圖形以提升簡報的視覺效果。即使選擇了預定義圖樣，仍可指定其實際使用的顏色。

以下示範如何使用 Aspose.Slides 為圖形套用圖樣填色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預設選項中挑選圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getBackColor)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getForeColor)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何對矩形套用圖樣填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Rectangle 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // 設定圖樣樣式。
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // 設定圖樣的背景色與前景色。
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入圖像，實質上將圖像作為圖形的背景。

以下示範如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設為 `Tile`（或其他偏好的模式）。
1. 從您要使用的圖像建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件。
1. 將圖像傳遞給 `SlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖片如下：

![The lotus picture](lotus.png)

以下 PHP 程式碼示範如何將圖片填色套用至圖形：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Rectangle 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 設定填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 設定圖片填充模式。
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // 載入圖像並將其加入簡報資源。
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

![The shape with picture fill](picture-fill.png)

### **將圖片以紋理方式平鋪**

如果您想將平鋪圖片作為紋理並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填充模式，可為 `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定圖形內平鋪圖塊的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制圖塊是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定圖塊相對於圖形原點的水平偏移量（點）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定圖塊相對於圖形原點的垂直偏移量（點）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義圖塊的水平縮放比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義圖塊的垂直縮放比例。

以下程式碼範例示範如何新增一個具有平鋪圖片填色的矩形圖形，並設定平鋪選項：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 新增矩形自動圖形。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // 設定圖形的填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 載入圖像並將其加入簡報資源。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 把圖像指派給圖形。
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

![The tile options](tile-options.png)

## **單色填色**

在 PowerPoint 中，單色填色是一種格式化選項，會以單一、均勻的顏色填滿圖形。此純色背景不會包含任何漸層、紋理或圖樣。

若要使用 Aspose.Slides 為圖形套用單色填色，請依照以下步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指派您偏好的填充顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何在 PowerPoint 投影片的矩形上套用單色填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Rectangle 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Solid。
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // 設定填色。
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用單色、漸層、圖片或紋理填色時，也可以設定透明度以控制填色的不透明程度。較高的透明度值會使圖形更為透視，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填色顏色的 α 值來設定透明度。操作方式如下：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具透明度的顏色（`alpha` 成分控制透明度）。
1. 儲存簡報。

以下 PHP 程式碼示範如何為矩形套用透明填色：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增實心矩形自動圖形。
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 在實心圖形上方新增透明矩形自動圖形。
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

![The transparent shape](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計的視覺元素時非常有用。

若要旋轉投影片上的圖形，請依照以下步驟：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將圖形的 rotation 屬性設定為所需的角度。
1. 儲存簡報。

以下 PHP 程式碼示範如何將圖形旋轉 5 度：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增類型為 Rectangle 的自動圖形。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 將圖形旋轉 5 度。
    $shape->setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 斜角效果。

若要為圖形新增 3D 斜角效果，請依照以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 PHP 程式碼示範如何為圖形套用 3D 斜角效果：

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

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

若要對圖形套用 3D 旋轉：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片上新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/lightrig/#setLightType) 定義 3D 旋轉。
1. 儲存簡報。

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

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 上所有具有佔位符的圖形的定位、大小與格式還原為預設設定：

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // 重設投影片上每個在版面上具有佔位符的圖形。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖片與媒體佔用大部分檔案空間，而顏色、效果與漸層等圖形參數以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有對應值皆相同，則視為樣式相同，便可在邏輯上將這些圖形分組，從而簡化後續的樣式管理。

**我可以將一組自訂圖形樣式儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例圖形存放於範本投影片或 .POTX 範本檔案中。建立新簡報時，開啟該範本，複製所需的樣式圖形，然後在需要的地方重新套用其格式。