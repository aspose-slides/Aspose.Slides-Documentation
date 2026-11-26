---
title: Dostosowywanie kształtów prezentacji w Pythonie
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
- zakrzywiony róg
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona w .NET: ścieżki geometryczne, zakrzywione rogi, kształty złożone."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować kształty w prezentacji w Aspose.Slides, edytując geometrię kształtu za pomocą punktów edycji i ścieżek geometrycznych. Pokazuje, jak pracować z [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/), aby modyfikować istniejące kształty, wykonywać podstawowe operacje edycji ścieżek, dodawać lub usuwać punkty oraz zastosować zaktualizowaną geometrię ponownie do kształtu.

Demonstruje także, jak tworzyć własne i złożone kształty, budować kształty z zakrzywionymi rogami, określać, czy geometria kształtu jest zamknięta, oraz wyodrębniać elementy kształtu do analizy konturu.

## **Zmienianie kształtu za pomocą punktów edycji**

W programie PowerPoint możesz używać **Edit Points**, aby modyfikować kwadrat:

* Przesuwać róg do wewnątrz lub na zewnątrz.
* Dostosowywać krzywiznę w punkcie.
* Dodawać nowe punkty.

Edycja punktów pozwala zmienić obrys kształtu lub użyć istniejącego kształtu jako bazy dla nowego.

## **Wskazówki dotyczące edycji kształtów**

![overview_image](custom_shape_0.png)

Podczas edycji kształtów w PowerPoint pamiętaj o następujących koncepcjach:

* Kształt (lub jego ścieżka) może być zamknięty lub otwarty.
* Ścieżka kształtu składa się z punktów kotwiczących połączonych odcinkami.
* Odcinek może być prosty lub zakrzywiony. Punkty kotwiczące i uchwyty kontrolne określają jego kształt.
* Punkty kotwiczące występują jako punkty narożne, proste lub gładkie:
  * W punkcie narożnym łączące się odcinki mogą tworzyć kąt.
  * W punkcie gładkim dwa uchwyty kontrolne są wyrównane i równo oddalone od punktu kotwiczącego.
  * W punkcie prostym dwa uchwyty kontrolne są wyrównane, ale mogą mieć różne odległości od punktu kotwiczącego.
* Przemieszczanie punktów kotwiczących lub dostosowywanie ich uchwytów zmienia obrys kształtu.

