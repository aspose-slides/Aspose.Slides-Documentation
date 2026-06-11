---
title: Anpassa presentationsformer i JavaScript
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/nodejs-java/custom-shape/
keywords:
- anpassad form
- lägga till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigera punkter
- lägga till punkt
- ta bort punkt
- redigeringsoperation
- kurvat hörn
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js: geometribanor, kurvade hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur man anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri med redigeringspunkter och geometriska banor. Den visar hur man arbetar med `GeometryPath` för att ändra befintliga former, utföra enkla redigeringsoperationer på banor, lägga till eller ta bort punkter och applicera uppdaterad geometri tillbaka på en form.

Den visar också hur man skapar anpassade och sammansatta former, bygger former med kurvade hörn, avgör om en formgeometri är sluten, och konverterar mellan `GeometryPath` och `java.awt.Shape` för ytterligare scenarier för geometrianpassning.

## **Ändra en form med redigeringspunkter**

Tänk dig en kvadrat. I PowerPoint, med **redigeringspunkter**, kan du

* flytta kvadratens hörn inåt eller utåt
* ange krökning för ett hörn eller en punkt
* lägga till nya punkter på kvadraten
* manipulera punkter på kvadraten osv. 

I grund och botten kan du utföra de beskrivna uppgifterna på vilken form som helst. Med redigeringspunkter kan du förändra en form eller skapa en ny form från en befintlig form. 

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former med redigeringspunkter kan du vilja ta hänsyn till följande punkter om former:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* När en form är sluten saknar den en start- eller slutpunkt. När en form är öppen har den en början och ett slut. 
* Alla former består av minst två förankringspunkter som är länkade till varandra med linjer
* En linje är antingen rak eller kurvad. Förankringspunkter bestämmer linjens karaktär. 
* Förankringspunkter finns som hörnpunkter, raka punkter eller mjuka punkter:
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel. 
  * En mjuk punkt är en punkt där två handtag finns på en rak linje och linjesegmenten möts i en mjuk kurva. I detta fall är alla handtag placerade på samma avstånd från förankringspunkten. 
  * En rak punkt är en punkt där två handtag finns på en rak linje och linjesegmenten möts i en rak linje. I detta fall behöver handtagen inte vara placerade på lika avstånd från förankringspunkten. 
* Genom att flytta eller redigera förankringspunkter (vilket ändrar linjernas vinklar) kan du ändra hur en form ser ut. 

För att redigera PowerPoint‑former med redigeringspunkter tillhandahåller **Aspose.Slides** klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath) och klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath).

* En [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath)-instans representerar en geometribana för [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape)-objektet.
* För att hämta `GeometryPath` från `GeometryShape`‑instansen kan du använda metoden [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* För att ange `GeometryPath` för en form kan du använda dessa metoder: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) för *solida former* och [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) för *sammansatta former*.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath).
* Genom att använda metoderna [GeometryPath.setStroke](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) och [GeometryPath.setFillMode](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) kan du ange utseendet för en geometribana.
* Genom att använda metoden [GeometryPath.getPathData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath#getPathData--) kan du hämta geometribanen för en `GeometryShape` som en array av bansegment.
* För att få tillgång till ytterligare anpassningsalternativ för formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Använd [geometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) och [graphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeUtil)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) fram och tillbaka.

## **Enkla redigeringsoperationer**

Denna JavaScript‑kod visar hur man

**Lägg till en linje** i slutet av en bana

```javascript
lineTo(point);
lineTo(x, y);
```
**Lägg till en linje** på en angiven position på en bana:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Lägg till en kubisk Bézier‑kurva** i slutet av en bana:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Lägg till en kubisk Bézier‑kurva** på den angivna positionen på en bana:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Lägg till en kvadratisk Bézier‑kurva** i slutet av en bana:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Lägg till en kvadratisk Bézier‑kurva** på en angiven position på en bana:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Lägg till en given båge** till en bana:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Stäng den aktuella figuren** för en bana:

```javascript
closeFigure();
```
**Ange positionen för nästa punkt**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Ta bort bansegmentet** på ett givet index:

```javascript
removeAt(index);
```

## **Lägg till anpassade punkter till en form**
1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape) och sätt typen [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeType).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath) från formen.
3. Lägg till en ny punkt mellan de två översta punkterna på banan.
4. Lägg till en ny punkt mellan de två nedersta punkterna på banan.
5. Applicera banan på formen.

Denna JavaScript‑kod visar hur man lägger till anpassade punkter till en form:

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

## **Ta bort punkter från en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape) och sätt typen [ShapeType.Heart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeType).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath) från formen.
3. Ta bort segmentet för banan.
4. Applicera banan på formen.

Denna JavaScript‑kod visar hur man tar bort punkter från en form:

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

## **Skapa anpassad form**

1. Beräkna punkterna för formen.
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath).
3. Fyll banan med punkterna.
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape).
5. Applicera banan på formen.

Denna JavaScript‑kod visar hur man skapar en anpassad form:

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


## **Skapa sammansatt anpassad form**

  1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape).
  2. Skapa en första instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath).
  3. Skapa en andra instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath).
  4. Applicera banorna på formen.

Denna JavaScript‑kod visar hur man skapar en sammansatt anpassad form:

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

## **Skapa anpassad form med kurvade hörn**

Denna JavaScript‑kod visar hur man skapar en anpassad form med kurvade hörn (inåt);

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla sidor är sammanlänkade och bildar en enda omkrets utan hål. En sådan form kan vara en enkel geometrisk form eller en komplex anpassad kontur. Följande kodexempel visar hur man kontrollerar om en formgeometri är sluten:

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

## **Konvertera GeometryPath till java.awt.Shape** 

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryShape).
2. Skapa en instans av klassen [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konvertera [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)-instansen till [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GeometryPath)-instansen med hjälp av [ShapeUtil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeUtil).
4. Applicera banorna på formen.

Denna JavaScript‑kod—en implementering av stegen ovan—demonstrerar konverteringsprocessen från **GeometryPath** till **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Skapa ny form
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Hämta geometribana för formen
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Skapa ny grafikbana med text
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
    // Konvertera grafikbana till geometribana
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Ställ in kombinationen av den nya geometribanen och den ursprungliga geometribanen på formen
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometrin ersatts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/setrotation/)‑metod; geometrin roterar med formen eftersom den är bunden till formens egna koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/nodejs-java/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/nodejs-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.