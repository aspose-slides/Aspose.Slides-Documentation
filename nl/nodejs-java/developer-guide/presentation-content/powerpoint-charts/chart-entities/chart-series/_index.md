---
title: Beheer grafiekgegevensreeksen in presentaties met JavaScript
linktitle: Gegevensreeksen
type: docs
url: /nl/nodejs-java/chart-series/
keywords:
- grafiekreeksen
- reeks overlap
- reeks kleur
- categorie kleur
- reeks naam
- datapunt
- reeks tussenruimte
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u grafiekreeksen kunt beheren in JavaScript voor PowerPoint (PPT/PPTX) met praktische codevoorbeelden en best practices om uw datapresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/) in Aspose.Slides, met de nadruk op hoe gegevens worden gestructureerd en gevisualiseerd in presentaties. Deze objecten vormen de basiselementen die individuele sets van gegevenspunten, categorieën en uiterlijk‑parameters in een grafiek definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/) te werken, kunnen ontwikkelaars onderliggende gegevensbronnen naadloos integreren en volledige controle behouden over hoe informatie wordt weergegeven, resulterend in dynamische, gegevens‑gedreven presentaties die inzichten en analyses duidelijk overbrengen.

Een serie is een rij of kolom met getallen die in een grafiek worden uitgezet.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Instellen van overlap van grafiekserie**

Met de methode [ChartSeries.getOverlap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartseries/#getOverlap) kun je aangeven hoeveel balken en kolommen elkaar moeten overlappen in een 2D‑grafiek (bereik: -100 tot 100). Deze eigenschap is van toepassing op alle series van de bovenliggende series‑groep: dit is een projectie van de juiste groeps‑eigenschap. Daarom is deze eigenschap alleen‑lezen.

Gebruik de lees‑schrijf‑eigenschap `ParentSeriesGroup.getOverlap` om de gewenste waarde voor `Overlap` in te stellen. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Voeg een gegroepeerde kolomgrafiek toe op een dia.
1. Open de eerste grafiekserie.
1. Open de `ParentSeriesGroup` van de grafiekserie en stel de gewenste overlapwaarde voor de serie in.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de overlap voor een grafiekserie instelt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Voegt grafiek toe
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Stelt overlappen van series in
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Schrijft het presentiebestand naar schijf
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Serie‑kleur wijzigen**

Aspose.Slides for Node.js via Java maakt het mogelijk om de kleur van een serie op de volgende manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Voeg een grafiek toe op de dia.
1. Open de serie waarvan je de kleur wilt wijzigen. 
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe je de kleur van een serie wijzigt:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kleur van seriecategorie wijzigen**

Aspose.Slides for Node.js via Java maakt het mogelijk om de kleur van een seriecategorie op de volgende manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Voeg een grafiek toe op de dia.
1. Open de seriecategorie waarvan je de kleur wilt wijzigen.
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe je de kleur van een seriecategorie wijzigt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Naam van serie wijzigen** 

Standaard zijn de legendanaam­en voor een grafiek de inhoud van de cellen boven elke kolom of rij met gegevens. 

In ons voorbeeld (beeld), 

* de kolommen zijn *Series 1, Series 2,* en *Series 3*;
* de rijen zijn *Category 1, Category 2, Category 3,* en *Category 4.* 

Aspose.Slides voor Node.js via Java maakt het mogelijk om een serienaam in de grafiekgegevens en de legenda bij te werken of te wijzigen.

Deze JavaScript‑code laat zien hoe je de naam van een serie wijzigt in de grafiekgegevens `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Deze JavaScript‑code laat zien hoe je de serienaam wijzigt in de legenda via `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Opvulkleur van grafiekserie instellen**

Aspose.Slides for Node.js via Java maakt het mogelijk om de automatische opvulkleur voor grafiekseries binnen een plotgebied op de volgende manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een grafiek toe met standaardgegevens op basis van het gewenste type (in het voorbeeld hieronder gebruiken we `ChartType.ClusteredColumn`).
1. Open de grafiekserie en stel de opvulkleur in op Automatisch.
1. Sla de presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de automatische opvulkleur voor een grafiekserie instelt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Maakt een gegroepeerde kolomgrafiek
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Stelt de opvullingsindeling van de serie in op automatisch
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Schrijft het presentiebestand naar schijf
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Omgekeerde opvulkleur voor grafiekserie instellen**

Aspose.Slides maakt het mogelijk om de omgekeerde opvulkleur voor grafiekseries binnen een plotgebied op de volgende manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia op basis van zijn index.
1. Voeg een grafiek toe met standaardgegevens op basis van het gewenste type (in het voorbeeld hieronder gebruiken we `ChartType.ClusteredColumn`).
1. Open de grafiekserie en stel de opvulkleur in op Omgekeerd.
1. Sla de presentatie op als een PPTX‑bestand.

Deze JavaScript‑code demonstreert de bewerking:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Voegt nieuwe series en categorieën toe
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Neemt de eerste grafiekserie en vult de seriegegevens in.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Serie omkeren wanneer waarde negatief is**

Aspose.Slides maakt het mogelijk om omkeringen in te stellen via de methode `ChartDataPoint.setInvertIfNegative`. Wanneer een omkering is ingesteld via de eigenschappen, keert het gegevenspunt zijn kleuren om zodra het een negatieve waarde krijgt. 

Deze JavaScript‑code demonstreert de bewerking:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gegevens van specifieke gegevenspunten wissen**

Aspose.Slides for Node.js via Java maakt het mogelijk om de `DataPoints`‑gegevens voor een specifieke grafiekserie op de volgende manier te wissen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
2. Verkrijg de referentie van een dia via zijn index.
3. Verkrijg de referentie van een grafiek via zijn index.
4. Itereer door alle `DataPoints` van de grafiek en stel `XValue` en `YValue` in op null.
5. Wis alle `DataPoints` voor een specifieke grafiekserie.
6. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

Deze JavaScript‑code demonstreert de bewerking:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Stel de gatbreedte van de serie in**

Aspose.Slides for Node.js via Java maakt het mogelijk om de Gap Width van een serie in te stellen via de **`GapWidth`**‑eigenschap op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Open een willekeurige grafiekserie.
1. Stel de eigenschap `GapWidth` in.
1. Schrijf de gewijzigde presentatie weg naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je de Gap Width van een serie instelt:

```javascript
// Maakt lege presentatie
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia van de presentatie
    var slide = pres.getSlides().get_Item(0);
    // Voegt een grafiek toe met standaardgegevens
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Stelt de index van het grafiekgegevensblad in
    var defaultWorksheetIndex = 0;
    // Haalt het werkblad met grafiekgegevens op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Voegt series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Voegt categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Neemt de tweede grafiekserie
    var series = chart.getChartData().getSeries().get_Item(1);
    // Vult de seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Stelt de GapWidth-waarde in
    series.getParentSeriesGroup().setGapWidth(50);
    // Slaat de presentatie op naar schijf
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Is er een limiet aan het aantal series dat een enkele grafiek kan bevatten?**

Aspose.Slides legt geen vaste limiet op aan het aantal series dat je toevoegt. De praktische bovengrens wordt bepaald door de leesbaarheid van de grafiek en door het beschikbare geheugen van je applicatie.

**Wat gebeurt er als de kolommen binnen een cluster te dicht bij elkaar of te ver van elkaar staan?**

Pas de instelling Gap Width aan voor die serie (of de bovenliggende series‑groep). Een hogere waarde vergroot de ruimte tussen de kolommen, terwijl een lagere waarde ze dichter bij elkaar brengt.