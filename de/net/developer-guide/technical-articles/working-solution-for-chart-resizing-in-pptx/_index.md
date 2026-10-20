---
title: Funktionierende Lösung für Diagrammgrößenänderungen in PPTX
type: docs
weight: 60
url: /de/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Beheben Sie unerwartete Diagrammgrößenänderungen in PPTX bei der Verwendung eingebetteter Excel-OLE-Objekte mit Aspose.Slides für .NET. Legen Sie feste Diagrammabmessungen fest, um die Größen von Diagramm und OLE-Rahmen konsistent zu halten."
---
## **Hintergrund**

Excel‑Diagramme, die als OLE‑Objekte in PowerPoint‑Präsentationen mit Aspose‑Komponenten eingebettet sind, können ihre Größe nach der ersten Aktivierung ändern. Das kann zu einem deutlichen Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammgrößen an den OLE‑Rahmen anpasst.

In [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), haben wir erklärt, wie man mit Aspose.Cells for .NET ein Excel‑Diagramm erstellt und es mit Aspose.Slides for .NET in eine PowerPoint‑Präsentation einbettet. Um das [Vorschau‑Problem für Objekte](/slides/de/net/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. In der Ergebnis‑Präsentation wird das Excel‑Diagramm aktiviert, wenn Sie den OLE‑Objektrahmen, der das Diagrammbild anzeigt, doppelklicken. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe besitzt eigene Fensterabmessungen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängige Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Größe des Objekts, um dessen Proportionen im Rahmen des Einbettungsprozesses beizubehalten. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher das Objekt zur Größenänderung veranlassen.

## **Funktionierende Lösung**

Das Beispiel erfordert Aspose.Cells for .NET und Aspose.Slides for .NET. Es erzeugt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erstellt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine vorhandene Präsentation siehe [Verwenden einer Vorlage](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Setzen Sie die [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/)‑Abmessungen über [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) und [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), wobei Punkte mit 96 Pixel pro Zoll in Pixel umgerechnet werden: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixel. Setzen Sie [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) auf den benutzerdefinierten Wert von [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
var width = 684f; // 9,5 Zoll.
var height = 288f; // 4 Zoll.

chart.SizeWithWindow = false;
// Punkte in Diagrammpixel umrechnen, dabei 96 Pixel pro Zoll verwenden.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Vorlage verwenden**

Die Logik zur Größenbestimmung ist für eine vorhandene Präsentation identisch. So passen Sie das Beispiel an:

1. Laden Sie die Vorlage‑Präsentation anstelle einer leeren Präsentation.
2. Prüfen Sie, dass die erste Folie mindestens drei Formen enthält, und verwenden Sie die Form mit dem Index 2 als Platzhalter.
3. Entnehmen Sie die Rahmenbreite und -höhe dieser Form anstelle der festen Werte 684 und 288. Lassen Sie die Berechnungen zur Größenbestimmung unverändert.
4. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters statt an den festen Koordinaten 36 und 72 ein.
5. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm seine Größe, nachdem es in PowerPoint aktiviert wurde?**

Dies geschieht, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Legen Sie feste Diagrammabmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das obige Beispiel zeigt die erforderlichen Einstellungen und Einheitumrechnungen.

**Reicht es aus, die Größe des Arbeitsmappen‑Fensters anzupassen?**

Das reine Anpassen der Größe des Arbeitsmappen‑Fensters verhindert nicht zuverlässig, dass der OLE‑Rahmen nach der Aktivierung seine Größe ändert. Verwenden Sie feste Diagrammabmessungen, wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**

Ja. Für eine Vorlage verwenden Sie die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und die Position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine Excel‑Arbeitsmappe, die mit Aspose.Cells erstellt wurde. Es zeigt das Aktivierungsverhalten für andere Tabellenkalkulationsprogramme nicht.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑Objekte automatisch mithilfe eines PowerPoint‑Add‑Ins aktualisieren](/slides/de/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)