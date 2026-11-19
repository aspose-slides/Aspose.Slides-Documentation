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
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 為 PowerPoint 形狀與文字套用並渲染 3D 效果。設定相機、照明、材質、擠出、填充以及 3D 文字。"
---
## **概覽**

Aspose.Slides for PHP via Java 可以建立、編輯、保留和呈現類似 PowerPoint 的 3D 格式化（用於形狀和文字）。本文介紹 3D 效果，如旋轉、擠出、斜角、照明、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本文說明 PowerPoint 形狀與文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 方法為形狀套用 3D 格式化。此方法會傳回 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)，用以控制該形狀的 3D 場景。

對於文字，使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。此方法會為文字框套用 3D 格式化，而非形狀本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | 檢視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面之高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、啞光、塑膠或金屬。 | 使相同的幾何形狀看起來更平坦、柔和、光澤或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從前表面向後延伸的距離。 | 將平面形狀變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | 擠出側面的顏色。 | 使深度可見，或將側面顏色與前景填充協調。 |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式化使用的額外 3D 深度。 | 微調形狀或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | 前後表面的凸起或圓角邊緣。 | 在平坦銳利的表面上加入柔和或成型的邊緣。 |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) 和 [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓線。 | 在渲染的輸出中強調物件邊界。 |

## **建立 3D 形狀**

- 相機設定，因為預設的正面視角可能會隱藏擠出效果。
- 光線設定，因為照明使面與側面易於辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面形狀需要厚度。

以下範例會建立一個矩形、在其正面加入文字，並套用 3D 格式化。相機旋轉值以度為單位，擠出高度為 100 點。範例會將投影片渲染成 PNG 圖片（尺寸為預設的兩倍），並將簡報另存為 PPTX。

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

渲染的投影片圖像顯示矩形為一個厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」窗格設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉面板，X、Y、Z 旋轉值已突顯](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) 取得相機。以下範例建立一個矩形、選取正投影前視圖，並分別將 X、Y、Z 旋轉設定為 20、30、40 度。此範例在記憶體中設定形狀，未儲存檔案：

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

在需要變更檢視者看到的物件方式時使用相機。它不會改變投影片上 2D 形狀的幾何形狀，而是改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

### **從範本形狀複製相機方向**

為了匹配範本形狀的方向，請使用 [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) 讀取其相機預設，並使用 [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation) 讀取其旋轉角度。範例開啟 `template.pptx`，將第一張投影片第一個形狀的相機方向複製到第二個形狀。兩個形狀皆已具備 3D 照明，第二個形狀則沒有明確的相機旋轉。

角度以度為單位。索引 `0` 為緯度，`1` 為經度，`2` 為旋轉。請依此順序傳遞給 [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation)。如果來源回傳 `null`，表示沒有明確的旋轉，則保持第二個形狀的角度未設定。若來源回傳 `(0, 0, 0)`，則表示三個值皆為零，應予以複製。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

重新在 PowerPoint 開啟 `camera-copy.pptx` 時，右側的箭頭將擁有與左側矩形相同的相機預設與旋轉。兩個形狀使用相同的照明與擠出深度。

![藍色 3D 矩形與右向箭頭，具相同相機方向，從上方右側檢視](camera-orientation.png)

## **加入擠出與深度**

在 PowerPoint 中，深度控制決定此可見厚度，顏色控制決定側面顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) 設定厚度，並使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) 取得側面顏色。此範例為矩形設定 100 點的擠出，側面為紫色，並旋轉相機以展示其厚度。此範例在記憶體中設定形狀，未儲存檔案：

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

[ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) 方法設定 3D 形狀的深度。[setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) 方法控制擠出效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與形狀填充相互獨立。您可以對正面套用純色、漸層、圖案或圖片填充，同時使用相同的相機、光線、材質與擠出設定。

