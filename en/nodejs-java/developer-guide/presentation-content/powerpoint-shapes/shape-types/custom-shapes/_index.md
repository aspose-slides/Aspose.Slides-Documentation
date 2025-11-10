---
title: Custom Shape
type: docs
weight: 20
url: /nodejs-java/custom-shape/
keywords: 
- shape
- custom shape
- create shape
- geometry
- shape geometry
- geometry path
- path points
- edit points
- PowerPoint
- presentation
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Add a custom shape to a PowerPoint presentation in JavaScript"
---

## **Change a Shape Using Edit Points**

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

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class and [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class.

* A [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) instance represents a geometry path of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) object.
* To retrieve the`GeometryPath` from the `GeometryShape` instance, you can use the [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) method.
* To set the `GeometryPath` for a shape, you can use these methods: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) for *solid shapes* and [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) for *composite shapes*.
* To add segments, you can use the methods under [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath).
* Using the [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) and [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) methods, you can set the appearance for a geometry path.
* Using the [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) method, you can retrieve the geometry path of a `GeometryShape` as an array of path segments.
* To access additional shape geometry customization options, you can convert [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) to [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Use [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) and [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) methods (from the [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil) class) to convert [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) to [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) back and forth.

## **Simple Editing Operations**

This JavaScript code shows you how to

**Add a line** to the end of a path

```javascript
lineTo(point);
lineTo(x, y);
```
**Add a line** to a specified position on a path:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Add a cubic Bezier curve** at the end of a path:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Add a cubic Bezier curve** to the specified position on a path:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Add a quadratic Bezier curve** at the end of a path:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Add quadratic Bezier curve** to a specified position on a path:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Append a given arc** to a path:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Close the current figure** of a path:

```javascript
closeFigure();
```
**Set the position for the next point**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Remove the path segment** at a given index:

```javascript
removeAt(index);
```

## **Add Custom Points to Shape**
1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) class and set the [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType) type.
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class from the shape.
3. Add a new point between the two top points on the path.
4. Add a new point between the two bottom points on the path.
5. Apply the path to the shape.

This JavaScript code shows you how to add custom points to a shape:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Remove Points From Shape**

1. Create an instance of [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) class and set the [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType) type.
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class from the shape.
3. Remove the segment for the path.
4. Apply the path to the shape.

This JavaScript code shows you how to remove points from a shape:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Create Custom Shape**

1. Calculate the points for the shape.
2. Create an instance of the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class.
3. Fill the path with the points.
4. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) class.
5. Apply the path to the shape.

This JavaScript shows you how to create a custom shape:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Create Composite Custom Shape**

  1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) class.
  2. Create a first instance of the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class.
  3. Create a second instance of the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) class.
  4. Apply the paths to the shape.

This JavaScript code shows you to create a composite custom shape:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Create Custom Shape With Curved Corners**

This JavaScript code shows you how to create a custom shape with curved corners (inwards);

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Find Out If a Shape Geometry Is Closed**

A closed shape is defined as one where all its sides connect, forming a single boundary without gaps. Such a shape can be a simple geometric form or a complex custom outline. The following code example shows how to check if a shape geometry is closed:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Convert GeometryPath to java.awt.Shape** 

1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) class.
2. Create an instance of the [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) class.
3. Convert the [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) instance to the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) instance using [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil).
4. Apply the paths to the shape.

This JavaScript code—an implementation of the steps above—demonstrates the **GeometryPath** to **GraphicsPath** conversion process:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Create new shape
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Get geometry path of the shape
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Create new graphics path with text
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Convert graphics path to geometry path
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Set combination of new geometry path and origin geometry path to the shape
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**What will happen to the fill and outline after replacing the geometry?**

The style remains with the shape; only the contour changes. The fill and outline are automatically applied to the new geometry.

**How do I correctly rotate a custom shape along with its geometry?**

Use the shape’s [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) method; the geometry rotates with the shape because it’s bound to the shape’s own coordinate system.

**Can I convert a custom shape to an image to "lock in" the result?**

Yes. Export the required [slide](/slides/nodejs-java/convert-powerpoint-to-png/) area or the [shape](/slides/nodejs-java/create-shape-thumbnails/) itself to a raster format; this simplifies further work with heavy geometries.
