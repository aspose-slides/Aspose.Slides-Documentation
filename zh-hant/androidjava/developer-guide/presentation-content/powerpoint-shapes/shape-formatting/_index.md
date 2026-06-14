---
title: 在 Android 上格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/androidjava/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 格式化接合樣式
- 漸層填滿
- 圖案填滿
- 圖片填滿
- 紋理填滿
- 單色填滿
- 形狀透明度
- 旋轉形狀
- 3D 磨角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完全掌控地為 PPT、PPTX 與 ODP 檔案設定填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以向投影片加入形狀。由於形狀是由線條組成，您可以透過修改或套用外框效果來格式化它們。同時，您也可以透過指定填滿設定來控制形狀內部的填充方式。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java 提供了介面與方法，讓您能使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明作法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [線條樣式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [虛線樣式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linedashstyle/)。
1. 設定形狀的線條顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形形狀的填滿顏色。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 套用格式至矩形的線條。
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // 設定矩形線條的顏色。
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The formatted lines in the presentation](formatted-lines.png)

## **格式化接合樣式**

以下為三種接合類型選項：

* 圓角 (Round)
* 斜角 (Miter)
* 斜面 (Bevel)

預設情況下，PowerPoint 在形狀角落以角度連接兩條線時，會使用 **Round** 設定。但若您繪製的形狀具有銳角，可能會較偏好 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Java 程式碼示範如何以 Miter、Bevel 與 Round 接合樣式建立三個矩形（如上圖所示）：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增三個矩形類型的自動形狀。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 為每個矩形形狀設定填滿顏色。
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // 設定線條寬度。
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 為每個矩形的線條設定顏色。
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // 設定接合樣式。
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 為每個矩形加入文字。
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **漸層填滿**

在 PowerPoint 中，漸層填滿是一種格式化選項，可讓您對形狀套用連續的顏色混合。例如，您可以使用兩種或以上的顏色，使其逐漸由一種顏色淡化為另一種顏色。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `add` 方法，依定義的位置加入兩個您偏好的顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何對橢圓套用漸層填滿效果：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增橢圓類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 設定漸層的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 新增兩個漸層停止點。
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The ellipse with gradient fill](gradient-fill.png)

## **圖案填滿**

在 PowerPoint 中，圖案填滿是一種格式化選項，讓您能將兩種顏色的設計（例如點、條紋、十字紋或格子）套用於形狀。您可以為圖案的前景與背景自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以將其套用於形狀以提升簡報的視覺吸引力。即使選取了預定義圖案，仍可自行指定確切的前景與背景顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖案填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中挑選圖案樣式。
1. 設定圖案的 [背景色彩](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [前景色彩](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何對矩形套用圖案填滿：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填滿類型為圖案。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 設定圖案樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 設定圖案的背景色與前景色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The rectangle with pattern fill](pattern-fill.png)

## **圖片填滿**

在 PowerPoint 中，圖片填滿是一種格式化選項，允許您在形狀內插入影像，實質上將影像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填滿：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填滿模式設定為 `Tile`（或其他您偏好的模式）。
1. 從欲使用的影像建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報儲存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，內容如下圖所示：

![The lotus picture](lotus.png)

以下 Java 程式碼示範如何以圖片填滿形狀：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填滿類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 設定圖片填滿模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 載入圖像並將其加入簡報資源。
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // 設定圖片。
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape with picture fill](picture-fill.png)

### **將圖片以圖塊方式作為紋理**

如果您想將平鋪的圖片作為紋理，並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturefillformat/) 類別的下列方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)：設定圖片填滿模式 — `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)：指定圖塊在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)：控制圖塊是水平翻轉、垂直翻轉或兩者皆翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)：設定圖塊相對於形狀原點的水平偏移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)：設定圖塊相對於形狀原點的垂直偏移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)：以百分比定義圖塊的水平縮放比例。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)：以百分比定義圖塊的垂直縮放比例。

以下程式碼範例示範如何新增一個具有平鋪圖片填滿的矩形形狀，並設定圖塊選項：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 新增矩形自動形狀。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定形狀的填滿類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 載入圖像並將其加入簡報資源。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將圖像指派給形狀。
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 設定圖片填滿模式與平鋪屬性。
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The tile options](tile-options.png)

## **單色填滿**

在 PowerPoint 中，單色填滿是一種格式化選項，會以單一、均勻的顏色填滿形狀。此純色背景不含任何漸層、紋理或圖案。

若要使用 Aspose.Slides 為形狀套用單色填滿，請依照下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指定您偏好的填滿顏色。
1. 將修改後的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何在 PowerPoint 投影片的矩形上套用單色填滿：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填滿類型為實色。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 設定填滿顏色。
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape with solid color fill](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用單色、漸層、圖片或紋理填滿時，亦可設定透明度以控制填滿的不透明程度。較高的透明度值會使形狀更為半透明，讓背景或底層物件部分可見。

Aspose.Slides 讓您透過調整填滿顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義帶有透明度的顏色（alpha 分量控制透明度）。
1. 儲存簡報。

以下 Java 程式碼示範如何對矩形套用透明填色：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增實心矩形自動形狀。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心形狀上新增透明矩形自動形狀。
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The transparent shape](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 讓您在 PowerPoint 簡報中旋轉形狀。此功能在需要特定對齊或設計需求時相當實用。

若要在投影片上旋轉形狀，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將形狀的旋轉屬性設定為所需的角度。
1. 儲存簡報。

以下 Java 程式碼示範如何將形狀旋轉 5 度：

```java
// 實例化表示簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將形狀旋轉 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **加入 3D 磨角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 屬性，為形狀加入 3D 磨角效果。

若要為形狀加入 3D 磨角效果，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 以定義磨角設定。
1. 儲存簡報。

以下 Java 程式碼示範如何為形狀套用 3D 磨角效果：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片中新增形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 設定形狀的 ThreeDFormat 屬性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 屬性，為形狀加入 3D 旋轉效果。

若要為形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片參考。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) 定義 3D 旋轉。
1. 儲存簡報。

以下 Java 程式碼示範如何為形狀套用 3D 旋轉效果：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，將 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslide/) 上所有含有版位的形狀的 位置、大小與格式恢復為預設設定：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重設投影片上每個在版面上具有版位的形狀。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

影響極小。嵌入的圖片與媒體佔據大部分檔案空間，而形狀的參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會增加額外大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性——填滿、線條與效果設定。若所有對應的值皆相同，則視為樣式相同，並在邏輯上將這些形狀分組，這樣可簡化稍後的樣式管理。

**我可以將自訂的形狀樣式集合儲存為獨立檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範本形狀存於範本投影片檔或 .POTX 範本檔。建立新簡報時，開啟該範本，克隆您需要的樣式形狀，並在需要的地方重新套用其格式。