---
title: Aangepaste presentatieshape's in JavaScript
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/nodejs-java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- gebogen hoek
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met JavaScript en Aspose.Slides voor Node.js: geometriepaden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieshape’s in Aspose.Slides kunt aanpassen door de shape‑geometrie te bewerken via bewerkingspunten en geometriepaden. Het toont hoe je met `GeometryPath` kunt werken om bestaande shapes te wijzigen, basisbewerkingen op paden uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een shape toe te passen.

Het laat ook zien hoe je aangepaste en samengestelde shapes maakt, shapes met gebogen hoeken bouwt, bepaalt of een shape‑geometrie gesloten is, en converteert tussen `GeometryPath` en `java.awt.Shape` voor extra geometrie‑aanpassingsscenario’s.

## **Shape wijzigen met bewerkingspunten**

Beschouw een vierkant. In PowerPoint kun je met **bewerkingspunten**

* de hoek van het vierkant naar binnen of buiten verplaatsen
* de kromming voor een hoek of punt specificeren
* nieuwe punten aan het vierkant toevoegen
* punten op het vierkant manipuleren, enz.

Kortom, je kunt de beschreven taken op elke shape uitvoeren. Met bewerkingspunten kun je een shape wijzigen of een nieuwe shape maken van een bestaande shape.

## **Tips voor shape‑bewerking**

![overview_image](custom_shape_0.png)

Voordat je begint met het bewerken van PowerPoint‑shapes via bewerkingspunten, kun je de volgende punten over shapes overwegen:

* Een shape (of het bijbehorende pad) kan gesloten of open zijn.
* Wanneer een shape gesloten is, heeft deze geen begin‑ of eindpunt. Wanneer een shape open is, heeft deze een begin‑ en eindpunt. 
* Alle shapes bestaan uit ten minste 2 ankerpunten die met elkaar verbonden zijn door lijnen.
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn. 
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:
  * Een hoekpunt is een punt waar twee rechte lijnen onder een hoek samenkomen. 
  * Een vloeiend punt is een punt waar twee handvatten op een rechte lijn liggen en de segmenten van de lijn in een vloeiende curve samenkomen. In dit geval staan alle handvatten op gelijke afstand van het ankerpunt. 
  * Een recht punt is een punt waar twee handvatten op een rechte lijn liggen en de segmenten van die lijn in een vloeiende curve samenkomen. In dit geval hoeven de handvatten niet op gelijke afstand van het ankerpunt te staan. 
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van de lijnen verandert), kun je de vorm van een shape wijzigen. 

Om PowerPoint‑shapes via bewerkingspunten te bewerken, biedt **Aspose.Slides** de [**GeometryPath**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse en de [**GeometryPath**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse.

* Een [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑instance vertegenwoordigt een geometriepad van het [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑object.
* Om de `GeometryPath` op te halen uit de `GeometryShape`‑instance, kun je de [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--)‑methode gebruiken.
* Om de `GeometryPath` voor een shape in te stellen, kun je deze methoden gebruiken: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) voor *solide shapes* en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) voor *samengestelde shapes*.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath) gebruiken.
* Met de [GeometryPath.setStroke](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-)‑methoden kun je het uiterlijk van een geometriepad instellen.
* Met de [GeometryPath.getPathData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath#getPathData--)‑methode kun je het geometriepad van een `GeometryShape` opvragen als een array van padsegmenten.
* Voor extra opties voor shape‑geometrie‑aanpassing kun je [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath) converteren naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Gebruik [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) en [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) methoden (van de [ShapeUtil](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeUtil)‑klasse) om [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath) om te zetten naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en terug.

## **Eenvoudige bewerkingsoperaties**

Deze JavaScript‑code toont hoe je

**Een lijn toevoegen** aan het einde van een pad

```javascript
lineTo(point);
lineTo(x, y);
```
**Een lijn toevoegen** op een opgegeven positie op een pad:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Een kubieke Bézier‑curve toevoegen** aan het einde van een pad:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Een kubieke Bézier‑curve toevoegen** op de opgegeven positie op een pad:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Een kwadratische Bézier‑curve toevoegen** aan het einde van een pad:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Een kwadratische Bézier‑curve toevoegen** op een opgegeven positie op een pad:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Een gegeven boog aan een pad toevoegen**:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**De huidige figuur van een pad sluiten**:

```javascript
closeFigure();
```
**De positie voor het volgende punt instellen**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Het padsegment op een gegeven index verwijderen**:

```javascript
removeAt(index);
```

## **Aangepaste punten aan een shape toevoegen**
1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑klasse aan en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeType) in.
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse op uit de shape.
3. Voeg een nieuw punt toe tussen de twee bovenste punten op het pad.
4. Voeg een nieuw punt toe tussen de twee onderste punten op het pad.
5. Pas het pad toe op de shape.

Deze JavaScript‑code toont hoe je aangepaste punten aan een shape toevoegt:

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

## **Punten uit een shape verwijderen**
1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑klasse aan en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeType) in.
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse op uit de shape.
3. Verwijder het segment van het pad.
4. Pas het pad toe op de shape.

Deze JavaScript‑code toont hoe je punten uit een shape verwijdert:

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

## **Aangepaste shape maken**
1. Bereken de punten voor de shape.
2. Maak een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse.
3. Vul het pad met de punten.
4. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑klasse.
5. Pas het pad toe op de shape.

Deze JavaScript‑code toont hoe je een aangepaste shape maakt:

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


## **Samengestelde aangepaste shape maken**
  1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑klasse.
  2. Maak een eerste instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse.
  3. Maak een tweede instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑klasse.
  4. Pas de paden toe op de shape.

Deze JavaScript‑code toont hoe je een samengestelde aangepaste shape maakt:

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

## **Aangepaste shape met gebogen hoeken maken**
Deze JavaScript‑code toont hoe je een aangepaste shape met gebogen hoeken (naar binnen) maakt;

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

## **Nagaan of een shape‑geometrie gesloten is**
Een gesloten shape wordt gedefinieerd als een shape waarvan alle zijden met elkaar verbonden zijn, waardoor één enkele omtrek zonder onderbrekingen ontstaat. Zo’n shape kan een eenvoudige geometrische vorm of een complexe aangepaste contour zijn. De volgende code‑voorbeeld laat zien hoe je controleert of een shape‑geometrie gesloten is:

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

## **GeometryPath naar java.awt.Shape converteren** 

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryShape)‑klasse.
2. Maak een instantie van de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑klasse.
3. Converteer de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑instance naar de [GeometryPath](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GeometryPath)‑instance met behulp van [ShapeUtil](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeUtil).
4. Pas de paden toe op de shape.

Deze JavaScript‑code – een implementatie van de bovenstaande stappen – toont het conversieproces van **GeometryPath** naar **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Nieuwe shape aanmaken
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Geometriepad van de shape ophalen
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Nieuwe graphics path met tekst maken
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
    // Graphics path naar geometriepad converteren
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Combinatie van nieuw geometriepad en origineel geometriepad instellen op de shape
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de opvulling en de omlijning na het vervangen van de geometrie?**

De stijl blijft behouden bij de shape; alleen de contour verandert. De opvulling en omlijning worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste shape correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/setrotation/)‑methode van de shape; de geometrie roteert mee omdat deze gebonden is aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape converteren naar een afbeelding om het resultaat vast te leggen?**

Ja. Exporteer het gewenste [slide](/slides/nl/nodejs-java/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/nodejs-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere bewerking met complexe geometrieën.