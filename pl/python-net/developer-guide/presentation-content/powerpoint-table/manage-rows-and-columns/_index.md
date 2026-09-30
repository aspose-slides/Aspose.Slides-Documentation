---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu Pythona
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/python-net/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- klonowanie wiersza
- klonowanie kolumny
- kopiowanie wiersza
- kopiowanie kolumny
- usuwanie wiersza
- usuwanie kolumny
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint przy użyciu Aspose.Slides for Python via .NET i przyspiesz edycję prezentacji oraz aktualizacje danych."
---
## **Wprowadzenie**

Aspose.Slides for Python via .NET umożliwia zarządzanie strukturą tabel i ich formatowaniem w prezentacjach PowerPoint przy użyciu klasy [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) . Możesz wyznaczyć wiersz nagłówka, klonować lub usuwać wiersze i kolumny oraz zastosować formatowanie tekstu do całego wiersza lub kolumny.

Ten artykuł wyjaśnia te operacje przy użyciu przykładów w Pythonie. Pokazuje także, jak pobrać ustawiony styl tabeli, aby można go było ponownie użyć. Indeksy wierszy i kolumn w tabeli zaczynają się od zera.

## **Kontrola wysokości wiersza**

Użyj [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) aby ustawić minimalną wysokość wiersza w punktach. Jest to dolna granica, a nie stała wysokość. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) zwraca rzeczywistą wysokość i jest tylko do odczytu. Dostęp do wiersza uzyskuje się przez [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

Przykład ładuje [row-height-input.pptx](row-height-input.pptx), który zawiera tabelę jako pierwszy kształt na pierwszym slajdzie. Jego pierwszy wiersz zaczyna się od 70 punktów. Komórki używają tekstu Arial 18‑punktowego, z zawijaniem i 6‑punktowymi marginesami górnym i dolnym; dłuższy tekst w drugiej kolumnie zawija się na kilka linii. Przykład zwiększa minimalną wysokość do 100 punktów, a następnie zmniejsza ją do 20 punktów, wypisuje rzeczywistą wysokość po każdej zmianie i zapisuje oba wyniki.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

W dostarczonej prezentacji zwiększenie wartości minimalnej dodaje przestrzeń do wiersza. Zmniejszenie jej usuwa tę dodatkową przestrzeń, ale rzeczywista wysokość pozostaje większa niż 20 punktów, ponieważ tekst i marginesy komórek potrzebują więcej miejsca. Samo obniżenie wartości minimalnej nie może wymusić, aby wiersz był niższy niż wymagane przez jego zawartość miejsce.

Kilka czynników wpływa na rzeczywistą wysokość:

- **Tekst i rozmiar czcionki:** dłuższy tekst, wymuszone podziały wierszy lub większa czcionka mogą wymagać więcej miejsca w pionie.
- **Zawijanie i szerokość kolumny:** przy włączonym zawijaniu, węższa [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) może tworzyć więcej linii. Szersza kolumna może zmniejszyć wymaganą pionowo przestrzeń.
- **Marginesy komórek:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) i [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) dodają przestrzeń w pionie. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) i [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) zmniejszają dostępny dla tekstu szerokość i mogą powodować dodatkowe zawijanie.

Dla tej tabeli bez scalonych komórek, komórka wymagająca najwięcej miejsca w pionie określa granicę dolną całego wiersza narzuconą przez zawartość. Aby skrócić wiersz, może być konieczne skrócenie tekstu, zmniejszenie rozmiaru czcionki lub marginesów albo poszerzenie kolumny.

Obrazy poniżej pokazują tę samą tabelę w tym samym skalowaniu. W tym uruchomieniu rzeczywiste wysokości wynosiły 70, 100 i 55,2 punktu: ostatni wiersz pozostał wyższy niż jego minimalna wartość 20 punktów. Dokładne pomiary tekstu mogą się różnić w zależności od czcionek dostępnych w Twoim środowisku. Pobierz zapisane wyniki: [increased minimum](row-height-increased.pptx) i [decreased minimum](row-height-decreased.pptx).

| Oryginalny: minimum 70 pt, rzeczywisty 70 pt | Zwiększony: minimum 100 pt, rzeczywisty 100 pt | Zmniejszony: minimum 20 pt, rzeczywisty 55.2 pt |
| --- | --- | --- |
| ![Oryginalna tabela z pierwszym wierszem o wysokości 70 punktów.](row-height-before.png) | ![Tabela po zwiększeniu minimalnej wysokości pierwszego wiersza do 100 punktów.](row-height-increased.png) | ![Tabela po zmniejszeniu minimalnej wysokości pierwszego wiersza do 20 punktów; zawijany tekst utrzymuje wiersz wyższym niż minimum.](row-height-decreased.png) |

