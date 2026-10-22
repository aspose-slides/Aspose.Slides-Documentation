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
description: "发现 Aspose.Slides for .NET：轻松管理 PowerPoint 和 OpenDocument 格式的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文解释了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据，使用工作簿单元格作为图表数据标签，访问工作表集合，以及为图表值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的方式。示例演示了如何创建并分配外部工作簿，检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/net/chart-series/)以了解空单元格与零之间的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/)来控制图表是否绘制隐藏工作表行和列中的数据。将其设为 `true` 仅绘制可见单元格，设为 `false` 则包括可见和隐藏单元格。此设置仅控制图表绘制，不会隐藏或显示工作表行或列。

[示例演示文稿](hidden-source-data.pptx)的第一张幻灯片的第一个形状是一个柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隐藏行) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问源单元格，并读取[IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/)以检查其隐藏状态。此属性为只读。在本文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True` 和 `True`。

对于本示例，在更改绘制设置后请刷新图表数据：使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)保留嵌入的工作簿，然后使用[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)重新加载它。包括所有单元格时，还需使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

示例保存了两个版本的演示文稿：一个仅包含可见的零售值（10 和 20），另一个包含全部六个值。下图的图像是从重新打开后保存的演示文稿渲染的；两个文件都保留了各自的绘制设置。第 3 行和 C 列在两个嵌入工作簿中仍然隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含值的隐藏单元格不同于空单元格。[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) 控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/net/chart-series/#control-the-display-of-empty-cells)获取示例。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，检查源范围以确定每个图表使用的工作表单元格。方法[IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/)返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名称，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识包括 A1 到 D5 的单元格。美元符号表示绝对行列引用。

该方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，则抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)。

此示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印信息并继续下一个图表。

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

Aspose.Slides for .NET 提供了[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)方法，允许读取和写入图表数据工作簿（其中包含使用 Aspose.Cells 编辑的图表数据）。**注意** 图表数据必须以相同方式组织或具有类似的结构。

此示例使用第一张幻灯片第一个形状的图表的演示文稿。它将嵌入的工作簿读取到流中，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中；示例未保存演示文稿。

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

### **验证工作簿修改后图表布局**

当使用已修改的工作簿替换嵌入工作簿时，图表保留其原始的系列和类别集合。此不匹配可能导致[IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)因索引超出范围而失败。请在将更新的工作簿写回图表之前清除现有系列和类别。此示例使用第一张幻灯片第一个形状的图表。注释标记了工作簿编辑的位置；可运行示例将原始工作簿写回并在内存中验证布局。

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

    // 在此修改工作簿流，例如，使用 Aspose.Cells。

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

清除集合可在写回工作簿之前移除陈旧的数据引用。对更新后的工作簿重新构建所需的系列和类别映射后再使用图表。

## **为工作簿单元格设置自定义数字格式**

使用[ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/)控制数值在图表嵌入工作簿中的显示方式。例如，报告可能需要将转化率显示为四位小数的百分比，将系数显示为五位小数。保持两者为数值，以便进行计算和图表绘制。

数字格式仅更改显示，不更改存储的值。格式 `0.0000%` 将 `0.125` 显示为 `12.5000%`；它不会将存储的数字替换为 `12.5`。同理，`0.00000` 将 `0.1234567` 显示为 `0.12346`，而不对存储值进行四舍五入。如果自定义格式为空字符串 (`""`)，则使用[PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/)。

以下示例创建柱形图并通过[ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/)访问其单元格。在工作表 0 上，B2 包含转化率，C2 包含系数。两个单元格都提供图表值。示例还启用了链接到源格式的数值标签。

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

工作簿单元格格式独立于直接在图表坐标轴或数据标签上设置的格式。在本例中，每个标签显示其源单元格的值，因为[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)已启用，并且因为[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 为 `true`，所以遵循源数字格式。保存并重新打开演示文稿后，标签显示 `12.5000%` 和 `0.12346`，如下所示。纵轴使用其自己的[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`，且[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) 设置为 `false`。

