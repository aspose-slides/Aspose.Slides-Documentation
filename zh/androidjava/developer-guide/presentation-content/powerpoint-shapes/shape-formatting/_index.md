---
title: 在 Android 上格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/androidjava/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 素描效果
- 形状线条素描
- 格式化连接样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 黑白形状渲染
- 灰度形状渲染
- 旋转形状
- 3D 倾斜效果
- 3D 旋转效果
- 重置格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Android 上使用 Aspose.Slides 对 PowerPoint 形状进行格式化——精准且完全控制地为 PPT 和 PPTX 文件设置填充、线条和效果样式。"
---
## **简介**

通过调整轮廓、填充和效果来格式化 PowerPoint 中的形状。Aspose.Slides for Android via Java 允许您以编程方式控制这些设置，包括透明度、旋转和 3D 格式化。

![PowerPoint 中的形状格式化选项](format-shape-powerpoint.png)

Aspose.Slides for Android via Java 提供接口和方法，允许您使用 PowerPoint 中可用的相同选项来格式化形状。

## **格式线条**

使用[IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--)来控制形状的轮廓。本例创建一个未填充、蓝色虚线轮廓的矩形。[ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-)选择粗细复合线，而[ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-)将其宽度设置为 7 磅，[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-)选择虚线样式。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

结果如下：

![演示文稿中格式化的线条](formatted-lines.png)

### **设置自定义线段虚线模式**

当预定义的线样式无法提供所需的虚线长度和间隙时（例如用于品牌轮廓或技术图表），请使用[ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---)。分配模式会自动将线条虚线样式更改为[LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/)。

数组条目在虚线和间隙长度之间交替，首先是虚线。每个值是线宽的倍数：在宽度为 3 磅时，`{ 4, 2 }` 产生 12 磅的虚线，随后是 6 磅的间隙。使用成对的有限非负值来定义完整的虚线-间隙段。示例使用正值以确保每个虚线和间隙都可见。

本例创建五条相同长度且带平直端点的蓝色线条。前三条在 3 磅宽度下比较不同模式。第四条以两倍宽度重复第一种模式，虚线和间隙长度均加倍。第五条从自定义模式切换为实线。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // 将最后一条线恢复为实线样式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果要恢复为预定义的虚线样式，请将[LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/)传递给[ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-)。所选样式控制线条的外观。

PowerPoint 中的结果（从上到下）：**{4, 2}，3 磅**；**{1, 2}，3 磅**；**{6, 2, 1, 2}，3 磅**；**{4, 2}，6 磅**；以及**实线，3 磅**。

![PowerPoint 中的三种自定义虚线模式、使用第一种模式的更宽线条以及实线](custom-dash-patterns.png)

### **设置线端帽**

使用[ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-)设置开放线的端点。[LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/)类提供三种明确的端帽样式：

- `Flat`：笔画在端点处停止。
- `Round`：半圆形端帽延伸至端点之外，延伸距离为线宽的一半。
- `Square`：方形端帽延伸至端点之外，延伸距离为线宽的一半。

该类还包含 `NotDefined`，表示未明确分配端帽样式。

端帽不同于箭头，后者在线端添加符号，也不同于连接方式，后者控制线段之间的拐角。本例通过[ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-)和[ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-)禁用箭头，以便仅比较端帽形状。

下面的示例创建三条除端帽外完全相同的水平线，宽度为 20 磅。从上到下，它们分别使用平直、圆形和方形端帽。它们的端点具有相同的水平坐标，圆形和方形端帽在每个端点之外延伸 10 磅。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

PowerPoint 中的结果（从上到下）：**Flat**，**Round** 和 **Square**。

![PowerPoint 中相同粗线的平直、圆形和方形端帽](line-caps.png)

## **对形状线条应用素描效果**

素描效果使形状线条看起来像手绘。使用[IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--)访问线条设置，使用[ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--)访问素描设置，并使用[ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-)从[LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)类中选择一个值。

下面的 Java 代码演示了如何应用[LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)效果，读取显式分配的值，以及使用[LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/)移除该效果：

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

[ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--)返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，则使用[ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--)，访问[ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--)，并读取[ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--)。有效值反映继承解析后实际应用的格式。本示例需要一个已有的演示文稿，其第一张幻灯片上至少有一个形状，并打印两个值：

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

## **格式连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

连接样式控制两个轮廓段在拐角处的连接方式。使用 **Round** 获得圆角，使用 **Miter** 获得尖角，或使用 **Bevel** 获得平坦的拐角。

![演示文稿中的连接样式](join-style-powerpoint.png)

本例创建三个黑色矩形，蓝色轮廓宽度为 15 磅。它使用[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-)分别应用[LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/)的 miter、bevel 和 round 值，以比较拐角的绘制方式。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **在尖角限制斜接连接**

