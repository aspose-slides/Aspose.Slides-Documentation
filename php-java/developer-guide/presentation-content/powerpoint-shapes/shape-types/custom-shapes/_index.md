---
title: Custom Shape
type: docs
weight: 20
url: /php-java/custom-shape/
keywords: "PowerPoint shape, custom shape, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Add custom shape in PowerPoint presentation "
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

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [**GeometryPath**](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class and [**IGeometryPath**](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryPath) interface.

* A [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) instance represents a geometry path of the [IGeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryShape) object.
* To retrieve the`GeometryPath` from the `IGeometryShape` instance, you can use the [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryShape#getGeometryPaths--) method.
* To set the `GeometryPath` for a shape, you can use these methods: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) for *solid shapes* and [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) for *composite shapes*.
* To add segments, you can use the methods under [IGeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryPath).
* Using the [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryPath#setStroke-boolean-) and [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryPath#setFillMode-byte-) methods, you can set the appearance for a geometry path.
* Using the [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/com.aspose.slides/IGeometryPath#getPathData--) method, you can retrieve the geometry path of a `GeometryShape` as an array of path segments.
* To access additional shape geometry customization options, you can convert [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) to [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* Use [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) and [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) methods (from the [ShapeUtil](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeUtil) class) to convert [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) to [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) back and forth.

## **Simple Editing Operations**

This Java code shows you how to

**Add a line** to the end of a path

```php

```
**Add a line** to a specified position on a path:

```php

```
**Add a cubic Bezier curve** at the end of a path:

```php

```
**Add a cubic Bezier curve** to the specified position on a path:

```php

```
**Add a quadratic Bezier curve** at the end of a path:

```php

```
**Add quadratic Bezier curve** to a specified position on a path:

```php

```
**Append a given arc** to a path:

```php

```
**Close the current figure** of a path:

```php

```
**Set the position for the next point**:

```php

```
**Remove the path segment** at a given index:

```php

```

## **Add Custom Points to Shape**
1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryShape) class and set the [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeType) type.
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class from the shape.
3. Add a new point between the two top points on the path.
4. Add a new point between the two bottom points on the path.
5. Apply the path to the shape.

This Java code shows you how to add custom points to a shape:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
![example1_image](custom_shape_1.png)

##  Remove Points From Shape

1. Create an instance of [GeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryShape) class and set the [ShapeType::Heart](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeType) type.
2. Get an instance of the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class from the shape.
3. Remove the segment for the path.
4. Apply the path to the shape.

This Java code shows you how to remove points from a shape:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
![example2_image](custom_shape_2.png)

##  **Create Custom Shape**

1. Calculate the points for the shape.
2. Create an instance of the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class.
3. Fill the path with the points.
4. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryShape) class.
5. Apply the path to the shape.

This Java shows you how to create a custom shape:

```php
  $points = new ArrayList<Point2D::Float>();
  $R = 100;
  $r = 50;
  $step = 72;
  for ($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * Math::PI / 180.0;
    $x = $R * Math->cos($radians);
    $y = $R * Math->sin($radians);
    $points->add(new Point2D::Float($x + $R, $y + $R));
    $radians = Math::PI * $angle . $step / 2 / 180.0;
    $x = $r * Math->cos($radians);
    $y = $r * Math->sin($radians);
    $points->add(new Point2D::Float($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for ($i = 1; $i < $points->size(); $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
![example3_image](custom_shape_3.png)


## **Create Composite Custom Shape**

  1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryShape) class.
  2. Create a first instance of the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class.
  3. Create a second instance of the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) class.
  4. Apply the paths to the shape.

This Java code shows you to create a composite custom shape:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(new GeometryPath[]{ $geometryPath0, $geometryPath1 });
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
![example4_image](custom_shape_4.png)

## **Create Custom Shape With Curved Corners**

This Java code shows you how to create a custom shape with curved corners (inwards);

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2D::Float($leftTopSize, 0);
    $point2 = new Point2D::Float($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2D::Float($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2D::Float($leftBottomSize, $shapeHeight);
    $point5 = new Point2D::Float(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```

## **Convert GeometryPath to java.awt.Shape** 

1. Create an instance of the [GeometryShape](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryShape) class.
2. Create an instance of the [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) class.
3. Convert the [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) instance to the [GeometryPath](https://reference.aspose.com/slides/php-java/com.aspose.slides/GeometryPath) instance using [ShapeUtil](https://reference.aspose.com/slides/php-java/com.aspose.slides/ShapeUtil).
4. Apply the paths to the shape.

This Java code—an implementation of the steps above—demonstrates the **GeometryPath** to **GraphicsPath** conversion process:

```php
  $pres = new Presentation();
  try {
    // Create new shape
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    // Get geometry path of the shape
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    // Create new graphics path with text
    $graphicsPath;
    $font = new Font("Arial", Font::PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage::TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    // Convert graphics path to geometry path
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    // Set combination of new geometry path and origin geometry path to the shape
    $shape->setGeometryPaths(new IGeometryPath[]{ $originalPath, $textPath });
  } finally {
    if ($pres != null) {
      $pres->dispose();
    }
  }

```
![example5_image](custom_shape_5.png)
