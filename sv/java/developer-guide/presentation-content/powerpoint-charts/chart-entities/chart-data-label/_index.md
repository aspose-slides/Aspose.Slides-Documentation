---
title: "Hantera diagramdataetiketter i presentationer med Java"
linktitle: "Dataetikett"
type: docs
url: /sv/java/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etiketavstånd
- etiketaplacering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för Java för mer engagerande bildspel."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsarna att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procent, läser etiketttext, styr etiketter utanför axelns maximum, justerar avståndet mellan kategoriaxelns etiketter och placerar cirkeldiagrameetiketter.

## **Ställ in dataprecision i diagrammets dataetiketter**

Använd [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) för att formatera serievärden. Det här exemplet skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdeetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsseparator och två decimaler utan att ändra de underliggande värdena.

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

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentandel av sin kategori totalsumma och texten tilldelas textramen som returneras av [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Detta exempel använder diagrammets standarddata och visar procent med två decimaler i en 8‑punkts teckensnitt. Kategorier med en total på noll hoppas över för att undvika division med noll. Om diagramdata ändras måste den anpassade etiketttexten beräknas om.

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

## **Ställ in procenttecken med diagrammets dataetiketter**

När värden lagras som bråk, använd [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) för att visa procent. Skicka `false` till [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) för att tillämpa etikettformatet oberoende av källcellerna.

Det här exemplet skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje värdepar summeras till 1. Etikettformatet `0.0%` visar 0,30 som 30,0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit etiketttext i 10 punkter.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color[] seriesColors = { Color.RED, Color.BLUE };
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

## **Läs den faktiska texten för dataetiketter**

Använd [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) för att hämta den text som genereras av en dataetiketts inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som procent, och en annan använder anpassad text från [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

Numret som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75 %` tillsammans med kategori- och serienamn. Anpassad text ersätter den genererade etiketttexten. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) returnerar den resulterande etikettsträngen i båda fallen. Kontrollera [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) separat, som visas ovan, när du bara vill extrahera synliga etiketter.

## **Styr dataetiketter utanför axelns maximum**

När du begränsar ett axelintervall manuellt kan vissa datapunkter överstiga dess maximum. Använd [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) för att styra om deras dataetiketter visas. Denna inställning ändrar etikettens synlighet; den ändrar inte axelintervallet eller de underliggande datavärdena.

Exemplet nedan skapar ett 2D-klustrat stapeldiagram med värdena 60 och 120. Det skickar `false` till [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) och sätter maximum till 100 med [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) på den vertikala axeln. Den första bilden tillåter etiketter utanför maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdeetiketter med [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Diagramnivåinställningen aktiverar inte värdevisning i sig eller åsidosätter en enskild etikett som har inaktiverad värdevisning. Detta exempel aktiverar värden för hela serien och använder [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) för att placera etiketter i slutet av varje stapel på utsidan.

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

Följande bilder visar de sparade bilderna som renderats i Microsoft PowerPoint. Med `true` är etiketten **120** synlig vid den övre gränsen; med `false` är den dold. Etiketten **60** förblir synlig, axelmaximum förblir på **100**, och den andra datapunkten förblir **120** i båda fallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint-diagram som visar värdeetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-true.png) | ![PowerPoint-diagram som döljer värdeetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Det här exemplet använder ett 2D-stapeldiagram med en värdeaxel. Diagram utan värdeaxel, såsom paj- och donutdiagram, har ingen axelmaximum att begränsa på detta sätt.
{{% /alert %}}

## **Ställ in etiketavstånd från en axel**

Använd [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) för att styra avståndet mellan kategoriaxelns etiketter och axeln. Värdet är en procentandel av den maximala teckenstorleken för axelns etiketter. Detta exempel skapar ett klustrat stapeldiagram och sätter den horisontella axelns etiketavstånd till 500. Denna inställning påverkar kategoriaxelns etiketter snarare än etiketter som är kopplade till enskilda datapunkter.

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

## **Justera etikettplacering**

I ett pajdiagram justeras dataetiketternas positioner för att förbättra avståndet och ge plats för ledlinjer.

Det här exemplet visar värdet för den första datapunkten, placerar dess etikett utanför sektorn och justerar dess horisontella och vertikala offset med hjälp av [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) och [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Dessa offset är relativa till diagrammets bredd respektive höjd.

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

![Pajdiagram med en justerad dataetikettposition](pie-chart-adjusted-label.png)

## **Lägg till flera rader med dataetiketter ovanför ett stapeldiagram**

Det här exemplet skapar ett stapeldiagram med två rader dataetiketter ovanför plotområdet. Serie A visar de synliga staplarna, medan Serie B och Serie C tillhandahåller de extra etiketterna. Deras staplar är dolda genom att ta bort fyllning och kontur. Metoden [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) justerar alla tre serier med samma kategoricentrat.

Inställningarna för [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) reserverar utrymme för etikett raderna. Efter att [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) beräknat standardpositionerna, bevarar [DataLabel.setX och DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) den horisontella justeringen och tillämpar vertikala offset för att ordna etiketterna i två rader. Siffrorna förblir dataetiketter knutna till serievärdena; endast radrubrikerna är separata textformer.

```java
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
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Dölj kolumnerna för B och C, men behåll deras dataetiketter.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Justera alla tre serier med samma kategoricentrat.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Använd färre rutnätslinjer för detta kompakta exempel.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reservera utrymme ovanför diagrammet för två rader med dataetiketter.
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
            // Behåll den horisontella standardpositionen. Y är ett avstånd från
            // standardetikettpositionen, uttryckt som en bråkdel av diagramhöjden.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Endast radrubriken är en separat textform.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hur kan jag förhindra att dataetiketter överlappar på täta diagram?**

Kombinera automatisk placering av etiketter, ledlinjer och minskad teckenstorlek; om nödvändigt, dölj vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden som är 0, negativa eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek och verifiera att teckensnittet är tillgängligt i renderingsmiljön för att undvika ersättning.