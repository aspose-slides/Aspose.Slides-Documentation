---
title: Trendlijnen toevoegen aan presentatiediagrammen in JavaScript
linktitle: Trendlijn
type: docs
url: /nl/nodejs-java/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-diagrammen met JavaScript en Aspose.Slides voor Node.js via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe je trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het toont hoe je een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe je een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over forward- en backward-projectiewaarden van trendlijnen en of trendlijnen behouden blijven bij het exporteren naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**

Gebruik [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) om een trendlijn toe te voegen aan een diagramreeks, waarbij je het type selecteert met [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Het voorbeeld maakt een gegroepeerd kolomdiagram met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie reeksen.

De exponentiële trendlijn verbergt zijn vergelijking en R-squared-waarde via [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) en [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) voor een aangepast label. Het voortschrijdend gemiddelde gebruikt een [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) van drie gegevenspunten en een aangepaste [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName).

De polynomiale trendlijn heeft een [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) van drie en breidt één categorie naar voren uit via [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). De machts‑trendlijn breidt één categorie naar achteren uit via [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trendlijnintercept instellen**

Gebruik [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) om de Y-waarde van een trendlijn vast te leggen op X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een productiekostmodel moet mogelijk beginnen met bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productievolumes een andere basislijn suggereren. Voor een lineaire trendlijn dwingt het vastzetten van het intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan op basis van de data aangepast onder die beperking. Het verplaatst niet simpelweg een reeds aangepaste lijn. Instellingen voor kruising van assen bepalen waar de diagramassen elkaar ontmoeten, niet de coëfficiënten van de aangepaste trendlijn.

Het volgende voorbeeld maakt een spreidings‑ (XY‑) diagram met productievolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat het diagram op met het standaard automatische intercept, stelt het intercept in op 100 en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de interceptinstelling. De trendlijn toont zijn vergelijking en loopt terug tot X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bij automatische berekening geven deze gegevens `y = 30x + 140`. Het instellen van het intercept op 100 levert ongeveer `y = 43.33x + 100` op: de aangepaste waarde op nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk gegevenspunt gaat.

| Automatisch intercept | Vaste intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekend intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vast intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en aschalen. De trendlijnen worden teruggestrekt tot X = 0 om hun intercepten weer te geven.

Standaard retourneert [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN`, wat een niet‑gespecificeerd intercept aangeeft in plaats van nul. Het intercept wordt dan automatisch berekend op basis van de gegevens.

## **Aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over het diagram wordt getekend in plaats van een trendlijn die wordt berekend uit reeksengegevens. Dit voorbeeld gebruikt [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) om een horizontale lijn toe te voegen aan de dia boven het diagram. De positie van de lijn wordt gespecificeerd in dia‑coördinaten, gemeten in punten, zodat deze begint bij de linkerkant van het diagram en halverwege het diagram ligt. De breedte komt overeen met de breedte van het diagram. De [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) geeft de lijn een effen rode kleur.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/naar achteren worden geprojecteerd: voor spreidings‑ (XY‑) diagrammen — in as‑eenheden; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides zet presentaties om naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, worden behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/nodejs-java/create-shape-thumbnails/).