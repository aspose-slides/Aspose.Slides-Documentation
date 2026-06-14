---
title: 在 PHP 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/php-java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 格式化交接樣式
- 漸層填充
- 圖樣填充
- 圖片填充
- 紋理填充
- 純色填充
- 形狀透明度
- 旋轉形狀
- 3D 邊緣效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何在 PHP 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完全掌控地為 PPT、PPTX 與 ODP 檔案設定填充、線條與效果樣式。"
---
## **介紹**

在 PowerPoint 中，您可以向投影片添加形狀。由於形狀是由線條組成，您可以透過修改或套用輪廓效果來格式化它們。此外，您也可以透過指定控制內部填充方式的設定來格式化形狀。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java 提供了類別與方法，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明了此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/linedashstyle/)。
1. 為形狀設定線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何格式化矩形 `AutoShape`：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // 設定矩形形狀的填充顏色。
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // 為矩形的線條套用格式設定。
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

## **格式化交接樣式**

以下是三種交接類型選項：

* Round
* Miter
* Bevel

預設情況下，PowerPoint 在形狀角落等角度處連接兩條線時，使用 **Round** 設定。然而，若您繪製的是銳角形狀，可能會較喜歡 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 PHP 程式碼示範如何使用 Miter、Bevel 與 Round 交接類型設定建立如上圖所示的三個矩形：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增三個矩形類型的自動形狀。
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // 為每個矩形形狀設定填充顏色。
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

    // 為每個矩形的線條設定顏色。
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // 設定交接樣式。
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

## **漸層填充**

在 PowerPoint 中，漸層填充是一種格式化選項，可讓您將連續的顏色混合應用於形狀。例如，您可以以一種顏色逐漸淡出到另一種顏色的方式應用兩種或多種顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [GradientFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/gradientformat/) 類別所公開的漸層停止集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何對橢圓套用漸層填充效果：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個橢圓類型的自動形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // 對橢圓套用漸層格式設定。
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

## **圖樣填充**

在 PowerPoint 中，圖樣填充是一種格式化選項，讓您可以將兩色設計（例如點、條紋、交叉陰影或格子）套用至形狀。您可以為圖樣的前景色與背景色自行選擇顏色。

Aspose.Slides 提供超過 45 種預定義的圖樣樣式，您可以將其套用至形狀以增強簡報的視覺效果。即使選擇了預定義圖樣，仍可自行指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖樣填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getBackColor)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/patternformat/#getForeColor)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何對矩形套用圖樣填充：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

## **圖片填充**

在 PowerPoint 中，圖片填充是一種格式化選項，允許您將影像插入形狀內部，實質上是將影像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設定為 `Tile`（或其他您偏好的模式）。
1. 使用您欲使用的影像建立一個 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件。
1. 將影像傳遞給 `SlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下是一張名為「lotus.png」的示例圖片：

![The lotus picture](lotus.png)

以下 PHP 程式碼示範如何以圖片填充形狀：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // 設定填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 設定圖片填充模式。
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // 載入影像並將其加入簡報資源。
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

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片設定為紋理，並自訂平鋪行為，可使用 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setPictureFillMode)：設定圖片填充模式—`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileFlip)：控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileOffsetX)：設定平鋪相對於形狀原點的水平偏移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileOffsetY)：設定平鋪相對於形狀原點的垂直偏移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileScaleX)：以百分比定義水平縮放比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/picturefillformat/#setTileScaleY)：以百分比定義垂直縮放比例。

以下程式碼示範如何新增一個帶有平鋪圖片填充的矩形形狀，並配置平鋪選項：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // 設定形狀的填充類型為 Picture。
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // 載入圖像並將其加入簡報資源。
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // 將圖像指定給形狀。
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

## **純色填充**

在 PowerPoint 中，純色填充是一種格式化選項，可將形狀填滿單一、均勻的顏色。此背景顏色不包含任何漸層、紋理或圖樣。

若要使用 Aspose.Slides 為形狀套用純色填充，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指派您偏好的填充顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 PHP 程式碼示範如何在 PowerPoint 投影片的矩形上套用純色填充：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用純色、漸層、圖片或紋理填充時，也可以設定透明度以控制填充的不透明程度。較高的透明度值會使形狀更透明，讓背景或底層物件部分可見。

Aspose.Slides 允許您透過調整填充顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義帶有透明度的顏色（alpha 元件控制透明度）。
1. 儲存簡報。

以下 PHP 程式碼示範如何為矩形套用透明填充顏色：

```php
    // 實例化代表簡報檔案的 Presentation 類別。
    $presentation = new Presentation();
    try {
        // 取得第一張投影片。
        $slide = $presentation->getSlides()->get_Item(0);

        // 新增一個實心矩形自動形狀。
        $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

        // 在實心形狀之上加入一個透明矩形自動形狀。
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

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

若要在投影片上旋轉形狀，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 將形狀的 rotation 屬性設定為所需的角度。
1. 儲存簡報。

以下 PHP 程式碼示範如何將形狀旋轉 5 度：

```php
// 實例化代表簡報檔案的 Presentation 類別。
$presentation = new Presentation();
try {
    // 取得第一張投影片。
    $slide = $presentation->getSlides()->get_Item(0);

    // 新增一個矩形類型的自動形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // 將形狀旋轉 5 度。
    $shape->setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **加入 3D 邊緣效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 邊緣效果。

若要為形狀加入 3D 邊緣效果，請依照以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 以定義邊緣設定。
1. 儲存簡報。

以下 PHP 程式碼展示如何為形狀套用 3D 邊緣效果：

```php
// 建立 Presentation 類別的實例。
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 向投影片新增形狀。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // 設定形狀的 ThreeDFormat 屬性。
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

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/) 屬性，為形狀套用 3D 旋轉效果。

若要為形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 向投影片新增一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/camera/#setCameraType) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/lightrig/#setLightType) 定義 3D 旋轉。
1. 儲存簡報。

以下 PHP 程式碼示範如何為形狀套用 3D 旋轉效果：

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

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/) 上所有佔位符形狀的位置、大小與格式恢復為預設設定：

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // 重設投影片上在版面配置中具有占位符的每個形狀。
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖片與媒體佔用大部分檔案空間，而形狀的參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀以便分組？**

比較每個形狀的關鍵格式屬性——填充、線條與效果設定。若所有對應值相同，即可視為樣式相同，並在邏輯上將這些形狀分組，這樣可簡化之後的樣式管理。

**我可以將一組自訂的形狀樣式儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將具有目標樣式的範例形狀存放於模板投影片或 .POTX 模板檔中。建立新簡報時，開啟該模板，複製所需的樣式形狀，並在需要的地方重新套用其格式。