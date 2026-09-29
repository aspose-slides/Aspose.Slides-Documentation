---
title: 在 .NET 中管理演示文稿的图表工作簿
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
description: "了解 Aspose.Slides for .NET：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化您的演示文稿数据。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/net/chart-series/)以了解空单元格与零之间的区别，以及折线图展示的可用显示模式比较。

## **包括隐藏行和列中的数据**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)来控制图表是否绘制来自隐藏工作表行和列的数据。将其设为 `true` 只绘制可见单元格，设为 `false` 则包括可见和隐藏单元格。此设置控制图表绘制；它不会隐藏或取消隐藏工作表行或列。

下载[hidden-source-data.pptx](hidden-source-data.pptx)并将其放在工作目录中。其第一张幻灯片包含一个作为第一形状的柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和列 C 为隐藏状态，但它们的单元格仍然包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问源单元格，并读取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/ishidden/)以检查其隐藏状态。此属性为只读。在本文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True` 和 `True`。

对于本示例，在更改绘制设置后请刷新图表数据：使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/readworkbookstream/)保留嵌入工作簿，并使用[WriteWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/writeworkbookstream/)重新加载。当包含所有单元格时，还需使用[SetRange](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/setrange/)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

        // 刷新图表数据，从嵌入的工作簿中读取。
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

示例将仅包含可见零售值（10 和 20）的 `hidden_cells_True.pptx` 保存，而将所有六个值保存到 `hidden_cells_False.pptx`。下面的图像是重新打开保存的演示文稿后渲染的；两个文件均保留其分配的绘制设置。第 3 行和列 C 在两个嵌入工作簿中仍然保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/displayblanksas/)控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/net/chart-series/#control-the-display-of-empty-cells)获取示例。

## **读取和写入工作簿中的图表数据**

Aspose.Slides for .NET 提供了[ReadWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[WriteWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，允许您读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**Note** 图表数据必须以相同方式组织或结构类似于源。

此示例打开 `chart.pptx`，该文件必须在其第一张幻灯片的第一形状中包含一个图表。它将嵌入的工作簿读取到流中，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中；示例未保存演示文稿。

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

当您用修改后的工作簿替换嵌入工作簿时，图表会保留其原始系列和类别集合。此不匹配可能导致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/validatechartlayout/)因索引超出范围错误而失败。在将更新的工作簿写回图表之前，请先清除现有系列和类别。此示例需要 `chart.pptx`，其第一张幻灯片的第一形状必须是图表。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

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

    // 在此修改工作簿流，例如，使用 Aspose.Cells.

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

清除集合可在工作簿写回之前移除陈旧的数据引用。请在使用图表之前为更新的工作簿重新构建任何必需的系列和类别映射。

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。以下步骤展示了如何将气泡图中的标签链接到其数据工作簿中的单元格。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 通过其从零起始的索引访问第一张幻灯片。
3. 添加一个使用默认数据的气泡图。
4. 访问图表系列。
5. 将工作簿单元格设为数据标签。
6. 保存演示文稿。

此示例打开 `chart2.pptx`，该文件必须至少包含一张幻灯片，并添加一个使用默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列的前三个标签，启用来自单元格的标签，并将结果保存为 `resultchart.pptx`。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/worksheets/)属性提供对图表工作簿中工作表的访问。此示例创建一个使用默认数据的饼图，并将每个工作表名称打印到控制台。

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

此示例创建一个使用默认数据的三维柱形图，并使用不同的数据源设置两个系列名称。第一个名称使用字符串文字；第二个使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/datasourcetype/)枚举为每个名称选择源。结果保存为 `pres.pptx`。

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

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可以嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以使用[IChartData](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/)上的[EmbeddedWorkbookType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/)属性结合[WorkbookType](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。此示例检查 `sample.pptx` 第一张幻灯片上的形状，跳过非图表形状，并为每个嵌入 .xlsb 工作簿的图表打印诊断信息。

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

使用[ReadWorkbookStream](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[SetExternalWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/setexternalworkbook/)将嵌入的图表工作簿导出为文件，并将图表链接到该外部工作簿。

此示例创建一个使用默认数据的饼图，将其工作簿写入 `externalWorkbook1.xlsx`，并在将文件分配为图表数据源之前关闭输出流。它将已链接的演示文稿保存为 `externalWorkbook.pptx`。

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

使用[SetExternalWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果已移动）。

虽然无法直接编辑存储在远程位置或资源中的工作簿，但仍可将此类工作簿用作外部数据源。如果提供了相对路径，系统会自动将其转换为完整路径。

此示例需要工作目录中存在 `externalWorkbook.xlsx`。其名为 `Sheet1` 的工作表必须在 B1 中包含系列名称，在 A2:A4 中包含类别名称，并在 B2:B4 中包含数值。示例创建一个饼图，链接工作簿，并使用[SetRange](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/setrange/)将 A1:B4 映射为一个系列和三个类别。结果保存为 `Presentation_with_externalWorkbook.pptx`。

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

`SetExternalWorkbook` 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

下面的示例将占位符 URL 与 `updateChartData` 设置为 `false` 一起分配。它保留饼图的默认数据，并在未加载不可用工作簿的情况下保存演示文稿。

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

要识别链接到图表的工作簿，首先检查图表是否使用外部数据源。如果是，您可以按照以下步骤检索工作簿路径。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。
2. 通过其从零起始的索引访问第一张幻灯片。
3. 检查第一个形状是否为图表。
4. 读取图表的数据源类型。
5. 如果源是外部工作簿，则读取其路径。

此示例打开先前示例中创建的 `externalWorkbook.pptx`，检查第一张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例会将[ExternalWorkbookPath](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)打印到控制台。随后将演示文稿的副本保存为 `Result.pptx`。

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

此示例需要 `presentation.pptx`，其第一张幻灯片的第一形状必须是图表，并且拥有可访问的外部工作簿。示例将第一系列第一个数据点的单元格支持值设置为 100，并将演示文稿保存为 `presentation_out.pptx`。编辑单元格值可能会更新链接的外部 XLSX 文件，如需保留原始工作簿，请使用副本。

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

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/)，配置其[SpreadsheetOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/spreadsheetoptions/)，并在打开演示文稿前将[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/)设为 `true`。

下面的 C# 示例打开 `presentation.pptx`，其第一张幻灯片的第一形状必须是引用不可用外部工作簿的图表，并通过[IChart.ChartData](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichart/chartdata/)和[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。仅在使用缓存的图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含演示文稿上次更新后对外部工作簿所做的更改。

## **常见问题**

**我能否确定特定图表是链接到外部工作簿还是嵌入工作簿？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/datasourcetype/)和[external workbook path](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持相对路径的外部工作簿，它们如何存储？**

支持。提供相对路径时，系统会自动将其转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这些工作簿可以用作外部数据源。不过，Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为来源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿存储的是指向外部文件的[链接](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/chartdata/externalworkbookpath/)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如需保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备一个已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/net/)），然后链接该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储自己的链接。如果它们指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。