---
title: 在 Java 演示文稿中应用图表工作表公式
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
- 图表数据工作簿
- 公式计算
- 首选语言环境
- 特定语言环境公式
- 双字节字符集
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
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Java 的图表工作表中应用 Excel 样式公式，重新计算数值，并在 PowerPoint 图表中使用结果。"
---
## **概述**

PowerPoint 图表通常将其源数据存储在嵌入的工作表中。在 Aspose.Slides for Java 中，您可以通过图表数据工作簿访问该工作表，写入输入值，为单元格分配公式，计算受支持的公式，并将计算后的单元格用作图表数据。

本文阐述了完整的公式工作流：创建图表，填充其工作表，分配 A1 样式或 R1C1 样式的公式，重新计算它们，读取计算结果，将这些单元格连接到图表系列，并保存演示文稿。同时还描述了受支持的公式语法、内置函数子集、缓存值、不受支持的公式以及特定于电子表格的错误。

## **图表工作表和公式**

图表工作表包含图表使用的类别、系列名称和数值。  
在 PowerPoint 中，您可以通过打开图表数据编辑器来检查工作表：

![PowerPoint 图表以及打开的嵌入工作表，显示类别和系列数据](chart-worksheet-formulas_1.png)

在 Aspose.Slides 中，工作表通过 [IChartDataWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/) 接口暴露。对于 A1 样式的公式，请使用 [IChartDataCell.setFormula](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-)。对于 R1C1 样式的公式，请使用 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)。在更改输入单元格或公式后，调用 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) 以重新计算受支持的公式并更新相应的单元格值。

计算后的单元格仍然通过 [IChartDataCell.getValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#getValue--) 暴露其结果。当您需要在代码中检查公式结果或将单元格用作图表数据点时，这一点尤为重要。

## **创建图表并计算工作表公式**

下面的示例演示了一个端到端的工作流。它创建了一个簇状柱形图，清除示例数据，写入季度收入和支出值，使用公式计算利润，读取结果，将计算后的单元格用作图表数值，并保存演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

图表数据点引用 `D2:D4`，因此图表使用计算后的利润值。在此工作流中没有单独的图表刷新调用：先重新计算工作簿，然后使用或保存指向计算单元格的图表数据。

## **使用 A1 样式公式**

A1 表示法使用字母标识列，使用数字标识行。通过 [IChartDataCell.setFormula](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) 分配 A1 样式的表达式。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

常见的 A1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 范围 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相对引用在电子表格应用移动或复制公式时可能会改变。绝对引用保持两个坐标均固定，而混合引用仅固定行或列。

## **使用 R1C1 样式公式**

R1C1 表示法以数字标识行和列。相对引用使用方括号中的偏移量。通过 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) 分配此语法。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

常见的 R1C1 引用形式如下：

| 引用 | 相对 | 绝对 | 混合 |
|---|---|---|---|
| 单元格 | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 范围 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例如，在单元格 `D2` 中，`RC[-2]` 表示同一行向左两个列的单元格（`B2`）。

## **公式常量和运算符**

内置公式求值器支持逻辑值、数字字面量、字符串、电子表格错误值、算术运算符和比较运算符。

### **常量和字面量**

| 类型 | 示例 | 备注 |
|---|---|---|
| 逻辑 | `TRUE`, `FALSE` | 可直接在逻辑表达式中使用，例如 `A2=TRUE`。 |
| 数值 | `1`, `0.5`, `.3`, `1E-2` | 支持常规和科学计数法。 |
| 字符串 | `"abc"`, `"2/3/2020 12:00"` | 文本字面量在公式中使用双引号括起来。 |
| 错误结果 | `#DIV/0!`, `#N/A`, `#REF!` | 有效公式可以求值为电子表格错误值，而非普通结果。 |

此示例使用了多种常量类型：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // 假
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **算术运算符**

| 运算符 | 含义 | 示例 |
|---|---|---|
| `+` | 加法或一元正号 | `2+3` |
| `-` | 减法或取负 | `2-3`, `-3` |
| `*` | 乘法 | `2*3` |
| `/` | 除法 | `2/3` |
| `%` | 百分比 | `30%` |
| `^` | 指数 | `2^3` |

