---
title: 在 .NET 中管理演示文稿的图表数据系列
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
## **概览**

图表将其绘制的数据存储在图表数据工作簿中。一个 [IChartSeries](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/) 表示一组相关值，系列中的每个 [IChartDataPoint](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/) 都对应一个或多个工作簿单元格。 [IChartCategory](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartcategory/) 对象提供系列共享的标签或分组值。因此，系列名称、类别和点值连接到 [IChartDataCell](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/) 对象，而不是仅作为显示文本存储。

对于典型的类别图表，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给 [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、行和列索引均为从零开始。这种布局在使用默认数据创建图表时很有用，但不要假设每个已有图表都采用此布局。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用范围：

- 系列级别设置，例如 [IChartSeries.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/format/)，为同一系列的所有点提供默认外观。
- 数据点级别设置，例如 [IChartDataPoint.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/format/)，覆盖该点的系列外观。
- 组设置适用于属于同一 [IChartSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/) 的兼容系列。需要设置重叠或间隙宽度等选项时，可通过 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries.Overlap](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/overlap/) 报告 2D 图表中条形或柱形的重叠程度，范围从 -100 到 100%。它是父系列组设置的只读投影。设置 [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/overlap/) 可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图表中不相关的系列组没有影响。

下面的示例为包含第一个系列的组设置重叠：

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

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用 [IChartSeries.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/format/) 为整个系列设置默认填充。如果某个点已经有显式填充，其 [IChartDataPoint.Format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/format/) 设置将覆盖该点的系列填充。

下面的示例为第一个系列应用纯蓝色填充：

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

![The color of the series](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚集柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一个系列的名称。以下示例中的命名常量明确了该结构：

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

您也可以更新已由 [IChartSeries.Name](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/name/) 引用的单元格。这种方法避免了对现有图表中特定行列的假设：

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

![The series name](series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 返回根据系列索引和图表样式计算的颜色。这是当系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色，不会分配新的填充。

下面的示例打印每个默认系列的自动颜色：

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

## **为图表系列设置负值填充颜色**

对于条形、柱形和气泡系列，[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertifnegative/) 可在负值时显示不同的填充。将常规系列填充设为实色，启用反转，并通过 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) 指定负值颜色。工作簿中的负数保持不变，仅改变其显示颜色。

下面的示例将默认图表数据替换为一个系列。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您可以通过 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定的点启用，并为该点分配负值以便效果可见：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的数值可通过 [IChartDataPoint.YValue](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/yvalue/) 获得。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除代表您想要移除的数值的单元格。不要在想保留其他点时调用 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示方式**

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。将 [IChartDataCell.Value](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/value/) 设为 `null` 可使单元格为空。数值零始终为零，不受空单元格设置影响。

使用 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/displayblanksas/) 选择图表如何显示空单元格。此设置适用于整个图表。它改变空白的绘制方式，而不会将空单元格填充为零或插值。

下面的独立示例创建一个包含一个系列的折线图，清除第 3 天的数值，并分别以每种模式保存相同的图表。无需输入文件。 [IChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/) 使用工作表 0，第 0 列存放类别标签，第 1 列存放数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// 让第3天真实为空，同时保留其类别和数据点。
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

每个输出文件在保存前存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。如果只想保存一种版本，请在保存演示文稿前分配所需模式，而不是遍历所有模式。

下面的对比显示了三个文件中相同的数据。第 3 天在工作簿中均为空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图可以直观比较三种模式。条形图和柱形图没有线可在缺失类别间连接，`Span` 因此无法生成上述连接段；缺失的柱形和零高度的柱形也可能看起来相似。同样，仅有标记的散点图没有连接线。不要指望每种图表类型都呈现三种明显不同的结果；请检查所用图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而不是单个系列。对组一次性设置 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) 即可。较大的值会在簇之间创建更多空间，较小的值则使簇更紧凑。

下面的示例更改间隙宽度并仅保存最终的演示文稿：

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

![The gap width](gap_width.png)

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/charttype/) 枚举表示的图表类型都使用图表数据，但它们的系列并不具备相同的数值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y，气泡图额外使用气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图表可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/addchart/) 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用 [IChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/) 中的单元格。更改引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整条系列？**

将相应的数值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在想删除该系列所有点时才使用 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同时删除了类别，请更新所有系列，使它们的数值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型和 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/displayblanksas/)。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来展示。请选择符合演示文稿中缺失数据含义的设置。完整示例和可视化对比请参见 “控制空单元格的显示方式”。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertifnegative/) 并设置 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您也可以通过 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 为单个点覆盖此行为。这些属性影响格式，而不改变存储的数值。

**当系列和点都设置格式时，哪个格式生效？**

显式的数据点格式对该点具有最高优先级。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，不会覆盖点级别的格式。

**图表可以包含多少系列，有没有上限？**

Aspose.Slides 并未设置单独的固定系列数量上限。实际限制取决于演示文稿文件的约束、可用内存、渲染时间以及图表的可读性。

**当柱形之间太靠近或太远时应如何调整？**

在相应的父系列组上设置 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增大该值可扩大簇之间的间距，减小则使簇更紧凑。