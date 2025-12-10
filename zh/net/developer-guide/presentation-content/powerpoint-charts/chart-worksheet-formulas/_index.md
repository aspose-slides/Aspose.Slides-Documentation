---
title: 在 .NET 中对演示文稿应用图表工作表公式
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
**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含的数据以图形方式在图表中呈现。当您在 PowerPoint 中创建图表时，系统会自动创建与该图表关联的工作表。图表工作表适用于所有图表类型：折线图、柱形图、旭日图、饼图等。要在 PowerPoint 中查看图表电子表格，请双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet 包含图表元素的名称（Category Name: *Category1*，Serie Name）以及对应这些类别和系列的数值数据表。默认情况下，创建新图表时——图表电子表格数据会使用默认数据。随后您可以手动在工作表中更改电子表格数据。

通常，图表展示的是复杂数据（例如金融分析、科学分析），其中的单元格可能由其他单元格的值或其他动态数据计算得出。手动计算单元格值并硬编码到单元格中，会导致将来难以修改。如果您更改了某个单元格的值，所有依赖该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，从而形成一个需要易于灵活更新的复杂演示文稿数据方案。

**Chart spreadsheet formula** 在演示文稿中是一个用于自动计算和更新图表电子表格数据的表达式。电子表格公式定义了某个单元格或一组单元格的数据计算逻辑。电子表格公式可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，而该单元格本身不包含普通值。电子表格公式计算出结果并返回，然后将该结果赋给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/net/) 中，图表电子表格由 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) 属性表示，属于 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) 类型。  
电子表格公式可通过  
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) 属性进行分配和修改。  
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



通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后图表数据未被修改，**IChartDataCell.Value** 属性在读取时返回这些值。但如果电子表格数据已被更改，读取 **ChartDataCell.Value** 属性时会抛出 **CellUnsupportedDataException**，因为不支持的公式。原因在于，当公式成功解析时，会确定单元格依赖关系并验证上一次值的正确性；而如果公式无法解析，则无法保证单元格值的正确性。
## **向演示文稿中添加图表电子表格公式**
首先，使用 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) 在新演示文稿的第一张幻灯片上添加一个带有示例数据的图表。  
图表的工作表会自动创建，可通过  
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) 属性访问：
```csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...

}
```




使用  
[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) 属性（类型为 **Object**，表示可以向该属性设置任意值）向单元格写入一些数值：
```csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




现在要向单元格写入公式，可使用  
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) 属性：
```csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*Note*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) 属性用于设置 A1 样式单元格引用。 



要设置 [R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 单元格引用，可使用 [**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 属性：
```csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


随后使用 [**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) 方法计算工作簿中所有公式并更新相应单元格的值：
```csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：




## **数值常量**
数字可以使用常规或科学计数法表示，以创建图表电子表格公式：




## **字符串常量**
字符串（或文字）常量是指按原样使用且不改变的特定值。字符串常量可能是：日期、文本、数字等：




## **错误常量**
有时公式无法计算出结果，此时会在单元格中显示错误代码而非值。每种错误都有特定代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 可能在单元格上显示，表示其值仍在计算中。
- #N/A - 信息缺失或不可用。原因可能包括：公式使用的单元格为空、存在额外空格字符、拼写错误等。
- #NAME? - 无法通过名称找到某个单元格或其他公式对象。 
- #NULL! - 当公式中出现错误时可能出现，例如使用 (,) 或用空格字符代替冒号 (:)。
- #NUM! - 公式中的数值无效、过长或过短等。
- #REF! - 无效的单元格引用。
- #VALUE! - 值类型意外。例如，将字符串值放入数值单元格。




## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：



|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|+ (加号) |加法或一元加号|2 + 3|
|- (减号) |减法或取负号 |2 - 3<br>-3|
|* (星号)|乘法 |2 * 3|
|/ (斜杠)|除法 |2 / 3|
|% (百分号) |百分比 |30%|
|^ (脱字符)|幂运算 |2 ^ 3|


*Note*: 如需改变计算顺序，请使用括号将先计算的部分括起来。


## **比较运算符**
您可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 FALSE：



|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|= (等号) |等于 |A2 = 3|
|<> (不等号) |不等于|A2 <> 3|
|> (大于号) |大于|A2 > 3|
|>= (大于等于号)|大于等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于等于号)|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用** 用于列以字母标识（例如 "*A*"），行以数字标识（例如 "*1*"）的工作表。A1 样式单元格引用的用法如下：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对引用 |相对引用 |混合引用|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


以下示例展示了在公式中使用 A1 样式单元格引用的方式：




## **R1C1 样式单元格引用**
**R1C1 样式单元格引用** 用于行列均以数字标识的工作表。R1C1 样式单元格引用的用法如下：



|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对引用 |相对引用 |混合引用|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下示例展示了在公式中使用 A1 样式单元格引用的方式：




## **预定义函数**
以下预定义函数可在公式中使用，以简化实现。这些函数封装了最常用的操作，例如：

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

## **FAQ**

**是否支持使用外部 Excel 文件作为带公式图表的数据源？**

是的。Aspose.Slides 支持将外部工作簿用作 [图表的数据源](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/)，从而可以在演示文稿之外的 XLSX 中使用公式。

**图表公式能否通过工作表名称引用同一工作簿中的其他工作表？**

可以。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包括路径和工作簿名称。