---
title: 图表工作表公式
type: docs
weight: 70
url: /zh/net/chart-worksheet-formulas/
keywords: "图表电子表格, 图表公式, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "图表电子表格和C#或.NET中的PowerPoint演示文稿的公式"
---


## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或图表工作表）是在演示文稿中的图表数据源。图表电子表格包含的数据以图形方式显示在图表上。当您在PowerPoint中创建图表时，与该图表相关的工作表也会自动创建。图表工作表为所有类型的图表创建：折线图、条形图、旭日图、饼图等。要在PowerPoint中查看图表电子表格，您应该双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)



图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列相对应的数值数据表。默认情况下，当您创建新图表时，图表电子表格的数据是使用默认数据设置的。然后，您可以手动更改工作表中的电子表格数据。

通常，图表表示复杂数据（例如，财务分析师、科学分析师），具有从其他单元格的值或其他动态数据计算得出的单元格。手动计算单元格的值并将其硬编码到单元格中，将使得将来更改变得困难。如果您更改某个单元格的值，所有依赖于它的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，创建一个复杂的演示文稿数据方案，需要以简单和灵活的方式进行更新。

**图表电子表格公式**是在演示文稿中用于自动计算和更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或一组单元格的数据计算逻辑。电子表格公式是一个数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格中，并且该单元格不包含简单值。电子表格公式计算值并将其返回，然后该值被分配给单元格。演示文稿中的图表电子表格公式实际上与excel公式相同，并且支持相同的默认函数、运算符和常量以实现它们。

在[**Aspose.Slides**](https://products.aspose.com/slides/net/)中，图表电子表格通过
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性表示，该属性属于
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook)类型。
电子表格公式可以通过
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性进行分配和更改。
Aspose.Slides支持以下公式功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1风格的单元格引用
- R1C1风格的单元格引用
- 预定义函数



通常，电子表格存储最后计算的公式值。如果在演示文稿加载后，图表数据没有更改 - **IChartDataCell.Value**属性在读取时返回这些值。但是，如果电子表格数据发生了更改，在读取**ChartDataCell.Value**属性时，它会为不支持的公式抛出**CellUnsupportedDataException**。这是因为当公式成功解析时，单元格依赖关系被确定，最后值的正确性被确定。但是，如果公式无法解析，则不能保证单元格值的正确性。
## **将图表电子表格公式添加到演示文稿**
首先，通过
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1)在新演示文稿的第一页添加一个图表并包含一些示例数据。
图表的工作表会自动创建，并可以通过
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)属性访问：



``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}

```



让我们在单元格中写入一些值，通过
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value)属性
的**Object**类型，这意味着您可以将任何值设置为该属性：



``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```



现在，要将公式写入单元格，您可以使用
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性：

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*注意*：[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)属性用于设置A1风格的单元格引用。



要设置[R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)单元格引用，您可以使用
[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)属性：

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

然后使用[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas)方法计算工作簿中的所有公式并更新相应的单元格值：



``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，如*FALSE*和*TRUE*：




## **数值常量**
数字可以采用常规或科学记数法在图表电子表格公式中使用：




## **字符串常量**
字符串（或字面量）常量是一个特定值，用于原样使用且不改变。字符串常量可以是：日期、文本、数字等：




## **错误常量**
有时无法通过公式计算结果。在这种情况下，单元格中显示错误代码而不是其值。每种错误类型都有特定代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 可能在单元格中显示，而其值仍在计算中。
- #N/A - 信息缺失或不可用。一些原因可能是：公式中使用的单元格为空、多余的空格字符、拼写错误等。
- #NAME? - 无法通过名称找到某个单元格或其他公式对象。
- #NULL! - 公式中有错误，例如：使用（，）或空格字符代替冒号（:）。
- #NUM! - 公式中的数值可能无效、过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置为数值单元格。




## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：



|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|+（加号） |加法或一元加法|2 + 3|
|-（减号） |减法或取负 |2 - 3<br>-3|
|*（星号）|乘法 |2 * 3|
|/（正斜杠）|除法 |2 / 3|
|%（百分号） |百分比 |30%|
|^（插入符号）|幂运算 |2 ^ 3|


*注意*：要更改评估顺序，请将要首先计算的公式部分括在括号中。


## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是逻辑值*TRUE*或FALSE：



|**运算符** |**含义** |**含义** |
| :- | :- | :- |
|=（等号） |等于 |A2 = 3|
|<>（不等号） |不等于|A2 <> 3|
|>（大于号） |大于|A2 > 3|
|>=（大于或等于号）|大于或等于|A2 >= 3|
|<（小于号）|小于|A2 < 3|
|<=（小于或等于号）|小于或等于|A2 <= 3|

## **A1风格的单元格引用**
**A1风格的单元格引用**用于工作表，其中列具有字母标识符（例如“*A*”）而行具有数字标识符（例如“*1*”）。A1风格的单元格引用可以按以下方式使用：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


以下是如何在公式中使用A1风格的单元格引用的示例：




## **R1C1风格的单元格引用**
**R1C1风格的单元格引用**用于工作表，其中行和列都有数字标识符。R1C1风格的单元格引用可以按以下方式使用：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下是如何在公式中使用A1风格的单元格引用的示例：




## **预定义函数**
有一些预定义函数可以在公式中使用以简化其实现。这些函数封装了最常用的操作，如： 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE（1900年日期系统）
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