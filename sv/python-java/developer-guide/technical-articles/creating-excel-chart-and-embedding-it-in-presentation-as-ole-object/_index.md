---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 30
url: /sv/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa Excel-diagram och bädda in dem som OLE-objekt i PowerPoint- och OpenDocument-presentationer med Python. Steg-för-steg-guide med kodexempel."
---
## **Bakgrund**

I PowerPoint är det vanligt att använda redigerbara diagram för att visuellt visa data. Aspose stöder att skapa Excel-diagram med Aspose.Cells för Python via Java, och dessa diagram kan sedan bäddas in som OLE-objekt i PowerPoint‑bilder via Aspose.Slides för Python via Java. Denna artikel beskriver de nödvändiga stegen och ger ett Python‑kodexempel för att skapa ett Excel-diagram och bädda in det som ett OLE‑objekt i en PowerPoint‑presentation med Aspose.Cells och Aspose.Slides.

## **Nödvändiga steg**

Följande sekvens av steg krävs för att skapa och bädda in ett Excel‑diagram som ett OLE‑objekt i en PowerPoint‑bild:

1. Skapa ett Excel‑diagram med Aspose.Cells.  
1. Ange OLE‑storleken för Excel‑diagrammet med Aspose.Cells.  
1. Hämta en bild av Excel‑diagrammet med Aspose.Cells.  
1. Bädda in Excel‑diagrammet som ett OLE‑objekt i en PPTX‑presentation med Aspose.Slides.  
1. Byt ut bilden "EMBEDDED OLE OBJECT" mot bilden som hämtades i steg 3 för att åtgärda [objektförhandsvisningsproblemet](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/).  
1. Spara presentationen till disk i PPTX‑format.

## **Implementering av de nödvändiga stegen**

Python‑implementeringen av ovanstående steg är följande:

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
    # En matris av cellnamn.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # En matris av cellvärden.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Lägg till ett nytt kalkylblad för att fylla celler med data.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Fyll databladet med data.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Lägg till ett diagramblad.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Lägg till ett diagram på diagrambladet med dataserier från databladet.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Ställ in diagrambladet som aktivt blad.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Beskriv arbetsboken som inbäddad OLE-data.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Skapa en arbetsbok.
workbook = Workbook()

# Lägg till ett Excel-diagram.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Ange OLE-storleken för diagrammet.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Hämta diagrammets bild och spara den till en ström.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Spara arbetsboken till en ström.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Skapa en presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till arbetsboken på en bild.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Spara presentationen till disk.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Presentation som skapas med metoden ovan kommer att innehålla Excel‑diagrammet som ett OLE‑objekt som kan aktiveras genom att dubbelklicka på OLE‑objektets ram.

## **Slutsats**

Genom att använda Aspose.Cells för Python via Java tillsammans med Aspose.Slides för Python via Java kan vi skapa vilket Excel‑diagram som helst som stöds av Aspose.Cells och bädda in diagrammet som ett OLE‑objekt i en PowerPoint‑bild. OLE‑storleken för Excel‑diagrammet kan också definieras. Slutanvändare kan sedan redigera Excel‑diagrammet precis som vilket annat OLE‑objekt som helst.

## **Relaterade avsnitt**

- [Fungerande lösning för diagramändring i PPTX](/slides/sv/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problem med objektförhandsvisning när OleObjectFrame läggs till](/slides/sv/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Vilka bibliotek används för att skapa och bädda in Excel‑diagrammet?**

Aspose.Cells för Python via Java skapar Excel‑diagrammet, och Aspose.Slides för Python via Java bäddar in det som ett OLE‑objekt i en PowerPoint‑bild.

**Hur kan användare redigera det inbäddade Excel‑diagrammet?**

Användare kan dubbelklicka på OLE‑objektets ram för att aktivera diagrammet och redigera det som vilket annat OLE‑objekt som helst.

**Hur ersätts standard‑förhandsvisningen för OLE‑objektet?**

Exemplet hämtar en bild av Excel‑diagrammet med Aspose.Cells och använder den för att ersätta bilden "EMBEDDED OLE OBJECT".