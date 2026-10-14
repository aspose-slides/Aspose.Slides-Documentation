---
title: 在 Java 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 素描效果
- 圖形線條素描
- 格式化連接樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 圖形透明度
- 黑白圖形呈現
- 灰階圖形呈現
- 旋轉圖形
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides 格式化 PowerPoint 圖形——精確且全面地設定 PPT、PPTX 與 ODP 檔案的填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中，您可以在投影片上加入圖形。由於圖形由線條組成，您可以透過修改或套用效果於其輪廓來格式化它們。此外，您也可以透過指定設定來控制圖形內部的填充方式，從而格式化圖形。

![PowerPoint 中的圖形格式化](format-shape-powerpoint.png)

Aspose.Slides for Java 提供介面與方法，讓您可使用 PowerPoint 中相同的選項來格式化圖形。

## **格式線條**

使用 Aspose.Slides，您可以為圖形指定自訂的線條樣式。以下步驟概述了程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 設定圖形的 [line style](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)。
1. 設定圖形的線條顏色。
1. 將已修改的簡報儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 設定矩形圖形的填充顏色。
    shape.getFillFormat().setFillType(FillType.NoFill);

    // 為矩形的線條套用格式設定。
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

![簡報中格式化的線條](formatted-lines.png)

## **套用素描效果於圖形線條**

素描效果會讓圖形線條看起來像手繪。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 取得線條設定，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) 取得素描設定，並使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 列舉中選取值。

以下 Java 程式碼展示如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 移除效果：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 取得圖形的線條格式與其素描格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 套用素描效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 讀取直接指派給圖形的素描效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除素描效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

由 [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) 回傳的值代表直接指派給圖形的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/)，取得 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/)，並讀取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/)。有效值反映了解決繼承後實際套用的格式：

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

## **格式連接樣式**

以下是三種連接類型選項：

* Round
* Miter
* Bevel

預設情況下，PowerPoint 在以角度連接兩條線（例如圖形的角落）時，使用 **Round** 設定。然而，如果您繪製的圖形具有尖銳角度，可能會偏好 **Miter** 選項。

![簡報中的連接樣式](join-style-powerpoint.png)

以下 Java 程式碼示範如何使用 Miter、Bevel 和 Round 連接類型設定建立上述圖示中的三個矩形：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增三個類型為 Rectangle 的自動圖形。
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

    // 設定連接樣式。
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // 為每個矩形添加文字。
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

在 PowerPoint 中，漸層填色是一種格式化選項，可讓您將連續的顏色漸變套用到圖形。例如，您可以以漸變方式套用兩種或多種顏色，使一種顏色逐漸淡出另一種顏色。

以下說明如何使用 Aspose.Slides 對圖形套用漸層填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) 介面所公開的漸層停止集合的 `add` 方法，加入兩個首選顏色並指定位置。
1. 將已修改的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何對橢圓套用漸層填色效果：

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Ellipse 的自動圖形。
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

![具有漸層填色的橢圓](gradient-fill.png)

如果漸層在匯出影像中的顯示與在 PowerPoint 中不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改簡報中儲存的漸層填色的情況下選擇渲染樣式。

## **圖案填色**

在 PowerPoint 中，圖案填色是一種格式化選項，允許您將兩色設計（例如點、條紋、交叉陰影或格子）套用到圖形。您可以為圖案的前景與背景選擇自訂顏色。

Aspose.Slides 提供超過 45 種預定義圖案樣式，您可以套用於圖形以增強簡報的視覺效果。即使選取了預定義圖案，仍可指定確切的顏色。

以下說明如何使用 Aspose.Slides 對圖形套用圖案填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖案樣式。
1. 設定圖案的 [背景顏色](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--)。
1. 設定圖案的 [前景顏色](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--)。
1. 將已修改的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何對矩形套用圖案填色：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的自動圖形。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為 Pattern。
    shape.getFillFormat().setFillType(FillType.Pattern);

    // 設定圖案樣式。
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // 設定圖案的背景顏色與前景顏色。
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // 將 PPTX 檔案儲存至磁碟。
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

在 PowerPoint 中，圖片填色是一種格式化選項，允許您在圖形內插入影像，實際上將影像作為圖形的背景。

以下說明如何使用 Aspose.Slides 對圖形套用圖片填色：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填色模式設為 `Tile`（或其他偏好模式）。
1. 從欲使用的影像建立一個 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 物件。
1. 將影像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將已修改的簡報儲存為 PPTX 檔案。

以下為 "lotus.png" 檔案的示例圖片：

![蓮花圖片](lotus.png)

以下 Java 程式碼示範如何以圖片填滿圖形：

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的自動圖形。
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

