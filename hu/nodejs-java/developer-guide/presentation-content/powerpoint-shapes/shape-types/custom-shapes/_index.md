---
title: Prezentációs alakzatok testreszabása JavaScriptben
linktitle: Egyéni alakzat
type: docs
weight: 20
url: /hu/nodejs-java/custom-shape/
keywords:
- egyéni alakzat
- alakzat hozzáadása
- alakzat létrehozása
- alakzat módosítása
- alakzat geometria
- geometriai út
- út pontok
- szerkesztő pontok
- pont hozzáadása
- pont eltávolítása
- szerkesztési művelet
- görbe sarok
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alakzatok létrehozása és testreszabása PowerPoint prezentációkban JavaScript és Aspose.Slides for Node.js segítségével: geometriai utak, görbe sarkok, összetett alakzatok."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a prezentáció alakzatokat az Aspose.Slides-ban a forma geometriájának szerkesztésével szerkesztő pontok és geometriai utak segítségével. Megmutatja, hogyan lehet a `GeometryPath`‑sal dolgozni meglévő alakzatok módosításához, alapvető út szerkesztési műveletek elvégzéséhez, pontok hozzáadásához vagy eltávolításához, és a frissített geometria alkalmazásához egy alakzatra.

Ez továbbá bemutatja, hogyan lehet egyéni és összetett alakzatokat létrehozni, görbe sarkokkal rendelkező alakzatokat építeni, meghatározni, hogy egy alakzat geometria zárt‑e, és konvertálni a `GeometryPath` és a `java.awt.Shape` között további geometriai testreszabási esetekhez.

## **Alakzat módosítása szerkesztő pontokkal**

Tekintsünk egy négyzetet. A PowerPointban, **szerkesztő pontok** használatával, a következőket teheted:

* a négyzet sarkát be vagy ki lehet húzni
* meghatározni egy sarok vagy pont görbületét
* új pontokat hozzáadni a négyzethez
* a négyzet pontjait manipulálni, stb. 

Lényegében ezeket a feladatokat bármelyik alakzaton elvégezheted. Szerkesztő pontok használatával módosíthatsz egy alakzatot vagy új alakzatot hozhatsz létre egy meglévőből. 

## **Alakzat szerkesztési tippek**

![overview_image](custom_shape_0.png)

Mielőtt elkezdenél PowerPoint alakzatokat szerkeszteni szerkesztő pontok segítségével, érdemes átgondolnod ezeket a pontokat az alakzatokkal kapcsolatban:

* Egy alakzat (vagy az útja) lehet zárt vagy nyitott.
* Ha egy alakzat zárt, nincs kezdő vagy végpontja. Ha nyitott, van kezdete és vége. 
* Minden alakzat legalább 2 rögzítési pontból áll, amelyeket vonalak kötnek össze
* A vonal lehet egyenes vagy görbe. A rögzítési pontok határozzák meg a vonal jellegét. 
* A rögzítési pontok léteznek sarkpontként, egyenes pontként vagy sima pontként:
  * A sarokpont egy olyan pont, ahol 2 egyenes vonal szöggel csatlakozik. 
  * A sima pont egy olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonal szegmensei sima ívben csatlakoznak. Ebben az esetben minden fogantyú egyenlő távolságra van a rögzítési ponttól. 
  * Egy egyenes pont egy olyan pont, ahol 2 fogantyú egy egyenes vonalon helyezkedik el, és a vonal szegmensei sima ívben csatlakoznak. Ebben az esetben a fogantyúk nem kell, hogy egyenlő távolságra legyenek a rögzítési ponttól. 
* A rögzítési pontok mozgatásával vagy szerkesztésével (ami a vonalak szögét változtatja) megváltoztathatod egy alakzat kinézetét. 

A PowerPoint alakzatok szerkesztéséhez szerkesztő pontokkal, az **Aspose.Slides** biztosítja a [**GeometryPath**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) osztályt és a [**GeometryPath**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) osztályt.

