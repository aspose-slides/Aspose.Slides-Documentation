---
title: 在演示文稿中使用 Python 应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/python-net/chart-worksheet-formulas/
keywords:
- 图表 电子表格
- 图表 工作表
- 图表 公式
- 工作表 公式
- 电子表格 公式
- 图表 数据工作簿
- 公式 计算
- 首选 文化
- 特定于文化的公式
- DBCS
- 逻辑 常量
- 数值 常量
- 字符串 常量
- 错误 常量
- 算术 运算符
- 比较 运算符
- A1 样式
- R1C1 样式
- 预定义 函数
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python via .NET 的图表工作表中使用 Excel 样式公式，重新计算数值，并在 PowerPoint 图表中使用结果。"
---
## **概述**

PowerPoint 图表通常将其源数据存储在嵌入的工作表中。在 Aspose.Slides for Python via .NET 中，您可以通过图表数据工作簿访问该工作表，写入输入值，为单元格分配公式，计算受支持的公式，并将计算后的单元格用作图表数据。

本文说明了完整的公式工作流：创建图表、填充其工作表、分配 A1 样式或 R1C1 样式公式、重新计算它们、读取计算值、将这些单元格连接到图表系列并保存演示文稿。还描述了受支持的公式语法、内置函数子集、缓存值、不受支持的公式以及电子表格特定错误。

## **图表工作表和公式**

图表工作表包含图表使用的类别、系列名称和数值。在 PowerPoint 中，您可以通过打开图表数据编辑器来检查工作表：

![PowerPoint 图表及其打开的嵌入工作表，显示类别和系列数据](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表通过[chart data workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdataworkbook/)公开。使用[formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/formula/)属性设置 A1 样式公式，使用[r1c1_formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)属性设置 R1C1 样式公式。更改输入单元格或公式后，调用[calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)以重新计算受支持的公式并更新相应的单元格值。

计算后的单元格仍通过[value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/value/)属性公开其结果。当您需要在代码中检查公式结果或将单元格用作图表数据点时，这一点很重要。

## **创建图表并计算工作表公式**

下面的示例演示了端到端工作流。它创建一个簇状柱形图，清除示例数据，写入季度收入和支出值，使用公式计算利润，读取结果，将计算后的单元格用作图表值，并保存演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

图表数据点引用 `D2:D4`，因此图表使用计算后的利润值。此工作流中没有单独的图表刷新调用：先重新计算工作簿，然后使用或保存指向计算单元格的图表数据。

## **使用 A1 样式公式**

A1 表示法使用字母标识列、数字标识行。通过[IChartDataCell.formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/formula/)分配 A1 样式表达式。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

常见的 A1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `A2` | `$A$2` | `A$2` `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 区域 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4` `$A2:C$4` |

相对引用在公式被移动或复制时会更改。绝对引用保持两个坐标固定，混合引用则只固定行或列。

## **使用 R1C1 样式公式**

R1C1 表示法使用数字标识行列。相对引用在方括号中使用偏移量。通过[IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)分配此语法。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

常见的 R1C1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `R[2]C[3]` | `R2C3` | `R2C[3]` `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 区域 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]` `R[2]C3:R5C[7]` |

例如，在单元格 `D2` 中，`RC[-2]` 表示同一行向左两列的单元格（`B2`）。

## **公式常量和运算符**

内置公式求值器支持逻辑值、数值文字、字符串、电子表格错误值、算术运算符和比较运算符。

### **常量和文字**

| 类型 | 示例 | 备注 |
|---|---|---|
| 逻辑 | `TRUE` `FALSE` | 可直接在逻辑表达式中使用，例如 `A2=TRUE`。 |
| 数值 | `1` `0.5` `.3` `1E-2` | 支持普通和科学计数法表示。 |
| 字符串 | `"abc"` `"2/3/2020 12:00"` | 文本文字在公式中用双引号括起。 |
| 错误结果 | `#DIV/0!` `#N/A` `#REF!` | 有效公式可以求值为电子表格错误值。 |

以下示例使用了多种常量类型：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # 假
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **算术运算符**

| 运算符 | 含义 | 示例 |
|---|---|---|
| `+` | 加法或一元加号 | `2+3` |
| `-` | 减法或取负 | `2-3` `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 指数 | `2^3` |

使用圆括号显式指定计算顺序，例如 `(A2+B2)*C2`。

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

Aspose.Slides 为图表工作表提供内置公式求值器，但它不是完整的 Excel 计算引擎。文档中列出的函数集有限。请勿假设任意 Excel 函数都能通过[calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)重新计算。

| 函数 | 用途或支持形式 | 示例 |
|---|---|---|
| `ABS` | 取绝对值 | `ABS(A2)` |
| `AVERAGE` | 算术平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整到指定倍数 | `CEILING(A2,5)` |
| `CHOOSE` | 按索引选择值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 连接文本值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 连接文本值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系统创建日期值 | `DATE(2026,8,19)` |
| `DAYS` | 返回两个日期之间的天数 | `DAYS(B2,A2)` |
| `FIND` | 在文本中查找另一段文本 | `FIND("-",A2)` |
| `FINDB` | 按字节搜索文本 | `FINDB("a",A2)` |
| `IF` | 条件结果 | `IF(A2>0,A2,0)` |
| `INDEX` | 引用形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 求和 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表中显示的限制很重要：`INDEX` 以引用形式记录，而 `LOOKUP` 和 `MATCH` 以向量形式记录。`DATE` 使用 1900 日期系统。未在此列出的功能和函数应视为 Aspose.Slides 公式求值器不支持，除非有单独文档说明。

## **使用首选文化计算公式**

某些图表工作簿函数会根据文化特定规则解释文本。这在处理使用双字节字符集（DBCS）的语言时尤为重要。要正确计算此类公式，请创建[LoadOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/)，通过[LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/spreadsheet_options/)设置[SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/spreadsheetoptions/)，然后加载演示文稿。

下面的示例选择日语文化，使用配置好的加载选项打开演示文稿，并为每个图表工作簿调用[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

首选文化是演示文稿加载配置的一部分，因此在创建[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)实例之前指定。使用工作簿公式期望的文化，例如对应日语 DBCS 计算规则的 `ja-JP`。

## **重新计算和缓存值**

电子表格文件通常同时存储公式及其最近一次计算的值。Aspose.Slides 因此可以在加载演示文稿且相关图表数据未更改时，从[IChartDataCell.value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/value/)读取缓存值。

更改输入单元格或公式后，请勿依赖旧的缓存结果。读取计算值或保存依赖这些值的图表数据前，请先调用[ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)。

对于不在受支持子集中的公式，Aspose.Slides 可能无法解析公式或确定其依赖关系。如果工作簿已被修改，先前的缓存值不再可靠。在这种情况下，读取包含不受支持数据的单元格的值可能会引发[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

如果您的图表依赖于 Aspose.Slides 未评估的 Excel 函数，请使用支持这些函数的电子表格引擎计算公式，然后将结果写回图表工作簿。不要用猜测的值替换不受支持的公式。

## **处理公式错误**

需要区分两种不同的问题。

公式可以是有效的，但产生如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` 的电子表格错误结果。在这种情况下，错误标记是单元格结果，可以通过 `value` 返回。

公式也可能在解析、引用、依赖或受支持数据层面失败。Aspose.Slides 为这些情况提供了特定的电子表格异常：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)、以及[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

当公式来自模板或用户输入时，请在重新计算和访问值时捕获这些异常：

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **实际限制**

图表工作表中的公式支持旨在满足特定子集的电子表格计算需求，而非完整的 Excel 兼容性。在设计报表工作流时请牢记以下约束：

- 仅在需要 Aspose.Slides 重新计算公式时使用文档中列出的常量、运算符、引用和函数。
- 在更改公式结果依赖的单元格后进行重新计算。
- 将加载的演示文稿中的缓存值视为快照，而不是在编辑后重新计算的替代方案。
- 在依赖模板中已有的计算值之前，先测试这些公式，特别是当它们使用未在文档中列出的函数时。
- 对于需要完整电子表格计算引擎的公式，请先在外部计算，然后将结果更新到图表工作簿。

## **常见问答**

**`formula` 与 `r1c1_formula` 有何区别？**

[formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/formula/)存储 A1 样式表达式，例如 `B2-C2`。[r1c1_formula](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/)存储 R1C1 样式表达式，例如 `RC[-2]-RC[-1]`。使用最符合您生成或复制公式方式的表示法。

**在计算后我需要读取单元格本身还是它的值？**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)返回 `IChartDataCell`。在重新计算后，读取该单元格的[value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichartdatacell/value/)属性即可获得计算结果。

