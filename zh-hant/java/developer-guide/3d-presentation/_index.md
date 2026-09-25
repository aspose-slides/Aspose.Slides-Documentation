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
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 為 PowerPoint 圖形與文字套用和呈現 3D 效果。設定相機、光線、材質、擠出、填充與 3D 文字。"
---
## **概述**

Aspose.Slides for Java 可以建立、編輯、保留與呈現 PowerPoint 風格的 3D 格式，適用於圖形與文字。本文涵蓋 3D 效果，如旋轉、擠出、倒角、光線、材質、漸層或圖片填充，以及 3D 文字。

{{% alert color="info" title="注意" %}}
此文章說明的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getThreeDFormat--) 方法對圖形套用 3D 格式化。此方法會回傳 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/)，用來控制該圖形的 3D 場景。

對文字則使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法，這會對文字框套用 3D 格式化，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放和透視。 | 在 3D 空間中旋轉物件或套用 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向及光線旋轉。 | 改變 3D 表面上高光與陰影的顯示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、霧面、塑料或金屬。 | 讓相同的幾何形狀呈現較平坦、較柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 形狀從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 擠出側面的顏色。 | 使深度可見或將側面顏色與正面填充協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式使用的額外深度。 | 針對圖形或文字微調深度，特別是與倒角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前後面之上升或圓角邊緣。 | 加入柔和或模具化的邊緣，而不是銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形在看起來具有說服力的 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正視圖可能會隱藏擠出效果。
- 光線設定，因為光線讓各面與側面可被辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形、在正面加入文字，並套用 3D 格式化。相機旋轉值以度為單位，擠出高度為 100 點。此範例將投影片渲染為兩倍預設尺寸的 PNG 影像，並將簡報存為 PPTX。

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

渲染的投影片影像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是從「3-D Rotation」窗格設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 窗格，突出顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getCamera--) 取得相機。此範例建立一個矩形、選取正投影前視圖，並將 X、Y、Z 旋轉分別設定為 20、30、40 度。它在記憶體中設定圖形，未存檔：

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

需要變更觀者觀看物件的角度時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出透過在正面之後延伸形狀，使其看起來較厚。在 PowerPoint 中，深度控制決定此可見厚度，顏色控制決定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) 取得側面顏色。此範例為矩形設定 100 點的擠出、高紫色側面，並旋轉相機以顯示其厚度。它在記憶體中設定圖形，未存檔：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setDepth-double-) 方法設定 3D 圖形的深度。[setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 方法控制擠出效果的高度，如本範例所示。

## **使用漸層或圖片填充搭配 3D 效果**

3D 格式化與圖形填充互不相干。您可以對正面套用實色、漸層、圖案或圖片填充，同時使用相同的相機、光線、材質與擠出設定。

此範例將藍到橙的漸層套用至正面，並將深橙色套用至 150 點的擠出。漸層停點 0 與 100 分別為起始與結束。相機旋轉值以度為單位。投影片渲染為兩倍預設尺寸的 PNG：

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

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

渲染結果保留正面的漸層，同時分別渲染擠出側面：

![渲染的 3D 矩形，藍到橙的漸層填充與橙色擠出](img_02_03.png)

若改用圖片填充，先將圖片加入簡報並指派給圖形填充。此範例假設工作目錄中已有名為「image.jpg」的檔案。它將圖片伸展以填滿矩形、設定 150 點擠出，並以度為單位旋轉相機。它在記憶體中設定圖形，未儲存或渲染檔案：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

圖片在正面呈現，而擠出則以 3D 側面呈現：

![渲染的 3D 矩形，正面為照片填充，側面為橙色擠出](img_02_04.png)

## **將 3D 格式化套用至文字**

圖形的 3D 格式化影響圖形本體；文字的 3D 格式化則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光線與相機設定。

以下範例建立文字，使用橙白格線圖案、套用向上拱形，並透過 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 設定 3D 參數。擠出高度與深度以點為單位，光線旋轉以度為單位。隱藏圖形填充與輪廓，使僅顯示文字。範例將投影片渲染為兩倍預設尺寸的 PNG，並將簡報存為 PPTX：

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

文字以拱形、擠出的 3D 形式呈現：

![渲染的 3D 文字，拱形 WordArt 轉換、橙色圖案填充與深色擠出](img_02_05.png)

## **在 3D 圖形上保持文字平面顯示**

若要在保留圖形 3D 外觀的同時讓文字易於閱讀，請透過 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/#getTextFrameFormat--) 呼叫 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)。當值為 `true` 時，文字不會進入 3D 場景；為 `false` 時，文字會參與場景並遵循 3D 方向。

此設定不會移除圖形的 3D 格式化：其相機、光線、材質與擠出仍透過 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getThreeDFormat--) 設定。它也不同於普通旋轉。[IShape.setRotation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#setRotation-float-) 會在投影片平面內旋轉圖形，而 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 控制文字在其邊界框內的自訂旋轉。保持文字不進入 3D 場景不會重設上述任一角度。

以下自行完整的範例建立藍色矩形與文字，並在原圖旁複製一個。兩個圖形皆使用相同的 3D 格式化，僅文字設定不同：左側為 `false`，右側為 `true`。相機角度以度為單位，擠出高度為 40 點。範例將簡報存為 PPTX，並以兩倍預設尺寸渲染比較投影片為 PNG。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

左側文字遵循 3D 方向；右側文字保持平面且較易閱讀。兩個矩形保留相同的可見擠出與 3D 方向。

![並排的 3D 矩形：左側文字跟隨 3D 方向，右側文字保持平面](keep_text_flat.png)

## **匯出與渲染行為**

Aspose.Slides 在存為 PPTX 等 PowerPoint 格式時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在以下情況皆會發生：將投影片渲染為 [PNG](/slides/zh-hant/java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)，或產生用於 [影片轉換](/slides/zh-hant/java/convert-powerpoint-to-video/) 的幀。

請記住以下要點：

- 匯出的影像與 PDF 並非互動式的。匯出後觀者無法旋轉物件。
- 最終外觀取決於相機、光線、材質、擠出、填充與投影片縮放的組合。
- 若需檢查繼承或佈景主題設定的格式值，請閱讀 [有效圖形屬性](/slides/zh-hant/java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。於這些格式中，視覺結果會以渲染的方式呈現，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能建立互動式的 3D 簡報嗎？**

Aspose.Slides 會建立並渲染 PowerPoint 圖形與文字的 3D 效果。它不會讓匯出的影像、PDF 或 HTML 頁面成為可由觀者旋轉的互動式 3D 場景。在 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差別？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用在一般 PowerPoint 圖形或文字上的格式化，例如旋轉、擠出、倒角、光線與材質。本文僅討論 3D 效果。

**要呈現可見的 3D 圖形需要哪些設定？**

最低需要設定相機旋轉，並設定擠出或深度。實務上，通常也會設定光線與材質，以確保渲染出的面有清晰的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。對圖形本體使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getThreeDFormat--)；對文字則使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

**3D 效果在匯出為影像、PDF、HTML 或影片幀時會顯示嗎？**

會。Aspose.Slides 會在產生投影片影像、PDF、HTML 以及用於影片轉換的幀時渲染 3D 效果。匯出的輸出包含渲染後的外觀，而非可編輯的 3D 物件。

**我能在套用繼承與佈景主題後讀取最終的 3D 值嗎？**

可以。使用在 [圖形有效屬性](/slides/zh-hant/java/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光線、倒角與相關 3D 值。