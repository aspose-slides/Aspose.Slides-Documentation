---
title: 在 Python 中格式化 PowerPoint 形状
linktitle: 形状格式化
type: docs
weight: 20
url: /zh/python-net/shape-formatting/
keywords:
- 格式化形状
- 格式化线条
- 草图效果
- 草图形状线条
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
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中格式化 PowerPoint 形状——精确且全面地为 PPT、PPTX 和 ODP 文件设置填充、线条和效果样式。"
---
## **简介**

通过调整轮廓、填充和效果来对 PowerPoint 中的形状进行格式化。Aspose.Slides for Python via .NET 让您能够以编程方式控制这些设置，包括透明度、旋转和 3D 格式化。

![PowerPoint 中的形状格式化选项](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET 提供的类和属性可让您使用 PowerPoint 中相同的选项对形状进行格式化。

## **格式化线条**

使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 来控制形状的轮廓。本示例创建一个无填充的矩形，使用蓝色虚线轮廓。[LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) 选择粗细复合线，而 [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 将宽度设为 7 磅，[LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 选择虚线模式。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![演示文稿中格式化的线条](formatted-lines.png)

### **设置自定义线条虚线模式**

当预定义的线条样式无法提供所需的虚线长度和间隙时（例如品牌轮廓或技术图表），请使用 [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/)。分配模式后会自动将 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) 设置为 [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。

列表条目在虚线和间隙长度之间交替，首先是虚线。每个值都是线宽的倍数：在宽度为 3 磅时 `[4, 2]` 产生 12 磅的虚线后跟 6 磅的间隙。使用成对的有限、非负值来定义完整的虚线-间隙段。示例使用正值以保持每段虚线和间隙可见。

此示例创建五条相同长度、平头的蓝线。前三条在宽度为 3 磅时比较模式。第四条以两倍宽度重复第一种模式，虚线和间隙长度均加倍。第五条将自定义模式切换为实线。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # 将最后一条线恢复为实线样式。
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

如果要返回预定义的虚线样式，请将 [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) 分配给 [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)。所选样式决定线条的外观。

PowerPoint 中从上到下的结果：**{4, 2}, 3 pt**；**{1, 2}, 3 pt**；**{6, 2, 1, 2}, 3 pt**；**{4, 2}, 6 pt**；以及 **Solid, 3 pt**。

![PowerPoint 中的三种自定义虚线模式、使用第一种模式的更宽线条和实线](custom-dash-patterns.png)

### **设置线帽**

使用 [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) 设置开放线条的端点。[LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) 枚举提供三种显式的帽子样式：

- `FLAT`：笔画在端点处停止。
- `ROUND`：半圆形帽子超出端点半个线宽。
- `SQUARE`：方形帽子超出端点半个线宽。

枚举中还包含 `NOT_DEFINED`，表示未显式分配帽子样式。

帽子不同于箭头（在端点添加符号）和连接（控制线段之间的拐角）。本示例通过 [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) 和 [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) 禁用箭头，以仅比较帽子形状。

以下示例创建三条在其他方面相同的水平线，宽度为 20 磅。从上到下，它们分别使用平帽、圆帽和方帽。它们的端点具有相同的水平坐标，圆帽和方帽在每个端点之外延伸 10 磅。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中从上到下的结果：**Flat**、**Round** 和 **Square**。

![PowerPoint 中相同粗线的平帽、圆帽和方帽](line-caps.png)

## **对形状线条应用草图效果**

草图效果使形状线条看起来像手绘。使用 [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) 访问线条设置，使用 [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) 访问草图设置，使用 [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 从 [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 枚举中选择值。

下面的 Python 代码演示如何应用 [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 效果、读取显式分配的值以及使用 [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) 删除效果：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

[SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) 返回的值表示直接分配给形状的设置。如果线条格式可以从主题、母版幻灯片或版面幻灯片继承，请使用 [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)，访问 [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)，并读取 [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/)。有效值反映了解决继承后实际应用的格式。本示例需要一个已有的演示文稿，其中首张幻灯片至少包含一个形状，并打印两个值：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **格式化连接样式**

以下是三种连接类型选项：

* Round
* Miter
* Bevel

连接样式控制两个轮廓段在拐角处的相交方式。使用 **Round** 可获得圆角，使用 **Miter** 可获得尖角，使用 **Bevel** 可获得平坦角。

![演示文稿中的连接样式](join-style-powerpoint.png)

本示例创建三个蓝色轮廓、宽度为 15 磅的黑色矩形。它将 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 分别设置为 [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) 的斜接、斜角和圆角，以比较拐角的绘制效果。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **在尖角处限制斜接连接**

将 [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) 与 [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) 设置为 [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/) 可限制尖角的伸展距离。

该限制是连接的内外角距离与线宽的比率。例如，值 `8` 允许斜接长度最多为线宽的八倍；这不是以磅为单位的测量。如果拐角超过该限制，PowerPoint 会在该拐角使用斜角连接。更大的限制会产生更尖的角度。此设置仅影响斜接连接，当拐角仍在限制范围内时更改它不会产生可见效果。

本示例创建两个相同的无填充三角形，轮廓宽度为 20 磅。左侧三角形的限制为 `2`，右侧为 `8`。每个三角形宽 80 磅，高 160 磅，使其顶部拐角的斜接长度与线宽比约为 `4.12`。因此，PowerPoint 对左侧顶点使用斜角，对右侧保持尖角。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的结果：左侧 **Miter limit 2**，右侧 **miter limit 8**。

![PowerPoint 中的斜角限制 2 的斜角顶点和斜角限制 8 的尖角顶点](miter-limits.png)

## **渐变填充**

渐变填充在形状内部混合颜色。此示例使用 [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/) 将椭圆填充为 45 度角、从红色到紫色的线性渐变。通过 [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) 方法在渐变的起始（0）和结束（1）位置放置颜色停止。清除现有停止可确保仅使用这两种颜色。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![带渐变填充的椭圆](gradient-fill.png)

如果导出的图像中渐变的显示与 PowerPoint 中不同，请参阅[选择渐变渲染样式](/slides/zh/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style)。您可以在不更改演示文稿中存储的渐变填充的情况下选择渲染样式。

### **设置线性渐变角度**

使用 [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) 控制 [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 填充的方向。角度以度为单位，顺时针递增：`0` 从左到右，`90` 从上到下，`180` 从右到左，`270` 从下到上。支持小数角度。超出 `[0, 360)` 的有限角度会规范化为一整圈，例如 `-45` 变为 `315`，`360` 变为 `0`。

本示例创建六个矩形，颜色停止在位置 `0`、`0.5`、`1` 处均为红、绿、蓝。禁用缩放以便在不受矩形比例影响的情况下比较角度。角度从左到右依次为 `0`、`45`、`90`（第一行），以及 `135`、`180`、`270`（第二行）。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的结果：

![顶部行的 0、45、90 度线性渐变，底部行的 135、180、270 度线性渐变](linear-gradient-angles.png)

### **随形状缩放线性渐变**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) 接受一个 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 值。显式设为 `FALSE` 可在形状比例变化时保持几何渐变角度不变，设为 `TRUE` 则随形状的宽高缩放渐变。启用缩放后，在非正方形形状上可见角度与指定角度不同。

下面的示例使用 `45` 度角和与角度比较相同的颜色停止。左列使用 `FALSE`，右列使用 `TRUE`。每列包含一个宽矩形上方一个高矩形。两者起始宽度相同；改变第二个矩形的宽高演示填充在调整大小时的响应，而不改变渐变设置。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint 中的结果，左侧关闭缩放、右侧开启缩放：

![宽矩形和高矩形的 45 度渐变，左侧 linear_gradient_scaled 为 FALSE，右侧为 TRUE 的比较](linear-gradient-scaling.png)

关闭缩放时，对角色带在两个矩形中保持相同方向。开启缩放时，色带会随形状比例拉伸。这有助于在将形状适配为不同尺寸时复现模板的渐变。在正方形上，启用缩放不会改变此 `45` 度渐变的外观。

角度和缩放设置均适用于线性渐变。它们不控制 [GradientShape.RADIAL] 或 [GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) 填充。

### **将方向与渐变角度结合使用**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) 从 [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) 枚举中选择渐变样式；它不是数值角度的替代品。对于线性渐变，角落样式可以在不更改 [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) 的情况下改变颜色分布的区域。比较角度或缩放时请保持方向不变。

下面的示例以相反的顺序应用相同设置。两个矩形的外观相同：先设方向再设角度或先设角度再设方向都不会改变结果。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **图案填充**

图案填充使用两种颜色的设计，例如点、条纹或格子。本示例使用 [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) 选择格子图案。[PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) 提供浅灰色背景，[PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) 提供黄色图案颜色。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![带图案填充的矩形](pattern-fill.png)

## **图片填充**

图片填充在形状内部使用图像。本示例需要本地图片，并使用 [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) 将其加载到演示文稿的图像集合中。将 [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) 设置为平铺模式，可在矩形内重复图像。下面显示的源图像如下：

![莲花图片](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![带图片填充的形状](picture-fill.png)

### **将图片平铺为纹理**

如果希望将平铺图片设为纹理并自定义平铺行为，可使用 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 类的以下属性：

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/)：设置图片填充模式——`TILE` 或 `STRETCH`。
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/)：指定平铺在形状内的对齐方式。
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/)：控制平铺是否水平、垂直或同时翻转。
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/)：设置平铺相对于形状原点的水平偏移（磅）。
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/)：设置平铺相对于形状原点的垂直偏移（磅）。
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/)：定义平铺的水平缩放百分比。
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/)：定义平铺的垂直缩放百分比。

本示例需要本地图片，并将 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 配置为以原始尺寸的 50% 重复。`-32` 磅的偏移将平铺水平和垂直移动；右下对齐并在两个方向翻转决定了重复纹理的排列方式。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![平铺选项](tile-options.png)

## **纯色填充**

纯色填充为形状赋予单一、均匀的颜色。此示例将 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为纯色填充模式，并通过 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 分配黄色，然后在演示文稿中保存矩形。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![带纯色填充的形状](solid-color-fill.png)

### **复制颜色并保留主题引用**

使用 [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/) 复制颜色定义，包括其颜色类型、主题引用和变换。这在将填充颜色在应继续遵循演示文稿主题的形状之间转移时非常有用。该方法仅复制颜色本身：不会复制填充类型、轮廓或其他形状格式。请显式设置目标的 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)。