使用[ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-)并将[ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-)设置为[LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/)来限制尖角的延伸距离。

该限制是内外拐角之间的距离与线宽的比例。例如，值 `8` 允许斜接长度最多为线宽的八倍；这不是以磅为单位的度量。如果拐角超过限制，PowerPoint 会在该拐角使用平切连接。更大的限制会产生更尖的点。此设置仅影响斜接连接，在拐角仍在两种限制范围内时更改它不会产生可见效果。

本例创建两个相同的未填充三角形，轮廓宽度为 20 磅。左侧三角形使用 `2` 的限制，右侧使用 `8`。每个三角形宽 80 磅，高 160 磅，使其顶部拐角的斜接长度与线宽的比例约为 `4.12`。因此，PowerPoint 对左侧顶点进行平切，而保留右侧顶点。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的结果：左侧为 **Miter limit 2**，右侧为 **miter limit 8**。

![PowerPoint 中斜接限制为 2 的平切顶点和斜接限制为 8 的尖锐顶点](miter-limits.png)

## **渐变填充**

渐变填充在形状上混合颜色。本例使用[IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--)在椭圆中填充 45 度角的线性渐变，从红色到紫色。[IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-)方法将颜色停止点放置在 0 和 1，即渐变的起点和终点。清除现有的停止点可以确保仅使用这两种颜色。

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

结果：

![具有渐变填充的椭圆](gradient-fill.png)

如果导出图像中的渐变与 PowerPoint 中的显示不同，请参阅[选择渐变渲染样式](/slides/zh/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的情况下选择渲染样式。

### **设置线性渐变角度**

使用[IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-)控制[GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)填充的方向。角度以度为单位，顺时针递增：`0` 为从左到右，`90` 为从上到下，`180` 为从右到左，`270` 为从下到上。支持小数角度。超出 `[0, 360)` 的有限角度会归一化为一次完整旋转；例如，`-45` 变为 `315`，`360` 变为 `0`。

本例创建六个矩形，在位置 `0`、`0.5` 和 `1` 处放置相同的红、绿、蓝颜色停止点。禁用缩放，以便角度可以独立于矩形比例进行比较。从左到右的角度分别为第一行的 `0`、`45`、`90`，第二行的 `135`、`180`、`270`。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPoint 中的结果：

![顶部行的线性渐变分别为 0、45、90 度，底部行为 135、180、270 度](linear-gradient-angles.png)

### **Scale a Linear Gradient with the Shape**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-)接受一个[NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/)值。显式设置为 `False` 可在形状比例变化时保持几何渐变角度不变，设置为 `True` 则随形状的宽度和高度缩放渐变。启用缩放时，在非正方形形状上可见角度可能与分配的角度不同。

下面的示例使用 `45` 度角度和与角度比较相同的颜色停止点。左列使用 `False`，右列使用 `True`。每列包含一个宽矩形在上方和一个高矩形在下方。两个列最初都有相同的宽度尺寸；通过改变第二个矩形的宽高来演示填充在调整大小时如何响应，而不更改其渐变设置。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPoint 中的结果，左侧禁用缩放，右侧启用缩放：

![宽矩形和高矩形的 45 度渐变，对比左侧 LinearGradientScaled 为 False 与右侧为 True](linear-gradient-scaling.png)

缩放禁用时，对角色带在两个矩形中保持相同方向。启用缩放时，色带随形状比例拉伸。这有助于在将形状适配到不同尺寸时复制模板的渐变。在正方形上，启用缩放不会改变此 `45` 度渐变的外观。

角度和缩放设置均适用于线性渐变。它们不控制[GradientShape.Radial 或 GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/)填充。

### **Combine the Angle with Gradient Direction**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-)从[GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/)类中选择渐变样式；它并不能替代数值角度。对于线性渐变，拐角样式可以在不更改通过 [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) 分配的角度的情况下改变颜色分布的区域。比较角度或缩放时，请保持方向不变。

下面的示例以相反的顺序应用相同的设置。两个矩形的外观相同：在角度之前或之后分配方向都不会改变结果。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **图案填充**

图案填充使用两色图案，如点、条纹或格子。本例使用[IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-)选择格子图案。[IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--)提供浅灰色背景，[IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--)提供黄色图案颜色。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

图片填充在形状内部使用图像。本例需要本地图像，并使用[Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-)将其加载到演示文稿的图像集合中。将[IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)设置为平铺模式会在矩形内重复图像。下方显示了此处使用的源图像：

![莲花图片](lotus.png)

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

结果：

![带图片填充的形状](picture-fill.png)

### **Tile Picture As Texture**

如果要将平铺图片设置为纹理并自定义平铺行为，可以使用[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/)接口和[PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/)类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-)：指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-)：控制平铺是否水平翻转、垂直翻转或两者皆翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-)：设置平铺相对于形状原点的水平偏移（单位为磅）。
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-)：设置平铺相对于形状原点的垂直偏移（单位为磅）。
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-)：以百分比定义平铺的水平比例。
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-)：以百分比定义平铺的垂直比例。

