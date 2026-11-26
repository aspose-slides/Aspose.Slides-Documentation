---
title: Prezentációs alakzatok testreszabása Java-ban
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/java/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint-prezentációkban az Aspose.Slides for Java segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diák alakzatát az Aspose.Slides-ban a forma geometriájának szerkesztésével szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan dolgozzunk a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) és az [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) használatával meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria visszaalkalmazásához az alakzatra.

Emellett bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, alakzatokat ívelt sarkokkal, hogyan határozható meg, hogy egy alakzat geometria lezárt‑e, hogyan vizsgálhatók meg az alakzat elemei, valamint hogyan konvertálhatók a Java AWT szövegos körvonalak geometriai útvonalakká.

## **Alakzat módosítása szerkesztési pontokkal**

A PowerPointban a **Szerkesztési pontok** segítségével módosíthat egy négyzetet:

* Egy sarkot befelé vagy kifelé mozgathat.
* A pont ívét állíthatja.
* Új pontokat adhat hozzá.

A szerkesztési pontok használata lehetővé teszi az alakzat körvonalának módosítását, vagy egy meglévő alakzat felhasználását új alapként.

## **Alakzat‑szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor vegye figyelembe a következőket:

* Egy alakzat (vagy az útvonala) lehet lezárt vagy nyílt.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* A szegmens lehet egyenes vagy íves. A horgonypontok és a vezérlőfogók határozzák meg alakját.
* A horgonypontok lehetnek sarok‑pontok, egyenes pontok vagy sima pontok:
  * Sarok‑pont esetén a szomszédos szegmensek szöggel találkozhatnak.
  * Sima pont esetén a két vezérlőfogó egyvonalú és egyenlő távolságra van a horgonyponttól.
  * Egyenes pont esetén a két vezérlőfogó egyvonalú, de eltérő távolságra lehet a horgonyponttól.
* A horgonypontok mozgatása vagy a fogók módosítása megváltoztatja az alakzat körvonalát.

PowerPoint‑alakzatok szerkesztéséhez **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) osztályt és az [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) interfészt kínálja.

* Egy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) példány egy [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) objektum geometriai útvonalát reprezentálja.
* Az [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódussal kérhető le a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) egy [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) példányból.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) beállításához használhatja ezeket a metódusokat: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) egyetlen útvonallal rendelkező alakzatokhoz, valamint [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) többet tartalmazó alakzatokhoz.
* Szegmensek hozzáadásához használja az [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) alatti metódusokat.
* Az [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) és az [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metódusokkal állítható be egy geometriai útvonal megjelenése.
* Az [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) metódussal lekérhető a [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) geometriai útvonala szegmens tömbként.
* További alakzat‑geometria testreszabási lehetőségekhez olvassa be a [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)-t a [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)-én keresztül, és játssza le a szegmenseket egy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)-on.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkeszthet egy geometriai útvonalat. Az indexet elfogadó túlterhelések a szegmens‑tömbben a nullától kezdődő pozícióba illesztik be a szegmenst.

| Művelet | Metódus |
| --- | --- |
| Egy egyenes vonal hozzáfűzése vagy beszúrása. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Egy kockás Bézier‑görbe hozzáfűzése vagy beszúrása két vezérlőponttal és egy végponttal. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Egy kvadratikus Bézier‑görbe hozzáfűzése vagy beszúrása egy vezérlőponttal és egy végponttal. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Egy ellipszisív ív hozzáfűzése a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Az aktuális alakzat lezárása az útvonal végpontjának a kezdőponthoz csatlakoztatásával. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Egy alakzat kezdeti pontjának beállítása. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Egy szegmens eltávolítása a nullától kezdődő index alapján. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Egyedi pontok hozzáadása egy alakzathoz**

Ez a példa két pontot illeszt be egy téglalapba a [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) segítségével, majd a szerkesztett útvonalat az [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)‑val alkalmazza. A koordináták az alakzathoz helyiértékűek: mindkét új pont a középénél van, 100 ponttól a bal szél, 50 ponttól a felső szél. Az 1‑es és 4‑es szegmens‑indexek a felső és alsó élre helyezik őket, ezáltal az él(ek) befelé húzódnak.

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

