---
title: 在 Java 中建立投影片的 3D 效果
linktitle: 3D 投影片
type: docs
weight: 232
url: /zh-hant/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 投影片
- 3D 旋轉
- 3D 深度
- 3D 擠出
- 3D 漸層
- 3D 文字
- PowerPoint
- 投影片
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides 為 PowerPoint 圖形和文字套用及呈現 3D 效果。設定相機、光源、材質、擠出、填色和 3D 文字。"
---
## **概觀**

Aspose.Slides for Java 能夠建立、編輯、保留和呈現類似 PowerPoint 的 3D 格式設定，可用於圖形和文字。本文討論的 3D 效果包括旋轉、擠出、倒角、光照、材質、漸層或圖片填色，以及 3D 文字。

{{% alert color="primary" %}}
本文關於 PowerPoint 圖形與文字的 3D 格式化效果，並不涉及插入或編輯獨立的 3D 模型檔案。當您將投影片匯出為影像、PDF 或 HTML 時，Aspose.Slides 會將這些 3D 效果呈現在匯出的 2D 輸出中。
{{% /alert %}}

## **3D 格式概念**

使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/).`getThreeDFormat()` 來對圖形套用 3D 格式。返回的格式物件控制該圖形的 3D 場景。

對文字，使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。此方法將 3D 格式套用於文字框，而非圖形本體。

以下是最重要的 API 成員：

