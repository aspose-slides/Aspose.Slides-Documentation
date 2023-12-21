---
title: Custom Shape
type: docs
weight: 20
url: /net/custom-shape/
keywords: "PowerPoint shape, custom shape, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add custom shape in PowerPoint presentation in C# or .NET"
---

# Change a Shape Using Edit Points
Consider a square. In PowerPoint, using **edit points**, you can 

* move the square's corner in or out
* specify the curvature for a corner or point
* add new points to the square
* manipulate points on the square, etc. 

Essentially, you can perform the described tasks on any shape. Using edit points, you get to change a shape or create a new shape from an existing shape. 

## **Shape Editing Tips**

![overview_image](custom_shape_0.png)

Before you start editing PowerPoint shapes through edit points, you might want to consider these points about shapes:

* A shape (or its path) can either be closed or open.
* When a shape is closed, it lacks a start or end point. When a shape is open, it has a beginning and end. 
* All shapes consist of at least 2 anchor points linked to each other by lines
* A line is either straight or curved. Anchor points determine the nature of the line. 
* Anchor points exist as corner points, straight points, or smooth points:
  * A corner point is a point where 2 straight lines join at an angle. 
  * A smooth point is a point where 2 handles exist in a straight line and the line's segments join in a smooth curve. In this case, all handles are separated from the anchor point by an equal distance. 
  * A straight point is a point where 2 handles exist in a straight line and that line's line segments joins in a smooth curve. In this case, the handles don't have to be separated from the anchor point by an equal distance. 
* By moving or editing anchor points (which changes the angle of lines), you can change the way a shape looks. 

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [**GeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class and [**IGeometryPath**](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath) interface. 

* A [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) instance represents a geometry path of the [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape) object. 
* To retrieve the`GeometryPath` from the `IGeometryShape` instance, you can use the [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/getgeometrypaths) method. 
* To set the `GeometryPath` for a shape, you can use these methods: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypath) for *solid shapes* and [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/methods/setgeometrypaths) for *composite shapes*.
* To add segments, you can use the methods under [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath). 
* Using the [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/stroke) and [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/fillmode) properties, you can set the appearance for a geometry path.
* Using the [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/properties/pathdata) property, you can retrieve the geometry path of a `GeometryShape` as an array of path segments. 
* To access additional shape geometry customization options, you can convert [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) to [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* Use [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) and [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) methods (from the [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil) class) to convert [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) to [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) back and forth. 

## **Simple Editing Operations**

This C# code shows you how to

**Add a line** to the end of a path

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Add a line** to a specified position on a path:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Add a cubic Bezier curve** at the end of a path:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Add a cubic Bezier curve** to the specified position on a path:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Add a quadratic Bezier curve** at the end of a path:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Add quadratic Bezier curve** to a specified position on a path:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Append a given arc** to a path:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Close the current figure** of a path:

``` csharp
void CloseFigure();
```
**Set the position for the next point**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Remove the path segment** at a given index:

``` csharp
void RemoveAt(int index);
```
## **Add Custom Points to Shape**
1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) class and set the [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype) type.
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class from the shape.
3. Add a new point between the two top points on the path.
4. Add a new point between the two bottom points on the path.
5. Apply the path to the shape.

This C# code shows you how to add custom points to a shape:

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

##  Remove Points From Shape

1. Create an instance of [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) class and set the [ShapeType.Heart](https://reference.aspose.com/slides/net/aspose.slides/shapetype) type. 
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class from the shape.
3. Remove the segment for the path.
4. Apply the path to the shape.

This C# code shows you how to remove points from a shape:

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

##  **Create Custom Shape**

1. Calculate the points for the shape.
2. Create an instance of the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class. 
3. Fill the path with the points.
4. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) class. 
5. Apply the path to the shape.

This C# shows you how to create a custom shape:

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


## **Create Composite Custom Shape**

  1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) class.
  2. Create a first instance of the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class.
  3. Create a second instance of the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) class.
  4. Apply the paths to the shape.

This C# code shows you to create a composite custom shape:

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

## **Create Custom Shape With Curved Corners**

This C# code shows you how to create a custom shape with curved corners (inwards);

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

## **Check Whether a Shape Geometry is Closed**

A geometric shape in PowerPoint may comprise several geometric paths. Each of those geometric paths may be open or [closed](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/). 

This C# code shows you how to check if a geometric shape contains a closed path:

```c#

```

## **Convert GeometryPath to GraphicsPath (System.Drawing.Drawing2D)** 

1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape) class.
2. Create an instance of the [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) class of the [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) namespace.
3. Convert the [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) instance to the [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath) instance using [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil).
4. Apply the paths to the shape.

This C# code—an implementation of the steps above—demonstrates the **GeometryPath** to **GraphicsPath** conversion process:

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