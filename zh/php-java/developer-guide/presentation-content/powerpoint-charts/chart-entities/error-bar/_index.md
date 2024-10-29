---
title: 错误条
type: docs
url: /zh/php-java/error-bar/
---

## **添加错误条**
Aspose.Slides for PHP via Java 提供了一个简单的 API 用于管理错误条值。示例代码适用于使用自定义值类型的情况。要指定一个值，请使用 [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 在所需的幻灯片上添加一个气泡图。
1. 访问第一个图表系列并设置错误条 X 格式。
1. 访问第一个图表系列并设置错误条 Y 格式。
1. 设置条形值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```php
  # 创建一个 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 创建气泡图
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 添加错误条并设置其格式
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
    # 保存演示文稿
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **添加自定义错误条值**
Aspose.Slides for PHP via Java 提供了一个简单的 API 用于管理自定义错误条值。示例代码适用于 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) 属性等于 **Custom** 的情况。要指定一个值，请使用 [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 在所需的幻灯片上添加一个气泡图。
1. 访问第一个图表系列并设置错误条 X 格式。
1. 访问第一个图表系列并设置错误条 Y 格式。
1. 访问图表系列的单个数据点并设置单个系列数据点的错误条值。
1. 设置条形值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```php
  # 创建一个 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 创建气泡图
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 添加自定义错误条并设置其格式
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # 访问图表系列数据点并为
    # 单个点设置错误条值
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # 为图表系列点设置错误条
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # 保存演示文稿
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```