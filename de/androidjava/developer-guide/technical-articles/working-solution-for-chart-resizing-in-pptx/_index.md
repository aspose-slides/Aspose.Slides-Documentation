---
title: Arbeitslösung für Diagrammgrößenanpassung in PPTX
type: docs
weight: 40
url: /de/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenanpassung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Unerwartete Diagrammgrößenänderungen in PPTX beheben, wenn eingebettete Excel-OLE-Objekte mit Aspose.Slides für Android via Java verwendet werden. Feste Diagrammabmessungen festlegen, um die Größen von Diagramm und OLE‑Rahmen konsistent zu halten."
---
## **Übersicht**

Excel-Diagramme, die als OLE-Objekte in PowerPoint-Präsentationen mit Aspose-Komponenten eingebettet sind, können nach ihrer ersten Aktivierung die Größe ändern. Dies kann zu einem deutlichen Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie sie verhindert werden kann, indem die festen Diagrammabmessungen an den OLE‑Rahmen angepasst werden.

In [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel‑Diagramm mit Aspose.Cells für Android via Java erstellt und es in eine PowerPoint‑Präsentation mit Aspose.Slides für Android via Java einbettet. Um das [Objektvorschau-Problem](/slides/de/androidjava/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objekt‑Rahmen des Diagramms zugewiesen. In der Ausgabe‑Präsentation wird das OLE‑Objekt‑Rahmen, das das Diagrammbild anzeigt, durch Doppelklick aktiviert. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objekt‑Rahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe hat eigene Fensterdimensionen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat eigenständig definierte Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Objektgröße, um dessen Proportionen im Rahmen des Einbettungsprozesses beizubehalten. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher das Objekt skalieren.

## **Funktionierende Lösung**

Passen Sie die Diagrammgröße an den OLE‑Rahmen auf der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster. Diese Lösung funktioniert sowohl mit einer neuen Präsentation als auch mit einer bestehenden Vorlage.

Das Beispiel benötigt Aspose.Cells für Android via Java und Aspose.Slides für Android via Java. Es erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Rufen Sie `FixedChartSize.createPresentation(getFilesDir())` aus einer Android‑Aktivität auf, um die Ausgabe im internen Dateiverzeichnis der Anwendung zu speichern. Die OLE‑Aktivierung erfordert das Desktop‑PowerPoint und eine kompatible Excel‑Installation. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine bestehende Präsentation siehe [Verwenden einer Vorlage](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Legen Sie die Abmessungen des [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) über [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) und [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) fest und konvertieren Sie Punkte in Pixel bei 96 Pixel pro Zoll: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixeln. Setzen Sie [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) auf den CUSTOM‑Wert von [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("Data");
                dataSheet.getCells().get("A1").putValue(10);
                dataSheet.getCells().get("A2").putValue(20);

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                chart.getNSeries().add("Data!A1:A2", true);
                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

                Presentation presentation = new Presentation();
                try {
                    ISlide slide = presentation.getSlides().get_Item(0);

                    // Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
                    float width = 684f; // 9,5 Zoll.
                    float height = 288f; // 4 Zoll.

                    chart.setSizeWithWindow(false);
                    // Punkte in Diagrammpixel umrechnen, wobei 96 Pixel pro Zoll verwendet werden.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Vorlage verwenden**

Die Größenlogik ist für eine vorhandene Präsentation identisch. So passen Sie das Beispiel an:

1. Laden Sie die Vorlagen‑Präsentation statt einer leeren Präsentation.
2. Prüfen Sie, ob die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit Index 2 als Platzhalter.
3. Nehmen Sie die Rahmenbreite und -höhe von dieser Form statt der festen Werte 684 und 288. Lassen Sie die Berechnungen unverändert.
4. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters statt an den festen Koordinaten 36 und 72 ein.
5. Entfernen Sie den Platzhalter vor dem Speichern der Präsentation.

## **FAQ**

**Warum ändert sich mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint?**

Das passiert, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenänderung führen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Legen Sie feste Diagrammabmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das obige Beispiel zeigt die erforderlichen Einstellungen und Umrechnungen.

**Reicht es, die Größe des Arbeitsmappen‑Fensters anzupassen?**

Allein die Anpassung der Arbeitsmappen‑Fenstergröße verhindert nicht zuverlässig, dass sich der OLE‑Rahmen nach der Aktivierung ändert. Verwenden Sie feste Diagrammabmessungen wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**

Ja. Für eine Vorlage nutzen Sie die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und Position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine Excel‑Arbeitsmappe, die mit Aspose.Cells erstellt wurde. Es demonstriert kein Aktivierungsverhalten anderer Tabellenkalkulationsprogramme.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)