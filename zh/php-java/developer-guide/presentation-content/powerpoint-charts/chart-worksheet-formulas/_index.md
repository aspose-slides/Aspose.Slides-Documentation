---
title: 在演示文稿中使用 PHP 应用图表工作表公式
linktitle: 工作表公式
type: docs
weight: 70
url: /zh/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP 中通过 Java 图表工作表应用 Excel 样式公式，并在 PPT 和 PPTX 文件中自动生成报告。"
---

## **关于演示文稿中的图表电子表格公式**
**Chart spreadsheet**（或 chart worksheet）在演示文稿中是图表的数据源。Chart spreadsheet 包含的数据以图形方式显示在图表上。创建 PowerPoint 图表时，系统会自动创建与该图表关联的工作表。所有图表类型（折线图、柱状图、旭辉图、饼图等）都会创建图表工作表。要在 PowerPoint 中查看图表电子表格，双击图表即可：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet 包含图表元素的名称（Category Name: *Category1*、Serie Name）以及对应这些类别和系列的数值数据表。默认情况下，创建新图表时，图表电子表格数据会使用默认数据。随后可以手动在工作表中更改电子表格数据。

通常，图表用于展示复杂数据（例如金融分析、科学分析），其中的单元格会根据其他单元格或动态数据进行计算。手动计算单元格的值并硬编码到单元格中，会导致以后难以更改。如果修改某个单元格的值，所有依赖于该单元格的单元格也需要更新。此外，表格数据可能依赖于其他表格的数据，形成需要以简便灵活方式更新的复杂演示文稿数据方案。

**Chart spreadsheet formula** 在演示文稿中是一种自动计算并更新图表电子表格数据的表达式。电子表格公式定义了特定单元格或一组单元格的数据计算逻辑。公式可以是数学公式或逻辑公式，使用：单元格引用、数学函数、逻辑运算符、算术运算符、转换函数、字符串常量等。公式的定义写入单元格，该单元格本身不保存普通数值。电子表格公式计算出值并返回，然后将该值赋给单元格。演示文稿中的图表电子表格公式实际上与 Excel 公式相同，支持相同的默认函数、运算符和常量。

在[**Aspose.Slides**](https://products.aspose.com/slides/php-java/)中，图表电子表格由
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 方法表示，
对应的类型为[**ChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)。
可以使用
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) 方法来分配和更改公式。
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


通常，电子表格会存储上一次计算的公式值。如果在加载演示文稿后图表数据未更改，则
[**ChartDataCell::getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#getValue) 方法在读取时返回这些值。但如果电子表格数据已更改，在读取值时会抛出
[**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) 异常，表示公式不受支持。这是因为在公式成功解析后会确定单元格依赖关系并验证上一次值的正确性；若公式无法解析，则无法保证单元格值的正确性。

## **向演示文稿添加图表电子表格公式**
首先，使用
[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart)
在新演示文稿的第一张幻灯片上添加图表。
图表的工作表会自动创建，可通过
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 方法访问：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


接下来，使用
[**ChartDataCell::setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) 方法（**Object** 类型），向单元格写入任意值：
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```


现在，要向单元格写入公式，可使用
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) 方法。

*Note*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) 方法用于设置 A1 样式单元格引用。

若要使用 R1C1 样式设置公式，可使用
[**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 方法。

然后，如果读取单元格 B2 和 C2 的值，它们将被计算：
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **逻辑常量**
可以在单元格公式中使用逻辑常量，如 *FALSE* 和 *TRUE*：
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 该值包含布尔值 "false"
```


## **数值常量**
可以使用普通或科学计数法的数字创建图表电子表格公式：
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```


## **字符串常量**
字符串（或文字）常量是按原样使用且不会改变的特定值。字符串常量可以是日期、文本、数字等：
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");
```


## **错误常量**
有时公式无法计算出结果，此时单元格会显示错误代码而不是数值。每种错误都有特定代码：

- #DIV/0! - 公式尝试除以零。
- #GETTING_DATA - 单元格的值仍在计算中时可能显示此错误。
- #N/A - 信息缺失或不可用。可能原因包括：公式中使用的单元格为空、出现多余空格、拼写错误等。
- #NAME? - 无法按名称找到某个单元格或其他公式对象。
- #NULL! - 公式中出现错误，例如使用了 (,) 或将空格字符误作冒号 (:)。
- #NUM! - 公式中的数值无效、过长或过短等。
- #REF! - 无效的单元格引用。
- #VALUE! - 值类型不匹配。例如，将字符串赋给数值单元格。
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 该值包含字符串 "#DIV/0!"
```


## **算术运算符**
可以在图表工作表公式中使用所有算术运算符：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|+ (加号)|加法或一元加|2 + 3|
|- (减号)|减法或取负|2 - 3<br>-3|
|* (星号)|乘法|2 * 3|
|/ (斜杠)|除法|2 / 3|
|% (百分号)|百分比|30%|
|^ (脱字符)|指数|2 ^ 3|

*Note*: 若要改变计算顺序，请使用括号将先计算的部分括起来。

## **比较运算符**
可以使用比较运算符比较单元格的值。使用这些运算符比较两个值时，结果是逻辑值 *TRUE* 或 *FALSE*：

|**运算符**|**含义**|**示例**|
| :- | :- | :- |
|= (等号)|等于|A2 = 3|
|<> (不等号)|不等于|A2 <> 3|
|> (大于号)|大于|A2 > 3|
|>= (大于等于号)|大于等于|A2 >= 3|
|< (小于号)|小于|A2 < 3|
|<= (小于等于号)|小于等于|A2 <= 3|

## **A1 样式单元格引用**
**A1 样式单元格引用**用于列以字母标识（如 "*A*"）且行以数字标识（如 "*1*"）的工作表。A1 样式单元格引用的用法如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||**绝对**|**相对**|**混合**|
|单元格|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|范围|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


下面示例演示在公式中使用 A1 样式单元格引用：
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 样式单元格引用**
**R1C1 样式单元格引用**用于行列均采用数字标识的工作表。R1C1 样式单元格引用的用法如下：

|**单元格引用**|**示例**|||
| :- | :- | :- | :- |
||**绝对**|**相对**|**混合**|
|单元格|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|范围|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


下面示例演示在公式中使用 R1C1 样式单元格引用：
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **预定义函数**
以下预定义函数可用于公式中，以简化实现。这些函数封装了最常用的操作，例如：

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

## **常见问题**

**是否支持将外部 Excel 文件作为带公式的图表数据源？**

是的。Aspose.Slides 支持将外部工作簿用作[图表的数据源](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/)，从而可以在演示文稿之外的 XLSX 中使用公式。

**图表公式是否可以通过工作表名称引用同一工作簿中的其他工作表？**

是的。公式遵循标准的 Excel 引用模型，您可以引用同一工作簿或外部工作簿中的其他工作表。对于外部引用，请使用 Excel 语法在路径和工作簿名称中指定。