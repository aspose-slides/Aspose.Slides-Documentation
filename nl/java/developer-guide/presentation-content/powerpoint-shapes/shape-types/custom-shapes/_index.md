---
title: Aangepaste presentatieshapes in Java
linktitle: Aangepaste shape
type: docs
weight: 20
url: /nl/java/custom-shape/
keywords: 
- aangepaste shape
- shape toevoegen
- shape maken
- shape wijzigen
- shape geometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas shapes aan in PowerPoint-presentaties met Aspose.Slides voor Java: geometrie-paden, afgeronde hoeken, samengestelde shapes."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieshapes in Aspose.Slides kunt aanpassen door de geometrie van een shape te bewerken via bewerkingspunten en geometrie‑paden. Het laat zien hoe je werkt met `GeometryPath` en `IGeometryPath` om bestaande shapes te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie terug toe te passen op een shape.

Het toont bovendien hoe je aangepaste en samengestelde shapes maakt, shapes met afgeronde hoeken bouwt, bepaalt of de geometrie van een shape gesloten is, en converteert tussen `GeometryPath` en `java.awt.Shape` voor extra geometrie‑aanpassingsscenario’s.

## **Een shape wijzigen met bewerkingspunten**

Beschouw een vierkant. In PowerPoint kun je met **bewerkingspunten**:

* de hoek van het vierkant naar binnen of naar buiten verplaatsen
* de kromming van een hoek of punt specificeren
* nieuwe punten aan het vierkant toevoegen
* punten op het vierkant manipuleren, enz.

In wezen kun je de beschreven handelingen op elke shape uitvoeren. Met bewerkingspunten kun je een shape wijzigen of een nieuwe shape maken op basis van een bestaande shape.

## **Tips voor shape-bewerking**

![overview_image](custom_shape_0.png)

Voordat je begint met het bewerken van PowerPoint‑shapes via bewerkingspunten, wil je wellicht de volgende zaken over shapes in overweging nemen:

* Een shape (of het pad ervan) kan gesloten of open zijn.
* Wanneer een shape gesloten is, heeft het geen start‑ of eindpunt. Wanneer een shape open is, heeft het een begin‑ en eindpunt.
* Alle shapes bestaan uit minstens 2 ankerpunten die met elkaar verbonden zijn door lijnen.
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn.
* Ankerpunten bestaan als hoekpunten, rechte punten of soepele punten:
  * Een hoekpunt is een punt waar 2 rechte lijnen in een hoek samenkomen.
  * Een soepel punt is een punt waar 2 handvatten in een rechte lijn liggen en de segmenten van de lijn in een vloeiende kromme samenkomen. In dit geval staan alle handvatten op gelijke afstand van het ankerpunt.
  * Een recht punt is een punt waar 2 handvatten in een rechte lijn liggen en de lijnsegmenten in een vloeiende kromme samenkomen. In dit geval hoeven de handvatten niet op gelijke afstand van het ankerpunt te staan.
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van lijnen verandert), kun je de vorm van een shape aanpassen.

Om PowerPoint‑shapes via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [**GeometryPath**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) en de interface [**IGeometryPath**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryPath).

* Een [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) instantie vertegenwoordigt een geometrie‑pad van het [IGeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryShape) object. 
* Om de `GeometryPath` uit de `IGeometryShape`‑instantie op te halen, kun je de methode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) gebruiken. 
* Om de `GeometryPath` voor een shape in te stellen, kun je deze methoden gebruiken: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) voor *solide shapes* en [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) voor *samengestelde shapes*.
* Om segmenten toe te voegen, kun je de methoden onder [IGeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryPath) gebruiken. 
* Met behulp van de methoden [IGeometryPath.setStroke](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) en [IGeometryPath.setFillMode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) kun je het uiterlijk van een geometrie‑pad instellen.
* Met behulp van de methode [IGeometryPath.getPathData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IGeometryPath#getPathData--) kun je het geometrie‑pad van een `GeometryShape` ophalen als een array van padsegmenten. 
* Om extra opties voor shape‑geometrie‑aanpassing te benaderen, kun je [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) converteren naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Gebruik de methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) en [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (van de klasse [ShapeUtil](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeUtil)) om [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) heen en weer te converteren naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).

