---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w Pythonie za pomocą Java
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/python-java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- system oświetlenia
- kształt fazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: Dowiedz się, jak używać Aspose.Slides dla Pythona za pomocą Java, aby rozróżniać lokalne, dziedziczone i efektywne formatowanie kształtów w prezentacjach PowerPoint.
---
## **Zrozumienie właściwości lokalnych, dziedziczonych i efektywnych**

PowerPoint formatowanie może pochodzić z kilku miejsc. Wartość przechowywana bezpośrednio na obiekcie to jego **wartość lokalna**. Jeśli ta wartość nie jest ustawiona, PowerPoint patrzy na źródła formatowania nadrzędnego, takie jak domyślne ustawienia akapitu, styl tekstu, układ lub slajd wzorcowy, motyw lub domyślne ustawienia prezentacji. Te wartości są **wartościami dziedziczonymi**. Wartość, która pozostaje po rozwiązaniu całej hierarchii, to **wartość efektywna** — wartość używana do renderowania obiektu.

Na przykład fragment tekstu może nie definiować własnej wysokości czcionki. Jego lokalna wartość [getFontHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#getFontHeight) to wtedy `float("nan")`, co oznacza „nie ustawiono tutaj”. Fragment może dziedziczyć wysokość z akapitu, domyślnego stylu tekstu prezentacji lub innego odpowiedniego źródła. Wywołanie [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective) na formacie fragmentu zwraca ostateczną rozwiązaną wysokość.

Używaj dwóch rodzajów danych formatowania w zależności od celu:

- Odczytaj lub zmień lokalny obiekt formatu, taki jak [PortionFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/), gdy potrzebujesz kontrolować, gdzie wartość jest zdefiniowana.
- Odczytaj obiekt danych efektywnych, taki jak `PortionFormatEffectiveData`, gdy potrzebujesz ostatecznego, renderowanego wyniku. Dane efektywne są tylko do odczytu.

## **Porównanie wartości lokalnych, dziedziczonych i efektywnych**

Poniższy pełny przykład tworzy kształt i stosuje wysokości czcionek na poziomach prezentacji, akapitu i fragmentu. Każdy krok wypisuje wartości zdefiniowane na tych poziomach oraz wynikającą wartość efektywną dla tego samego fragmentu tekstu. Pokazuje także, dlaczego dane efektywne należy ponownie odczytać po zmianach formatowania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Odczytaj dane efektywne po poprzednich zmianach.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Zdefiniuj dziedziczone wartości na dwóch różnych poziomach.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Lokalna wartość w fragmencie nadpisuje obie dziedziczone wartości.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Zmiana dziedziczonej wartości nie nadpisuje istniejącej lokalnej wartości.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Wyczyść lokalną wartość. Fragment ponownie dziedziczy z akapitu.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Wyczyść wartość akapitu. Domyślna wartość prezentacji dostarcza teraz wynik.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Priorytet w tym przykładzie to najpierw formatowanie lokalne fragmentu, potem formatowanie akapitu, potem domyślne ustawienia prezentacji. Inne obiekty mogą mieć różne łańcuchy dziedziczenia, ale zasada jest taka sama: bardziej specyficzna wartość explicite wygrywa, a [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective) zwraca ostateczny wynik.

## **Uzyskiwanie efektywnych właściwości tekstu**

Formatowanie tekstu jest podzielone na kilka obiektów:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#getEffective) rozwiązuje właściwości ramki tekstowej, takie jak marginesy, umiejscowienie, automatyczne dopasowanie i pionowy kierunek tekstu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textstyle/#getEffective) rozwiązuje formatowanie akapitu dla każdego poziomu stylu tekstu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#getEffective) rozwiązuje właściwości akapitu, takie jak wyrównanie, wcięcie i wypunktowanie.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective) rozwiązuje właściwości znaków, takie jak wysokość czcionki, krój, kolor, pogrubienie i kursywa.

Do kolejnego przykładu, `text-formatting.pptx` musi zawierać przynajmniej jeden slajd i jedną [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) z niepustą ramką tekstową. AutoShape może znajdować się w dowolnej pozycji w kolekcji kształtów; kod wyszukuje odpowiedni obiekt i waliduje go przed użyciem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Uzyskiwanie efektywnych właściwości 3D**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/threedformat/#getEffective) zwraca jeden obiekt `ThreeDFormatEffectiveData`, który grupuje wszystkie rozwiązane ustawienia 3D. Jego metody `getCamera`, `getLightRig`, `getBevelTop` i `getBevelBottom` udostępniają odpowiadające dane efektywne. Czytanie tych powiązanych ustawień razem ułatwia zrozumienie ostatecznego wyglądu 3D kształtu.

Do tego przykładu, `shape-3d.pptx` musi zawierać przynajmniej jeden kształt na pierwszym slajdzie. Zastosuj ustawienia kamery 3D, oświetlenia lub fazowania do tego kształtu, jeśli chcesz, aby wynik zawierał wartości inne niż domyślne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Uzyskiwanie efektywnego formatowania tabeli**

Formatowanie tabeli może pochodzić ze stylu tabeli oraz z formatów zastosowanych do całej tabeli, kolumny, wiersza lub pojedynczej komórki. W przypadku konfliktów między explicite zdefiniowanymi wypełnieniami priorytet jest: komórka, wiersz, kolumna, a następnie cała tabela. Efektywny format komórki to ostateczny format używany do narysowania tej komórki.

Do tego przykładu, `table-formatting.pptx` musi zawierać przynajmniej jedną tabelę na pierwszym slajdzie. Tabela musi mieć przynajmniej jeden wiersz i jedną kolumnę. Kod wyszukuje [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) zamiast zakładać, że `getShapes().get_Item(0)` jest tabelą.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Jeśli potrzebujesz koloru, a nie tylko typu wypełnienia, najpierw sprawdź efektywną metodę `getFillType`, a następnie odczytaj metodę odpowiednią dla tego typu — na przykład `getSolidFillColor` dla wypełnienia jednolitego.

## **Ponowne odczytanie danych efektywnych po zmianach**

Dane efektywne opisują hierarchię formatowania w momencie ich rozwiązania. Wywołaj ponownie [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective) po zmianie czegokolwiek, co może uczestniczyć w tej hierarchii, w tym:

- lokalne formatowanie obiektu;
- domyślne formatowanie akapitu lub ramki tekstowej;
- styl tabeli, tabela, kolumna, wiersz lub format komórki;
- formatowanie układu lub slajdu wzorcowego;
- dane motywu lub domyślne ustawienia na poziomie prezentacji;
- układ lub wzorzec przypisany do slajdu.

Nie przechowuj obiektu danych efektywnych jako trwałego migawki. Aspose.Slides może wewnętrznie buforować niektóre dane efektywne, a późniejsze wywołanie [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective) może odświeżyć te dane. Jeśli potrzebujesz porównać wartości przed i po zmianie, skopiuj potrzebne wartości skalarne — takie jak wysokość czcionki, kolor, wyrównanie lub szerokość fazowania — do własnych zmiennych przed dokonaniem zmiany.

Aby zmienić wartość, zaktualizuj odpowiedni lokalny obiekt formatu, a następnie wywołaj [getEffective](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portionformat/#getEffective), aby zweryfikować wynik. Obiekty danych efektywnych są same w sobie tylko do odczytu.

## **FAQ**

**Jak mogę określić, który poziom dostarczył wartość efektywną?**

Dane efektywne zawierają ostateczną wartość, a nie jej źródło. Należy sprawdzić odpowiednie lokalne obiekty, zaczynając od najbardziej szczegółowego poziomu i przechodząc na zewnątrz. Dla tekstu może to obejmować fragment, akapit, ramkę tekstową, układ, wzorzec, motyw oraz domyślne ustawienia prezentacji. Nieokreślone wartości, takie jak `float("nan")` lub `None`, wskazują, że wyszukiwanie kontynuuje się na innym poziomie.

**Co się dzieje, gdy żaden poziom nie definiuje właściwości?**

Aspose.Slides rozwiązuje odpowiedni domyślny PowerPoint lub biblioteki. Ta rozwiązana wartość pojawia się w danych efektywnych, mimo że żaden lokalny obiekt nie definiuje jej explicite.

**Dlaczego czasami wartość efektywna jest równa wartości lokalnej?**

Wartość lokalna wygrała w obliczeniach dziedziczenia. Jest to oczekiwane, gdy właściwość jest explicite ustawiona na obiekcie i żadna bardziej szczegółowa reguła jej nie nadpisuje.

**Kiedy powinienem używać danych lokalnych zamiast danych efektywnych?**

Używaj danych lokalnych, aby sprawdzić lub edytować określony poziom formatowania. Używaj danych efektywnych, gdy potrzebny jest ostateczny wygląd po zastosowaniu dziedziczenia, reguł motywu i odpowiednich stylów. [Pełny przykład porównania](#compare-local-inherited-and-effective-values) pokazuje oba podejścia w tym samym przepływie pracy.