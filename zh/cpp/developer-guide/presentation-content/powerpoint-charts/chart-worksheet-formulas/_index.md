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
description: "在 Aspose.Slides 中为 C++ 图表工作表应用 Excel 样式公式，并在 PPT 和 PPTX 文件中自动生成报告。"
---

## **关于演示文稿中的图表电子表格公式**
**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含数据，这些数据以图形方式显示在图表上。当您在 PowerPoint 中创建图表时，关联的工作表会自动创建。Chart worksheet 为所有类型的图表创建：折线图、条形图、旭辉图、饼图等。要在 PowerPoint 中查看 chart spreadsheet，您应双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet 包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时，chart spreadsheet 数据使用默认数据。随后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如金融分析、科学分析），其中的单元格是根据其他单元格的值或其他动态数据计算得出的。手动计算单元格的值并硬编码到单元格中，未来更改会十分困难。如果更改某个单元格的值，所有依赖该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，形成一个复杂的演示文稿数据方案，需要以简便灵活的方式进行更新。

演示文稿中的 **Chart spreadsheet formula** 是用于自动计算和更新 chart spreadsheet 数据的表达式。Spreadsheet formula 为特定单元格或一组单元格定义数据计算逻辑。Spreadsheet formula 是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格不包含普通值。Spreadsheet formula 计算出数值并返回，然后该数值被赋给单元格。演示文稿中的 chart spreadsheet 公式实际上与 Excel 公式相同，并支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) 中，chart spreadsheet 由 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法（属于 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook) 类型）表示。 
可以使用 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法为电子表格公式赋值或更改。 
Aspose.Slides 对公式支持以下功能：
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后，图表数据未被更改，**IChartDataCell.get_Value()** 方法在读取时会返回这些值。但如果电子表格数据已更改，在读取时调用 **ChartDataCell.get_Value()** 方法会抛出 **CellUnsupportedDataException**，因为不支持的公式。之所以会这样，是因为当公式成功解析时，会确定单元格依赖关系并确认上一次值的正确性；但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，使用 [IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 在新演示文稿的第一页添加图表。图表的工作表会自动创建，可通过 [**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 方法访问：
``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```


让我们使用 **Object** 类型的 [**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 方法向单元格写入一些值，这意味着您可以向该方法传入任意值：
``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```


现在，要向单元格写入公式，您可以使用 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法：

*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 方法用于设置 A1 样式单元格引用。

要设置 R1C1Formula 单元格引用，您可以使用 [**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 方法：

然后如果您尝试读取单元格 B2 和 C2 的值，它们将被计算：
``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，如 *FALSE* 和 *TRUE*：

## **数值常量**
可以使用普通或科学计数法的数字来创建 chart spreadsheet 公式：

## **字符串常量**
字符串（或文字）常量是按原样使用且不变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时公式无法计算出结果，此时单元格会显示错误代码而非数值。每种错误都有特定的代码：
- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能显示此错误。
- #N/A - 信息缺失或不可用。可能原因包括：公式中使用的单元格为空、存在额外空格、拼写错误等。
- #NAME? - 无法根据名称找到某个单元格或其他公式对象。
- #NULL! - 当公式中有错误时可能出现，例如使用 (,) 或空格字符代替冒号 (:)。
- #NUM! - 公式中的数字可能无效、过长或过小等。
- #REF! - 单元格引用无效。
- #VALUE! - 值类型不符合预期。例如，向数值单元格赋予字符串。

## **算术运算符**
您可以在 chart worksheet 公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (plus sign)|加法或一元加号|2 + 3|
|- (minus sign)|减法或取负号|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|指数|2 ^ 3|

*Note*: 若要更改求值顺序，请将需先计算的部分用括号括起来。

## **比较运算符**
您可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 *FALSE*：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (equal sign)|等于|A2 = 3|
|<> (not equal sign)|不等于|A2 <> 3|
|> (greater than sign)|大于|A2 > 3|
|>= (greater than or equal to sign)|大于或等于|A2 >= 3|
|< (less than sign)|小于|A2 < 3|
|<= (less than or equal to sign)|小于或等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用** 用于列使用字母标识（例如 “*A*”）且行使用数字标识（例如 “*1*）的工作表。A1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是一个在公式中使用 A1 样式单元格引用的示例：

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用** 用于行和列均使用数字标识的工作表。R1C1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是一个在公式中使用 R1C1 样式单元格引用的示例：

## **预定义函数**
公式中可以使用预定义函数来简化实现。这些函数封装了最常用的操作，例如：

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

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdatasourcetype/)，从而可以在演示文稿之外的 XLSX 中使用公式。

**图表公式能否通过工作表名称引用同一工作簿中的工作表？**

是的。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。