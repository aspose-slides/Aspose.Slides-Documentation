---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
type: docs
weight: 20
url: /pl/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- skalowanie obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Napraw skalowanie OLE arkusza Excel w prezentacjach: dwa sposoby na utrzymanie spójności ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Uwaga" %}}

Zaobserwowano, że arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint za pośrednictwem komponentów Aspose są skalowane do nieokreślonej wielkości po pierwszej aktywacji. Zachowanie to powoduje widoczną różnicę wizualną w prezentacji między stanem przed i po aktywacji obiektu OLE. Zbadaliśmy ten problem szczegółowo i przedstawiliśmy rozwiązanie, które opisano w tym artykule.

{{% /alert %}}

## **Tło**

W artykule [Zarządzanie OLE](/slides/pl/python-java/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for Python via Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki OLE. W prezentacji wyjściowej, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywnym skoroszytem. Rozmiar ramki OLE zmieni się, gdy użytkownik powróci do slajdu. Współczynnik skalowania będzie się różnił w zależności od rozmiaru ramki OLE i osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować swój pierwotny rozmiar po pierwszej aktywacji. Z drugiej strony ramka OLE ma własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby utrzymać prawidłowe proporcje w ramach procesu osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i pozycją ramki OLE.

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj rozmiar ramki OLE w prezentacji PowerPoint, aby dopasować wysokość i szerokość do żądanej liczby wierszy i kolumn w ramce OLE.  
- Utrzymaj stały rozmiar ramki OLE i skaluj rozmiar uczestniczących wierszy oraz kolumn, aby pasowały do wybranego rozmiaru ramki OLE.

### **Skalowanie rozmiaru ramki OLE**

W tym podejściu nauczymy się ustawiać rozmiar ramki OLE osadzonego skoroszytu Excel tak, aby odpowiadał łącznemu rozmiarowi uczestniczących wierszy i kolumn w arkuszu Excel.

Załóżmy, że posiadamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu rozmiar ramki OLE zostanie najpierw obliczony na podstawie łącznych wysokości wierszy i szerokości kolumn uczestniczących w skoroszycie. Następnie ustawimy rozmiar ramki OLE na tę obliczoną wartość. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy także obraz żądanych części wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Ustaw wyświetlany rozmiar, gdy skoroszyt jest używany jako obiekt OLE w PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Pobierz szerokość i wysokość obrazu OLE w punktach.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Użyj zmodyfikowanego skoroszytu.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Dodaj obraz OLE do zasobów prezentacji.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Utwórz ramkę obiektu OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Skalowanie zakresu komórek**

W tym podejściu nauczymy się skalować wysokości uczestniczących wierszy oraz szerokości uczestniczących kolumn, aby pasowały do niestandardowego rozmiaru ramki OLE.

Załóżmy, że posiadamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu ustawimy rozmiar ramki OLE i skalujemy rozmiar wierszy oraz kolumn, które uczestniczą w obszarze ramki OLE. Następnie zapisujemy skoroszyt do strumienia, aby zastosować zmiany, i konwertujemy go na tablicę bajtów w celu dodania go do ramki OLE. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy także obraz żądanych części wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # Oczekiwana szerokość i wysokość zakresu komórek podawana jest w punktach.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Ustaw wyświetlany rozmiar, gdy skoroszyt jest używany jako obiekt OLE w PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Skaluj zakres komórek, aby dopasować go do rozmiaru ramki.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Użyj zmodyfikowanego skoroszytu.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Dodaj obraz OLE do zasobów prezentacji.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Utwórz ramkę obiektu OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Wniosek**

{{% alert color="info" title="Uwaga" %}} 

Istnieją dwa podejścia do rozwiązania problemu zmiany rozmiaru arkusza. Wybór odpowiedniego podejścia zależy od konkretnych wymagań i scenariusza użycia. Oba podejścia działają identycznie, niezależnie od tego, czy prezentacje są tworzone od szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma ograniczenia co do rozmiaru ramki OLE.

{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może prowadzić do zmiany rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE tak, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do żądanej ramki OLE, można zapobiec niepożądanej zmianie rozmiaru.

**Którą metodę skalowania powinienem użyć, skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli potrzebny jest stały rozmiar ramki OLE w prezentacji.

**Czy te rozwiązania działają, jeśli moja prezentacja jest oparta na szablonie?**

Tak. Obydwa rozwiązania działają zarówno dla prezentacji tworzonych na podstawie szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy stosowaniu tych metod?**

Nie. Możesz ustawić ramkę OLE na dowolny rozmiar, o ile odpowiednio ustawisz skalowanie.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**

Tak. Przechwytując migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, możesz wyświetlić własny podgląd zamiast domyślnego tekstu zastępczego.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)