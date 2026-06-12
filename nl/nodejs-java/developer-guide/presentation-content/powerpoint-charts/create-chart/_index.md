---
title: Maak of werk PowerPoint‑presentatiegrafieken bij in JavaScript
linktitle: Maak of werk grafieken bij
type: docs
weight: 10
url: /nl/nodejs-java/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- spreidingsgrafiek
- taartgrafiek
- lijngrafiek
- tree‑map‑grafiek
- aandelen‑grafiek
- box‑en‑whisker‑grafiek
- funnel‑grafiek
- sunburst‑grafiek
- histogramgrafiek
- radargrafiek
- meervoudige‑categorie‑grafiek
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas grafieken aan in PowerPoint‑presentaties met Aspose.Slides voor Node.js. Voeg grafieken toe, formatteer ze en bewerk ze met praktische codevoorbeelden in JavaScript."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids voor het maken en aanpassen van grafieken met Aspose.Slides. Je leert hoe je programmeermatig een grafiek aan een dia toevoegt, deze vult met gegevens, en diverse opmaakopties toepast om aan je specifieke ontwerpeisen te voldoen. Gedurende het artikel illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en grafiekobject tot het configureren van series, assen en legendes. Door deze gids te volgen, krijg je een solide begrip van hoe je dynamische grafiekgeneratie in je toepassingen integreert, waardoor het maken van gegevensgestuurde presentaties wordt gestroomlijnd.

## **Grafiek maken**
Grafieken helpen mensen om gegevens snel te visualiseren en inzichten te verkrijgen, die niet meteen duidelijk zijn uit een tabel of spreadsheet. 


**Waarom grafieken maken?**

Met grafieken kun je

* grote hoeveelheden data op één dia in een presentatie aggregeren, condenseren of samenvatten
* patronen en trends in data blootleggen
* de richting en momentum van data in de loop van de tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitschieters, afwijkingen, fouten, onzinnige data, enz. opsporen
* complexe data communiceren of presenteren

In PowerPoint kun je grafieken maken via de invoeg‑functie, die sjablonen biedt voor het ontwerpen van vele soorten grafieken. Met Aspose.Slides kun je reguliere grafieken (gebaseerd op populaire grafiektype­n) en aangepaste grafieken maken. 

{{% alert color="primary" %}} 

Om je grafieken te laten maken, biedt Aspose.Slides de [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType)‑klasse. De velden onder deze klasse komen overeen met verschillende grafiektype­n.

{{% /alert %}} 

### **Normale grafieken maken**

_Steps: Maak grafiek_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steps:</em> Maak PowerPoint‑grafiek in JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steps:</em> Maak presentatiegrafiek in JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatiegrafiek in JavaScript</strong></a>

_Code Steps:_

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
2. Haal een dia‑referentie op via de index.
3. Voeg een grafiek toe met enige data en geef je gewenste grafiektype op. 
4. Voeg een titel toe voor de grafiek. 
5. Toegang tot het werkblad met grafiekdata. 
6. Wis alle standaard‑series en -categorieën. 
7. Voeg nieuwe series en categorieën toe. 
8. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
9. Voeg een vulkleur toe voor de grafiekseries. 
10. Voeg labels toe voor de grafiekseries. 
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een normale grafiek maakt:

```javascript
// Instantieert een presentatieklasse die een PPTX‑bestand representeert
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Voegt een grafiek toe met de standaardgegevens
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Stelt de eerste serie in om waarden weer te geven
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Stelt de index in voor het werkblad met grafiekgegevens
    var defaultWorksheetIndex = 0;
    // Haalt het werkblad met grafiekgegevens op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Voegt nieuwe series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Neemt de eerste grafiekserie
    var series = chart.getChartData().getSeries().get_Item(0);
    // Vul nu de gegevens van de serie in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Stelt de opvulkleur in voor de serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Neemt de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Vul de gegevens van de serie in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Stelt de opvulkleur in voor de serie
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Maak aangepaste labels voor elke categorie voor de nieuwe serie
    // Stelt het eerste label in om de categorienaam weer te geven
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Toont de waarde voor het derde label
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Slaat de presentatie met grafiek op
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Spreidingsgrafieken maken**
Spreidingsgrafieken (ook wel scatter‑plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te controleren of correlaties tussen twee variabelen aan te tonen. 

Je wilt een spreidingsgrafiek gebruiken wanneer 

* je gepaarde numerieke gegevens hebt
* je twee variabelen hebt die goed samenpassen
* je wilt bepalen of twee variabelen gerelateerd zijn
* je een onafhankelijke variabele hebt met meerdere waarden voor een afhankelijke variabele

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steps:</em> Maak spreidingsgrafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steps:</em> Maak PowerPoint‑spreidingsgrafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatiespreidingsgrafiek in JavaScript</strong></a>

1. Volg de stappen zoals beschreven onder [Normale grafieken maken](#creating-normal-charts)  
2. Voor de derde stap, voeg een grafiek toe met enige data en specificeer je grafiektype als een van de volgende  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een spreidingsgrafiek met markeringen voor._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een spreidingsgrafiek voor die door krommen verbonden is, met datamarkeringen._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een spreidingsgrafiek voor die door krommen verbonden is, zonder datamarkeringen._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een spreidingsgrafiek voor die door rechte lijnen verbonden is, met datamarkeringen._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een spreidingsgrafiek voor die door rechte lijnen verbonden is, zonder datamarkeringen._

Deze JavaScript‑code laat zien hoe je een spreidingsgrafiek maakt met verschillende series van markeringen:

```javascript
// Instantiëert een presentatie‑klasse die een PPTX‑bestand representeert
var pres = new aspose.slides.Presentation();
try {
    // Verkrijgt de eerste dia
    var slide = pres.getSlides().get_Item(0);
    // Maakt de standaardgrafiek
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Krijgt de index van het standaard werkblad met grafiekdata
    var defaultWorksheetIndex = 0;
    // Haalt het werkblad met grafiekdata op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de demo‑series
    chart.getChartData().getSeries().clear();
    // Voegt nieuwe series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Pakt de eerste grafiekserie
    var series = chart.getChartData().getSeries().get_Item(0);
    // Voegt een nieuw punt (1:3) toe aan de serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Voegt een nieuw punt (2:10) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Wijzigt het type van de serie
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Wijzigt de marker van de grafiekserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Pakt de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Voegt een nieuw punt (5:2) toe daar
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Voegt een nieuw punt (3:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Voegt een nieuw punt (2:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Voeg een nieuw punt (5:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Wijzigt de marker van de grafiekserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Taartgrafieken maken**

Taartgrafieken zijn het best geschikt om de deel‑tot‑geheel‑relatie in data te laten zien, vooral wanneer de data categorische labels met numerieke waarden bevat. Als je echter veel delen of labels hebt, kun je beter een staafgrafiek gebruiken.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steps:</em> Maak taartgrafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steps:</em> Maak PowerPoint‑taartgrafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatietaartgrafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Verkrijg een dia‑referentie via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type (in dit geval [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).Pie). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
8. Voeg nieuwe punten toe voor de grafiek en pas aangepaste kleuren toe op de sectoren van de taartgrafiek. 
9. Stel labels in voor de series. 
10. Stel leidende lijnen in voor de series‑labels. 
11. Stel de rotatiehoek in voor de taartgrafiek‑dia’s. 
12. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een taartgrafiek maakt:

```javascript
// Instantiëert een presentatieklasse die een PPTX‑bestand representeert
var pres = new aspose.slides.Presentation();
try {
    // Verkrijgt de eerste dia
    var slides = pres.getSlides().get_Item(0);
    // Voegt een grafiek toe met de standaardgegevens
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Stelt de eerste serie in om waarden te tonen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Stelt de index in voor het werkblad met grafiekgegevens
    var defaultWorksheetIndex = 0;
    // Haalt het werkblad met grafiekgegevens op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Voegt nieuwe series toe
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Vult de serie met gegevens
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Werkt niet in de nieuwe versie
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Stelt de rand van de sector in
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Stelt de rand van de sector in
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Stelt de rand van de sector in
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Maakt aangepaste labels voor elke categorie voor de nieuwe serie
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
    // Toont leider‑lijnen voor de grafiek
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Stelt de rotatiehoek in voor de taartgrafiek‑sectoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Slaat de presentatie met een grafiek op
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Lijngrafieken maken**

Lijngrafieken (ook wel lijndiagrammen genoemd) zijn het best geschikt wanneer je veranderingen in waarden over tijd wilt aantonen. Met een lijngrafiek kun je veel data tegelijk vergelijken, trends volgen, anomalieën in seriëen benadrukken, enz.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
1. Haal een dia‑referentie op via de index. 
1. Voeg een grafiek toe met standaarddata en het gewenste type (in dit geval `ChartType.Line`). 
1. Toegang tot de grafiekdata‑IChartDataWorkbook. 
1. Wis de standaard‑series en -categorieën. 
1. Voeg nieuwe series en categorieën toe. 
1. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een lijngrafiek maakt:

```javascript
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

Standaard worden punten op een lijngrafiek verbonden door rechte doorlopende lijnen. Als je wilt dat de punten met strepen worden verbonden, kun je je gewenste streptype als volgt opgeven:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **Tree‑map‑grafieken maken**

Tree‑map‑grafieken zijn ideaal voor verkoopdata wanneer je de relatieve grootte van datacategorieën wilt tonen en tegelijk snel de grote bijdragers per categorie wilt benadrukken. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steps:</em> Maak tree‑map‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steps:</em> Maak PowerPoint‑tree‑map‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatietree‑map‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type (in dit geval [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).TreeMap). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
8. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een tree‑map‑grafiek maakt:

```javascript
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

### **Aandelen‑grafieken maken**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steps:</em> Maak aandelen‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steps:</em> Maak PowerPoint‑aandelen‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑aandelen‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Verkrijg een dia‑referentie via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).OpenHighLowClose). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
8. Specificeer het HiLowLines‑formaat. 
9. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Voorbeeld‑JavaScript‑code om een aandelen‑grafiek te maken:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

### **Box‑en‑whisker‑grafieken maken**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steps:</em> Maak box‑en‑whisker‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steps:</em> Maak PowerPoint‑box‑en‑whisker‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑box‑en‑whisker‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).BoxAndWhisker). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
8. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een box‑en‑whisker‑grafiek maakt:

```javascript
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

### **Funnel‑grafieken maken**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steps:</em> Maak funnel‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steps:</em> Maak PowerPoint‑funnel‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑funnel‑grafiek in JavaScript</strong></a>


1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).Funnel). 
4. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

De JavaScript‑code laat zien hoe je een funnel‑grafiek maakt:

```javascript
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

### **Sunburst‑grafieken maken**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steps:</em> Maak sunburst‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steps:</em> Maak PowerPoint‑sunburst‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑sunburst‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type (in dit geval [ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).sunburst). 
4. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een sunburst‑grafiek maakt:

```javascript
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

### **Histogram‑grafieken maken**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steps:</em> Maak histogram‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steps:</em> Maak PowerPoint‑histogram‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑histogram‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).Histogram). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een histogram‑grafiek maakt:

```javascript
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

### **Radar‑grafieken maken**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steps:</em> Maak radar‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steps:</em> Maak PowerPoint‑radar‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑radar‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met enige data en specificeer je gewenste grafiektype (`ChartType.Radar` in dit geval). 
4. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een radar‑grafiek maakt:

```javascript
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

### **Meervoudige‑categorie‑grafieken maken**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steps:</em> Maak meervoudige‑categorie‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steps:</em> Maak PowerPoint‑meervoudige‑categorie‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑meervoudige‑categorie‑grafiek in JavaScript</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. 
2. Haal een dia‑referentie op via de index. 
3. Voeg een grafiek toe met standaarddata en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartType).ClusteredColumn). 
4. Toegang tot de grafiekdata‑[ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartDataWorkbook). 
5. Wis de standaard‑series en -categorieën. 
6. Voeg nieuwe series en categorieën toe. 
7. Voeg nieuwe grafiekdata toe voor de grafiekseries. 
8. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een meervoudige‑categorie‑grafiek maakt:

