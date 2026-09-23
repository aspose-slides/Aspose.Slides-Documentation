---
title: 在 .NET 中管理演示文稿的图表数据标签
linktitle: 数据标签
type: docs
url: /zh/net/chart-data-label/
keywords:
- 图表
- 数据标签
- 数据精度
- 百分比
- 标签距离
- 标签位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中添加和格式化图表数据标签，以创建更具吸引力的幻灯片。"
---
## **介绍**

数据标签显示图表系列和单个数据点的信息，帮助读者识别数值并理解图表。本文说明了如何格式化数值、显示百分比、读取标签文本、调整类目轴标签间距以及定位饼图标签。

## **在图表数据标签中设置数据精度**

使用 [NumberFormatOfValues](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartseries/numberformatofvalues/) 来格式化系列值。此示例创建一个带有默认数据的折线图，显示其数据表，并为第一个系列启用数值标签。格式 `#,##0.00` 显示千位分隔符和两位小数，而不更改底层数值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **将百分比显示为标签**

对于堆积柱形图，计算每个数值占其类目总和的百分比，并将文本分配给 [TextFrameForOverriding](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)。此示例使用默认图表数据，并以两位小数、8 磅字体显示百分比。总和为零的类目会被跳过，以避免除以零。若图表数据更改，需要重新计算自定义标签文本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **在图表数据标签中设置百分号**

当数值以分数形式存储时，使用 [NumberFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabelformat/numberformat/) 来显示百分比。将 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 设置为 `false`，即可独立于源单元格应用标签格式。

此示例创建一个 100% 堆积柱形图，四个类目中分别包含红色和蓝色系列。每对数值之和为 1。标签格式 `0.0%` 将 0.30 显示为 30.0%，而纵轴使用两位小数。两个系列均使用白色、10 磅的标签文本。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **读取数据标签的实际文本**

使用 [GetActualLabelText](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 获取数据标签设置产生的文本。当需要为报告提取标签、搜索演示文稿内容或验证生成的图表时，这非常有用。下面的示例中，默认的 [data label format](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabelformat/) 将每个类目名称、系列名称和数值组合在一起。一个点将其数值格式化为百分比，另一个使用来自 [TextFrameForOverriding](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) 的自定义文本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

存储在数据点中的数值仍为 `0.75`，即使其标签显示为 `75%` 并附带类目和系列名称。自定义文本会替代生成的标签文本。无论哪种情况，[GetActualLabelText](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 都返回结果标签字符串。正如上文所示，如果只想提取可见标签，请单独检查 [IsVisible](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/idatalabel/isvisible/)。

## **设置标签与坐标轴的距离**

使用 [LabelOffset](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/iaxis/labeloffset/) 控制类目轴标签与坐标轴之间的距离。该值是轴标签最大字号的百分比。本示例创建一个簇状柱形图，并将水平轴标签偏移设置为 500。此设置影响类目轴标签，而不是附加在单个数据点上的标签。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **调整标签位置**

在饼图上，调整数据标签位置以改善间距并为指引线留出空间。

此示例显示第一个数据点的数值，将其标签放置在扇形外部，并调整其 [X](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ilayoutable/x/) 和 [Y](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ilayoutable/y/) 偏移量。这些偏移量分别相对于图表的宽度和高度。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![带有调整后数据标签位置的饼图](pie-chart-adjusted-label.png)

## **常见问题**

**如何防止密集图表上的数据标签重叠？**

结合自动标签布局、指引线以及减小字号；必要时隐藏某些字段（例如类目），或仅对极值或关键点显示标签。

**如何仅对零、负数或空值禁用标签？**

在启用标签之前过滤数据点，并根据预定义规则关闭对数值为 0、负数或缺失值的显示。

**在导出为 PDF/图像时，如何确保标签样式一致？**

显式设置字体族和字号，并确保渲染环境中提供该字体，以防止回退。