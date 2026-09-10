---
title: Maak of werk PowerPoint‑presentatie‑diagrammen bij in JavaScript
linktitle: Maak of werk diagrammen bij
type: docs
weight: 10
url: /nl/nodejs-java/create-chart/
keywords:
- diagram toevoegen
- diagram maken
- diagram bewerken
- diagram wijzigen
- diagram bijwerken
- spreidingsdiagram
- cirkeldiagram
- lijndiagram
- boomkaartdiagram
- aandelen‑diagram
- box‑en‑whisker‑diagram
- trechterdiagram
- sunburst‑diagram
- histogramdiagram
- radardiagram
- multicategorie‑diagram
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas diagrammen aan in PowerPoint‑presentaties met Aspose.Slides voor Node.js. Voeg diagrammen toe, formatteer en bewerk ze met praktische code‑voorbeelden in JavaScript."
---
## **Overzicht**

Dit artikel biedt een uitgebreide handleiding voor het maken en aanpassen van diagrammen met Aspose.Slides. Je leert hoe je programmatic een diagram aan een dia kunt toevoegen, deze kunt vullen met gegevens en verschillende opmaakopties kunt toepassen om aan je specifieke ontwerpvereisten te voldoen. Door het artikel heen illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en diagramobject tot het configureren van series, assen en legenda’s. Door deze gids te volgen, krijg je een solide begrip van hoe je dynamische diagramgeneratie in je applicaties kunt integreren, waardoor het proces van het maken van gegevensgestuurde presentaties wordt gestroomlijnd.

## **Diagram maken**

Diagrammen helpen mensen snel gegevens te visualiseren en inzicht te krijgen dat niet meteen duidelijk is uit een tabel of spreadsheet.

**Waarom diagrammen maken?**

Met diagrammen kun je:

* grote hoeveelheden gegevens samenvatten op één dia in een presentatie
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens over tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitschieters, afwijkingen, fouten, onzinnige gegevens, enz. spotten
* complexe gegevens communiceren of presenteren

In PowerPoint kun je diagrammen maken via de *Invoegen*-functie, die sjablonen biedt voor het ontwerpen van veel verschillende diagramtypen. Met Aspose.Slides kun je zowel reguliere diagrammen (gebaseerd op populaire diagramtypen) als aangepaste diagrammen maken.

{{% alert color="info" title="Note" %}}
Om diagrammen te maken, gebruik je de [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/)‑klasse. De velden in deze klasse corresponderen met verschillende diagramtypen.
{{% /alert %}}

### **Geclusterde kolomdiagrammen maken**

In dit gedeelte wordt uitgelegd hoe je geclusterde kolomdiagrammen maakt met Aspose.Slides. Je leert een presentatie te initialiseren, een diagram toe te voegen en de elementen zoals titel, gegevens, series, categorieën en opmaak aan te passen. Volg de onderstaande stappen om te zien hoe een standaard geclusterde kolomdiagram wordt gegenereerd:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met enkele gegevens en specificeer het type `ChartType.ClusteredColumn`.
1. Voeg een titel toe aan het diagram.
1. Open het gegevenswerkblad van het diagram.
1. Verwijder alle standaard series en categorieën.
1. Voeg nieuwe series en categorieën toe.
1. Voeg nieuwe diagramgegevens toe voor de diagramseries.
1. Pas een opvulkleur toe op de diagramseries.
1. Voeg labels toe aan de diagramseries.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code toont hoe je een geclusterde kolomdiagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Voegt een diagram toe met de standaardgegevens
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Stelt de diagramtitel in
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // Stelt de eerste reeks in om waarden weer te geven
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Stelt de index in voor het diagram‑gegevensblad
    var defaultWorksheetIndex = 0;
    // Haalt het diagram‑gegevenswerkblad op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de standaard gegenereerde reeksen en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Voegt nieuwe reeksen toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Pakt de eerste diagramreeks
    var series = chart.getChartData().getSeries().get_Item(0);
    // Vult nu de reeksen‑gegevens
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Pakt de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1);
    // Vult reeksen‑gegevens
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Maak aangepaste labels voor elke categorie voor de nieuwe reeks
    // Stelt het eerste label in om de categorienaam weer te geven
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Toont waarde voor het derde label
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Slaat de presentatie met diagram op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Spreidingsdiagrammen maken**
Spreidingsdiagrammen (ook bekend als scatter‑plots of x‑y‑grafieken) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een spreidingsdiagram wanneer:

* je gepaarde numerieke gegevens hebt
* je twee variabelen hebt die goed bij elkaar passen
* je wilt bepalen of twee variabelen met elkaar samenhangen
* je een onafhankelijke variabele hebt met meerdere waarden voor een afhankelijke variabele

