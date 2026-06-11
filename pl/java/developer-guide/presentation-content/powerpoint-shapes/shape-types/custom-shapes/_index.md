---
title: Dostosowywanie kształtów prezentacji w Javie
linktitle: Kształt niestandardowy
type: docs
weight: 20
url: /pl/java/custom-shape/
keywords:
- niestandardowy kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- punkty edycji
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony róg
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides poprzez edycję geometrii kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z `GeometryPath` i `IGeometryPath`, aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Demonstruje także, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi rogami, określać, czy geometria kształtu jest zamknięta, oraz konwertować pomiędzy `GeometryPath` i `java.awt.Shape` w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmiana kształtu za pomocą punktów edycji**

Rozważmy kwadrat. W PowerPoint, używając **punktów edycji**, możesz

* przesunąć róg kwadratu do wewnątrz lub na zewnątrz
* określić krzywiznę rogu lub punktu
* dodać nowe punkty do kwadratu
* manipulować punktami na kwadracie itd.

W zasadzie możesz wykonać opisane czynności na dowolnym kształcie. Dzięki punktom edycji możesz zmienić istniejący kształt lub utworzyć nowy kształt na jego podstawie.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów PowerPoint za pomocą punktów edycji, rozważ następujące kwestie dotyczące kształtów:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Gdy kształt jest zamknięty, nie ma punktu początkowego ani końcowego. Gdy jest otwarty, ma początek i koniec. 
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych liniami.
* Linia może być prostą lub krzywą. Punkty kotwiczące określają charakter linii. 
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * Punkt narożny to punkt, w którym 2 proste linie łączą się pod kątem. 
  * Punkt płynny to punkt, w którym 2 uchwyty leżą w jednej prostej, a odcinki linii łączą się płynną krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o tę samą odległość. 
  * Punkt prosty to punkt, w którym 2 uchwyty leżą w jednej prostej, a odcinki linii łączą się płynną krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość. 
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu. 

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) oraz interfejs [**IGeometryPath**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryPath).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape). 
* Aby pobrać `GeometryPath` z instancji `IGeometryShape`, użyj metody [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape#getGeometryPaths--). 
* Aby ustawić `GeometryPath` dla kształtu, możesz użyć metod: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) dla *kształtów wypełnionych* oraz [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) dla *kształtów złożonych*. 
* Aby dodać segmenty, użyj metod dostępnych w [IGeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryPath). 
* Korzystając z metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) i [IGeometryPath.setFillMode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryPath#setFillMode-byte-), możesz ustawić wygląd ścieżki geometrycznej. 
* Metodą [IGeometryPath.getPathData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryPath#getPathData--) możesz uzyskać ścieżkę geometryczną `GeometryShape` jako tablicę segmentów ścieżki. 
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html). 
* Użyj metod [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) i [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeUtil)), aby konwertować [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) i odwrotnie. 

## **Proste operacje edycji**

Ten kod w Javie pokazuje, jak

**Dodawać linię** na koniec ścieżki

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Dodawać linię** w określonej pozycji na ścieżce:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Dodawać krzywą Beziera trzeciego stopnia** na koniec ścieżki:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Dodawać krzywą Beziera trzeciego stopnia** w określonej pozycji na ścieżce:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Dodawać krzywą Beziera drugiego stopnia** na koniec ścieżki:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Dodawać krzywą Beziera drugiego stopnia** w określonej pozycji na ścieżce:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Dołączać dany łuk** do ścieżki:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Zamknąć bieżącą figurę** ścieżki:

``` java
public void closeFigure();
```
**Ustawić pozycję następnego punktu**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Usunąć segment ścieżki** pod danym indeksem:

``` java
public void removeAt(int index);
```

## **Dodawanie własnych punktów do kształtu**
1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryShape) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeType).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) z kształtu.  
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami na ścieżce.  
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami na ścieżce.  
5. Zastosuj ścieżkę do kształtu.  

Ten kod w Javie pokazuje, jak dodać własne punkty do kształtu:

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

## **Usuwanie punktów z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryShape) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeType).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) z kształtu.  
3. Usuń segment ze ścieżki.  
4. Zastosuj ścieżkę do kształtu.  

Ten kod w Javie pokazuje, jak usunąć punkty z kształtu:

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

## **Utworzenie własnego kształtu**

1. Oblicz punkty kształtu.  
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath).  
3. Wypełnij ścieżkę punktami.  
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryShape).  
5. Zastosuj ścieżkę do kształtu.  

Ten kod w Javie pokazuje, jak utworzyć własny kształt:

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


## **Utworzenie złożonego własnego kształtu**

  1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryShape).  
  2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath).  
  3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath).  
  4. Zastosuj ścieżki do kształtu.  

Ten kod w Javie pokazuje, jak utworzyć złożony własny kształt:

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

## **Utworzenie własnego kształtu z zaokrąglonymi rogami**

Ten kod w Javie pokazuje, jak utworzyć własny kształt z zaokrąglonymi rogami (do wewnątrz);

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

## **Sprawdzenie, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiowany jest jako taki, w którym wszystkie jego boki łączą się, tworząc jedną granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym własnym obrysem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

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

## **Konwersja GeometryPath na java.awt.Shape** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryShape).  
2. Utwórz instancję klasy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Przekonwertuj instancję [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/java/com.aspose.slides/GeometryPath) przy użyciu [ShapeUtil](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeUtil).  
4. Zastosuj ścieżki do kształtu.  

Ten kod w Javie — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** na **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Utwórz nowy kształt
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Pobierz ścieżkę geometryczną kształtu
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Utwórz nową ścieżkę graficzną z tekstem
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

    // Konwertuj ścieżkę graficzną na ścieżkę geometryczną
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Ustaw kombinację nowej ścieżki geometrycznej i pierwotnej ścieżki geometrycznej dla kształtu
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i konturem po zamianie geometrii?**

Styl pozostaje powiązany z kształtem; zmienia się jedynie kontur. Wypełnienie i kontur są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**

Użyj metody kształtu [setRotation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#setRotation-float-); geometria obraca się razem z kształtem, ponieważ jest związana z układem współrzędnych samego kształtu.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wymaganą [slide](/slides/pl/java/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/java/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.