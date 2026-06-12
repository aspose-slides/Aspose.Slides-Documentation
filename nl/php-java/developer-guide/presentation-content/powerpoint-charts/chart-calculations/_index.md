---
title: Optimaliseer grafiekberekeningen voor presentaties in PHP
linktitle: Grafiekberekeningen
type: docs
weight: 50
url: /nl/php-java/chart-calculations/
keywords:
- grafiekberekeningen
- grafiekelementen
- elementpositie
- werkelijke positie
- onderliggend element
- bovenliggend element
- grafiekwaarden
- werkelijke waarde
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Begrijp grafiekberekeningen, gegevensupdates en precisiecontrole in Aspose.Slides for PHP via Java voor PPT en PPTX, met praktische codevoorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met grafiekberekeningen en lay‑outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van grafiekelementen kunt ophalen, inclusief de echte positie en grootte van elementen en de werkelijke waarden van graafassen. Het legt ook uit dat deze waarden worden ingevuld na de validatie van de grafieklayout.

Daarnaast laat het artikel zien hoe u de werkelijke positie van bovenliggende grafiekelementen kunt verkrijgen en hoe u grafiekcomponenten zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om de lay‑outinformatie van grafieken te inspecteren en de zichtbaarheid van grafiekelementen in PowerPoint‑presentaties programmeerbaar te beheren.

## **Werkelijke waarden van grafiekelementen berekenen**
Aspose.Slides for PHP via Java biedt een eenvoudige API om deze eigenschappen op te halen. Methoden van de [Axis](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/)‑klasse bieden informatie over de werkelijke positie van het as‑grafiekelement ([getActualMaxValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/getactualminorunitscale/)). Het is noodzakelijk om eerst de methode [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/validatechartlayout/) aan te roepen om de eigenschappen met werkelijke waarden te vullen.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Werkelijke positie van bovenliggende grafiekelementen berekenen**
Aspose.Slides for PHP via Java biedt een eenvoudige API om deze eigenschappen op te halen. Methoden van de `ActualLayout`‑klasse bieden informatie over de werkelijke positie van bovenliggend grafiekelement (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Het is noodzakelijk om eerst de methode [Chart.validateChartLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/validatechartlayout/) aan te roepen om de eigenschappen met werkelijke waarden te vullen.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Grafiekelementen verbergen**
Dit onderwerp helpt u te begrijpen hoe u informatie uit een grafiek kunt verbergen. Met Aspose.Slides for PHP via Java kunt u **Title, Vertical Axis, Horizontal Axis** en **Grid Lines** uit een grafiek verbergen. De onderstaande codevoorbeelden laten zien hoe u deze eigenschappen kunt gebruiken.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Titel van grafiek verbergen
    $chart->setTitle(false);
    # /Verbergen Waarde-as
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Zichtbaarheid van categorische as
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Legenda verbergen
    $chart->setLegend(false);
    # Hoofd rasterlijnen verbergen
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Kleur van serielijn instellen
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Werken externe Excel-werkboeken als gegevensbron, en hoe beïnvloedt dat opnieuw berekenen?**

Ja. Een grafiek kan een extern werkboek refereren: wanneer u de externe bron koppelt of ververst, worden formules en waarden uit dat werkboek gehaald, en de grafiek geeft de updates weer tijdens het openen/bewerken. De API laat u [specify the external workbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setexternalworkbook/) pad opgeven en de gekoppelde gegevens beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlines](/slides/nl/php-java/trend-line/) (lineair, exponentieel en anderen) worden door Aspose.Slides toegevoegd en bijgewerkt; hun parameters worden automatisch opnieuw berekend vanuit de seriedata, zodat u uw eigen berekeningen niet hoeft te implementeren.

**Als een presentatie meerdere grafieken met externe koppelingen bevat, kan ik bepalen welk werkboek elke grafiek gebruikt voor berekende waarden?**

Ja. Elke grafiek kan naar zijn eigen [external workbook](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdata/setexternalworkbook/) wijzen, of u kunt per grafiek een extern werkboek maken/vervangen, onafhankelijk van de andere.