此範例將藍到橙的漸層套用於正面，並將深橙色套用於 150 點的擠出。漸層停點 0 與 100 分別標示漸層的起始與結束。相機旋轉值以度為單位。投影片以兩倍預設尺寸渲染為 PNG 圖片：

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

渲染的輸出保留正面的漸層，且分別渲染擠出：

![渲染的 3D 矩形，具藍至橙漸層填充與橙色擠出](img_02_03.png)

若改用圖片填充，請先將圖片加入簡報，並指派給形狀的填充。本範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸以填滿矩形，套用 150 點的擠出，並以度為單位設定相機旋轉。此範例在記憶體中設定形狀，未儲存或渲染檔案：

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

渲染的結果為正面以照片填充，且擠出作為 3D 側面：

![渲染的 3D 矩形，正面以照片填充，且有橙色擠出](img_02_04.png)

## **將 3D 格式套用至文字**

形狀的 3D 格式影響形狀本體；文字的 3D 格式則影響文字框。此功能對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、照明與相機設定。

以下範例建立帶有橙白格線圖案的文字，套用向上拱形，並通過 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) 設定 3D。擠出高度與深度以點為單位，光線旋轉以度為單位。隱藏形狀填充與輪廓，使僅文字可見。範例會以兩倍預設投影片尺寸渲染 PNG 圖片，並將簡報另存為 PPTX：

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

渲染的 3D 文字帶拱形 WordArt 變形、橙色圖案填充與深色擠出：

![渲染的 3D 文字，帶拱形 WordArt 變形、橙色圖案填充與深色擠出](img_02_05.png)

## **保持文字在 3D 形狀上平面**

若要在保留形狀 3D 外觀的同時讓文字易讀，請透過 [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat) 呼叫 [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat)。當值為 `true` 時，文字會保持在 3D 場景之外；當值為 `false` 時，文字會參與場景並遵循其 3D 方向。

此設定不會移除形狀的 3D 格式：其相機、照明、材質與擠出仍透過 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) 設定。它也不同於普通旋轉。[Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 會在投影片平面上旋轉形狀，而 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) 則控制文字在其邊界框內的自訂旋轉。將文字保持在 3D 場景之外不會重置上述任一角度。

以下自行完整的範例會建立一個藍色矩形並加入文字，然後在原始形狀旁邊複製一個。兩個形狀具有相同的 3D 格式；唯一差異在於文字設定：左側為 `false`，右側為 `true`。相機角度以度為單位，擠出高度為 40 點。範例將簡報另存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG：

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

左側的文字遵循 3D 方向；右側的文字保持平面且較易閱讀。兩個矩形保留相同的可見擠出與 3D 方向。

![並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（例如 PPTX）時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。此行為同樣適用於將投影片渲染為 [PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 的框格。

- 匯出的圖像和 PDF 並非互動式。物件在匯出後無法讓檢視者旋轉。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 如果需要檢查繼承或主題基礎的格式設定值，請讀取 [有效形狀屬性](/slides/zh-hant/php-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，會將視覺結果渲染出來，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 形狀與文字的 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面成為可讓檢視者旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 內編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用在一般 PowerPoint 形狀或文字上的格式化，例如旋轉、擠出、斜角、照明與材質。本文僅討論 3D 效果。

**需要哪些設定才能產生可見的 3D 形狀？**

最低需求是設定相機旋轉，並至少設定擠出或深度。實務上，亦建議設定光源與材質，以便渲染出的面具有明顯的高光與陰影。

**我可以將 3D 效果套用於形狀與文字嗎？**

可以。對形狀本體使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat)，對文字使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat)。

**匯出為圖像、PDF、HTML 或影片框格時會出現 3D 效果嗎？**

會。Aspose.Slides 於產生投影片圖像、PDF、HTML 以及用於影片轉換的框格時，會渲染 3D 效果。匯出的結果僅包含渲染後的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我可以讀取最終的 3D 值嗎？**

可以。請使用在 [有效形狀屬性](/slides/zh-hant/php-java/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、斜角與相關 3D 值。