## **Ustaw pierwszy wiersz jako nagłówek**

Użyj właściwości [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) aby oznaczyć pierwszy wiersz jako nagłówek. Jego wygląd zależy od zastosowanego stylu tabeli.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Uzyskaj dostęp do tabeli przechowywanej jako pierwszy kształt na slajdzie.
4. Włącz formatowanie nagłówka dla jej pierwszego wiersza.
5. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie. Włącza formatowanie nagłówka dla pierwszego wiersza i zapisuje plik `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie wiersza lub kolumny tabeli**

Klonuj wiersze lub kolumny, aby ponownie wykorzystać ich zawartość i formatowanie. Możesz dodać kopię na koniec tabeli lub wstawić ją w określone miejsce.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Sklonuj wymagane wiersze.
6. Sklonuj wymagane kolumny.
7. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `Test.pptx` z co najmniej jednym slajdem. Tworzy tabelę z trzema kolumnami i pięcioma wierszami, o wymiarach podanych w punktach. Dodaje kopie pierwszego wiersza i pierwszej kolumny, a następnie wstawia kopie drugiego wiersza i drugiej kolumny pod indeksem 3 (czwarte miejsce). Powstała tabela ma siedem wierszy i pięć kolumn. Argument `False` wyłącza klonowanie do sąsiednich scalonych wierszy lub kolumn; ta tabela nie ma scalonych komórek.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie wiersza lub kolumny z tabeli**

Usuwaj wiersze lub kolumny, które nie są już potrzebne w tabeli. Usunięcie elementu przesuwa indeksy kolejnych wierszy lub kolumn.

1. Utwórz prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Zdefiniuj szerokości kolumn i wysokości wierszy.
4. Dodaj tabelę przy użyciu metody [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Usuń drugi wiersz i drugą kolumnę.
6. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 3 × 3 i usuwa wiersz oraz kolumnę o indeksie 1, pozostawiając tabelę 2 × 2 w pliku `TestTable_out.pptx`. Wymiary podane są w punktach. Argument `False` wyłącza usuwanie sąsiednich scalonych wierszy lub kolumn; ta tabela nie ma scalonych komórek.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.shapes.add_table(100, 100, column_widths, row_heights)

    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie formatowania tekstu na poziomie wiersza tabeli**

Zastosuj formatowanie tekstu do całego wiersza, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) dla pierwszego wiersza.
4. Ustaw [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) i [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) dla pierwszego wiersza.
5. Ustaw [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) dla drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwoma wierszami. Stosuje tekst 25‑punktowy, wyrównanie do prawej oraz 20‑punktowy prawy margines akapitu w pierwszym wierszu, a następnie ustawia pionowy tekst w drugim wierszu.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustawianie formatowania tekstu na poziomie kolumny tabeli**

Zastosuj formatowanie tekstu do całej kolumny, aby utrzymać spójność komórek. Możesz ustawić właściwości czcionki, formatowanie akapitu i kierunek tekstu bez formatowania każdej komórki osobno.

1. Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Uzyskaj dostęp do tabeli na pierwszym slajdzie.
3. Ustaw [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) dla pierwszej kolumny.
4. Ustaw [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) i [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) dla pierwszej kolumny.
5. Ustaw [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) dla drugiej kolumny.
6. Zapisz zmodyfikowaną prezentację.

Przykład wymaga pliku `table.pptx` z tabelą jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej dwiema kolumnami. Stosuje tekst 25‑punktowy, wyrównanie do prawej oraz 20‑punktowy prawy margines akapitu w pierwszej kolumnie, a następnie ustawia pionowy tekst w drugiej kolumnie.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobieranie właściwości stylu tabeli**

Użyj właściwości [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) aby pobrać preset zastosowany do tabeli i ponownie użyć go w innej tabeli. Dzięki temu identyfikujesz preset, a nie poszczególne nadpisania formatowania komórek.

Przykład tworzy tabelę, stosuje [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), a następnie odczytuje preset. Wypisuje `True`, gdy pobrany preset odpowiada zastosowanemu, i zapisuje tabelę w pliku `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zastosować motywy/styl PowerPoint do już utworzonej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/macierzy, a jednocześnie możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli tak, jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci najpierw, a potem ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paskowane (wzorzec) kolumny, zachowując jednocześnie niestandardowe kolory w określonych komórkach?**

Tak. Włącz paskowanie kolumn, a następnie nadpisz wybrane komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.