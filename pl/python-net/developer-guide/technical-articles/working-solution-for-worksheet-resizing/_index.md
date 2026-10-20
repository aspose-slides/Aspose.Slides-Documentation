---
title: Rozwiązanie działające dla zmiany rozmiaru arkusza
type: docs
weight: 40
url: /pl/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- zmiana rozmiaru obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Napraw zmianę rozmiaru OLE arkusza Excel w prezentacjach: dwa sposoby utrzymania spójności ramek obiektów — skalowanie ramki lub arkusza — w formatach PPT i PPTX."
---
{{% alert color="info" title="Note" %}}

Arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose mogą nieoczekiwanie zmienić rozmiar po pierwszej aktywacji. Zachowanie to powoduje zauważalną różnicę wizualną między obiektem OLE przed i po aktywacji. Ten artykuł wyjaśnia problem i opisuje dwa sposoby jego rozwiązania.

{{% /alert %}} 

## **Tło**

W artykule [Zarządzanie OLE](/slides/pl/python-net/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for Python via .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W prezentacji wyjściowej, po dwukrotnym kliknięciu ramki obiektu OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzić dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywowanym skoroszytem. Rozmiar ramki obiektu OLE zmieni się, gdy użytkownik wróci do slajdu. Współczynnik zmiany rozmiaru będzie zależał od rozmiaru ramki obiektu OLE oraz osadzonego skoroszytu Excel.

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, próbuje zachować pierwotny rozmiar po pierwszej aktywacji. Z drugiej strony ramka obiektu OLE ma własne wymiary. Według Microsoft, po aktywacji skoroszytu Excel, Excel i PowerPoint negocjują rozmiar, aby zapewnić prawidłowe proporcje w procesie osadzania. Zmiana rozmiaru zachodzi w oparciu o różnice między rozmiarem okna Excel a rozmiarem i pozycją ramki obiektu OLE.

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skaluj ramkę OLE w prezentacji PowerPoint, aby dopasować ją do łącznej wysokości i szerokości wybranych wierszy i kolumn.
- Zachowaj stały rozmiar ramki OLE i skaluj wybrane wiersze i kolumny, aby zmieściły się w niej.

### **Skalowanie rozmiaru ramki OLE**

To podejście ustawia rozmiar ramki OLE tak, aby odpowiadał łącznej wysokości i szerokości wybranych wierszy i kolumn w osadzonym arkuszu Excel.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza przy użyciu indeksów zerowych. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiuje wyświetlany zakres. Podgląd jest renderowany w 96 DPI, a jego wymiary w pikselach są konwertowane na punkty przy użyciu 72 punktów na cal. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) osadza zmodyfikowany skoroszyt w ramce o tych wymiarach. Podgląd jest przypisywany przez [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) w celu zastąpienia tekstu zastępczego „EMBEDDED OLE OBJECT” w zapisywanej prezentacji.

Pomocniczy kod podglądu ustawia [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) na wybrany zakres i usuwa marginesy, nagłówki oraz stopki. Przy włączonym [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) renderuje zakres jako obraz PNG. Pomocnik przewija strumień obrazu przed jego zwróceniem do użycia w prezentacji.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Pełny przykład poniżej łączy pomocniki z osadzaniem skoroszytu i zapisuje prezentację jako `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Pobierz szerokość i wysokość obrazu OLE w punktach.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Musimy użyć zmodyfikowanego skoroszytu.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Dodaj obraz OLE do zasobów prezentacji.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Utwórz ramkę obiektu OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Skalowanie rozmiaru zakresu komórek**

To podejście skaluje wysokość wybranych wierszy i szerokość wybranych kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Przykład ładuje istniejący skoroszyt Excel i wybiera pierwsze 10 wierszy oraz 13 kolumn pierwszego arkusza przy użyciu indeksów zerowych. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) definiuje wyświetlany zakres, a poniższy pomocnik skaluje ten zakres, aby zmieścił się w ramce o szerokości 400 punktów i wysokości 100 punktów. Po zapisaniu zmodyfikowanego skoroszytu do strumienia, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) osadza go w określonym rozmiarze. Podgląd renderowany w 96 DPI jest przypisywany przez [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), dzięki czemu zapisana prezentacja wyświetla wybrane komórki zamiast domyślnego zamiennika.

Pomocnik skalujący oblicza osobne współczynniki szerokości i wysokości dla wybranego zakresu, zachowując względne szerokości jego kolumn oraz względne wysokości jego wierszy. Przekształca obliczone wymiary z punktów na cale przed zastosowaniem ich przy pomocy [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) i [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). Wybrany zakres musi mieć niezerową szerokość i wysokość.

```py
import aspose.cells as cells

