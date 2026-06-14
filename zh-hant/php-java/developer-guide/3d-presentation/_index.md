---
title: 在 PHP 中建立簡報的 3D 效果
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
description: "在 PHP 中使用 Aspose.Slides 為 PowerPoint 形狀和文字套用並呈現 3D 效果。設定相機、光源、材質、擠出、填色及 3D 文字。"
---
## **概觀**

Aspose.Slides for PHP via Java 可建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式化（形狀與文字）。本篇說明 3D 效果，包括旋轉、擠出、斜角、光源、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="primary" %}}

本篇討論的是 PowerPoint 形狀與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出中。

{{% /alert %}}

## **3D 格式化概念**

使用 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別與其 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getThreeDFormat--) 方法，可將 3D 格式化套用至形狀。該方法會傳回 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/)，負責控制該形狀的 3D 場景。

對於文字，使用 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 類別與其 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#getThreeDFormat--) 方法。此方法會將 3D 格式化套用至文字框，而非形狀本體。

最重要的設定如下：

| 方法或設定 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或套用 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getLightRig--) | 光源預設、方向與光源旋轉。 | 變更 3D 表面的高光與陰影呈現方式。 |
| [setMaterial](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setMaterial-byte-) | 表面材質，如平面、霧面、塑膠或金屬。 | 讓相同的幾何形狀看起來更平滑、柔和、有光澤或金屬感。 |
| [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | 形狀從正面向後延伸的距離。 | 將平面形狀變成可見的厚度 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getExtrusionColor--) | 擠出側面的顏色。 | 讓深度可見，或將側面顏色與正面填色協調。 |
| [setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的額外深度。 | 微調形狀或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getBevelTop--) 與 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getBevelBottom--) | 正面與背面的凸起或圓角邊緣。 | 為平面加入柔化或成型的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getContourColor--) 與 [setContourWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setContourWidth-double-) | 3D 物件的輪廓線顏色與寬度。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

形狀在看起來具有說服力的 3D 效果前，通常需要以下四種設定：

- 相機設定，因為預設的正面視角可能看不見擠出效果。  
- 光源設定，因為光線讓各面與側面可被辨識。  
- 材質設定，因為表面會影響光線的呈現方式。  
- 擠出或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式化，將簡報另存為 PPTX，並將投影片渲染為 PNG 圖片。

```php
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

渲染後的投影片圖像顯示該矩形為厚實的 3D 方塊：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉透過「3-D 旋轉」面板設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat::getCamera](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getCamera--) 設定相機類型與旋轉：

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

當需要改變觀眾觀看物件的方式時使用相機。它不會改變投影片上 2D 形狀的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出會使形狀透過延伸至正面後方而產生厚度。PowerPoint 中的深度控制即設定此可見厚度，顏色控制則設定側面顏色。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

使用 [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#getExtrusionColor--) 設定側面顏色：

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

當需要直接使用 PowerPoint 的深度值，或將深度與斜角、材質、文字效果結合時，使用 [ThreeDFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/threedformat/#setDepth-double-)。在許多形狀情境下，`setExtrusionHeight` 更直觀，因為它直接表達可見的擠出厚度。

## **結合漸層或圖片填色與 3D 效果**

3D 格式化與形狀的填色是獨立的。您可以對正面套用純色、漸層、圖樣或圖片填色，同時使用相同的相機、光源、材質與擠出設定。

以下範例對形狀套用漸層填色，並將側面顏色設為較深的擠出色：

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

渲染結果保留正面的漸層，並獨立呈現擠出側面：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

若改為使用圖片填色，先將圖片加入簡報，再指定給形狀填色：

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

圖片會渲染於正面，擠出則以 3D 側面呈現：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **將 3D 格式化套用至文字**

形狀的 3D 格式化影響形狀本體；文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光源與相機設定。

以下範例建立帶圖樣填色的文字，套用 WordArt 變形，並在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/) 上設定 3D 參數：

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

文字會以拱形、擠出的 3D 文字形式呈現：

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/php-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 的影格。

請留意以下要點：

- 匯出的影像與 PDF 不是互動式的，匯出後觀眾無法旋轉物件。  
- 最終外觀取決於相機、光源、材質、擠出、填色與投影片縮放的組合。  
- 如需檢查繼承或主題基礎的格式值，請讀取 [effective shape properties](/slides/zh-hant/php-java/shape-effective-properties/)。  
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化，於此類格式中，視覺結果會被渲染而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 形狀與文字的 3D 效果，但不會讓匯出的影像、PDF 或 HTML 頁面成為可由觀眾旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式化，如旋轉、擠出、斜角、光源與材質。本文僅討論 3D 效果。

**顯示可見 3D 形狀需要哪些設定？**

最少需設定相機旋轉，並設定擠出或深度。實務上，通常也會設定光源與材質，以確保渲染出的面有清晰的高光與陰影。

**我可以同時對形狀與文字套用 3D 效果嗎？**

可以。對形狀本體使用 [Shape::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getThreeDFormat--)，對文字使用 [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#getThreeDFormat--)。

**匯出為影像、PDF、HTML 或影片影格時會出現 3D 效果嗎？**

會。Aspose.Slides 會在產生投影片影像、PDF、HTML 以及影片轉換的影格時渲染 3D 效果。匯出的內容包含渲染後的外觀，而非可編輯的 3D 物件。

**我能在套用繼承與主題設定後讀取最終的 3D 值嗎？**

可以。請使用在 [Shape Effective Properties](/slides/zh-hant/php-java/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、斜角與相關 3D 值。