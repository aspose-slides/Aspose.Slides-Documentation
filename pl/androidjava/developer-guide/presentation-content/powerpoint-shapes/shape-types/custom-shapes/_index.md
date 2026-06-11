---
title: Dostosuj kształty prezentacji na Androidzie
linktitle: Kształt niestandardowy
type: docs
weight: 20
url: /pl/androidjava/custom-shape/
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
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida w Javie: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides poprzez edycję geometrii kształtu przy użyciu punktów edycji oraz ścieżek geometrycznych. Pokazuje, jak pracować z `GeometryPath` i `IGeometryPath`, aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Pokazuje również, jak tworzyć kształty niestandardowe i złożone, budować kształty z zaokrąglonymi narożnikami, określić, czy geometria kształtu jest zamknięta, oraz konwertować pomiędzy `GeometryPath` a `java.awt.Shape` w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmienianie kształtu przy użyciu punktów edycji**
Rozważmy kwadrat. W programie PowerPoint, używając **punktów edycji**, możesz  

* przesunąć róg kwadratu do wewnątrz lub na zewnątrz  
* określić krzywiznę dla rogu lub punktu  
* dodać nowe punkty do kwadratu  
* manipulować punktami na kwadracie, itp.  

Zasadniczo możesz wykonywać opisane zadania na dowolnym kształcie. Korzystając z punktów edycji, możesz zmienić kształt lub utworzyć nowy kształt z istniejącego kształtu. 

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów PowerPoint przy użyciu punktów edycji, warto rozważyć następujące kwestie dotyczące kształtów:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.  
* Gdy kształt jest zamknięty, nie posiada punktu początkowego ani końcowego. Gdy jest otwarty, ma początek i koniec.  
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych ze sobą liniami.  
* Linia może być prostą lub zakrzywioną. Punkty kotwiczące określają charakter linii.  
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:  
  * Punkt narożny to punkt, w którym dwie proste linie łączą się pod kątem.  
  * Punkt gładki to punkt, w którym dwa uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w płynną krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o równą odległość.  
  * Punkt prosty to punkt, w którym dwa uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w płynną krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość.  
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu.  

Do edycji kształtów PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) oraz interfejs [**IGeometryPath**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryPath).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) reprezentuje ścieżkę geometryczną obiektu [IGeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryShape).  
* Aby pobrać `GeometryPath` z instancji `IGeometryShape`, możesz użyć metody [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--).  
* Aby ustawić `GeometryPath` dla kształtu, możesz użyć tych metod: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) dla *solid shapes* oraz [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) dla *composite shapes*.  
* Aby dodać segmenty, możesz użyć metod pod [IGeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryPath).  
* Korzystając z metod [IGeometryPath.setStroke](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) i [IGeometryPath.setFillMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), możesz ustawić wygląd ścieżki geometrycznej.  
* Korzystając z metody [IGeometryPath.getPathData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IGeometryPath#getPathData--), możesz pobrać ścieżkę geometryczną obiektu `GeometryShape` jako tablicę segmentów ścieżki.  
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
* Użyj [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) i [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeUtil)), aby konwertować [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) i z powrotem.  

## **Proste operacje edycji**

Ten kod Java pokazuje, jak

**Dodaj linię** na koniec ścieżki

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Dodaj linię** do określonej pozycji na ścieżce:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Dodaj krzywą Beziera trzeciego stopnia** na koniec ścieżki:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Dodaj krzywą Beziera trzeciego stopnia** do określonej pozycji na ścieżce:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Dodaj krzywą Beziera kwadratowego** na koniec ścieżki:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Dodaj krzywą Beziera kwadratowego** do określonej pozycji na ścieżce:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Dołącz podany łuk** do ścieżki:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Zamknij bieżącą figurę** ścieżki:

``` java
public void closeFigure();
```
**Ustaw pozycję kolejnego punktu**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Usuń segment ścieżki** pod danym indeksem:

``` java
public void removeAt(int index);
```

## **Dodaj niestandardowe punkty do kształtu**
1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryShape) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeType).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) z kształtu.  
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami na ścieżce.  
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami na ścieżce.  
5. Zastosuj ścieżkę do kształtu.  

Ten kod Java pokazuje, jak dodać niestandardowe punkty do kształtu:

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

## **Usuń punkty z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryShape) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeType).  
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) z kształtu.  
3. Usuń segment ścieżki.  
4. Zastosuj ścieżkę do kształtu.  

Ten kod Java pokazuje, jak usunąć punkty z kształtu:

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

## **Utwórz niestandardowy kształt**

1. Oblicz punkty dla kształtu.  
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath).  
3. Wypełnij ścieżkę punktami.  
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryShape).  
5. Zastosuj ścieżkę do kształtu.  

Ten kod Java pokazuje, jak stworzyć niestandardowy kształt:

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


## **Utwórz złożony niestandardowy kształt**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryShape).  
2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath).  
3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath).  
4. Zastosuj ścieżki do kształtu.  

Ten kod Java pokazuje, jak stworzyć złożony niestandardowy kształt:

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

## **Utwórz niestandardowy kształt z zaokrąglonymi narożnikami**

Ten kod Java pokazuje, jak stworzyć niestandardowy kształt z zaokrąglonymi narożnikami (do wewnątrz);

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

## **Sprawdź, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiowany jest jako taki, w którym wszystkie jego boki łączą się, tworząc jedną granicę bez przerw. Taki kształt może być prostą formą geometryczną lub skomplikowanym niestandardowym obrysem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

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

## **Konwertuj GeometryPath do java.awt.Shape** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryShape).  
2. Utwórz instancję klasy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).  
3. Konwertuj instancję [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GeometryPath) za pomocą [ShapeUtil](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeUtil).  
4. Zastosuj ścieżki do kształtu.  

Ten kod Java — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** do **GraphicsPath**:

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

    // Ustaw połączenie nowej ścieżki geometrycznej i pierwotnej ścieżki geometrycznej dla kształtu
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zamianie geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić niestandardowy kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#setRotation-float-) kształtu; geometria obraca się wraz z kształtem, ponieważ jest powiązana z własnym układem współrzędnych kształtu.

**Czy mogę przekonwertować niestandardowy kształt na obraz, aby „zamknąć” wynik?**

Tak. Wyeksportuj wymaganą [slajd](/slides/pl/androidjava/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/androidjava/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.