---
title: 创建或更新 PowerPoint 演示文稿图表（C#）
linktitle: 创建或更新图表
type: docs
weight: 10
url: /zh/net/create-chart/
keywords:
- 添加图表
- 创建图表
- 编辑图表
- 更改图表
- 更新图表
- 散点图
- 饼图
- 折线图
- 树状图
- 股票图
- 箱线图
- 漏斗图
- 旭辉图
- 直方图
- 雷达图
- 多类别图表
- PowerPoint 演示文稿
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和自定义图表。内容包括在演示文稿中添加、格式化和编辑图表，并提供 C# 实际代码示例。"
---

## **概述**

本文提供了使用 Aspose.Slides for .NET 创建和自定义图表的完整指南。您将学习如何以编程方式向幻灯片添加图表、填充数据，并应用各种格式设置以满足特定的设计需求。文章中详细的代码示例展示了每一步，从初始化演示文稿和图表对象到配置系列、坐标轴和图例。通过本指南，您将深入了解如何在 .NET 应用程序中集成动态图表生成，简化数据驱动演示文稿的创建过程。

## **创建图表**

图表帮助人们快速可视化数据，并获得表格或电子表格中不易立即发现的洞察。

**为什么要创建图表？**

使用图表，您可以：

* 在单个幻灯片上汇总、压缩或概括大量数据；
* 显示数据中的模式和趋势；
* 推断数据随时间或特定计量单位的方向和动量；
* 发现异常值、偏差、错误和无意义的数据；
* 交流或展示复杂数据。

在 PowerPoint 中，您可以通过 *Insert* 功能创建图表，该功能提供了多种图表模板。使用 Aspose.Slides，您可以创建常规图表（基于流行图表类型）和自定义图表。

{{% alert color="primary" %}} 
使用位于 [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) 命名空间下的 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举。该枚举的值对应不同的图表类型。
{{% /alert %}} 

### **创建聚合柱形图**

本节介绍如何使用 Aspose.Slides for .NET 创建聚合柱形图。您将学习初始化演示文稿、添加图表以及自定义标题、数据、系列、类别和样式等元素。按照以下步骤查看标准聚合柱形图的生成过程：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加带有数据的图表，并指定 `ChartType.ClusteredColumn` 类型。
1. 为图表添加标题。
1. 访问图表的数据工作表。
1. 清除所有默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 为图表系列应用填充颜色。
1. 为图表系列添加标签。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码演示如何创建聚合柱形图：
```c#
// 实例化 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚合柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // 设置图表标题。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 设置第一系列显示数值。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // 设置图表数据表的索引。
    int worksheetIndex = 0;

    // 获取图表数据工作簿。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 删除默认生成的系列和类别。
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 添加新系列。
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // 添加新类别。
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // 获取第一条图表系列。
    IChartSeries series = chart.ChartData.Series[0];

    // 填充系列数据。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 设置系列的填充颜色。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // 获取第二条图表系列。
    series = chart.ChartData.Series[1];

    // 填充系列数据。
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // 设置系列的填充颜色。
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // 设置第一个标签显示类别名称。
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // 设置系列在第三个标签显示数值。
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


结果：

![聚合柱形图](clustered_column_chart.png)

### **创建散点图**

散点图（也称为散布图或 x‑y 图）常用于检查模式或展示两个变量之间的相关性。

在以下情况下使用散点图：

* 您有成对的数值数据。
* 您有两个配对良好的变量。
* 您想确定这两个变量是否相关。
* 您有一个独立变量对应多个因变量的取值。

以下 C# 代码展示如何使用不同标记系列创建散点图：
```c#
// 实例化 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 创建默认散点图。
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // 设置图表数据表的索引。
    int worksheetIndex = 0;

    // 获取图表数据工作簿。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 删除默认系列。
    chart.ChartData.Series.Clear();

    // 添加新系列。
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // 获取第一条图表系列。
    IChartSeries series = chart.ChartData.Series[0];

    // 向系列添加新点 (1:3)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // 添加新点 (2:10)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // 更改系列类型。
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // 更改图表系列标记。
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // 获取第二条图表系列。
    series = chart.ChartData.Series[1];

    // 向图表系列添加新点 (5:2)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // 添加新点 (3:1)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // 添加新点 (2:2)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // 添加新点 (5:1)。
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // 更改图表系列标记。
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```



结果：

![散点图](scatter_chart.png)

### **创建饼图**

饼图最适合显示数据的部分与整体的关系，尤其是当数据包含带数值的分类标签时。不过，如果数据包含大量部分或标签，建议使用条形图。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.Pie` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 为饼图的各扇区添加新点并应用自定义颜色。
1. 为系列设置标签。
1. 为系列标签启用引线。
1. 设置饼图的旋转角度。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建饼图：
```c#
// 实例化 Presentation 类。
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加带默认数据的图表。
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // 设置图表标题。
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // 将第一系列设置为显示数值。
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // 设置图表数据表的索引。
    int worksheetIndex = 0;

    // 获取图表数据工作簿。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 删除默认生成的系列和类别。
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 添加新类别。
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // 添加新系列。
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 填充系列数据。
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // 设置扇区颜色。
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // 设置扇区边框。
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // 设置扇区边框。
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // 设置扇区边框。
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // 为新系列的每个类别创建自定义标签。
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // 设置系列显示图表的引线。
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // 设置饼图扇区的旋转角度。
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```


