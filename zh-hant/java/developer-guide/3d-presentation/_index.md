---
title: 使用 Java 在簡報中建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/java/3d-presentation/
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
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 套用與渲染 PowerPoint 形狀與文字的 3D 效果。設定相機、光源、材質、拉伸、填充，以及 3D 文字。"
---
## **概覽**

Aspose.Slides for Java 能夠建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式化，包括形狀與文字。本文介紹旋轉、拉伸、倒角、光照、材質、漸層或圖片填充以及 3D 文字等 3D 效果。

{{% alert color="info" %}}
本文說明的是 PowerPoint 形狀與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染為匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/).`getThreeDFormat()` 來對形狀套用 3D 格式化。返回的格式物件控制該形狀的 3D 場景。

對於文字，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。此方法對文字框套用 3D 格式化，而非形狀本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getCamera--) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面的高光與陰影顯示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、霧面、塑膠或金屬。 | 讓相同的幾何形狀呈現更平坦、柔軟、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形狀從正面向後延伸的距離。 | 將平面形狀變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸側面的顏色。 | 使深度可見，或將側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的額外深度。 | 微調形狀或文字的深度，尤其與倒角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面與背面的凸起或圓角邊緣。 | 為物件加入柔化或成形的邊緣，取代尖銳的平坦面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourWidth--), 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

一個形狀在看起來具說服力的 3D 效果之前，通常需要以下四種設定：

- 相機設定，因為預設的正視圖可能會隱藏拉伸效果。
- 光源設定，因為光照讓各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 拉伸或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於其正面加入文字，套用 3D 格式化，將簡報儲存為 PPTX，並將投影片渲染為 PNG 圖像。

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

渲染出的投影片圖像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」窗格設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 視窗格，標示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，使用 `shape.getThreeDFormat()` 回傳的 3D 格式物件設定相機類型與旋轉：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

當您需要變更觀者觀看物件的角度時使用相機。它不會改變投影片上 2D 形狀的幾何形態，只會改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **加入拉伸與深度**

拉伸透過將形狀向正面後方延伸，使其看起來更厚。於 PowerPoint 中，深度控制決定此可見厚度，顏色控制則決定側面的顏色。

![PowerPoint 深度控制對應到拉伸顏色與拉伸高度屬性](img_02_02.png)

設定拉伸高度以決定厚度，並設定拉伸顏色以決定側面顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

當需要直接使用 PowerPoint 的深度值，或將深度與倒角、材質及文字效果結合時，使用深度設定。在許多形狀情境下，拉伸高度較為直觀，因為它直接表達可見的拉伸。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式化與形狀填充相互獨立。您可以對正面套用純色、漸層、圖案或圖片填充，同時使用相同的相機、光源、材質與拉伸設定。

此範例對形狀套用漸層填充，並將側面拉伸顏色設為較暗：

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

渲染結果保留正面的漸層，同時獨立渲染拉伸效果：

![渲染的 3D 矩形，藍至橙色漸層填充，橙色拉伸](img_02_03.png)

若改用圖片填充，請先將影像加入簡報並指派給形狀填充：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

圖片會在正面渲染，而拉伸則以 3D 側面表面渲染：

![渲染的 3D 矩形，正面為照片填充，橙色拉伸](img_02_04.png)

## **將 3D 格式化套用至文字**

形狀的 3D 格式化影響形狀本體。文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要拉伸、材質、光照與相機設定。

以下範例建立帶有圖案填充的文字，套用 WordArt 變形，並於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` 設定 3D 參數：

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

文字被渲染為彎曲、拉伸的 3D 字樣：

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充，深色拉伸](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面的格式時，3D 場景會被光柵化或繪製成 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/java/convert-powerpoint-to-video/) 的影格時皆適用。

請注意以下要點：

- 匯出的圖像與 PDF 不是互動式的。匯出後，觀者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、拉伸、填充與投影片縮放的組合。
- 若需檢視繼承或主題基礎的格式值，請讀取 [effective shape properties](/slides/zh-hant/java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問題**

### Aspose.Slides 能建立互動式 3D 簡報嗎？

Aspose.Slides 會建立並渲染形狀與文字的 PowerPoint 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面成為觀者可旋轉的互動式 3D 場景。在 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

### 3D 模型與 3D 效果有何差異？

3D 模型是插入簡報的獨立 3D 物件。3D 效果是套用於一般 PowerPoint 形狀或文字的格式化，如旋轉、拉伸、倒角、光照與材質。本文僅討論 3D 效果。

### 需要哪些設定才能產生可見的 3D 形狀？

至少需要設定相機旋轉，並同時設定拉伸或深度。實務上，還會設定光源與材質，使渲染的面具有明顯的高光與陰影。

### 是否能同時將 3D 效果套用於形狀與文字？

可以。對形狀本體使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/).`getThreeDFormat()`，對文字使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。

### 匯出為圖像、PDF、HTML 或影片影格時會出現 3D 效果嗎？

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及用於影片轉換的影格時，會渲染 3D 效果。匯出的內容包含已渲染的外觀，而非可編輯的 3D 物件。

### 在繼承與主題設定套用後，我能讀取最終的 3D 值嗎？

可以。使用在 [Shape Effective Properties](/slides/zh-hant/java/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、倒角與相關 3D 值。