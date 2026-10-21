---
title: Diagramm-Workbooks in Präsentationen mit JavaScript verwalten
linktitle: Diagramm-Workbook
type: docs
weight: 70
url: /de/nodejs-java/chart-workbook/
keywords:
- Diagramm-Workbook
- Diagrammdaten
- Workbook-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externes Workbook
- externe Daten
- Diagramm-Cache
- Workbook-Wiederherstellung
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Node.js via Java: Verwalten Sie mühelos Diagramm-Workbooks in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie mit Diagramm‑Workbooks in Aspose.Slides arbeiten. Er zeigt, wie Diagrammdaten über Workbook‑Streams gelesen und geschrieben werden, wie Workbook‑Zellen als Datenbeschriftungen verwendet werden, wie auf Arbeitsblatt‑Sammlungen zugegriffen wird und wie der Datentyp‑Quelltyp für Diagrammwerte angegeben wird.

Er behandelt außerdem die Verwendung externer Workbooks als Datenquellen für Diagramme. Die Beispiele demonstrieren, wie ein externes Workbook erstellt und zugewiesen, der Pfad eines externen Workbooks, das mit einem Diagramm verknüpft ist, ermittelt und Diagrammdaten bearbeitet werden, wenn das Workbook verfügbar ist.

Für Workbook‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/nodejs-java/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus versteckten Zeilen und Spalten einbeziehen**

Verwenden Sie [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/), um zu steuern, ob ein Diagramm Daten aus versteckten Arbeitsblatt‑Zeilen und -Spalten plotten soll. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch versteckte Zellen einzuschließen. Diese Einstellung steuert das Plotten des Diagramms; sie verbirgt oder zeigt keine Arbeitsblatt‑Zeilen oder -Spalten an.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Shape auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, deren Zellen enthalten jedoch Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (versteckte Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (versteckte Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) auf Quellzellen zu und lesen Sie [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/), um deren versteckten Status zu prüfen. Diese Methode meldet den verborgenen Status, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur versteckten Zeile und C2 zur versteckten Spalte; das Beispiel gibt `false`, `true` und `true` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie das eingebettete Workbook mit [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) und laden Sie es mit [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) neu. Beim Einbeziehen aller Zellen verwenden Sie außerdem [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/), um den vollständigen Bereich wiederherzustellen, einschließlich der versteckten Februarkategorie. Einfach das Flag zu ändern reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategorienamen dieses Beispiels zu aktualisieren. Das Beispiel konvertiert den zurückgegebenen Node.js‑Puffer in ein Java‑Byte‑Array, bevor es an die Schreib‑Methode übergeben wird.

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

            // Diagrammdaten aus dem eingebetteten Workbook aktualisieren.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Den vollständigen Quellbereich wiederherstellen, einschließlich versteckter Kategorien.
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

Das Beispiel speichert zwei Versionen der Präsentation: eine mit nur den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die untenstehenden Abbildungen zeigen die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Workbooks ausgeblendet.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine versteckte Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) steuert, wie fehlende Werte angezeigt werden; sie schließt versteckte Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/nodejs-java/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Datenbereich eines Diagramms abrufen**

