---
title: 在 JavaScript 中创建或更新 PowerPoint 演示文稿图表
linktitle: 创建图表
type: docs
weight: 10
url: /zh/nodejs-java/create-chart/
keywords: "创建图表, 散点图, 饼图, 树形图, 股票图, 箱线图, 直方图, 漏斗图, 旭辉图, 多类别图, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中于 PowerPoint 演示文稿创建图表"
---

## 概述

本文介绍如何在 Java 中**创建 PowerPoint 演示文稿图表**。您还可以**在 JavaScript 中更新图表**。本文涵盖以下主题。

_图表_: **普通**
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

_图表_: **树形图**
- [Java 创建树形图](#java-create-tree-map-chart)
- [Java 创建 PowerPoint 树形图](#java-create-powerpoint-tree-map-chart)
- [Java 创建 PowerPoint 演示文稿树形图](#java-create-powerpoint-presentation-tree-map-chart)

_图表_: **股票图**
- [Java 创建股票图](#java-create-stock-chart)
- [Java 创建 PowerPoint 股票图](#java-create-powerpoint-stock-chart)
- [Java 创建 PowerPoint 演示文稿股票图](#java-create-powerpoint-presentation-stock-chart)

_图表_: **箱线图**
- [Java 创建箱线图](#java-create-box-and-whisker-chart)
- [Java 创建 PowerPoint 箱线图](#java-create-powerpoint-box-and-whisker-chart)
- [Java 创建 PowerPoint 演示文稿箱线图](#java-create-powerpoint-presentation-box-and-whisker-chart)

_图表_: **漏斗图**
- [Java 创建漏斗图](#java-create-funnel-chart)
- [Java 创建 PowerPoint 漏斗图](#java-create-powerpoint-funnel-chart)
- [Java 创建 PowerPoint 演示文稿漏斗图](#java-create-powerpoint-presentation-funnel-chart)

_图表_: **旭辉图**
- [Java 创建旭辉图](#java-create-sunburst-chart)
- [Java 创建 PowerPoint 旭辉图](#java-create-powerpoint-sunburst-chart)
- [Java 创建 PowerPoint 演示文稿旭辉图](#java-create-powerpoint-presentation-sunburst-chart)

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

_Action_: **更新图表**
- [Java 更新 PowerPoint 图表](#java-update-powerpoint-chart)
- [Java 更新演示文稿图表](#java-update-presentation-chart)
- [Java 更新 PowerPoint 演示文稿图表](#java-update-powerpoint-presentation-chart)


## **创建图表**
图表帮助人们快速可视化数据并获得洞察，这些信息可能在表格或电子表格中并不明显。

**为什么要创建图表？**

使用图表，您可以

* 在演示文稿的单张幻灯片上聚合、压缩或汇总大量数据
* 揭示数据中的模式和趋势
* 推断数据随时间或相对于特定计量单位的方向和动量
* 发现异常值、偏差、错误、无意义的数据等
* 传达或展示复杂数据

在 PowerPoint 中，您可以通过插入功能创建图表，该功能提供用于设计多种图表的模板。使用 Aspose.Slides，您可以创建常规图表（基于流行图表类型）和自定义图表。

{{% alert color="primary" %}} 
为了让您创建图表，Aspose.Slides 提供了 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType) 类。该类下的字段对应不同的图表类型。
{{% /alert %}} 

### **创建普通图表**

_步骤：创建图表_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 图表</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>步骤：</em> 在 JavaScript 中创建演示文稿图表</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿图表</strong></a>

代码步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加包含部分数据的图表并指定您首选的图表类型。
4. 为图表添加标题。
5. 访问图表数据工作表。
6. 清除所有默认系列和类别。
7. 添加新的系列和类别。
8. 为图表系列添加新的数据。
9. 为图表系列添加填充颜色。
10. 为图表系列添加标签。
11. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建普通图表：
```javascript
// 实例化一个表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 添加一个带默认数据的图表
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // 设置图表标题
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // 设置第一系列显示数值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // 设置图表数据工作表的索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 删除默认生成的系列和类别
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // 添加新系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 添加新类别
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 获取第一条图表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 现在填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 设置系列的填充颜色
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 获取第二条图表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 设置该系列的填充颜色
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // 为新系列的每个类别创建自定义标签
    // 设置第一个标签显示类别名称
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // 为第三个标签显示数值
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // 保存包含图表的演示文稿
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建散点图**

散点图（也称为散点图或 x‑y 图）常用于检查模式或展示两个变量之间的相关性。

当满足以下条件时，您可能需要使用散点图

* 您拥有成对的数值数据
* 您有 2 个配对良好的变量
* 您想确定这 2 个变量是否相关
* 您有一个独立变量，对应多个因变量值

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>步骤：</em> 在 JavaScript 中创建散点图</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 散点图</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿散点图</strong></a>

1. 请按照上文[创建普通图表](#creating-normal-charts) 中的步骤操作
2. 第三步，添加图表并指定图表类型为以下之一
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _表示带标记的散点图。_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _表示用平滑曲线连接并带数据标记的散点图。_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _表示用平滑曲线连接且不带数据标记的散点图。_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _表示用直线连接并带数据标记的散点图。_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _表示用直线连接且不带数据标记的散点图。_

下面的 JavaScript 代码展示了如何使用不同标记系列创建散点图：
```javascript
// 实例化一个表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 创建默认图表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // 获取默认图表数据工作表索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 删除演示系列
    chart.getChartData().getSeries().clear();
    // 添加新系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // 获取第一条图表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 向系列添加新点 (1:3)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // 添加新点 (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // 更改系列类型
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // 更改图表系列标记
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // 获取第二条图表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 在此处添加新点 (5:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // 添加新点 (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // 添加新点 (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // 添加新点 (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // 更改图表系列标记
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建饼图**

饼图最适合展示数据的部分与整体关系，尤其是当数据包含带数值的分类标签时。然而，如果数据包含太多部分或标签，建议改用柱形图。

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>步骤：</em> 在 JavaScript 中创建饼图</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 饼图</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿饼图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Pie。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新数据。
8. 为饼图各扇区添加新点并自定义颜色。
9. 为系列设置标签。
10. 为系列标签设置指引线。
11. 设置饼图的旋转角度。
12. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建饼图：
```javascript
// 实例化一个表示 PPTX 文件的演示文稿类
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slides = pres.getSlides().get_Item(0);
    // 添加默认数据的图表
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // 设置图表标题
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // 设置第一系列显示数值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // 设置图表数据工作表的索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 删除默认生成的系列和类别
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 添加新类别
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // 添加新系列
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // 填充系列数据
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // 在新版本中不起作用
    // 添加新点并设置扇区颜色
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // 设置扇区边框
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // 设置扇区边框
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // 设置扇区边框
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // 为新系列的每个类别创建自定义标签
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // 显示图表的引导线
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // 设置饼图扇区的旋转角度
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // 保存包含图表的演示文稿
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建折线图**

折线图（也称为折线图）最适合用来展示随时间变化的数值。使用折线图，您可以一次比较大量数据，跟踪随时间的变化和趋势，突出数据系列中的异常等。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定类型为 `ChartType.Line`。
1. 访问图表数据 IChartDataWorkbook。
1. 清除默认系列和类别。
1. 添加新的系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建折线图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


默认情况下，折线图上的点由直线连续相连。如果希望点之间使用虚线相连，可按如下方式指定首选的虚线类型：
```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```


### **创建树形图**

树形图最适合用于销售数据，可显示各数据分类的相对大小，并快速关注对每个类别贡献大的项目。

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建树形图</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 树形图</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿树形图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).TreeMap。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新数据。
8. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建树形图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // 分支 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // 分支 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建股票图**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>步骤：</em> 在 JavaScript 中创建股票图</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 股票图</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿股票图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).OpenHighLowClose。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新数据。
8. 指定 HiLowLines 格式。
9. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 示例展示了如何创建股票图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建箱线图**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>步骤：</em> 在 JavaScript 中创建箱线图</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 箱线图</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿箱线图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).BoxAndWhisker。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新数据。
8. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建箱线图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建漏斗图**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>步骤：</em> 在 JavaScript 中创建漏斗图</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 漏斗图</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿漏斗图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Funnel。
4. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建漏斗图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建旭辉图**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>步骤：</em> 在 JavaScript 中创建旭辉图</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 旭辉图</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿旭辉图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).sunburst。
4. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建旭辉图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // 分支 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // 分支 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建直方图**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>步骤：</em> 在 JavaScript 中创建直方图</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 直方图</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿直方图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Histogram。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建直方图：
```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```


### **创建雷达图**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>步骤：</em> 在 JavaScript 中创建雷达图</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 雷达图</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿雷达图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一些数据的图表，并指定首选类型为 `ChartType.Radar`。
4. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建雷达图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建多类别图**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>步骤：</em> 在 JavaScript 中创建多类别图</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 多类别图</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿多类别图</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据的图表，并指定类型为 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).ClusteredColumn。
4. 访问图表数据 [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook)。
5. 清除默认系列和类别。
6. 添加新的系列和类别。
7. 为图表系列添加新数据。
8. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何创建多类别图：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // 添加系列
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // 保存带图表的演示文稿
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建地图图**

地图图是对包含数据的区域进行可视化的图形。地图图最适合比较不同地理区域的数据或数值。

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建地图图</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 地图图</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>步骤：</em> 在 JavaScript 中创建 PowerPoint 演示文稿地图图</strong></a>

下面的 JavaScript 代码展示了如何创建地图图：
```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **创建组合图**

组合图（或称为复合图）将两种或多种图表类型合并在同一图形中。该图表可帮助您突出、比较或检查多个数据集之间的差异，从而识别它们之间的关系。

![组合图表](combination_chart.png)

下面的 JavaScript 代码展示了如何在 PowerPoint 演示文稿中创建上述组合图表：
```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // 设置图表标题。
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // 设置图例。
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // 删除默认生成的系列和类别。
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // 添加新类别。
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // 添加第一系列。
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // 设置水平轴。
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // 设置垂直轴。
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // 设置垂直主网格线颜色。
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // 设置次要水平轴。
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 设置次要垂直轴。
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```



## **更新图表**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>步骤：</em> 在 JavaScript 中更新 PowerPoint 图表</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>步骤：</em> 在 JavaScript 中更新演示文稿图表</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>步骤：</em> 在 JavaScript 中更新 PowerPoint 演示文稿图表</strong></a>

1. 实例化一个表示包含要更新图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以查找目标图表。
4. 访问图表数据工作表。
5. 通过更改系列值来修改图表数据系列。
6. 添加新系列并填充数据。
7. 将修改后的演示文稿写入 PPTX 文件。

下面的 JavaScript 代码展示了如何更新图表：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var sld = pres.getSlides().get_Item(0);
    // 获取默认数据的图表
    var chart = sld.getShapes().get_Item(0);
    // 设置图表数据表的索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 更改图表类别名称
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // 获取第一条图表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 现在更新系列数据
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// 修改系列名称
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // 获取第二条图表系列
    series = chart.getChartData().getSeries().get_Item(1);
    // 现在更新系列数据
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// 修改系列名称
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // 现在，添加新系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // 获取第3条图表系列
    series = chart.getChartData().getSeries().get_Item(2);
    // 现在填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // 保存带图表的演示文稿
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **为图表设置数据范围**

要为图表设置数据范围，请执行以下操作：

1. 实例化一个表示包含该图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
2. 通过索引获取幻灯片的引用。
3. 遍历所有形状以查找目标图表。
4. 访问图表数据并设置范围。
5. 将修改后的演示文稿保存为 PPTX 文件。

下面的 JavaScript 代码展示了如何为图表设置数据范围：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **在图表中使用默认标记**

当在图表中使用默认标记时，每个图表系列会自动获得不同的默认标记符号。

下面的 JavaScript 代码展示了如何自动为图表系列设置标记：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // 获取第二条图表系列
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // 现在填充系列数据
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
