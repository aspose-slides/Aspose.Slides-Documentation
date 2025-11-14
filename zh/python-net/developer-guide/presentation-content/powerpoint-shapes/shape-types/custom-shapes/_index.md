---
title: 在演示文稿中使用 Python 自定义形状
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
- 删除点
- 编辑操作
- 圆角
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义形状：几何路径、圆角、复合形状。"
---

# 使用编辑点更改形状

考虑一个正方形。在PowerPoint中，通过**编辑点**，您可以

* 将正方形的角向内或向外移动
* 指定角落或点的曲率
* 向正方形添加新点
* 操作正方形上的点等。

本质上，您可以对任何形状执行上述任务。使用编辑点，您可以更改形状或从现有形状创建新形状。

## 形状编辑提示

![overview_image](custom_shape_0.png)

在您开始通过编辑点编辑PowerPoint形状之前，您可能希望考虑以下关于形状的要点：

* 形状（或其路径）可以是闭合的或开放的。
* 当一个形状是闭合的时，它没有起点或终点。当一个形状是开放的时，它有一个开始和结束。
* 所有形状至少由 2 个锚点通过直线连接在一起。
* 一条线可以是直线或曲线。锚点决定了线的性质。
* 锚点可以是角点、直点或平滑点：
  * 角点是两个直线在一个角度交汇的点。
  * 平滑点是两个手柄以直线存在，并且线段以平滑曲线连接的点。在这种情况下，所有手柄与锚点之间的距离相等。
  * 直点是两个手柄以直线存在，并且线段以平滑曲线连接的点。在这种情况下，手柄与锚点之间的距离不必相等。
* 通过移动或编辑锚点（这会改变线的角度），您可以改变形状的外观。

要通过编辑点编辑PowerPoint形状，**Aspose.Slides**提供了[**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)类和[**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/)接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例代表 [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) 对象的几何路径
* 要从 `IGeometryShape` 实例检索 `GeometryPath`，您可以使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) 方法。
* 要为形状设置 `GeometryPath`，您可以使用这些方法：[IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) 用于 *固体形状* 和 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) 用于 *复合形状*。
* 为了添加线段，您可以使用 [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) 下的方法。
* 使用 [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) 和 [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) 属性，您可以设置几何路径的外观。
* 使用 [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata) 属性，您可以将 `GeometryShape` 的几何路径作为路径段数组检索。
* 要访问额外的形状几何自定义选项，您可以将 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 转换为 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)。
* 使用 `GeometryPathToGraphicsPath` 和 `GraphicsPathToGeometryPath` 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/) 类）将 `GeometryPath` 与 `GraphicsPath` 相互转换。

## **简单编辑操作**

此Python代码演示了如何

**在路径末尾添加一条线：**

```py
line_to(point)
line_to(x, y)
```
**在路径指定位置添加一条线：**

```py    
line_to(point, index)
line_to(x, y, index)
```
**在路径末尾添加一条立方贝塞尔曲线：**

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**在路径指定位置添加一条立方贝塞尔曲线：**

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**在路径末尾添加一条二次贝塞尔曲线：**
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**在路径指定位置添加一条二次贝塞尔曲线：**

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**将给定弧追加到路径：**
```py
arc_to(width, heigth, startAngle, sweepAngle)
```
**关闭当前路径的图形：**
```py
close_figure()
```
**设置下一个点的位置：**
```py
move_to(point)
move_to(x, y)
```
**删除给定索引处的路径段：**

```py
remove_at(index)
```
## 向形状添加自定义点
1. 创建 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例，并设置 [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 在路径的两个顶部点之间添加一个新点。
4. 在路径的两个底部点之间添加一个新点。
6. 将路径应用于形状。

此Python代码演示了如何向形状添加自定义点：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## 从形状移除点

1. 创建 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例，并设置 [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) 类型。
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 删除路径的线段。
4. 将路径应用于形状。

此Python代码演示了如何从形状中移除点：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

	path = shape.get_geometry_paths()[0]
	path.remove_at(2)
	shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## 创建自定义形状

1. 计算形状的点。
2. 创建 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 用点填充路径。
4. 创建 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例。
5. 将路径应用于形状。

此Python代码演示了如何创建自定义形状：

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

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)


## 创建复合自定义形状

1. 创建 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例。
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 类的实例。
4. 将路径应用于形状。

此Python代码演示了如何创建复合自定义形状：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([ geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **创建具有圆角的自定义形状**

此Python代码演示了如何创建具有圆角（向内）的自定义形状：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## 几何路径到图形路径的转换 (System.Drawing.Drawing2D)

1. 创建 [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) 类的实例。
2. 创建 [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 命名空间的 [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 类的实例。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/) 将 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) 实例。
4. 将路径应用于形状。

此Python代码展示了上述步骤的实现—**GeometryPath** 到 **GraphicsPath** 的转换过程：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Text in shape", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)