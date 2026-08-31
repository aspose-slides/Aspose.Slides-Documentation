---
title: 使用 Python 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/python-net/chart-workbook/
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
- Aspose.Slides
description: "通过 .NET 使用 Aspose.Slides for Python：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，简化演示文稿数据。"
---
## **概述**

本文说明了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合以及为图表值指定数据源类型。

此外，还介绍了使用外部工作簿作为图表数据源的操作。示例演示了如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

## **从工作簿读取和写入图表数据**

Aspose.Slides 提供了读取和写入图表工作簿（其中包含使用 Aspose.Cells 编辑的图表数据）的方法。**注意：**图表数据必须以相同方式组织，或具有与源相似的结构。

下面的 Python 代码演示了一个示例操作：

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **在工作簿修改后验证图表布局**

当您用已修改的工作簿替换嵌入的工作簿时，图表仍保留原始的系列和类别集合。这种不匹配可能导致[IChart.validate_chart_layout](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/ichart/validate_chart_layout/)因索引超出范围而失败。请在将更新的工作簿写回图表之前清除现有的系列和类别。

```python
# 在修改工作簿流后（例如使用 Aspose.Cells）
updated_workbook = chart_data.read_workbook_stream()

# 清除现有的数据引用。
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

清除集合可确保图表数据结构与新工作簿保持一致，从而使 `validate_chart_layout` 能够顺利完成而不报错。

## **将工作簿单元格设置为图表数据标签**

有时您需要的图表标签直接来自底层数据工作簿中的单元格。Aspose.Slides 允许将数据标签绑定到特定的工作簿单元格，使标签文本始终反映单元格的值。下面的示例展示了如何启用“从单元格获取值”标签并将选定标签指向图表工作簿中的自定义单元格。

1. 创建一个 [Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 实例。  
2. 按索引获取幻灯片引用。  
3. 添加一个带有示例数据的气泡图。  
4. 访问图表系列。  
5. 使用工作簿单元格作为数据标签。  
6. 保存演示文稿。

以下 Python 代码展示了如何将工作簿单元格设为图表数据标签：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# 实例化表示演示文稿文件的 Presentation 类。
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **管理工作表**

下面的 Python 代码演示了如何使用 `worksheets` 属性访问工作表集合：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **指定数据源类型**

下面的 Python 代码展示了如何指定数据源类型：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/) 上使用 `embedded_workbook_type` 属性，并结合 [WorkbookType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # 嵌入的工作簿为 .xlsb 格式，不受支持。
            continue

        # 在此读取或修改图表工作簿数据。
```

## **外部工作簿**

Aspose.Slides 支持将外部工作簿用作图表的数据源。

### **设置外部工作簿**

通过使用 [ChartData.set_external_workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以将外部工作簿分配给图表作为其数据源。此方法还可以在外部工作簿被移动后更新其路径。

虽然无法直接编辑存放在远程位置或资源上的工作簿，但仍可将这些工作簿用作外部数据源。如果为外部工作簿提供相对路径，系统会自动转换为完整路径。

下面的 Python 代码展示了如何设置外部工作簿：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # 传入 False 只存储路径：目标工作簿可以暂时不存在。
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` 方法的 `update_chart_data` 参数指示是否加载 Excel 工作簿。

- 当 `update_chart_data` 设置为 `False` 时，仅更新工作簿路径；图表数据不会从目标工作簿加载或刷新。目标工作簿不存在或不可用时请使用此设置。  
- 当 `update_chart_data` 设置为 `True`（默认）时，图表数据会从目标工作簿加载并更新。如果无法打开该工作簿，将抛出消息为 “External workbook is not available” 的异常。

### **创建外部工作簿**

通过使用 [read_workbook_stream](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 和 [set_external_workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您既可以从头创建外部工作簿，也可以将内部工作簿转换为外部工作簿。

以下 Python 代码演示了外部工作簿的创建过程：

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **获取图表的外部数据源工作簿路径**

有时图表的数据链接到外部 Excel 工作簿，而不是演示文稿的嵌入数据。使用 Aspose.Slides，您可以检查图表的数据源，并在其为外部工作簿时读取完整的工作簿路径。

1. 创建一个 [Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 实例。  
2. 按索引获取幻灯片引用。  
3. 获取图表形状的引用。  
4. 获取表示图表数据源的源（[ChartDataSourceType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatasourcetype/)）。  
5. 检查源类型是否匹配外部工作簿数据源类型。

下面的 Python 代码演示了此操作：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **编辑图表数据**

您可以像编辑内部工作簿一样编辑外部工作簿中的数据。如果外部工作簿无法加载，将抛出异常。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿缓存的数据中重建图表工作簿。创建 [LoadOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/)，然后在打开演示文稿之前通过 `LoadOptions.spreadsheet_options` 启用 [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/zh/python-net/aspose.slides.spreadsheetoptions/recover_workbook_from_chart_cache/)。

下面的 Python 示例打开了一个其图表引用不可用外部工作簿的演示文稿，并通过 [Chart.chart_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/chart_data/) 与 [ChartData.chart_data_workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) 访问恢复的数据：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # 在此读取或修改恢复的工作簿数据。
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存的图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿的后续更改。

## **常见问题**

**我能确定特定图表是链接到外部工作簿还是嵌入的工作簿吗？**

可以。图表具有 [data source type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/data_source_type/) 和 [path to an external workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/external_workbook_path/)；如果源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持对外部工作簿使用相对路径，且它们是如何存储的？**

支持。如果您指定相对路径，系统会自动转换为绝对路径。这有助于项目的可移植性；但请注意，演示文稿将在 PPTX 文件中存储绝对路径。

**可以使用位于网络资源/共享上的工作簿吗？**

可以，这些工作簿可以用作外部数据源。不过，Aspose.Slides 不支持直接编辑远程工作簿——只能将其作为数据源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**

只有在您编辑了图表数据时才会。演示文稿存储了指向外部文件的链接，并在读取数据时使用该链接，因此打开并保存演示文稿本身不会更改工作簿。然而，通过图表数据修改的值（参见上面的“编辑图表数据”）将在保存演示文稿时写回外部工作簿——如果原始文件必须保持完整，请先对其进行复制。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是在使用前移除保护，或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)）并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都会存储自己的链接。如果它们都指向同一个文件，更新该文件后在下次加载数据时所有图表都会反映更改。