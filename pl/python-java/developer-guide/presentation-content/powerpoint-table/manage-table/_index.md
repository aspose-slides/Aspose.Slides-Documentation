---
title: Zarządzanie tabelami w prezentacji w Pythonie
linktitle: Zarządzanie tabelą
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
description: "Twórz i edytuj tabele w slajdach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java. Odkryj proste przykłady kodu, które usprawnią Twoje przepływy pracy z tabelami."
---
## **Wprowadzenie**

Tabele w programie PowerPoint organizują informacje w wierszach i kolumnach, co ułatwia ich odczyt i porównywanie wartości.

Aspose.Slides udostępnia klasy [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) i [Komórka](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) oraz inne typy, które pozwalają tworzyć, aktualizować i zarządzać tabelami w prezentacjach.

## **Utworzenie tabeli od podstaw**

Utwórz tabelę, określając jej pozycję, szerokości kolumn i wysokości wierszy. Po dodaniu jej do slajdu możesz formatować obramowania komórek, scalać komórki i wstawiać tekst.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu po jego indeksie.
3. Zdefiniuj listę szerokości kolumn w punktach.
4. Zdefiniuj listę wysokości wierszy w punktach.
5. Dodaj obiekt [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) do slajdu przez metodę [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Przejdź przez każdą [Komórka](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) i zastosuj formatowanie górnych, dolnych, prawych i lewych obramowań.
7. Scal pierwsze dwa pola w pierwszym wierszu tabeli.
8. Uzyskaj dostęp do scalonej komórki przez metodę [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Ustaw tekst w scalonej komórce.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład tworzy tabelę z trzema kolumnami i pięcioma wierszami w punkcie (100, 50). Stosuje czerwone obramowania o szerokości 5 punktów, scala pierwsze dwa pola w pierwszym wierszu i zapisuje wynik jako `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numeracja w standardowej tabeli**

W standardowej tabeli indeksy komórek zaczynają się od zera i używają kolejności (kolumna, wiersz). Pierwsza komórka ma indeks (0, 0).

Na przykład komórki w tabeli z 4 kolumnami i 4 wierszami są numerowane w ten sposób:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ten przykład tworzy tabelę 4 × 4 przedstawioną powyżej, ze szerokościami kolumn i wysokościami wierszy po 70 punktów oraz czerwonymi obramowaniami o szerokości 5 punktów. Współrzędne ilustrują indeksy komórek; przykład pozostawia komórki puste i zapisuje tabelę jako `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do istniejącej tabeli**

Tabele są przechowywane w kolekcji kształtów slajdu. Przejrzyj kształty, aby znaleźć tabelę, a następnie użyj klasy [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/), aby odczytać lub zaktualizować jej komórki.

1. Wczytaj prezentację przy użyciu klasy [Prezentacja](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu zawierającego tabelę po jego indeksie.
3. Przejrzyj obiekty [Kształt](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) i zatrzymaj się, gdy znajdziesz tabelę. Jeśli slajd zawiera kilka tabel, użyj [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText), aby zidentyfikować potrzebną.
4. Zaktualizuj tekst w docelowej komórce.
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `UpdateExistingTable.pptx` i znajduje pierwszą tabelę na pierwszym slajdzie. Ustawia komórkę w kolumnie 0, wierszu 1 na `New` i zapisuje wynik jako `table1_out.pptx`. Plik wejściowy musi zawierać co najmniej jeden slajd, a pierwsza tabela na tym slajdzie musi mieć co najmniej jedną kolumnę i dwa wiersze.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby zmienić rozmiar wiersza w istniejącej tabeli i zrozumieć, dlaczego jego rzeczywista wysokość może przekraczać wymaganą minimalną, zobacz [Kontroluj wysokość wiersza](/slides/pl/python-java/manage-rows-and-columns/#control-row-height).

## **Znajdowanie komórki, której właścicielem jest ramka tekstowa**

Gdy ogólny kod przetwarzający tekst otrzyma obiekt [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) z tabeli, użyj metody [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell), aby uzyskać właściciela – [Komórka](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). Dla ramki tekstowej komórki tabeli metoda [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) zwraca właściciela, a [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) zwraca `None`, mimo że sama tabela jest kształtem.

Współrzędne komórki są dostępne przez tylko do odczytu metody [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) oraz [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). Metoda [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) zapewnia również nawigację tylko do odczytu: zwraca właściciela, ale nie zmienia własności. Zawsze sprawdzaj, czy zwrócona komórka nie jest `None`, zanim ją użyjesz.

Pełny przykład identyfikujący właścicieli komórek tabeli i kształtów, w tym kształty powiązane z węzłami SmartArt, znajduje się w [Wyszukaj i zamień tekst](/slides/pl/python-java/search-and-replace-text/).

## **Wyrównanie tekstu w tabeli**

Możesz kontrolować pionowe zakotwiczenie i kierunek tekstu w poszczególnych komórkach tabeli. Przykład w tej sekcji centruje tekst w pierwszej komórce i obraca go o 270 stopni.

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu po jego indeksie.
3. Dodaj obiekt [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) do slajdu.
4. Uzyskaj dostęp do obiektu [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) z tabeli.
5. Uzyskaj dostęp do pierwszego [Akapitu](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) i ustaw jego tekst oraz kolor.
6. Ustaw pionowe zakotwiczenie komórki i kierunek tekstu przy użyciu [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) oraz [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Zapisz zmodyfikowaną prezentację.

Ten przykład tworzy tabelę 4 × 4 o szerokościach kolumn 120 punktów i wysokościach wierszy 100 punktów. Formatuje tekst w komórce (0, 0), dodaje wartości do pozostałych komórek w pierwszym wierszu i zapisuje wynik jako `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawienie formatowania tekstu na poziomie tabeli**

Użyj [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat), aby zastosować formatowanie tekstu we wszystkich komórkach tabeli. Przeciążenia akceptują formatowanie fragmentu, akapitu i ramki tekstowej, więc możesz ustawiać te właściwości bez iteracji po poszczególnych komórkach.

1. Wczytaj prezentację przy użyciu klasy [Prezentacja](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Pobierz odwołanie do slajdu po jego indeksie.
3. Uzyskaj dostęp do obiektu [Tabela](https://reference.aspose.com/slides/python-java/aspose.slides/table/) ze slajdu.
4. Ustaw rozmiar czcionki przy użyciu [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) dla tekstu.
5. Ustaw wyrównanie akapitu i prawy margines przy użyciu [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) oraz [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Ustaw kierunek tekstu przy użyciu [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Zapisz zmodyfikowaną prezentację.

Poniższy przykład otwiera `table.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Ustawia rozmiar czcionki na 25 punktów, wyrównuje akapity do prawej z prawym marginesem 20 punktów i zmienia tekst na pionowy. Sformatowaną prezentację zapisuje jako `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pobieranie właściwości stylu tabeli**

Użyj [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), aby odczytać wstępnie ustawiony styl tabeli, oraz [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset), aby go przypisać. Ten przykład stosuje [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) do jednej tabeli, wypisuje wartość presetu i przypisuje ten sam preset drugiej tabeli. Obie tabele są zapisywane w `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zablokowanie proporcji tabeli**

Proporcje tabeli to stosunek jej szerokości do wysokości. Użyj [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), aby zablokować ten stosunek dla tabeli.

Poniższy przykład otwiera `pres.pptx`, który musi zawierać co najmniej jeden slajd z tabelą jako pierwszym kształtem. Wypisuje bieżący stan blokady, włącza blokadę proporcji, wypisuje zaktualizowany stan (`True`) i zapisuje wynik jako `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę włączyć kierunek czytania od prawej do lewej (RTL) dla całej tabeli i tekstu w jej komórkach?**

Tak. Tabela udostępnia metodę [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), a akapity mają [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Użycie obu zapewnia prawidłowy porządek RTL i renderowanie wewnątrz komórek.

**Jak mogę uniemożliwić użytkownikom przenoszenie lub zmianę rozmiaru tabeli w pliku końcowym?**

Użyj [blokad kształtów](/slides/pl/python-java/applying-protection-to-presentation/), aby wyłączyć przenoszenie, zmianę rozmiaru, zaznaczanie itp. Te blokady działają również na tabele.

**Czy wstawianie obrazu jako tła w komórce jest obsługiwane?**

Tak. Możesz ustawić [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) dla komórki; obraz pokryje obszar komórki zgodnie z wybranym trybem (rozciąganie lub kafelkowanie).