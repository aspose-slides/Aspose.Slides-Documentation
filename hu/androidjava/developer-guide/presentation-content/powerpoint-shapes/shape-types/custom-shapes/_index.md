---
title: Alakzatok testreszabása prezentációkban Androidon
linktitle: Egyedi alakzat
type: docs
weight: 20
url: /hu/androidjava/custom-shape/
keywords:
- egyedi alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai útvonal
- útvonal pontok
- szerkesztőpontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- görbe sarok
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Android Java segítségével: geometriai útvonalak, görbe sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a megjelenítési alakzatok az Aspose.Slides‑ben úgy, hogy a forma geometriáját szerkesztőpontokkal és geometriai útvonalakkal módosítjuk. Megmutatja, hogyan használható a `GeometryPath` és az `IGeometryPath` meglévő alakzatok módosítására, alapvető útvonal‑szerkesztési műveletek végrehajtására, pontok hozzáadására vagy eltávolítására, valamint a frissített geometria alakzatra való alkalmazására.

Emellett bemutatja, hogyan hozhatók létre egyedi és összetett alakzatok, hogyan építhetők görbe sarkokkal rendelkező alakzatok, hogyan határozható meg, hogy egy alakzat geometriája zárt‑e, valamint hogyan konvertálható a `GeometryPath` és a `java.awt.Shape` egymásba további geometriák testreszabási forgatókönyveihez.

## **Alakzat módosítása szerkesztőpontokkal**
Tekintsünk egy négyzetet. A PowerPointban **szerkesztőpontok** használatával a következőket tehetjük:

* a négyzet sarkát be‑ vagy kifelé mozgatni
* egy sarok vagy pont görbületét megadni
* új pontokat hozzáadni a négyzethez
* a négyzet pontjait manipulálni, stb.

Lényegében a leírt feladatok bármely alakzatra elvégezhetők. A szerkesztőpontok segítségével módosítható egy alakzat, vagy új alakzat hozható létre egy meglévőből.

## **Alakzatszerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt szerkesztenél PowerPoint‑alakzatokat szerkesztőpontokkal, vedd figyelembe a következőket az alakzatokkal kapcsolatban:

* Egy alakzat (vagy annak útvonala) lehet zárt vagy nyitott.
* Zárt alakzatnál nincs kezdeti vagy végpont, nyitott alakzatnál van kezdete és vége.
* Minden alakzat legalább 2 horgonypontból áll, amelyeket vonalak kötnek össze.
* A vonal lehet egyenes vagy íves. A horgonypontok határozzák meg a vonal jellegét.
* A horgonypontok lehetnek sarokpontok, egyenes pontok vagy sima pontok:
  * Egy sarokpont az a pont, ahol 2 egyenes vonal szöget zár be.
  * Egy sima pont az a pont, ahol 2 kontrolpont egyenes vonalban helyezkedik el, és a vonal szegmensei sima görbével csatlakoznak. Ilyenkor a kontrolpontok egyenlő távolságra vannak a horgonyponttól.
  * Egy egyenes pont az a pont, ahol 2 kontrolpont egyenes vonalban található, de a vonal szegmensei nem feltétlenül csatlakoznak egyenlő távolságra a horgonyponttól.
* Horgonypontok mozgatásával vagy szerkesztésével (ami a vonalak szögét változtatja) megváltoztatható az alakzat megjelenése.

PowerPoint‑alakzatok szerkesztőpontokkal történő szerkesztéséhez az **Aspose.Slides** a [**GeometryPath**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályt és az [**IGeometryPath**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryPath) interfészt biztosítja.

* Egy [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) példány a [IGeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape) objektum geometriai útvonalát reprezentálja.
* A `GeometryPath` lekéréséhez a `IGeometryShape` példányból a [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) metódust használhatod.
* Egy alakzat `GeometryPath`‑jának beállításához a következő metódusok állnak rendelkezésre: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) *szilárd alakzatok* esetén és [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) *összetett alakzatok* esetén.
* Szegmensek hozzáadásához az [IGeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryPath) alatti metódusokat használhatod.
* Az [IGeometryPath.setStroke](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) és az [IGeometryPath.setFillMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) metódusokkal beállítható egy geometriai útvonal megjelenése.
* Az [IGeometryPath.getPathData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryPath#getPathData--) metódussal a `GeometryShape` útvonaladatai szegmens tömbként kérhetők le.
* További alakzatgeometria‑testreszabási lehetőségek eléréséhez a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) konvertálható a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) típusra.
* A [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) és a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metódusok (a [ShapeUtil](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeUtil) osztályból) segítségével a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) visszakonvertálható a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) típusra és fordítva.

