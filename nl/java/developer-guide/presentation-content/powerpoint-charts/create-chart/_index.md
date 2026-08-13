---
title: Diagrammen maken of bijwerken in PowerPoint-presentaties met Java
linktitle: Diagrammen maken of bijwerken
type: docs
weight: 10
url: /nl/java/create-chart/
keywords:
- diagram toevoegen
- diagram maken
- diagram bewerken
- diagram wijzigen
- diagram bijwerken
- spreidingsdiagram
- taartdiagram
- lijndiagram
- boomkaartdiagram
- aandelendiagram
- box-en-whisker-diagram
- funnel-diagram
- sunburst-diagram
- histogram-diagram
- radardiagram
- multicategorie-diagram
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas diagrammen aan in PowerPoint-presentaties met Aspose.Slides voor Java. Voeg diagrammen toe, formatteer en bewerk ze met praktische codevoorbeelden in Java."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe je diagrammen kunt maken en aanpassen met Aspose.Slides. Je leert hoe je programmeermatig een diagram aan een dia toevoegt, deze vult met gegevens, en verschillende opmaakopties toepast om te voldoen aan jouw specifieke ontwerpeisen. Door het artikel heen illustreren gedetailleerde codevoorbeelden elke stap, van het initialiseren van de presentatie en het diagramobject tot het configureren van series, assen en legenda's. Door deze gids te volgen, krijg je een gedegen begrip van hoe je dynamische diagramgeneratie kunt integreren in je toepassingen, waardoor het maken van gegevensgestuurde presentaties wordt gestroomlijnd.

## **Diagram maken**
Diagrammen helpen mensen om gegevens snel te visualiseren en inzichten te verkrijgen, die niet direct duidelijk zijn uit een tabel of spreadsheet. 


**Waarom diagrammen maken?**

Met diagrammen kun je

* grote hoeveelheden gegevens samenvatten, comprimeren of consolideren op één dia in een presentatie
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitbijters, afwijkingen, fouten, onzinnige gegevens, enz. opsporen
* complexe gegevens communiceren of presenteren

In PowerPoint kun je diagrammen maken via de invoegfunctie, die sjablonen biedt voor het ontwerpen van vele diagramtypen. Met Aspose.Slides kun je gewone diagrammen (gebaseerd op populaire diagramtypen) en aangepaste diagrammen maken. 

{{% alert color="info" %}} 

Om je diagrammen te laten maken, biedt Aspose.Slides de klasse [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType) . De velden onder deze klasse komen overeen met verschillende diagramtypen. 

{{% /alert %}} 

### **Reguliere diagrammen maken**

_Stappen: Diagram maken_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Stappen:</em> Maak PowerPoint-diagram in Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Stappen:</em> Maak Presentatie-diagram in Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Stappen:</em> Maak PowerPoint-presentatie-diagram in Java</strong></a>

