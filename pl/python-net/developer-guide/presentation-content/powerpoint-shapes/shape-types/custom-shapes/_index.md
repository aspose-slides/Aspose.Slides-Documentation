---
title: Personalizuj kształty w prezentacjach za pomocą Pythona
linktitle: Własny kształt
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
- zaokrąglony róg
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i personalizuj kształty w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona w środowisku .NET: ścieżki geometryczne, zaokrąglone rogi, kształty złożone."
---
## **Wprowadzenie**

Rozważ kwadrat. W programie PowerPoint, używając **Edit Points**, możesz:

* przesunąć róg kwadratu w środku lub na zewnątrz,
* dostosować krzywiznę rogu lub punktu,
* dodać nowe punkty do kwadratu,
* manipulować jego punktami.

Możesz zastosować te operacje do dowolnego kształtu. Dzięki **Edit Points** możesz modyfikować kształt lub utworzyć nowy na podstawie istniejącego kształtu.

## **Wskazówki dotyczące edycji kształtów**

!["Edit Points" - polecenie](custom_shape_0.png)

Zanim rozpoczniesz edycję kształtów w PowerPoint przy użyciu **Edit Points**, rozważ następujące uwagi dotyczące kształtów:

* Kształt (lub jego ścieżka) może być **zamknięty** lub **otwarty**.
* Zamknięty kształt nie ma punktu początkowego ani końcowego; otwarty kształt ma początek i koniec.
* Każdy kształt posiada co najmniej dwa punkty kotwiczące połączone odcinkami linii.
* Odcinek jest prosty lub zakrzywiony; punkty kotwiczące określają charakter odcinka.
* Punkty kotwiczące mogą być **corner**, **smooth** lub **straight**:
  * Punkt **corner** to miejsce, w którym dwa proste odcinki spotykają się pod kątem.
  * Punkt **smooth** posiada dwa uchwyty leżące na jednej linii, a przylegające odcinki tworzą płynnie zakrzywioną krzywą. W tym przypadku oba uchwyty są w tej samej odległości od punktu kotwiczącego.
  * Punkt **straight** również ma dwa kolinearne uchwyty, a przylegające odcinki tworzą gładką krzywą. W tym przypadku uchwyty nie muszą znajdować się w takiej samej odległości od punktu kotwiczącego.
* Przesuwając lub edytując punkty kotwiczące (co zmienia kąty odcinków), możesz zmienić wygląd kształtu.

Aby edytować kształty w PowerPoint, Aspose.Slides udostępnia klasę [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/).

* Instancja [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) reprezentuje ścieżkę geometryczną obiektu [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/).
* Aby pobrać [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) z instancji [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/), użyj metody [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Aby ustawić [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) dla kształtu, użyj [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/set_geometry_path/) dla *solid shapes* oraz [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/set_geometry_paths/) dla *composite shapes*.
* Aby dodać odcinki, użyj metod klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/).
* Użyj właściwości [GeometryPath.stroke](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/stroke/) i [GeometryPath.fill_mode](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/fill_mode/) aby kontrolować wygląd ścieżki geometrycznej.
* Użyj właściwości [GeometryPath.path_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/path_data/) aby pobrać ścieżkę geometryczną kształtu jako tablicę segmentów ścieżki.

## **Proste operacje edycji**

Poniższe metody służą do prostych operacji edycji.

**Dodaj linię** na końcu ścieżki:

```py
line_to(point)
line_to(x, y)
```

**Dodaj linię** w określonej pozycji w ścieżce:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Dodaj krzywą Beziera stopnia sześciennego** na końcu ścieżki:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Dodaj krzywą Beziera stopnia sześciennego** w określonej pozycji w ścieżce:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Dodaj krzywą Beziera stopnia kwadratowego** na końcu ścieżki:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Dodaj krzywą Beziera stopnia kwadratowego** w określonej pozycji w ścieżce:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Dodaj łuk** do ścieżki:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Zamknij bieżącą figurę** w ścieżce:

```py
close_figure()
```

**Ustaw pozycję następnego punktu**:

```py
move_to(point)
move_to(x, y)
```

**Usuń segment ścieżki** o podanym indeksie:

```py
remove_at(index)
```

## **Dodaj własne punkty do kształtów**

