---
title: Customize Error Bars in Presentation Charts Using PHP
linktitle: Error Bar
type: docs
url: /php-java/error-bar/
keywords:
- error bar
- custom value
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to add and customize error bars in charts with Aspose.Slides for PHP via Java — optimize data visuals in PowerPoint presentations."
---

## **Add Error Bars**
Aspose.Slides for PHP via Java provides a simple API for managing error bar values. The sample code applies when using a custom value type. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the [**data points**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```php
  # Create an instance of Presentation class
  $pres = new Presentation();
  try {
    # Creating a bubble chart
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Adding Error bars and setting its format
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Saving presentation
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add Custom Error Bar Values**
Aspose.Slides for PHP via Java provides a simple API for managing custom error bar values. The sample code applies when the [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) method returns **Custom**. To specify a value, use the **ErrorBarCustomValues** property of a specific data point in the [**data points**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) collection of series:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. Add a bubble chart on desired slide.
1. Access the first chart series and set the error bar X format.
1. Access the first chart series and set the error bar Y format.
1. Access the chart series individual data points and setting the Error Bar values for individual series data point.
1. Setting bars values and format.
1. Write the modified presentation to a PPTX file.

```php
  # Create an instance of Presentation class
  $pres = new Presentation();
  try {
    # Creating a bubble chart
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Adding custom Error bars and setting its format
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Accessing chart series data point and setting error bars values for
    # individual point
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Setting error bars for chart series points
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Saving presentation
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

They are rendered as part of the chart and preserved during conversion along with the rest of the chart formatting, assuming a compatible version or renderer.

**Can error bars be combined with markers and data labels?**

Yes. Error bars are a separate element and are compatible with markers and data labels; if elements overlap, you may need to adjust formatting.

**Where can I find the list of properties and classes for working with error bars in the API?**

In the API reference: the [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) class and the related classes [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) and [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).
