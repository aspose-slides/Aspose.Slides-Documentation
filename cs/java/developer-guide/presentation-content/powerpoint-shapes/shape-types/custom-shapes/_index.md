---
title: Přizpůsobení tvarů prezentace v Javě
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/java/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakulacený roh
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Javu: geometrické cesty, zakulacené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s `GeometryPath` a `IGeometryPath` pro úpravu existujících tvarů, provádění základních operací úpravy cesty, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, sestavit tvary se zakulacenými rohy, zjistit, zda je geometrie tvaru uzavřená, a převést mezi `GeometryPath` a `java.awt.Shape` pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**

Zvažte čtverec. V PowerPointu, pomocí **edit points**, můžete

* posunout roh čtverce dovnitř nebo ven
* specifikovat zakřivení rohu nebo bodu
* přidat nové body do čtverce
* manipulovat body na čtverci atd.

V podstatě můžete provádět popsané úkoly na jakémkoli tvaru. Pomocí edit points máte možnost změnit tvar nebo vytvořit nový tvar z existujícího tvaru.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Než začnete upravovat tvary PowerPointu pomocí edit points, možná budete chtít zvážit následující body o tvarech:

* Tvar (nebo jeho cesta) může být buď uzavřený, nebo otevřený.
* Když je tvar uzavřený, nemá počáteční ani koncový bod. Když je tvar otevřený, má začátek i konec.
* Všechny tvary se skládají alespoň ze 2 kotevních bodů propojených čarami.
* Čára může být buď rovná, nebo zakřivená. Kotevní body určují povahu čáry.
* Kotevní body existují jako rohové body, rovné body nebo hladké body:
  * Rohový bod je bod, kde se dva rovné úseky spojují pod úhlem.
  * Hladký bod je bod, kde existují dva úchyty v jedné přímce a úseky čáry se spojují do hladké křivky. V tomto případě jsou všechny úchyty od kotevního bodu vzdáleny stejně.
  * Rovný bod je bod, kde existují dva úchyty v jedné přímce a úseky čáry se spojují v hladkou křivku. V tomto případě nemusí být úchyty od kotevního bodu vzdáleny stejně.
* Posunutím nebo úpravou kotevních bodů (což mění úhel čar) můžete změnit vzhled tvaru.

Pro úpravu tvarů PowerPointu pomocí edit points poskytuje **Aspose.Slides** třídu [**GeometryPath**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) a rozhraní [**IGeometryPath**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryPath).

* Instance třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape).
* Chcete-li získat `GeometryPath` z instance `IGeometryShape`, můžete použít metodu [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape#getGeometryPaths--).
* Pro nastavení `GeometryPath` pro tvar můžete použít tyto metody: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) pro *plné tvary* a [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) pro *složené tvary*.
* Pro přidání segmentů můžete použít metody pod [IGeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryPath).
* Pomocí metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) a [IGeometryPath.setFillMode](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) můžete nastavit vzhled geometrické cesty.
* Pomocí metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryPath#getPathData--) můžete získat geometrickou cestu `GeometryShape` jako pole segmentů cesty.
* Pro přístup k dalším možnostem přizpůsobení geometrie tvaru můžete převést [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Použijte metody [geometryPathToGraphicsPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) a [graphicsPathToGeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (z třídy [ShapeUtil](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeUtil)) pro převod [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) a zpět.

## **Jednoduché operace úpravy**

Tento Java kód vám ukazuje, jak

**Přidat čáru** na konec cesty

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Přidat čáru** na určenou pozici v cestě:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Přidat kubickou Bézierovu křivku** na konec cesty:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Přidat kubickou Bézierovu křivku** na určenou pozici v cestě:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Přidat kvadratickou Bézierovu křivku** na konec cesty:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Přidat kvadratickou Bézierovu křivku** na určenou pozici v cestě:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Připojit daný oblouk** k cestě:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Uzavřít aktuální figuru** cesty:

``` java
public void closeFigure();
```
**Nastavit pozici pro další bod**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Odstranit segment cesty** na daném indexu:

``` java
public void removeAt(int index);
```

## **Přidání vlastních bodů do tvaru**
1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryShape) a nastavte typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeType).
2. Získáte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) ze tvaru.
3. Přidejte nový bod mezi dvěma horními body na cestě.
4. Přidejte nový bod mezi dvěma spodními body na cestě.
5. Aplikujte cestu na tvar.

Tento Java kód vám ukazuje, jak přidat vlastní body do tvaru:

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

## **Odstranění bodů z tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryShape) a nastavte typ [ShapeType.Heart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeType).
2. Získáte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) ze tvaru.
3. Odstraňte segment cesty.
4. Aplikujte cestu na tvar.

Tento Java kód vám ukazuje, jak odstranit body z tvaru:

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

## **Vytvoření vlastního tvaru**

1. Vypočítejte body pro tvar.
2. Vytvořte instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath).
3. Naplněte cestu body.
4. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryShape).
5. Aplikujte cestu na tvar.

Tento Java kód vám ukazuje, jak vytvořit vlastní tvar:

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


## **Vytvoření složeného vlastního tvaru**

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryShape).
2. Vytvořte první instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath).
3. Vytvořte druhou instanci třídy [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath).
4. Aplikujte cesty na tvar.

Tento Java kód vám ukazuje, jak vytvořit složený vlastní tvar:

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

## **Vytvoření vlastního tvaru se zakulacenými rohy**

Tento Java kód vám ukazuje, jak vytvořit vlastní tvar se zakulacenými rohy (dovnitř);

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

## **Zjistěte, zda je geometrie tvaru uzavřená**

Uzavřený tvar je definován jako takový, kde všechny jeho strany spojují a tvoří jedinou hranici bez mezer. Takový tvar může být jednoduchou geometrickou formou nebo složitým vlastním obrysem. Následující příklad kódu ukazuje, jak zkontrolovat, zda je geometrie tvaru uzavřená:

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

## **Převod GeometryPath na java.awt.Shape** 

1. Vytvořte instanci třídy [GeometryShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryShape).
2. Vytvořte instanci třídy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Převěďte instanci [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instanci [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/GeometryPath) pomocí [ShapeUtil](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapeUtil).
4. Aplikujte cesty na tvar.

Tento Java kód—implementace výše uvedených kroků—ukazuje proces převodu **GeometryPath** na **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Vytvořit nový tvar
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Získat geometrickou cestu tvaru
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Vytvořit novou grafickou cestu s textem
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

    // Převést grafickou cestu na geometrickou cestu
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Nastavit kombinaci nové geometrické cesty a původní geometrické cesty na tvar
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky použity na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte metodu [setRotation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#setRotation-float-) tvaru; geometrie se otáčí s tvarem, protože je vázána na vlastní souřadnicový systém tvaru.

**Mohu převést vlastní tvar na obrázek, abych „uzamkl“ výsledek?**

Ano. Exportujte požadovanou oblast [slidu](/slides/cs/java/convert-powerpoint-to-png/) nebo samotný [tvar](/slides/cs/java/create-shape-thumbnails/) do rastrového formátu; to zjednoduší další práci s komplexními geometriemi.