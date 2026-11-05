---
title: 在 Java 中格式化 PowerPoint 圖形
linktitle: 圖形格式化
type: docs
weight: 20
url: /zh-hant/java/shape-formatting/
keywords:
- 格式化圖形
- 格式化線條
- 草圖效果
- 圖形線條草圖
- 格式化接合樣式
- 漸層填色
- 圖樣填色
- 圖片填色
- 紋理填色
- 實色填色
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
description: "了解如何在 Java 中使用 Aspose.Slides 格式化 PowerPoint 圖形——為 PPT 與 PPTX 檔案精確且完整地設定填色、線條與效果樣式。"
---
## **簡介**

在 PowerPoint 中透過調整輪廓、填色與效果來格式化圖形。Aspose.Slides for Java 讓您能以程式方式控制這些設定，包括透明度、旋轉以及 3D 格式設定。

![PowerPoint 中的圖形格式選項](format-shape-powerpoint.png)

Aspose.Slides for Java 提供介面與方法，讓您使用與 PowerPoint 中相同的選項來格式化圖形。

## **格式線條**

使用 [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) 來控制圖形的輪廓。此範例建立一個未填色、藍色虛線輪廓的矩形。[ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) 選擇粗細複合線，而 [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) 將寬度設為 7 點，且 [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) 選擇虛線樣式。

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

![投影片中已格式化的線條](formatted-lines.png)

### **設定自訂線條虛線圖樣**

當預先定義的線條樣式無法提供所需的虛線長度與間距時（例如品牌輪廓或技術圖表），請使用 [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float---)。指定圖樣會自動將線條虛線樣式變更為 [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)。

陣列項目在虛線與間隙長度之間交替，首項為虛線。每個值都是線寬的倍數：在寬度為 3 點時，`{ 4, 2 }` 會產生 12 點的虛線，接著 6 點的間隙。使用有限且非負的成對值來定義完整的虛線與間隙段落。此範例使用正值以確保每段虛線與間隙皆可見。

此範例建立五條藍色線條，長度相同且使用平直端點。前三條在 3 點寬度下比較圖樣。第四條以兩倍寬度重複第一個圖樣，將虛線與間隙長度皆加倍。第五條則從自訂圖樣切換為實線。

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

    // 將最後一條線恢復為實線樣式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要改回預先定義的虛線樣式，請將 [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) 傳入 [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-)。所選樣式會控制線條的外觀。

PowerPoint 中的結果（由上而下）：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三個自訂虛線圖樣、使用第一個圖樣的較寬線條，以及一條實線](custom-dash-patterns.png)

### **設定線條端點樣式**

使用 [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) 設定開放線條的端點。[LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) 類別提供三種明確的端點樣式：

- `Flat`：筆畫於端點處停止。
- `Round`：半圓形端點延伸至端點之外，延伸距離為線寬的一半。
- `Square`：方形端點延伸至端點之外，延伸距離為線寬的一半。

此類別亦包含 `NotDefined`，表示未明確指派端點樣式。

端點樣式不同於箭頭端點（在線條末端加入符號）以及接合點（控制線段之間的角落）。此範例透過 [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) 與 [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) 停用箭頭端點，以便僅比較端點形狀。

以下範例建立三條水平線條，寬度皆為 20 點，其他屬性相同。由上而下分別使用 flat、round、square 端點。它們的端點在水平座標上相同；round 與 square 端點會延伸至端點之外 10 點。

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

PowerPoint 中的結果（由上而下）：**Flat**、**Round** 與 **Square**。

![PowerPoint 中相同粗線的平直、圓形與方形端點](line-caps.png)

## **套用手繪草圖效果於圖形線條**

