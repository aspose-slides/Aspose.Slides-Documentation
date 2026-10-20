---
title: Funktionsfähige Lösung für Diagrammgrößenänderung in PPTX
type: docs
weight: 40
url: /de/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Behebt unerwartete Diagrammgrößenänderungen in PPTX bei Verwendung eingebetteter Excel-OLE-Objekte mit Aspose.Slides für Node.js via Java. Legen Sie feste Diagrammabmessungen fest, um die Größen von Diagramm und OLE‑Rahmen konsistent zu halten."
---
## **Übersicht**

Excel‑Diagramme, die als OLE‑Objekte in PowerPoint‑Präsentationen mit Aspose‑Komponenten eingebettet werden, können nach ihrer ersten Aktivierung die Größe ändern. Dadurch entsteht ein spürbarer Unterschied im Aussehen des Diagramms vor und nach der Aktivierung. Dieser Artikel erklärt, warum die Größenanpassung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammgrößen an den OLE‑Rahmen anpasst.

In [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erläutert, wie man mit Aspose.Cells für Node.js via Java ein Excel‑Diagramm erstellt und es mit Aspose.Slides für Node.js via Java in eine PowerPoint‑Präsentation einbettet. Um das [Problem mit der Objektvorschau](/slides/de/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) zu lösen, haben wir das Diagrammbild dem OLE‑Objektrahmen des Diagramms zugewiesen. Im erzeugten Vortrag wird beim Doppelklick auf den OLE‑Objektrahmen, der das Diagrammbild zeigt, das Excel‑Diagramm aktiviert. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Beim Zurückkehren ändert sich die Größe des OLE‑Objektrahmens, wobei der Skalierungsfaktor von den ursprünglichen Größen sowohl des OLE‑Objektrahmens als auch der eingebetteten Excel‑Arbeitsmappe abhängt.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe besitzt eigene Fensterabmessungen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängig definierte Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Objektgröße, um das Seitenverhältnis im Einbettungsprozess zu wahren. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher zu einer Größenanpassung des Objekts führen.

## **Funktionsfähige Lösung**

Stellen Sie die Diagrammgröße dem OLE‑Rahmen auf der Folie angleich und halten Sie die Diagramm‑Abmessungen unabhängig vom Arbeitsmappen‑Fenster. Diese Lösung funktioniert sowohl mit einer neuen Präsentation als auch mit einer bestehenden Vorlage.

Das Beispiel erfordert Aspose.Cells für Node.js via Java und Aspose.Slides für Node.js via Java. Installieren Sie die Node.js‑Pakete `aspose.cells`, `aspose.slides.via.java` und `java`. Führen Sie die beiden CommonJS‑Skripte unten in separaten Node.js‑Prozessen aus, wobei beide im selben Arbeitsverzeichnis liegen, da beide Aspose‑Pakete beim Laden die Java‑Brücke initialisieren. Das Skript erstellt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagramm‑Vorschaubild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Das Beispiel erzeugt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand entfernt liegt. Folienkoordinaten und -abmessungen werden in Punkten angegeben (72 Punkte pro Zoll). Für eine bestehende Präsentation siehe [Vorlage verwenden](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) auf false, sodass die Diagramm‑Abmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Legen Sie die Dimensionen über [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) mittels [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) und [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) fest und konvertieren Sie Punkte in Pixel bei 96 Pixeln pro Zoll: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixeln. Setzen Sie [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) auf den CUSTOM‑Wert von `PrintSizeType`. Das Beispiel bettet die Arbeitsmappe mit [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

Speichern Sie dieses erste Skript als `create-fixed-chart.js`. Es erzeugt `chart-fixed-size.xls` mit einem Diagramm von 912 × 384 Pixeln, das dem 684 × 288‑Punkte‑Rahmen des zweiten Skripts entspricht. Eine Eingabe‑Arbeitsmappe ist nicht erforderlich.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Passe die OLE‑Rahmendimensionen in Punkten an (72 Punkte pro Zoll).
    const width = 684; // 9,5 Zoll.
    const height = 288; // 4 Zoll.

    chart.setSizeWithWindow(false);
    // Konvertiere Punkte in Diagrammpixel bei 96 Pixeln pro Zoll.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Alle synchronen Vorgänge sind abgeschlossen; stoppe den Java‑Brückenprozess.
process.exit(0);
```

Speichern Sie das zweite Skript als `embed-fixed-chart.js` und führen Sie es nach `create-fixed-chart.js` aus. Es liest die erstellte XLS‑Arbeitsmappe und speichert `chart-fixed-size.pptx`. Die Java‑Brücke benötigt ein explizites Java‑Byte‑Array für die Arbeitsmappendaten und Java‑Float‑Werte für die Rahmenkoordinaten und -abmessungen. Die Dateierweiterung `xls` entspricht dem gespeicherten Format der Arbeitsmappe.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
    const width = 684; // 9,5 Zoll.
    const height = 288; // 4 Zoll.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Alle synchronen Vorgänge sind abgeschlossen; stoppe den Java-Bridgeprozess.
process.exit(0);
```

## **Vorlage verwenden**

Die Logik zur Größenbestimmung ist für eine bestehende Präsentation identisch. So passen Sie das Beispiel an:

1. Laden Sie die Vorlagen‑Präsentation anstelle einer leeren Präsentation.
1. Stellen Sie sicher, dass die erste Folie mindestens drei Shapes enthält, und verwenden Sie das Shape mit Index 2 als Platzhalter.
1. Übernehmen Sie die Rahmenbreite und -höhe von diesem Shape anstelle der festen Werte 684 und 288. Verwenden Sie dieselben Abmessungen im Arbeitsmappen‑Erstellungsskript, lassen Sie die Berechnungen unverändert und erzeugen Sie die XLS‑Arbeitsmappe erneut, bevor Sie sie einbetten.
1. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters statt an den festen Koordinaten 36 und 72 ein.
1. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint seine Größe?**  
Das geschieht, weil Excel versucht, beim ersten Aktivieren die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Größenanpassung führen kann.

**Wie kann ich die Diagramm‑ und OLE‑Rahmen‑Größen konsistent halten?**  
Legen Sie feste Diagramm‑Abmessungen fest, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das oben gezeigte Beispiel enthält die erforderlichen Einstellungen und Umrechnungen.

**Reicht es, die Größe des Arbeitsmappen‑Fensters anzupassen?**  
Allein das Anpassen der Arbeitsmappen‑Fenstergröße verhindert nicht zuverlässig, dass sich der OLE‑Rahmen nach der Aktivierung ändert. Verwenden Sie feste Diagramm‑Abmessungen, wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**  
Ja. Bei einer Vorlage nutzen Sie die Abmessungen und die Position des Platzhalters. Bei einer neuen Präsentation geben Sie die Rahmenabmessungen und -position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**  
Das Beispiel verwendet eine Excel‑Arbeitsmappe, die mit Aspose.Cells erstellt wurde. Es demonstriert kein Aktivierungsverhalten für andere Tabellenkalkulationsprogramme.

## **Verwandte Abschnitte**

- [Excel‑Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)