---
title: 图表工作表公式
type: docs
weight: 70
url: /zh/nodejs-java/chart-worksheet-formulas/
keywords: "PowerPoint 方程式, PowerPoint 电子表格公式"
description: "PowerPoint 方程式和电子表格公式"
---

## **关于演示文稿中的图表电子表格公式**
**Chart spreadsheet**（or chart worksheet）在演示文稿中是图表的数据源。 Chart spreadsheet 包含数据，这些数据以图形方式在图表上呈现。当您在 PowerPoint 中创建图表时，关联的工作表也会自动创建。Chart worksheet 会为所有类型的图表创建：折线图、柱状图、旭日图、饼图等。要在 PowerPoint 中查看 chart spreadsheet，请双击图表：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet 包含图表元素的名称（Category Name: *Category1*，Serie Name）以及与这些类别和序列对应的数值数据表。默认情况下，创建新图表时，chart spreadsheet 数据会使用默认数据进行设置。随后您可以手动在工作表中更改电子表格数据。

通常，图表表示复杂数据（例如金融分析、科学分析），其中的单元格会根据其他单元格的值或其他动态数据进行计算。手动计算单元格的值并将其硬编码到单元格中，会导致将来难以更改。如果您更改某个单元格的值，所有依赖于该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，形成一个需要以简便灵活方式更新的复杂演示文稿数据方案。

**Chart spreadsheet formula** 在演示文稿中是一种用于自动计算和更新 chart spreadsheet 数据的表达式。Spreadsheet formula 为特定单元格或一组单元格定义了数据计算逻辑。Spreadsheet formula 是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格不包含普通数值。Spreadsheet formula 计算出数值并返回，然后将该数值赋给单元格。演示文稿中的 chart spreadsheet 公式实际上与 Excel 公式相同，并支持相同的默认函数、运算符和常量。

在 [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) 中，chart spreadsheet 通过 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 方法表示，属于 [**ChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) 类型。可以使用 [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法分配和更改 Spreadsheet formula。Aspose.Slides 对公式支持以下功能：
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式单元格引用
- R1C1 样式单元格引用
- 预定义函数

通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后图表数据未更改，`[**ChartDataCell.getValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getValue--)` 方法在读取时会返回这些值。但是，如果电子表格数据已更改，在读取 **ChartDataCell.Value** 属性时会抛出 [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellUnsupportedDataException)，表示不支持的公式。这是因为当公式成功解析时，会确定单元格依赖关系并验证上一次值的正确性。但如果公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，在新演示文稿的第一张幻灯片上使用 [ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-) 添加图表。图表的工作表会自动创建，可通过 [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) 方法访问：```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


让我们使用 **Object** 类型的 [**ChartDataCell.setValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) 属性向单元格写入一些值，这意味着您可以为该属性设置任意值：```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```


现在要向单元格写入公式，可以使用 [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法：

*注意*： [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) 方法用于设置 A1 样式单元格引用。

要设置 [R1C1Formula](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) 单元格引用，可使用 [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) 方法：

然后如果尝试读取单元格 B2 和 C2 的值，它们将被计算：```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```


## **逻辑常量**
您可以在单元格公式中使用逻辑常量，例如 *FALSE* 和 *TRUE*：```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// 值包含布尔值 "false"
```


## **数值常量**
数字可以以普通或科学计数法表示，用于创建图表电子表格公式：```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **字符串常量**
字符串（或文字）常量是直接使用且不变的特定值。字符串常量可以是：日期、文本、数字等：```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **错误常量**
有时公式无法计算出结果。此时，单元格会显示错误代码而非值。每种错误都有特定的代码：
- #DIV/0! - 公式试图除以零。
- #GETTING_DATA - 当单元格的值仍在计算时可能会显示此错误。
- #N/A - 信息缺失或不可用。可能原因包括：公式中使用的单元格为空、存在额外空格、拼写错误等。
- #NAME? - 找不到某个单元格或其他公式对象的名称。
- #NULL! - 当公式中出现错误时可能出现，例如使用 (,) 或用空格代替冒号 (:)。
- #NUM! - 公式中的数字可能无效、过长或过短等。
- #REF! - 单元格引用无效。
- #VALUE! - 值类型不符合预期。例如，将字符串值设置到数值单元格。
```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// 值包含字符串 "#DIV/0!"
```


## **算术运算符**
您可以在图表工作表公式中使用所有算术运算符：

|**Operator** |**Meaning** |**Example**|
| :- | :- | :- |
|+ (加号) |加法或一元正号|2 + 3|
|- (减号) |减法或取负|2 - 3<br>-3|
|* (星号)|乘法|2 * 3|
|/ (斜杠)|除法|2 / 3|
|% (百分号) |百分比|30%|
|^ (脱字符) |幂运算|2 ^ 3|

*注*：要更改求值顺序，请使用括号将先计算的公式部分括起来。

## **比较运算符**
您可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果为逻辑值 *TRUE* 或 FALSE：

|**Operator** |**Meaning** |**Meaning** |
| :- | :- | :- |
|= (等号) |等于|A2 = 3|
|<> (不等于) |不等于|A2 <> 3|
|> (大于) |大于|A2 > 3|
|>= (大于等于) |大于等于|A2 >= 3|
|< (小于) |小于|A2 < 3|
|<= (小于等于) |小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用** 用于工作表，其中列使用字母标识（如 "*A*"），行使用数字标识（如 "*1*"）。A1 样式单元格引用可按如下方式使用：

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|范围 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

下面是使用 A1 样式单元格引用的公式示例：```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 样式单元格引用**
**R1C1 样式单元格引用** 用于工作表，其中行和列均使用数字标识。R1C1 样式单元格引用可按以下方式使用：

|**Cell reference**|**Example**|||
| :- | :- | :- | :- |
||绝对 |相对 |混合|
|单元格 |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|范围 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

下面是使用 R1C1 样式单元格引用的公式示例：```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **预定义函数**
预定义函数可用于公式中，以简化实现。这些函数封装了最常用的操作，例如：

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

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatasourcetype/)，从而在演示文稿之外的 XLSX 中使用公式。

**图表公式是否可以通过工作表名称引用同一工作簿中的工作表？**

是的。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法包含路径和工作簿名称。