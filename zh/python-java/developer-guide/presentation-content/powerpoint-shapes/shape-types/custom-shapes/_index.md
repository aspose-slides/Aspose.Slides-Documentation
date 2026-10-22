---
title: 通过 Java 的 Python 定制演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/python-java/custom-shape/
keywords:
- 自定义形状
- 添加形状
- 创建形状
- 更改形状
- 形状几何
- 几何路径
- 路径点
- 编辑点
- 添加点
- 移除点
- 编辑操作
- 圆角
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、圆角、复合形状。"
---
## **概述**

本文说明如何通过编辑点和几何路径编辑形状几何，从而在 Aspose.Slides 中自定义演示文稿形状。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 来修改现有形状、执行基本路径编辑操作、添加或删除点，并将更新后的几何应用回形状。

此外，还演示了如何创建自定义和复合形状、构建带圆角的形状、判断形状几何是否闭合、检查形状元素，以及将 Java AWT 文本轮廓转换为几何路径。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用 **编辑点** 来修改正方形：

* 将角向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点让您可以修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

编辑 PowerPoint 形状时，请记住以下概念：

* 形状（或其路径）可以是闭合的也可以是打开的。
* 形状的路径由锚点和段组成，锚点通过段相连。
* 段可以是直线或曲线。锚点和控制柄决定其形状。
* 锚点有三种类型：拐角点、直线点或平滑点：
  * 在拐角点，邻近的段可以形成一个角度。
  * 在平滑点，两个控制柄对齐且与锚点的距离相等。
  * 在直线点，两个控制柄对齐但距离可以不同。
* 移动锚点或调整其柄会改变形状的轮廓。

为了通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 实例表示 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 对象的几何路径。
* 要从 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)，可以使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)，可以使用以下方法：单路径形状使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath)；多路径形状使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 要添加段，可使用 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 下的相应方法。
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) 和 [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 方法，可设置几何路径的外观。
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) 方法，可将 [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) 的几何路径检索为路径段数组。
* 若要访问更多形状几何自定义选项，可通过其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 读取 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)，并在 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 上重放这些段。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径的段数组中零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| 追加或插入带两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 追加或插入带一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 追加具有指定尺寸和角度（单位为度）的椭圆弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| 通过将端点连接到起点来关闭当前图形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| 设置图形的起始点。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| 删除零基索引处的段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **向形状添加自定义点**

此示例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) 向矩形形状插入两个点，并使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 应用编辑后的路径。坐标相对于形状：两个新点位于形状中心，左侧 100 点、顶部 50 点。段索引 1 和 4 将它们分别放在顶部和底部边缘，向内拉动这些边缘。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用 [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) 删除零基索引 2 处的段，来更改心形轮廓。使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 应用修改后的路径后，形状的轮廓得到更新。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 构建一个五角星。交替的外半径 100 点和内半径 50 点定义了星尖和凹陷；72 度的步进使五个星尖均匀分布。路径使用 [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) 关闭，并使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 应用于矩形形状，替换其轮廓。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一分别定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 对象。使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 同时应用两个路径，可创建一个在中部三分之一有间隙的单一复合形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **创建带圆角的自定义形状**

此示例将直线段与 [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) 结合，创建一个具有内凹圆角的形状。每个角的大小以点为单位设置弧的宽度和高度，-90 度的扫过角度绘制逆时针四分之一椭圆。完成的路径使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 应用，并将演示文稿保存为 PPTX 格式。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **判断形状几何是否闭合**

下面的辅助方法检查每个非空几何路径是否以闭合段结束。它读取 [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData)，并将最终段的 [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) 与 [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) 进行比较。当没有非空路径时返回 `False`。该检查仅针对每条路径的最终命令，不会检查路径内部的每个子图形。示例对矩形输出 `True`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **提取并检查形状元素**

使用 [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) 可将现有形状检查为包含路径点和点类型的元素。将每个返回的元素强制转换为 [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/)（使用 `jpype.JObject`），即可通过 [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) 和 [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) 方法获取点数组和类型数组。这种表示方式适用于轮廓分析或将几何传递给自定义绘图工具。

示例打开 `input.pptx`，在第一张幻灯片上直接找到第一个几何形状，并打印其路径段。使用包含直线和曲线段的形状进行测试，以看到两种输出。该示例不在组内部搜索。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

数组通过索引对应：`points[i]` 为一个点，`types[i]` 描述其角色。类型 `0` 表示开始一个图形，类型 `1` 表示从前一点绘制直线到当前点。三次 Bézier 段从前一个终点开始，使用连续的三个类型为 `3` 的条目：两个控制点后跟新的终点。循环一次性消费这三个条目，并检查终点是否闭合。

点类型还包含标志位。使用 `0x07` 掩码可识别段类型，单独检测 `0x80` 可判断闭合子路径。例如，`129`（`0x81`）表示闭合子路径的线段终点，`131`（`0x83`）表示闭合的 Bézier 终点。Java 将这些标志存储在有符号字节中；进行掩码操作可保留预期的位值。仅与 `1` 或 `3` 比较原始值会遗漏这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不会改变基础段类型。

**坐标与变换。** 点的单位为 point（1/72 英寸），X 向右递增，Y 向下递增。对于未分组的形状，提取的坐标已包含由 [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) 和 [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) 返回的位置，并反映其当前宽高。例如，未旋转的矩形位于 `(100, 200)`，尺寸为 `120 × 80`，其轮廓边界为 `(100, 200)`–`(220, 280)`。不要再次添加形状的位置。减去其 X 与 Y 可得到相对于未旋转框架的坐标。

提取的点不考虑由 [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) 返回的旋转，也不考虑水平和垂直翻转。要还原显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还必须考虑组坐标映射和变换；不要假设提取的点已经是最终渲染的幻灯片坐标，亦不要对已在子框架中体现的平移或缩放再做一次。

**检查 vs. 编辑。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。当您的分析或绘图代码需要点/类型数组时请选择此方式。若需要在形状本地坐标系中获取几何命令或编辑其几何，请使用 [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths)。通过 [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 应用编辑后的路径。

## **将 Java AWT Shape 转换为 GeometryPath**

此示例将矩形轮廓与转换后的文本轮廓组合。轮廓的 [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) 方法关闭了填充。一个 [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中创建文本轮廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 提供移动、直线、二次、三次和闭合段，示例将这些段重放到 [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) 上。

文本使用 40 点 Arial 字体。轮廓水平偏移 20 点，且其可视顶部位于形状顶部以下 10 点。文本路径被填充，而原始矩形保持为轮廓。通过 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) 同时应用两条路径，生成包含矩形和文本的单一形状。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 获取形状的几何路径。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 创建带文本的新图形路径。
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # 将图形路径转换为几何路径。
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # 将文本路径与原始几何路径一起应用。
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **常见问题解答**

**替换几何后，填充和轮廓会怎样？**

样式仍然保留在形状上，仅轮廓发生变化。填充和轮廓会自动应用到新的几何上。

**如何在几何一起旋转自定义形状？**

使用形状的 [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) 方法；几何会随形状一起旋转，因为它绑定到形状自身的坐标系。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/python-java/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/python-java/create-shape-thumbnails/) 本身导出为栅格格式，这会简化对复杂几何的后续处理。