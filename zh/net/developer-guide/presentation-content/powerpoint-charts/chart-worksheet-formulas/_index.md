---
title: 在 .NET 演示文稿中应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/net/chart-worksheet-formulas/
keywords:
- 图表电子表格
- 图表工作表
- 图表公式
- 工作表公式
- 电子表格公式
- 图表数据工作簿
- 公式计算
- 首选文化
- 文化特定公式
- DBCS
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式
- R1C1 样式
- 预定义函数
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 图表工作表中使用 Excel 样式公式，重新计算数值，并在 PowerPoint 图表中使用结果。"
---
## **概述**

PowerPoint 图表通常将源数据存储在嵌入的工作表中。在 Aspose.Slides for .NET 中，您可以通过图表数据工作簿访问该工作表，写入输入值，为单元格分配公式，计算受支持的公式，并将计算后的单元格用作图表数据。

本文解释完整的公式工作流：创建图表，填充其工作表，分配 A1 样式或 R1C1 样式公式，重新计算它们，读取计算值，将这些单元格连接到图表系列，并保存演示文稿。它还描述了受支持的公式语法、内置函数子集、缓存值、不受支持的公式以及电子表格特定错误。

## **图表工作表和公式**

图表工作表包含图表使用的类别、系列名称和数值。在 PowerPoint 中，您可以通过打开图表数据编辑器来检查工作表：

