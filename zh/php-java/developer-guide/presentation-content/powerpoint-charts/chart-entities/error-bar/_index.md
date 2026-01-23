---
title: 使用 PHP 定制演示文稿图表的误差线
linktitle: 误差线
type: docs
url: /zh/php-java/error-bar/
keywords:
- 误差线
- 自定义值
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在图表中添加和自定义误差线——优化 PowerPoint 演示文稿中的数据可视化。"
---

## **添加误差线**
Aspose.Slides for PHP via Java 提供了用于管理误差线值的简易 API。此示例代码适用于使用自定义值类型的情况。要指定值，请使用特定数据点在系列的[**数据点**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/)集合中的**ErrorBarCustomValues**属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置错误棒 X 格式。
1. 访问第一个图表系列并设置错误棒 Y 格式。
1. 设置棒的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 创建气泡图表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # 添加误差线并设置其格式
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


## **添加自定义错误棒值**
Aspose.Slides for PHP via Java 提供了用于管理自定义错误棒值的简易 API。当[**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) 方法返回 **Custom** 时，示例代码适用。要指定值，请使用特定数据点在系列的[**数据点**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/)集合中的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置错误棒 X 格式。
1. 访问第一个图表系列并设置错误棒 Y 格式。
1. 访问图表系列的各个数据点并为单独的数据点设置错误棒值。
1. 设置棒的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 创建气泡图表
    # 添加自定义误差线并设置其格式
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # 访问图表系列数据点并设置误差线值
    # 单个点
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # 为图表系列点设置误差线
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


## **常见问题**

**导出演示文稿为 PDF 或图像时，错误棒会怎样？**

它们作为图表的一部分渲染，并在转换过程中与图表的其他格式一起保留下来，前提是使用兼容的版本或渲染器。

**错误棒可以与标记和数据标签组合使用吗？**

可以。错误棒是独立的元素，能够与标记和数据标签兼容；如果元素重叠，可能需要调整格式。

**在哪里可以找到用于在 API 中操作错误棒的属性和类列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) 类以及相关的 [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/) 类。