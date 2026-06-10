---
title: Prezentáció alakzatainak testreszabása Java-ban
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
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Java segítségével: geometriai útvonalak, ívelt sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides‑ban a alakzatgeometria szerkesztésével a szerkesztési pontok és geometriai útvonalak segítségével. Megmutatja, hogyan lehet a `GeometryPath` és az `IGeometryPath` osztályokkal dolgozni a meglévő alakzatok módosításához, alapvető útvonal‑szerkesztési műveletek végrehajtásához, pontok hozzáadásához vagy eltávolításához, valamint a frissített geometria alkalmazásához az alakzatra.

Ezen kívül bemutatja, hogyan hozhatunk létre egyedi és összetett alakzatokat, alakzatokat ívelt sarkokkal, hogyan határozhatjuk meg, hogy egy alakzatgeometria zárt‑e, valamint hogyan konvertálhatunk a `GeometryPath` és a `java.awt.Shape` között további geometriai testreszabási helyzetekben.

## **Alakzat módosítása szerkesztési pontokkal**

Gondolj egy négyzetre. A PowerPointban a **szerkesztési pontok** segítségével:

* a négyzet sarkát be‑ vagy kifelé mozgathatod
* megadhatod egy sarok vagy pont görbületét
* új pontokat adhat hozzá a négyzethez
* a négyzet pontjait manipulálhatod, stb.

Lényegében a leírt feladatok bármely alakzattal elvégezhetők. A szerkesztési pontok használatával alakzatot módosíthatsz vagy egy új alakzatot hozhatsz létre egy meglévőből.

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt a PowerPoint‑alakzatokat szerkesztési pontokkal módosítanád, érdemes figyelembe venni a következőket:

* Egy alakzat (vagy az útvonala) lehet zárt vagy nyitott.
* Zárt alakzat esetén nincs kezdő‑ vagy végpontja. Nyitott alakzatnak van kezdő és befejező pontja.
* Minden alakzat legalább 2 horgonypontból áll, amelyeket vonalak kötnek össze.
* A vonal lehet egyenes vagy ívelt. A horgonypontok határozzák meg a vonal típusát.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * A sarokpont az a pont, ahol 2 egyenes vonal találkozik szöggel.
  * A sima pont az a pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonal szegmensei sima ívet alkotnak. Ebben az esetben a fogantyúk azonos távolságra vannak a horgonyponttól.
  * Az egyenes pont az a pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, de a vonal szegmensei nem feltétlenül egyenlő távolságra vannak a horgonyponttól.
* A horgonypontok mozgatásával vagy szerkesztésével (amely a vonalak szögét változtatja) megváltoztathatod az alakzat megjelenését.

A PowerPoint‑alakzatok szerkesztési pontokkal történő módosításához az **Aspose.Slides** a [**GeometryPath**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) osztályt és a [**IGeometryPath**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryPath) interfészt biztosítja.

* A [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példány a [IGeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape) objektum geometriai útvonalát képviseli.
* Az `IGeometryShape` példányból a `GeometryPath` lekéréséhez használhatod a [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) metódust.
* Egy alakzathoz a `GeometryPath` beállításához a következő metódusok állnak rendelkezésre: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) **szilárd alakzatokhoz** és [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) **összetett alakzatokhoz**.
* Szegmensek hozzáadásához használhatod az [IGeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryPath) alatti metódusokat.
* Az [IGeometryPath.setStroke](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) és az [IGeometryPath.setFillMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) metódusokkal beállíthatod a geometriai útvonal megjelenését.
* Az [IGeometryPath.getPathData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryPath#getPathData--) metódussal lekérheted egy `GeometryShape` geometriai útvonalát útvonal‑szegmensek tömbjeként.
* További alakzat‑geometriai testreszabási lehetőségekhez konvertálhatod a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath)‑t a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) típusra.
* A [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) és a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metódusok (a [ShapeUtil](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeUtil) osztályból) segítségével a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) vissza‑ és előre is konvertálható a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) típusra.

## **Egyszerű szerkesztési műveletek**

Ez a Java‑kód megmutatja, hogyan lehet

