---
title: Excel-Diagramme erstellen und in Präsentationen als OLE-Objekte einbetten
type: docs
weight: 30
url: /de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Python über Java und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides ein, einschließlich einer Diagramm‑Vorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells für Python über Java erstellt und dessen Arbeitsmappe in einer PowerPoint‑Präsentation mit Aspose.Slides für Python über Java einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Installieren Sie die Python‑Pakete `aspose-cells` und `aspose-slides-java` sowie ein kompatibles Java‑Runtime. Importieren Sie beide Pakete, bevor die JVM gestartet wird, damit deren Java‑Bibliotheken für JPype verfügbar sind. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erzeugt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluierungsmodus arbeiten.

## **Wie die Einbettung funktioniert**

1. Erzeugen Sie eine Arbeitsmappe mit einem Daten‑Arbeitsblatt und einem Diagrammblatt.
2. Machen Sie das Diagrammblatt aktiv, damit die Arbeitsmappe mit dem Diagramm geöffnet wird.
3. Setzen Sie den OLE‑Anzeigebereich der Arbeitsmappe und rendern Sie das Diagramm zu PNG.
4. Speichern Sie die Arbeitsmappe im Speicher als XLSX und betten Sie diese Bytes in eine Folie ein.
5. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) verwendet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) hingegen verwendet die obere Zeile, linke Spalte, untere Zeile und rechte Spalte. Das Beispiel verwendet Zeilenindex 55 und Spaltenindex 25 als rechte untere Grenze; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu dehnen, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Das folgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagramm‑Serie. `ChartSheet` wird vor dem Speichern der Arbeitsmappe als aktives Blatt ausgewählt.

Die Arbeitsmappe wird ausdrücklich als XLSX gespeichert, wobei die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) übergebene Erweiterung `xlsx` übereinstimmt. Java‑Byte‑Array‑Streams halten die Arbeitsmappe und das Bild im Speicher und stellen die für die Java‑APIs erforderlichen Byte‑Arrays bereit. Das PNG wird direkt aus seinen Bytes geladen, ohne eine Zwischen‑Bitmap‑Konvertierung. Die Zuweisung über [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ersetzt den Standard‑OLE‑Platzhalter.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Rendern Sie die Diagrammvorschau und serialisieren Sie die bearbeitbare Arbeitsmappe separat.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Passen Sie die Vorschau innerhalb der Folie an, ohne das Seitenverhältnis zu ändern.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagramm‑Vorschau. Die Arbeitsmappe enthält die Originaldaten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel‑Säulendiagramm, angezeigt als Vorschau einer eingebetteten Arbeitsmappe](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel kann man das Objekt doppelklicken, um die eingebettete Arbeitsmappe zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des Standard‑„EMBEDDED OLE OBJECT“-Platzhalters anzeigt. Siehe [Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Momentaufnahme. Beim programmgesteuerten Aktualisieren der Arbeitsmappendaten müssen Sie das Diagrammbild neu erzeugen und sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten ersetzen.

**Kann ich XLS statt XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das alleinige Ändern der Erweiterung konvertiert die Daten nicht.

**Warum könnte das Objekt nach der Aktivierung seine Größe ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Der OLE‑Anzeigebereich der Arbeitsmappe und die Abmessungen des Folienrahmens sind beide relevant. Siehe [Lösungsansatz für Diagrammgrößenänderung in PPTX](/slides/de/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Lösungsansatz für Diagrammgrößenänderung in PPTX](/slides/de/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/)