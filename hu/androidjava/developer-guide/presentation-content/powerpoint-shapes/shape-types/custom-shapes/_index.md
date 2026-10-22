---
title: Alakzatok testreszabása prezentációkban Androidon
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/androidjava/custom-shape/
keywords:
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometriája
- geometriai útvonal
- útvonal pontok
- szerkesztési pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- ívelt sarok
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Android segítségével Java használatával: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a prezentáció alakzatai az Aspose.Slides‑ban a forma geometria szerkesztésével szerkesztési pontokon és geometriai útvonalakon keresztül. Megmutatja, hogyan dolgozhat a [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) és a [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) segítségével meglévő alakzatok módosítására, alapvető útvonal‑szerkesztési műveletek végrehajtására, pontok hozzáadására vagy eltávolítására, és a módosított geometria visszaalkalmazására egy alakzatra.

Emellett bemutatja, hogyan hozhat létre egyéni és összetett alakzatokat, hogyan építhet alakzatokat ívelt sarkokkal, hogyan határozhatja meg, hogy egy alakzat geometriája zárt‑e, és hogyan vizsgálhatja meg az alakzat elemeit Android ponttömbök használatával.

## **Alakzat módosítása szerkesztési pontokkal**

* Mozgassa a sarkot befelé vagy kifelé.
* Állítsa be a görbületet egy pontnál.
* Adjon hozzá új pontokat.

A pontok szerkesztése lehetővé teszi az alakzat körvonalának módosítását, vagy egy meglévő alakzat felhasználását új alapként.

## **Alakzat szerkesztési tippek**

![áttekintés_kép](custom_shape_0.png)

PowerPoint‑alakzatok szerkesztésekor vegye figyelembe a következő fogalmakat:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Az alakzat útvonala horgonypontokból áll, amelyeket szegmensek kötnek össze.
* Egy szegmens lehet egyenes vagy ívelt. A horgonypontok és a vezérlőkarok határozzák meg a formáját.
* A horgonypontok léteznek sarokpontként, egyenes pontként vagy sima pontként:
  * Sarokpontnál a szomszédos szegmensek egy szögnél találkozhatnak.
  * Sima pontnál a két vezérlőkar egy vonalban van és egyenlő távolságra van a horgonyponttól.
  * Egyenes pontnál a két vezérlőkar egy vonalban van, de különböző távolságra lehet a horgonyponttól.
* A horgonypontok mozgatása vagy a karok állítása megváltoztatja az alakzat körvonalát.

PowerPoint‑alakzatok szerkesztéséhez szerkesztési pontokkal a **Aspose.Slides** biztosítja a [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) osztályt és a [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) interfészt.

* Egy [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) példány a [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) objektum geometriai útvonalát képviseli.
* A [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) metódussal lekérheti a [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑t a [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) példányból.
* Egy alakzat [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)‑jának beállításához használhatja a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) metódust egyszeres útvonalú alakzatokhoz, valamint a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metódust többeszörös útvonalú alakzatokhoz.
* Szegmensek hozzáadásához a [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) alatti metódusokat használhatja.
* A [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) és a [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) metódusokkal beállíthatja egy geometriai útvonal megjelenését.
* A [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) metódussal lekérheti a [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) geometriai útvonalát útvonal‑szegmensek tömbjeként.

## **Egyszerű szerkesztési műveletek**

Használja a következő metódusokat egy geometriai útvonal szerkesztéséhez. Az indexet elfogadó túlterhelések egy szegmenst a nullától számított pozícióba illesztik be az útvonal szegmens‑tömbjében.

