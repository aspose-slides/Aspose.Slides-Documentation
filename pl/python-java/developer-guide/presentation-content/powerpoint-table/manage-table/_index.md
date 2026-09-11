---
title: Zarządzanie tabelami prezentacji w Pythonie
linktitle: Zarządzaj tabelą
type: docs
weight: 10
url: /pl/python-java/manage-table/
keywords:
- dodaj tabelę
- utwórz tabelę
- dostęp do tabeli
- proporcje
- wyrównaj tekst
- formatowanie tekstu
- styl tabeli
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java. Odkryj proste przykłady kodu, które usprawnią Twoje procesy pracy z tabelami."
---
## **Wprowadzenie**

Tabela w programie PowerPoint jest efektywnym sposobem prezentacji informacji. Informacje w siatce komórek (układanych w wiersze i kolumny) są proste i łatwe do zrozumienia.

Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) klasę [Cell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami w różnego rodzaju prezentacjach.

## **Utworzenie tabeli od podstaw**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu po jego indeksie.
3. Zdefiniuj listę szerokości kolumn.
4. Zdefiniuj listę wysokości wierszy.
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) do slajdu za pomocą metody [addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable).
6. Iteruj przez każde [Cell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/), aby zastosować formatowanie do górnych, dolnych, prawych i lewych krawędzi.
7. Scal pierwsze dwie komórki pierwszego wiersza tabeli.
8. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) komórki [Cell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/).
9. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).
10. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak utworzyć tabelę w prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
presentation = Presentation()
try:

    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Dodaje kształt tabeli do slajdu
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustawia format krawędzi dla każdej komórki
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Łączy komórki 1 i 2 wiersza 1
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Dodaje tekst do scalonej komórki
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Zapisuje prezentację na dysku
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli numeracja komórek jest prosta i zaczyna się od zera. Pierwsza komórka w tabeli ma indeks 0,0 (kolumna 0, wiersz 0).

Na przykład, komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w następujący sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten kod w Pythonie pokazuje, jak utworzyć tabelę ze standardową numeracją komórek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
presentation = Presentation()
try:

    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Dodaje kształt tabeli do slajdu
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Ustawia format krawędzi dla każdej komórki
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

    # Zapisuje prezentację na dysku
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do istniejącej tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu zawierającego tabelę po jego indeksie.
3. Zainicjalizuj zmienną dla obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/), ustawiając ją na `None`.
4. Iteruj przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/) aż znajdziesz tabelę.

   Jeśli podejrzewasz, że slajd, z którym pracujesz, zawiera jedną tabelę, możesz po prostu sprawdzić wszystkie jego kształty. Gdy kształt zostanie zidentyfikowany jako tabela, możesz użyć go jako obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/). Jeśli jednak slajd zawiera kilka tabel, lepiej wyszukać potrzebną tabelę przy użyciu jej [getAlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText).

5. Użyj obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/), aby pracować z tabelą. W poniższym przykładzie aktualizujemy tekst w pierwszej kolumnie drugiego wiersza.
6. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak uzyskać dostęp i pracować z istniejącą tabelą:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Uzyskuje dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Inicjalizuje referencję do tabeli.
    table = None

    # Iteruje przez kształty i ustawia referencję do znalezionej tabeli
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Ustawia tekst dla pierwszej kolumny drugiego wiersza
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Zapisuje zmodyfikowaną prezentację na dysku
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Znajdowanie komórki, która posiada ramkę tekstową**

Gdy ogólny kod przetwarzający tekst otrzymuje [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) z tabeli, użyj metody [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentCell), aby pobrać właściciela – [Cell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/). Dla ramki tekstowej w komórce tabeli, [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentCell) zwraca właściciela, a [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentShape) zwraca `None`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne poprzez metody tylko do odczytu [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/#getFirstColumnIndex) i [Cell.getFirstRowIndex](https://reference.aspose.com/slides/pl/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/#getParentCell) także zapewnia nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `None`, zanim ją użyjesz.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajdziesz w [Search and Replace Text](/slides/pl/python-java/search-and-replace-text/).

## **Wyrównywanie tekstu w tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu po jego indeksie.
3. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/) obiektu [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).
6. Wyrównaj tekst pionowo.
7. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak wyrównać tekst w tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Tworzy instancję klasy Presentation
presentation = Presentation()
try:

    # Pobiera pierwszy slajd
    slide = presentation.getSlides().get_Item(0)

    # Definiuje kolumny o określonych szerokościach i wiersze o określonych wysokościach
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Dodaje kształt tabeli do slajdu
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Uzyskuje dostęp do ramki tekstowej
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Uzyskuje dostęp do pierwszego akapitu w ramce tekstowej.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Uzyskuje dostęp do pierwszej części w akapicie.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Wyrównuje tekst pionowo
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Zapisuje prezentację na dysku
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw formatowanie tekstu na poziomie tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu po jego indeksie.
3. Uzyskaj dostęp do obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) ze slajdu.
4. Ustaw wysokość czcionki tekstu przy pomocy [setFontHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Ustaw wyrównanie i prawy margines przy pomocy [setAlignment](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setAlignment) oraz [setMarginRight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ustaw pionowy typ tekstu przy pomocy [setTextVerticalType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Zapisz zmodyfikowaną prezentację.

Ten kod w Pythonie pokazuje, jak zastosować wybrane opcje formatowania do tekstu w tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Tworzy instancję klasy Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Załóżmy, że pierwszy kształt na pierwszym slajdzie jest tabelą
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Ustawia wysokość czcionki komórek tabeli
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Ustawia wyrównanie tekstu i prawy margines komórek tabeli w jednym wywołaniu
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Ustawia pionowy typ tekstu komórek tabeli
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides pozwala pobrać właściwości stylu tabeli, aby można było wykorzystać te informacje w innej tabeli lub w innym miejscu. Ten kod w Pythonie pokazuje, jak uzyskać właściwości stylu z predefiniowanego stylu tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # zmień domyślny styl tabeli

    # Pobiera preset stylu tabeli
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Zastosuj pobrany preset stylu do innej tabeli
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zablokowanie proporcji tabeli**

Proporcja geometrycznego kształtu to stosunek jego wymiarów w różnych wymiarach. Aspose.Slides udostępnia metodę [setAspectRatioLocked](https://reference.aspose.com/slides/pl/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), aby umożliwić zablokowanie ustawienia proporcji dla tabel i innych kształtów.

Ten kod w Pythonie pokazuje, jak zablokować proporcje tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # odwróć
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę włączyć kierunek odczytu od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/#setRightToLeft), a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setRightToLeft). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w finalnym pliku?**

Użyj [shape locks](/slides/pl/python-java/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady działają również na tabele.

**Czy wstawianie obrazu wewnątrz komórki jako tła jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/pl/python-java/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).