_Code stappen:_

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met enkele gegevens en specificeer je gewenste diagramtype. 
4. Voeg een titel toe aan het diagram. 
5. Open het gegevenswerkblad van het diagram.
6. Verwijder alle standaard series en categorieën.
7. Voeg nieuwe series en categorieën toe.
8. Voeg nieuwe diagramgegevens toe voor de diagramseries.
9. Voeg een vulkleur toe voor de diagramseries.
10. Voeg labels toe voor de diagramseries. 
11. Sla de aangepaste presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een regulier diagram maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voegt een diagram toe met de standaardgegevens
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Stelt de diagramtitel in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index in voor het diagramgegevensblad
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagramgegevenswerkblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Voegt nieuwe series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Neemt de eerste diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Vult nu de seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Stelt de opvulkleur in voor de serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Neemt de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Vult seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt de opvulkleur in voor de serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Maak aangepaste labels voor elke categorie voor de nieuwe serie
    // Stelt het eerste label in om de categorienaam weer te geven
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Toont de waarde voor het derde label
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Slaat de presentatie met diagram op
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Spreidingsdiagrammen maken**
Spreidingsdiagrammen (ook wel scatter plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te controleren of correlaties tussen twee variabelen aan te tonen. 

Je kunt een spreidingsdiagram gebruiken wanneer 

* je gepaarde numerieke gegevens hebt
* je twee variabelen hebt die goed bij elkaar passen
* je wilt bepalen of twee variabelen gerelateerd zijn
* je een onafhankelijke variabele hebt die meerdere waarden heeft voor een afhankelijke variabele

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Stappen:</em> Maak spreidingsdiagram in Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑spreidingsdiagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑spreidingsdiagram in Java</strong></a>

1. Volg de stappen die hierboven worden genoemd in [Reguliere diagrammen maken](#creating-normal-charts)
2. Voor de derde stap, voeg een diagram toe met enkele gegevens en specificeer je diagramtype als een van de volgende
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een spreidingsdiagram voor._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat verbonden is door curven, met datamarkers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een spreidingsdiagram voor dat verbonden is door curven, zonder datamarkers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat verbonden is door rechte lijnen, met datamarkers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een spreidingsdiagram voor dat verbonden is door rechte lijnen, zonder datamarkers._

Deze Java‑code laat zien hoe je een spreidingsdiagram maakt met een verschillende reeks markers: 

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Maakt het standaarddiagram
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Haalt de index van het standaarddiagramgegevenswerkblad op
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagramgegevenswerkblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de demoserie
    chart.getChartData().getSeries().clear();
    
    // Voegt nieuwe series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Neemt de eerste diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Voegt een nieuw punt (1:3) toe aan de serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Voegt een nieuw punt (2:10) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Wijzigt het serietype
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Wijzigt de marker van de diagramserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Neemt de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Voegt hier een nieuw punt (5:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Voegt een nieuw punt (3:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Voegt een nieuw punt (2:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Voegt een nieuw punt (5:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Wijzigt de marker van de diagramserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Taartdiagrammen maken**

Taartdiagrammen zijn het beste om de deel‑tot‑geheelrelatie in gegevens weer te geven, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter veel delen of labels bevatten, kun je beter een staafdiagram gebruiken.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Stappen:</em> Maak taartdiagram in Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑taartdiagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑taartdiagram in Java</strong></a>

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
2. Verkrijg de referentie van een dia via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).Pie).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Voeg nieuwe punten toe voor diagrammen en voeg aangepaste kleuren toe voor de sectoren van het taartdiagram.
9. Stel labels in voor series.
10. Stel leiderslijnen in voor serieslabels.
11. Stel de rotatiehoek in voor taartdiagramdia's.
12. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een taartdiagram maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Voegt een diagram toe met standaardgegevens
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Stelt de diagramtitel in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index in voor het diagramgegevensblad
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagramgegevenswerkblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaardgegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Voegt nieuwe series toe
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // Vult de seriedata in
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Werkt niet in de nieuwe versie
    // Nieuwe punten toevoegen en sectorkleur instellen
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
    
    // Maakt aangepaste labels voor elke categorie voor de nieuwe serie
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
    
    // Toont leiderlijnen voor het diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Stelt de rotatiehoek in voor de sectoren van het taartdiagram
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Slaat de presentatie met een diagram op
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lijndiagrammen maken**

Lijndiagrammen (ook wel lijngrafieken genoemd) zijn het meest geschikt in situaties waarin je veranderingen in waarden over de tijd wilt laten zien. Met een lijndiagram kun je veel gegevens tegelijk vergelijken, wijzigingen en trends in de tijd volgen, afwijkingen in dataseries benadrukken, enz.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) aan.
1. Haal de referentie van een dia op via de index.
1. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit geval, `ChartType.Line`).
1. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een lijndiagram maakt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Standaard worden punten op een lijndiagram verbonden door rechte doorlopende lijnen. Als je wilt dat de punten in plaats daarvan worden verbonden door streepjes, kun je je gewenste stippellijntype op deze manier opgeven:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Boomkaartdiagrammen maken**

Boomkaartdiagrammen zijn het meest geschikt voor verkoopgegevens wanneer je de relatieve grootte van datacategorieën wilt tonen en (tegelijkertijd) snel de aandacht wilt vestigen op items die grote bijdragers zijn aan elke categorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Stappen:</em> Maak boomkaartdiagram in Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑boomkaartdiagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑boomkaartdiagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).TreeMap).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een boomkaartdiagram maakt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
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

