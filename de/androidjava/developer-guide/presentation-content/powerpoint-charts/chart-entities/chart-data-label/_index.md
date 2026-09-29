---
title: Diagrammdateneetiketten in Präsentationen auf Android verwalten
linktitle: Dateneetikett
type: docs
url: /de/androidjava/chart-data-label/
keywords:
- Diagramm
- Dateneetikett
- Datenpräzision
- Prozentsatz
- Etikettenabstand
- Etikettenposition
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdateneetiketten in PowerPoint-Präsentationen mithilfe von Aspose.Slides für Android über Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einführung**

Dateneetiketten zeigen Informationen zu Diagrammserien und einzelnen Datenpunkten an und helfen den Lesern, Werte zu erkennen und das Diagramm zu verstehen. Dieser Artikel erklärt, wie Werte formatiert, Prozentsätze angezeigt, Etikettentext gelesen, Etiketten jenseits des Achsenmaximums gesteuert, der Abstand von Kategorienachsenetiketten angepasst und Etiketten in Kreisdiagrammen positioniert werden.

## **Datenpräzision in Diagrammdateneetiketten festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) , um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertetiketten für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prozentsätze als Etiketten anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsumme seiner Kategorie und weisen den Text dem von [getTextFrameForOverriding](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) zurückgegebenen Textfeld zu. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8-Punkt-Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Etikettentext neu, wenn sich die Diagrammdaten ändern.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prozentzeichen bei Diagrammdateneetiketten festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) , um Prozentsätze anzuzeigen. Übergeben Sie `false` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) , um das Etikettenformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100% gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jedes Wertepaar summiert sich zu 1. Das Etikettenformat `0.0%` zeigt 0.30 als 30.0% an, während die senkrechte Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Etikettentexte mit 10-Punkt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    int[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Den tatsächlichen Text von Dateneetiketten lesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) , um den von den Einstellungen eines Dateneetiketts erzeugten Text abzurufen. Dies ist nützlich beim Extrahieren von Etiketten für Berichte, Durchsuchen von Präsentationsinhalten oder Validieren erzeugter Diagramme. Im folgenden Beispiel kombiniert das standardmaessige [data label format](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/) den Namen jeder Kategorie, den Namen der Serie und den Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, und ein anderer verwendet benutzerdefinierten Text aus [getTextFrameForOverriding](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, auch wenn ihr Etikett `75%` zusammen mit den Kategorien- und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den erzeugten Etikettentext. [getActualLabelText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) gibt den resultierenden Etikettenstring in jedem Fall zurueck. Pruefen Sie [isVisible](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#isVisible--) separat, wie oben gezeigt, wenn Sie nur sichtbare Etiketten extrahieren moechten.

## **Dateneetiketten jenseits des Achsenmaximums steuern**

Wenn Sie einen Achsenbereich manuell begrenzen, koennen einige Datenpunkte das Maximum ueberschreiten. Verwenden Sie [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) , um zu steuern, ob deren Dateneetiketten angezeigt werden. Diese Einstellung aendert die Sichtbarkeit der Etiketten; sie aendert weder den Achsenbereich noch die zugrunde liegenden Datenwerte.

Das folgende Beispiel erstellt ein 2D gruppiertes Saeulendiagramm mit den Werten 60 und 120. Es uebergibt `false` an [setAutomaticMaxValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) und setzt das Maximum auf 100 mit [setMaxValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) auf der senkrechten Achse. Die erste Folie erlaubt Etiketten jenseits des Maximums; eine Kopie dieser Folie deaktiviert sie. Beide Folien werden in `DataLabelsOverMaximum.pptx` gespeichert.

Aktivieren Sie Wertetiketten mit [setShowValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Die Diagrammebene-Einstellung aktiviert die Wertanzeige nicht von allein und ueberschreibt nicht die deaktivierte Wertanzeige eines einzelnen Etiketts. Dieses Beispiel aktiviert Werte fuer die gesamte Serie und verwendet [setPosition](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) , um Etiketten am aeusseren Ende jeder Spalte zu platzieren.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die folgenden Bilder zeigen die in Microsoft PowerPoint gerenderten gespeicherten Folien. Bei `true` ist das Etikett **120** an der oberen Grenze sichtbar; bei `false` ist es ausgeblendet. Das Etikett **60** bleibt sichtbar, das Achsenmaximum bleibt bei **100**, und der zweite Datenpunkt bleibt in beiden Faellen **120**.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dieses Beispiel verwendet ein 2D-Saeulendiagramm mit einer Werteachse. Diagramme ohne Werteachse, wie Kreis- und Donut-Diagramme, besitzen kein Achsenmaximum, das auf diese Weise begrenzt werden kann.
{{% /alert %}}

## **Etikettenabstand von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) , um den Abstand zwischen den Kategorienachsen-Etiketten und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgroesse der Achsenetiketten. Dieses Beispiel erstellt ein gruppiertes Saeulendiagramm und setzt den horizontalen Achsenetiketten-Versatz auf 500. Diese Einstellung wirkt sich auf die Kategorienachsen-Etiketten aus, nicht auf Etiketten, die einzelnen Datenpunkten zugeordnet sind.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Etikettenposition anpassen**

Bei einem Kreisdiagramm passen Sie die Positionen der Dateneetiketten an, um den Abstand zu optimieren und Platz fuer Fuehrungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert dessen Etikett ausserhalb des Segmentes und passt die horizontalen und vertikalen Versaeze mit [setX](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutable/#setX-float-) und [setY](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutable/#setY-float-) an. Diese Versaeze beziehen sich jeweils auf die Diagrammbreite bzw. -hoehe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kreisdiagramm mit angepasster Dateneetikettenposition](pie-chart-adjusted-label.png)

## **FAQ**

**How can I prevent data labels from overlapping on dense charts?**

Kombinieren Sie automatische Etikettenplatzierung, Fuehrungslinien und eine kleinere Schriftgroesse; falls nötig, blenden Sie einige Felder (z.B. die Kategorie) aus oder zeigen Sie Etiketten nur fuer extreme Werte oder wichtige Punkte an.

**How can I disable labels only for zero, negative, or empty values?**

Filtern Sie Datenpunkte, bevor Sie Etiketten aktivieren, und deaktivieren Sie die Anzeige fuer Werte von 0, negative Werte oder fehlende Werte gemaess einer definierten Regel.

**How can I ensure a consistent label style when exporting to PDF/images?**

Setzen Sie explizit die Schriftfamilie und -groesse und pruefen Sie, dass die Schrift im Rendering-Umfeld verfuegbar ist, um ein Zurueckgreifen auf Ersatzschriften zu vermeiden.