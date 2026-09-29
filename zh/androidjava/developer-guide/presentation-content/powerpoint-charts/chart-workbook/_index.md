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
description: "探索适用于 Android via Java 的 Aspose.Slides：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化您的演示文稿数据。"
---
## **概述**

本文档说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表值指定数据源类型。

还涵盖了将外部工作簿作为图表数据源的使用方法。示例演示了如何创建并指定外部工作簿、获取链接到图表的外部工作簿路径以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/androidjava/chart-series/)以了解空单元格与零之间的区别，以及可用显示模式的折线图比较。

## **包含隐藏行列中的数据**

使用[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)来控制图表是否绘制隐藏工作表行列中的数据。将其设为 `true` 只绘制可见单元格，设为 `false` 则同时包含可见和隐藏单元格。此设置仅控制图表绘制；它不会隐藏或显示工作表行列。

下载 [hidden-source-data.pptx](hidden-source-data.pptx) 并将其放在工作目录中。其第一页包含一个柱状图作为第一个形状。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和列 C 被隐藏，但其单元格仍包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

通过[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--)访问源单元格，并读取[IChartDataCell.isHidden](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdatacell/#isHidden--)以检查其隐藏状态。该方法报告隐藏状态而不进行更改。在本文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `false`、`true` 和 `true`。

对于本示例，在更改绘图设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)保留嵌入的工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)重新加载。当包含所有单元格时，还需使用[setRange](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-)恢复完整范围，包括隐藏的 February 类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

示例将仅包含可见零售值 (10 和 20) 的文件保存为 `hidden_cells_true.pptx`，将全部六个值保存为 `hidden_cells_false.pptx`。下图展示了两种绘图模式。第 3 行和列 C 在两个嵌入工作簿中均保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：1 月和 3 月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：1 月、2 月和 3 月的零售和批发值。](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) 控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/androidjava/chart-series/#control-the-display-of-empty-cells)获取示例。

## **从工作簿读取和写入图表数据**

Aspose.Slides for Android via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)和[writeWorkbookStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)方法，允许读取和写入包含使用 Aspose.Cells 编辑的图表数据的工作簿。**注意**，图表数据必须以相同方式组织，或结构类似于源数据。

本示例打开 `chart.pptx`（该文件的第一张幻灯片的第一个形状必须是图表），将嵌入的工作簿读取为字节数组，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中；示例未保存演示文稿。

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

当用修改后的工作簿替换嵌入工作簿时，图表会保留其原始的系列和类别集合。此不匹配可能导致[IChart.validateChartLayout](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#validateChartLayout--) 报索引超出范围错误。在写回更新的工作簿之前，请先清除现有的系列和类别。本示例需要 `chart.pptx`（第一张幻灯片的第一个形状为图表）。注释标记了工作簿编辑的位置；可运行示例将原始工作簿写回并在内存中验证布局。

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

清除集合可在写回工作簿前移除过期的数据引用。在使用图表之前，重新构建任何必需的系列和类别映射以匹配更新后的工作簿。

## **将工作簿单元格设为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。以下步骤演示如何在气泡图中将标签链接到其数据工作簿中的单元格。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例。
1. 按零基索引访问第一张幻灯片。
1. 添加一个带默认数据的气泡图。
1. 访问图表系列。
1. 将工作簿单元格设为数据标签。
1. 保存演示文稿。

本示例打开 `chart2.pptx`（该文件必须至少包含一张幻灯片），并添加一个带默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三级标签，启用来自单元格的标签，并将结果保存为 `resultchart.pptx`。

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 方法提供对图表工作簿中工作表的访问。本示例创建一个带默认数据的饼图，并将每个工作表名称打印到控制台。

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

本示例创建一个带默认数据的 3D 柱形图，并使用不同的数据源为两个系列设置名称。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/datasourcetype/) 枚举用于为每个名称选择来源。结果保存为 `pres.pptx`。

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

Aspose.Slides 不支持某些图表中可嵌入的 Excel 二进制工作簿 (.xlsb) 格式。可以在 [IChartData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 方法结合 [WorkbookType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。示例检查 `sample.pptx` 的第一张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

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

使用[readWorkbookStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--)和[setExternalWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)将嵌入的图表工作簿导出到文件并将图表链接到该外部工作簿。

本示例创建一个带默认数据的饼图，将其工作簿写入 `externalWorkbook1.xlsx`，并在将文件指定为图表数据源之前完成文件写入。随后将链接的演示文稿保存为 `externalWorkbook.pptx`。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 方法，可将外部工作簿指定为图表的数据源。此方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法直接编辑存放在远程位置或资源中的工作簿数据，但仍可将其用作外部数据源。如果提供了相对路径，会自动转换为完整路径。

本示例需要工作目录中存在 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必须在 B1 单元格包含系列名称，在 A2:A4 包含类别名称，在 B2:B4 包含数值。示例创建一个饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) 将 A1:B4 映射为一个系列和三个类别。结果保存为 `Presentation_with_externalWorkbook.pptx`。

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

[setExternalWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) 的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

下面的示例将占位符 URL 与 `updateChartData` 设置为 `false` 一起使用。它保留饼图的默认数据，并在未加载不可用工作簿的情况下保存演示文稿。

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

要识别链接到图表的工作簿，首先检查图表是否使用外部数据源。如果是，则按照以下步骤检索工作簿路径。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 实例。
1. 按零基索引访问第一张幻灯片。
1. 确认第一个形状是图表。
1. 读取图表的数据源类型。
1. 如果源是外部工作簿，读取其路径。

本示例打开之前示例创建的 `externalWorkbook.pptx`，检查第一张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例将 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) 打印到控制台。随后将演示文稿的副本保存为 `Result.pptx`。

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

可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。如果无法加载外部工作簿，会抛出异常。

本示例需要 `presentation.pptx`（第一张幻灯片的第一个形状为图表）以及可访问的外部工作簿。示例将第一系列第一个数据点的单元格对应值设为 100，并将演示文稿保存为 `presentation_out.pptx`。编辑单元格值可以更新链接的外部 XLSX 文件，如需保留原始工作簿请使用副本。

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

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿缓存的数据中重建图表工作簿。创建 [LoadOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/)，调用 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)，并在打开演示文稿前将 [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) 设为 `true`。

下面的 Java 示例打开 `presentation.pptx`（其第一张幻灯片的第一个形状必须是引用不可用外部工作簿的图表），并通过 [IChart.getChartData](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#getChartData--) 与 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) 访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 会抛出异常。仅在使用缓存图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿在最后一次更新演示文稿后所做的更改。

## **常见问题**

**我能否确定特定图表是链接到外部工作簿还是嵌入工作簿？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；如果源是外部工作簿，可读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径？它们如何存储？**

支持。若指定相对路径，会自动转换为绝对路径。演示文稿将在 PPTX 文件中存储绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这些工作簿可用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——只能作为数据源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿会存储对外部文件的链接。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护，该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是预先移除保护或准备已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都会保存自己的链接。如果它们都指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。