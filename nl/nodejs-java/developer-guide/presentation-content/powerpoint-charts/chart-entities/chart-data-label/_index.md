---
title: Beheer grafiek-gegevenslabels in presentaties met JavaScript
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
description: "Leer hoe u grafiek-gegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met JavaScript en Aspose.Slides voor Node.js via Java voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekseries en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek beter begrijpen. Dit artikel legt uit hoe u waarden kunt opmaken, percentages kunt weergeven, labeltekst kunt lezen, de afstand tussen labels op de categorische as kunt aanpassen en labels op een cirkeldiagram kunt positioneren.

## **Gegevensprecisie instellen in grafiek-gegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) om de waarden van een serie op te maken. Dit voorbeeld maakt een lijngrafiek met standaardgegevens, toont de gegevenstabel en schakelt labels voor de eerste serie in. Het formaat `#,##0.00` geeft een duizendtallen­scheidingsteken en twee decimalen weer zonder de onderliggende waarden te wijzigen.

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

Voor een gestapelde kolomgrafiek berekent u elke waarde als percentage van de totale categorie en kent u de tekst toe aan het tekstkader dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 pt. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage‑symbool instellen met grafiek‑gegevenslabels**

Wanneer waarden als breuken zijn opgeslagen, gebruikt u [setNumberFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapelde kolomgrafiek met rode en blauwe series over vier categorieën. Elk waardepaar telt op tot 1. Het label‑formaat `0.0%` toont 0.30 als 30.0 %, terwijl de verticale as twee decimalen gebruikt. Beide series gebruiken witte labeltekst van 10 pt.

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

Gebruik [getActualLabelText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is handig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud of het valideren van gegenereerde grafieken. In het onderstaande voorbeeld combineert het standaard [data label format](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabelformat/) elke categorienaam, serienaam en waarde. Eén punt formatteert de waarde als percentage, en een ander gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` toont samen met de categorie‑ en serienamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) retourneert de resulterende label‑string in beide gevallen. Controleer [isVisible](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/isvisible/) apart, zoals hierboven weergegeven, wanneer u alleen zichtbare labels wilt extraheren.

## **Labelafstand tot een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/axis/setlabeloffset/) om de afstand tussen labels op de categorische as en de as zelf te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerde kolomgrafiek en stelt de horizontale as‑label‑offset in op 500. Deze instelling beïnvloedt de categorische as‑labels, niet de labels die aan individuele gegevenspunten zijn gekoppeld.

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

## **Labelpositie aanpassen**

Bij een cirkeldiagram past u de posities van gegevenslabels aan om de tussenruimte te verbeteren en ruimte te maken voor leiding‑lijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten het segment en past de horizontale en verticale offsets aan met behulp van [setX](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/setx/) en [setY](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/datalabel/sety/). Deze offsets zijn respectievelijk relatief ten opzichte van de breedte en hoogte van de grafiek.

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

![Cirkeldiagram met een aangepaste labelpositie](pie-chart-adjusted-label.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in drukke grafieken?**

Combineer automatische labelplaatsing, leiding‑lijnen en een kleinere lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor uiterste waarden of belangrijke punten.

**Hoe kan ik labels uitschakelen voor nul‑, negatieve of lege waarden?**

Filter gegevenspunten voordat u labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of missende waarden volgens een vaste regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer of het lettertype beschikbaar is in de renderomgeving om fallback te voorkomen.