本例需要本地图像，并配置[IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/)以原始大小的 50% 重复显示。−32 磅的偏移量将平铺水平和垂直移动；右下对齐并在两个方向翻转决定了重复纹理的排列方式。

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

结果：

![平铺选项](tile-options.png)

## **纯色填充**

纯色填充为形状提供单一、统一的颜色。本例使用[IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-)选择纯色填充模式，并通过[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)分配黄色，然后将矩形保存到演示文稿中。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

结果：

![带纯色填充的形状](solid-color-fill.png)

## **使用幻灯片背景作为形状填充**

当形状应匹配幻灯片背景时（例如在演示文稿模板中），请使用[IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-)。首先使用[IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-)并设为[FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)以移除任何显式填充。通过此组合，形状使用幻灯片背景而非其样式填充。仅启用该标志并不能移除已有的显式填充。

这与[FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)不同：背景填充使用幻灯片背景对应区域覆盖形状背后的对象，而 No Fill 则让这些对象可见。渐变保持与幻灯片对齐，而不是在每个形状内部重新开始。

下面的示例创建一个由幻灯片继承的母版背景，并在三个矩形后放置一条品红色条带。左侧矩形使用背景填充，中间矩形无填充，右侧矩形从背景填充切换为显式的橙色填充。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // 从母版继承渐变。
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // 先添加此对象，使其位于矩形后方。
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

    // 在应用显式填充之前禁用背景填充。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果（从左到右）：**背景填充**、**无填充**和**显式填充**。品红色条带被左侧和右侧矩形遮挡，但通过中间矩形仍可见。

![背景填充、无填充和显式橙色填充覆盖在品红色条带上](background-fill.png)

相同的行为适用于直接在幻灯片上定义或从版面继承的背景。形状使用幻灯片已解析的背景；示例未定义幻灯片和版面背景，因此使用母版背景。

## **设置透明度**

对于纯色填充，颜色的 alpha 分量控制不透明度：0 表示完全透明，255 表示完全不透明。本例对黄色矩形使用 alpha 值 128，使其约 50% 透明，从而下方的矩形仍可见。颜色通过[IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--)分配。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

使用[IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-)在幻灯片平面上旋转形状。角度以度为单位；本例将矩形顺时针旋转 5 度并保存演示文稿。

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

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

使用[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)为形状增加深度和倾斜边缘。本例创建一个绿色椭圆并使用橙色轮廓，调用[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)将深度设为 4 磅，并通过[IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--)应用宽高为 6 磅的圆形顶部倾斜。正视正射相机和三点灯光使倾斜效果可见。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
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

结果：

![3D 倾斜效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

形状的 3D 视图由其相机设置控制。本例使用[ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-)将纬度、经度和旋转角度分别设为 40、35、20 度。通过[ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-)选取等轴相机，并通过[ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-)选择均衡光照，然后保存已格式化的矩形。

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

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-)方法指定在以黑白模式查看或处理演示文稿时单个形状的渲染方式。它本身不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用[BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/)类中的值来选择所需行为。例如，`Automatic` 让渲染应用程序自行决定转换方式，`Gray` 和 `LightGray` 使用灰色，`BlackWhite` 仅使用黑白，`Black` 和 `White` 强制单色，`Color` 保持正常着色，`Hidden` 在黑白模式下隐藏形状。`NotDefined` 表示未分配形状级别的模式。

本例创建一个橙色矩形，并使用[IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-)选择灰色着色。保存的形状在正常彩色显示下保持橙色填充，并在遵循黑白显示设置的应用程序中请求灰色着色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保持其橙色填充。在黑白显示工作流中，由于模式设置为 `Gray`，它会使用灰色着色。这使您能够在保留全彩幻灯片的同时，为打印、预览或其他遵循演示文稿黑白显示设置的工作流定义不同的外观。

## **重置格式**

使用[ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--)从相应的版面占位符恢复幻灯片占位符的位置、大小和格式。本例需要一个已有的演示文稿，其中占位符链接到版面，并在保存前重置每张幻灯片。没有对应版面占位符的形状不会被重置。

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

## **常见问题**

**形状格式化会影响最终的演示文稿文件大小吗？**

相对于嵌入的图像和媒体，颜色、线条样式和效果设置通常只会增加很少的数据。图片填充可能会增加文件大小，因为其图像被存储在演示文稿中。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值均匹配，则视其样式为相同，并在逻辑上对这些形状进行分组，这将简化后续的样式管理。

**我可以将自定义形状样式保存到单独的文件以便在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开该模板，克隆所需的已样式化形状，并在需要的地方重新应用其格式。