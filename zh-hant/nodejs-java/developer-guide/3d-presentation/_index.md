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
- 3D 拉伸
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中使用 Aspose.Slides 套用及渲染 PowerPoint 圖形與文字的 3D 效果。設定相機、光源、材質、拉伸、填色，以及 3D 文字。"
---
## **概觀**

Aspose.Slides for Node.js via Java 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式設定，適用於圖形與文字。本篇文章探討 3D 效果，例如旋轉、拉伸、斜角、光源、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="info" title="Note" %}}
本篇文章說明 PowerPoint 圖形與文字的 3D 格式化效果。它不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染到匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式化概念**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) 方法將 3D 格式套用到圖形。此方法會回傳 [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/)，用來控制該圖形的 3D 場景。

對於文字，使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 方法。此方法會將 3D 格式套用到文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、啞光、塑膠或金屬。 | 使相同的幾何形狀看起來更平坦、較柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 形狀從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 拉伸側面的顏色。 | 讓深度可見，或使側面顏色與正面填色協調。 |
| [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式所使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定同時使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面之提升或圓角邊緣。 | 加入柔和或成形的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件周圍的輪廓線。 | 在渲染結果中強調物件邊界。 |

## **建立 3D 圖形**

- 相機設定，因為預設的正面視圖可能隱藏拉伸效果。
- 光源設定，因為光照使得各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 拉伸或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於其正面加入文字，並套用 3D 格式。相機旋轉值以度為單位，拉伸高度為 100 點。範例會將投影片渲染成 PNG 圖像，尺寸為預設的兩倍，並將簡報儲存為 PPTX。

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

渲染出的投影片圖像顯示矩形為一個厚實的 3D 方塊：

![已渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」面板設定的。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，存取相機的方式是使用 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getCamera)。此範例建立一個矩形，選擇正投影前視圖，並將其 X、Y、Z 旋轉分別設定為 20、30、40 度。它在記憶體中設定圖形，而不儲存檔案：

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

當需要變更觀眾觀看物件的方式時，使用相機。它不會改變投影片上 2D 圖形的幾何形狀，而是更改 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

### **從範本圖形複製相機方向**

為了匹配範本圖形的方向，請使用 [getCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getCameraType) 讀取其相機預設，並使用 [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#getRotation) 讀取其旋轉角度。此範例開啟 `template.pptx`，將第一張投影片中第一個圖形的相機方向複製到第二個圖形。兩個圖形均已具備 3D 燈光，第二個圖形沒有明確的相機旋轉。

角度以度為單位。索引 `0` 為緯度，索引 `1` 為經度，索引 `2` 為旋轉。依此順序傳遞給 [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation)。如果來源回傳 `null`，代表沒有明確的旋轉，則保留第二個圖形的角度未設定。若明確旋轉為 `(0, 0, 0)`，會回傳三個零，應予以複製。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    const destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    const angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

當您在 PowerPoint 中重新開啟 `camera-copy.pptx` 時，右側的箭頭會與左側的矩形擁有相同的相機預設與旋轉。兩個圖形使用相同的光源與拉伸深度。

![一個藍色 3D 矩形與一個右箭頭，相機方向相同，從上方與右側觀看](camera-orientation.png)

## **新增拉伸與深度**

拉伸透過將形狀延伸至正面之後，使其看起來更厚實。在 PowerPoint 中，深度控制設定此可見的厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到拉伸顏色與拉伸高度屬性](img_02_02.png)

使用 [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) 設定厚度，並使用 [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) 取得側面顏色。此範例為矩形設定 100 點的拉伸，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中設定圖形，而不儲存檔案：

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

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) 方法設定 3D 圖形的深度。[setExtrusionHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) 方法則控制拉伸效果的高度，如同此範例所示。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式化與圖形填色相互獨立。您可以為正面套用純色、漸層、圖案或圖片填色，同時保留相同的相機、光源、材質與拉伸設定。

此範例將藍至橙的漸層套用到正面，並將側面的 150 點拉伸設定為深橙色。漸層在 0 與 100 的位置分別為起始與結束。相機旋轉值以度為單位。投影片會以兩倍預設尺寸渲染為 PNG 圖像：

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

