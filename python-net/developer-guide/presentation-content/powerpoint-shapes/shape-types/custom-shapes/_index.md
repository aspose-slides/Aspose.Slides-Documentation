---
title: Custom Shape
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "PowerPoint shape, custom shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add custom shape in PowerPoint presentation in Python"
---

# Shape Geometry Customization (Shape Points Editing)
## Overview
Customization of the shape geometry assumes editing points of an existing shape. 

![overview_image](custom_shape_0.png)

To provide the mentioned functionality [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class and [IGeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometrypath) interface have been added. [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) instance represents a geometry path of the [IGeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometryshape) object. 

To retrieve [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) from the [IGeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometryshape) instance [IGeometryShape.GetGeometryPaths](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometryshape/methods/getgeometrypaths) method has been added. Shapes may be built from a few smaller shapes (e.g. an "equal" sign) so this method returns an array of [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) objects. 

To set [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) to the shape two methods have been added: 
[IGeometryShape.SetGeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometryshape/methods/setgeometrypath) for solid shapes and [IGeometryShape.SetGeometryPaths](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometryshape/methods/setgeometrypaths) for composite shapes.

[IGeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometrypath) provides methods for adding segments of various types:

**Adds line** to the end of the path
```py
line_to(point)
line_to(x, y)
```
**Adds line** to the specified place of the path:
```py    
line_to(point, index)
line_to(x, y, index)
```
**Adds cubic Bezier curve** at the end the path:
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**Adds cubic Bezier curve** to the specified place of the path:
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**Adds quadratic Bezier curve** at the end the path:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**Adds quadratic Bezier curve** to the specified place of the path:
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**Appends the specified arc** to the path:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```
**Closes the current figure** of this path:
```py
close_figure()
```
**Sets next point position**:
```py
move_to(point)
move_to(x, y)
```
**Removes path segment** at the specified index:
```py
remove_at(index)
```
Properties [IGeometryPath.Stroke](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/stroke) and [IGeometryPath.FillMode](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/fillmode) set an appearance of the geometry path.

Property [IGeometryPath.PathData](https://apireference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata) returns the geometry path of [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) as an array of path segments.


*To provide more options of shape geometry customization [ShapeUtil](https://apireference.aspose.com/slides/python-net/aspose.slides.util/shapeutil) class has been added. Methods of this class allow to convert [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) to [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) back and forth.*

# Examples and Use Cases
## Add Custom Points to Shape
- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) class of type [ShapeType.Rectangle](https://apireference.aspose.com/slides/python-net/aspose.slides/shapetype)
- Retrieve an instance of the [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class from the shape.
- Add a new point between two top points of the path.
- Add a new point between two bottom points of the path.
- Apply the path to the shape.
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

##  Remove Points from Shape

- Create an instance of [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) class of type [ShapeType.Heart](https://apireference.aspose.com/slides/python-net/aspose.slides/shapetype).
- Retrieve an instance of the [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class from the shape.
- Remove segment of the path.
- Apply the path to the shape.
```py
import aspose.slides as slides

with slides.Presentation() as pres:
	shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

	path = shape.get_geometry_paths()[0]
	path.remove_at(2)
	shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

##  Create Custom Shape

- Calculate points of the shape.
- Create an instance of the [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class. 
- Fill the path with the points.
- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) class. 
- Apply the path to the shape.

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


## Create Composite Custom Shape

  - Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) class.
  - Create first instance of the [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class.
  - Create second instance of the [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) class.
  - Apply the paths to the shape.

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

## Conversion of GeometryPath to GraphicsPath (System.Drawing.Drawing2D) 

- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/python-net/aspose.slides/geometryshape) class.
- Create an instance of the [GrpahicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) class  of the [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) namespace.
- Convert the [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) instance to the  [GeometryPath](https://apireference.aspose.com/slides/python-net/aspose.slides/geometrypath) instance using [ShapeUtil](https://apireference.aspose.com/slides/python-net/aspose.slides.util/shapeutil).
- Apply the paths to the shape.
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