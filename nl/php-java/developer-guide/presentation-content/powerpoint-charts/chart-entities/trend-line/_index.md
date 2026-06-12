---
title: Voeg trendlijnen toe aan presentatiediagrammen in PHP
linktitle: Trendlijn
type: docs
url: /nl/php-java/trend-line/
keywords:
- grafiek
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-grafieken met Aspose.Slides voor PHP via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over voorwaartse en achterwaartse trendlijnprojectiewaarden en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor het beheren van verschillende diagramtrendlijnen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld wordt ChartType::ClusteredColumn gebruikt).
1. Voeg een exponentiële trendlijn toe voor diagramreeks 1.
1. Voeg een lineaire trendlijn toe voor diagramreeks 1.
1. Voeg een logaritmische trendlijn toe voor diagramreeks 2.
1. Voeg een voortschrijdend-gemiddelde trendlijn toe voor diagramreeks 2.
1. Voeg een polynomiale trendlijn toe voor diagramreeks 3.
1. Voeg een machts trendlijn toe voor diagramreeks 3.
1. Schrijf de aangepaste presentatie naar een PPTX-bestand.

De volgende code wordt gebruikt om een diagram met trendlijnen te maken.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Maak een gegroepeerde kolomgrafiek
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Voeg een exponentiële trendlijn toe voor diagramreeks 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Voeg een lineaire trendlijn toe voor diagramreeks 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Voeg een logaritmische trendlijn toe voor diagramreeks 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Voeg een voortschrijdend gemiddelde trendlijn toe voor diagramreeks 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Voeg een polynomiale trendlijn toe voor diagramreeks 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Voeg een machts trendlijn toe voor diagramreeks 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Sla de presentatie op
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aangepaste lijn toevoegen**
Aspose.Slides for PHP via Java biedt een eenvoudige API om aangepaste lijnen aan een diagram toe te voegen. Om een eenvoudige, rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse
- Verkrijg de referentie van een dia via de index
- Maak een nieuw diagram met de AddChart-methode van het Shapes-object
- Voeg een AutoShape van het type Lijn toe met de AddAutoShape-methode van het Shapes-object
- Stel de kleur van de vormlijnen in.
- Schrijf de aangepaste presentatie naar een PPTX-bestand

De volgende code wordt gebruikt om een diagram met aangepaste lijnen te maken.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die voorwaarts/achterwaarts worden geprojecteerd: voor spreidingsdiagrammen (XY) — in assen-eenheden; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, worden behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [exporteren](/slides/nl/php-java/create-shape-thumbnails/).