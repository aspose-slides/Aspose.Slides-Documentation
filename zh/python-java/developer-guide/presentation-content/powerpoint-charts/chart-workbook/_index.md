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
description: "了解 Aspose.Slides for Python via Java：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表值指定数据源类型。

还包括使用外部工作簿作为图表数据源的用法。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

## **从工作簿读取和写入图表数据**
Aspose.Slides 提供了[readWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#readWorkbookStream)和[writeWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#writeWorkbookStream)方法，允许您读取和写入包含使用 Aspose.Cells 编辑的图表数据的工作簿。**注意**图表数据必须以相同方式组织，或具有类似于源的结构。

此 Python 代码演示了一个示例操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **在工作簿修改后验证图表布局**

当您用已修改的工作簿替换嵌入的工作簿时，图表仍保留原始的系列和类别集合。此不一致可能导致[Chart.validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout)抛出 `ArgumentOutOfRangeException`（参数：index）。为避免异常，请在将更新的工作簿写回图表之前 **先** 清除现有的系列和类别。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# 在修改后读取工作簿（例如，使用 Aspose.Cells）。
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # 清除现有的数据引用。
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

清除集合可确保图表数据结构与新工作簿保持一致，从而使[validateChartLayout](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#validateChartLayout)能够顺利完成。

## **将工作簿单元格设置为图表数据标签**

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个带有数据的气泡图。  
4. 访问图表系列。  
5. 将工作簿单元格设为数据标签。  
6. 保存演示文稿。

此 Python 代码展示了如何将工作簿单元格设置为图表数据标签：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

此 Python 代码演示了使用[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/#getWorksheets)方法访问工作表集合的操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **指定数据源类型**

此 Python 代码展示了如何为数据源指定类型：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/)上使用[getEmbeddedWorkbookType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType)方法，并结合[WorkbookType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # 嵌入式工作簿为 .xlsb 格式，不受支持。
            continue
        # 在此读取或修改图表工作簿数据。
finally:
    presentation.dispose()
```

### **创建外部工作簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#readWorkbookStream)和[setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以从头创建外部工作簿，或将内部工作簿转换为外部工作簿。

此 Python 代码演示了外部工作簿的创建过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **设置外部工作簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook)方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，系统会自动将其转换为完整路径。

此 Python 代码展示了如何设置外部工作簿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#setExternalWorkbook)方法的第二个 (`bool`) 参数用于指定是否加载 Excel 工作簿。

* 当其值设为 `False` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时可以使用此设置。  
* 当其值设为 `True` 时，图表数据会从目标工作簿更新。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **获取图表的外部数据源工作簿路径**

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 为图表形状创建对象。  
4. 为表示图表数据源的源（[ChartDataSourceType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatasourcetype/)）类型创建对象。  
5. 根据源类型与外部工作簿数据源类型相同的条件指定相应的条件。

此 Python 代码演示了该操作：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **编辑图表数据**

您可以像修改内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

此 Python 代码实现了上述过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/)，使用[SpreadsheetOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/spreadsheetoptions/)进行配置，并在打开演示文稿前将[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)设为 `True`。

以下 Python 示例打开了一个图表引用不可用外部工作簿的演示文稿，并通过[Chart.getChartData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#getChartData)和[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getChartDataWorkbook)访问恢复的数据：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # 读取或修改此处恢复的工作簿数据。
finally:
    presentation.dispose()
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存的图表数据是可接受的后备方案时才启用恢复，因为缓存可能不包含演示文稿上次更新后对外部工作簿所做的更改。

## **常见问题解答**

**我能判断特定图表是链接到外部工作簿还是嵌入式工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getDataSourceType)和[external workbook path](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持相对路径的外部工作簿，且它们如何存储？**

支持。如果指定相对路径，系统会自动转换为绝对路径。这对项目可移植性很方便；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但 Aspose.Slides 不支持直接编辑远程工作簿——只能作为数据源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

不会。演示文稿仅存储一个[link to the external file](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)并在读取数据时使用它。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是预先解除保护或准备一个已解密的副本（例如使用[Aspose.Cells](/cells/python-java/)），然后链接该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都会存储自己的链接。如果它们指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。