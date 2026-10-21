---
title: Diagramm-Arbeitsmappen in Präsentationen auf Android verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/androidjava/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm-Cache
- Arbeitsmappen-Wiederherstellung
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Android via Java: Verwalten Sie mühelos Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Überblick**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie Diagrammdaten über Arbeitsmappen‑Streams gelesen und geschrieben werden, wie Arbeitsmappen‑Zellen als Diagrammdaten‑Beschriftungen verwendet werden, wie auf Arbeitsblatt‑Sammlungen zugegriffen wird und wie der Datentyp für Diagrammwerte festgelegt wird.

Außerdem behandelt er die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer mit einem Diagramm verknüpften externen Arbeitsmappe ermittelt und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten repräsentieren, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/androidjava/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Einbeziehen von Daten aus ausgeblendeten Zeilen und Spalten**

Verwenden Sie [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblattzeilen und -spalten darstellt. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung steuert das Plotten des Diagramms; sie blendet Arbeitsblattzeilen oder -spalten nicht ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erstes Objekt auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den folgenden Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, aber ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf Quellzellen zu und lesen Sie [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) aus, um deren Ausblendestatus zu prüfen. Diese Methode meldet den Ausblendestatus, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 gehört zur ausgeblendeten Spalte; das Beispiel gibt `false`, `true` bzw. `true` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten, nachdem Sie die Plot‑Einstellung geändert haben: behalten Sie die eingebettete Arbeitsmappe mit [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und laden Sie sie mit [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) erneut. Wenn Sie alle Zellen einbeziehen, verwenden Sie zusätzlich [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-), um den vollständigen Bereich einschließlich der ausgeblendeten Februar‑Kategorie wiederherzustellen. Das bloße Ändern des Flags reicht nicht aus, um die im Beispiel zwischengespeicherten Diagrammdaten und Kategoriebeschriftungen zu aktualisieren.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Aktualisieren Sie die Diagrammdaten aus der eingebetteten Arbeitsmappe.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Stellen Sie den gesamten Quellbereich wieder her, einschließlich ausgeblendeter Kategorien.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Das Beispiel speichert zwei Versionen der Präsentation: eine nur mit den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die Bilder unten veranschaulichen die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen ausgeblendet.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/androidjava/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Den Datenbereich eines Diagramms abrufen**

Bevor Sie Arbeitsmappendaten in einer vorhandenen Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblattzellen jedes Diagramm verwendet. Die Methode [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) liefert den aktuellen Datenbereich als arbeitblattqualifizierte Formel, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 einschließlich. Die Dollarzeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder seine Arbeitsmappe zu verändern. Wenn das Diagramm keine Arbeitsmappe als Datenquelle verwendet, wird `InvalidOperationException` ausgelöst. Weitere Informationen finden Sie in der [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Formen direkt auf jeder Folie auf Diagramme. Es gibt den Namen jedes Diagramms und seinen Quellbereich aus. Wenn ein Diagramm keine Arbeitsmappe verwendet, gibt es eine Meldung aus und fährt mit dem nächsten Diagramm fort.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides for Android via Java stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) bereit, mit denen Sie Diagramm‑Arbeitsmappen (die mit Aspose.Cells bearbeitete Diagrammdaten enthalten) lesen und schreiben können. **Hinweis** dass die Diagrammdaten in derselben Weise organisiert sein müssen oder eine ähnliche Struktur wie die Quelle besitzen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erstes Objekt auf ihrer ersten Folie. Es liest die eingebettete Arbeitsmappe in ein Byte‑Array, löscht die vorhandenen Serien und Kategorien und schreibt dieselbe Arbeitsmappe zurück. Die Änderungen verbleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine geänderte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Diskrepanz kann dazu führen, dass [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das das erste Objekt auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Arbeitsmappenbearbeitung stattfinden würde; das ausführbare Beispiel schreibt die Originalarbeitsmappe zurück und validiert das Layout im Speicher.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Ändern Sie hier die Arbeitsmappen-Bytes, zum Beispiel mit Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Das Löschen der Sammlungen entfernt veraltete Datenreferenzen, bevor die Arbeitsmappe zurückgeschrieben wird. Bauen Sie etwaige erforderliche Serien‑ und Kategoriezusordnungen für die aktualisierte Arbeitsmappe neu auf, bevor Sie das Diagramm verwenden.

## **Benutzerdefinierte Zahlenformate für Arbeitsmappen‑Zellen festlegen**

Verwenden Sie [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-), um zu steuern, wie numerische Werte in einer im Diagramm eingebetteten Arbeitsmappe angezeigt werden. Beispielsweise kann ein Bericht eine Konversionsrate als Prozentwert mit vier Dezimalstellen und einen Koeffizienten mit fünf Dezimalstellen anzeigen. Beide Werte sollten numerisch bleiben, damit sie für Berechnungen und Diagramm‑Plotting verfügbar bleiben.

Ein Zahlenformat ändert die Anzeige, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12,5000%` an; es ersetzt nicht die gespeicherte Zahl durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0,12346` an, ohne den gespeicherten Wert zu runden. Wenn das benutzerdefinierte Format ein leerer String (`""`) ist, wird stattdessen das von [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) zurückgegebene Format verwendet.

Das nachfolgende Beispiel erstellt ein Säulendiagramm und greift über [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf dessen Zellen zu. Auf Arbeitsblatt 0 enthält B2 die Konversionsrate und C2 den Koeffizienten. Beide Zellen liefern Diagrammw Werte. Das Beispiel aktiviert zudem Wertebeschriftungen, die an die Quellformate gebunden sind.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Arbeitsmappen‑Zellformate sind von Formaten getrennt, die direkt auf Diagrammachsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert der Quellzelle, weil [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) auf `true` gesetzt ist und [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) ebenfalls auf `true` steht. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12,5000%` und `0,12346`, wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes Zahlenformat, das mit [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) auf `0.00` gesetzt wurde, wobei [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) auf `false` steht.

Um ein Datenbeschriftungsformat unabhängig zu formatieren, setzen Sie dessen Quell‑Verknüpfungs‑Flag auf `false` und weisen Sie mit [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) ein Format zu. Dies ändert nicht das Format der Arbeitsmappen‑Zelle. Beispielsweise zeigt ein unabhängiges Beschriftungsformat `0.00` den ersten Wert als `0,13` an, während B2 weiterhin `12,5000%` anzeigt. Siehe [Chart Data Labels](/slides/de/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) für direkte Beschriftungsformatierung.

![Säulendiagramm mit quellenverknüpften Beschriftungen, die 12,5000 % und 0,12346 anzeigen, sowie einer unabhängig formatierten numerischen Achse.](custom-cell-formats.png)

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

Sie können Text aus Arbeitsmappen‑Zellen als Diagrammdatenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standardsdaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Arbeitsblätter verwalten**

Die Methode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) stellt Zugriff auf die Arbeitsblätter einer Diagramm‑Arbeitsmappe bereit. Dieses Beispiel erstellt ein Kreisdiagramm mit Standardsdaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Datentyp der Datenquelle festlegen**

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standardsdaten und legt für zwei Seriennamen unterschiedliche Datenquellen fest. Der erste Name verwendet ein String‑Literal; der zweite verwendet die Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nicht unterstützte eingebettete Arbeitsmappenformate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet sein kann. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) auf [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel prüft die Formen auf der ersten Folie einer vorhandenen Präsentation, überspringt Nicht‑Diagramm‑Formen und gibt für jedes Diagramm mit einer eingebetteten .xlsb‑Arbeitsmappe eine Diagnosemeldung aus.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Unterstützte Diagramm‑Arbeitsmappendaten hier lesen oder ändern.
    }
} finally {
    presentation.dispose();
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), um eine eingebettete Diagramm‑Arbeitsmappe in eine Datei zu exportieren und das Diagramm mit dieser externen Arbeitsmappe zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standardsdaten und exportiert dessen Arbeitsmappe. Der Dateischreibvorgang wird abgeschlossen, bevor die externe Arbeitsmappe als Diagrammdatenquelle zugewiesen wird, anschließend wird die verknüpfte Präsentation gespeichert.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Externe Arbeitsmappe zuweisen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann ebenfalls verwendet werden, um den Pfad zu einer externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle verwenden. Wenn ein relativer Pfad für eine externe Arbeitsmappe angegeben wird, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet eine externe Arbeitsmappe, deren Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft die Arbeitsmappe und verwendet [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Parameter `updateChartData` von [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) steuert, ob die Arbeitsmappe geladen wird.

* Wenn `updateChartData` `false` ist, wird nur der Arbeitsmappapfad aktualisiert. Die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert, sodass die Arbeitsmappe nicht verfügbar sein kann.
* Wenn `updateChartData` `true` ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL zu, wobei `updateChartData` auf `false` gesetzt ist. Es behält die Standardsdaten des Kreisdiagramms bei und speichert die Präsentation, ohne die nicht verfügbare Arbeitsmappe zu laden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

Um die zu einem Diagramm verknüpfte Arbeitsmappe zu ermitteln, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Arbeitsmappapfad ab.

Dieses Beispiel prüft das erste Objekt auf der ersten Folie einer Präsentation mit einer verknüpften externen Arbeitsmappe. Handelt es sich um ein Diagramm, das mit einer externen Arbeitsmappe verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise ändern, wie Sie Inhalte interner Arbeitsmappen ändern. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das das erste Objekt auf der ersten Folie ist und mit einer zugänglichen externen Arbeitsmappe verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original erhalten bleiben soll.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Präsentations‑Cache gespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) auf und setzen Sie [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) vor dem Öffnen der Präsentation auf `true`.

Das nachfolgende Java‑Beispiel stellt Arbeitsmappendaten für ein Diagramm wieder her, das das erste Objekt auf der ersten Folie ist und auf eine nicht verfügbare externe Arbeitsmappe verweist. Es greift über [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) und [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf die wiederhergestellten Daten zu:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Hier die wiederhergestellten Arbeitsmappendaten lesen oder ändern.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ist die externe Arbeitsmappe nicht verfügbar und ist die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Fallback ist, da der Cache möglicherweise Änderungen enthält, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm hat einen [Datentyp der Datenquelle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben der Arbeitsmappe eine Aktualisierung des Links erfordern kann.

**Kann ich Arbeitsmappen auf Netzwerkressourcen/Freigaben verwenden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von Remote‑Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Das Bearbeiten von zellbasierten Diagrammdaten kann zudem die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie der Arbeitsmappe, wenn das Original unverändert bleiben muss.

**Wie soll ich vorgehen, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert kein Passwort beim Verknüpfen. Ein gängiger Ansatz ist, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/java/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird ein Update dieser Datei in jedem Diagramm beim nächsten Laden der Daten wirksam.