---
title: 在 Java 中创建或更新 PowerPoint 演示文稿图表
linktitle: 创建图表
type: docs
weight: 10
url: /androidjava/create-chart/
keywords: "创建图表, 散点图, 饼图, 树图, 股票图, 箱线图, 直方图, 漏斗图, 日晕图, 多类别图, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中创建 PowerPoint 演示文稿中的图表"
---

## 概述

本文描述了如何在 **Java 中创建 PowerPoint 演示文稿图表**。您还可以 **在 Java 中更新图表**。涉及以下主题。

_图表_: **普通**
- [Java 创建 PowerPoint 图表](#java-create-powerpoint-chart)
- [Java 创建演示文稿图表](#java-create-presentation-chart)
- [Java 创建 PowerPoint 演示文稿图表](#java-create-powerpoint-presentation-chart)

_图表_: **散点**
- [Java 创建散点图](#java-create-scattered-chart)
- [Java 创建 PowerPoint 散点图](#java-create-powerpoint-scattered-chart)
- [Java 创建 PowerPoint 演示文稿散点图](#java-create-powerpoint-presentation-scattered-chart)

_图表_: **饼**
- [Java 创建饼图](#java-create-pie-chart)
- [Java 创建 PowerPoint 饼图](#java-create-powerpoint-pie-chart)
- [Java 创建 PowerPoint 演示文稿饼图](#java-create-powerpoint-presentation-pie-chart)

_图表_: **树图**
- [Java 创建树图](#java-create-tree-map-chart)
- [Java 创建 PowerPoint 树图](#java-create-powerpoint-tree-map-chart)
- [Java 创建 PowerPoint 演示文稿树图](#java-create-powerpoint-presentation-tree-map-chart)

_图表_: **股票**
- [Java 创建股票图](#java-create-stock-chart)
- [Java 创建 PowerPoint 股票图](#java-create-powerpoint-stock-chart)
- [Java 创建 PowerPoint 演示文稿股票图](#java-create-powerpoint-presentation-stock-chart)

_图表_: **箱线图**
- [Java 创建箱线图](#java-create-box-and-whisker-chart)
- [Java 创建 PowerPoint 箱线图](#java-create-powerpoint-box-and-whisker-chart)
- [Java 创建 PowerPoint 演示文稿箱线图](#java-create-powerpoint-presentation-box-and-whisker-chart)

_图表_: **漏斗**
- [Java 创建漏斗图](#java-create-funnel-chart)
- [Java 创建 PowerPoint 漏斗图](#java-create-powerpoint-funnel-chart)
- [Java 创建 PowerPoint 演示文稿漏斗图](#java-create-powerpoint-presentation-funnel-chart)

_图表_: **日晕**
- [Java 创建日晕图](#java-create-sunburst-chart)
- [Java 创建 PowerPoint 日晕图](#java-create-powerpoint-sunburst-chart)
- [Java 创建 PowerPoint 演示文稿日晕图](#java-create-powerpoint-presentation-sunburst-chart)

_图表_: **直方图**
- [Java 创建直方图](#java-create-histogram-chart)
- [Java 创建 PowerPoint 直方图](#java-create-powerpoint-histogram-chart)
- [Java 创建 PowerPoint 演示文稿直方图](#java-create-powerpoint-presentation-histogram-chart)

_图表_: **雷达**
- [Java 创建雷达图](#java-create-radar-chart)
- [Java 创建 PowerPoint 雷达图](#java-create-powerpoint-radar-chart)
- [Java 创建 PowerPoint 演示文稿雷达图](#java-create-powerpoint-presentation-radar-chart)

_图表_: **多类别**
- [Java 创建多类别图](#java-create-multi-category-chart)
- [Java 创建 PowerPoint 多类别图](#java-create-powerpoint-multi-category-chart)
- [Java 创建 PowerPoint 演示文稿多类别图](#java-create-powerpoint-presentation-multi-category-chart)

_图表_: **地图**
- [Java 创建地图图](#java-create-map-chart)
- [Java 创建 PowerPoint 地图图](#java-create-powerpoint-map-chart)
- [Java 创建 PowerPoint 演示文稿地图图](#java-create-powerpoint-presentation-map-chart)

_操作_: **更新图表**
- [Java 更新 PowerPoint 图表](#java-update-powerpoint-chart)
- [Java 更新演示文稿图表](#java-update-presentation-chart)
- [Java 更新 PowerPoint 演示文稿图表](#java-update-powerpoint-presentation-chart)


## **创建图表**
图表有助于人们快速可视化数据并获得洞见，这些洞察在表格或电子表格中可能并不明显。 


**为什么要创建图表？**

使用图表，您可以

* 在演示文稿的单个幻灯片上汇总、压缩或总结大量数据
* 暴露数据中的模式和趋势
* 推断数据随时间或特定测量单位的方向和趋势 
* 找出异常值、偏差、错误、不合逻辑的数据等 
* 传达或展示复杂数据

在 PowerPoint 中，您可以通过插入功能创建图表，该功能提供了用于设计多种类型图表的模板。使用 Aspose.Slides，您可以创建常规图表（基于流行的图表类型）和自定义图表。 

{{% alert color="primary" %}} 

为了让您能够创建图表，Aspose.Slides 提供了 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType) 类。该类下的字段对应于不同的图表类型。

{{% /alert %}} 

### **创建普通图表**

_步骤：创建图表_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 图表</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>步骤：</em>在 Java 中创建演示文稿图表</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿图表</strong></a>

_代码步骤：_

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有一些数据的图表，并指定您选择的图表类型。 
4. 为图表添加标题。 
5. 访问图表数据工作表。
6. 清除所有默认系列和类别。
7. 添加新系列和类别。
8. 为图表系列添加一些新图表数据。
9. 为图表系列添加填充颜色。
10. 为图表系列添加标签。 
11. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了如何创建普通图表：

```java
// Instantiates a presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Adds a chart with its default data
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Sets the chart Title
    chart.getChartTitle().addTextFrameForOverriding("示例标题");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Sets the first series to show values
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Sets the index for the chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Gets the chart data WorkSheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Deletes the default generated series and categories
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Adds new series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "系列 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "系列 2"),chart.getType());
    
    // Adds new categories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "分类 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "分类 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "分类 3"));
    
    // Takes the first chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Now populates the series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Sets the fill color for series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Takes the second chart series
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Populates series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Sets the fill color for the series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Create custom labels for each categories for the new series
    // Sets the first label to show Category name
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Shows value for the third label
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Saves the presentation with chart
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建散点图**
散点图（也称为散点图或 x-y 图）通常用于检查模式或演示两个变量之间的相关性。 

您可能想在以下情况下使用散点图：

* 您拥有成对的数值数据
* 您有两个变量配对良好
* 您想确定两个变量是否相关
* 您有一个独立变量，其具有多个从属变量的值

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>步骤：</em>在 Java 中创建散点图</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 散点图</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿散点图</strong></a>

1. 请遵循上述 [创建普通图表](#creating-normal-charts) 中提到的步骤
2. 对于第三步，添加带有一些数据的图表，并将图表类型指定为以下之一
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _表示散点图。_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _表示带有曲线和数据标记的散点图。_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _表示不带数据标记的曲线连接的散点图。_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _表示带有数据标记的直线连接的散点图。_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _表示不带数据标记的直线连接的散点图。_

以下 Java 代码演示了如何创建带有不同系列标记的散点图：

```java
// Instantiates a presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Creates the default chart
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Gets the default chart data worksheet index
    int defaultWorksheetIndex = 0;
    
    // Gets the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Deletes the demo series
    chart.getChartData().getSeries().clear();
    
    // Adds new series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "系列 2"), chart.getType());
    
    // Takes first chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Adds a new point (1:3) to the series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Adds a new point (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Changes the series type
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Changes the chart series marker
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Takes the second chart series
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Adds a new point (5:2) there
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Adds a new point (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Adds a new point (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Adds a new point (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Changes the chart series marker
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建饼图**

饼图最好用于显示数据中的部分与整体之间的关系，尤其是当数据包含带有数值的分类标签时。然而，如果您的数据包含许多部分或标签，您可能希望考虑使用条形图。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>步骤：</em>在 Java 中创建饼图</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 饼图</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿饼图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（在本例中，是 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Pie）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 为图表的扇区添加新点并添加自定义颜色。
9. 为系列设置标签。
10. 为系列标签设置引导线。
11. 设置饼图幻灯片的旋转角度。
12. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建饼图：

```java
// Instantiates a presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Adds a chart with default data
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Sets the chart Title
    chart.getChartTitle().addTextFrameForOverriding("示例标题");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Sets the first series to show values
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Sets the index for the chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Gets the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Deletes the default generated series and categories
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Adds new categories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "第一季度"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "第二季度"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "第三季度"));
    
    // Adds new series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "系列 1"), chart.getType());
    
    // Populates the series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Not working in new version
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Sets the Sector border
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Sets the Sector border
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Sets the Sector border
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Creates custom labels for each of categories for new series
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Shows Leader Lines for Chart
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Sets the Rotation Angle for Pie Chart Sectors
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Saves the presentation with a chart
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建线图**

线图（也称为线形图）最好用于显示要演示的值随时间的变化情况。使用线图，您可以同时比较大量数据，跟踪数据随时间的变化和趋势，突出数据系列中的异常等。

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（在本例中，为 `ChartType.Line`）。
4. 访问图表数据 IChartDataWorkbook。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建线图：

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

默认情况下，线图上的点由直线连接。如果您希望点通过虚线连接，可以通过以下方式指定您首选的虚线类型：

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **创建树图**

树图在销售数据中最适合用来显示数据类别的相对大小，并在同一时间快速引起对每个类别中大型贡献项的关注。 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>步骤：</em>在 Java 中创建树图</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 树图</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿树图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（在本例中，为 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).TreeMap）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建树图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branch 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "叶子1"));
    leaf.getGroupingLevels().setGroupingItem(1, "干1");
    leaf.getGroupingLevels().setGroupingItem(2, "分支1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "叶子2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "叶子3"));
    leaf.getGroupingLevels().setGroupingItem(1, "干2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "叶子4"));

    //branch 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "叶子5"));
    leaf.getGroupingLevels().setGroupingItem(1, "干3");
    leaf.getGroupingLevels().setGroupingItem(2, "分支2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "叶子6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "叶子7"));
    leaf.getGroupingLevels().setGroupingItem(1, "干4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "叶子8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建股票图**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>步骤：</em>在 Java 中创建股票图</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-create-powerpoint-stock-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 股票图</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿股票图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).OpenHighLowClose）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 指定 HiLowLines 格式。
9. 将修改后的演示文稿写入 PPTX 文件

用于创建股票图的示例 Java 代码：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "开盘"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "最高"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "最低"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "收盘"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建箱线图**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>步骤：</em>在 Java 中创建箱线图</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-create-powerpoint-box-and-whisker-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 箱线图</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿箱线图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).BoxAndWhisker）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建箱线图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "类别 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建漏斗图**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>步骤：</em>在 Java 中创建漏斗图</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 漏斗图</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿漏斗图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Funnel）。
4. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建漏斗图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "类别 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "类别 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "类别 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "类别 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "类别 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "类别 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建日晕图**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>步骤：</em>在 Java 中创建日晕图</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 日晕图</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿日晕图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（在本例中，[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).sunburst）。
4. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建日晕图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branch 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "叶子1"));
    leaf.getGroupingLevels().setGroupingItem(1, "干1");
    leaf.getGroupingLevels().setGroupingItem(2, "分支1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "叶子2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "叶子3"));
    leaf.getGroupingLevels().setGroupingItem(1, "干2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "叶子4"));

    //branch 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "叶子5"));
    leaf.getGroupingLevels().setGroupingItem(1, "干3");
    leaf.getGroupingLevels().setGroupingItem(2, "分支2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "叶子6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "叶子7"));
    leaf.getGroupingLevels().setGroupingItem(1, "干4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "叶子8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建直方图**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>步骤：</em>在 Java 中创建直方图</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 直方图</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿直方图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表以及所需的类型（[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).Histogram）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建直方图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建雷达图**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>步骤：</em>在 Java 中创建雷达图</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 雷达图</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿雷达图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。 
3. 添加一个带有数据的图表，并指定您的首选图表类型（在本例中，即 `ChartType.Radar`）。
4. 将修改后的演示文稿写入 PPTX 文件

以下 Java 代码演示了如何创建雷达图：

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建多类别图**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>步骤：</em>在 Java 中创建多类别图</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 多类别图</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿多类别图</strong></a>

1. 创建一个表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。 
3. 添加一个带有默认数据的图表以及所需的类型（[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartType).ClusteredColumn）。
4. 访问图表数据 [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新系列和类别。
7. 为图表系列添加新图表数据。
8. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了如何创建多类别图：

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "组1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "组2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "组3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "组4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Adding Series
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "系列 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Save presentation with chart
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建地图图**

地图图是数据区域的可视化。地图图最好用于比较不同地理区域的数据或值。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>步骤：</em>在 Java 中创建地图图</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 地图图</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>步骤：</em>在 Java 中创建 PowerPoint 演示文稿地图图</strong></a>

以下 Java 代码演示了如何创建地图图：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **创建组合图**

组合图（或组合图表）是将两种或多种图表组合在单个图形上的图表。这种图表允许您突出、比较或查看两组（或更多）数据之间的差异。通过这种方式，您可以看到数据集之间（如果有的话）的关系。 

![组合图](combination-chart-ppt.png)

以下 Java 代码演示了如何在 PowerPoint 中创建组合图：

```java
private static void createComboChart()
{
    Presentation pres = new Presentation();
    {
        IChart chart = createChart(pres.getSlides().get_Item(0));
        addFirstSeriesToChart(chart);
        addSecondSeriesToChart(chart);
        pres.save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart createChart(ISlide slide)
{
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 1, "系列 1"), chart.getType());
    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 2, "系列 2"), chart.getType());

    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "分类 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "分类 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "分类 3"));

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 30));
    
    series.setPlotOnSecondAxis(true);

    return chart;
}

private static void addFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 3, "系列 3"), ChartType.ScatterWithSmoothLines);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 1, 3),
            workbook.getCell(worksheetIndex, 1, 2, 5));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 10),
            workbook.getCell(worksheetIndex, 1, 4, 13));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 3, 20),
            workbook.getCell(worksheetIndex, 2, 4, 15));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 3, 12),
            workbook.getCell(worksheetIndex, 3, 4, 9));

    series.setPlotOnSecondAxis(true);
}

private static void addSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 5, "系列 4"),
            ChartType.ScatterWithStraightLinesAndMarkers);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 5),
            workbook.getCell(worksheetIndex, 1, 4, 2));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 5, 10),
            workbook.getCell(worksheetIndex, 1, 6, 7));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 5, 15),
            workbook.getCell(worksheetIndex, 2, 6, 12));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 5, 12),
            workbook.getCell(worksheetIndex, 3, 6, 9));

    series.setPlotOnSecondAxis(true);
}
```

## **更新图表**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>步骤：</em>在 Java 中更新 PowerPoint 图表</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>步骤：</em>在 Java 中更新演示文稿图表</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>步骤：</em>在 Java 中更新 PowerPoint 演示文稿图表</strong></a>

1. 实例化一个表示包含您要更新的图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类。
2. 通过使用其索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据系列数据。
6. 添加新系列并填充其中的数据。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了如何更新图表：

```java
Presentation pres = new Presentation();
try {
    // Access first slideMarker
    ISlide sld = pres.getSlides().get_Item(0);

    // Get chart with default data
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;

    // Getting the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Changing chart Category Name
    fact.getCell(defaultWorksheetIndex, 1, 0, "修改后的分类 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "修改后的分类 2");

    // Take first chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Now updating series data
    fact.getCell(defaultWorksheetIndex, 0, 1, "新系列1");// Modifying series name
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Take Second chart series
    series = chart.getChartData().getSeries().get_Item(1);

    // Now updating series data
    fact.getCell(defaultWorksheetIndex, 0, 2, "新系列2");// Modifying series name
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Now, Adding a new series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "系列 3"), chart.getType());

    // Take 3rd chart series
    series = chart.getChartData().getSeries().get_Item(2);

    // Now populating series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Save presentation with chart
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **为图表设置数据范围**

要为图表设置数据范围，请执行以下操作：

1. 实例化一个表示包含图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类。
2. 通过其索引获取幻灯片的引用。
3. 遍历所有形状以找到所需的图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了如何为图表设置数据范围：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在图表中使用默认标记**
当您在图表中使用默认标记时，每个图表系列会自动获得不同的默认标记符号。

以下 Java 代码演示了如何在图表系列中自动设置图表系列标记：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "系列 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "系列 2"), chart.getType());
    //Take second chart series
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //Now populating series data
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```