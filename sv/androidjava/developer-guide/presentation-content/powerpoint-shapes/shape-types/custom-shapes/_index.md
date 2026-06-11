---
title: Anpassa presentationsformer på Android
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för Android via Java: geometribanor, kurvade hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med `GeometryPath` och `IGeometryPath` för att modifiera befintliga former, utföra grundläggande banredigeringsoperationer, lägga till eller ta bort punkter och applicera uppdaterad geometri tillbaka på en form.

Den demonstrerar också hur du skapar anpassade och sammansatta former, bygger former med kurvade hörn, avgör om en formgeometri är sluten och konverterar mellan `GeometryPath` och `java.awt.Shape` för ytterligare scenarier för geometrianpassning.

## **Ändra en form med redigeringspunkter**

Föreställ dig en kvadrat. I PowerPoint kan du, med **redigeringspunkter**, 

* flytta kvadratens hörn inåt eller utåt
* ange krökningen för ett hörn eller en punkt
* lägga till nya punkter på kvadraten
* manipulera punkter på kvadraten osv. 

Kort sagt kan du utföra beskrivna uppgifter på vilken form som helst. Med redigeringspunkter kan du ändra en form eller skapa en ny form utifrån en befintlig form. 

## **Tips för att redigera former**

![overview_image](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former via redigeringspunkter kan du vilja tänka på följande om former:

* En form (eller dess bana) kan vara antingen sluten eller öppen.
* När en form är sluten saknas en start‑ eller slutpunkt. När en form är öppen har den en början och ett slut. 
* Alla former består av minst två ankarlänkpunkter som är sammankopplade med linjer
* En linje är antingen rak eller kurvad. Ankarlänkpunkter bestämmer linjens natur. 
* Ankarlänkpunkter kan vara hörnpunkter, raka punkter eller jämna punkter:
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel. 
  * En jämn punkt är en punkt där två handtag ligger på en rak linje och linjens segment förenas i en mjuk kurva. I detta fall är alla handtag separerade från ankarlänkpunkten med ett lika avstånd. 
  * En rak punkt är en punkt där två handtag ligger på en rak linje och linjens segment förenas i en mjuk kurva. I detta fall behöver handtagen inte vara separerade från ankarlänkpunkten med ett lika avstånd. 
* Genom att flytta eller redigera ankarlänkpunkter (vilket ändrar linjernas vinkel) kan du förändra hur en form ser ut. 

För att redigera PowerPoint‑former via redigeringspunkter erbjuder **Aspose.Slides** klassen [**GeometryPath**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath) och gränssnittet [**IGeometryPath**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryPath).

* En [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath)‑instans representerar en geometrisk bana för objektet [IGeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape).
* För att hämta `GeometryPath` från `IGeometryShape`‑instansen kan du använda metoden [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* För att ange `GeometryPath` för en form kan du använda dessa metoder: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) för *solida former* och [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) för *sammansatta former*.
* För att lägga till segment kan du använda metoderna under [IGeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryPath).
* Genom att använda metoderna [IGeometryPath.setStroke](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) och [IGeometryPath.setFillMode](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) kan du ange utseendet för en geometrisk bana.
* Med metoden [IGeometryPath.getPathData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IGeometryPath#getPathData--) kan du hämta geometribanan för en `GeometryShape` som en array av bansegment.
* För att få tillgång till ytterligare anpassningsalternativ för formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Använd [geometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) och [graphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) metoder (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeUtil)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) fram och tillbaka.

## **Enkla redigeringsoperationer**

Denna Java‑kod visar hur du

**Lägg till en linje** i slutet av en bana

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Lägg till en linje** på en angiven position på en bana:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Lägg till en kubisk Bezier‑kurva** i slutet av en bana:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Lägg till en kubisk Bezier‑kurva** på den angivna positionen på en bana:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Lägg till en kvadratisk Bezier‑kurva** i slutet av en bana:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Lägg till en kvadratisk Bezier‑kurva** på en angiven position på en bana:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Lägg till en given båge** till en bana:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Stäng den aktuella figuren** i en bana:

``` java
public void closeFigure();
```
**Ange positionen för nästa punkt**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Ta bort bansegmentet** på ett givet index:

``` java
public void removeAt(int index);
```

## **Lägg till anpassade punkter i en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryShape) och ange typ [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeType).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath) från formen.
3. Lägg till en ny punkt mellan de två övre punkterna på banan.
4. Lägg till en ny punkt mellan de två nedre punkterna på banan.
5. Applicera banan på formen.

Denna Java‑kod visar hur du lägger till anpassade punkter i en form:

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

## **Ta bort punkter från en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryShape) och ange typ [ShapeType.Heart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeType).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath) från formen.
3. Ta bort segmentet för banan.
4. Applicera banan på formen.

Denna Java‑kod visar hur du tar bort punkter från en form:

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

## **Skapa en anpassad form**

1. Beräkna punkterna för formen.
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath).
3. Fyll banan med punkterna.
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryShape).
5. Applicera banan på formen.

Denna Java‑kod visar hur du skapar en anpassad form:

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


## **Skapa en sammansatt anpassad form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryShape).
2. Skapa en första instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath).
3. Skapa en andra instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath).
4. Applicera banorna på formen.

Denna Java‑kod visar hur du skapar en sammansatt anpassad form:

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

## **Skapa en anpassad form med kurvade hörn**

Denna Java‑kod visar hur du skapar en anpassad form med kurvade hörn (inåt);

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla dess sidor är sammanlänkade och bildar en enda kontur utan luckor. En sådan form kan vara en enkel geometrisk form eller en komplex anpassad kontur. Följande kodexempel visar hur du kontrollerar om en formgeometri är sluten:

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

## **Konvertera GeometryPath till java.awt.Shape**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryShape).
2. Skapa en instans av klassen [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konvertera [java.awt Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑instansen till [GeometryPath](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/GeometryPath)‑instansen med hjälp av [ShapeUtil](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ShapeUtil).
4. Applicera banorna på formen.

Denna Java‑kod – en implementation av stegen ovan – demonstrerar konverteringsprocessen från **GeometryPath** till **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Skapa ny form
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Hämta geometribana för formen
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Skapa ny grafikbana med text
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

    // Konvertera grafikbana till geometribana
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Ställ in kombinationen av ny geometribana och ursprunglig geometribana på formen
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **Vanliga frågor**

**Vad händer med fyllning och kontur efter att geometrin har ersatts?**

Stilen förblir kopplad till formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag korrekt en anpassad form tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#setRotation-float-)‑metod; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det behövliga [slide](/slides/sv/androidjava/convert-powerpoint-to-png/) området eller själva [shape](/slides/sv/androidjava/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med tunga geometrier.