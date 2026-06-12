---
title: Beheer diagramgegevensreeksen in presentaties met PHP
linktitle: Gegevensreeks
type: docs
url: /nl/php-java/chart-series/
keywords:
- grafiekreeksen
- reeks overlap
- reeks kleur
- categorie kleur
- reeksnaam
- gegevenspunt
- reeksafstand
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u diagramgegevensreeksen kunt beheren in PHP voor PowerPoint (PPT/PPTX) met praktische codevoorbeelden en best practices om uw gegevenspresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/) in Aspose.Slides, met nadruk op hoe gegevens worden gestructureerd en gevisualiseerd binnen presentaties. Deze objecten leveren de fundamentele elementen die individuele verzamelingen van gegevenspunten, categorieën en weergave‑parameters in een diagram definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/) te werken, kunnen ontwikkelaars moeiteloos onderliggende gegevensbronnen integreren en volledige controle behouden over hoe informatie wordt weergegeven, wat resulteert in dynamische, data‑gedreven presentaties die duidelijk inzichten en analyses overbrengen.

Een serie is een rij of kolom met getallen die in een diagram worden uitgezet.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlapping van Chart Series in**

Met de [getParentSeriesGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#getParentSeriesGroup) methode kun je aangeven hoeveel balken en kolommen moeten overlappen in een 2D‑diagram (bereik: -100 tot 100). Deze eigenschap is van toepassing op alle series van de bovenliggende series‑groep: dit is een projectie van de overeenkomstige groepseigenschap. Daarom is deze eigenschap alleen‑lezen.

Gebruik de `ChartSeriesGroup::setOverlap` methode om je gewenste waarde voor `Overlap` in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Voeg een gegroepeerde kolomgrafiek toe aan een dia.  
3. Open de eerste diagramserie.  
4. Open de `ParentSeriesGroup` van de diagramserie en stel de gewenste overlapwaarde voor de serie in.  
5. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```php
  $pres = new Presentation();
  try {
    # Voegt diagram toe
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Stelt overlappen van de reeks in
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Schrijft het presentatiebestand naar schijf
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wijzig de kleur van de serie**

Aspose.Slides for PHP via Java stelt je in staat een seriekleur op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Voeg een diagram toe aan de dia.  
3. Open de serie waarvan je de kleur wilt wijzigen.  
4. Stel het gewenste vultype en de vulkleur in.  
5. Sla de gewijzigde presentatie op.

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wijzig de kleur van de seriecategorie**

Aspose.Slides for PHP via Java stelt je in staat een seriecategorie‑kleur op deze manier te wijzigen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Voeg een diagram toe aan de dia.  
3. Open de seriecategorie waarvan je de kleur wilt wijzigen.  
4. Stel het gewenste vultype en de vulkleur in.  
5. Sla de gewijzigde presentatie op.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wijzig de naam van de serie**

Standaard zijn de legendarenaam voor een diagram de inhoud van de cellen boven elke kolom of rij met gegevens.

In ons voorbeeld (voorbeeldafbeelding),

* de kolommen zijn *Series 1, Series 2* en *Series 3*;  
* de rijen zijn *Category 1, Category 2, Category 3* en *Category 4*.

Aspose.Slides for PHP via Java maakt het mogelijk om een serienaam in de diagramgegevens en de legende bij te werken of te wijzigen.

Deze PHP‑code laat zien hoe je de naam van een serie wijzigt in de diagramgegevens `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Deze PHP‑code laat zien hoe je een serienaam wijzigt in de legende via `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel de opvulkleur van de diagramserie in**

Aspose.Slides for PHP via Java maakt het mogelijk om de automatische opvulkleur voor diagramseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een diagram toe met standaardgegevens gebaseerd op het type naar keuze (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).  
4. Open de diagramserie en stel de opvulkleur in op Automatic.  
5. Sla de presentatie op als een PPTX‑bestand.

```php
  $pres = new Presentation();
  try {
    # Maakt een gegroepeerde kolomgrafiek
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Stelt vulformaat van de serie in op automatisch
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Schrijft het presentatiebestand naar schijf
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel de omgekeerde opvulkleur in voor een diagramserie**

Aspose.Slides maakt het mogelijk om de omgekeerde opvulkleur voor diagramseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een diagram toe met standaardgegevens gebaseerd op het type naar keuze (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).  
4. Open de diagramserie en stel de opvulkleur in op invert.  
5. Sla de presentatie op als een PPTX‑bestand.

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Voegt nieuwe series en categorieën toe
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Neemt de eerste diagramserie en vult de seriedata.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel een serie in om om te keren wanneer de waarde negatief is**

Aspose.Slides maakt het mogelijk om omkeringen in te stellen via de `IChartDataPoint.InvertIfNegative` en `ChartDataPoint.InvertIfNegative` eigenschappen. Wanneer een omkering is ingesteld met deze eigenschappen, keert het gegevenspunt zijn kleuren om wanneer het een negatieve waarde krijgt.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Specifieke puntgegevens wissen**

Aspose.Slides for PHP via Java maakt het mogelijk om de `DataPoints`‑gegevens van een specifieke diagramserie op deze manier te wissen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Haal de referentie van een dia op via de index.  
3. Haal de referentie van een diagram op via de index.  
4. Itereer door alle `DataPoints` van het diagram en stel `XValue` en `YValue` in op null.  
5. Wis alle `DataPoints` voor de specifieke diagramserie.  
6. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel de Gap Width van de serie in**

Aspose.Slides for PHP via Java maakt het mogelijk om de Gap Width van een serie in te stellen via de **`GapWidth`** eigenschap op deze manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.  
2. Open de eerste dia.  
3. Voeg een diagram toe met standaardgegevens.  
4. Open een willekeurige diagramserie.  
5. Stel de `GapWidth` eigenschap in.  
6. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```php
  # Creëert een lege presentatie
  $pres = new Presentation();
  try {
    # Benadert de eerste dia van de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een diagram toe met standaardgegevens
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Stelt de index van het diagramdata-werkblad in
    $defaultWorksheetIndex = 0;
    # Haalt het diagramdata-werkblad op
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Voegt series toe
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Voegt categorieën toe
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Neemt de tweede diagramserie
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Vult de seriedata
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Stelt GapWidth-waarde in
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Slaat de presentatie op op schijf
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is er een limiet aan hoeveel series een enkel diagram kan bevatten?**

Aspose.Slides stelt geen vaste limiet aan het aantal series dat je kunt toevoegen. De praktische grens wordt bepaald door de leesbaarheid van het diagram en door het beschikbare geheugen van je applicatie.

**Wat als de kolommen binnen een cluster te dicht bij elkaar liggen of te ver uit elkaar staan?**

Pas de `GapWidth`‑instelling voor die serie (of de bovenliggende series‑groep) aan. Een hogere waarde vergroot de ruimte tussen de kolommen, terwijl een lagere waarde ze dichter bij elkaar brengt.