---
title: Cirkeldiagrammen aanpassen in presentaties met PHP
linktitle: Cirkeldiagram
type: docs
url: /nl/php-java/pie-chart/
keywords:
- cirkeldiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u cirkeldiagrammen kunt maken en aanpassen met Aspose.Slides voor PHP via Java, exporteerbaar naar PowerPoint, en zo uw dataverhalen in enkele seconden versterkt."
---
## **Overzicht**

Dit artikel legt uit hoe u met cirkeldiagrammen in Aspose.Slides werkt. Het laat zien hoe u secundaire plotopties kunt configureren voor Pie of Pie‑ en Bar of Pie‑diagrammen, en hoe u automatische velschildering voor een standaardcirkel‑diagram kunt inschakelen.

De voorbeelden richten zich op praktische stappen voor diagramaanpassing, zoals een diagram aan een dia toevoegen, series‑ en labelinstellingen aanpassen, standaarddiagramgegevens vervangen door aangepaste categorieën en waarden, en de bijgewerkte presentatie opslaan.

## **Secundaire plotopties voor Pie of Pie‑ en Bar of Pie‑diagrammen**
Aspose.Slides for PHP via Java ondersteunt nu secundaire plotopties voor Pie of Pie‑ of Bar of Pie‑diagrammen. In dit onderwerp laten we u zien hoe u die opties kunt specificeren met Aspose.Slides. Om de eigenschappen te specificeren, doet u het volgende:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Voeg een diagram toe aan de dia.
1. Specificeer de secundaire plotopties van het diagram.
1. Sla de presentatie op naar schijf.

In het onderstaande voorbeeld hebben we verschillende eigenschappen van een Pie of Pie‑diagram ingesteld.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    # Voeg diagram toe aan dia
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Stel verschillende eigenschappen in
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Schrijf presentatie naar schijf
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Stel automatische kleuren voor diagramsegmenten in**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor het instellen van automatische kleuren voor cirkeldiagramsegmenten. De voorbeeldcode past de hierboven genoemde eigenschappen toe.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Stel de titel van het diagram in.
1. Stel de eerste serie in om waarden te tonen.
1. Stel de index van het diagram‑datablad in.
1. Haal het werkblad met diagramgegevens op.
1. Verwijder de standaardgegenereerde series en categorieën.
1. Voeg nieuwe categorieën toe.
1. Voeg nieuwe series toe.

Sla de aangepaste presentatie op als een PPTX‑bestand.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    # Voeg diagram toe met standaardgegevens
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Instellen diagramtitel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Stel eerste serie in om waarden te tonen
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Instellen van de index van het diagramdatablad
    $defaultWorksheetIndex = 0;
    # Ophalen van het werkblad met diagramgegevens
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Verwijder automatisch gegenereerde series en categorieën
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Nieuwe categorieën toevoegen
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Nieuwe series toevoegen
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Nu seriesgegevens invullen
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Worden de 'Pie of Pie' en 'Bar of Pie' varianten ondersteund?**

Ja, de bibliotheek [ondersteunt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de typen 'Pie of Pie' en 'Bar of Pie'.

**Kan ik alleen het diagram exporteren als afbeelding (bijvoorbeeld PNG)?**

Ja, u kunt [het diagram zelf exporteren als afbeelding](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) (bijvoorbeeld PNG) zonder de hele presentatie.