1. Volg de stappen in [Create Clustered Column Charts](#create-clustered-column-charts).
2. Voeg voor stap drie een diagram toe met enkele gegevens en specificeer je diagramtype als één van de volgende:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) – _Stelt een spreidingsdiagram voor._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) – _Stelt een spreidingsdiagram voor dat met curven verbonden is, met datamarkers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) – _Stelt een spreidingsdiagram voor dat met curven verbonden is, zonder datamarkers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, met datamarkers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) – _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, zonder datamarkers._

Deze JavaScript‑code toont hoe je een spreidingsdiagram maakt met verschillende markers voor elke serie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Maakt het standaarddiagram
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Haalt de index van het standaard diagram‑gegevens‑werkblad op
    var defaultWorksheetIndex = 0;
    // Haalt het diagram‑gegevens‑werkblad op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de demo‑reeks
    chart.getChartData().getSeries().clear();
    // Voegt nieuwe reeksen toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Pakt de eerste diagramreeks
    var series = chart.getChartData().getSeries().get_Item(0);
    // Voegt een nieuw punt (1:3) toe aan de reeks
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Voegt een nieuw punt (2:10) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Wijzigt het type van de reeks
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Wijzigt de marker van de diagramreeks
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Pakt de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1);
    // Voegt daar een nieuw punt (5:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Voegt een nieuw punt (3:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Voegt een nieuw punt (2:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Voegt een nieuw punt (5:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Wijzigt de marker van de diagramreeks
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Cirkeldiagrammen maken**

Cirkeldiagrammen zijn het meest geschikt om de deel‑tot‑geheel‑relatie in gegevens weer te geven, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter veel delen of labels bevatten, kun je beter een staafdiagram gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Pie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Pie).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Voeg nieuwe punten toe voor het diagram en pas aangepaste kleuren toe op de sectoren van het cirkeldiagram.
9. Stel labels in voor de series.
10. Schakel leader‑lines in voor de serielabels.
11. Stel de rotatiehoek in voor de sectoren van het cirkeldiagram.
12. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een cirkeldiagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia
    var slides = pres.getSlides().get_Item(0);
    // Voegt een diagram toe met standaardgegevens
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Stelt de diagramtitel in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Stelt de eerste reeks in om waarden weer te geven
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Stelt de index in voor het diagram‑gegevensblad
    var defaultWorksheetIndex = 0;
    // Haalt het diagram‑gegevens‑werkblad op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de standaard gegenereerde reeksen en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Voegt nieuwe reeksen toe
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Vult de reeksen‑gegevens
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Werkt niet in de nieuwe versie
    // Voegt nieuwe punten toe en stelt de sectorkleur in
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Stelt de sectorrand in
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Stelt de sectorrand in
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Stelt de sectorrand in
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // Maakt aangepaste labels voor elke categorie voor de nieuwe reeks
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Toont begeleidende lijnen voor diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Stelt de rotatiehoek in voor de sectoren van het cirkeldiagram
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Slaat de presentatie met een diagram op
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Lijndiagrammen maken**

Lijndiagrammen (ook bekend als lijngrafieken) zijn het meest geschikt wanneer je veranderingen in waarden over tijd wilt demonstreren. Met een lijndiagram kun je een grote hoeveelheid gegevens tegelijk vergelijken, veranderingen en trends in de tijd volgen, anomalieën in gegevensseries markeren, en meer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Line](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Line).
1. Open het diagram‑gegevenswerkboek ([ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/)).
1. Verwijder de standaard series en categorieën.
1. Voeg nieuwe series en categorieën toe.
1. Voeg nieuwe diagramgegevens toe voor de diagramseries.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een lijndiagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Standaard worden punten in een lijndiagram verbonden door rechte doorlopende lijnen. Als je wilt dat de punten in plaats daarvan met stippellijnen worden verbonden, kun je het gewenste stippeltype als volgt opgeven:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Boomkaartdiagrammen maken**

