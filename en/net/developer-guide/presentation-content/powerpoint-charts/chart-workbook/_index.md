---
title: Manage Chart Workbooks in Presentations in .NET
linktitle: Chart Workbook
type: docs
weight: 70
url: /net/chart-workbook/
keywords:
- chart workbook
- chart data
- workbook cell
- data label
- worksheet
- data source
- external workbook
- external data
- chart cache
- workbook recovery
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Discover Aspose.Slides for .NET: effortlessly manage chart workbooks in PowerPoint and OpenDocument formats to streamline your presentation data."
---

## **Overview**

This article explains how to work with chart workbooks in Aspose.Slides. It shows how to read and write chart data through workbook streams, use workbook cells as chart data labels, access worksheet collections, and specify the data source type for chart values.

It also covers working with external workbooks as chart data sources. The examples demonstrate how to create and assign an external workbook, retrieve the path of an external workbook linked to a chart, and edit chart data when the workbook is available.

For workbook cells that represent missing data, see [Control the Display of Empty Cells](/slides/net/chart-series/) for the difference between an empty cell and zero, and a line-chart comparison of the available display modes.

## **Include Data from Hidden Rows and Columns**

Use [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) to control whether a chart plots data from hidden worksheet rows and columns. Set it to `true` to plot only visible cells, or `false` to include both visible and hidden cells. This setting controls chart plotting; it does not hide or unhide worksheet rows or columns.

Download [hidden-source-data.pptx](hidden-source-data.pptx) and place it in the working directory. Its first slide contains a column chart as the first shape. The embedded worksheet, `Sheet1`, contains the following source range, `A1:C4`. Row 3 and column C are hidden, but their cells still contain values.

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Access source cells through [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) and read [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) to inspect their hidden status. This property is read-only. In this file, B2 is visible, B3 belongs to the hidden row, and C2 belongs to the hidden column; the example prints `False`, `True`, and `True`, respectively.

