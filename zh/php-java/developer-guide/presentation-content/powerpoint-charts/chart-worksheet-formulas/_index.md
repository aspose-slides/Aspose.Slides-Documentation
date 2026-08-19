---
title: 在 PHP 演示文稿中应用图表工作表公式
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
- 图表数据工作簿
- 公式计算
- 逻辑常量
- 数值常量
- 字符串常量
- 错误常量
- 算术运算符
- 比较运算符
- A1 样式
- R1C1 样式
- 预定义函数
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP via Java 的图表工作表中应用 Excel 样式公式，重新计算数值，并在 PowerPoint 图表中使用结果。"
---
## **概述**

PowerPoint 图表通常将其源数据存储在嵌入的工作表中。在 Aspose.Slides for PHP via Java 中，您可以通过图表数据工作簿访问该工作表、写入输入值、为单元格分配公式、计算受支持的公式，并使用计算后的单元格作为图表数据。

本文解释了完整的公式工作流：创建图表、填充其工作表、分配 A1 样式或 R1C1 样式公式、重新计算它们、读取计算值、将这些单元格连接到图表系列并保存演示文稿。文中还描述了受支持的公式语法、内置函数子集、缓存值、不受支持的公式以及电子表格特定错误。

## **图表工作表和公式**

图表工作表包含图表使用的类别、系列名称和数值。在 PowerPoint 中，您可以通过打开图表数据编辑器来检查工作表：

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表通过 [ChartDataWorkbook](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/) 类公开。使用 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setFormula) 设置 A1 样式公式，使用 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 设置 R1C1 样式公式。更改输入单元格或公式后，调用 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 重新计算受支持的公式并更新相应的单元格值。

计算后的单元格仍通过 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#getValue) 暴露其结果。当您需要在代码中检查公式结果或将单元格用作图表数据点时，这一点非常重要。

## **创建图表并计算工作表公式**

下面的示例演示了端到端工作流。它创建一个簇状柱形图，清除示例数据，写入季度收入和支出值，使用公式计算利润，读取结果，将计算后的单元格用作图表值，并保存演示文稿。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

图表数据点引用 `D2:D4`，因此图表使用计算得到的利润值。在此工作流中没有单独的图表刷新调用：先重新计算工作簿，然后使用或保存指向计算单元格的图表数据。

## **使用 A1 样式公式**

A1 表示法使用字母标识列，使用数字标识行。通过 [ChartDataCell::setFormula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setFormula) 分配 A1 样式表达式。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

常见的 A1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 区域 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相对引用在公式被移动或复制时可能会更改。绝对引用固定两个坐标，而混合引用仅固定行或列。

## **使用 R1C1 样式公式**

R1C1 表示法使用数字标识行和列。相对引用使用方括号中的偏移量。通过 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 分配此语法。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

常见的 R1C1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 区域 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在单元格 `D2` 中，`RC[-2]` 表示同一行向左两列的单元格 (`B2`)。

## **公式常量和运算符**

内置公式求值器支持逻辑值、数值文字、字符串、电子表格错误值、算术运算符和比较运算符。

### **常量和文字**

| 类型 | 示例 | 备注 |
|---|---|---|
| 逻辑 | `TRUE`, `FALSE` | 可直接用于逻辑表达式，如 `A2=TRUE`。 |
| 数值 | `1`, `0.5`, `.3`, `1E-2` | 支持普通记数法和科学计数法。 |
| 字符串 | `"abc"`, `"2/3/2020 12:00"` | 文本文字需在公式内部用双引号括起。 |
| 错误结果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可能会计算为电子表格错误值，而不是正常结果。 |

以下示例使用了多种常量类型：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **算术运算符**

| 运算符 | 含义 | 示例 |
|---|---|---|
| `+` | 加法或一元加号 | `2+3` |
| `-` | 减法或取负 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 幂运算 | `2^3` |

使用括号可以明确求值顺序，例如 `(A2+B2)*C2`。

### **比较运算符**

比较表达式返回逻辑值。

| 运算符 | 含义 | 示例 |
|---|---|---|
| `=` | 等于 | `A2=3` |
| `<>` | 不等于 | `A2<>3` |
| `>` | 大于 | `A2>3` |
| `>=` | 大于等于 | `A2>=3` |
| `<` | 小于 | `A2<3` |
| `<=` | 小于等于 | `A2<=3` |

## **受支持的预定义函数**

Aspose.Slides 为图表工作表提供了内置公式求值器，但它并不是完整的 Excel 计算引擎。文档中列出的函数集仅限于下表所示的函数。不要假设任意 Excel 函数都可以通过 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 重新计算。

| 函数 | 目的或支持形式 | 示例 |
|---|---|---|
| `ABS` | 绝对值 | `ABS(A2)` |
| `AVERAGE` | 算术平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整到指定倍数 | `CEILING(A2,5)` |
| `CHOOSE` | 按索引选择值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 合并文本值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 合并文本值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系统创建日期值 | `DATE(2026,8,19)` |
| `DAYS` | 返回两个日期之间的天数 | `DAYS(B2,A2)` |
| `FIND` | 在文本中查找另一个文本 | `FIND("-",A2)` |
| `FINDB` | 基于字节的文本搜索 | `FINDB("a",A2)` |
| `IF` | 条件结果 | `IF(A2>0,A2,0)` |
| `INDEX` | 引用形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 求和 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表中显示的限制非常关键：`INDEX` 以引用形式记录，而 `LOOKUP` 和 `MATCH` 采用向量形式。`DATE` 使用 1900 日期系统。未在此列出的功能和函数应视为 Aspose.Slides 公式求值器不支持，除非另有文档说明。

