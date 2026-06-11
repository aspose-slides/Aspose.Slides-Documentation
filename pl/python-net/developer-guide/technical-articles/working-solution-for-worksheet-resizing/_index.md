---
title: Działające rozwiązanie dla zmiany rozmiaru arkusza
type: docs
weight: 40
url: /pl/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- obraz podglądu
- skalowanie obrazu
- Excel
- arkusz
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Napraw skalowanie OLE arkusza Excel w prezentacjach: dwa sposoby, aby utrzymać ramki obiektów spójne—skalowanie ramki lub arkusza—w formatach PPT i PPTX."
---
{{% alert color="primary" %}} 
Zaobserwowano, że arkusze Excel osadzone jako obiekty OLE w prezentacji PowerPoint przy użyciu komponentów Aspose są skalowane do nieokreślonego rozmiaru po pierwszej aktywacji. To zachowanie powoduje zauważalną różnicę wizualną w prezentacji między stanem przed i po aktywacji obiektu OLE. Zbadaliśmy ten problem szczegółowo i przedstawiliśmy rozwiązanie, które opisano w tym artykule.
{{% /alert %}} 

## **Tło**

W artykule [Zarządzanie OLE](/slides/pl/python-net/manage-ole/) wyjaśniliśmy, jak dodać ramkę OLE do prezentacji PowerPoint przy użyciu Aspose.Slides for Python via .NET. Aby rozwiązać [problem podglądu obiektu](/slides/pl/python-net/object-preview-issue-when-adding-oleobjectframe/), przypisaliśmy obraz wybranego obszaru arkusza do ramki obiektu OLE. W wygenerowanej prezentacji, po dwukrotnym kliknięciu ramki OLE wyświetlającej obraz arkusza, aktywowany jest skoroszyt Excel. Użytkownicy mogą wprowadzać dowolne zmiany w rzeczywistym skoroszycie Excel, a następnie wrócić do slajdu, klikając poza aktywnym skoroszytem Excel. Rozmiar ramki OLE zmieni się po powrocie użytkownika do slajdu. Współczynnik zmiany rozmiaru będzie się różnił w zależności od rozmiaru ramki OLE i osadzonego skoroszytu Excel. 

## **Przyczyna zmiany rozmiaru**

Ponieważ skoroszyt Excel ma własny rozmiar okna, stara się zachować pierwotny rozmiar przy pierwszej aktywacji. Z drugiej strony ramka OLE ma własny rozmiar. Według Microsoftu, gdy skoroszyt Excel jest aktywowany, Excel i PowerPoint negocjują rozmiar, aby zapewnić prawidłowe proporcje w ramach procesu osadzania. Zmiana rozmiaru zachodzi na podstawie różnic między rozmiarem okna Excel a rozmiarem i pozycją ramki OLE. 

## **Rozwiązanie**

Istnieją dwa możliwe rozwiązania, aby uniknąć efektu zmiany rozmiaru.

- Skalowanie rozmiaru ramki OLE w prezentacji PowerPoint tak, aby odpowiadał wysokości i szerokości żądanej liczby wierszy i kolumn w ramce OLE.  
- Utrzymanie stałego rozmiaru ramki OLE i skalowanie rozmiaru uczestniczących wierszy oraz kolumn, aby dopasować je do wybranego rozmiaru ramki OLE.  

### **Skalowanie rozmiaru ramki OLE**

W tym podejściu nauczymy się, jak ustawić rozmiar ramki OLE osadzonego skoroszytu Excel, aby odpowiadał łącznemu rozmiarowi uczestniczących wierszy i kolumn w arkuszu Excel.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu rozmiar ramki OLE zostanie najpierw obliczony na podstawie łącznych wysokości wierszy i szerokości kolumn uczestniczących w skoroszycie. Następnie ustawimy rozmiar ramki OLE na tę obliczoną wartość. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy również obraz pożądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```py
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

```py
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

W tym podejściu nauczymy się, jak skalować wysokości uczestniczących wierszy oraz szerokość uczestniczących kolumn, aby dopasować je do niestandardowego rozmiaru ramki OLE.

Załóżmy, że mamy szablon arkusza Excel i chcemy dodać go do prezentacji jako ramkę OLE. W tym scenariuszu ustawimy rozmiar ramki OLE i skalujemy rozmiar wierszy i kolumn, które uczestniczą w obszarze ramki OLE. Następnie zapiszemy skoroszyt do strumienia, aby zastosować zmiany, i przekonwertujemy go na tablicę bajtów w celu dodania do ramki OLE. Aby uniknąć czerwonego komunikatu „EMBEDDED OLE OBJECT” dla ramki OLE w PowerPoint, przechwycimy również obraz pożądanych fragmentów wierszy i kolumn w skoroszycie i ustawimy go jako obraz ramki OLE.

```py
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

```py
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

```py
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

## **Podsumowanie**

{{% alert color="primary" %}}
Istnieją dwa podejścia do naprawy problemu zmiany rozmiaru arkusza. Wybór odpowiedniego podejścia zależy od konkretnych wymagań i scenariusza użycia. Oba podejścia działają tak samo, niezależnie od tego, czy prezentacje są tworzone z szablonu, czy od zera. Dodatkowo w tym rozwiązaniu nie ma ograniczenia rozmiaru ramki OLE.
{{% /alert %}}