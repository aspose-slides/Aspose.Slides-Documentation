---
title: 在 Python 中管理演示文稿中的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/python-net/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在演示文稿中使用 Python 管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[ChartSeries](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/)表示一组相关值，而系列中的每个[ChartDataPoint](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/)指向一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、类别和点值连接到[ChartDataCell](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatacell/)对象，而不仅仅存储为显示文本。

对于典型的类别图表，默认工作簿使用第0行存放系列名称，第0列存放类别名称，其余单元格用于系列值。传递给[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)的工作表、行和列索引是从零开始的。此布局在创建带有默认数据的图表时很有用，但不要假设每个现有图表都使用该布局。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的范围：

- 系列级别的设置，例如[ChartSeries.format]，为同一系列的所有点提供默认外观。
- 数据点级别的设置，例如[ChartDataPoint.format]，覆盖该点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup]的兼容系列。当需要设置如重叠或间隙宽度等选项时，可通过[ChartSeries.parent_series_group]访问该组。

当未设置显式的点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式同时存在时，点的格式对该点具有优先权。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.overlap](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/overlap/)报告2D图表中条形或柱形的重叠程度，范围为-100到100百分比。它是父系列组设置的只读投影。设置[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/overlap/)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图表中不相关的系列组没有影响。

以下示例为包含第一系列的组设置重叠：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # 新图表包含示例系列、类别和数值。
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.format]为整个系列设置默认填充。如果某个点已经具有显式填充，则其[ChartDataPoint.format]设置会覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色填充：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The color of the series](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格B1位于第0行第1列，包含第一系列的名称。下面示例中的命名常量明确了该结构：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

您也可以更新[ChartSeries.name]已经引用的单元格。此方法避免了对现有图表中特定行列的假设：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The series name](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)返回根据系列索引和图表样式计算的颜色。这是当系列填充未显式定义时使用的颜色。调用该方法仅读取计算得到的颜色；不会分配新的填充。

以下示例打印每个默认系列的自动颜色：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

默认图表样式的示例输出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

具体颜色取决于图表样式和主题。

## **为图表系列设置负值反转填充颜色**

对于条形、柱形和气泡系列，[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/invert_if_negative/) 可以使用不同的填充来显示负值。将常规系列填充设置为实色，启用反转，并通过[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)分配负值颜色。负数在工作簿中保持不变，只有显示颜色会改变。

以下示例将默认图表数据替换为单一系列。工作表第0行包含系列名称，第0列包含类别名称，第1列包含数值：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The inverted solid fill color](inverted_solid_fill_color.png)

您可以通过[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选定的点启用反转。该点还被赋予负值，以便看到效果：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **清除特定数据点的值**

要使某一点为空而不删除其他点，将其对应的工作簿单元格设置为`None`。对于柱形图，绘制的数值可通过[ChartDataPoint.value]获取。数据点仍保留在相同的类别位置，但图表会根据其空值设置将该值视为空白。

以下示例仅清除第一系列的第二个点：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

散点图使用单独的X和Y单元格，气泡图还使用尺寸单元格。仅清除代表您要删除的值的单元格。若想保留其他点，请勿调用[ChartDataPointCollection.clear]，因为该方法会删除该系列中的所有数据点。

## **控制空单元格的显示**

包含值的隐藏单元格与空单元格是不同的情况。若要在隐藏的工作表行和列中包含或排除数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿单元格表示缺失数据；包含`0`的单元格表示已知的数值。将[ChartDataCell.value]设为`None`即可使单元格为空。无论空单元格设置如何，数值零仍保持为零。

使用[Chart.display_blanks_as]选择图表如何显示空单元格。此设置适用于整个图表。它改变空白的绘制方式，但不会将空工作簿单元格填充为零或插值。

以下独立示例创建一个包含一个系列的折线图，清除第3天的数值，并以每种模式保存相同的图表。无需输入文件。[ChartDataWorkbook]使用工作表0，第0列作为类别标签，第1列作为数值；第0行保存系列名称。最终数据为`10, 20, empty, 30, 40`。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # 将第3天真正留空，同时保留其类别和数据点。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

每个输出文件在保存前存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。若只需保存一个版本，只需设置所需模式并一次保存演示文稿，而不是遍历所有模式。

以下比较显示了三个文件中相同的数据。无论哪种情况，工作簿中的第3天都是空的：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图使三种模式都易于比较。柱形图和条形图没有跨缺失类别的连线，因此`SPAN`无法生成上述连接段；缺失的柱形和零高度的柱形也可能看起来相同。类似地，仅带标记的散点图没有连线。不要指望每种图表类型都有三种不同的结果；请检查所使用图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。和重叠一样，它属于父系列组而非单个系列。为组一次性设置[ChartSeriesGroup.gap_width]。较大的值会在簇之间创建更多空间，较小的值则使它们更紧密。

以下示例更改间隙宽度并仅保存最终的演示文稿：

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The gap width](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

所有由[ChartType]枚举表示的图表类型都使用图表数据，但它们的系列并不具有相同的值结构或设置。例如，类别图表使用类别和数值，散点图使用X和Y值，气泡图则添加气泡大小。请使用与系列类型相匹配的数据点创建方法。诸如重叠和间隙宽度的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup] 包含共享组级绘图设置的兼容系列。组合图表可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.add_chart]会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。亦可使用重载创建不含默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[ChartDataWorkbook]中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点在预期的类别下绘制。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为`None`，即可保留该点的类别位置为空点。仅在希望删除该系列的所有点时才使用[ChartDataPointCollection.clear]。如果同时删除了类别，请更新每个系列，使其值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型和[Chart.display_blanks_as]。支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据含义相匹配的设置。完整示例和可视比较请参见[控制空单元格的显示]。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[ChartSeries.invert_if_negative]并设置[ChartSeries.inverted_solid_fill_color]。您也可以通过[ChartDataPoint.invert_if_negative]为单个点覆盖此行为。这些属性影响格式，而不改变存储的数值。

**当系列和点都进行了格式设置时，哪种格式优先？**

对于该点，显式的数据点格式具有优先权。其他点继续使用显式的系列格式，或者在未定义系列格式时使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表能包含的系列数量是否有限制？**

Aspose.Slides 并未设定单独的系列数量上限。实际使用中，演示文稿文件限制、可用内存、渲染时间以及图表可读性决定了实际可接受的上限。

**当柱形之间太近或太远时应如何调整？**

在相应的父系列组上设置[ChartSeriesGroup.gap_width]。增大该值可扩大簇之间的间距，减小则使簇更紧密。