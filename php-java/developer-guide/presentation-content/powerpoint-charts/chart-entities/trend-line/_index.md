---
title: Trend Line
type: docs
url: /php-java/trend-line/
---

## **Add Trend Line**
Aspose.Slides for PHP via Java provides a simple API for managing different chart Trend Lines:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses ChartType->ClusteredColumn).
1. Adding exponential trend line for chart series 1.
1. Adding linear trend line for chart series 1.
1. Adding logarithmic trend line for chart series 2.
1. Adding moving average trend line for chart series 2.
1. Adding polynomial trend line for chart series 3.
1. Adding power trend line for chart series 3.
1. Write the modified presentation to a PPTX file.

The following code is used to create a chart with Trend Lines.

```php
  // Create an instance of Presentation class
  $pres = new Presentation();
  try {
    // Creating a clustered column chart
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType->ClusteredColumn, 20, 20, 500, 400);
    // Adding ponential trend line for chart series 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType->Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    // Adding Linear trend line for chart series 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType->Linear);
    $tredLineLin->setTrendlineType(TrendlineType->Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType->Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    // Adding Logarithmic trend line for chart series 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType->Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType->Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    // Adding MovingAverage trend line for chart series 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType->MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType->MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    // Adding Polynomial trend line for chart series 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType->Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType->Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    // Adding Power trend line for chart series 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType->Power);
    $tredLinePower->setTrendlineType(TrendlineType->Power);
    $tredLinePower->setBackward(1);
    // Saving presentation
    $pres->save("ChartTrendLines_out.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```

## **Add Custom Line**
Aspose.Slides for PHP via Java provides a simple API to add custom lines in a chart. To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class
- Obtain the reference of a slide by using its Index
- Create a new chart using AddChart method exposed by Shapes object
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Set the Color of the shape lines.
- Write the modified presentation as a PPTX file

The following code is used to create a chart with Custom Lines.

```php
  // Create an instance of Presentation class
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType->ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType->Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType->Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat->Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }

```
