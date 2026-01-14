---
title: 使用 PHP 在演示文稿中自定义气泡图
linktitle: 气泡图
type: docs
url: /zh/php-java/bubble-chart/
keywords:
- 气泡图
- 气泡大小
- 尺寸缩放
- 尺寸表示
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 中创建并自定义强大的气泡图，轻松提升数据可视化效果。"
---

## **气泡图尺寸缩放**
Aspose.Slides for PHP via Java 提供对气泡图尺寸缩放的支持。在 Aspose.Slides for PHP via Java 中已添加了 [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbubblesizescale/)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/)和[**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/)方法。下面给出示例。

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将数据表示为气泡图尺寸**
已向 [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/)、[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) 类及相关类添加了方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/)。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的取值有： [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) 和 [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width)。因此，已添加 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) 枚举，以指定将数据表示为气泡图尺寸的可能方式。下面给出示例代码。

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**
**是否支持带有 3-D 效果的气泡图，它与普通气泡图有何不同？**

是的。 有一种单独的图表类型，“Bubble with 3-D”。它为气泡应用 3D 样式，但不会增加额外的坐标轴；数据仍保持 X-Y-S（大小）。该类型可在 [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类中找到。

**气泡图的系列和数据点数量是否有限制？**

在 API 级别没有硬性限制；约束取决于性能和目标 PowerPoint 版本。建议保持点的数量适中，以确保可读性和渲染速度。

**导出会如何影响气泡图的外观（PDF、图像）？**

导出到受支持的格式会保留图表外观；渲染由 Aspose.Slides 引擎完成。对于光栅/矢量格式，遵循通用的图表渲染规则（分辨率、抗锯齿），因此打印时应选择足够的 DPI。