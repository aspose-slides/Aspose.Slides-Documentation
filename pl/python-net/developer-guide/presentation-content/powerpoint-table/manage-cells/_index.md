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
description: "Zarządzaj komórkami tabel PowerPoint w Pythonie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy przy użyciu Aspose.Slides dla Pythona poprzez .NET."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować połączone komórki tabel, usuwać obramowania komórek, pracować z numeracją komórek po połączeniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych. Współrzędne w tym artykule podawane są jako `(column, row)`.

## **Zidentyfikuj połączoną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada się, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny i używa [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) do identyfikacji komórek w połączonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), oraz początkowe współrzędne regionu, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) i [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) i dodaj tabelę do pierwszego slajdu za pomocą [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Szerokości kolumn, wysokości wierszy i pozycja tabeli podawane są w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), co sprawia, że są niewidoczne.

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

## **Dodaj ukośne obramowania komórek**

Użyj [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) aby narysować linię od lewego górnego rogu do prawego dolnego, oraz [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) aby narysować linię od lewego dolnego rogu do prawego górnego. Przekątna może oznaczać nagłówek narożny; obie przekątne mogą tworzyć X, aby oznaczyć komórkę jako nieodpowiednią.

Każda przekątna jest obiektem [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). W jej [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ustaw [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) i wybierz [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Ustaw [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) linii w punktach.

Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną w dół, niebieską przekątną w górę oraz obie przekątne. Pozostawia niezmienione górne, dolne, lewe i prawe obramowania komórek.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Przekątna jest właściwością formatowania, a nie podziałem komórki. Każda komórka zachowuje pojedynczy [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); obszary po obu stronach przekątnej nie mogą być edytowane niezależnie.

The saved table, rendered in Microsoft PowerPoint:

![Trzy komórki tabeli pokazujące czerwoną przekątną od lewego górnego do prawego dolnego, niebieską przekątną od lewego dolnego do prawego górnego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna w dół (czerwona, 3 pt), przekątna w górę (niebieska, 5 pt) oraz obie przekątne.*

## **Scal komórki tabeli**

Użyj [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki znajdujące się w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument określa, czy scalanie może obejmować komórki poza określonym zakresem; `False` utrzymuje scalanie w tym zakresie.

Przykład tworzy tabelę 4 na 4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwa kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.rows[1][1]` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie ulegają zmianie.

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

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę siatki i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides podąża za modelem siatki tabeli w PowerPoint.

Ten przykład tworzy tabelę 4 na 4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) na komórce `(1, 1)`. Połowa szerokości 70 punktów komórki jest przekazywana w celu utworzenia dwóch komórek o równej szerokości.

Po tym podziale dwie połówki są dostępne jako `table.rows[1][1]` i `table.rows[1][2]`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przenoszone są odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

<!-- visual-explanation:manage-cells:start -->
[![Niepołączona komórka 70-punktowa dzieli się na dwie komórki 35-punktowe, dodając piątą kolumnę siatki i przesuwając indeksy po jej prawej stronie.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Rozdzielenie szerokości dotyczy komórki (1, 1), używając indeksów zerowych (column, row). Inne wiersze zachowują komórkę rozciągającą się na oba nowe pozycje kolumn.*
<!-- visual-explanation:manage-cells:end -->

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) aby podzielić wzdłuż istniejącej granicy wiersza, lub [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scalonego regionu:

- Podział wiersza: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Podział kolumny: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Przykład zakłada, że prezentacja zawiera tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym komórki `(1, 2)` i `(1, 3)` są połączone pionowo. Zaczynając od niższej pozycji, używa [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) i [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) aby zlokalizować początek i sprawdza oba zakresy. `split_by_row_span` z indeksem równym 1 oddziela następnie wiersze 2 i 3 dla nazw produktów. W przypadku poziomego połączenia dwóch kolumn, użyj `split_by_col_span` z indeksem równym 1.

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

        # Pobierz wynikowe komórki z tabeli po podzieleniu.
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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakresy równe 1 i [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) zwraca `False`. Większe obszary mogą pozostać częściowo połączone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw wymagane formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) po szczegóły.

### **Podziel komórkę na określoną wysokość**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) przyjmuje wysokość górnej części w punktach. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) przyjmuje liczbę istniejących wierszy siatki w górnej części. Aby wyśrodkować 40-punktową komórkę w pionie w prawej kolumnie, odejmij 40 od rzeczywistej wysokości komórki i podziel pozostałą przestrzeń równo pomiędzy górą i dołem.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Pierwszy podział dodaje wiersz siatki, pozostawiając dolne 90 punktów w `table.rows[1][1]`. Drugi podział dzieli tę komórkę na środkową komórkę o wysokości 40 punktów oraz dolną komórkę o wysokości 50 punktów. Trzy komórki w prawej kolumnie mają teraz wysokości kolejno 50, 40 i 50 punktów od góry do dołu. Lewa komórka rozciąga się na wszystkie trzy wiersze przy swojej pierwotnej wysokości 140 punktów.

![Lewa komórka rozciąga się na pełną wysokość tabeli obok trzech komórek z napisem Middle w centrum.](split-by-height.png)

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Ustawia [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na solid i [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) i dodaje go do kolekcji obrazów prezentacji przy pomocy [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Następnie przypisuje obraz do wypełnienia obrazu (picture fill) komórki `(0, 0)`, pierwszej komórki w tabeli.

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

**Czy mogę ustawić różne grubości i style linii dla różnych stron jednej komórki?**

Tak. Obrzeża [górny](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[dolny](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[lewy](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[prawy](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tło komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/python-net/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (runy) z niezależnym formatowaniem — rodzinę czcionek, styl, rozmiar i kolor.