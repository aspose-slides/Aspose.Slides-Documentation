---
title: 在 .NET 中格式化演示文稿图表
linktitle: 图表格式化
type: docs
weight: 60
url: /zh/net/chart-formatting/
keywords:
- 格式化图表
- 图表格式化
- 图表实体
- 图表属性
- 图表设置
- 图表选项
- 字体属性
- 圆角边框
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "学习 Aspose.Slides for .NET 中的图表格式化，通过自定义坐标轴、字体、数字格式和圆角图表边框，提升您的 PowerPoint 演示文稿。"
---
## **概述**

本文说明如何使用 Aspose.Slides 在 PowerPoint 演示文稿中格式化图表。它展示了如何自定义关键图表元素，例如坐标轴、网格线、标题、图例、绘图区和墙面填充，以改善图表数据的外观和可读性。

它还演示了如何为图表文本设置字体属性、对图表数据应用预设数值格式，以及为图表区域启用圆角。这些示例共同展示了如何控制演示文稿中图表的视觉样式和数据呈现。

## **格式化图表实体**

使用[IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/)来格式化图表标题、坐标轴、网格线、图例和绘图区。此示例创建一个带有标记和默认数据的折线图，然后对其数值轴和类别轴分别应用文本和线条样式。字体大小和线宽以磅为单位指定；类别标签旋转45度。

数值轴使用[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/)，独立于源单元格。其刻度范围为 -2 到 15，主刻度间隔为 2，次刻度间隔为 0.5。示例还将百分比格式与设置为千位的[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/)相结合，请根据数据的含义和规模调整这些设置。由于[Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/)被禁用，图例位于绘图区之外。背墙和地板填充通过[BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/)和[Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)进行配置，但这些表面仅在3D图表中可见。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **设置图表的字体属性**

通过[Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/)为图表文本设置默认字体大小。示例创建一个聚簇柱形图，使用 20 磅字体，并通过[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)为第一系列启用数值标签。具有自己显式字体设置的文本元素可覆盖图表默认设置。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **设置数值格式**

使用[IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/)将内置数值格式应用于图表工作簿单元格。此示例创建一个默认单元格数据的聚簇柱形图，并对每个系列的数值单元格应用索引为 10（`0.00%`）的格式。这会更改工作簿中数值的显示方式，而不更改其底层数值；例如，0.25 将显示为 25.00%。坐标轴和数据标签格式可以分别配置。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

下表列出了内置数值格式索引及其对应的英文（美国）地区的 Excel 示例格式。确切的格式字符串及其显示可能因应用程序和地区而异，尤其是货币和日期。一些 Excel 格式也与 OOXML 标准的默认值不同，详见[Microsoft 的数字格式实现说明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)。

| 索引 | 格式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **设置图表区域圆角边框**

启用[IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/)可为图表区域的角进行圆角处理。示例创建一个聚簇柱形图，并使用[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/)在保存演示文稿前为其轮廓设置实心灰色和单线样式。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **编辑现有图表批注**

图表可以包含自定义形状，例如说明报告状态的文本批注。可通过[IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/)访问这些形状，该属性也在图表 API 参考中的[Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/)下列出。其[Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)集合包含图表拥有的形状。

放置在图表上方的普通文本框属于幻灯片，即使它看起来像图表的一部分。遍历[Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)可以找到图表及普通幻灯片形状，但不会枚举图表内部的各个形状。图表标题和数据标签是独立的图表元素，而非此集合中的自定义批注。

下载[chart-annotations.pptx](chart-annotations.pptx)并放置在应用程序的工作目录中。其第一页包含一个图表，该图表带有未分组的批注“Preliminary results”、图表拥有的线条，以及普通幻灯片文本框“Slide overlay”。示例在该幻灯片上查找第一个图表，并在报告准备发布时将批注更改为“Final results”。它会检查集合是否为空，仅编辑具有非空[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/)且文本符合预期的[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

线条和幻灯片文本框保持不变。以下图像显示了输入以及保存后重新打开的结果：

| 编辑前 | 编辑后 |
| --- | --- |
| ![图表批注显示 Preliminary results](chart-annotations-before.png) | ![图表批注显示 Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
示例仅检查最高层级的图表拥有的形状。如果批注位于[IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)内部，请同样检查该组的[Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/)集合。对嵌套组递归重复此操作，对其子形状应用相同的文本检查。组本身是一个容器；不要将其视为文本框。
{{% /alert %}}

## **常见问题**

**我可以为柱形/区域设置半透明填充，同时保持边框不透明吗？**

可以。填充透明度和轮廓是分别配置的。这对于提升密集可视化中网格和数据的可读性非常有用。

**当数据标签重叠时，我该如何处理？**

降低字体大小，禁用非必要的标签组件（例如类别），调整标签位置，如有必要仅为选定的数据点显示标签，或将格式切换为“数值 + 图例”。

**我可以对系列应用渐变或图案填充吗？**

可以。系列支持实色、渐变和图案填充。实际使用时应适量使用渐变，并避免使用会降低网格和文本对比度的组合。