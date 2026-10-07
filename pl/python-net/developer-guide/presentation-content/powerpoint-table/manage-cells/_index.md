---
title: Zarządzanie komórkami tabel w prezentacjach w Pythonie
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/python-net/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- dzielenie komórki
- obraz w komórce
- kolor tła
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj komórkami tabel PowerPoint w Pythonie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla Pythona na platformie .NET."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórki poprzez jej właściwości oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych. Współrzędne w tym artykule podawane są w formacie `(kolumna, wiersz)`.

## **Identyfikowanie scalonej komórki tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje pierwszą figurę na pierwszym slajdzie jako tabelę. Zakłada, że slajd i figura istnieją oraz że figura jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `wiersz;kolumna`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) oraz współrzędne początkowe regionu, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) i [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Usuwanie obramowań komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Szerokości kolumn, wysokości wierszy i pozycja tabeli podawane są w punktach. Przykład ustawia wszystkie cztery obramowania komórki na [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), czyniąc je niewidocznymi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Scalanie komórek tabeli**

Użyj [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) do połączenia prostokątnego zakresu komórek w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument określa, czy scalanie może obejmować komórki poza podanym zakresem; `False` utrzymuje scalanie w obrębie tego zakresu.

Przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy siatka tabeli nadal ma cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.rows[1][1]` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie ulegają zmianie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Dzielanie komórek tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Dzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides podąża za modelem siatki tabeli PowerPointa.

Ten przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) na komórce `(1, 1)`. Połowa szerokości 70‑punktowej komórki jest przekazywana, aby utworzyć dwie komórki o równych szerokościach.

Po tym podziale dwie połówki są dostępne jako `table.rows[1][1]` i `table.rows[1][2]`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą do kolumn 3 i 4, odpowiednio. Indeksy wierszy pozostają niezmienione. Użyj zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Dzielanie scalonych komórek według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) do podziału wzdłuż istniejącej granicy wiersza lub [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) do podziału wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest on względem scalonego regionu:

- Podział wiersza: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Podział kolumny: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Przykład zakłada, że prezentacja ma tabelę jako pierwszą figurę na pierwszym slajdzie, z komórkami `(1, 2)` i `(1, 3)` scalonymi pionowo. Rozpoczynając od dolnej pozycji, używa [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) i [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) do zlokalizowania punktu początkowego i sprawdza oba zakresy. `split_by_row_span` z indeksem 1 oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalania dwóch kolumn użyj `split_by_col_span` z indeksem 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Pobierz wynikowe komórki z tabeli po podziale.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakresy równe 1 i [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) zwraca `False`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) po szczegóły.

## **Zmiana koloru tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Ustawia [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na `solid` oraz [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) na czerwony dla komórki `(2, 3)`, czyli trzeciej kolumny i czwartego wiersza.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie obrazu wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) i dodaje go do kolekcji obrazów prezentacji przy użyciu [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Następnie przypisuje obraz do wypełnienia obrazu komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podawane są w punktach. Załadowany obraz jest automatycznie zwalniany po zakończeniu bloku `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla poszczególnych krawędzi jednej komórki?**

Tak. Obramowania [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są ustawiane na poziomie fragmentu tekstu wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/figury. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (uruchomienia) z niezależnym formatowaniem — rodzinę czcionki, styl, rozmiar i kolor.