| Művelet | Metódus |
| --- | --- |
| Egyenes vonal hozzáadása vagy beszúrása. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| Köbös Bézier‑görbe hozzáadása vagy beszúrása két vezérlőponttal és egy végponttal. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Kvadratikus Bézier‑görbe hozzáadása vagy beszúrása egy vezérlőponttal és egy végponttal. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Elliptikus ív hozzáadása a megadott méretekkel és fokokban megadott szögekkel. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Az aktuális alakzat lezárása azzal, hogy a végpontját összeköti a kiindulási ponttal. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Az alakzat kezdőpontjának beállítása. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Szegmens eltávolítása a nulla‑alapú indexnél. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Egyéni pontok hozzáadása egy alakzathoz**

Ez a példa két pontot szúr be egy téglalap alakzatba a [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) használatával, majd a szerkesztett útvonalat a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)‑vel alkalmazza. A koordináták az alakzatra lokálisak: mindkét új pont a középpontban van, 100 pontbalra a bal szélről és 50 pontbalra a felső szélről. Az 1 és 4 indexű szegmensek a felső és alsó élekre helyezik őket, behúzva ezeket az éleket.

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

![példa1_kép](custom_shape_1.png)

## **Pontok eltávolítása egy alakzatból**

Ez a példa egy szív alakú körvonalat módosít úgy, hogy eltávolítja a nullától számított 2‑es indexű szegmenst a [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) használatával. A módosított útvonal [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)‑vel történő alkalmazása frissíti az alakzat körvonalát.

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
![példa2_kép](custom_shape_2.png)

## **Egyéni alakzat létrehozása**

Ez a példa ötágú csillagot épít a [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) segítségével. A külső és belső sugarak 100 és 50 pont váltakozása határozza meg a csúcsokat és a benyúlásokat; egy 72‑fokos lépés egyenlő távolságra helyezi el az öt csúcsot. Az útvonalat a [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) zárja le, majd a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) alkalmazza egy téglalap alakzatra, felülírva annak körvonalát.

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
![példa3_kép](custom_shape_3.png)

## **Összetett egyéni alakzat létrehozása**

Ez a példa két zárt [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) objektumot definiál az alakzat felső és alsó harmadjára. Mindkét útvonal [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) használatával történő alkalmazása egyetlen összetett alakzatot hoz létre, amelynek középső harmada rés van.

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
![példa4_kép](custom_shape_4.png)

## **Egyéni alakzat ívelt sarkokkal**

Ez a példa egyenes szegmenseket kombinál a [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) hívásával, hogy egy befelé ívelt sarkokkal rendelkező alakzatot hozzon létre. Minden sarokméret a bolygó szélességét és magasságát pontban adja meg, a -90‑fokos ív pedig egy óramutató járásával ellentétes negyed‑ellipszist rajzol. A kész útvonalat a [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) alkalmazza, és a prezentációt PPTX formátumban menti.

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

## **Megállapítás, hogy egy alakzat geometriája zárt-e**

Az alábbi segédfüggvény ellenőrzi, hogy minden nem üres geometriai útvonal záró szegmensekkel végződik‑e. A [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) olvasásával összehasonlítja az utolsó szegmens [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) értékét a [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/)‑val. Üres útvonal esetén hamis értéket ad vissza. Ez a függvény minden útvonal végső parancsát ellenőrzi; nem vizsgálja meg az egyes alalakzatokat az útvonalon belül. A példa egy téglalap esetén `true`‑t ír ki.

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

Használja a [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) metódust egy meglévő alakzat elemeinek megtekintéséhez, amelyek útvonal‑pontokat és pont‑típusokat tartalmaznak. Az egyes visszaadott [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) objektumot castolja [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/)‑re, hogy a [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) és a [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) metódusokkal lekérje a pont‑ és típus‑tömböket. Ez a reprezentáció hasznos kontúr‑analízishez vagy a geometria custom rajzoló eszközöknek történő átadásához.

A példa megnyit egy `input.pptx` fájlt, megtalálja az első geometriával rendelkező alakzatot az első dián, és kiírja az útvonal‑szegmenseit. Használjon olyan prezentációt, amelyben az alakzat egyenes és ívelt szegmenseket is tartalmaz, hogy mindkét kimenetet láthassa. A csoportokon belül nem keres.

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
                int pointType = types[i] & 0x07; // Tartsa meg a szegmens típusát, a flag-eket kizárva.
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

