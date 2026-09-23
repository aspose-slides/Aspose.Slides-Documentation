---
title: Diagramm-Datenetiketten in Präsentationen auf Android verwalten
linktitle: Datenetikett
type: docs
url: /de/androidjava/chart-data-label/
keywords:
- Diagramm
- Datenetikett
- Datenpräzision
- Prozentsatz
- Etikettenabstand
- Etikettenposition
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramm-Datenetiketten in PowerPoint-Präsentationen mit Aspose.Slides für Android via Java hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---
## **Einleitung**

Datenetiketten zeigen Informationen zu Diagrammserien und einzelnen Datenpunkten an und helfen den Lesern, Werte zu erkennen und das Diagramm zu verstehen. Dieser Artikel erklärt, wie man Werte formatiert, Prozentsätze anzeigt, den Etikettentext ausliest, den Abstand der Kategorienachsen‑Etiketten anpasst und die Position von Kreisdiagramm‑Etiketten festlegt.

## **Datenpräzision in Diagramm‑Datenetiketten festlegen**

Verwenden Sie [setNumberFormatOfValues](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-), um Serienwerte zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Standarddaten, zeigt dessen Datentabelle an und aktiviert Wertetiketten für die erste Serie. Das Format `#,##0.00` zeigt ein Tausendertrennzeichen und zwei Dezimalstellen, ohne die zugrunde liegenden Werte zu ändern.

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

Für ein gestapeltes Säulendiagramm berechnen Sie jeden Wert als Prozentsatz des Gesamtsummedits seiner Kategorie und weisen den Text dem Textfeld zu, das von [getTextFrameForOverriding](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) zurückgegeben wird. Dieses Beispiel verwendet die Standarddiagrammdaten und zeigt Prozentsätze mit zwei Dezimalstellen in einer Schriftgröße von 8 pt an. Kategorien mit einer Gesamtsumme von Null werden übersprungen, um eine Division durch Null zu vermeiden. Berechnen Sie den benutzerdefinierten Etikettentext neu, wenn sich die Diagrammdaten ändern.

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

## **Prozentzeichen mit Diagramm‑Datenetiketten festlegen**

Wenn Werte als Brüche gespeichert sind, verwenden Sie [setNumberFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-), um Prozentsätze anzuzeigen. Übergeben Sie `false` an [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-), um das Etikettenformat unabhängig von den Quellzellen anzuwenden.

Dieses Beispiel erstellt ein 100 % gestapeltes Säulendiagramm mit roten und blauen Serien über vier Kategorien. Jeder Werte‑Paar addiert sich zu 1. Das Etikettenformat `0.0%` zeigt 0.30 als 30,0 % an, während die vertikale Achse zwei Dezimalstellen verwendet. Beide Serien nutzen weiße Etiketten mit 10 pt Schriftgröße.

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

## **Den tatsächlichen Text von Datenetiketten auslesen**

Verwenden Sie [getActualLabelText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--), um den durch die Einstellungen eines Datenetiketts erzeugten Text abzurufen. Dies ist nützlich, wenn Etiketten für Berichte extrahiert, Präsentationsinhalte durchsucht oder erzeugte Diagramme validiert werden sollen. Im folgenden Beispiel kombiniert das Standard‑[data label format](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabelformat/) den Namen jeder Kategorie, den Namen der Serie und den Wert. Ein Punkt formatiert seinen Wert als Prozentsatz, ein anderer verwendet benutzerdefinierten Text aus [getTextFrameForOverriding](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Die in einem Datenpunkt gespeicherte Zahl bleibt `0.75`, selbst wenn ihr Etikett `75 %` zusammen mit den Kategorien‑ und Seriennamen anzeigt. Benutzerdefinierter Text ersetzt den generierten Etikettentext. [getActualLabelText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) liefert in beiden Fällen den resultierenden Etiketten‑String. Prüfen Sie [isVisible](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idatalabel/#isVisible--) separat, wie oben gezeigt, wenn Sie nur sichtbare Etiketten extrahieren möchten.

## **Abstand von Etiketten zu einer Achse festlegen**

Verwenden Sie [setLabelOffset](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-), um den Abstand zwischen den Kategorienachsen‑Etiketten und der Achse zu steuern. Der Wert ist ein Prozentsatz der maximalen Schriftgröße der Achsenetiketten. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm und setzt den horizontalen Achsen‑Etiketten‑Versatz auf 500. Diese Einstellung wirkt sich auf Kategorienachsen‑Etiketten aus, nicht auf Etiketten, die einzelnen Datenpunkten zugeordnet sind.

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

Bei einem Kreisdiagramm passen Sie die Position der Datenetiketten an, um den Abstand zu verbessern und Platz für Führungslinien zu schaffen.

Dieses Beispiel zeigt den Wert des ersten Datenpunkts, platziert sein Etikett außerhalb des Segments und passt die horizontalen und vertikalen Versätze mit [setX](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutable/#setX-float-) und [setY](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ilayoutable/#setY-float-) an. Diese Versätze sind relativ zur Diagrammbreite bzw. -höhe.

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

![Kreisdiagramm mit angepasster Datenetikettenposition](pie-chart-adjusted-label.png)

## **FAQ**

**Wie kann ich verhindern, dass Datenetiketten bei dichten Diagrammen überlappen?**

Kombinieren Sie automatische Etikettenplatzierung, Führungslinien und reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Etiketten nur für Extremwerte bzw. Schlüsselpunkte anzeigen.

**Wie kann ich Etiketten nur für Null‑, Negative‑ oder Leerewerte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Etiketten aktivieren, und schalten Sie die Anzeige für Werte von 0, negative Werte oder fehlende Werte gemäß einer definierten Regel aus.

**Wie stelle ich einen einheitlichen Etikettenstil beim Export in PDF/Bilder sicher?**

Setzen Sie explizit Schriftfamilie und -größe und überprüfen Sie, dass die Schrift im Rendering‑Umfeld verfügbar ist, um ein Fallback zu vermeiden.