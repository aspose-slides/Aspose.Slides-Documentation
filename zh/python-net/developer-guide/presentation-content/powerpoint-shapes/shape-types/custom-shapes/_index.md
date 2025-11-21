---
title: 使用 Python 在演示文稿中自定义形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/python-net/custom-shape/
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
- 圆滑角
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建并自定义形状：几何路径、圆滑角、复合形状。"
---

## **概述**

考虑一个正方形。在 PowerPoint 中使用 **编辑点**，您可以：

* 将正方形的角向内或向外移动，
* 调整角或点的曲率，
* 向正方形添加新点，
* 操作其点。

您可以将这些操作应用于任意形状。使用 **编辑点**，您可以修改形状或根据现有形状创建新形状。

## **形状编辑技巧**

![“编辑点”命令](custom_shape_0.png)

在使用 **编辑点** 开始编辑 PowerPoint 形状之前，请注意以下关于形状的说明：

* 形状（或其路径）可以是 **闭合** 或 **开放** 的。
* 闭合形状没有起始点或结束点；开放形状有起始点和结束点。
* 每个形状至少有两个通过线段连接的锚点。
* 线段可以是直的或曲的；锚点决定线段的性质。
* 锚点可以是 **角点**、**平滑点** 或 **直线点**：
  * **角点** 是两条直线段在一个角处相交的点。
  * **平滑点** 有两个共线的手柄，相邻的线段形成平滑曲线。在此情况下，两个手柄与锚点的距离相等。
  * **直线点** 也有两个共线的手柄，相邻的线段形成平滑曲线，但手柄到锚点的距离可以不同。
* 通过移动或编辑锚点（从而改变线段角度），可以改变形状的外观。

要编辑 PowerPoint 形状，Aspose.Slides 提供了 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例表示 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 对象的几何路径。
* 要从 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 实例中获取 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，请使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，对 *实心形状* 使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)，对 *复合形状* 使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 要添加线段，请使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 上的方法。
* 使用 [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) 和 [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) 属性控制几何路径的外观。
* 使用 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 属性可将形状的几何路径作为路径段数组检索。

## **简单编辑操作**

以下方法用于简单编辑操作。

**在路径末尾添加直线**：
```py
line_to(point)
line_to(x, y)
```


**在路径的指定位置添加直线**：
```py    
line_to(point, index)
line_to(x, y, index)
```


**在路径末尾添加三次贝塞尔曲线**：
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```


**在路径的指定位置添加三次贝塞尔曲线**：
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```


**在路径末尾添加二次贝塞尔曲线**：
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```


**在路径的指定位置添加二次贝塞尔曲线**：
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```


**向路径追加弧线**：
```py
arc_to(width, heigth, startAngle, sweepAngle)
```


**关闭路径中的当前图形**：
```py
close_figure()
```


**设置下一个点的位置**：
```py
move_to(point)
move_to(x, y)
```


**删除给定索引处的路径段**：
```py
remove_at(index)
```


## **向形状添加自定义点**

在本节中，您将学习通过添加自己的点序列来定义自由形状。通过指定有序点和线段类型（直线或曲线），并可选地闭合路径，您可以在幻灯片上直接绘制精确的自定义图形——多边形、图标、批注或徽标。

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例并设置其 [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)。
2. 从该形状获取一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例。
3. 在路径的两个顶部点之间插入一个新点。
4. 在路径的两个底部点之间插入一个新点。
5. 将更新后的路径应用于形状。

以下 Python 代码演示如何向形状添加自定义点：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```


![自定义点](custom_shape_1.png)

##  **从形状中移除点**

有时自定义形状包含不必要的点，这会使几何结构变得复杂或影响渲染效果。本节展示如何从形状的路径中移除特定点，以简化轮廓并实现更清晰、更精确的结果。

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例并设置其 [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) 类型。
2. 从该形状获取一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例。
3. 从路径中移除一个线段。
4. 将更新后的路径应用于形状。

以下 Python 代码演示如何从形状中移除点：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```


![已移除的点](custom_shape_2.png)

##  **创建自定义形状**

通过定义一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 并使用直线、弧线和贝塞尔曲线进行组合，创建专属矢量形状。本节展示如何从零开始构建自定义几何体并将生成的形状添加到幻灯片中。

1. 计算形状的各个点。
2. 创建一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 用这些点填充路径。
4. 创建一个 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例。
5. 将路径应用于形状。

以下 Python 代码演示如何创建自定义形状：
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```


![自定义形状](custom_shape_3.png)

## **创建复合自定义形状**

创建复合自定义形状可将多个几何路径合并为幻灯片上的单个可重用形状。定义并合并这些路径，以构建超出标准形状集合的复杂视觉效果。

1. 创建一个 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例。
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
4. 将两个路径都应用于该形状。

以下 Python 代码演示如何创建复合自定义形状：
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```


![复合形状](custom_shape_4.png)

## **创建带圆滑角的自定义形状**

本节展示如何使用几何路径绘制带圆滑角的自定义形状。您将结合直线段和圆弧形成轮廓，并将完成的形状添加到幻灯片中。

以下 Python 代码演示如何创建带圆滑角的自定义形状：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```


![圆滑角](custom_shape_6.png)

## **确定形状几何是否闭合**

闭合形状指其所有边相连，形成没有间隙的单一边界。此类形状可以是简单的几何形态，也可以是复杂的自定义轮廓。以下代码示例展示如何检查形状几何是否闭合：
```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```


## **常见问题**

**替换几何后填充和轮廓会怎样？**

样式仍然保留在形状上；仅轮廓会更改。填充和轮廓会自动应用到新的几何上。

**如何让自定义形状连同其几何一起正确旋转？**

使用形状的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) 属性；几何会随形状一起旋转，因为它绑定到形状自身的坐标系。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/python-net/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/python-net/create-shape-thumbnails/) 本身导出为光栅格式，这样可以简化后续对复杂几何的处理。