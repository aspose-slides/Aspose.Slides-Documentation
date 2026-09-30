---
title: "Zarządzaj wierszami i kolumnami w tabelach PowerPoint przy użyciu Pythona"
linktitle: "Wiersze i kolumny"
type: docs
weight: 20
url: /pl/python-java/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonuj wiersz
- klonuj kolumnę
- kopiuj wiersz
- kopiuj kolumnę
- usuń wiersz
- usuń kolumnę
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java i przyspiesz edycję prezentacji oraz aktualizacje danych."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java umożliwia zarządzanie strukturą tabel i formatowaniem w prezentacjach PowerPoint przy użyciu klasy [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje przy użyciu przykładów w Pythonie. Pokazuje również, jak pobrać ustawienie stylu tabeli, aby można je ponownie wykorzystać. Indeksy wierszy i kolumn tabeli są zerowe.

## **Sterowanie wysokością wiersza**

Użyj [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight), aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) zwraca rzeczywistą wysokość. Uzyskaj dostęp do wiersza poprzez [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Przykład ładuje [row-height-input.pptx](row-height-input.pptx), który zawiera tabelę jako pierwszy kształt na pierwszym slajdzie. Jej pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18‑punktowego, z zawijaniem i marginesami górnym oraz dolnym po 6 punktów; dłuższy tekst w drugiej kolumnie zawija się na kilka linii. Przykład zwiększa minimalną wysokość do 100 punktów, następnie zmniejsza ją do 20 punktów, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W dostarczonej prezentacji zwiększenie wartości minimalnej dodaje przestrzeń do wiersza. Zmniejszenie jej usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek wymagają więcej miejsca. Samo zmniejszenie wartości minimalnej nie może wymusić, aby wiersz był niższy niż przestrzeń wymagana przez jego zawartość.

Na rzeczywistą wysokość wpływa kilka czynników:
- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone łamanie wierszy lub większa czcionka mogą wymagać więcej pionowej przestrzeni.
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu zmniejszenie szerokości kolumny za pomocą [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) może spowodować więcej linii. Szersza kolumna może zmniejszyć wymaganą pionowo przestrzeń.
- **Marginesy komórek:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) i [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) dodają przestrzeń pionową. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) i [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) zmniejszają dostępny dla tekstu szerokość i mogą powodować dodatkowe zawijanie.

W tej tabeli bez scalonych komórek komórka wymagająca najwięcej pionowej przestrzeni określa ograniczenie dolne całego wiersza wynikające z zawartości. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów, albo poszerzenie kolumny.

Poniższe obrazy pokazują tę samą tabelę w tej samej skali. W przedstawionych wynikach rzeczywiste wysokości wynosiły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimalna wartość 20 punktów. Dokładne pomiary tekstu mogą się różnić w zależności od czcionek dostępnych w Twoim środowisku. Pobierz zapisane wyniki: [zwiększone minimum](row-height-increased.pptx) i [zmniejszone minimum](row-height-decreased.pptx).

| Oryginalny: minimum 70 pt, rzeczywisty 70 pt | Zwiększony: minimum 100 pt, rzeczywisty 100 pt | Zmniejszony: minimum 20 pt, rzeczywisty 55.2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawinięty tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustawienie pierwszego wiersza jako nagłówka**

Użyj metody [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow), aby oznaczyć pierwszy wiersz do formatowania jako nagłówek. Jego wygląd zależy od stylu tabeli zastosowanego do tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli przechowywanej jako pierwszy kształt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje plik `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie użyć ich zawartości i formatowania. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Skopiuj (klonuj) wymagane wiersze.
6. Skopiuj (klonuj) wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, z wymiarami podanymi w punktach. Dodaje kopie pierwszego wiersza i kolumny, a następnie wstawia kopie drugiego wiersza i kolumny pod indeksem 3 (czwarte miejsce). Powstała tabela ma siedem wierszy i pięć kolumn. Argument `False` wyłącza klonowanie do sąsiadujących scalonych wierszy lub kolumn; ta tabela nie ma scalonych komórek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuń wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy wierszy lub kolumn, które po nim następują.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 3x3 i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę 2x2 w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `False` wyłącza usuwanie sąsiadujących scalonych wierszy lub kolumn; ta tabela nie posiada scalonych komórek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawienie formatowania tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) dla pierwszego wiersza.
4. Użyj [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) i [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) dla pierwszego wiersza.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwoma wierszami. Zastosowuje tekst 25‑punktowy, wyrównanie do prawej oraz prawy margines akapitu o 20 punktów w pierwszym wierszu, a następnie ustawia pionowy tekst w drugim wierszu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawienie formatowania tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Użyj [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) dla pierwszej kolumny.
4. Użyj [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) i [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) dla pierwszej kolumny.
5. Użyj [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwiema kolumnami. Zastosowuje tekst 25‑punktowy, wyrównanie do prawej oraz prawy margines akapitu o 20 punktów w pierwszej kolumnie, a następnie ustawia pionowy tekst w drugiej kolumnie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pobieranie właściwości stylu tabeli**

Użyj metody [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), aby pobrać preset zastosowany do tabeli i ponownie użyć go w innej tabeli. Identyfikuje to preset, a nie nadpisania formatowania poszczególnych komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) i odczytuje preset. Wypisuje wartość całkowitą odpowiadającą `DarkStyle1` i zapisuje tabelę w pliku `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zastosować motywy/stylizacje PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/głównego szablonu i nadal możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a następnie wypełnij ponownie wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (paskowe) kolumny, zachowując niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowane kolumny, a następnie nadpisz konkretne komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.