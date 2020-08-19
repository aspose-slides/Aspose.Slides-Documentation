---
title: Adding Chart Trend Lines in PHP
type: docs
weight: 20
url: /java/adding-chart-trend-lines-in-php/
---

## **Aspose.Slides - Adding Chart Trend Lines**
To Add Chart Trend Lines using **Aspose.Slides Java for PHP**, simply invoke **ChartTrendLines** module. Here you can see example code.

**PHPCode**

```

 # Creating empty presentation

$pres =new Presentation();

\# Creating a clustered column chart

$chartType=new ChartType();

$chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart($chartType->ClusteredColumn, 20, 20, 500, 400);

\# Adding ponential trend line for chart series 1

$trendlineType=new TrendlineType();

$tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add($trendlineType->Exponential);

$tredLinep->setDisplayEquation(false);

$tredLinep->setDisplayRSquaredValue(false);

\# Adding Linear trend line for chart series 1

$fillType=new FillType();

$color=new Color();

$tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add($trendlineType->Linear);

$tredLineLin->setTrendlineType($trendlineType->Linear);

$tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType($fillType->Solid);

$tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color->RED);


\# Adding Logarithmic trend line for chart series 2

$tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add($trendlineType->Logarithmic);

$tredLineLog->setTrendlineType($trendlineType->Logarithmic);

$tredLineLog->addTextFrameForOverriding("New log trend line");

\# Adding MovingAverage trend line for chart series 2

$tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add($trendlineType->MovingAverage);

$tredLineMovAvg->setTrendlineType($trendlineType->MovingAverage);

$tredLineMovAvg->setPeriod(3);

$tredLineMovAvg->setTrendlineName("New TrendLine Name");

\# Adding Polynomial trend line for chart series 3

$tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add($trendlineType->Polynomial);

$tredLinePol->setTrendlineType($trendlineType->Polynomial);

$tredLinePol->setForward(1);

$tredLinePol->setOrder(3);

\# Adding Power trend line for chart series 3

$tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add($trendlineType->Power);

$tredLinePower->setTrendlineType($trendlineType->Power);

$tredLinePower->setBackward(1);

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "ChartTrendLines.pptx", $save_format->Pptx);

print "Done with chart trend lines, please check the output file.".PHP_EOL;

```
## **Download Running Code**
Download **Adding Chart Trend Lines (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithCharts/ChartTrendLines.php)
