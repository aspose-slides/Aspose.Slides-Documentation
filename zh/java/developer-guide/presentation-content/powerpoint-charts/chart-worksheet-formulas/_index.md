---
title: 在演示文稿中使用 Java 应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/java/chart-worksheet-formulas/
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 的图表工作表中应用 Excel 样式公式，并实现 PPT 和 PPTX 文件的报告自动化。"
---

## **关于演示文稿中的图表电子表格公式**
**图表电子表格**（或 chart worksheet）在演示文稿中是图表的数据源。图表电子表格包含数据，这些数据以图形方式在图表中呈现。当您在 PowerPoint 中创建图表时，关联的工作表也会自动创建。图表工作表适用于所有类型的图表：折线图、柱形图、旭辉图、饼图等。要在 PowerPoint 中查看图表电子表格，您应双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


图表电子表格包含图表元素的名称（类别名称：*Category1*，系列名称）以及与这些类别和系列对应的数值数据表。默认情况下，创建新图表时——图表电子表格数据会使用默认数据进行设置。然后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如财务分析、科学分析），其中的单元格通过其他单元格的值或其他动态数据进行计算。手动计算单元格值并硬编码到单元格中，会导致以后难以更改。如果您更改某个单元格的值，所有依赖于该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，形成一个需要以简便灵活方式更新的复杂演示文稿数据方案。

**图表电子表格公式**是用于自动计算和更新图表电子表格数据的表达式。电子表格公式为特定单元格或一组单元格定义了数据计算逻辑。电子表格公式是使用单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等的数学公式或逻辑公式。公式的定义写入单元格，而该单元格本身不包含简单的值。电子表格公式计算出值并返回，然后将该值分配给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，支持相同的默认函数、运算符和常量。

在[**Aspose.Slides**](https://products.aspose.com/slides/java/)中，图表电子表格由[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)方法表示，所属类型为[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook)。可以使用[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)方法为公式赋值或修改。Aspose.Slides 对公式支持以下功能：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1‑style 单元格引用
- R1C1‑style 单元格引用
- 预定义函数


通常，电子表格会存储最后计算的公式值。如果在加载演示文稿后图表数据未被更改，调用[**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--)方法时会返回这些值。但如果电子表格数据已被更改，在读取 **ChartDataCell.Value** 属性时会抛出[**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException)异常，原因是公式无法解析。因为只有成功解析的公式才能确定单元格依赖关系并验证最后值的正确性，而无法解析的公式则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，使用[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)方法在新演示文稿的第一张幻灯片上添加图表。图表的工作表会自动创建，可通过[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)方法访问：
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


让我们使用[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-)属性为**Object**类型的单元格写入一些值，这意味着您可以向该属性设置任何值：
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


现在要向单元格写入公式，可以使用[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)方法：

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)方法用于设置 A1‑style 单元格引用。

要设置 [R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) 单元格引用，可使用[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)方法：

然后如果读取单元格 B2 和 C2 的值，它们将被计算：
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
Object value = cell.getValue(); // 该值包含布尔值 "false"
```


## **数值常量**
可以使用普通记数法或科学计数法的数字来创建图表电子表格公式：
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **字符串常量**
字符串（或文字）常量是指以原样使用且不会改变的特定值。字符串常量可能是日期、文本、数字等：
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **错误常量**
有时公式无法计算出结果，此时单元格会显示错误代码而不是数值。每种错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 单元格的值仍在计算中时可能显示此错误。
- #N/A - 信息缺失或不可用。原因可能包括：公式中使用的单元格为空、多余的空格字符、拼写错误等。
- #NAME? - 无法按名称找到某个单元格或其他公式对象。
- #NULL! - 公式中出现错误，例如使用了 (,) 或将空格字符误作冒号 (:)。
- #NUM! - 公式中的数字无效、过长或过短等。
- #REF! - 无效的单元格引用。
- #VALUE! - 值类型不符合预期，例如将字符串赋给数值单元格。
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 该值包含字符串 "#DIV/0!"
```


## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (plus sign)|加法或一元加号|2 + 3|
|- (minus sign)|减法或取负号|2 - 3<br>-3|
|* (asterisk)|乘法|2 * 3|
|/ (forward slash)|除法|2 / 3|
|% (percent sign)|百分比|30%|
|^ (caret)|指数|2 ^ 3|

*Note*: 如需改变求值顺序，请使用括号将需要先计算的部分括起来。

## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 *FALSE*：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (equal sign)|等于|A2 = 3|
|<> (not equal sign)|不等于|A2 <> 3|
|> (greater than sign)|大于|A2 > 3|
|>= (greater than or equal to sign)|大于或等于|A2 >= 3|
|< (less than sign)|小于|A2 < 3|
|<= (less than or equal to sign)|小于或等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于列使用字母标识（如 "*A*"），行使用数字标识（如 "*1*"）的工作表。A1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是使用 A1 样式单元格引用的公式示例：
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于行列均使用数字标识的工作表。R1C1 样式单元格引用的使用方式如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对|相对|混合|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


下面是使用 R1C1 样式单元格引用的公式示例：
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **预定义函数**
以下是可在公式中使用的预定义函数，用于简化实现。这些函数封装了最常用的操作，例如：

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
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **常见问题**

**是否支持将外部 Excel 文件作为带公式的图表数据源？**

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/)，这样您可以使用演示文稿外部的 XLSX 文件中的公式。

**图表公式是否可以通过工作表名称引用同一工作簿内的其他工作表？**

是的。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，使用 Excel 语法包含路径和工作簿名称。