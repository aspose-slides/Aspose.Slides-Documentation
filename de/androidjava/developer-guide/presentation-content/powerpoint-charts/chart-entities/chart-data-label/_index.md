---
title: Diagrammdatenbeschriftungen in Präsentationen auf Android verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/androidjava/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammdatenbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für Android über Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einführung**

Datenbeschriftungen zeigen Informationen über Diagrammserien und einzelne Datenpunkte an und helfen den Lesern, Werte zu identifizieren und das Diagramm zu verstehen. Dieser Artikel erklärt, wie man Werte formatiert, Prozentsätze anzeigt, Beschriftungstext liest, Beschriftungen jenseits des Achsenmaximums steuert, den Abstand von Kategorienachsenbeschriftungen anpasst und Kuchendiagrammbeschriftungen positioniert.

## **Datenpräzision in Diagrammdatenbeschriftungen festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) , um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertebeschriftungen für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen an, ohne die zugrunde liegenden Werte zu ändern.

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

## **Prozentsätze als Beschriftungen anzeigen**

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsummens der jeweiligen Kategorie und weisen den Text dem Textrahmen zu, der von [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer 8‑Punkt‑Schrift an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Beschriftungstext neu, wenn sich die Diagrammdaten ändern.

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

## **Prozentzeichen mit Diagrammdatenbeschriftungen festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) , um Prozentsätze anzuzeigen. Übergeben Sie `false` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) , um das Beschriftungsformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jede Wertepaare summieren sich zu 1. Das Beschriftungsformat `0.0%` zeigt 0,30 als 30,0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien verwenden weiße Beschriftungen mit 10 Punkt.

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

## **Den tatsächlichen Text von Datenbeschriftungen lesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) , um den durch die Einstellungen einer Datenbeschriftung erzeugten Text abzurufen. Dies ist nützlich beim Extrahieren von Beschriftungen für Berichte, beim Durchsuchen von Präsentationsinhalten oder beim Validieren generierter Diagramme. Im folgenden Beispiel kombiniert das Standard‑[Datenbeschriftungsformat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) jeden Kategorienamen, Seriennamen und Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, und ein anderer verwendet benutzerdefinierten Text aus [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn seine Beschriftung `75 %` zusammen mit Kategorie‑ und Serientitel anzeigt. Benutzerdefinierter Text ersetzt den generierten Beschriftungstext. [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) gibt in beiden Fällen die resultierende Beschriftungszeichenfolge zurück. Prüfen Sie [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) separat, wie oben gezeigt, wenn Sie nur sichtbare Beschriftungen extrahieren möchten.

## **Datenbeschriftungen jenseits des Achsenmaximums steuern**

Wenn Sie einen Achsenbereich manuell begrenzen, können einige Datenpunkte dessen Maximum überschreiten. Verwenden Sie [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) , um zu steuern, ob deren Datenbeschriftungen angezeigt werden. Diese Einstellung ändert die Sichtbarkeit der Beschriftungen; sie ändert weder das Achsenmaximum noch die zugrunde liegenden Datenwerte.

Das Beispiel unten erstellt ein 2D‑Cluster‑Säulendiagramm mit den Werten 60 und 120. Es übergibt `false` an [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) und setzt das Maximum auf 100 mit [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) auf der vertikalen Achse. Die erste Folie erlaubt Beschriftungen über dem Maximum; eine Kopie dieser Folie deaktiviert sie. Beide Folien werden in `DataLabelsOverMaximum.pptx` gespeichert.

Aktivieren Sie Wertebeschriftungen mit [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Die Diagramm‑Einstellung aktiviert die Anzeige von Werten nicht automatisch und überschreibt nicht die deaktivierte Anzeige einer einzelnen Beschriftung. Dieses Beispiel aktiviert Werte für die gesamte Serie und verwendet [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) , um Beschriftungen am äußeren Ende jeder Säule zu platzieren.

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

Die folgenden Bilder zeigen die gespeicherten Folien, wie sie von Microsoft PowerPoint gerendert werden. Bei `true` ist die Beschriftung **120** an der oberen Grenze sichtbar; bei `false` ist sie ausgeblendet. Die Beschriftung **60** bleibt sichtbar, das Achsenmaximum bleibt bei **100**, und der zweite Datenpunkt bleibt in beiden Fällen **120**.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint‑Diagramm, das die Werte‑Beschriftung 120 bei einem Achsen‑Maximum von 100 anzeigt](data-labels-over-maximum-true.png) | ![PowerPoint‑Diagramm, das die Werte‑Beschriftung 120 bei einem Achsen‑Maximum von 100 ausblendet](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dieses Beispiel verwendet ein 2D‑Säulendiagramm mit einer Wertachse. Diagramme ohne Wertachse, wie Kuchen‑ und Donut‑Diagramme, besitzen kein Achsen‑Maximum, das auf diese Weise begrenzt werden könnte.
{{% /alert %}}

## **Abstand der Beschriftung von einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) , um den Abstand zwischen den Kategorienachsen‑Beschriftungen und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenbeschriftungen. Dieses Beispiel erstellt ein Cluster‑Säulendiagramm und setzt den horizontalen Achsen‑Beschriftungs‑Offset auf 500. Diese Einstellung wirkt sich auf die Kategorienachsen‑Beschriftungen aus, nicht auf Beschriftungen, die einzelnen Datenpunkten zugeordnet sind.

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

## **Beschriftungsposition anpassen**

Bei einem Kuchendiagramm passen Sie die Positionen der Datenbeschriftungen an, um den Abstand zu verbessern und Platz für Leitlinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert seine Beschriftung außerhalb des Segmentes und passt die horizontalen sowie vertikalen Versätze mit [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) und [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) an. Diese Versätze beziehen sich jeweils auf die Diagrammbreite bzw. -höhe.

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

![Kuchendiagramm mit angepasster Datenbeschriftungsposition](pie-chart-adjusted-label.png)

## **Leitlinien formatieren**

Wenn Kuchendiagrammbeschriftungen außerhalb ihrer Segmente liegen, helfen Leitlinien den Lesern, jeden Wert dem richtigen Segment zuzuordnen. Eine kontrastierende Farbe und eine leicht dickere Linie können diese Verbindungen leichter nachvollziehbar machen, während Transparenz und ein gestrichelter Stil die Linien optisch unaufdringlich halten.

Verwenden Sie [getLeaderLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) , um Leitlinien auf Ebene der Datenbeschriftungssammlung einer Serie zu formatieren. Die Einstellungen in `series.getLabels().getLeaderLinesFormat().getLine()` gelten für die Sammlung, nicht für eine einzelne Beschriftung.

Dieses Beispiel erstellt ein Kuchendiagramm mit Standarddaten, zeigt Werte außerhalb der Segmente an und aktiviert [setShowLeaderLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). Es verschiebt zwei Beschriftungen weiter von ihren Segmenten mittels [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) und [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) Versätzen, angegeben als Bruchteile von Diagrammbreite und -höhe. Keine Eingabepräsentation ist erforderlich.

Die [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) der Linie setzt eine solide blaue Farbe mit einem Alphawert von 191 von 255, was etwa 25 % Transparenz ergibt. [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) legt die Stärke auf 2 Punkt fest, und [setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) macht die Linie gestrichelt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Verschiebe zwei Beschriftungen weiter von ihren Segmenten.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(Color.argb(191, 30, 90, 160));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Aktivieren von Leitlinien garantiert nicht, dass für jede Beschriftung eine Linie erscheint. Die Sichtbarkeit hängt von der Platzierung der Beschriftung und dem Layout‑Verhalten des Diagramms ab. In diesem Beispiel haben die beiden versetzten Beschriftungen sichtbare Leitlinien; die Beschriftungen, die nahe an ihren Segmenten bleiben, benötigen keine.

Das folgende Bild zeigt die gespeicherte `FormattedLeaderLines.pptx`, gerendert mit Aspose.Slides:

![Kuchendiagramm mit blauen, halbtransparenten, gestrichelten Leitlinien, die zwei Außen‑Beschriftungen mit ihren Segmenten verbinden](formatted-leader-lines.png)

## **Mehrere Zeilen von Datenbeschriftungen über einem Säulendiagramm hinzufügen**

Dieses Beispiel erstellt ein Säulendiagramm mit zwei Reihen von Datenbeschriftungen über dem Plot‑Bereich. Serie A zeigt die sichtbaren Säulen, während Serie B und Serie C die zusätzlichen Beschriftungen bereitstellen. Ihre Säulen werden ausgeblendet, indem Füllung und Kontur entfernt werden. Die Methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) richtet alle drei Serien an den gleichen Kategorien‑Mittelpunkten aus.

Die Einstellungen des [ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) reservieren Platz für die Beschriftungsreihen. Nach dem Aufruf von [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) werden die Standardpositionen berechnet; [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) und [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) erhalten die horizontale Ausrichtung und wenden vertikale Versätze an, um die Beschriftungen in zwei Reihen anzuordnen. Die Zahlen bleiben Datenbeschriftungen, die mit den Serienwerten verknüpft sind; nur die Zeilen‑Überschriften sind separate Textformen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Verstecke die Spalten von B und C, aber behalte deren Datenbeschriftungen bei.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.InsideBase);
        }
    }

    // Richte alle drei Serien an den selben Kategorienzentren aus.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // Verwende weniger Gitternetzlinien für dieses kompakte Beispiel.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reserviere Platz über dem Plot für zwei Zeilen von Datenbeschriftungen.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Behalte die Standard‑horizontale Position bei. Y ist ein Versatz von
            // der Standard‑Beschriftungsposition, ausgedrückt als Bruchteil der Diagrammhöhe.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Nur die Zeilenüberschrift ist eine separate Textform.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Säulendiagramm mit zwei Reihen von Datenbeschriftungen über dem Plot‑Bereich](multiple-rows-of-labels.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenbeschriftungen bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Beschriftungsplatzierung, Leitlinien und eine reduzierte Schriftgröße; bei Bedarf Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für Extremwerte bzw. Schlüsselpunkte anzeigen.

**Wie kann ich Beschriftungen nur für Null‑, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Export in PDF/Bilder sicherstellen?**

Setzen Sie explizit die Schriftfamilie und -größe und prüfen Sie, ob die Schrift im Render‑Umfeld verfügbar ist, um ein Fallback zu vermeiden.