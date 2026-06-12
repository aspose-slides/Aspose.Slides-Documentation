---
title: Maak of werk PowerPoint-presentatiegrafieken bij in PHP
linktitle: Grafieken maken of bijwerken
type: docs
weight: 10
url: /nl/php-java/create-chart/
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
- aandelengrafiek
- box-en-whisker-grafiek
- trechtergrafiek
- sunburst-grafiek
- histogramgrafiek
- radargrafiek
- multicategorie-grafiek
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak en pas grafieken aan in PowerPoint-presentaties met Aspose.Slides voor PHP via Java. Voeg grafieken toe, formatteer ze en bewerk ze met praktische code-voorbeelden."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe je grafieken kunt maken en aanpassen met Aspose.Slides. Je leert hoe je programmatic een grafiek aan een dia kunt toevoegen, deze kunt vullen met gegevens en verschillende opmaakopties kunt toepassen om te voldoen aan je specifieke ontwerpvereisten. Door het hele artikel heen illustreren gedetailleerde codevoorbeelden elke stap, van het initialiseren van de presentatie en het grafiekobject tot het configureren van series, assen en legenda’s. Door deze gids te volgen, krijg je een degelijk begrip van hoe je dynamische grafiekgeneratie in je applicaties kunt integreren, waardoor het proces van het maken van datagedreven presentaties wordt gestroomlijnd.

## **Maak een grafiek**

Grafieken helpen mensen om snel gegevens te visualiseren en inzichten te verkrijgen die mogelijk niet meteen duidelijk zijn uit een tabel of spreadsheet.

**Waarom grafieken maken?**

* grootschalige gegevens samenvatten, condenseren of aggregeren op één dia in een presentatie  
* patronen en trends in gegevens blootleggen  
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden  
* uitbijters, afwijkingen, afwijkende waarden, fouten, onzinnige gegevens, enz. opsporen  
* complexe gegevens communiceren of presenteren  

In PowerPoint kun je grafieken maken via de invoegfunctie, die sjablonen biedt voor het ontwerpen van vele soorten grafieken. Met Aspose.Slides kun je reguliere grafieken (gebaseerd op populaire grafiektype) en aangepaste grafieken maken.

{{% alert color="primary" %}} 
Om grafieken te kunnen maken, biedt Aspose.Slides de klasse [ChartType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ChartType). De velden onder deze klasse komen overeen met verschillende grafiektype.  
{{% /alert %}} 

### **Maak normale grafieken**

_Stappen: Maak grafiek_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Stappen:</em> Maak PowerPoint-grafiek </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Stappen:</em> Maak presentatiegrafiek </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Stappen:</em> Maak PowerPoint-presentatiegrafiek </strong></a>