结果：

![饼图](pie_chart.png)

### **创建折线图**

折线图（也称为折线图）最适合用于展示随时间变化的数值。使用折线图，您可以一次比较大量数据、跟踪随时间的变化趋势、突出数据系列中的异常等。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.Line` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建折线图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


默认情况下，折线图的点由直线连续相连。如果希望点之间使用虚线相连，可按如下方式指定首选的虚线类型：
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


结果：

![折线图](line_chart.png)

### **创建树状图**

树状图在展示销售数据时最为合适，能够显示数据类别的相对大小，并快速突出每个类别中对整体贡献较大的项目。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.Treemap` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建树状图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // 分支 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // 分支 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```


结果：

![树状图](treemap_chart.png)

### **创建股票图**

股票图用于显示开盘价、最高价、最低价和收盘价等金融数据，帮助分析市场趋势和波动性。它们为股票表现提供关键洞察，帮助投资者和分析师做出明智决策。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.OpenHighLowClose` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 指定 HiLowLines 格式。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建股票图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


结果：

![股票图](stock_chart.png)

### **创建箱线图**

箱线图用于通过汇总关键统计量（如中位数、四分位数和潜在异常值）来显示数据分布。它们在探索性数据分析和统计研究中尤为有用，能够快速了解数据的变异性并识别异常。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.BoxAndWhisker` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建箱线图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```


### **创建漏斗图**

漏斗图用于可视化包含顺序阶段的流程，数据量随步骤递减。它们特别适用于分析转化率、识别瓶颈以及跟踪销售或营销过程的效率。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.Funnel` 类型。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建漏斗图：
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```


结果：

![漏斗图](funnel_chart.png)

### **创建旭辉图**

旭辉图用于可视化层级数据，将不同层级显示为同心环。它们帮助展示部分与整体的关系，适合以紧凑的形式呈现嵌套类别和子类别。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.Sunburst` 类型。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建旭辉图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // 分支 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // 分支 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```


结果：

![旭辉图](sunburst_chart.png)

### **创建直方图**

