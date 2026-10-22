---
title: Prezentációs alakzatok testreszabása Java-ban
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/java/custom-shape/
keywords:
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzatgeometria
- geometriai útvonal
- útvonal pontok
- szerkesztő pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Java segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides‑ban úgy, hogy a forma geometriáját szerkesztő pontok és geometriai útvonalak segítségével módosítjuk. Bemutatja, hogyan kell használni a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) és a [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) elemeket a meglévő alakzatok módosításához, az alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, és a frissített geometria alkalmazásához egy alakzatra.

Emellett azt is bemutatja, hogyan hozhatunk létre egyéni és összetett alakzatokat, hogyan építhetünk ívelt sarkú alakzatokat, hogyan állapítható meg, hogy egy forma geometria zárt‑e, hogyan vizsgálhatók meg az alakzat elemei, és hogyan konvertálhatók a Java AWT szöveg körvonalak geometriai útvonalakká.

## **Alakzat módosítása szerkesztő pontokkal**

* Mozgassa be vagy ki egy sarkot.
* Állítsa be a görbületet egy pontnál.
* Adjon hozzá új pontokat.

A szerkesztő pontok lehetővé teszik az alakzat körvonalának módosítását vagy egy meglévő alakzat használatát új alapként.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor tartsa szem előtt az alábbi fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy görbe. A horgonypontok és a vezérlő fogantyúk határozzák meg alakját.
* A horgonypontok lehetnek sarkok, egyenes vagy sima pontok:
  * Sarkpontnál a szomszédos szegmensek szöggel találkozhatnak.
  * Simapontnál a két vezérlő fogantyú igazított és egyenlő távolságra van a horgonyponttól.
  * Egyenespontnál a két vezérlő fogantyú igazított, de különböző távolságban lehet a horgonyponttól.
* A horgonypontok mozgatása vagy a fogantyúk beállítása megváltoztatja az alakzat körvonalát.

A PowerPoint‑alakzatok szerkesztéséhez a **Aspose.Slides** a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) osztályt és a [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) interfészt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) példány egy geometriai útvonalat képvisel az [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) objektumban.
* A [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) lekéréséhez az [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) példányból használhatja az [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódust.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) beállításához használhatja ezeket a metódusokat: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) egyetlen útvonallal rendelkező alakzatokhoz és [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) több útvonallal rendelkező alakzatokhoz.
* Szegmensek hozzáadásához használhatja az [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) alatti metódusokat.
* Az [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) és [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metódusokkal beállíthatja egy geometriai útvonal megjelenését.
* Az [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) metódussal lekérhet egy [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) geometriai útvonalát útvonal‑szegmens tömbként.
* További alakzat‑geometria testreszabási lehetőségekhez beolvashat egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumot a hozzá tartozó [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) segítségével, és újrajátszhatja a szegmenseket egy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) objektumban.

## **Egyszerű szerkesztési műveletek**

Az alábbi metódusokkal szerkesztheti egy geometriai útvonalat. Az indexet elfogadó túlterhelések a szegmenst a szegmens tömb nulláról indexelt pozíciójába szúrják be.

| Operation | Method |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Köbös Bézier‑görbe hozzáadása vagy beszúrása két vezérlőponttal és végponttal. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Másodfokú Bézier‑görbe hozzáadása vagy beszúrása egy vezérlőponttal és végponttal. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Ellipszis ív hozzáadása a megadott méretekkel és fokban megadott szögekkel. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Az aktuális alakzat lezárása azzal, hogy a végpontját összeköti a kezdőponttal. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Szegmens eltávolítása nulláról indexelt pozíción. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) használatával, és a szerkesztett útvonalat alkalmazza a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) segítségével. A koordináták az alakzathoz relatívak: mindkét új pont az alakzat közepén helyezkedik el, 100 ponttól balra és 50 ponttól felül. Az 1‑es és 4‑es szegmens‑indexek a pontokat a felső és alsó élre helyezik, behúzva ezeket az éleket.

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

Ez a példa a szív alakú körvonalat módosítja azzal, hogy eltávolítja a nulláról indexelt 2‑es szegmenst a [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) használatával. A módosított útvonal alkalmazása a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) segítségével frissíti az alakzat körvonalát.

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

## **Egyéni alakzat létrehozása**

Ez a példa egy ötpontos csillagot épít fel a [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) segítségével. A 100 és 50 pont közti váltakozó külső és belső sugár definiálja a csúcsokat és a bemetszéseket; egy 72‑fokos lépés egyenletesen helyezi el az öt csúcsot. Az útvonal a [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) használatával záródik, és egy téglalap alakzatra alkalmazza a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) segítségével, ezzel felülírva annak körvonalát.

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

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) objektumot definiál egy alakzat felső és alsó harmadjához. Mindkét útvonal alkalmazása a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) segítségével egyetlen összetett alakzatot hoz létre, amelynek középső harmadja egy részt tartalmaz.

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

## **Egyéni alakzat létrehozása ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) használatával, hogy egy befelé ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarokméret beállítja az ív szélességét és magasságát pontban, a -90‑fokos ív pedig egy óramutatóval ellentétes negyed‑ellipszist rajzol. A befejezett útvonalat a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) segítségével alkalmazzák, és a prezentációt PPTX formátumban mentik.

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

## **Kiderítés, hogy egy alakzat geometriája zárt-e**

A következő segédprogram ellenőrzi, hogy minden nem üres geometriai útvonal lezáró szegmenssel végződik‑e. A [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) beolvassa, és az utolsó szegmens [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) értékét összehasonlítja a [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) értékkel. Ha nincs nem üres útvonal, hamisat ad vissza. Ez minden útvonal utolsó parancsát ellenőrzi; nem vizsgálja meg az útvonal minden alalakzatát. A példa `true` értéket ír ki egy téglalapra.

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

