---
title: Anpassen von Kreisdiagrammen in Präsentationen mit Java
linktitle: Kreisdiagramm
type: docs
url: /de/java/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und Anpassen von Kreisdiagrammen in Java mit Aspose.Slides. Sekundäre Diagramme konfigurieren, Datenbeschriftungen anzeigen und automatische Segmentfarben in PowerPoint anwenden."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Diagrammoptionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme konfiguriert und wie man die automatische Farbzuweisung für die Segmente eines Standard‑Kreisdiagramms aktiviert.

Die Beispiele konzentrieren sich auf Aufgaben zur Diagrammanpassung, wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Reihen‑ und Beschriftungseinstellungen, das Ersetzen der Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für sekundäre Diagramme bei Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagrammen**

Aspose.Slides for Java unterstützt sekundäre Diagrammoptionen für Pie‑of‑Pie‑ und Bar‑of‑Pie‑Diagramme. Diese Optionen steuern die Größe des sekundären Diagramms und wie Datenpunkte zwischen den beiden Diagrammen aufgeteilt werden.

Im folgenden Beispiel wird ein Pie‑of‑Pie‑Diagramm in einer neuen Präsentation erstellt und die Werte der Datenpunkte werden als Beschriftungen angezeigt. Die Methode [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) legt die Größe des sekundären Diagramms auf 149 % des Hauptdiagramms fest. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) wählt die prozentbasierte Aufteilung, und [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) setzt die Schwelle auf 53 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Werte anzeigen und das sekundäre Diagramm konfigurieren.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Auswahl von Kategorien für das sekundäre Diagramm**

Verwenden Sie benutzerdefinierte Aufteilung, wenn Sie bestimmte Kategorien im sekundären Diagramm gruppieren möchten, unabhängig von ihren prozentualen Werten. Zum Beispiel könnte ein Verkaufsbericht Online und Events zusammen anzeigen, damit die Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Rufen Sie [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) mit [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) auf und wählen Sie die Punkte über [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Die [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-)‑Methode der Sammlung akzeptiert einen nullbasierten Index in der Reihe; verwenden Sie [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) zum Hinzufügen eines Datenpunktobjekts. In diesem Beispiel wählt Index 1 Online aus, und der Punkt bei Index 3 wählt Events aus. Partners wird ebenfalls temporär hinzugefügt und dann über [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) ausgeschlossen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Ersetze die Standarddaten durch Verkäufe nach Kanal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Wähle Online anhand seines nullbasierten Index und Events anhand seines Datenpunktobjekts aus.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Schließe Partners von der Auswahl aus, ohne die Quelldaten zu löschen.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Diagramm. Im primären Diagramm werden sie durch ein kombiniertes Segment mit dem Wert 45 vertreten, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl lässt es im primären Diagramm erhalten; die Kategorie oder ihr Wert werden nicht aus den Quelldaten des Diagramms entfernt.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Grafik des Pie of Pie-Diagramms mit Online und Events im sekundären Diagramm und ihrem kombinierten Wert von 45 im primären Diagramm](pie_of_pie_custom.png)

## **Automatisches Zuweisen von Farben zu Kreisdiagramm‑Segmenten**

Aspose.Slides for Java kann automatisch verschiedene Farben zu den Segmenten eines Kreisdiagramms zuweisen. Das folgende Beispiel erstellt ein Kreisdiagramm mit zentriertem Titel und ersetzt die Standarddaten durch drei Quartalskategorien und deren Werte. Die Methode [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) für jede Scheibe eine unterschiedliche Farbe aktiviert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Füge einen zentrierten Diagrammtitel hinzu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ersetze die Standarddaten mithilfe des ersten Arbeitsblatts.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Werte anzeigen und den Segmenten unterschiedliche Farben zuweisen.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Werden die Varianten Pie‑of‑Pie und Bar‑of‑Pie unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ein sekundäres Diagramm für Kreisdiagramme, einschließlich der Typen Pie‑of‑Pie und Bar‑of‑Pie.

**Kann ich nur das Diagramm als Bild (z. B. PNG) exportieren?**

Ja, Sie können [das Diagramm selbst als Bild exportieren](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (wie PNG), ohne die gesamte Präsentation zu exportieren.