Tutaj dowiesz się, jak zdefiniować kształt wolnej formy, dodając własną sekwencję punktów. Określając uporządkowane punkty i typy segmentów (proste lub zakrzywione) oraz opcjonalnie zamykając ścieżkę, możesz rysować precyzyjne grafiki niestandardowe — wielokąty, ikony, dymki lub loga — bezpośrednio na slajdach.

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/) i ustaw jej [ShapeType.RECTANGLE](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapetype/).
2. Pobierz instancję [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) z kształtu.
3. Wstaw nowy punkt pomiędzy dwa górne punkty w ścieżce.
4. Wstaw nowy punkt pomiędzy dwa dolne punkty w ścieżce.
5. Zastosuj zaktualizowaną ścieżkę do kształtu.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Własne punkty](custom_shape_1.png)

##  **Usuń punkty z kształtów**

Czasami własny kształt zawiera niepotrzebne punkty, które komplikują jego geometrię lub wpływają na renderowanie. Ten rozdział pokazuje, jak usunąć konkretne punkty ze ścieżki kształtu, aby uprościć obrys i uzyskać czystsze, bardziej precyzyjne rezultaty.

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/) i ustaw jej typ [ShapeType.HEART](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapetype/).
2. Pobierz instancję [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) z kształtu.
3. Usuń segment ze ścieżki.
4. Zastosuj zaktualizowaną ścieżkę do kształtu.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Usunięte punkty](custom_shape_2.png)

##  **Utwórz własne kształty**

Utwórz dedykowane kształty wektorowe, definiując [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/) i komponując go z linii, łuków oraz krzywych Béziera. Ten rozdział pokazuje, jak zbudować własną geometrię od podstaw i dodać powstały kształt do slajdu.

1. Oblicz punkty dla kształtu.
2. Utwórz instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/).
3. Napełnij ścieżkę punktami.
4. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/).
5. Zastosuj ścieżkę do kształtu.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Własny kształt](custom_shape_3.png)

## **Utwórz złożone własne kształty**

Tworzenie złożonego własnego kształtu pozwala połączyć wiele ścieżek geometrycznych w jeden, wielokrotnego użytku kształt na slajdzie. Zdefiniuj i scal te ścieżki, aby zbudować złożone wizualizacje wykraczające poza standardowy zestaw kształtów.

1. Utwórz instancję klasy [GeometryShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/).
2. Utwórz pierwszą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/).
3. Utwórz drugą instancję klasy [GeometryPath](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometrypath/).
4. Zastosuj obie ścieżki do kształtu.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Kształt złożony](custom_shape_4.png)

## **Utwórz własne kształty z zaokrąglonymi rogami**

Ten rozdział pokazuje, jak narysować własny kształt z płynnie zakrzywionymi rogami przy użyciu ścieżki geometrycznej. Połączysz odcinki proste i łuki kołowe, aby utworzyć obrys i dodać gotowy kształt do slajdu.

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Zaokrąglone rogi](custom_shape_6.png)

## **Określ, czy geometria kształtu jest zamknięta**

Zamknięty kształt definiowany jest jako taki, w którym wszystkie jego boki łączą się, tworząc jednolitą granicę bez przerw. Taki kształt może być prostą formą geometryczną lub złożonym własnym obrysem. Poniższy przykład kodu pokazuje, jak sprawdzić, czy geometria kształtu jest zamknięta:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Jakie będą skutki dla wypełnienia i obrysu po zastąpieniu geometrii?**

Styl pozostaje przypisany do kształtu; zmienia się jedynie kontur. Wypełnienie i obrys są automatycznie stosowane do nowej geometrii.

**Jak prawidłowo obrócić własny kształt wraz z jego geometrią?**

Użyj właściwości [rotation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/rotation/) kształtu; geometria obraca się razem z kształtem, ponieważ jest związana z jego własnym układem współrzędnych.

**Czy mogę skonwertować własny kształt na obraz, aby „zablokować” wynik?**

Tak. Wyeksportuj wybrany [slide](/slides/pl/python-net/convert-powerpoint-to-png/) lub sam [shape](/slides/pl/python-net/create-shape-thumbnails/) do formatu rastrowego; upraszcza to dalszą pracę z rozbudowanymi geometriami.