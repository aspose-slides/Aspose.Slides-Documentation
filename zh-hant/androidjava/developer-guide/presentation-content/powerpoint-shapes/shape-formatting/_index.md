---
title: 在 Android 上格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/androidjava/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填充
- 圖樣填充
- 圖片填充
- 紋理填充
- 純色填充
- 形狀透明度
- 黑白形狀呈現
- 灰階形狀呈現
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習如何在 Android 上使用 Aspose.Slides 格式化 PowerPoint 形狀——精準且完整控制地為 PPT、PPTX 與 ODP 檔案設定填充、線條與效果樣式。"
---
## **簡介**

在 PowerPoint，您可以在投影片上加入形狀。由於形狀由線條組成，您可以透過修改或套用效果於輪廓來格式化它們。此外，您也可以透過指定設定以控制內部的填充方式來格式化形狀。

![格式化形狀‑PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java 提供介面與方法，讓您使用與 PowerPoint 相同的選項來格式化形狀。

## **格式化線條**

使用 Aspose.Slides，您可以為形狀指定自訂的線條樣式。以下步驟說明了操作程序：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 設定形狀的 [line style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linestyle/)。
1. 設定線寬。
1. 設定線條的 [dash style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linedashstyle/)。
1. 設定形狀的線色。
1. 將修改後的投影片儲存為 PPTX 檔案。

以下程式碼示範如何格式化矩形 `AutoShape`：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // 移除矩形形狀的填充，使僅顯示其線條。
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

![投影片中格式化的線條](formatted-lines.png)

## **套用草圖效果於形狀線條**

草圖效果會讓形狀線條看起來像手繪。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/) 取得線條設定，使用 [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformat/) 取得草圖設定，並使用 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformat/) 從 [LineSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 列舉中選取值。

以下 Java 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 效果、讀取明確指派的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/linesketchtype/) 取消效果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // 存取形狀的線條格式及其草圖格式。
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // 套用草圖效果。
    sketchFormat.setSketchType(LineSketchType.Curved);

    // 讀取直接指派給形狀的草圖效果。
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // 移除草圖效果。
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

由 [ISketchFormat.getSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformat/) 回傳的值代表直接指派給形狀的設定。如果線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformat/)，存取 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformateffectivedata/)，並讀取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isketchformateffectivedata/)。有效值反映在繼承解析後實際套用的格式：

```java
import com.aspose.slides.*;

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
* 斜角
* 斜面

預設情況下，PowerPoint 在以角度（例如形狀角落）連接兩條線時，會使用 **Round** 設定。然而，若您繪製具有銳利角度的形狀，可能會偏好 **Miter** 選項。

![投影片中的接合樣式](join-style-powerpoint.png)

以下 Java 程式碼示範了如上圖所示的三個矩形分別使用 Miter、Bevel、Round 接合樣式建立的方式：

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增三個矩形類型的自動形狀。
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 設定每個矩形形狀的填充顏色。
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

在 PowerPoint 中，漸層填充是一種格式化選項，可讓您對形狀套用連續的顏色混合。例如，您可以使用兩種或以上的顏色，以一種逐漸淡入另一種的方式進行填充。

以下說明如何使用 Aspose.Slides 為形狀套用漸層填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Gradient`。
1. 使用 [IGradientFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igradientformat/) 介面所提供的漸層停止集合的 `add` 方法，依定義的位置加入您偏好的兩種顏色。
1. 將修改後的投影片儲存為 PPTX 檔案。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個橢圓類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // 對橢圓套用漸層格式化。
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

![具有漸層填充的橢圓](gradient-fill.png)

## **圖樣填充**

在 PowerPoint 中，圖樣填充是一種格式化選項，讓您對形狀套用兩色設計（例如點、條紋、交叉陰影或格子）。您可為圖樣的前景與背景自訂顏色。

Aspose.Slides 提供超過 45 種預定義的圖樣樣式，您可以套用於形狀以提升簡報的視覺效果。即使選擇了預定義圖樣，仍可自行指定其精確的前景與背景顏色。

以下說明如何使用 Aspose.Slides 為形狀套用圖樣填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Pattern`。
1. 從預定義選項中選取圖樣樣式。
1. 設定圖樣的 [Background Color]。
1. 設定圖樣的 [Foreground Color]。
1. 將修改後的投影片儲存為 PPTX 檔案。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

![具有圖樣填充的矩形](pattern-fill.png)

## **圖片填充**

在 PowerPoint 中，圖片填充是一種格式化選項，可讓您在形狀內插入圖像，實際上是將圖像作為形狀的背景。

以下說明如何使用 Aspose.Slides 為形狀套用圖片填充：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Picture`。
1. 將圖片填充模式設為 `Tile`（或其他喜好的模式）。
1. 從欲使用的圖像建立 [IPPImage] 物件。
1. 將圖像傳遞給 `ISlidesPicture.setImage` 方法。
1. 將修改後的投影片儲存為 PPTX 檔案。

假設我們有一個名為 "lotus.png" 的檔案，內容如下圖所示：

![蓮花圖片](lotus.png)

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

![具有圖片填充的形狀](picture-fill.png)

### **將圖片平鋪為紋理**