_Code Stappen:_

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation).
2. Haal een referentie naar een dia op via de index.
3. Voeg een grafiek toe met enige gegevens en specificeer het gewenste grafiektype. 
4. Voeg een titel toe aan de grafiek. 
5. Toegang tot het werkblad met grafiekgegevens. 
6. Verwijder alle standaard series en categorieën. 
7. Voeg nieuwe series en categorieën toe. 
8. Voeg nieuwe grafiekgegevens toe voor de grafiekseries. 
9. Voeg een opvulkleur toe voor de grafiekseries. 
10. Voeg labels toe voor de grafiekseries. 
11. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```php
  # Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voegt een grafiek toe met standaardgegevens
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Stelt de grafiektitel in
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Stelt de eerste serie in om waarden te tonen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Stelt de index in voor het werkblad met grafiekdata
    $defaultWorksheetIndex = 0;
    # Haalt het grafiekgegevens‑werkblad op
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Verwijdert de standaard gegenereerde series en categorieën
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Voegt nieuwe series toe
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Voegt nieuwe categorieën toe
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Haalt de eerste grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Populeert nu de seriedata
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Stelt de vulkleur in voor de serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Haalt de tweede grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Populeert seriedata
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Stelt de vulkleur in voor de serie
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Maak aangepaste labels voor elke categorie voor de nieuwe serie
    # Stelt het eerste label in om de categorienaam weer te geven
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Toont waarde voor het derde label
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Slaat de presentatie met grafiek op
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak verspreide grafieken**

Verspreide grafieken (ook bekend als scatterplots of x‑y‑diagrammen) worden vaak gebruikt om patronen te controleren of correlaties tussen twee variabelen te demonstreren.

Je kunt een verspreide grafiek willen gebruiken wanneer  

* je beschikt over gekoppelde numerieke gegevens  
* je hebt twee variabelen die goed bij elkaar passen  
* je wilt bepalen of twee variabelen met elkaar verband houden  
* je hebt een onafhankelijke variabele die meerdere waarden heeft voor een afhankelijke variabele  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Stappen:</em> Maak verspreide grafiek </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑verspreide grafiek </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie verspreide grafiek </strong></a>

1. Please follow the steps mentioned above in [Creating Normal Charts](#creating-normal-charts)
2. Voor de derde stap, voeg een grafiek toe met enige gegevens en specificeer je grafiektype als een van de volgende  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Stelt een spreidingsgrafiek voor._  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Stelt een spreidingsgrafiek voor die met curven verbonden is, met datamarkers._  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Stelt een spreidingsgrafiek voor die met curven verbonden is, zonder datamarkers._  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Stelt een spreidingsgrafiek voor die met lijnen verbonden is, met datamarkers._  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Stelt een spreidingsgrafiek voor die met lijnen verbonden is, zonder datamarkers._

```php
  # Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $slide = $pres->getSlides()->get_Item(0);
    # Maakt de standaardgrafiek
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Haalt de index van het standaard grafiekdata‑werkblad op
    $defaultWorksheetIndex = 0;
    # Haalt het werkblad met grafiekdata op
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Verwijdert de demoserie
    $chart->getChartData()->getSeries()->clear();
    # Voegt nieuwe series toe
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Haalt de eerste grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Voegt een nieuw punt (1:3) toe aan de serie
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Voegt een nieuw punt (2:10) toe
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Wijzigt het serietype
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Wijzigt de marker van de grafiekserie
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Haalt de tweede grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Voegt daar een nieuw punt (5:2) toe
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Voegt een nieuw punt (3:1) toe
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Voegt een nieuw punt (2:2) toe
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Voegt een nieuw punt (5:1) toe
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Wijzigt de marker van de grafiekserie
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak taartgrafieken**

Taartdiagrammen worden het beste gebruikt om de deel‑tot‑geheel relatie te tonen in gegevens, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als je gegevens echter veel delen of labels bevatten, kun je overwegen een staafdiagram te gebruiken.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Stappen:</em> Maak taartdiagram </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑taartdiagram </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie taartdiagram </strong></a>

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation).  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, [ChartType].Pie).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Voeg nieuwe punten toe aan de grafiek en voeg aangepaste kleuren toe voor de sectoren van het taartdiagram.  
9. Stel labels in voor de series.  
10. Stel aanwijzingslijnen in voor de serieslabels.  
11. Stel de rotatiehoek in voor taartdiagramdia’s.  
12. Schrijf de aangepaste presentatie naar een PPTX‑bestand

