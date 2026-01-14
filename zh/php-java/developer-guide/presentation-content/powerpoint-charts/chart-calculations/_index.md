---
title: 在 PHP 中优化演示文稿的图表计算
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
description: "了解在 Aspose.Slides for PHP via Java 中的图表计算、数据更新和精度控制（适用于 PPT 和 PPTX），并提供实用代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for PHP via Java 提供了一个简易的 API 来获取这些属性。 [Axis](https://reference.aspose.com/slides/php-java/aspose.slides/axis/) 类的方法提供关于坐标轴图表元素的实际位置的信息（[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)、[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)、[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)、[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)、[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)、[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/))。 在获取实际值之前，需要先调用 [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) 方法来填充属性的实际值。
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


## **计算父级图表元素的实际位置**
Aspose.Slides for PHP via Java 提供了一个简易的 API 来获取这些属性。 `ActualLayout` 类的方法提供关于父级图表元素的实际位置的信息（`getActualX`、`getActualY`、`getActualWidth`、`getActualHeight`）。 在获取实际值之前，需要先调用 [Chart.validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) 方法来填充属性的实际值。
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
本主题帮助您了解如何在图表中隐藏信息。 使用 Aspose.Slides for PHP via Java，您可以隐藏图表中的 **标题、垂直坐标轴、水平坐标轴** 和 **网格线**。 以下代码示例展示了如何使用这些属性。
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


## **常见问题**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿中获取，图表会在打开/编辑操作期间反映更新。 API 允许您 [指定外部工作簿](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 路径并管理链接数据。

**我可以在不自行实现回归计算的情况下生成并显示趋势线吗？**

是的。[趋势线](/slides/zh/php-java/trend-line/)（线性、指数等）由 Aspose.Slides 添加并更新；其参数会根据序列数据自动重新计算，您无需实现自己的计算逻辑。

**如果演示文稿中有多个带外部链接的图表，我能控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表可以指向其自己的 [外部工作簿](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)，或者您可以为每个图表独立创建/替换外部工作簿，而不影响其他图表。