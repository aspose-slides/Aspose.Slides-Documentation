---
title: 在 Android 上建立 3D 簡報效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/androidjava/3d-presentation/
keywords:
- PowerPoint 3D
- 3D 簡報
- 3D 旋轉
- 3D 深度
- 3D 拉伸
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 套用並渲染 PowerPoint 形狀與文字的 3D 效果。設定相機、光源、材質、拉伸、填色以及 3D 文字。"
---
## **概觀**

Aspose.Slides for Android via Java 可以建立、編輯、保留並呈現 PowerPoint 風格的 3D 格式化（用於形狀和文字）。本文涵蓋旋轉、拉伸、斜角、照明、材質、漸層或圖片填色以及 3D 文字等 3D 效果。

{{% alert color="info" title="Note" %}}
本文說明的是在 PowerPoint 形狀和文字上套用的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 方法將 3D 格式化套用到形狀。該方法回傳 [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/)，用來控制該形狀的 3D 場景。

對於文字，請使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。此方法將 3D 格式化套用到文字框，而非形狀本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、啞光、塑膠或金屬。 | 讓相同的幾何形狀看起來更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形狀從正面向後伸出的距離。 | 將平面形狀轉換為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸側面的顏色。 | 使深度可見，或將側面顏色與正面填色協調。 |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化所使用的額外 3D 深度。 | 微調形狀或文字的深度，尤其與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面與背面之上的凸起或圓潤邊緣。 | 在正面添加柔化或模具式的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓顏色。 | 在渲染輸出中強調物件的邊界。 |

## **建立 3D 形狀**

形狀通常需要四種設定，才能看起來具有說服力的 3D 效果：

- 相機設定，因為預設的正面檢視可能會隱藏拉伸效果。
- 光源設定，因為照明能讓表面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 拉伸或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於其正面加入文字，並套用 3D 格式化。相機旋轉值以度為單位，拉伸高度為 100 點。此範例將投影片渲染為 PNG 圖像（尺寸為預設的兩倍），並將簡報另存為 PPTX。

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

渲染出的投影片圖像顯示矩形為一個厚實的 3D 塊狀：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」面板進行設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉角度。

![PowerPoint 3-D Rotation 面板，已突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 取得相機。此範例建立一個矩形，選擇正交前視，並將其 X、Y、Z 旋轉分別設定為 20、30、40 度。它在記憶體中配置形狀，未儲存檔案：

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

在需要變更觀眾觀看物件的視角時使用相機。它不會改變投影片上 2D 形狀的幾何形狀，而是更改 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

### **從範本形狀複製相機方向**

為了匹配範本形狀的方向，使用 [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) 讀取其相機預設，使用 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) 讀取其旋轉角度。此範例開啟 `template.pptx`，將第一張投影片中第一個形狀的相機方向複製到第二個形狀。兩個形狀皆已具備 3D 照明，第二個形狀則沒有明確的相機旋轉設定。

這些角度以度為單位。索引 `0` 為緯度，`1` 為經度，`2` 為旋轉。請依此順序傳入 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-)。如果來源回傳 `null`，代表沒有明確的旋轉，則保留第二個形狀的角度未設定。明確的旋轉 `(0, 0, 0)` 會回傳三個零，應予以複製。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

當您在 PowerPoint 中重新開啟 `camera-copy.pptx`，右側的箭頭會具有與左側矩形相同的相機預設與旋轉。兩個形狀使用相同的光源與拉伸深度。

![一個藍色 3D 矩形與一個相機方向匹配的右向箭頭，從上方右側觀看](camera-orientation.png)

## **新增拉伸與深度**

拉伸透過將形狀延伸至正面之後，使其看起來更厚。於 PowerPoint 中，深度控制設定此可見厚度，而顏色控制則設定側面顏色。

