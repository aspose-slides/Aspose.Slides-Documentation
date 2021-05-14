---
title: Custom Shape
type: docs
weight: 10
url: /java/custom-shape/
---

# Shape Geometry Customization (Shape Points Editing)

## Overview

Customization of the shape geometry assumes editing points of an existing shape. 

![overview_image](custom_shape_0.png)

To provide the mentioned functionality [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class and [IGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) interface have been added. [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) instance represents a geometry path of the [IGeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape) object. 

To retrieve [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) from the [IGeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape) instance [IGeometryShape.getGeometryPaths](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) method has been added. Shapes may be built from a few smaller shapes (e.g. an "equal" sign) so this method returns an array of [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) objects. 

To set [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) to the shape two methods have been added: 
[IGeometryShape.setGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) for solid shapes and [IGeometryShape.setGeometryPaths](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) for composite shapes.

[IGeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath) provides methods for adding segments of various types:

**Adds line** to the end of the path
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Adds line** to the specified place of the path:
``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Adds cubic Bezier curve** at the end the path:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Adds cubic Bezier curve** to the specified place of the path:
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Adds quadratic Bezier curve** at the end the path:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Adds quadratic Bezier curve** to the specified place of the path:
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Appends the specified arc** to the path:
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Closes the current figure** of this path:
``` java
public void closeFigure();
```
**Sets next point position**:
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Removes path segment** at the specified index:
``` java
public void removeAt(int index);
```
Methods [IGeometryPath.getStroke](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getStroke--), [IGeometryPath.getStroke](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setStroke-boolean-), [IGeometryPath.getFillMode](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getFillMode--) and [IGeometryPath.setFillMode](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) set an appearance of the geometry path.

Method [IGeometryPath.getPathData](https://apireference.aspose.com/slides/java/com.aspose.slides/IGeometryPath#getPathData--) returns the geometry path of [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) as an array of path segments.


*To provide more options of shape geometry customization [ShapeUtil](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeUtil) class has been added. Methods of this class allow to convert [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) to [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) back and forth.*

# Examples and Use Cases

## Add Custom Points to Shape

- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) class of type [ShapeType.Rectangle](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Rectangle)
- Retrieve an instance of the [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class from the shape.
- Add a new point between two top points of the path.
- Add a new point between two bottom points of the path.
- Apply the path to the shape.
  
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```

![example1_image](custom_shape_1.png)

##  Remove Points from Shape

- Create an instance of [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) class of type [ShapeType.Heart](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeType#Heart).
- Retrieve an instance of the [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class from the shape.
- Remove segment of the path.
- Apply the path to the shape.
  
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

##  Create Custom Shape

- Calculate points of the shape.
- Create an instance of the [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class. 
- Fill the path with the points.
- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) class. 
- Apply the path to the shape.

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)


## Create Composite Custom Shape

  - Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) class.
  - Create first instance of the [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class.
  - Create second instance of the [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) class.
  - Apply the paths to the shape.

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## Conversion of java.awt.Shape to GeometryPath

- Create an instance of the [GeometryShape](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryShape) class.
- Create an instance of the [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) class.
- Convert the [Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) instance to the  [GeometryPath](https://apireference.aspose.com/slides/java/com.aspose.slides/GeometryPath) instance using [ShapeUtil](https://apireference.aspose.com/slides/java/com.aspose.slides/ShapeUtil).
- Apply the paths to the shape.
  
``` java
Presentation pres = new Presentation();
try {
    // Create new shape
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Get geometry path of the shape
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Create new graphics path with text
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Convert graphics path to geometry path
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Set combination of new geometry path and origin geometry path to the shape
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });

    // Save the presentation
    pres.save(resultPath, SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)
