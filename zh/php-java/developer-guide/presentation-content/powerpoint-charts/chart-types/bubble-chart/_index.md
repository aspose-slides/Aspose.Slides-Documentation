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
Aspose.Slides for PHP via Java 提供了对气泡图尺寸缩放的支持。在 Aspose.Slides for PHP via Java 中已添加了 [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries#getBubbleSizeScale--)、[**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) 和 [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) 方法。下面给出了示例代码。
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
已在 [IChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeries)、[IChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup) 接口及相关类中添加了 方法 [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) 和 [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定气泡图中气泡尺寸值的表示方式。可能的取值有 [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Area) 和 [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType#Width)。因此，已添加了 [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/php-java/aspose.slides/BubbleSizeRepresentationType) 枚举，以指定将数据表示为气泡图尺寸的可能方式。下面给出示例代码。
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


## **常见问答**

**是否支持“具有 3D 效果的气泡图”，以及它与普通气泡图有何不同？**  
是的。存在一种单独的图表类型，“Bubble with 3-D”。它对气泡应用 3D 样式，但不会添加额外坐标轴；数据仍然是 X‑Y‑S（尺寸）。该类型在 [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 类中可用。

**气泡图的系列和数据点数量是否有限制？**  
在 API 层面没有硬性限制；约束由性能和目标 PowerPoint 版本决定。建议保持数据点数量适中，以确保可读性和渲染速度。

**导出（PDF、图像）会如何影响气泡图的外观？**  
导出到受支持的格式会保留图表外观；渲染由 Aspose.Slides 引擎完成。对于光栅/矢量格式，遵循一般的图表渲染规则（分辨率、抗锯齿），因此在打印时应选择足够的 DPI。