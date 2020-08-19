---
title: Creating a Chart from Scratch in PHP
type: docs
weight: 40
url: /java/creating-a-chart-from-scratch-in-php/
---

## **Aspose.Slides - Creating Normal Chart**
To Create Normal Chart using **Aspose.Slides Java for PHP**, call **create_normal_chart** method of **CreateChart** module. Here you can see example code.

**PHPCode**

```

 public static function create_normal_chart($dataDir=null){

    $pres = new Presentation();

    # Access first slide

    $sld = $pres->getSlides()->get_Item(0);

    $chartType=new ChartType();

    # Add chart with default data

    $chart = $sld->getShapes()->addChart($chartType->ClusteredColumn, 0, 0, 500, 500);

    $nullableBool=new NullableBool();

    # Setting chart Title

    # chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");

    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText($nullableBool->True);

    $chart->getChartTitle()->setHeight (20);

    $chart->hasTitle(true);

    # Set first series to Show Values

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    # Setting the index of chart data sheet

    $defaultWorksheetIndex = 0;

    # Getting the chart data worksheet

    $fact = $chart->getChartData()->getChartDataWorkbook();

    # Delete default generated series and categories

    $chart->getChartData()->getSeries()->clear();

    $chart->getChartData()->getCategories()->clear();

    $s = $chart->getChartData()->getSeries()->size();

    $s = $chart->getChartData()->getCategories()->size();

    # Adding new series

    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());

    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());

    # Adding new categories

    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));

    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));

    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

    # Take first chart series

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    # Now populating series data

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));

    # Setting fill color for series

    $fillType=new FillType();

    $color=new Color();


    $series->getFormat()->getFill()->setFillType($fillType->Solid);

    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color->RED);


    # Take second chart series

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    # Now populating series data

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));

    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));

    # Setting fill color for series

    $fillType1=new FillType();

    $color1=new Color();

    $series->getFormat()->getFill()->setFillType($fillType1->Solid);

    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color1->GREEN);

    # create custom labels for each of categories for new series

    # first label will be show Category name

    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();

    $lbl->getDataLabelFormat()->setShowCategoryName(true);

    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();

    $lbl->getDataLabelFormat()->setShowSeriesName(true);

    # Show value for third label

    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();

    $lbl->getDataLabelFormat()->setShowValue(true);

    $lbl->getDataLabelFormat()->setShowSeriesName(true);

    $lbl->getDataLabelFormat()->setSeparator ("/");

    # Save presentation with chart

    $save_format = new SaveFormat();

    $pres->save($dataDir . "NormalChart.pptx", $save_format->Pptx);

    print "Created normal chart, please check the output file.".PHP_EOL;

}

```
## **Download Running Code**
Download **Creating a Chart from Scratch (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithCharts/CreateChart.php)
