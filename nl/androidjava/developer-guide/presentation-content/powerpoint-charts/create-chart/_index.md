---
title: Diagrammen in PowerPoint‑presentaties maken of bijwerken op Android
linktitle: Diagrammen maken of bijwerken
type: docs
weight: 10
url: /nl/androidjava/create-chart/
keywords:
- diagram toevoegen
- diagram maken
- diagram bewerken
- diagram wijzigen
- diagram bijwerken
- verspreid diagram
- taartdiagram
- lijndiagram
- boomkaartdiagram
- aandelen diagram
- box‑en‑whisker‑diagram
- trechterdiagram
- zonnestraaldiagram
- histogramdiagram
- radardiagram
- multicategorie‑diagram
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Diagrammen maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor Android. Diagrammen toevoegen, opmaken en bewerken met praktische Java‑code‑voorbeelden."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe je diagrammen maakt en aanpast met Aspose.Slides. Je leert hoe je programmatisch een diagram aan een dia toevoegt, deze vult met gegevens en diverse opmaakopties toepast om te voldoen aan je specifieke ontwerpvereisten. Gedurende het artikel illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en diagramobject tot het configureren van series, assen en legenden. Door deze gids te volgen, krijg je een goed begrip van hoe je dynamische diagramgeneratie in je applicaties integreert, waardoor het proces van het maken van datagedreven presentaties wordt gestroomlijnd.

## **Diagram maken**
Diagrammen helpen mensen om snel gegevens te visualiseren en inzicht te krijgen, wat niet meteen duidelijk is uit een tabel of spreadsheet. 


**Waarom diagrammen maken?**

Met diagrammen kun je

* grote hoeveelheden gegevens op één dia in een presentatie samenvoegen, samenvatten of consolideren
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitschieters, afwijkingen, fouten, onzinnige gegevens, enz. opsporen
* complexe gegevens communiceren of presenteren

In PowerPoint kun je diagrammen maken via de invoeg‑functie, die sjablonen biedt voor veel soorten diagrammen. Met Aspose.Slides kun je reguliere diagrammen (gebaseerd op populaire diagramtypes) en aangepaste diagrammen maken. 

{{% alert color="info" %}} 
Om diagrammen te kunnen maken, biedt Aspose.Slides de klasse [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType). De velden onder deze klasse komen overeen met verschillende diagramtypes.
{{% /alert %}} 

### **Normale diagrammen maken**

_Stappen: Diagram maken_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Stappen:</em> PowerPoint-diagram maken in Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Stappen:</em> Presentatiediagram maken in Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Stappen:</em> PowerPoint‑presentatiediagram maken in Java</strong></a>

_Code‑stappen:_

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met enkele gegevens en geef je voorkeurs‑diagramtype op. 
4. Voeg een titel toe voor het diagram. 
5. Toegang tot het gegevenswerkblad van het diagram. 
6. Verwijder alle standaard‑series en -categorieën. 
7. Voeg nieuwe series en categorieën toe. 
8. Voeg nieuwe diagramgegevens toe voor de diagram‑series. 
9. Voeg een opvulkleur toe voor de diagram‑series. 
10. Voeg labels toe voor de diagram‑series. 
11. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een normaal diagram maakt:

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
    
    // Stelt de index in voor het diagram‑datablad
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagram‑datablad op
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
    
    // Vult nu de seriesgegevens
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Stelt de opvulkleur in voor de serie
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Neemt de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Vult de seriesgegevens
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

