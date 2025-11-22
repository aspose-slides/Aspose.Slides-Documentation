---
title: 图表工作表公式
type: docs
weight: 70
url: /zh/net/chart-worksheet-formulas/
keywords: "图表电子表格, 图表公式, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中使用 C# 或 .NET 的图表电子表格和公式"
---

## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或图表工作表）在演示文稿中是图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表上显示。当您在 PowerPoint 中创建图表时，关联的工作表也会自动创建。图表工作表适用于所有类型的图表：折线图、条形图、旭辉图、饼图等。要在 PowerPoint 中查看图表电子表格，您应双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时，图表电子表格数据会使用默认数据进行设置。随后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如金融分析、科学分析），其单元格的值是由其他单元格或其他动态数据计算得出的。手动计算单元格值并硬编码到单元格中，会使未来的更改变得困难。如果更改某个单元格的值，所有依赖该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，从而形成一个复杂的演示文稿数据方案，需要以简便灵活的方式进行更新。

**图表电子表格公式**在演示文稿中是一种用于自动计算和更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或一组单元格的数据计算逻辑。电子表格公式是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，而该单元格不包含简单值。电子表格公式计算出值并返回，然后将该值赋给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，并且支持相同的默认函数、运算符和常量以实现它们。

在[**Aspose.Slides**](https://products.aspose.com/slides/net/)中，图表电子表格由
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性（属于
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook)类型）表示。
可以使用
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性分配和更改电子表格公式。
Aspose.Slides 中支持以下公式功能：
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后，图表数据未被更改，**IChartDataCell.Value**属性在读取时会返回这些值。但是，如果电子表格数据已更改，在读取 **ChartDataCell.Value** 属性时会抛出 **CellUnsupportedDataException**，因为不支持的公式。这是因为当公式成功解析时，会确定单元格的依赖关系并确定上一次值的正确性。但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，使用[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1)在新演示文稿的第一张幻灯片上添加包含一些示例数据的图表。图表的工作表会自动创建，可通过
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性访问：

``` csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```


让我们使用
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value)属性
在**Object**类型的单元格中写入一些值，这意味着您可以为该属性设置任意值：

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```


现在要向单元格写入公式，您可以使用
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性：

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*注意*： [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性用于设置 A1 样式单元格引用。

要设置[R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)单元格引用，您可以使用[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)属性：

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


然后使用[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas)方法计算工作簿内的所有公式并更新相应单元格的值：

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **逻辑常量**
您可以在单元格公式中使用诸如 *FALSE* 和 *TRUE* 的逻辑常量：

## **数值常量**
数字可以使用普通记数法或科学记数法来创建图表电子表格公式：

## **字符串常量**
字符串（或文字）常量是按原样使用且不改变的特定值。字符串常量可以是：日期、文本、数字等：

## **错误常量**
有时公式无法计算出结果。在这种情况下，单元格会显示错误代码而不是值。每种错误都有特定的代码：
- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能会显示此错误。
- #N/A - 信息缺失或不可用。可能原因包括：公式中使用的单元格为空、存在额外空格字符、拼写错误等。
- #NAME? - 某个单元格或其他公式对象未能通过名称找到。
- #NULL! - 当公式中出现错误时可能出现，例如使用（，）或空格字符代替冒号（:）。
- #NUM! - 公式中的数字可能无效、过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置到数值单元格中。

## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (加号)|加法或一元加号|2 + 3|
|- (减号)|减法或取负号|2 - 3<br>-3|
|* (星号)|乘法|2 * 3|
|/ (斜杠)|除法|2 / 3|
|% (百分号)|百分比|30%|
|^ (脱字符)|指数|2 ^ 3|

*注意*：要更改求值顺序，请在需要首先计算的公式部分加上括号。

## **比较运算符**
您可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果是逻辑值 *TRUE* 或 FALSE：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (等号)|等于|A2 = 3|
|<> (不等号)|不等于|A2 <> 3|
|> (大于号)|大于|A2 > 3|
|>= (大于等于号)|大于等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于等于号)|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于工作表，其中列使用字母标识（例如 “*A*”），行使用数字标识（例如 “*1*”）。A1 样式单元格引用可按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||**绝对**|**相对**|**混合**|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是一个在公式中使用 A1 样式单元格引用的示例：

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于工作表，其中行和列均使用数字标识。R1C1 样式单元格引用可按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是一个在公式中使用 R1C1 样式单元格引用的示例：

## **预定义函数**
有一些预定义函数，可在公式中使用以简化实现。这些函数封装了最常用的操作，例如：
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
是的。Aspose.Slides 支持将外部工作簿作为[图表的数据源](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/)，从而允许在演示文稿之外的 XLSX 中使用公式。

**图表公式是否可以通过工作表名称引用同一工作簿内的工作表？**
是的。公式遵循标准的 Excel 引用模型，因此您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。