```php
  # Instantieert een presentatieklasse die een PPTX‑bestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haalt de eerste dia op
    $slides = $pres->getSlides()->get_Item(0);
    # Voegt een grafiek toe met standaardgegevens
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Stelt de grafiektitel in
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Stelt de eerste serie in om waarden te tonen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Stelt de index in voor het werkblad met grafiekdata
    $defaultWorksheetIndex = 0;
    # Haalt het werkblad met grafiekdata op
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Verwijdert de standaard gegenereerde series en categorieën
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Voegt nieuwe categorieën toe
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Voegt nieuwe series toe
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Populeert de seriedata
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Werkt niet in nieuwe versie
    # Nieuwe punten toevoegen en sectorkleur instellen
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Stelt de sectorrand in
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Stelt de sectorrand in
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Stelt de sectorrand in
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Maakt aangepaste labels voor elke categorie voor de nieuwe serie
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Toont aanwijzingslijnen voor de grafiek
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Stelt de rotatiehoek in voor taartgrafieksectoren
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Slaat de presentatie met een grafiek op
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak lijndiagrammen**

Lijndiagrammen (ook bekend als lijngrafieken) worden het beste gebruikt in situaties waarin je veranderingen in waarde over tijd wilt demonstreren. Met een lijndiagram kun je veel gegevens tegelijk vergelijken, veranderingen en trends over de tijd volgen, anomalieën in dataseries benadrukken, enz.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation).  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, `ChartType::Line`).  
4. Toegang tot de grafiekgegevens IChartDataWorkbook.  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Standaard worden punten op een lijndiagram verbonden door rechte, doorlopende lijnen. Als je wilt dat de punten in plaats daarvan met stippellijnen worden verbonden, kun je het gewenste stippeltype op deze manier specificeren:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **Maak boomkaartgrafieken**

Boomkaartgrafieken worden het beste gebruikt voor verkoopgegevens wanneer je de relatieve grootte van datacategorieën wilt tonen en (tegelijkertijd) snel de aandacht wilt vestigen op items die grote bijdragers zijn aan elke categorie.

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Stappen:</em> Maak boomkaartgrafiek </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑boomkaartgrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie boomkaartgrafiek </strong></a>

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) .  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval, [ChartType].TreeMap).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # tak 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # tak 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak aandelengrafieken**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Stappen:</em> Maak aandelengrafiek </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑aandelengrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie aandelengrafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Verkrijg een referentie naar een dia via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType].OpenHighLowClose).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Specificeer het HiLowLines‑formaat.  
9. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak box‑en‑whisker‑grafieken**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Stappen:</em> Maak box‑en‑whisker‑grafiek </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint box‑en‑whisker‑grafiek </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie box‑en‑whisker‑grafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType].BoxAndWhisker).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak trechtergrafieken**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Stappen:</em> Maak trechtergrafiek </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑trechtergrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie trechtergrafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType].Funnel).  
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak Sunburst‑grafieken**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Stappen:</em> Maak Sunburst‑grafiek </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint Sunburst‑grafiek </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie Sunburst‑grafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type (in dit geval,[ChartType].sunburst).  
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # tak 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # tak 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak histogramgrafieken**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Stappen:</em> Maak histogramgrafiek </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint histogramgrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie histogramgrafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType].Histogram).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **Maak radargrafieken**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Stappen:</em> Maak radargrafiek </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint radargrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie radargrafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met enige gegevens en specificeer je gewenste grafiektype (`ChartType::Radar` in dit geval).  
4. Schrijf de aangepaste presentatie weg als een PPTX‑bestand

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak multicategorie‑grafieken**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Stappen:</em> Maak multicategorie‑grafiek </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint multicategorie‑grafiek </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie multicategorie‑grafiek </strong></a>

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een grafiek toe met standaardgegevens en het gewenste type ([ChartType].ClusteredColumn).  
4. Toegang tot de [ChartDataWorkbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdataworkbook/).  
5. Verwijder de standaard series en categorieën.  
6. Voeg nieuwe series en categorieën toe.  
7. Voeg nieuwe grafiekgegevens toe voor de grafiekseries.  
8. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Series toevoegen
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Presentatie opslaan met grafiek
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak kaartgrafieken**

Een kaartgrafiek is een visualisatie van een gebied met gegevens. Kaartgrafieken worden het beste gebruikt om gegevens of waarden te vergelijken over geografische regio’s.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Stappen:</em> Maak kaartgrafiek </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑kaartgrafiek </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Stappen:</em> Maak PowerPoint‑presentatie kaartgrafiek </strong></a>

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Maak combinatiegrafieken**

Een combinatiegrafiek (of combo‑grafiek) combineert twee of meer grafiektype in één grafiek. Deze grafiek stelt je in staat om verschillen tussen twee of meer datasets te markeren, vergelijken of te onderzoeken, waardoor je relaties tussen hen kunt identificeren.

![De combinatiegrafiek](combination_chart.png)

De volgende PHP‑code toont hoe je de bovenstaande combinatiegrafiek maakt in een PowerPoint‑presentatie:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Stel de grafiektitel in.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Stel de grafieklegenda in.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Verwijder de standaard gegenereerde series en categorieën.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Voeg nieuwe categorieën toe.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Voeg de eerste serie toe.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Stel de horizontale as in.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Stel de verticale as in.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Stel de kleur van de verticale hoofd rasterlijnen in.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Stel de secundaire horizontale as in.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Stel de secundaire verticale as in.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **Grafieken bijwerken**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Stappen:</em> Grafiek in PowerPoint bijwerken </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Stappen:</em> Grafiek in presentatie bijwerken </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Stappen:</em> Grafiek in PowerPoint‑presentatie bijwerken </strong></a>

1. Instantieer een klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) die de presentatie vertegenwoordigt met de grafiek die je wilt bijwerken.  
2. Verkrijg de referentie van een dia door zijn index te gebruiken.  
3. Doorloop alle vormen om de gewenste grafiek te vinden.  
4. Toegang tot het werkblad met grafiekgegevens.  
5. Wijzig de gegevens van de grafiekserie door de waarden van de serie te veranderen.  
6. Voeg een nieuwe serie toe en vul de gegevens erin.  
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```php
  $pres = new Presentation();
  try {
    # Toegang tot eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Haal grafiek op met standaardgegevens
    $chart = $sld->getShapes()->get_Item(0);
    # Stel de index van het werkblad met grafiekgegevens in
    $defaultWorksheetIndex = 0;
    # Haal het werkblad met grafiekgegevens op
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Wijzigt de categorienaam van de grafiek
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Haal de eerste grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Werk nu de seriedata bij
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Wijzigt serienaam

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Haal de tweede grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Werk nu de seriedata bij
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Wijzigt serienaam

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Voeg nu een nieuwe serie toe
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Haal de derde grafiekserie op
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Populeer nu de seriedata
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Sla de presentatie met grafiek op
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gegevensbereik instellen voor een grafiek**

Om het gegevensbereik voor een grafiek in te stellen, doe het volgende:

1. Instantieer een klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) die de presentatie vertegenwoordigt met de grafiek.  
2. Haal een referentie naar een dia op via de index.  
3. Doorloop alle vormen om de gewenste grafiek te vinden.  
4. Toegang tot de grafiekgegevens en stel het bereik in.  
5. Sla de aangepaste presentatie op als een PPTX‑bestand.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is010null($pres)) {
      $pres->dispose();
    }
  }
