---
title: 在 .NET 演示文稿中自定义图表坐标轴
linktitle: 图表坐标轴
type: docs
url: /zh/net/chart-axis/
keywords:
- 图表坐标轴
- 垂直坐标轴
- 水平坐标轴
- 自定义坐标轴
- 操作坐标轴
- 管理坐标轴
- 坐标轴属性
- 最大值
- 最小值
- 坐标轴线
- 日期格式
- 坐标轴标题
- 坐标轴位置
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中自定义图表坐标轴，以用于报告和可视化。"
---
## **概述**

本文说明如何使用 Aspose.Slides for .NET 自定义图表坐标轴。内容涉及计算后的轴值、交换图表行列、轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、轴位置、显示单位以及对数缩放。

## **获取图表垂直轴的最大值**

创建一个[演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation/)并添加默认数据的面积图。 在读取计算后的轴值之前调用[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)，以确保图表布局是最新的。

读取[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)和[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)获取轴范围，读取[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)和[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)获取刻度间隔。 [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)和[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)提供时间单位尺度，适用于日期轴。 示例将这些值存入局部变量并保存图表。

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

使用[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)来交换系列和类别在图表数据中的角色。 先前的每个类别变为系列，先前的每个系列变为类别。 这会改变数据的分组方式，但不会交换水平和垂直轴。 示例使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)将默认数据绑定到 `Sheet1!A1:D5`（包括标题行和类别列），然后再交换行列。 它保存了一个包含四个系列和三个类别的图表。

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

## **颠倒轴的绘制顺序**

使用[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/)来颠倒类别轴或数值轴的绘制顺序。 例如，水平条形图可以按照工作表的顺序从上到下显示项目阶段：Planning、Development、Testing。 颠倒轴会改变绘制方向，但不会对工作簿数据进行排序或重新排列。 对比之下，[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)交换系列和类别的角色。

下面的示例创建一个包含三个阶段和一个系列的水平条形图。 它保存一个包含三张幻灯片的演示文稿：正常顺序、类别逆序和数值逆序。 每个副本使用相同的数据集，且每个副本仅颠倒一个轴。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: display the first category at the top.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Keep the horizontal value axis at the bottom.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: reverse only the horizontal numeric scale.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

