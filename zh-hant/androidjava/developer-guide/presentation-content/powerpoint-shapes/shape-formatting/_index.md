---
title: 在 Android 上格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/androidjava/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 素描效果
- 圖形線條素描
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上使用 Aspose.Slides 格式化 PowerPoint 圖形—精確且完整控制地設定 PPT、PPTX 與 ODP 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片中加入圖形。由於圖形是由線條組成，您可以透過修改或套用效果來格式化其輪廓。另外，您也可以透過設定控制圖形內部的填滿方式來格式化圖形。

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java 提供介面與方法，讓您能使用 PowerPoint 中相同的選項來格式化圖形。

## **格式化線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟說明此程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linestyle/)。
1. 設定線條寬度。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將修改後的簡報存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填充顏色。
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

## **套用草圖效果於圖形線條**

草圖效果會讓圖形線條看起來像手繪。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 取得線條設定，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformat/) 取得草圖設定，並使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 列舉中選取值。

以下 Java 程式碼顯示如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 移除效果：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 取得圖形的線條格式與其草圖格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 套用草圖效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 讀取直接指派給圖形的草圖效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除草圖效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

由 [ISketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformat/) 回傳的值代表直接指派給圖形的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformat/)，存取 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformateffectivedata/)，並讀取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformateffectivedata/)。此有效值反映經過繼承解析後實際套用的格式：

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式化接合樣式**

以下是三種接合類型選項：

* 圓形
* 斜接
* 斜角

預設情況下，PowerPoint 在角度（例如圖形的角落）處連接兩條線時，使用 **圓形** 設定。但是，若您繪製的圖形具有銳角，可能會較喜歡 **斜接** 選項。

![The join style in the presentation](join-style-powerpoint.png)

以下 Java 程式碼示範如何使用斜接、斜角與圓形接合樣式建立上圖所示的三個矩形：

```java
    // 實例化代表簡報檔案的 Presentation 類別。
    Presentation presentation = new Presentation();
    try {
        // 取得第一張投影片。
        ISlide slide = presentation.getSlides().get_Item(0);

        // 加入三個矩形類型的自動圖形。
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

## **漸層填色**

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您對圖形套用連續的顏色混合。例如，您可以使用兩種或多種顏色，使其中一種顏色逐漸淡入另一種顏色。

以下說明如何使用 Aspose.Slides 為圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Gradient`。
1. 使用由 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igradientformat/) 介面公開的漸層停止集合的 `add` 方法，加入您偏好的兩種顏色及其位置。
1. 將修改後的簡報存為 PPTX 檔案。

以下 Java 程式碼示範如何對橢圓套用漸層填色效果：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個橢圓類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 對橢圓套用漸層格式。
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // 設定漸層的方向。
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // 加入兩個漸層停止點。
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

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，可讓您對圖形套用雙色圖案─如點、條紋、交叉或格子─。您可以為圖案的前景色與背景色自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可套用於圖形以提升簡報的視覺效果。即使選取了預定義圖案，仍可指定其使用的確切顏色。

以下說明如何使用 Aspose.Slides 為圖形套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [Background Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [Foreground Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/patternformat/#getForeColor--)。
1. 將修改後的簡報存為 PPTX 檔案。

以下 Java 程式碼示範如何對矩形套用圖案填色：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
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

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入影像──實際上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 為圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設定為 `Tile`（或其他您偏好的模式）。
1. 從欲使用的影像建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的簡報存為 PPTX 檔案。

以下為「lotus.png」檔案的圖片示例：

![The lotus picture](lotus.png)

以下 Java 程式碼示範如何以圖片填滿圖形：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 設定填充類型為 Picture。
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

如果您想將平鋪圖片作為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 設定圖片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定圖形內平鋪圖塊的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制圖塊是水平翻轉、垂直翻轉或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 設定圖塊相對於圖形原點的水平偏移（單位為點）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 設定圖塊相對於圖形原點的垂直偏移（單位為點）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定義圖塊的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定義圖塊的垂直比例（百分比）。

以下程式碼範例顯示如何加入一個使用平鋪圖片填色的矩形，並設定平鋪選項：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 加入一個矩形自動圖形。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定圖形的填充類型為 Picture。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 載入影像並將其加入簡報資源。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 將影像指派給圖形。
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

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，會以單一均勻顏色填滿圖形。此純色背景不包含任何漸層、紋理或圖案。

要使用 Aspose.Slides 為圖形套用純色填色，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指定您偏好的填色。
1. 將修改後的簡報存為 PPTX 檔案。

以下 Java 程式碼示範如何在 PowerPoint 投影片中的矩形套用純色填色：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Solid。
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

在 PowerPoint 中，當您為圖形套用純色、漸層、圖片或紋理填色時，也可以設定透明度，以控制填色的透明程度。較高的透明度值會使圖形更透明，讓背景或底層物件部分可見。

Aspose.Slides 讓您透過調整填色所使用顏色的 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具有透明度的顏色（alpha 元件控制透明度）。
1. 儲存簡報。

以下 Java 程式碼示範如何為矩形套用透明填色：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個實心矩形自動圖形。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心圖形上加入一個透明矩形自動圖形。
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

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求時相當有用。

要在投影片上旋轉圖形，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 將圖形的 rotation 屬性設定為目標角度。
1. 儲存簡報。

以下 Java 程式碼示範如何將圖形旋轉 5 度：

```java
// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 加入一個矩形類型的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 旋轉圖形 5 度。
    shape.setRotation(5);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The shape rotation](shape-rotation.png)

## **加入 3D 斜角效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 屬性，為圖形加入 3D 斜角效果。

要為圖形加入 3D 斜角效果，請依以下步驟操作：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 Java 程式碼說明如何為圖形套用 3D 斜角效果：

```java
// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片中加入圖形。
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

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The 3D bevel effect](3D-bevel-effect.png)

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/threedformat/) 屬性，為圖形加入 3D 旋轉效果。

要為圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的執行個體。
1. 依索引取得投影片的參照。
1. 在投影片中加入 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/)。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) 定義 3D 旋轉。
1. 儲存簡報。

以下 Java 程式碼示範如何為圖形套用 3D 旋轉效果：

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

以下 Java 程式碼示範如何重設投影片的格式，並將其佔位符上所有圖形的位罝、大小與格式復原為 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslide/) 的預設設定：

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重置投影片上在版面上具有占位符的每個圖形。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**圖形格式化會影響最終簡報檔案大小嗎？**

影響很小。嵌入的圖像與媒體佔用了大部分檔案空間，而圖形的顏色、效果與漸層等參數僅以中繼資料形式儲存，幾乎不會增加額外大小。

**我該如何偵測投影片上具有相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性──填色、線條與效果設定。若所有相應值相符，即可視為樣式相同，並在邏輯上將這些圖形分組，這樣可以簡化後續的樣式管理。

**我能否將一組自訂圖形樣式儲存到單獨的檔案，以便在其他簡報中重複使用？**

可以。將帶有所需樣式的樣本圖形存入範本投影片或 .POTX 範本檔案。建立新簡報時，開啟該範本，復制您需要的已樣式化圖形，然後在需要的地方重新套用其格式。