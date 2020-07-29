---
title: Adding Error Bars for Charts in PHP
type: docs
weight: 30
url: /java/adding-error-bars-for-charts-in-php/
---

## **Aspose.Slides - Adding Fixed Error Bar Value for Chart**
To Add Fixed Error Bar Value for Chart using **Aspose.Slides Java for PHP**, call **add_fixed_error_bar_value** method of **ErrorBars** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function add_fixed_error_bar_value($dataDir = null){

    $pres = new Presentation();

    # Creating a bubble chart

    $chartType=new ChartType();

    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart($chartType->Bubble, 50, 50, 400, 300, true);

    # Adding Error bars and setting its format

    $error_bar_x = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();

    $error_bar_y = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();



    #error_bar_x.isVisible(true)

    #error_bar_y.isVisible(true)

    $errorBarValueType = new ErrorBarValueType();

    $errorBarType = new ErrorBarType();

    $error_bar_x->setValueType($errorBarValueType->Fixed);

    $error_bar_x->setValue(0.1);

    $error_bar_y->setValueType($errorBarValueType->Percentage);

    $error_bar_y->setValue(5);

    $error_bar_x->setType($errorBarType->Plus);

    $error_bar_y->getFormat()->getLine()->setWidth(2.0);

    #error_bar_x.hasEndCap(true)

    # Save presentation with chart

    $save_format = new SaveFormat();

    $pres->save($dataDir . "ErrorBar.pptx", $save_format->Pptx);

    print "Added fixed error bar value for chart, please check the output file.".PHP_EOL;


}

{{< /highlight >}}
## **Aspose.Slides - Adding Custom Error Bar Value for Chart**
To Add Custom Error Bar Value for Chart for Chart using **Aspose.Slides Java for PHP**, call **add_custom_error_bar_value** method of **ErrorBars** module. Here you can see example code.

**PHPCode**

{{< highlight php >}}

 public static function add_custom_error_bar_value($dataDir = null)

{

    $pres = new Presentation();

    $slide = $pres->getSlides()->get_Item(0);

    # Creating a bubble chart

    $chartType = new ChartType();

    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart($chartType->Bubble, 50, 50, 400, 300, true);

    # Adding custom Error bars and setting its format

    $error_bar_value_type = new ErrorBarValueType();

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $error_bar_x = $series->getErrorBarsXFormat();

    $error_bar_y = $series->getErrorBarsYFormat();

    #error_bar_x.isVisible(true)

    #error_bar_y.isVisible(true)

    $error_bar_x->setValueType($error_bar_value_type->Custom);

    $error_bar_y->setValueType($error_bar_value_type->Custom);

    #Accessing chart series data point and setting error bars values for individual point

    $data_source_type = new DataSourceType();

    $points = $series->getDataPoints();

    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues($data_source_type->DoubleLiterals);

    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues($data_source_type->DoubleLiterals);

    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues($data_source_type->DoubleLiterals);

    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues($data_source_type->DoubleLiterals);

    # Setting error bars for chart series points

    $i = 0;

    while ($i < $points->size()){

        $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);

        $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);

        $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);

        $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);

        $i++;

    }

    $save_format = new SaveFormat();

    $pres->save($dataDir . "ErrorBarsCustomValues.pptx", $save_format->Pptx);

    print "Added custom error bars values for chart, please check the output file.".PHP_EOL;

}

{{< /highlight >}}
## **Download Running Code**
Download **Adding Error Bars for Charts (Aspose.Slides)** from any of the below mentioned social coding sites:

- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java/blob/master/Plugins/Aspose_Slides_Java_for_PHP/src/aspose/slides/WorkingWithCharts/ErrorBars.php)
