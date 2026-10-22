---
title: Customize Presentation Shapes on Android
linktitle: Custom Shape
type: docs
weight: 20
url: /androidjava/custom-shape/
keywords:
- custom shape
- add shape
- create shape
- change shape
- shape geometry
- geometry path
- path points
- edit points
- add point
- remove point
- editing operation
- curved corner
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Create and customize shapes in PowerPoint presentations with Aspose.Slides for Android via Java: geometry paths, curved corners, composite shapes."
---

## **Overview**

This article explains how to customize presentation shapes in Aspose.Slides by editing shape geometry through edit points and geometry paths. It shows how to work with [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) and [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) to modify existing shapes, perform basic path editing operations, add or remove points, and apply updated geometry back to a shape.

It also demonstrates how to create custom and composite shapes, build shapes with curved corners, determine whether a shape geometry is closed, and inspect shape elements using Android point arrays.

## **Change a Shape Using Edit Points**

In PowerPoint, you can use **Edit Points** to modify a square:

* Move a corner inward or outward.
* Adjust the curvature at a point.
* Add new points.

Editing points lets you modify a shape’s outline or use an existing shape as the basis for a new one.

## **Shape Editing Tips**

![overview_image](custom_shape_0.png)

When editing PowerPoint shapes, keep these concepts in mind:

* A shape (or its path) can either be closed or open.
* A shape’s path consists of anchor points connected by segments.
* A segment can be straight or curved. Anchor points and control handles determine its shape.
* Anchor points exist as corner points, straight points, or smooth points:
  * At a corner point, adjoining segments can meet at an angle.
  * At a smooth point, the two control handles are aligned and equally distant from the anchor point.
  * At a straight point, the two control handles are aligned but can be different distances from the anchor point.
* Moving anchor points or adjusting their handles changes the shape’s outline.

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) class and [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) interface.

* A [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) instance represents a geometry path of the [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) object.
* To retrieve the [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) from the [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) instance, you can use the [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) method.
* To set the [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) for a shape, you can use these methods: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) for shapes with a single path and [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) for shapes with multiple paths.
* To add segments, you can use the methods under [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/).
* Using the [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) and [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) methods, you can set the appearance for a geometry path.
* Using the [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) method, you can retrieve the geometry path of a [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) as an array of path segments.

## **Simple Editing Operations**

Use the following methods to edit a geometry path. Overloads that accept an index insert a segment at that zero-based position in the path’s segment array.

| Operation | Method |
| --- | --- |
| Append or insert a straight line. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Append or insert a cubic Bézier curve with two control points and an endpoint. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Append or insert a quadratic Bézier curve with one control point and an endpoint. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Append an elliptical arc with the specified dimensions and angles in degrees. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Close the current figure by connecting its endpoint to its starting point. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Set the starting point of a figure. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Remove a segment at a zero-based index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Add Custom Points to a Shape**

This example inserts two points into a rectangular shape using [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) and applies the edited path with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). The coordinates are local to the shape: both new points are at its center, 100 points from the left and 50 points from the top. Segment indices 1 and 4 place them on the top and bottom edges, pulling those edges inward.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Remove Points from a Shape**

This example changes a heart-shaped outline by removing the segment at zero-based index 2 with [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-). Applying the modified path with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) updates the shape’s contour.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Create a Custom Shape**

This example builds a five-pointed star with [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/). Alternating outer and inner radii of 100 and 50 points define the tips and indentations; a 72-degree step spaces the five tips evenly. The path is closed with [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) and applied to a rectangular shape using [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), replacing its outline.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Create a Composite Custom Shape**

This example defines two closed [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) objects for the top and bottom thirds of a shape. Applying both paths with [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) creates a single composite shape with a gap across its middle third.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Create a Custom Shape with Curved Corners**

This example combines straight segments with [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) to create a shape with inward-curved corners. Each corner size sets the arc’s width and height in points, and the -90-degree sweep draws a counterclockwise quarter ellipse. The completed path is applied with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), and the presentation is saved in PPTX format.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Find Out If a Shape Geometry Is Closed**

The following helper checks whether every nonempty geometry path ends with a closing segment. It reads [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) and compares the final segment’s [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) with [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/). It returns false when there are no nonempty paths. This checks the final command of each path; it does not inspect every subfigure within a path. The example prints `true` for a rectangle.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Extract and Inspect Shape Elements**

Use [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) to inspect an existing shape as elements containing path points and point types. Cast each returned [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) to [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) to retrieve the point and type arrays through [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) and [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) methods. This representation is useful for contour analysis or passing geometry to custom drawing tools.

The example opens input.pptx, finds the first geometry shape directly on the first slide, and prints its path segments. Use a presentation containing a shape with straight and curved segments to see both kinds of output. It does not search inside groups.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

The arrays correspond by index: `points[i]` is a point and `types[i]` describes its role. Type `0` starts a figure, and type `1` draws a line from the previous point to the current point. A cubic Bézier segment starts at the previous endpoint and uses three consecutive type-`3` entries: two control points followed by the new endpoint. The loop consumes these three entries together and checks the endpoint for closure.

Point types also contain flags. Mask with `0x07` to identify the segment type, and test `0x80` separately to detect a closed subpath. For example, `129` (`0x81`) means a line endpoint that closes a subpath, and `131` (`0x83`) means a Bézier endpoint that closes one. Java stores these flags in signed bytes; masking preserves the intended bit values. Comparing the raw value only with `1` or `3` would miss these cases. Other flags, such as dash (`0x10`) and marker (`0x20`), do not change the base segment type.

**Coordinates and transformations.** Points are measured in points (1/72 inch), with X increasing to the right and Y increasing downward. For an ungrouped shape, the extracted coordinates already include the position returned by [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) and [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) and reflect its current width and height. For example, an unrotated rectangle at `(100, 200)` with size `120 × 80` has contour bounds `(100, 200)`–`(220, 280)`. Do not add the shape's position again. Subtract its X and Y to obtain coordinates relative to its unrotated frame.

The extracted points do not apply the shape's rotation, returned by [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--), or horizontal and vertical flips. To reproduce the displayed contour, apply those transformations around the shape's center. For grouped shapes, also account for the group coordinate mapping and transformations; do not assume that the extracted points are the final rendered slide coordinates or apply a translation or scale twice if it is already reflected in the child's frame.

**Inspection versus editing.** Extracted arrays describe the contour; changing them does not update the original shape. Choose this approach when your analysis or drawing code needs point/type arrays. Use [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) when you need geometry commands in the shape's local coordinate system or want to edit its geometry. Apply edited paths through [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) or [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **FAQ**

**What will happen to the fill and outline after replacing the geometry?**

The style remains with the shape; only the contour changes. The fill and outline are automatically applied to the new geometry.

**How do I correctly rotate a custom shape along with its geometry?**

Use the shape’s [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) method; the geometry rotates with the shape because it’s bound to the shape’s own coordinate system.

**Can I convert a custom shape to an image to "lock in" the result?**

Yes. Export the required [slide](/slides/androidjava/convert-powerpoint-to-png/) area or the [shape](/slides/androidjava/create-shape-thumbnails/) itself to a raster format; this simplifies further work with complex geometries.
