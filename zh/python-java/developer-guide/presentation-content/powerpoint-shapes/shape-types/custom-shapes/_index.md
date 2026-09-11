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
- 删除点
- 编辑操作
- 曲线角
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建和定制形状：几何路径、曲线角、复合形状。"
---
## **概述**

本文说明如何通过编辑点和几何路径编辑形状几何，以自定义 Aspose.Slides 中的演示文稿形状。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 修改现有形状、执行基本路径编辑操作、添加或删除点，并将更新后的几何应用回形状。

同时还演示了如何创建自定义和复合形状、构建带曲线角的形状、判断形状几何是否闭合，以及在 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 与 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之间相互转换，以满足其他几何自定义场景。

## **使用编辑点更改形状**

考虑一个正方形。在 PowerPoint 中，使用 **编辑点**，您可以  

* 将正方形的角向内或向外移动  
* 为角或点指定曲率  
* 向正方形添加新点  
* 操作正方形上的点等  

本质上，您可以对任何形状执行上述任务。使用编辑点，您可以更改形状或从已有形状创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

在通过编辑点编辑 PowerPoint 形状之前，您可能需要考虑以下关于形状的要点：

* 形状（或其路径）可以是闭合的，也可以是开放的。  
* 当形状闭合时，它没有起点或终点；当形状开放时，它有开始点和结束点。  
* 所有形状至少由 2 个锚点组成，这些锚点通过线段相连。  
* 线段可以是直线或曲线。锚点决定线段的属性。  
* 锚点有三种形式：角点、直点或平滑点：  
  * 角点是两条直线在某个角度处相交的点。  
  * 平滑点是两根手柄在同一直线上，且线段以平滑曲线相接的点。在此情况下，所有手柄与锚点的距离相等。  
  * 直点是两根手柄在同一直线上，且线段以平滑曲线相接的点。在此情况下，手柄与锚点的距离不必相等。  
* 通过移动或编辑锚点（从而改变线段的角度），可以改变形状的外观。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例表示 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 对象的几何路径。  
* 要从 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/)，可使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。  
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/)，可使用以下方法：对 *实心形状* 使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#setGeometryPath)，对 *复合形状* 使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/#setGeometryPaths)。  
* 要添加线段，可使用 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 下的相关方法。  
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/#setStroke) 和 [GeometryPath.setFillMode](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/#setFillMode) 方法，可设置几何路径的外观。  
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/#getPathData) 方法，可将 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 的几何路径以路径段数组的形式检索。  
* 若需更多形状几何自定义选项，可将 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 转换为 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)。  
* 使用 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeutil/) 与 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeutil/) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapeutil/) 类）可在 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 与 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之间相互转换。

## **基本编辑操作**

以下签名展示了基本的编辑操作：

**在路径末尾添加直线**：

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**在路径的指定位置添加直线**：

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**在路径末尾添加三次 Bézier 曲线**：

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**在路径的指定位置添加三次 Bézier 曲线**：

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**在路径末尾添加二次 Bézier 曲线**：

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**在路径的指定位置添加二次 Bézier 曲线**：

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**将给定弧段追加到路径**：

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**关闭路径的当前图形**：

- `geometry_path.closeFigure()`

**设置下一个点的位置**：

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**删除指定索引处的路径段**：

- `geometry_path.removeAt(index)`

## **向形状添加自定义点**
1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例，并将其类型设为 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Rectangle)。  
2. 从该形状获取一个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
3. 在路径的两个顶部点之间添加一个新点。  
4. 在路径的两个底部点之间添加一个新点。  
5. 将路径应用到形状。

以下 Python 代码演示了如何向形状添加自定义点：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **从形状删除点**

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例，并将其类型设为 [ShapeType.Heart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/#Heart)。  
2. 从该形状获取一个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
3. 删除路径的相应段。  
4. 将路径应用到形状。

以下 Python 代码演示了如何从形状删除点：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

1. 计算形状的各个点。  
2. 创建一个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
3. 用这些点填充路径。  
4. 创建一个 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例。  
5. 将路径应用到形状。

以下 Python 代码演示了如何创建自定义形状：

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
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **创建复合自定义形状**

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例。  
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
4. 将这些路径应用到形状。

以下 Python 代码演示了如何创建复合自定义形状：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **创建带曲线角的自定义形状**

以下 Python 代码演示了如何创建带曲线角（向内）的自定义形状：

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
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
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

闭合形状是指其所有边相连，形成无间隙的单一边界。该形状可以是简单的几何形体，也可以是复杂的自定义轮廓。下面的代码示例展示了如何检查形状几何是否闭合：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **将 GeometryPath 转换为 java.awt.Shape**

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometryshape/) 实例。  
2. 创建一个 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 实例。  
3. 通过遍历其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 并在路径上重新播放每个段，将该 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/geometrypath/) 实例。  
4. 将路径应用到形状。

以下 Python 代码实现了上述步骤，将图形路径转换为几何路径：

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
    # 创建一个新形状。
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # 获取形状的几何路径。
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # 使用文本创建新的图形路径。
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
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

**替换几何后填充和轮廓会怎样？**

样式仍然随形状保留，仅轮廓会改变。填充和轮廓会自动应用到新的几何上。

**如何在旋转自定义形状时一起旋转其几何？**

使用形状的 [setRotation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#setRotation) 方法；几何会随形状一起旋转，因为它绑定在形状自身的坐标系上。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/python-java/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/python-java/create-shape-thumbnails/) 本身导出为光栅格式，这可简化对复杂几何的后续处理。