### **Verspreide diagrammen maken**
Verspreide diagrammen (ook wel scatter‑plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen. 

Je wilt mogelijk een verspreid diagram gebruiken wanneer 

* je gekoppelde numerieke gegevens hebt
* je twee variabelen hebt die goed samengaan
* je wilt bepalen of twee variabelen met elkaar samenhangen
* je een onafhankelijke variabele hebt die meerdere waarden heeft voor een afhankelijke variabele

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Stappen:</em> Verspreid diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Stappen:</em> PowerPoint‑verspreid diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑verspreid diagram maken in Java</strong></a>

1. Volg de stappen die hierboven zijn beschreven in [Normale diagrammen maken](#normale-diagrammen-maken)
2. Voor de derde stap, voeg een diagram toe met enkele gegevens en specificeer je diagramtype als één van de volgende
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Vertegenwoordigt een verspreid diagram met markers._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Vertegenwoordigt een verspreid diagram verbonden door krommen, met datamarkers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Vertegenwoordigt een verspreid diagram verbonden door krommen, zonder datamarkers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Vertegenwoordigt een verspreid diagram verbonden door rechte lijnen, met datamarkers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Vertegenwoordigt een verspreid diagram verbonden door rechte lijnen, zonder datamarkers._

Deze Java‑code laat zien hoe je verspreide diagrammen maakt met verschillende reeksen van markers: 

```java
import com.aspose.slides.*;

// Instantieert een presentatieklasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Maakt het standaarddiagram
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Haalt de index van het standaard-datablad van het diagram op
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagram-datablad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de demo-series
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
    
    // Voegt daar een nieuw punt (5:2) toe
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

Taartdiagrammen zijn het meest geschikt om de deel‑tot‑geheel‑relatie in gegevens weer te geven, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter uit veel delen of labels bestaan, kun je beter een staafdiagram gebruiken.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Stappen:</em> Taartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Stappen:</em> PowerPoint‑taartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑taartdiagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Pie).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagram‑series.
8. Voeg nieuwe punten toe voor diagrammen en voeg aangepaste kleuren toe voor de sectoren van het taartdiagram.
9. Stel labels in voor de series.
10. Stel begeleidingslijnen in voor de series‑labels.
11. Stel de rotatiehoek in voor de taartdiagramdia's.
12. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een taartdiagram maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatieklasse die een PPTX-bestand vertegenwoordigt
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
    
    // Stelt de index in voor het diagram-datablad
    int defaultWorksheetIndex = 0;
    
    // Haalt het diagram-datablad op
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
    
    //Vult de seriesgegevens
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Not working in new version
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
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
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
    
    // Toont leiderlijnen voor diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Stelt de rotatiehoek in voor de taartdiagramsectoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Slaat de presentatie met een diagram op
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lijndiagrammen maken**

Lijndiagrammen (ook wel lijngrafieken genoemd) zijn het meest geschikt in situaties waarin je veranderingen in waarden over tijd wilt aantonen. Met een lijndiagram kun je veel gegevens tegelijk vergelijken, veranderingen en trends in de tijd volgen, anomalieën in dataseries benadrukken, enzovoort.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
1. Haal een verwijzing naar een dia op via de index.
1. Voeg een diagram toe met standaardgegevens en geef het gewenste type op (in dit geval, `ChartType.Line`).
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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

Standaard worden punten in een lijndiagram verbonden door rechte doorlopende lijnen. Als je wilt dat de punten verbonden worden door stippellijnen, kun je je voorkeur voor het type streep op deze manier opgeven:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Boomkaartdiagrammen maken**

Boomkaartdiagrammen zijn het meest geschikt voor verkoopgegevens wanneer je de relatieve grootte van datacategorieën wilt tonen en (tegelijkertijd) snel de aandacht wilt vestigen op items die grote bijdragers zijn aan elke categorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Stappen:</em> Boomkaartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Stappen:</em> PowerPoint‑boomkaartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑boomkaartdiagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).TreeMap).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagram‑series.
8. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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

### **Aandelen‑diagrammen maken**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Stappen:</em> Aandelen‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Stappen:</em> PowerPoint‑aandelen‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑aandelen‑diagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).OpenHighLowClose).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagram‑series.
8. Specificeer het formaat van HiLowLines.
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Voorbeeld‑Java‑code om een aandelen‑diagram te maken:

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

### **Box‑en‑whisker‑diagrammen maken**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Stappen:</em> Box‑en‑whisker‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Stappen:</em> PowerPoint‑box‑en‑whisker‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑box‑en‑whisker‑diagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).BoxAndWhisker).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagram‑series.
8. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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

### **Trechter‑diagrammen maken**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Stappen:</em> Trechter‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Stappen:</em> PowerPoint‑trechter‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑trechter‑diagram maken in Java</strong></a>


1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Funnel).
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

De Java‑code laat zien hoe je een trechter‑diagram maakt:

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

### **Zonnestraal‑diagrammen maken**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Stappen:</em> Zonnestraal‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Stappen:</em> PowerPoint‑zonnestraal‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑zonnestraal‑diagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op (in dit geval, [ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).sunburst).
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een zonnestraal‑diagram maakt:

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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Stappen:</em> Histogram‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Stappen:</em> PowerPoint‑histogram‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑histogram‑diagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index.
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).Histogram).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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

### **Radardiagrammen maken**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Stappen:</em> Radardiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Stappen:</em> PowerPoint‑radardiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑radardiagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index. 
3. Voeg een diagram toe met enkele gegevens en specificeer je voorkeurs‑diagramtype (`ChartType.Radar` in dit geval).
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een radardiagram maakt:

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

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Stappen:</em> Multi‑categorie‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Stappen:</em> PowerPoint‑multi‑categorie‑diagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑multi‑categorie‑diagram maken in Java</strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse.
2. Haal een verwijzing naar een dia op via de index. 
3. Voeg een diagram toe met standaardgegevens en geef het gewenste type op ([ChartType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ChartType).ClusteredColumn).
4. Toegang tot de diagram‑gegevens [IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IChartDataWorkbook).
5. Verwijder de standaard‑series en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagram‑series.
8. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een multi‑categorie‑diagram maakt:

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

### **Kaartdiagrammen maken**

Een kaartdiagram is een visualisatie van een gebied dat gegevens bevat. Kaartdiagrammen zijn het meest geschikt om gegevens of waarden te vergelijken over geografische regio’s.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Stappen:</em> Kaartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Stappen:</em> PowerPoint‑kaartdiagram maken in Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑kaartdiagram maken in Java</strong></a>

Deze Java‑code laat zien hoe je een kaartdiagram maakt:

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

Een combinatie‑diagram (of combo‑diagram) combineert twee of meer diagramtypes in één grafiek. Dit diagram stelt je in staat om te benadrukken, vergelijken of verschillen tussen twee of meer datasets te onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![De combinatiediagram](combination_chart.png)

De volgende Java‑code laat zien hoe je het hierboven weergegeven combinatie‑diagram maakt in een PowerPoint‑presentatie:

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

    // Stel de legenda in.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Verwijder de standaardgegenereerde series en categorieën.
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

## **Diagrammen bijwerken**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Stappen:</em> PowerPoint‑diagram bijwerken in Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Stappen:</em> Presentatiediagram bijwerken in Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Stappen:</em> PowerPoint‑presentatie‑diagram bijwerken in Java</strong></a>

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse die de presentatie vertegenwoordigt waarin het diagram staat dat je wilt bijwerken.
2. Haal de referentie van een dia op door de index te gebruiken.
3. Doorloop alle shapes om het gewenste diagram te vinden.
4. Toegang tot het diagram‑gegevenswerkblad.
5. Wijzig de gegevens van de diagram‑series door de waarden van de series te veranderen.
6. Voeg een nieuwe serie toe en vul de gegevens erin.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een diagram bijwerkt:

```java
import com.aspose.slides.*;

// Opent de presentatie die het diagram bevat dat moet worden bijgewerkt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Haal het diagram van de dia op
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Instellen van de index van het diagram-datablad
    int defaultWorksheetIndex = 0;

    // Het diagram-datablad ophalen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Diagramcategorie-naam wijzigen
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Neem de eerste diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Seriesgegevens nu bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // Serienaam aanpassen
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Neem de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);

    // Seriesgegevens nu bijwerken
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // Serienaam aanpassen
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nu een nieuwe serie toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Neem de derde diagramserie
    series = chart.getChartData().getSeries().get_Item(2);

    // Seriesgegevens nu invullen
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

## **Gegevensbereik voor een diagram instellen**

Om het gegevensbereik voor een diagram in te stellen, doe je het volgende:

1. Instantieer een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse die de presentatie vertegenwoordigt waarin het diagram staat.
2. Haal een verwijzing naar een dia op via de index.
3. Doorloop alle shapes om het gewenste diagram te vinden.
4. Toegang tot de diagram‑gegevens en stel het bereik in.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

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

## **Standaard‑markers in diagrammen gebruiken**
Wanneer je een standaard‑marker in diagrammen gebruikt, krijgt elke diagram‑serie automatisch een ander standaard‑markersymbool.

Deze Java‑code laat zien hoe je automatisch een diagram‑seriemarker instelt:

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

    // Nu seriesgegevens invullen
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

### Welke diagramtypes worden ondersteund door Aspose.Slides?

Aspose.Slides ondersteunt een breed scala aan [diagramtypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/charttype/), inclusief staaf-, lijn-, taart-, gebieds-, spreidings-, histogram‑, radardiagrammen en nog veel meer. Deze flexibiliteit stelt je in staat om het meest geschikte diagramtype voor je gegevensvisualisatie te kiezen.

### Hoe voeg ik een nieuw diagram toe aan een dia?

Om een diagram toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse, haal je de gewenste dia op met behulp van de index, en roep je vervolgens de methode aan om een diagram toe te voegen, waarbij je het diagramtype en de initiële gegevens opgeeft. Dit proces integreert het diagram direct in je presentatie.

### Hoe kan ik de gegevens in een diagram bijwerken?

Je kunt de gegevens van een diagram bijwerken door toegang te krijgen tot het gegevens‑workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ichartdataworkbook/)), de standaard‑series en -categorieën te verwijderen, en vervolgens je eigen gegevens toe te voegen. Hiermee kun je het diagram vernieuwen zodat het de nieuwste gegevens weergeeft.

### Is het mogelijk om het uiterlijk van het diagram aan te passen?

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenden en andere [opmaak‑elementen](/slides/nl/androidjava/chart-entities/) wijzigen om het uiterlijk van het diagram af te stemmen op je specifieke ontwerpvereisten.