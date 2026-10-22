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
description: "了解适用于 .NET 的 Python 版 Aspose.Slides：轻松管理 PowerPoint 和 OpenDocument 格式中的图表工作簿，以简化演示文稿数据。"
---
## **概述**

本文说明如何在 Aspose.Slides 中使用图表工作簿。展示如何通过工作簿流读取和写入图表数据、使用工作簿单元格作为图表数据标签、访问工作表集合，以及为图表值指定数据源类型。

还介绍了将外部工作簿用作图表数据源的操作。示例演示如何创建并分配外部工作簿、检索链接到图表的外部工作簿路径，以及在工作簿可用时编辑图表数据。

对于表示缺失数据的工作簿单元格，请参阅[控制空单元格的显示](/slides/zh/python-net/chart-series/)以了解空单元格与零的区别，以及可用显示模式的折线图比较。

## **包含隐藏行和列的数据**

使用[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/)控制图表是否绘制来自隐藏工作表行和列的数据。将其设为 `True` 只绘制可见单元格，设为 `False` 则同时包含可见和隐藏单元格。此设置仅控制图表绘制，不会隐藏或显示工作表行或列。

[示例演示文稿](hidden-source-data.pptx)的第一张幻灯片的第一个形状是柱形图。嵌入的工作表 `Sheet1` 包含源范围 `A1:C4`。第 3 行和列 C 被隐藏，但它们的单元格仍包含值。

| 工作表行 | A: 月份 | B: 零售 | C: 批发（隐藏列） |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

通过[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)访问源单元格，并读取[ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/)检查其隐藏状态。此属性为只读。在本例中，B2 可见，B3 属于隐藏行，C2 属于隐藏列；示例分别打印 `False`、`True` 和 `True`。

对于本示例，在更改绘制设置后刷新图表数据：使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)保留嵌入工作簿，并使用[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)重新加载。当包含所有单元格时，还需使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)恢复完整范围，包括隐藏的 February 类别。仅更改标志不足以刷新此示例的缓存图表数据和类别标签。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # 从嵌入的工作簿刷新图表数据。
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # 恢复完整的源范围，包括隐藏的类别。
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

该示例保存了两种版本的演示文稿：一种仅包含可见的零售值（10 和 20），另一种包含所有六个值。下图是重新打开保存的演示文稿后渲染的图像；两个文件均保留了各自的绘制设置。第 3 行和列 C 在两个嵌入工作簿中仍保持隐藏。

| 仅可见单元格 (`True`) | 所有单元格 (`False`) |
| --- | --- |
| ![仅可见单元格：1 月和 3 月的零售值 10 和 20。](hidden_cells_True.png) | ![所有单元格：1 月、2 月和 3 月的零售和批发值。](hidden_cells_False.png) |

