---
title: Erstellen von Excel‑Diagrammen und Einbetten in Präsentationen als OLE‑Objekte
type: docs
weight: 30
url: /de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel‑Diagramm
- Diagramm einbetten
- OLE‑Objekt
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen Sie ein Excel‑Diagramm mit Aspose.Cells für Java und betten Sie die Arbeitsmappe in eine PowerPoint‑Präsentation mit Aspose.Slides ein, einschließlich einer Diagrammvorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells for Java erstellt und seine Arbeitsmappe in eine PowerPoint‑Präsentation mit Aspose.Slides for Java einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Fügen Sie Aspose.Cells for Java und Aspose.Slides for Java zu den Projektabhängigkeiten hinzu. Führen Sie das Beispiel innerhalb einer Java‑Methode aus. Microsoft Office wird nicht benötigt, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erstellt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluierungsmodus arbeiten.

## **So funktioniert das Einbetten**

1. Erstellen Sie eine Arbeitsmappe mit einem Datenarbeitsblatt und einem Diagrammblatt.  
2. Aktivieren Sie das Diagrammblatt, damit die Arbeitsmappe beim Öffnen das Diagramm anzeigt.  
3. Setzen Sie den OLE-Anzeigebereich der Arbeitsmappe und rendern Sie das Diagramm zu PNG.  
4. Speichern Sie die Arbeitsmappe im Speicher als XLSX und betten Sie diese Bytes in eine Folie ein.  
5. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) verwendet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) hingegen verwendet die obere Zeile, die linke Spalte, die untere Zeile und die rechte Spalte. Das Beispiel verwendet Zeilenindex 55 und Spaltenindex 25 als rechts‑untere Grenzen; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Das nachstehende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammreihe. `ChartSheet` wird als aktives Blatt ausgewählt, bevor die Arbeitsmappe gespeichert wird.

Die Arbeitsmappe wird explizit als XLSX gespeichert, wobei die `xlsx`‑Erweiterung verwendet wird, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) übergeben wird. Das PNG wird direkt aus seinen Bytes geladen, ohne eine Zwischenumwandlung in ein Bitmap. Die Zuweisung über [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ersetzt den Standard‑OLE‑Platzhalter.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // Diagrammvorschau rendern und die editierbare Arbeitsmappe separat serialisieren.
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // Vorschau innerhalb der Folie anpassen, ohne das Seitenverhältnis zu ändern.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagrammvorschau. Die Arbeitsmappe enthält die ursprünglichen Daten und ein Säulendiagramm mit vier Reihen. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel‑Säulendiagramm, das als Vorschau einer eingebetteten Arbeitsmappe angezeigt wird](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel können Sie das Objekt doppelklicken, um die eingebettete Arbeitsmappe zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des standardmäßigen "EMBEDDED OLE OBJECT"‑Platzhalters anzeigt. Siehe [Object Preview Issue when Adding OleObjectFrame](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Schnappschuss. Beim programmgesteuerten Aktualisieren der Arbeitsmappendaten muss das Diagrammbild neu erzeugt und sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten ersetzt werden.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das alleinige Ändern der Erweiterung konvertiert die Daten nicht.

**Warum kann sich die Größe des Objekts nach der Aktivierung ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Der OLE‑Anzeigebereich der Arbeitsmappe und die Abmessungen des Folienrahmens sind beide relevant. Siehe [Working Solution for Chart Resizing in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Lösungsansatz für Diagrammgrößenanpassung in PPTX](/slides/de/java/working-solution-for-chart-resizing-in-pptx/)
- [Problem mit Objektvorschau beim Hinzufügen von OleObjectFrame](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE‑Objekte automatisch aktualisieren mit einem PowerPoint‑Add‑In](/slides/de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)