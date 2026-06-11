---
title: Zarządzanie tabelami w prezentacjach za pomocą Pythona
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/python-net/manage-table/
keywords:
- dodaj tabelę
- utwórz tabelę
- dostęp do tabeli
- proporcje
- wyrównaj tekst
- formatowanie tekstu
- styl tabeli
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona w środowisku .NET. Odkryj proste przykłady kodu, które usprawnią Twoje przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint to efektywny sposób prezentacji informacji. Informacje ułożone w siatce komórek (wiersze i kolumny) są przejrzyste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/), klasę [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) oraz inne powiązane typy, które pomogą Ci tworzyć, aktualizować i zarządzać tabelami w dowolnej prezentacji.

## **Utworzenie tabel od podstaw**

Ta sekcja pokazuje, jak od podstaw utworzyć tabelę w Aspose.Slides, dodając kształt tabeli do slajdu, definiując jej wiersze i kolumny oraz ustawiając precyzyjne rozmiary. Zobaczysz także, jak wypełniać komórki tekstem, dostosowywać wyrównanie i obramowania oraz dostosowywać wygląd tabeli.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn.
4. Zdefiniuj tablicę wysokości wierszy.
5. Dodaj [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
6. Iteruj po każdej [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) i formatuj jej górną, dolną, prawą i lewą krawędź.
7. Scal pierwsze dwie komórki w pierwszym wierszu tabeli.
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) w [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/).
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/).
10. Zapisz zmodyfikowaną prezentację.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Ustaw format obramowania dla każdej komórki.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Scal komórki od (wiersz 0, kolumna 0) do (wiersz 1, kolumna 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Dodaj tekst do scalonej komórki.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Zapisz prezentację na dysk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeracja w standardowych tabelach**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks (0, 0) (kolumna 0, wiersz 0).

Na przykład w tabeli z 4 kolumnami i 4 wierszami komórki są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Poniższy przykład w języku Python pokazuje, jak odwoływać się do komórek używając tej numeracji zerowej:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Dostęp do istniejącej tabeli**

Ta sekcja wyjaśnia, jak znaleźć i pracować z istniejącą tabelą w prezentacji przy użyciu Aspose.Slides. Dowiesz się, jak znaleźć tabelę na slajdzie, uzyskać dostęp do jej wierszy, kolumn i komórek oraz aktualizować zawartość lub formatowanie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu zawierającego tabelę za pomocą jego indeksu.
3. Iteruj przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) aż znajdziesz tabelę.
4. Użyj obiektu [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) aby pracować z tabelą.
5. Zapisz zmodyfikowaną prezentację.

{{% alert color="info" %}}
Jeśli slajd zawiera kilka tabel, lepiej jest wyszukać potrzebną tabelę za pomocą jej właściwości `alternative_text`.
{{% /alert %}}

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby załadować plik PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    table = None

    # Przejdź przez kształty i odwołaj się do pierwszej znalezionej tabeli.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Ustaw tekst pierwszej komórki w pierwszym wierszu.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Zapisz zmodyfikowaną prezentację na dysk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyrównywanie tekstu w tabelach**

Ta sekcja pokazuje, jak kontrolować wyrównanie tekstu wewnątrz komórek tabeli przy użyciu Aspose.Slides. Nauczysz się ustawiać wyrównanie poziome i pionowe dla komórek, aby treść była przejrzysta i spójna.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) z tabeli.
5. Wyrównaj tekst w pionie.
6. Zapisz zmodyfikowaną prezentację.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Wyśrodkuj tekst i ustaw pionową orientację.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Zapisz prezentację na dysk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

Ta sekcja pokazuje, jak zastosować formatowanie tekstu na poziomie tabeli w Aspose.Slides, aby każda komórka dziedziczyła spójny, jednolity styl. Nauczysz się globalnie ustawiać rozmiary czcionek, wyrównania i marginesy.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
4. Ustaw rozmiar czcionki (wysokość czcionki) dla tekstu.
5. Ustaw wyrównanie akapitu i marginesy.
6. Ustaw pionową orientację tekstu.
7. Zapisz zmodyfikowaną prezentację.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Tworzy instancję klasy Presentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Ustaw rozmiar czcionki dla wszystkich komórek tabeli.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Ustaw tekst wyrównany do prawej i prawy margines dla wszystkich komórek tabeli.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Ustaw pionową orientację tekstu dla wszystkich komórek tabeli.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zastosuj wbudowane style tabel**

Aspose.Slides umożliwia formatowanie tabel przy użyciu predefiniowanych stylów bezpośrednio w kodzie. Przykład demonstruje tworzenie tabeli, zastosowanie wbudowanego stylu i zapis wyniku — efektywny sposób zapewnienia spójnego, profesjonalnego formatowania.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Zablokowanie proporcji tabel**

Proporcje kształtu to stosunek jego wymiarów. Aspose.Slides udostępnia właściwość `aspect_ratio_locked`, która pozwala zablokować proporcje tabel i innych kształtów.

Poniższy przykład w języku Python pokazuje, jak zablokować proporcje dla tabeli:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia właściwość [right_to_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/right_to_left/), a akapity mają [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/right_to_left/). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę zapobiec użytkownikom przemieszczaniu lub zmienianiu rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](/slides/pl/python-net/applying-protection-to-presentation/), aby wyłączyć przemieszczanie, zmianę rozmiaru, zaznaczanie itp. Te blokady mają zastosowanie również do tabel.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).