---
title: Dostosuj kształty prezentacji w Pythonie
linktitle: Kształt niestandardowy
type: docs
weight: 20
url: /pl/python-net/custom-shape/
keywords:
- niestandardowy kształt
- dodaj kształt
- utwórz kształt
- zmień kształt
- geometria kształtu
- ścieżka geometryczna
- punkty ścieżki
- edytuj punkty
- dodaj punkt
- usuń punkt
- operacja edycji
- zaokrąglony narożnik
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona w technologii .NET: ścieżki geometryczne, zaokrąglone narożniki, kształty złożone."
---
## **Przegląd**

W tym artykule wyjaśniono, jak dostosować kształty w prezentacji w Aspose.Slides poprzez edycję geometrii kształtu przy użyciu punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię z powrotem do kształtu.

Pokazuje również, jak tworzyć własne i złożone kształty, budować kształty z zakrzywionymi narożnikami, określać, czy geometria kształtu jest zamknięta oraz wyodrębniać elementy kształtu do analizy konturu.

## **Zmienianie kształtu przy użyciu punktów edycji**

* Przesuń narożnik do wewnątrz lub na zewnątrz.
* Dostosuj krzywiznę w punkcie.
* Dodaj nowe punkty.

Edycja punktów pozwala modyfikować kontur kształtu lub używać istniejącego kształtu jako podstawy do nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint, pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub zakrzywiony. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym przylegające odcinki mogą łączyć się pod kątem.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i znajdują się w jednakowej odległości od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą znajdować się w różnej odległości od punktu kotwiczącego.
* Przemieszczanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia kontur kształtu.

Aby edytować kształty PowerPoint przy użyciu punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), możesz użyć metody [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) dla kształtu, możesz użyć tych metod: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) dla kształtów z jedną ścieżką oraz [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz użyć metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Używając właściwości [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) i [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), możesz ustawić wygląd ścieżki geometrycznej.
* Korzystając z właściwości [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Użyj następujących metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają segment na wskazanej, zerowo‑indeksowanej pozycji w tablicy segmentów ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Dodaj lub wstaw krzywą Béziera drugiego stopnia z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Dodaj eliptyczną łuk z określonymi wymiarami i kątami w stopniach. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Ustaw punkt początkowy figury. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Usuń segment pod zerowo‑indeksowanym indeksem. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/), i zastosowuje edytowaną ścieżkę za pomocą [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego centrum, 100 punktów od lewej i 50 punktów od góry. Indeksy segmentów 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do wewnątrz.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Usuwanie punktów z kształtu**

Ten przykład zmienia kontur kształtu serca, usuwając segment pod zerowo‑indeksowanym indeksem 2 za pomocą [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Zastosowanie zmodyfikowanej ścieżki przy użyciu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aktualizuje kontur kształtu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Tworzenie własnego kształtu**

Ten przykład tworzy pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Naprzemienne zewnętrzne i wewnętrzne promienie o wartościach 100 i 50 punktów definiują wierzchołki i wgłębienia; krok 72 stopnie równomiernie rozmieszcza pięć wierzchołków. Ścieżka jest zamykana metodą [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) i stosowana do prostokątnego kształtu przy użyciu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), zastępując jego kontur.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Tworzenie złożonego własnego kształtu**

Ten przykład definiuje dwa zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) dla górnej i dolnej trzeciej części kształtu. Zastosowanie obu ścieżek przy użyciu [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) tworzy pojedynczy złożony kształt z przerwą w środkowej trzeciej części.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(shape.height / 3 * 2, 0)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zakrzywionymi narożnikami**

Ten przykład łączy proste odcinki z [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) aby stworzyć kształt z wklęsłymi, zakrzywionymi narożnikami. Rozmiar każdego narożnika określa szerokość i wysokość łuku w punktach, a obrót -90 stopni rysuje elipsę w ćwiartce w kierunku przeciwnym do ruchu wskazówek zegara. Gotowa ścieżka jest stosowana przy użyciu [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), a prezentacja jest zapisywana w formacie PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdzenie, czy geometria kształtu jest zamknięta**

Poniższy pomocnik sprawdza, czy każda niepusta ścieżka geometryczna kończy się segmentem zamykającym. Odczytuje [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) i porównuje polecenie ostatniego segmentu [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) z [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. Sprawdza jedynie końcowe polecenie każdej ścieżki; nie analizuje każdej podfigury w ścieżce. Przykład wypisuje `True` dla prostokąta.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Wyodrębnianie i analizowanie elementów kształtu**

Użyj [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) , aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Każdy zwrócony [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) udostępnia tablice [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) i [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysujących.

Przykład otwiera prezentację, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z odcinkami prostymi i zakrzywionymi, aby zobaczyć oba rodzaje wyników. Nie przeszukuje grup.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Tablice odpowiadają sobie indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment krzywej Béziera trzeciego stopnia zaczyna się od poprzedniego punktu końcowego i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne i nowy punkt końcowy. Pętla zużywa te trzy wpisy jednocześnie i sprawdza punkt końcowy pod kątem zamknięcia.

Typy punktów zawierają także flagi. Maska `0x07` służy do identyfikacji typu segmentu, a test `0x80` oddzielnie wykrywa zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii zamykający podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera zamykający podścieżkę. Porównywanie surowej wartości tylko z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty są mierzone w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niepogrupowanego kształtu wyodrębnione współrzędne już zawierają jego pozycję [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) i [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) oraz odzwierciedlają aktualną szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o rozmiarze `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ani odbić poziomych i pionowych kształtu. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla grupowanych kształtów uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj dwukrotnie tłumaczenia lub skalowania, jeśli jest już odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje pierwotnego kształtu. Wybierz to podejście, gdy twoja analiza lub kod rysujący wymaga tablic punktów/typów. Użyj [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) , gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki przy użyciu [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) lub [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Co się stanie z wypełnieniem i konturem po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i kontur są automatycznie stosowane do nowej geometrii.

**Jak poprawnie obrócić własny kształt wraz z jego geometrią?**

Użyj właściwości [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z własnym układem współrzędnych kształtu.

**Czy mogę przekonwertować własny kształt na obraz, aby „zablokować” rezultat?**

Tak. Wyeksportuj wymaganą [slide](/slides/pl/python-net/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/python-net/create-shape-thumbnails/) do formatu rastrowego; ułatwia to dalszą pracę z złożonymi geometrami.