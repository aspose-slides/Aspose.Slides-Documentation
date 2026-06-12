---
title: Grafiekassen aanpassen in presentaties met PHP
linktitle: Grafiekas
type: docs
url: /nl/php-java/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximumwaarde
- minimumwaarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor PHP via Java kunt gebruiken om grafiekassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen in Aspose.Slides kunt aanpassen. Het laat zien hoe u de werkelijke aswaarden kunt opvragen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categorie-as kunt wijzigen, het datumformaat voor categorie-aswaarden kunt instellen, een as‑titel kunt roteren, de as‑positie kunt bepalen en een eenheid‑label op de waardenas kunt weergeven.

## **De maximale waarden op de verticale as van diagrammen ophalen**
Aspose.Slides for PHP via Java stelt u in staat de minimum‑ en maximumwaarden op een verticale as op te halen. Volg deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Haalt de werkelijke maximumwaarde van de as op.
5. Haalt de werkelijke minimumwaarde van de as op.
6. Haalt de werkelijke hoofd‑eenheid van de as op.
7. Haalt de werkelijke sub‑eenheid van de as op.
8. Haalt de werkelijke schaal van de hoofd‑eenheid van de as op.
9. Haalt de werkelijke schaal van de sub‑eenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—toont hoe u de benodigde waarden kunt ophalen :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Slaat de presentatie op
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Gegevens tussen assen verwisselen**
Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen te verwisselen—de gegevens die op de verticale as (y‑as) staan, worden naar de horizontale as (x‑as) verplaatst en omgekeerd.

Deze PHP‑code laat zien hoe u de gegevens‑verwisseling tussen assen in een diagram uitvoert:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Wisselt rijen en kolommen
    $chart->getChartData()->switchRowColumn();
    # Slaat de presentatie op
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verticale as uitschakelen voor lijndiagrammen**
Deze PHP‑code laat zien hoe u de verticale as voor een lijndiagram kunt verbergen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Horizontale as uitschakelen voor lijndiagrammen**
Deze code laat zien hoe u de horizontale as voor een lijndiagram kunt verbergen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Categorie-as wijzigen**
Met de eigenschap **CategoryAxisType** kunt u het gewenste type van de categorie-as opgeven (**date** of **text**). Deze code demonstreert de bewerking:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Datumformaat instellen voor categorie-aswaarden**
Aspose.Slides for PHP via Java maakt het mogelijk het datumformaat voor een waarde op de categorie-as in te stellen. De bewerking wordt gedemonstreerd in deze PHP‑code:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Rotatie‑hoek instellen voor een as‑titel van een diagram**
Aspose.Slides for PHP via Java maakt het mogelijk de rotatie‑hoek voor een as‑titel van een diagram in te stellen. Deze PHP‑code demonstreert de bewerking:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **As‑positie instellen op een categorie‑ of waardenas**
Aspose.Slides for PHP via Java maakt het mogelijk de as‑positie in een categorie‑ of waardenas in te stellen. Deze PHP‑code laat zien hoe u de taak uitvoert:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eenheid‑label weergeven op de waardenas van het diagram inschakelen**
Aspose.Slides for PHP via Java maakt het mogelijk een diagram zo te configureren dat er een eenheid‑label wordt getoond op de waardenas van het diagram. Deze PHP‑code demonstreert de bewerking:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Veelgestelde vragen**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/setcrosstype/): u kunt kiezen om bij nul, bij de maximale categorie/waarde of bij een specifieke numerieke waarde te kruisen. Dit is nuttig om de X‑as omhoog of omlaag te verplaatsen of om een basislijn te benadrukken.

**Hoe kan ik de tik‑labels positioneren ten opzichte van de as (langs, buiten, binnen)?**

Stel de [label position](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/setmajortickmark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine diagrammen.