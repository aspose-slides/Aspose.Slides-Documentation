---
title: Arbeitslösung für die Größenanpassung von Diagrammen in PPTX
type: docs
weight: 40
url: /de/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Unerwartete Größenänderungen von Diagrammen in PPTX beheben, wenn eingebettete Excel-OLE-Objekte mit Aspose.Slides for Python via Java verwendet werden. Feste Diagrammabmessungen festlegen, um Diagramm- und OLE-Rahmengrößen konsistent zu halten."
---
## **Hintergrund**

Excel-Diagramme, die als OLE-Objekte in PowerPoint-Präsentationen mit Aspose-Komponenten eingebettet sind, können ihre Größe nach der ersten Aktivierung ändern. Dies kann zu einem deutlichen Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammgrößen an den OLE‑Rahmen anpasst.

In [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), haben wir erklärt, wie man mit Aspose.Cells for Python via Java ein Excel-Diagramm erstellt und es mit Aspose.Slides for Python via Java in eine PowerPoint-Präsentation einbettet. Um das [Objekt-Vorschau-Problem](/slides/de/python-java/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE-Objektrahmen des Diagramms zugewiesen. In der Ergebnispräsentation wird das OLE-Objekt, das das Diagrammbild anzeigt, durch Doppelklick aktiviert. Benutzer können die eingebettete Excel-Arbeitsmappe bearbeiten und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE-Objektrahmens als auch der eingebetteten Excel-Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel-Arbeitsmappe hat eigene Fensterdimensionen, die Excel bei der ersten Aktivierung des Objekts beizubehalten versucht. Der OLE-Rahmen auf der Folie hat unabhängig definierte Abmessungen. Wenn die Excel-Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Objektgröße, um die Proportionen im Rahmen des Einbettungsprozesses beizubehalten. Unterschiede zwischen dem Arbeitsmappenfenster und dem OLE-Rahmen können daher das Objekt vergrößern/verkleinern.

## **Funktionsfähige Lösung**

Passen Sie die Diagrammgröße an den OLE‑Rahmen auf der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappenfenster. Diese Lösung funktioniert sowohl mit einer neuen Präsentation als auch mit einer vorhandenen Vorlage.

Das Beispiel benötigt Aspose.Cells for Python via Java und Aspose.Slides for Python via Java. Es erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS-Format ein. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE-Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9.5 × 4‑Zoll‑OLE‑Rahmen, der 0.5 Zoll vom linken Rand und 1 Zoll vom oberen Rand entfernt positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine bestehende Präsentation siehe [Verwenden einer Vorlage](#use-a-template).

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
        width = 684.0  # 9,5 Zoll.
        height = 288.0  # 4 Zoll.

        chart.setSizeWithWindow(False)
        # Punkte in Diagrammpixel umrechnen unter Verwendung von 96 Pixel pro Zoll.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **Feste Diagrammgröße festlegen**

Setzen Sie [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappenfenster sind. Legen Sie die Abmessungen von [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) über [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) und [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) fest, wobei Punkte mit 96 Pixel pro Zoll in Pixel umgerechnet werden: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixeln. Setzen Sie [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) auf den Wert CUSTOM von [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) ein und speichert eine Präsentation mit einem 9.5 × 4‑Zoll‑OLE‑Rahmen.

## **Vorlage verwenden**

Die Größenlogik ist für eine bestehende Präsentation identisch. Um das Beispiel anzupassen:

1. Laden Sie die Vorlagenpräsentation anstelle einer leeren Präsentation.
1. Überprüfen Sie, dass die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit dem Index 2 als Platzhalter.
1. Entnehmen Sie die Rahmenbreite und -höhe aus dieser Form, anstatt die festen Werte 684 und 288 zu verwenden. Halten Sie die Größenberechnungen unverändert.
1. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters statt an den festen Koordinaten 36 und 72 hinzu.
1. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert sich mein eingebettetes Excel-Diagramm nach der Aktivierung in PowerPoint?**

Das passiert, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was die Größenänderung verursachen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Legen Sie feste Diagrammabmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das obige Beispiel zeigt die erforderlichen Einstellungen und Einheitumrechnungen.

**Reicht es aus, die Größe des Arbeitsmappenfensters anzupassen?**

Das reine Anpassen der Größe des Arbeitsmappenfensters verhindert nicht zuverlässig, dass der OLE‑Rahmen nach der Aktivierung seine Größe ändert. Verwenden Sie feste Diagrammabmessungen wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**

Ja. Für eine Vorlage verwenden Sie die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und -position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine mit Aspose.Cells erstellte Excel‑Arbeitsmappe. Es demonstriert das Aktivierungsverhalten anderer Tabellenkalkulationsprogramme nicht.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)