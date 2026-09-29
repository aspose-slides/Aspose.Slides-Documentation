---
title: 使用 JavaScript 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js via Java：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，简化演示文稿数据。"
---
## **概述**

本文介绍了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合，以及为图表值指定数据源类型。

它还涵盖了使用外部工作簿作为图表数据源的操作。示例演示了如何创建和分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/nodejs-java/chart-series/)，了解空单元格与零的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly)来控制图表是否绘制来自隐藏工作表行和列的数据。将其设为 `true` 只绘制可见单元格，设为 `false` 则同时包含可见和隐藏单元格。此设置仅控制图表绘制；它不会隐藏或显示工作表的行或列。

下载[hidden-source-data.pptx](hidden-source-data.pptx)并将其放置在工作目录中。它的第一张幻灯片的第一个形状是柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)访问源单元格，并读取[ChartDataCell.isHidden](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdatacell/#isHidden)检查其隐藏状态。此方法报告隐藏状态而不修改它。在此文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `false`、`true` 和 `true`。

对于本示例，在更改绘制设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)保留嵌入的工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)重新加载它。包含所有单元格时，还使用[setRange](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#setRange)恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。示例在传递给写入方法之前，将返回的 Node.js 缓冲区转换为 Java 字节数组。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 刷新嵌入工作簿中的图表数据。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 恢复完整的源范围，包括隐藏的类别。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

示例将 `hidden_cells_true.pptx` 保存为仅包含可见零售值（10 和 20）的文件，将 `hidden_cells_false.pptx` 保存为包含全部六个值的文件。下图展示了两种绘制模式。第 3 行和 C 列在两个嵌入工作簿中仍保持隐藏。

| 仅可见单元格 (`true`) | 所有单元格 (`false`) |
| --- | --- |
| ![仅可见单元格：一月和三月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：一月、二月和三月的零售和批发值。](hidden_cells_False.png) |

包含值的隐藏单元格不同于空单元格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs)控制缺失值的显示方式；它不包含也不排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/nodejs-java/chart-series/#control-the-display-of-empty-cells)获取示例。

## **从工作簿读取和写入图表数据**

Aspose.Slides for Node.js via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)和[writeWorkbookStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream)方法，允许读取和写入包含使用 Aspose.Cells 编辑的图表数据的工作簿。**注意**，图表数据必须以相同方式组织或结构类似于源数据。

此示例打开 `chart.pptx`，该文件的第一张幻灯片的第一个形状必须是图表。它将嵌入的工作簿读取为字节数组，清除现有系列和类别，并将相同的工作簿写回。更改保留在内存中；示例不保存演示文稿。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **在工作簿修改后验证图表布局**

当用修改后的工作簿替换嵌入工作簿时，图表仍保留原始的系列和类别集合。这种不匹配可能导致[Chart.validateChartLayout](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/#validateChartLayout)因索引超出范围而失败。在将更新的工作簿写回图表之前，先清除现有系列和类别。本示例需要 `chart.pptx`，其中第一张幻灯片的第一个形状是图表。注释标记了工作簿编辑的位置；可运行示例将原始工作簿写回并在内存中验证布局。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // 在此修改工作簿字节，例如使用 Aspose.Cells。

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

清除集合可在工作簿写回之前移除过时的数据引用。为更新的工作簿重新构建任何必需的系列和类别映射后再使用图表。

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。以下步骤展示如何将气泡图标签链接到其数据工作簿中的单元格。

1. 创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)类的实例。
1. 按零基索引访问第一页幻灯片。
1. 添加默认数据的气泡图。
1. 访问图表系列。
1. 将工作簿单元格设为数据标签。
1. 保存演示文稿。

此示例打开 `chart2.pptx`，该文件必须至少包含一张幻灯片，并添加默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列前三个标签，启用来自单元格的标签，并将结果保存为 `resultchart.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **管理工作表**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets)方法提供对图表工作簿中工作表的访问。本示例创建默认数据的饼图，并将每个工作表名称打印到控制台。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **指定数据源类型**

此示例创建默认数据的 3D 柱形图，并使用不同的数据源为两个系列设置名称。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datasourcetype/)枚举选择每个名称的源。结果保存为 `pres.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **检测不受支持的嵌入工作簿格式**

Aspose.Slides 不支持某些图表中可以嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/)上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType)方法结合[WorkbookType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。此示例检查 `sample.pptx` 第一张幻灯片上的形状，跳过非图表形状，并为每个嵌入 .xlsb 工作簿的图表打印诊断信息。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
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

使用[readWorkbookStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#readWorkbookStream)和[setExternalWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)将嵌入的图表工作簿导出到文件，并将图表链接到该外部工作簿。

此示例创建默认数据的饼图，将其工作簿写入 `externalWorkbook1.xlsx`，并在将文件分配为图表数据源之前完成文件写入。它将链接的演示文稿保存为 `externalWorkbook.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **设置外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以为图表指定外部工作簿作为数据源。该方法还可用于更新外部工作簿的路径（如果已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供相对路径，系统会自动将其转换为完整路径。

此示例需要工作目录中存在 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必须在 B1 单元格包含系列名称，在 A2:A4 单元格包含类别名称，在 B2:B4 单元格包含数值。示例创建饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#setRange)将 A1:B4 映射为一个系列和三个类别。结果保存为 `Presentation_with_externalWorkbook.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook)的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `false` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `true` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `false` 一起使用。它保留饼图的默认数据，并在不加载不可用工作簿的情况下保存演示文稿。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，首先检查图表是否使用外部数据源。如果是，您可以按照以下步骤检索工作簿路径。

1. 创建[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)类的实例。
1. 按零基索引访问第一页幻灯片。
1. 确认第一个形状是图表。
1. 读取图表数据源类型。
1. 如果源是外部工作簿，读取其路径。

此示例打开前面示例中创建的 `externalWorkbook.pptx`，检查第一页的第一个形状。如果它是链接到外部工作簿的图表，示例将 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) 打印到控制台。随后将演示文稿的副本保存为 `Result.pptx`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **编辑图表数据**

您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

此示例需要 `presentation.pptx`，其第一张幻灯片的第一个形状是图表，并且具备可访问的外部工作簿。它将第一系列第一个数据点的单元格支持值设置为 100，并将演示文稿保存为 `presentation_out.pptx`。编辑单元格值会更新链接的外部 XLSX 文件，如需保留原始工作簿，请使用副本。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/)，调用[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，并在打开演示文稿前将[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)设为 `true`。

以下 JavaScript 示例打开 `presentation.pptx`，其第一张幻灯片的第一个形状必须是引用不可用外部工作簿的图表，并通过[Chart.getChartData](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/#getChartData)和[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook)访问恢复的数据：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // 在此读取或修改恢复的工作簿数据。
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 会抛出异常。仅在接受使用缓存图表数据作为后备时才启用恢复，因为缓存可能不包含对外部工作簿在演示文稿上次更新后所做的更改。

## **常见问题解答**

**我能判断特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getDataSourceType)和[external workbook path](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)；如果源是外部工作簿，您可以读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径，如何存储？**

支持。如果指定相对路径，系统会自动将其转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，移动工作簿可能需要更新链接。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——只能作为数据源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

演示文稿存储指向外部文件的[链接](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath)。编辑单元格支持的图表数据也可能更新链接的本地 XLSX 文件。如果必须保持原始工作簿不变，请使用工作簿的副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。