草圖效果使圖形線條看起來像手繪。使用 [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) 取得線條設定，[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) 取得草圖設定，並透過 [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) 從 [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 類別中選取值。

以下 Java 程式碼示範如何套用 [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 效果、讀取明確指派的值，及使用 [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) 移除該效果：

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

由 [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) 回傳的值代表直接指派給圖形的設定。若線條格式可以從佈景主題、母片或版面投影片繼承，請使用 [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--)，存取 [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)，並讀取 [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--)。有效值反映繼承解析後實際套用的格式。此範例需要一個已存在且第一張投影片至少有一個圖形的簡報，並會印出兩個值：

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

## **格式接合樣式**

以下是三種接合類型選項：

* Round
* Miter
* Bevel

接合樣式控制兩段輪廓在角落的相交方式。使用 **Round** 取得圓角，**Miter** 取得尖角，或 **Bevel** 取得平緩角。

![投影片中的接合樣式](join-style-powerpoint.png)

此範例建立三個黑色矩形，藍色輪廓寬度為 15 點。使用 [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) 分別將 [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) 的斜接、平緩與圓形值套用，以比較角落的繪製方式。

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

使用 [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) 搭配將 [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) 設為 [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/)，以限制銳角的延伸距離。

此限制是接合內、外角之間距離與線寬的比率。例如，`8` 的值允許斜接長度最高為線寬的八倍；它不是以點數為單位的測量。如果角落超過此限制，PowerPoint 會在該角落使用平緩接合。較大的限制允許更尖銳的點。此設定僅影響斜接接合，當角落仍在限制範圍內時變更它不會產生可見效果。

此範例建立兩個相同且未填色的三角形，輪廓寬度為 20 點。左側三角形使用 `2` 的限制，右側使用 `8`。每個三角形寬 80 點、高 160 點，使其頂角的斜接長度與線寬比約為 `4.12`。因此，PowerPoint 會將左側頂點平緩化，而保留右側頂點。

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

PowerPoint 中的結果：左側為 **Miter limit 2**，右側為 **miter limit 8**。

![PowerPoint 中斜接限制 2 的平緩頂點與斜接限制 8 的尖銳頂點](miter-limits.png)

## **漸層填色**

漸層填色會在圖形上混合顏色。此範例使用 [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--) 以 45 度角從紅色到紫色的線性漸層填滿橢圓形。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) 方法在位置 0 與 1（漸層的開始與結束）放置顏色節點。清除現有的節點可確保僅使用這兩種顏色。

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

如果匯出圖片中的漸層與 PowerPoint 中的呈現不同，請參閱 [Choose a Gradient Rendering Style](/slides/zh-hant/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不變更簡報內部儲存的漸層填色的情況下選擇渲染樣式。

### **設定線性漸層角度**

使用 [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) 來控制 [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 填色的方向。角度以度數表示，且順時針遞增：`0` 為左至右，`90` 為上至下，`180` 為右至左，`270` 為下至上。支援小數角度。超出 `[0, 360)` 的有限角度會正規化為一週，例如 `-45` 變為 `315`，`360` 變為 `0`。

此範例建立六個矩形，於位置 `0`、`0.5`、`1` 設定相同的紅、綠、藍顏色節點。停用縮放以便在不受矩形比例影響下比較角度。角度由左至右依序為第一列的 `0`、`45`、`90`，第二列的 `135`、`180`、`270`。

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

### **依圖形縮放線性漸層**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) 接受一個 [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 值。明確設定為 `False` 可在圖形比例變更時維持幾何漸層角度，設定為 `True` 則會隨圖形的寬高縮放漸層。啟用縮放時，非正方形圖形的可見角度可能與指派角度不同。

以下範例使用 `45` 度角度與相同的顏色節點。左欄使用 `False`，右欄使用 `True`。每個欄位包含一個寬矩形在上方與一個高矩形在下方。兩者起始寬度相同；變更第二個矩形的寬高可示範填色在調整大小時如何回應，而不改變其漸層設定。

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

PowerPoint 中的結果，左側停用縮放、右側啟用縮放：

![寬與高矩形的 45 度漸層，左側為 LinearGradientScaled False，右側為 True 的比較](linear-gradient-scaling.png)

停用縮放時，對角色帶在兩個矩形中保持相同方向。啟用縮放時，色帶會隨圖形比例伸展。這有助於在將圖形調整為不同尺寸時重現範本的漸層。對於正方形而言，啟用縮放不會改變此 `45` 度漸層的外觀。

角度與縮放設定皆套用於線性漸層。它們不會控制 [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/) 填色。

### **結合角度與漸層方向**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) 從 [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/) 類別中選取漸層樣式；它並非數值角度的替代品。對於線性漸層，角落樣式可以改變顏色分布的區域，而不改變透過 [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) 指定的角度。比較角度或縮放時請保持方向不變。

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

## **圖樣填色**

圖樣填色會套用兩色設計，例如點、條紋或格子。此範例使用 [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) 選取格狀圖樣。[IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) 提供淡灰色背景，[IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) 提供黃色圖樣顏色。

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

![帶圖樣填色的矩形](pattern-fill.png)

## **圖片填色**

圖片填色會在圖形內使用影像。此範例需要本機影像，並使用 [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) 將其載入簡報的影像集合。將 [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) 設為平鋪模式會在矩形內重複影像。以下顯示此處使用的來源影像：

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

![帶圖片填色的圖形](picture-fill.png)

### **將圖片平鋪為紋理**

如果想將平鋪圖片作為紋理並自訂平鋪行為，可以使用下列 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) 類別的方法：

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)：設定圖片填充模式，可為 `Tile`（平鋪）或 `Stretch`（拉伸）。
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)：指定圖塊在圖形內的對齊方式。
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)：控制圖塊是否水平翻轉、垂直翻轉或兩者皆翻轉。
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)：設定圖塊相對於圖形原點的水平偏移（以點為單位）。
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)：設定圖塊相對於圖形原點的垂直偏移（以點為單位）。
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)：定義圖塊的水平縮放比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)：定義圖塊的垂直縮放比例（百分比）。

