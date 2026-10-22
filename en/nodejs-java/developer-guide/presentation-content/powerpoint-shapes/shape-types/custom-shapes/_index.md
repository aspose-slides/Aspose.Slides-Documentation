---
title: Customize Presentation Shapes in JavaScript
linktitle: Custom Shape
type: docs
weight: 20
url: /nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Create and customize shapes in PowerPoint presentations with JavaScript and Aspose.Slides for Node.js: geometry paths, curved corners, composite shapes."
---

## **Overview**

This article explains how to customize presentation shapes in Aspose.Slides by editing shape geometry through edit points and geometry paths. It shows how to work with [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) to modify existing shapes, perform basic path editing operations, add or remove points, and apply updated geometry back to a shape.

It also demonstrates how to create custom and composite shapes, build shapes with curved corners, determine whether a shape geometry is closed, inspect shape elements, and convert Java AWT text outlines into geometry paths.

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

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) class.

* A [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) instance represents a geometry path of the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) object.
* To retrieve the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) from the [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) instance, you can use the [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) method.
* To set the [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) for a shape, you can use these methods: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) for shapes with a single path and [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) for shapes with multiple paths.
* To add segments, you can use the methods under [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).
* Using the [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) and [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) methods, you can set the appearance for a geometry path.
* Using the [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) method, you can retrieve the geometry path of a [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) as an array of path segments.
* To access additional shape geometry customization options, you can read a [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) through its [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) and replay the segments on a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

## **Simple Editing Operations**

Use the following methods to edit a geometry path. Overloads that accept an index insert a segment at that zero-based position in the path’s segment array.

| Operation | Method |
| --- | --- |
| Append or insert a straight line. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| Append or insert a cubic Bézier curve with two control points and an endpoint. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Append or insert a quadratic Bézier curve with one control point and an endpoint. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Append an elliptical arc with the specified dimensions and angles in degrees. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Close the current figure by connecting its endpoint to its starting point. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Set the starting point of a figure. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Remove a segment at a zero-based index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Add Custom Points to a Shape**

This example inserts two points into a rectangular shape using [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) and applies the edited path with [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath). The coordinates are local to the shape: both new points are at its center, 100 points from the left and 50 points from the top. Segment indices 1 and 4 place them on the top and bottom edges, pulling those edges inward.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Remove Points from a Shape**

This example changes a heart-shaped outline by removing the segment at zero-based index 2 with [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt). Applying the modified path with [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) updates the shape’s contour.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Create a Custom Shape**

This example builds a five-pointed star with [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/). Alternating outer and inner radii of 100 and 50 points define the tips and indentations; a 72-degree step spaces the five tips evenly. The path is closed with [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) and applied to a rectangular shape using [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), replacing its outline.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Create a Composite Custom Shape**

This example defines two closed [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) objects for the top and bottom thirds of a shape. Applying both paths with [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) creates a single composite shape with a gap across its middle third.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Create a Custom Shape with Curved Corners**

This example combines straight segments with [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) to create a shape with inward-curved corners. Each corner size sets the arc’s width and height in points, and the -90-degree sweep draws a counterclockwise quarter ellipse. The completed path is applied with [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), and the presentation is saved in PPTX format.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Find Out If a Shape Geometry Is Closed**

The following helper checks whether every nonempty geometry path ends with a closing segment. It reads [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) and compares the final segment’s [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) with [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/). It returns false when there are no nonempty paths. This checks the final command of each path; it does not inspect every subfigure within a path. The example prints `true` for a rectangle.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Extract and Inspect Shape Elements**

Use [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) to inspect an existing shape as elements containing path points and point types. Use each returned [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) to retrieve the point and type arrays through [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) and [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) methods. This representation is useful for contour analysis or passing geometry to custom drawing tools.

The example opens input.pptx, finds the first geometry shape directly on the first slide, and prints its path segments. Use a presentation containing a shape with straight and curved segments to see both kinds of output. It does not search inside groups.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
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

**Coordinates and transformations.** Points are measured in points (1/72 inch), with X increasing to the right and Y increasing downward. For an ungrouped shape, the extracted coordinates already include the position returned by [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) and [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) and reflect its current width and height. For example, an unrotated rectangle at `(100, 200)` with size `120 × 80` has contour bounds `(100, 200)`–`(220, 280)`. Do not add the shape's position again. Subtract its X and Y to obtain coordinates relative to its unrotated frame.

The extracted points do not apply the shape's rotation, returned by [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation), or horizontal and vertical flips. To reproduce the displayed contour, apply those transformations around the shape's center. For grouped shapes, also account for the group coordinate mapping and transformations; do not assume that the extracted points are the final rendered slide coordinates or apply a translation or scale twice if it is already reflected in the child's frame.

**Inspection versus editing.** Extracted arrays describe the contour; changing them does not update the original shape. Choose this approach when your analysis or drawing code needs point/type arrays. Use [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) when you need geometry commands in the shape's local coordinate system or want to edit its geometry. Apply edited paths through [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) or [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Convert a Java AWT Shape to GeometryPath**

This example combines a rectangular outline with text converted to geometry. The outline's [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) method disables its fill. A [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creates the text outline in a [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Its [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) supplies move, line, quadratic, cubic, and closing segments, which the example replays on a [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/).

The Java bridge uses explicit float and byte values for the corresponding Java parameters. The iterator writes coordinates into a Java float array; reflection reads its updated values back into JavaScript. The text uses a 40-point Arial font. The outline is offset 20 points horizontally and positioned with its visual top 10 points below the shape's top edge. The text path is filled, while the original rectangle remains an outline. Applying both paths with [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) produces a single shape containing the rectangle and text.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Move to.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Line to.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // Quadratic Bezier curve.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Cubic Bezier curve.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Close figure.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**What will happen to the fill and outline after replacing the geometry?**

The style remains with the shape; only the contour changes. The fill and outline are automatically applied to the new geometry.

**How do I correctly rotate a custom shape along with its geometry?**

Use the shape’s [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) method; the geometry rotates with the shape because it’s bound to the shape’s own coordinate system.

**Can I convert a custom shape to an image to "lock in" the result?**

Yes. Export the required [slide](/slides/nodejs-java/convert-powerpoint-to-png/) area or the [shape](/slides/nodejs-java/create-shape-thumbnails/) itself to a raster format; this simplifies further work with complex geometries.
