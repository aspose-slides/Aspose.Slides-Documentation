---
title: 在 Python 中对演示文稿应用图表工作表公式
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
- presentation
- Python
- Aspose.Slides
description: 在 Aspose.Slides for Python 中通过 .NET 图表工作表应用 Excel 风格的公式，并在 PPT、PPTX 和 ODP 文件中自动生成报告。
---

## **关于演示文稿中的图表电子表格公式**
**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含的数据以图形方式显示在图表上。当您在 PowerPoint 中创建图表时，关联的工作表也会自动创建。图表工作表会为所有类型的图表创建：折线图、柱形图、旭辉图、饼图等。要在 PowerPoint 中查看图表电子表格，请双击该图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet 包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，当您创建新图表时，图表电子表格数据会使用默认数据。随后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如财务分析、科学分析），其中的单元格是根据其他单元格的值或其他动态数据计算得出的。手动计算单元格的值并硬编码到单元格中，会使以后难以修改。如果您更改某个单元格的值，所有依赖它的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，形成一个复杂的演示文稿数据结构，需要以简单灵活的方式进行更新。

**Chart spreadsheet formula**（图表电子表格公式）是用于在演示文稿中自动计算和更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或一组单元格的数据计算逻辑。电子表格公式可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，而该单元格本身不包含普通值。电子表格公式计算出值并返回，然后该值被分配给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，并支持相同的默认函数、运算符和常量。

在[**Aspose.Slides**](https://products.aspose.com/slides/python-net/)中，图表电子表格由
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)属性（属于
[**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/)类型）表示。
可以使用[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)属性来分配和更改电子表格公式。
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

通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后图表数据未被更改，**IChartDataCell.Value**属性在读取时会返回这些值。但是，如果电子表格数据已被更改，在读取 **ChartDataCell.Value** 属性时会抛出 **CellUnsupportedDataException**，因为公式不受支持。之所以会这样，是因为当公式成功解析时，会确定单元格的依赖关系并验证上一次值的正确性。但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿中添加图表电子表格公式**
首先，使用[add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/)在新演示文稿的第一张幻灯片中添加一个带有示例数据的图表。图表的工作表会自动创建，可通过[**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/)属性访问：
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```


让我们使用
[**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)属性在单元格中写入一些值，该属性的类型为 **Object**，这意味着您可以为属性设置任意值：
```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```


现在要向单元格写入公式，您可以使用
[**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)属性：
```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```


*注意*：[**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)属性用于设置 A1 样式单元格引用。

要设置 [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)单元格引用，您可以使用[**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/)属性：
```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```


然后使用[**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)方法计算工作簿中的所有公式并更新相应单元格的值：
```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：

## **数值常量**
可以使用常规或科学计数法的数字来创建图表电子表格公式：

## **字符串常量**
字符串（或文字）常量是按原样使用且不会改变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时公式无法计算出结果。此时，单元格会显示错误代码而不是值。每种错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能会显示此错误。
- #N/A - 信息缺失或不可用。可能的原因包括：公式使用的单元格为空、存在额外空格字符、拼写错误等。
- #NAME? - 无法根据名称找到某个单元格或其他公式对象。
- #NULL! - 当公式中出现错误时可能出现，例如使用 (,) 或空格字符代替冒号 (:)。
- #NUM! - 公式中的数值可能无效、过长或过小等。
- #REF! - 单元格引用无效。
- #VALUE! - 值的类型意外。例如，将字符串值设置到数值单元格。

## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (加号)|加法或一元加号|2 + 3|
|- (减号)|减法或取负|2 - 3<br>-3|
|* (星号)|乘法|2 * 3|
|/ (斜杠)|除法|2 / 3|
|% (百分号)|百分比|30%|
|^ (脱字符)|幂运算|2 ^ 3|

*注意*：要更改运算顺序，请将要首先计算的部分用括号括起来。

## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是逻辑值 *TRUE* 或 FALSE：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (等号)|等于|A2 = 3|
|<> (不等号)|不等于|A2 <> 3|
|> (大于号)|大于|A2 > 3|
|>= (大于等于号)|大于等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于等于号)|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于工作表，其中列使用字母标识（例如 "*A*"），行使用数字标识（例如 "*1*"）。A1 样式单元格引用可以按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是如何在公式中使用 A1 样式单元格引用的示例：

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于工作表，其中行和列均使用数字标识。R1C1 样式单元格引用可以按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是如何在公式中使用 R1C1 样式单元格引用的示例：

## **预定义函数**
有一些预定义函数可在公式中使用，以简化实现。这些函数封装了最常用的操作，例如：

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
**外部 Excel 文件是否支持作为带公式的图表的数据源？**

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/)，这使您能够使用演示文稿外部 XLSX 文件中的公式。

**图表公式是否可以通过工作表名称引用同一工作簿中的工作表？**

是的。公式遵循标准的 Excel 引用模型，因此您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。