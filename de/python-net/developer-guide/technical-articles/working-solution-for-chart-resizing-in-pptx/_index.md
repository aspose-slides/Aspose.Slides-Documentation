---
title: Arbeitslösung für Diagrammgrößenänderung in PPTX
type: docs
weight: 60
url: /de/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- Python über .NET
- Python
- Aspose.Slides
description: "Unerwartete Diagrammgrößenänderungen in PPTX beheben, wenn eingebettete Excel-OLE-Objekte mit Aspose.Slides für Python via .NET verwendet werden. Feste Diagrammabmessungen festlegen, um die Größen von Diagramm und OLE-Rahmen konsistent zu halten."
---
## **Übersicht**

Excel‑Diagramme, die als OLE‑Objekte in PowerPoint‑Präsentationen mit Aspose‑Komponenten eingebettet sind, können ihre Größe nach der ersten Aktivierung ändern. Dies kann zu einem bemerkbaren Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammabmessungen an den OLE‑Rahmen anpasst.

In [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), haben wir erklärt, wie man ein Excel‑Diagramm mit Aspose.Cells für Python via .NET erstellt und es in eine PowerPoint‑Präsentation mit Aspose.Slides für Python via .NET einbettet. Um das [Objektvorschau-Problem](/slides/de/python-net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. In der ausgegebenen Präsentation wird das Excel‑Diagramm aktiviert, wenn Sie den OLE‑Objektrahmen, der das Diagrammbild anzeigt, doppelt anklicken. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe hat eigene Fensterdimensionen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängig definierte Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Größe des Objekts, um seine Proportionen im Rahmen des Einbettungsprozesses beizubehalten. Unterschiede zwischen dem Arbeitsmappenfenster und dem OLE‑Rahmen können daher das Objekt skalieren.

## **Funktionierende Lösung**

Passen Sie die Diagrammgröße dem OLE‑Rahmen auf der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappenfenster. Diese Lösung funktioniert mit einer neuen Präsentation oder einer vorhandenen Vorlage.

Das Beispiel erfordert Aspose.Cells für Python via .NET und Aspose.Slides für Python via .NET. Es erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine vorhandene Präsentation siehe [Vorlage verwenden](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) auf false, sodass die Diagrammabmessungen unabhängig vom Arbeitsmappenfenster sind.  
Stellen Sie die [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/)-Abmessungen über [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) und [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) ein und konvertieren Sie Punkte in Pixel mit 96 Pixel pro Zoll: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixeln.  
Setzen Sie [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) auf den CUSTOM‑Wert von [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/).  
Das Beispiel bettet die Arbeitsmappe mit [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
    width = 684.0  # 9,5 Zoll.
    height = 288.0  # 4 Zoll.

    chart.size_with_window = False
    # Punkte in Diagrammpixel umrechnen mit 96 Pixeln pro Zoll.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Vorlage verwenden**

Die Größenlogik ist für eine vorhandene Präsentation dieselbe. Um das Beispiel anzupassen:

1. Laden Sie die Vorlagenpräsentation anstelle einer leeren Präsentation.  
1. Stellen Sie sicher, dass die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit Index 2 als Platzhalter.  
1. Nehmen Sie die Rahmenbreite und -höhe von dieser Form, anstatt die festen Werte 684 und 288 zu verwenden. Lassen Sie die Berechnungen für die Größe unverändert.  
1. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters ein, anstatt die festen Koordinaten 36 und 72 zu verwenden.  
1. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint die Größe?**  
Das passiert, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**  
Legen Sie feste Diagrammabmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Druckgröße des Diagramms. Das obige Beispiel zeigt die erforderlichen Einstellungen und Umrechnungen der Einheiten.

**Reicht es, die Größe des Arbeitsmappenfensters anzupassen?**  
Das reine Anpassen der Größe des Arbeitsmappenfensters verhindert nicht zuverlässig, dass der OLE‑Rahmen nach der Aktivierung die Größe ändert. Verwenden Sie feste Diagrammabmessungen wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**  
Ja. Verwenden Sie für eine Vorlage die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und -position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**  
Das Beispiel verwendet eine Excel‑Arbeitsmappe, die mit Aspose.Cells erstellt wurde. Es demonstriert nicht das Aktivierungsverhalten anderer Tabellenkalkulationsprogramme.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE-Objekte in Präsentationen einbetten](/slides/de/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE-Objekte automatisch mit einem PowerPoint-Add‑In aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)