已渲染的 3D 矩形，藍至橙色漸層填色與橙色拉伸：

![已渲染的 3D 矩形，藍至橙色漸層填色與橙色拉伸](img_02_03.png)

若改為使用圖片填色，請先將影像加入簡報，並指定給圖形填色。此範例需要工作目錄中已有名為 "image.jpg" 的檔案。它會將圖片拉伸以填滿矩形，套用 150 點拉伸，並以度為單位設定相機旋轉。它在記憶體中設定圖形，而不儲存或渲染檔案：

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

已渲染的 3D 矩形，正面使用相片填色與橙色拉伸：

![已渲染的 3D 矩形，正面使用相片填色與橙色拉伸](img_02_04.png)

## **將 3D 格式套用至文字**

圖形的 3D 格式化會影響圖形本體；文字的 3D 格式化則會影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身也需要拉伸、材質、光源與相機設定。

以下範例建立文字，套用橙白格子圖案，施加向上拱形，並透過 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 設定 3D 參數。拉伸高度與深度以點為單位，光源旋轉以度為單位。圖形填色與輪廓被隱藏，僅顯示文字。範例會以兩倍預設投影片尺寸渲染 PNG 圖像，並將簡報儲存為 PPTX：

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

已渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填色與深色拉伸：

![已渲染的 3D 文字，帶有拱形 WordArt 變形、橙色圖案填色與深色拉伸](img_02_05.png)

## **在 3D 圖形上保持文字平面**

為了在保留圖形 3D 外觀的同時，使文字易於閱讀，請透過 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getTextFrameFormat) 呼叫 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat)。當值為 `true` 時，文字會保持在 3D 場景之外；當值為 `false` 時，文字會參與 3D 場景並遵循其方向。

此設定不會移除圖形的 3D 格式化：其相機、光源、材質與拉伸仍透過 [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) 進行設定。它也不同於普通的旋轉。[Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) 會在投影片平面上旋轉圖形，而 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) 則控制文字在其邊框內的自訂旋轉。保持文字在 3D 場景之外不會重設這兩個角度。

以下完整範例建立一個藍色矩形並加入文字，然後在原件旁複製一次。兩個圖形的 3D 格式相同，唯一差異是文字設定：左側為 `false`、右側為 `true`。相機角度以度為單位，拉伸高度為 40 點。範例將簡報儲存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG：

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

並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面：

![並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)，或產生供 [video conversion](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 使用的影格。

請留意以下要點：

- 匯出的圖像與 PDF 不是互動式的。匯出後物件無法被觀眾旋轉。
- 最終外觀取決於相機、光源、材質、拉伸、填色與投影片縮放的組合。
- 如果需要檢查繼承或主題基礎的格式值，請閱讀 [有效圖形屬性](/slides/zh-hant/nodejs-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，視覺結果會以渲染方式呈現，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能夠建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 圖形與文字的 3D 效果。它不會使匯出的圖像、PDF 或 HTML 頁面變成可讓觀眾旋轉的互動式 3D 場景。在支援的 PPTX 格式中，3D 格式仍保留為可在 PowerPoint 中編輯的設定。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果是對一般 PowerPoint 圖形或文字套用的格式化，例如旋轉、拉伸、斜角、光源與材質。本篇文章僅討論 3D 效果。

**顯示 3D 圖形需要哪些設定？**

至少需要設定相機旋轉以及拉伸或深度。實務上，還應設定光源與材質，以確保渲染出的面具有明顯的高光與陰影。

**我能將 3D 效果套用到圖形與文字嗎？**

可以。對圖形本體使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat)，對文字使用 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat)。

**匯出為圖像、PDF、HTML 或影片幀時，3D 效果會出現嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF 輸出、HTML 輸出以及用於影片轉換的影格時，會渲染 3D 效果。匯出的結果包含渲染後的外觀，而非可編輯的 3D 物件。

**在繼承與主題設定套用後，我能讀取最終的 3D 值嗎？**

可以。請使用在 [有效圖形屬性](/slides/zh-hant/nodejs-java/shape-effective-properties/) 中描述的有效格式化 API，來讀取最終的相機、光源、斜角與相關 3D 值。