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

本文介绍了如何使用 Aspose.Slides for .NET 自定义图表轴。内容包括计算轴值、切换图表行列、轴可见性、类别标签和刻度间隔、日期类别及其格式、标题旋转、轴位置、显示单位以及对数缩放。

## **获取图表中垂直轴的最大值**

创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)并添加一个默认数据的面积图。在读取计算轴值之前调用[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)以确保图表布局是最新的。

读取[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)和[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)获取轴的限制，读取[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)和[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)获取刻度间隔。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)和[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)提供时间单位刻度，这与日期轴相关。示例将这些值存储在局部变量中并保存图表。

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

使用[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)交换图表数据中系列和类别的角色。每个原来的类别变为系列，每个原来的系列变为类别。这会改变数据的分组方式；但不会交换水平轴和垂直轴。示例在切换行列之前使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)将默认数据绑定到`Sheet1!A1:D5`，包括标题行和类别列。它保存了一个包含四个系列和三个类别的图表。

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

将垂直轴的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为`false`以隐藏它。示例创建一个默认数据的折线图并保存，垂直轴已隐藏。

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

将水平轴的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)设为`false`以隐藏它。示例创建一个默认数据的折线图并保存，水平轴已隐藏。

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

## **更改类别轴**

将[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)设置为选择日期或文本类别轴。此示例需要`ExistingChart.pptx`，其中图表位于第一张幻灯片的第一个形状，且类别单元格包含数字型 Excel 日期值。它将水平轴更改为日期轴。将[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)设为`false`，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)设为`1`，并将[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)设为月份，可使主刻度以一个月为间隔。

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

## **控制类别轴标签间隔**

当图表拥有大量类别时，可在不删除类别或数据点的前提下减少可见轴标签的数量。将[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)设为`false`，然后将[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)设为所需的类别间隔。对于按正常顺序排列的文本类别，计数从第一个类别开始：