若要独立格式化数据标签，请将其源链接标志设为 `false` 并分配其[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)。这不会更改工作簿单元格的格式。例如，独立标签格式 `0.00` 将第一个值显示为 `0.13`，而 B2 仍显示 `12.5000%`。请参阅[图表数据标签](/slides/zh/net/chart-data-label/#set-percentage-sign-with-chart-data-labels)了解直接标签格式化。

下图是重新打开后从保存的演示文稿渲染的图像：

![带有源链接标签显示 12.5000% 和 0.12346，以及独立格式化数值坐标轴的柱形图。](custom-cell-formats.png)

## **将工作簿单元格设置为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。

此示例向现有演示文稿的第一张幻灯片添加一个默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列的前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

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

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/)属性提供对图表工作簿中工作表的访问。此示例创建一个默认数据的饼图并将每个工作表名称打印到控制台。

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

系列点值也可以直接存储为数值文字。请参阅[使用数值文字设置系列值](/slides/zh/net/chart-series/#set-series-values-using-numeric-literals)获取完整示例，该示例演示了保存和读取方式。点值的数据源类型与图表的内部或外部工作簿配置分离；使用数值文字本身并不会删除嵌入的工作簿。

此示例创建一个默认数据的 3D 柱形图，并使用不同的数据源设置两个系列名称。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) 枚举为每个名称选择来源。示例保存了包含更新系列名称的演示文稿。

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

Aspose.Slides 不支持可嵌入某些图表的 Excel 二进制工作簿（.xlsb）格式。可以使用[IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) 上的[EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/)属性结合[WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。此示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

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

使用[ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/)和[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)将嵌入图表的工作簿导出为文件，并将图表链接到该外部工作簿。

此示例创建一个默认数据的饼图并导出其工作簿。它在将外部工作簿分配为图表数据源之前关闭输出流，然后保存已链接的演示文稿。

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

使用[SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/)方法，可以为图表指定外部工作簿作为其数据源。此方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然不能编辑存储在远程位置或资源中的工作簿数据，但仍可将这些工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

此示例使用一个外部工作簿，其工作表 `Sheet1` 在 B1 中包含系列名称，在 A2:A4 中包含类别名称，在 B2:B4 中包含数值。示例创建饼图，链接工作簿，并使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/)将 A1:B4 映射为一个系列和三个类别。它保存了带有链接图表的演示文稿。

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

以下示例将占位符 URL 与 `updateChartData` 设置为 `false` 进行分配。它保留饼图的默认数据并在未加载不可用工作簿的情况下保存演示文稿。

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

此示例检查演示文稿第一张幻灯片上第一个形状是否为链接外部工作簿的图表。如果是，则将[ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/)打印到控制台，然后保存演示文稿的副本。

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

可以像编辑内部工作簿内容一样编辑外部工作簿的数据。当外部工作簿无法加载时，会抛出异常。

此示例使用第一张幻灯片上第一个形状的图表，该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格支持值设为 100 并保存更新后的演示文稿。编辑单元格值会更新链接的外部 XLSX 文件，若需要保留原始工作簿，请使用副本。

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

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)，配置其[SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/)，并在打开演示文稿前将[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) 设置为 `true`。

下面的 C# 示例恢复了第一张幻灯片上第一个形状的图表的工作簿数据，该图表引用了不可用的外部工作簿。它通过[IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) 和[IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) 访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 会抛出[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)。仅在接受使用缓存图表数据作为可接受后备时才启用恢复，因为缓存可能不包含对外部工作簿在最后一次更新演示文稿后所做的更改。

## **常见问题解答**

**我能确定特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/)和[external workbook path](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径，如何存储？**

支持。如果指定相对路径，它会自动转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——只能用作源。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

演示文稿存储对外部文件的[link](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/)。编辑单元格支持的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护，该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/net/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储自己的链接。如果它们指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。