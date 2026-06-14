---
title: 在 Java 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 格式化接合樣式
- 漸層填充
- 圖樣填充
- 圖片填充
- 紋理填充
- 實色填充
- 圖形透明度
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式化
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且完整控制地設定 PPT、PPTX 與 ODP 檔案的填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以將圖形新增至投影片。由於圖形由線條組成，您可以透過修改或套用效果來格式化其輪廓。此外，您也可以透過指定控制內部填充方式的設定來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java 提供介面與方法，讓您使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明了整個程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

下列程式碼示範如何格式化矩形 `AutoShape`：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填充顏色。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 套用矩形線條的格式化。
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

以下是三種接合類型的選項：

* Round（圓角）
* Miter（斜接）
* Bevel（斜切）

預設情況下，PowerPoint 在以角度（例如圖形的角落）連接兩條線時，使用 **Round** 設定。然而，如果您正在繪製具有銳角的圖形，可能會較偏好 **Miter** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Java 程式碼示範如何使用 Miter、Bevel 與 Round 接合類型設定建立上述圖中顯示的三個矩形：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增三個矩形類型的自動圖形。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形圖形的填充顏色。
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

    // 設定每個矩形線條的顏色。
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

## **漸層填充**

在 PowerPoint 中，漸層填充是一種格式化選項，可讓您將連續的顏色漸層套用到圖形。例如，您可以以兩種或多種顏色的方式，使一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 將漸層填充套用至圖形：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/igradientformat/) 介面所公開的 gradient stop 集合的 `add` 方法，加入兩個您偏好的顏色並設定位置。
1. 將修改後的簡報另存為 PPTX 檔案。

下列 Java 程式碼示範如何對橢圓套用漸層填充效果：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個橢圓類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 為橢圓套用漸層格式化。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 設定漸層方向。
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

## **圖樣填充**

在 PowerPoint 中，圖樣填充是一種格式化選項，讓您能將兩種顏色的圖案（例如點、條紋、交叉線或格子）套用到圖形。您可以為圖樣的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預設圖樣樣式，您可以將其套用至圖形以提升簡報的視覺效果。即使選取了預設圖樣，仍可指定其實際使用的顏色。

以下說明如何使用 Aspose.Slides 將圖樣填充套用至圖形：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Pattern`。
1. 從預設選項中選擇圖樣樣式。
1. 設定圖樣的 [Background Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/patternformat/#getBackColor--)。
1. 設定圖樣的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報另存為 PPTX 檔案。

下列 Java 程式碼示範如何對矩形套用圖樣填充：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為圖樣。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 設定圖樣樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 設定圖樣的背景色與前景色。
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

## **圖片填充**

在 PowerPoint 中，圖片填充是一種格式化選項，允許您在圖形內插入影像—實際上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 將圖片填充套用至圖形：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設定為 `Tile`（或其他您偏好的模式）。
1. 從您要使用的影像建立一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ippimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報另存為 PPTX 檔案。

假設我們有一個名為「lotus.png」的檔案，其圖片如下：

![The lotus picture](lotus.png)

下列 Java 程式碼示範如何使用圖片填充圖形：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填充類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 設定圖片填充模式。
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // 載入影像並將其加入簡報資源。
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

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片設為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 設定圖片填充模式—`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定平鋪在圖形內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 設定平鋪在水平方向上相對於圖形原點的位移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 設定平鋪在垂直方向上相對於圖形原點的位移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定義平鋪的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定義平鋪的垂直比例（百分比）。

下列程式碼範例示範如何新增一個具有平鋪圖片填充的矩形圖形，並設定平鋪選項：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動圖形。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定圖形的填充類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 載入影像並將其加入簡報資源。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 指派影像給圖形。
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 設定圖片填充模式與平鋪屬性。
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

## **實色填充**

在 PowerPoint 中，實色填充是一種格式化選項，可將圖形填滿單一、均勻的顏色。此純色背景不含任何漸層、紋理或圖樣。

若要使用 Aspose.Slides 將實色填充套用至圖形，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指定您偏好的填充顏色。
1. 將修改後的簡報另存為 PPTX 檔案。

下列 Java 程式碼示範如何在 PowerPoint 投影片的矩形上套用實色填充：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為實色。
    shape.getFillFormat().setFillType(FillType.Solid);

    // 設定填充顏色。
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

在 PowerPoint 中，當您對圖形套用實色、漸層、圖片或紋理填充時，也可以設定透明度，以控制填充的看透程度。較高的透明度值會讓圖形更透明，讓背景或底層物件部分可見。

Aspose.Slides 讓您透過調整填充顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具透明度的顏色（alpha 成分控制透明度）。
1. 儲存簡報。

下列 Java 程式碼示範如何為矩形套用透明填充顏色：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個實心矩形自動圖形。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心圖形上方新增一個透明矩形自動圖形。
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

## **旋轉圖形**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

要在投影片上旋轉圖形，請依以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 將圖形的旋轉屬性設定為所需角度。
1. 儲存簡報。

下列 Java 程式碼示範如何將圖形旋轉 5 度：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 將圖形旋轉 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **新增 3D 斜角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 屬性，為圖形加入 3D 斜角效果。

要為圖形新增 3D 斜角效果，請依以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

下列 Java 程式碼顯示如何為圖形套用 3D 斜角效果：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // 設定圖形的 ThreeDFormat 屬性。
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // 將簡報另存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/threedformat/) 屬性，為圖形加入 3D 旋轉效果。

要為圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參考。
1. 在投影片上新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilightrig/#setLightType-int-) 來定義 3D 旋轉。
1. 儲存簡報。

下列 Java 程式碼示範如何為圖形套用 3D 旋轉效果：

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

    // 將簡報另存為 PPTX 檔案。
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The 3D rotation effect](3D-rotation-effect.png)

## **重設格式化**

以下 Java 程式碼示範如何重設投影片的格式，並將所有在 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/) 上具有佔位符的圖形之位置、大小與格式恢復為預設設定：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重設投影片上在版面配置中具有佔位符的每個圖形。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**  

**圖形格式化會影響最終簡報檔案大小嗎？**  

影響極小。嵌入的影像與多媒體佔用了大部分檔案空間，而圖形參數（如顏色、效果與漸層）以中繼資料形式儲存，幾乎不會額外增加檔案大小。

**如何偵測投影片上格式相同的圖形，以便將它們分組？**  

比對每個圖形的關鍵格式屬性——填充、線條與效果設定。若所有對應的值皆相同，即可視為樣式相同，並在邏輯上將這些圖形分組，這樣可簡化後續的樣式管理。

**我可以將一組自訂圖形樣式儲存為獨立檔案，以便在其他簡報中重複使用嗎？**  

可以。將具有所需樣式的範例圖形儲存於模板投影片或 .POTX 模板檔案中。建立新簡報時，開啟該模板，複製所需的已樣式化圖形，並在需要的地方重新套用其格式。