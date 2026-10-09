---
title: Diagramm-Arbeitsmappen in Präsentationen mit JavaScript verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/nodejs-java/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappenzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externe Arbeitsmappe
- Externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js über Java: Verwalten Sie mühelos Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Überblick**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwendet, Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Datenquelle für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, abruft und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/nodejs-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus ausgeblendeten Zeilen und Spalten einbeziehen**

Verwenden Sie [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly), um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblatt‑Zeilen und -Spalten plotten soll. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung steuert das Plotten des Diagramms; sie blendet keine Arbeitsblatt‑Zeilen oder -Spalten aus oder ein.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Shape auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, ihre Zellen enthalten jedoch weiterhin Werte.

| Arbeitsblatt‑Zeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) auf Quellzellen zu und lesen Sie [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden), um deren ausgeblendeten Status zu prüfen. Diese Methode gibt den ausgeblendeten Status zurück, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `false`, `true` und `true` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie die eingebettete Arbeitsmappe mit [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) und laden Sie sie mit [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) erneut. Beim Einbeziehen aller Zellen verwenden Sie auch [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange), um den vollständigen Bereich, einschließlich der ausgeblendeten Februar‑Kategorie, wiederherzustellen. Das bloße Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategorienamen dieses Beispiels zu aktualisieren. Das Beispiel konvertiert den zurückgegebenen Node.js‑Puffer in ein Java‑Byte‑Array, bevor es an die Schreib‑Methode übergeben wird.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Diagrammdaten aus der eingebetteten Arbeitsmappe aktualisieren.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Den vollständigen Quellbereich wiederherstellen, einschließlich ausgeblendeter Kategorien.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Das Beispiel speichert zwei Versionen der Präsentation: eine mit nur den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die folgenden Bilder illustrieren die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen ausgeblendet.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle mit einem Wert unterscheidet sich von einer leeren Zelle. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/nodejs-java/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Abrufen des Datenbereichs eines Diagramms**

Bevor Sie Arbeitsmappen‑Daten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblatt‑Zellen jedes Diagramm verwendet. Die Methode [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) gibt den aktuellen Datenbereich als arbeitsblatt‑qualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inklusive. Die Dollar‑Zeichen kennzeichnen absolute Zeilen‑ und Spalten‑Bezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder seine Arbeitsmappe zu ändern. Wenn das Diagramm keine Arbeitsmappe als Datenquelle verwendet, wirft sie eine `InvalidOperationException`. Weitere Informationen finden Sie in der [ChartData‑API‑Referenz](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Shapes auf jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und dessen Quellbereich aus. Wenn ein Diagramm keine Arbeitsmappe verwendet, wird eine Meldung ausgegeben und zum nächsten Diagramm fortgefahren.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lesen und Schreiben von Diagrammdaten aus einer Arbeitsmappe**

Aspose.Slides for Node.js via Java stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) und [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) bereit, mit denen Sie Diagramm‑Arbeitsmappen (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstes Shape auf ihrer ersten Folie. Es liest die eingebettete Arbeitsmappe in ein Byte‑Array, löscht die vorhandenen Serien und Kategorien und schreibt dieselbe Arbeitsmappe zurück. Die Änderungen verbleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategorien‑Sammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Arbeitsmappen‑Bearbeitung stattfinden würde; das ausführbare Beispiel schreibt die ursprüngliche Arbeitsmappe zurück und validiert das Layout im Speicher.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Arbeitsbuch-Bytes hier ändern, zum Beispiel mit Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor die Arbeitsmappe zurückgeschrieben wird. Erstellen Sie ggf. erforderliche Serien‑ und Kategorien‑Zuordnungen für die aktualisierte Arbeitsmappe erneut, bevor Sie das Diagramm verwenden.

## **Eine Arbeitsmappen‑Zelle als Diagrammdaten‑Beschriftung festlegen**

Sie können Text aus Arbeitsmappen‑Zellen als Diagrammdaten‑Beschriftungen verwenden.

Dieses Beispiel fügt der ersten Folie einer bestehenden Präsentation ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 im Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Arbeitsblätter verwalten**

Die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) bietet Zugriff auf die Arbeitsblätter einer Diagramm‑Arbeitsmappe. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Datentyp der Datenquelle festlegen**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen mithilfe unterschiedlicher Datenquellen fest. Der erste Name verwendet ein Literal‑String; der zweite verwendet die Zelle C1 im Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Erkennung nicht unterstützter eingebetteter Arbeitsmappen‑Formate**

Aspose.Slides unterstützt das Excel‑Binary‑Arbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet werden kann. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) auf [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel prüft die Shapes auf der ersten Folie einer bestehenden Präsentation, überspringt Nicht‑Diagramm‑Shapes und gibt für jedes Diagramm mit einer eingebetteten .xlsb‑Arbeitsmappe eine Diagnosemeldung aus.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Lese oder ändere hier unterstützte Diagramm-Arbeitsmappen-Daten.
    }
} finally {
    presentation.dispose();
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) und [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), um eine eingebettete Diagramm‑Arbeitsmappe in eine Datei zu exportieren und das Diagramm mit dieser externen Arbeitsmappe zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Arbeitsmappe. Es schließt den Datei‑Schreibvorgang ab, bevor es die externe Arbeitsmappe als Diagrammdaten‑Quelle zuweist, und speichert anschließend die verknüpfte Präsentation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Externe Arbeitsmappe zuweisen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einer externen Arbeitsmappe zu aktualisieren (wenn diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die sich an entfernten Standorten oder Ressourcen befinden, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet eine externe Arbeitsmappe, deren Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft die Arbeitsmappe und nutzt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Parameter `updateChartData` der Methode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) steuert, ob die Arbeitsmappe geladen wird.

* Wenn `updateChartData` `false` ist, wird nur der Arbeitsmappen‑Pfad aktualisiert. Die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert, sodass die Arbeitsmappe nicht verfügbar sein kann.
* Wenn `updateChartData` `true` ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL mit `updateChartData` auf `false` zu. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne die nicht verfügbare Arbeitsmappe zu laden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms ermitteln**

Um die mit einem Diagramm verknüpfte Arbeitsmappe zu identifizieren, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Arbeitsmappen‑Pfad ab.

Dieses Beispiel untersucht das erste Shape auf der ersten Folie einer Präsentation mit einer verknüpften externen Arbeitsmappe. Handelt es sich um ein Diagramm, das mit einer externen Arbeitsmappe verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten, wie Sie Änderungen an den Inhalten interner Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist und mit einer zugänglichen externen Arbeitsmappe verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellenwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original unverändert bleiben soll.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/)-Objekt, rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) auf und setzen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) auf `true`, bevor Sie die Präsentation öffnen.

Das folgende JavaScript‑Beispiel stellt Arbeitsmappendaten für ein Diagramm wieder her, das das erste Shape auf der ersten Folie ist und auf eine nicht verfügbare externe Arbeitsmappe verweist. Es greift über [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) auf die wiederhergestellten Daten zu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Lese hier die wiederhergestellten Arbeitsmappendaten oder ändere sie.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten als akzeptabler Fallback gilt, da der Cache möglicherweise nicht die nachträglichen Änderungen der externen Arbeitsmappe enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datenquellentyp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad lesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass das Verschieben der Arbeitsmappe möglicherweise eine Aktualisierung des Links erfordert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerk‑Ressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen von Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Das Bearbeiten von zellbasierten Diagrammdaten kann auch die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie der Arbeitsmappe, wenn das Original unverändert bleiben muss.

**Was tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein üblicher Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/java/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jeder Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird ein Update dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.