本示例创建三个矩形，左到右分别为：源、感知主题的副本和固定 RGB 副本。源使用 [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) 引用第一强调色，并通过 [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/) 添加色调。RGB 副本使用源的有效填充颜色，因此最初三者看起来完全相同。分配 [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) 可设置固定的 RGB 值并清除任何现有的颜色变换。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # 主题引用遵循新的强调色；固定的 RGB 值则不受影响。
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

主题更改前，所有三种填充都匹配：

![源、copy_from 目标和固定 RGB 目标的相同蓝色填充](color-copy-before.png)

主题更改后，源和感知主题的副本遵循新的强调色并保留其色调。固定 RGB 副本仍保持蓝色：

![源和 copy_from 目标为橙色填充，固定 RGB 目标保持蓝色](color-copy-after.png)

复制的定义独立于源。随后更改源的主题引用、分配其他颜色或添加/删除其变换都不会影响目标。主题更改仍会影响两个形状，因为它们各自独立引用相同的主题颜色。

保存并重新打开 PPTX 会保留已复制颜色的 [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/)、主题引用和 [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) 集合；不会将定义展平为 RGB。

在不同主题上下文之间复制（例如不同强调色调色板的演示文稿）时，复制的引用会相对于目标的主题解析。因此相同的引用和变换可能产生不同的可见颜色。有关配置主题颜色的更多信息，请参阅[演示文稿主题](/slides/zh/python-net/presentation-theme/)。

