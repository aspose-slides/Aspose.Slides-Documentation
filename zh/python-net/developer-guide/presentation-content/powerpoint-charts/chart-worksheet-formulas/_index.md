---
title: 在演示文稿中使用 Python 应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/python-net/chart-worksheet-formulas/
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
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Aspose.Slides for Python 中通过 .NET 图表工作表应用 Excel 样式公式，并在 PPT、PPTX 和 ODP 文件中自动生成报告。"
---

## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或图表工作表）在演示文稿中是图表的数据源。图表电子表格包含的数据以图形方式在图表中呈现。 当您在 PowerPoint 中创建图表时，关联的工作表会自动创建。图表工作表适用于所有类型的图表：折线图、柱形图、旭辉图、饼图等。要在 PowerPoint 中查看图表电子表格，请双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时，图表电子表格会使用默认数据。随后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如金融分析、科学分析），其中的单元格通过其他单元格的值或其他动态数据计算得出。手动计算单元格的值并硬编码到单元格中，会导致以后难以更改。如果更改某个单元格的值，所有依赖它的单元格也必须更新。此外，表格数据可能依赖其他表格的数据，形成复杂的演示文稿数据结构，需要以简便灵活的方式进行更新。

**图表电子表格公式**是在演示文稿中的一种表达式，用于自动计算和更新图表电子表格数据。电子表格公式为特定单元格或一组单元格定义数据计算逻辑。电子表格公式可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格本身不包含普通值。电子表格公式计算出结果并返回，然后将该值赋给单元格。演示文稿中的图表电子表格公式实际与 Excel 公式相同，支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，图表电子表格由 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) 属性（属于
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) 类型）表示。
可以通过 [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性分配和更改电子表格公式。
Aspose.Slides 中对公式支持以下功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储最近计算的公式值。如果在加载演示文稿后图表数据未更改，则 **IChartDataCell.Value** 属性在读取时返回这些值。但如果电子表格数据已更改，在读取 **ChartDataCell.Value** 属性时会抛出 **CellUnsupportedDataException**，因为不支持的公式。之所以这样，是因为当公式成功解析时，会确定单元格依赖关系并验证最后值的正确性；但如果公式无法解析，则无法保证单元格值的正确性。

## **添加图表电子表格公式到演示文稿**
首先，使用 [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 在新演示文稿的第一页幻灯片上添加一个带有示例数据的图表。图表的工作表会自动创建，可通过 [**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) 属性访问：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

让我们使用 **Object** 类型的 [**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性在单元格中写入一些值，这意味着您可以为该属性设置任意值：

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

现在，要在单元格中写入公式，可以使用 [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性：

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*注意*：[**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性用于设置 A1 样式的单元格引用。

要设置 [r1c1_formula] 单元格引用，可使用 [**r1c1_formula**] 属性：

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

然后使用 [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 方法计算工作簿中所有公式并更新相应单元格的值：

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：

## **数值常量**
可以使用普通或科学计数法的数字来创建图表电子表格公式：

## **字符串常量**
字符串（或字面量）常量是按原样使用且不改变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时公式无法计算出结果。此时，单元格会显示错误代码而不是数值。每种错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能显示此错误。
- #N/A - 信息缺失或不可用。原因可能包括：公式中使用的单元格为空、存在多余空格、拼写错误等。
- #NAME? - 无法根据名称找到某个单元格或其他公式对象。
- #NULL! - 当公式中出现错误时可能出现，例如使用 (,) 或空格代替冒号 (:)。
- #NUM! - 公式中的数值可能无效、过大或过小等。
- #REF! - 单元格引用无效。
- #VALUE! - 值的类型不符合预期。例如将字符串值设置到数值单元格。

## **算术运算符**
在图表工作表公式中，您可以使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (plus sign)|加法或一元加号|2 + 3|
|- (minus sign)|减法或取负|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|指数运算|2 ^ 3|

*注意*：要更改求值顺序，请在需要首先计算的公式部分加上括号。

## **比较运算符**
在图表工作表公式中，您可以使用比较运算符来比较单元格的值。当使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 *FALSE*：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (equal sign)|等于|A2 = 3|
|<> (not equal sign)|不等于|A2 <> 3|
|> (greater than sign)|大于|A2 > 3|
|>= (greater than or equal to sign)|大于等于|A2 >= 3|
|< (less than sign)|小于|A2 < 3|
|<= (less than or equal to sign)|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用** 用于列采用字母标识（例如 "*A*"）且行采用数字标识（例如 "*1*"）的工作表。A1 样式单元格引用可按以下方式使用：

|**Cell reference**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- |
|**Cell**|$A$2|A2|<p>A$2</p><p>$A2</p>|
|**Row**|$2:$2|2:2|-|
|**Column**|$A:$A|A:A|-|
|**Range**|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

这里有一个在公式中使用 A1 样式单元格引用的示例：

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用** 用于列和行均采用数字标识的工作表。R1C1 样式单元格引用可按以下方式使用：

|**Cell reference**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- |
|**Cell**|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|**Row**|R2|R[2]|-|
|**Column**|C3|C[3]|-|
|**Range**|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

这里有一个在公式中使用 R1C1 样式单元格引用的示例：

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
**外部 Excel 文件是否支持作为带公式图表的数据源？**

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)，允许您使用演示文稿之外的 XLSX 文件中的公式。

**图表公式能否通过工作表名称引用同一工作簿中的工作表？**

是的。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包括路径和工作簿名称。