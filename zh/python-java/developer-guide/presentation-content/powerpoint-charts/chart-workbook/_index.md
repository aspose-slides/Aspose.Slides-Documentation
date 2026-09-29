---
title: 使用 Python via Java 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/python-java/chart-workbook/
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
- Python
- Java
- Aspose.Slides
description: "了解适用于 Python via Java 的 Aspose.Slides：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，简化您的演示文稿数据。"
---
## **概述**

本文阐述了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表数值指定数据源类型。

还包括使用外部工作簿作为图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索与图表关联的外部工作簿路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅 [Control the Display of Empty Cells](/slides/zh/python-java/chart-series/) 了解空单元格与零值的区别，以及可用显示模式的线形图比较。

## **包含隐藏行列中的数据**

使用 [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) 控制图表是否仅绘制隐藏工作表行列中的可见数据。将其设为 `True` 只绘制可见单元格，设为 `False` 则同时包含可见和隐藏单元格。此设置仅控制图表绘制；它不会隐藏或显示工作表的行列。

下载 [hidden-source-data.pptx](hidden-source-data.pptx) 并放置在工作目录中。其第一张幻灯片的第一形状是柱形图。嵌入的工作表 `Sheet1` 包含如下源范围 `A1:C4`。第 3 行和列 C 被隐藏，但它们的单元格仍包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隐藏行） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

