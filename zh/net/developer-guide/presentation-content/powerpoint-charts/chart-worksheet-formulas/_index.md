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
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 的图表工作表中应用 Excel 样式公式，并在 PPT 和 PPTX 文件中自动生成报告。"
---

## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或图表工作表）是图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表中呈现。当在 PowerPoint 中创建图表时，关联的工作表会自动创建。图表工作表适用于所有类型的图表：折线图、柱形图、旭辉图、饼图等。要在 PowerPoint 中查看图表电子表格，请双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时，图表电子表格数据会使用默认数据。随后可以手动在工作表中更改电子表格数据。

通常，图表代表复杂数据（例如财务分析、科学分析），其中的单元格会根据其它单元格的值或其它动态数据进行计算。手动计算单元格值并硬编码到单元格中，会导致以后修改困难。如果更改某个单元格的值，所有依赖它的单元格也必须更新。此外，表格数据可能依赖于其他表格的数据，形成复杂的演示文稿数据方案，需要以简便、灵活的方式进行更新。

**图表电子表格公式**是在演示文稿中用于自动计算并更新图表电子表格数据的表达式。公式定义了特定单元格或一组单元格的数据计算逻辑。图表电子表格公式可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格本身不包含普通值。公式计算出结果并返回，再将该结果赋给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，支持相同的默认函数、运算符和常量。

在[**Aspose.Slides**](https://products.aspose.com/slides/net/)中，图表电子表格通过
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性表示，类型为
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook)。  
可以使用
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性来赋值和更改公式。Aspose.Slides 对公式支持以下功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储上次计算的公式值。如果在加载演示文稿后图表数据没有变化，**IChartDataCell.Value**属性会返回这些值。但如果电子表格数据已更改，在读取 **ChartDataCell.Value** 属性时会抛出 **CellUnsupportedDataException**，因为不支持的公式无法解析。解析成功时会确定单元格依赖关系并验证上次值的正确性；若公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，使用
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1)  
在新演示文稿的第一页幻灯片上添加一个包含示例数据的图表。图表的工作表会自动创建，可通过
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性访问：
``` csharp

using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```


使用
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value)属性（类型为 **Object**）写入单元格值，这意味着可以向该属性设置任何值：
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```


现在要向单元格写入公式，可使用
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性：
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*注意*：使用 **IChartDataCell.Formula** 属性时采用 A1 样式单元格引用。

若要设置 **R1C1Formula** 单元格引用，可使用
[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)属性：
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


然后调用
[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) 方法，计算工作簿中的所有公式并更新相应单元格的值：
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **逻辑常量**
可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：

## **数值常量**
可以使用普通或科学计数法的数字来创建图表电子表格公式：

## **字符串常量**
字符串（或文字）常量是指按原样使用且不会改变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时公式无法计算出结果，此时单元格会显示错误代码而不是值。每种错误都有特定的代码：

- #DIV/0! – 公式尝试除以零。
- #GETTING_DATA – 单元格的值仍在计算中时可能显示此错误。
- #N/A – 信息缺失或不可用。原因可能包括：公式使用的单元格为空、存在额外空格、拼写错误等。
- #NAME? – 未能通过名称找到某个单元格或其它公式对象。
- #NULL! – 公式中出现错误，例如使用了 (,) 或空格代替冒号 (:)。
- #NUM! – 公式中的数值无效、过大或过小等。
- #REF! – 无效的单元格引用。
- #VALUE! – 值类型不符合预期。例如，将字符串值放入数值单元格。

## **算术运算符**
可以在图表工作表公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+（加号）|加法或一元正号|2 + 3|
|-（减号）|减法或取负|2 - 3<br>-3|
|*（星号）|乘法|2 * 3|
|/（斜杠）|除法|2 / 3|
|%（百分号）|百分比|30%|
|^（脱字符）|乘幂|2 ^ 3|

*注意*：若需改变计算顺序，请使用圆括号将先计算的部分括起来。

## **比较运算符**
可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 *FALSE*：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|=（等号）|等于|A2 = 3|
|<>（不等号）|不等于|A2 <> 3|
|>（大于号）|大于|A2 > 3|
|>=（大于等于号）|大于或等于|A2 >= 3|
|<（小于号）|小于|A2 < 3|
|<=（小于等于号）|小于或等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于列以字母标识（如 “A”），行以数字标识（如 “1”）的工作表。A1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**| | |
| :- | :- | :- | :- |
| |绝对引用|相对引用|混合引用|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是使用 A1 样式单元格引用的公式示例：

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于行列均以数字标识的工作表。R1C1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**| | |
| :- | :- | :- | :- |
| |绝对引用|相对引用|混合引用|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是使用 R1C1 样式单元格引用的公式示例：

## **预定义函数**
以下预定义函数可在公式中使用，以简化实现。这些函数封装了最常用的操作，例如：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE（1900 日期系统）
- DAYS
- FIND
- FINDB
- IF
- INDEX（引用形式）
- LOOKUP（向量形式）
- MATCH（向量形式）
- MAX
- SUM
- VLOOKUP

## **常见问题**

**是否支持将外部 Excel 文件作为带公式的图表数据源？**

是的。Aspose.Slides 支持将外部工作簿作为[图表的数据源](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/)，从而使用演示文稿之外的 XLSX 中的公式。

**图表公式是否可以通过工作表名称引用同一工作簿中的其他工作表？**

可以。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包括路径和工作簿名称。