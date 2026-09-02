---
title: Zarządzanie kształtami prezentacji w Pythonie
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/python-net/shape-manipulations/
keywords:
- kształt PowerPoint
- kształt prezentacji
- kształt na slajdzie
- znajdowanie kształtu
- klonowanie kształtu
- usuwanie kształtu
- ukrywanie kształtu
- zmiana kolejności kształtu
- pobieranie ID kształtu interop
- alternatywny tekst kształtu
- punkt dopasowania kształtu
- wstępne dopasowanie kształtu
- geometria kształtu
- formaty układu kształtu
- kształt jako SVG
- kształt do SVG
- wyrównanie kształtu
- odbijanie kształtu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, dostosowywać, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odbijać kształty w prezentacji za pomocą Aspose.Slides for Python via .NET."
---
## **Przegląd**

Aspose.Slides dla Pythona via .NET przedstawia kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdujesz i modyfikujesz kształty, oraz źródłem ich kolejności nakładania: indeks `0` jest najdalej z tyłu, a ostatni indeks jest najbliżej przodu.

Ten artykuł opiera się na tym modelu. Najpierw wyjaśnia, jak niezawodnie zidentyfikować kształt i zmodyfikować wstępnie ustawione punkty dopasowania, a następnie pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport SVG, wyrównywanie i ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać tylko operacji wymaganych w Twoim przepływie pracy.

## **Identyfikowanie i wyszukiwanie kształtów**

Indeksy kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stabilnymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator zgodnie z tym, jak prezentacja jest tworzona i utrzymywana:

- [Shape.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/name/) jest przydatny w szablonach kontrolowanych przez programistów i łatwy do sprawdzenia w panelu wyboru PowerPointa. Nazwy mogą być edytowane i nie są gwarantowane jako unikalne, więc wprowadź konwencję nazewnictwa, jeśli kod od nich zależy.
- [Shape.alternative_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/alternative_text/) jest przydatny, gdy opis dostępności lub tag dostarczony przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub przepisywany w celu zapewnienia dostępności i nie jest gwarantowany jako unikalny. Nie używaj cichego przeznaczenia znaczącego tekstu dostępności jako klucza bazy danych.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/office_interop_shape_id/) jest identyfikatorem tylko do odczytu, który jest unikalny w obrębie slajdu i odpowiada identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odniesienia w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana własność [Shape.unique_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/unique_id/) ma zakres prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie należy traktować jej jako trwałego zewnętrznego klucza. Jeśli długoterminowa tożsamość jest istotna, zachowaj mapowanie w danych aplikacji i zweryfikuj, czy oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po `name` przy użyciu dokładnego porównania i raportuje identyfikator interop w zakresie slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Gdy operacja jest specyficzna dla typu kształtu, sprawdź typ przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i alternatywny tekst tylko wtedy, gdy nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Identyfikowanie i modyfikowanie wstępnie ustawionych dopasowań kształtów**

