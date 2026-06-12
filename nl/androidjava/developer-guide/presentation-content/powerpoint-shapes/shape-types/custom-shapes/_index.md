---
title: Aangepaste presentatiesvormen op Android
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/androidjava/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometrisch pad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor Android via Java: geometrische paden, afgeronde hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentaties‑vormen kunt aanpassen in Aspose.Slides door de vormgeometrie te bewerken via bewerkingspunten en geometrische paden. Het laat zien hoe u werkt met `GeometryPath` en `IGeometryPath` om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug op een vorm toe te passen.

Het laat ook zien hoe u aangepaste en samengestelde vormen maakt, vormen met afgeronde hoeken bouwt, bepaalt of een vormgeometrie gesloten is, en converteert tussen `GeometryPath` en `java.awt.Shape` voor extra geometrie‑aanpassingsscenario’s.

## **Vorm wijzigen met bewerkingspunten**

Beschouw een vierkant. In PowerPoint kunt u met **bewerkingspunten** 

* verplaats de hoek van het vierkant naar binnen of naar buiten
* specificeer de kromming van een hoek of punt
* voeg nieuwe punten toe aan het vierkant
* bewerk punten op het vierkant, enz. 

Deze taken kunt u in essentie op elke vorm uitvoeren. Met bewerkingspunten kunt u een vorm wijzigen of een nieuwe vorm maken op basis van een bestaande vorm. 

## **Tips voor het bewerken van vormen**

![overzicht_afbeelding](custom_shape_0.png)

Voordat u PowerPoint‑vormen gaat bewerken via bewerkingspunten, wilt u wellicht rekening houden met de volgende zaken over vormen:

* Een vorm (of het pad ervan) kan gesloten of geopend zijn.  
* Wanneer een vorm gesloten is, heeft die geen begin‑ of eindpunt. Wanneer een vorm geopend is, heeft die een begin en een einde.  
* Alle vormen bestaan uit ten minste 2 ankerpunten die met elkaar verbonden zijn door lijnen.  
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn.  
* Ankerpunten bestaan als hoekpunten, rechte punten of vloeiende punten:  
  * Een hoekpunt is een punt waar 2 rechte lijnen onder een hoek samenkomen.  
  * Een vloeiend punt is een punt waar 2 handvatten in een rechte lijn liggen en de lijnsegmenten in een vloeiende boog aansluiten. In dit geval zijn alle handvatten even ver verwijderd van het ankerpunt.  
  * Een recht punt is een punt waar 2 handvatten in een rechte lijn liggen en die lijnsegmenten in een vloeiende boog aansluiten. In dit geval hoeven de handvatten niet even ver van het ankerpunt te staan.  
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van de lijnen verandert), kunt u de vorm van een vorm wijzigen.  

Om PowerPoint‑vormen te bewerken via bewerkingspunten, biedt **Aspose.Slides** de klasse [**GeometryPath**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) en de interface [**IGeometryPath**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryPath) aan.

* Een [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) instantie vertegenwoordigt een geometrisch pad van het [IGeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape) object.  
* Om de `GeometryPath` van de `IGeometryShape`‑instantie op te halen, kunt u de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) gebruiken.  
* Om de `GeometryPath` voor een vorm in te stellen, kunt u deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) voor *solide vormen* en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) voor *samengestelde vormen*.  
* Om segmenten toe te voegen, kunt u de methoden onder [IGeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryPath) gebruiken.  
* Met de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) kunt u het uiterlijk van een geometrisch pad instellen.  
* Met de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IGeometryPath#getPathData--) kunt u het geometrische pad van een `GeometryShape` ophalen als een array van padsegmenten.  
* Om extra aanpassingsopties voor vormgeometrie te benaderen, kunt u [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) converteren naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Gebruik de methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) en [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (van de klasse [ShapeUtil](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeUtil)) om [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en terug te converteren.

## **Eenvoudige bewerkingen**

Deze Java‑code toont hoe u

**Voeg een lijn toe** aan het einde van een pad

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Voeg een lijn toe** op een opgegeven positie op een pad:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Voeg een kubieke Bézier‑curve toe** aan het einde van een pad:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Voeg een kubieke Bézier‑curve toe** op de opgegeven positie op een pad:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Voeg een kwadratische Bézier‑curve toe** aan het einde van een pad:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Voeg een kwadratische Bézier‑curve toe** op de opgegeven positie op een pad:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Voeg een opgegeven boog toe** aan een pad:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Sluit de huidige figuur** van een pad:

``` java
public void closeFigure();
```
**Stel de positie in voor het volgende punt**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Verwijder het padsegment** op een gegeven index:

``` java
public void removeAt(int index);
```

## **Aangepaste punten aan een vorm toevoegen**
1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryShape) klasse en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeType) in.  
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) klasse op uit de vorm.  
3. Voeg een nieuw punt toe tussen de twee bovenste punten op het pad.  
4. Voeg een nieuw punt toe tussen de twee onderste punten op het pad.  
5. Pas het pad toe op de vorm.  

