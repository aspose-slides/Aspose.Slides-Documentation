---
title: "Pobieranie efektywnych właściwości kształtu z prezentacji w Pythonie"
linktitle: "Właściwości efektywne"
type: docs
weight: 50
url: /pl/python-net/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- system oświetlenia
- fazowanie kształtu
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla Pythona poprzez .NET, aby rozróżnić lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint."
---
## **Zrozumienie właściwości lokalnych, dziedziczonych i efektywnych**

Formatowanie PowerPoint może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie to jego **wartość lokalna**. Jeśli ta wartość nie jest ustawiona, PowerPoint patrzy na źródła formatowania nadrzędne, takie jak domyślne ustawienia akapitu, styl tekstu, układ lub slajd wzorcowy, motyw lub domyślne ustawienia prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, to **wartość efektywna**, która jest używana do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna [font_height](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ibaseportionformat/font_height/) wynosi wtedy `float("nan")`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformat/get_effective/) na formacie fragmentu zwraca ostateczną, rozwiązanej wysokość.

Używaj dwóch rodzajów danych formatowania w różnych celach:

- Odczyt lub zmiana lokalnego obiektu formatowania, takiego jak [IPortionFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczyt obiektu danych efektywnych, takiego jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformateffectivedata/), gdy potrzebujesz ostatecznego wyniku renderowania. Dane efektywne są tylko do odczytu.

## **Porównanie wartości lokalnych, dziedziczonych i efektywnych**

Poniższy kompletny przykład tworzy kształt i stosuje wysokości czcionek na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Demonstruje także, dlaczego dane efektywne należy ponownie odczytać po zmianach formatowania.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Odczytaj dane efektywne po poprzednich zmianach.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Wartość lokalna w fragmencie nadpisuje obie dziedziczone wartości.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Zmiana dziedziczonej wartości nie nadpisuje istniejącej wartości lokalnej.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Wyczyść wartość lokalną. Fragment ponownie dziedziczy z akapitu.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Wyczyść wartość akapitu. Domyślna wartość prezentacji dostarcza teraz wynik.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Priorytet w tym przykładzie to najpierw formatowanie lokalne fragmentu, potem formatowanie akapitu, a na końcu domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest taka sama: bardziej specyficzna, explicite ustawiona wartość wygrywa, a [get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformat/get_effective/) zwraca ostateczny wynik.

## **Uzyskiwanie efektywnych właściwości tekstu**

Formatowanie tekstu jest rozdzielone na kilka obiektów:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/itextframeformat/get_effective/) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, kotwiczenie, automatyczne dopasowanie i pionowy kierunek tekstu.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/itextstyle/get_effective/) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iparagraphformat/get_effective/) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i wypunktowanie.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformat/get_effective/) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

W następnym przykładzie `text-formatting.pptx` musi zawierać co najmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnej pozycji w kolekcji kształtów; kod wyszukuje odpowiedni obiekt i weryfikuje go przed użyciem.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Uzyskiwanie efektywnych właściwości 3D**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformat/get_effective/) zwraca jeden obiekt [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/), który grupuje wszystkie rozwiązane ustawienia 3D. Jego właściwości [camera](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/) i [bevel_bottom](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) udostępniają odpowiadające dane efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

W tym przykładzie `shape-3d.pptx` musi zawierać co najmniej jeden kształt na pierwszym slajdzie. Dodaj ustawienia kamery 3D, oświetlenia lub fazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Uzyskiwanie efektywnego formatowania tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów pomiędzy explicite ustawionymi wypełnieniami priorytet jest następujący: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki to ostateczny format używany do jej rysowania.

W tym przykładzie `table-formatting.pptx` musi zawierać co najmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć co najmniej jeden wiersz i jedną kolumnę. Kod wyszukuje obiekt [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) zamiast zakładać, że `shapes[0]` to tabela.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywny [fill_type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ifillformateffectivedata/fill_type/), a następnie odczytaj właściwość odpowiadającą temu typowi, na przykład [solid_fill_color](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) dla jednolitego wypełnienia.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie jej rozwiązania. Wywołaj ponownie `get_effective` po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalnego formatowania obiektu;
- domyślnych ustawień akapitu lub ramki tekstowej;
- stylu tabeli, formatu tabeli, kolumny, wiersza lub komórki;
- formatowania układu lub slajdu wzorcowego;
- danych motywu lub domyślnych ustawień prezentacji;
- układu lub wzorca przypisanego do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może buforować niektóre dane efektywne wewnętrznie, a późniejsze wywołanie `get_effective` może odświeżyć te dane. Jeśli musisz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarnych, takie jak wysokość czcionki, kolor, wyrównanie lub szerokość fazowania, do własnych zmiennych przed wprowadzeniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatowania, a następnie wywołaj `get_effective`, aby zweryfikować wynik. Same obiekty danych efektywnych są tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, nie jej źródło. Przeglądaj odpowiednie lokalne obiekty od najbardziej konkretnego poziomu ku ogólniejszemu. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, wzorzec, motyw i domyślne ustawienia prezentacji. Niezdefiniowane wartości, takie jak `float("nan")` lub `None`, wskazują, że wyszukiwanie kontynuuje się na kolejnym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiedni domyślny parametr PowerPoint lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden lokalny obiekt nie definiuje jej explicite.

**Dlaczego wartość efektywna czasami jest równa wartości lokalnej?**

Wartość lokalna wygrała w obliczeniach dziedziczenia. Jest to oczekiwane, gdy właściwość jest explicite ustawiona na obiekcie i żadne bardziej specyficzne reguły jej nie nadpisują.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby sprawdzić lub edytować konkretny poziom formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po zastosowaniu dziedziczenia, reguł motywu i stosownych stylów. [complete comparison example](#compare-local-inherited-and-effective-values) demonstruje oba podejścia w jednym przepływie pracy.