```

## **Standaard‑markers gebruiken in grafieken**

Wanneer je een standaard‑marker in grafieken gebruikt, krijgt elke grafiekserie automatisch een verschillend standaard‑markersymbool.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Neem de tweede grafiekserie
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Populeert nu de seriedata
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke grafiektypen worden ondersteund door Aspose.Slides?**

Aspose.Slides ondersteunt een breed scala aan [grafiektype]..., waaronder staaf, lijn, taart, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt je in staat om het meest geschikte grafiektype te kiezen voor jouw visualisatiebehoeften.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maak je eerst een instantie van de klasse [Presentation], haal je de gewenste dia op via de index en roep je vervolgens de methode aan om een grafiek toe te voegen, waarbij je het grafiektype en de initiële gegevens opgeeft. Dit proces integreert de grafiek direct in je presentatie.

**Hoe kan ik de weergegeven gegevens in een grafiek bijwerken?**

Je kunt de gegevens van een grafiek bijwerken door toegang te krijgen tot de gegevenswerkmap ([ChartDataWorkbook]), alle standaard series en categorieën te verwijderen en vervolgens je eigen gegevens toe te voegen. Hiermee kun je de grafiek vernieuwen zodat deze de nieuwste gegevens weergeeft.

**Is het mogelijk het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides biedt uitgebreide aanpassingsopties. Je kunt kleuren, lettertypen, labels, legenda’s en andere [opmaakelementen](/slides/nl/php-java/chart-entities/) aanpassen om het uiterlijk van de grafiek af te stemmen op je specifieke ontwerpvereisten.