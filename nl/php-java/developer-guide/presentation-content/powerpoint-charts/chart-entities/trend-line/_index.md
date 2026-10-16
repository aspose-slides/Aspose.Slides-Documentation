---
title: Trendlijnen toevoegen aan presentatiegrafieken in PHP
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

Dit artikel legt uit hoe u trendlijnen aan presentatiegrafieken kunt toevoegen met behulp van Aspose.Slides. Het toont hoe u een grafiek maakt, trendlijnen toevoegt aan grafiekseries, en werkt met verschillende typen trendlijnen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft ook hoe u een aangepaste lijn aan een grafiek toevoegt door een lijnvorm in te voegen, en bevat een korte FAQ over voorwaartse en achterwaartse projectiewaarden van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van grafieken als afbeeldingen.

## **Trendlijn toevoegen**

Gebruik [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) om een trendlijn toe te voegen aan een grafieksreeks, en selecteer het type met [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie reeksen.

De exponentiële trendlijn verbergt zijn vergelijking en R‑squared‑waarde via [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) en [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) voor een aangepast label. Het voortschrijdend gemiddelde gebruikt een [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) van drie gegevenspunten en een aangepaste [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

De polynomiale trendlijn heeft een orde van drie, ingesteld via [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), en strekt zich één categorie naar voren uit via [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). De machts‑trendlijn strekt zich één categorie naar achteren uit via [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Een trendlijnintercept instellen**

Gebruik [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) om de Y‑waarde van een trendlijn te vergrendelen op X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een model voor productiekosten kan moeten beginnen bij bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productiewolumes een andere basislijn suggereren. Voor een lineaire trendlijn beperkt het fixeren van het intercept de vergelijking `y = ax + b` tot `b = 100`; de helling wordt dan bij het passen van de gegevens onder die beperking vastgesteld. Het verplaatst niet simpelweg een reeds gepaste lijn. Instellingen voor het kruisen van de assen bepalen waar de assen van de grafiek elkaar ontmoeten, niet de coëfficiënten van de gepaste trendlijn.

Het volgende voorbeeld maakt een spreidings‑(XY‑)grafiek met productiewolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat de grafiek op met het standaard automatische intercept, stelt het intercept in op 100 en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de interceptinstelling. De trendlijn toont zijn vergelijking en strekt zich terug tot X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Met automatische berekening leveren deze gegevens `y = 30x + 140`. Het instellen van het intercept op 100 levert in plaats daarvan ongeveer `y = 43.33x + 100`: de gepaste waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk gegevenpunt gaat.

| Automatisch intercept | Vast intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekend intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vast intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en asschaal. De trendlijnen worden teruggestrekt tot X = 0 om hun intercepten te tonen.

Standaard retourneert [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) `NaN`, wat een onbepaald intercept aangeeft in plaats van nul. Het intercept wordt vervolgens automatisch uit de gegevens berekend.

## **Aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over de grafiek wordt getekend in plaats van een trendlijn die wordt berekend uit de seriedata. Dit voorbeeld gebruikt [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) om een horizontale lijn toe te voegen aan de dia boven de grafiek. De positie van de lijn wordt gespecificeerd in dia‑coördinaten, gemeten in punten, zodat deze begint bij de linkerkant van de grafiek en halverwege de grafiek wordt geplaatst. De breedte komt overeen met de breedte van de grafiek. De [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) geeft de lijn een effen rode kleur.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die naar voren/naar achteren worden geprojecteerd: voor spreidings‑(XY‑)grafieken — in as‑eenheden; voor niet‑spreidingsgrafieken — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/php-java/render-a-slide-as-an-svg-image/) en rendert grafieken naar afbeeldingen; trendlijnen, als onderdeel van de grafiek, worden behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om [een afbeelding van de grafiek exporteren](/slides/nl/php-java/create-shape-thumbnails/) zelf.