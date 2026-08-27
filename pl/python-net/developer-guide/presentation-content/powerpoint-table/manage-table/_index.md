---
title: Zarządzaj tabelami prezentacji w Pythonie
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
description: "Twórz i edytuj tabele w slajdach PowerPoint oraz OpenDocument przy użyciu Aspose.Slides dla Pythona w technologii .NET. Odkryj proste przykłady kodu, które usprawnią Twoje procesy pracy z tabelami."
---
## **Wstęp**

Tabela w programie PowerPoint jest wydajnym sposobem prezentacji informacji. Informacje ułożone w siatce komórek (wiersze i kolumny) są przejrzyste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/), klasę [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) oraz inne powiązane typy, które pomagają tworzyć, aktualizować i zarządzać tabelami w dowolnej prezentacji.

## **Tworzenie tabel od podstaw**

W tej sekcji przedstawiono, jak utworzyć tabelę od podstaw w Aspose.Slides, dodając kształt tabeli do slajdu, definiując jej wiersze i kolumny oraz ustalając dokładne rozmiary. Zobaczysz także, jak wypełniać komórki tekstem, dostosowywać wyrównanie i obramowania oraz personalizować wygląd tabeli.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według jego indeksu.
3. Zdefiniuj tablicę szerokości kolumn.
4. Zdefiniuj tablicę wysokości wierszy.
5. Dodaj [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
6. Przejdź po każdej [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) i sformatuj jej górne, dolne, prawe i lewe obramowanie.
7. Połącz komórki pierwszych dwóch wierszy i pierwszych dwóch kolumn w jedną komórkę.
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) komórki [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/).
9. Dodaj tekst do [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/).
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak utworzyć tabelę w prezentacji:

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
        
    # Połącz komórki od (wiersz 0, kolumna 0) do (wiersz 1, kolumna 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Dodaj tekst do połączonej komórki.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Zapisz prezentację na dysk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeracja w standardowych tabelach**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks (0, 0) (kolumna 0, wiersz 0).

Na przykład w tabeli mającej 4 kolumny i 4 wiersze komórki są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Poniższy przykład w języku Python pokazuje, jak odwoływać się do komórek przy użyciu tej numeracji zaczynającej się od zera:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Dodaj tabelę z 4 kolumnami i 4 wierszami.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskiwanie dostępu do istniejącej tabeli**

W tej sekcji wyjaśniono, jak zlokalizować i pracować z istniejącą tabelą w prezentacji przy użyciu Aspose.Slides. Dowiesz się, jak znaleźć tabelę na slajdzie, uzyskać dostęp do jej wierszy, kolumn i komórek oraz zaktualizować zawartość lub formatowanie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu zawierającego tabelę według jego indeksu.
3. Przeglądaj wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/) aż znajdziesz tabelę.
4. Użyj obiektu [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/), aby pracować z tabelą.
5. Zapisz zmodyfikowaną prezentację.

{{% alert color="info" title="Note" %}}

Jeśli slajd zawiera wiele tabel, lepiej wyszukać potrzebną tabelę po właściwości `alternative_text`.

{{% /alert %}}

Poniższy przykład w języku Python pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby wczytać plik PPTX.
with slides.Presentation("sample.pptx") as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    table = None

    # Iteruj po kształtach i odwołaj się do pierwszej znalezionej tabeli.
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

## **Znajdź komórkę, do której należy ramka tekstowa**

Gdy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/) z tabeli, użyj właściwości [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/), aby pobrać należącą do niej [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/). Dla ramki tekstowej w komórce tabeli właściwość [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/) jest ustawiona, a [TextFrame.parent_shape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_shape/) ma wartość `None`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez tylko do odczytu właściwości [Cell.first_column_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/first_column_index/) i [Cell.first_row_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/first_row_index/). Właściwość [TextFrame.parent_cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/parent_cell/) jest również tylko do odczytu: umożliwia nawigację do właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `None`, zanim jej użyjesz.

Kompletny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajduje się w sekcji [Search and Replace Text](/slides/pl/python-net/search-and-replace-text/).

## **Wyrównywanie tekstu w tabelach**

W tej sekcji przedstawiono, jak kontrolować położenie tekstu wewnątrz komórek tabeli przy użyciu Aspose.Slides. Nauczysz się kotwiczyć tekst pionowo w komórce oraz zmieniać kierunek, w jakim tekst jest wyświetlany.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według jego indeksu.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/) w tabeli.
5. Wyśrodkuj tekst pionowo w komórce i ustaw kierunek tekstu.
6. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak wyrównać tekst w tabeli:

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

W tej sekcji wyjaśniono, jak zastosować formatowanie tekstu na poziomie tabeli w Aspose.Slides, aby każda komórka dziedziczyła spójny, jednolity styl. Nauczysz się globalnie ustawiać rozmiary czcionek, wyrównania i marginesy.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu według jego indeksu.
3. Dodaj [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/) do slajdu.
4. Ustaw rozmiar czcionki (wysokość czcionki) dla tekstu.
5. Ustaw wyrównanie akapitu i marginesy.
6. Ustaw pionową orientację tekstu.
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład w języku Python pokazuje, jak zastosować preferowane opcje formatowania do tekstu w tabeli:

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

Aspose.Slides umożliwia formatowanie tabel przy użyciu wbudowanych stylów bezpośrednio w kodzie. Przykład demonstruje tworzenie tabeli, zastosowanie wbudowanego stylu i zapis wyniku — efektywny sposób zapewnienia jednolitego, profesjonalnego formatowania.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Zablokuj proporcje tabel**

Proporcje kształtu to stosunek jego wymiarów. Aspose.Slides udostępnia właściwość `aspect_ratio_locked`, która pozwala zablokować proporcje tabel i innych kształtów.

Poniższy przykład w języku Python pokazuje, jak zablokować proporcje tabeli:

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

**Czy mogę włączyć kierunek od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia właściwość [right_to_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/right_to_left/), a akapity mają [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/pl/python-net/aspose.slides/paragraphformat/right_to_left/). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](/slides/pl/python-net/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady dotyczą również tabel.

**Czy wstawianie obrazu jako tła w komórce jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub powielanie).