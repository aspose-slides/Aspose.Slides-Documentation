---
title: 在 .NET 中自定义演示文稿的饼图
linktitle: 饼图
type: docs
url: /zh/net/pie-chart/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中创建并自定义饼图。配置次要绘图，显示数据标签，并在 PowerPoint 中应用自动切片颜色。"
---
## **概述**

本文介绍了如何在 Aspose.Slides 中使用饼图。它展示了如何为 Pie of Pie 和 Bar of Pie 图表配置次要绘图选项，以及如何为标准饼图启用自动切片着色。

示例侧重于图表自定义任务，例如向幻灯片添加图表、调整系列和标签设置、用自定义类别和值替换默认图表数据，并保存更新后的演示文稿。

## **Pie of Pie 和 Bar of Pie 图表的次要绘图选项**

Aspose.Slides for .NET 支持 Pie of Pie 和 Bar of Pie 图表的次要绘图选项。这些选项控制次要绘图的大小以及数据点在两个绘图之间的划分方式。

以下示例在新演示文稿中创建一个 Pie of Pie 图表并将数据点值显示为标签。[SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) 属性将次要绘图的大小设置为主绘图的 149%。[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) 选择基于百分比的划分，且 [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) 将阈值设为 53%。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// 显示数值并配置次要绘图。
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **为次要绘图选择类别**

当您希望在次要绘图中对特定类别进行分组且不考虑其百分比值时，可使用自定义划分。例如，销售报告可能将 Online 和 Events 放在一起，以便读者比较这两个渠道，尽管它们分别占总销售额的 35% 和 10%。

将 [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) 设置为 [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) 并通过 [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) 选择点。集合的 [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) 方法接受系列中的零基索引或数据点对象。在本例中，索引 1 选择 Online，索引 3 处的点选择 Events。Partners 也被临时添加，然后使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) 将其排除。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// 替换默认数据为渠道销售。
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// 通过其零基索引选择 Online，并通过其数据点对象选择 Events。
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// 从选择中排除 Partners，但不删除其源数据。
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) 和 Events (10) 在次要绘图中显示为独立的切片。在主绘图中，它们以一个合并切片的形式出现，值为 45，另外还有 Retail (40) 和 Partners (15)。从自定义选择中移除 Partners 会使其仍保留在主绘图中；它不会从图表的源数据中删除该类别或其值。

以下图片显示了在 PowerPoint 中保存的演示文稿：

![Pie of Pie 图表，在次要绘图中显示 Online 和 Events，在主绘图中其合并值为 45](pie_of_pie_custom.png)

## **设置自动饼图切片颜色**

Aspose.Slides for .NET 可以自动为饼图切片分配不同的颜色。以下示例创建一个带居中标题的饼图，并用三个季度类别及其数值替换默认数据。[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 属性将数值 20、50 和 30 显示为标签，而 [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) 则为每个切片启用不同的颜色。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// 添加居中的图表标题。
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 使用第一个工作表替换默认数据。
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// 显示数值并为切片分配不同的颜色。
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **常见问题**

**是否支持 Pie of Pie 和 Bar of Pie 变体？**

是的，库[支持](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)饼图的次要绘图，包括 Pie of Pie 和 Bar of Pie 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以[将图表本身导出为图像](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)（例如 PNG），而无需导出整个演示文稿。