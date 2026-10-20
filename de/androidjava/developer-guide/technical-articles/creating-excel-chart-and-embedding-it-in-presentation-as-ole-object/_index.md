---
title: Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten
type: docs
weight: 30
url: /de/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Android via Java und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides für Android via Java ein, einschließlich einer Diagramm‑Vorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit Aspose.Cells für Android via Java ein Excel‑Säulendiagramm erstellt und seine Arbeitsmappe in eine PowerPoint‑Präsentation mit Aspose.Slides für Android via Java einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Fügen Sie Aspose.Cells für Android via Java und Aspose.Slides für Android via Java zu den Projektabhängigkeiten hinzu. Rufen Sie `ExcelChartEmbedding.createPresentation(getFilesDir())` aus einer Android‑Aktivität auf. Microsoft Office wird nicht benötigt, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erstellt die Daten und das Diagramm im Speicher und schreibt dann `OutputChart.pptx` in das interne Dateiverzeichnis der Anwendung. Lizenzieren Sie beide Produkte, wenn Sie außerhalb des Evaluierungsmodus arbeiten.

## **Funktionsweise des Einbettens**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Worksheet und einem Diagramm‑Sheet.  
1. Machen Sie das Diagramm‑Sheet aktiv, damit die Arbeitsmappe beim Öffnen das Diagramm anzeigt.  
1. Setzen Sie den OLE‑Anzeige‑Bereich der Arbeitsmappe und rendern Sie das Diagramm nach PNG.  
1. Speichern Sie die Arbeitsmappe als XLSX im Speicher und betten Sie die Bytes in eine Folie ein.  
1. Ordnen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeige‑Bereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Aufgaben. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) verwendet nullbasierte Start‑/End‑Zeilen‑ und Spaltenindizes. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) hingegen verwendet die obere Zeile, linke Spalte, untere Zeile und rechte Spalte. Das Beispiel verwendet Zeilenindex 55 und Spaltenindex 25 als untere rechte Grenze; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie zu füllen.

## **Diagramm erstellen und einbetten**

Das folgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammserie. `ChartSheet` wird vor dem Speichern der Arbeitsmappe als aktives Blatt ausgewählt.

Die Arbeitsmappe wird explizit als XLSX gespeichert, wobei die `xlsx`‑Erweiterung an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/) übergeben wird. Das PNG wird direkt aus seinen Bytes geladen, ohne eine Zwischenkonvertierung in ein Bitmap. Das Zuordnen über [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ersetzt den Standard‑OLE‑Platzhalter.

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
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
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

                // Rendern Sie die Diagramm‑Vorschau und serialisieren Sie die editierbare Arbeitsmappe separat.
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

                        // Passen Sie die Vorschau innerhalb der Folie an, ohne das Seitenverhältnis zu verändern.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
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
    }
}
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagramm‑Vorschau. Die Arbeitsmappe enthält die ursprünglichen Daten und ein Säulendiagramm mit vier Serien. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel können Sie das Objekt doppelklicken, um die eingebettete Arbeitsmappe zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folien‑Vorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des Standard‑„EMBEDDED OLE OBJECT“-Platzhalters anzeigt. Siehe [Objektvorschau-Problem beim Hinzufügen von OleObjectFrame](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Momentaufnahme. Beim programmgesteuerten Aktualisieren von Arbeitsmappendaten müssen Sie das Diagrammbild neu erzeugen und sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten ersetzen.

**Kann ich XLS statt XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Dateierweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappenformat entsprechen; das bloße Ändern der Erweiterung konvertiert die Daten nicht.

**Warum kann sich die Objektgröße nach der Aktivierung ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Sowohl der OLE‑Anzeige‑Bereich der Arbeitsmappe als auch die Abmessungen des Folienrahmens spielen dabei eine Rolle. Siehe [Lösungsansatz für die Größenänderung von Arbeitsblättern](/slides/de/androidjava/working-solution-for-worksheet-resizing/).

## **Verwandte Abschnitte**

- [Lösungsansatz für die Größenänderung von Arbeitsblättern](/slides/de/androidjava/working-solution-for-worksheet-resizing/)
- [Objektvorschau-Problem beim Hinzufügen von OleObjectFrame](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [OLE verwalten](/slides/de/androidjava/manage-ole/)