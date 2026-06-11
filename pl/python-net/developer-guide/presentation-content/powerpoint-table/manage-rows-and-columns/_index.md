---
title: Zarządzaj wierszami i kolumnami w tabelach PowerPoint przy użyciu Pythona
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/python-net/manage-rows-and-columns/
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
description: "Zarządzaj wierszami i kolumnami tabel w PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python w .NET, przyspieszając edycję prezentacji i aktualizacje danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak zarządzać wierszami i kolumnami tabel w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python. Dowiesz się, jak dodawać, wstawiać, klonować i usuwać wiersze lub kolumny, oznaczyć pierwszy wiersz jako nagłówek, dostosować rozmiary i układ oraz zastosować formatowanie tekstu i stylu na poziomie wiersza lub kolumny. Każde zadanie jest przedstawione przy użyciu zwięzłych, samodzielnych fragmentów kodu opartych na interfejsie API [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/), dzięki czemu możesz szybko znaleźć tabelę na slajdzie i przekształcić jej strukturę, aby pasowała do twojego projektu.

## **Ustaw pierwszy wiersz jako nagłówek**

Oznacz pierwszy wiersz tabeli jako nagłówek, aby wyraźnie odróżnić tytuły kolumn od danych. W Aspose.Slides for Python wystarczy włączyć opcję *First Row* tabeli, aby zastosować formatowanie nagłówka określone przez wybrany styl tabeli.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację.
1. Uzyskaj dostęp do slajdu za pomocą jego indeksu.
1. Iteruj przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) w celu znalezienia odpowiedniej tabeli.
1. Ustaw pierwszy wiersz tabeli jako nagłówek.

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Iteruj po kształtach i uzyskaj odwołanie do tabeli.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Ustaw pierwszy wiersz tabeli jako jej nagłówek.
    table.first_row = True
    
    # Zapisz prezentację na dysku.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonuj wiersz lub kolumnę tabeli**

Sklonuj dowolny wiersz lub kolumnę tabeli i wstaw kopię w wybranym miejscu tabeli. Duplikat zachowuje zawartość komórek, formatowanie oraz rozmiary, dzięki czemu możesz szybko i konsekwentnie rozszerzać układy.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację.
1. Uzyskaj dostęp do slajdu za pomocą jego indeksu.
1. Zdefiniuj tablicę szerokości kolumn.
1. Zdefiniuj tablicę wysokości wierszy.
1. Dodaj [Table] do slajdu używając `add_table(x, y, column_widths, row_heights)`.
1. Sklonuj wiersz tabeli.
1. Sklonuj kolumnę tabeli.
1. Zapisz zmodyfikowaną prezentację.

```python
 import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Dodaj tabelę do slajdu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Dodaj tekst do wiersza 1, kolumny 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Dodaj tekst do wiersza 2, kolumny 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Sklonuj wiersz 1 na końcu tabeli.
    table.rows.add_clone(table.rows[0], False)

    # Dodaj tekst do wiersza 1, kolumny 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Dodaj tekst do wiersza 2, kolumny 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Sklonuj wiersz 2 jako 4‑ty wiersz tabeli.
    table.rows.insert_clone(3,table.rows[1], False)

    # Sklonuj pierwszą kolumnę na końcu.
    table.columns.add_clone(table.columns[0], False)

    # Sklonuj drugą kolumnę pod indeksem 3 (czwarte pozycję).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Zapisz prezentację na dysku.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń wiersz lub kolumnę z tabeli**

Uprość tabelę, usuwając dowolny wiersz lub kolumnę według indeksu przy użyciu Aspose.Slides for Python — układ automatycznie się dostosowuje, zachowując formatowanie pozostałych komórek. Jest to przydatne przy upraszczaniu siatek danych lub usuwaniu symboli zastępczych bez konieczności przebudowy tabeli.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację.
1. Uzyskaj dostęp do slajdu za pomocą jego indeksu.
1. Zdefiniuj tablicę szerokości kolumn.
1. Zdefiniuj tablicę wysokości wierszy.
1. Dodaj ITable do slajdu używając `add_table(x, y, column_widths, row_heights)`.
1. Usuń wiersz tabeli.
1. Usuń kolumnę tabeli.
1. Zapisz zmodyfikowaną prezentację.

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

## **Ustaw formatowanie tekstu na poziomie wiersza tabeli**

Zastosuj spójny styl tekstu do całego wiersza tabeli w jednym kroku. Dzięki Aspose.Slides for Python możesz jednocześnie ustawić rodzinę czcionki, rozmiar, wagę, kolor i wyrównanie dla wszystkich komórek w wierszu, aby nagłówki lub paski danych były jednolite.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację.
1. Uzyskaj dostęp do slajdu za pomocą jego indeksu.
1. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) na slajdzie.
1. Ustaw wysokość czcionki dla komórek pierwszego wiersza.
1. Ustaw wyrównanie i prawy margines dla komórek pierwszego wiersza.
1. Ustaw pionowy typ tekstu dla komórek drugiego wiersza.
1. Zapisz zmodyfikowaną prezentację.

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ustaw wysokość czcionki dla komórek pierwszego wiersza.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Ustaw wyrównanie tekstu i prawy margines komórek pierwszego wiersza.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Ustaw pionowy typ tekstu komórek drugiego wiersza.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Zapisz prezentację na dysku.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw formatowanie tekstu na poziomie kolumny tabeli**

Zastosuj spójny styl tekstu do całej kolumny tabeli w jednym kroku. Dzięki Aspose.Slides for Python możesz jednocześnie ustawić rodzinę czcionki, rozmiar, wagę, kolor i wyrównanie dla wszystkich komórek w kolumnie, tworząc jednolite pionowe sekcje nagłówków lub danych.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i wczytaj prezentację.
1. Uzyskaj dostęp do slajdu za pomocą jego indeksu.
1. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) na slajdzie.
1. Ustaw wysokość czcionki dla komórek pierwszej kolumny.
1. Ustaw wyrównanie i prawy margines dla komórek pierwszej kolumny.
1. Ustaw pionowy typ tekstu dla komórek drugiej kolumny.
1. Zapisz zmodyfikowaną prezentację.

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Ustaw wysokość czcionki komórek pierwszej kolumny.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Ustaw wyrównanie tekstu i prawy margines komórek pierwszej kolumny.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Ustaw pionowy typ tekstu komórek drugiej kolumny.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Zapisz prezentację na dysku.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobierz właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było je ponownie wykorzystać w innej tabeli lub w innym miejscu. Poniższy kod Pythona pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę zastosować motywy/ style PowerPoint do już istniejącej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mastera, a nadal możesz nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli jak w Excelu?**

Nie, tabele w Aspose.Slides nie posiadają wbudowanego sortowania ani filtrów. Posortuj najpierw dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć zebrane (pasy) kolumny, zachowując jednocześnie niestandardowe kolory w określonych komórkach?**

Tak. Włącz kolumny w paski, a następnie nadpisz konkretne komórki formatowaniem lokalnym; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.