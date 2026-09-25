---
title: 使用 Node.js 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中使用 Aspose.Slides 套用並渲染 PowerPoint 形狀與文字的 3D 效果。可設定相機、光源、材質、擠出、填充以及 3D 文字。"
---
## **概覽**

Aspose.Slides for Node.js via Java 可以建立、編輯、保留並呈現類似 PowerPoint 的 3D 格式設定，適用於形狀與文字。本文說明 3D 效果，包括旋轉、擠出、斜角、照明、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本篇文章討論 PowerPoint 形狀與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果轉換成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getThreeDFormat) 方法對形狀套用 3D 格式設定。此方法會傳回 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/)，負責控制該形狀的 3D 場景。

針對文字，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。這會對文字框套用 3D 格式，而不是形狀本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getLightRig) | 燈光預設、方向與燈光旋轉。 | 調整 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setMaterial) | 表面材質，如平面、霧面、塑膠或金屬。 | 使相同的幾何形狀看起來更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從正面向後延伸的距離。 | 將平面形狀變為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 擠出側面的顏色。 | 使深度可見或將側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式使用的額外深度。 | 為形狀或文字微調深度，特別是結合斜角與材質設定時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面的升起或圓角邊緣。 | 加入柔和或模具式邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

形狀在看起來具說服力的 3D 效果前，通常需要以下四種設定：

- 相機設定，因為預設的正面視圖可能隱蔽擠出效果。
- 燈光設定，因為光線使各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面形狀需要厚度。

下列範例建立一個矩形，於正面加入文字，並套用 3D 格式。相機旋轉值以度為單位，擠出高度為 100 點。此範例將投影片渲染為 PNG 圖片，尺寸為預設的兩倍，並將簡報儲存為 PPTX。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

渲染出的投影片圖像顯示矩形為厚實的 3D 方塊：

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉設定位於「3‑D 旋轉」窗格。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

在 Aspose.Slides 中，透過 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getCamera) 取得相機。此範例建立矩形、選擇正交前視圖，並將 X、Y、Z 旋轉分別設定為 20、30、40 度。它在記憶體中配置形狀，未寫入檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

當需要改變觀察者觀看物件的角度時使用相機。它不會改變投影片上 2D 形狀的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出會讓形狀看起來變厚，因為它向正面後方延伸。PowerPoint 中的深度控制即設定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

使用 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) 設定厚度，並使用 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) 取得側面顏色。此範例為矩形設定 100 點擠出，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置形狀，未寫入檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setDepth) 方法設定 3D 形狀的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) 方法則控制擠出效果的高度，如此範例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式設定與形狀填充相互獨立。您可以為正面套用單色、漸層、圖案或圖片填充，同時使用相同的相機、光源、材質與擠出設定。

此範例將藍到橙的漸層套用於正面，並將深橙色套用於 150 點的擠出。漸層止點 0 與 100 分別標示漸層的開始與結束。相機旋轉值以度為單位。投影片渲染為 PNG 圖片，尺寸為預設的兩倍：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

渲染結果保留正面的漸層，同時獨立呈現擠出：

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

若改用圖片填充，先將圖片加入簡報並指定為形狀填充。此範例假設工作目錄中已有名為 "image.jpg" 的檔案。它將圖片拉伸以填滿矩形，套用 150 點擠出，並以度為單位設定相機旋轉。形狀同樣在記憶體中配置，未寫入或渲染檔案：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

圖片渲染於正面，擠出則以 3D 側面呈現：

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **將 3D 格式套用於文字**

形狀的 3D 格式影響形狀本體；文字的 3D 格式影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立具有橙白格線圖案的文字，套用向上的拱形，並透過 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 設定 3D。擠出高度與深度以點為單位，光源旋轉以度為單位。形狀填充與輪廓被隱藏，僅保留文字可見。此範例渲染 PNG 圖片，尺寸為預設投影片的兩倍，並將簡報儲存為 PPTX：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

文字以彎曲、擠出的 3D 形式呈現：

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **在 3D 形狀上保持文字平面顯示**

若要在保留形狀 3D 外觀的同時讓文字易於閱讀，請透過 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) 呼叫 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat)。當值為 `true` 時，文字會保持在 3D 場景之外；值為 `false` 時，文字會參與 3D 場景並遵循其方向。

此設定不會移除形狀的 3D 格式：其相機、光源、材質與擠出仍透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getThreeDFormat) 進行設定。它亦不同於一般旋轉。[Shape.setRotation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#setRotation) 會在投影片平面內旋轉形狀，而 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) 控制文字在其邊框內的自訂旋轉。保持文字在 3D 場景之外不會重設上述任一角度。

以下自包含範例建立一個藍色矩形與文字，並在原始旁邊複製一個。兩個形狀使用相同的 3D 格式，僅文字設定不同：左側為 `false`，右側為 `true`。相機角度以度為單位，擠出高度為 40 點。範例將簡報儲存為 PPTX，並將比較投影片渲染為 PNG，尺寸為預設的兩倍。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

左側文字遵循 3D 方向，右側文字保持平面且較易閱讀。兩個矩形保留相同的可見擠出與 3D 方向。

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 的幀。

請留意以下要點：

- 匯出的影像與 PDF 並非互動式。匯出後觀察者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填充與投影片縮放的組合。
- 若需檢查繼承或主題設定的格式值，請參閱 [effective shape properties](/slides/zh-hant/nodejs-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在此類格式中，視覺結果會被渲染而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會建立並渲染 PowerPoint 形狀與文字的 3D 效果。它不會將匯出的影像、PDF 或 HTML 頁面變成觀察者可旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式設定，如旋轉、擠出、斜角、照明與材質。本文僅討論 3D 效果。

**要讓 3D 形狀可見，需要哪些設定？**

最低需要設定相機旋轉以及擠出或深度。實務上，還會設定光源與材質，以確保渲染面的高光與陰影清晰可見。

**我可以同時對形狀與文字套用 3D 效果嗎？**

可以。對形狀本體使用 [Shape.getThreeDFormat]，對文字使用 [TextFrameFormat.getThreeDFormat]。

**在匯出為影像、PDF、HTML 或影片幀時，3D 效果會顯示嗎？**

會。Aspose.Slides 會在產生投影片影像、PDF、HTML 以及影片轉換幀時渲染 3D 效果。匯出的結果為渲染後的外觀，而非可編輯的 3D 物件。

**我可以在繼承與主題設定套用後，讀取最終的 3D 值嗎？**

可以。使用在 [Shape Effective Properties](/slides/zh-hant/nodejs-java/shape-effective-properties/) 中描述的有效格式 API，讀取最終的相機、光源、斜角與相關 3D 值。