颠倒轴还可以将垂直轴移动到绘图区的另一侧。 使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)控制另一轴在配置轴的何处相交。 在第 2 张幻灯片中，将其设置为 `Maximum` 可在颠倒的类别轴上保持水平数值轴位于底部。 若需指定具体的交叉点，请使用[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。 更改方向时请检查交叉设置，尤其是图表已拥有自定义交叉点的情况。 将 `IsPlotOrderReversed` 设回 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别逆序（幻灯片 2） | 数值逆序（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别和数值轴顺序正常](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值轴逆向且零点在右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部；数值从左到右递增。 | 计划、开发和测试从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右到左递增。类别轴在右侧零点处相交。 |

## **禁用折线图的垂直轴**

将垂直轴的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为 `false` 即可隐藏。 示例创建一个默认数据的折线图，并以隐藏垂直轴的形式保存。

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

将水平轴的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为 `false` 即可隐藏。 示例创建一个默认数据的折线图，并以隐藏水平轴的形式保存。

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

## **显示或隐藏图表网格线**

读取[ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/)和[ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/)以检查轴当前显示的网格线类型。 两个属性均为只读。 使用[MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/)的线条填充来显示或隐藏次要网格线。 为显示设置可见颜色的实线填充，或使用 `FillType.NoFill` 隐藏。 对主要网格线的相应设置为[MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`。 更改网格线填充不会影响轴的可见性和刻度标记。

此簇状柱形图的垂直轴默认显示主要网格线且隐藏次要网格线。 示例先将次要网格线显示为橙色，然后再次隐藏后保存演示文稿。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| 已启用次要网格线 | 已隐藏次要网格线 |
| --- | --- |
| ![垂直轴上主要网格线之间的橙色次要网格线](minor-gridlines-enabled.png) | ![相同的柱形图，仅显示主要网格线](minor-gridlines-hidden.png) |

## **更改类别轴**

设置[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)以选择日期或文本类别轴。 本示例需要 `ExistingChart.pptx`，其中第一张幻灯片的第一个形状是图表，类别单元格包含 Excel 数值日期。 示例将水平轴更改为日期轴。 将[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)设为 `false`，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)设为 `1`，并将[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)设为 months，即可使主要刻度间隔为一个月。

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

### **根据数据确定类别轴类型**

在填充完类别后调用[SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/)，随后读取[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/)检查结果。 当同一图表可能接收文本标签或数值日期时，此方法非常有用。 它在调用时确定类型，不会启用后续数据更改的持久重新评估模式。 替换类别后请再次调用。

下面的示例创建一个具有文本类别的图表并输出 `Text`。 然后将类别单元格值替换为日期并再次调用该方法，输出 `Date`。 日期以数值 OLE Automation 形式存储，来自[DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate)，而不是日期字符串。 [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) 控制这些值的显示方式；它不将文本转换为数值日期。 更多关于类别单元格的信息请参阅[Chart Workbook](/slides/zh/net/chart-workbook/)。

使用自动确定适用于已知包含文本类别或数值日期的输入（如本示例所示）。 对于普通数值标签、混合类别或空数据，请显式设置[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/)以匹配实际含义。 单纯的数值并不能说明类别代表日期。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // 文本

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // 日期

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **控制类别轴标签间隔**

当图表包含大量类别时，可通过减少可见轴标签数量来提升可读性，而不必删除类别或数据点。 将[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)设为 `false`，随后将[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)设为所需的类别间隔。 对于按正常顺序排列的文本类别，计数从第一类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | 类别 1、类别 2、类别 3、… 类别 24 |
| `2` | 类别 1、类别 3、类别 5、… 类别 23 |
| `3` | 类别 1、类别 4、类别 7、… 类别 22 |

间隔为 `3` 时每三个标签显示一次，两个标签被隐藏，而对应的列仍然保留。 自动间距根据可用空间选择间隔，并不一定显示所有标签。

刻度标记拥有独立的控制。 将[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)设为 `false`，并使用[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)设定其间隔。 例如，`1` 可在每个类别间隔保留刻度标记，而标签仅每三个类别出现一次。 将[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)设为可见样式以观察效果。 将任一自动间距属性恢复为 `true` 可让图表重新自动选择间隔。

下面的自包含示例创建 24 个类别和一个系列，并在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间距、手动标签间距（刻度标记独立）以及恢复自动间距。 两个副本保留原始图表数据。 无需输入演示文稿。 水平标签文本使密度差异一目了然。

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

// 幻灯片 2：显示每三个标签，但为每个类别保留刻度标记。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 幻灯片 3：让图表再次自动选择两个间隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自动间距（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。 自动结果可能随图表大小、字体和渲染器而变化。

![自动类别标签间距，所有 24 列均可见](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每三个标签显示在一行，而刻度标记仍保持在每个类别间隔。 所有 24 列（包括未显示标签的列）仍保持可见且数值相同。 第 3 张幻灯片恢复了上述自动外观。

![手动类别标签间隔为三，所有 24 列均可见](category-axis-manual.png)

### **选择正确的轴和间隔**

对文本类别轴（如柱形图、折线图、面积图或条形图的类别轴）使用此类别计数间隔。 在柱形图中，它是水平轴；在水平条形图中，类别轴为垂直轴，需将这些设置应用于[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。 对于拥有系列轴的图表，刻度标记间距同样适用于系列轴。

请勿使用类别标签间隔来设置数值轴的数值刻度。 在数值轴上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)指定数值差异，例如 `10` 的主要单位会在 0、10、20… 产生刻度（前提是轴起始于零）。 而类别标签间隔 `3` 只是计数类别位置，与数据值无关。 散点图和气泡图使用数值轴而非文本类别轴。 对于日期轴，请参照[更改类别轴](#change-a-category-axis)中所述使用基于时间的主要单位和尺度。

## **为类别轴值设置日期格式**

示例用四个年度值替换默认图表数据。 日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中。 将[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)设为日期轴，禁用[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，并将[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)设为 `yyyy`，即可使类别标签独立于单元格格式显示四位数年份。

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

在垂直轴上启用[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供标题文本，并将[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)设定为所需角度即可旋转标题。 角度以度为单位；本示例将柱形图的数值轴标题旋转 90 度后保存。

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

## **设置类别轴或数值轴的位置**

使用[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)控制数值轴是位于类别轴之间还是在类别刻度线上相交。 此属性仅适用于类别轴。 示例将其在柱形图的水平类别轴上设为 `true` 并保存结果。

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

将[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)设为相应的单位，可在不改变底层数据的前提下缩放数值轴标签。 当[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)设为 `Millions` 时，60000000 将显示为 60。 示例创建一个柱形图并对其垂直轴应用“百万”显示单位。

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

## **配置对数数值轴**

当正数值跨越多个数量级时，对数数值轴非常有用。 例如，某服务在五个周期内的请求量分别为 10、100、1,000、10,000、100,000。 在线性尺度下，较小的数值会聚集在零附近。 对数尺度使其相对增长更易比较：相等的距离代表相等的比例而非相等的差值。

在数值轴上将[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/)设为 `true`，并使用[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/)选择基数。 这仅改变现有值的显示方式，不会修改数据或添加对数趋势线。 趋势线是对数据进行拟合的独立功能。

### **选择数值轴和基数**

对于折线图或柱形图，数值轴为[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。 对于水平条形图，则为[HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)。 散点图和气泡图拥有两个数值轴，可分别为 X 轴选取水平轴、为 Y 轴选取垂直轴，或两者皆设。 请勿对类别轴使用对数缩放。

默认对数基数为 `10`。 对于 PPTX 图表，基数可取 `2` 到 `1000`（含），同样支持 `2.5` 等小数基数。 基数为 `10` 时，10、100、1,000、10,000 等幂次等间距。

### **比较线性和对数缩放**

下面的自包含示例在第一张幻灯片上创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值轴。 两张幻灯片保留相同的数据。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**线性比例（幻灯片 1）：** 等距离的垂直跨度代表请求计数的等差。 最大值主导图表，导致较小的值难以辨识。

![PowerPoint 中的折线图，显示五个请求计数的线性数值轴](value-axis-linear.png)

**对数比例（幻灯片 2）：** 等距离的垂直跨度代表等比例。 每个周期的请求量是前一个的十倍，因此在以 10 为底的尺度上点呈现直线上升。 轴标签仍显示原始请求计数。

![PowerPoint 中相同的五个请求计数，使用 10 为底的对数数值轴](value-axis-logarithmic.png)

### **处理零和负值**

对数尺度只能显示严格正数。 启用前请检查数据。 若零或负值具有实际意义，请保持线性尺度或单独展示。 若在分析中排除这些值，请说明原因，切勿悄悄将其替换为小的正数，以免改变数据含义。 对数轴的手动最小值或最大值同样必须为正数。

## **常见问题**

**如何设置一个轴与另一个轴相交的数值（轴交叉）？**

使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)选择交叉行为。 若要指定数值交叉点，请设置[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。 这些设置可将轴交叉移动到合适的基准线。

**如何相对于轴定位刻度标签？**

使用[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)并结合[TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)的 `Low`、`High`、`NextTo` 或 `None`。 若要控制刻度标记本身，请使用[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/)或[MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)，它们与标签位置无关。