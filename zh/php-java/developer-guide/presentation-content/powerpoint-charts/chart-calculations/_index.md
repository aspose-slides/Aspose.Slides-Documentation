---
title: 为 PHP 演示优化图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/php-java/chart-calculations/
keywords:
- 图表计算
- 图表元素
- 元素位置
- 实际位置
- 子元素
- 父元素
- 图表数值
- 实际数值
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解在 Aspose.Slides for PHP via Java 中进行 PPT 和 PPTX 的图表计算、数据更新和精度控制，并提供实用代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for PHP via Java 提供了一个简单的 API 用于获取这些属性。IAxis 接口的属性提供了关于轴图表元素实际位置的信息（[IAxis.getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMaxValue--), [IAxis.getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinValue--), [IAxis.getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnit--), [IAxis.getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnit--), [IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMajorUnitScale--), [IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/IAxis#getActualMinorUnitScale--))。需要在之前调用方法[IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) 来填充属性的实际值。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **计算父图表元素的实际位置**
Aspose.Slides for PHP via Java 提供了一个简单的 API 用于获取这些属性。IActualLayout 接口的属性提供了关于父图表元素实际位置的信息（[IActualLayout.getActualX](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/php-java/aspose.slides/IActualLayout#getActualHeight--))。需要在之前调用方法[IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) 来填充属性的实际值。
```php
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


## **隐藏图表元素**
本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for PHP via Java，您可以隐藏图表的 **标题、垂直轴、水平轴** 和 **网格线**。下面的代码示例展示了如何使用这些属性。
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # 隐藏图表标题
    $chart->setTitle(false);
    # /隐藏值轴
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # 类别轴可见性
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # 隐藏图例
    $chart->setLegend(false);
    # 隐藏主网格线
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # 设置系列线颜色
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿中获取，图表会在打开/编辑操作期间反映更新。API 允许您[指定外部工作簿](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)路径并管理链接的数据。

**我可以在不自行实现回归的情况下计算并显示趋势线吗？**

是的。[趋势线](/slides/zh/php-java/trend-line/)（线性、指数等）由 Aspose.Slides 添加和更新；其参数会自动根据系列数据重新计算，因此您无需自行实现计算。

**如果一个演示文稿包含多个带有外部链接的图表，我可以控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表可以指向其自己的[外部工作簿](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)，或者您可以为每个图表单独创建/替换外部工作簿，而不受其他图表的影响。