---
title: Adding Chart Series Overlap for Charts in PHP
type: docs
weight: 10
url: /java/adding-chart-series-overlap-for-charts-in-php/
---

## **Aspose.Slides - Adding Chart Series Overlap for Charts**
To Add Chart Series Overlap for Charts using **Aspose.Slides Java for PHP**, call **add_overlap_for_chart** method of **ChartSeries** module. Here you can see example code.

**PHPCode**

```

 # Instantiate Presentation class that represents the presentation file

$pres = new Presentation();

\# Adding chart

$chartType = new ChartType();

$chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart($chartType->ClusteredColumn, 50, 50, 600, 400, true);

$series = $chart->getChartData()->getSeries();

if ($series->get_Item(0)->getOverlap() == 0) {

\# Setting series overlap

    $series -> get_Item(0) -> getParentSeriesGroup()->setOverlap(-30);

}

\# Saving the presentation

$save_format = new SaveFormat();

$pres->save($dataDir . "Overlap.pptx", $save_format->Pptx);

print "Added chart series overlap for charts, please check the output file.".PHP_EOL;

```
## **Download Running Code**
Download **Adding Chart Series Overlap for Charts (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithCharts/ChartSeries.php)
