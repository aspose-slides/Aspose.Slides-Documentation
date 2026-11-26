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
description: "使用 Aspose.Slides for Python 通过 .NET 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、曲线角、复合形状。"
---
## **概述**

本文介绍了如何通过编辑点和几何路径来编辑形状几何，从而自定义 Aspose.Slides 中的演示文稿形状。它展示了如何使用[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)来修改现有形状，执行基本的路径编辑操作，添加或删除点，并将更新后的几何应用回形状。

它还演示了如何创建自定义和复合形状，构建带曲线角的形状，确定形状几何是否闭合，以及提取形状元素以进行轮廓分析。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用**编辑点**来修改正方形：

* 将角向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点可让您修改形状的轮廓或以现有形状为基础创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的，也可以是打开的。
* 形状的路径由通过线段连接的锚点组成。
* 线段可以是直的或曲线的。锚点和控制手柄决定其形状。
* 锚点可分为拐角点、直线点或平滑点：
  * 在拐角点，相邻的线段可以在一个角度相交。
  * 在平滑点，两个控制手柄保持对齐且与锚点的距离相等。
  * 在直线点，两个控制手柄保持对齐但与锚点的距离可以不同。
* 移动锚点或调整其手柄会改变形状的轮廓。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)类。

* 一个[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)实例表示[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)对象的几何路径。
* 要从[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)实例检索[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可以使用[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)方法。
* 要为形状设置[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)，可以使用这些方法：对单一路径的形状使用[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)；对多路径形状使用[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)。
* 要添加线段，可以使用[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)下的方法。
* 使用[GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/)和[GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/)属性，可以设置几何路径的外观。
* 使用[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)属性，可以将[GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)的几何路径作为路径段数组检索。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径的线段数组中零基位置插入线段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线。 | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| 追加或插入具有两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| 追加或插入具有一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| 追加具有指定尺寸和角度（以度为单位）的椭圆弧。 | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| 通过将当前图形的终点连接到起点来闭合当前图形。 | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| 设置图形的起始点。 | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| 删除指定零基索引处的线段。 | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **向形状添加自定义点**

此示例使用[GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/)在矩形形状中插入两个点，并使用[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)应用编辑后的路径。坐标相对于形状本身：两个新点位于中心，左侧距离 100 点，顶部距离 50 点。线段索引 1 和 4 将它们放在顶部和底部边缘，向内拉动这些边缘。

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

![example1_image](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用[GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/)删除零基索引 2 处的线段来更改心形轮廓。使用[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)应用修改后的路径后，形状的轮廓会被更新。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

此示例使用[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)构建一个五角星。交替的外半径和内半径分别为 100 点和 50 点定义了星尖和凹口；72 度的步长将五个星尖均匀分布。路径使用[GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/)闭合，并使用[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)应用到矩形形状，替换其轮廓。

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
![example3_image](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一定义了两个闭合的[GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)对象。使用[GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)同时应用两条路径，可创建一个中间三分之一留有间隙的单一复合形状。

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
![example4_image](custom_shape_4.png)

## **创建带有曲线角的自定义形状**

此示例将直线段与[GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/)结合，创建一个角部向内弯曲的形状。每个角的大小以点为单位设置弧的宽度和高度，-90 度的扫掠绘制逆时针四分之一椭圆。完成的路径使用[GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)应用，演示文稿以 PPTX 格式保存。

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

## **确定形状几何是否闭合**

以下辅助方法检查每个非空几何路径是否以闭合线段结束。它读取[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)并将最终线段的[PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/)与[PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/)进行比较。当没有非空路径时返回 false。此检查每条路径的最终命令；它不会检查路径内部的每个子图形。示例对矩形打印 `True`。

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

## **检查几何路径命令**

下载[contour.pptx](contour.pptx)并将其放在工作目录中。第一张幻灯片的第一个形状具有直顶部边缘、三次 Bézier 曲线和直闭合边缘。使用[GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)读取其路径。对于每条路径，[GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/)按绘制顺序列出线段。每个线段的[PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/)决定如何解释其[PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/)。

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

该形状位于幻灯片上的 (200, 100) 点。报告的坐标相对于形状本身。其左上角为 (0, 0)，x 向右增大，y 向下增大。闭合线段返回到起始点而不需要额外坐标。

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![带有直顶部边缘、右上到左下弧形边缘和直左侧边缘的 PowerPoint 形状](contour.png)

## **提取并检查形状元素**

使用[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/)检查现有形状，返回的元素包含路径点和点类型数组。每个返回的[ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/)公开其[path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/)和[path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/)数组。此表示法对轮廓分析或将几何传递给自定义绘图工具非常有用。

示例打开一个演示文稿，在第一张幻灯片上直接查找第一个几何形状，并打印其路径线段。使用包含直线段和曲线段的形状进行演示，可看到两种输出。它不会在组内部搜索。

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
                point_type = types[i] & 0x07  # 保留线段类型，排除标志。
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

数组通过索引对应：`points[i]` 为一个点，`types[i]` 描述其角色。类型 `0` 开始一个图形，类型 `1` 从前一点绘制到当前点的直线。三次 Bézier 线段从前一个端点开始，使用连续的三个类型 `3` 条目：两个控制点后跟新的端点。循环一次性消费这三个条目并检查端点是否闭合。

点类型还包含标志。使用 `0x07` 掩码可识别线段类型，单独测试 `0x80` 可检测闭合子路径。例如，`129` (`0x81`) 表示闭合子路径的直线端点，`131` (`0x83`) 表示闭合子路径的 Bézier 端点。仅比较原始值为 `1` 或 `3` 会漏掉这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不改变基本线段类型。

**坐标和变换。** 点的单位是点（1/72 英寸），X 向右增大，Y 向下增大。对于未分组的形状，提取的坐标已包含其[x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)和[y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)位置，并反映其当前宽高。例如，未旋转的矩形位于 `(100, 200)`，大小 `120 × 80` 的轮廓界限为 `(100, 200)`–`(220, 280)`。不要再次添加形状的位置。减去其 X 和 Y 可得到相对于未旋转框架的坐标。

提取的点不应用形状的[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)或水平/垂直翻转。若要重现显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还需考虑组坐标映射及其变换；不要假设提取的点已经是最终渲染的幻灯片坐标，也不要在已经反映在子框架中的情况下再次平移或缩放。

**检查 vs 编辑。** 提取的数组描述轮廓；修改它们不会更新原始形状。当您的分析或绘图代码需要点/类型数组时可选择此方式。需要在形状本地坐标系中获取几何命令或编辑几何时，请使用[get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/)；编辑后通过[set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/)或[set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)应用。

## **常见问题**

**替换几何后填充和轮廓会怎样？**

样式仍然保留在形状上，仅轮廓会改变。填充和轮廓会自动应用到新的几何上。

**如何正确地连同几何一起旋转自定义形状？**

使用形状的[rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)属性；几何会随形状一起旋转，因为它绑定在形状自身的坐标系中。

**我能将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的[slide](/slides/zh/python-net/convert-powerpoint-to-png/)区域或[shape](/slides/zh/python-net/create-shape-thumbnails/)本身导出为光栅格式，这会简化后续对复杂几何的处理。