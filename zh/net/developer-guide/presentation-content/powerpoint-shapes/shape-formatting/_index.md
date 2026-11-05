---
title: 在 .NET 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 形状线条草图
- 格式化接合样式
- 渐变填充
- 图案填充
- 图片填充
- 纹理填充
- 纯色填充
- 形状透明度
- 黑白形状渲染
- 灰度形状渲染
- 旋转形状
- 3D 倒角效果
- 3D 旋转效果
- 重置格式化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 C# 和 Aspose.Slides 在 PowerPoint 中格式化形状——精确且完全控制地为 PPT 和 PPTX 文件设置填充、线条和效果样式。"
---
## **介绍**

通过调整轮廓、填充和效果来格式化 PowerPoint 中的形状。Aspose.Slides for .NET 让您能够以编程方式控制这些设置，包括透明度、旋转和 3D 格式化。

![PowerPoint 中的形状格式选项](format-shape-powerpoint.png)

Aspose.Slides for .NET 提供的接口和属性允许您使用 PowerPoint 中相同的选项来格式化形状。

## **格式化线条**

使用[IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)来控制形状的轮廓。本示例创建一个未填充的矩形，使用蓝色、虚线轮廓。[ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) 选择粗细复合线，而[ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) 将宽度设置为 7 磅，且[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 选择虚线模式。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

结果：

![演示文稿中的格式化线条](formatted-lines.png)

### **设置自定义线条虚线模式**

当预定义的线条样式无法提供所需的虚线长度和间隙时，例如用于品牌轮廓或技术图表，可使用[ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/)。分配模式会自动将[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 设置为[LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)。

数组条目在虚线和间隙长度之间交替，以虚线开始。每个值都是线宽的倍数：在宽度为 3 磅时，`{ 4, 2 }` 产生 12 磅的虚线，随后是 6 磅的间隙。使用成对的有限、非负值来定义完整的虚线‑间隙段。本示例使用正值，以确保每段虚线和间隙均可见。

本示例创建五条相同长度且端点为平头的蓝色线。前三条在宽度为 3 磅时比较不同的模式。第四条在宽度加倍（6 磅）时重复第一种模式，从而将虚线和间隙长度均加倍。第五条将自定义模式切换为实线。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Return the last line to a solid style.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

如需返回预定义的虚线样式，只需将[LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) 分配给[ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/)。所选样式控制线条的外观。

PowerPoint 中从上到下的结果为：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三个自定义虚线模式、使用第一种模式的更宽线条以及实线](custom-dash-patterns.png)


### **设置线条端点样式**

使用[ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/)来设置开放线条的端点。[LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) 枚举提供三种显式端点样式：

- `Flat`：笔画在端点处停止。
- `Round`：半圆形端点在端点之外延伸半个线宽。
- `Square`：方形端点在端点之外延伸半个线宽。

枚举还包括 `NotDefined`，表示未显式分配端点样式。

端点样式不同于箭头（在端点添加符号）和接合点（控制线段之间的拐角）。本示例通过[ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/)和[ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/)禁用箭头，以便仅比较端点形状。

以下示例创建三条在其他方面相同的水平线，宽度为 20 磅。从上到下，它们分别使用平头、圆头和方头。它们的端点具有相同的水平坐标；圆头和方头在每个端点之外延伸 10 磅。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

PowerPoint 中从上到下的结果为：**Flat**、**Round** 和 **Square**。

![PowerPoint 中相同粗线的平头、圆头和方头端点](line-caps.png)

## **对形状线条应用草图效果**

草图效果使形状线条看起来像手绘。使用[IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)访问线条设置，使用[ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/)访问草图设置，并通过[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/)从[LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 枚举中选择值。

下面的 C# 代码演示如何应用[LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 效果、读取显式分配的值以及使用[LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) 移除效果：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

[ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或布局幻灯片继承，请使用[ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)，访问[ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)，并读取[ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)。有效值反映在继承解析后实际应用的格式。本示例需要一个现有的演示文稿，其第一张幻灯片上至少有一个形状，并打印两个值：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **格式化接合样式**

以下是三种接合类型选项：

* Round
* Miter
* Bevel

接合样式控制两个轮廓段在拐角处的连接方式。使用 **Round** 可得到圆角，**Miter** 可得到尖角，**Bevel** 可得到平直的拐角。

![演示文稿中的接合样式](join-style-powerpoint.png)

本示例创建三个黑色矩形，蓝色轮廓宽度为 15 磅。它分别将[ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 设置为[LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 的斜接、斜面和圆形值，以比较拐角的绘制效果。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **在尖角处限制斜接接合**

将[ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) 与[ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) 设置为[LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) 可限制尖角的伸展距离。

该限制是接合内外拐角之间距离与线宽的比例。例如，值 `8` 允许斜接长度最多为线宽的八倍；它不是以磅为单位的测量。如果拐角超过此限制，PowerPoint 会在该拐角使用斜面接合。更大的限制会产生更尖的角度。此设置仅影响斜接接合，当拐角仍在限制范围内时更改设置不会产生可见效果。

本示例创建两个相同的无填充三角形，轮廓宽度为 20 磅。左侧三角形使用限制 `2`，右侧使用 `8`。每个三角形宽 80 磅，高 160 磅，使其顶部拐角的斜接长度与线宽比例约为 `4.12`。因此，PowerPoint 对左侧顶点使用斜面，而保留右侧顶点的尖角。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

PowerPoint 中的结果：左侧为 **斜接限制 2**，右侧为 **斜接限制 8**。

![PowerPoint 中斜接限制 2 的斜面顶点和斜接限制 8 的尖锐顶点](miter-limits.png)

## **渐变填充**

渐变填充在形状内部混合颜色。本示例使用[IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) 将椭圆填充为从红色到紫色、45 度角的线性渐变。[IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) 方法在 0 和 1（渐变的起始和结束位置）处放置颜色停止。清除现有的停止确保仅使用这两种颜色。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

结果：

![带有渐变填充的椭圆](gradient-fill.png)

如果导出图像中的渐变与 PowerPoint 中显示的不同，请参阅[选择渐变渲染样式](/slides/zh/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的情况下选择渲染样式。

### **设置线性渐变角度**

使用[IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 控制[GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填充的方向。角度以度数计，并顺时针递增：`0` 从左到右，`90` 从上到下，`180` 从右到左，`270` 从下到上。支持小数角度。超出 `[0, 360)` 的有限角度会归一化为一圈，例如 `-45` 变为 `315`，`360` 变为 `0`。

本示例创建六个矩形，颜色停止点在 `0`、`0.5`、`1` 位置分别为红、绿、蓝。关闭缩放以便在不受矩形比例影响的情况下比较角度。左到右的角度分别为 `0`、`45`、`90`（第一行），以及 `135`、`180`、`270`（第二行）。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

PowerPoint 中的结果：

![顶部行的 0、45、90 度线性渐变，底部行的 135、180、270 度线性渐变](linear-gradient-angles.png)

### **使用形状缩放线性渐变**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) 接受[NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) 值。将其显式设为 `False` 可在形状比例改变时保持几何渐变角度不变，设为 `True` 则随形状宽高缩放渐变。启用缩放后，在非正方形形状上可见角度可能与分配的角度不同。

下面的示例使用 `45` 度角和与角度比较相同的颜色停止。左列使用 `False`，右列使用 `True`。每列包含一个宽矩形上方和一个高矩形下方。两个矩形起始宽度相同；改变第二个矩形的宽高演示了填充在调整大小时的响应，而不改变其渐变设置。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

PowerPoint 中的结果，左侧禁用缩放，右侧启用缩放：

![宽矩形和高矩形的 45 度渐变，左侧 LinearGradientScaled 为 False，右侧为 True](linear-gradient-scaling.png)

禁用缩放时，斜向色带在两个矩形中保持相同方向。启用缩放后，色带随形状比例拉伸。这有助于在将形状适配为不同尺寸时重现模板的渐变。在正方形上，启用缩放不会改变此 `45` 度渐变的外观。

角度和缩放设置均适用于线性渐变。它们不控制[GradientShape.Radial 或 GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) 填充。

### **将角度与渐变方向结合**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) 从[GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) 枚举中选择渐变样式；它并不是数值角度的替代品。对于线性渐变，角的样式可以在不更改[LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) 的情况下改变颜色分布的区域。在比较角度或缩放时保持方向不变。

下面的示例以相反的顺序应用相同设置。两个矩形呈现相同外观：先设置方向后设置角度或相反都不会改变结果。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **图案填充**

图案填充使用两种颜色的设计，例如点、条纹或格子。本示例使用[IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) 选择格子图案。[IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) 提供浅灰色背景，而[IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) 提供黄色图案颜色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

结果：

![带有图案填充的矩形](pattern-fill.png)

## **图片填充**

图片填充在形状内部使用图像。本示例需要本地图像，并使用[Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) 将其加载到演示文稿的图像集合中。将[IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) 设置为平铺模式，可在矩形内重复图像。下面显示使用的源图像：

![莲花图片](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

结果：

![带有图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果希望将平铺图片设为纹理并自定义平铺行为，可使用[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 接口和[PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) 类的以下属性：

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/)：设置图片填充模式——`Tile` 或 `Stretch`。
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/)：指定平铺在形状内的对齐方式。
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/)：控制平铺是水平翻转、垂直翻转还是两者皆翻转。
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/)：设置平铺相对于形状原点的水平偏移（单位：磅）。
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/)：设置平铺相对于形状原点的垂直偏移（单位：磅）。
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/)：以百分比定义平铺的水平缩放。
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/)：以百分比定义平铺的垂直缩放。

本示例需要本地图像，并将[IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) 配置为以原始尺寸的 50% 重复。`-32` 磅的偏移将平铺在水平和垂直方向上移动；右下对齐并在两个方向上翻转决定了重复纹理的布局方式。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

结果：

![平铺选项](tile-options.png)

## **纯色填充**

纯色填充为形状提供单一、均匀的颜色。本示例将[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 设置为纯色填充模式，并通过[IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 赋予黄色，然后将矩形保存到演示文稿中。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

结果：

![带有纯色填充的形状](solid-color-fill.png)

### **在保留主题引用的情况下复制颜色**

使用[IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) 可复制颜色定义，包括颜色类型、主题引用和转换。这在将填充颜色在应继续遵循演示文稿主题的形状之间转移时非常有用。该方法仅复制颜色本身；不会复制填充类型、轮廓或其他形状格式。请显式设置目标的[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/)。

本示例创建三个矩形，从左到右依次为：源、主题感知的复制以及固定的 RGB 复制。源使用[IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) 引用第一个强调色，并通过[IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/) 添加色调。RGB 复制使用源的有效填充颜色，因此最初三个矩形看起来相同。为[IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) 分配固定的 RGB 值会清除任何现有的颜色转换。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

在主题更改之前，所有三个填充均匹配：

![源、CopyFrom 目标和固定 RGB 目标的相同蓝色填充](color-copy-before.png)

主题更改后，源和主题感知的复制遵循新的强调色并保留其色调。固定的 RGB 复制保持蓝色：

![源和 CopyFrom 目标为橙色填充，固定 RGB 目标仍为蓝色](color-copy-after.png)

复制的定义独立于源。随后更改源的主题引用、分配其他颜色或添加/删除其转换，都不会影响目标。主题更改仍会影响两个形状，因为它们各自独立引用相同的主题颜色。

保存并重新打开 PPTX 会保留复制颜色的[IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/)、主题引用和[IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) 集合；不会将定义展平成 RGB。

在不同主题上下文之间复制时，例如在具有不同强调调色板的演示文稿之间，复制的引用会依据目标的主题进行解析。因此相同的引用和转换可能产生不同的可见颜色。详见[演示文稿主题](/slides/zh/net/presentation-theme/) 以了解更多主题颜色配置。

## **将幻灯片背景用作形状填充**

当形状应匹配幻灯片背景（例如在演示模板中）时，请使用[IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/)。首先将[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) 设置为[FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 以移除任何显式填充。使用此组合后，形状将使用幻灯片背景而非其样式填充。仅启用此标志并不会移除已有的显式填充。

这与[FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) 不同：背景填充会用幻灯片相应区域的背景覆盖形状后面的对象，而无填充则让这些对象保持可见。渐变仍然与幻灯片对齐，而不是在每个形状内部重新开始。

下面的示例创建一个由母版继承的背景，并在三个矩形后面放置一条品红色带。左侧矩形使用背景填充，中间矩形无填充，右侧矩形则从背景填充切换为显式的橙色填充。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// 从母版继承渐变。
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// 首先添加此对象，使其位于矩形后面。
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// 在应用显式填充之前禁用背景填充。
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

结果，从左到右依次为：**背景填充**、**无填充**和**显式填充**。品红色带被左侧和右侧矩形遮挡，但在中间矩形后仍可见。

![背景填充、无填充和显式橙色填充覆盖的品红色带](background-fill.png)

相同的行为也适用于直接在幻灯片上定义或从布局继承的背景。形状使用解析后的幻灯片背景；本示例将幻灯片和布局背景均留空，以便由母版提供。

## **设置透明度**

对于纯色填充，颜色的 alpha 分量控制不透明度：0 为完全透明，255 为完全不透明。本示例使用 alpha 值 128 为黄色矩形设置约 50% 的透明度，使其下方的矩形仍然可见。颜色通过[IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) 赋予。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

结果：

![透明形状](shape-transparency.png)

## **旋转形状**

使用[IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 可在幻灯片平面上旋转形状。角度以度数计；本示例将矩形顺时针旋转 5 度并保存演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倒角效果**

使用[IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 为形状添加深度和倒角边缘。本示例创建一个绿色椭圆，橙色轮廓，将[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) 设置为 4 磅，并通过[IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) 将顶部圆形倒角的宽度和高度设为 6 磅。前视正投影相机和三点光源使倒角可见。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

结果：

![3D 倒角效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

形状的 3D 视图由相机设置控制。本示例使用[ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) 将纬度、经度和旋转角度分别设为 40、35 和 20 度。通过[ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 选择等轴相机，并通过[ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) 选择平衡光照，然后保存已格式化的矩形。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 属性指定在以黑白模式查看或处理演示文稿时，单个形状的渲染方式。它本身不会启用黑白显示，也不会在普通彩色模式下更改形状的填充、线条或其他格式。

使用[BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) 枚举中的值选择所需行为。例如，`Automatic` 让渲染应用自行选择转换，`Gray` 和 `LightGray` 使用灰度，`BlackWhite` 仅使用黑白，`Black` 和 `White` 强制使用单一颜色，`Color` 保持正常着色，`Hidden` 在黑白模式下省略形状。`NotDefined` 表示未分配任何形状级别的模式。

本示例创建一个橙色矩形，并将[IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) 设置为灰色。保存的形状在普通彩色显示下保持橙色填充，但在尊重黑白显示设置的应用程序中请求灰色渲染：

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

在普通彩色模式下，矩形保留橙色填充。在黑白显示工作流中，由于模式设置为 `Gray`，它会使用灰色渲染。这使您能够在保留完整彩色幻灯片的同时，为打印、预览或其他遵循演示文稿黑白显示设置的工作流定义不同的外观。

## **重置格式化**

使用[ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) 可将幻灯片占位符的位置、大小和格式恢复为其对应布局占位符的设置。本示例需要一个已有布局占位符的演示文稿，并在保存前重置每张幻灯片。没有对应布局占位符的形状不会被重置。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **常见问题**

**形状格式化会影响最终演示文稿的文件大小吗？**

颜色、线条样式和效果设置相对于嵌入的图像和媒体通常只会增加少量数据。图片填充可能会增加文件大小，因为其图像会存储在演示文稿中。

**如何检测幻灯片上共享相同格式的形状，以便对其进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视为样式相同，可逻辑上将这些形状分组，这有助于后续的样式管理。

**我可以将一套自定义形状样式保存为单独的文件，以便在其他演示文稿中重用吗？**

可以。将具有所需样式的示例形状存储在模板幻灯片稿或 .POTX 模板文件中。创建新演示文稿时，打开模板，克隆所需的样式形状，并在需要的地方重新应用其格式。