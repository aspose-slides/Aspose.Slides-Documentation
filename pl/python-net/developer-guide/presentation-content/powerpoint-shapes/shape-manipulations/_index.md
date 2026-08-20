---
title: Zarządzanie kształtami prezentacji w Pythonie
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/python-net/shape-manipulations/
keywords:
- Kształt PowerPoint
- Kształt prezentacji
- Kształt na slajdzie
- Znajdź kształt
- Klonuj kształt
- Usuń kształt
- Ukryj kształt
- Zmień kolejność kształtu
- Pobierz ID kształtu interop
- Alternatywny tekst kształtu
- Formaty układu kształtu
- Kształt jako SVG
- Kształt do SVG
- Wyrównaj kształt
- Odwróć kształt
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak identyfikować, klonować, usuwać, ukrywać, zmieniać kolejność, eksportować, wyrównywać i odwracać kształty prezentacji przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

Aspose.Slides for Python via .NET reprezentuje kształty na slajdzie jako uporządkowaną [ShapeCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/). Kolekcja jest jednocześnie miejscem, w którym znajdziesz i zmodyfikujesz kształty, oraz źródłem ich kolejności nakładania: indeks `0` oznacza najoddalniejszy kształt, a ostatni indeks – najbliższy.

Ten artykuł podąża za tym modelem. Najpierw wyjaśnia, jak wiarygodnie zidentyfikować kształt, a potem pokazuje, jak klonować, usuwać, ukrywać i zmieniać kolejność kształtów. Ostatnie sekcje obejmują formatowanie na poziomie układu, eksport do SVG, wyrównywanie oraz ustawienia odbicia. Każdy przykład jest niezależny, więc możesz używać wyłącznie operacji wymaganych w Twoim procesie.

## **Identyfikacja i wyszukiwanie kształtów**

Indeksy w kolekcji są wygodne przy przetwarzaniu znanego pliku, ale nie są stałymi identyfikatorami. Dodanie, usunięcie lub zmiana kolejności kształtu może zmienić jego indeks. Wybierz identyfikator w zależności od tego, jak prezentacja jest tworzona i utrzymywana:

- [Shape.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/name/) jest przydatny w szablonach kontrolowanych przez dewelopera i łatwo go sprawdzić w panelu zaznaczania programu PowerPoint. Nazwy można edytować i nie są gwarantowanie unikalne, dlatego warto ustalić konwencję nazewnictwa, jeśli kod od nich zależy.
- [Shape.alternative_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/alternative_text/) jest użyteczny, gdy opis dostępności lub tag podany przez autora już identyfikuje kształt. Jest widoczny dla użytkowników, może być lokalizowany lub zmieniany w celu zwiększenia dostępności i nie jest gwarantowanie unikalny. Nie wykorzystuj w ciszy znaczącego tekstu dostępności jako klucza bazodanowego.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/office_interop_shape_id/) to identyfikator tylko do odczytu, unikalny w obrębie slajdu i odpowiadający identyfikatorowi kształtu używanemu przez interfejs PowerPoint. Używaj go przy integracji z PowerPointem lub gdy potrzebujesz jednoznacznego odwołania w czasie życia kształtu. Sklonowany lub odtworzony kształt jest innym kształtem i otrzymuje własny identyfikator.

Powiązana własność [Shape.unique_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/unique_id/) ma zakres prezentacji, ale jest przeznaczona dla dodatków i może być ponownie przypisana. Nie powinna być traktowana jako trwały zewnętrzny klucz. Jeśli długoterminowa tożsamość jest istotna, przechowuj mapowanie w danych aplikacji i weryfikuj, że oczekiwany kształt nadal istnieje.

Poniższy przykład wyszukuje po `name` przy użyciu dokładnego porównania i zgłasza interopowy identyfikator scoped do slajdu. Gdy szablon nie zawiera oczekiwanego kształtu, kod zgłasza ten wynik zamiast kontynuować z niewłaściwym obiektem.

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

