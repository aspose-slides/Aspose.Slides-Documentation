---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
type: docs
weight: 20
url: /pl/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Napraw zmianę rozmiaru arkusza Excel OLE w prezentacjach: dwa sposoby, aby utrzymać ramki obiektów spójne — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Note" %}}

Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmienić rozmiar po pierwszej aktywacji. To zachowanie powoduje wyraźną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby jego rozwiązania.

{{% /alert %}}

## **Tło**

W artykule [Zarządzanie OLE](/slides/pl/python-java/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for Python via Java. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzać dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie powrócić do slajdu, klikając poza aktywnym skoroszytem Excel. Rozmiar ramki obiektu OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie zależał od rozmiaru ramki obiektu OLE oraz osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować swój pierwotny rozmiar przy pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własne wymiary. Według Microsoftu, po aktywacji skoroszytu Excel, Excel i PowerPoint negocjują rozmiar, aby zapewnić prawidłowe proporcje w ramach procesu osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i położeniem ramki obiektu OLE.

## **Rozwiązanie**

Istnieją dwa możliwe sposoby, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby odpowiadała łącznej wysokości i szerokości wybranych wierszy i kolumn.
- Zachowaj stały rozmiar ramki OLE i skaluj wybrane wiersze oraz kolumny, aby pasowały do niej.

### **Skalowanie rozmiaru ramki OLE**

To podejście ustawia rozmiar ramki OLE tak, aby odpowiadał łącznej wysokości i szerokości wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn jego pierwszego arkusza za pomocą indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiuje wyświetlany zakres. Podgląd jest renderowany w 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisany przez [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), aby zastąpić placeholder „EMBEDDED OLE OBJECT” w zapisanej prezentacji.

Pomocnik podglądu ustawia [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) na wybrany zakres i usuwa marginesy, nagłówki oraz stopki. Z włączoną opcją [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea), [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) renderuje zakres jako obraz PNG. Pomocnik zwraca nowy strumień wejściowy zawierający obraz PNG, ustawiony na początek, gotowy do użycia w prezentacji.

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

### **Skalowanie rozmiaru zakresu komórek**

To podejście skaluje wysokości wybranych wierszy i szerokości wybranych kolumn, aby pasowały do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn jego pierwszego arkusza za pomocą indeksów zerowych. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definiuje wyświetlany zakres, a pomocnik scale_cell_range skaluje ten zakres, aby zmieścił się w ramce o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do strumienia, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) osadza go w określonym rozmiarze. Podgląd renderowany w 96 DPI jest przypisany przez [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego placeholdera.

Pomocnik skalowania oblicza oddzielne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości kolumn i względne wysokości wierszy. Przekształca obliczone wymiary z punktów na cale przed zastosowaniem ich przy użyciu [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) i [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). Wybrany zakres musi mieć niezerową szerokość i wysokość.

Ten pomocnik podglądu renderuje przeskalowany zakres przy użyciu [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Ogranicza [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) do tego zakresu, usuwa marginesy, nagłówki oraz stopki i zwraca strumień PNG ustawiony na początek.

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
    # Oczekiwana szerokość i wysokość zakresu komórek podana jest w punktach.
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

## **Wnioski**

{{% alert color="info" title="Note" %}} 

Istnieją dwa podejścia, aby naprawić problem zmiany rozmiaru arkusza. Wybierz to, które najlepiej odpowiada Twoim wymaganiom i przypadkowi użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od zera. Dodatkowo w tym rozwiązaniu nie ma ograniczenia rozmiaru ramki obiektu OLE.

{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel stara się zachować pierwotny rozmiar okna po aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do żądanej ramki OLE, można uniknąć niepożądanej zmiany rozmiaru.

**Którą metodę skalowania powinienem użyć, skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania będą działać, jeśli moja prezentacja opiera się na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje ograniczenie rozmiaru ramki OLE przy użyciu tych metod?**

Nie. Możesz ustawić dowolny rozmiar ramki obiektu OLE, pod warunkiem odpowiedniego skalowania.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego "EMBEDDED OLE OBJECT" w PowerPoint?**

Tak. Pobierając migawkę docelowego zakresu komórek Excel i ustawiając ją jako obraz zastępczy ramki OLE, możesz wyświetlić własny obraz podglądu zamiast domyślnego placeholdera.

## **Powiązane artykuły**

[Tworzenie wykresu Excel i osadzanie go w prezentacji jako obiekt OLE](/slides/pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Automatyczna aktualizacja obiektów OLE przy użyciu dodatku MS PowerPoint](/slides/pl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)