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
description: "了解如何使用 C# 在演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/)表示一组相关值，而系列中的每个[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/)引用一个或多个工作簿单元格。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和数据点值连接到[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列值。传递给[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)的工作表、行和列索引均为零基。这种布局在创建默认数据的图表时很有用，但不要假设所有现有图表都使用它。对于已加载的演示文稿，请在更改工作簿值之前检查系列、类别和数据点所引用的单元格。

图表设置有三种不同的作用范围：

- 系列级设置，例如[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)，为同一系列的所有数据点提供默认外观。
- 数据点级设置，例如[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)，覆盖单个数据点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)访问该组。

当未显式设置数据点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和数据点格式时，数据点格式对该点具有优先权。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/)报告 2D 图表中条形或柱形的重叠程度，取值范围为 -100% 到 100%。它是对父系列组设置的只读投影。设置[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)即可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组不产生影响。

以下示例为包含第一个系列的组设置重叠：

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

使用[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)为整个系列设置默认填充。如果某个数据点已经拥有显式填充，其[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)设置将覆盖该点的系列填充。

以下示例为第一个系列应用实心蓝色填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一个系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以更新[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)已引用的单元格。这种做法避免了对已有图表中特定行列的假设：

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

### **从多个单元格创建具有名称的系列**

当产品名称和报告时期分别存储在不同工作簿单元格时，复合系列名称会很有用。例如，您可以将 B1 中的 `Product A` 与 C1 中的 `2026` 组合成单个系列名称，同时保持两部分与其源单元格的链接。

使用[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)检索名称范围，然后将该集合传递给[IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)。`skipHiddenCells` 参数控制是否包含隐藏单元格：`true` 排除，`false` 包含。此示例使用 `false` 包含名称范围内的所有单元格。

以下示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// 这两个单元格提供系列名称。
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// 分离的单元格提供类别和数值数据点。
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

生成的系列名称为 `Product A 2026`，两个单元格值之间带有空格。图例将其显示为两列的单一条目。下图为已保存演示文稿的渲染结果：

![柱形图（包含北部和南部值），图例中显示复合系列名称 Product A 2026](composite_series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色；并不会分配新的填充。

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

## **为图表系列设置负值填充颜色翻转**

对于条形、柱形和气泡系列，您可以使用[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)在负值时显示不同的填充。将常规系列填充设为实心，启用翻转，并通过[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)指定负值颜色。工作簿中的负数本身保持不变，仅其显示颜色会改变。

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

![翻转的实心填充颜色](inverted_solid_fill_color.png)

您也可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个数据点启用翻转。下面示例在系列整体关闭翻转的情况下，仅为选中的点启用翻转，并为该点分配负值以便可见：

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

要使某一点为空而不删除其他点，请将其后台工作簿单元格设为 `null`。对于柱形图，绘制的数值可通过[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)获取。数据点仍然保持在相同的类别位置，但图表会根据其空值设置将该值视为空白。

以下示例仅清除第一个系列的第二个点：

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

散点图使用独立的 X 与 Y 单元格，气泡图还使用大小单元格。只清除您想删除的值对应的单元格。不要在想保留其他点时调用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示**

隐藏的、包含数值的单元格属于与空单元格不同的情况。若需包含或排除隐藏工作表行列中的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。将[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)设为 `null` 可使单元格为空。数值零始终保持为零，无论空单元格设置为何。

使用[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)选择图表如何显示空单元格。此设置适用于整个图表，会改变空白的绘制方式，而不会将空工作簿单元格填充为零或插值。

以下自包含示例创建一个包含一个系列的折线图，清除第 3 天的数值，并分别以每种模式保存同一图表。无需输入文件。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)使用工作表 0，第 0 列存放类别标签，第 1 列存放数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

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

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

每个输出文件在保存前记录相应模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只需一种版本，可在保存演示文稿前设定所需模式并一次保存，而不是遍历所有模式。

下图比较了三个文件中相同数据的显示效果。第 3 天在工作簿中始终为空：

![折线图（相同数据）：Gap 在第3天断开线条，Zero 将线条降至零，Span 将第2天连接到第4天](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较所有三种模式。条形图和柱形图没有连线可跨越缺失的类别，因此 `Span` 无法产生如上所示的连接段；缺失的柱形和零高度柱形在视觉上也可能相似。同理，仅有标记的散点图也没有连线。不要指望每种图表类型都能得到三种截然不同的结果；请针对所使用的图表类型检查输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。和重叠一样，它属于父系列组而非单个系列。对组一次性设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)即可。较大的值会在簇之间创建更多空间，较小的值则使簇更密集。

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

**哪个图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并不具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型相匹配的数据点创建方法。诸如重叠和间隙宽度的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点均绘制在预期的类别下。

**如何仅清除一个点而不是整个系列？**

将相关值单元格设为 `null`，即可保留该点的类别位置作为空点。仅在您打算删除该系列所有点时才使用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同时删除类别，请更新所有系列，使它们的数值仍然与类别集合保持对齐。

**空点如何显示？**

显示效果取决于图表类型以及[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来补齐。请选择与演示文稿中缺失数据含义相匹配的设置。有关完整示例和可视化比较，请参阅[控制空单元格的显示](#控制空单元格的显示)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)并设置[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个数据点覆盖此行为。这些属性影响外观格式，而不改变存储的数值。

**当系列和数据点同时设置格式时，哪一个优先？**

显式的数据点格式对该点具有优先权。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，不会覆盖点级格式。

**图表能够包含的系列数量是否有限制？**

Aspose.Slides 并未设定单独的固定系列计数上限。实际使用中，演示文稿文件限制、可用内存、渲染时间以及图表可读性决定了实际可接受的上限。

**当柱形之间过于靠近或过于分散时，该怎么做？**

在相应的父系列组上设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增加该值可扩大簇之间的间距，减小则使簇更靠近。