---
title: 图表工作表公式
type: docs
weight: 70
url: /cpp/chart-worksheet-formulas/
keywords: "powerpoint 方程式, powerpoint 电子表格公式"
description: "PowerPoint 方程式和电子表格公式"
---


## **关于演示中的图表电子表格公式**
**图表电子表格**（或图表工作表）是图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表上表示。当您在 PowerPoint 中创建图表时，与该图表相关的工作表也会自动创建。图表工作表适用于所有类型的图表：折线图、柱状图、旭日图、饼图等。要在 PowerPoint 中查看图表电子表格，您应该双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)



图表电子表格包含图表元素的名称（类别名称：*类别1*，系列名称）和与这些类别和系列相对应的数字数据表。默认情况下，当您创建一个新图表时，图表电子表格数据会被设定为默认数据。然后，您可以手动更改工作表中的电子表格数据。

通常情况下，图表表示复杂数据（例如：财务分析，科学分析），其单元格的值是从其他单元格的值或其他动态数据计算得出的。手动计算单元格的值并将其硬编码到单元格中，会使得将来更改变得困难。如果您更改某个单元格的值，则所有依赖于该单元格的单元格也都需要更新。此外，表格数据可能依赖于其他表的数据，形成复杂的演示数据方案，需要以简单灵活的方式进行更新。

**演示中的图表电子表格公式**是自动计算和更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或单元格集合的数据计算逻辑。电子表格公式是数学公式或逻辑公式，使用单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，而该单元格不包含简单的值。电子表格公式计算值并返回，然后将该值分配给单元格。演示中的图表电子表格公式实际上与 Excel 公式相同，并且它们的实现支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) 中，图表电子表格通过 [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法表示，属于 [**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook) 类型。电子表格公式可以通过 [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法来分配和更改。 Aspose.Slides 支持以下公式功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 风格单元格引用
- R1C1 风格单元格引用
- 预定义函数



通常情况下，电子表格会存储最后计算的公式值。如果在演示加载后，图表数据没有更改 - **IChartDataCell.get_Value()** 方法读取时返回这些值。但是，如果电子表格数据已被更改，在读取 **ChartDataCell.get_Value()** 方法时，会因不支持的公式抛出 **CellUnsupportedDataException**。这是因为，当公式成功解析时，会确定单元格依赖关系并确定最后值的正确性。但是，如果无法解析公式，则无法保证单元格值的正确性。


## **将图表电子表格公式添加到演示文稿**
首先，使用 [IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 方法将图表添加到新演示文稿的第一张幻灯片中。图表的工作表会自动创建并可以通过 [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法访问：



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



现在，可以使用 [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 方法在单元格中写入一些值，**Object** 类型表示可以将任何值传递给该方法：



``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



现在，要在单元格中写入公式，可以使用 [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法：




*注意*： [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法用于设置 A1 风格的单元格引用。



要设置 R1C1 公式单元格引用，可以使用 [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 方法：




然后如果您尝试从单元格 B2 和 C2 读取值，它们将被计算：



``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：




## **数值常量**
可以使用常规或科学计数法中的数字来创建图表电子表格公式：




## **字符串常量**
字符串（或字面量）常量是作为其本身使用的特定值，并且不会改变。字符串常量可以是：日期、文本、数字等：




## **错误常量**
有时，通过公式计算结果是不可能的。在这种情况下，单元格中显示错误代码，而不是其值。每种错误类型都有特定代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 可能在单元格上显示，在其值仍在计算中。
- #N/A - 信息缺失或不可用。一些原因可以是：公式中使用的单元格为空、额外的空格字符、拼写错误等。
- #NAME? - 某个单元格或其他公式对象无法通过其名称找到。
- #NULL! - 当公式中有错误时可能会出现，例如：使用了 (,) 或空格字符代替冒号 (:)。
- #NUM! - 公式中的数字可能无效，过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置为数字单元格。




## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：



|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|+ (加号) |加法或一元加|2 + 3|
|- (减号) |减法或否定 |2 - 3<br>-3|
|* (星号)|乘法 |2 * 3|
|/ (斜杠)|除法 |2 / 3|
|% (百分号) |百分比 |30%|
|^ (插入符号) |指数 |2 ^ 3|


*注意*：要更改计算顺序，请在要首先计算的公式部分加上括号。


## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是一个逻辑值，可能是 *TRUE* 或 FALSE：



|**运算符** |**含义** |**含义** |
| :- | :- | :- |
|= (等号) |等于 |A2 = 3|
|<> (不等号) |不等于|A2 <> 3|
|> (大于号) |大于|A2 > 3|
|>= (大于或等于号)|大于或等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于或等于号)|小于或等于|A2 <= 3|

## **A1 风格单元格引用**
**A1 风格单元格引用**用于工作表，其中列有字母标识（例如：“A”）而行有数字标识（例如：“1”）。A1 风格单元格引用可以如下使用：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


这是如何在公式中使用 A1 风格单元格引用的示例：




## **R1C1 风格单元格引用**
**R1C1 风格单元格引用**用于工作表，其中行和列都有数字标识。R1C1 风格单元格引用可以如下使用：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


这是如何在公式中使用 R1C1 风格单元格引用的示例：




## **预定义函数**
有一些预定义函数，可以在公式中使用以简化其实现。这些函数封装了最常用的操作，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 日期系统)
- DAYS
- FIND
- FINDB
- IF
- INDEX (引用形式)
- LOOKUP (向量形式)
- MATCH (向量形式)
- MAX
- SUM
- VLOOKUP