Gdy operacja jest specyficzna dla typu kształtu, sprawdź typ przed użyciem członków specyficznych dla typu. Ten przykład aktualizuje tekst i tekst alternatywny tylko wtedy, gdy nazwany obiekt jest [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/).

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

## **Modyfikacja kolekcji kształtów**

Metody dodawania, klonowania, usuwania i zmiany kolejności działają na kolekcji natychmiast. Jeśli operacja zmienia liczbę lub kolejność kształtów, nie polegaj dalej na indeksach przechwyconych przed tą operacją.

### **Klonowanie kształtu**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_clone/) tworzy niezależną kopię i dodaje ją na końcu docelowej kolekcji. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/insert_clone/) również tworzy kopię, ale umieszcza ją pod określonym indeksem kolejności Z. Przeciążenia przyjmujące współrzędne przenoszą klon bez zmiany rozmiaru; przeciążenia z szerokością i wysokością mogą również zmieniać rozmiar.

Przykład tworzy slajd docelowy, klonuje oznaczony prostokąt na wierzch i wstawia drugi klon na spód. Zmiany w dowolnym klonie nie modyfikują kształtu źródłowego.

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

Klonowanie kopiuje zawartość i formatowanie kształtu, włączając nazwę oraz tekst alternatywny. Przypisz nowe logiczne identyfikatory klonowi, gdy te wartości muszą być unikalne. Zasoby używane przez złożone kształty są obsługiwane przez prezentację, ale klon pozostaje nowym elementem kolekcji z nową tożsamością kształtu.

### **Usuwanie kształtów**

[ShapeCollection.remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/remove/) usuwa konkretny obiekt kształtu z jego kolekcji. Podczas usuwania wielu dopasowań w iteracji indeksowanej, przeglądaj od końca, aby każdy pozostały indeks pozostał prawidłowy.

Ten przykład usuwa każdy kształt o wyznaczonej nazwie. Odczytuje `slide.shapes[index]`, a nie stały element kolekcji, i nie rzutuje kształtu niepotrzebnie.

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

Po usunięciu liczba kształtów i indeksy kolejnych kształtów ulegają zmianie. Odwołania do nieusuniętych kształtów pozostają bardziej niezawodne niż zapisane indeksy. Pamiętaj także o łącznikach, animacjach i innych elementach prezentacji, które mogą odnosić się do usuniętego obiektu; usunięcie widocznego kształtu może zmienić więcej niż tylko wygląd slajdu.

### **Ukrywanie kształtu**

Ustawienie [Shape.hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/hidden/) na `True` pozostawia kształt w kolekcji, ale zapobiega jego wyświetlaniu w normalnym pokazie slajdów. Jego indeks, formatowanie i zawartość pozostają dostępne dla kodu, więc ukrywanie jest odpowiednie dla opcjonalnych elementów, które mogą zostać przywrócone później.

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

Ukrywanie nie jest usunięciem ani zabezpieczeniem. Obiekt nadal może być odkryty i odukryty przez użytkownika lub kod i pozostaje częścią pliku prezentacji.

### **Zmiana kolejności Z**

Nakładające się kształty są rysowane w kolejności kolekcji. [ShapeCollection.reorder](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/reorder/) przenosi istniejący kształt do docelowego indeksu bez jego klonowania. Indeks `0` to tył; `len(slide.shapes) - 1` to przód.

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

Prostokąt jest tworzony jako pierwszy i początkowo znajduje się pod elipsą. Przeniesienie go na ostatni indeks ustawia go na wierzchu. Ustal kolejność Z po dodaniu lub sklonowaniu wszystkich powiązanych kształtów, ponieważ te operacje dopisują lub wstawiają nowe elementy kolekcji i mogą zmienić zamierzoną warstwę.

## **Inspekcja kształtów w układach slajdów**

