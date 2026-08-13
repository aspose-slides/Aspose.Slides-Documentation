---
title: 在 Android 上建立簡報的 3D 效果
linktitle: 3D 簡報
type: docs
weight: 232
url: /zh-hant/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Android 上套用並呈現 PowerPoint 圖形與文字的 3D 效果。可設定相機、光照、材質、擠出、填色與 3D 文字。"
---
## **概覽**

Aspose.Slides for Android via Java 可以建立、編輯、保留並呈現類似 PowerPoint 的 3D 格式設定，適用於圖形與文字。本文介紹如旋轉、擠出、斜角、光照、材質、漸層或圖片填色，以及 3D 文字等 3D 效果。

{{% alert color="info" %}}
本文討論的是 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。將投影片匯出為圖像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 方法對圖形套用 3D 格式化。該方法會傳回 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/)，用來控制該圖形的 3D 場景。

對於文字，請使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。此方法會將 3D 格式化套用到文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 視點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設值。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的顯示方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、霧面、塑料或金屬。 | 使相同的幾何形狀呈現更平坦、柔和、光亮或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 圖形從正面向後延伸的距離。 | 將平面圖形變成可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 擠出側面的顏色。 | 使深度可見，或將側面顏色與正面填色協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化所使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與斜角與材質設定一起使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面與背面之提升或圓角邊緣。 | 添加柔化或成形的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourColor--)、[getContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓線。 | 在渲染輸出中強調物件邊界。 |

## **建立 3D 圖形**

圖形通常需要四種設定才能呈現逼真的 3D 效果：

- 相機設定，因為預設的正面視圖可能隱藏擠出效果。
- 光源設定，因為光照讓各面與側面更易辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形，於正面加入文字，套用 3D 格式化，將簡報儲存為 PPTX，並將投影片渲染為 PNG 圖像。

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

渲染出的投影片影像顯示矩形為厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是在「3D 旋轉」面板中設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3-D 旋轉面板，已標示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 設定相機類型與旋轉：

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

當需要變更觀者觀看物件的角度時，使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 觀點。

## **加入擠出與深度**

擠出透過將圖形延伸到正面後方，使其呈現厚度。在 PowerPoint 中，深度控制決定此可見厚度，顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 設定側面顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

當需要直接使用 PowerPoint 的深度值，或將深度與斜角、材質與文字效果結合時，請使用 [IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)。在多數圖形情境中，`setExtrusionHeight` 更直觀，因為它直接表示可見的擠出厚度。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式化與圖形的填色互不相干。您可以在正面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與擠出設定。

此範例對圖形套用漸層填色，並將側面設定為較深的擠出顏色：

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

渲染結果保留正面的漸層，且分別渲染擠出側面：

![渲染的 3D 矩形，藍至橙漸層填色與橙色擠出側面](img_02_03.png)

若要改用圖片填色，先將影像加入簡報，再指派給圖形的填色：

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

圖片會渲染在正面，而擠出則以 3D 側面呈現：

![渲染的 3D 矩形，正面使用照片填色，側面為橙色擠出](img_02_04.png)

## **將 3D 格式化套用於文字**

圖形的 3D 格式化會影響圖形本體；文字的 3D 格式化則會影響文字框。這在類似 WordArt 的效果中很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下範例建立具有圖案填色的文字，套用 WordArt 變形，並於 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/) 設定 3D 參數：

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

文字會以彎曲、擠出的 3D 形態呈現：

![渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填色與深色擠出](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這在將投影片渲染為 [PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)，或產生 [video conversion](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 的影格時皆適用。

請注意以下要點：

- 匯出的圖像與 PDF 並非互動式，使用者在匯出後無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填色與投影片縮放的組合。
- 若需檢視繼承或主題基礎的格式值，請參閱 [effective shape properties](/slides/zh-hant/androidjava/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，會渲染出視覺結果，而非保留可編輯的 3D 設定。

## **常見問題**

### Aspose.Slides 能產生互動式 3D 簡報嗎？

Aspose.Slides 會為圖形與文字建立並渲染 PowerPoint 3D 效果。它不會讓匯出的圖像、PDF 或 HTML 頁面成為可由使用者旋轉的互動式 3D 場景。於 PPTX 中，只要格式支援，3D 格式化仍可在 PowerPoint 中編輯。

### 3D 模型與 3D 效果有何不同？

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式化，例如旋轉、擠出、斜角、光照與材質。本文討論的正是 3D 效果。

### 需要哪些設定才能產生可見的 3D 圖形？

至少必須設定相機旋轉，並設定擠出或深度。實務上，也建議設定光源與材質，讓渲染出的各面具備明顯的高光與陰影。

### 我可以將 3D 效果同時套用於圖形與文字嗎？

可以。對圖形本體使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)，對文字則使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

### 3D 效果在匯出為圖像、PDF、HTML 或影片影格時會出現嗎？

會。Aspose.Slides 於產生投影片圖像、PDF、HTML 以及影片轉換用的影格時，皆會渲染 3D 效果。匯出的結果僅包含渲染後的外觀，並非可編輯的 3D 物件。

### 我能在繼承與主題設定套用後讀取最終的 3D 值嗎？

可以。使用在 [Shape Effective Properties](/slides/zh-hant/androidjava/shape-effective-properties/) 中描述的有效格式化 API，即可讀取最終的相機、光源、斜角及相關的 3D 值。