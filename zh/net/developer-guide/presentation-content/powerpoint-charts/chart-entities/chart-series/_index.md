---
title: 在 .NET 演示文稿中管理图表数据系列
linktitle: 数据系列
type: docs
url: /zh/net/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在演示文稿中使用 C# 管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[IChartSeries](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/)表示一组相关值，系列中的每个[IChartDataPoint](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/)引用一个或多个工作簿单元格。[IChartCategory](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和数据点值连接到[IChartDataCell](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/)对象，而不仅仅作为显示文本存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/getcell/)的工作表、行和列索引均从零开始。此布局在创建带有默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，请在更改工作簿值之前检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级设置，例如[IChartSeries.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/format/)，为一个系列中的所有点提供默认外观。
- 数据点级设置，例如[IChartDataPoint.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/format/)，会覆盖该点的系列外观。
- 组级设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/parentseriesgroup/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式均存在时，点的格式优先于该点的系列格式。

![图表系列PowerPoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries.Overlap](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/overlap/)报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100 百分比。它是对父系列组设置的只读投影。设置[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/overlap/)即可更新该组中所有兼容的系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

以下示例为包含第一系列的组设置重叠：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新图表包含示例系列、类别和数值。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[IChartSeries.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/format/)为整个系列设置默认填充。如果某个点已经有显式填充，其[IChartDataPoint.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/format/)设置会覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色填充：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

结果：

![系列的颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名常量明确了该结构：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

您也可以直接更新[IChartSeries.Name](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/name/)已引用的单元格。此方法避免了对现有图表特定行列的假设：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算出的颜色。这是系列填充未显式定义时使用的颜色。调用该方法会读取计算得到的颜色；不会为系列分配新填充。

以下示例打印每个默认系列的自动颜色：

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

默认图表样式的示例输出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

确切颜色取决于图表样式和主题。

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertifnegative/)可以在负值时使用不同的填充。将常规系列填充设为实心，启用反转，并通过[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)指定负值颜色。负数在工作簿中保持不变，仅其显示颜色会改变。

以下示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

结果：

![反转的实心填充颜色](inverted_solid_fill_color.png)

您也可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定点启用，并为该点赋予负值，以便看到效果：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **清除特定数据点的值**

要使某一点为空而不移除其他点，请将其背后的工作簿单元格设为 `null`。对于柱形图，绘制的值可通过[IChartDataPoint.YValue](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/yvalue/)获取。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一系列的第二个点：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

散点图使用单独的 X 与 Y 单元格，气泡图还使用大小单元格。仅清除代表您想移除的值的单元格。不要在希望保留其他点时调用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而不是单个系列。对组一次性设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)即可。较大的值会在簇之间产生更多空间，较小的值会使簇更紧密。

以下示例更改间隙宽度并仅保存最终的演示文稿：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

结果：

![间隙宽度](gap_width.png)

## **常见问题**

**哪种图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并非全部拥有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图还添加气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过一个系列访问的组设置不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addchart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前先清除系列和类别集合。还有一个重载可以创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[IChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请确保类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在希望删除该系列所有点时才使用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同时删除了类别，请更新所有系列，使它们的数值仍与类别集合对齐。

**空点如何显示？**

显示结果取决于图表类型和[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/displayblanksas/)。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来显示。请选择与您演示文稿中缺失数据意义相符的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertifnegative/)并设置[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您也可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个点覆盖此行为。这些属性影响显示格式，而不是存储的数值。

**当系列和点都被格式化时，哪种格式优先？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，或者在未定义系列格式时使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，且不属于点级别的格式覆盖。

**图表能包含的系列数量是否有限制？**

Aspose.Slides 并未对系列数量设置固定上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了实际可接受的上限。

**当柱形之间太近或太远时应如何调整？**

在相应的父系列组上设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增大该值可扩大簇之间的间距，减小则使簇更靠近。