---
title: 图表工作表公式
type: docs
weight: 70
url: /python-net/chart-worksheet-formulas/
keywords: "图表电子表格, 图表公式, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "Python中的PowerPoint演示文稿中的图表电子表格和公式"
---

## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或图表工作表）是图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表上表示。当你在PowerPoint中创建图表时，与该图表相关的工作表也会自动创建。所有类型的图表都创建图表工作表：折线图、条形图、旭日图、饼图等。要在PowerPoint中查看图表电子表格，你应该双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

图表电子表格包含图表元素的名称（类别名称：*类别1*、系列名称）和与这些类别和系列相应的数值数据表。默认情况下，当你创建新图表时，图表电子表格的数据将设置为默认数据。然后，你可以手动更改工作表中的电子表格数据。

通常，图表表示复杂的数据（例如财务分析师、科学分析师），具有从其他单元格的值或其他动态数据计算得出的单元格。手动计算单元格的值并将其硬编码到单元格中，使将来更改它变得困难。如果你更改某个单元格的值，则所有依赖于该值的单元格也需要更新。此外，表格数据可能依赖于其他表中的数据，创建复杂的演示文稿数据方案，需要以简单和灵活的方式进行更新。

**演示文稿中的图表电子表格公式**是自动计算和更新图表电子表格数据的表达式。电子表格公式定义了某个单元格或一组单元格的数据计算逻辑。电子表格公式是一种数学公式或逻辑公式，其中使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义是写入单元格中的，该单元格不包含简单值。电子表格公式计算值并将其返回，然后此值被分配给单元格。演示文稿中的图表电子表格公式实际上与Excel公式相同，并且对于它们的实现支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，图表电子表格通过 [**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) 属性表示，属于 [**IChartDataWorkbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdataworkbook/) 类型。可以通过 [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性设置和更改电子表格公式。Aspose.Slides 支持以下功能用于公式：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1样式单元格引用
- R1C1样式单元格引用
- 预定义函数

通常，电子表格存储最后计算的公式值。如果在演示文稿加载后，图表数据没有更改 - **IChartDataCell.Value** 属性在读取时返回这些值。但是，如果电子表格数据被更改，在读取 **ChartDataCell.Value** 属性时，对于不支持的公式会抛出 **CellUnsupportedDataException**。这是因为当公式成功解析时，单元格依赖关系被确定，并且最后值的正确性被确定。但是，如果无法解析公式，则无法保证单元格值的正确性。

## **将图表电子表格公式添加到演示文稿**
首先，使用 [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 将一个带有一些示例数据的图表添加到新演示文稿的第一张幻灯片中。图表的工作表会自动创建，并可以通过 [**chart_data_workbook**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdata/) 属性访问：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```

接下来，在单元格中使用 [**value**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性写入一些值，该属性的 **Object** 类型，意味着你可以将任何值设置给该属性：

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

现在要将公式写入单元格，可以使用 [**formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性：

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*注意*： [**IChartDataCell.Formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性用于设置 A1 样式单元格引用。

要设置 [r1c1_formula](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 单元格引用，可以使用 [**r1c1_formula**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatacell/) 属性：

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

然后使用 [**calculate_formulas**](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) 方法来计算工作簿中的所有公式并更新相应的单元格值：

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **逻辑常量**
你可以在单元格公式中使用逻辑常量，如 *FALSE* 和 *TRUE*：

## **数值常量**
可以使用常规或科学记数法的数字来创建图表电子表格公式：

## **字符串常量**
字符串（或字面量）常量是一个特定的值，以原样使用而不改变。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时无法通过公式计算结果。在这种情况下，单元格中显示错误代码而不是其值。每种类型的错误都有特定代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 可能会在单元格中显示，而它的值仍在计算中。
- #N/A - 信息缺失或不可用。某些原因可能是：公式中使用的单元格为空、额外空格字符、拼写错误等。
- #NAME? - 某个单元格或其他公式对象无法按其名称找到。
- #NULL! - 当公式中有错误时可能出现，例如： (,) 或空格字符用作冒号(:)。
- #NUM! - 公式中的数字可能无效、过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置为数值单元格。

## **算术运算符**
你可以在图表工作表公式中使用所有算术运算符：

|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|+ (加号) |加法或一元加法|2 + 3|
|- (减号) |减法或取负|2 - 3<br>-3|
|* (星号)|乘法 |2 * 3|
|/ (斜杠)|除法 |2 / 3|
|% (百分号) |百分比 |30%|
|^ (尖号) |幂运算 |2 ^ 3|

*注意*：要更改评估顺序，请将要首先计算的公式部分用括号括起来。

## **比较运算符**
你可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是一个逻辑值，*TRUE* 或 FALSE：

|**运算符** |**含义** |**意义** |
| :- | :- | :- |
|= (等号) |等于 |A2 = 3|
|<> (不等号) |不等于|A2 <> 3|
|> (大于号) |大于|A2 > 3|
|>= (大于等于号)|大于或等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于等于号)|小于或等于|A2 <= 3|

## **A1样式单元格引用**
**A1样式单元格引用**用于工作表，其中列具有字母标识符（例如 "*A*"），行具有数字标识符（例如 "*1*"）。A1样式单元格引用可以这样使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

这是使用 A1样式单元格引用的公式示例：

## **R1C1样式单元格引用**
**R1C1样式单元格引用**用于工作表，其中行和列都有数字标识符。R1C1样式单元格引用可以这样使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

这是使用 A1样式单元格引用的公式示例：

## **预定义函数**
可以在公式中使用预定义函数以简化它们的实现。这些函数封装用于最常见的操作，如：

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