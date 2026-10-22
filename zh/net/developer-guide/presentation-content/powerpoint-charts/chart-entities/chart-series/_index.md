---
title: .NET 演示文稿中管理图表数据系列
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
description: "了解如何在使用 C# 的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表可以将绘制的数值存储在工作簿单元格中或直接作为数值文字。一个[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/)表示一组相关值，每个[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/)表示该系列中的一个点。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)对象提供系列共享的标签或分组值。对于使用默认数据创建的图表，系列名称、类别和点值使用来自图表工作簿的[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)对象。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，剩余单元格存放系列值。传递给[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)的工作表、行和列索引为零基。此布局在创建使用默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，请在更改工作簿值之前检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)，为一个系列中的所有点提供默认外观。
- 数据点设置，例如[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)，覆盖该点的系列外观。
- 组设置适用于属于同一[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)的兼容系列。需要设置重叠或间隙宽度等选项时，通过[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式时，点的格式优先。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **使用数值文字设置系列值**

当系列值来源于应用程序数据或计算且不需要工作表单元格引用时使用数值文字。将[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/)设为[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)后，通过[AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/)为每个点的[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/)赋值。

集合设置控制该系列所有点值的来源类型。每个点的[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/)报告所选类型；通过集合设置进行更改。使用`Worksheet`时，使用[AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/)访问引用的单元格。使用`DoubleLiterals`时，使用`AsLiteralDouble`直接读取或写入数字。

下面的示例创建一个具有默认系列和类别的柱形图，然后为其第一系列的现有点分配计算得到的 10、20 等值。它保存演示文稿，重新打开并打印存储的值。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

点值来源类型独立于[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/)，后者标识图表的内部或外部工作簿配置。使用数值文字本身并不会移除嵌入的工作簿。在本示例中，工作簿仍用于类别标签、系列名称和其他系列。有关工作簿管理，请参阅[Chart Workbook](/slides/zh/net/chart-workbook/)。

对于散点图和气泡图，设置[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/)和[DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/)以选择[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/)和[YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)的来源。气泡图还使用[DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/)来提供[BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/)。在通过该值的`AsLiteralDouble`属性赋值之前，将每个适用的来源设置为`DoubleLiterals`。

## **设置图表系列重叠**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/)报告二维图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是父系列组设置的只读投影。通过设置[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一系列的组设置重叠：

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

使用[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)为整个系列设置默认填充。如果点已经具有显式填充，其[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)设置将覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝色填充：

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

系列名称存储在图表数据工作簿中，通常显示在图例中。对于默认创建的聚类柱形图，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以直接更新[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)已引用的单元格。此方法避免在已有图表中假设特定的行列位置：

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

### **从多个单元格创建带名称的系列**

当产品名称和报告期间分别存储在不同工作簿单元格中时，复合系列名称很有用。例如，可以将 B1 中的`Product A`和 C1 中的`2026`组合成一个系列名称，同时保持两部分与其源单元格的链接。

使用[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)检索名称范围，然后将该集合传递给[IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)。`skipHiddenCells`参数控制是否排除隐藏单元格：`true`排除，`false`包含。本例使用`false`来包含名称范围内的所有单元格。

下面的示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

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

// Separate cells supply the categories and numeric data points.
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

生成的系列名称为`Product A 2026`，两个单元格值之间有一个空格。图例中将其显示为一个条目。下图为从保存的演示文稿渲染的图像：

![带复合系列名称的柱形图（North 和 South 值）](composite_series_name.png)

## **获取自动系列填充颜色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用此方法只读取计算出的颜色，不会分配新填充。

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

具体颜色取决于图表样式和主题。

## **为图表系列设置负值填充颜色**

对于条形、柱形和气泡系列， [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) 可在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)指定负值颜色。负数在工作簿中保持不变，仅其显示颜色会改变。

下面的示例用一个系列替换默认图表数据。工作表第 0 行存放系列名称，第 0 列存放类别名称，第 1 列存放值：

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

![反转的实色填充颜色](inverted_solid_fill_color.png)

您可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个点启用反转。下例中，系列禁用反转，仅为选定点启用，并为该点分配负值以显示效果：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为`null`。对于柱形图，绘制的数值可通过[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)获取。数据点仍保持在相同的类别位置，但图表会根据空值设置将其视为空白。

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

散点图使用独立的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示要删除的值的单元格。不要在想保留其他点时调用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示**

包含值的隐藏单元格与空单元格是不同的情况。要包含或排除隐藏工作表行列中的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含`0`的单元格表示已知数值。将[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)设为`null`即可使单元格为空。数值零始终保持为零，无论空单元格设置如何。

使用[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)选择图表如何显示空单元格。此设置适用于整个图表，改变空白的绘制方式，而不会将空工作簿单元格填充为零或插值。

下面的完整示例创建一个包含一个系列的折线图，清除第 3 天的值，并分别使用每种模式保存相同的图表。无需输入文件。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)使用工作表 0，第 0 列作为类别标签，第 1 列作为数值；第 0 行保存系列名称。最终数据为`10, 20, empty, 30, 40`。

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

// 将第 3 天真正设为空，同时保留其类别和数据点。
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

每个输出文件在保存前存储的模式分别为 `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只需一种版本，可在保存演示文稿前分配所需模式，避免遍历所有模式。

下面的对比显示了三文件中的相同数据。第 3 天在工作簿中始终为空：

![折线图的空白显示比较：Gap 在第 3 天断开线段，Zero 将线段降到零，Span 将第 2 天连接到第 4 天。](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较三种模式。条形和柱形图没有线段可跨越缺失的类别，因此`Span`无法产生上述连接段；缺失的柱形和零高度的柱形看起来也很相似。类似地，仅使用标记的散点图没有连接线。不要期望每种图表类型都有三种明显不同的结果；请检查所用图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对组一次性设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。更大的值会在簇之间产生更大的间距，较小的值则使它们更紧凑。

下面的示例修改间隙宽度并仅保存最终演示文稿：

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

## **FAQ**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)枚举表示的图表类型都会使用图表数据，但它们的系列并不全部拥有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)包含共享组级绘制设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表会包含默认数据吗？**

会。默认情况下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有重载可以创建不含默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点在预期的类别下绘制。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为`null`，即可保留点的类别位置但使其为空点。仅在需要删除该系列全部点时才使用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同时删除了类别，请更新所有系列，使它们的值仍然与类别集合保持对齐。

**空点如何显示？**

显示方式取决于图表类型和[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来填补。请选择符合演示文稿中缺失数据含义的设置。完整示例及视觉对比请参见[Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)并设置[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您也可以通过[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)为单个点覆盖此行为。这些属性影响显示格式，而非存储的数值。

**当系列和点都被格式化时，哪一个生效？**

显式的数据点格式优先于该点。其他点继续使用显式的系列格式，若系列未定义，则使用自动的图表样式和主题。组属性如重叠和间隙宽度控制布局，不会被点级别的格式覆盖。

**图表的系列数量是否有限制？**

Aspose.Slides 并未设定固定的系列数量上限。实际可容纳的系列数受演示文稿文件限制、可用内存、渲染时间以及图表可读性等因素影响。

**当柱形之间太靠近或太分散时该怎么办？**

对相应的父系列组设置[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增大数值可扩大簇之间的间距，减小则使簇更紧凑。