![PowerPoint 图表打开其嵌入工作表，显示类别和系列数据](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表通过[图表数据工作簿](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/)公开。使用[Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/formula/)属性处理 A1 样式公式，使用[R1C1Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/r1c1formula/)属性处理 R1C1 样式公式。更改输入单元格或公式后，调用[CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)以重新计算受支持的公式并更新相应的单元格值。

计算后的单元格仍通过[Value](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/value/)属性公开其结果。这在您需要在代码中检查公式结果或将单元格用作图表数据点时尤为重要。

## **创建图表并计算工作表公式**

以下示例演示端到端工作流。它创建一个簇状柱形图，清除示例数据，写入季度收入和支出值，通过公式计算利润，读取结果，将计算后的单元格用作图表值，并保存演示文稿。

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

图表数据点引用 `D2:D4`，因此图表使用计算后的利润值。在此工作流中没有单独的图表刷新调用：先重新计算工作簿，然后使用或保存指向计算单元格的图表数据。

## **使用 A1 样式公式**

A1 表示法使用字母标识列，使用数字标识行。通过[IChartDataCell.Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/formula/)分配 A1 样式表达式。

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

常见的 A1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 范围 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相对引用在公式被电子表格应用程序移动或复制时会更改。绝对引用固定两个坐标，混合引用仅固定行或列。

## **使用 R1C1 样式公式**

R1C1 表示法使用数字标识行和列。相对引用使用方括号中的偏移量。通过[IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/r1c1formula/)分配此语法。

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

常见的 R1C1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 范围 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在单元格 `D2` 中，`RC[-2]` 表示同一行左侧两列的单元格 (`B2`)。

## **公式常量和运算符**

内置公式求值器支持逻辑值、数值文字、字符串、电子表格错误值、算术运算符和比较运算符。

### **常量和文字**

| 类型 | 示例 | 备注 |
|---|---|---|
| 逻辑 | `TRUE`, `FALSE` | 可以直接在逻辑表达式中使用，如 `A2=TRUE`。 |
| 数值 | `1`, `0.5`, `.3`, `1E-2` | 支持普通和科学计数法表示。 |
| 字符串 | `"abc"`, `"2/3/2020 12:00"` | 文本文字在公式中使用双引号括起。 |
| 错误结果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可能评估为电子表格错误值而非普通结果。 |

以下示例使用了多种常量类型：

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

var logicalValue = workbook.GetCell(0, "B2").Value; // 假
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **算术运算符**

| 运算符 | 含义 | 示例 |
|---|---|---|
| `+` | 加法或一元加号 | `2+3` |
| `-` | 减法或取负 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 幂运算 | `2^3` |

使用括号明确求值顺序，例如 `(A2+B2)*C2`。

### **比较运算符**

比较表达式返回逻辑值。

| 运算符 | 含义 | 示例 |
|---|---|---|
| `=` | 等于 | `A2=3` |
| `<>` | 不等于 | `A2<>3` |
| `>` | 大于 | `A2>3` |
| `>=` | 大于等于 | `A2>=3` |
| `<` | 小于 | `A2<3` |
| `<=` | 小于等于 | `A2<=3` |

## **受支持的预定义函数**

Aspose.Slides 为图表工作表提供内置公式求值器，但它不是完整的 Excel 计算引擎。文档中列出的函数集合有限。不要假设任意 Excel 函数都可以通过[CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)重新计算。

| 函数 | 用途或受支持的形式 | 示例 |
|---|---|---|
| `ABS` | 绝对值 | `ABS(A2)` |
| `AVERAGE` | 算术平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整到指定倍数 | `CEILING(A2,5)` |
| `CHOOSE` | 按索引选择值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合并文本值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合并文本值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系统创建日期值 | `DATE(2026,8,19)` |
| `DAYS` | 返回两个日期之间的天数 | `DAYS(B2,A2)` |
| `FIND` | 在另一个文本中查找文本 | `FIND("-",A2)` |
| `FINDB` | 按字节搜索文本 | `FINDB("a",A2)` |
| `IF` | 条件结果 | `IF(A2>0,A2,0)` |
| `INDEX` | 引用形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 求和 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表中显示的限制很重要：`INDEX` 以引用形式记录，而 `LOOKUP` 和 `MATCH` 以向量形式记录。`DATE` 使用 1900 日期系统。未在此列出的功能和函数应视为 Aspose.Slides 公式求值器不支持，除非另有文档说明。

## **使用首选文化计算公式**

某些工作簿函数会根据文化特定规则解释文本。这在处理使用双字节字符集（DBCS）语言的函数时尤为重要。要正确计算此类公式，请创建[LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/)，通过[LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/spreadsheetoptions/)设置[ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/zh/net/aspose.slides/ispreadsheetoptions/preferredculture/)，然后加载演示文稿。

以下示例选择日语文化，使用配置好的加载选项打开演示文稿，并为每个图表工作簿调用[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)：

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

首选文化是演示文稿加载配置的一部分，因此应在创建[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)实例之前指定。使用工作簿公式所期望的文化，例如对应日语 DBCS 计算规则的 `ja-JP`。

## **重新计算和缓存值**

电子表格文件通常同时存储公式及其最近一次计算的值。Aspose.Slides 因此可以在加载演示文稿且相关图表数据未更改时，从[IChartDataCell.Value](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/value/)读取缓存值。

更改输入单元格或公式后，读取计算值或保存依赖这些值的图表数据之前，请调用[IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。

对于超出受支持子集的公式，Aspose.Slides 可能无法解析公式或确定其依赖关系。如果工作簿已被修改，先前的缓存值不再可靠。在这种情况下，读取包含不受支持数据的单元格可能会抛出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

如果您的图表依赖于 Aspose.Slides 未评估的 Excel 函数，请使用支持这些函数的电子表格引擎先计算公式，然后将结果写回图表工作簿。不要用猜测的数值替代不受支持的公式。

## **处理公式错误**

需要区分两类问题。

公式可以是有效的，但产生诸如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` 的电子表格错误结果。在这种情况下，错误标记是单元格结果，可以通过 `Value` 返回。

公式也可能在解析、引用、依赖或受支持数据层面失败。Aspose.Slides 为这些情况提供特定的电子表格异常：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

当公式来自模板或用户输入时，请在重新计算和访问值时捕获这些异常：

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

## **实际限制**

图表工作表中的公式支持旨在满足一组定义好的电子表格计算子集，而非完整的 Excel 兼容性。在设计报表工作流时请牢记以下约束：

- 仅在需要 Aspose.Slides 重新计算公式时使用文档中列出的常量、运算符、引用和函数。
- 在更改公式结果依赖的单元格后进行重新计算。
- 将加载的演示文稿中的缓存值视为快照，而不是在编辑后重新计算的替代方案。
- 在依赖现有模板的计算值之前，先测试这些模板中的公式，特别是当它们使用未列出的函数时。
- 对于需要完整电子表格计算引擎的公式，请在外部计算后更新图表工作簿的结果值。

## **常见问答**

**`Formula` 与 `R1C1Formula` 有何区别？**

[Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/formula/)存储 A1 样式表达式，例如 `B2-C2`。[R1C1Formula](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/r1c1formula/)存储 R1C1 样式表达式，例如 `RC[-2]-RC[-1]`。请使用最符合您生成或复制公式方式的表示法。

**在计算后，我需要读取单元格本身还是它的值？**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/getcell/)返回 `IChartDataCell`。在重新计算后，读取该单元格的[Value](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdatacell/value/)属性即可获得计算结果。

**何时应该调用 `CalculateFormulas`？**

在更改输入值或公式后、在依赖计算结果之前调用[CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。这会更新内置求值器支持的所有公式的值。

**Aspose.Slides 是否支持所有 Excel 函数？**

不支持。内置求值器只支持文档中列出的函数子集。未列出的函数不应假定能够正确重新计算。如果需要完整的 Excel 公式兼容性，请使用适当的电子表格引擎进行计算，然后将最终值写入图表工作簿。

**如果加载的演示文稿包含不受支持的公式会怎样？**

如果图表数据未更改，工作簿可能仍包含先前计算的缓存值。相关数据被修改后，该缓存值可能不再有效。尝试访问无法处理的公式所在的单元格可能会抛出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式错误值等同于 .NET 异常吗？**

不等同。`#DIV/0!` 等结果是由有效计算产生的电子表格值。像[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellinvalidformulaexception/)或[CellCircularReferenceException](https://reference.aspose.com/slides/zh/net/aspose.slides.spreadsheet/cellcircularreferenceexception/)这类异常表示公式无法正常处理。

**当公式单元格更改时，图表会自动更新吗？**

图表系列可以引用工作簿单元格。先重新计算工作簿，然后保存或渲染演示文稿。如果图表数据点引用了计算后的单元格，图表会使用这些更新后的值；此工作流不需要单独的图表刷新方法。

**图表可以使用外部 Excel 工作簿吗？**

可以，图表数据可以通过图表数据 API 配置为使用外部工作簿。但本文描述的公式计算工作流仅涉及图表数据工作簿以及 Aspose.Slides 评估的公式子集。不要假设[CalculateFormulas](https://reference.aspose.com/slides/zh/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)能够对外部 XLSX 文件中的任意公式进行完整重新计算。

**我可以使用引用其他工作表或工作簿的公式吗？**

图表工作簿中可能出现 Excel 样式的跨工作表或外部引用，但公式求值受到支持的解析器和函数集合限制。如果跨表或外部引用至关重要，请使用目标 Aspose.Slides 版本验证确切公式。对于需要广泛 Excel 引用兼容性的工作流，请在外部计算工作簿并将解析后的值写回图表数据。

**公式字符串需要以 `=` 开头吗？**

Aspose.Slides API 示例中分配的表达式如 `B2-C2` 或 `SUM(B2:B5)` 均不带前导 `=`。使用这种形式可使生成的公式与文档中的 API 示例保持一致。