---
title: "Zarządzanie komórkami tabel w prezentacjach przy użyciu Pythona"
linktitle: "Zarządzaj komórkami"
type: docs
weight: 30
url: /pl/python-java/manage-cells/
keywords:
- "komórka tabeli"
- "scalanie komórek"
- "usuwanie obramowania"
- "dzielenie komórki"
- "obraz w komórce"
- "kolor tła"
- "PowerPoint"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Zarządzaj komórkami tabel PowerPoint w Pythonie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy za pomocą Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórki oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zerowych do dostępu do komórek tabeli w kolejności `(column, row)`.

## **Identyfikowanie scalonej komórki tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego obiektu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i obiekt istnieją oraz że obiekt jest tabelą. Następnie iteruje po wszystkich wierszach i kolumnach i używa [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) do identyfikacji komórek w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) oraz współrzędne początkowe regionu, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) i [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Usuwanie obramowań komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i dodaj tabelę do pierwszego slajdu za pomocą [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Szerokości kolumn, wysokości wierszy i pozycja tabeli są określane w punktach. Przykład ustawia wszystkie cztery obramowania komórki na [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), czyniąc je niewidocznymi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodawanie przekątnych obramowań komórek**

Użyj [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown), aby narysować linię od lewego górnego rogu do prawego dolnego, oraz [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp), aby narysować linię od lewego dolnego rogu do prawego górnego. Przekątna może oznaczyć nagłówek narożny. Obie przekątne mogą tworzyć X, aby zaznaczyć komórkę jako niewłaściwą.

Każda przekątna jest obiektem [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). W jej [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) użyj [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), aby wybrać [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) i określić kolor za pomocą [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Ustaw szerokość linii w punktach za pomocą [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Przykład tworzy trzy komórki w jednym wierszu: czerwoną przekątną w dół, niebieską w górę oraz obie przekątne. Górne, dolne, lewe i prawe obramowania komórek pozostają niezmienione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Przekątna jest właściwością formatowania, a nie podziałem komórki. Każda komórka zachowuje pojedynczą ramkę tekstową, dostępną przez [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Regiony po obu stronach przekątnej nie mogą być edytowane niezależnie.

![Trzy komórki tabeli pokazujące czerwoną przekątną od lewego górnego rogu do prawego dolnego, niebieską przekątną od lewego dolnego rogu do prawego górnego oraz obie przekątne tworzące X.](diagonal-cell-borders.png)

*Od lewej do prawej: przekątna w dół (czerwona, 3 pt), przekątna w górę (niebieska, 5 pt) oraz obie przekątne.*

## **Scalanie komórek tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells), aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza podanym zakresem; `False` utrzymuje scalanie w granicach tego zakresu.

Przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery środkowe komórki od `(1, 1)` do `(2, 2)`. Powstała komórka zajmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym obszarze pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem się nie zmieniają.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dzielenie komórek tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę w siatce i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides stosuje się do modelu siatki tabeli PowerPointa.

Przykład tworzy tabelę 4 × 4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) na komórce `(1, 1)`. Połowa szerokości 70 punktów komórki jest przekazywana, aby utworzyć dwie komórki o równej szerokości.

Po tym podziale dwie połowy są dostępne jako `table.get_Item(1, 1)` i `table.get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przesuwają się odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

<!-- visual-explanation:manage-cells:start -->
[![Niescalona komórka o szerokości 70 punktów dzieli się na dwie komórki po 35 punktów, dodając piątą kolumnę siatki i przesuwając indeksy po jej prawej stronie.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Podział szerokości dotyczy komórki (1, 1), używając indeksów zerowych (kolumna, wiersz). Inne wiersze zachowują komórkę rozciągającą się na oba nowe pozycje kolumn.*
<!-- visual-explanation:manage-cells:end -->

### **Rozdzielanie scalonych komórek według wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) do podziału wzdłuż istniejącej granicy wiersza lub [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) do podziału wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest on względny względem scalonego obszaru:

- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy obiekt na pierwszym slajdzie, z komórkami `(1, 2)` i `(1, 3)` scalonymi pionowo. Zaczynając od niższej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) i [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex), aby określić początek, i sprawdza oba zakresy. `splitByRowSpan(1)` oddziela wiersze 2 i 3 dla nazw produktów. Dla poziomego scalania dwóch kolumn użyj `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Pobierz wynikowe komórki z tabeli po podziale.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki po ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) zwraca `False`. Większe obszary mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i wyraźnie ustaw wymagane formatowanie tekstu.

Zapisana prezentacja zawiera oddzielne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Dokumentacja API komórki](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) po szczegóły.

### **Dzielenie komórki o określonej wysokości**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) przyjmuje wysokość górnej części w punktach. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) przyjmuje liczbę istniejących wierszy siatki w górnej części. Aby wyśrodkować komórkę 40 punktów w prawej kolumnie, odejmij 40 od faktycznej wysokości komórki i podziel pozostałą przestrzeń równo powyżej i poniżej niej.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pierwszy podział dodaje wiersz siatki i pozostawia dolne 90 punktów w komórce `(1, 1)`. Drugi podział dzieli tę komórkę na środkową o wysokości 40 punktów i dolną o wysokości 50 punktów. Prawa kolumna ma teraz trzy komórki o wysokościach 50, 40 i 50 punktów od góry do dołu. Lewa komórka rozciąga się na wszystkie trzy wiersze i zachowuje oryginalną wysokość 140 punktów.

![Lewa komórka rozciąga się na pełną wysokość tabeli obok trzech komórek z „Middle” w środku.](split-by-height.png)

## **Zmiana koloru tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), aby wybrać wypełnienie jednorodne i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodawanie obrazu wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) i dodaje go do kolekcji obrazów prezentacji za pomocą [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Następnie przypisuje obraz do wypełnienia obrazu komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnił komórkę, co może zmienić jego proporcje. Szerokości kolumn i wysokości wierszy podawane są w punktach. Ładowany obraz jest zwalniany w bloku `finally` po dodaniu go do prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla poszczególnych stron jednej komórki?**

Tak. Obramowania [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) mają oddzielne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hiperłącza](/slides/pl/python-java/manage-hyperlinks/) są ustawiane na poziomie fragmentu tekstu wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/obiektu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (uruchomienia) z niezależnym formatowaniem – rodziną czcionki, stylem, rozmiarem i kolorem.