### **Aandelendiagrammen maken**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Stappen:</em> Maak aandelendiagram in Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑aandelendiagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑aandelendiagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Verkrijg de referentie van een dia via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Specificeer het formaat van HiLowLines.
9. Sla de aangepaste presentatie op als een PPTX‑bestand

Voorbeeld‑Java‑code die wordt gebruikt om een aandelendiagram te maken:

```java
import com.aspose.slides.*;

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

### **Box‑en‑Whisker‑diagrammen maken**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Stappen:</em> Maak Box‑en‑Whisker‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint‑Box‑en‑Whisker‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑Box‑en‑Whisker‑diagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een box‑en‑whisker‑diagram maakt:

```java
import com.aspose.slides.*;

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

### **Funnel‑diagrammen maken**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Stappen:</em> Maak funnel‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑funnel‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑funnel‑diagram in Java</strong></a>


1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).Funnel).
4. Sla de aangepaste presentatie op als een PPTX‑bestand

De Java‑code laat zien hoe je een funnel‑diagram maakt:

```java
import com.aspose.slides.*;

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

### **Sunburst‑diagrammen maken**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Stappen:</em> Maak sunburst‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint‑sunburst‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑sunburst‑diagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type (in dit geval,[ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).sunburst).
4. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een sunburst‑diagram maakt:

```java
import com.aspose.slides.*;

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

