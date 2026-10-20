---
title: Arbeitsfähige Lösung für Diagrammgrößenänderung in PPTX
type: docs
weight: 40
url: /de/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Unerwartete Diagrammgrößenänderungen in PPTX beheben, wenn eingebettete Excel OLE-Objekte mit Aspose.Slides für Java verwendet werden. Feste Diagrammabmessungen festlegen, um die Größen von Diagramm und OLE‑Rahmen konsistent zu halten."
---
## **Hintergrund**

Excel-Diagramme, die als OLE-Objekte in PowerPoint-Präsentationen mit Aspose-Komponenten eingebettet sind, können nach ihrer ersten Aktivierung die Größe ändern. Dies kann zu einem bemerkenswerten Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammabmessungen an den OLE‑Rahmen anpasst.

In [Erstellen von Excel-Diagrammen und Einbetten als OLE-Objekte in Präsentationen](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) erklärten wir, wie man mit Aspose.Cells für Java ein Excel-Diagramm erstellt und es mit Aspose.Slides für Java in eine PowerPoint-Präsentation einbettet. Um das [Problem mit der Objektvorschau](/slides/de/java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE-Objekt‑Rahmen des Diagramms zugewiesen. In der Ausgabepäsentation wird das OLE-Objekt‑Rahmen, das das Diagrammbild anzeigt, durch Doppelklick aktiviert. Benutzer können die eingebettete Excel-Arbeitsmappe bearbeiten und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objekt‑Rahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe hat eigene Fensterdimensionen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängig definierte Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Größe des Objekts, um dessen Proportionen im Einbettungsprozess beizubehalten. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher das Objekt skalieren.

## **Funktionierende Lösung**

Stellen Sie die Diagrammgröße an den OLE‑Rahmen der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster. Diese Lösung funktioniert mit einer neuen Präsentation oder einer bestehenden Vorlage.

Das Beispiel benötigt Aspose.Cells für Java und Aspose.Slides für Java. Es erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll) angegeben. Für eine bestehende Präsentation siehe [Verwenden einer Vorlage](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Setzen Sie die [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--)‑Abmessungen über [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) und [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-), indem Sie Punkte mit 96 Pixeln pro Zoll in Pixel konvertieren: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixeln. Setzen Sie [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) auf den CUSTOM‑Wert von [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

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
        // Punkte mit 96 Pixeln pro Zoll in Diagrammpixel konvertieren.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Vorlage verwenden**

Die Logik zur Größenbestimmung ist für eine bestehende Präsentation dieselbe. Um das Beispiel anzupassen:

1. Laden Sie die Vorlagenpräsentation anstelle einer leeren Präsentation.
2. Stellen Sie sicher, dass die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit dem Index 2 als Platzhalter.
3. Nehmen Sie die Rahmenbreite und -höhe von dieser Form anstelle der festen Werte 684 und 288. Lassen Sie die Berechnungen zur Größenbestimmung unverändert.
4. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters statt an den festen Koordinaten 36 und 72 ein.
5. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint seine Größe?**

Dies geschieht, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Setzen Sie feste Diagrammabmessungen, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das obige Beispiel zeigt die erforderlichen Einstellungen und Einheitumrechnungen.

**Reicht es aus, die Größe des Arbeitsmappen‑Fensters anzupassen?**

Allein die Anpassung der Größe des Arbeitsmappen‑Fensters verhindert nicht zuverlässig, dass der OLE‑Rahmen nach der Aktivierung die Größe ändert. Verwenden Sie feste Diagrammabmessungen, wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**

Ja. Für eine Vorlage verwenden Sie die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und -position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine mit Aspose.Cells erstellte Excel‑Arbeitsmappe. Es zeigt das Aktivierungsverhalten für andere Tabellenkalkulationsprogramme nicht.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)