---
title: Beheer grafiekgegevenslabels in presentaties met JavaScript
linktitle: Gegevenslabel
type: docs
url: /nl/nodejs-java/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint‑presentaties met JavaScript en Aspose.Slides voor Node.js via Java voor boeiendere dia's."
---
## **Introductie**

Gegevenslabels tonen informatie over grafiekreeksen en individuele gegevenspunten, zodat lezers waarden kunnen identificeren en de grafiek begrijpen. Dit artikel legt uit hoe waarden te formatteren, percentages weer te geven, labeltekst te lezen, labels buiten de as‑maximum te controleren, de afstand tussen categorie‑as‑labels aan te passen en labels voor cirkeldiagrammen te positioneren.

## **Gegevensprecisie instellen in grafiekgegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) om de waarden van de reeks te formatteren. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de gegevenstabel en schakelt waardelabels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

## **Percentage weergeven als labels**

Voor een gestapeld kolomdiagram berekent u elke waarde als een percentage van het categorie‑totaal en kent u de tekst toe aan het tekstkader dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een fontgrootte van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑teken instellen met grafiekgegevenslabels**

Wanneer waarden als breuken zijn opgeslagen, gebruik [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het label‑formaat `0.0%` toont 0,30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

## **De werkelijke tekst van gegevenslabels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatiesinhoud of het valideren van gegenereerde grafieken. In het voorbeeld hieronder combineert het standaard [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) elke categorienaam, reekse naam en waarde. Eén punt formatteert zijn waarde als percentage, en een andere gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` toont samen met de categorie‑ en reeksnamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) retourneert in beide gevallen de resulterende label‑string. Controleer [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) apart, zoals hierboven getoond, wanneer u alleen zichtbare labels wilt extraheren.

## **Gegevenslabels buiten de as‑maximum controleren**

Wanneer u handmatig een as‑bereik beperkt, kunnen sommige gegevenspunten de maximumwaarde overschrijden. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) om te bepalen of hun gegevenslabels worden weergegeven. Deze instelling wijzigt de label‑zichtbaarheid; ze verandert niet het as‑bereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D gegroepeerd kolomdiagram met waarden 60 en 120. Het geeft `false` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) op de verticale as. De eerste dia staat labels toe boven het maximum; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). De instelling op diagramniveau activeert de weergave van waarden niet zelfstandig en overschrijft niet de uitgeschakelde waardweergave van een individueel label. Dit voorbeeld activeert waarden voor de volledige reeks en gebruikt [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) om labels aan het buitenkant van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia's zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenkant; met `false` is het verborgen. Het label **60** blijft zichtbaar, het as‑maximum blijft **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint-diagram dat het waardelabel 120 toont met een as‑maximum van 100](data-labels-over-maximum-true.png) | ![PowerPoint-diagram dat het waardelabel 120 verbergt met een as‑maximum van 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Grafiektype" %}}
Dit voorbeeld gebruikt een 2D kolomdiagram met een waardenas. Diagrammen zonder waardenas, zoals taart‑ en donutdiagrammen, hebben geen as‑maximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Labelafstand van een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) om de afstand tussen categorie‑as‑labels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de categorie‑as‑labels in plaats van de labels die aan individuele gegevenspunten zijn gekoppeld.

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

## **Labellocatie aanpassen**

Pas bij een taartdiagram de posities van gegevenslabels aan om de spatiëring te verbeteren en ruimte te maken voor leiderschapslijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de part, en past de horizontale en verticale offsets aan met behulp van [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) en [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). Deze offsets zijn respectievelijk relatief ten opzichte van de diagrambreedte en -hoogte.

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

![Taartdiagram met een aangepaste gegevenslabelpositie](pie-chart-adjusted-label.png)

## **Leiderschapslijnen opmaken**

Wanneer taartdiagramlabels buiten hun partjes staan, helpen leiderschapslijnen lezers elke waarde aan het juiste partje te koppelen. Een contrasterende kleur en een iets dikkere lijn kunnen deze verbindingen makkelijker leesbaar maken, terwijl transparantie en een gestreepte stijl de lijnen visueel onopvallend houden.

Gebruik [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) om leiderschapslijnen op het niveau van de gegevenslabelverzameling van de reeks op te maken. De instellingen in `series.getLabels().getLeaderLinesFormat().getLine()` gelden voor de verzameling, niet voor een individueel label.

Dit voorbeeld maakt een taartdiagram met standaardgegevens, toont waarden buiten de partjes en schakelt [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/) in. Het verplaatst twee labels verder van hun partjes met behulp van [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) en [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) offsets, uitgedrukt als breuken van de diagrambreedte en -hoogte. Er is geen invoer‑presentatie vereist.

De [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) van de lijn stelt een egale blauwe kleur in met een alfa‑waarde van 191 van 255, wat ongeveer 25 % transparantie oplevert. [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) stelt de dikte in op 2 punten, en [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) maakt de lijn gestreept.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // Verplaats twee labels verder van hun partjes.
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het inschakelen van leiderschapslijnen garandeert niet dat er voor elk label een lijn verschijnt. Zichtbaarheid hangt af van de labelplaatsing en het lay‑outgedrag van het diagram. In dit voorbeeld hebben de twee verplaatste labels zichtbare leiderschapslijnen; de labels die dicht bij hun partjes blijven, hebben ze niet nodig.

De volgende afbeelding toont het opgeslagen `FormattedLeaderLines.pptx` gerenderd met Aspose.Slides:

![Taartdiagram met blauwe, halftransparante gestreepte leiderschapslijnen die twee buitenste labels verbinden met hun partjes](formatted-leader-lines.png)

## **Meerdere rijen van gegevenslabels boven een kolomdiagram toevoegen**

Dit voorbeeld maakt een kolomdiagram met twee rijen gegevenslabels boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl Reeks B en Reeks C de extra labels leveren. Hun kolommen worden verborgen door de vulling en omtrek te verwijderen. De methode [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) aligneert alle drie de reeksen op dezelfde categorie‑centra.

De instellingen van [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) reserveren ruimte voor de labelrijen. Na het berekenen van de standaardposities door [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) behouden [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) en [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) de horizontale uitlijning en passen verticale offsets toe om de labels in twee rijen te rangschikken. De cijfers blijven gegevenslabels gekoppeld aan de reekswaarden; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Lijn alle drie series uit met dezelfde categoricentra.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reserveer ruimte boven het plotgebied voor twee rijen gegevenslabels.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Behoud de standaard horizontale positie. Y is een offset ten opzichte van
            // de standaard labelpositie, uitgedrukt als een fractie van de diagramhoogte.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Alleen de rij‑kop is een apart tekst‑object.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Kolomdiagram met twee rijen gegevenslabels boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in drukke diagrammen?**

Combineer automatische labelplaatsing, leiderschapslijnen en verkleinde lettergrootte; indien nodig, verberg enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme waarden of belangrijke punten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**

Filter gegevenspunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een vooraf gedefinieerde regel.

**Hoe kan ik een consistente labelstijl waarborgen bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om een fallback te voorkomen.