通过 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 访问源单元格，并读取 [ChartDataCell.isHidden](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatacell/#isHidden) 检查其隐藏状态。此方法仅报告隐藏状态而不修改它。在本文件中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True`、`True`。

对于本示例，在更改绘制设置后请刷新图表数据：使用 [readWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#readWorkbookStream) 保留嵌入工作簿，并使用 [writeWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#writeWorkbookStream) 重新加载。当包含所有单元格时，还需使用 [setRange](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setRange) 恢复完整范围，包括隐藏的二月类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # 从嵌入的工作簿刷新图表数据。
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # 恢复完整的源范围，包括隐藏的类别。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

示例将仅包含可见零售值（10 和 20）的 `hidden_cells_True.pptx` 保存，以及包含全部六个数值的 `hidden_cells_False.pptx`。下图展示了两种绘制模式。第 3 行和列 C 在两个嵌入工作簿中均保持隐藏。

| 仅可见单元格（`True`） | 所有单元格（`False`） |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDisplayBlanksAs) 控制缺失值的显示方式；它不包含或排除隐藏的源数据。请参阅 [Control the Display of Empty Cells](/slides/zh/python-java/chart-series/#control-the-display-of-empty-cells) 获取示例。

## **从工作簿读取和写入图表数据**

Aspose.Slides for Python via Java 提供了 [readWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#readWorkbookStream) 和 [writeWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，允许读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意** 图表数据必须以相同方式组织或结构类似于源数据。

本示例打开 `chart.pptx`（该文件须在首张幻灯片的第一形状中包含图表），将嵌入工作簿读取为字节数组，清除现有系列和类别，然后将同一工作簿写回。更改保留在内存中，示例不保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **在修改工作簿后验证图表布局**

当用修改后的工作簿替换嵌入工作簿时，图表仍保留原来的系列和类别集合。这种不匹配可能导致 [Chart.validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout) 报索引超出范围错误。写回更新工作簿之前请先清除现有系列和类别。此示例需要 `chart.pptx`，其首张幻灯片的第一形状为图表。注释标明工作簿编辑位置；可运行示例将原始工作簿写回并在内存中验证布局。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # 在此修改工作簿字节，例如使用 Aspose.Cells。

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

清除集合可在写回工作簿前移除陈旧的数据引用。为更新的工作簿在使用图表前，请重新构建所需的系列和类别映射。

## **将工作簿单元格设为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。以下步骤展示如何将气泡图标签链接到其数据工作簿中的单元格。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例。  
2. 通过零基索引访问第一张幻灯片。  
3. 添加默认数据的气泡图。  
4. 访问图表系列。  
5. 将工作簿单元格设为数据标签。  
6. 保存演示文稿。

本示例打开 `chart2.pptx`（该文件须至少包含一张幻灯片），并添加默认数据的气泡图。它使用工作表 0 的单元格 A10:A12 作为第一系列前三级标签，启用从单元格读取标签，并将结果保存为 `resultchart.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **管理工作表**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法提供对图表工作簿中工作表的访问。本示例创建默认数据的饼图，并将每个工作表名称打印到控制台。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **指定数据源类型**

本示例创建默认数据的 3D 柱形图，并使用不同的数据源为两个系列设置名称。第一个名称使用字符串文字；第二个名称使用工作表 0 中的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/datasourcetype/) 枚举用于为每个名称选择来源。结果保存为 `pres.pptx`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **检测不受支持的嵌入工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。可以在 [ChartData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/) 上使用 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) 方法结合 [WorkbookType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。此示例检查 `sample.pptx` 首张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # 在此读取或修改受支持的图表工作簿数据。
finally:
    presentation.dispose()
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用 [readWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#readWorkbookStream) 和 [setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook) 将嵌入图表的工作簿导出为文件，并将图表链接到该外部工作簿。

本示例创建默认数据的饼图，将其工作簿写入 `externalWorkbook1.xlsx`，完成文件写入后将该文件指定为图表数据源。然后将已链接的演示文稿保存为 `externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **设置外部工作簿**

使用 [setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook) 方法，可为图表指定外部工作簿作为数据源。该方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存放在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供相对路径，系统会自动转换为完整路径。

本示例需要工作目录中存在 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必须在 B1 单元格包含系列名称，A2:A4 包含类别名称，B2:B4 包含数值。示例创建饼图，链接工作簿，并使用 [setRange](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setRange) 将 A1:B4 映射为一个系列和三个类别。结果保存为 `Presentation_with_externalWorkbook.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook) 的 `updateChartData` 参数决定是否加载工作簿。

* 当 `updateChartData` 为 `False` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。  
* 当 `updateChartData` 为 `True` 时，图表数据将从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `False`。它保留饼图的默认数据，并在不加载不可用工作簿的情况下保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，首先检查图表是否使用外部数据源。如果是，则可按照以下步骤检索工作簿路径。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 实例。  
2. 通过零基索引访问第一张幻灯片。  
3. 确认第一个形状是图表。  
4. 读取图表的数据源类型。  
5. 如果源是外部工作簿，读取其路径。

本示例打开前述示例生成的 `externalWorkbook.pptx`，检查首张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例将 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) 打印到控制台。随后将演示文稿的副本保存为 `Result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **编辑图表数据**

可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

本示例需要 `presentation.pptx`（其首张幻灯片的第一形状为图表）以及可访问的外部工作簿。示例将第一系列第一个数据点的单元格支持值设为 100，并将演示文稿保存为 `presentation_out.pptx`。编辑单元格值会更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以根据演示文稿中缓存的图表数据重建工作簿。创建 [LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/)，调用 [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，并在打开演示文稿前将 [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) 设置为 `True`。

以下 Python 示例打开 `presentation.pptx`（其首张幻灯片的第一形状必须是引用不可用外部工作簿的图表），并通过 [Chart.getChartData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#getChartData) 和 [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getChartDataWorkbook) 访问恢复的数据：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # 在此读取或修改恢复的工作簿数据。
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 会抛出异常。仅在使用缓存图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿在演示文稿上次更新后所做的更改。

## **常见问题**

**我能判断某个特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有 [data source type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getDataSourceType) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；如果源是外部工作簿，则可读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径，它们是如何存储的？**

支持。若指定相对路径，系统会自动转换为绝对路径。演示文稿将在 PPTX 文件中存储绝对路径，移动工作簿后可能需要更新链接。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可作为外部数据源使用。但不支持直接从 Aspose.Slides 编辑远程工作簿——只能用作数据源。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿只存储指向外部文件的链接。编辑基于单元格的图表数据也可能更新本地的链接 XLSX 文件。如需保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/python-java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储自己的链接。如果它们指向同一文件，更新该文件将在下次加载数据时反映到所有图表中。