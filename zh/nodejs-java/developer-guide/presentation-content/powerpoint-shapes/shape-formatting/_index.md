---
title: 在 JavaScript 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/nodejs-java/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 草图形状线
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
- Node.js
- JavaScript
- Aspose.Slides
description: "学习如何在 JavaScript 中使用 Aspose.Slides 对 PowerPoint 形状进行格式化——精确且完全控制地为 PPT 和 PPTX 文件设置填充、线条和效果样式。"
---
## **介绍**

通过调整轮廓、填充和效果来格式化 PowerPoint 中的形状。Aspose.Slides for Node.js via Java 允许您以编程方式控制这些设置，包括透明度、旋转和 3D 格式化。

![PowerPoint 中的形状格式化选项](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java 提供类和方法，使您可以使用 PowerPoint 中可用的相同选项对形状进行格式化。

## **格式线**

使用 [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) 来控制形状的轮廓。此示例创建一个未填充、带蓝色虚线轮廓的矩形。[LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) 选择粗细复合线，而 [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) 将宽度设置为 7 磅，且 [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) 选择虚线模式。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![演示文稿中格式化的线条](formatted-lines.png)

### **设置自定义线段虚线模式**

当预定义线样式无法提供所需的划线和间隔长度时（例如品牌轮廓或技术图表），使用 [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern)。分配模式后会自动将线的虚线样式更改为 [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/)。

数组条目在划线和间隔长度之间交替出现，以划线开始。每个值都是线宽的倍数：在宽度为 3 磅时 `[4, 2]` 产生 12 磅划线后跟 6 磅间隔。使用成对的有限、非负值来定义完整的划线‑间隔段。示例使用正值以保持每段划线和间隔可见。

此示例创建五条相同长度、端点为平头的蓝色线。前三条在宽度为 3 磅时比较不同模式。第四条以两倍宽度重复第一种模式，划线和间隔长度均加倍。第五条从自定义模式切换为实线。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // 将最后一条线恢复为实线样式。
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要返回预定义的虚线样式，请将 [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) 传递给 [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle)。所选样式控制线条的外观。

PowerPoint 中从上到下的结果：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![三个自定义虚线模式、使用第一种模式的较宽线以及实线在 PowerPoint 中的显示](custom-dash-patterns.png)

### **设置线端帽**

使用 [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) 设置开放线段的端点。[LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) 类提供三种显式端帽样式：

- `Flat`：笔画在端点处停止。
- `Round`：半圆形端帽超出端点半个线宽。
- `Square`：方形端帽超出端点半个线宽。

该类还包括 `NotDefined`，表示未显式分配端帽样式。

端帽不同于箭头（在端点添加符号）和连接（控制线段之间的拐角）。此示例通过 [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) 和 [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) 禁用箭头，以便仅比较端帽形状。

以下示例创建三条除端帽外完全相同的水平线，宽度为 20 磅。从上到下，它们分别使用平头、圆头和方头。它们的端点水平坐标相同；圆头和方头在每个端点之外延伸 10 磅。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中从上到下的结果：**Flat**、**Round** 和 **Square**。

![在 PowerPoint 中相同粗细线条的平头、圆头和方头](line-caps.png)

## **对形状线应用草图效果**

草图效果使形状线看起来手绘。使用 [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) 访问线设置，使用 [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) 访问草图设置，并使用 [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) 从 [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 类中选择值。

下面的 JavaScript 代码展示如何应用 [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 效果，读取显式分配的值，以及使用 [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) 移除该效果：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) 返回的值表示直接分配给形状的设置。如果线格式可以从主题、母版幻灯片或布局幻灯片继承，请使用 [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective)，在返回的对象上调用 `getSketchFormat`，然后调用其 `getSketchType` 方法。有效值反映在解析继承后实际应用的格式。此示例需要一个在第一张幻灯片上至少有一个形状的现有演示文稿，并打印两个值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **格式连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

连接样式控制两个轮廓段在拐角处的相接方式。使用 **Round** 生成圆形拐角，使用 **Miter** 生成尖锐拐角，使用 **Bevel** 生成平坦拐角。

![演示文稿中的连接样式](join-style-powerpoint.png)

此示例创建三个蓝色轮廓、宽度为 15 磅的黑色矩形。它分别使用 [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) 将 [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) 的斜接、斜面和圆形值应用于矩形，以比较拐角的绘制方式。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **在锐角处限制斜接连接**

将 [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) 与 [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) 设置为 [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) 结合使用，以限制锐角可以延伸的距离。

该限制是连接内部角和外部角之间的距离与线宽的比率。例如，值 `8` 允许斜接长度最多为线宽的八倍；它不是磅的度量。如果拐角超过限制，PowerPoint 将在该拐角使用斜面连接。较大的限制会产生更尖锐的点。此设置仅影响斜接连接，在拐角仍在两者限制范围内时更改它不会产生可见效果。

此示例创建两个相同的、未填充的三角形，轮廓宽度为 20 磅。左侧三角形使用限制 `2`，右侧使用 `8`。每个三角形宽 80 磅，高 160 磅，使其顶部拐角的斜接长度与线宽比约为 `4.12`。因此，PowerPoint 对左侧顶点使用斜面，而保留右侧顶点的尖锐形状。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的结果：左侧 **Miter limit 2**，右侧 **miter limit 8**。

![PowerPoint 中斜接限制为 2 的斜面顶点和斜接限制为 8 的尖锐顶点](miter-limits.png)

## **渐变填充**

渐变填充在形状内混合颜色。此示例使用 [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) 将椭圆填充为从红色到紫色的 45 度线性渐变。通过 [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) 方法在渐变的起点（0）和终点（1）放置颜色点。清除现有的颜色点可确保仅使用这两种颜色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![带渐变填充的椭圆](gradient-fill.png)

如果在导出图像时渐变看起来与 PowerPoint 中不同，请参阅 [Choose a Gradient Rendering Style](/slides/zh/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的前提下选择渲染样式。

### **设置线性渐变角度**

使用 [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) 控制 [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) 填充的方向。角度以度为单位，顺时针递增：`0` 从左至右，`90` 从上至下，`180` 从右至左，`270` 从下至上。支持小数角度。超出 `[0, 360)` 的有限角度会归一化为一圈，例如 `-45` 变为 `315`，`360` 变为 `0`。

此示例创建六个矩形，颜色点在位置 `0`、`0.5`、`1` 处分别为红、绿、蓝。禁用比例缩放，以便在不受矩形比例影响的情况下比较角度。左到右的角度分别为第一行的 `0`、`45`、`90`，第二行的 `135`、`180`、`270`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的结果：

![顶部行的 0、45、90 度线性渐变，底部行的 135、180、270 度线性渐变](linear-gradient-angles.png)

### **使用形状比例缩放线性渐变**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) 接受一个 [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) 值。显式设为 `False` 可在形状比例变化时保持几何渐变角度不变，设为 `True` 则随形状的宽高比例缩放渐变。启用缩放后，在非正方形形状上可见角度可能与分配的角度不同。

下面的示例使用 `45` 度角度和与角度比较相同的颜色点。左列使用 `False`；右列使用 `True`。每列包含一个宽矩形上方一个高矩形。两者起始尺寸相同；更改第二个矩形的宽高展示了在不更改渐变设置的情况下填充如何响应尺寸变化。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint 中的结果，左侧禁用缩放，右侧启用缩放：

![宽高矩形使用 45 度渐变，左侧 LinearGradientScaled 为 False，右侧为 True 的对比图](linear-gradient-scaling.png)

禁用缩放时，对角线色带在两个矩形中保持相同方向。启用缩放时，色带随形状比例拉伸。这有助于在将形状适配为不同尺寸时保持模板的渐变。在正方形上，启用缩放不会改变此 `45` 度渐变的外观。

角度和缩放设置仅适用于线性渐变，不控制 [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) 填充。

### **将角度与渐变方向结合使用**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) 从 [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) 类中选择渐变样式；它并不是数值角度的替代品。对于线性渐变，角落样式可以在不更改通过 [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) 分配的角度的情况下，改变颜色分布的区域。比较角度或缩放时，请保持方向不变。

下面的示例以相反的顺序应用相同的设置。两个矩形的外观相同：先设置方向后设置角度或相反顺序均不改变结果。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **图案填充**

图案填充使用两色设计，如点、条纹或格子。此示例使用 [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) 选择格子图案。通过 [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) 提供浅灰背景，使用 [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) 提供黄色图案颜色。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

图片填充在形状内部使用图像。此示例需要本地图片，并使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) 将其加载到演示文稿的图像集合中。将 [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) 设置为平铺模式，可在矩形内重复图像。下面显示使用的源图片：

![莲花图片](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![带图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果想将平铺图片设为纹理并自定义平铺行为，可使用 [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) 类的以下方法：

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode)：设置图片填充模式——`Tile` 或 `Stretch`。
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment)：指定平铺在形状内的对齐方式。
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip)：控制平铺是否水平、垂直或同时翻转。
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX)：设置平铺相对于形状原点的水平偏移（以磅为单位）。
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY)：设置平铺相对于形状原点的垂直偏移（以磅为单位）。
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX)：定义平铺的水平比例（百分比）。
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY)：定义平铺的垂直比例（百分比）。

