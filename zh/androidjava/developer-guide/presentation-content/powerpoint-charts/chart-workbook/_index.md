---
title: 在 Android 上的演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/androidjava/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- 图表缓存
- 工作簿恢复
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java：轻松管理 PowerPoint 和 OpenDocument 格式的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文介绍如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表值指定数据源类型。

它还涉及使用外部工作簿作为图表数据源。示例演示如何创建并分配外部工作簿、获取链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/androidjava/chart-series/)，了解空单元格与零之间的区别以及可用显示模式的折线图比较。

## **包含隐藏行和列的数据**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)来控制图表是否仅绘制隐藏工作表行和列中的数据。将其设为`true`以仅绘制可见单元格，或设为`false`以包含可见和隐藏单元格。此设置仅控制图表绘制；它不会隐藏或显示工作表的行或列。

[示例演示文稿](hidden-source-data.pptx)包含首张幻灯片上的第一个形状——柱状图。嵌入的工作表`Sheet1`的源范围为`A1:C4`。第 3 行和 C 列被隐藏，但其单元格仍包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发 (隐藏列) |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3 (隐藏行) | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)访问源单元格，并使用[IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)检查其隐藏状态。此方法仅报告隐藏状态，不会更改它。在本例中，B2 可见，B3 位于隐藏行，C2 位于隐藏列；示例分别打印`false`、`true`和`true`。

对于本示例，在更改绘图设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)保留嵌入的工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)重新加载。当包含所有单元格时，还需使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 从嵌入的工作簿刷新图表数据。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 恢复完整的源范围，包括隐藏的类别。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

示例将演示文稿保存为两个版本：一个仅包含可见的零售值（10 和 20），另一个包含所有六个值。下图展示了两种绘图模式。行 3 和列 C 在两个嵌入的工作簿中仍保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20.](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值.](hidden_cells_False.png) |

包含值的隐藏单元格不同于空单元格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/androidjava/chart-series/#control-the-display-of-empty-cells)了解示例。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，检查源范围以确定每个图表使用的工作表单元格。[IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--)方法返回当前数据范围的工作表限定公式，例如`Sheet1!$A$1:$D$5`。其中`Sheet1`是工作表名称，`!`用于分隔工作表名和单元格范围，`$A$1:$D$5`标识从 A1 到 D5（含）的单元格。美元符号表示绝对行列引用。

此方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，则会抛出`InvalidOperationException`。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)。

本示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印一条信息并继续检查下一个图表。

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **从工作簿读取和写入图表数据**

Aspose.Slides for Android via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)和[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)方法，允许读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**图表数据必须以相同方式组织或具有类似的结构。

本示例使用首张幻灯片上的第一个形状——图表。它将嵌入的工作簿读取为字节数组，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中，示例并未保存演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **在工作簿修改后验证图表布局**

当用修改后的工作簿替换嵌入的工作簿时，图表仍保留其原始的系列和类别集合。此不匹配可能导致[IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--)因索引超出范围而失败。请在将更新的工作簿写回图表之前清除现有系列和类别。示例使用首张幻灯片的第一个形状——图表。注释标记了工作簿编辑的位置；可运行示例将原始工作簿写回并在内存中验证布局。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // 在此修改工作簿字节，例如，使用 Aspose.Cells。

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

清除集合可在写回工作簿前移除陈旧的数据引用。为更新的工作簿重新构建任何必需的系列和类别映射后再使用图表。

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。

本示例向现有演示文稿的首张幻灯片添加一个带默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列的前三个标签，启用从单元格获取标签，并保存更新后的演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理工作表**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--)方法提供对图表工作簿中工作表的访问。本示例创建一个带默认数据的饼图，并将每个工作表名称打印到控制台。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **指定数据源类型**

本示例创建一个带默认数据的 3D 柱状图，并使用不同的数据源为两个系列设置名称。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/)枚举用于为每个名称选择源。示例保存了包含更新系列名称的演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检测不受支持的嵌入工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/)上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--)方法，并结合[WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/)枚举检测不受支持的格式并跳过这些图表。此示例检查现有演示文稿首张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // 在此读取或修改受支持的图表工作簿数据。
    }
} finally {
    presentation.dispose();
}
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)和[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)将嵌入的图表工作簿导出为文件，并将图表链接到该外部工作簿。

本示例创建一个带默认数据的饼图并导出其工作簿。完成文件写入后将外部工作簿分配为图表数据源，然后保存已链接的演示文稿。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **设置外部工作簿**

通过[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)方法，您可以将外部工作簿分配给图表作为其数据源。该方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然不能编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了相对路径，系统会自动将其转换为完整路径。

本示例使用一个外部工作簿，其工作表 `Sheet1` 在 B1 包含系列名称，A2:A4 包含类别名称，B2:B4 包含数值。示例创建一个饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)将 A1:B4 映射为一个系列和三个类别。随后保存包含已链接图表的演示文稿。

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `false`。它保留饼图的默认数据并在不加载不可用工作簿的情况下保存演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

本示例检查演示文稿首张幻灯片的第一个形状是否为链接外部工作簿的图表。如果是，则将[getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)打印到控制台，然后保存演示文稿的副本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **编辑图表数据**

您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

本示例使用首张幻灯片上的第一个形状——链接到可访问外部工作簿的图表。它将第一系列第一个数据点的单元格支持值设为 100 并保存更新后的演示文稿。编辑单元格值可以更新链接的外部 XLSX 文件；如果需要保留原始工作簿，请使用副本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)，调用[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，并在打开演示文稿前将[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)设为 `true`。

下面的 Java 示例恢复了首张幻灯片上第一个形状——引用不可用外部工作簿的图表的工作簿数据。它通过[IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--)和[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)访问恢复的数据：

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // 在此读取或修改恢复的工作簿数据。
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存的图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿在演示文稿最后一次更新后所做的更改。

## **常见问题**

**我可以确定特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--)和[外部工作簿路径](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径，它们如何存储？**

支持。如果指定相对路径，系统会自动将其转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，因此移动工作簿后可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——它们只能用作源。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

演示文稿存储了指向外部文件的[链接](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用工作簿的副本。

**如果外部文件受密码保护，我该怎么办？**

Aspose.Slides 在建立链接时不接受密码。常见的做法是事先移除保护或准备一个已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储自己的链接。如果它们都指向同一文件，更新该文件后在下次加载数据时会在每个图表中体现。