## **Pontok eltávolítása egy alakzatból**

Ez a példa a szív alakú körvonalat módosítja a [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) metódussal, az index 2‑nél elvégzett eltávolítással. Az [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)‑val alkalmazott módosított útvonal frissíti az alakzat kontúrját.

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

## **Egyedi alakzat létrehozása**

Ez a példa egy ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) használatával. A 100 és 50 pont közötti váltakozó külső‑ és belső‑sugár határozza meg a csúcsokat és a beütéseket; a 72‑fokos lépés egyenlő távolságra helyezi el az öt csúcsot. Az útvonalat a [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) zárja le, majd egy téglalapra az [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) alkalmazza, felülírva az eredeti körvonalat.

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

## **Összetett egyedi alakzat létrehozása**

Ez a példa két lezárt [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) objektumot definiál a forma felső és alsó harmadához. A két útvonal [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) segítségével történő alkalmazása egyetlen összetett alakzatot eredményez, amelynek középső harmadában rés keletkezik.

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

## **Egyedi alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) metódussal, így hozva létre egy alakzatot, amelynek sarkai befelé ívelnek. Minden sarokméret a körív szélességét és magasságát adja pontban, a -90‑fokos ív egy óramutató járásával ellentétes negyed‑ellipszist rajzol. A kész útvonalat az [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) alkalmazza, majd a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy egy alakzat geometria lezárt‑e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmenssel végződik‑e. A [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) beolvasásával összehasonlítja a végső szegmens [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) értékét a [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/)‑val. Ha nincs nem üres útvonal, hamis értéket ad vissza. Ez a függvény az egyes útvonalak végső parancsát ellenőrzi; nem vizsgálja meg az útvonal minden alalakzatát. A példa egy téglalap esetén `true`‑t ír ki.

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

## **Geometriai útvonal‑parancsok vizsgálata**

