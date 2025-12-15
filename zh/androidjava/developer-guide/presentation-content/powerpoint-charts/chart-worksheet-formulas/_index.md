---
title: 在 Android 上的演示文稿中应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "通过 Java 图表工作表在 Aspose.Slides for Android 中应用 Excel 样式公式，并在 PPT 与 PPTX 文件中实现报告自动化。"
---

## **关于演示文稿中图表电子表格公式**
**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含以图形方式在图表上呈现的数据。当您在 PowerPoint 中创建图表时，关联的工作表会自动创建。Chart worksheet 对所有类型的图表都会创建：折线图、柱形图、旭形图、饼图等。要在 PowerPoint 中查看 chart spreadsheet，您应该双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet 包含图表元素的名称（类别名称：*Category1*，系列名称）以及一个包含对应这些类别和系列的数值数据的表格。默认情况下，创建新图表时，chart spreadsheet 数据会使用默认数据进行设置。然后您可以在工作表中手动更改电子表格数据。

通常，图表表示复杂数据（例如财务分析、科学分析），其中的单元格是根据其他单元格的值或其他动态数据计算得到的。手动计算单元格的值并硬编码到单元格中，会导致将来难以更改。如果您更改某个单元格的值，所有依赖于它的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，从而形成一个需要以简便灵活方式更新的复杂演示数据方案。

演示文稿中的 **Chart spreadsheet formula** 是用于自动计算和更新 chart spreadsheet 数据的表达式。Spreadsheet formula 定义了某个单元格或一组单元格的数据计算逻辑。Spreadsheet formula 是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，而该单元格本身不包含简单值。Spreadsheet formula 计算出值并返回，然后该值被分配给单元格。演示文稿中的 chart spreadsheet formulas 实际上与 Excel 公式相同，并支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) 中，chart spreadsheet 由 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法表示，该方法属于 [**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook) 类型。

可以使用 [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法分配和更改 spreadsheet formula。

以下功能在 Aspose.Slides 的公式中受支持：

- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储最近一次计算的公式值。如果在加载演示文稿后图表数据未更改，则 [**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) 方法在读取时返回这些值。但如果电子表格数据已被更改，在读取 **ChartDataCell.Value** 属性时会抛出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException)，因为不支持的公式。这是因为当公式成功解析时，会确定单元格的依赖关系并确认最近值的正确性。但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加 Chart Spreadsheet 公式**
首先，使用 [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) 方法在新演示文稿的第一张幻灯片上添加图表。图表的工作表会自动创建，可通过 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法访问：
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


让我们使用 **Object** 类型的 [**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) 属性向单元格写入一些值，这意味着您可以向该属性设置任意值：
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


现在，要向单元格写入公式，您可以使用 [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法：

*注意*：[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) 方法用于设置 A1 样式单元格引用。

要设置 [R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) 单元格引用，您可以使用 [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) 方法：

然后，如果尝试读取单元格 B2 和 C2 的值，它们将被计算出来：
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 该值包含布尔值 "false"
```


## **数值常量**
可以使用常规或科学计数法的数字来创建 chart spreadsheet 公式：
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **字符串常量**
字符串（或字面量）常量是直接使用且不改变的特定值。字符串常量可以是：日期、文本、数字等：
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **错误常量**
有时无法通过公式计算出结果。在这种情况下，单元格会显示错误代码而不是其值。每种错误都有特定的代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能显示此错误。
- #N/A - 信息缺失或不可用。可能原因包括：公式中使用的单元格为空、存在多余空格、拼写错误等。
- #NAME? - 无法根据名称找到某个单元格或其他公式对象。
- #NULL! - 当公式中出现错误时可能出现，例如使用 (,) 或空格字符代替冒号 (:)。
- #NUM! - 公式中的数值可能无效、过长或过小等。
- #REF! - 无效的单元格引用。
- #VALUE! - 意外的值类型。例如，将字符串值设置到数值单元格。
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 该值包含字符串 "#DIV/0!"
```


## **算术运算符**
您可以在 chart worksheet 公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+（加号）|加法或一元加号|2 + 3|
|-（减号）|减法或取负|2 - 3<br>-3|
|*（星号）|乘法|2 * 3|
|/（斜杠）|除法|2 / 3|
|%（百分号）|百分比|30%|
|^（脱字符）|幂运算|2 ^ 3|

*注意*：要改变计算顺序，请使用括号将需先计算的部分括起来。

## **比较运算符**
您可以使用比较运算符比较单元格的值。当使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 FALSE：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|=（等号）|等于|A2 = 3|
|<>（不等号）|不等于|A2 <> 3|
|>（大于号）|大于|A2 > 3|
|>=（大于等于号）|大于等于|A2 >= 3|
|<（小于号）|小于|A2 < 3|
|<=（小于等于号）|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用** 用于工作表，其中列使用字母标识（如 *A*），行使用数字标识（如 *1*）。A1 样式单元格引用可以按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是一个在公式中使用 A1 样式单元格引用的示例：
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 样式单元格引用**
**R1C1 样式单元格引用** 用于工作表，其中行和列均使用数字标识。R1C1 样式单元格引用可以按以下方式使用：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是一个在公式中使用 R1C1 样式单元格引用的示例：
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **预定义函数**
有一些预定义函数可在公式中使用，以简化实现。这些函数封装了最常用的操作，例如：

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
**外部 Excel 文件是否支持作为包含公式的图表的数据源？**

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdatasourcetype/)，这使您可以使用演示文稿外部的 XLSX 中的公式。

**图表公式是否可以通过工作表名称引用同一本工作簿中的工作表？**

是的。公式遵循标准的 Excel 引用模型，因此您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。