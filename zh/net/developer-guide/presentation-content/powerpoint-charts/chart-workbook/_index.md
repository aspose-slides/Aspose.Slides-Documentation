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
description: "了解 Aspose.Slides for .NET：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文阐述了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表数值指定数据源类型。

还涵盖了将外部工作簿用作图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/net/chart-series/)，了解空单元格与零的区别以及可用显示模式的折线图比较。

## **包含隐藏行列中的数据**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) 可以控制图表是否仅绘制隐藏工作表行列中的可见单元格。将其设为 `true` 只绘制可见单元格，设为 `false` 则同时包含隐藏单元格。此设置仅控制图表绘制；并不会隐藏或显示工作表行列。

[示例演示文稿](hidden-source-data.pptx) 的第一张幻灯片的第一个形状是柱形图。嵌入的工作表 `Sheet1` 包含源范围 `A1:C4`。第 3 行和 C 列被隐藏，但其单元格仍然包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 访问源单元格，并读取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) 检查其隐藏状态。此属性为只读。在本示例中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别输出 `False`、`True` 和 `True`。

对于本示例，在更改绘制设置后请刷新图表数据：使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 保留嵌入工作簿，并使用[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 重新加载。若要包含所有单元格，还需使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) 恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

示例保存了两个版本的演示文稿：一个仅包含可见的零售值（10 和 20），另一个包含全部六个值。下面的图片是重新打开保存后的演示文稿渲染的；两个文件均保留了各自的绘制设置。第 3 行和 C 列在两个嵌入工作簿中仍然隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) 控制缺失值的显示方式；它不影响是否包含隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/net/chart-series/#control-the-display-of-empty-cells) 获取示例。

## **检索图表的数据范围**

在更新已存在演示文稿中的工作簿数据之前，先检查源范围以确定每个图表使用了哪些工作表单元格。`[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/)` 方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识从 A1 到 D5（含）的单元格。美元符号表示绝对行列引用。

该方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，将抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)。

此示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印一条消息并继续检查下一个图表。

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

Aspose.Slides for .NET 提供了[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 和[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) 方法，允许读取和写入图表工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意** 图表数据必须以相同方式组织，或结构需与源类似。

本示例使用的演示文稿在第一张幻灯片的第一个形状上有一个图表。它将嵌入的工作簿读取到流中，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中，示例不保存演示文稿。

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

### **在修改工作簿后验证图表布局**

当用修改后的工作簿替换嵌入工作簿时，图表仍保留原有的系列和类别集合。此不匹配可能导致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) 以索引超出范围错误失败。请在将更新的工作簿写回图表之前先清除现有系列和类别。此示例使用第一张幻灯片的第一个形状（图表）。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

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

清除集合可在写回工作簿前移除陈旧的数据引用。写回前请为更新后的工作簿重新构建所需的系列和类别映射。

## **将工作簿单元格设为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。

本示例向现有演示文稿的第一张幻灯片添加一个带默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) 属性提供对图表工作簿中工作表的访问。本示例创建一个带默认数据的饼图，并将每个工作表名称打印到控制台。

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

本示例创建一个带默认数据的 3D 柱形图，并使用不同的数据源为两个系列名称赋值。第一个名称使用字符串文字，第二个名称使用工作表 0 上的单元格 C1。`[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)` 枚举用于为每个名称选择来源。示例保存了带有更新系列名称的演示文稿。

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

Aspose.Slides 不支持可以嵌入某些图表的 Excel 二进制工作簿（.xlsb）格式。可以结合使用[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) 上的[EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) 属性和[WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。本示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

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

使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) 和[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 将嵌入的图表工作簿导出为文件并将图表链接到该外部工作簿。

本示例创建一个带默认数据的饼图并导出其工作簿。它在分配外部工作簿作为图表数据源之前关闭输出流，然后保存已链接的演示文稿。

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

使用[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) 方法，可为图表指定外部工作簿作为数据源。该方法也可用于更新外部工作簿的路径（如果工作簿已被移动）。

虽然无法编辑存放在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了相对路径，它会自动转换为完整路径。

本示例使用的外部工作簿其工作表 `Sheet1` 包含 B1 单元格的系列名称、A2:A4 的类别名称以及 B2:B4 的数值。示例创建饼图，链接工作簿，并使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) 将 A1:B4 映射为一个系列和三个类别。随后保存带有链接图表的演示文稿。

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

`[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)` 方法的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `false` 进行分配。它保留了饼图的默认数据并在不加载不可用工作簿的情况下保存演示文稿。

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

本示例检查演示文稿第一张幻灯片的第一个形状，若该形状是链接到外部工作簿的图表，则将[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) 打印到控制台。随后保存演示文稿的副本。

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

可以像编辑内部工作簿一样编辑外部工作簿中的数据。如果无法加载外部工作簿，将抛出异常。

本示例使用第一张幻灯片的第一个形状（图表），该图表已链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100 并保存更新后的演示文稿。编辑单元格值可能会更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

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

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中的缓存数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)，配置其[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)，并将[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 设置为 `true`，然后打开演示文稿。

下面的 C# 示例恢复了第一张幻灯片上第一个形状（图表）所引用的不可用外部工作簿的数据。它通过[IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) 与[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。仅在接受使用缓存图表数据作为可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿在演示文稿上次更新后所做的更改。

## **常见问题解答**

**我能否确定特定图表是链接到外部工作簿还是嵌入工作簿？**

可以。图表具有[数据源类型](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) 和[外部工作簿路径](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)，如果源是外部工作簿，可以读取完整路径以确认使用的是外部文件。

**是否支持对外部工作簿的相对路径，如何存储？**

支持。指定相对路径后会自动转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但不支持直接使用 Aspose.Slides 编辑远程工作簿——只能用作数据源。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿会存储对外部文件的[链接](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。编辑基于单元格的图表数据也可能会更新链接的本地 XLSX 文件。如需保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/net/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表会存储自己的链接。如果它们都指向同一文件，更新该文件后下次加载数据时每个图表都会反映更改。