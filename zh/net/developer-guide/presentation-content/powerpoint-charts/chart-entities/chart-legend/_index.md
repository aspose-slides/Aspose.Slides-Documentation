---
title: 在 .NET 中自定义演示文稿的图表图例
linktitle: 图表图例
type: docs
url: /zh/net/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 自定义图表图例，以针对性的图例格式优化 PowerPoint 演示文稿。"
---
## **概述**

Aspose.Slides for .NET 提供了在 PowerPoint 演示文稿中自定义图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小、为单个图例项格式化以及隐藏或恢复选定的图例项。

常见问题解答涵盖了相关行为，包括为图例预留空间、显示多行标签以及从演示文稿主题继承格式。

## **图例定位**

使用图例的 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/)、[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/)、[Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) 和 [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) 属性，以图表尺寸的比例指定其位置和大小。

下面的示例创建一个演示文稿，并在第一张幻灯片上添加一个默认数据的簇状柱形图。将期望的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角偏移 50 点，尺寸为 100 × 100 点。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 表达图例相对于图表的位置和大小。
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **设置图例的字体大小**

使用图例的 [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) 访问其文本格式，并在点数上设置 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/)。

下面的示例创建一个默认数据的图表，并将图例文本设置为 20 点。同时禁用垂直轴的自动范围，并将其范围设为 -5 到 10。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **设置单个图例项的字体大小**

使用图例的 [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) 集合访问特定项的格式。条目索引从零开始，因此索引 `1` 指代第二个条目。

下面的示例创建一个默认数据包含至少两个系列的簇状柱形图。它将第二个图例条目格式化为粗体、斜体、20 点蓝色文本。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **隐藏单个图例项**

若要在保持数据可见的情况下从图例中排除辅助系列，请通过 [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) 将 [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) 设置为 `true`。这只会隐藏选定的图例条目，不会删除系列或其数据点。相比之下，将 [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) 设置为 `false` 会隐藏整个图例。

下面的示例创建一个使用默认数据的多系列簇状柱形图。它隐藏第二个系列的图例条目（索引 `1`），并保存演示文稿。随后将 `Hide` 设置为 `false` 恢复该条目，并保存第二个副本。两份文件中的柱形仍然可见。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// 恢复相同的条目而不更改图表数据。
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

下面的对比展示了同一图表在全部条目可见和第二条目隐藏时的效果。第二系列的柱形保持不变。

![对比图：所有图例条目均可见与第二条目隐藏的图表；所有柱形均保持可见。](hide-legend-entry.png)

在柱形图、条形图和折线图中，图例条目标识系列。对于饼图，它们标识单个数据点（切片），因此请在选定的切片上使用 [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/)。API 为 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 和 `BarOfPie` 图表类型记录了此数据点属性。不要假设它适用于环形图，因为环形图不在此列表中。

## **常见问题**

**我可以让图表为图例预留空间，而不是覆盖它吗？**

可以。将 [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) 设置为 `false`，即可为图例预留空间，防止其覆盖绘图区域。

**我可以使用多行图例标签吗？**

可以。当可用宽度不足时，长标签会自动换行。也可以在系列名称中使用换行符来强制换行。

**如何让图例遵循演示文稿主题的配色方案？**

保持图例的颜色、填充和字体未设置，让其继承主题格式。显式设置的格式会覆盖相应的主题设置。