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
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 的 Aspose.Slides for Python 轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文解释了如何在 Aspose.Slides 中使用图表工作簿。它展示了如何通过工作簿流读取和写入图表数据、将工作簿单元格用作图表数据标签、访问工作表集合以及为图表值指定数据源类型。

它还涵盖了将外部工作簿用作图表数据源的使用方法。示例演示了如何创建并分配外部工作簿、获取链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

## **从工作簿读取和写入图表数据**

Aspose.Slides 提供了读取和写入图表数据工作簿的方法（这些工作簿包含使用 Aspose.Cells 编辑的图表数据）。**注意:** 图表数据必须以相同的方式组织，或具有与源相似的结构。

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

## **将工作簿单元格设为图表数据标签**

有时您需要直接来自底层数据工作簿单元格的图表标签。Aspose.Slides 允许您将数据标签绑定到特定的工作簿单元格，使标签文本始终反映单元格的值。下面的示例展示了如何启用基于单元格的值标签，并将选定的标签指向图表工作簿中的自定义单元格。

1. 创建 [Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 添加带有示例数据的气泡图表。  
4. 访问图表系列。  
5. 使用工作簿单元格作为数据标签。  
6. 保存演示文稿。

下面的 Python 代码展示了如何将工作簿单元格设为图表数据标签：

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

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/) 上使用 `embedded_workbook_type` 属性，并结合 [WorkbookType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/workbooktype/) 枚举来检测不受支持的格式并跳过这些图表。

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

通过使用 [ChartData.set_external_workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以将外部工作簿分配给图表作为其数据源。 如果外部工作簿已被移动，此方法还可以更新其路径。

虽然您无法编辑存储在远程位置或资源上的工作簿数据，但仍可以将这些工作簿用作外部数据源。 如果为外部工作簿提供相对路径，它会自动转换为完整路径。

下面的 Python 代码展示了如何设置外部工作簿：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` 方法的 `update_chart_data` 参数指定是否加载 Excel 工作簿。

- 当 `update_chart_data` 设置为 `False` 时，仅更新工作簿路径；不会从目标工作簿加载或刷新图表数据。当目标工作簿不存在或不可用时使用此设置。  
- 当 `update_chart_data` 设置为 `True` 时，将从目标工作簿加载并更新图表数据。

### **创建外部工作簿**

通过使用 [read_workbook_stream](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 和 [set_external_workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以从头创建外部工作簿，或将内部工作簿转换为外部工作簿。

下面的 Python 代码演示了外部工作簿的创建过程：

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

有时图表的数据链接到外部 Excel 工作簿，而不是演示文稿的嵌入数据。 使用 Aspose.Slides，您可以检查图表的数据源，如果它是外部工作簿，则读取完整的工作簿路径。

1. 创建 [Presentation](https://docs.aspose.com/slides/zh/python-net/api-reference/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 获取图表形状的引用。  
4. 获取表示图表数据源的 source（[ChartDataSourceType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatasourcetype/)）。  
5. 检查 source 类型是否匹配外部工作簿数据源类型。

下面的 Python 代码演示了该操作：

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

您可以像编辑内部工作簿一样编辑外部工作簿中的数据。 如果外部工作簿无法加载，将抛出异常。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我能否确定特定图表是链接到外部工作簿还是嵌入式工作簿？**  
是的。图表具有一个 [data source type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/data_source_type/) 和一个 [path to an external workbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/external_workbook_path/)；如果源是外部工作簿，您可以读取完整路径以确保使用的是外部文件。

**是否支持外部工作簿的相对路径，且它们如何存储？**  
是的。如果您指定相对路径，它会自动转换为绝对路径。这有利于项目的可移植性；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**我能使用位于网络资源/共享上的工作簿吗？**  
可以，这类工作簿可以用作外部数据源。不过，Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为数据源使用。

**在保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**  
不会。演示文稿仅存储一个指向外部文件的 [link to the external file](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，并在读取数据时使用该链接。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护，我该怎么办？**  
Aspose.Slides 在链接时不接受密码。常见的做法是事先移除保护或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**  
可以。每个图表都存储自己的链接。如果它们都指向同一个文件，更新该文件后，下次加载数据时所有图表都会反映更改。