## **Eenvoudige bewerkingsbewerkingen**

Deze Java‑code laat zien hoe je

**Een lijn toevoegen** aan het einde van een pad

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Een lijn toevoegen** op een opgegeven positie op een pad:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Een kubieke Bézier‑curve toevoegen** aan het einde van een pad:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Een kubieke Bézier‑curve toevoegen** op de opgegeven positie op een pad:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Een kwadratische Bézier‑curve toevoegen** aan het einde van een pad:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Een kwadratische Bézier‑curve toevoegen** op een opgegeven positie op een pad:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Een gegeven boog toevoegen** aan een pad:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**De huidige figuur sluiten** van een pad:

``` java
public void closeFigure();
```
**De positie voor het volgende punt instellen**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Het pad‑segment verwijderen** op een opgegeven index:

``` java
public void removeAt(int index);
```

## **Aangepaste punten aan een shape toevoegen**
1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryShape) aan en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeType) in.  
2. Haal een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) op van de shape.  
3. Voeg een nieuw punt toe tussen de twee bovenste punten op het pad.  
4. Voeg een nieuw punt toe tussen de twee onderste punten op het pad.  
5. Pas het pad toe op de shape.

Deze Java‑code laat zien hoe je aangepaste punten aan een shape toevoegt:

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

## **Punten van een shape verwijderen**

1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryShape) aan en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeType) in.  
2. Haal een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) op van de shape.  
3. Verwijder het segment van het pad.  
4. Pas het pad toe op de shape.

Deze Java‑code laat zien hoe je punten van een shape verwijdert:

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

## **Een aangepaste shape maken**

1. Bereken de punten voor de shape.  
2. Maak een instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) aan.  
3. Vul het pad met de punten.  
4. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryShape) aan.  
5. Pas het pad toe op de shape.

Deze Java‑code laat zien hoe je een aangepaste shape maakt:

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


## **Een samengestelde aangepaste shape maken**

1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryShape) aan.  
2. Maak een eerste instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) aan.  
3. Maak een tweede instantie van de klasse [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) aan.  
4. Pas de paden toe op de shape.

Deze Java‑code laat zien hoe je een samengestelde aangepaste shape maakt:

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

## **Een aangepaste shape met afgeronde hoeken maken**

Deze Java‑code laat zien hoe je een aangepaste shape met afgeronde hoeken (naar binnen) maakt:

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

## **Controleren of een shape‑geometrie gesloten is**

Een gesloten shape wordt gedefinieerd als een shape waarvan alle zijden met elkaar verbonden zijn, waardoor één doorlopende grens ontstaat zonder gaten. Zo’n shape kan een eenvoudige geometrische vorm of een complexe aangepaste omtrek zijn. De volgende code‑voorbeeld laat zien hoe je controleert of een shape‑geometrie gesloten is:

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

## **GeometryPath naar java.awt.Shape converteren**

1. Maak een instantie van de klasse [GeometryShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryShape) aan.  
2. Maak een instantie van de klasse [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) aan.  
3. Converteer de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) instantie naar de [GeometryPath](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GeometryPath) instantie met behulp van [ShapeUtil](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ShapeUtil).  
4. Pas de paden toe op de shape.

Deze Java‑code—een implementatie van de bovenstaande stappen—demonstrates het **GeometryPath**‑naar‑**GraphicsPath**‑conversieproces:

``` java
Presentation pres = new Presentation();
try {
    // Nieuwe shape maken
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Geometry pad van de shape ophalen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Nieuw graphics pad maken met tekst
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

    // Graphics pad omzetten naar geometry pad
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Combinatie van nieuw geometry pad en origineel geometry pad instellen op de shape
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en de omtrek na het vervangen van de geometrie?**

De stijl blijft aan de shape gekoppeld; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste shape correct samen met de geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#setRotation-float-)‑methode van de shape; de geometrie roteert mee met de shape omdat deze gebonden is aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape naar een afbeelding converteren om het resultaat vast te leggen?**

Ja. Exporteer het gewenste [dia](/slides/nl/java/convert-powerpoint-to-png/) gebied of de [shape](/slides/nl/java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt het verdere werken met complexe geometrieën.