**Vonal hozzáadása** az útvonal végéhez

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Vonal hozzáadása** egy megadott pozícióban az útvonalon:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Kúpszelet‑Bezier‑görbe hozzáadása** az útvonal végéhez:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Kúpszelet‑Bezier‑görbe hozzáadása** egy megadott pozícióban az útvonalon:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Másodfokú‑Bezier‑görbe hozzáadása** az útvonal végéhez:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Másodfokú‑Bezier‑görbe hozzáadása** egy megadott pozícióban az útvonalon:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Adott ív hozzáfűzése** az útvonalhoz:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Az aktuális alakzat lezárása** az útvonalon:

``` java
public void closeFigure();
```
**A következő pont pozíciójának beállítása**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Az útvonal‑szegmens eltávolítása** egy adott indexnél:

``` java
public void removeAt(int index);
```

## **Egyedi pontok hozzáadása egy alakzathoz**
1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryShape) példányt, és állítsd be a [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeType) típust.
2. Szerezd meg a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányt az alakzatról.
3. Adj egy új pontot a két felső pont közé az útvonalon.
4. Adj egy új pontot a két alsó pont közé az útvonalon.
5. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód megmutatja, hogyan adhatunk egyedi pontokat egy alakzathoz:

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

## **Pontok eltávolítása egy alakzatról**

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryShape) példányt, és állítsd be a [ShapeType.Heart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeType) típust. 
2. Szerezd meg a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányt az alakzatról.
3. Távolítsd el a szegmenst az útvonalról.
4. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód megmutatja, hogyan távolíthatók el a pontok egy alakzatról:

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

## **Egyedi alakzat létrehozása**

1. Számítsd ki az alakzat pontjait.
2. Hozz létre egy [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányt. 
3. Töltsd fel a pontokkal az útvonalat.
4. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryShape) példányt. 
5. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód megmutatja, hogyan hozhatsz létre egyedi alakzatot:

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


## **Összetett egyedi alakzat létrehozása**

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryShape) példányt.
2. Hozz létre egy első [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányt.
3. Hozz létre egy második [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányt.
4. Alkalmazd az útvonalakat az alakzatra.

Ez a Java‑kód megmutatja, hogyan hozhatsz létre összetett egyedi alakzatot:

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

## **Egyedi alakzat létrehozása ívelt sarkokkal**

Ez a Java‑kód megmutatja, hogyan hozhatsz létre egyedi alakzatot ívelt (befelé mutató) sarkokkal:

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Megállapítás, hogy egy alakzatgeometria zárt‑e**

A zárt alakzat olyan, amelynek minden oldalát összekapcsolja, egyetlen szépéllyel zárva, hézagok nélkül. Egy ilyen alakzat lehet egyszerű geometriai forma vagy összetett egyedi körvonal. Az alábbi kódrészlet megmutatja, hogyan ellenőrizheted, hogy egy alakzatgeometria zárt‑e:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **GeometryPath konvertálása java.awt.Shape‑ra** 

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryShape) példányt.
2. Hozz létre egy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) példányt.
3. A [ShapeUtil](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapeUtil) segítségével konvertáld a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/GeometryPath) példányra.
4. Alkalmazd az útvonalakat az alakzatra.

Ez a Java‑kód – a fenti lépések megvalósítása – demonstrálja a **GeometryPath**‑ról **GraphicsPath**‑ra történő konverziós folyamatot:

``` java
Presentation pres = new Presentation();
try {
    // Új alakzat létrehozása
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Az alakzat geometriájának útvonalának lekérése
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Új grafikus útvonal létrehozása szöveggel
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

    // Grafikus útvonal konvertálása geometriai útvonalra
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Az új geometriai útvonal és az eredeti geometriai útvonal kombinációjának beállítása az alakzatra
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria lecserélése után?**

A stílus az alakzattal marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan lehet helyesen elforgatni egy egyedi alakzatot a geometriájával együtt?**

Használd az alakzat [setRotation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#setRotation-float-) metódusát; a geometria az alakzattal együtt forog, mert az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom egy egyedi alakzatot képpé, „lezárva” a végeredményt?**

Igen. Exportáld a szükséges [slide](/slides/hu/java/convert-powerpoint-to-png/) területet vagy a [shape](/slides/hu/java/create-shape-thumbnails/) sajátját raszteres formátumba; ez leegyszerűsíti a nehéz geometriákkal való további munkát.