---
title: Hantera diagramdatapetiketter i presentationer med JavaScript
linktitle: Dataetikett
type: docs
url: /sv/nodejs-java/chart-data-label/
keywords:
- diagram
- datapetikett
- dataprecision
- procent
- etikettavstånd
- etikettposition
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdatapetiketter i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js via Java för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsarna att identifiera värden och förstå diagrammet. Denna artikel förklarar hur man formaterar värden, visar procenttal, läser etiketttext, styr etiketter utanför axelns maximum, justerar avståndet för kategorialetiketter och placerar etiketter i pajdiagram.

## **Ange dataprecision i diagrammets datapetiketter**

Använd [setNumberFormatOfValues](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) för att formatera serievärden. Detta exempel skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdeetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsavgränsare och två decimaler utan att ändra de underliggande värdena.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentandel av sin kategorisumma och texten tilldelas till textramen som returneras av [getTextFrameForOverriding](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Detta exempel använder standarddiagramdata och visar procenttal med två decimaler i ett 8‑punkts typsnitt. Kategorier med en totalsumma på noll hoppas över för att undvika division med noll. Omsätt den anpassade etiketttexten igen om diagramdata ändras.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in procenttecken med diagrammets datapetiketter**

När värden lagras som bråk, använd [setNumberFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) för att visa procenttal. Skicka `false` till [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) för att tillämpa etiketformatet oberoende av källcellerna.

Detta exempel skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje par av värden summeras till 1. Etiketformatet `0.0%` visar 0.30 som 30.0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit, 10‑punkts etikettext.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Läs den faktiska texten för datapetiketter**

Använd [getActualLabelText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) för att hämta texten som genereras av en datapetiketts inställningar. Detta är användbart när man extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standardformatet för [datapetiketter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som procent, och en annan använder anpassad text från [getTextFrameForOverriding](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Numret som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75%` tillsammans med kategori- och serienamnen. Anpassad text ersätter den genererade etikettexten. [getActualLabelText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) returnerar den resulterande etikettsträngen i båda fallen. Kontrollera [isVisible](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/isvisible/) separat, som visas ovan, när du bara vill extrahera synliga etiketter.

## **Styr datapetiketter utanför axelns maximum**

När du begränsar ett axelintervall manuellt kan vissa datapunkter överskrida dess maximum. Använd [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) för att kontrollera om deras datapetiketter visas. Denna inställning ändrar etiketters synlighet; den ändrar inte axelintervallet eller de underliggande datavärdena.

Exemplet nedan skapar ett 2D grupprad i stapeldiagram med värdena 60 och 120. Det skickar `false` till [setAutomaticMaxValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) och sätter maximum till 100 med [setMaxValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/axis/setmaxvalue/) på den vertikala axeln. Den första bilden tillåter etiketter utöver maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdeetiketter med [setShowValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). Diagramnivåinställningen aktiverar inte värdevisning i sig själv eller åsidosätter en enskild etikett som har inaktiverad värdevisning. Detta exempel aktiverar värden för hela serien och använder [setPosition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabelformat/setposition/) för att placera etiketter vid varje kolumns yttre ända.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Följande bilder visar de sparade bilderna renderade av Microsoft PowerPoint. Med `true` är etiketten **120** synlig vid den övre gränsen; med `false` är den dold. Etiketten **60** förblir synlig, axelmaximum förblir **100**, och den andra datapunkten förblir **120** i båda fallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.

{{% /alert %}}

## **Ange etikettavstånd från en axel**

Använd [setLabelOffset](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/axis/setlabeloffset/) för att kontrollera avståndet mellan kategorialetiketter och axeln. Värdet är en procentandel av den maximala teckenstorleken för axelns etiketter. Detta exempel skapar ett grupprad i stapeldiagram och sätter den horisontella axelns etikettavstånd till 500. Denna inställning påverkar kategorialetiketter snarare än etiketter som är fästa vid enskilda datapunkter.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Justera etikettens position**

I ett pajdiagram justeras datapetikettpositionerna för att förbättra avståndet och skapa utrymme för ledningslinjer.

Detta exempel visar värdet för den första datapunkten, placerar dess etikett utanför segmentet och justerar dess horisontella och vertikala förskjutning med [setX](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/setx/) och [setY](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datalabel/sety/). Dessa förskjutningar är relativa till diagrammets bredd respektive höjd.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Hur kan jag förhindra att datapetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, ledningslinjer och minskad teckenstorlek; vid behov dölja vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek och verifiera att teckensnittet är tillgängligt i renderingsmiljön för att undvika ersättning.