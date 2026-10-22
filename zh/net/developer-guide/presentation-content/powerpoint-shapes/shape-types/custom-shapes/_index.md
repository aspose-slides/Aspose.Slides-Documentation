---
title: 在 .NET 中自定义演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/net/custom-shape/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、圆角、复合形状。"
---
## **概述**

本文说明了如何通过编辑点和几何路径来编辑形状几何，从而在 Aspose.Slides 中自定义演示文稿形状。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 和 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 来修改现有形状、执行基本路径编辑操作、添加或删除点，并将更新后的几何应用回形状。

它还演示了如何创建自定义和复合形状、构建带圆角的形状、判断形状几何是否闭合，以及使用旧版在 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 与 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之间的转换，以满足更多几何自定义场景。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用 **编辑点** 来修改正方形：

* 向内或向外移动角点。
* 调整点的曲率。
* 添加新点。

编辑点可让您修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的也可以是打开的。
* 形状的路径由通过线段连接的锚点组成。
* 线段可以是直线或曲线。锚点和控制手柄决定其形状。
* 锚点有三种类型：拐角点、直线点和光滑点：
  * 在拐角点，邻接的线段可以形成角度。
  * 在光滑点，两个控制手柄对齐且与锚点的距离相等。
  * 在直线点，两个控制手柄对齐但与锚点的距离可以不同。
* 移动锚点或调整其手柄会改变形状的轮廓。

为了通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 类和 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 对象的几何路径。
* 要从 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可以使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/)，可以使用以下方法：单路径形状使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/)，多路径形状使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/)。
* 要添加线段，可以使用位于 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) 下的方法。
* 通过 [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) 和 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 属性，可设置几何路径的外观。
* 使用 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 属性，可将 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) 的几何路径检索为路径段数组。
* 在支持以下转换方法的旧版中，您可以将 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 转换为 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)。
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) 和 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/) 类）在 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 与 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 之间进行转换。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径的线段数组中零基位置插入线段。

| 操作 | 方法 |
| --- | --- |
| 添加或插入直线。 | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| 添加或插入带有两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| 添加或插入带有一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| 添加具有指定尺寸和角度（以度为单位）的椭圆弧。 | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| 通过将终点连接到起点来关闭当前图形。 | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| 设置图形的起始点。 | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| 删除零基索引处的线段。 | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **向形状添加自定义点**

此示例使用 [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) 向矩形形状插入两个点，并使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 应用编辑后的路径。坐标相对于形状本身：两个新点位于形状中心，距左侧 100 点，距顶部 50 点。线段索引 1 和 4 将它们放在顶部和底部边缘上，向内拉动这些边缘。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用 [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) 删除零基索引 2 处的线段来修改心形轮廓。使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 应用修改后的路径后，形状的轮廓会被更新。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 构建一个五角星。交替的外半径 100 点和内半径 50 点定义了尖端和凹陷；每隔 72 度的步进均匀分布五个尖端。路径通过 [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) 闭合，并使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 应用于矩形形状，从而替换其轮廓。

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一分别定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) 对象。使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 同时应用这两个路径，可在形状的中间三分之一处产生一个间隙，形成单一的复合形状。

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **创建带圆角的自定义形状**

此示例将直线段与 [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) 结合，创建一个内部圆角的形状。每个角的大小决定了弧的宽度和高度（单位为点），-90 度的扫掠角绘制逆时针四分之一椭圆。完成的路径通过 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 应用，并以 PPTX 格式保存演示文稿。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **判断形状几何是否闭合**

以下辅助方法检查每个非空几何路径是否以闭合线段结束。它读取 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) 并将最终线段的 [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) 与 [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) 进行比较。当没有非空路径时返回 false。该检查仅针对每条路径的最终命令，不会检查路径内部的每个子图形。示例对矩形输出 `True`。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **提取并检查形状元素**

使用 [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) 可将现有形状检查为包含路径点和点类型的元素。将每个返回的 [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) 强制转换为 [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) 可读取其 [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) 和 [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) 数组。此表示方式对于轮廓分析或将几何传递给自定义绘图工具非常有用。

示例打开一个演示文稿，查找第一张幻灯片上的第一个几何形状，并打印其路径线段。请使用包含直线和曲线段的形状进行测试，以看到两种输出。此方法不在组内部搜索。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // 保留线段类型，排除标志。
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // 消费两个控制点和终点。
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

数组按索引对应：`points[i]` 为点，`types[i]` 描述其角色。类型 `0` 表示开始一个图形，类型 `1` 表示从前一点绘制到当前点的直线。三次 Bézier 线段从前一个终点开始，使用连续的三个类型 `3` 条目：两个控制点后接新的终点。循环一次性消费这三个条目，并检查终点是否闭合。

点类型还包含标志。使用 `0x07` 掩码可识别线段类型，使用 `0x80` 可单独检测闭合子路径。例如，`129`（`0x81`）表示闭合子路径的直线终点，`131`（`0x83`）表示闭合的 Bézier 终点。仅比较原始值为 `1` 或 `3` 会漏掉这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不会改变基础线段类型。

**坐标与变换。** 点的单位为点（1/72 英寸），X 向右递增，Y 向下递增。对于未分组的形状，提取的坐标已经包含其 [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) 和 [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) 位置，并反映其当前宽高。例如，位于 `(100, 200)`、尺寸为 `120 × 80` 的未旋转矩形其轮廓界限为 `(100, 200)`–`(220, 280)`。不要再次加上形状的位置。减去其 X 与 Y 可获得相对于未旋转框架的坐标。

提取的点不包含形状的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 或水平、垂直翻转。若要还原显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还需考虑组的坐标映射和变换；不要假设提取的点已经是最终渲染的幻灯片坐标，或在已在子框架中体现的情况下再次平移或缩放。

**检查与编辑的区别。** 提取的数组仅描述轮廓，改变它们不会更新原始形状。当您的分析或绘图代码需要点/类型数组时使用此方式。若需要在形状本地坐标系中获取几何命令或编辑其几何，请使用 [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)。编辑后通过 [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) 或 [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 应用。

## **将 GeometryPath 转换为 GraphicsPath (System.Drawing.Drawing2D)**

以下示例需要支持 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 的旧版 Aspose.Slides for .NET 程序集（例如 25.10 版），以及带有 `System.Drawing.Common` 的 Windows 环境。该转换方法已在 [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) 中移除。

示例将矩形轮廓与转换为几何的文字结合。轮廓的 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) 被设为不填充。一个 [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) 存储文字轮廓，使用 [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) 将其转换为填充几何路径。通过 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) 同时应用两个路径，可生成包含矩形和文字的单一形状。若需逆向转换，请使用 [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)。

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **常见问题解答**

**替换几何后填充和轮廓会怎样？**

样式仍然保留在形状上，只有轮廓会改变。填充和轮廓会自动应用到新几何上。

**如何在旋转自定义形状时一起旋转其几何？**

使用形状的 [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 属性；几何会随形状一起旋转，因为它绑定到形状自身的坐标系。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/net/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/net/create-shape-thumbnails/) 本身导出为光栅格式，这会简化对复杂几何的后续处理。