如果您想將平鋪的圖片設定為紋理並自訂平鋪行為，可以使用 [IPictureFillFormat] 介面與 [PictureFillFormat] 類別的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 設定圖片填充模式，可為 `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) 指定圖塊在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) 控制圖塊是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) 設定圖塊相對於形狀原點的水平偏移（點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) 設定圖塊相對於形狀原點的垂直偏移（點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) 定義圖塊的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) 定義圖塊的垂直比例（百分比）。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 新增一個矩形自動形狀。
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // 設定形狀的填充類型為圖片。
    shape.getFillFormat().setFillType(FillType.Picture);

    // 載入影像並將其加入簡報資源。
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 指定影像給形狀。
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

## **純色填充**

在 PowerPoint 中，純色填充是一種格式化選項，會以單一均勻的顏色填滿形狀。此純色背景不含漸層、紋理或圖樣。

以下說明使用 Aspose.Slides 為形狀套用純色填充的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 為形狀指派您偏好的填充顏色。
1. 將修改後的投影片儲存為 PPTX 檔案。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 設定填充類型為實心。
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

![具有純色填充的形狀](solid-color-fill.png)

## **設定透明度**

在 PowerPoint 中，當您對形狀套用純色、漸層、圖片或紋理填充時，也可以設定透明度以控制填充的不透明度。較高的透明度值會使形狀更透，讓背景或底層物件部分可見。

Aspose.Slides 透過調整用於填充的顏色之 alpha 值來設定透明度。操作步驟如下：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 將形狀的 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/) 設為 `Solid`。
1. 使用 `Color` 定義帶有透明度的顏色（`alpha` 成分控制透明度）。
1. 儲存簡報。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增實心矩形自動形狀。
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 在實心形狀上方新增透明矩形自動形狀。
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

![透明形狀](shape-transparency.png)

## **旋轉形狀**

Aspose.Slides 允許您在 PowerPoint 簡報中旋轉形狀。這在以特定對齊或設計需求定位視覺元素時相當有用。

要在投影片上旋轉形狀，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 設定形狀的 rotation 屬性為所需角度。
1. 儲存簡報。

```java
import com.aspose.slides.*;

// 實例化代表簡報檔案的 Presentation 類別。
Presentation presentation = new Presentation();
try {
    // 取得第一張投影片。
    ISlide slide = presentation.getSlides().get_Item(0);

    // 新增一個矩形類型的自動形狀。
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

![形狀旋轉](shape-rotation.png)

## **新增 3D斜角效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat] 屬性來套用 3D 斜角效果。

要為形狀新增 3D 斜角效果，請遵循以下步驟：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 設定形狀的 [ThreeDFormat] 以定義斜角設定。
1. 儲存簡報。

```java
import com.aspose.slides.*;
import java.awt.Color;

// 建立 Presentation 類別的實例。
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 在投影片上新增形狀。
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

    // Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 斜角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

Aspose.Slides 允許您透過設定形狀的 [ThreeDFormat] 屬性來套用 3D 旋轉效果。

要對形狀套用 3D 旋轉：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 將 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 加入投影片。
1. 使用 [setCameraType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icamera/#setCameraType-int-) 與 [setLightType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) 定義 3D 旋轉。
1. 儲存簡報。

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

## **控制形狀的黑白顯示**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 方法指定在以黑白模式檢視或處理簡報時，單一形狀的呈現方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下更改形狀的填充、線條或其他格式設定。

使用來自 [BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/blackwhitemode/) 類別的值來選取所需的行為。例如，`Automatic` 讓渲染應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰色，`BlackWhite` 只使用黑白，`Black` 與 `White` 強制單色，`Color` 保留正常顏色，`Hidden` 在黑白模式下隱藏形狀。`NotDefined` 表示未指定任何形狀層級的模式。

以下 Java 程式碼建立一個彩色形狀，並在黑白顯示模式下使其呈現灰色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // 保留橙色填充於彩色模式，但在黑白模式下以灰色呈現形狀。
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保留橙色填充。在黑白顯示的工作流程中，因其模式設為 `Gray`，因此使用灰色。這讓您在保留全彩投影片的同時，為列印、預覽或其他遵循黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

以下 Java 程式碼示範如何重設投影片的格式，並將 [LayoutSlide] 上所有帶有佔位符的形狀的位置、大小與格式恢復為預設設定：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 重設投影片上在版面配置中具有佔位符的每個形狀。
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終簡報檔案大小嗎？**

只會有極小的影響。嵌入的圖像與媒體會佔據大部分檔案空間，而形狀的參數如顏色、效果與漸層僅以中繼資料儲存，幾乎不會額外增加檔案大小。

**如何偵測投影片上具有相同格式的形狀以便將它們分組？**

比較每個形狀的關鍵格式屬性──填充、線條與效果設定。若所有對應值相同，即視為樣式相同，並在邏輯上將這些形狀分組，這樣可簡化後續的樣式管理。

**我能將一組自訂形狀樣式儲存至其他檔案，以便在其他簡報中重複使用嗎？**

可以。將帶有所需樣式的範本形狀存於樣板投影片或 .POTX 樣板檔。建立新簡報時，開啟樣板，複製需要的樣式形狀，並在需要的地方重新套用其格式。