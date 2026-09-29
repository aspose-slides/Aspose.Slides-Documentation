---
title: 使用 Java 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "探索适用于 Java 的 Aspose.Slides：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化演示文稿数据。"
---
## **概览**

本文说明如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据，使用工作簿单元格作为图表数据标签，访问工作表集合，以及为图表值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的操作。示例演示了如何创建和分配外部工作簿，检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[Control the Display of Empty Cells](/slides/zh/java/chart-series/)，了解空单元格与零的区别以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)来控制图表是否绘制来自隐藏工作表行和列的数据。将其设置为 `true` 以仅绘制可见单元格，或 `false` 以同时包括可见和隐藏单元格。此设置控制图表绘制；它不会隐藏或取消隐藏工作表行或列。

下载[hidden-source-data.pptx](hidden-source-data.pptx)并将其放置在工作目录中。它的第一张幻灯片的第一个形状是柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)访问源单元格，并读取[IChartDataCell.isHidden](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdatacell/#isHidden--)以检查其隐藏状态。此方法报告隐藏状态而不更改它。在此文件中，B2 是可见的，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `false`、`true` 和 `true`。

对于本例，在更改绘制设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#readWorkbookStream--)保留嵌入的工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)重新加载。当包含所有单元格时，还要使用[setRange](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

示例将仅包含可见零售值（10 和 20）的 `hidden_cells_true.pptx` 保存下来，并将包含所有六个值的 `hidden_cells_false.pptx` 保存下来。下图展示了两种绘制模式。第 3 行和 C 列在两个嵌入工作簿中仍然隐藏。

| 仅可见单元格（`true`） | 所有单元格（`false`） |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[Control the Display of Empty Cells](/slides/zh/java/chart-series/#control-the-display-of-empty-cells)示例。

## **从工作簿读取和写入图表数据**

Aspose.Slides for Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#readWorkbookStream--)和[writeWorkbookStream](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)方法，允许读取和写入图表数据工作簿（其中包含使用 Aspose.Cells 编辑的图表数据）。**注意**图表数据必须以相同方式组织或具有类似于源的结构。

此示例打开 `chart.pptx`，该文件必须在其第一张幻灯片的第一个形状中包含一个图表。它将嵌入的工作簿读取为字节数组，清除现有的系列和类别，然后将相同的工作簿写回。更改保留在内存中；示例未保存演示文稿。

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

当您用修改后的工作簿替换嵌入工作簿时，图表保留其原始的系列和类别集合。此不匹配可能导致[IChart.validateChartLayout](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#validateChartLayout--)因索引超出范围错误而失败。在将更新的工作簿写回图表之前，先清除现有的系列和类别。此示例需要 `chart.pptx`，其第一张幻灯片的第一个形状为图表。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

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

        // 在此修改工作簿字节，例如使用 Aspose.Cells。

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

清除集合可在工作簿写回之前移除过时的数据引用。在使用图表之前，为更新的工作簿重建所需的系列和类别映射。

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。以下步骤展示了如何将气泡图中的标签链接到其数据工作簿中的单元格。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 通过零基索引访问第一张幻灯片。
3. 添加一个带默认数据的气泡图。
4. 访问图表系列。
5. 将工作簿单元格设为数据标签。
6. 保存演示文稿。

此示例打开 `chart2.pptx`（该文件必须至少包含一张幻灯片），并添加一个带默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三级标签，启用来自单元格的标签，并将结果保存为 `resultchart.pptx`。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供对图表工作簿中工作表的访问。此示例创建一个带默认数据的饼图，并将每个工作表名称打印到控制台。

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

此示例创建一个带默认数据的 3D 柱形图，并使用不同的数据源为两个系列设置名称。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/datasourcetype/) 枚举用于为每个名称选择来源。结果保存为 `pres.pptx`。

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

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[IChartData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/) 上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法，并结合[WorkbookType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。此示例检查 `sample.pptx` 第一张幻灯片上的形状，跳过非图表形状，并为每个嵌入 .xlsb 工作簿的图表打印诊断信息。

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

Aspose.Slides 支持将外部工作簿用作图表的数据源。

### **创建外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#readWorkbookStream--)和[setExternalWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)将嵌入的图表工作簿导出为文件，并将图表链接到该外部工作簿。

此示例创建一个带默认数据的饼图，将其工作簿写入 `externalWorkbook1.xlsx`，并在将文件分配为图表数据源之前完成文件写入。它将链接的演示文稿保存为 `externalWorkbook.pptx`。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **设置外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果后者已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可以将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

此示例需要工作目录中有 `externalWorkbook.xlsx`。其名为 `Sheet1` 的工作表必须在 B1 中包含系列名称，在 A2:A4 中包含类别名称，在 B2:B4 中包含数值。示例创建一个饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)将 A1:B4 映射为一个系列和三个类别。它将结果保存为 `Presentation_with_externalWorkbook.pptx`。

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

下面的示例将占位符 URL 分配给 `updateChartData` 为 `false`。它保留饼图的默认数据，并在不加载不可用工作簿的情况下保存演示文稿。

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

要识别链接到图表的工作簿，首先检查图表是否使用外部数据源。如果是，则可按照以下步骤检索工作簿路径。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 通过零基索引访问第一张幻灯片。
3. 检查第一个形状是否为图表。
4. 读取图表的数据源类型。
5. 如果源是外部工作簿，则读取其路径。

此示例打开先前示例创建的 `externalWorkbook.pptx`，并检查第一张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例会将 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 打印到控制台。随后将演示文稿的副本保存为 `Result.pptx`.

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

此示例需要 `presentation.pptx`，其中第一张幻灯片的第一个形状为图表，并且有可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100，并将演示文稿保存为 `presentation_out.pptx`。编辑单元格值可以更新链接的外部 XLSX 文件，如需保留原始工作簿请使用副本。

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

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/)，调用[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，并在打开演示文稿之前将[ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 设置为 `true`。

下面的 Java 示例打开 `presentation.pptx`，其中第一张幻灯片的第一个形状必须是引用不可用外部工作簿的图表，并通过[IChart.getChartData](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#getChartData--) 和 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存的图表数据是可接受的后备方案时才启用恢复，因为缓存可能不包含演示文稿上次更新后对外部工作簿所做的更改。

## **常见问题**

**我可以确定特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chartdata/#getDataSourceType--) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；如果源是外部工作簿，可以读取完整路径以确认正在使用外部文件。

**是否支持外部工作簿的相对路径，且它们如何存储？**

支持。如果指定相对路径，它会自动转换为绝对路径。演示文稿将在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可以用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——只能作为数据来源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

演示文稿存储了指向外部文件的[link to the external file](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护，我该怎么办？**

Aspose.Slides 在链接时不接受密码。常用做法是提前移除保护或准备一个已解密的副本（例如，使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储各自的链接。如果它们都指向同一文件，更新该文件后下次加载数据时，所有图表都会反映出更改。