## **Alakzat elemeinek kinyerése és vizsgálata**

A [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) használatával vizsgálhat egy meglévő alakzatot, amely elemeket tartalmaz, útpontokkal és ponttípusokkal. Az egyes visszaadott [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) objektumot konvertálja [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/)‑re, hogy a [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) és [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) metódusok segítségével lekérje a pont- és típus‑tömböket. Ez a reprezentáció hasznos a körvonal‑analízishez vagy a geometria átadásához egyéni rajzoló eszközöknek.

A példa megnyitja az input.pptx fájlt, megtalálja az első geometriai alakzatot közvetlenül az első dián, és kiírja az útvonal szegmenseit. Használjon egy olyan prezentációt, amely alakzatot tartalmaz egyenes és görbe szegmensekkel, hogy mindkét kimenetet lássa. Nem keres a csoportok belsejében.

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
                int pointType = types[i] & 0x07; // Tartsa meg a szegmens típusát, a flag-ek nélkül.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Fogyasztja mindkét vezérlőpontot és a végpontot.
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

A tömbök index szerint egyeznek: a `points[i]` egy pont, a `types[i]` leírja a szerepét. A `0` típus egy alakzatot indít, az `1` típus egy vonalat rajzol az előző pontból a jelenlegi pontba. Egy köbös Bézier szegmens az előző végpontnál kezdődik, és három egymást követő `3` típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezeknek a három bejegyzésnek a fogyasztását végzi, és ellenőrzi a végpontot a zárás szempontjából.

A ponttípusok flag‑eket is tartalmaznak. A `0x07` maszkolással azonosítható a szegmens típusa, a `0x80` önálló tesztelése pedig a zárt alútvonal felismerésére szolgál. Például a `129` (`0x81`) egy vonalvégpontot jelent, amely zár egy alútvonalat, a `131` (`0x83`) pedig egy Bézier‑végpontot, amely szintén zár. A Java ezeket a flag‑eket előjeles bájtokban tárolja; a maszkolás megőrzi a kívánt bitértékeket. Ha csak a nyers értéket hasonlítjuk `1`‑gyel vagy `3`‑mal, ezek az esetek kimaradnak. Egyéb flag‑ek, mint a szaggatás (`0x10`) és a marker (`0x20`), nem változtatják a szegmens alap típusát.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) mérnek, az X jobbra, a Y pedig lefelé nő. Egy csoportosítatlan alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) és [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) által visszaadott pozíciót, és tükrözik a jelenlegi szélességét és magasságát. Például egy nem elfordított téglalap a `(100, 200)` helyen, `120 × 80` mérettel, a körvonalhatárait `(100, 200)`–`(220, 280)` adja. Ne adja hozzá újra az alakzat pozícióját. Vonja ki az X és Y értékét, hogy a koordináták a nem elfordított kerethez viszonyítva legyenek.

A kinyert pontok nem alkalmazzák az alakzat [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) által visszaadott forgását, vagy a vízszintes és függőleges tükrözéseket. A megjelenített körvonal reprodukálásához alkalmazza ezeket a transzformációkat az alakzat középpontja körül. Csoportosított alakzatok esetén vegye figyelembe a csoport koordináta leképezését és transzformációit; ne feltételezze, hogy a kinyert pontok a végleges megjelenített dia koordináták, és ne alkalmazzon kétszer fordítási vagy méretezési lépést, ha az már a gyermek keretben tükröződik.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök leírják a körvonalat; azok módosítása nem frissíti az eredeti alakzatot. Ezt a megközelítést válassza, ha elemzése vagy rajzoló kódja pont‑típus tömböket igényel. Használja a [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódust, ha geometriai parancsokra van szüksége az alakzat helyi koordináta‑rendszerében, vagy ha a geometriát szerkeszteni szeretné. Alkalmazza a szerkesztett útvonalakat a [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) vagy a [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) segítségével.

## **Java AWT Shape konvertálása GeometryPath‑re**

Ez a példa egy téglalap körvonalat kombinál a geometriává konvertált szöveggel. A körvonal [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metódusa kikapcsolja a kitöltést. Egy [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) hozza létre a szöveg körvonalát egy [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) objektumban. A [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) mozgás, vonal, kvadratikus, köbös és záró szegmenseket szolgáltat, amelyeket a példa újrajátssza egy [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) objektumban.

A szöveg 40‑pontos Arial betűtípussal kerül megjelenítésre. A körvonal 20 ponttal vízszintesen eltolódik, és a vizuális teteje 10 ponttal a alakzat felső szélétől helyezkedik el. A szöveg útvonal kitöltött, míg az eredeti téglalap csak körvonal marad. Mindkét útvonal alkalmazása a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) segítségével egyetlen alakzatot hoz létre, amely tartalmazza a téglalapot és a szöveget.

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

    // Új grafikai útvonal létrehozása szöveggel
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

    // Grafikai útvonal konvertálása geometriai útra
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

    // Az új geometriai útvonal és az eredeti geometriai útvonal kombinációjának beállítása az alakzatra
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a körvonal változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan lehet helyesen elforgatni egy egyéni alakzatot a geometriai adataival együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) metódusát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átkonvertálhatom-e egy egyéni alakzatot képpé a végeredmény „lezárásához”?**

Igen. Exportálja a szükséges [dia](/slides/hu/java/convert-powerpoint-to-png/) területet vagy az [alakzat](/slides/hu/java/create-shape-thumbnails/) maga raster formátumba; ez egyszerűsíti a komplex geometriák további kezelését.