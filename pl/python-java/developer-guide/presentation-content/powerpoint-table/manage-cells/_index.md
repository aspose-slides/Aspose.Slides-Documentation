---
title: Zarządzaj komórkami tabel w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj komórkami
type: docs
weight: 30
url: /pl/python-java/manage-cells/
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
description: "Zarządzaj komórkami tabel PowerPoint w Pythonie: identyfikuj scalone komórki, usuwaj obramowania, dziel komórki oraz ustawiaj kolory tła i obrazy za pomocą Aspose.Slides dla Pythona poprzez Javę."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabel w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabel, usunąć obramowania komórek, pracować z numeracją komórek po scaleniu lub podziale komórek, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, uzyskać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez właściwości komórek i zapisać zmodyfikowaną prezentację jako plik PPTX.

Aspose.Slides używa indeksów zaczynających się od zera do dostępu do komórek tabel w kolejności `(column, row)`.

## **Zidentyfikuj scaloną komórkę tabeli**

Przykład otwiera istniejącą prezentację i uzyskuje dostęp do pierwszego kształtu na pierwszym slajdzie jako tabeli. Zakłada, że slajd i kształt istnieją oraz że kształt jest tabelą. Następnie iteruje przez wszystkie wiersze i kolumny i używa [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell), aby zidentyfikować komórki w scalonych obszarach. Dla każdego dopasowania wypisuje współrzędne komórki w kolejności `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) oraz początkowe współrzędne regionu, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) i [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Usuń obramowania komórek tabeli**

Utwórz [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) i dodaj tabelę do jej pierwszego slajdu za pomocą [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Szerokości kolumn, wysokości wierszy i pozycja tabeli są podane w punktach. Przykład ustawia wszystkie cztery obramowania komórek na [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), czyniąc je niewidocznymi.

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

## **Scal komórki tabeli**

Użyj [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells), aby połączyć prostokątny zakres komórek tabeli w jedną komórkę. Określ komórki w lewym górnym i prawym dolnym rogu zakresu. Ostatni argument kontroluje, czy scalanie może obejmować komórki poza określonym zakresem; `False` utrzymuje scalenie w tym zakresie.

Przykład tworzy tabelę 4‑na‑4 z kolumnami i wierszami o szerokości 70 punktów, a następnie scala cztery centralne komórki od `(1, 1)` do `(2, 2)`. Powstała komórka obejmuje dwie kolumny i dwa wiersze, podczas gdy podstawowa siatka tabeli zachowuje cztery kolumny i cztery wiersze. Aby uzyskać dostęp do zawartości lub formatowania scalonej komórki, użyj jej pozycji w lewym górnym rogu: `table.get_Item(1, 1)` w tym przykładzie. Pozostałe pozycje w scalonym zakresie pozostają częścią siatki tabeli, więc indeksy komórek poza zakresem nie zmieniają się.

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

## **Podziel komórki tabeli**

Scalanie komórek w poprzednim przykładzie zachowuje siatkę tabeli. Podzielenie komórki może wprowadzić nową kolumnę w siatce i zmienić indeksy kolumn komórek po jej prawej stronie. Aspose.Slides korzysta z modelu siatki tabeli PowerPoint.

Ten przykład tworzy tabelę 4‑na‑4 z kolumnami i wierszami o szerokości 70 punktów i wywołuje [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) na komórce `(1, 1)`. Połowa szerokości 70‑punktowej komórki jest przekazywana w celu utworzenia dwóch komórek o równej szerokości.

Po tym podziale dwie połówki są dostępne jako `table.get_Item(1, 1)` i `table.get_Item(2, 1)`. Siatka tabeli ma teraz pięć kolumn: komórki pierwotnie w kolumnach 2 i 3 przechodzą odpowiednio do kolumn 3 i 4. Indeksy wierszy pozostają niezmienione. Używaj tych zaktualizowanych indeksów kolumn przy dostępie do komórek po podziale.

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

### **Podziel scalone komórki według zakresu wiersza lub kolumny**

Aby przygotować scalone komórki szablonu do wypełniania danymi, użyj [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan), aby podzielić wzdłuż istniejącej granicy wiersza, lub [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan), aby podzielić wzdłuż granicy kolumny.

Argument `index` liczy wiersze w górnej części lub kolumny w lewej części podziału; jest względny względem scalonego regionu:

- Podział wiersza: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Podział kolumny: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Przykład zakłada, że prezentacja ma tabelę jako pierwszy kształt na pierwszym slajdzie, przy czym `(1, 2)` i `(1, 3)` są scalone pionowo. Rozpoczynając od niższej pozycji, używa [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) i [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex), aby zlokalizować początek i sprawdza oba zakresy. `splitByRowSpan(1)` oddziela następnie wiersze 2 i 3 dla nazw produktów. Dla poziomego scalenia dwóch kolumn użyj `splitByColSpan(1)`.

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

Siatka tabeli i otaczające indeksy komórek pozostają niezmienione. Pobierz wynikowe komórki według ich współrzędnych; tutaj obie mają zakres 1 i [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) zwraca `False`. Większe regiony mogą pozostać częściowo scalone po jednym podziale.

Oryginalny tekst i jego formatowanie pozostają w górnej (lub lewej) komórce; nowa komórka jest pusta, ale dziedziczy formatowanie komórki, takie jak wypełnienie, obramowania i marginesy. Wypełnij komórki po podziale i ustaw ewentualne formatowanie tekstu explicite.

Zapisana prezentacja zawiera osobne komórki „Product A” i „Product B” z zachowanym formatowaniem komórek szablonu. Zobacz [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) po szczegóły.

## **Zmień kolor tła komórki tabeli**

Ten przykład tworzy tabelę z kolumnami o szerokości 150 punktów i wierszami o wysokości 50 punktów. Używa [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), aby wybrać wypełnienie jednolite i ustawia kolor zwrócony przez [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) na czerwony dla komórki `(2, 3)`, w trzeciej kolumnie i czwartym wierszu.

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

## **Dodaj obraz wewnątrz komórki tabeli**

Umieść obraz wejściowy w katalogu roboczym przed uruchomieniem tego przykładu. Ładuje obraz za pomocą [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) i dodaje go do kolekcji obrazów prezentacji za pomocą [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Następnie przypisuje obraz do wypełnienia obrazem komórki `(0, 0)`, pierwszej komórki w tabeli.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) rozciąga obraz, aby wypełnić komórkę, co może zmienić jej proporcje. Szerokości kolumn i wysokości wierszy podane są w punktach. Załadowany obraz jest zwalniany w bloku `finally` po jego dodaniu do prezentacji.

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

**Czy mogę ustawić różne grubości i style linii dla różnych stron jednej komórki?**

Tak. Obramowania [górne](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[dolne](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[lewe](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[prawe](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) mają osobne właściwości, więc grubość i styl każdej strony mogą się różnić.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [tryb wypełnienia](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hyperlinks](/slides/pl/python-java/manage-hyperlinks/) są ustawiane na poziomie tekstu (fragmentu) wewnątrz ramki tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/python-java/aspose.slides/portion/).