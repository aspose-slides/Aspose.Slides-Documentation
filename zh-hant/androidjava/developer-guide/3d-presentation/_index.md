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
- 3D 擠壓
- 3D 漸層
- 3D 文字
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 套用並渲染 PowerPoint 圖形與文字的 3D 效果。設定相機、光照、材質、擠壓、填色，以及 3D 文字。"
---
## **概觀**

Aspose.Slides for Android via Java 能夠建立、編輯、保留並渲染類似 PowerPoint 的 3D 格式化，適用於圖形和文字。本文介紹旋轉、擠壓、倒角、光照、材質、漸層或圖片填色以及 3D 文字等 3D 效果。

{{% alert color="primary" %}}
本文說明 PowerPoint 圖形與文字的 3D 格式化效果，並非插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為圖片、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果渲染成匯出的 2D 輸出。
{{% /alert %}}

## **3D 格式化概念**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 方法為圖形套用 3D 格式化。此方法會回傳 [IThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/)，負責控制該圖形的 3D 場景。

對於文字，請使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 方法。此方法會將 3D 格式化套用於文字框，而非圖形本體。

最重要的 API 成員如下：

| API 成員 | 控制項目 | 使用時機 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或符合 PowerPoint 的 3D 旋轉預設值。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 變更 3D 表面上高光與陰影的呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、霧面、塑膠或金屬。 | 讓相同的幾何形狀呈現更平坦、柔和、光亮或金屬的效果。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 圖形從前表面向後延伸的距離。 | 將平面圖形轉換為可見的厚實 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 擠壓側面的顏色。 | 使深度可見，或將側面顏色與前景填色協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式化使用的額外 3D 深度。 | 微調圖形或文字的深度，特別是與倒角與材質設定結合時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 前後表面的凸起或圓角邊緣。 | 加入柔化或成型的邊緣，取代銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓線。 | 在渲染結果中強調物件邊界。 |

## **建立 3D 圖形**

圖形在看起來真的具有 3D 效果之前，通常需要四種設定：

- 相機設定，因為預設的正面視角可能會遮蔽擠壓效果。
- 光源設定，因為光照讓各面與側面可辨識。
- 材質設定，因為表面會影響光線的呈現方式。
- 擠壓或深度設定，因為平面圖形需要厚度。

以下範例建立一個矩形、在其前表面加入文字、套用 3D 格式化，將簡報儲存為 PPTX，並將投影片渲染為 PNG 圖片。

```java
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

渲染後的投影片圖像顯示矩形成為厚實的 3D 方塊：

![已渲染的藍色 3D 矩形，前表面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3-D Rotation」面板設定。X、Y、Z 旋轉值對應於您透過相機 API 設定的旋轉。

![PowerPoint 3-D Rotation 面板，顯示 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 設定相機類型與旋轉：

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

當需要變更觀察者觀看物件的角度時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 以及 Aspose.Slides 渲染時使用的 3D 視點。

## **加入擠壓與深度**

擠壓會使圖形因向前表面後方延伸而看起來變厚。於 PowerPoint 中，深度控制設定此可見厚度，而顏色控制則設定側面的顏色。

![PowerPoint 深度控制對應至擠壓顏色與擠壓高度屬性](img_02_02.png)

使用 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 設定厚度，並使用 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 設定側面顏色：

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

當需要直接操作 PowerPoint 的深度值，或將深度與倒角、材質、文字效果結合時，請使用 [IThreeDFormat.setDepth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)。在多數圖形情況下，`setExtrusionHeight` 更直觀，因為它直接表示可見的擠壓高度。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式化與圖形填色互不相干。您可以對前表面套用純色、漸層、圖案或圖片填色，同時仍使用相同的相機、光源、材質與擠壓設定。

以下範例對圖形使用漸層填色，並將側面的擠壓顏色設為較深：

```java
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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

渲染結果保留前表面的漸層，且擠壓部分另行渲染：

![已渲染的 3D 矩形，藍至橙的漸層填色與橙色擠壓側面](img_02_03.png)

若要改用圖片填色，請先將影像加入簡報，再指派給圖形的填色：

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

圖片會渲染在前表面，擠壓則以 3D 側面表面呈現：

![已渲染的 3D 矩形，前表面為照片填色，側面為橙色擠壓](img_02_04.png)

## **將 3D 格式化套用至文字**

圖形的 3D 格式化會影響圖形本體；文字的 3D 格式化則影響文字框。這在類似 WordArt 的效果中很有用，因為字母本身需要擠壓、材質、光照與相機設定。

以下範例建立帶圖案填色的文字，套用 WordArt 變形，並在 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/) 上配置 3D 設定：

```java
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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

文字會以彎曲、擠壓的 3D 文字呈現：

![已渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填色與深色擠壓](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PowerPoint 格式（如 PPTX）時會保留 3D 格式化。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製成 2D 結果。這適用於將投影片渲染為 [PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/androidjava/convert-powerpoint-to-video/) 的影格時。

請留意以下要點：

- 匯出的圖像與 PDF 為靜態，使用者在匯出後無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠壓、填色與投影片縮放的組合。
- 若需檢查繼承或佈景主題的格式值，請參閱 [有效圖形屬性](/slides/zh-hant/androidjava/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式化。在這些格式中，僅會將視覺結果渲染出來，而非保留可編輯的 3D 設定。

## **常見問題**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會為圖形與文字建立並渲染 PowerPoint 的 3D 效果。但它不會使匯出為圖像、PDF 或 HTML 頁面的內容變成可讓觀眾旋轉的互動式 3D 場景。在 PPTX 中，若格式支援，3D 格式化仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式化，例如旋轉、擠壓、倒角、光照與材質。本文僅討論 3D 效果。

**要呈現可見的 3D 圖形需要哪些設定？**

至少須設定相機旋轉，並選擇擠壓或深度。實務上，還需設定光源與材質，以使渲染出的各面具有明顯的高光與陰影。

**我能將 3D 效果套用於圖形與文字嗎？**

可以。對圖形本體使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)，對文字使用 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)。

**匯出為圖像、PDF、HTML 或影片框格時會顯示 3D 效果嗎？**

會。Aspose.Slides 在產生投影片影像、PDF、HTML 以及用於影片轉換的框格時，都會渲染 3D 效果。匯出的結果僅包含已渲染好的外觀，而非可編輯的 3D 物件。

**我能在繼承與佈景主題設定套用後讀取最終的 3D 值嗎？**

可以。請使用在 [有效圖形屬性](/slides/zh-hant/androidjava/shape-effective-properties/) 中描述的有效格式化 API，讀取最終的相機、光源、倒角與相關 3D 值。