![具有圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪圖片作為紋理並自訂平鋪行為，可使用 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): 設定圖片填色模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): 指定圖形內平鋪的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): 控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): 設定平鋪相對於圖形原點的水平位移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): 設定平鋪相對於圖形原點的垂直位移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): 定義平鋪的水平縮放百分比。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): 定義平鋪的垂直縮放百分比。

以下程式碼示範如何加入具有平鋪圖片填色的矩形並設定平鋪選項：

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動圖形。
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

![平鋪選項](tile-options.png)

## **純色填色**

在 PowerPoint 中，純色填色是一種格式化選項，會以單一均勻的顏色填滿圖形。此背景顏色不包含任何漸層、紋理或圖案。

要使用 Aspose.Slides 為圖形套用純色填色，請執行以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將圖形的 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 設為 `Solid`。
1. 為圖形指派您偏好的填色。
1. 將已修改的簡報儲存為 PPTX 檔案。

以下 Java 程式碼示範如何對簡報投影片中的矩形套用純色填色：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的自動圖形。
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

![具有純色填色的圖形](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對圖形套用純色、漸層、圖片或紋理填色時，也可設定透明度以控制填色的不透明程度。較高的透明度會使圖形更透，使背景或底層物件部分可見。

Aspose.Slides 允許您透過調整用於填色的顏色的 alpha 值來設定透明度。以下說明如何操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將 [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義具有透明度的顏色（alpha 成分控制透明度）。
1. 儲存簡報。

以下 Java 程式碼示範如何對矩形套用透明填色：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![透明的圖形](shape-transparency.png)

## **旋轉圖形**

Aspose.Slides 讓您可在 PowerPoint 簡報中旋轉圖形。這在需要特定對齊或設計需求的視覺元素定位時相當有用。

要在投影片上旋轉圖形，請依下列步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 將圖形的旋轉屬性設定為所需角度。
1. 儲存簡報。

以下 Java 程式碼示範如何將圖形旋轉 5 度：

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個類型為 Rectangle 的自動圖形。
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

![圖形的旋轉](shape-rotation.png)

## **加入 3D 斜角效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 屬性，為圖形套用 3D 斜角效果。

要為圖形加入 3D 斜角效果，請依下列步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 設定圖形的 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 以定義斜角設定。
1. 儲存簡報。

以下 Java 程式碼示範如何對圖形套用 3D 斜角效果：

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // 將簡報儲存為 PPTX 檔案。
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 斜角效果](3D-bevel-effect.png)

## **加入 3D 旋轉效果**

Aspose.Slides 允許您透過設定其 [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) 屬性，為圖形套用 3D 旋轉效果。

要對圖形套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 加到投影片中。
1. 使用 [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) 定義 3D 旋轉。
1. 儲存簡報。

以下 Java 程式碼示範如何對圖形套用 3D 旋轉效果：

```java
import com.aspose.slides.*;

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

![3D 旋轉效果](3D-rotation-effect.png)

## **控制圖形的黑白呈現**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 方法指定在以黑白模式檢視或處理簡報時，單一圖形的呈現方式。它本身不會啟用黑白顯示，也不會在正常色彩模式下變更圖形的填色、線條或其他格式設定。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) 類別中的值來選取所需行為。例如，`Automatic` 讓呈現應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 只使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保留正常著色，`Hidden` 在黑白模式下隱藏圖形，`NotDefined` 表示未指派圖形層級的模式。

以下 Java 程式碼建立一個有色圖形，並在黑白顯示模式下使其呈現為灰色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // 在彩色模式下保留橙色填充，但在黑白模式下將圖形呈現為灰色。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常色彩模式下，矩形保留橙色填色；在黑白顯示工作流程中，因模式設定為 `Gray`，因此使用灰階顏色。這讓您在保留全彩投影片的同時，為列印、預覽或其他尊重簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) 上所有佔位符圖形的位置、大小與格式恢復為預設設定：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重設投影片上每個在版面配置中具有占位符的圖形。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

只有極小的影響。嵌入的影像與媒體佔用大部分檔案空間，而顏色、效果與漸層等圖形參數僅以中繼資料儲存，幾乎不會增加額外大小。

**如何偵測投影片上共享相同格式的圖形，以便將它們分組？**

比較每個圖形的關鍵格式屬性——填色、線條與效果設定。若所有對應值相同，則視為相同樣式，並可在邏輯上將這些圖形分組，從而簡化後續的樣式管理。

**我可以將一組自訂的圖形樣式儲存為單獨的檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範例圖形存放在模板投影片或 .POTX 模板檔中。建立新簡報時，開啟該模板，複製所需的樣式圖形，並在需要的地方重新套用其格式。