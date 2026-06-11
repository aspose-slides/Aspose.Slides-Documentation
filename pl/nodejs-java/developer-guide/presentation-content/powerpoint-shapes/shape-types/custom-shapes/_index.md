---
title: Dostosowywanie kształtów prezentacji w JavaScript
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/nodejs-java/custom-shape/
keywords:
- własny kształt
- dodaj kształt
- twórz kształt
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z `GeometryPath`, aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię do kształtu.

Pokazuje również, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określać, czy geometria kształtu jest zamknięta, oraz konwertować pomiędzy `GeometryPath` a `java.awt.Shape` w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmienianie kształtu za pomocą punktów edycji**

Rozważmy kwadrat. W PowerPoint, używając **punktów edycji**, możesz 

* przesunąć róg kwadratu do środka lub na zewnątrz
* określić krzywiznę rogu lub punktu
* dodać nowe punkty do kwadratu
* manipulować punktami na kwadracie itd. 

W zasadzie możesz wykonywać opisane zadania na dowolnym kształcie. Używając punktów edycji, możesz zmienić kształt lub stworzyć nowy kształt z istniejącego kształtu. 

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów PowerPoint przy użyciu punktów edycji, warto rozważyć następujące kwestie dotyczące kształtów:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Gdy kształt jest zamknięty, nie ma punktu początkowego ani końcowego. Gdy kształt jest otwarty, ma początek i koniec. 
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych liniami
* Linia jest albo prosta, albo zakrzywiona. Punkty kotwiczące określają charakter linii. 
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * Punkt narożny to punkt, w którym 2 proste linie łączą się pod kątem. 
  * Punkt płynny to punkt, w którym 2 uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w gładką krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o równą odległość. 
  * Punkt prosty to punkt, w którym 2 uchwyty znajdują się w jednej prostej, a odcinki linii łączą się w gładką krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość. 
* Przez przesuwanie lub edycję punktów kotwiczących (co zmienia kąt linii), możesz zmienić wygląd kształtu. 

Do edycji kształtów PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) oraz klasę [**GeometryPath**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape).
* Aby pobrać`GeometryPath` z instancji `GeometryShape`, możesz użyć metody [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Aby ustawić `GeometryPath` dla kształtu, możesz użyć tych metod: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) dla *kształtów stałych* i [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) dla *kształtów złożonych*.
* Aby dodać segmenty, możesz użyć metod pod [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath).
* Używając metod [GeometryPath.setStroke](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) i [GeometryPath.setFillMode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), możesz ustawić wygląd ścieżki geometrycznej.
* Używając metody [GeometryPath.getPathData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath#getPathData--) możesz pobrać ścieżkę geometryczną `GeometryShape` jako tablicę segmentów ścieżki.
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz skonwertować [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Użyj metod [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) i [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeUtil)) aby konwertować [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) w obie strony.

## **Proste operacje edycji**

Ten kod JavaScript pokazuje, jak

**Dodaj linię** na koniec ścieżki

```javascript
lineTo(point);
lineTo(x, y);
```
**Dodaj linię** w określonej pozycji ścieżki:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Dodaj krzywą Beziera typu cubic** na koniec ścieżki:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Dodaj krzywą Beziera typu cubic** w określonej pozycji ścieżki:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Dodaj krzywą Beziera typu quadratic** na koniec ścieżki:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Dodaj krzywą Beziera typu quadratic** w określonej pozycji ścieżki:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Dodaj dany łuk** do ścieżki:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Zamknij bieżącą figurę** ścieżki:

```javascript
closeFigure();
```
**Ustaw pozycję następnego punktu**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Usuń segment ścieżki** o podanym indeksie:

```javascript
removeAt(index);
```

## **Dodawanie własnych punktów do kształtu**
1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeType).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) z kształtu.
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami na ścieżce.
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami na ścieżce.
5. Zastosuj ścieżkę do kształtu.

Ten kod JavaScript pokazuje, jak dodać własne punkty do kształtu:

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

## **Usuwanie punktów z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeType).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) z kształtu.
3. Usuń segment ścieżki.
4. Zastosuj ścieżkę do kształtu.

Ten kod JavaScript pokazuje, jak usunąć punkty z kształtu:

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

## **Tworzenie własnego kształtu**

1. Oblicz punkty dla kształtu.
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath).
3. Wypełnij ścieżkę punktami.
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape).
5. Zastosuj ścieżkę do kształtu.

Ten kod JavaScript pokazuje, jak stworzyć własny kształt:

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


## **Tworzenie złożonego własnego kształtu**

  1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape).
  2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath).
  3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath).
  4. Zastosuj ścieżki do kształtu.

Ten kod JavaScript pokazuje, jak stworzyć złożony własny kształt:

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

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten kod JavaScript pokazuje, jak stworzyć własny kształt z zaokrąglonymi narożnikami (do wnętrza);

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

## **Sprawdzenie, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiuje się jako taki, w którym wszystkie jego strony łączą się, tworząc jedną granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym własnym konturem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

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

## **Konwersja GeometryPath na java.awt.Shape** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape).
2. Utwórz instancję klasy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Przekonwertuj instancję [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryPath) przy użyciu [ShapeUtil](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeUtil).
4. Zastosuj ścieżki do kształtu.

Ten kod JavaScript — implementacja powyższych kroków — demonstruje proces konwersji **GeometryPath** na **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Utwórz nowy kształt
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Pobierz ścieżkę geometryczną kształtu
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Utwórz nową ścieżkę graficzną z tekstem
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
    // Konwertuj ścieżkę graficzną na ścieżkę geometryczną
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Ustaw połączenie nowej ścieżki geometrycznej i oryginalnej ścieżki geometrycznej dla kształtu
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co stanie się z wypełnieniem i obrysem po zamianie geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/setrotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z własnym układem współrzędnych kształtu.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wymagany [slide](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/nodejs-java/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometrami.