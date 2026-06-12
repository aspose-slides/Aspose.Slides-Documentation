---
title: Grafieken voor PowerPoint‑presentaties creëren of bijwerken op Android
linktitle: Grafieken maken of bijwerken
type: docs
weight: 10
url: /nl/androidjava/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- verspreide grafiek
- taartgrafiek
- lijngrafiek
- boomkaartgrafiek
- aandelen‑grafiek
- box‑en‑whisker‑grafiek
- trechtergrafiek
- sunburst‑grafiek
- histogram‑grafiek
- radar‑grafiek
- multi‑categorie‑grafiek
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Grafieken maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor Android. Voeg grafieken toe, formatteer ze en bewerk ze met praktische Java‑codevoorbeelden."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe u grafieken kunt maken en aanpassen met Aspose.Slides. U leert hoe u programmatic een grafiek aan een dia kunt toevoegen, deze kunt vullen met gegevens en diverse opmaakopties kunt toepassen om aan uw specifieke ontwerpeisen te voldoen. Gedurende het artikel illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en het grafiekobject tot het configureren van series, assen en legenden. Door deze gids te volgen krijgt u een solide begrip van hoe u dynamische grafiekgeneratie in uw applicaties kunt integreren, waardoor het proces van het maken van datagedreven presentaties wordt gestroomlijnd.

## **Maak een grafiek**
Grafieken helpen mensen om gegevens snel te visualiseren en inzichten te verkrijgen, die mogelijk niet direct duidelijk zijn uit een tabel of spreadsheet. 


**Waarom grafieken maken?**

Met grafieken kunt u

* grote hoeveelheden gegevens samenvatten, condenseren of aggregeren op één dia in een presentatie
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitbijters, afwijkingen, fouten, onzinnige gegevens, enz. opsporen
* complexe gegevens communiceren of presenteren

In PowerPoint kunt u grafieken maken via de invoeg‑functie, die sjablonen biedt voor het ontwerpen van veel typen grafieken. Met Aspose.Slides kunt u gewone grafieken (gebaseerd op populaire grafiektype­n) en aangepaste grafieken maken. 

{{% alert color="primary" %}} 

Om grafieken te kunnen maken, biedt Aspose.Slides de [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType)‑klasse. De velden onder deze klasse corresponderen met verschillende grafiektype­n.

{{% /alert %}} 

### **Maak normale grafieken**

_Stappen: Grafiek maken_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Stappen:</em> Maak PowerPoint‑grafiek in Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Stappen:</em> Maak presentatie‑grafiek in Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑grafiek in Java</strong></a>

_Code Stappen:_

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met enkele gegevens en specificeer uw gewenste grafiektype. 
4. Voeg een titel toe voor de grafiek. 
5. Toegang tot het werkblad met grafiekgegevens.
6. Maak alle standaard series en categorieën leeg.
7. Voeg nieuwe series en categorieën toe.
8. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
9. Voeg een vulkleur toe voor de grafiekseries.
10. Voeg labels toe voor de grafiekseries. 
11. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een normale grafiek maakt:

```java
// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voegt een grafiek toe met de standaardgegevens
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Stelt de eerste reeks in om waarden te tonen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Stelt de index in voor het werkblad met grafiekgegevens
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met grafiekgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaard gegenereerde reeksen en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Voegt nieuwe reeksen toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Neemt de eerste grafiekreeks
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Populeert nu de gegevens van de reeks
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Neemt de tweede grafiekreeks
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Populeert de gegevens van de reeks
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt de vulkleur in voor de reeks
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Aangepaste labels maken voor elke categorie voor de nieuwe reeks
    // Stelt het eerste label in om de categorienaam te tonen
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Toont de waarde voor het derde label
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Slaat de presentatie met grafiek op
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak verspreide grafieken**
Verspreide grafieken (ook bekend als scatter‑plots of x‑y‑grafieken) worden vaak gebruikt om patronen te controleren of correlaties tussen twee variabelen aan te tonen. 

U wilt mogelijk een verspreide grafiek gebruiken wanneer 

* u gepaarde numerieke gegevens hebt
* u twee variabelen hebt die goed bij elkaar passen
* u wilt bepalen of twee variabelen gerelateerd zijn
* u een onafhankelijke variabele hebt met meerdere waarden voor een afhankelijke variabele

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Stappen:</em> Maak verspreide grafiek in Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑verspreide grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑verspreide grafiek in Java</strong></a>

1. Volg de stappen die hierboven zijn beschreven in [Maak normale grafieken](#making-normal-charts)
2. Voor de derde stap, voeg een grafiek toe met enkele gegevens en specificeer uw grafiektype als een van de volgende
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een scatter‑grafiek voor._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een scatter‑grafiek voor die door krommen is verbonden, met gegevensmarkeringen._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een scatter‑grafiek voor die door krommen is verbonden, zonder gegevensmarkeringen._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een scatter‑grafiek voor die door rechte lijnen is verbonden, met gegevensmarkeringen._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een scatter‑grafiek voor die door rechte lijnen is verbonden, zonder gegevensmarkeringen._

Deze Java‑code laat zien hoe u verspreide grafieken maakt met verschillende reeksen markeringen: 

```java
// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Maakt de standaardgrafiek
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Haalt de index van het standaardwerkblad met grafiekgegevens op
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met grafiekgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de demoreeks
    chart.getChartData().getSeries().clear();
    
    // Voegt nieuwe reeksen toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Neemt de eerste grafiekreeks
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Voegt een nieuw punt (1:3) toe aan de reeks
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Voegt een nieuw punt (2:10) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Wijzigt het type van de reeks
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Wijzigt de marker van de grafiekreeks
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Neemt de tweede grafiekreeks
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Voegt daar een nieuw punt (5:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Voegt een nieuw punt (3:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Voegt een nieuw punt (2:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Voegt een nieuw punt (5:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Wijzigt de marker van de grafiekreeks
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak taartgrafieken**

Taartgrafieken zijn het meest geschikt om de deel‑tot‑geheel‑relatie in gegevens weer te geven, vooral wanneer de gegevens categorie‑labels met numerieke waarden bevatten. Als uw gegevens echter uit veel delen of labels bestaan, kunt u beter een staafgrafiek gebruiken.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Stappen:</em> Maak taartgrafiek in Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑taartgrafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑taartgrafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Pie).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Voeg nieuwe punten toe voor grafieken en voeg aangepaste kleuren toe voor de sectoren van de taartgrafiek.
9. Stel labels in voor series.
10. Stel leidende lijnen in voor serieslabels.
11. Stel de rotatie‑hoek in voor taartgrafiekdia’s.
12. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een taartgrafiek maakt:

```java
// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Voegt een grafiek toe met standaardgegevens
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de eerste reeks in om waarden te tonen
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Stelt de index in voor het werkblad met grafiekgegevens
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met grafiekgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaard gegenereerde reeksen en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Voegt nieuwe reeksen toe
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Vult de reeksgegevens
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Werkt niet in de nieuwe versie
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Stelt de sectorrand in
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Stelt de sectorrand in
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Stelt de sectorrand in
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Creëert aangepaste labels voor elke categorie voor de nieuwe reeks
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Toont leidende lijnen voor de grafiek
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Stelt de rotatiehoek in voor taartgrafiek‑sectoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Slaat de presentatie met een grafiek op
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak lijngrafieken**

Lijngrafieken (ook bekend als lijndiagrammen) zijn het meest geschikt in situaties waarin u veranderingen in waarde over tijd wilt demonstreren. Met een lijngrafiek kunt u veel gegevens tegelijk vergelijken, veranderingen en trends over tijd volgen, anomalieën in gegevensreeksen markeren, enzovoort.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Haal een verwijzing naar een dia op via de index.
1. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval `ChartType.Line`).
1. Toegang tot de grafiekgegevens IChartDataWorkbook.
1. Maak de standaard series en categorieën leeg.
1. Voeg nieuwe series en categorieën toe.
1. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een lijngrafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Standaard worden punten in een lijngrafiek verbonden door rechte, doorlopende lijnen. Als u wilt dat de punten in plaats daarvan door streeplijnen worden verbonden, kunt u uw voorkeursstreeptype als volgt aangeven:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Maak boomkaartgrafieken**

Boomkaartgrafieken zijn het meest geschikt voor verkoopgegevens wanneer u de relatieve grootte van datacategorieën wilt tonen en (tegelijkertijd) snel de aandacht wilt vestigen op items die grote bijdragers zijn aan elke categorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Stappen:</em> Maak boomkaartgrafiek in Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑boomkaartgrafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑boomkaartgrafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een boomkaartgrafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // tak 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak aandelen‑grafieken**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Stappen:</em> Maak aandelen‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑aandelen‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑aandelen‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Verkrijg een verwijzing naar een dia via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Specificeer het formaat van HiLowLines.
9. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Voorbeeld‑Java‑code om een aandelen‑grafiek te maken:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak box‑en‑whisker‑grafieken**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Stappen:</em> Maak box‑en‑whisker‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint‑box‑en‑whisker‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑box‑en‑whisker‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een box‑en‑whisker‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak trechter‑grafieken**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Stappen:</em> Maak trechter‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑trechter‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑trechter‑grafiek in Java</strong></a>


1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Funnel).
4. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

De Java‑code laat zien hoe u een trechter‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak sunburst‑grafieken**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Stappen:</em> Maak sunburst‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint‑sunburst‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑sunburst‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).sunburst).
4. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een sunburst‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //tak 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //tak 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak histogram‑grafieken**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Stappen:</em> Maak histogram‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint‑histogram‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑histogram‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Histogram).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een histogram‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak radar‑grafieken**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Stappen:</em> Maak radar‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint‑radar‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑radar‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index. 
3. Voeg een grafiek toe met enkele gegevens en specificeer uw gewenste grafiektype (`ChartType.Radar` in dit geval).
4. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand

Deze Java‑code laat zien hoe u een radar‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak multi‑categorie‑grafieken**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Stappen:</em> Maak multi‑categorie‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint‑multi‑categorie‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑multi‑categorie‑grafiek in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar een dia op via de index. 
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Toegang tot de grafiekgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Maak de standaard series en categorieën leeg.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

Deze Java‑code laat zien hoe u een multi‑categorie‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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

    // Reeksen toevoegen
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Presentatie met grafiek opslaan
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak kaart‑grafieken**

Een kaart‑grafiek visualiseert een gebied met gegevens. Kaart‑grafieken zijn het meest geschikt om gegevens of waarden over geografische regio’s te vergelijken.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Stappen:</em> Maak kaart‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑kaart‑grafiek in Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑kaart‑grafiek in Java</strong></a>

Deze Java‑code laat zien hoe u een kaart‑grafiek maakt:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Maak combinatie‑grafieken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiektype­n in één diagram. Deze grafiek stelt u in staat om verschillen tussen twee of meer datasets te benadrukken, vergelijken of te onderzoeken, waardoor u relaties tussen hen kunt identificeren.

![The combination chart](combination_chart.png)

De volgende Java‑code laat zien hoe u de bovenstaande combinatie‑grafiek maakt in een PowerPoint‑presentatie:

```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Stel de titel van de grafiek in.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Stel de legende van de grafiek in.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Verwijder de standaard gegenereerde reeksen en categorieën.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Voeg nieuwe categorieën toe.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Voeg de eerste reeks toe.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Stel de horizontale as in.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Stel de verticale as in.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Stel de kleur van de verticale grote rasterlijnen in.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Stel de secundaire horizontale as in.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Stel de secundaire verticale as in.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Grafieken bijwerken**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Stappen:</em> Werk PowerPoint‑grafiek bij in Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Stappen:</em> Werk presentatie‑grafiek bij in Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Stappen:</em> Werk PowerPoint‑presentatie‑grafiek bij in Java</strong></a>

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse die de presentatie vertegenwoordigt die de grafiek bevat die u wilt bijwerken.
2. Verkrijg de referentie van een dia door gebruik te maken van de Index.
3. Doorloop alle vormen om de gewenste grafiek te vinden.
4. Toegang tot het werkblad met grafiekgegevens.
5. Wijzig de gegevens van de grafiekseries door series‑waarden te veranderen.
6. Voeg een nieuwe serie toe en vul de gegevens erin.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe u een grafiek bijwerkt:

```java
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste slideMarker
    ISlide sld = pres.getSlides().get_Item(0);

    // Grafiek ophalen met standaardgegevens
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Instellen van de index van het werkblad met grafiekgegevens
    int defaultWorksheetIndex = 0;

    // Het werkblad met grafiekgegevens ophalen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Grafiekcategorienaam wijzigen
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Eerste grafiekreeks nemen
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nu de gegevens van de reeks bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Reeksnaam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Tweede grafiekreeks nemen
    series = chart.getChartData().getSeries().get_Item(1);

    // Nu de gegevens van de reeks bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Reeksnaam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nu een nieuwe reeks toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Derde grafiekreeks nemen
    series = chart.getChartData().getSeries().get_Item(2);

    // Nu de gegevens van de reeks vullen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Presentatie met grafiek opslaan
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevensbereik voor een grafiek instellen**

Om het gegevensbereik voor een grafiek in te stellen, doet u het volgende:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse die de presentatie vertegenwoordigt die de grafiek bevat.
2. Haal een verwijzing naar een dia op via de index.
3. Doorloop alle vormen om de gewenste grafiek te vinden.
4. Toegang tot de grafiekgegevens en stel het bereik in.
5. Sla de aangepaste presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe u het gegevensbereik voor een grafiek instelt:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaard‑markeringen in grafieken gebruiken**
Wanneer u een standaard‑markering in grafieken gebruikt, krijgt elke grafiekserie automatisch een verschillende standaard‑markering.

Deze Java‑code laat zien hoe u automatisch een markering voor een grafiekserie instelt:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Neem de tweede grafiekreeks
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Nu de gegevens van de reeks vullen
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke grafiektype­n worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [grafiektype­n](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/), inclusief staaf, lijn, taart, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt u in staat om het meest geschikte grafiektype voor uw gegevensvisualisatie‑behoeften te kiezen.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maakt u eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse, haalt u de gewenste dia op met behulp van de index, en roept u vervolgens de methode aan om een grafiek toe te voegen, waarbij u het grafiektype en de initiële gegevens specificeert. Dit proces integreert de grafiek direct in uw presentatie.

**Hoe kan ik de gegevens in een grafiek bijwerken?**

U kunt de gegevens van een grafiek bijwerken door toegang te krijgen tot het gegevens‑werkboek ([IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/)), eventuele standaard series en categorieën te wissen, en vervolgens uw eigen gegevens toe te voegen. Hiermee kunt u de grafiek vernieuwen zodat deze de laatste gegevens weergeeft.

**Is het mogelijk om het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. U kunt kleuren, lettertypen, labels, legenden en andere [opmaak‑elementen](/slides/nl/androidjava/chart-entities/) wijzigen om het uiterlijk van de grafiek af te stemmen op uw specifieke ontwerp‑vereisten.