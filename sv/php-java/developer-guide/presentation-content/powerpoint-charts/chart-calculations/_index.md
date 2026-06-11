---
title: Optimera diagramberäkningar för presentationer i PHP
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/php-java/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underordnat element
- överordnat element
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för PHP via Java för PPT och PPTX, med praktiska kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Den här artikeln visar hur du hämtar de faktiska värdena för diagrammets element, inklusive den verkliga positionen och storleken på elementen samt de faktiska värdena för diagramaxlarna. Den förklarar också att dessa värden fylls i efter validering av diagramlayouten.

Dessutom demonstrerar artikeln hur du får den faktiska positionen för föräldraelement i diagram och hur du döljer diagramkomponenter såsom titel, axlar, legend och rutnät. Tillsammans hjälper dessa exempel dig att inspektera layoutinformationen för diagram och programatiskt styra synligheten för diagrammets element i PowerPoint-presentationer.

## **Beräkna faktiska värden för diagrammets element**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Metoder i klassen [Axis](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/) ger information om den faktiska positionen för diagrammets axel­element ([getActualMaxValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/getactualminorunitscale/)). Det är nödvändigt att anropa metoden [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/validatechartlayout/) i förväg för att fylla egenskaperna med faktiska värden.

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

## **Beräkna faktisk position för föräldraelement i diagrammet**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hämta dessa egenskaper. Metoder i klassen `ActualLayout` ger information om den faktiska positionen för föräldraelementet i diagrammet (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Det är nödvändigt att anropa metoden [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/validatechartlayout/) i förväg för att fylla egenskaperna med faktiska värden.

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

## **Dölja diagrammets element**
Detta ämne hjälper dig att förstå hur du döljer information i diagrammet. Med Aspose.Slides för PHP via Java kan du dölja **Titel, vertikal axel, horisontell axel** och **rutlinjer** i diagrammet. Nedan visas ett kodexempel som visar hur du använder dessa egenskaper.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Dölja diagramtitel
    $chart->setTitle(false);
    # /Dölja värdeaxel
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Kategoriaxel synlighet
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Dölja legend
    $chart->setLegend(false);
    # Dölja MajorGridLines
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Ställa in serielinjens färg
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

**Fungerar externa Excel‑arbetsböcker som datakälla, och hur påverkar det omberäkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan hämtas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings‑/redigeringsoperationer. API:et låter dig [ange den externa arbetsboken](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/setexternalworkbook/) sökväg och hantera den länkade datan.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlines](/slides/sv/php-java/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar omberäknas automatiskt utifrån seriedatan, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdata/setexternalworkbook/), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.