---
title: 在 .NET 中管理演示文稿中的图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/net/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- 图表缓存
- 工作簿恢复
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "发现 Aspose.Slides for .NET：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化您的演示文稿数据。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表数值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/net/chart-series/)以了解空单元格与零的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)控制图表是否绘制来自隐藏工作表行和列的数据。将其设为 `true` 只绘制可见单元格，设为 `false` 则同时包含可见和隐藏单元格。此设置仅控制图表绘制；它不会隐藏或取消隐藏工作表的行或列。

[示例演示文稿](hidden-source-data.pptx)的第一张幻灯片的第一个形状是一个柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列已隐藏，但它们的单元格仍然包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

通过[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问源单元格，并读取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/)以检查其隐藏状态。此属性为只读。在本文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True` 和 `True`。

对于本示例，在更改绘图设置后刷新图表数据：使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)保留嵌入的工作簿，然后使用[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)重新加载。当包含所有单元格时，还需要使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)恢复完整范围，包括隐藏的 February 类别。仅更改标志不足以刷新此示例缓存的图表数据和类别标签。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // 从嵌入的工作簿刷新图表数据。
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // 恢复完整的源范围，包括隐藏的类别。
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

示例保存了两种版本的演示文稿：一种仅包含可见的 Retail 值（10 和 20），另一种包含全部六个值。下方图片是重新打开保存的演示文稿后渲染的，两文件均保留了各自的绘图设置。第 3 行和 C 列在两个嵌入工作簿中仍保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)控制缺失值的显示方式；它不包含或排除隐藏的源数据。参见[控制空单元格的显示](/slides/zh/net/chart-series/#control-the-display-of-empty-cells)获取示例。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，检查源范围以确定每个图表使用的工作表单元格。[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/)方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名称，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识从 A1 到 D5（含）的单元格。美元符号表示绝对行列引用。

此方法在不更改图表或其工作簿的情况下读取当前范围。如果图表未使用工作簿作为数据源，则会抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)。

本示例打开一个演示文稿并检查每张幻灯片上直接的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印相应消息并继续下一个图表。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **从工作簿读取和写入图表数据**

Aspose.Slides for .NET 提供了[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，允许读取和写入包含由 Aspose.Cells 编辑的图表数据的工作簿。**注意**，图表数据必须以相同方式组织或具有类似于源的结构。

本示例使用第一张幻灯片上第一个形状为图表的演示文稿。它将嵌入的工作簿读取为流，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中；示例不保存演示文稿。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **在工作簿修改后验证图表布局**

当用已修改的工作簿替换嵌入工作簿时，图表仍保留原始的系列和类别集合。此不匹配可能导致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)因索引超出范围而失败。写回更新的工作簿之前请先清除现有系列和类别。本示例使用第一张幻灯片上第一个形状为图表。注释标记了工作簿编辑可能出现的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // 在此修改工作簿流，例如使用 Aspose.Cells。

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

清除集合可在写回工作簿前移除陈旧的数据引用。在使用图表之前，请为更新后的工作簿重新构建所需的系列和类别映射。

## **选择类别标签的存储方式**

在添加标签之前，对空类别集合设置[IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/)。使用工作表单元格作为引用工作簿数据或形成层次结构的标签，例如按年份分组的季度。使用字符串文字作为单层标签，无需单元格引用。此设置仅适用于类别。下方两个图表均使用工作表单元格存储数值系列。

示例创建两个柱形图，并为每个图表打印 `Q1 Q2 Q3 Q4` 以及其存储模式。对于基于工作表的标签，使用[IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/)获取底层单元格，且[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)返回其标签。对于文字标签，直接读取[IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/)。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **为工作簿单元格设置自定义数字格式**

使用[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/)控制数字值在图表嵌入工作簿中的显示方式。例如，报告可能需要将转化率显示为保留四位小数的百分比，将系数显示为保留五位小数的数值。保持两个值为数值类型，以便仍可用于计算和图表绘制。

数字格式仅改变显示，而不改变存储的值。格式 `0.0000%` 会将 `0.125` 显示为 `12.5000%`，但不会把存储的数字改为 `12.5`。同理，`0.00000` 会将 `0.1234567` 显示为 `0.12346`，而不会对存储值进行四舍五入。如果自定义格式为空字符串 (`""`)，则使用[PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/)。

下面的示例创建一个柱形图，并通过[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问其单元格。在工作表 0 中，B2 包含转化率，C2 包含系数。两个单元格均供图表使用。示例还启用了链接到源格式的数值标签。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

工作簿单元格格式独立于直接在图表坐标轴或数据标签上设置的格式。在本示例中，每个标签显示其源单元格的值，因为[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)已启用，并且因为[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 为 `true`，所以遵循源数字格式。保存并重新打开演示文稿后，标签显示 `12.5000%` 和 `0.12346`，如下所示。垂直坐标轴使用其自身的[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`，且[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) 为 `false`。

若要独立格式化数据标签，请将其源链接标志设为 `false` 并分配[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)。这不会改变工作簿单元格的格式。例如，独立标签格式 `0.00` 会将首个值显示为 `0.13`，而 B2 仍显示 `12.5000%`。请参阅[图表数据标签](/slides/zh/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)了解直接标签格式化。

下图是重新打开保存的演示文稿后渲染的结果：

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **将工作簿单元格用作图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。

本示例向现有演示文稿的第一张幻灯片添加一个默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **管理工作表**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/)属性提供对图表工作簿中工作表的访问。本示例创建一个默认数据的饼图，并将每个工作表名称打印到控制台。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **指定数据源类型**

