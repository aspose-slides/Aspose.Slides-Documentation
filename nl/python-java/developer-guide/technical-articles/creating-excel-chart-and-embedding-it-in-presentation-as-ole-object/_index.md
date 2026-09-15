---
title: Maak Excel-diagrammen en embed ze in presentaties als OLE-objecten
type: docs
weight: 30
url: /nl/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- diagram insluiten
- OLE-object
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak Excel-diagrammen en embed ze als OLE-objecten in PowerPoint- en OpenDocument-presentaties met Python. Stapsgewijze handleiding met codevoorbeelden."
---
## **Achtergrond**

In PowerPoint is het gebruik van bewerkbare diagrammen om gegevens grafisch weer te geven een gangbare praktijk. Aspose ondersteunt het maken van Excel‑diagrammen met Aspose.Cells for Python via Java, en deze diagrammen kunnen vervolgens als OLE‑objecten in PowerPoint‑dia's worden ingesloten via Aspose.Slides for Python via Java. Dit artikel behandelt de benodigde stappen en biedt een Python‑codevoorbeeld voor het maken van een Excel‑diagram en het insluiten ervan als OLE‑object in een PowerPoint‑presentatie met Aspose.Cells en Aspose.Slides.

## **Benodigde stappen**

1. Maak een Excel‑diagram met Aspose.Cells.
2. Stel de OLE‑grootte van het Excel‑diagram in met Aspose.Cells.
3. Haal een afbeelding van het Excel‑diagram op met Aspose.Cells.
4. Voeg het Excel‑diagram als OLE‑object in een PPTX‑presentatie in met Aspose.Slides.
5. Vervang de afbeelding "EMBEDDED OLE OBJECT" door de afbeelding die in stap 3 is verkregen om het [preview‑probleem van object](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/) op te lossen.
6. Sla de presentatie op schijf in PPTX‑formaat.

## **Implementatie van de benodigde stappen**

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
    # Een array met celnamen.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Een array met celdata.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Voeg een nieuw werkblad toe om cellen met gegevens te vullen.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Vul het gegevensblad met data.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Voeg een diagramblad toe.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Voeg een diagram toe aan het diagramblad met dataseries van het gegevensblad.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Stel het diagramblad in als actief blad.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Beschrijf de werkmap als ingesloten OLE-gegevens.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Maak een werkmap.
workbook = Workbook()

# Voeg een Excel-diagram toe.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Stel de OLE-grootte van het diagram in.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Haal de diagramafbeelding op en sla deze op in een stream.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Sla de werkmap op in een stream.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Maak een presentatie.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg de werkmap toe aan een dia.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Sla de presentatie op schijf.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De presentatie die met de bovenstaande methode wordt aangemaakt bevat het Excel‑diagram als OLE‑object dat geactiveerd kan worden door dubbel te klikken op het OLE‑object‑frame.

## **Conclusie**

Door Aspose.Cells for Python via Java samen met Aspose.Slides for Python via Java te gebruiken, kunnen we elk Excel‑diagram maken dat door Aspose.Cells wordt ondersteund en het diagram als OLE‑object in een PowerPoint‑dia insluiten. De OLE‑grootte van het Excel‑diagram kan ook worden gedefinieerd. Eindgebruikers kunnen vervolgens het Excel‑diagram bewerken zoals elk ander OLE‑object.

## **Gerelateerde secties**

- [Werkende oplossing voor het schalen van diagrammen in PPTX](/slides/nl/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Preview‑probleem van object bij het toevoegen van OleObjectFrame](/slides/nl/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Welke bibliotheken worden gebruikt om het Excel‑diagram te maken en in te sluiten?**

Aspose.Cells for Python via Java maakt het Excel‑diagram, en Aspose.Slides for Python via Java legt het vast als OLE‑object in een PowerPoint‑dia.

**Hoe kunnen gebruikers het ingebedde Excel‑diagram bewerken?**

Gebruikers kunnen dubbelklikken op het OLE‑object‑frame om het diagram te activeren en het te bewerken zoals elk ander OLE‑object.

**Hoe wordt de standaard OLE‑objectpreview vervangen?**

Het voorbeeld haalt een afbeelding van het Excel‑diagram op met Aspose.Cells en gebruikt deze om de afbeelding "EMBEDDED OLE OBJECT" te vervangen.