## **重新计算和缓存值**

电子表格文件通常同时存储公式及其上一次计算的结果。Aspose.Slides 因此可以在加载演示文稿且相关图表数据未更改时，从 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#getValue) 读取缓存值。

在更改输入单元格或公式后，请勿依赖旧的缓存结果。读取计算值或保存依赖这些值的图表数据前，请先调用 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)。

对于不在受支持子集中的公式，Aspose.Slides 可能无法解析公式或确定其依赖关系。如果工作簿已被修改，先前的缓存值不再可靠。在这种情况下，读取包含不受支持数据的单元格值可能会抛出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellunsupporteddataexception/)。

如果您的图表依赖于 Aspose.Slides 不评估的 Excel 函数，请使用支持这些函数的电子表格引擎先行计算，然后将结果写回图表工作簿。不要用猜测的值替换不受支持的公式。

## **处理公式错误**

需要区分两种不同的问题。

公式本身可能有效，但会产生电子表格错误结果，如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!` 或 `#VALUE!`。在这种情况下，错误标记是单元格的结果，可通过 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#getValue) 返回。

公式也可能在解析、引用、依赖或支持数据层面失败。Aspose.Slides 为这些情况提供了特定的电子表格异常： [CellInvalidFormulaException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellcircularreferenceexception/) 和 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellunsupporteddataexception/)。

在 PHP via Java 中，Java 异常会通过 `JavaException` 暴露。当公式来自模板或用户输入时，请在重新计算和访问值的代码块中捕获并处理这些异常。堆栈跟踪中报告的 Java 异常能够指明具体的电子表格失败原因：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **实际限制**

图表工作表中的公式支持旨在覆盖一组定义好的电子表格计算，而非完整的 Excel 兼容性。在设计报告工作流时请牢记以下约束：

- 仅使用文档中列出的常量、运算符、引用方式和函数，以便 Aspose.Slides 能重新计算公式。
- 在更改公式结果依赖的单元格后进行重新计算。
- 将加载的演示文稿中的缓存值视为快照，而不是在编辑后无需重新计算的替代方案。
- 在依赖模板中已有的公式计算值之前，请先对这些公式进行测试，特别是当它们使用未列出的函数时。
- 对于需要完整电子表格计算引擎的公式，请先在外部计算后再将结果写入图表工作簿。

## **常见问题**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setFormula) 与 [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 有何区别？**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setFormula) 存储类似 `B2-C2` 的 A1 样式表达式。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#setR1C1Formula) 存储类似 `RC[-2]-RC[-1]` 的 R1C1 样式表达式。请选择最符合您生成或复制公式方式的表示法。

**在计算后，我需要读取单元格本身还是它的值？**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#getCell) 返回一个 [ChartDataCell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/)。要获取计算结果，请在重新计算后调用该单元格的 [ChartDataCell::getValue](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdatacell/#getValue) 方法。

**何时应调用 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)？**

在更改输入值或公式后、在依赖计算结果之前，调用 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)。这会更新内置求值器支持的公式值。

**Aspose.Slides 是否支持所有 Excel 函数？**

不支持。内置求值器仅支持文档中列出的函数子集。未列出的函数不应被假设能够正确重新计算。若需要完整的 Excel 公式兼容性，请使用合适的电子表格引擎进行计算，然后将最终值写入图表工作簿。

**如果加载的演示文稿包含不受支持的公式会怎样？**

如果图表数据未改变，工作簿可能仍保留先前计算的缓存值。修改相关数据后，该缓存值可能不再有效。尝试访问无法处理的公式单元格可能会抛出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellunsupporteddataexception/)。

**公式错误值与 PHP 异常是同一回事吗？**

不是。`#DIV/0!` 等结果是有效计算产生的电子表格值。诸如 [CellInvalidFormulaException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellinvalidformulaexception/) 或 [CellCircularReferenceException](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cellcircularreferenceexception/) 等电子表格处理失败会以 Java 异常形式出现，并通过 `JavaException` 传递给 PHP。

**当公式单元格更改时，图表会自动更新吗？**

图表系列可以引用工作簿单元格。先重新计算工作簿，然后保存或呈现演示文稿。如果图表数据点引用的是计算单元格，图表会使用这些更新后的值；此工作流不需要额外的图表刷新方法。

**图表可以使用外部 Excel 工作簿吗？**

可以，图表数据可以通过图表数据 API 配置为使用外部工作簿。不过，本文描述的公式计算工作流仅针对图表数据工作簿以及 Aspose.Slides 所评估的公式子集。不要假设 [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) 能对外部 XLSX 文件中的任意公式进行完整重新计算。

**我可以使用引用其他工作表或工作簿的公式吗？**

Excel 样式的跨工作表或跨工作簿引用在图表工作簿中可能存在，但公式求值受限于支持的解析器和函数集。如果跨表或外部引用是必需的，请在目标 Aspose.Slides 版本中验证该公式的可行性。对于需要广泛 Excel 引用兼容性的工作流，建议在外部计算工作簿并将解析后的值写回图表数据。

**公式字符串需要以 `=` 开头吗？**

Aspose.Slides API 示例中分配的表达式如 `B2-C2` 或 `SUM(B2:B5)` 并未以 `=` 开头。使用这种形式可以让生成的公式与文档中示例保持一致。