Boomkaartdiagrammen zijn het meest geschikt voor verkoopgegevens wanneer je de relatieve grootte van gegevenscategorieën wilt laten zien en snel de aandacht wilt vestigen op items die grote bijdragers zijn binnen elke categorie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Treemap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Treemap).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een boomkaartdiagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // tak 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // tak 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Aandelen‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#OpenHighLowClose).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Specificeer het opmaaktype voor de high‑low‑lijnen.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een aandelen‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Box‑en‑whisker‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#BoxAndWhisker).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een box‑en‑whisker‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Funnel‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Funnel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Funnel).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een funnel‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Sunburst‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Sunburst](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Sunburst).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een sunburst‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // tak 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // tak 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Histogram‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Histogram](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Histogram).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een histogram‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **Radar‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met enkele gegevens en specificeer jouw gewenste diagramtype ([ChartType.Radar](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#Radar) in dit geval).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een radar‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Multi‑categorie‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ClusteredColumn).
4. Open het diagram‑gegevenswerkboek [ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een multi‑categorie‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // Series toevoegen
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Presentatie met diagram opslaan
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kaart‑diagrammen maken**

Kaart‑diagrammen visualiseren geografische gegevens en helpen waarden over regio's heen te vergelijken.

Deze JavaScript‑code toont hoe je een kaart‑diagram maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Combinatie‑diagrammen maken**

Een combinatie‑diagram (of combo‑diagram) combineert twee of meer diagramtypen in één grafiek. Dit diagram stelt je in staat verschillen tussen twee of meer datasets te markeren, vergelijken of onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![The combination chart](combination_chart.png)

De volgende JavaScript‑code toont hoe je het bovenstaande combinatie‑diagram in een PowerPoint‑presentatie maakt:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Stel de diagramtitel in.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Stel de diagramlegenda in.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Verwijder de standaard gegenereerde series en categorieën.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Voeg nieuwe categorieën toe.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Voeg de eerste serie toe.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Stel de horizontale as in.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Stel de verticale as in.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Stel de kleur van de verticale hoofdroosterlijnen in.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Stel de secundaire horizontale as in.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Stel de secundaire verticale as in.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **Diagrammen bijwerken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse die de presentatie bevat met het diagram dat je wilt bijwerken.
2. Verkrijg een referentie naar een dia via de index.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open het gegevenswerkblad van het diagram.
5. Wijzig de diagram‑dataseries door de reekswaarden aan te passen.
6. Voeg een nieuwe reeks toe en vul de gegevens in.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je een diagram bijwerkt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Haal diagram op met standaardgegevens
    var chart = sld.getShapes().get_Item(0);
    // Stel de index van het diagramgegevensblad in
    var defaultWorksheetIndex = 0;
    // Haal het diagram‑gegevens‑werkblad op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Diagramcategorie‑naam wijzigen
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Pak de eerste diagramreeks
    var series = chart.getChartData().getSeries().get_Item(0);
    // Reeksgegevens nu bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Serie‑naam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Pak de tweede diagramreeks
    series = chart.getChartData().getSeries().get_Item(1);
    // Reeksgegevens nu bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Serie‑naam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Nu een nieuwe reeks toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Pak de derde diagramreeks
    series = chart.getChartData().getSeries().get_Item(2);
    // Nu de reeksgegevens invullen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Presentatie met diagram opslaan
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gegevensbereik instellen voor een diagram**

Om het gegevensbereik voor een diagram in te stellen, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse die de presentatie bevat met het diagram.
2. Verkrijg een referentie naar een dia via de index.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open de diagramgegevens en stel het bereik in.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code toont hoe je het gegevensbereik voor een diagram instelt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standaard‑markers gebruiken in diagrammen**

Wanneer je standaard‑markers in diagrammen gebruikt, krijgt elke diagramserie automatisch een ander marker‑symbool.

Deze JavaScript‑code toont hoe je automatisch een diagramseriemarker instelt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Pak de tweede diagramreeks
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Nu de reeksgegevens invullen
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Welke diagramtypen worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [diagramtypen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/), waaronder barra, lijn, cirkel, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt je in staat om het meest geschikte diagramtype voor je gegevensvisualisatie te kiezen.

**Hoe voeg ik een nieuw diagram toe aan een dia?**

Om een diagram toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse, haal je de gewenste dia op via de index en roep je vervolgens de methode aan om een diagram toe te voegen, waarbij je het diagramtype en de initiële gegevens opgeeft. Dit proces integreert het diagram direct in je presentatie.

**Hoe kan ik de gegevens die in een diagram worden weergegeven bijwerken?**

Je kunt de gegevens van een diagram bijwerken door toegang te krijgen tot het gegevenswerkboek van het diagram ([ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/)), de standaard series en categorieën te wissen, en vervolgens je eigen aangepaste gegevens toe te voegen. Hiermee kun je het diagram programmatisch vernieuwen zodat het de nieuwste gegevens weergeeft.

**Is het mogelijk om de uitstraling van het diagram aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenda’s en andere [formatting elements](/slides/nl/nodejs-java/chart-entities/) wijzigen om de uitstraling van het diagram af te stemmen op je specifieke ontwerpvereisten.