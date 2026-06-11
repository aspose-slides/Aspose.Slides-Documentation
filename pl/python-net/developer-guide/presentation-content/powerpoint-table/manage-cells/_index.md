---
title: Zarządzaj komórkami tabel w prezentacjach w Pythonie
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/python-net/manage-cells/
keywords:
- komórka tabeli
- scalanie komórek
- usuwanie obramowania
- podział komórki
- obraz w komórce
- kolor tła
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Z łatwością zarządzaj komórkami tabel w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez .NET. Opanuj szybki dostęp, modyfikację i stylizowanie komórek dla płynnej automatyzacji slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek za pomocą właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikowanie scalonych komórek tabeli**

Tabele często zawierają scalone komórki w nagłówkach lub w celu grupowania powiązanych danych. W tej sekcji zobaczysz, jak określić, czy dana komórka należy do scalonego obszaru oraz jak odwołać się do komórki nadrzędnej (górny‑lewy róg), aby móc odczytać lub sformatować cały blok w jednolity sposób.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz tabelę z pierwszego slajdu.
1. Iteruj po wierszach i kolumnach tabeli, aby znaleźć scalone komórki.
1. Wypisz komunikat, gdy zostaną znalezione scalone komórki.

Poniższy kod Python identyfikuje scalone komórki tabeli w prezentacji:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Zakładając, że pierwszym kształtem na pierwszym slajdzie jest tabela.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Usuwanie obramowań komórek tabeli**

Czasami obramowania tabel odciągają uwagę od treści lub tworzą niepotrzebny bałagan wizualny. W tej sekcji pokazano, jak usunąć obramowania z wybranych komórek — lub konkretnych stron komórki — aby uzyskać czystszy układ i lepiej dopasować go do projektu slajdu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz slajd według jego indeksu.
1. Zdefiniuj tablicę szerokości kolumn.
1. Zdefiniuj tablicę wysokości wierszy.
1. Dodaj tabelę do slajdu za pomocą metody [add_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_table/).
1. Iteruj po każdej komórce, aby usunąć obramowania górne, dolne, lewe i prawe.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod Python pokazuje, jak usunąć obramowania z komórek tabeli:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj kolumny z szerokościami i wiersze z wysokościami.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Wyczyść wypełnienie krawędzi dla każdej komórki.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Zapisz plik PPTX na dysku.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Numeracja w scalonych komórkach**

Jeśli scalasz dwie pary komórek — na przykład (1, 1) x (2, 1) i (1, 2) x (2, 2) — otrzymana tabela zachowa taką samą numerację komórek jak tabela bez scalania. Poniższy kod Python demonstruje to zachowanie:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj kolumny z szerokościami i wiersze z wysokościami.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Scal komórki (1,1) i (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Scal komórki (1, 2) i (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Wypisz indeksy komórek.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Zapisz plik PPTX na dysku.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Wyjście:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Numeracja w podzielonych komórkach**

W poprzednim przykładzie, gdy komórki tabeli były scalone, numeracja w pozostałych komórkach się nie zmieniła. Tym razem tworzymy zwykłą tabelę (bez scalonych komórek), a następnie dzielimy komórkę (1, 1), aby uzyskać specjalną tabelę. Zwróć uwagę na numerację tej tabeli — może wyglądać nietypowo. Jednak tak Microsoft PowerPoint numeruje komórki tabel, a Aspose.Slides zachowuje takie samo zachowanie.

Poniższy kod Python demonstruje to zachowanie:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Podziel komórkę (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Wypisz indeksy komórek.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Zapisz plik PPTX na dysku.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Wyjście:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Zmiana koloru tła komórki tabeli**

Poniższy przykład w Pythonie demonstruje, jak zmienić kolor tła komórki tabeli:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Utwórz nową tabelę.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Ustaw kolor tła komórki.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Wstawianie obrazów do komórek tabeli**

W tej sekcji pokazano, jak wstawić obraz do komórki tabeli w Aspose.Slides. Omówiono zastosowanie wypełnienia obrazem w docelowej komórce oraz konfigurację opcji wyświetlania, takich jak rozciąganie lub kafelkowanie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu według jego indeksu.
1. Zdefiniuj tablicę szerokości kolumn.
1. Zdefiniuj tablicę wysokości wierszy.
1. Dodaj tabelę do slajdu przy użyciu metody [add_table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapecollection/add_table/).
1. Wczytaj obraz z pliku.
1. Dodaj obraz do kolekcji obrazów prezentacji, aby uzyskać obiekt [PPImage](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ppimage/).
1. Ustaw [FillType](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/) komórki tabeli na `PICTURE`.
1. Zastosuj obraz w komórce tabeli i wybierz tryb wypełnienia (np. `STRETCH`).
1. Zapisz prezentację jako plik PPTX.

Poniższy kod Python pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

```python
import aspose.slides as slides

# Utwórz obiekt Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.slides[0]

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Dodaj kształt tabeli do slajdu.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Wczytaj obraz i dodaj go do prezentacji, aby uzyskać obiekt PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Zastosuj obraz w pierwszej komórce tabeli.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Zapisz prezentację na dysku.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla różnych krawędzi jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cellformat/border_top/)/[dolne](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cellformat/border_bottom/)/[lewe](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cellformat/border_left/)/[prawe](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cellformat/border_right/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić. Wynika to logicznie z kontroli obramowania po każdej stronie komórki przedstawionej w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillmode/). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. W artykule wspomniano o trybach wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portion/).