| API 成員 | 控制項目 | 何時使用 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getCamera--) | 觀點、預設相機類型、旋轉、縮放與透視。 | 在 3D 空間中旋轉物件，或匹配 PowerPoint 的 3D 旋轉預設。 |
| [getLightRig](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getLightRig--) | 光源預設、方向與光線旋轉。 | 改變 3D 表面的高光與陰影呈現方式。 |
| [getMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getMaterial--) 和 [setMaterial](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 表面材質，例如平面、啞光、塑膠或金屬。 | 使相同幾何外觀更平坦、柔和、有光澤或金屬感。 |
| [getExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 和 [setExtrusionHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 圖形從正面向後延伸的距離。 | 將平面圖形轉換為可見厚度的 3D 物件。 |
| [getExtrusionColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 擠出側面的顏色。 | 使深度可見，或將側面顏色與正面填色協調。 |
| [getDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getDepth--) 和 [setDepth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 格式所使用的額外深度。 | 微調圖形或文字的深度，特別是與倒角與材質設定搭配使用時。 |
| [getBevelTop](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelTop--) 和 [getBevelBottom](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 正面與背面的提升或圓角邊緣。 | 為圖形加入柔化或模具化的邊緣，而非銳利的平面。 |
| [getContourColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#getContourWidth--), 和 [setContourWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 物件的輪廓線條。 | 在渲染結果中強調物件邊界。 |

## **建立 3D 圖形**

- 相機設定，因為預設的正視圖可能隱藏擠出效果。
- 光源設定，因為光照使各面與側面可見。
- 材質設定，因為表面影響光線的呈現方式。
- 擠出或深度設定，因為平面圖形需要厚度。

以下示例建立一個矩形，於正面加入文字，套用 3D 格式，將簡報另存為 PPTX，並將投影片渲染為 PNG 影像。

```java
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

渲染的投影片影像顯示矩形已變成厚實的 3D 方塊：

![渲染的藍色 3D 矩形，正面有白色 3D 文字](img_01_01.png)

## **使用相機旋轉圖形**

在 PowerPoint 中，3D 旋轉是透過「3‑D 旋轉」窗格設定。X、Y、Z 旋轉值對應於透過相機 API 設定的旋轉。

![PowerPoint 3‑D 旋轉窗格，已突顯 X、Y、Z 旋轉值](img_02_01.png)

在 Aspose.Slides 中，透過 `shape.getThreeDFormat()` 返回的 3D 格式設定相機類型與旋轉：

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

需要變更觀看者看到物件方式時使用相機。它不會改變投影片上 2D 圖形的幾何形狀，只會改變 PowerPoint 與 Aspose.Slides 渲染時使用的 3D 視點。

## **加入擠出與深度**

擠出透過將圖形向後延伸，使其看起來更厚實。PowerPoint 中的深度控制決定可見厚度，顏色控制決定側面的顏色。

![PowerPoint 深度控制對應到擠出顏色與擠出高度屬性](img_02_02.png)

設定擠出高度以決定厚度，並設定擠出顏色以決定側面顏色：

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

需要直接使用 PowerPoint 的深度值，或將深度與倒角、材質與文字效果結合時，請使用深度設定。在許多圖形情境下，擠出高度較為直觀，因為它直接表達可見的擠出量。

## **在 3D 效果中使用漸層或圖片填色**

3D 格式與圖形填色相互獨立。您可以對正面套用單色、漸層、圖案或圖片填色，同時使用相同的相機、光源、材質與擠出設定。

此示例對圖形使用漸層填色，並將側面的擠出顏色調暗：

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

渲染的 3D 矩形，藍至橙漸層填色與橙色擠出：

![渲染的 3D 矩形，藍至橙漸層填色與橙色擠出](img_02_03.png)

若改用圖片填色，先將影像加入簡報，然後指派給圖形填色：

```java
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
```

圖片顯示在正面，而擠出則以 3D 側面呈現：

![渲染的 3D 矩形，正面為照片填色且側面為橙色擠出](img_02_04.png)

## **將 3D 格式套用於文字**

圖形的 3D 格式影響圖形本體；文字的 3D 格式則影響文字框。這對於類似 WordArt 的效果很有用，因為字母本身需要擠出、材質、光照與相機設定。

以下示例建立帶圖案填色的文字，套用 WordArt 變形，並在 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/) 上配置 3D 設定：

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

渲染的 3D 文字，帶拱形 WordArt 變形、橙色圖案填色與深色擠出：

![渲染的 3D 文字，拱形 WordArt 變形、橙色圖案填色與深色擠出](img_02_05.png)

## **匯出與渲染行為**

Aspose.Slides 在儲存為 PPTX 等 PowerPoint 格式時會保留 3D 格式。當渲染或匯出為固定版面格式時，3D 場景會被光柵化或繪製為 2D 結果。這在您將投影片渲染為 [PNG](/slides/zh-hant/java/convert-powerpoint-to-png/)、匯出為 [PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、匯出為 [HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)，或產生用於 [video conversion](/slides/zh-hant/java/convert-powerpoint-to-video/) 的框格時皆會發生。

- 匯出的影像與 PDF 並非互動式。匯出後使用者無法旋轉物件。
- 最終外觀取決於相機、光源、材質、擠出、填色與投影片縮放的組合。
- 若需檢查繼承或主題的格式值，請參閱 [有效形狀屬性](/slides/zh-hant/java/shape-effective-properties/)。
- 某些輸出格式無法儲存可編輯的 PowerPoint 3D 格式。在這些格式中，僅會將視覺結果渲染出來，而非保留可編輯的 3D 設定。

## **FAQ**

**Aspose.Slides 能否建立互動式 3D 簡報？**

Aspose.Slides 會建立並呈現 PowerPoint 圖形與文字的 3D 效果。它不會讓匯出的影像、PDF 或 HTML 頁面成為可互動的 3D 場景供觀看者旋轉。在 PPTX 中，支援的 3D 格式仍可在 PowerPoint 中編輯。

**3D 模型與 3D 效果有何差異？**

3D 模型是插入簡報的獨立 3D 物件。3D 效果則是套用於一般 PowerPoint 圖形或文字的格式設定，如旋轉、擠出、倒角、光照與材質。本文僅討論 3D 效果。

**要呈現可見的 3D 圖形，需要哪些設定？**

最低需要設定相機旋轉，並設定擠出或深度。實務上，亦建議同時設定光源與材質，以便讓渲染出的面具有明顯的高光與陰影。

**我可以同時對圖形與文字套用 3D 效果嗎？**

可以。對圖形本體使用 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/).`getThreeDFormat()`，對文字則使用 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`。

**匯出為影像、PDF、HTML 或影片框格時，會出現 3D 效果嗎？**

會。Aspose.Slides 會在產生投影片影像、PDF、HTML 以及用於影片轉換的框格時渲染 3D 效果。匯出的檔案僅包含渲染後的外觀，而非可編輯的 3D 物件。

**在套用繼承與主題設定後，我能讀取最終的 3D 值嗎？**

能。請使用於 [有效形狀屬性](/slides/zh-hant/java/shape-effective-properties/) 中描述的有效格式 API，讀取最終的相機、光源、倒角與相關的 3D 值。