直方图用于通过将数值数据分组到区间或箱中来表示其分布。它们对识别频率、偏斜、离散程度以及检测数据集中的异常值尤为有用。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加带有数据的图表，并指定 `ChartType.Histogram` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建直方图：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```


结果：

![直方图](histogram_chart.png)

### **创建雷达图**

雷达图用于在二维平面上显示多变量数据，便于同时比较多个变量。它们特别适合识别多项绩效指标或属性之间的模式、优势和劣势。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加带有数据的图表，并指定 `ChartType.Radar` 类型。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建雷达图：
```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```


结果：

![雷达图](radar_chart.png)

### **创建多类别图表**

多类别图表用于显示涉及多个分类分组的数据，能够在多个维度上同时比较数值。它们在分析复杂、多层次数据集的趋势和关系时特别有帮助。

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 添加默认数据的图表，并指定 `ChartType.ClusteredColumn` 类型。
1. 访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))。
1. 清除默认系列和类别。
1. 添加新系列和类别。
1. 为图表系列添加新数据。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何创建多类别图表：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // 添加一个系列。
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // 保存包含图表的演示文稿。
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


结果：

![多类别图表](multi_category_chart.png)

### **创建地图图表**

地图图表用于通过将信息映射到特定位置（如国家、州或城市）来可视化地理数据。它们在分析区域趋势、人口统计数据和空间分布时尤为直观且富有吸引力。

以下 C# 代码展示如何创建地图图表：
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


结果：

![地图图表](map_chart.png)

### **创建组合图表**

组合图表（或称为混合图表）将两种或多种图表类型合并在同一图形中。此图表可帮助突出、比较或检查多个数据集之间的差异，从而识别它们之间的关系。

![组合图表](combination_chart.png)

以下 C# 代码展示如何在 PowerPoint 演示文稿中创建上述组合图表：
```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // 设置图表标题
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // 设置图例
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // 删除默认生成的系列和类别
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 添加新类别
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // 添加第一个系列
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // 设置水平坐标轴
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // 设置垂直坐标轴
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // 设置垂直主网格线颜色
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // 设置次要水平坐标轴
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // 设置次要垂直坐标轴
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```


## **更新图表**

Aspose.Slides for .NET 使您能够通过修改图表数据、格式和样式来更新 PowerPoint 图表。此功能简化了使用动态内容保持演示文稿最新的过程，并确保图表准确反映当前数据和视觉标准。

1. 实例化表示包含图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
1. 使用索引获取幻灯片的引用。
1. 遍历所有形状以查找图表。
1. 访问图表的数据工作表。
1. 通过更改系列值来修改图表数据系列。
1. 添加新系列并填充其数据。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何更新图表：
```c#
const string chartName = "My chart";

// 实例化表示 PPTX 文件的 Presentation 类。
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // 设置图表数据表的索引。
            int worksheetIndex = 0;

            // 获取图表数据工作簿。
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // 更改图表类别名称。
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // 获取第一条图表系列。
            IChartSeries series = chart.ChartData.Series[0];

            // 更新系列数据。
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // 修改系列名称。
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // 获取第二条图表系列。
            series = chart.ChartData.Series[1];

            // 更新系列数据。
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // 修改系列名称。
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // 添加新系列。
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // 填充系列数据。
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // 保存包含图表的演示文稿。
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```


## **为图表设置数据范围**

Aspose.Slides for .NET 提供灵活性，可将工作表中的特定数据范围定义为图表数据的来源。这意味着您可以直接映射工作表的某一部分到图表，控制哪些单元格贡献于图表的系列和类别。因此，您可以轻松更新并同步图表与工作表中的最新数据更改，确保 PowerPoint 演示文稿反映当前且准确的信息。

1. 实例化表示包含图表的演示文稿的 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
1. 使用索引获取幻灯片的引用。
1. 遍历所有形状以查找图表。
1. 访问图表数据并设置范围。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下 C# 代码展示如何为图表设置数据范围：
```c#
const string chartName = "My chart";

// 实例化表示 PPTX 文件的 Presentation 类。
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```


## **在图表中使用默认标记**

使用默认标记时，每个图表系列会自动获得不同的默认标记符号。

以下 C# 代码展示如何自动设置图表系列标记：
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // 填充系列数据。
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```


## **常见问答**

**Aspose.Slides for .NET 支持哪些图表类型？**

Aspose.Slides for .NET 支持多种图表类型，包括柱形图、折线图、饼图、面积图、散点图、直方图、雷达图等。这种灵活性让您能够选择最合适的图表类型来满足数据可视化需求。

**如何向幻灯片添加新图表？**

要添加图表，首先创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，使用索引获取目标幻灯片的引用，然后调用添加图表的方法，指定图表类型和初始数据。此过程会直接将图表集成到演示文稿中。

**如何更新图表中显示的数据？**

您可以通过访问图表的数据工作簿 ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/))，清除默认系列和类别，然后添加自定义数据，从而以编程方式刷新图表以反映最新数据。

**是否可以自定义图表的外观？**

是的，Aspose.Slides for .NET 提供丰富的自定义选项。您可以修改颜色、字体、标签、图例以及其他格式元素，以满足特定的设计需求。