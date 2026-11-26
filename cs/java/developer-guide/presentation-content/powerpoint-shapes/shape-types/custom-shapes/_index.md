---
title: Přizpůsobení tvarů prezentace v Javě
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- upravit body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Java: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) pro úpravu existujících tvarů, provádění základních operací úpravy cest, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, stavět tvary se zakřivenými rohy, určit, zda je geometrie tvaru uzavřená, prohlížet prvky tvaru a převést obrysy textu Java AWT na geometrické cesty.

## **Změna tvaru pomocí editačních bodů**

In PowerPoint můžete použít **Edit Points** k úpravě čtverce:

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

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

To edit PowerPoint shapes through edit points, **Aspose.Slides** provides the [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) class and [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) interface.

* Instance [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) můžete použít metodu [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) pro tvary s jednou cestou a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/).
* Použitím metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) a [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) můžete nastavit vzhled geometrické cesty.
* Použitím metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete přečíst [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) přes jeho [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) a přehrát segmenty na [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

## **Jednoduché operace úpravy**

Use the following methods to edit a geometry path. Overloads that accept an index insert a segment at that zero-based position in the path’s segment array.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit rovnou čáru. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídícími body a koncovým bodem. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídícím bodem a koncovým bodem. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Uzavřít aktuální útvar spojením koncového bodu se startovacím bodem. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Nastavit počáteční bod útvaru. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Odstranit segment na nultém indexu. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Přidání vlastních bodů do tvaru**

This example inserts two points into a rectangular shape using [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) and applies the edited path with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-). The coordinates are local to the shape: both new points are at its center, 100 points from the left and 50 points from the top. Segment indices 1 and 4 place them on the top and bottom edges, pulling those edges inward.

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

## **Odstranění bodů z tvaru**

This example changes a heart-shaped outline by removing the segment at zero-based index 2 with [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-). Applying the modified path with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) updates the shape’s contour.

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

## **Vytvoření vlastního tvaru**

This example builds a five-pointed star with [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/). Alternating outer and inner radii of 100 and 50 points define the tips and indentations; a 72-degree step spaces the five tips evenly. The path is closed with [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) and applied to a rectangular shape using [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), replacing its outline.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
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

## **Vytvoření složeného vlastního tvaru**

This example defines two closed [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) objects for the top and bottom thirds of a shape. Applying both paths with [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) creates a single composite shape with a gap across its middle third.

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

## **Vytvoření vlastního tvaru se zakřivenými rohy**

This example combines straight segments with [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) to create a shape with inward-curved corners. Each corner size sets the arc’s width and height in points, and the -90-degree sweep draws a counterclockwise quarter ellipse. The completed path is applied with [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-), and the presentation is saved in PPTX format.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

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

## **Zjistit, zda je geometrie tvaru uzavřená**

The following helper checks whether every nonempty geometry path ends with a closing segment. It reads [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) and compares the final segment’s [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) with [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/). It returns false when there are no nonempty paths. This checks the final command of each path; it does not inspect every subfigure within a path. The example prints `true` for a rectangle.

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

## **Prozkoumání příkazů geometrické cesty**

Download [contour.pptx](contour.pptx) and place it in the application's working directory. The first shape on the first slide has a straight top edge, a cubic Bézier curve, and a straight closing edge. Use [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) to read the shape's paths and [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) to read each path's segments in drawing order. For each segment, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) identifies the command and determines how to interpret the values returned by [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--).

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

The shape sits at (200, 100) points on the slide. The reported coordinates are local to the shape, with (0, 0) at its upper-left corner, x increasing to the right, and y increasing downward. The closing segment returns to the starting point without additional coordinates.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Tvar PowerPoint s rovnou horní hranou, zakřivenou hranou od pravého horního rohu k levému dolnímu a rovnou levou hranou](contour.png)

## **Extrahování a prozkoumání prvků tvaru**

Use [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) to inspect an existing shape as elements containing path points and point types. Cast each returned [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) to [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) to retrieve the point and type arrays through [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) and [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) methods. This representation is useful for contour analysis or passing geometry to custom drawing tools.

The example opens input.pptx, finds the first geometry shape directly on the first slide, and prints its path segments. Use a presentation containing a shape with straight and curved segments to see both kinds of output. It does not search inside groups.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Zachovat typ segmentu, vyjma příznaků.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Spotřebovat oba řídící body a koncový bod.
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

**Coordinates and transformations.** Points are measured in points (1/72 inch), with X increasing to the right and Y increasing downward. For an ungrouped shape, the extracted coordinates already include the position returned by [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) and [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) and reflect its current width and height. For example, an unrotated rectangle at `(100, 200)` with size `120 × 80` has contour bounds `(100, 200)`–`(220, 280)`. Do not add the shape's position again. Subtract its X and Y to obtain coordinates relative to its unrotated frame.

The extracted points do not apply the shape's rotation, returned by [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--), or horizontal and vertical flips. To reproduce the displayed contour, apply those transformations around the shape's center. For grouped shapes, also account for the group coordinate mapping and transformations; do not assume that the extracted points are the final rendered slide coordinates or apply a translation or scale twice if it is already reflected in the child's frame.

**Inspection versus editing.** Extracted arrays describe the contour; changing them does not update the original shape. Choose this approach when your analysis or drawing code needs point/type arrays. Use [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) when you need geometry commands in the shape's local coordinate system or want to edit its geometry. Apply edited paths through [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) or [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).

## **Převod Java AWT Shape na GeometryPath**

This example combines a rectangular outline with text converted to geometry. The outline's [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) method disables its fill. A [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creates the text outline in a [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Its [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) supplies move, line, quadratic, cubic, and closing segments, which the example replays on a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/).

The text uses a 40-point Arial font. The outline is offset 20 points horizontally and positioned with its visual top 10 points below the shape's top edge. The text path is filled, while the original rectangle remains an outline. Applying both paths with [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) produces a single shape containing the rectangle and text.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Vytvořit nový tvar
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Získat geometrickou cestu tvaru
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Vytvořit novou grafickou cestu s textem
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Převést grafickou cestu na geometrickou cestu
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Nastavit kombinaci nové geometrické cesty a původní geometrické cesty na tvar
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; změní se pouze obrys. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu tvaru [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-); geometrie se otočí spolu s tvarem, protože je vázána na koordinátový systém tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou [slide](/slides/cs/java/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/java/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s komplexními geometriemi.