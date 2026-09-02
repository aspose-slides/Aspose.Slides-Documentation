---
title: Apply Chart Worksheet Formulas in Presentations in .NET
linktitle: Worksheet Formulas
type: docs
weight: 70
url: /net/chart-worksheet-formulas/
keywords:
- chart spreadsheet
- chart worksheet
- chart formula
- worksheet formula
- spreadsheet formula
- chart data workbook
- formula calculation
- preferred culture
- culture-specific formula
- DBCS
- logical constant
- numerical constant
- string constant
- error constant
- arithmetic operator
- comparison operator
- A1 style
- R1C1 style
- predefined function
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Apply Excel-style formulas in Aspose.Slides for .NET chart worksheets, recalculate values, and use the results in PowerPoint charts."
---

## **Overview**

PowerPoint charts usually store their source data in an embedded worksheet. In Aspose.Slides for .NET, you can access that worksheet through the chart data workbook, write input values, assign formulas to cells, calculate supported formulas, and use the calculated cells as chart data.

This article explains the complete formula workflow: create a chart, populate its worksheet, assign A1-style or R1C1-style formulas, recalculate them, read the calculated values, connect those cells to a chart series, and save the presentation. It also describes the supported formula syntax, the built-in function subset, cached values, unsupported formulas, and spreadsheet-specific errors.

## **Chart Worksheets and Formulas**

A chart worksheet contains the categories, series names, and values used by a chart. In PowerPoint, you can inspect the worksheet by opening the chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