Aby edytować kształty programu PowerPoint za pomocą punktów edycji, **Aspose.Slides** udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), możesz użyć metody [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) dla kształtu, możesz użyć metod: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) dla kształtów z jedną ścieżką oraz [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) dla kształtów z wieloma ścieżkami.
* Aby dodać odcinki, możesz używać metod dostępnych w [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Korzystając z właściwości [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) i [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), możesz określić wygląd ścieżki geometrycznej.
* Dzięki właściwości [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) możesz pobrać ścieżkę geometryczną [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Użyj poniższych metod, aby edytować ścieżkę geometryczną. Przeciążenia przyjmujące indeks wstawiają odcinek w tej zero‑indeksowanej pozycji w tablicy odcinków ścieżki.

| Operacja | Metoda |
| --- | --- |
| Dodaj lub wstaw prostą linię. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Dodaj lub wstaw krzywą Béziera trzeciego stopnia z dwoma punktami kontrolnymi i punktem końcowym. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Dodaj lub wstaw krzywą Béziera kwadratową z jednym punktem kontrolnym i punktem końcowym. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Dodaj łuk eliptyczny o podanych wymiarach i kątach w stopniach. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Zamknij bieżącą figurę, łącząc jej punkt końcowy z punktem początkowym. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Ustaw punkt początkowy figury. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Usuń odcinek pod zero‑indeksowym indeksem. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Dodawanie własnych punktów do kształtu**

Ten przykład wstawia dwa punkty do prostokątnego kształtu przy użyciu [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) i stosuje edytowaną ścieżkę metodą [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Współrzędne są lokalne względem kształtu: oba nowe punkty znajdują się w jego środku, 100 punktów od lewej i 50 punktów od góry. Indeksy odcinków 1 i 4 umieszczają je na górnej i dolnej krawędzi, ściągając te krawędzie do środka.

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

Ten przykład zmienia kontur w kształcie serca, usuwając odcinek pod zero‑indeksowym indeksem 2 przy użyciu [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Zastosowanie zmodyfikowanej ścieżki metodą [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aktualizuje kontur kształtu.

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

Ten przykład tworzy pięcioramienną gwiazdę przy użyciu [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Naprzemienne promienie zewnętrzne i wewnętrzne o wartościach 100 i 50 punktów definiują szczyty i wcięcia; krok 72 stopni równomiernie rozmieszcza pięć szczytów. Ścieżka jest zamykana metodą [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) i stosowana do prostokątnego kształtu metodą [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), zastępując jego kontur.

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

Ten przykład definiuje dwie zamknięte obiekty [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) dla górnej i dolnej jednej trzeciej kształtu. Zastosowanie obu ścieżek metodą [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) tworzy jeden złożony kształt z przerwą w jego środkowej jednej trzeciej.

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
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Tworzenie własnego kształtu z zakrzywionymi rogami**

Ten przykład łączy proste odcinki z metodą [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/), aby utworzyć kształt z wklęsłymi rogami. Rozmiar każdego rogu określa szerokość i wysokość łuku w punktach, a wycinek -90 stopni rysuje przeciwnie do ruchu wskazówek zegara ćwiartkowy elipsę. Gotowa ścieżka jest stosowana metodą [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), a prezentacja jest zapisywana w formacie PPTX.

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

## **Sprawdzanie, czy geometria kształtu jest zamknięta**

Poniższy pomocniczy kod sprawdza, czy każda niepusta ścieżka geometryczna kończy się odcinkiem zamykającym. Odczytuje [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) i porównuje polecenie ostatniego odcinka [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) z [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Zwraca false, gdy nie ma niepustych ścieżek. To sprawdzenie dotyczy jedynie ostatniego polecenia każdej ścieżki; nie analizuje wszystkich podfigur w ramach ścieżki. Przykład wypisuje `True` dla prostokąta.

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

## **Inspekcja poleceń ścieżki geometrycznej**

Pobierz plik [contour.pptx](contour.pptx) i umieść go w katalogu roboczym. Pierwszy kształt na pierwszym slajdzie ma prostą górną krawędź, krzywą Béziera trzeciego stopnia i prostą krawędź zamykającą. Użyj [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), aby odczytać jego ścieżki. Dla każdej ścieżki [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) wypisuje segmenty w kolejności rysowania. Polecenie każdego segmentu [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) określa, jak interpretować jego [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Kształt znajduje się w punkcie (200, 100) na slajdzie. Podane współrzędne są lokalne względem kształtu. Jego lewy górny róg to (0, 0), oś X rośnie w prawo, a oś Y w dół. Segment zamykający powraca do punktu początkowego bez dodatkowych współrzędnych.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![Kształt PowerPoint z prostą górną krawędzią, krzywą krawędzią od prawego górnego do lewego dolnego oraz prostą lewą krawędzią](contour.png)

## **Wyodrębnianie i inspekcja elementów kształtu**

Użyj [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/), aby przeanalizować istniejący kształt jako elementy zawierające punkty ścieżki i typy punktów. Każdy zwrócony [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) udostępnia tablice [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) i [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Ta reprezentacja jest przydatna do analizy konturu lub przekazywania geometrii do własnych narzędzi rysunkowych.

Przykład otwiera prezentację, znajduje pierwszy kształt geometryczny bezpośrednio na pierwszym slajdzie i wypisuje jego segmenty ścieżki. Użyj prezentacji zawierającej kształt z prostymi i zakrzywionymi segmentami, aby zobaczyć oba rodzaje wyjścia. Nie przeszukuje grup.

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
                point_type = types[i] & 0x07  # Zachowaj typ segmentu, pomijając flagi.
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

Tablice są skorelowane indeksami: `points[i]` to punkt, a `types[i]` opisuje jego rolę. Typ `0` rozpoczyna figurę, a typ `1` rysuje linię od poprzedniego punktu do bieżącego. Segment Béziera trzeciego stopnia zaczyna się w poprzednim punkcie końcowym i wykorzystuje trzy kolejne wpisy typu `3`: dwa punkty kontrolne i nowy punkt końcowy. Pętla konsumuje te trzy wpisy razem i sprawdza, czy punkt końcowy zamyka figurę.

Typy punktów zawierają również flagi. Maskuj za pomocą `0x07`, aby określić typ segmentu, oraz testuj `0x80` osobno, aby wykryć zamkniętą podścieżkę. Na przykład `129` (`0x81`) oznacza punkt końcowy linii, który zamyka podścieżkę, a `131` (`0x83`) oznacza punkt końcowy Béziera, który również zamyka podścieżkę. Porównywanie surowej wartości jedynie z `1` lub `3` pominęłoby te przypadki. Inne flagi, takie jak kreska (`0x10`) i znacznik (`0x20`), nie zmieniają podstawowego typu segmentu.

**Współrzędne i przekształcenia.** Punkty mierzone są w punktach (1/72 cala), przy czym X rośnie w prawo, a Y w dół. Dla niezgromadzonego kształtu wyodrębnione współrzędne już zawierają jego pozycję [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) i [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) oraz odzwierciedlają jego bieżącą szerokość i wysokość. Na przykład nieobrócony prostokąt w `(100, 200)` o wymiarach `120 × 80` ma granice konturu `(100, 200)`–`(220, 280)`. Nie dodawaj ponownie pozycji kształtu. Odejmij jego X i Y, aby uzyskać współrzędne względem nieobróconej ramki.

Wyodrębnione punkty nie uwzględniają obrotu [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) kształtu ani odbić poziomych i pionowych. Aby odtworzyć wyświetlany kontur, zastosuj te przekształcenia wokół środka kształtu. Dla kształtów zgrupowanych uwzględnij także mapowanie współrzędnych grupy i przekształcenia; nie zakładaj, że wyodrębnione punkty są ostatecznymi współrzędnymi slajdu ani nie stosuj podwójnego przesunięcia lub skalowania, jeśli już są odzwierciedlone w ramce dziecka.

**Inspekcja vs. edycja.** Wyodrębnione tablice opisują kontur; ich modyfikacja nie aktualizuje pierwotnego kształtu. Wybierz to podejście, gdy Twoja analiza lub kod rysujący potrzebuje tablic punktów/typów. Używaj [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), gdy potrzebujesz poleceń geometrycznych w lokalnym układzie współrzędnych kształtu lub chcesz edytować jego geometrię. Zastosuj edytowane ścieżki za pomocą [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) lub [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Co się stanie z wypełnieniem i konturem po zamianie geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i kontur są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj właściwości [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” rezultat?**

Tak. Eksportuj wymagany [slajd](/slides/pl/python-net/convert-powerpoint-to-png/) lub sam [kształt](/slides/pl/python-net/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z złożonymi geometriami.