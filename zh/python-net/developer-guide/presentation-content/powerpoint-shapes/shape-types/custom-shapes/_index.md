---
title: 在 Python 中自定义演示文稿形状
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
- 曲线角
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、曲线角、复合形状。"
---
## **概述**

本文解释了如何通过编辑点和几何路径编辑形状几何来自定义 Aspose.Slides 中的演示文稿形状。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 修改现有形状，执行基本的路径编辑操作，添加或删除点，并将更新后的几何应用回形状。

它还演示了如何创建自定义和复合形状，构建带曲线角的形状，判断形状几何是否闭合，以及提取形状元素进行轮廓分析。

## **使用编辑点更改形状**

* 将角点向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点可以让你修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![概览图](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的或打开的。
* 形状的路径由锚点和段连接组成。
* 段可以是直线或曲线。锚点和控制柄决定其形状。
* 锚点存在为拐角点、直线点或平滑点：
  * 在拐角点， 相邻段可以形成角度。
  * 在平滑点，两个控制柄对齐且距离锚点相等。
  * 在直线点，两个控制柄对齐，但与锚点的距离可以不同。
* 移动锚点或调整其控制柄会改变形状的轮廓。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例表示 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 对象的几何路径。
* 要从 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可以使用 [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可以使用以下方法：单路径形状使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)，多路径形状使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 要添加段，可以使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 下的方法。
* 使用 [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) 和 [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) 属性，可设置几何路径的外观。
* 使用 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 属性，可将 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 的几何路径检索为路径段数组。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径段数组的相应零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 追加或插入带有两个控制点和终点的三次贝塞尔曲线。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 追加或插入带有一个控制点和终点的二次贝塞尔曲线。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 追加具有指定尺寸和角度（以度为单位）的椭圆弧。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 通过将端点连接到起点来闭合当前图形。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 设置图形的起始点。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| 移除零基索引处的段。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **向形状添加自定义点**

此示例使用 [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) 向矩形形状插入两个点，并使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 应用编辑后的路径。坐标相对于形状本身：两个新点位于中心，距左边 100 点，距顶部 50 点。段索引 1 和 4 将它们放在顶部和底部边缘，向内拉动这些边缘。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![示例1图](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用 [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) 删除零基索引 2 处的段来更改心形轮廓。使用 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 应用修改后的路径后，形状的轮廓会被更新。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![示例2图](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 构建一个五角星。交替的外半径 100 点和内半径 50 点定义了顶点和凹陷；72 度的步长使五个顶点均匀分布。使用 [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) 将路径闭合，并通过 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 应用于矩形形状，替换其轮廓。

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![示例3图](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 对象。使用 [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 同时应用这两条路径，可创建一个在中间三分之一处留有间隙的单一复合形状。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![示例4图](custom_shape_4.png)

## **创建带曲线角的自定义形状**

此示例将直线段与 [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) 组合，生成一个角部向内弯曲的形状。每个角的大小决定弧的宽度和高度（单位为点），-90 度的扫掠角绘制出逆时针的四分之一椭圆。完成的路径通过 [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 应用，并将演示文稿保存为 PPTX 格式。

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **判断形状几何是否闭合**

以下帮助程序检查每个非空几何路径是否以闭合段结束。它读取 [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) 并将最后一段的 [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) 与 [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) 进行比较。如果没有非空路径，则返回 false。该检查仅关注每条路径的最终命令；不会检查路径内部的每个子图形。示例对矩形输出 `True`。

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **提取并检查形状元素**

使用 [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) 可将现有形状检查为包含路径点和点类型的元素集合。每个返回的 [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) 暴露其 [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) 和 [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) 数组。这种表示方式对轮廓分析或将几何传递给自定义绘图工具很有帮助。

示例打开一个演示文稿，直接在第一张幻灯片上找到第一个几何形状，并打印其路径段。使用包含直线段和曲线段的形状进行测试，可看到两种输出。该方法不会在组内部搜索。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # 保留段类型，排除标志。
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # 消耗两个控制点和终点。

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

数组通过索引对应：`points[i]` 为一个点，`types[i]` 描述其角色。类型 `0` 表示开始一个图形，类型 `1` 表示从前一点绘制到当前点的直线。三次贝塞尔段在前一个端点开始，使用连续的三个类型 `3` 条目：两个控制点随后是新的端点。循环会一起消费这三个条目，并检查端点是否闭合。

点类型还包含标志。使用 `0x07` 掩码可识别段类型，使用 `0x80` 可单独检测闭合子路径。例如，`129` (`0x81`) 表示闭合子路径的直线端点，`131` (`0x83`) 表示闭合子路径的贝塞尔端点。仅与 `1` 或 `3` 比较原始值会遗漏这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不会改变基础段类型。

**坐标和转换。** 点的单位是点（1/72 英寸），X 向右增大，Y 向下增大。对于未分组的形状，提取的坐标已经包含其 [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) 和 [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) 位置，并反映其当前宽高。例如，位于 `(100, 200)`、大小为 `120 × 80` 的未旋转矩形其轮廓界限为 `(100, 200)`–`(220, 280)`。不要再次加上形状的位置。减去其 X 和 Y 可得到相对于未旋转框架的坐标。

提取的点不应用形状的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 或水平、垂直翻转。若要还原显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还必须考虑组坐标映射和变换；不要假设提取的点已经是最终渲染在幻灯片上的坐标，也不要在已经反映在子对象框架中的情况下再次平移或缩放。

**检查与编辑的区别。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。当你的分析或绘图代码只需要点/类型数组时使用此方法。若需要在形状本地坐标系中获取几何命令或编辑几何，请使用 [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)。通过 [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) 或 [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) 应用编辑后的路径。

## **常见问题**

**替换几何后填充和轮廓会怎样？**

样式仍附着在形状上，仅轮廓会改变。填充和轮廓会自动应用到新的几何上。

**如何正确地连同几何一起旋转自定义形状？**

使用形状的 [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) 属性；几何会随形状一起旋转，因为它绑定在形状自身的坐标系中。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [幻灯片](/slides/zh/python-net/convert-powerpoint-to-png/) 区域或 [形状](/slides/zh/python-net/create-shape-thumbnails/) 本身导出为光栅格式，这会简化后续对复杂几何的处理。