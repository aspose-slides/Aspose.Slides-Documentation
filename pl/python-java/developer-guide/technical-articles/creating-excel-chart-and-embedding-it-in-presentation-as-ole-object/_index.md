---
title: Utwórz wykresy Excel i osadź je w prezentacjach jako obiekty OLE
type: docs
weight: 30
url: /pl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- wykres Excel
- osadzanie wykresu
- obiekt OLE
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Utwórz wykresy Excel i osadź je jako obiekty OLE w prezentacjach PowerPoint i OpenDocument przy użyciu Pythona. Przewodnik krok po kroku z przykładami kodu."
---
## **Tło**

W PowerPoint użycie edytowalnych wykresów do graficznego przedstawiania danych jest powszechną praktyką. Aspose wspiera tworzenie wykresów Excel za pomocą Aspose.Cells for Python via Java, a te wykresy mogą być następnie osadzane jako obiekty OLE na slajdach PowerPoint przy użyciu Aspose.Slides for Python via Java. Ten artykuł opisuje niezbędne kroki i zawiera przykładowy kod w języku Python, który tworzy wykres Excel i osadza go jako obiekt OLE w prezentacji PowerPoint przy użyciu Aspose.Cells i Aspose.Slides.

## **Wymagane kroki**

1. Utwórz wykres Excel przy użyciu Aspose.Cells.
1. Ustaw rozmiar OLE wykresu Excel przy użyciu Aspose.Cells.
1. Uzyskaj obraz wykresu Excel za pomocą Aspose.Cells.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides.
1. Zamień obraz "EMBEDDED OLE OBJECT" na obraz uzyskany w kroku 3, aby rozwiązać problem [problem podglądu obiektu](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Zapisz prezentację na dysku w formacie PPTX.

## **Implementacja wymaganych kroków**

Implementacja w języku Python powyższych kroków wygląda następująco:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Tablica nazw komórek.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Tablica danych komórek.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Dodaj nowy arkusz, aby wypełnić komórki danymi.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Wypełnij arkusz danymi.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Dodaj arkusz wykresu.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Dodaj wykres do arkusza wykresu z seriami danych z arkusza danych.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Ustaw arkusz wykresu jako aktywny arkusz.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Opisz skoroszyt jako osadzony obiekt OLE.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Utwórz skoroszyt.
workbook = Workbook()

# Dodaj wykres Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Ustaw rozmiar OLE wykresu.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Pobierz obraz wykresu i zapisz go do strumienia.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Zapisz skoroszyt do strumienia.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Utwórz prezentację.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj skoroszyt do slajdu.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Zapisz prezentację na dysku.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prezentacja utworzona przy użyciu powyższej metody będzie zawierać wykres Excel jako obiekt OLE, który można aktywować podwójnym kliknięciem ramki obiektu OLE.

## **Wnioski**

Używając Aspose.Cells for Python via Java w połączeniu z Aspose.Slides for Python via Java, możemy tworzyć dowolny wykres Excel obsługiwany przez Aspose.Cells i osadzać go jako obiekt OLE na slajdzie PowerPoint. Rozmiar OLE wykresu Excel może także być określony. Końcowi użytkownicy mogą następnie edytować wykres Excel tak jak każdy inny obiekt OLE.

## **Powiązane sekcje**

- [Działające rozwiązanie dla zmiany rozmiaru wykresu w PPTX](/slides/pl/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problem podglądu obiektu przy dodawaniu OleObjectFrame](/slides/pl/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Jakie biblioteki są używane do tworzenia i osadzania wykresu Excel?**

Aspose.Cells for Python via Java tworzy wykres Excel, a Aspose.Slides for Python via Java osadza go jako obiekt OLE w slajdzie PowerPoint.

**Jak użytkownicy mogą edytować osadzony wykres Excel?**

Użytkownicy mogą podwójnie kliknąć ramkę obiektu OLE, aby aktywować wykres i edytować go tak jak każdy inny obiekt OLE.

**Jak zastąpiony jest domyślny podgląd obiektu OLE?**

Przykład uzyskuje obraz wykresu Excel za pomocą Aspose.Cells i używa go do zastąpienia obrazu „EMBEDDED OLE OBJECT”.