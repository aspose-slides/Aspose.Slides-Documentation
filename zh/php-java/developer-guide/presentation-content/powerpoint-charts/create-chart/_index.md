---
title: 创建或更新 PowerPoint 演示文稿图表
linktitle: 创建图表
type: docs
weight: 10
url: /zh/php-java/create-chart/
keywords: "创建图表, 散点图, 饼图, 树状图, 股票图, 箱形图, 直方图, 漏斗图, 日冕图, 多类别图, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中创建图表"
---

## 概述

本文描述了如何在 **Java 中创建 PowerPoint 演示文稿图表**。您还可以**更新图表**。它涵盖了以下主题。

_图表_: **常规**
- [Java 创建 PowerPoint 图表](#java-create-powerpoint-chart)
- [Java 创建演示文稿图表](#java-create-presentation-chart)
- [Java 创建 PowerPoint 演示文稿图表](#java-create-powerpoint-presentation-chart)

_图表_: **散点图**
- [Java 创建散点图](#java-create-scattered-chart)
- [Java 创建 PowerPoint 散点图](#java-create-powerpoint-scattered-chart)
- [Java 创建 PowerPoint 演示文稿散点图](#java-create-powerpoint-presentation-scattered-chart)

_图表_: **饼图**
- [Java 创建饼图](#java-create-pie-chart)
- [Java 创建 PowerPoint 饼图](#java-create-powerpoint-pie-chart)
- [Java 创建 PowerPoint 演示文稿饼图](#java-create-powerpoint-presentation-pie-chart)

_图表_: **树状图**
- [Java 创建树状图](#java-create-tree-map-chart)
- [Java 创建 PowerPoint 树状图](#java-create-powerpoint-tree-map-chart)
- [Java 创建 PowerPoint 演示文稿树状图](#java-create-powerpoint-presentation-tree-map-chart)

_图表_: **股票图**
- [Java 创建股票图](#java-create-stock-chart)
- [Java 创建 PowerPoint 股票图](#java-create-powerpoint-stock-chart)
- [Java 创建 PowerPoint 演示文稿股票图](#java-create-powerpoint-presentation-stock-chart)

_图表_: **箱形图**
- [Java 创建箱形图](#java-create-box-and-whisker-chart)
- [Java 创建 PowerPoint 箱形图](#java-create-powerpoint-box-and-whisker-chart)
- [Java 创建 PowerPoint 演示文稿箱形图](#java-create-powerpoint-presentation-box-and-whisker-chart)

_图表_: **漏斗图**
- [Java 创建漏斗图](#java-create-funnel-chart)
- [Java 创建 PowerPoint 漏斗图](#java-create-powerpoint-funnel-chart)
- [Java 创建 PowerPoint 演示文稿漏斗图](#java-create-powerpoint-presentation-funnel-chart)

_图表_: **日冕图**
- [Java 创建日冕图](#java-create-sunburst-chart)
- [Java 创建 PowerPoint 日冕图](#java-create-powerpoint-sunburst-chart)
- [Java 创建 PowerPoint 演示文稿日冕图](#java-create-powerpoint-presentation-sunburst-chart)

_图表_: **直方图**
- [Java 创建直方图](#java-create-histogram-chart)
- [Java 创建 PowerPoint 直方图](#java-create-powerpoint-histogram-chart)
- [Java 创建 PowerPoint 演示文稿直方图](#java-create-powerpoint-presentation-histogram-chart)

_图表_: **雷达图**
- [Java 创建雷达图](#java-create-radar-chart)
- [Java 创建 PowerPoint 雷达图](#java-create-powerpoint-radar-chart)
- [Java 创建 PowerPoint 演示文稿雷达图](#java-create-powerpoint-presentation-radar-chart)

_图表_: **多类别图**
- [Java 创建多类别图](#java-create-multi-category-chart)
- [Java 创建 PowerPoint 多类别图](#java-create-powerpoint-multi-category-chart)
- [Java 创建 PowerPoint 演示文稿多类别图](#java-create-powerpoint-presentation-multi-category-chart)

_图表_: **地图图**
- [Java 创建地图图](#java-create-map-chart)
- [Java 创建 PowerPoint 地图图](#java-create-powerpoint-map-chart)
- [Java 创建 PowerPoint 演示文稿地图图](#java-create-powerpoint-presentation-map-chart)

_操作_: **更新图表**
- [Java 更新 PowerPoint 图表](#java-update-powerpoint-chart)
- [Java 更新演示文稿图表](#java-update-presentation-chart)
- [Java 更新 PowerPoint 演示文稿图表](#java-update-powerpoint-presentation-chart)


## **创建图表**
图表帮助人们快速可视化数据并获得见解，这些见解在表格或电子表格中可能并不明显。 


**为什么要创建图表？**

使用图表，您可以

* 在演示文稿的单一幻灯片上聚合、浓缩或总结大量数据
* 揭示数据中的模式和趋势
* 推断数据随时间的方向和动量，或针对特定的测量单位 
* 发现异常值、偏差、偏差、错误、无意义数据等 
* 传达或呈现复杂数据

在 PowerPoint 中，您可以通过插入功能创建图表，该功能提供用于设计多种类型图表的模板。使用 Aspose.Slides，您可以创建常规图表（基于常见图表类型）和自定义图表。 

{{% alert color="primary" %}} 

为了让您创建图表，Aspose.Slides 提供了 [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType) 类。该类下的字段对应于不同的图表类型。

{{% /alert %}} 

### **创建常规图表**

_步骤：创建图表_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>步骤：</em> 创建 PowerPoint 图表 </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>步骤：</em> 创建演示文稿图表 </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿图表 </strong></a>

_代码步骤：_

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有一些数据的图表并指定您首选的图表类型。 
4. 为图表添加标题。 
5. 访问图表数据工作表。
6. 清除所有默认系列和类别。
7. 添加新的系列和类别。
8. 为图表系列添加一些新的图表数据。
9. 为图表系列添加填充颜色。
10. 为图表系列添加标签。 
11. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码显示了如何创建一个常规图表：

```php
  # 实例化一个表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 访问第一个幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加带有默认数据的图表
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # 设置图表标题
    $chart->getChartTitle()->addTextFrameForOverriding("示例标题");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # 设置第一个系列显示值
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 设置图表数据工作表的索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除默认生成的系列和类别
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # 添加新系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "系列 2"), $chart->getType());
    # 添加新类别
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "类别 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "类别 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "类别 3"));
    # 获取第一个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 现在填充系列数据
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 设置系列的填充颜色
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 获取第二个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 填充系列数据
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 设置系列的填充颜色
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # 为新系列创建自定义标签
    # 设置第一个标签显示类别名称
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # 显示第三个标签的值
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # 保存带图表的演示文稿
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建散点图**
散点图（也称为散点图或 x-y 图）通常用于检查模式或演示两个变量之间的相关性。 

您可能希望在以下情况下使用散点图 

* 您有成对的数值数据
* 您有两个变量，它们彼此之间配合良好
* 您想确定两个变量是否相关
* 您有一个独立变量，该变量对于一个因变量有多个值

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>步骤：</em> 创建散点图 </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>步骤：</em> 创建 PowerPoint 散点图 </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿散点图 </strong></a>

1. 请按照 [创建常规图表](#creating-normal-charts) 中提到的步骤进行操作
2. 在第三步中，添加带有一些数据的图表并将图表类型指定为以下之一
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _表示散点图。_
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _表示用曲线连接的散点图，带数据标记。_
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _表示用曲线连接的散点图，不带数据标记。_
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _表示用线连接的散点图，带数据标记。_
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _表示用线连接的散点图，不带数据标记。_

以下 PHP 代码显示了如何创建一个带有不同系列标记的散点图：

```php
  # 实例化一个表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 访问第一个幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 创建默认图表
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # 获取默认图表数据工作表索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除演示系列
    $chart->getChartData()->getSeries()->clear();
    # 添加新系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "系列 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "系列 2"), $chart->getType());
    # 获取第一个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 向系列添加一个新点 (1:3)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # 添加一个新点 (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # 更改系列类型
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # 更改图表系列标记
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # 获取第二个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 在那里添加一个新点 (5:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # 添加一个新点 (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # 添加一个新点 (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # 添加一个新点 (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # 更改图表系列标记
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建饼图**

饼图最适合于显示数据中的部分与整体的关系，特别是当数据包含带有数值的类别标签时。然而，如果您的数据包含许多部分或标签，您可能想考虑使用条形图。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>步骤：</em> 创建饼图 </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>步骤：</em> 创建 PowerPoint 饼图 </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿饼图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型（在这种情况下， [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 为饼图的扇区添加新点并添加自定义颜色。
9. 为系列设置标签。
10. 为系列标签设置引导线。
11. 设置饼图幻灯片的旋转角度。
12. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个饼图：

```php
  # 实例化一个表示 PPTX 文件的演示文稿类
  $pres = new Presentation();
  try {
    # 访问第一个幻灯片
    $slides = $pres->getSlides()->get_Item(0);
    # 添加带有默认数据的图表
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # 设置图表标题
    $chart->getChartTitle()->addTextFrameForOverriding("示例标题");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # 设置第一个系列显示值
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 设置图表数据工作表的索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 删除默认生成的系列和类别
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 添加新类别
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "第一季度"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "第二季度"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "第三季度"));
    # 添加新系列
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "系列 1"), $chart->getType());
    # 填充系列数据
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # 无法在新版本中使用
    # 添加新点并设置扇区颜色
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # 设置扇区边框
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # 设置扇区边框
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # 设置扇区边框
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # 为每个类别创建自定义标签
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # 显示图表的引导线
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # 设置饼图扇区的旋转角度
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # 保存带有图表的演示文稿
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建线图**

线图（也称为线型图）最适合用于演示随时间变化的值。在使用线图时，您可以一次性比较大量数据，跟踪随时间的变化和趋势，突出数据显示系列中的异常，等。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加带有默认数据的图表并指定所需的类型（在这种情况下， `ChartType::Line`）。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新的图表数据。
1. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个线图：

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

默认情况下，线图上的点通过直线连接。如果您希望点通过虚线连接，可以这样指定您首选的虚线类型：

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **创建树状图**

树状图最适合用于销售数据，当您想要显示数据类别的相对大小并迅速引起注意的大型贡献者时， 应该使用此类型图表。 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>步骤：</em> 创建树状图 </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>步骤：</em> 创建 PowerPoint 树状图 </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿树状图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型（在这种情况下，[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个树状图：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # 分支 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "叶子1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "分支1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "叶子2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "叶子3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "叶子4"));
    # 分支 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "叶子5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "分支2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "叶子6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "叶子7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "叶子8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建股票图**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>步骤：</em> 创建股票图 </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>步骤：</em> 创建 PowerPoint 股票图 </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿股票图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型 ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose)。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 指定 HiLowLines 格式。
9. 将修改后的演示文稿写入 PPTX 文件

用于创建股票图的示例 PHP 代码：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "开盘价"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "最高价"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "最低价"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "收盘价"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建箱形图**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>步骤：</em> 创建箱形图 </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>步骤：</em> 创建 PowerPoint 箱形图 </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿箱形图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型 ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker)。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个箱形图：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "类别 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建漏斗图**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>步骤：</em> 创建漏斗图 </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>步骤：</em> 创建 PowerPoint 漏斗图 </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿漏斗图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型 ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel)。
4. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个漏斗图：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "类别 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "类别 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "类别 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "类别 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "类别 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "类别 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建日冕图**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>步骤：</em> 创建日冕图 </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>步骤：</em> 创建 PowerPoint 日冕图 </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿日冕图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型（在这种情况下，[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst）。
4. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个日冕图：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # 分支 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "叶子1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "分支1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "叶子2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "叶子3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "叶子4"));
    # 分支 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "叶子5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "分支2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "叶子6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "叶子7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "主干4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "叶子8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建直方图**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>步骤：</em> 创建直方图 </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>步骤：</em> 创建 PowerPoint 直方图 </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿直方图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加带有默认数据的图表并指定所需的类型 ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram)。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个直方图：

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);

```

### **创建雷达图**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>步骤：</em> 创建雷达图 </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>步骤：</em> 创建 PowerPoint 雷达图 </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿雷达图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。 
3. 添加图表并指定您首选的图表类型（在这种情况下，`ChartType::Radar`）。
4. 将修改后的演示文稿写入 PPTX 文件

以下 PHP 代码显示了如何创建一个雷达图：

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建多类别图**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>步骤：</em> 创建多类别图 </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>步骤：</em> 创建 PowerPoint 多类别图 </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿多类别图 </strong></a>

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。 
3. 添加带有默认数据的图表并指定所需的类型（在这种情况下，[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新的图表数据。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码显示了如何创建一个多类别图：

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "组1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "组2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "组3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "组4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # 添加系列
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "系列 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # 保存带图表的演示文稿
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建地图图**

地图图是对区域数据的可视化。地图图最适合用于比较各地理区域的数据或值。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>步骤：</em> 创建地图图 </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>步骤：</em> 创建 PowerPoint 地图图 </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>步骤：</em> 创建 PowerPoint 演示文稿地图图 </strong></a>

以下 PHP 代码显示了如何创建一个地图图：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **创建组合图**

组合图（或组合图表）是将两个或多个图表合并为一个单一图表的图表。这样的图表可以突出显示、比较或回顾两个（或多个）数据集之间的差异。通过这种方式，您可以看到数据集之间的关系（如果有的话）。 

![combination-chart-ppt](combination-chart-ppt.png)

以下 PHP 代码显示了如何在 PowerPoint 中创建组合图：

```php

```

## **更新图表**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>步骤：</em> 更新 PowerPoint 图表 </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>步骤：</em> 更新演示文稿图表 </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>步骤：</em> 更新 PowerPoint 演示文稿图表 </strong></a>

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例，该实例表示包含您要更新的图表的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据系列数据。
6. 添加新的系列并填充数据。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 PHP 代码显示了如何更新图表：

```php
  $pres = new Presentation();
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 获取带有默认数据的图表
    $chart = $sld->getShapes()->get_Item(0);
    # 设置图表数据表的索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 更改图表类别名称
    $fact->getCell($defaultWorksheetIndex, 1, 0, "修改后的类别 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "修改后的类别 2");
    # 获取第一个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # 现在更新系列数据
    $fact->getCell($defaultWorksheetIndex, 0, 1, "新系列1");// 修改系列名称

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # 获取第二个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 现在更新系列数据
    $fact->getCell($defaultWorksheetIndex, 0, 2, "新系列2");// 修改系列名称

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # 现在，添加一个新系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "系列 3"), $chart->getType());
    # 获取第三个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # 现在填充系列数据
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # 保存带图表的演示文稿
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置图表的数据范围**

要为图表设置数据范围，可以按照以下步骤操作：

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例，该实例表示包含图表的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿保存为 PPTX 文件。

以下 PHP 代码显示了如何为图表设置数据范围：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在图表中使用默认标记**
当您在图表中使用默认标记时，每个图表系列会自动获得不同的默认标记符号。

以下 PHP 代码显示了如何自动设置图表系列标记：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "系列 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "系列 2"), $chart->getType());
    # 获取第二个图表系列
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # 现在填充系列数据
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```