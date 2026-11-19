---
title: 在 .NET 中管理演示文稿中的图表数据系列
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

图表可以将绘制的数值存储在工作簿单元格中或直接作为数字字面量。**[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/)** 表示一组相关值，而每个 **[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/)** 表示该系列中的一个点。**[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)** 对象提供系列共享的标签或分组值。对于使用默认数据创建的图表，系列名称、类别和点值使用来自图表工作簿的 **[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)** 对象。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给 **[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)** 的工作表、行和列索引为零基。此布局在创建带有默认数据的图表时很有用，但不要假设每个已有的图表都采用此布局。对于已加载的演示文稿，在更改工作簿数值之前，请检查系列、类别和数据点引用的单元格。

图表设置具有三种不同的范围：

- 系列级别的设置，例如 **[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)**，为一个系列中的所有点提供默认外观。
- 数据点级别的设置，例如 **[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)**，覆盖该点的系列外观。
- 组设置适用于属于同一 **[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)** 的兼容系列。当需要设置重叠或间隙宽度等选项时，通过 **[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)** 访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式都存在时，点的格式优先于该点。

![图表系列 PowerPoint](chart-series-powerpoint.png)

对于聚集的柱形立体图，请参阅 **[更改 3D 系列类型或条形形状](/slides/zh/net/3d-chart/#change-the-3d-series-type-and-bar-shape)** 如何影响第一个系列。

## **使用数字字面量设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，请使用数字字面量。在为每个点的 **[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/)** 赋值之前，将 **[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/)** 设置为 **[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)**，并通过 **[AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/)** 进行赋值。

集合设置控制该系列中所有点值的源类型。每个点的 **[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/)** 报告所选类型；通过集合设置进行更改。使用 `Worksheet` 时，使用 **[AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/)** 访问引用的单元格。使用 `DoubleLiterals` 时，使用 `AsLiteralDouble` 直接读取或写入数字。

下面的示例创建一个默认系列和类别的柱形图，然后为其第一个系列的现有点分配计算得到的 10、20 等值。示例保存演示文稿、重新打开并打印存储的值。

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

点值的来源类型与 **[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/)** 分开，后者标识图表的内部或外部工作簿配置。使用数字字面量本身并不会删除嵌入的工作簿。在本例中，工作簿仍用于类别标签、系列名称以及其他系列。有关工作簿管理，请参阅 **[图表工作簿](/slides/zh/net/chart-workbook/)**。

对于散点图和气泡图，设置 **[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/)** 和 **[DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/)** 以选择 **[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/)** 和 **[YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)** 的来源。气泡图还使用 **[DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/)** 来获取 **[BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/)**。在通过该值的 `AsLiteralDouble` 属性赋值之前，请将每个适用的来源设置为 `DoubleLiterals`。

## **设置图表系列重叠**

**[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/)** 报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100 百分比。它是父系列组上设置的只读投影。将 **[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)** 设置为可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；在组合图中不影响不相关的系列组。

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

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用 **[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)** 为整个系列设置默认填充。如果某个点已经具有显式填充，其 **[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)** 设置将覆盖该点的系列填充。

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚集柱形图创建的默认工作簿中，单元格 B1（第 0 行第 1 列）包含第一个系列的名称。以下示例中的命名常量明确了该结构：

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

您也可以直接更新 **[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)** 已引用的单元格。此方法避免了对现有图表中特定行列的假设：

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

### **使用多个单元格创建带名称的系列**

当产品名称和报告期间存放在不同工作簿单元格中时，组合系列名称非常有用。例如，您可以将 B1 中的 `Product A` 与 C1 中的 `2026` 合并为一个系列名称，同时保持两部分均链接到源单元格。

使用 **[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)** 检索名称范围，然后将该集合传递给 **[IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)**。`skipHiddenCells` 参数控制是否包含隐藏单元格：`true` 排除，`false` 包含。下面的示例使用 `false` 包含名称范围内的所有单元格。

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

生成的系列名称为 `Product A 2026`，两个单元格值之间有一个空格。图例将其显示为一个条目。下图为保存后的演示文稿渲染结果：

![带有北部和南部值以及组合系列名称 Product A 2026 的柱形图](composite_series_name.png)

## **获取自动系列填充颜色**

**[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)** 返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法只读取计算出的颜色，不会分配新填充。

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

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，**[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)** 可在负值时显示不同的填充。将常规系列填充设置为实色，启用反转，并通过 **[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)** 分配负值颜色。负数在工作簿中保持不变，仅改变显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

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

![反转实色填充颜色](inverted_solid_fill_color.png)

您可以通过 **[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)** 为单个点启用反转。以下示例在系列上禁用反转，仅为选定点启用，并为该点分配负值以便可见：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `null`。对于柱形图，绘制的值可通过 **[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)** 获得。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一个系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除您想删除的值对应的单元格。不要在只想保留其他点时调用 **[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)**，因为该方法会删除集合中的所有数据点。

## **控制空单元格的显示方式**

包含值的隐藏单元格与空单元格是不同的情况。要在隐藏的工作表行列中包含或排除数据，请参阅 **[从隐藏行列中包含数据](/slides/zh/net/chart-workbook/#include-data-from-hidden-rows-and-columns)**。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。将 **[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)** 设为 `null` 可使单元格为空。数值零始终保持为零，无论空单元格设置如何。

使用 **[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)** 选择图表如何显示空单元格。此设置适用于整个图表。它仅改变空白的绘制方式，不会用零或插值填充空工作簿单元格。

下面的独立示例创建一个包含一个系列的折线图，清除第 3 天的值，并使用每种模式分别保存同一图表。无需输入文件。**[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)** 使用工作表 0，第 0 列作为类别标签，第 1 列作为数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

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

每个输出文件在保存前存储对应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 与 `empty_cells_Span.pptx`。如只需一个版本，请在保存演示文稿前设置所需模式并仅保存一次，而不是遍历所有模式。

下表比较了三个文件中相同数据的显示效果。第 3 天在工作簿中始终为空：

![折线图显示比较：Gap 在第 3 天断开线段，Zero 将线段降至零，Span 将第 2 天与第 4 天连接。](display_blanks_as.png)

可见效果取决于图表类型。折线图可以清晰比较所有三种模式。条形和柱形图没有用于跨缺失类别的连线，因此 `Span` 无法产生上图所示的连接段；缺失的柱形和零高度的柱形看起来也相似。类似地，仅有标记的散点图也没有连线。不要期望每种图表类型都有三种明显不同的结果，请检查您使用的图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。一次性为组设置 **[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)**。数值越大，簇之间的空间越宽；数值越小，簇越密集。

下面的示例更改间隙宽度并仅保存最终演示文稿：

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

## **显示或隐藏系列线**

系列线在图表中可视化地连接相关部分。使用 **[IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/)** 在受支持的堆积条形图和 Pie of Pie 图中显示或隐藏它们。在二维堆积条形图和柱形图中，它们连接跨类别的对应堆叠边界。在 Pie of Pie 和 Bar of Pie 图中，它们连接主绘图与次绘图。此设置并非用于其他图表类型的通用连接器。

通过 **[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)** 访问该组。该设置适用于组中的每个系列。**[IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/)** 为只读属性，反映父组的设置；更改组属性即可更新。

下面的示例创建一个带默认数据的 **[PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)** 图表。它分别保存开启和关闭系列线的两个图表，以便比较。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| 启用系列线 | 禁用系列线 |
| --- | --- |
| ![启用系列线的 Pie of Pie 图表](series_lines_enabled.png) | ![禁用系列线的 Pie of Pie 图表](series_lines_disabled.png) |
| 两条线将主饼图连接到次饼图。 | 两个饼图均可见，但连接线被隐藏。 |

系列线不同于数据标签引线（将标签连接到数据点）、网格线（在坐标轴上标记间隔）以及折线图中的折线（表示数据值）。此设置不控制这些元素。

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由 **[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)** 枚举表示的图表类型都使用图表数据，但其系列并不全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图还加入气泡大小。使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

**[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)** 包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过一个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，**[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/)** 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有重载方法可以在不使用默认数据的情况下创建图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用 **[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)** 中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何仅清除一个点而不是整个系列？**

将相关值单元格设为 `null`，即可保留该点在类别位置上的空点。仅在希望删除该系列所有点时才使用 **[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)**，因为该方法会删除该系列的所有数据点。

**空点如何显示？**

结果取决于图表类型和 **[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)** 的设置。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来填补。选择与演示文稿中缺失数据意义相符的设置。请参阅 **[控制空单元格的显示方式](#control-the-display-of-empty-cells)** 获取完整示例和可视化比较。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用 **[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)** 并设置 **[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)**。您可以通过 **[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)** 为单个点覆盖此行为。这些属性影响格式，而非存储的数值。

**当系列和点都被格式化时，哪种格式优先？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，或在系列格式未定义时使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，不会覆盖点级别的格式。

**图表可以包含的系列数量是否有限制？**

Aspose.Slides 本身未设置固定的系列数量上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了实际可用的上限。

**当列之间间距太近或太远时该如何调整？**

在相应的父系列组上设置 **[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)**。增大该值可扩大簇之间的空间，减小则使簇更紧凑。