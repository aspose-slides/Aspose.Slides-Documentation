---
title: 在 Java 中格式化 PowerPoint 形狀
linktitle: 形狀格式化
type: docs
weight: 20
url: /zh-hant/java/shape-formatting/
keywords:
- 格式化形狀
- 格式化線條
- 草圖效果
- 草圖形狀線條
- 格式化接合樣式
- 漸層填色
- 圖案填色
- 圖片填色
- 紋理填色
- 純色填色
- 形狀透明度
- 黑白形狀渲染
- 灰階形狀渲染
- 旋轉形狀
- 3D 斜角效果
- 3D 旋轉效果
- 重設格式
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Java 中使用 Aspose.Slides 格式化 PowerPoint 形狀——精確且完全掌控地為 PPT 與 PPTX 檔案設定填色、線條與效果樣式。"
---
## **介紹**

在 PowerPoint 中透過調整形狀的輪廓、填色與效果來格式化形狀。Aspose.Slides for Java 讓您以程式方式控制這些設定，包括透明度、旋轉以及 3D 格式化。

![PowerPoint 中的形狀格式化選項](format-shape-powerpoint.png)

Aspose.Slides for Java 提供介面與方法，讓您使用 PowerPoint 中相同的選項來格式化形狀。

## **格式化線條**

使用[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) 來控制形狀的輪廓。此範例建立一個未填色且藍色虛線輪廓的矩形。[ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) 選擇粗細交錯的複合線，而[ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) 設定寬度為 7 點，且[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) 選擇虛線樣式。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![投影片中格式化的線條](formatted-lines.png)

### **設定自訂線條虛線模式**

當預先定義的線條樣式無法提供所需的虛線長度與間距時，請使用[ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-)。指定模式會自動將線條虛線樣式變更為[LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)。

陣列項目交替為虛線與間距長度，從虛線開始。每個值都是線寬的倍數：`{ 4, 2 }` 在寬度為 3 點時會產生 12 點的虛線，接著 6 點的間距。使用成對的有限、非負值來定義完整的虛線‑間距段落。範例使用正值以確保每個虛線與間距皆可見。

此範例建立五條相同長度、平端點的藍色線條。前三條在 3 點寬度下比較不同模式。第四條以兩倍寬度重複第一個模式，將虛線與間距長度同時加倍。第五條則從自訂模式切換為實線。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // 將最後一條線設定為實線樣式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要改回預先定義的虛線樣式，請傳遞[LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)給[ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-)。所選樣式控制線條的外觀。

PowerPoint 中的結果，從上到下： **{4, 2}, 3 pt**； **{1, 2}, 3 pt**； **{6, 2, 1, 2}, 3 pt**； **{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三種自訂虛線模式、使用第一種模式的較寬線條，以及 PowerPoint 中的實線](custom-dash-patterns.png)

### **設定線條端點樣式**

使用[ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) 來設定開放線條的兩端。[LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) 類別提供三種明確的端點樣式：

- `Flat`：筆劃在端點處停止。
- `Round`：半圓形端點延伸至線寬的一半。
- `Square`：方形端點延伸至線寬的一半。

該類別亦包含 `NotDefined`，表示未明確指派端點樣式。

端點樣式與箭頭不同，箭頭會在線端加入符號，且與接合方式不同，接合控制線段之間的拐角。此範例透過[ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) 與[ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) 停用箭頭，以便僅比較端點形狀。

以下範例建立三條在其他屬性上相同、寬度為 20 點的水平線。由上而下分別使用 Flat、Round、Square 端點。它們的端點具有相同的水平座標；Round 與 Square 端點會在每個端點向外延伸 10 點。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果，從上到下： **Flat**、**Round**、**Square**。

![在相同粗線上使用 Flat、Round、Square 端點的效果 (PowerPoint)](line-caps.png)

## **套用草圖效果於形狀線條**

