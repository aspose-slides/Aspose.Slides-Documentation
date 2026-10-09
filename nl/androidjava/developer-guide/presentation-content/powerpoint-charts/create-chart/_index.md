---
title: Diagrammen in PowerPoint-presentaties maken of bijwerken op Android
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
- spreidingsdiagram
- taartdiagram
- lijndiagram
- boomkaartdiagram
- aandelen diagram
- box-and-whisker diagram
- trechterdiagram
- sunburst diagram
- histogramdiagram
- radardiagram
- multicategorie diagram
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en pas diagrammen in PowerPoint-presentaties aan met Aspose.Slides voor Android. Voeg diagrammen toe, formatteer en bewerk ze met praktische Java-codevoorbeelden."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe je diagrammen kunt maken en aanpassen met Aspose.Slides. Je leert hoe je programmatisch een diagram aan een dia toevoegt, het vult met gegevens, en verschillende opmaakopties toepast om te voldoen aan je specifieke ontwerpeisen. Gedurende het artikel illustreren gedetailleerde codevoorbeelden elke stap, van het initialiseren van de presentatie en het diagramobject tot het configureren van series, assen en legenden. Door deze gids te volgen, krijg je een grondig inzicht in hoe je dynamische diagramgeneratie kunt integreren in je applicaties, zodat je het proces van het maken van gegevensgestuurde presentaties kunt stroomlijnen.

## **Een diagram maken**

Diagrammen helpen mensen snel gegevens te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn uit een tabel of spreadsheet.

**Waarom diagrammen maken?**

* grote hoeveelheden gegevens op één dia in een presentatie aggregeren, comprimeren of samenvatten
* patronen en trends in gegevens blootleggen
* de richting en het momentum van gegevens over tijd of ten opzichte van een specifieke meeteenheid afleiden
* uitschieters, afwijkingen, fouten, onzinnige gegevens, enz. opsporen
* complexe gegevens communiceren of presenteren

In PowerPoint kun je diagrammen maken via de *Insert*-functie, die sjablonen biedt voor het ontwerpen van veel verschillende diagramtypen. Met Aspose.Slides kun je zowel gewone diagrammen (gebaseerd op populaire diagramtypen) als aangepaste diagrammen maken.

{{% alert color="info" title="Note" %}}
Om diagrammen te maken, gebruik je de [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) klasse. De velden in deze klasse komen overeen met verschillende diagramtypen.
{{% /alert %}}

### **Geclusterde kolomdiagrammen maken**

Deze sectie legt uit hoe je geclusterde kolomdiagrammen maakt met Aspose.Slides. Je leert een presentatie te initialiseren, een diagram toe te voegen en de elementen zoals titel, gegevens, series, categorieën en styling aan te passen. Volg de onderstaande stappen om te zien hoe een standaard geclusterde kolomdiagram wordt gegenereerd:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een diagram toe met enkele gegevens en specificeer het type `ChartType.ClusteredColumn`.
1. Voeg een titel toe aan het diagram.
1. Open het gegevenswerkblad van het diagram.
1. Wis alle standaardsseries en -categorieën.
1. Voeg nieuwe series en categorieën toe.
1. Voeg nieuwe diagramgegevens toe voor de diagramseries.
1. Pas een vulkleur toe op de diagramseries.
1. Voeg labels toe aan de diagramseries.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code toont hoe je een geclusterde kolomdiagram maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantiëert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Voegt een diagram toe met de standaardgegevens
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Stelt de titel van het diagram in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index voor het diagramdatablad in
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met diagramgegevens op
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
    
    // Stelt de vulkleur voor de serie in
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Neemt de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Vult seriedata in
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Stelt de vulkleur voor de serie in
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

Spreidingsdiagrammen (ook bekend als spreidingsgrafieken of x‑y‑grafieken) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een spreidingsdiagram wanneer:

* je gepaarde numerieke gegevens hebt
* je twee variabelen hebt die goed bij elkaar passen
* je wilt bepalen of twee variabelen met elkaar verbonden zijn
* je een onafhankelijke variabele hebt die meerdere waarden heeft voor een afhankelijke variabele