## **Egyszerű szerkesztési műveletek**

Ez a Java‑kód bemutatja, hogyan

**Adjunk hozzá egy vonalat** egy útvonal végéhez

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Adjunk hozzá egy vonalat** egy megadott pozícióban az útvonalon:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Adjunk hozzá egy köbös Bézier‑görbét** az útvonal végére:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Adjunk hozzá egy köbös Bézier‑görbét** a megadott pozícióba az útvonalon:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Adjunk hozzá egy kvadratikus Bézier‑görbét** az útvonal végére:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Adjunk hozzá egy kvadratikus Bézier‑görbét** a megadott pozícióba az útvonalon:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Fűzzünk hozzá egy adott ívet** az útvonalhoz:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Zárjuk le a jelenlegi alakzatot** egy útvonalon:

``` java
public void closeFigure();
```
**Állítsuk be a következő pont pozícióját**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Távolítsuk el a szegmenst** a megadott indexnél:

``` java
public void removeAt(int index);
```

## **Egyedi pontok hozzáadása egy alakzathoz**
1. Hozz létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryShape) osztályból, és állítsd be a [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeType) típust.
2. Szerezz egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályból az alakzatról.
3. Adj hozzá egy új pontot a két felső pont közé az útvonalon.
4. Adj hozzá egy új pontot a két alsó pont közé az útvonalon.
5. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód mutatja, hogyan adhatunk egyedi pontokat egy alakzathoz:

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

## **Pontok eltávolítása egy alakzatból**

1. Hozz létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryShape) osztályból, és állítsd be a [ShapeType.Heart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeType) típust.
2. Szerezz egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályból az alakzatról.
3. Távolítsd el a szegmenst az útvonalból.
4. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód mutatja, hogyan távolíthatók el pontok egy alakzatból:

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

1. Számold ki az alakzat pontjait.
2. Hozz létre egy példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályból.
3. Töltsd fel az útvonalat a pontokkal.
4. Hozz létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryShape) osztályból.
5. Alkalmazd az útvonalat az alakzatra.

Ez a Java‑kód bemutatja, hogyan hozhatsz létre egy egyedi alakzatot:

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

1. Hozz létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryShape) osztályból.
2. Hozz létre egy első példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályból.
3. Hozz létre egy második példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) osztályból.
4. Alkalmazd a két útvonalat az alakzatra.

Ez a Java‑kód bemutatja, hogyan hozhatsz létre egy összetett egyedi alakzatot:

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

## **Egyedi alakzat létrehozása görbe sarkokkal**

Ez a Java‑kód megmutatja, hogyan hozhatsz létre egy egyedi alakzatot görbe (befelé ívelő) sarkokkal:

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

## **Megállapítás, hogy egy alakzat geometriája zárt‑e**

A zárt alakzat olyan, amelynek minden oldala összekapcsolódik, így egyetlen határoló nélkülös szegmens keletkezik. Ilyen alakzat lehet egy egyszerű geometriai forma vagy egy komplex egyedi körvonal. Az alábbi kódrészlet megmutatja, hogyan ellenőrizhető, hogy az alakzat geometriája zárt‑e:

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

1. Hozz létre egy példányt a [GeometryShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryShape) osztályból.
2. Hozz létre egy példányt a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) osztályból.
3. A [ShapeUtil](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapeUtil) segítségével konvertáld a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GeometryPath) példányra.
4. Alkalmazd a kapott útvonalakat az alakzatra.

Ez a Java‑kód – a fenti lépések megvalósítása – demonstrálja a **GeometryPath**‑ról **GraphicsPath**‑ra történő konverzió folyamatát:

``` java
Presentation pres = new Presentation();
try {
    // Új alakzat létrehozása
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Az alakzat geometriai útvonalának lekérése
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

    // A grafikus útvonal konvertálása geometriai útvonalra
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

**Mi történik a kitöltéssel és körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a kontúr változik. A kitöltés és a körvonal automatikusan az új geometriára kerül alkalmazásra.

**Hogyan forgathatom helyesen a saját alakzatot a geometriájával együtt?**

Használd az alakzat [setRotation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#setRotation-float-) metódusát; a geometria az alakzattal együtt forog, mivel az az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom-e a saját alakzatot egy képpé a „lezáráshoz”?**

Igen. Exportáld a kívánt [slide](/slides/hu/androidjava/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/androidjava/create-shape-thumbnails/)‑t raszteres formátumba; ez megkönnyíti a nehéz geometriákkal való további munkát.