草圖效果會讓形狀線條看起來像手繪。使用[IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) 取得線條設定，使用[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) 取得草圖設定，並使用[ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) 從[LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 類別選取值。

以下 Java 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 效果、讀取明確指派的值，並以 [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 移除效果：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) 回傳的值代表直接指派給形狀的設定。若線條格式可能繼承自佈景主題、母片或版面投影片，請使用[ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)，取得[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)，再讀取[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--)。有效值反映在繼承解析後實際套用的格式。此範例需要一個已存在的投影片，且其第一張投影片上至少有一個形狀，並會同時輸出兩個值：

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

以下為三種接合類型選項：

* 圓角
* 斜角
* 斜切

接合樣式控制兩條輪廓在拐角處的相遇方式。使用 **圓角** 取得圓形拐角，**斜角** 取得尖銳拐角，或 **斜切** 取得平坦拐角。

![投影片中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色輪廓寬度為 15 點。分別使用[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) 設定[LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) 的斜接、斜切與圓角，以比較拐角的呈現方式。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **在銳角限制斜接接合**

使用[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) 搭配將[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) 設為[LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) 以限制銳角可延伸的距離。

此限制是接合內外角之間距離與線寬的比例。例如，值 `8` 允許斜接長度最多為線寬的八倍；它不是以點為單位的測量。若拐角超過此限制，PowerPoint 會在該處使用斜切接合。較大的限制允許更尖銳的點。此設定僅影響斜接，當拐角仍在限制範圍內時，變更設定不會產生可見效果。

此範例建立兩個相同、未填色的三角形，輪廓寬度為 20 點。左側三角形使用限制 `2`，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂部拐角的斜接長度與線寬比例約為 `4.12`。因此，PowerPoint 會在左側頂點使用斜切，在右側保留尖銳頂點。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的結果：左側 **Miter limit 2**，右側 **miter limit 8**。

![在 PowerPoint 中，斜接限制為 2 的斜切頂點與限制為 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在形狀內混合顏色。此範例使用 [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) 於橢圓形套用 45 度角、由紅色過渡至紫色的線性漸層。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) 方法將顏色停止點置於 0 與 1（漸層的開始與結束）。清除現有的停止點可確保僅使用這兩種顏色。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有漸層填色的橢圓形](gradient-fill.png)

如果在匯出影像時漸層看起來與 PowerPoint 中不同，請參閱[Choose a Gradient Rendering Style](/slides/zh-hant/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改投影片內儲存的漸層填色的情況下選擇渲染樣式。

### **設定線性漸層角度**

使用[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) 來控制[GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 填色的方向。角度以度數計算，順時鐘遞增：`0` 為左至右，`90` 為上至下，`180` 為右至左，`270` 為下至上。支援小數角度。超出 `[0, 360)` 範圍的有限角度會正規化為一圈，例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，於位置 `0`、`0.5`、`1` 處放置相同的紅、綠、藍停止點。停用縮放以便在不受矩形比例影響的情況下比較角度。角度由左至右依序為第一行的 `0`、`45`、`90`，第二行的 `135`、`180`、`270`。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的結果：

![上排 0、45、90 度的線性漸層，下排 135、180、270 度的線性漸層](linear-gradient-angles.png)

### **根據形狀縮放線性漸層**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) 接受一個[NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 值。將其明確設為 `False` 可在形狀比例變化時保持幾何漸層角度不變，設為 `True` 則會隨形狀的寬高一起縮放漸層。啟用縮放時，非正方形形狀的可見角度可能與指派角度不同。

以下範例使用 `45` 度角與相同的顏色停止點。左欄使用 `False`；右欄使用 `True`。每欄包含一個寬矩形上方一個高矩形。兩者起始寬度相同；變更第二個矩形的寬高以示範在不改變漸層設定的前提下，填色如何回應尺寸調整。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的結果，左側停用縮放，右側啟用縮放：

![寬與高矩形的 45 度漸層，左側 LinearGradientScaled 為 False，右側為 True 的比較圖](linear-gradient-scaling.png)

停用縮放時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨形狀比例伸展。這有助於在將形狀調整為不同尺寸時重現範本的漸層。對於正方形而言，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆僅套用於線性漸層，不會控制[GradientShape.Radial 或 GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 填色。

### **結合角度與漸層方向**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) 從[GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) 類別選取漸層樣式；它並非數值角度的替代方案。對於線性漸層，角落樣式可在不更改透過[setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) 指派的角度下，改變顏色分布的區域。比較角度或縮放時，請保持方向不變。

以下範例以相反順序套用相同設定。兩個矩形的外觀相同：先設定方向或先設定角度皆不會改變結果。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **圖案填色**

圖案填色會套用兩色設計，例如點、條紋或格子。此範例使用[IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) 選取格狀圖案。[IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) 提供淡灰色背景，而[IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) 提供黃色圖案色。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有圖案填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在形狀內使用影像。此範例需要本機圖片，並使用[Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) 將其載入投影片的影像集合。將[IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 設為平鋪模式會在矩形內重複影像。以下為使用的來源影像：

![蓮花圖片](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有圖片填色的形狀](picture-fill.png)

### **以磚塊方式平鋪圖片作為紋理**

如果想將平鋪圖片作為紋理並自訂平鋪行為，可使用以下 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) 類別的方法：

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)：設定圖片填充模式 — `Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)：指定平鋪在形狀內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)：控制平鋪是否水平、垂直或同時翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)：設定平鋪相對於形狀原點的水平位移（單位：點）。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)：設定平鋪相對於形狀原點的垂直位移（單位：點）。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)：以百分比定義平鋪的水平倍率。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)：以百分比定義平鋪的垂直倍率。

此範例需要本機圖片，並將 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 設定為以原始尺寸 50% 重複平鋪。將 X、Y 位移皆設為 -32 點，使平鋪在水平與垂直方向上平移；使用右下對齊並同時翻轉兩個方向，以決定重複紋理的排列方式。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![平鋪選項](tile-options.png)

## **純色填色**

純色填色會為形狀設定單一、均勻的顏色。此範例使用[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設定為純色填充模式，並透過[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 指派黃色，最後將矩形儲存至投影片。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![具有純色填充的形狀](solid-color-fill.png)

## **使用投影片背景作為形狀填色**

當形狀應與投影片背景相匹配時（例如在投影片範本中），請使用[IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-)。先使用[IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為[FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 以移除任何明確的填色。結合此操作後，形狀會使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已存在的明確填色。

這與[FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 不同：背景填色會以投影片背景相應區域覆蓋形狀背後的物件，而無填色則會讓這些物件保持可見。漸層會與投影片對齊，而不會在每個形狀內重新開始。

以下範例建立一個由母片繼承的背景，並在三個矩形後放置一條洋紅色條紋。左側矩形使用背景填色，中間矩形無填色，右側矩形則從背景填色切換為明確的橙色填色。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // 繼承母片的漸層。
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // 先加入此物件，使其位於矩形之後方。
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // 在套用明確填色之前，停用背景填色。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果，從左到右： **background fill**、**no fill**、**explicit fill**。洋紅色條紋被左、右兩個矩形遮蔽，但在中間矩形下仍可見。

![背景填色、無填色與明確橙色填色覆蓋在洋紅條紋上](background-fill.png)

相同的行為也適用於直接在投影片上定義或從版面繼承的背景。形狀會使用投影片解析後的背景；此範例未設定投影片與版面的背景，讓母片提供背景。

## **設定透明度**

對於純色填色，顏色的 alpha 成分控制不透明度：0 為全透明，255 為全不透明。此範例將 alpha 值設為 128，為黃色矩形提供約 50% 的透明度，使其下方的矩形仍可見。顏色透過[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 進行指派。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![透明形狀](shape-transparency.png)

## **旋轉形狀**

使用[IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) 可在投影片平面上旋轉形狀。角度以度數計算；此範例將矩形順時鐘旋轉 5 度，並儲存投影片。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![形狀旋轉](shape-rotation.png)

## **新增 3D 斜角效果**

使用[IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) 為形狀提供深度與斜角邊緣。此範例建立綠色橢圓形，橙色輪廓，使用[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) 將深度設定為 4 點，並透過[IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) 套用寬高皆為 6 點的圓形上斜角。正面正投影相機與三點式光源使斜角可見。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 斜角效果](3D-bevel-effect.png)

## **新增 3D 旋轉效果**

形狀的 3D 觀點由相機設定控制。此範例使用[ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-)，分別設定緯度、經度與旋轉角度為 40、35、20 度。再透過[ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) 選取等角相機，並使用[ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) 設定平衡光源，最後儲存格式化後的矩形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![3D 旋轉效果](3D-rotation-effect.png)

## **控制形狀的黑白渲染**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 方法指定當投影片以黑白模式檢視或處理時，單一形狀的呈現方式。此方法本身不會啟用黑白顯示，也不會在正常彩色模式下變更形狀的填色、線條或其他格式設定。

使用[BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) 類別的值來選取所需行為。例如，`Automatic` 讓渲染應用程式自行選擇轉換方式，`Gray` 與 `LightGray` 使用灰階顏色，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單色，`Color` 保留正常顏色，`Hidden` 在黑白模式下省略形狀。`NotDefined` 表示未指派形狀層級的模式。

此範例建立橙色矩形，並使用[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 將模式設定為灰色。儲存後的形狀在正常彩色顯示時保留橙色填色，且在支援黑白顯示設定的應用程式中會請求以灰色呈現：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保留橙色填色。於黑白顯示工作流程中，因模式設定為 `Gray`，矩形會以灰色呈現。此方式讓您在保留完整彩色投影片的同時，為列印、預覽或其他遵循投影片黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用[ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) 可從對應的版面佔位符恢復投影片佔位符的位置、大小與格式設定。此範例需要一個已存在且具版面連結佔位符的投影片，並在儲存前重設每張投影片。未與版面佔位符對應的形狀不會被重設。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**形狀格式化會影響最終投影片檔案大小嗎？**

顏色、線條樣式與效果設定相較於嵌入的影像與媒體，通常只會增加少量資料。圖片填色可能因其影像儲存在投影片內而增加檔案大小。

**如何偵測投影片上具有相同格式的形狀，以便將它們分組？**

比較每個形狀的關鍵格式屬性——填色、線條與效果設定。若所有對應值相符，視為樣式相同，便可在邏輯上將這些形狀分組，從而簡化後續的樣式管理。

**我能將一組自訂形狀樣式存成獨立檔案，以便在其他投影片中重複使用嗎？**

可以。將具有所需樣式的範例形狀保存在範本投影片或 .POTX 範本檔中。建立新投影片時，開啟該範本，複製需要的已樣式化形狀，並在需要的地方重新套用其格式。