系列点的数值也可以直接作为数值文字存储。请参阅[使用数值文字设置系列值](/slides/zh/net/chart-series/#set-series-values-using-numeric-literals)获取完整示例，该示例演示了保存和读取这些文字。点值的数据源类型独立于图表内部或外部工作簿的配置；使用数值文字本身并不会移除嵌入的工作簿。

本示例创建一个默认数据的 3D 柱形图，并使用不同的数据源为两个系列名称赋值。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)枚举用于为每个名称选择来源。示例保存了带有更新系列名称的演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **检测不受支持的嵌入工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿 (.xlsb) 格式。您可以使用[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) 上的[EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/)属性结合[WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。此示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个包含嵌入 .xlsb 工作簿的图表打印诊断信息。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // 在此读取或修改受支持的图表工作簿数据。
}
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)将嵌入的图表工作簿导出到文件，并将图表链接到该外部工作簿。

本示例创建一个默认数据的饼图并导出其工作簿。将输出流关闭后，将外部工作簿设为图表的数据源，随后保存已链接的演示文稿。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **设置外部工作簿**

使用[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，您可以将外部工作簿分配给图表作为其数据源。此方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存放在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供相对路径，则会自动转换为完整路径。

本示例使用一个外部工作簿，其工作表 `Sheet1` 在 B1 中包含系列名称，A2:A4 中包含类别名称，B2:B4 中包含数值。示例创建一个饼图，链接该工作簿，并使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)将 A1:B4 映射为一个系列和三个类别。随后保存带有链接图表的演示文稿。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 的 `updateChartData` 设置为 `false`。它保留饼图的默认数据并在未加载不可用工作簿的情况下保存演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

本示例检查带有外部工作簿链接的演示文稿第一张幻灯片上的第一个形状。如果它是链接到外部工作簿的图表，示例将[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/)打印到控制台。随后保存演示文稿的副本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **编辑图表数据**

您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

本示例使用第一张幻灯片上第一个形状的图表，该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100，并保存更新后的演示文稿。编辑单元格值可能会更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

## **从源工作簿刷新图表数据**

Aspose.Slides for .NET 26.11 添加了[IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/)（针对单个图表）和[IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/)（针对整个演示文稿）。在源工作簿值更改后使用它们。外部工作簿必须可访问且受支持。

在安装了[Aspose.Slides for .NET](/slides/zh/net/installation/) 26.11 或更高版本的情况下，本示例刷新 `charts.pptx` 第一次幻灯片上的第一个图表。其源工作簿必须可用。将结果保存以保留已更新的图表数据。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

若要刷新所有图表，请使用单独的演示文稿实例，如下所示。传入 `false` 会使刷新失败向调用方传播；它不会回滚已成功刷新的图表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

参数默认值为 `true`：[RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) 会跳过失败的图表并继续处理其他图表。它不返回每个图表的结果，因此一次成功的调用并不证明每个图表都已刷新。如需识别每个失败图表，请使用单独的[RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) 调用。

刷新会重新加载源数据。它与公式计算、图表布局验证和 OLE 预览更新是分离的。检查实时的单元格值以验证内存中的刷新。除非保存并重新打开演示文稿，否则[CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) 仍可能描述先前保存的图表。

### **在没有工作簿的情况下读取缓存的图表值**

在 .NET 26.11 中，缓存值访问器读取图表随附的值，而无需打开其工作簿。当链接文件不可用且仅需图表的最后存储数据时，这些访问器非常有用。这不同于下面的恢复选项。

| 对象 | 缓存访问器 |
| --- | --- |
| 普通系列数据点 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| 散点或气泡数据点 | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| 气泡数据点 | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| 图表类别 | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

每个访问器返回[ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/)。[Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) 暴露存储的对象；[ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) 提供文本；[ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) 对缺失或非数值返回 `NaN`。缓存可能缺失或已过时，包括在尚未保存的新建图表上。不要假设每个字段都存在或包含数字。

本示例读取 `cached-chart.pptx`（一个已保存的包含图表的演示文稿）中的所有这些字段。由于代码不访问[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)或实时工作簿单元格，缺少外部工作簿是可以接受的。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

需要当前源数据时请使用刷新；当存储的快照已足够时使用缓存读取。缓存不是工作簿的完整副本，无法提供自上次更新后所做的更改。

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)，配置其[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)，并在打开演示文稿前将[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 设为 `true`。

下面的 C# 示例为第一张幻灯片上第一个形状的图表恢复工作簿数据，该图表引用了不可用的外部工作簿。它通过[IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) 和[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 访问恢复的数据：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // 在此读取或修改恢复的工作簿数据。
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

如果代码在外部工作簿不可用且恢复已禁用的情况下访问该工作簿，Aspose.Slides 会抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。仅在使用缓存图表数据可接受作为后备时才启用恢复，因为缓存可能不包含外部工作簿在演示文稿上次更新后所做的更改。

## **常见问题解答**

**我可以判断特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[数据源类型](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)和[外部工作簿路径](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)；如果来源是外部工作簿，您可以读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径，它们是如何存储的？**

支持。若指定相对路径，系统会自动转换为绝对路径。演示文稿在 PPTX 文件中存储的是绝对路径，因此移动工作簿后可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，此类工作簿可用作外部数据源。但 Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为来源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿存储的是指向外部文件的[链接](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常用做法是事先移除保护或准备一个已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/net/)）并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们指向同一文件，更新该文件后将在下次加载数据时反映到所有图表中。