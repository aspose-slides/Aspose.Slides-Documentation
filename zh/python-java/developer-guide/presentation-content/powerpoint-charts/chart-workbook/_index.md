---
title: 在演示文稿中使用 Python via Java 管理图表工作簿
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
description: "探索 Aspose.Slides for Python via Java：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文档说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据，使用工作簿单元格作为图表数据标签，访问工作表集合，以及为图表值指定数据源类型。

还介绍了将外部工作簿作为图表数据源的使用方法。示例演示了如何创建并分配外部工作簿，检索链接到图表的外部工作簿的路径，以及在工作簿可用时编辑图表数据。

有关表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/python-java/chart-series/)以了解空单元格与零的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列中的数据**

使用[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly)控制图表是否仅绘制隐藏工作表行和列中的可见单元格。将其设置为 `True` 仅绘制可见单元格，设置为 `False` 则同时包含可见和隐藏单元格。此设置仅影响图表绘制，不会隐藏或显示工作表行或列。

[示例演示文稿](hidden-source-data.pptx)的第一张幻灯片的首个形状是柱形图。嵌入的工作表 `Sheet1` 包含以下源范围 `A1:C4`。第 3 行和 C 列被隐藏，但它们的单元格仍然包含数值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

通过[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook)访问源单元格，并读取[ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden)以检查其隐藏状态。此方法仅报告隐藏状态，不会更改它。在本例中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True` 和 `True`。

对于本示例，在更改绘制设置后刷新图表数据：使用[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)保留嵌入工作簿，并使用[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream)重新加载。当包含所有单元格时，还需使用[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)恢复完整范围，包括隐藏的 February 类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

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

示例保存了两个版本的演示文稿：一个仅包含可见的零售值（10 和 20），另一个包含所有六个值。下图展示了两种绘制模式。第 3 行和 C 列在两个嵌入工作簿中均保持隐藏。

| 仅可见单元格 (`True`) | 所有单元格 (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs)控制缺失值的显示方式；它不包含也不排除隐藏的源数据。有关示例，请参阅[控制空单元格的显示](/slides/zh/python-java/chart-series/#control-the-display-of-empty-cells)。

## **检索图表的数据范围**

在更新现有演示文稿中的工作簿数据之前，检查源范围以确定每个图表使用的工作表单元格。[ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange)方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名称，`!` 与单元格范围分隔，`$A$1:$D$5` 标识从 A1 到 D5（含）的单元格。美元符号表示绝对行列引用。

该方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，则会抛出 `InvalidOperationException`。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)。

本示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果图表未使用工作簿，则打印提示信息并继续处理下一个图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **从工作簿读取和写入图表数据**

Aspose.Slides for Python via Java 提供了[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)和[writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream)方法，允许读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同方式组织或具有类似的结构。

本示例使用第一张幻灯片的首个形状（图表）的演示文稿。它将嵌入工作簿读取为字节数组，清除现有系列和类别，然后将相同工作簿写回。更改保留在内存中，示例不保存演示文稿。

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

当您用已修改的工作簿替换嵌入工作簿时，图表仍保留原始的系列和类别集合。此不匹配可能导致[Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout)因索引超出范围而失败。写回更新的工作簿之前，请先清除现有系列和类别。本示例使用第一张幻灯片的首个形状（图表）。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

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

        # 在此处修改工作簿字节，例如，使用 Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

清除集合可在写回工作簿之前移除陈旧的数据引用。为更新的工作簿重新构建所需的系列和类别映射后再使用图表。

## **将工作簿单元格设为图表数据标签**

您可以使用工作簿单元格中的文本作为图表数据标签。

本示例向现有演示文稿的第一张幻灯片添加一个默认数据的气泡图。它使用工作表 0 上的单元格 A10:A12 作为第一系列的前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets)方法提供对图表工作簿中工作表的访问。本示例创建一个默认数据的饼图，并将每个工作表名称打印到控制台。

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

本示例创建一个默认数据的 3D 柱形图，并使用不同的数据源为两个系列名称赋值。第一个名称使用字符串文字；第二个名称使用工作表 0 上的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/)枚举选择每个名称的来源。示例保存了已更新系列名称的演示文稿。

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

Aspose.Slides 不支持某些图表中可嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType)方法，并结合[WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。示例检查现有演示文稿第一张幻灯片的形状，跳过非图表形状，并为每个带有 .xlsb 嵌入工作簿的图表打印诊断信息。

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

Aspose.Slides 支持将外部工作簿用作图表的数据源。

### **创建外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream)和[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook)将嵌入的图表工作簿导出为文件并将图表链接到该外部工作簿。

本示例创建一个默认数据的饼图并导出其工作簿。文件写入完成后，将外部工作簿分配为图表数据源，随后保存链接后的演示文稿。

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

使用[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以为图表分配外部工作簿作为其数据源。此方法还可用于更新外部工作簿的路径（如果已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了相对路径，它会自动转换为完整路径。

本示例使用一个外部工作簿，其工作表 `Sheet1` 包含 B1 中的系列名称、A2:A4 中的类别名称以及 B2:B4 中的数值。示例创建饼图，链接工作簿，并使用[setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange)将 A1:B4 映射为一个系列和三个类别。随后保存带有链接图表的演示文稿。

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook)的 `updateChartData` 参数控制是否加载工作簿。

* 当 `updateChartData` 为 `False` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `updateChartData` 为 `True` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 与 `updateChartData` 设置为 `False`。它保留饼图的默认数据，并在未加载不可用工作簿的情况下保存演示文稿。

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

要识别链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

本示例检查带有链接外部工作簿的演示文稿第一张幻灯片的首个形状。如果它是链接到外部工作簿的图表，示例将[getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)打印到控制台。随后保存演示文稿的副本。

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

您可以像编辑内部工作簿一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

本示例使用第一张幻灯片的首个形状（图表），该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100 并保存更新后的演示文稿。编辑单元格值可能会更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

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

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/)，调用[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)，并在打开演示文稿前将[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)设为 `True`。

以下 Python 示例恢复了第一张幻灯片的首个形状（图表）所引用的不可用外部工作簿的数据。它通过[Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData)和[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook)访问恢复的数据：

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

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。只有在接受使用缓存图表数据作为可接受的回退时才启用恢复，因为缓存可能不包含对外部工作簿在演示文稿最后一次更新后所做的更改。

## **常见问答**

**我能判断特定图表是链接到外部工作簿还是嵌入工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType)和[external workbook path](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径，如何存储？**

支持。若指定相对路径，系统会自动转换为绝对路径。演示文稿在 PPTX 文件中存储的是绝对路径，因此移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可以作为外部数据源使用。但 Aspose.Slides 不支持直接编辑远程工作簿——只能用作源。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿存储的是[链接到外部文件](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如需保持原始工作簿不变，请使用其副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备解密后的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/python-java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表存储各自的链接。如果它们都指向同一文件，更新该文件将在下次加载数据时反映到每个图表中。