---
title: 在 Android 上為簡報建立 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 為 PowerPoint 圖形與文字套用及渲染 3D 效果。設定相機、照明、材質、拉伸、填充與 3D 文字。"
---
## **概述**

Aspose.Slides for Android via Java 能夠建立、編輯、保留與呈現 PowerPoint 風格的 3D 格式設定，適用於圖形與文字。本文涵蓋 3D 效果，例如旋轉、拉伸、斜角、照明、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="注意" %}}

本文討論的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染至匯出的 2D 輸出。

{{% /alert %}}

## **3D 格式設定概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 方法將 3D 格式套用到圖形。此方法會傳回 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/)，用來控制該圖形的 3D 場景。

對於文字，使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。此方法會將 3D 格式套用到文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 它控制什麼 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面的高光與陰影呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 與 [setMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、霧面、塑膠或金屬。 | 使相同幾何形狀呈現較平坦、柔和、有光澤或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 與 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形狀從前表面向後延伸的距離。 | 將平面形狀轉換為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 拉伸側面的顏色。 | 使深度可見或將側面顏色與前景填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 與 [setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式設定所使用的額外 3D 深度。 | 微調形狀或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 與 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前後表面的凸起或圓角邊緣。 | 加入柔化或成型的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) 與 [setContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 形狀**

一個形狀在看起來具有說服力的 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正視圖可能會隱藏拉伸效果。
- 光線設定，因為照明使各面與側面可辨。
- 材質設定，因為表面會影響光線的呈現。
- 拉伸或深度設定，因為平面形狀需要厚度。

以下範例建立一個矩形，於其正面加入文字，並套用 3D 格式。相機旋轉值以度為單位，拉伸高度為 100 點。此範例將投影片渲染為 PNG 圖像（尺寸為預設的兩倍），並將簡報儲存為 PPTX。

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

渲染出的投影片圖像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉形狀**

在 PowerPoint 中，3D 旋轉是從「3-D 旋轉」窗格設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉窗格，突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 取得相機。此範例建立一個矩形，選擇正交前視圖，並分別將 X、Y、Z 旋轉設定為 20、30、40 度。它在記憶體中配置圖形，未儲存檔案：

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

當您需要變更觀眾看到物件的方式時，使用相機。它不會改變投影片上 2D 圖形的幾何形狀；而是改變 PowerPoint 與 Aspose.Slides 在渲染時使用的 3D 觀點。

## **新增拉伸與深度**

拉伸透過將形狀延伸至前面之後，使其看起來更厚。PowerPoint 中的深度控制決定此可見厚度，顏色控制則決定側面的顏色。

![PowerPoint 深度控制對映至拉伸顏色與拉伸高度屬性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 取得側面顏色。此範例為矩形設定 100 點的拉伸，側面為紫色，並旋轉相機以顯示其厚度。它在記憶體中配置圖形，未儲存檔案：

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) 方法設定 3D 形狀的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法則控制拉伸效果的高度，如本例所示。

## **在 3D 效果中使用漸層或圖片填充**

3D 格式與圖形的填充互不影響。您可以對正面套用純色、漸層、圖案或圖片填充，同時使用相同的相機、光線、材質與拉伸設定。

此範例對正面套用藍到橙的漸層，對 150 點的拉伸使用深橙色。漸層在 0 與 100 處停止，分別標示漸層的起點與終點。相機旋轉值以度為單位。投影片以兩倍預設尺寸渲染為 PNG 圖像：

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

渲染結果保留了正面的漸層，同時單獨渲染拉伸側面：

![渲染的 3D 矩形，藍到橙的漸層填充與橙色拉伸](img_02_03.png)

若要改用圖片填充，將圖片加入簡報並指派給圖形填充。此範例假設工作目錄中已有名為「image.jpg」的檔案。它會將圖片拉伸以填滿矩形，套用 150 點的拉伸，並以度為單位設定相機旋轉。它在記憶體中配置圖形，未儲存或渲染檔案：

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

圖片呈現在正面，拉伸則以 3D 側面呈現：

![渲染的 3D 矩形，正面使用相片填充，側面為橙色拉伸](img_02_04.png)

## **將 3D 格式套用到文字**

圖形的 3D 格式影響圖形本體；文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要拉伸、材質、照明與相機設定。

以下範例建立帶有橙白格子圖案的文字，套用向上拱形，並透過 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 設定 3D。拉伸高度與深度以點為單位，光線旋轉以度為單位。圖形填充與輪廓被隱藏，僅保留文字可見。此範例將 PNG 圖像以兩倍投影片預設尺寸渲染，並將簡報儲存為 PPTX：

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

文字以拱形、立體化的方式呈現：

![渲染的 3D 文字，拱形 WordArt 變形，橙色圖案填充與深色拉伸](img_02_05.png)

## **在 3D 形狀上保持文字平面**

若要在保持形狀 3D 外觀的同時，使文字易於閱讀，請透過 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) 呼叫 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。當值為 `true` 時，文字不會進入 3D 場景；當值為 `false` 時，文字會參與場景並遵循 3D 方向。

此設定不會移除圖形的 3D 格式：其相機、光線、材質與拉伸仍透過 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 進行配置。它也不同於一般的旋轉。[IShape.setRotation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setRotation-float-) 會在投影片平面內旋轉圖形，而 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 控制文字在其邊界盒內的自訂旋轉。將文字排除於 3D 場景外不會重設上述任一角度。

以下自行完整的範例建立一個藍色矩形與文字，並在右側複製一個相同的形狀。兩個圖形的 3D 格式相同，只有文字設定不同：左側為 `false`，右側為 `true`。相機角度以度為單位，拉伸高度為 40 點。範例將簡報儲存為 PPTX，並以兩倍預設尺寸將比較投影片渲染為 PNG。

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

左側的文字遵循 3D 方向；右側的文字保持平面且較易閱讀。兩個矩形皆保留相同的可見拉伸與 3D 方向。

![並排的 3D 矩形：左側文字遵循 3D 方向，右側保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 的影格。

請注意以下要點：

- 匯出的圖像與 PDF 並非互動式。匯出後觀眾無法旋轉物件。
- 最終外觀取決於相機、光線、材質、拉伸、填充與投影片縮放的組合。
- 若需檢視繼承或主題基礎的格式值，請閱讀 [有效圖形屬性](/slides/zh-hant/androidjava/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，會渲染出視覺結果，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式 3D 投影片嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 形狀與文字的 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面變成可由觀眾旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何不同？**

3D 模型是插入至簡報的獨立 3D 物件。3D 效果則是對一般 PowerPoint 圖形或文字套用的格式，包括旋轉、拉伸、斜角、照明與材質。本文僅討論 3D 效果。

**要讓 3D 形狀可見，需要哪些設定？**

最低需求是設定相機旋轉以及拉伸或深度。實務上，還會設定光線與材質，以便渲染出明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。對圖形本體使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)，對文字使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

**匯出為圖像、PDF、HTML 或影片影格時，會出現 3D 效果嗎？**

會。Aspose.Slides 於產生投影片圖像、PDF、HTML 以及影片轉換的影格時，會渲染 3D 效果。匯出的結果為渲染後的外觀，而非可編輯的 3D 物件。

**我能在繼承與主題設定套用後，讀取最終的 3D 值嗎？**

可以。使用在 [有效圖形屬性](/slides/zh-hant/androidjava/shape-effective-properties/) 中描述的有效格式 API，讀取最終的相機、光線、斜角與相關 3D 值。