### **Histogram‑diagrammen maken**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Stappen:</em> Maak histogram‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint‑histogram‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑histogram‑diagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).Histogram).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een histogram‑diagram maakt:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Radar‑diagrammen maken**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Stappen:</em> Maak radar‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint‑radar‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑radar‑diagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index. 
3. Voeg een diagram toe met enkele gegevens en specificeer je gewenste diagramtype (`ChartType.Radar` in dit geval).
4. Sla de aangepaste presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe je een radar‑diagram maakt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Multi‑categorie‑diagrammen maken**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Stappen:</em> Maak multi‑categorie‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint‑multi‑categorie‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑multi‑categorie‑diagram in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.
2. Haal de referentie van een dia op via de index. 
3. Voeg een diagram toe met standaardgegevens en het gewenste type ([ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Open de diagramgegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard series en categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de aangepaste presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een multicategorie‑diagram maakt:

```java
import com.aspose.slides.*;

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

    // Series toevoegen
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
    
    // Presentatie met diagram opslaan
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kaart‑diagrammen maken**

Een kaartdiagram is een visualisatie van een gebied met gegevens. Kaartdiagrammen zijn het meest geschikt om gegevens of waarden te vergelijken over geografische regio's.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Stappen:</em> Maak kaart‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑kaart‑diagram in Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie‑kaart‑diagram in Java</strong></a>

Deze Java‑code laat zien hoe je een kaart‑diagram maakt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Combinatie‑diagrammen maken**

Een combinatie‑diagram (of combo‑diagram) combineert twee of meer diagramtypen in één grafiek. Dit diagram laat je toe om verschillen tussen twee of meer gegevenssets te belichten, te vergelijken of te onderzoeken, zodat je relaties daartussen kunt identificeren.

![The combination chart](combination_chart.png)

De volgende Java‑code laat zien hoe je het bovenstaande combinatie‑diagram maakt in een PowerPoint‑presentatie:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Stel de diagramtitel in.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Stel de diagramlegenda in.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Verwijder de standaard gegenereerde series en categorieën.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Voeg nieuwe categorieën toe.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Voeg de eerste serie toe.
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

    // Stel de kleur van de verticale hoofdgridlijnen in.
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

## **Diagrammen bijwerken**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Stappen:</em> Update PowerPoint‑diagram in Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Stappen:</em> Update Presentatie‑diagram in Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Stappen:</em> Update PowerPoint‑presentatie‑diagram in Java</strong></a>

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse die de presentatie vertegenwoordigt die het diagram bevat dat je wilt bijwerken. 
2. Verkrijg de referentie van een dia door de index te gebruiken.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open het gegevenswerkblad van het diagram.
5. Wijzig de gegevens van de diagramserie door seriewaarden te wijzigen.
6. Voeg een nieuwe serie toe en vul de gegevens daarin.
7. Sla de aangepaste presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een diagram bijwerkt:

```java
import com.aspose.slides.*;

// Opent de presentatie die het diagram bevat dat moet worden bijgewerkt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Haal het diagram op van de dia
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Stelt de index van het diagramgegevensblad in
    int defaultWorksheetIndex = 0;

    // Haalt het diagramgegevenswerkblad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Wijzigt de categorienaam van het diagram
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Neem de eerste diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Nu de seriedata bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Wijzigen van serienaam
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Neem de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);

    // Nu de seriedata bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Wijzigen van serienaam
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nu een nieuwe serie toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Neem de 3e diagramserie
    series = chart.getChartData().getSeries().get_Item(2);

    // Nu de seriedata invullen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Presentatie met diagram opslaan
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevensbereik instellen voor een diagram**

Om het gegevensbereik voor een diagram in te stellen, doe je het volgende:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse die de presentatie vertegenwoordigt die het diagram bevat.
2. Haal de referentie van een dia op via de index.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open de diagramgegevens en stel het bereik in.
5. Sla de aangepaste presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je het gegevensbereik voor een diagram instelt:

```java
import com.aspose.slides.*;

// Opent de presentatie die het diagram bevat
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaardmarkers gebruiken in diagrammen**
Wanneer je een standaardmarker in diagrammen gebruikt, krijgt elke diagramserie automatisch een verschillend standaardmarkersymbool.

Deze Java‑code laat zien hoe je een diagramserie‑marker automatisch instelt:

```java
import com.aspose.slides.*;

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
    // Neem de tweede diagramserie
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Nu de seriedata invullen
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

### Welke diagramtypen worden ondersteund door Aspose.Slides?

Aspose.Slides ondersteunt een breed scala aan [diagramtypen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/), waaronder staaf, lijn, taart, gebied, scatter, histogram, radar en vele meer. Deze flexibiliteit stelt je in staat om het meest geschikte diagramtype voor je gegevensvisualisatie te kiezen.

### Hoe voeg ik een nieuw diagram toe aan een dia?

Om een diagram toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse, haal je de gewenste dia op via de index, en roep je vervolgens de methode aan om een diagram toe te voegen, waarbij je het diagramtype en de initiële gegevens specificeert. Dit proces integreert het diagram direct in je presentatie.

### Hoe kan ik de gegevens in een diagram bijwerken?

Je kunt de gegevens van een diagram bijwerken door toegang te krijgen tot de gegevenswerkmap ([IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/)), eventuele standaard series en categorieën te verwijderen, en vervolgens je eigen gegevens toe te voegen. Hiermee kun je het diagram vernieuwen zodat het de nieuwste gegevens weerspiegelt.

### Is het mogelijk om het uiterlijk van het diagram aan te passen?

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenda's en andere [formatteerelementen](/slides/nl/java/chart-entities/) wijzigen om het uiterlijk van het diagram af te stemmen op je specifieke ontwerpvereisten.