A tömbök index‑szerint párosodnak: `points[i]` egy pont, `types[i]` pedig annak szerepét írja le. A `0` típus új alakzatot indít, az `1` típus egy vonalat rajzol az előző pontból a jelenlegi pontba. Egy köbös Bézier‑szegmens a korábbi végpontból indul, három egymást követő `3` típusú bejegyzést használ: két vezérlőpontot, majd az új végpontot. A ciklus ezekhez a három bejegyzéshez egyszerre fér hozzá, és ellenőrzi a végpontot a zárás szempontjából.

A pont‑típusok flag‑eket is tartalmaznak. A `0x07` maszkkal határozható meg a szegmens típusa, a `0x80` flag önállóan jelez zárt alútvonalat. Például a `129` (`0x81`) egy vonal‑végpont, amely alútvonalat zár, a `131` (`0x83`) pedig egy Bézier‑végpont, amely szintén zár. A Java ezeket a flag‑eket aláírt byte‑ként tárolja; a maszkolás megőrzi a megfelelő bitértékeket. Ha csak a nyers értéket hasonlítaná `1`‑el vagy `3`‑mal, ezek a esetek kimaradnának. Más flag‑ek, például a szaggatottság (`0x10`) és a marker (`0x20`), nem változtatják az alap szegmens típust.

**Koordináták és transzformációk.** A pontok pontban (1/72 hüvelyk) vannak mérve, az X jobb felé, a Y lefele növekszik. Egy nem csoportosított alakzat esetén a kinyert koordináták már tartalmazzák a [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) és [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) által visszaadott pozíciót, valamint a jelenlegi szélességet és magasságot. Például egy elforgatás nélküli téglalap a `(100, 200)`‑as bal‑felső sarokkal és `120 × 80` mérettel a körvonal‑határolókat `(100, 200)`–`(220, 280)` adja. Ne adja hozzá újra az alakzat pozícióját; vonja ki az X‑et és Y‑t a lokális koordinátákhoz.

A kinyert pontok nem alkalmazzák az alakzat [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) által visszaadott forgatását, illetve a vízszintes és függőleges tükrözést. A megjelenített körvonal reprodukálásához ezeket a transzformációkat kell alkalmazni a középpont körül. Csoportos alakzatok esetén a csoportkoordináta‑leképezést és transzformációkat is figyelembe kell venni; ne tételezze, hogy a kinyert pontok már a végső diára vetített koordináták, és ne alkalmazzon kétszeres eltolást vagy skálázást, ha már a gyermek keretben szerepelnek.

**Vizsgálat vs. szerkesztés.** A kinyert tömbök a körvonalat írják le; azok módosítása nem frissíti az eredeti alakzatot. Ezt a megközelítést válassza, ha a pont‑típus tömbökre van szüksége elemzéshez vagy rajzoló kódhoz. Használja a [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--)‑t, ha a geometriai parancsokra van szüksége az alakzat lokális koordináta‑rendszerében, vagy ha szerkeszteni szeretné a geometriaát. Szerkesztett útvonalak alkalmazásához használja a [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) vagy a [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metódusokat.

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzattal marad; csak a körvonal változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan forgathatom helyesen egy egyéni alakzatot a geometriájával együtt?**

Használja az alakzat [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) metódusát; a geometria együtt forgik az alakzattal, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom‑e egy egyéni alakzatot képpé, hogy „lezárjam” az eredményt?**

Igen. Exportálja a szükséges [dia](/slides/hu/androidjava/convert-powerpoint-to-png/) területet vagy magát a [alakzat](/slides/hu/androidjava/create-shape-thumbnails/)‑t raster formátumba; ez egyszerűsíti a komplex geometriákkal való további munkát.