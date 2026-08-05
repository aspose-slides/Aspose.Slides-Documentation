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
- 数据源
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术常量
- 比较运算符
- A1 样式
- R1C1 样式
- 预定义函数
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 的图表工作表中应用 Excel 样式公式，并在 PPT 和 PPTX 文件中实现报告自动化。"
---
## **概述**

图表工作表是演示文稿中图表背后的数据源。它存储类别和系列名称以及图表显示的数值。 在 Aspose.Slides 中，可以通过图表数据工作簿访问此工作表，从而可以以编程方式处理图表数据。

本文说明如何在图表数据中使用工作表公式，以便单元格值可以自动计算和更新，而不是手动输入。它展示了如何分配公式、使用 A1 样式和 R1C1 样式的引用、重新计算工作簿公式，以及使用演示文稿中图表工作表支持的常量、运算符、单元格引用和预定义函数。

## **关于演示文稿中的图表电子表格公式**

**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含的数据以图形方式在图表中呈现。当您在 PowerPoint 中创建图表时，关联的工作表也会自动创建。Chart worksheet 为所有类型的图表创建：折线图、条形图、旭状图、饼图等。要在 PowerPoint 中查看 chart spreadsheet，请双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet 包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时，chart spreadsheet 数据会使用默认数据设置。然后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如金融分析、科学分析），其中的单元格是由其他单元格的值或其他动态数据计算得出的。手动计算单元格值并将其硬编码到单元格中，会导致以后难以更改。如果您更改某个单元格的值，所有依赖于该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，从而形成一个复杂的演示文稿数据方案，需要以简单灵活的方式进行更新。

演示文稿中的 **Chart spreadsheet formula** 是一种用于自动计算和更新 chart spreadsheet 数据的表达式。Spreadsheet formula 为特定单元格或一组单元格定义了数据计算逻辑。Spreadsheet formula 可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格不包含普通值。Spreadsheet formula 计算出数值并返回，然后将该数值赋给单元格。演示文稿中的 chart spreadsheet formulas 实际上与 Excel 公式相同，并且支持相同的默认函数、运算符和常量。

In [**Aspose.Slides**](https://products.aspose.com/slides/zh/cpp/) 中，chart spreadsheet 通过 [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法（属于 [**IChartDataWorkbook**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_workbook) 类型）表示。可以使用 [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法分配和更改 Spreadsheet formula。Aspose.Slides 中支持以下公式功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后图表数据未更改，**IChartDataCell.get_Value()** 方法在读取时会返回这些值。但如果电子表格数据已更改，在读取时 **ChartDataCell.get_Value()** 方法会抛出 **CellUnsupportedDataException**，因为不支持的公式。之所以会这样，是因为当公式成功解析时，会确定单元格依赖关系并确认上一次值的正确性。但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**

首先，使用 [IShapeCollection::AddChart()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 在新演示文稿的第一张幻灯片中添加图表。图表的工作表会自动创建，可通过 [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法访问：

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

让我们使用 [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 方法（**Object** 类型）在单元格中写入一些值，这意味着您可以向该方法传递任何值：

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

现在，要向单元格写入公式，您可以使用 [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法：

*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法用于设置 A1 样式单元格引用。

要设置 R1C1Formula 单元格引用，可以使用 [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 方法：

然后，如果尝试读取单元格 B2 和 C2 的值，它们将被计算：

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **逻辑常量**

您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：

## **数值常量**

可以使用普通或科学计数法的数字来创建 chart spreadsheet 公式：

## **字符串常量**

字符串（或文字）常量是按原样使用且不变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**

有时公式无法计算出结果。此时，单元格会显示错误代码而不是其值。每种错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 可能在单元格上显示，表示其值仍在计算中。
- #N/A - 信息缺失或不可用。可能的原因包括：公式中使用的单元格为空、存在额外空格、拼写错误等。
- #NAME? - 找不到某个单元格或其他公式对象的名称。 
- #NULL! - 当公式中有错误时可能出现，例如：(,) 或使用空格字符代替冒号 (:)。
- #NUM! - 公式中的数字可能无效、过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置为数值单元格。

## **算术运算符**

您可以在 chart worksheet 公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (plus sign)|加法或一元正号|2 + 3|
|- (minus sign)|减法或取负|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|指数|2 ^ 3|

*Note*: 要更改求值顺序，请将要首先计算的公式部分用括号括起来。

## **比较运算符**

您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是逻辑值 *TRUE* 或 FALSE：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (equal sign)|等于|A2 = 3|
|<> (not equal sign)|不等于|A2 <> 3|
|> (greater than sign)|大于|A2 > 3|
|>= (greater than or equal to sign)|大于或等于|A2 >= 3|
|< (less than sign)|小于|A2 < 3|
|<= (less than or equal to sign)|小于或等于|A2 <= 3|

## **A1 样式单元格引用**

**A1 样式单元格引用** 用于工作表，其中列使用字母标识（例如 "*A*"），行使用数字标识（例如 "*1*"）。可以按以下方式使用 A1 样式单元格引用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
| |**绝对**|**相对**|**混合**|
|Cell |$A$2 |A2 |<p>A$2</p><p>$A2</p>|
|Row |$2:$2 |2:2 |-|
|Column |$A:$A |A:A |-|
|Range |$A$2:$C$4 |A2:C4 |<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是使用 A1 样式单元格引用的公式示例：

## **R1C1 样式单元格引用**

**R1C1 样式单元格引用** 用于工作表，其中行和列均使用数字标识。可以按以下方式使用 R1C1 样式单元格引用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
| |**绝对**|**相对**|**混合**|
|Cell |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row |R2|R[2]|-|
|Column |C3|C[3]|-|
|Range |R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是使用 R1C1 样式单元格引用的公式示例：

## **预定义函数**

有预定义函数可在公式中使用，以简化实现。这些函数封装了最常用的操作，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **常见问题**

**是否支持将外部 Excel 文件作为带公式的图表的数据源？**

是的。Aspose.Slides 支持将外部工作簿作为[图表的数据源](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/chartdatasourcetype/)，从而可以使用演示文稿之外的 XLSX 中的公式。

**图表公式是否可以通过工作表名称引用同一工作簿内的工作表？**

是的。公式遵循标准的 Excel 引用模型，因此可以引用同一工作簿中的其他工作表或外部工作簿。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。