Kształty o geometrii wstępnie ustawionej mogą udostępniać punkty dopasowania, które kontrolują cechy takie jak rozmiar narożników, proporcje strzałek lub kąty łuków. Dostęp do nich uzyskuje się przez kolekcję tylko do odczytu [GeometryShape.adjustments](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/adjustments/). Sama kolekcja jest dostarczana przez kształt, ale każdy [AdjustValue](https://reference.aspose.com/slides/pl/python-net/aspose.slides/adjustvalue/) zawiera wartość, którą można zmienić.

Nie polegaj wyłącznie na stałym indeksie kolekcji. Iteruj przez dopasowania i sprawdzaj własność tylko do odczytu [AdjustValue.type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/adjustvalue/type/), której wartość [ShapeAdjustmentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeadjustmenttype/) opisuje, co dopasowanie kontroluje. Własność tylko do odczytu [AdjustValue.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/adjustvalue/name/) dostarcza dodatkowych informacji identyfikacyjnych i jest szczególnie przydatna, gdy wstępny zestaw zawiera więcej niż jedno dopasowanie tego samego typu semantycznego.

Użyj właściwości wartości odpowiadającej znaczeniu dopasowania:

| Typ dopasowania | Cel | Wartość do zmiany |
|---|---|---|
| `CORNER_SIZE` | Rozmiar zaokrąglonych narożników | [raw_value](https://reference.aspose.com/slides/pl/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Grubość ogona strzałki | `raw_value` |
| `ARROWHEAD_LENGTH` | Długość grotu strzałki | `raw_value` |
| `ARROWHEAD_WIDTH` | Szerokość grotu strzałki | `raw_value` |
| `START_ANGLE` | Kąt początkowy koła lub łuku | [angle_value](https://reference.aspose.com/slides/pl/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Kąt końcowy koła lub łuku | `angle_value` |

`type` i `name` nie mogą być przypisywane. `raw_value` jest liczbą całkowitą do odczytu/zapisu w natywnych jednostkach geometrii wstępnego zestawu, natomiast `angle_value` jest wartością kąta w stopniach, którą można odczytywać i zapisywać. Liczba, kolejność, znaczenie i dopuszczalny zakres dopasowań zależą od wstępnego zestawu [GeometryShape.shape_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/geometryshape/shape_type/). Wartość ważna dla jednego wstępnego zestawu może być niewłaściwa lub mieć inny efekt dla innego.

Gdy `type` ma wartość `ShapeAdjustmentType.CUSTOM`, API nie rozpoznaje standardowego znaczenia semantycznego. Sprawdź `name`, typ wstępny i istniejącą wartość, i pozostaw dopasowanie niezmienione, chyba że znane jest oczekiwane znaczenie i zakres. Nawet dla rozpoznanych typów, sprawdź, czy ten sam typ występuje więcej niż raz przed wybraniem wartości. Artykuł [Connector](/slides/pl/python-net/connector/) pokazuje tę sytuację w kontekście dopasowań zgięcia łącznika.

Poniższy kompletny przykład tworzy domyślne i zmodyfikowane wersje trzech wstępnych kształtów. Iteruje przez każde dopasowanie, raportuje jego `name` i `type`, zmienia wartości związane z rozmiarem poprzez `raw_value`, zmienia kąty poprzez `angle_value` i zapisuje wynik. Lewa kolumna zachowuje domyślną geometrię; prawa kolumna pokazuje dostosowany prostokąt zaokrąglony, czterokierunkową strzałkę i kołowy wycinek.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj nagłówki dla domyślnych i zmodyfikowanych kolumn kształtów.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Sprawdzanie typu semantycznego przed zmianą wartości sprawia, że kod jest jednoznaczny co do zamiaru i unika zakładania, że konkretny indeks kolekcji ma to samo znaczenie w różnych wstępnych kształtach.

## **Modyfikowanie kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie kontynuuj polegania na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_clone/) tworzy niezależną kopię i dopisuje ją do docelowej kolekcji. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/insert_clone/) także tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany rozmiaru; przeciążenia z szerokością i wysokością mogą również zmienić jego rozmiar.

Przykład tworzy slajd docelowy, klonuje opisany prostokąt na przednią warstwę i wstawia drugi klon z tyłu. Zmiany w którymkolwiek klonie nie modyfikują kształtu źródłowego.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Klonowanie kopiuje zawartość i formatowanie kształtu, w tym jego nazwę oraz tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[ShapeCollection.remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w trakcie iteracji indeksowanej, przechodź od końca, aby każdy pozostały indeks pozostał ważny.

Ten przykład usuwa każdy kształt o określonej nazwie. Odczytuje `slide.shapes[index]`, a nie stały element kolekcji, i nie rzutuje kształtu niepotrzebnie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do niezmienionych kształtów pozostają bardziej wiarygodne niż zapisane indeksy. Weź także pod uwagę łączniki, animacje i inne elementy prezentacji, które mogą odwoływać się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Shape.hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/hidden/) na `True` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą być przywrócone później.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Ukrycie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może zostać wykryty i odsłonięty przez użytkownika lub kod, i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z-Order**

Nakładające się kształty są rysowane w kolejności kolekcji. [ShapeCollection.reorder](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez klonowania. Indeks `0` jest tyłem; `len(slide.shapes) - 1` jest przodem.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Prostokąt jest tworzony najpierw i początkowo znajduje się za elipsem. Przeniesienie go do ostatniego indeksu powoduje, że znajduje się z przodu. Sfinalizuj kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dopisują lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną kolejkę.

## **Inspekcja kształtów na slajdach układu**

Normalne slajdy, slajdy układu i slajdy nadrzędne mają osobne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie pozycjonowany kształt na normalnym slajdzie. Sprawdzaj kształty układu, gdy musisz zrozumieć lub zmienić formatowanie dostarczone przez układ.

Poniższy przykład odczytuje [Shape.fill_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/fill_format/) i [Shape.line_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/line_format/) każdego kształtu układu, nie zakładając, że każdy kształt jest `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Edycja układu może wpływać na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy normalny slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksport kształtu do SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, nie cały tło slajdu ani sąsiadujące kształty.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Utrzymuj prezentację otwartą podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd, a nie pojedynczy kształt. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/align_shapes/) posiada przeciążenia wyrównujące wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb rozmieszczenia. Ustaw `align_to_slide` na `True`, aby używać krawędzi slajdu; ustaw na `False`, aby wyrównać wybrane kształty względem siebie nawzajem.

Ten przykład wyrównuje trzy kształty do górnej krawędzi slajdu. Ich bieżące indeksy są rozwiązywane bezpośrednio przed wyrównaniem.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Wyrównanie zmienia pozycje, nie kolejność Z. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, natomiast rozmieszczenie poziome lub pionowe wymaga wystarczającej liczby kształtów, aby określić odstępy. Przelicz indeksy, jeśli zmieniasz kolekcję przed wywołaniem metody.

## **Odbijanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz rotację. Jej wartości `flip_h` i `flip_v` używają [NullableBool](https://reference.aspose.com/slides/pl/python-net/aspose.slides/nullablebool/): `TRUE` włącza odbicie, `FALSE` wyłącza, a `NOT_DEFINED` zachowuje nieokreślony lub domyślny stan.

Prezentacja wejściowa poniżej zawiera jeden nieodbijany kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie pozostałe wartości klatki i zastępuje tylko dwa ustawienia odbicia. Jest to istotne, ponieważ przypisanie nowego [Shape.frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/frame/) zastępuje całą klatkę.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie pozycję, rozmiar i rotację.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `name` lub `alternative_text` dla szablonów tworzonych, lub `office_interop_shape_id` do pracy z interop na poziomie slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być odnaleziony, przemieszczany, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`add_clone` dopisuje klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `insert_clone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.

**Czy mogę używać stałego indeksu do identyfikacji wstępnego dopasowania kształtu?**

Tylko po zweryfikowaniu dokładnego wstępu i układu kolekcji. Preferuj iterację przez `GeometryShape.adjustments` i sprawdzanie `AdjustValue.type`; użyj `AdjustValue.name` jako dodatkowej informacji, gdy ten sam typ semantyczny pojawia się więcej niż raz.