```javascript
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
    // Sla de presentatie op met grafiek
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Kaart‑grafieken maken**

Een kaart‑grafiek visualiseert een gebied met bijbehorende data. Kaart‑grafieken zijn het best geschikt om data of waarden over geografische regio’s te vergelijken.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steps:</em> Maak kaart‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steps:</em> Maak PowerPoint‑kaart‑grafiek in JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steps:</em> Maak PowerPoint‑presentatie‑kaart‑grafiek in JavaScript</strong></a>

Deze JavaScript‑code laat zien hoe je een kaart‑grafiek maakt:

```javascript
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

### **Combinatie‑grafieken maken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiektype­n in één diagram. Deze grafiek laat je toe om verschillen tussen twee of meer datasets te benadrukken, vergelijken of onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![The combination chart](combination_chart.png)

De volgende JavaScript‑code laat zien hoe je de bovenstaande combinatie‑grafiek maakt in een PowerPoint‑presentatie:

```js
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

    // Stel de grafiektitel in.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Stel de grafieklegenda in.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Verwijder de standaardgegenereerde series en categorieën.
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

## **Grafieken bijwerken**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steps:</em> Werk PowerPoint‑grafiek bij in JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steps:</em> Werk presentatiegrafiek bij in JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steps:</em> Werk PowerPoint‑presentatie‑grafiek bij in JavaScript</strong></a>

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse die de presentatie bevat met de grafiek die je wilt bijwerken. 
2. Verkrijg de referentie van een dia via de index. 
3. Doorloop alle shapes om de gewenste grafiek te vinden. 
4. Toegang tot het werkblad met grafiekdata. 
5. Pas de gegevens van de grafiekseries aan door de waarden te wijzigen. 
6. Voeg een nieuwe serie toe en vul de data erin. 
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je een grafiek bijwerkt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Haal grafiek op met standaardgegevens
    var chart = sld.getShapes().get_Item(0);
    // Stel de index van het werkblad met grafiekgegevens in
    var defaultWorksheetIndex = 0;
    // Haal het werkblad met grafiekgegevens op
    var fact = chart.getChartData().getChartDataWorkbook();
    // Wijzig de naam van de grafiekcategorie
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Neem de eerste grafiekserie
    var series = chart.getChartData().getSeries().get_Item(0);
    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Wijzig de serienaam
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Neem de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);
    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Wijzig de serienaam
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Voeg nu een nieuwe serie toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Neem de derde grafiekserie
    series = chart.getChartData().getSeries().get_Item(2);
    // Vul nu de seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Sla de presentatie met grafiek op
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gegevensbereik voor grafieken instellen**

Om het gegevensbereik voor een grafiek in te stellen, doe je het volgende:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse die de presentatie bevat met de grafiek. 
2. Haal een dia‑referentie op via de index. 
3. Doorloop alle shapes om de gewenste grafiek te vinden. 
4. Toegang tot de grafiekdata en stel het bereik in. 
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe je het gegevensbereik voor een grafiek instelt:

```javascript
var pres = new aspose.slides.Presentation();
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

