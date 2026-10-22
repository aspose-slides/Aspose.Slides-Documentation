---
title: Dostosowywanie kształtów prezentacji w Pythonie poprzez Java
linktitle: Niestandardowy kształt
type: docs
weight: 20
url: /pl/python-java/custom-shape/
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
- Python
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżki, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu.

Pokazuje także, jak tworzyć niestandardowe i złożone kształty, budować kształty z zakrzywionymi rogami, określać, czy geometria kształtu jest zamknięta, analizować elementy kształtu oraz konwertować kontury tekstu Java AWT na ścieżki geometryczne.

## **Zmiana kształtu przy użyciu punktów edycji**

* Przesuń róg do wewnątrz lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Punkty edycji pozwalają zmodyfikować kontur kształtu lub użyć istniejącego kształtu jako podstawy dla nowego.

## **Wskazówki dotyczące edycji kształtu**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów PowerPoint, pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięta lub otwarta.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub zakrzywiony. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym, przylegające odcinki mogą spotykać się pod kątem.
  * W punkcie gładkim, dwa uchwyty kontrolne są wyrównane i równomiernie oddalone od punktu kotwiczącego.
  * W punkcie prostym, dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przemieszczanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia kontur kształtu.

Aby edytować kształty PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), można użyć metody [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) dla kształtu, możesz użyć następujących metod: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) dla kształtów z pojedynczą ścieżką oraz [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz użyć metod znajdujących się w [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Korzystając z metod [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) i [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), możesz ustawić wygląd ścieżki geometrycznej.
* Używając metody [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.
* Aby uzyskać dostęp do dodatkowych opcji dostosowywania geometrii kształtu, możesz odczytać [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) za pomocą jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) i odtworzyć segmenty na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Proste operacje edycji**

Użyj następujących metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają segment w tej pozycji zerobazowej w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Dodaj lub wstaw kwadratową krzywą Béziera z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Ustaw punkt początkowy figury. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Usuń segment o indeksie zerowym. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Dodaj niestandardowe punkty do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) i stosuje edytowaną ścieżkę metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej krawędzi i 50 punktów od górnej. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do wewnątrz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Usuń punkty z kształtu**

Ten przykład zmienia obrys kształtu serca, usuwając segment o indeksie zerowym 2 metodą [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Zastosowanie zmodyfikowanej ścieżki metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aktualizuje kontur kształtu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Utwórz niestandardowy kształt**

Ten przykład buduje pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne wynoszące odpowiednio 100 i 50 punktów definiują wierzchołki i wgłębienia; krok 72 stopni równomiernie rozmieszcza pięć wierzchołków. Ścieżka jest zamykana metodą [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) i stosowana do prostokątnego kształtu metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), zastępując jego obrys.

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
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Utwórz złożony niestandardowy kształt**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek metodą [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy pojedynczy złożony kształt z przerwą w środkowej jednej trzeciej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Utwórz niestandardowy kształt z zaokrąglonymi rogami**

Ten przykład łączy proste odcinki z metodą [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo), aby stworzyć kształt z wklęsłymi zakrzywionymi rogami. Rozmiar każdego rogu określa szerokość i wysokość łuku w punktach, a kąt -90 stopni rysuje przeciwzegarowy ćwiartkowy elipsę. Gotowa ścieżka jest stosowana metodą [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), a prezentacja jest zapisywana w formacie PPTX.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

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

## **Sprawdź, czy geometria kształtu jest zamknięta**

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) i porównuje polecenie ostatniego segmentu [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) z [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Zwraca `False`, gdy nie ma niepustych ścieżek. Procedura sprawdza polecenie końcowe każdej ścieżki; nie analizuje każdego podfigury w obrębie ścieżki. Przykład wypisuje `True` dla prostokąta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Wyodrębnij i przeanalizuj elementy kształtu**

Użyj [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Rzutuj każdy zwrócony element na [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) przy pomocy `jpype.JObject`, aby pobrać tablice punktów i typów za pomocą metod [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) i [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Ta reprezentacja jest przydatna przy analizie konturu lub przekazywaniu geometrii do własnych narzędzi rysunkowych.

Przykład otwiera plik input.pptx, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z odcinkami prostymi i zakrzywionymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Zachowaj typ segmentu, wyłączając flagi.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Zużyj oba punkty kontrolne i punkt końcowy.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Tablice odpowiadają sobie indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment krzywej Béziera trzeciego stopnia zaczyna się w poprzednim punkcie końcowym i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne oraz nowy punkt końcowy. Pętla konsumuje te trzy wpisy razem i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maskuj wartości za pomocą `0x07`, aby zidentyfikować typ segmentu, oraz testuj `0x80` oddzielnie, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii, który zamyka podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera, który zamyka podścieżkę. Java przechowuje te flagi w bajtach ze znakiem; maskowanie zachowuje zamierzone wartości bitowe. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak przerywanie (`0x10`) i marker (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezgromadzonego kształtu wyodrębnione współrzędne już zawierają pozycję zwróconą przez [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) i [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) oraz odzwierciedlają aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o wymiarach `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj pozycji kształtu ponownie. Odejmij jego X i Y, aby uzyskać współrzędne względem jego nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu kształtu zwróconego przez [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów zgromadzonych uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego tłumaczenia lub skalowania, jeśli już są odzwierciedlone w ramce dziecka.

**Inspekcja a edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje pierwotnego kształtu. Wybierz tę metodę, gdy analiza lub kod rysujący potrzebuje tablic punktów/typów. Użyj [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), gdy potrzebujesz poleceń geometrii w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki za pomocą [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) lub [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konwertuj kształt Java AWT na GeometryPath**

Ten przykład łączy prostokątny obrys z tekstem przekształconym na geometrię. Metoda [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) obrysu wyłącza jego wypełnienie. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) tworzy kontur tekstu w [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Jego [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) dostarcza segmenty ruchu, linii, kwadratowe, sześcienne i zamykające, które przykład odtwarza na [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Tekst używa czcionki Arial 40 punktów. Obrys jest przesunięty o 20 punktów w poziomie i umieszczony tak, aby jego wizualna górna krawędź była 10 punktów niżej od górnej krawędzi kształtu. Ścieżka tekstowa jest wypełniona, podczas gdy oryginalny prostokąt pozostaje jedynie obrysem. Zastosowanie obu ścieżek metodą [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) tworzy pojedynczy kształt zawierający prostokąt i tekst.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Pobierz ścieżkę geometryczną kształtu.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Utwórz nową ścieżkę graficzną z tekstem.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Przekształć ścieżkę graficzną na ścieżkę geometryczną.
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

    # Apply the text path together with the original geometry path.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Co się stanie z wypełnieniem i obrysem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się tylko kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić niestandardowy kształt wraz z jego geometrią?**

Użyj metody [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) kształtu; geometria obraca się razem z kształtem, ponieważ jest powiązana z jego własnym układem współrzędnych.

**Czy mogę przekonwertować niestandardowy kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wymaganą [slajd](/slides/pl/python-java/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/python-java/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.