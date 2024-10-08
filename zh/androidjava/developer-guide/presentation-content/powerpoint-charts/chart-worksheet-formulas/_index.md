---
title: 图表工作表公式
type: docs
weight: 70
url: /androidjava/chart-worksheet-formulas/
keywords: "powerpoint 方程, powerpoint 电子表格公式"
description: "PowerPoint 方程和电子表格公式"
---


## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或称图表工作表）是在演示文稿中图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表上表示。当您在 PowerPoint 中创建图表时，与该图表关联的工作表也会自动创建。所有类型的图表都将创建图表工作表：折线图、条形图、旭日图、饼图等。要在 PowerPoint 中查看图表电子表格，您应该双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）和适用于这些类别和系列的数字数据表。默认情况下，当您创建新图表时，图表电子表格数据将设置为默认数据。然后，您可以手动更改工作表中的电子表格数据。

通常，图表表示复杂的数据（例如，财务分析师、科学分析师），具有从其他单元格的值或其他动态数据计算得出的单元格。手动计算单元格的值并将其硬编码到单元格中，使将来更改变得困难。如果您更改某个单元格的值，所有依赖于该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表的数据，从而创建一个复杂的演示数据方案，需要以简单且灵活的方式进行更新。

**演示文稿中的图表电子表格公式**是一个自动计算和更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或一组单元格的数据计算逻辑。电子表格公式是一个数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格中，并且该单元格不包含简单的值。电子表格公式计算值并将其返回，然后该值被分配给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，并且用于实现的默认功能、运算符和常量是支持相同的。

在 [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) 中，图表电子表格通过
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法表示为
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook) 类型。
电子表格公式可以通过 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法进行赋值和更改。
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


通常，电子表格存储最后计算的公式值。如果在演示加载后，图表数据没有更改 - [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) 方法在读取时返回这些值。但如果电子表格数据已经更改，在读取 **ChartDataCell.Value** 属性时，对于不支持的公式，它会抛出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException)。这是因为在公式成功解析后，单元格的依赖关系被确定，最后值的正确性也得到了确认。但是，如果公式无法解析，则无法保证单元格值的正确性。

## **将图表电子表格公式添加到演示文稿**
首先，使用 [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) 将图表添加到新演示文稿的第一页幻灯片。
图表的工作表会自动创建，并且可以通过 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法访问：


```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

现在我们可以使用 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 属性将一些值写入单元格，**Object** 类型意味着您可以将任何值设置到属性中：

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

现在要将公式写入单元格，您可以使用 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法：

*注意*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法用于设置 A1 样式单元格引用。 

要设置 [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) 单元格引用，您可以使用 [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) 方法：

然后，如果您尝试从单元格 B2 和 C2 读取值，它们将被计算：

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **逻辑常量**
您可以在单元格公式中使用逻辑常量，如 *FALSE* 和 *TRUE*：

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 值包含布尔值 "false"
```

## **数值常量**
数字可以用常规或科学记数法表示以创建图表电子表格公式：

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **字符串常量**
字符串（或字面量）常量是特定值，它以原样使用并且不会改变。字符串常量可以是：日期、文本、数字等：

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **错误常量**
有时无法通过公式计算结果。在这种情况下，错误代码会显示在单元格中，而不是其值。每种类型的错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时，可能会显示在单元格上。
- #N/A - 信息缺失或不可用。一些原因可能是：公式中使用的单元格为空、额外的空格字符、拼写错误等。
- #NAME? - 找不到某个单元格或其他公式对象的名称。 
- #NULL! - 当公式中存在错误时可能会出现，如：  (,) 或空格字符用作冒号 (:).
- #NUM! - 公式中的数字可能无效，过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置到数字单元格中。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 值包含字符串 "#DIV/0!"
```

## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：

|**运算符** |**含义** |**示例**|
| :- | :- | :- |
|+ (加号) |加法或一元加|2 + 3|
|- (减号) |减法或取反 |2 - 3<br>-3|
|* (星号)|乘法 |2 * 3|
|/ (斜杠)|除法 |2 / 3|
|% (百分号) |百分比 |30%|
|^ (抬头) |指数运算 |2 ^ 3|

*注意*: 要改变计算的顺序，请将要先计算部分括在括号中。

## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果是逻辑值要么为 *TRUE* 要么为 FALSE：

|**运算符** |**含义** |**含义** |
| :- | :- | :- |
|= (等于号) |等于 |A2 = 3|
|<> (不等于号) |不等于|A2 <> 3|
|> (大于号) |大于|A2 > 3|
|>= (大于或等于号)|大于或等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于或等于号)|小于或等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于工作表，其中列有字母标识符（例如 "*A*"），行有数字标识符（例如 "*1*"）。A1 样式单元格引用可以以以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


以下是如何在公式中使用 A1 样式单元格引用的示例：

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于工作表，其中行和列都有数字标识符。R1C1 样式单元格引用可以以以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下是如何在公式中使用 R1C1 样式单元格引用的示例：

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **预定义函数**
有一些预定义函数，可以在公式中使用以简化它们的实现。这些函数封装了最常用的操作，如： 

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 年日期系统)
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