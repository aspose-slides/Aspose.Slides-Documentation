---
title: 使用 Node.js 建立簡報的 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/nodejs-java/3d-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Node.js 中使用 Aspose.Slides 應用與渲染 PowerPoint 圖形與文字的 3D 效果。配置相機、光源、材質、擠壓、填色以及 3D 文字。"
---
## **概述**

Aspose.Slides for Node.js via Java 能夠建立、編輯、保留和轉譯 PowerPoint 風格的 3D 格式設定，用於圖形和文字。本篇文章涵蓋旋轉、擠壓、斜角、光源、材質、漸層或圖片填色以及 3D 文字等 3D 效果。

{{% alert color="primary" %}}
本文說明的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式設定概念**

使用 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/).`getThreeDFormat()` 來對圖形套用 3D 格式設定。傳回的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/) 物件控制該圖形的 3D 場景。

對文字，使用 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`。這會將 3D 格式設定套用至文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getCamera) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或符合 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getLightRig) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的顯示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getMaterial) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setMaterial) | 表面材質，例如平面、啞光、塑膠或金屬。 | 讓相同的幾何形狀看起來更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 圖形從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 擠壓側面的顏色。 | 使深度可見，或讓側面顏色與正面填色協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getDepth) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 格式設定使用的額外深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelTop) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 正面與背面的凸起或圓角邊緣。 | 加入柔化或模具化的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getContourColor)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#getContourWidth) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 物件的輪廓線。 | 在渲染的輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形通常需要四種設定才能呈現可信的 3D 效果：

- 相機設定，因為預設的正面視圖可能會隱藏擠壓效果。
- 光源設定，因為光線使各面與側面更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要有厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式設定，將簡報另存為 PPTX，並將投影片渲染為 PNG 圖片。

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

在 PowerPoint 中，3D 旋轉是從「3‑D 旋轉」面板設定的。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3‑D 旋轉面板，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 `shape.getThreeDFormat()` 回傳的 3D 格式設定來設定相機類型與旋轉：

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

當需要改變觀眾觀看物件的角度時使用相機設定。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠壓與深度**

擠壓透過將圖形延伸至正面之後，使其看起來更厚實。在 PowerPoint 中，深度控制決定此可見厚度，顏色控制決定側面的顏色。

![PowerPoint 深度控制對應至擠壓顏色與擠壓高度屬性](img_02_02.png)

設定擠壓高度以決定厚度，並設定擠壓顏色以決定側面顏色：

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

當需要直接使用 PowerPoint 的深度值，或將深度與斜角、材質、文字效果結合時，使用深度設定。在許多圖形情境下，擠壓高度是較直觀的設定，因為它直接表達可見的擠壓量。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式設定與圖形的填色無關。您可以對正面套用單色、漸層、圖案或圖片填色，同時使用相同的相機、光源、材質與擠壓設定。

此範例將漸層填色套用至圖形，並將較深的擠壓顏色套用於側面：

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

渲染結果保留了正面的漸層，並分別繪製擠壓側面：

![已渲染的 3D 矩形，藍到橙的漸層填色與橙色擠壓側面](img_02_03.png)

若改為使用圖片填色，先將影像加入簡報，然後指派給圖形填色：

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

圖片會渲染於正面，而擠壓則作為 3D 側面表面呈現：

![已渲染的 3D 矩形，正面為照片填色，側面為橙色擠壓](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式影響圖形本體；文字的 3D 格式則影響文字框。這對於需要讓字母本身具有擠壓、材質、光源與相機設定的 WordArt 類似效果非常有用。

以下範例建立帶圖案填色的文字，套用 WordArt 變形，並在 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()` 上配置 3D 設定：

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

文字以拱形、擠壓的 3D 形式呈現：

![已渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填色與深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式設定。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 的框格時皆會發生。

請注意以下要點：

- 匯出的圖片與 PDF 並非互動式。匯出後，觀眾無法旋轉此物件。
- 最終外觀取決於相機、光源、材質、擠壓、填色以及投影片比例的組合。
- 如果需要檢查繼承或佈景主題的格式值，請閱讀[effective shape properties](/slides/zh-hant/nodejs-java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式設定。在這些格式中，視覺結果僅以渲染方式呈現，而非保留為可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 只能建立並渲染 PowerPoint 圖形與文字的 3D 效果。它不會讓匯出的圖片、PDF 或 HTML 頁面變成觀眾可旋轉的互動式 3D 場景。於 PPTX 中，若格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是對一般 PowerPoint 圖形或文字套用的格式設定，例如旋轉、擠壓、斜角、光源與材質。本篇文章僅討論 3D 效果。

**顯示可見 3D 圖形需要哪些設定？**

最低需要設定相機旋轉，並設定擠壓或深度。實務上，還應設定光源與材質，以確保渲染出的面有明顯的高光與陰影。

**我可以將 3D 效果套用於圖形和文字嗎？**

可以。對圖形本體使用 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/).`getThreeDFormat()`，對文字使用 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`。

**匯出至圖片、PDF、HTML 或影片框格時，會出現 3D 效果嗎？**

會。Aspose.Slides 在產生投影片圖片、PDF 輸出、HTML 輸出以及用於影片轉換的框格時，會渲染 3D 效果。匯出的檔案只包含已渲染的外觀，而非可編輯的 3D 物件。

**在繼承與佈景主題設定套用後，我能讀取最終的 3D 值嗎？**

可以。使用在 [Shape Effective Properties](/slides/zh-hant/nodejs-java/shape-effective-properties/) 中描述的有效格式 API，即可讀取最終的相機、光源、斜角與相關 3D 值。