Bevor Sie Workbook‑Daten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblatt‑Zellen jedes Diagramm verwendet. Die Methode [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) gibt den aktuellen Datenbereich als arbeitsblatt‑qualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblatt‑Name, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inklusiv. Die Dollar‑Zeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder sein Workbook zu ändern. Verwendet das Diagramm kein Workbook als Datenquelle, wird `InvalidOperationException` ausgelöst. Weitere Informationen finden Sie in der [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Shapes jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Verwendet ein Diagramm kein Workbook, wird eine Meldung ausgegeben und mit dem nächsten Diagramm fortgefahren.

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

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides for Node.js via Java stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) und [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) bereit, mit denen Sie Diagramm‑Data‑Workbooks (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelle aufweisen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstem Shape auf der ersten Folie. Es liest das eingebettete Workbook in ein Byte‑Array, löscht die bestehenden Serien und Kategorien und schreibt dasselbe Workbook zurück. Die Änderungen bleiben im Speicher; das Beispiel speichert die Präsentation nicht.

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

### **Diagrammlayout nach Workbook‑Änderung validieren**

Wenn Sie ein eingebettetes Workbook durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Diskrepanz kann dazu führen, dass [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) mit einem „Index‑out‑of‑range“-Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie das aktualisierte Workbook zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Workbook‑Bearbeitung stattfinden würde; das ausführbare Beispiel schreibt das ursprüngliche Workbook zurück und validiert das Layout im Speicher.

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

        // Workbook-Bytes hier ändern, zum Beispiel mithilfe von Aspose.Cells.

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

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor das Workbook zurückgeschrieben wird. Stellen Sie für das aktualisierte Workbook die erforderlichen Serien‑ und Kategoriezusordnungen wieder her, bevor Sie das Diagramm verwenden.

## **Benutzerdefinierte Zahlenformate für Workbook‑Zellen festlegen**

Verwenden Sie [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/), um zu steuern, wie numerische Werte im eingebetteten Workbook eines Diagramms angezeigt werden. Beispielsweise kann ein Bericht eine Konversionsrate als Prozentsatz mit vier Dezimalstellen und einen Koeffizienten mit fünf Dezimalstellen darstellen. Beide Werte bleiben numerisch, sodass sie für Berechnungen und Diagramm‑Plotting verfügbar bleiben.

Ein Zahlenformat ändert die Anzeige, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12.5000%` an; es ersetzt die gespeicherte Zahl nicht durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0.12346` an, ohne den gespeicherten Wert zu runden. Wenn das benutzerdefinierte Format ein leerer String (`""`) ist, wird das von [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) zurückgegebene Format verwendet.

Das folgende Beispiel erstellt ein Säulendiagramm und greift über [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) auf dessen Zellen zu. Auf Arbeitsblatt 0 enthält B2 die Konversionsrate und C2 den Koeffizienten. Beide Zellen liefern Diagrammw erte. Das Beispiel aktiviert außerdem Wertebeschriftungen, die an die Quellformate gebunden sind.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Workbook‑Zellformate sind von Formaten getrennt, die direkt an Diagrammacht‑Achsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert der Quellzelle, weil [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) auf `true` gesetzt ist und weil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) ebenfalls `true` ist. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12.5000%` und `0.12346` wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes Zahlenformat, das mit [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) auf `0.00` gesetzt wurde, wobei [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) auf `false` steht.

Um eine Datenbeschriftung unabhängig zu formatieren, setzen Sie deren Quell‑Verknüpfungs‑Flag auf `false` und weisen Sie ein Format mit [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) zu. Dadurch wird das Format der Workbook‑Zelle nicht geändert. Beispielsweise zeigt ein unabhängiges Beschriftungsformat `0.00` den ersten Wert als `0.13` an, während B2 weiterhin `12.5000%` anzeigt. Siehe [Chart Data Labels](/slides/de/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) für die direkte Beschriftungsformatierung.

Das untenstehende Bild wurde aus der gespeicherten Präsentation nach dem erneuten Öffnen gerendert:

![Säulendiagramm mit quellenverknüpften Beschriftungen, die 12.5000 % und 0.12346 zeigen, sowie einer unabhängig formatierten numerischen Achse.](custom-cell-formats.png)

## **Eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

Sie können Text aus Workbook‑Zellen als Diagrammdatenbeschriftungen verwenden.

Dieses Beispiel fügt einer vorhandenen Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

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

Die Methode [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) liefert Zugriff auf die Arbeitsblätter in einem Diagramm‑Workbook. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

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

## **Datentyp der Datenquelle angeben**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen fest, die unterschiedliche Datenquellen verwenden. Der erste Name verwendet ein Zeichenketten‑Literal; der zweite nutzt die Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) bestimmt die Quelle für jeden Namen. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

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

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet sein kann. Sie können die Methode `getEmbeddedWorkbookType` auf [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Shapes auf der ersten Folie einer vorhandenen Präsentation, überspringt Nicht‑Diagramm‑Shapes und gibt für jedes Diagramm mit einem eingebetteten .xlsb‑Workbook eine Diagnosemeldung aus.

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

        // Lesen oder ändern Sie unterstützte Diagramm-Workbook-Daten hier.
    }
} finally {
    presentation.dispose();
}
```

## **Externes Workbook**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Externes Workbook erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) und [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/), um ein eingebettetes Diagramm‑Workbook in eine Datei zu exportieren und das Diagramm mit diesem externen Workbook zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Workbook. Es schließt den Datei‑Schreibvorgang ab, bevor das externe Workbook als Datenquelle zugewiesen wird, und speichert die verknüpfte Präsentation.

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

### **Externes Workbook festlegen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zu einem externen Workbook zu aktualisieren (wenn dieses verschoben wurde).

Während Sie die Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Workbooks dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad zu einem externen Workbook angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

Dieses Beispiel verwendet ein externes Workbook, dessen Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft das Workbook und nutzt [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

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

Der Parameter `updateChartData` der Methode [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) steuert, ob das Workbook geladen wird.

* Wenn `updateChartData` `false` ist, wird nur der Workbook‑Pfad aktualisiert. Die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert, sodass das Workbook nicht verfügbar sein kann.
* Wenn `updateChartData` `true` ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

Das folgende Beispiel weist einen Platzhalter‑URL mit `updateChartData` = `false` zu. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne das nicht verfügbare Workbook zu laden.

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

### **Pfad des externen Datenquellen‑Workbooks eines Diagramms ermitteln**

Um das mit einem Diagramm verknüpfte Workbook zu identifizieren, prüfen Sie, ob das Diagramm eine externe Datenquelle nutzt, und rufen Sie dessen Workbook‑Pfad ab.

Dieses Beispiel untersucht das erste Shape auf der ersten Folie einer Präsentation mit einem verknüpften externen Workbook. Handelt es sich um ein Diagramm, das mit einem externen Workbook verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

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

Sie können die Daten in externen Workbooks genauso bearbeiten, wie Sie Änderungen an internen Workbooks vornehmen. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das das erste Shape auf der ersten Folie ist und mit einem zugänglichen externen Workbook verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts in der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original‑Workbook erhalten bleiben muss.

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

### **Workbook aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm ein externes Workbook, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) auf und setzen Sie [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) auf `true`, bevor Sie die Präsentation öffnen.

Das folgende JavaScript‑Beispiel stellt Workbook‑Daten für ein Diagramm wieder her, das das erste Shape auf der ersten Folie ist und ein nicht verfügbares externes Workbook referenziert. Es greift über [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) und [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) auf die wiederhergestellten Daten zu:

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

        // Lesen oder ändern Sie hier die wiederhergestellten Workbook-Daten.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückfall ist, da der Cache Änderungen am externen Workbook nach dem letzten Update der Präsentation möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder einem eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) und einen [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben des Workbooks eine Aktualisierung des Links erfordern kann.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Workbooks aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Die Präsentation speichert einen [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Das Bearbeiten von zellbasierten Diagrammdaten kann das verknüpfte lokale XLSX‑File ebenfalls aktualisieren. Verwenden Sie eine Kopie des Workbooks, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/java/)) vorzubereiten und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.