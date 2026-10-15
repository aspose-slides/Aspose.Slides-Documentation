---
title: 在 .NET 中自定义演示文稿的图表坐标轴
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

本文介绍如何使用 Aspose.Slides for .NET 自定义图表坐标轴。内容包括计算坐标轴值、切换图表行列、坐标轴可见性、类别标签和刻度间隔、日期类别及格式、标题旋转、坐标轴定位、显示单位以及对数刻度。

## **获取图表垂直坐标轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)并添加一个默认数据的面积图。在读取计算的坐标轴值之前，调用[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)以确保图表布局是最新的。

读取[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)和[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)以获取坐标轴的限制值，读取[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)和[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)以获取刻度间隔。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)和[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)提供时间单位比例，这与日期坐标轴相关。示例将这些值存储在本地变量中并保存图表。

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

## **交换坐标轴之间的数据**

使用[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式；但不会交换水平和垂直坐标轴。示例在切换行列之前，使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)将默认数据绑定到`Sheet1!A1:D5`，包括标题行和类别列。它保存了一个包含四个系列和三个类别的图表。

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

## **反转坐标轴的绘制顺序**

使用[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/)来反转类别或数值坐标轴。例如，水平条形图可以按照工作表的顺序从上到下显示项目阶段：Planning、Development、Testing。反转坐标轴会改变绘制方向；但不会对工作簿数据进行排序或重新排列。相比之下，[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)交换系列和类别的角色。

下面的示例创建一个包含三个阶段和一个系列的水平条形图。它保存一个包含三张幻灯片的演示文稿：正常顺序、类别反转和数值反转。每个副本使用相同的数据集，并且每个副本只反转一个坐标轴。

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