## **Standaard‑markeringen in grafieken gebruiken**
Wanneer je een standaard‑markering in grafieken gebruikt, krijgt elke grafiekserie automatisch een ander standaard‑markering‑symbool.

Deze JavaScript‑code laat zien hoe je automatisch een markering voor een grafiekserie instelt:

```javascript
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
    // Neem de tweede grafiekserie
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Nu de seriedata invullen
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

**Welke grafiektype­n worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan grafiektype­n, waaronder staaf-, lijngrafieken, taart‑, area‑, spreidings‑, histogram‑, radar‑ en vele andere. Deze flexibiliteit stelt je in staat het meest geschikte grafiektype voor je visualisatie‑behoeften te kiezen.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑klasse, haal je de gewenste dia op via de index, en roep je vervolgens de methode aan om een grafiek toe te voegen, waarbij je het grafiektype en de initiële data specificeert. Dit proces integreert de grafiek direct in je presentatie.

**Hoe kan ik de data die in een grafiek wordt weergegeven bijwerken?**

Je kunt de data van een grafiek bijwerken door toegang te krijgen tot de gegevens‑workbook ([ChartDataWorkbook](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chartdataworkbook/)), alle standaard‑series en -categorieën te wissen, en vervolgens je eigen data toe te voegen. Hiermee kun je de grafiek programmatisch vernieuwen zodat deze de nieuwste gegevens weergeeft.

**Is het mogelijk het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legendes en andere opmaak‑elementen wijzigen om het uiterlijk van de grafiek af te stemmen op je specifieke ontwerpvereisten.