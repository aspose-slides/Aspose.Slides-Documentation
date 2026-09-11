---
title: Dostosowywanie kształtów prezentacji w Pythonie za pośrednictwem Javy
linktitle: Własny kształt
type: docs
weight: 20
url: /pl/python-java/custom-shape/
keywords:
- własny kształt
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
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona za pośrednictwem Javy: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) w celu modyfikacji istniejących kształtów, wykonywania podstawowych operacji edycji ścieżek, dodawania lub usuwania punktów oraz zastosowania zaktualizowanej geometrii do kształtu.

Demonstruje także, jak tworzyć własne i złożone kształty, budować kształty z zaokrąglonymi narożnikami, określić, czy geometria kształtu jest zamknięta, oraz konwertować między [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) a [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) w dodatkowych scenariuszach dostosowywania geometrii.

## **Zmiana kształtu za pomocą punktów edycji**

Rozważmy kwadrat. W PowerPoint, używając **punktów edycji**, możesz

* przesunąć róg kwadratu do środka lub na zewnątrz
* określić krzywiznę rogu lub punktu
* dodać nowe punkty do kwadratu
* manipulować punktami na kwadracie itp.

W zasadzie możesz wykonać opisane czynności na dowolnym kształcie. Korzystając z punktów edycji, możesz zmienić kształt lub utworzyć nowy kształt z istniejącego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów PowerPoint za pomocą punktów edycji, warto rozważyć następujące kwestie dotyczące kształtów:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Kiedy kształt jest zamknięty, nie ma punktu początkowego ani końcowego. Gdy jest otwarty, ma początek i koniec. 
* Wszystkie kształty składają się z co najmniej 2 punktów kotwiczących połączonych liniami.
* Linia może być prosta lub zakrzywiona. Punkty kotwiczące określają charakter linii. 
* Punkty kotwiczące występują jako punkty narożne, proste lub płynne:
  * Punkt narożny to punkt, w którym 2 proste linie łączą się pod kątem. 
  * Punkt płynny to punkt, w którym 2 uchwyty leżą w jednej linii, a segmenty linii łączą się w płynną krzywą. W tym przypadku wszystkie uchwyty są oddalone od punktu kotwiczącego o tę samą odległość. 
  * Punkt prosty to punkt, w którym 2 uchwyty leżą w jednej linii, a segmenty tej linii łączą się w płynną krzywą. W tym przypadku uchwyty nie muszą być oddalone od punktu kotwiczącego o równą odległość. 
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąt linii), możesz zmienić wygląd kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/). 
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/), użyj metody [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#getGeometryPaths). 
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#setGeometryPath) dla *kształtów stałych* oraz [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/#setGeometryPaths) dla *kształtów złożonych*.
* Aby dodać segmenty, użyj metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/). 
* Korzystając z metod [GeometryPath.setStroke](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/#setStroke) i [GeometryPath.setFillMode](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/#setFillMode), możesz ustawić wygląd ścieżki geometrycznej.
* Metodą [GeometryPath.getPathData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/#getPathData) możesz pobrać geometrię [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki. 
* Aby uzyskać dodatkowe opcje dostosowywania geometrii kształtu, możesz przekonwertować [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Użyj metod [geometryPathToGraphicsPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeutil/) i [graphicsPathToGeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeutil/) (z klasy [ShapeUtil](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapeutil/)) do konwersji [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) na [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) i odwrotnie. 

## **Podstawowe operacje edycji**

Poniższe sygnatury pokazują podstawowe operacje edycji:

**Dodaj linię** na końcu ścieżki:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Dodaj linię** w określonej pozycji na ścieżce:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Dodaj krzywą Beziera stopnia trzeciego** na końcu ścieżki:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Dodaj krzywą Beziera stopnia trzeciego** w określonej pozycji na ścieżce:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Dodaj krzywą Beziera stopnia drugiego** na końcu ścieżki:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Dodaj krzywą Beziera stopnia drugiego** w określonej pozycji na ścieżce:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Dołącz dany łuk** do ścieżki:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Zamknij bieżącą figurę** ścieżki:

- `geometry_path.closeFigure()`

**Ustaw pozycję dla następnego punktu**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Usuń segment ścieżki** o podanym indeksie:

- `geometry_path.removeAt(index)`


## **Dodawanie własnych punktów do kształtu**
1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/) i ustaw typ [ShapeType.Rectangle](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Rectangle).
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) z tego kształtu.
3. Dodaj nowy punkt pomiędzy dwoma górnymi punktami ścieżki.
4. Dodaj nowy punkt pomiędzy dwoma dolnymi punktami ścieżki.
5. Zastosuj ścieżkę do kształtu.

Ten kod w Pythonie pokazuje, jak dodać własne punkty do kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/) i ustaw typ [ShapeType.Heart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/#Heart). 
2. Pobierz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/) z tego kształtu.
3. Usuń segment ścieżki.
4. Zastosuj ścieżkę do kształtu.

Ten kod w Pythonie pokazuje, jak usunąć punkty z kształtu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

1. Oblicz punkty dla kształtu.
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/). 
3. Wypełnij ścieżkę punktami.
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/). 
5. Zastosuj ścieżkę do kształtu.

Ten kod w Pythonie pokazuje, jak stworzyć własny kształt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Tworzenie złożonego własnego kształtu**

  1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/).
  2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/).
  3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/).
  4. Zastosuj ścieżki do kształtu.

Ten kod w Pythonie pokazuje, jak stworzyć złożony własny kształt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zaokrąglonymi narożnikami**

Ten kod w Pythonie pokazuje, jak stworzyć własny kształt z zaokrąglonymi narożnikami (do wewnątrz):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    shape.setGeometryPath(geometry_path)
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiuje się jako taki, w którym wszystkie jego boki łączą się, tworząc jedną granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym własnym obrysem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **Konwersja GeometryPath do java.awt.Shape** 

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometryshape/).
2. Utwórz instancję klasy [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Przekonwertuj instancję [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) na instancję [GeometryPath](https://reference.aspose.com/slides/pl/python-java/aspose.slides/geometrypath/), przechodząc jej [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtwarzając każdy segment na ścieżce.
4. Zastosuj ścieżki do kształtu.

Ten kod w Pythonie realizuje powyższe kroki, konwertując ścieżkę graficzną na ścieżkę geometryczną:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    # Utwórz nowy kształt.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Pobierz ścieżkę geometryczną kształtu.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Utwórz nową ścieżkę graficzną z tekstem.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Konwertuj ścieżkę graficzną na ścieżkę geometryczną.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Zastosuj ścieżkę tekstową wraz z oryginalną ścieżką geometryczną.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i konturem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i kontur są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setRotation) kształtu; geometria obraca się razem z kształtem, ponieważ jest powiązana z własnym układem współrzędnych kształtu.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj żądany obszar [slajdu](/slides/pl/python-java/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/python-java/create-shape-thumbnails/) do formatu rastrowego; ułatwi to dalszą pracę z ciężkimi geometriami.