此示例需要本地图片，并将 [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) 配置为以原始大小的 50% 重复。`-32` 磅的偏移在水平和垂直方向上移动平铺；右下对齐并在两个方向上翻转决定了重复纹理的排列方式。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![平铺选项截图](tile-options.png)

## **纯色填充**

纯色填充为形状赋予单一、统一的颜色。此示例使用 [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) 选择纯色填充模式，并通过 [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) 分配黄色，然后将矩形保存到演示文稿中。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![带纯色填充的形状](solid-color-fill.png)

### **在保留主题引用的同时复制颜色**

使用 [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) 复制颜色定义，包括颜色类型、主题引用和变换。这在将填充颜色在应继续遵循演示文稿主题的形状之间转移时非常有用。此方法仅复制颜色本身；不会复制填充类型、轮廓或其他形状格式。请使用 [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) 显式设置目标的填充类型。

此示例创建三个矩形，从左到右依次为：源、主题感知的副本以及固定 RGB 副本。源使用 [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) 引用第一个强调色，并通过 [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add) 添加色调。RGB 副本使用源的有效填充颜色，因此最初三个看起来完全相同。调用 [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) 设置固定 RGB 值并清除任何现有的颜色变换。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // 主题引用遵循新的强调颜色；固定的 RGB 值则不会。
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