![PowerPoint 深度控制對應到拉伸顏色與拉伸高度屬性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 取得側面顏色。此範例為矩形設定 100 點的拉伸，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置形狀，未儲存檔案：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) 方法設定 3D 形狀的深度。 [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法控制拉伸效果的高度，如本範例所示。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式化與形狀填色互不影響。您可以對正面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與拉伸設定。

此範例將藍至橙的漸層套用於正面，並將深橙色用於 150 點的拉伸。漸層在 0 與 100 處分別為起點與終點。相機旋轉值以度為單位。投影片以兩倍預設尺寸渲染為 PNG 圖像：

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

渲染的輸出保留正面的漸層，同時分別渲染拉伸側面：

![渲染的 3D 矩形，正面為藍至橙漸層填色，側面為橙色拉伸](img_02_03.png)

若改用圖片填色，請將圖像加入簡報並指定為形狀填色。此範例需要在工作目錄中已有名為 "image.jpg" 的檔案。它將圖片拉伸以填滿矩形，套用 150 點的拉伸，並以度為單位設定相機旋轉。它在記憶體中配置形狀，未儲存或渲染檔案：

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

圖片在正面渲染，而拉伸則作為 3D 側面表面渲染：

![渲染的 3D 矩形，正面為照片填色，側面為橙色拉伸](img_02_04.png)

## **將 3D 格式化套用於文字**

形狀的 3D 格式化會影響形狀本體；文字的 3D 格式化會影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要拉伸、材質、照明與相機設定。

以下範例建立具有橙白格線圖案的文字，套用向上拱形，並透過 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 設定 3D 參數。拉伸高度與深度以點為單位，光源旋轉以度為單位。形狀填色與輪廓被隱藏，僅顯示文字。本範例以兩倍預設投影片尺寸渲染 PNG 圖像，並將簡報另存為 PPTX：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

文字以彎曲、拉伸的 3D 字母方式渲染：

![渲染的 3D 文字，帶拱形 WordArt 變形、橙色圖案填色與深色拉伸](img_02_05.png)

## **在 3D 形狀上保持文字平面**

若要在保留形狀 3D 外觀的同時讓文字易於閱讀，請透過 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) 呼叫 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。當值為 `true` 時，文字不會進入 3D 場景；當值為 `false` 時，文字會參與場景並遵循其 3D 方向。

此設定不會移除形狀的 3D 格式化：其相機、光源、材質與拉伸仍透過 [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 進行設定。它也不同於一般的旋轉。[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) 會在投影片平面上旋轉形狀，而 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 則控制文字在其邊框內的自訂旋轉。讓文字保持在 3D 場景之外不會重設這兩個角度。

以下獨立範例建立一個帶文字的藍色矩形，並在原始矩形旁邊複製一個。兩個形狀擁有相同的 3D 格式化，僅文字設定不同：左側為 `false`，右側為 `true`。相機角度以度為單位，拉伸高度為 40 點。範例將簡報儲存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

左側的文字會遵循 3D 方向。右側的文字保持平面，較易閱讀。兩個矩形保留相同的可見拉伸與 3D 方向。

![並排的 3D 矩形：左側文字遵循 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（例如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 的影格時皆適用。

請留意以下要點：

- 匯出的圖像與 PDF 不是互動式的，匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光源、材質、拉伸、填色與投影片縮放的組合。
- 若需檢查繼承或主題基礎的格式值，請閱讀 [有效形狀屬性](/slides/zh-hant/androidjava/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，視覺結果會被渲染，而非保留為可編輯的 3D 設定。

## **常見問答**

**Aspose.Slides 能建立互動式 3D 簡報嗎？**

Aspose.Slides 會建立並渲染形狀與文字的 PowerPoint 3D 效果。它不會使匯出的圖像、PDF 或 HTML 頁面成為觀眾可旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 形狀或文字的格式化，例如旋轉、拉伸、斜角、照明與材質。本文討論的即是 3D 效果。

**要顯示 3D 形狀需要哪些設定？**

最低需求是設定相機旋轉以及拉伸或深度。實務上，亦須設定光源與材質，以使渲染的表面呈現明顯的高光與陰影。

**我能將 3D 效果套用於形狀與文字嗎？**

可以。對形狀本體使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)，對文字使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

**匯出為圖像、PDF、HTML 或影片影格時，3D 效果會出現嗎？**

會。Aspose.Slides 在產生投影片圖像、PDF、HTML 以及用於影片轉換的影格時，都會渲染 3D 效果。匯出的結果僅包含已渲染的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 值嗎？**

可以。使用在 [形狀有效屬性](/slides/zh-hant/androidjava/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、斜角與相關 3D 值。