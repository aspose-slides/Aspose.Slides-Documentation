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
description: "了解如何在使用 Python 的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[ChartSeries](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/)代表一组相关值，系列中的每个[ChartDataPoint](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/)对应一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartcategory/)对象提供系列共享的标签或分组值。系列名称、类别以及点值因此连接到[ChartDataCell](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的分类图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)的工作表、行和列索引均为零基。这种布局在创建带有默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，请在更改工作簿数值之前检查系列、类别和数据点引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[ChartSeries.format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/format/)，为整个系列的所有点提供默认外观。
- 数据点级别设置，例如[ChartDataPoint.format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/format/)，会覆盖该点所在系列的外观。
- 组合设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[ChartSeries.parent_series_group](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/parent_series_group/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.overlap](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/overlap/)报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100 百分比。它是对父系列组中设置的只读投影。设置[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/overlap/)即可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一系列的组设置重叠：

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

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/format/)为整个系列设置默认填充。如果某个点已经有显式填充，其[ChartDataPoint.format](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/format/)设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名常量明确了该结构：

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

您也可以更新[ChartSeries.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/name/)已引用的单元格。这种做法避免了对已有图表中特定行列的假设：

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

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算得到的颜色，不会分配新的填充。

下面的示例打印每个默认系列的自动颜色：

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

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，`[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/invert_if_negative/)`可以在负值时使用不同的填充。将常规系列填充设为实心，启用反转，并通过[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)指定负值颜色。工作簿中的负数保持不变，仅改变其显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行存放系列名称，第 0 列存放类别名称，第 1 列存放数值：

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

![反转实心填充颜色](inverted_solid_fill_color.png)

您也可以通过[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)为单个点启用反转。下面的示例在系列中禁用反转，仅对选定点启用，并为该点分配负值以便看到效果：

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

要使某一点为空而不删除其他点，可将其对应的工作簿单元格设为 `None`。对于柱形图，绘制的数值可通过[ChartDataPoint.value](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/value/)获取。数据点仍保持在相同的类别位置，但图表会依据空值设置将其视为空白。

下面的示例仅清除第一系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除代表您想删除的数值的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapointcollection/clear/)，因为该方法会删除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的间距，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而不是单个系列。对组一次性设置[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。较大的值会在簇之间创建更多空间，较小的值会使它们更密集。

下面的示例更改间隙宽度并仅保存最终演示文稿：

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

![间隙宽度](gap_width.png)

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并不全部具有相同的值结构或设置。例如，分类图使用类别和值，散点图使用 X 和 Y 值，气泡图则额外使用气泡大小。使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某一系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表会包含默认数据吗？**

会。默认情况下，[ShapeCollection.add_chart](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shapecollection/add_chart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。还有重载可以在不生成默认数据的情况下创建图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用[ChartDataWorkbook](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相应的值单元格设为 `None`，即可保留该点的类别位置而将其设为空点。仅在需要删除该系列所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapointcollection/clear/)。如果同时删除类别，请更新所有系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

显示结果取决于图表类型和[Chart.display_blanks_as](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chart/display_blanks_as/)。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择符合您演示文稿中缺失数据含义的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/invert_if_negative/)并设置[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)。您可以通过[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)为单个点覆盖此行为。这些属性影响显示格式，而非存储的数值。

**当系列和点都被格式化时，哪种格式生效？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动的图表样式和主题。组属性（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表能容纳的系列数量是否有限制？**

Aspose.Slides 并未设定单独的固定系列计数上限。实际可容纳的数量受演示文稿文件限制、可用内存、渲染时间以及图表可读性等因素影响。

**当柱形之间距离过近或过远时应如何调整？**

在相应的父系列组上设置[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/zh/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。增大该值可以扩大簇之间的间距，减小则使簇更紧凑。