* A [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példány a [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) objektum geometriai útvonalát képviseli.
* A `GeometryPath` lekéréséhez a `GeometryShape` példányból, használhatod a [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) metódust.
* A `GeometryPath` beállításához egy alakzatra, használhatod ezeket a metódusokat: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) a *szilárd alakzatok* és [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) a *összetett alakzatok* esetén.
* Szegmensek hozzáadásához használhatod a [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) alatti metódusokat.
* A [GeometryPath.setStroke](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) és a [GeometryPath.setFillMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) metódusokkal beállíthatod egy geometriai út megjelenését.
* A [GeometryPath.getPathData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath#getPathData--) metódus segítségével lekérheted egy `GeometryShape` geometriai útját útvonal‑szegmensek tömbjeként.
* További alakzat geometria testreszabási lehetőségek eléréséhez konvertálhatod a [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath)‑ot [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑ra.
* Használd a [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) és a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metódusokat (a [ShapeUtil](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeUtil) osztályból) a [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) és a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) közötti átalakításhoz oda és vissza.

## **Egyszerű szerkesztési műveletek**

Ez a JavaScript kód megmutatja, hogyan

**Sor hozzáadása** egy út végéhez

```javascript
lineTo(point);
lineTo(x, y);
```
**Sor hozzáadása** egy megadott pozícióra az úton:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Köbös Bézier-görbe hozzáadása** egy út végéhez:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Köbös Bézier-görbe hozzáadása** a megadott pozícióra az úton:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Másodfokú Bézier-görbe hozzáadása** egy út végéhez:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Másodfokú Bézier-görbe hozzáadása** a megadott pozícióra az úton:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Adott ív hozzáfűzése** egy útvonalhoz:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Az aktuális alakzat lezárása** egy útvonalon:

```javascript
closeFigure();
```
**A következő pont pozíciójának beállítása**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Az út szegmensének eltávolítása** egy megadott indexnél:

```javascript
removeAt(index);
```

## **Egyéni pontok hozzáadása egy alakzathoz**
1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) példányt, és állítsd be a [ShapeType.Rectangle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeType) típust.
2. Szerezz egy [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányt az alakzatról.
3. Adj hozzá egy új pontot a két felső pont között az útvonalon.
4. Adj hozzá egy új pontot a két alsó pont között az útvonalon.
5. Alkalmazd az útvonalat az alakzatra.

Ez a JavaScript kód megmutatja, hogyan lehet egyéni pontokat hozzáadni egy alakzathoz:

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

## **Pontok eltávolítása egy alakzatról**

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) példányt, és állítsd be a [ShapeType.Heart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeType) típust.
2. Szerezz egy [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányt az alakzatról.
3. Távolítsd el az útvonal szegmensét.
4. Alkalmazd az útvonalat az alakzatra.

Ez a JavaScript kód megmutatja, hogyan lehet pontokat eltávolítani egy alakzatról:

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

## **Egyéni alakzat létrehozása**

1. Számold ki az alakzat pontjait.
2. Hozz létre egy [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányt.
3. Töltsd fel az útvonalat a pontokkal.
4. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) példányt.
5. Alkalmazd az útvonalat az alakzatra.

Ez a JavaScript megmutatja, hogyan hozhatsz létre egy egyéni alakzatot:

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


## **Összetett egyéni alakzat létrehozása**

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) példányt.
2. Hozz létre egy első [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányt.
3. Hozz létre egy második [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányt.
4. Alkalmazd az útvonalakat az alakzatra.

Ez a JavaScript kód megmutatja, hogyan lehet összetett egyéni alakzatot létrehozni:

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

## **Egyéni alakzat létrehozása görbe sarkokkal**

Ez a JavaScript kód megmutatja, hogyan lehet egyéni alakzatot létrehozni görbe sarkokkal (befelé);

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

## **Megállapítás, hogy egy alakzat geometria zárt‑e**

A zárt alakzat olyan, amelynek minden oldala összekapcsolódik, egyetlen határt képezve rés szakadások nélkül. Egy ilyen alakzat lehet egyszerű geometriai forma vagy összetett egyéni körvonal. A következő kódrészlet megmutatja, hogyan ellenőrizheted, hogy egy alakzat geometria zárt‑e:

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

## **GeometryPath konvertálása java.awt.Shape objektummá** 

1. Hozz létre egy [GeometryShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryShape) példányt.
2. Hozz létre egy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) példányt.
3. Konvertáld a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) példányt a [GeometryPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/GeometryPath) példányra a [ShapeUtil](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ShapeUtil) segítségével.
4. Alkalmazd az útvonalakat az alakzatra.

Ez a JavaScript kód – a fenti lépések megvalósítása – bemutatja a **GeometryPath**‑ról **GraphicsPath**‑ra történő konverzió folyamatát:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Új alakzat létrehozása
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Az alakzat geometriai útvonalának lekérése
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Új grafikus útvonal létrehozása szöveggel
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
    // Grafikus útvonal konvertálása geometriai útra
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Az új geometriai út és az eredeti geometriai út kombinációjának beállítása az alakzatra
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **GYIK**

**Mi történik a kitöltéssel és a körvonallal a geometria cseréje után?**

A stílus az alakzaton marad; csak a körvonal változik. A kitöltés és a körvonal automatikusan alkalmazásra kerül az új geometriára.

**Hogyan tudom helyesen elforgatni egy egyéni alakzatot a geometriai adataival együtt?**

Használd az alakzat [setRotation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/setrotation/) metódusát; a geometria az alakzattal együtt forog, mert az alakzat saját koordináta‑rendszeréhez van kötve.

**Átalakíthatom‑e egy egyéni alakzatot képpé, hogy "lezárjam" az eredményt?**

Igen. Exportáld a szükséges [slide](/slides/hu/nodejs-java/convert-powerpoint-to-png/) területet vagy magát a [shape](/slides/hu/nodejs-java/create-shape-thumbnails/) raszteres formátumba; ez leegyszerűsíti a nehéz geometriákkal való további munkát.