## **将幻灯片背景用作形状填充**

当形状应匹配幻灯片背景（如在演示文稿模板中）时，使用 [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/)。首先将 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为 [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，以移除任何显式填充。使用此组合，形状将使用幻灯片背景而非其样式填充。仅启用此标志并不会删除已有的显式填充。

这与 [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) 不同：背景填充会用幻灯片背景的相应区域覆盖形状后面的对象，而无填充则保留这些对象可见。渐变仍然相对于幻灯片对齐，而不是在每个形状内部重新开始。

下面的示例创建一个由母版继承的背景，并在三个矩形后面放置一条品红色带。左矩形使用背景填充，中矩形无填充，右矩形从背景填充切换为显式的橙色填充。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # 继承母版的渐变。
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # 首先添加此对象，使其出现在矩形后面。
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # 在应用显式填充之前禁用背景填充。
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

结果从左到右分别为：**背景填充**、**无填充**、**显式填充**。品红色带在左、右矩形后面被遮挡，但在中间矩形下仍可见。

![背景填充、无填充和显式橙色填充覆盖在品红色带上](background-fill.png)

相同的行为适用于直接在幻灯片上定义的背景或从版面继承的背景。形状使用已解析的幻灯片背景；本示例未在幻灯片和版面上定义背景，以便由母版提供。

## **设置透明度**

对于纯色填充，颜色的 alpha 分量控制不透明度：0 表示完全透明，255 表示完全不透明。本示例对黄色矩形使用 alpha 值 128，使其约 50% 透明，从而下面的矩形仍然可见。颜色通过 [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) 分配。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![透明的形状](shape-transparency.png)

## **旋转形状**

使用 [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 在幻灯片平面上旋转形状。角度以度为单位；本示例将矩形顺时针旋转 5 度并保存演示文稿。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![形状旋转](shape-rotation.png)

## **添加 3D 倾斜效果**

使用 [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) 为形状添加深度和倾斜边缘。本示例创建一个绿色椭圆并使用橙色轮廓，将 [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) 设为 4 磅，并通过 [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) 将顶部圆形倾斜的宽度和高度设为 6 磅。前视正交相机和三点光源使倾斜效果可见。

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![3D 倾斜效果](3D-bevel-effect.png)

## **添加 3D 旋转效果**

形状的 3D 视图由相机设置控制。本示例使用 [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) 设置纬度、经度和旋转角度分别为 40、35、20 度。通过 [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) 选择等轴相机，并通过 [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) 选择平衡光源，然后保存格式化后的矩形。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![3D 旋转效果](3D-rotation-effect.png)

## **控制形状的黑白渲染**

[Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 属性指定在以黑白模式查看或处理演示文稿时，单个形状的渲染方式。它本身并不会启用黑白显示，也不会在正常彩色模式下更改形状的填充、线条或其他格式。

使用来自 [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) 枚举的值选择所需行为。例如，`AUTOMATIC` 让渲染应用程序自行决定转换方式，`GRAY` 和 `LIGHT_GRAY` 使用灰度，`BLACK_WHITE` 仅使用黑白，`BLACK` 和 `WHITE` 强制单色，`COLOR` 保持正常彩色，`HIDDEN` 在黑白模式下省略形状。`NOT_DEFINED` 表示未分配形状级别的模式。

本示例创建一个橙色矩形，并将 [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) 设置为灰色。保存后的形状在正常彩色显示下保持橙色填充，在遵循黑白显示设置的应用程序中请求灰色渲染：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

在正常彩色模式下，矩形保持橙色填充。在黑白显示工作流中，由于模式设置为 `GRAY`，它会使用灰色渲染。这让您在保留全彩幻灯片的同时，为打印、预览或其他遵循黑白显示设置的工作流定义不同的外观。

## **重置格式**

使用 [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) 可将幻灯片占位符的位置、大小和格式恢复为其对应布局占位符的设置。本示例需要一个已有布局占位符的演示文稿，并在保存前重置每张幻灯片。没有对应布局占位符的形状不会被重置。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**形状格式化会影响最终演示文稿的文件大小吗？**

颜色、线条样式和效果设置相对于嵌入的图像和媒体通常只会增加少量数据。图片填充可能会增加文件大小，因为其图像会存储在演示文稿中。

**如何检测幻灯片上共享相同格式的形状，以便对它们进行分组？**

比较每个形状的关键格式属性——填充、线条和效果设置。如果所有对应值匹配，则视其样式为相同，并在逻辑上将这些形状分组，这可以简化后续的样式管理。

**我可以将一组自定义形状样式保存到单独的文件，以便在其他演示文稿中重复使用吗？**

可以。将带有所需样式的示例形状存储在模板幻灯片或 .POTX 模板文件中。在创建新演示文稿时，打开模板，克隆所需的样式形状，并在需要的地方重新应用它们的格式。