---
title: 在演示文稿中使用 C++ 应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/cpp/chart-worksheet-formulas/
keywords:
- 图表电子表格
- 图表工作表
- 图表公式
- 工作表公式
- 电子表格公式
- 图表数据工作簿
- 公式计算
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 形式
- R1C1 形式
- 预定义函数
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 的图表工作表中应用 Excel 风格的公式，重新计算数值，并在 PowerPoint 图表中使用结果。"
---
## **概述**

PowerPoint 图表通常将其源数据存储在嵌入的工作表中。在 Aspose.Slides for C++ 中，您可以通过图表数据工作簿访问该工作表，写入输入值，为单元格分配公式，计算受支持的公式，并将计算后的单元格用作图表数据。

本文阐述完整的公式工作流：创建图表、填充其工作表、分配 A1 形式或 R1C1 形式的公式、重新计算、读取计算结果、将这些单元格连接到图表系列并保存演示文稿。还会介绍受支持的公式语法、内置函数子集、缓存值、不受支持的公式以及电子表格特定错误。

## **图表工作表和公式**

图表工作表包含图表使用的类别、系列名称和数值。在 PowerPoint 中，您可以通过打开图表数据编辑器来检查工作表：

![PowerPoint 图表及其嵌入的工作表打开，显示类别和系列数据](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表通过[IChartDataWorkbook](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/) 接口暴露。使用[IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 处理 A1 形式公式，使用[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 处理 R1C1 形式公式。更改输入单元格或公式后，调用[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 重新计算受支持的公式并更新对应的单元格值。

已计算的单元格仍通过[IChartDataCell::get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/get_value/) 暴露其结果。当您需要在代码中检查公式结果或把单元格用作图表数据点时，这一点尤为重要。

## **创建图表并计算工作表公式**

下面的示例演示端到端工作流。它创建一个簇状柱形图，清除示例数据，写入季度收入和支出值，使用公式计算利润，读取结果，将计算后的单元格用作图表数值，并保存演示文稿。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

图表数据点引用 `D2:D4`，因此图表使用计算后的利润值。在此工作流中没有单独的图表刷新调用：先重新计算工作簿，然后使用或保存指向已计算单元格的图表数据。

## **使用 A1 形式公式**

A1 表示法使用字母标识列，数字标识行。通过[IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 分配 A1 形式表达式。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

常见的 A1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 范围 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相对引用在公式被电子表格应用移动或复制时会改变。绝对引用保持行列坐标固定，混合引用仅固定行或列。

## **使用 R1C1 形式公式**

R1C1 表示法使用数字标识行和列。相对引用在方括号中使用偏移量。通过[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 分配此语法。

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

常见的 R1C1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 范围 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在单元格 `D2` 中，`RC[-2]` 表示同一行向左两列的单元格，即 `B2`。

## **公式常量与运算符**

内置公式求值器支持逻辑值、数值文字、字符串、电子表格错误值、算术运算符和比较运算符。

### **常量与文字**

| 类型 | 示例 | 说明 |
|---|---|---|
| 逻辑 | `TRUE`, `FALSE` | 可直接用于逻辑表达式，如 `A2=TRUE`。 |
| 数值 | `1`, `0.5`, `.3`, `1E-2` | 支持普通记数法和科学计数法。 |
| 字符串 | `"abc"`, `"2/3/2020 12:00"` | 文本文字需在公式内部使用双引号括起。 |
| 错误结果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可以求得电子表格错误值，而不是普通结果。 |

以下示例使用了多种常量类型：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // 假
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **算术运算符**

| 运算符 | 含义 | 示例 |
|---|---|---|
| `+` | 加法或一元加号 | `2+3` |
| `-` | 减法或取负号 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 幂运算 | `2^3` |

使用圆括号可明确求值顺序，例如 `(A2+B2)*C2`。

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

Aspose.Slides 为图表工作表提供内置公式求值器，但它不是完整的 Excel 计算引擎。文档中列出的函数集仅限于以下函数。不要假设任意 Excel 函数都可以通过[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 重新计算。

| 函数 | 用途或支持形式 | 示例 |
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

表中显示的限制非常重要：`INDEX` 以引用形式记录，而 `LOOKUP` 与 `MATCH` 以向量形式记录。`DATE` 使用 1900 日期系统。未在此列出的功能应视为 Aspose.Slides 公式求值器不支持，除非另有文档说明。

## **重新计算与缓存值**

电子表格文件通常同时存储公式及其最近一次计算的值。加载演示文稿且相关图表数据未更改时，Aspose.Slides 可以通过[IChartDataCell::get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/get_value/) 读取缓存值。

更改输入单元格或公式后，请在读取计算值或保存依赖这些值的图表数据之前调用[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。

对于不在受支持子集中的公式，Aspose.Slides 可能无法解析公式或建立其依赖关系。如果工作簿已被修改，之前的缓存值将不再可靠。在这种情况下，读取包含不受支持数据的单元格可能会抛出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

如果您的图表依赖于 Aspose.Slides 未评估的 Excel 函数，请使用支持这些函数的电子表格引擎计算公式，然后将结果写回图表工作簿。不要用猜测的值替代不受支持的公式。

## **处理公式错误**

需要区分两类问题。

公式本身有效，但产生如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` 的电子表格错误结果。这时错误标记是单元格的结果，可通过[IChartDataCell::get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/get_value/) 返回。

公式也可能在解析、引用、依赖或受支持数据层面失败。Aspose.Slides 为这些情况提供专属异常：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) 和 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

当公式来源于模板或用户输入时，请在重新计算和访问值的代码块周围捕获这些异常：

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // 处理无效公式。
}
catch (CellInvalidReferenceException&)
{
    // 处理无效的单元格引用。
}
catch (CellCircularReferenceException&)
{
    // 处理循环引用。
}
catch (CellUnsupportedDataException&)
{
    // 处理不受支持的电子表格数据。
}
```

## **实际限制**

图表工作表中的公式支持面向特定子集的电子表格计算，而非完整的 Excel 兼容性。设计报表工作流时请牢记以下约束：

- 仅使用文档中列出的常量、运算符、引用和函数，以便 Aspose.Slides 能重新计算公式。
- 在更改公式结果依赖的单元格后进行重新计算。
- 将加载的演示文稿中的缓存值视为快照，而非编辑后重新计算的替代品。
- 在依赖模板计算值之前先对现有模板的公式进行测试，尤其是使用了文档未列出的函数时。
- 对于需要完整电子表格计算引擎的公式，请在外部计算后再更新图表工作簿的数值。

## **常见问答**

**`set_Formula` 与 `set_R1C1Formula` 有何区别？**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_formula/) 存储 A1 形式的表达式，例如 `B2-C2`。[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) 存储 R1C1 形式的表达式，例如 `RC[-2]-RC[-1]`。使用最符合您生成或复制公式方式的记法。

**计算后需要读取单元格本身还是其值？**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) 返回 `IChartDataCell`。在重新计算后，读取该单元格的[IChartDataCell::get_Value](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdatacell/get_value/) 即可获得计算结果。

**何时调用 `CalculateFormulas`？**

在更改输入值或公式后、在依赖计算结果之前，调用[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)。这会更新内置求值器支持的公式值。

**Aspose.Slides 是否支持所有 Excel 函数？**

不支持。内置求值器仅支持文档中列出的子集。未列出的函数不应假设能够正确重新计算。若需完整的 Excel 公式兼容性，请使用相应的电子表格引擎进行计算并将最终值写入图表工作簿。

**加载的演示文稿中包含不受支持的公式会怎样？**

如果图表数据未更改，工作簿可能仍保留先前计算的缓存值。相关数据被修改后，该缓存值可能失效。访问无法处理的公式所在的单元格可能会抛出[CellUnsupportedDataException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)。

**公式错误值等同于 C++ 异常吗？**

不等同。诸如 `#DIV/0!` 的结果是有效计算产生的电子表格值。像[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)或[CellCircularReferenceException](https://reference.aspose.com/slides/zh/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)之类的异常表示公式无法正常处理。

**公式单元格更改时图表会自动更新吗？**

图表系列可以引用工作簿单元格。先重新计算工作簿，然后保存或渲染演示文稿。如果图表数据点引用了已计算的单元格，图表会使用这些更新后的数值；此工作流无需额外的图表刷新方法。

**图表可以使用外部 Excel 工作簿吗？**

可以，图表数据可通过图表数据 API 配置为使用外部工作簿。但本文讨论的公式计算工作流仅涉及图表数据工作簿及 Aspose.Slides 所评估的公式子集。不要假设[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) 能对外部 XLSX 文件中的任意公式进行完整重新计算。

**可以使用引用其他工作表或工作簿的公式吗？**

Chart 工作簿中可能出现 Excel 风格的跨表或跨簿引用，但公式求值受限于解析器和函数集。如果跨表或外部引用是必需的，请在目标 Aspose.Slides 版本中验证该公式的可行性。对于需要广泛 Excel 引用兼容性的工作流，建议在外部计算工作簿并将解析后的数值写回图表数据。

**公式字符串需要以 `=` 开头吗？**

Aspose.Slides API 示例分配的表达式如 `B2-C2` 或 `SUM(B2:B5)` 并不以 `=` 开头。使用这种形式可使生成的公式与文档中的 API 示例保持一致。