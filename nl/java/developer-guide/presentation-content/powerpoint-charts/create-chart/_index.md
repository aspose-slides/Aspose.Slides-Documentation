---
title: Maak of werk PowerPoint‑presentatie‑grafieken bij in Java
linktitle: Maak of werk grafieken bij
type: docs
weight: 10
url: /nl/java/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- spreidingsgrafiek
- taartgrafiek
- lijngrafiek
- boomkaartgrafiek
- aandelen‑grafiek
- box‑en‑whisker‑grafiek
- funnel‑grafiek
- sunburst‑grafiek
- histogramgrafiek
- radargrafiek
- multicategorie‑grafiek
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak en pas grafieken aan in PowerPoint‑presentaties met Aspose.Slides voor Java. Voeg grafieken toe, formatteer ze en bewerk ze met praktische code‑voorbeelden in Java."
---
## **Overzicht**

Dit artikel biedt een uitgebreide handleiding voor het maken en aanpassen van grafieken met Aspose.Slides. Je leert hoe je programmatic een grafiek aan een dia toevoegt, deze van gegevens voorziet en verschillende opmaakopties toepast om te voldoen aan jouw specifieke ontwerpvereisten. Gedurende het artikel illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en het grafiekobject tot het configureren van series, assen en legenda's. Door deze gids te volgen krijg je een solide inzicht in hoe je dynamische grafiekgeneratie integreert in je applicaties, waardoor het proces van het maken van datagestuurde presentaties wordt vereenvoudigd.

## **Grafiek maken**

Grafieken helpen mensen om gegevens snel te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn uit een tabel of spreadsheet.

**Waarom grafieken maken?**

Met grafieken kun je:

* grote hoeveelheden gegevens op één dia van een presentatie aggregeren, condenseren of samenvatten
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitschieters, afwijkingen, fouten, onzinnige gegevens, enz. identificeren
* complexe gegevens communiceren of presenteren

In PowerPoint kun je grafieken maken via de *Insert*-functie, die sjablonen biedt voor het ontwerpen van veel verschillende grafiektype­n. Met Aspose.Slides kun je zowel reguliere grafieken (gebaseerd op populaire grafiektype­n) als aangepaste grafieken maken.

{{% alert color="info" title="Note" %}}

Om grafieken te maken, gebruik je de [ChartType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/)‑klasse. De velden in deze klasse komen overeen met verschillende grafiektype­n.

{{% /alert %}}

### **Clustered Column‑grafieken maken**

Deze sectie legt uit hoe je clustered column‑grafieken maakt met Aspose.Slides. Je leert een presentatie initialiseren, een grafiek toevoegen en de elementen zoals titel, gegevens, series, categorieën en stijl aanpassen. Volg de onderstaande stappen om te zien hoe een standaard clustered column‑grafiek wordt gegenereerd:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een grafiek toe met enkele gegevens en specificeer het type `ChartType.ClusteredColumn`.
1. Voeg een titel toe aan de grafiek.
1. Toegang tot het gegevenswerkblad van de grafiek.
1. Verwijder alle standaardseries en -categorieën.
1. Voeg nieuwe series en categorieën toe.
1. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
1. Pas een vulkleur toe op de grafiekseries.
1. Voeg labels toe aan de grafiekseries.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code demonstreert hoe je een clustered column‑grafiek maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatie‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voegt een grafiek toe met zijn standaardgegevens
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index voor het datablad van de grafiek in
    int defaultWorksheetIndex = 0;
    
    // Verkrijgt het werkblad met de grafiekgegevens
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaard gegenereerde series en categorieën
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
    
    // Pakt de eerste grafiekserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Vult nu de seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Stelt de vulkleur in voor de series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Pakt de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Vult seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt de vulkleur in voor de series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Maak aangepaste labels voor elke categorie voor de nieuwe serie
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
    
    // Slaat de presentatie met grafiek op
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Scatter‑grafieken maken**

