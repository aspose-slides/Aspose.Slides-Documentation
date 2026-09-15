---
title: Erstellen von Excel-Diagrammen und Einbetten als OLE-Objekte in Präsentationen
type: docs
weight: 30
url: /de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie Excel-Diagramme und betten Sie diese als OLE-Objekte in PowerPoint- und OpenDocument-Präsentationen mit Python ein. Schritt-für-Schritt-Anleitung mit Codebeispielen."
---
## **Hintergrund**

In PowerPoint ist die Verwendung bearbeitbarer Diagramme zur grafischen Darstellung von Daten gängige Praxis. Aspose unterstützt das Erstellen von Excel‑Diagrammen mit Aspose.Cells für Python via Java, und diese Diagramme können anschließend als OLE‑Objekte in PowerPoint‑Folien über Aspose.Slides für Python via Java eingebettet werden. Dieser Artikel beschreibt die notwendigen Schritte und liefert ein Python‑Codebeispiel zum Erstellen eines Excel‑Diagramms und zum Einbetten als OLE‑Objekt in eine PowerPoint‑Präsentation mit Aspose.Cells und Aspose.Slides.

## **Erforderliche Schritte**

Die folgende Schrittfolge ist erforderlich, um ein Excel‑Diagramm als OLE‑Objekt in einer PowerPoint‑Folie zu erstellen und einzubetten:

1. Erstellen Sie ein Excel‑Diagramm mit Aspose.Cells.
1. Legen Sie die OLE‑Größe des Excel‑Diagramms mit Aspose.Cells fest.
1. Erfassen Sie ein Bild des Excel‑Diagramms mit Aspose.Cells.
1. Betten Sie das Excel‑Diagramm als OLE‑Objekt in eine PPTX‑Präsentation mit Aspose.Slides ein.
1. Ersetzen Sie das Bild „EMBEDDED OLE OBJECT“ durch das in Schritt 3 erhaltene Bild, um das [Objektvorschau-Problem](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben.
1. Speichern Sie die Präsentation auf dem Datenträger im PPTX‑Format.

## **Umsetzung der erforderlichen Schritte**

Die Python‑Umsetzung der obigen Schritte lautet wie folgt:

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
    # Ein Array von Zellnamen.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Ein Array von Zellwerten.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Ein neues Arbeitsblatt hinzufügen, um Zellen mit Daten zu füllen.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Das Datenblatt mit Daten füllen.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Ein Diagrammblatt hinzufügen.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Ein Diagramm zum Diagrammblatt hinzufügen, wobei die Datenreihen aus dem Datenblatt stammen.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Das Diagrammblatt als aktives Blatt festlegen.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Das Arbeitsbuch als eingebettete OLE-Daten beschreiben.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Ein Arbeitsbuch erstellen.
workbook = Workbook()

# Ein Excel-Diagramm hinzufügen.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Die OLE-Größe des Diagramms festlegen.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Das Diagrammbild holen und in einen Stream speichern.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Das Arbeitsbuch in einen Stream speichern.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Eine Präsentation erstellen.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Das Arbeitsbuch zu einer Folie hinzufügen.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Die Präsentation auf dem Datenträger speichern.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die durch die oben genannte Methode erstellte Präsentation enthält das Excel‑Diagramm als OLE‑Objekt, das durch Doppelklicken auf den OLE‑Objekt‑Rahmen aktiviert werden kann.

## **Fazit**

Durch die Kombination von Aspose.Cells für Python via Java mit Aspose.Slides für Python via Java können wir jedes von Aspose.Cells unterstützte Excel‑Diagramm erstellen und das Diagramm als OLE‑Objekt in eine PowerPoint‑Folie einbetten. Die OLE‑Größe des Excel‑Diagramms kann ebenfalls definiert werden. Endbenutzer können das Excel‑Diagramm dann wie jedes andere OLE‑Objekt bearbeiten.

## **Verwandte Abschnitte**

- [Funktionsfähige Lösung für die Diagrammgrößenänderung in PPTX](/slides/de/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Welche Bibliotheken werden zum Erstellen und Einbetten des Excel‑Diagramms verwendet?**

Aspose.Cells für Python via Java erstellt das Excel‑Diagramm, und Aspose.Slides für Python via Java bettet es als OLE‑Objekt in eine PowerPoint‑Folie ein.

**Wie können Benutzer das eingebettete Excel‑Diagramm bearbeiten?**

Benutzer können den OLE‑Objekt‑Rahmen doppelklicken, um das Diagramm zu aktivieren und es wie jedes andere OLE‑Objekt zu bearbeiten.

**Wie wird die Standard‑OLE‑Objekt‑Vorschau ersetzt?**

Das Beispiel erzeugt ein Bild des Excel‑Diagramms mit Aspose.Cells und verwendet es, um das Bild „EMBEDDED OLE OBJECT“ zu ersetzen.