| 间隔 | 示例中显示的标签 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3`的间隔会每隔三个标签显示一次，在显示的标签之间隐藏两个标签。这不会删除相应的列。自动间隔会根据可用空间选择间隔；它不一定会显示所有标签。

刻度线有独立的控制。将[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)设为`false`并使用[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)设置其间隔。例如，`1`将在每个类别间隔保留一个刻度线，而标签仅每三个类别显示一次。将[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)设置为可见样式，以便看到效果。将任一自动间隔属性重新设为`true`，图表将再次自行选择间隔。

下面的独立示例创建 24 个类别和一个系列，然后在`CategoryAxisIntervals.pptx`中保存三张幻灯片：自动间隔、具有独立刻度线的手动标签间隔以及恢复自动间隔。两份副本保留原始图表数据。无需输入演示文稿。水平标签文本使密度差异易于观察。

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

// 幻灯片 2：显示每三个标签，但为每个类别保留刻度线。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 幻灯片 3：让图表再次选择两个间隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自动间隔（幻灯片 1）：** 在此渲染中，每隔一个类别标签显示一次，并换行为两行。自动结果可能会随图表大小、字体和渲染器而变化。

![自动类别标签间隔（所有 24 列可见）](category-axis-automatic.png)

**手动间隔（幻灯片 2）：** 每三个标签显示在一行，且刻度线仍保持在每个类别间隔。所有 24 列，包括没有标签的列，仍以相同的值可见。幻灯片 3 恢复了上图的自动外观。

![手动类别标签间隔为三（所有 24 列可见）](category-axis-manual.png)

### **选择正确的轴和间隔**

对文本类别轴（例如柱形图、折线图、面积图或条形图的类别轴）使用此类别计数间隔。在柱形图中，类别轴是水平轴；在水平条形图中，类别轴是垂直的，因此将这些设置应用于[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度间隔同样适用于具有系列轴的图表中的系列轴。

不要使用类别标签间隔来设置数值轴的数值刻度。在数值轴上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/)指定数值间隔，例如，主单位为`10`时，若轴起点为零，则刻度出现在 0、10、20 等位置。类别标签间隔为`3`则只计数类别位置，而不考虑其数值。散点图和气泡图使用数值轴而非文本类别轴。对于日期轴，请使用基于时间的主单位和刻度，如[更改类别轴](#change-a-category-axis)中所述。

## **设置类别轴值的日期格式**

示例用四个年度值替换默认图表数据。日期以 OLE Automation 序列号存储在第一个工作表（索引 `0`）中。将[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)设置为日期轴，禁用[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，并将`yyyy`赋给[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，使类别标签显示四位年份且不受单元格格式影响。

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

在垂直轴上启用[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供标题文本，并将[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/)设为旋转角度。角度以度数计；本示例将柱形图的数值轴标题旋转 90 度后保存。

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

使用[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/)控制数值轴是跨越类别轴的类别之间还是在类别刻度线处相交。此属性适用于类别轴。示例将其在柱形图的水平类别轴上设为`true`并保存结果。

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

将[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/)设定可在不更改底层数据的情况下对数值轴标签进行缩放。将[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/)设为`Millions`时，数值 60,000,000 将显示为 60。示例创建一个柱形图并将其垂直轴的显示单位设为百万。

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

对数数值轴在正值跨越多个数量级时非常有用。例如，某服务在五个时期可能收到 10、100、1,000、10,000 和 100,000 次请求。在线性尺度上，较小的值会聚集在接近零的位置。对数尺度使它们的相对增长更易比较：等距离代表相等比例而非相等差值。

在数值轴上将[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/)设为`true`并使用[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/)选择基数。此操作仅改变现有数值的显示方式；不会修改数据或添加对数趋势线。趋势线表示对数据的拟合关系，是独立的功能。

### **选择数值轴和基数**

对于折线图或柱形图，数值轴为[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。对于水平条形图，数值轴为[HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)。散点图和气泡图有两个数值轴，因此可为 X 值选择水平轴，为 Y 值选择垂直轴，或同时选择。不要对类别轴应用对数缩放。

默认的对数基数是`10`。对于 PPTX 图表，基数可在 `2` 到 `1000`（含）之间使用；也支持如 `2.5` 的小数基数。采用基数 `10` 时，后续的 10、100、1,000、10,000 等幂次等间距。

### **比较线性和对数缩放**

下面的独立示例在第一张幻灯片创建一个包含五个请求计数的折线图，然后克隆该幻灯片并在第二张上启用基数为 10 的对数数值轴。两张幻灯片保留相同的数据。

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

**线性尺度（幻灯片 1）：** 等垂直距离表示请求计数的等差值。最大值主导图表，导致较小的值难以辨别。

![PowerPoint 折线图显示线性数值轴上的五个请求计数](value-axis-linear.png)

**对数尺度（幻灯片 2）：** 等垂直距离表示等比例。每个时期的请求量是前一个的十倍，因此在基数为 10 的尺度上，点形成一条直线上升线。轴标签仍显示原始请求计数。

![PowerPoint 上相同的五个请求计数的基数为 10 的对数数值轴](value-axis-logarithmic.png)

### **处理零和负值**

对数尺度只能显示严格正值。在启用之前请检查数据。如果零或负值有意义，则保留线性尺度或单独显示它们。如果在分析中排除这些值是合适的，请说明省略原因。不要悄悄地用小的正数替代它们，因为这会改变数据的含义。对数轴手动配置的最小值或最大值也必须为正。

## **常见问题**

**如何设置一个轴交叉另一个轴的数值（轴交叉）？**

使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/)选择交叉行为。若要指定数值交叉点，设定[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。这些设置可让您将轴交叉位置移动到合适的基准线。

**如何相对于轴定位刻度标签？**

使用[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/)并结合[TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)设置为 `Low`、`High`、`NextTo` 或 `None` 来定位刻度标签。若要控制刻度线本身，可使用[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/)或[MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)；它们独立于标签定位。