包含数值的隐藏单元格不同于空单元格。[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)控制缺失值的显示方式；它不包括或排除隐藏的源数据。请参阅[控制空单元格的显示](/slides/zh/python-net/chart-series/#control-the-display-of-empty-cells)获取示例。

## **检索图表的数据范围**

在对现有演示文稿中的工作簿数据进行更新之前，检查源范围以确定每个图表使用的工作表单元格。[ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/)方法返回当前数据范围的工作表限定公式，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 为工作表名称，`!` 将其与单元格范围分隔，`$A$1:$D$5` 标识从 A1 到 D5（含）的单元格。美元符号表示绝对行列引用。

该方法读取当前范围而不更改图表或其工作簿。如果图表未使用工作簿作为数据源，则会抛出异常。更多信息请参阅[ChartData API 参考](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)。

本示例打开演示文稿并直接检查每张幻灯片上的形状是否为图表。它打印每个图表的名称和源范围。如果无法检索范围，则打印诊断信息并继续下一个图表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **从工作簿读取和写入图表数据**

Aspose.Slides for Python via .NET 提供[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)和[write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/)方法，允许读取和写入包含使用 Aspose.Cells 编辑的图表数据的工作簿。**注意**，图表数据必须以相同方式组织或具有类似的结构。

本示例使用第一张幻灯片的第一个形状（柱形图）所在的演示文稿。它将嵌入的工作簿读取为流，清除现有系列和类别，然后将相同的工作簿写回。更改保留在内存中，示例不会保存演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **在工作簿修改后验证图表布局**

当用修改后的工作簿替换嵌入工作簿时，图表仍保留其原始系列和类别集合。此不匹配可能导致[Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/)因索引超出范围而失败。写回更新工作簿之前，请先清除现有系列和类别。本示例使用第一张幻灯片的第一个形状（柱形图）。注释标记了工作簿编辑的位置；可运行的示例将原始工作簿写回并在内存中验证布局。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # 在此修改工作簿流，例如使用 Aspose.Cells。

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

清除集合可在工作簿写回之前移除陈旧的数据引用。为更新的工作簿在使用图表之前重新构建所需的系列和类别映射。

## **为工作簿单元格设置自定义数字格式**

使用[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/)控制数值在图表嵌入工作簿中的显示方式。例如，报告可能需要将转化率显示为四位小数的百分比，将系数显示为五位小数。保持两者为数值，以便后续计算和图表绘制。

数字格式仅更改显示，不改变存储的值。格式 `0.0000%` 将 `0.125` 显示为 `12.5000%`，但不会把存储的数值替换为 `12.5`。同理，`0.00000` 将 `0.1234567` 显示为 `0.12346`，而不对存储值进行四舍五入。如果自定义格式为空字符串 (`""`)，则使用[preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/)。

下面示例创建柱形图并通过[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)访问其单元格。在工作表 0 中，B2 包含转化率，C2 包含系数。两个单元格均提供图表值。示例还启用了与源格式关联的数值标签。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

工作簿单元格格式独立于直接在图表轴或数据标签上设置的格式。在本例中，每个标签因为[show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/)被启用而显示其源单元格的值，并因为[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) 为 `True` 而遵循源数字格式。保存并重新打开演示文稿后，标签显示 `12.5000%` 和 `0.12346`，如下所示。垂直轴使用自己的[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`，并将[is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) 设置为 `False`。

若要独立格式化数据标签，请将其 source‑link 标志设为 `False` 并分配[number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)。这不会更改工作簿单元格的格式。例如，独立标签格式 `0.00` 将第一个值显示为 `0.13`，而 B2 仍显示 `12.5000%`。参见[图表数据标签](/slides/zh/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels)获取直接标签格式化示例。

以下图片是重新打开保存的演示文稿后渲染的：

![带有源链接标签显示 12.5000% 和 0.12346 且轴独立格式化的柱形图。](custom-cell-formats.png)

## **将工作簿单元格设为图表数据标签**

可以使用工作簿单元格中的文本作为图表数据标签。

本示例向现有演示文稿的第一张幻灯片添加默认数据的气泡图。它使用工作表 0 的单元格 A10:A12 作为第一系列的前三个标签，启用来自单元格的标签，并保存更新后的演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **管理工作表**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/)属性提供对图表工作簿中工作表的访问。本示例创建默认数据的饼图并将每个工作表名称打印到控制台。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **指定数据源类型**

系列点值也可以直接存储为数字文字。请参阅[使用数字文字设置系列值](/slides/zh/python-net/chart-series/#set-series-values-using-numeric-literals)获取完整示例，该示例展示了保存和读取过程。点值的数据源类型独立于图表的内部或外部工作簿配置；使用数字文字本身并不会移除嵌入工作簿。

本示例创建默认数据的 3D 柱形图，并使用不同的数据源为两个系列名称赋值。第一个名称使用字符串文字；第二个名称使用工作表 0 中的单元格 C1。[DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) 枚举选择每个名称的来源。示例保存了带有更新系列名称的演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **检测不受支持的嵌入式工作簿格式**

Aspose.Slides 不支持某些图表中可能嵌入的 Excel 二进制工作簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) 上使用[embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/)属性并结合[WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/)枚举来检测不受支持的格式并跳过这些图表。本示例检查现有演示文稿第一张幻灯片上的形状，跳过非图表形状，并为每个带有嵌入 .xlsb 工作簿的图表打印诊断信息。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # 在此读取或修改受支持的图表工作簿数据。
```

## **外部工作簿**

Aspose.Slides 支持使用外部工作簿作为图表的数据源。

### **创建外部工作簿**

使用[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)和[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)将嵌入图表的工作簿导出为文件，并将图表链接到该外部工作簿。

本示例创建默认数据的饼图并导出其工作簿。它在分配外部工作簿作为图表数据源之前关闭输出流，然后保存已链接的演示文稿。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **设置外部工作簿**

使用[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)方法，您可以为图表分配外部工作簿作为数据源。该方法也可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，系统会自动将其转换为完整路径。

本示例使用外部工作簿，其工作表 `Sheet1` 在 B1 包含系列名称，在 A2:A4 包含类别名称，在 B2:B4 包含数值。示例创建饼图，链接工作簿，并使用[set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)将 A1:B4 映射为一个系列和三个类别。随后保存带有链接图表的演示文稿。

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) 中的 `update_chart_data` 参数控制是否加载工作簿。

* 当 `update_chart_data` 为 `False` 时，仅更新工作簿路径。图表数据不会从目标工作簿加载或更新，因此工作簿可以不可用。
* 当 `update_chart_data` 为 `True` 时，图表数据会从目标工作簿更新。

以下示例将占位符 URL 的 `update_chart_data` 设置为 `False`。它保留饼图的默认数据，并在未加载不可用工作簿的情况下保存演示文稿。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **获取图表的外部数据源工作簿路径**

要识别链接到图表的工作簿，请检查图表是否使用外部数据源并检索其工作簿路径。

本示例检查带有链接外部工作簿的演示文稿第一张幻灯片的第一个形状。如果它是链接到外部工作簿的图表，示例会将[external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)打印到控制台。随后保存演示文稿的副本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **编辑图表数据**

您可以像修改内部工作簿内容一样编辑外部工作簿中的数据。当外部工作簿无法加载时，会抛出异常。

本示例使用第一张幻灯片的第一个形状（图表），该图表链接到可访问的外部工作簿。它将第一系列第一个数据点的单元格值设为 100 并保存更新后的演示文稿。编辑单元格值可能会更新链接的外部 XLSX 文件，若需保留原始工作簿，请使用副本。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **从图表缓存恢复工作簿**

如果图表使用的外部工作簿缺失或不可用，Aspose.Slides 可以从演示文稿中缓存的数据重建图表工作簿。创建[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)，配置其[spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)，并在打开演示文稿前将[SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)设为 `True`。

以下 Python 示例恢复第一张幻灯片的第一个形状（图表）的工作簿数据，该图表引用不可用的外部工作簿。它通过[Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/)和[ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/)访问恢复的数据：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # 在此读取或修改恢复的工作簿数据。
    else:
        print("The first shape is not a chart.")
```

如果外部工作簿不可用且未启用恢复，Aspose.Slides 将抛出异常。仅在使用缓存的图表数据是可接受的回退方案时才启用恢复，因为缓存可能不包含对外部工作簿在上次更新演示文稿后所做的更改。

## **常见问题**

**我能判断特定图表是链接到外部工作簿还是嵌入式工作簿吗？**

可以。图表具有[data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)和[external workbook path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)；如果数据源是外部工作簿，您可以读取完整路径以确认使用了外部文件。

**是否支持外部工作簿的相对路径？它们是如何存储的？**

支持。若指定相对路径，系统会自动转换为绝对路径。演示文稿在 PPTX 文件中存储绝对路径，移动工作簿可能需要更新链接。

**我可以使用位于网络资源/共享上的工作簿吗？**

可以，这类工作簿可用作外部数据源。但 Aspose.Slides 不支持直接编辑远程工作簿——它们只能作为源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**

演示文稿存储了指向外部文件的[link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)。编辑基于单元格的图表数据也可能更新链接的本地 XLSX 文件。如果原始文件必须保持不变，请使用工作簿的副本。

**如果外部文件受密码保护该怎么办？**

Aspose.Slides 在链接时不接受密码。常见做法是提前解除保护或准备已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/python-net/)），然后链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**

可以。每个图表都存储自己的链接。如果它们指向同一文件，更新该文件后在下次加载数据时会在所有图表中体现。