---
title: 在 .NET 中自定义演示文稿的图表轴
linktitle: 图表轴
type: docs
url: /zh/net/chart-axis/
keywords:
- 图表轴
- 垂直轴
- 水平轴
- 自定义轴
- 操作轴
- 管理轴
- 轴属性
- 最大值
- 最小值
- 轴线
- 日期格式
- 轴标题
- 轴位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中自定义图表轴，以用于报告和可视化。"
---
## **概述**

本文说明如何使用 Aspose.Slides for .NET 自定义图表轴。内容包括计算轴值、切换图表行列、轴可见性、类目标签和刻度间隔、日期类目及格式、标题旋转、轴定位以及显示单位。

## **获取图表垂直轴的最大值**

创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 并添加一个带默认数据的面积图。读取计算轴值之前调用 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) 以确保图表布局是最新的。

读取轴限制的 [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) 和 [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)，以及刻度间隔的 [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) 和 [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) 和 [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) 提供时间单位的比例，这在日期轴中相关。示例将这些值存储在局部变量中并保存图表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **在轴之间交换数据**

使用 [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) 交换图表数据中系列和类目的角色。每个原来的类目变为系列，每个原来的系列变为类目。这会改变数据的分组方式，但不会交换水平和垂直轴。示例使用 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) 将默认数据绑定到 `Sheet1!A1:D5`（包括标题行和类目列），然后切换行列。它保存了一个具有四个系列和三个类目的图表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **禁用折线图的垂直轴**

将垂直轴的 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 设置为 `false` 以隐藏它。示例创建一个带默认数据的折线图并在垂直轴隐藏的情况下保存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **禁用折线图的水平轴**

将水平轴的 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 设置为 `false` 以隐藏它。示例创建一个带默认数据的折线图并在水平轴隐藏的情况下保存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **更改类目轴**

将 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 设置为选择日期或文本类目轴。此示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一形状是图表，类目单元格包含数值型 Excel 日期。它将水平轴更改为日期轴。将 [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) 设置为 `false`，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) 设置为 `1`，并将 [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) 设置为月份，可使主刻度每月一次。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **控制类目轴标签间隔**

当图表拥有大量类目时，可在不删除类目或数据点的前提下减少可见轴标签的数量。将 [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) 设置为 `false`，随后将 [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) 设置为所需的类目间隔。对于按正常顺序排列的文本类目，计数从第一个类目开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` 的间隔会显示每第三个标签，显示的标签之间会隐藏两个标签。它不会删除对应的列。自动间隔会根据可用空间选择间隔；不一定会显示每个标签。

刻度线拥有独立的控制。将 [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) 设置为 `false` 并使用 [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) 来设定其间隔。例如，`1` 可在每个类目间隔处保留刻度线，而标签仅每三个类目显示一次。将 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) 设置为可见样式以便观察结果。将任一自动间隔属性重新设为 `true` 可让图表再次自动选择间隔。

以下自包含示例创建 24 个类目和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间隔、手动标签间隔且刻度线独立，以及恢复自动间隔。两份副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// 幻灯片 2：显示每三个标签，但为每个类目保留刻度标记。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 幻灯片 3：让图表重新自动选择标签和刻度间隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自动间距（幻灯片 1）：** 在此渲染中，每第二个类目标签会显示并换行至两行。自动结果可能会随图表大小、字体和渲染器而变化。

![自动类目标签间距，显示全部 24 列](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每第三个标签显示在一行上，而刻度线仍保持在每个类目间隔。所有 24 列（包括未标记的列）仍可见且值保持不变。幻灯片 3 恢复了上图的自动外观。

![手动类目标签间隔为三，显示全部 24 列](category-axis-manual.png)

### **选择正确的轴和间隔**

对于文本类目轴（如柱形图、折线图、面积图或条形图的类目轴）使用此类目计数间隔。在柱形图中，它是水平轴；在水平条形图中，类目轴是垂直的，因此请将这些设置应用于 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度间隔同样适用于具有系列轴的图表。

不要使用类目标签间隔来设置数值轴的数字刻度。在数值轴上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) 指定数值差异，例如 `10` 的主单位会在 0、10、20 等位置生成刻度，当轴从零开始时。类目标签间隔 `3` 则是按类目位置计数， 与其数据值无关。散点图和气泡图使用数值轴而非文本类目轴。对于日期轴，请使用在 [更改类目轴](#change-a-category-axis) 中描述的基于时间的主单位和比例。

## **设置类目轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中。将 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 设置为日期轴，禁用 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，并将 `yyyy` 赋给 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，使类目标签显示四位年份且不受单元格格式影响。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **为图表轴标题设置旋转角度**

在垂直轴上启用 [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供标题文本，并将 [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) 设置为旋转标题。角度以度为单位；本示例将柱形图的数值轴标题旋转 90 度后保存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **在类目轴或数值轴上设置轴位置**

使用 [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) 控制数值轴是跨越类目轴之间还是在类目刻度线处交叉。此属性适用于类目轴。示例在柱形图的水平类目轴上将其设为 `true` 并保存结果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **在图表数值轴上设置显示单位**

将 [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) 设置为在不更改底层数据的情况下缩放数值轴标签。将 [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) 设为 `Millions`，则 60,000,000 会显示为 60。示例创建一个柱形图并将其垂直轴的显示单位设为百万。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **FAQ**

**如何设置一个轴交叉另一个轴的数值（轴交叉点）？**

使用 [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) 选择交叉行为。若要指定数值交叉点，设置 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。这些设置可让你将轴交叉移动到合适的基准线上。

**如何相对于轴定位刻度标签？**

使用 [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) 并结合 [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 或 [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)，它们与标签位置分离。