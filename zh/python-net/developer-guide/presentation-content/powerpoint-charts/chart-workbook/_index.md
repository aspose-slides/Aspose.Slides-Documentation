---
title: 使用 Python 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/python-net/developer-guide/presentation-content/powerpoint-charts/chart-workbook/
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
description: "通过 .NET 的 Aspose.Slides for Python，轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---

## **从工作簿设置图表数据**

Aspose.Slides 提供读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）的方法。**注意：** 图表数据必须以相同方式组织，或具有与源相似的结构。

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

有时需要直接从底层数据工作簿的单元格获取图表标签。Aspose.Slides 允许将数据标签绑定到特定工作簿单元格，使标签文本始终反映单元格的值。下面的示例展示了如何启用“从单元格获取值”的标签，并将选定的标签指向图表工作簿中的自定义单元格。

1. 创建 [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片引用。  
3. 添加带有示例数据的气泡图。  
4. 访问图表系列。  
5. 使用工作簿单元格作为数据标签。  
6. 保存演示文稿。

下面的 Python 代码演示了如何将工作簿单元格设置为图表数据标签：

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

下面的 Python 代码演示如何使用 `worksheets` 属性访问工作表集合：

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

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **设置外部工作簿**

通过使用 [ChartData.set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以将外部工作簿分配给图表作为其数据源。该方法还可以在外部工作簿移动后更新其路径。

虽然无法编辑存储在远程位置或资源上的工作簿数据，但仍可以将这些工作簿用作外部数据源。如果为外部工作簿提供相对路径，它会自动转换为完整路径。

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

- 当 `update_chart_data` 设置为 `False` 时，仅更新工作簿路径；图表数据不会从目标工作簿加载或刷新。目标工作簿不存在或不可用时使用此设置。  
- 当 `update_chart_data` 设置为 `True` 时，图表数据会从目标工作簿加载并更新。

### **创建外部工作簿**

通过使用 [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) 和 [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 方法，您可以从头创建外部工作簿，或将内部工作簿转换为外部工作簿。

以下 Python 代码演示外部工作簿的创建过程：

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

有时图表的数据链接到外部 Excel 工作簿而不是演示文稿的嵌入数据。使用 Aspose.Slides，您可以检查图表的数据源，如果是外部工作簿，则读取完整的工作簿路径。

1. 创建 [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片引用。  
3. 获取图表形状的引用。  
4. 获取表示图表数据源的 source ([ChartDataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatasourcetype/))。  
5. 检查源类型是否匹配外部工作簿数据源类型。

下面的 Python 代码演示此操作：

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

您可以像编辑内部工作簿一样编辑外部工作簿中的数据。如果无法加载外部工作簿，会抛出异常。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**我如何判断特定图表是链接到外部工作簿还是嵌入工作簿？**

可以。图表具有 [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) 和 [external workbook path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。如果数据源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持外部工作簿的相对路径，且它们如何存储？**

支持。指定相对路径时，会自动转换为绝对路径。这对项目可移植性很有帮助；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**可以使用位于网络资源/共享的工作簿吗？**

可以，这类工作簿可作为外部数据源使用。但 Aspose.Slides 不支持直接编辑远程工作簿——只能将其用作数据来源。

**保存演示文稿时，Aspose.Slides 是否会覆盖外部 XLSX？**

不会。演示文稿只存储指向外部文件的 [link](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)，用于读取数据。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是预先去除保护，或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/python-net/)），然后链接该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都保存自己的链接。如果它们都指向同一个文件，更新该文件后，下次加载数据时所有图表都会反映更改。