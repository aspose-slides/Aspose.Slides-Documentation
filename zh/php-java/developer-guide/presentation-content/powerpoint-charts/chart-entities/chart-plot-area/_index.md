---
title: 使用 PHP 定制演示文稿图表的绘图区
linktitle: 绘图区
type: docs
url: /zh/php-java/chart-plot-area/
keywords:
- 图表
- 绘图区
- 绘图区宽度
- 绘图区高度
- 绘图区大小
- 布局模式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中定制图表绘图区。轻松提升幻灯片视觉效果。"
---

## **获取图表绘图区的宽度和高度**
Aspose.Slides for PHP via Java 提供了一个简单的 API 用于 .

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用方法 [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置图表绘图区的布局模式**
Aspose.Slides for PHP via Java 提供了一个简单的 API 来设置图表绘图区的布局模式。已在 [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) 类中添加了方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 和 [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)。如果手动定义绘图区的布局，此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）进行布局。此属性有两个可能的值，定义在 [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType) 枚举中。

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - 指定绘图区的大小应决定绘图区的尺寸，不包括刻度线和坐标轴标签。
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - 指定绘图区的大小应决定绘图区的尺寸、刻度线以及坐标轴标签。

以下提供示例代码。
```php
  # 创建 Presentation 类的实例
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**实际的 x、实际的 y、实际的宽度和实际的高度返回的单位是什么？**

以点为单位；1 英寸 = 72 点。这是 Aspose.Slides 的坐标单位。

**绘图区与图表区在内容上有何区别？**

绘图区是数据绘制区域（系列、网格线、趋势线等）；图表区包括周围的元素（标题、图例等）。在 3D 图表中，绘图区还包括墙面/底面和坐标轴。

**当布局为手动时，绘图区的 x、y、宽度和高度如何解释？**

它们是图表整体大小的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区位置会变化？**

图例位于图表区的绘图区之外，但会影响布局和可用空间，因此在自动定位生效时，绘图区可能会因图例的存在而移动。这是 PowerPoint 图表的标准行为。