In Aspose.Slides, the worksheet is exposed through the [chart data workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Use the [Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/formula/) property for A1-style formulas and the [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/r1c1formula/) property for R1C1-style formulas. After changing input cells or formulas, call [CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) to recalculate supported formulas and update the corresponding cell values.

A calculated cell still exposes its result through the [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) property. This is important when you need to inspect a formula result in code or use the cell as a chart data point.

## **Create a Chart and Calculate Worksheet Formulas**

The following example demonstrates an end-to-end workflow. It creates a clustered column chart, clears the sample data, writes quarterly revenue and expense values, calculates profit with formulas, reads the results, uses the calculated cells as chart values, and saves the presentation.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

The chart data points reference `D2:D4`, so the chart uses the calculated profit values. There is no separate chart-refresh call in this workflow: recalculate the workbook first, then use or save the chart data that points to the calculated cells.

## **Use A1-Style Formulas**

A1 notation identifies columns with letters and rows with numbers. Assign A1-style expressions through [IChartDataCell.Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Common A1 reference forms are:

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relative references can change when a formula is moved or copied by a spreadsheet application. Absolute references keep both coordinates fixed, while mixed references fix only a row or a column.

## **Use R1C1-Style Formulas**

R1C1 notation identifies both rows and columns numerically. Relative references use offsets in square brackets. Assign this syntax through [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Common R1C1 reference forms are:

| Reference | Relative | Absolute | Mixed |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

For example, in cell `D2`, `RC[-2]` means the cell in the same row two columns to the left (`B2`).

## **Formula Constants and Operators**

The built-in formula evaluator supports logical values, numeric literals, strings, spreadsheet error values, arithmetic operators, and comparison operators.

### **Constants and Literals**

| Type | Examples | Notes |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Can be used directly in logical expressions such as `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Common and scientific notation are supported. |
| String | `"abc"`, `"2/3/2020 12:00"` | Text literals are enclosed in double quotation marks inside the formula. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | A valid formula can evaluate to a spreadsheet error value instead of a normal result. |

This example uses several constant types:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // False
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Arithmetic Operators**

| Operator | Meaning | Example |
|---|---|---|
| `+` | Addition or unary plus | `2+3` |
| `-` | Subtraction or negation | `2-3`, `-3` |
| `*` | Multiplication | `2*3` |
| `/` | Division | `2/3` |
| `%` | Percent | `30%` |
| `^` | Exponentiation | `2^3` |

Use parentheses to make evaluation order explicit, for example `(A2+B2)*C2`.

### **Comparison Operators**

Comparison expressions return logical values.

| Operator | Meaning | Example |
|---|---|---|
| `=` | Equal to | `A2=3` |
| `<>` | Not equal to | `A2<>3` |
| `>` | Greater than | `A2>3` |
| `>=` | Greater than or equal to | `A2>=3` |
| `<` | Less than | `A2<3` |
| `<=` | Less than or equal to | `A2<=3` |

## **Supported Predefined Functions**

Aspose.Slides includes a built-in formula evaluator for chart worksheets, but it is not a complete Excel calculation engine. The documented function set is limited to the functions below. Do not assume that an arbitrary Excel function can be recalculated by [CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Function | Purpose or supported form | Example |
|---|---|---|
| `ABS` | Absolute value | `ABS(A2)` |
| `AVERAGE` | Arithmetic mean | `AVERAGE(B2:B5)` |
| `CEILING` | Round a number upward to a multiple | `CEILING(A2,5)` |
| `CHOOSE` | Select a value by index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Join text values | `CONCAT(A2,B2)` |
| `CONCATENATE` | Join text values | `CONCATENATE(A2," ",B2)` |
| `DATE` | Create a date value using the 1900 date system | `DATE(2026,8,19)` |
| `DAYS` | Return the number of days between dates | `DAYS(B2,A2)` |
| `FIND` | Find one text value inside another | `FIND("-",A2)` |
| `FINDB` | Byte-oriented text search | `FINDB("a",A2)` |
| `IF` | Conditional result | `IF(A2>0,A2,0)` |
| `INDEX` | Reference form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum value | `MAX(B2:B5)` |
| `SUM` | Sum values | `SUM(B2:B5)` |
| `VLOOKUP` | Vertical lookup | `VLOOKUP(A2,B2:D10,3,FALSE)` |

The restrictions shown in the table are significant: `INDEX` is documented in reference form, while `LOOKUP` and `MATCH` are documented in their vector forms. `DATE` uses the 1900 date system. Features and functions not listed here should be treated as unsupported by the Aspose.Slides formula evaluator unless they are documented separately.

## **Calculate Formulas with a Preferred Culture**

Some chart workbook functions interpret text according to culture-specific rules. This is especially important for functions intended for languages that use double-byte character sets (DBCS). To calculate such formulas correctly, create [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), set [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/preferredculture/) through [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), and then load the presentation.

The following example selects the Japanese culture, opens a presentation with the configured load options, and calls [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) for every chart workbook:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

The preferred culture is part of the presentation loading configuration, so specify it before creating the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance. Use the culture expected by the workbook formulas; for example, use `ja-JP` for formulas that should follow Japanese DBCS calculation rules.

## **Recalculation and Cached Values**

Spreadsheet files commonly store both a formula and its last calculated value. Aspose.Slides can therefore read a cached value from [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) when a presentation is loaded and the relevant chart data has not been changed.

After changing input cells or formulas, do not rely on an old cached result. Call [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) before reading calculated values or saving chart data that depends on them.

For formulas outside the supported subset, Aspose.Slides may be unable to parse the formula or establish its dependencies. If the workbook has been modified, the previous cached value can no longer be considered reliable. In that situation, reading the value of a cell with unsupported data can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

If your chart depends on Excel functions that Aspose.Slides does not evaluate, calculate those formulas with a spreadsheet engine that supports them and write the resulting values back to the chart workbook. Do not replace unsupported formulas with guessed values.

## **Handle Formula Errors**

There are two different kinds of problems to distinguish.

A formula can be valid but produce a spreadsheet error result such as `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, or `#VALUE!`. In this case, the error token is a cell result and can be returned through `Value`.

A formula can also fail at the parsing, reference, dependency, or supported-data level. Aspose.Slides provides spreadsheet-specific exceptions for these cases: [CellInvalidFormulaException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), and [CellUnsupportedDataException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

When formulas come from templates or user input, handle these exceptions around recalculation and value access:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Practical Limitations**

The formula support in chart worksheets is intended for a defined subset of spreadsheet calculations, not for full Excel compatibility. Keep these constraints in mind when designing a reporting workflow:

- Use only the documented constants, operators, references, and functions when you need Aspose.Slides to recalculate formulas.
- Recalculate after changing cells that formula results depend on.
- Treat cached values from loaded presentations as snapshots, not as a replacement for recalculation after edits.
- Test formulas from existing templates before relying on their calculated values, especially when they use functions outside the documented list.
- For formulas that require a full spreadsheet calculation engine, calculate them externally and then update the chart workbook with the resulting values.

## **FAQ**

**What is the difference between `Formula` and `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/formula/) stores an A1-style expression such as `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/r1c1formula/) stores an R1C1-style expression such as `RC[-2]-RC[-1]`. Use the notation that best matches how you generate or copy formulas.

**Do I need to read the cell itself or its value after calculation?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) returns an `IChartDataCell`. To obtain the calculated result, read that cell's [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) property after recalculation.

**When should I call `CalculateFormulas`?**

Call [CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) after changing input values or formulas and before you depend on the calculated results. This updates the values of formulas that the built-in evaluator supports.

**Does Aspose.Slides support every Excel function?**

No. The built-in evaluator supports a documented subset of functions. Functions outside that subset should not be assumed to recalculate correctly. If full Excel formula compatibility is required, perform the calculation with an appropriate spreadsheet engine and write the final values to the chart workbook.

**What happens if a loaded presentation contains an unsupported formula?**

If the chart data has not changed, the workbook may still contain a previously calculated cached value. After related data is modified, that cached value may no longer be valid. Accessing a cell whose formula cannot be handled can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Are formula error values the same as .NET exceptions?**

No. A result such as `#DIV/0!` is a spreadsheet value produced by a valid calculation. Exceptions such as [CellInvalidFormulaException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) or [CellCircularReferenceException](https://reference.aspose.com/slides/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indicate that the formula cannot be processed normally.

**Does a chart update automatically when a formula cell changes?**

A chart series can reference workbook cells. Recalculate the workbook first, then save or render the presentation. If the chart data points reference the calculated cells, the chart uses those updated cell values; no separate chart-refresh method is required for this workflow.

**Can charts use an external Excel workbook?**

Yes, chart data can be configured to use an external workbook through the chart data API. However, the formula calculation workflow described in this article concerns the chart data workbook and the formula subset evaluated by Aspose.Slides. Do not assume that [CalculateFormulas](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) provides full recalculation of arbitrary formulas in an external XLSX file.

**Can I use formulas that reference another worksheet or workbook?**

Excel-style references may exist in chart workbooks, but formula evaluation is limited by the supported parser and function set. If a cross-sheet or external reference is essential, validate that exact formula with your target Aspose.Slides version. For workflows that require broad Excel reference compatibility, calculate the workbook externally and write the resolved values back to the chart data.

**Should formula strings start with `=`?**

The Aspose.Slides API examples assign expressions such as `B2-C2` or `SUM(B2:B5)` without a leading `=`. Using that form keeps generated formulas consistent with the documented API examples.