Töltse le a [contour.pptx](contour.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dián az első alakzatnak egy egyenes felső él, egy kockás Bézier‑görbe és egy egyenes záró él van. Használja a [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódust az alakzat útvonalainak beolvasásához, majd a [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) metódust az egyes útvonalak szegmenseinek a rajzolási sorrendben való lekéréséhez. Minden szegmenshez a [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) adja meg a parancsot, és meghatározza, hogyan kell értelmezni a [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) által visszaadott értékeket.

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

Az alakzat a dia (200, 100) pontján helyezkedik el. A jelentett koordináták az alakzathoz helyiértékűek, a (0, 0) a bal‑felső sarkban van, az x jobbra, az y pedig lefelé nő. A záró szegmens a kezdőpontra tér vissza további koordináták nélkül.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Alakzat‑elemek kinyerése és vizsgálata**

Használja a [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) metódust egy meglévő alakzat elemeinek megtekintéséhez, amelyek útvonal‑pontokat és pont‑típusokat tartalmaznak. A visszakapott [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) objektumokat konvertálja [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) típusra, majd a [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) és a [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) metódusokkal kapja meg a pont‑ és típus‑tömböket. Ez a reprezentáció hasznos a kontúr‑elemzéshez vagy a geometria egyedi rajzoló‑eszközökbe való átadásához.

A példa megnyitja az input.pptx‑t, megtalálja az első geometriai alakzatot az első dián, és kiírja a szegmenseket. Használjon egy olyan prezentációt, amelynek alakzata egyenlő és ívelt szegmenseket is tartalmaz, hogy mindkét kimenetet lássa. Nem keres csoportok belsejében.

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
                int pointType = types[i] & 0x07; // Megtartja a szegmens típusát, a flag-eket kizárva.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Fogyasztja a két vezérlőpontot és a végpontot.
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

A tömbök index szerint egyeznek: a `points[i]` egy pont, a `types[i]` pedig a szerepét írja le. A `0` típus egy alakzatot indít, az `1` típus egy vonalat rajzol az előző pontból az aktuális pontba. Egy kockás Bézier‑szegmens a előző végpontból indul, és három egymást követő `3`‑as típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeket a három bejegyzést egyszerre fogyasztja, és ellenőrzi a végpontot a lezárás szempontjából.

A pont‑típusok további flag‑eket is tartalmaznak. Használja a `0x07` maszkot a szegmens‑típus azonosításához, a `0x80`‑at külön a lezárt alútvonal felismeréséhez. Például a `129` (`0x81`) egy vonal‑végpont, amely lezár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén lezár. A Java ezeket a flag‑eket előjeles bájtokban tárolja; a maszkolás megőrzi a kívánt bit‑értékeket. A nyers érték `1`‑ vagy `3`‑mal való összehasonlítása kihagyja ezeket az eseteket. Egyéb flag‑ek, mint a szaggatás (`0x10`) vagy a marker (`0x20`), nem változtatják a szegmens‑alaptípust.

**Koordináták és transzformációk.** A pontok pontban vannak mérve (1/72 hüvelyk), az X jobbra, a Y pedig lefelé nő. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) és a [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) által visszaadott pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy nem elforgatott téglalap a `(100, 200)` pontban, mérete `120 × 80`, kontúrboundsza `(100, 200)`‑`(220, 280)`. Ne adja hozzá újra az alakzat pozícióját; vonja ki az X‑et és Y‑t a relatív koordinátákhoz.

A kinyert pontok nem alkalmazzák az alakzat [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) által visszaadott forgását, vagy a vízszintes‑, függőleges tükrözéseket. A megjelenített kontúr reprodukálásához ezeket a transzformációkat az alakzat középpontja körül alkalmazza. Csoportos alakzatok esetén vegye figyelembe a csoportkoordináta‑leképezést és a transzformációkat; ne feltételezze, hogy a kinyert pontok már a végső diákoordináták, és ne alkalmazzon kétszeres eltolást vagy méretezést, ha már be vannak építve a gyermek keretbe.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a kontúrt írják le; módosításuk nem frissíti az eredeti alakzatot. Ezt a módszert akkor válassza, ha elemzés‑ vagy rajzoló‑kódja pont‑/típus‑tömböket igényel. Használja a [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódust, ha a geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha szerkeszteni szeretné a geometria­t. Az szerkesztett útvonalak alkalmazásához használja a [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) vagy a [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metódusokat.

## **Java AWT Shape konvertálása GeometryPath‑ra**

Ez a példa egy téglalap körvonalat kombinál a szöveg geopetikus átalakításával. A körvonal [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metódusa letiltja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveges körvonalat egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)-ban. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás, vonal, kvadratikus, kockás és záró szegmenseket ad, amelyeket a példa egy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)‑ra játssza le.

A szöveg 40‑pont Arial betűtípussal jelenik meg. A körvonal 20 ponttal vízszintesen eltolódik, és a vizuális teteje 10 ponttal a forma felső élétől lefelé helyezkedik el. A szöveg útvonal kitöltött, míg az eredeti téglalap csak körvonalas. A két útvonal [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) alkalmazásával egyetlen alakzat jön létre, amely tartalmazza a téglalapot és a szöveget.

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
    // Új alakzat létrehozása
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Az alakzat geometriai útvonalának lekérése
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Új grafikus útvonal létrehozása szöveggel
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

    // Grafikus útvonal konvertálása geometriai útvonalra
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

    // Az új és az eredeti geometriai útvonal kombinációjának beállítása az alakzatra
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus megmarad az alakzaton; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerül.

**Hogyan forgathatom helyesen az egyedi alakzatot a geometriájával együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) metódusát; a geometria az alakzattal együtt forog, mivel az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom az egyedi alakzatot képpé a "lezárás" érdekében?**

Igen. Exportálja a kívánt [slide](/slides/hu/java/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/java/create-shape-thumbnails/)‑t raszteres formátumba; ez egyszerűsíti a komplex geometriák további feldolgozását.