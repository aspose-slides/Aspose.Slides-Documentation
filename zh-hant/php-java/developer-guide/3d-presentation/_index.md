---
title: 使用 PHP 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/php-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 擠壓
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 套用並呈現 PowerPoint 形狀與文字的 3D 效果。設定相機、光照、材質、擠壓、填充以及 3D 文字。"
---
## **概述**

Aspose.Slides for PHP via Java 能夠建立、編輯、保留與呈現 PowerPoint 風格的形狀與文字之 3D 格式化。本篇文章涵蓋旋轉、擠壓、斜角、光照、材質、漸層或圖片填充，以及 3D 文字等 3D 效果。

{{% alert color="info" title="Note" %}}
本文說明 PowerPoint 形狀與文字的 3D 格式化效果，並不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getThreeDFormat--) 方法為形狀套用 3D 格式化。此方法會回傳 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/)，用來控制該形狀的 3D 場景。

對文字而言，請使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 方法。此方法會將 3D 格式化套用至文字框，而非形狀本體。

最重要的 API 成員包括：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 形狀從前表面向後延伸的距離。 | 將平面形狀變為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 擠壓側面的顏色。 | 使深度可見，或讓側面顏色與前景填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 格式化所使用的額外 3D 深度。 | 微調形狀或文字的深度，特別是與斜角和材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getBevelBottom--) | 前後表面的凸起或圓角邊緣。 | 加入柔和或成型的邊緣，以取代銳利平面的外觀。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 物件的輪廓線。 | 在渲染輸出中突顯物件邊界。 |

## **建立 3D 形狀**

形狀通常需要四種設定才能呈現出逼真的 3D 效果：

- 相機設定，因為預設的前視圖可能會隱藏擠壓效果。
- 光源設定，因為光照使表面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於其前表面加入文字，並套用 3D 格式化。相機旋轉值以度數表示，擠壓高度為 100 點。此範例會將投影片渲染成 PNG 圖像（尺寸為預設的兩倍），並將簡報儲存為 PPTX。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

渲染出的投影片圖像顯示矩形為一個厚實的 3D 塊狀：

![渲染的藍色 3D 矩形，前表面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值與透過相機 API 所設定的旋轉相對應。

![PowerPoint 3-D 旋轉面板，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getCamera--) 取得相機。此範例建立一個矩形，選擇正交前視圖，並分別將 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置形狀，未儲存檔案：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

當需要變更觀眾觀看物件的角度時，使用相機。它不會改變投影片上 2D 形狀的幾何形態，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠壓與深度**

擠壓透過將形狀延伸至前表面之後，使其看起來更厚。在 PowerPoint 中，深度控制設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應至擠壓顏色與擠壓高度屬性](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getExtrusionColor--) 取得側面顏色。此範例為矩形設定 100 點的擠壓，側面為紫色，且旋轉相機以顯示其厚度。它在記憶體中配置形狀，未儲存檔案：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setDepth-double-) 方法設定 3D 形狀的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 方法控制擠壓效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與形狀填充相互獨立。您可以對前表面套用純色、漸層、圖案或圖片填充，並同時使用相同的相機、光源、材質與擠壓設定。

此範例將藍至橙的漸層套用於前表面，並將 150 點的擠壓側面設定為深橙色。漸層在 0 與 100 處停止，分別標示漸層的開始與結束。相機旋轉值以度數表示。投影片渲染為 PNG 圖像（尺寸為預設的兩倍）：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

渲染的 3D 矩形，藍至橙漸層填充與橙色擠壓：

![渲染的 3D 矩形，藍至橙漸層填充與橙色擠壓](img_02_03.png)

若改用圖片填充，請先將圖像加入簡報，然後指派給形狀填充。本範例需要工作目錄中已有名為「image.jpg」的檔案。它將圖片拉伸以填滿矩形，套用 150 點的擠壓，並以度數設定相機旋轉。它在記憶體中配置形狀，未儲存或渲染檔案：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

渲染的 3D 矩形，前表面為照片填充，側面為橙色擠壓：

![渲染的 3D 矩形，前表面為照片填充，側面為橙色擠壓](img_02_04.png)

## **將 3D 格式化套用至文字**

形狀的 3D 格式化會影響形狀本體；文字的 3D 格式化則影響文字框。此功能適用於類似 WordArt 的效果，讓字母本身具備擠壓、材質、光照與相機設定。

以下範例建立具有橙白格線圖案的文字，套用向上拱形，並透過 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 設定 3D 參數。擠壓高度與深度以點為單位，光線旋轉則以度數表示。形狀的填充與輪廓被隱藏，僅保留文字可見。此範例將投影片渲染成 PNG 圖像（尺寸為預設的兩倍），並將簡報儲存為 PPTX：

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充與深色擠壓：

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充與深色擠壓](img_02_05.png)

## **在 3D 形狀上保持文字平面**

若要在保留形狀 3D 外觀的同時保持文字可讀，請透過 [TextFrame::getTextFrameFormat] 呼叫 [TextFrameFormat::setKeepTextFlat]。當值為 `true` 時，文字不會進入 3D 場景；當值為 `false` 時，文字會參與場景並遵循 3D 方向。

此設定不會移除形狀的 3D 格式化：相機、光源、材質與擠壓仍透過 [Shape::getThreeDFormat] 進行設定。它也不同於一般旋轉。[Shape::setRotation] 會在投影片平面上旋轉形狀，而 [TextFrameFormat::setRotationAngle] 控制文字在其邊框內的自訂旋轉。將文字保持在 3D 場景之外不會重置上述任一角度。

以下獨立範例建立一個藍色矩形與文字，並在原始旁邊複製一個。兩個形狀均具相同的 3D 格式化，唯一差異在文字設定：左側為 `false`，右側為 `true`。相機角度以度數表示，擠壓高度為 40 點。此範例將簡報儲存為 PPTX，並將比較投影片渲染為 PNG（尺寸為預設的兩倍）。

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面：

![並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 於儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面配置格式時，3D 場景會被光柵化或繪製成 2D 結果。這在將投影片渲染為 [PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 的影格時均適用。

- 匯出的影像與 PDF 並非互動式。匯出後使用者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠壓、填充以及投影片縮放的組合。
- 若需檢視繼承或主題基礎的格式設定值，請閱讀 [有效形狀屬性](/slides/zh-hant/php-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會為形狀與文字建立並渲染 PowerPoint 的 3D 效果。但它不會將匯出的影像、PDF 或 HTML 頁面變成觀眾可以旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式化，例如旋轉、擠壓、斜角、光照與材質。本文說明的是 3D 效果。

**要顯示可見的 3D 形狀需要哪些設定？**

最低需求是設定相機旋轉以及擠壓或深度。實務上，亦應設定光源與材質，使渲染出的表面具備明顯的高光與陰影。

**我能否同時對形狀與文字套用 3D 效果？**

是的。對形狀本體使用 [Shape::getThreeDFormat]，對文字使用 [TextFrameFormat::getThreeDFormat] 來套用 3D 效果。

**匯出為影像、PDF、HTML 或影片影格時，3D 效果會出現嗎？**

是的。Aspose.Slides 在產生投影片影像、PDF、HTML，以及用於影片轉換的影格時，皆會渲染 3D 效果。匯出的結果為已渲染的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我可以讀取最終的 3D 值嗎？**

是的。使用在 [有效形狀屬性](/slides/zh-hant/php-java/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、斜角與相關 3D 值。