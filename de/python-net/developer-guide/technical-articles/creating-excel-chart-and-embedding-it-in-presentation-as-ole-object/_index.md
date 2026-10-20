---
title: Excel-Diagramme erstellen und in Präsentationen als OLE-Objekte einbetten
type: docs
weight: 50
url: /de/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- Python
- Python via .NET
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Python via .NET und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides ein, einschließlich einer Diagramm-Vorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells für Python via .NET erstellt und dessen Arbeitsmappe in einer PowerPoint‑Präsentation mit Aspose.Slides für Python via .NET einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Installieren Sie die Pakete `aspose-cells-python` und `aspose-slides` in Ihrer Python‑Umgebung. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erstellt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluationsmodus arbeiten.

## **Wie die Einbettung funktioniert**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Worksheet und einem Diagramm‑Sheet.  
1. Aktivieren Sie das Diagramm‑Sheet, damit die Arbeitsmappe beim Öffnen das Diagramm anzeigt.  
1. Legen Sie den OLE‑Anzeigebereich der Arbeitsmappe fest und rendern Sie das Diagramm als PNG.  
1. Speichern Sie die Arbeitsmappe im Speicher als XLSX und betten Sie diese Bytes in eine Folie ein.  
1. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) verwendet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) verwendet dagegen die oberste Zeile, linke Spalte, unterste Zeile und rechte Spalte. Das Beispiel verwendet den Zeilenindex 55 und den Spaltenindex 25 als recht‑untere Grenzen; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Das folgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagramm‑Serie. `ChartSheet` wird als aktives Sheet ausgewählt, bevor die Arbeitsmappe gespeichert wird.

Die Arbeitsmappe wird explizit als XLSX gespeichert, passend zur `xlsx`‑Erweiterung, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) übergeben wird. Das PNG wird direkt aus seinem Stream geladen, ohne eine Zwischenumwandlung in ein Bitmap. Die Zuweisung über [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) ersetzt den standardmäßigen OLE‑Platzhalter.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Diagrammvorschau rendern und die bearbeitbare Arbeitsmappe separat serialisieren.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Vorschau innerhalb der Folie anpassen, ohne das Seitenverhältnis zu ändern.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagrammvorschau. Die Arbeitsmappe enthält die Originaldaten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel‑Säulendiagramm, angezeigt als Vorschau einer eingebetteten Arbeitsmappe](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel können Sie das Objekt doppelklicken, um die eingebettete Arbeitsmappe zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschau‑Bild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des standardmäßigen Platzhalters „EMBEDDED OLE OBJECT“ anzeigt. Siehe [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Momentaufnahme. Wenn Sie Arbeitsmappendaten programmgesteuert aktualisieren, erzeugen Sie das Diagrammbild erneut und ersetzen sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das alleinige Ändern der Erweiterung konvertiert die Daten nicht.

**Warum könnte das Objekt nach der Aktivierung die Größe ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, sobald sie die Arbeitsmappe aktiviert. Der OLE‑Anzeigebereich der Arbeitsmappe und die Abmessungen des Folienrahmens sind beide relevant. Siehe [OLE‑Objekte in PowerPoint‑Präsentationen automatisch skalieren](/slides/de/python-net/working-solution-for-worksheet-resizing/).

## **Verwandte Abschnitte**

- [OLE‑Objekte in PowerPoint‑Präsentationen automatisch skalieren](/slides/de/python-net/working-solution-for-worksheet-resizing/)
- [Problem mit der Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE‑Objekte verwalten](/slides/de/python-net/manage-ole/)