1. Volg de stappen in [Geclusterde kolomdiagrammen maken](#create-clustered-column-charts).
2. Voor de derde stap voeg je een diagram toe met enkele gegevens en specificeer je je diagramtype als een van de volgende:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een spreidingsdiagram voor._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat met curven verbonden is, met datamarkers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een spreidingsdiagram voor dat met curven verbonden is, zonder datamarkers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, met datamarkers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een spreidingsdiagram voor dat met rechte lijnen verbonden is, zonder datamarkers._

Deze Java‑code toont hoe je een spreidingsdiagram maakt met verschillende markers voor elke serie:

```java
import com.aspose.slides.*;

// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slide = pres.getSlides().get_Item(0);

    // Maakt het standaard diagram
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Haalt de index van het standaard diagramdatablad op
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met diagramgegevens op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Verwijdert de demo‑series
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

Taartdiagrammen worden het best gebruikt om de verhouding tussen deel en geheel weer te geven, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter veel onderdelen of labels bevatten, kun je beter een staafdiagram gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Pie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Pie).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Voeg nieuwe punten toe voor het diagram en pas aangepaste kleuren toe op de sectoren van het taartdiagram.
9. Stel labels in voor de series.
10. Schakel leidende lijnen in voor de serielabels.
11. Stel de rotatiehoek in voor de sectoren van het taartdiagram.
12. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een taartdiagram maakt:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een presentatie‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Voegt een diagram toe met standaardgegevens
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Stelt de titel van het diagram in
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Stelt de index voor het diagramdatablad in
    int defaultWorksheetIndex = 0;
    
    // Haalt het werkblad met diagramgegevens op
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
    
    //Vult de seriedata in
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Werkt niet in de nieuwe versie
    // Voegt nieuwe punten toe en stelt de sector‑kleur in
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
    
    // Toont leidende lijnen voor het diagram
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Stelt de rotatiehoek in voor taartdiagramsectoren
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Slaat de presentatie met een diagram op
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Lijndiagrammen maken**

Lijndiagrammen (ook wel lijngrafieken genoemd) zijn het best geschikt voor situaties waarin je veranderingen in waarde over de tijd wilt laten zien. Met een lijndiagram kun je een grote hoeveelheid gegevens tegelijk vergelijken, veranderingen en trends in de tijd volgen, anomalieën in dataseries accentueren, en meer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
1. Haal een referentie op naar een dia op basis van de index.
1. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Line](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Line).
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een lijndiagram maakt:

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

Standaard worden punten in een lijndiagram verbonden door rechte, doorlopende lijnen. Als je wilt dat de punten met streepjes worden verbonden, kun je het gewenste streeptype als volgt opgeven:

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

Boomkaartdiagrammen zijn het best geschikt voor verkoopgegevens wanneer je de relatieve grootte van datacategorieën wilt tonen en snel aandacht wilt vestigen op items die grote bijdragers zijn binnen elke categorie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Treemap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Treemap).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een boomkaartdiagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#OpenHighLowClose).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Specificeer het formaat van de hoog‑laag‑lijnen.
9. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een aandelen‑diagram maakt:

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

### **Box‑and‑Whisker‑diagrammen maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#BoxAndWhisker).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een box‑and‑whisker‑diagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Funnel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Funnel).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een trechter‑diagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Sunburst](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Sunburst).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een sunburst‑diagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.Histogram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Histogram).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een histogram‑diagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met enkele gegevens en specificeer je gewenste diagramtype ([ChartType.Radar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#Radar) in dit geval).
4. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een radardiagram maakt:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar een dia op basis van de index.
3. Voeg een diagram toe met standaardgegevens en specificeer het type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ClusteredColumn).
4. Open het gegevenswerkboek van het diagram via [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/).
5. Wis de standaardsseries en -categorieën.
6. Voeg nieuwe series en categorieën toe.
7. Voeg nieuwe diagramgegevens toe voor de diagramseries.
8. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een multicatogorie‑diagram maakt:

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

Kaartdiagrammen visualiseren geografische gegevens en helpen waarden over regio’s heen te vergelijken.

Deze Java‑code toont hoe je een kaart‑diagram maakt:

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

Een combinatie‑diagram (of combo‑diagram) combineert twee of meer diagramtypen in één grafiek. Dit diagram stelt je in staat om verschillen tussen twee of meer datasets te benadrukken, vergelijken of te onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![The combination chart](combination_chart.png)

De volgende Java‑code toont hoe je het bovenstaande combinatie‑diagram maakt in een PowerPoint‑presentatie:

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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse die de presentatie bevat met het diagram dat je wilt bijwerken.
2. Haal een referentie op naar een dia op basis van de index.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open het gegevenswerkblad van het diagram.
5. Wijzig de diagramserie‑waarden.
6. Voeg een nieuwe serie toe en vul de gegevens in.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je een diagram bijwerkt:

```java
import com.aspose.slides.*;

// Opent de presentatie die het diagram bevat dat moet worden bijgewerkt
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Haal het diagram op van de dia
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Stelt de index van het diagramdatablad in
    int defaultWorksheetIndex = 0;

    // Haalt het diagramdatablad op
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Wijzigt de categorienaam van het diagram
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Neem de eerste diagramserie
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Serie naam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Neem de tweede diagramserie
    series = chart.getChartData().getSeries().get_Item(1);

    // Werk nu de seriedata bij
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Serie naam wijzigen
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Nu een nieuwe serie toevoegen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Neem de derde diagramserie
    series = chart.getChartData().getSeries().get_Item(2);

    // Seriegegevens nu invullen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Bewaar de presentatie met diagram
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gegevensbereik voor een diagram instellen**

Om het al gebruikte bereik van een bestaand diagram te bekijken, zie [Het gegevensbereik van een diagram ophalen](/slides/nl/androidjava/chart-workbook/#retrieve-a-charts-data-range).

Om het gegevensbereik voor een diagram in te stellen, doe je het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse die de presentatie bevat met het diagram.
2. Haal een referentie op naar een dia op basis van de index.
3. Doorloop alle vormen om het gewenste diagram te vinden.
4. Open de diagramgegevens en stel het bereik in.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze Java‑code toont hoe je het gegevensbereik voor een diagram instelt:

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

## **Standaardmarkeringen in diagrammen gebruiken**

Wanneer je standaardmarkeringen in diagrammen gebruikt, krijgt elke diagramserie automatisch een ander markersymbool.

Deze Java‑code toont hoe je automatisch een diagramseriemarker instelt:

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

    // Nu seriedata invullen
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

**Welke diagramtypen worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [diagramtypen](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/), waaronder staaf-, lijn‑, taart‑, gebieds‑, spreidings‑, histogram‑, radar‑ en nog veel meer diagrammen. Deze flexibiliteit stelt je in staat om het meest geschikte diagramtype te kiezen voor je data‑visualisatiebehoeften.

**Hoe voeg ik een nieuw diagram toe aan een dia?**

Om een diagram toe te voegen, maak je eerst een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse, haal je de gewenste dia op via de index, en roep je vervolgens de methode aan om een diagram toe te voegen, waarbij je het diagramtype en de initiële gegevens opgeeft. Dit proces integreert het diagram rechtstreeks in je presentatie.

**Hoe kan ik de gegevens die in een diagram worden weergegeven bijwerken?**

Je kunt de gegevens van een diagram bijwerken door toegang te krijgen tot het gegevenswerkboek ([IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)), alle standaardsseries en -categorieën te wissen, en vervolgens je eigen aangepaste gegevens toe te voegen. Hiermee kun je het diagram verversen zodat het de nieuwste gegevens weergeeft.

**Is het mogelijk het uiterlijk van het diagram aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenden en andere [opmaakelementen](/slides/nl/androidjava/chart-entities/) wijzigen om het uiterlijk van het diagram af te stemmen op je specifieke ontwerpvereisten.