此範例需要本機影像，並設定 [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) 以原始大小的 50% 進行平鋪。−32 點的偏移會在水平與垂直方向上移動圖塊；右下對齊且雙向翻轉決定了重複紋理的排列方式。

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

![圖塊選項](tile-options.png)

## **實心顏色填色**

實心填色會給予圖形單一且均勻的顏色。此範例使用 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設定實心填色模式，並透過 [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 指派黃色，最後將矩形儲存於簡報中。

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

![帶實心顏色填色的圖形](solid-color-fill.png)

### **在保留主題參照的同時複製顏色**

使用 [IColorFormat.copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) 複製顏色定義，包含其顏色類型、主題參照與變換。這在將填色在應持續遵循簡報主題的圖形間傳遞時相當有用。此方法僅複製顏色本身，並不複製填色類型、輪廓或其他圖形格式。請使用 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 明確設定目標的填色類型。

此範例建立三個矩形，從左至右分別為：來源、具主題感知的複本、以及固定 RGB 的複本。來源使用 [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setSchemeColor-int-) 參照第一個強調色，並透過 [IColorOperationCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/icoloroperationcollection/#add-int-float-) 加上色調。RGB 複本使用來源的有效填色，讓三者起始外觀相同。呼叫 [IColorFormat.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#setColor-java.awt.Color-) 會設定固定的 RGB 值，並清除任何既有的顏色變換。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // 主題參照會跟隨新的強調色；固定的 RGB 值則不會。
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(new Color(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在主題變更前，三個填色皆相同：

![來源、copyFrom 目的地與固定 RGB 目的地皆以相同藍色填色](color-copy-before.png)

在主題變更後，來源與具主題感知的複本會遵循新的強調色並保留其色調。固定的 RGB 複本則保持藍色：

![來源與 copyFrom 目的地呈橙色填色，固定的 RGB 目的地仍為藍色](color-copy-after.png)

複製的定義與來源獨立。之後變更來源的主題參照、指派其他顏色，或增減其變換，都不會影響目的地。主題變更仍會影響兩個圖形，因為它們各自獨立參照相同的主題顏色。

儲存並重新開啟 PPTX 會保留複製顏色的類型（由 [IColorFormat.getColorType](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorType--) 取得）、主題參照以及變換集合（由 [IColorFormat.getColorTransform](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/#getColorTransform--) 取得）；不會將定義展平為 RGB。

在不同主題環境之間（例如不同強調調色盤的簡報）進行複製時，複製的參照會依目的地的主題進行解析。因此相同的參照與變換可能產生不同的可見顏色。請參閱 [Presentation Theme](/slides/zh-hant/java/presentation-theme/) 了解更多主題顏色設定。

## **將投影片背景作為圖形填色**

當圖形需與投影片背景相同（例如在簡報範本中），請使用 [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-)。先使用 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 設為 [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 以移除任何明確的填色。此組合會使圖形使用投影片背景而非其樣式填色。僅啟用此旗標不會移除已存在的明確填色。

這與 [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) 不同：背景填色會以投影片背景的相應區域覆蓋圖形背後的物件，而無填色則會保留這些物件可見。漸層仍會與投影片對齊，而非在每個圖形內重新開始。

以下範例建立一個被投影片繼承的母片背景，並在三個矩形後面放置一條洋紅色條帶。左側矩形使用背景，中央矩形無填色，右側矩形則從背景填色切換為明確的橙色填色。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // 從母片繼承漸層。
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

    // 先加入此物件，使其位於矩形背後。
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

    // 在套用明確填色前停用背景填色。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果（由左至右）：**background fill**、**no fill** 與 **explicit fill**。洋紅條帶被左、右矩形遮蔽，但在中間矩形下仍可見。

![背景填色、無填色與明確橙色填色覆蓋於洋紅條帶上](background-fill.png)

相同的行為亦適用於直接於投影片上定義或從版面繼承的背景。圖形使用投影片解析後的背景；此範例讓投影片與版面的背景皆未定義，讓母片提供背景。

## **設定透明度**

對於實心填色，顏色的 alpha 元件控制不透明度：0 為完全透明，255 為完全不透明。此範例為黃色矩形使用 alpha 值 128，使其約 50% 透明，讓底下的矩形仍可見。顏色透過 [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) 指派。

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

![透明的圖形](shape-transparency.png)

## **旋轉圖形**

使用 [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) 於投影片平面上旋轉圖形。角度以度數表示；此範例將矩形順時針旋轉 5 度並儲存簡報。

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

![圖形旋轉](shape-rotation.png)

## **新增 3D 斜角效果**

使用 [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) 為圖形賦予深度與斜角邊緣。此範例建立綠色橢圓，橙色輪廓，使用 [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) 設定深度為 4 點，並透過 [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) 套用寬高皆為 6 點的圓形上斜角。前向正投影相機與三點光源使斜角可見。

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

圖形的 3D 觀點由相機設定控制。此範例使用 [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-)，將緯度、經度與旋轉角度分別設為 40、35、20 度。透過 [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) 選取等角相機，並使用 [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) 設定平衡光源，最後儲存格式化的矩形。

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

## **控制圖形的黑白呈現**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 方法指定在簡報以黑白模式檢視或處理時，個別圖形的呈現方式。它本身不會啟用黑白顯示，也不會在正常彩色模式下變更圖形的填色、線條或其他格式設定。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) 類別中的值來選取所需行為。例如，`Automatic` 讓渲染應用程式自行決定轉換方式，`Gray` 與 `LightGray` 使用灰階著色，`BlackWhite` 僅使用黑白，`Black` 與 `White` 強制單一顏色，`Color` 保持正常著色，`Hidden` 在黑白模式下隱藏圖形。`NotDefined` 表示未指派圖形層級的模式。

此範例建立一個橙色矩形，並使用 [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) 將模式設為灰色。儲存的圖形在正常彩色顯示時保留橙色填色，並向支援黑白顯示設定的應用程式請求灰色著色：

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

在正常彩色模式下，矩形保留橙色填色。在黑白顯示工作流程中，因模式設為 `Gray`，會使用灰色著色。此功能讓您在保留全彩投影片的同時，為列印、預覽或其他遵循簡報黑白顯示設定的工作流程定義不同的外觀。

## **重設格式**

使用 [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) 從對應的版面占位符還原投影片占位符的位置、大小與格式。此範例需要已有的簡報，且該簡報的占位符已連結至版面，並在儲存前重設每張投影片。沒有對應版面占位符的圖形不會被重設。

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

**圖形格式化會影響最終簡報檔案大小嗎？**

相較於嵌入的影像與媒體，顏色、線條樣式與效果設定通常只會增加少量資料。圖片填色可能會因為影像儲存在簡報中而增加檔案大小。

**如何偵測投影片上具有相同格式的圖形以便將它們分組？**

比較每個圖形的關鍵格式屬性──填色、線條與效果設定。若所有對應的值皆相同，則視其樣式為相同，並在邏輯上將這些圖形分組，這可簡化之後的樣式管理。

**我能將自訂圖形樣式存成單獨檔案，以便在其他簡報中重複使用嗎？**

可以。將具備所需樣式的範例圖形儲存在範本投影片或 .POTX 範本檔中。建立新簡報時，開啟範本、複製所需的樣式圖形，然後在需要的地方重新套用其格式。