使用括号可以明确求值顺序，例如 `(A2+B2)*C2`。

### **比较运算符**

比较表达式返回逻辑值。

| 运算符 | 含义 | 示例 |
|---|---|---|
| `=` | 等于 | `A2=3` |
| `<>` | 不等于 | `A2<>3` |
| `>` | 大于 | `A2>3` |
| `>=` | 大于或等于 | `A2>=3` |
| `<` | 小于 | `A2<3` |
| `<=` | 小于或等于 | `A2<=3` |

## **受支持的预定义函数**

Aspose.Slides 为图表工作表提供了内置公式求值器，但它并非完整的 Excel 计算引擎。文档中列出的函数集仅限于下表中的函数。不要假设任意 Excel 函数都可以通过 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) 重新计算。

| 函数 | 目的或支持的形式 | 示例 |
|---|---|---|
| `ABS` | 绝对值 | `ABS(A2)` |
| `AVERAGE` | 算术平均值 | `AVERAGE(B2:B5)` |
| `CEILING` | 向上取整到指定倍数 | `CEILING(A2,5)` |
| `CHOOSE` | 按索引选择值 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 连接文本值 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 连接文本值 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 使用 1900 日期系统创建日期值 | `DATE(2026,8,19)` |
| `DAYS` | 返回两个日期之间的天数 | `DAYS(B2,A2)` |
| `FIND` | 在文本中查找另一文本 | `FIND("-",A2)` |
| `FINDB` | 基于字节的文本搜索 | `FINDB("a",A2)` |
| `IF` | 条件结果 | `IF(A2>0,A2,0)` |
| `INDEX` | 引用形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | 向量形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | 向量形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大值 | `MAX(B2:B5)` |
| `SUM` | 求和 | `SUM(B2:B5)` |
| `VLOOKUP` | 垂直查找 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表中显示的限制非常重要：`INDEX` 采用引用形式记录，而 `LOOKUP` 和 `MATCH` 则采用向量形式记录。`DATE` 使用 1900 日期系统。未在此列出的功能和函数应视为 Aspose.Slides 公式求值器不支持，除非另有文档说明。

## **使用首选语言环境计算公式**

某些图表工作簿函数会根据特定语言环境的规则解释文本。这在针对使用双字节字符集（DBCS）语言的函数时尤为重要。要正确计算此类公式，需要创建 [LoadOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/)，使用 [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/zh/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) 设置首选语言环境，通过 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) 分配电子表格选项，然后加载演示文稿。

下面的示例选择日语语言环境，使用配置好的加载选项打开演示文稿，并对每个图表工作簿调用 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)：

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

首选语言环境是演示文稿加载配置的一部分，因此请在创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 实例之前进行指定。使用工作簿公式所期望的语言环境，例如，对应日语 DBCS 计算规则的公式应使用 `ja-JP`。

## **重新计算和缓存值**

电子表格文件通常同时存储公式及其最近一次计算的值。因此，当加载演示文稿且相关图表数据未被更改时，Aspose.Slides 可以从 [IChartDataCell.getValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#getValue--) 读取缓存值。

在更改输入单元格或公式后，不要依赖旧的缓存结果。在读取计算值或保存依赖这些值的图表数据之前，调用 [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)。

对于不在受支持子集内的公式，Aspose.Slides 可能无法解析公式或确定其依赖关系。如果工作簿已被修改，之前的缓存值将不再可靠。在这种情况下，读取包含不受支持数据的单元格值可能会抛出 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/cellunsupporteddataexception/)。

如果您的图表依赖于 Aspose.Slides 不支持的 Excel 函数，请使用支持这些函数的电子表格引擎计算公式，并将得到的值写回图表工作簿。不要用猜测的值替代不受支持的公式。

## **处理公式错误**

需要区分两类不同的问题。

