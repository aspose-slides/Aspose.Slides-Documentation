---
title: 使用 PHP 在演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/php-java/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 创建和自定义饼图，可导出到 PowerPoint，帮助您在几秒钟内提升数据叙事。"
---

## **饼图的饼图和条形饼图的第二绘图选项**
Aspose.Slides for PHP via Java 现在支持 Pie of Pie 或 Bar of Pie 图表的第二绘图选项。在本主题中，我们将展示如何使用 Aspose.Slides 指定这些选项。要指定属性，请执行以下操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二绘图选项。
1. 将演示文稿写入磁盘。

在下面的示例中，我们已设置 Pie of Pie 图表的不同属性。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 在幻灯片上添加图表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # 设置不同的属性
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # 将演示文稿写入磁盘
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置自动饼图切片颜色**
Aspose.Slides for PHP via Java 提供了一个简单的 API 来设置自动饼图切片颜色。示例代码演示了上述属性的设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 使用默认数据添加图表。
1. 设置图表标题。
1. 将第一系列设置为显示数值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    # 添加默认数据的图表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # 设置图表标题
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 将第一系列设置为显示数值
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 设置图表数据表的索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除默认生成的系列和类别
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 添加新类别
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # 添加新系列
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # 现在填充系列数据
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**是否支持 “Pie of Pie” 和 “Bar of Pie” 变体？**

是的，库[支持](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 饼图的第二绘图，包括 “Pie of Pie” 和 “Bar of Pie” 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以[导出图表本身为图像](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)（如 PNG），而无需导出整个演示文稿。