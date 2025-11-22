---
title: 自定义形状
type: docs
weight: 20
url: /zh/net/custom-shape/
keywords:
- 形状
- 自定义形状
- 创建形状
- 几何
- 形状几何
- 几何路径
- 路径点
- 编辑点
- PowerPoint
- 演示文稿
- C#
- Aspose.Slides for .NET
description: "在 .NET 中向 PowerPoint 演示文稿添加自定义形状"
---

## **使用编辑点更改形状**

考虑一个正方形。在 PowerPoint 中，使用 **编辑点**，您可以  

* 将正方形的角向内或向外移动  
* 指定角或点的曲率  
* 向正方形添加新点  
* 操作正方形上的点，等等  

本质上，您可以对任何形状执行上述操作。使用编辑点，您可以更改形状或从现有形状创建新形状。  

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

在通过编辑点开始编辑 PowerPoint 形状之前，您可能需要考虑以下关于形状的要点：

* 形状（或其路径）可以是闭合的，也可以是开放的。  
* 所有形状至少由 2 个锚点组成，这些锚点通过线段相连。  
* 线段可以是直线或曲线。锚点决定线段的性质。  
* 锚点可分为拐角点、直线点或平滑点：  
  * 拐角点是两条直线在一个角度处相交的点。  
  * 平滑点是两条控制柄在同一直线上，且线段以平滑曲线相连的点。在这种情况下，所有控制柄与锚点的距离相等。  
  * 直线点是两条控制柄在同一直线上，且该线段以平滑曲线相连的点。在这种情况下，控制柄与锚点的距离不必相等。  
* 通过移动或编辑锚点（这会改变线段的角度），您可以改变形状的外观。  

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类和 [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) 接口。  

* 一个 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 实例表示 [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) 对象的几何路径。  
* 要从 `IGeometryShape` 实例检索 `GeometryPath`，可以使用 [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) 方法。  
* 要为形状设置 `GeometryPath`，可以使用这些方法：对 *实心形状* 使用 [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) ，对 *复合形状* 使用 [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) 。  
* 要添加线段，可以使用 [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) 下的方法。  
* 使用 [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) 和 [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) 属性，可设置几何路径的外观。  
* 使用 [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) 属性，可将 `GeometryShape` 的几何路径检索为路径段数组。  
* 要访问更多形状几何自定义选项，您可以将 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 转换为 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 。  
* 使用 [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) 和 [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) 类）在 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 与 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 之间相互转换。  

## **简单编辑操作**

以下 C# 代码演示如何  

**在路径末尾添加直线**  
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
  

**在路径的指定位置添加直线**：  
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
  

**在路径末尾添加三次贝塞尔曲线**：  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
  

**在路径的指定位置添加三次贝塞尔曲线**：  
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
  

**在路径末尾添加二次贝塞尔曲线**：  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
  

**在路径的指定位置添加二次贝塞尔曲线**：  
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
  

**向路径追加给定弧线**：  
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
  

**关闭路径的当前图形**：  
``` csharp
void CloseFigure();
```
  

**设置下一个点的位置**：  
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
  

**删除指定索引处的路径段**：  
``` csharp
void RemoveAt(int index);
```
  

## **向形状添加自定义点**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) 类的实例并设置为 [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype) 类型。  
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类的实例。  
3. 在路径的两个顶部点之间添加一个新点。  
4. 在路径的两个底部点之间添加一个新点。  
5. 将路径应用到形状。  

以下 C# 代码演示如何向形状添加自定义点：  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```
  

![example1_image](custom_shape_1.png)  

## **从形状移除点**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) 类的实例并设置为 [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype) 类型。  
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类的实例。  
3. 删除路径的线段。  
4. 将路径应用到形状。  

以下 C# 代码演示如何从形状中移除点：  
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
  

![example2_image](custom_shape_2.png)  

## **创建自定义形状**

1. 计算形状的点。  
2. 创建 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类的实例。  
3. 使用这些点填充路径。  
4. 创建 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) 类的实例。  
5. 将路径应用到形状。  

以下 C# 代码演示如何创建自定义形状：  
``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
  

![example3_image](custom_shape_3.png)  

## **创建复合自定义形状**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) 类的实例。  
2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类的实例。  
3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 类的实例。  
4. 将路径应用到形状。  

以下 C# 代码演示如何创建复合自定义形状：  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
  

![example4_image](custom_shape_4.png)  

## **创建带曲线角的自定义形状**

以下 C# 代码演示如何创建带曲线角（向内）的自定义形状；  
```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```
  

## **判断形状几何是否闭合**

闭合形状的定义是其所有边相连，形成一个没有间隙的单一边界。此类形状可以是简单的几何形状，也可以是复杂的自定义轮廓。下面的代码示例演示如何检查形状几何是否闭合：  
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```
  

## **将 GeometryPath 转换为 GraphicsPath（System.Drawing.Drawing2D）**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) 类的实例。  
2. 创建 [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) 命名空间下的 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 类的实例。  
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) 将 [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) 实例。  
4. 将路径应用到形状。  

以下 C# 代码——上述步骤的实现——演示了 **GeometryPath** 到 **GraphicsPath** 的转换过程：  
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
  

![example5_image](custom_shape_5.png)  

## **常见问题**

**替换几何后填充和轮廓会怎样？**  
样式仍保留在形状上；仅轮廓会更改。填充和轮廓会自动应用到新的几何形状。  

**如何正确地旋转自定义形状以及其几何？**  
使用形状的 [rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) 属性；几何会随形状一起旋转，因为它绑定到形状自身的坐标系。  

**我能将自定义形状转换为图像以“锁定”结果吗？**  
可以。将所需的 [slide](/slides/zh/net/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/net/create-shape-thumbnails/) 本身导出为光栅格式；这样可简化对复杂几何的后续处理。