Deze Java‑code toont hoe u aangepaste punten aan een vorm toevoegt:

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
![voorbeeld1_afbeelding](custom_shape_1.png)

## **Punten uit een vorm verwijderen**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryShape) klasse en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeType) in.  
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) klasse op uit de vorm.  
3. Verwijder het segment van het pad.  
4. Pas het pad toe op de vorm.  

Deze Java‑code toont hoe u punten uit een vorm verwijdert:

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
![voorbeeld2_afbeelding](custom_shape_2.png)

## **Aangepaste vorm maken**

1. Bereken de punten voor de vorm.  
2. Maak een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) klasse.  
3. Vul het pad met de punten.  
4. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryShape) klasse.  
5. Pas het pad toe op de vorm.  

Deze Java‑code toont hoe u een aangepaste vorm maakt:

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
![voorbeeld3_afbeelding](custom_shape_3.png)


## **Samengestelde aangepaste vorm maken**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryShape) klasse.  
2. Maak een eerste instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) klasse.  
3. Maak een tweede instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) klasse.  
4. Pas de paden toe op de vorm.  

Deze Java‑code toont hoe u een samengestelde aangepaste vorm maakt:

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
![voorbeeld4_afbeelding](custom_shape_4.png)

## **Aangepaste vorm met afgeronde hoeken maken**

Deze Java‑code toont hoe u een aangepaste vorm met afgeronde hoeken (naar binnen) maakt;

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

## **Controleren of een vormgeometrie gesloten is**

Een gesloten vorm wordt gedefinieerd als een vorm waarbij alle zijden met elkaar verbonden zijn, waardoor één aaneengesloten omtrek ontstaat zonder gaten. Zo’n vorm kan een eenvoudige geometrische vorm zijn of een complex aangepast omtrek. De volgende code‑voorbeeld laat zien hoe u controleert of een vormgeometrie gesloten is:

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

## **GeometryPath converteren naar java.awt.Shape** 

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryShape) klasse.  
2. Maak een instantie van de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) klasse.  
3. Converteer de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) instantie naar de [GeometryPath](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GeometryPath) instantie met behulp van [ShapeUtil](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ShapeUtil).  
4. Pas de paden toe op de vorm.  

Deze Java‑code – een implementatie van de bovenstaande stappen – demonstreert het **GeometryPath**‑naar‑**GraphicsPath**‑conversieproces:

``` java
Presentation pres = new Presentation();
try {
    // Maak een nieuwe vorm
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Haal het geometriepad van de vorm op
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Maak een nieuw grafisch pad met tekst
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

    // Converteer het grafische pad naar een geometrisch pad
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Stel de combinatie van het nieuwe geometriepad en het oorspronkelijke geometriepad in voor de vorm
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![voorbeeld5_afbeelding](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek nadat de geometrie is vervangen?**

De stijl blijft behouden bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#setRotation-float-) methode van de vorm; de geometrie roteert mee met de vorm omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm naar een afbeelding converteren om het resultaat vast te leggen?**

Ja. Exporteer het gewenste [dia](/slides/nl/androidjava/convert-powerpoint-to-png/) gebied of de [vorm](/slides/nl/androidjava/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere werkzaamheden met complexe geometrieën.