主题更改前，三个填充均匹配：

![源、copyFrom 目标和固定 RGB 目标的相同蓝色填充](color-copy-before.png)

主题更改后，源和主题感知的副本遵循新强调色并保留其色调。固定 RGB 副本仍保持蓝色：

![源和 copyFrom 目标呈橙色填充，而固定 RGB 目标保持蓝色](color-copy-after.png)

复制的定义独立于源。随后更改源的主题引用、分配其他颜色或添加/删除其变换都不会影响目标。主题更改仍会影响两个形状，因为它们各自独立引用相同的主题颜色。

保存并重新打开 PPTX 会保留通过 [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType) 返回的颜色类型、主题引用以及通过 [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform) 返回的变换集合；不会将定义展平为 RGB。

在不同主题上下文之间复制（例如具有不同强调色板的演示文稿）时，复制的引用会针对目标的主题解析。因此，相同的引用和变换可能会产生不同的可见颜色。有关配置主题颜色的更多信息，请参阅 [Presentation Theme](/slides/zh/nodejs-java/presentation-theme/)。

## **使用幻灯片背景作为形状填充**

当形状应匹配幻灯片背景（例如在演示模板中）时，使用 [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill)。首先通过 [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) 将填充类型设为 [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 以移除任何显式填充。使用此组合，形状将使用幻灯片背景而非其样式填充。仅启用该标志并不会移除已存在的显式填充。

这与 [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) 不同：背景填充会用对应的幻灯片背景区域覆盖形状后面的对象，而无填充则保持这些对象可见。渐变仍与幻灯片对齐，而不是在每个形状内部重新开始。

以下示例创建一个由母版继承的背景，并在三个矩形后面放置一条品红色带。左侧矩形使用背景填充，中间矩形无填充，右侧矩形从背景填充切换为显式橙色填充。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // 从母版继承渐变。
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // 首先添加此对象，使其位于矩形后面。
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // 在应用显式填充前禁用背景填充。
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果从左到右：**背景填充**、**无填充** 和 **显式填充**。品红色带被左侧和右侧矩形遮挡，但在中间矩形下仍可见。

![背景填充、无填充和显式橙色填充覆盖在品红色带上](background-fill.png)

相同的行为适用于直接定义在幻灯片上的背景或从布局继承的背景。形状使用解析后的幻灯片背景；示例未对幻灯片和布局背景进行定义，以便使用母版提供的背景。

## **设置透明度**

对于纯色填充，颜色的 alpha 分量控制不透明度：0 完全透明，255 完全不透明。此示例将 alpha 值设为 128，为黄色矩形提供约 50% 透明度，使其下方的矩形仍可见。颜色通过 [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) 分配。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![透明形状](shape-transparency.png)

## **旋转形状**

使用 [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) 在幻灯片平面上旋转形状。角度以度为单位；此示例将矩形顺时针旋转 5 度并保存演示文稿。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

使用 [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) 为形状添加深度和倾斜边缘。此示例创建一个绿色椭圆，橙色轮廓，使用 [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) 将深度设为 4 磅，并通过 [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) 将顶部倾斜设置为宽高均为 6 磅的圆形。正视正交摄像机和三点照明使倾斜可见。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![3D 倾斜效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

形状的 3D 视图由其摄像机设置控制。此示例使用 [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) 将纬度、经度和旋转角度分别设为 40、35、20 度。通过 [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) 选择等轴摄像机，并通过 [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) 选择平衡照明，然后保存格式化的矩形。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果如下：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) 方法指定在以黑白模式查看或处理演示文稿时，单个形状的渲染方式。它本身不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用 [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) 类中的值选择所需行为。例如，`Automatic` 让渲染应用自行选择转换，`Gray` 和 `LightGray` 使用灰度，`BlackWhite` 仅使用黑白，`Black` 与 `White` 强制单色，`Color` 保持正常彩色，`Hidden` 在黑白模式下省略该形状，`NotDefined` 表示未分配形状级别的模式。

此示例创建一个橙色矩形，并使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) 选择灰度着色。保存的形状在正常彩色显示下保持橙色填充，在遵循黑白显示设置的应用程序中请求灰度着色：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在正常彩色模式下，矩形保持橙色填充。在黑白显示工作流中，由于其模式设置为 `Gray`，因此使用灰度着色。这使您在保留全彩幻灯片的同时，为打印、预览或其他遵循演示文稿黑白显示设置的工作流定义不同的外观。

## **重置格式**

使用 [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) 将幻灯片占位符的位置、大小和格式恢复为其对应布局占位符的设置。此示例需要一个已有布局关联占位符的演示文稿，并在保存前重置每张幻灯片。没有对应布局占位符的形状不会被重置。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**形状格式化会影响最终演示文稿的文件大小吗？**

颜色、线条样式和效果设置相对于嵌入的图像和媒体一般只会增加少量数据。图片填充可能会增加文件大小，因为其图像会存储在演示文稿中。

**如何检测幻灯片上具有相同格式的形状以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为相同样式，可在逻辑上将这些形状分组，从而简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重用吗？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。创建新演示文稿时，打开模板，克隆所需的样式形状，并在需要的地方重新应用其格式。