**何时应调用 `calculate_formulas`？**

在更改输入值或公式后、在依赖计算结果之前调用[calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)。这会更新内置求值器支持的公式的值。

**Aspose.Slides 是否支持所有 Excel 函数？**

不支持。内置求值器仅支持文档中列出的子集。未列出的函数不应假设能够正确重新计算。如果需要完整的 Excel 公式兼容性，请使用适当的电子表格引擎进行计算并将最终值写入图表工作簿。

**如果加载的演示文稿包含不受支持的公式会怎样？**

如果图表数据未更改，工作簿可能仍保留先前计算的缓存值。相关数据被修改后，该缓存值可能失效。访问无法处理的公式单元格时可能会抛出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式错误值与 Python 异常是同一回事吗？**

不是。`#DIV/0!` 等结果是有效计算产生的电子表格值。像[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/)或[CellCircularReferenceException](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/)之类的异常表示公式无法正常处理。

**当公式单元格更改时图表会自动更新吗？**

图表系列可以引用工作簿单元格。先重新计算工作簿，然后保存或渲染演示文稿。如果图表数据点引用了计算后的单元格，图表会使用这些更新的值；此工作流不需要额外的图表刷新方法。

**图表可以使用外部 Excel 工作簿吗？**

可以，图表数据可以通过图表数据 API 配置为使用外部工作簿。但本文描述的公式计算工作流仅针对图表数据工作簿及 Aspose.Slides 评估的公式子集。不要假设[calculate_formulas](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/)能够完整重新计算外部 XLSX 文件中的任意公式。

**我可以使用引用其他工作表或工作簿的公式吗？**

Excel 样式的引用可能出现在图表工作簿中，但公式求值受限于支持的解析器和函数集。如果跨工作表或外部引用是必需的，请在目标 Aspose.Slides 版本上验证确切公式。对于需要广泛 Excel 引用兼容性的工作流，请在外部计算工作簿并将解析后的值写回图表数据。

**公式字符串需要以 `=` 开头吗？**

Aspose.Slides API 示例中分配的表达式如 `B2-C2` 或 `SUM(B2:B5)` 并不带前导 `=`。采用这种形式可使生成的公式与文档中的 API 示例保持一致。