反转坐标轴还可以将垂直的坐标轴移动到绘图的另一侧。[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)控制另一坐标轴在被配置的坐标轴上的交叉位置。在第 2 张幻灯片中，将其设为 `Maximum` 在反转的类别坐标轴上，使水平数值坐标轴保持在底部。若需特定的交叉点，请使用[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。在改变方向时检查交叉设置，尤其是图表已经有自定义交叉点时。将 `IsPlotOrderReversed` 设置回 `false` 可恢复正常绘制方向；交叉设置是独立的。

| 正常顺序（幻灯片 1） | 类别反转（幻灯片 2） | 数值反转（幻灯片 3） |
| --- | --- | --- |
| ![水平条形图，类别和数值坐标轴顺序正常](axis-order-normal.png) | ![水平条形图，类别从上到下显示](axis-order-categories-reversed.png) | ![水平条形图，数值坐标轴反转且零位于右侧](axis-order-values-reversed.png) |
| 类别从底部到顶部排列；数值从左向右递增。 | Planning、Development、Testing 从上到下排列。数值和工作表行顺序保持不变。 | 类别保持正常顺序；数值从右向左递增。类别坐标轴在右侧的零处交叉。 |

## **禁用折线图的垂直坐标轴**

在垂直坐标轴上将[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为 `false` 以隐藏它。示例创建一个带默认数据的折线图，并保存为隐藏垂直坐标轴的版本。

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

## **禁用折线图的水平坐标轴**

在水平坐标轴上将[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为 `false` 以隐藏它。示例创建一个带默认数据的折线图，并保存为隐藏水平坐标轴的版本。

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

## **更改类别坐标轴**

将[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)设置为选择日期或文本类别坐标轴。此示例需要 `ExistingChart.pptx`，其中图表是第一张幻灯片的第一个形状，且类别单元格包含数字形式的 Excel 日期值。它将水平坐标轴更改为日期坐标轴。将[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)设为 `false`，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)设为 `1`，并将[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)设为 months（月份），可使主刻度间隔为一个月。

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

## **控制类别坐标轴标签间隔**

当图表类别众多时，可在不删除类别或数据点的前提下减少可见坐标轴标签的数量。将[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)设为 `false`，然后将[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)设为所需的类别间隔。对于正常顺序的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

间隔为 `3` 时，每隔三个标签显示一次，中间的两个标签被隐藏。它不会删除对应的列。自动间距根据可用空间选择间隔；并不一定显示所有标签。

刻度线有独立的控制。将[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)设为 `false`，并使用[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)设置其间隔。例如，设为 `1` 时在每个类别间隔都保留刻度线，而标签仅每第三个类别出现一次。将[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)设置为可见样式，以便看到效果。将任一自动间距属性恢复为 `true`，图表会再次自行选择间隔。

下面的独立示例创建 24 个类别和一个系列，然后在 `CategoryAxisIntervals.pptx` 中保存三张幻灯片：自动间距、手动标签间距并独立刻度线、以及恢复自动间距。两个副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异一目了然。

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

// 幻灯片 2：显示每第三个标签，但为每个类别保留刻度线。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 幻灯片 3：让图表再次自行选择两个间隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自动间距（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。自动结果会随图表大小、字体和渲染器而变化。

![自动类别标签间距，所有 24 列均可见](category-axis-automatic.png)

**手动间距（幻灯片 2）：** 每三个标签显示在一行，而刻度线仍保持在每个类别间隔。所有 24 列，包括没有标签的列，仍以相同的数值可见。幻灯片 3 恢复上述自动外观。

![手动类别标签间隔为三，所有 24 列均可见](category-axis-manual.png)

### **选择正确的坐标轴和间隔**

对文本类别坐标轴（例如柱形图、折线图、面积图或条形图的类别坐标轴）使用此类别计数间隔。在柱形图中，它是水平坐标轴。在水平条形图中，类别坐标轴是垂直的，因此将这些设置应用于[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度间距同样适用于具有系列坐标轴的图表的系列坐标轴。

不要使用类别标签间隔来设置数值坐标轴的数值刻度。在数值坐标轴上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)指定数值的差值，例如，当坐标轴起点为零时，`10` 的主单位会在 0、10、20 等位置生成刻度。类别标签间隔为 `3` 则是按类别位置计数，与数据值无关。散点图和气泡图使用数值坐标轴而非文本类别坐标轴。对于日期坐标轴，请使用基于时间的主单位和比例，如[更改类别坐标轴](#change-a-category-axis)所述。

## **设置类别坐标轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中。将[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)设置为日期坐标轴，禁用[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，并将`yyyy`赋给[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，以便类别标签独立于单元格格式显示四位年份。

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

## **设置图表坐标轴标题的旋转角度**

在垂直坐标轴上启用[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供标题文本，并设置[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)以旋转标题。角度以度为单位；本示例保存了一个列图，其数值坐标轴标题旋转了 90 度。

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

## **设置类别或数值坐标轴的位置**

使用[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)控制数值坐标轴是跨越类别之间还是在类别刻度线上与类别坐标轴相交。此属性适用于类别坐标轴。示例在柱形图的水平类别坐标轴上将其设为 `true`，并保存结果。

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

## **设置图表数值坐标轴的显示单位**

将[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)设置为在不更改底层数据的情况下缩放数值坐标轴的标签。将[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)设为 `Millions` 时，60000000 的值显示为 60。示例创建了一个柱形图，并将百万显示单位应用于其垂直坐标轴。

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

## **配置对数数值坐标轴**

当正值跨越多个数量级时，对数数值坐标轴非常有用。例如，一个服务在五个时期可能分别收到 10、100、1,000、10,000 和 100,000 次请求。在线性刻度上，较小的数值会在零附近密集排列。对数刻度使其相对增长更易比较：相等的距离代表相等的比例，而非相等的差值。

在数值坐标轴上将[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/)设为 `true`，并使用[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/)选择底数。这会改变现有数值的显示方式；但不修改数据或添加对数趋势线。趋势线表示数据的拟合关系，是独立的功能。

### **选择数值坐标轴和底数**

对于折线图或柱形图，数值坐标轴是[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。对于水平条形图，则是[HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)。散点图和气泡图有两个数值坐标轴，因此可为 X 值选择水平坐标轴，为 Y 值选择垂直坐标轴，或两者皆选。不要对类别坐标轴应用对数刻度。

默认的对数底数为 `10`。对于 PPTX 图表，底数可使用 `2` 到 `1000`（包括两端）的整数；也支持诸如 `2.5` 的分数底数。底数为 `10` 时，后续的 10、100、1,000、10,000 等幂次等间距。

### **比较线性和对数刻度**

下面的独立示例在第一张幻灯片创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张幻灯片上启用基数为 10 的对数数值坐标轴。两张幻灯片保留相同的数据。

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

// 保持第一张幻灯片为线性且仅更改副本的数值轴比例。
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**线性刻度（幻灯片 1）：** 相等的垂直距离代表请求计数的相等差值。最大值主导图表，使较小的值难以辨别。

![PowerPoint 中的折线图，显示线性数值坐标轴上的五个请求计数](value-axis-linear.png)

**对数刻度（幻灯片 2）：** 相等的垂直距离代表相等的比例。每个时期的请求数是前一个时期的十倍，因而点在基数为 10 的刻度上形成一条直线上升线。坐标轴标签仍显示原始的请求计数。

![PowerPoint 中相同的五个请求计数，使用基数为 10 的对数数值坐标轴](value-axis-logarithmic.png)

### **处理零和负值**

对数刻度只能显示严格正值。启用前请检查数据。如果零或负值具有意义，请保持线性刻度或单独显示它们。如果在分析中排除这些值是合适的，请说明省略原因。不应悄悄将它们替换为较小的正数，因为这会改变数据的含义。对数坐标轴的手动设置的最小值或最大值也必须为正数。

## **常见问题**

**如何设置一个坐标轴交叉另一个坐标轴的数值（坐标轴交叉）？**

使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)选择交叉行为。若要指定数值交叉点，请设置[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。这些设置可将坐标轴交叉点移动到合适的基准线。

**如何相对于坐标轴定位刻度标签？**

使用[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)并结合[TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)设置为 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度线本身，请使用[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/)或[MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)；它们与标签定位分开。