---
title: Zarządzanie wierszami i kolumnami w tabelach PowerPoint przy użyciu Pythona
linktitle: Wiersze i kolumny
type: docs
weight: 20
url: /pl/python-java/manage-rows-and-columns/
keywords:
- wiersz tabeli
- kolumna tabeli
- pierwszy wiersz
- nagłówek tabeli
- sklonuj wiersz
- sklonuj kolumnę
- kopiuj wiersz
- kopiuj kolumnę
- usuń wiersz
- usuń kolumnę
- formatowanie tekstu wiersza
- formatowanie tekstu kolumny
- styl tabeli
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj wierszami i kolumnami tabel w programie PowerPoint za pomocą Aspose.Slides dla Pythona przez Java i przyspiesz edycję prezentacji oraz aktualizację danych."
---
## **Wprowadzenie**

Aby umożliwić zarządzanie wierszami i kolumnami tabeli w prezentacji PowerPoint, Aspose.Slides udostępnia klasę [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) oraz wiele innych typów.

## **Ustaw pierwszy wiersz jako nagłówek**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację.  
2. Pobierz odwołanie do slajdu według indeksu.  
3. Utwórz odwołanie do [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) i ustaw je na `None`.  
4. Przejdź przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/), aby odnaleźć odpowiednią tabelę.  
5. Ustaw pierwszy wiersz tabeli jako nagłówek.

Ten kod w języku Python pokazuje, jak ustawić pierwszy wiersz tabeli jako nagłówek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonowanie wiersza lub kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację.  
2. Pobierz odwołanie do slajdu według indeksu.  
3. Zdefiniuj listę szerokości kolumn.  
4. Zdefiniuj listę wysokości wierszy.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) do slajdu metodą [addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable).  
6. Sklonuj wiersz tabeli.  
7. Sklonuj kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Python pokazuje, jak sklonować wiersz lub kolumnę tabeli PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)
    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usuwanie wiersza lub kolumny z tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).  
2. Pobierz odwołanie do slajdu według indeksu.  
3. Zdefiniuj listę szerokości kolumn.  
4. Zdefiniuj listę wysokości wierszy.  
5. Dodaj obiekt [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) do slajdu metodą [addTable](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addTable).  
6. Usuń wiersz tabeli.  
7. Usuń kolumnę tabeli.  
8. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Python pokazuje, jak usunąć wiersz lub kolumnę z tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawianie formatowania tekstu na poziomie wiersza tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację.  
2. Pobierz odwołanie do slajdu według indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) na slajdzie.  
4. Ustaw wysokość czcionki komórek pierwszego wiersza za pomocą [setFontHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ustaw wyrównanie tekstu i prawy margines komórek pierwszego wiersza za pomocą [setAlignment](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setAlignment) oraz [setMarginRight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Ustaw pionowy typ tekstu komórek drugiego wiersza za pomocą [setTextVerticalType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Python demonstruje operację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getRows().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getRows().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getRows().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Ustawianie formatowania tekstu na poziomie kolumny tabeli**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację.  
2. Pobierz odwołanie do slajdu według indeksu.  
3. Uzyskaj dostęp do odpowiedniego obiektu [Table](https://reference.aspose.com/slides/pl/python-java/aspose.slides/table/) na slajdzie.  
4. Ustaw wysokość czcionki komórek pierwszej kolumny za pomocą [setFontHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Ustaw wyrównanie tekstu i prawy margines komórek pierwszej kolumny za pomocą [setAlignment](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setAlignment) oraz [setMarginRight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraphformat/#setMarginRight).  
6. Ustaw pionowy typ tekstu komórek drugiej kolumny za pomocą [setTextVerticalType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setTextVerticalType).  
7. Zapisz zmodyfikowaną prezentację.

Ten kod w języku Python demonstruje operację:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.getColumns().get_Item(0).setTextFormat(portion_format)
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.getColumns().get_Item(0).setTextFormat(paragraph_format)
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.getColumns().get_Item(1).setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Pobieranie właściwości stylu tabeli**

Aspose.Slides umożliwia pobranie właściwości stylu tabeli, aby można było wykorzystać je w innej tabeli lub w innym miejscu. Ten kod w języku Python pokazuje, jak pobrać właściwości stylu z predefiniowanego stylu tabeli:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę zastosować motywy/ style PowerPoint do już istniejącej tabeli?**

Tak. Tabela dziedziczy motyw slajdu/układu/mastera, a jednocześnie można nadpisać wypełnienia, obramowania i kolory tekstu ponad tym motywem.

**Czy mogę sortować wiersze tabeli tak jak w Excelu?**

Nie, tabele Aspose.Slides nie mają wbudowanego sortowania ani filtrów. Posortuj dane w pamięci, a następnie ponownie wypełnij wiersze tabeli w tej kolejności.

**Czy mogę mieć paski (wzory) w kolumnach przy zachowaniu niestandardowych kolorów w wybranych komórkach?**

Tak. Włącz paski w kolumnach, a następnie nadpisz wybrane komórki lokalnym formatowaniem; formatowanie na poziomie komórki ma pierwszeństwo przed stylem tabeli.