Zwykłe slajdy, układy slajdów i slajdy wzorcowe mają oddzielne kolekcje kształtów. Kształt w kolekcji układu nie jest tym samym obiektem co podobnie położony kształt na zwykłym slajdzie. Sprawdzaj kształty układu, gdy potrzebujesz zrozumieć lub zmienić formatowanie dostarczane przez układ.

Poniższy przykład odczytuje [Shape.fill_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/fill_format/) i [Shape.line_format](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/line_format/) każdego kształtu układu bez zakładania, że każdy kształt jest `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Edycja układu może wpłynąć na wiele slajdów, które go używają. Przed zmianą kształtu układu określ, czy zwykły slajd dziedziczy obiekt, czy zawiera lokalne nadpisanie, i przetestuj każdy slajd korzystający z tego układu.

## **Eksportowanie kształtu do SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) zapisuje wyrenderowaną zawartość jednego kształtu do strumienia. Wynik zawiera tylko kształt, a nie całe tło slajdu ani sąsiadujące kształty.

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

Utrzymaj otwartą prezentację podczas renderowania. Wyjście zależy od formatowania kształtu oraz zasobów takich jak czcionki i obrazy. Jeśli potrzebujesz całej kompozycji, wyeksportuj slajd, a nie pojedynczy kształt. Wywołujący jest właścicielem strumienia i musi go zamknąć.

## **Wyrównywanie kształtów**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/align_shapes/) ma przeciążenia, które wyrównują wszystkie kształty lub wybrane indeksy kolekcji. [ShapesAlignmentType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapesalignmenttype/) określa krawędź, linię środkową lub tryb dystrybucji. Ustaw `align_to_slide` na `True`, aby używać krawędzi slajdu; ustaw na `False`, aby wyrównać wybrane kształty względem siebie.

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

Wyrównanie zmienia położenie, nie kolejność Z. Wyrównanie względne zazwyczaj wymaga co najmniej dwóch kształtów, podczas gdy dystrybucja pozioma lub pionowa wymaga wystarczającej liczby kształtów do określenia odstępu. Przelicz indeksy, jeśli modyfikujesz kolekcję przed wywołaniem metody.

## **Odwracanie kształtu**

Klasa [ShapeFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapeframe/) przechowuje pozycję, rozmiar, ustawienia odbicia poziomego i pionowego oraz obrót. Jej wartości `flip_h` i `flip_v` używają [NullableBool](https://reference.aspose.com/slides/pl/python-net/aspose.slides/nullablebool/): `TRUE` włącza odbicie, `FALSE` wyłącza, a `NOT_DEFINED` zachowuje nieokreślony lub domyślny stan.

Poniższa prezentacja wejściowa zawiera jeden nieodwrócony kształt.

![The shape before flipping](shape_to_be_flipped.png)

Przykład zachowuje wszystkie inne wartości ramki i zmienia tylko dwa ustawienia odbicia. To ważne, ponieważ przypisanie nowego [Shape.frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/frame/) zastępuje całą ramkę.

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

Zapisany kształt jest odbity poziomo i pionowo, zachowując jednocześnie pozycję, rozmiar i obrót.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Czy powinienem używać indeksu kolekcji jako identyfikatora kształtu?**

Tylko w krótkotrwałym przetwarzaniu, gdy kolekcja nie zmieni się przed użyciem indeksu. Preferuj zweryfikowaną konwencję `name` lub `alternative_text` dla szablonów tworzonych przez autora, lub `office_interop_shape_id` dla pracy z interopem scoped do slajdu.

**Czy ukrycie kształtu usuwa go z kolejności Z?**

Nie. Ukryty kształt pozostaje w kolekcji pod tym samym indeksem. Może być znaleziony, przestawiony, edytowany lub ponownie widoczny.

**Dlaczego sklonowany kształt pojawił się przed innym kształtem?**

`add_clone` dopisuje klon na koniec kolekcji, co jest przodem kolejności Z. Użyj `insert_clone`, aby wybrać początkowy indeks, lub `reorder` po dodaniu wszystkich kształtów.