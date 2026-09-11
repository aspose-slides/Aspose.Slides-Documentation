---
title: Zarządzanie komórkami tabeli w prezentacjach przy użyciu Pythona
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
description: "Bezproblemowo zarządzaj komórkami tabeli w PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Javę. Opanuj szybki dostęp, modyfikację i stylizowanie komórek, aby zapewnić płynną automatyzację slajdów."
---
## **Przegląd**

Aspose.Slides umożliwia dostęp i modyfikację komórek tabeli w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak zidentyfikować scalone komórki tabeli, usunąć obramowania komórek, pracować z numeracją komórek po scałkowaniu lub podzieleniu, zmienić kolor tła komórki oraz dodać obraz wewnątrz komórki tabeli. Przykłady pokazują, jak utworzyć lub otworzyć prezentację, pobrać tabelę ze slajdu, zaktualizować formatowanie komórek poprzez ich właściwości oraz zapisać zmodyfikowaną prezentację jako plik PPTX.

## **Identyfikowanie scalonej komórki tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz tabelę z pierwszego slajdu.
3. Iteruj przez wiersze i kolumny tabeli, aby znaleźć scalone komórki.
4. Wypisz komunikat, gdy zostaną znalezione scalone komórki.

Ten kod w Pythonie pokazuje, jak zidentyfikować scalone komórki tabeli w prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Zakłada się, że pierwszy kształt na pierwszym slajdzie jest tabelą.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Usuwanie obramowań komórek tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu po jego indeksie.
3. Zdefiniuj listę szerokości kolumn.
4. Zdefiniuj listę wysokości wierszy.
5. Dodaj tabelę do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable).
6. Iteruj po każdej komórce, aby usunąć górne, dolne, prawe i lewe obramowanie.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak usunąć obramowania z komórek tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustaw format obramowania dla każdej komórki.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeracja w scalonych komórkach**

Jeśli scalimy dwie pary komórek: (1, 1) i (2, 1) oraz (1, 2) i (2, 2), powstała tabela zachowuje numerację komórek. Ten kod w Pythonie demonstruje ten proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustaw format obramowania dla każdej komórki.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Scal komórki (1, 1) i (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Scal komórki (1, 2) i (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Następnie scalamy dalej komórki, łącząc (1, 1) i (1, 2). Wynikiem jest tabela zawierająca dużą scaloną komórkę w jej centrum:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustaw format obramowania dla każdej komórki.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Scal komórki (1, 1) i (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Scal komórki (1, 2) i (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Scal komórki (1, 1) i (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeracja w podzielonej komórce**

W poprzednich przykładach scalanie komórek tabeli nie zmieniło numeracji pozostałych komórek.

Tym razem bierzemy zwykłą tabelę (tabelę bez scalonych komórek) i próbujemy podzielić komórkę (1, 1), aby uzyskać specjalną tabelę. Warto zwrócić uwagę na numerację tej tabeli, która może wydawać się niezwykła. Jest to jednak sposób, w jaki Microsoft PowerPoint numeruje komórki tabeli, a Aspose.Slides zachowuje się tak samo.

Ten kod w Pythonie demonstruje opisany proces:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustaw format obramowania dla każdej komórki.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Podziel komórkę (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zmiana koloru tła komórki tabeli**

Ten kod w Pythonie pokazuje, jak zmienić kolor tła komórki tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Ustaw kolor tła dla komórki.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dodawanie obrazu wewnątrz komórki tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu po jego indeksie.
3. Zdefiniuj listę szerokości kolumn.
4. Zdefiniuj listę wysokości wierszy.
5. Dodaj tabelę do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable).
6. Wczytaj plik obrazu przy użyciu [Images.fromFile](https://reference.aspose.com/slides/pl/python-java/aspose.slides/images/#fromFile).
7. Dodaj obraz do prezentacji, aby utworzyć obiekt [PPImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ppimage/).
8. Ustaw typ wypełnienia [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/) komórki tabeli na [FillType.Picture](https://reference.aspose.com/slides/pl/python-java/aspose.slides/filltype/#Picture).
9. Dodaj obraz do pierwszej komórki tabeli.
10. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod w Pythonie pokazuje, jak umieścić obraz wewnątrz komórki tabeli podczas tworzenia tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Zdefiniuj szerokości kolumn i wysokości wierszy.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Dodaj tabelę do slajdu.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Utwórz obraz prezentacji z pliku obrazu.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Dodaj obraz do pierwszej komórki tabeli.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Zapisz prezentację jako plik PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ustawić różne grubości i style linii dla różnych krawędzi jednej komórki?**

Tak. Obrzeża [górne](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellformat/#getBorderTop)/[dolne](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellformat/#getBorderBottom)/[lewe](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellformat/#getBorderLeft)/[prawe](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cellformat/#getBorderRight) mają oddzielne właściwości, więc grubość i styl każdej krawędzi mogą się różnić. Wynika to logicznie z możliwości sterowania obramowaniem po stronach dla pojedynczej komórki, przedstawionych w artykule.

**Co się stanie z obrazem, jeśli zmienię rozmiar kolumny/wiersza po ustawieniu obrazu jako tła komórki?**

Zachowanie zależy od [trybu wypełnienia](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillmode/) (rozciąganie/kafelkowanie). Przy rozciąganiu obraz dopasowuje się do nowej komórki; przy kafelkowaniu kafelki są przeliczane. W artykule opisano tryby wyświetlania obrazu w komórce.

**Czy mogę przypisać hiperłącze do całej zawartości komórki?**

[Hiperłącza](/slides/pl/python-java/manage-hyperlinks/) są ustawiane na poziomie fragmentu tekstu w ramce tekstowej komórki lub na poziomie całej tabeli/kształtu. W praktyce przypisujesz link do fragmentu lub do całego tekstu w komórce.

**Czy mogę ustawić różne czcionki w jednej komórce?**

Tak. Ramka tekstowa komórki obsługuje [fragmenty](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) (runs) z niezależnym formatowaniem — rodziną czcionki, stylem, rozmiarem i kolorem.