For this example, refresh the chart data after changing the plotting setting: retain the embedded workbook with [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and reload it with [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). When including all cells, also use [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) to restore the complete range, including the hidden February category. Simply changing the flag is insufficient to refresh this sample's cached chart data and category labels.

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

        // Refresh the chart data from the embedded workbook.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Restore the complete source range, including hidden categories.
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

The example saves `hidden_cells_True.pptx` with only the visible Retail values (10 and 20), and `hidden_cells_False.pptx` with all six values. The images below were rendered from the saved presentations after reopening them; both files preserve their assigned plotting setting. Row 3 and column C remain hidden in both embedded workbooks.

| Only visible cells (`true`) | All cells (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

A hidden cell containing a value is different from an empty cell. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) controls how missing values are displayed; it does not include or exclude hidden source data. See [Control the Display of Empty Cells](/slides/net/chart-series/#control-the-display-of-empty-cells) for an example.

## **Read and Write Chart Data from a Workbook**

Aspose.Slides for .NET provides the [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This example opens `chart.pptx`, which must contain a chart as the first shape on its first slide. It reads the embedded workbook into a stream, clears the existing series and categories, and writes the same workbook back. The changes remain in memory; the example does not save the presentation.

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

### **Validate Chart Layout After Workbook Modification**

When you replace an embedded workbook with a modified one, the chart retains its original series and category collections. This mismatch can cause [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) to fail with an index-out-of-range error. Clear the existing series and categories before writing the updated workbook back to the chart. This example requires `chart.pptx` with a chart as the first shape on its first slide. The comment marks where workbook editing would occur; the runnable example writes the original workbook back and validates the layout in memory.

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

    // Modify the workbook stream here, for example, using Aspose.Cells.

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

Clearing the collections removes stale data references before the workbook is written back. Rebuild any required series and category mappings for the updated workbook before using the chart.

## **Set a Workbook Cell as a Chart Data Label**

You can use text from workbook cells as chart data labels. The following steps show how to link the labels in a bubble chart to cells in its data workbook.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Access the first slide by its zero-based index.
1. Add a bubble chart with default data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This example opens `chart2.pptx`, which must contain at least one slide, and adds a bubble chart with default data. It uses cells A10:A12 on worksheet 0 for the first three labels in the first series, enables labels from cells, and saves the result to `resultchart.pptx`.

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

## **Manage Worksheets**

The [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) property provides access to the worksheets in a chart workbook. This example creates a pie chart with default data and prints each worksheet name to the console.

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

## **Specify the Data Source Type**

This example creates a 3D column chart with default data and sets two series names using different data sources. The first name uses a string literal; the second uses cell C1 on worksheet 0. The [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) enumeration selects the source for each name. The result is saved to `pres.pptx`.

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides does not support the Excel binary workbook (.xlsb) format that can be embedded in some charts. You can use the [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) property on [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) together with the [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) enumeration to detect unsupported formats and skip those charts. This example inspects the shapes on the first slide of `sample.pptx`, skips non-chart shapes, and prints a diagnostic message for each chart with an embedded .xlsb workbook.

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

    // Read or modify supported chart workbook data here.
}
```

## **External Workbook**

Aspose.Slides supports using external workbooks as a data source for charts.

### **Create an External Workbook**

Use [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) and [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) to export an embedded chart workbook to a file and link the chart to that external workbook.

This example creates a pie chart with default data, writes its workbook to `externalWorkbook1.xlsx`, and closes the output stream before assigning the file as the chart data source. It saves the linked presentation to `externalWorkbook.pptx`.

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


### **Set an External Workbook**

Using the [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This example requires `externalWorkbook.xlsx` in the working directory. Its worksheet named `Sheet1` must contain a series name in B1, category names in A2:A4, and numeric values in B2:B4. The example creates a pie chart, links the workbook, and uses [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) to map A1:B4 to one series and three categories. It saves the result to `Presentation_with_externalWorkbook.pptx`.

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

The `updateChartData` parameter of [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) controls whether the workbook is loaded.

* When `updateChartData` is `false`, only the workbook path is updated. The chart data is not loaded or updated from the target workbook, so the workbook can be unavailable.
* When `updateChartData` is `true`, the chart data is updated from the target workbook.

The following example assigns a placeholder URL with `updateChartData` set to `false`. It retains the pie chart's default data and saves the presentation without loading the unavailable workbook.

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

### **Get the External Data Source Workbook Path of a Chart**

To identify the workbook linked to a chart, first check whether the chart uses an external data source. If it does, you can retrieve the workbook path by following these steps.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Access the first slide by its zero-based index.
1. Check that the first shape is a chart.
1. Read the chart data source type.
1. If the source is an external workbook, read its path.

This example opens `externalWorkbook.pptx`, created in the earlier example, and inspects the first shape on the first slide. If it is a chart linked to an external workbook, the example prints [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) to the console. It then saves a copy of the presentation to `Result.pptx`.

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

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This example requires `presentation.pptx` with a chart as the first shape on the first slide and an accessible external workbook. It sets the cell-backed value of the first data point in the first series to 100 and saves the presentation to `presentation_out.pptx`. Editing cell values can update the linked external XLSX file, so use a copy if you need to preserve the original workbook.

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

### **Recover a Workbook from the Chart Cache**

If a chart uses an external workbook that is missing or unavailable, Aspose.Slides can reconstruct the chart workbook from the data cached in the presentation. Create [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), configure its [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), and set [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) to `true` before opening the presentation.

The following C# example opens `presentation.pptx`, whose first shape on the first slide must be a chart referencing an unavailable external workbook, and accesses the recovered data through [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) and [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Read or modify the recovered workbook data here.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

If the external workbook is unavailable and recovery is disabled, Aspose.Slides throws an [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Enable recovery only when using the cached chart data is an acceptable fallback, because the cache may not contain changes made to the external workbook after the presentation was last updated.

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) and a [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. The presentation stores the absolute path in the PPTX file, so moving the workbook may require updating the link.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

The presentation stores a [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Editing cell-backed chart data can also update the linked local XLSX file. Use a copy of the workbook if the original must remain unchanged.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](https://reference.aspose.com/cells/net/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.