# <param name="width">Oczekiwana szerokość zakresu komórek w punktach.</param>
# <param name="height">Oczekiwana wysokość zakresu komórek w punktach.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Ten pomocnik podglądu renderuje zmieniony rozmiar zakresu przy użyciu [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Ogranicza [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) do tego zakresu, usuwa marginesy, nagłówki i stopki oraz zwraca strumień PNG ustawiony na początek.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

Pełny przykład poniżej łączy pomocniki z osadzaniem skoroszytu i zapisuje prezentację jako `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">Oczekiwana szerokość zakresu komórek w punktach.</param>
# <param name="height">Oczekiwana wysokość zakresu komórek w punktach.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Ustaw wyświetlany rozmiar, gdy plik skoroszytu jest używany jako obiekt OLE w PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Skaluj zakres komórek, aby dopasować go do rozmiaru ramki.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Musimy użyć zmodyfikowanego skoroszytu.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Dodaj obraz OLE do zasobów prezentacji.
            ole_image = presentation.images.add_image(image_stream)

            # Utwórz ramkę obiektu OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Wnioski**

{{% alert color="info" title="Note" %}}

Istnieją dwa podejścia, aby naprawić problem zmiany rozmiaru arkusza. Wybierz podejście, które najlepiej odpowiada Twoim wymaganiom i scenariuszowi użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od podstaw. Dodatkowo w tym rozwiązaniu nie ma ograniczeń co do wielkości ramki obiektu OLE.

{{% /alert %}}

## **FAQ**

**Dlaczego osadzony arkusz Excel zmienia rozmiar po pierwszej aktywacji w PowerPoint?**

Dzieje się tak, ponieważ Excel próbuje zachować oryginalny rozmiar okna przy aktywacji, podczas gdy ramka obiektu OLE w PowerPoint ma własne wymiary. PowerPoint i Excel negocjują rozmiar, aby utrzymać proporcje, co może powodować zmianę rozmiaru.

**Czy można całkowicie zapobiec temu problemowi ze zmianą rozmiaru?**

Tak. Skalując ramkę OLE, aby pasowała do rozmiaru zakresu komórek Excel, lub skalując zakres komórek, aby pasował do pożądanego rozmiaru ramki OLE, można uniknąć niepożądanej zmiany rozmiaru.

**Którą metodę skalowania powinienem wybrać, skalowanie ramki OLE czy skalowanie zakresu komórek?**

Wybierz **skalowanie ramki OLE**, jeśli chcesz zachować oryginalne rozmiary wierszy i kolumn w Excelu. Wybierz **skalowanie zakresu komórek**, jeśli potrzebujesz stałego rozmiaru ramki OLE w prezentacji.

**Czy te rozwiązania działają, jeśli moja prezentacja oparta jest na szablonie?**

Tak. Oba rozwiązania działają zarówno dla prezentacji tworzonych z szablonów, jak i od podstaw.

**Czy istnieje limit rozmiaru ramki OLE przy użyciu tych metod?**

Nie. Możesz ustawić dowolny rozmiar ramki obiektu OLE, o ile odpowiednio skalujesz.

**Czy istnieje sposób, aby uniknąć tekstu zastępczego „EMBEDDED OLE OBJECT” w PowerPoint?**

Tak. Tworząc zrzut wybranego zakresu komórek Excel i ustawiając go jako obraz zastępczy ramki OLE, możesz wyświetlić własny obraz podglądu zamiast domyślnego tekstu zastępczego.