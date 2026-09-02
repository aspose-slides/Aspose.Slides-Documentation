---
title: Apply Chart Worksheet Formulas in Presentations on Android
linktitle: Worksheet Formulas
type: docs
weight: 70
url: /androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Apply Excel-style formulas in Aspose.Slides for Android via Java chart worksheets, recalculate values, and use the results in PowerPoint charts."
---

## **Overview**

PowerPoint charts usually store their source data in an embedded worksheet. In Aspose.Slides for Android via Java, you can access that worksheet through the chart data workbook, write input values, assign formulas to cells, calculate supported formulas, and use the calculated cells as chart data.

This article explains the complete formula workflow: create a chart, populate its worksheet, assign A1-style or R1C1-style formulas, recalculate them, read the calculated values, connect those cells to a chart series, and save the presentation. It also describes the supported formula syntax, the built-in function subset, cached values, unsupported formulas, and spreadsheet-specific errors.

## **Chart Worksheets and Formulas**

A chart worksheet contains the categories, series names, and values used by a chart. In PowerPoint, you can inspect the worksheet by opening the chart data editor:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

In Aspose.Slides, the worksheet is exposed through the [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) interface. Use [IChartDataCell.setFormula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) for A1-style formulas and [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) for R1C1-style formulas. After changing input cells or formulas, call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) to recalculate supported formulas and update the corresponding cell values.

A calculated cell still exposes its result through [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--). This is important when you need to inspect a formula result in code or use the cell as a chart data point.

## **Create a Chart and Calculate Worksheet Formulas**

The following example demonstrates an end-to-end workflow. It creates a clustered column chart, clears the sample data, writes quarterly revenue and expense values, calculates profit with formulas, reads the results, uses the calculated cells as chart values, and saves the presentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The chart data points reference `D2:D4`, so the chart uses the calculated profit values. There is no separate chart-refresh call in this workflow: recalculate the workbook first, then use or save the chart data that points to the calculated cells.

## **Use A1-Style Formulas**

A1 notation identifies columns with letters and rows with numbers. Assign A1-style expressions through [IChartDataCell.setFormula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
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

R1C1 notation identifies both rows and columns numerically. Relative references use offsets in square brackets. Assign this syntax through [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
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

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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

Aspose.Slides includes a built-in formula evaluator for chart worksheets, but it is not a complete Excel calculation engine. The documented function set is limited to the functions below. Do not assume that an arbitrary Excel function can be recalculated by [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

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

Some chart workbook functions interpret text according to culture-specific rules. This is especially important for functions intended for languages that use double-byte character sets (DBCS). To calculate such formulas correctly, create [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), set the preferred culture with [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), assign the spreadsheet options through [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), and then load the presentation.

The following example selects the Japanese culture, opens a presentation with the configured load options, and calls [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) for every chart workbook:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

The preferred culture is part of the presentation loading configuration, so specify it before creating the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) instance. Use the culture expected by the workbook formulas; for example, use `ja-JP` for formulas that should follow Japanese DBCS calculation rules.

## **Recalculation and Cached Values**

Spreadsheet files commonly store both a formula and its last calculated value. Aspose.Slides can therefore read a cached value from [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) when a presentation is loaded and the relevant chart data has not been changed.

After changing input cells or formulas, do not rely on an old cached result. Call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) before reading calculated values or saving chart data that depends on them.

For formulas outside the supported subset, Aspose.Slides may be unable to parse the formula or establish its dependencies. If the workbook has been modified, the previous cached value can no longer be considered reliable. In that situation, reading the value of a cell with unsupported data can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellunsupporteddataexception/).

If your chart depends on Excel functions that Aspose.Slides does not evaluate, calculate those formulas with a spreadsheet engine that supports them and write the resulting values back to the chart workbook. Do not replace unsupported formulas with guessed values.

## **Handle Formula Errors**

There are two different kinds of problems to distinguish.

A formula can be valid but produce a spreadsheet error result such as `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, or `#VALUE!`. In this case, the error token is a cell result and can be returned through [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

A formula can also fail at the parsing, reference, dependency, or supported-data level. Aspose.Slides provides spreadsheet-specific exceptions for these cases: [CellInvalidFormulaException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellcircularreferenceexception/), and [CellUnsupportedDataException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellunsupporteddataexception/).

When formulas come from templates or user input, handle these exceptions around recalculation and value access:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
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

**What is the difference between [IChartDataCell.setFormula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) and [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) stores an A1-style expression such as `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) stores an R1C1-style expression such as `RC[-2]-RC[-1]`. Use the notation that best matches how you generate or copy formulas.

**Do I need to read the cell itself or its value after calculation?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) returns an [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/). To obtain the calculated result, call that cell's [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) method after recalculation.

**When should I call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Call [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) after changing input values or formulas and before you depend on the calculated results. This updates the values of formulas that the built-in evaluator supports.

**Does Aspose.Slides support every Excel function?**

No. The built-in evaluator supports a documented subset of functions. Functions outside that subset should not be assumed to recalculate correctly. If full Excel formula compatibility is required, perform the calculation with an appropriate spreadsheet engine and write the final values to the chart workbook.

**What happens if a loaded presentation contains an unsupported formula?**

If the chart data has not changed, the workbook may still contain a previously calculated cached value. After related data is modified, that cached value may no longer be valid. Accessing a cell whose formula cannot be handled can raise [CellUnsupportedDataException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Are formula error values the same as Java exceptions?**

No. A result such as `#DIV/0!` is a spreadsheet value produced by a valid calculation. Exceptions such as [CellInvalidFormulaException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellinvalidformulaexception/) or [CellCircularReferenceException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellcircularreferenceexception/) indicate that the formula cannot be processed normally.

**Does a chart update automatically when a formula cell changes?**

A chart series can reference workbook cells. Recalculate the workbook first, then save or render the presentation. If the chart data points reference the calculated cells, the chart uses those updated cell values; no separate chart-refresh method is required for this workflow.

**Can charts use an external Excel workbook?**

Yes, chart data can be configured to use an external workbook through the chart data API. However, the formula calculation workflow described in this article concerns the chart data workbook and the formula subset evaluated by Aspose.Slides. Do not assume that [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) provides full recalculation of arbitrary formulas in an external XLSX file.

**Can I use formulas that reference another worksheet or workbook?**

Excel-style references may exist in chart workbooks, but formula evaluation is limited by the supported parser and function set. If a cross-sheet or external reference is essential, validate that exact formula with your target Aspose.Slides version. For workflows that require broad Excel reference compatibility, calculate the workbook externally and write the resolved values back to the chart data.

**Should formula strings start with `=`?**

The Aspose.Slides API examples assign expressions such as `B2-C2` or `SUM(B2:B5)` without a leading `=`. Using that form keeps generated formulas consistent with the documented API examples.
