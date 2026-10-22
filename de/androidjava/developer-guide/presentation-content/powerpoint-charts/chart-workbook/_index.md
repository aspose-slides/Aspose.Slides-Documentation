---
title: Diagramm‑Workbooks in Präsentationen auf Android verwalten
linktitle: Diagramm‑Workbook
type: docs
weight: 70
url: /de/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für Android via Java: verwalten Sie mühelos Diagramm‑Workbooks in PowerPoint- und OpenDocument‑Formaten, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Workbooks in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Workbook‑Streams liest und schreibt, Workbook‑Zellen als Diagrammdatenbeschriftungen verwendet, Arbeitsblatt‑Kollektionen zugreift und den Datentyp für Diagrammwerte festlegt.

Er behandelt außerdem die Arbeit mit externen Workbooks als Diagrammdatenquellen. Die Beispiele demonstrieren, wie man ein externes Workbook erstellt und zuweist, den Pfad eines mit einem Diagramm verknüpften externen Workbooks abruft und Diagrammdaten bearbeitet, wenn das Workbook verfügbar ist.

Für Workbook‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/androidjava/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus ausgeblendeten Zeilen und Spalten einbeziehen**

Verwenden Sie [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) um zu steuern, ob ein Diagramm Daten aus ausgeblendeten Arbeitsblattzeilen und -spalten plotten soll. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch ausgeblendete Zellen einzubeziehen. Diese Einstellung steuert das Plotten des Diagramms; sie blendet Arbeitsblatt‑Zeilen oder -Spalten nicht ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erste Form auf der ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den Quellbereich `A1:C4`. Zeile 3 und Spalte C sind ausgeblendet, doch ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (ausgeblendete Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (ausgeblendete Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf Quellzellen zu und lesen Sie [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) um deren Ausblendestatus zu prüfen. Diese Methode gibt den Ausblendestatus zurück, ohne ihn zu ändern. In dieser Datei ist B2 sichtbar, B3 gehört zur ausgeblendeten Zeile und C2 zur ausgeblendeten Spalte; das Beispiel gibt `false`, `true` und `true` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: Behalten Sie das eingebettete Workbook mit [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und laden Sie es mit [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) erneut. Beim Einbeziehen aller Zellen verwenden Sie außerdem [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-), um den vollständigen Bereich einschließlich der ausgeblendeten Februar‑Kategorie wiederherzustellen. Allein das Ändern des Flags reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategoriebeschriftungen dieses Beispiels zu aktualisieren.

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

            // Aktualisieren Sie die Diagrammdaten aus dem eingebetteten Workbook.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Stellen Sie den vollständigen Quellbereich wieder her, einschließlich ausgeblendeter Kategorien.
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

Das Beispiel speichert zwei Versionen der Präsentation: eine nur mit den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die nachstehenden Bilder illustrieren die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Workbooks ausgeblendet.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine ausgeblendete Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) steuert, wie fehlende Werte angezeigt werden; sie schließt ausgeblendete Quelldaten nicht ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/androidjava/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Datenbereich eines Diagramms abrufen**

Bevor Sie Workbook‑Daten in einer vorhandenen Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblattzellen jedes Diagramm verwendet. Die Methode [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) gibt den aktuellen Datenbereich als arbeitsblattqualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblattname, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inklusiv. Die Dollar‑Zeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder sein Workbook zu ändern. Wenn das Diagramm kein Workbook als Datenquelle verwendet, wirft sie `InvalidOperationException`. Weitere Informationen finden Sie in der [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Formen direkt auf jeder Folie auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Verwendet ein Diagramm kein Workbook, gibt es eine Meldung aus und fährt mit dem nächsten Diagramm fort.

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

## **Diagrammdaten aus einem Workbook lesen und schreiben**

Aspose.Slides for Android via Java stellt die Methoden [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) bereit, mit denen Sie Diagramm‑Workbooks (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**, dass die Diagrammdaten in derselben Weise organisiert sein müssen oder eine ähnliche Struktur wie die Quelle aufweisen sollten.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erster Form auf der ersten Folie. Es liest das eingebettete Workbook in ein Byte‑Array, löscht die vorhandenen Serien und Kategorien und schreibt dasselbe Workbook zurück. Die Änderungen verbleiben im Speicher; das Beispiel speichert die Präsentation nicht.

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

### **Diagrammlayout nach Workbook‑Änderung validieren**

Wenn Sie ein eingebettetes Workbook durch ein modifiziertes ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategoriesammlungen bei. Diese Diskrepanz kann dazu führen, dass [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) mit einem Index‑out‑of‑range‑Fehler fehlschlägt. Löschen Sie die bestehenden Serien und Kategorien, bevor Sie das aktualisierte Workbook zurückschreiben. Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Workbook‑Bearbeitung stattfinden würde; das ausführbare Beispiel schreibt das ursprüngliche Workbook zurück und validiert das Layout im Speicher.

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

        // Ändern Sie hier die Workbook-Bytes, zum Beispiel mit Aspose.Cells.

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

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor das Workbook zurückgeschrieben wird. Bauen Sie die erforderlichen Serien‑ und Kategorien‑Zuordnungen für das aktualisierte Workbook neu auf, bevor Sie das Diagramm verwenden.

## **Benutzerdefinierte Zahlenformate für Workbook‑Zellen festlegen**

Verwenden Sie [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-), um zu steuern, wie numerische Werte im eingebetteten Workbook eines Diagramms angezeigt werden. Beispielsweise könnte ein Bericht eine Umrechnungsrate als Prozentsatz mit vier Dezimalstellen und einen Koeffizienten mit fünf Dezimalstellen anzeigen müssen. Beide Werte sollten numerisch bleiben, damit sie für Berechnungen und Diagramm‑Plotting verfügbar bleiben.

Ein Zahlenformat ändert die Anzeige, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12.5000%` an; es ersetzt die gespeicherte Zahl nicht durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0.12346` an, ohne den gespeicherten Wert zu runden. Ist das benutzerdefinierte Format ein leerer String (`""`), wird das von [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) zurückgegebene Format stattdessen verwendet.

Das folgende Beispiel erstellt ein Säulendiagramm und greift über [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf dessen Zellen zu. Auf Arbeitsblatt 0 enthält B2 die Umrechnungsrate und C2 den Koeffizienten. Beide Zellen liefern Diagrammwerte. Das Beispiel aktiviert zudem Wertbeschriftungen, die an die Quellformate gebunden sind.

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

Workbook‑Zellformate sind von Formaten getrennt, die direkt an Diagrammachsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert der Quellzelle, weil [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) auf `true` gesetzt ist und weil [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) ebenfalls `true` ist. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12.5000%` und `0.12346` an, wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes Zahlenformat, das mit [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) auf `0.00` gesetzt wurde, wobei [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) auf `false` steht.

Um eine Datenbeschriftung unabhängig zu formatieren, setzen Sie deren Quell‑Verknüpfungs‑Flag auf `false` und weisen ein Format mit [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) zu. Dies ändert das Format der Workbook‑Zelle nicht. Beispielsweise zeigt ein unabhängiges Beschriftungsformat `0.00` den ersten Wert als `0.13` an, während B2 weiterhin `12.5000%` anzeigt. Siehe [Diagrammdatenbeschriftungen](/slides/de/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) für eine direkte Beschriftungsformatierung.

Das Bild unten wurde aus der nach dem erneuten Öffnen gespeicherten Präsentation gerendert:

![Säulendiagramm mit quellverknüpften Beschriftungen, die 12,5000 % und 0,12346 anzeigen, und einer unabhängig formatierten Zahlenachse.](custom-cell-formats.png)

## **Eine Workbook‑Zelle als Diagrammdatenbeschriftung festlegen**

Sie können Text aus Workbook‑Zellen als Diagrammdatenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Blasendiagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

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

Die Methode [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) bietet Zugriff auf die Arbeitsblätter in einem Diagramm‑Workbook. Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und gibt jeden Arbeitsblattnamen in der Konsole aus.

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

## **Datentyp der Datenquelle angeben**

Series‑Punktwerte können auch direkt als numerische Literale gespeichert werden. Siehe [Serieswerte mit numerischen Literalen festlegen](/slides/de/androidjava/chart-series/#set-series-values-using-numeric-literals) für ein vollständiges Beispiel, das sie speichert und liest. Der Quellentyp der Punktwerte ist getrennt von der internen oder externen Workbook‑Konfiguration des Diagramms; die Verwendung numerischer Literale entfernt das eingebettete Workbook nicht automatisch.

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und legt zwei Seriennamen über unterschiedliche Datenquellen fest. Der erste Name verwendet ein String‑Literal; der zweite nutzt die Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Seriennamen.

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

## **Nicht unterstützte eingebettete Workbook‑Formate erkennen**

Aspose.Slides unterstützt das Excel‑Binär‑Workbook‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) auf [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Formen auf der ersten Folie einer vorhandenen Präsentation, überspringt Nicht‑Diagramm‑Formen und gibt für jedes Diagramm mit eingebettetem .xlsb‑Workbook eine Diagnosemeldung aus.

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

        // Lesen oder ändern Sie unterstützte Diagramm‑Workbook‑Daten hier.
    }
} finally {
    presentation.dispose();
}
```

## **Externes Workbook**

Aspose.Slides unterstützt die Verwendung externer Workbooks als Datenquelle für Diagramme.

### **Externes Workbook erstellen**

Verwenden Sie [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) und [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), um ein eingebettetes Diagramm‑Workbook in eine Datei zu exportieren und das Diagramm mit diesem externen Workbook zu verknüpfen.

Dieses Beispiel erstellt ein Kreisdiagramm mit Standarddaten und exportiert dessen Workbook. Es schließt das Schreiben der Datei ab, bevor das externe Workbook als Diagrammdatenquelle zugewiesen wird, und speichert dann die verknüpfte Präsentation.

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

### **Externes Workbook festlegen**

Mit der Methode [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) können Sie einem Diagramm ein externes Workbook als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zu einem externen Workbook zu aktualisieren (falls dieses verschoben wurde).

Obwohl Sie Daten in Workbooks, die an entfernten Speicherorten oder Ressourcen liegen, nicht direkt bearbeiten können, können solche Workbooks dennoch als externe Datenquelle verwendet werden. Wird ein relativer Pfad für ein externes Workbook angegeben, wird er automatisch in einen vollständigen Pfad konvertiert.

Dieses Beispiel verwendet ein externes Workbook, dessen Arbeitsblatt `Sheet1` einen Seriennamen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kreisdiagramm, verknüpft das Workbook und verwendet [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

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

Der Parameter `updateChartData` von [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) steuert, ob das Workbook geladen wird.

* Wenn `updateChartData` `false` ist, wird nur der Workbook‑Pfad aktualisiert. Die Diagrammdaten werden nicht aus dem Ziel‑Workbook geladen oder aktualisiert, sodass das Workbook nicht verfügbar sein kann.
* Wenn `updateChartData` `true` ist, werden die Diagrammdaten aus dem Ziel‑Workbook aktualisiert.

Das folgende Beispiel weist eine Platzhalter‑URL mit `updateChartData` = `false` zu. Es behält die Standarddaten des Kreisdiagramms bei und speichert die Präsentation, ohne das nicht verfügbare Workbook zu laden.

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

### **Pfad des externen Datenquellen‑Workbooks eines Diagramms ermitteln**

Um das mit einem Diagramm verknüpfte Workbook zu bestimmen, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Workbook‑Pfad ab.

Dieses Beispiel untersucht die erste Form auf der ersten Folie einer Präsentation mit einem verknüpften externen Workbook. Handelt es sich um ein Diagramm, das mit einem externen Workbook verknüpft ist, gibt das Beispiel [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

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

Sie können die Daten in externen Workbooks auf die gleiche Weise ändern wie den Inhalt interner Workbooks. Wenn ein externes Workbook nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist und mit einem erreichbaren externen Workbook verknüpft ist. Es setzt den zellbasierten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original‑Workbook unverändert bleiben soll.

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

### **Ein Workbook aus dem Diagramm‑Cache wiederherstellen**

Verwendet ein Diagramm ein externes Workbook, das fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Workbook aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)-Objekt, rufen Sie [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) auf und setzen Sie [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) auf `true`, bevor Sie die Präsentation öffnen.

Das folgende Java‑Beispiel stellt Workbook‑Daten für ein Diagramm wieder her, das die erste Form auf der ersten Folie ist und ein nicht verfügbares externes Workbook referenziert. Es greift über [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) und [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) auf die wiederhergestellten Daten zu:

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

        // Lesen oder ändern Sie die wiederhergestellten Workbook-Daten hier.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ist das externe Workbook nicht verfügbar und die Wiederherstellung deaktiviert, wirft Aspose.Slides eine Ausnahme. Aktivieren Sie die Wiederherstellung nur, wenn die Nutzung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache Änderungen am externen Workbook nach dem letzten Aktualisieren der Präsentation möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einem externen oder eingebetteten Workbook verknüpft ist?**

Ja. Ein Diagramm hat einen [Datentyp der Datenquelle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) und einen [Pfad zu einem externen Workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ist die Quelle ein externes Workbook, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Workbooks unterstützt und wie werden sie gespeichert?**

Ja. Gibt man einen relativen Pfad an, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben des Workbooks eine Aktualisierung des Links erfordern kann.

**Kann ich Workbooks verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Workbooks können als externe Datenquelle verwendet werden. Das direkte Bearbeiten entfernter Workbooks aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle genutzt werden.

**Überschreibt Aspose.Slides das externe XLSX beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Das Bearbeiten zellbasierter Diagrammdaten kann auch die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie des Workbooks, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/java/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dasselbe externe Workbook referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Zeigen sie alle auf dieselbe Datei, wird eine Aktualisierung dieser Datei in jedem Diagramm beim nächsten Laden der Daten reflektiert.