Scatter‑grafieken (ook wel scatter‑plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een scatter‑grafiek wanneer:

* je gekoppelde numerieke gegevens hebt
* je twee variabelen hebt die goed bij elkaar passen
* je wilt bepalen of twee variabelen gerelateerd zijn
* je een onafhankelijke variabele hebt met meerdere waarden voor een afhankelijke variabele

1. Volg de stappen in [Create Clustered Column Charts](#create-clustered-column-charts).
2. Voeg in stap drie een grafiek toe met enkele gegevens en specificeer je grafiektype als een van de volgende:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een scatter‑grafiek voor._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een scatter‑grafiek voor die door curven verbonden is, met datamarkers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een scatter‑grafiek voor die door curven verbonden is, zonder datamarkers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een scatter‑grafiek voor die door rechte lijnen verbonden is, met datamarkers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een scatter‑grafiek voor die door rechte lijnen verbonden is, zonder datamarkers._

Deze Java‑code laat zien hoe je een scatter‑grafiek maakt met verschillende markers voor elke serie:

```java
import com.aspose.slides.*;

// Instantieert een presentatie‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Maakt de standaardgrafiek
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Haalt de index van het standaardgrafiek‑datablads op
    int defaultWorksheetIndex = 0;
    
    // Haalt het grafiek‑datablad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de demo‑series
    chart.getChartData().getSeries().clear();
    
    // Voegt nieuwe series toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Pakt de eerste grafiekserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Voegt een nieuw punt (1:3) toe aan de serie
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Voegt een nieuw punt (2:10) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Wijzigt het serietype
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Wijzigt de marker van de grafiekserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Pakt de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Voegt daar een nieuw punt (5:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Voegt een nieuw punt (3:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Voegt een nieuw punt (2:2) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Voegt een nieuw punt (5:1) toe
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Wijzigt de marker van de grafiekserie
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Taartgrafieken maken**

Taartgrafieken worden het best gebruikt om de relatie deel‑tot‑geheel in gegevens weer te geven, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter veel delen of labels bevatten, kun je beter een staafgrafiek gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Pie](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Pie).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Voeg nieuwe punten toe voor de grafiek en pas aangepaste kleuren toe op de sectoren van de taartgrafiek.
9. Stel labels in voor de series.
10. Schakel leiderslijnen in voor de serielabels.
11. Stel de rotatiehoek in voor de taartgrafieksectoren.
12. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een taartgrafiek maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatie‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Verkrijgt de eerste dia
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Voegt een grafiek toe met standaardgegevens
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Stelt de titel van de grafiek in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index voor het grafiek‑datablad in
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met de grafiekgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de standaard gegenereerde series en categorieën
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Voegt nieuwe categorieën toe
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Voegt nieuwe series toe
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Vult de seriedata
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
    
    // Toont leidingslijnen voor de grafiek
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Stelt de rotatiehoek in voor de taartgrafiek‑sectoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Slaat de presentatie met een grafiek op
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lijngrafieken maken**

Lijngrafieken (ook bekend als lijngrafieken) worden het best gebruikt wanneer je veranderingen in een waarde over de tijd wilt demonstreren. Met een lijngrafiek kun je veel gegevens tegelijk vergelijken, veranderingen en trends in de tijd volgen, anomalieën in dataseries benadrukken, en meer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia op basis van de index.
1. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Line](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Line).
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een lijngrafiek maakt:

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

Standaard worden punten op een lijngrafiek verbonden door rechte doorlopende lijnen. Als je wilt dat de punten in plaats daarvan met streepjes worden verbonden, kun je het gewenste streepjes­type als volgt specificeren:

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

### **Tree Map‑grafieken maken**

Tree map‑grafieken worden het best gebruikt voor verkoopgegevens wanneer je de relatieve grootte van datacategorieën wilt tonen en snel de items die grote bijdragers zijn binnen elke categorie wilt benadrukken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Treemap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Treemap).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een tree map‑grafiek maakt:

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

### **Aandelen‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#OpenHighLowClose).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Specificeer het formaat van de high‑low‑lijnen.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een aandelen‑grafiek maakt:

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

### **Box‑and‑Whisker‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#BoxAndWhisker).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een box‑and‑whisker‑grafiek maakt:

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

### **Funnel‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Funnel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Funnel).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een funnel‑grafiek maakt:

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

### **Sunburst‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Sunburst](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Sunburst).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een sunburst‑grafiek maakt:

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

### **Histogram‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.Histogram](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Histogram).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een histogram‑grafiek maakt:

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

### **Radar‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met enkele gegevens en specificeer je voorkeurs‑grafiektype ([ChartType.Radar](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#Radar) in dit geval).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een radar‑grafiek maakt:

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

### **Multi‑Category‑grafieken maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Voeg een grafiek toe met standaardgegevens en specificeer het type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/#ClusteredColumn).
4. Toegang tot het grafiek‑datablad [IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/).
5. Verwijder de standaardseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een multicategory‑grafiek maakt:

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
    
    // Presentatie met grafiek opslaan
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Kaart‑grafieken maken**

Kaart‑grafieken visualiseren geografische gegevens en helpen waarden over regio’s heen te vergelijken.

Deze Java‑code laat zien hoe je een kaart‑grafiek maakt:

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

### **Combinatie‑grafieken maken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiektype­n in één grafiek. Deze grafiek stelt je in staat om verschillen tussen twee of meer datasets te markeren, vergelijken of onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![De combinatiegrafiek](combination_chart.png)

De volgende Java‑code laat zien hoe je de hierboven getoonde combinatie‑grafiek maakt in een PowerPoint‑presentatie:

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

    // Stel de grafiektitel in.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Stel de grafieklegenda in.
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
    verticalAxis.getFormat().getLine().setFillType(FillType.NoFill);

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
    secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse die de presentatie bevat met de grafiek die je wilt bijwerken.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Doorloop alle shapes om de gewenste grafiek te vinden.
4. Toegang tot het werkblad van de grafiekgegevens.
5. Pas de grafiek‑dataseries aan door de serie‑waarden te wijzigen.
6. Voeg een nieuwe serie toe en vul de gegevens in.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je een grafiek bijwerkt:

```java
import com.aspose.slides.*;

// Opent de presentatie die de grafiek bevat die moet worden bijgewerkt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Open de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Verkrijg de grafiek van de dia
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Stelt de index van het grafiekdatablad in
    int defaultWorksheetIndex = 0;

    // Haalt het werkblad met grafiekgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Categorie‑naam van de grafiek wijzigen
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Neem de eerste grafiekserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Serienaam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Neem de tweede grafiekserie
    series = chart.getChartData().getSeries().get_Item(1);

    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Serienaam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Voeg nu een nieuwe serie toe
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Neem de derde grafiekserie
    series = chart.getChartData().getSeries().get_Item(2);

    // Vul nu de seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Sla de presentatie met de grafiek op
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevensbereik voor een grafiek instellen**

Om het gegevensbereik voor een grafiek in te stellen, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse die de presentatie bevat met de grafiek.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Doorloop alle shapes om de gewenste grafiek te vinden.
4. Toegang tot de grafiekgegevens en stel het bereik in.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code laat zien hoe je het gegevensbereik voor een grafiek instelt:

```java
import com.aspose.slides.*;

// Opent de presentatie die de grafiek bevat
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

## **Standaard‑markers gebruiken in grafieken**

Wanneer je standaard‑markers in grafieken gebruikt, krijgt elke grafiekserie automatisch een ander markersymbool.

Deze Java‑code laat zien hoe je automatisch een grafiekserie‑marker instelt:

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
    // Neem de tweede grafiekserie
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

**Welke grafiektype­n worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [grafiektype­n](https://reference.aspose.com/slides/nl/java/com.aspose.slides/charttype/), waaronder staaf, lijn, taart, gebied, scatter, histogram, radar en vele andere. Deze flexibiliteit stelt je in staat om het meest passende grafiektype voor je data‑visualisatiebehoeften te kiezen.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse, haal je de gewenste dia op via de index en roep je vervolgens de methode aan om een grafiek toe te voegen, waarbij je het grafiektype en de initiële gegevens opgeeft. Dit proces integreert de grafiek direct in je presentatie.

**Hoe kan ik de gegevens in een grafiek bijwerken?**

Je kunt de gegevens van een grafiek bijwerken door toegang te krijgen tot het gegevens‑werkboek ([IChartDataWorkbook](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ichartdataworkbook/)), eventuele standaardseries en -categorieën te verwijderen en vervolgens je eigen aangepaste gegevens toe te voegen. Zo kun je de grafiek vernieuwen zodat deze de nieuwste data weergeeft.

**Is het mogelijk om het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenda's en andere [formatteringselementen](/slides/nl/java/chart-entities/) wijzigen om het uiterlijk van de grafiek af te stemmen op je specifieke ontwerpvereisten.