公式可能是合法的，但会产生诸如 `#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!` 或 `#VALUE!` 的电子表格错误结果。在这种情况下，错误标记是单元格的结果，可通过 [IChartDataCell.getValue](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#getValue--) 返回。

公式也可能在解析、引用、依赖或支持的数据层面失败。针对这些情况，Aspose.Slides 提供了特定于电子表格的异常：[CellInvalidFormulaException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/cellcircularreferenceexception/) 和 [CellUnsupportedDataException](https://reference.aspose.com/slides/zh/java/com.aspose.slides/cellunsupporteddataexception/)。

当公式来自模板或用户输入时，请在重新计算和访问值的代码块中捕获这些异常：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **实际限制**

图表工作表中的公式支持旨在覆盖特定子集的电子表格计算，而非完整的 Excel 兼容性。在设计报表工作流时请牢记以下限制：

- 仅在需要 Aspose.Slides 重新计算公式时使用文档中列出的常量、运算符、引用和函数。  
- 在更改公式结果依赖的单元格后进行重新计算。  
- 将从已加载演示文稿中获得的缓存值视为快照，而不是编辑后重新计算的替代方案。  
- 在依赖现有模板的计算值之前，请先测试公式，特别是当它们使用文档列表之外的函数时。  
- 对于需要完整电子表格计算引擎的公式，请在外部计算后将结果值更新到图表工作簿。

## **常见问题**

**IChartDataCell.setFormula 与 IChartDataCell.setR1C1Formula 有何区别？**

[IChartDataCell.setFormula] 存储 A1 样式的表达式，例如 `B2-C2`。 [IChartDataCell.setR1C1Formula] 存储 R1C1 样式的表达式，例如 `RC[-2]-RC[-1]`。请使用最符合您生成或复制公式方式的表示法。

**在计算后，我需要读取单元格本身还是其值？**

[IChartDataWorkbook.getCell] 返回一个 [IChartDataCell]。要获取计算结果，请在重新计算后调用该单元格的 [IChartDataCell.getValue] 方法。

**何时应调用 [IChartDataWorkbook.calculateFormulas]？**

在更改输入值或公式后、在依赖计算结果之前调用 [IChartDataWorkbook.calculateFormulas]。此操作会更新内置求值器支持的公式的值。

**Aspose.Slides 是否支持所有 Excel 函数？**

不。内置求值器仅支持文档中列出的子集函数。不应假设子集之外的函数能够正确重新计算。如果需要完整的 Excel 公式兼容性，请使用合适的电子表格引擎进行计算，并将最终值写入图表工作簿。

**如果加载的演示文稿包含不受支持的公式会怎样？**

如果图表数据未发生变化，工作簿可能仍保留先前计算的缓存值。相关数据被修改后，该缓存值可能不再有效。访问无法处理的公式所在的单元格可能会抛出 [CellUnsupportedDataException]。

**公式错误值与 Java 异常是同一回事吗？**

不是。`#DIV/0!` 等结果是有效计算产生的电子表格值。诸如 [CellInvalidFormulaException] 或 [CellCircularReferenceException] 等异常表示公式无法正常处理。

**当公式单元格更改时，图表会自动更新吗？**

图表系列可以引用工作簿单元格。先重新计算工作簿，然后保存或渲染演示文稿。如果图表数据点引用了计算后的单元格，图表会使用这些更新后的单元格值；此工作流无需单独的图表刷新方法。

**图表可以使用外部 Excel 工作簿吗？**

可以，图表数据可以通过图表数据 API 配置为使用外部工作簿。但本文描述的公式计算工作流仅涉及图表数据工作簿以及 Aspose.Slides 所评估的公式子集。不要假设 [IChartDataWorkbook.calculateFormulas] 能对外部 XLSX 文件中的任意公式进行完整重新计算。

**我可以使用引用其他工作表或工作簿的公式吗？**

图表工作簿中可能出现 Excel 样式的跨工作表或跨工作簿引用，但公式求值受限于支持的解析器和函数集。如果跨表或外部引用是必需的，请使用目标 Aspose.Slides 版本验证该公式的准确性。对于需要广泛 Excel 引用兼容性的工作流，请在外部计算工作簿并将解析得到的值写回图表数据。

**公式字符串应以 `=` 开头吗？**

Aspose.Slides API 示例在分配表达式时，如 `B2-C2` 或 `SUM(B2:B5)`，不需要前导 `=`。采用这种形式可以使生成的公式与文档中的 API 示例保持一致。