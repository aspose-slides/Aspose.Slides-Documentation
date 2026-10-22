---
title: 在 Python 中管理演示文稿的图表数据系列
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
description: "了解如何在 Python 中管理演示文稿的图表系列、数据点、工作簿单元格、格式、重叠、间隙宽度和负值。"
---
## **概述**

图表可以将其绘制的数值存储在工作簿单元格中或直接作为数值文字。一个[ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/)表示一组相关的数值，每个[ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/)表示该系列中的一个点。[ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/)对象提供系列共享的标签或分组值。在使用默认数据创建的图表中，系列名称、类别和点值使用来自图表工作簿的[ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/)对象。

对于典型的类别图，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/)的工作表、行和列索引是从零开始的。此布局在创建带默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，请在更改工作簿数值之前检查系列、类别和数据点引用的单元格。

Chart 设置有三种不同的作用域：

- 系列级别的设置，例如[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)，为单个系列中的所有点提供默认外观。
- 数据点级别的设置，例如[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)，覆盖单个点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，通过[ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式同时存在时，点的格式优先适用于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **使用数值文字设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，请使用数值文字。在通过[as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/)为每个点的[value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)赋值之前，将[data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/)设置为[DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/)。

集合设置控制该系列中所有点值的源类型。每个点的[value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/)报告所选类型；通过集合设置进行更改。使用`WORKSHEET`时，使用[as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/)访问引用的单元格。使用`DOUBLE_LITERALS`时，使用`as_literal_double`直接读取或写入数字。

下面的示例创建一个具有默认系列和类别的柱形图，然后为其第一系列的现有点分配 10、20 等计算值。它保存演示文稿，重新打开并打印存储的值。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

点值源类型与[ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/)分开，后者标识图表的内部或外部工作簿配置。使用数值文字本身并不会删除嵌入的工作簿。在本例中，工作簿仍用于类别标签、系列名称和其他系列。有关工作簿管理，请参阅[Chart Workbook](/slides/zh/python-net/chart-workbook/)。

对于散点图和气泡图，设置[data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/)和[data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/)以选择[x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/)和[y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/)的来源。气泡图还使用[data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/)来获取[bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/)的来源。在为这些值分配数字之前，将每个适用的来源设置为`DOUBLE_LITERALS`，然后通过其`as_literal_double`属性进行读取或写入。

## **设置图表系列重叠**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/)报告 2D 图表中条形或柱形的重叠程度，范围从 -100 到 100 百分比。它是父系列组上设置的只读投影。通过设置[ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/)来更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

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

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/)为整个系列设置默认填充。如果某一点已经具有显式填充，其[ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/)设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝色填充：

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

您也可以更新[ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/)已经引用的单元格。此方法避免对已有图表假设特定的行列：

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

### **从多个单元格创建包含名称的系列**

当产品名称和报告期间分别存储在不同工作簿单元格时，复合系列名称非常有用。例如，您可以将 B1 中的`Product A`与 C1 中的`2026`组合成单个系列名称，同时保持两部分与其源单元格的链接。

使用[ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/)检索名称范围，然后将该集合传递给[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/)。`skip_hidden_cells`参数控制是否包括隐藏单元格：`True`排除，`False`包括。此示例使用`False`以包含名称范围内的所有单元格。

下面的示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # 这两个单元格提供系列名称。
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # 各个单元格提供类别和数值数据点。
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

得到的系列名称为`Product A 2026`，两单元格值之间有空格。图例将其显示为两列的单个条目。下图是从保存的演示文稿渲染的图像：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用此方法仅读取计算出的颜色，不会分配新的填充。

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

确切的颜色取决于图表样式和主题。

## **设置图表系列的反转填充颜色**

对于条形、柱形和气泡系列，[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)可以为负值显示不同的填充。将常规系列填充设为实色，启用反转，并通过[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)指定负值颜色。负数在工作簿中保持不变，仅改变其显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

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

您可以通过[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅为选中的点启用，并为该点分配负值以显示效果：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为`None`。对于柱形图，绘制的数值可通过[ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/)获得。数据点仍保持在相同的类别位置，但图表会根据空值设置将其视为空白。

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示您想要移除的数值的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)，因为该方法会删除集合中的所有数据点。

## **控制空单元格的显示**

隐藏的包含数值的单元格与空单元格是不同的情况。要包括或排除来自隐藏工作表行和列的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含`0`的单元格表示已知的数值。将[ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/)设为`None`即可使单元格为空。数值零始终保持为零，无论空单元格设置如何。

使用[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)选择图表如何显示空单元格。此设置适用于整个图表。它改变空白的绘制方式，而不会将空工作簿单元格填充为零或插值值。

下面的自包含示例创建一个具有单个系列的折线图，清除第 3 天的数值，并使用每种模式分别保存同一图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)使用工作表 0，第 0 列作为类别标签，第 1 列作为数值；第 0 行存放系列名称。最终数据为`10, 20, empty, 30, 40`。

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

    # 让第 3 天真正空置，同时保留其类别和数据点。
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

每个输出文件在保存之前存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。如果只想保存一种版本，只需在保存演示文稿前设置所需模式，而不是遍历所有模式。

下面的比较展示了三个文件中相同的数据。第 3 天在工作簿中始终为空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观地比较所有三种模式。条形和柱形图没有连线跨越缺失的类别，因此`SPAN`无法产生上图所示的连接段；缺失的柱形和零高度的柱形也可能看起来相似。类似地，仅使用标记的散点图没有连接线。不要指望每种图表类型都能得到三种截然不同的结果；请检查您使用的图表类型的实际输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，表示为条形或柱形宽度的百分比。与重叠类似，它属于父系列组而不是单个系列。为组一次性设置[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。较大的值会在簇之间创建更多空间，较小的值则使它们更密集。

下面的示例更改间隙宽度并仅保存最终的演示文稿：

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

所有由[ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并不全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 与 Y 值，气泡图则额外使用气泡大小。请使用与系列类型匹配的数据点创建方法。诸如重叠和间隙宽度之类的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载方式创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点在预期的类别下绘制。

**如何只清除一个点而不是整系列？**

将相关的值单元格设为`None`，即可在保持该点类别位置的同时将其设为空点。当只想删除该系列的所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/)。如果还要删除类别，请确保更新每个系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

显示效果取决于图表类型和[Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/)。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来填补。请选择与演示文稿中缺失数据含义相匹配的设置。完整示例和可视化比较请参阅[Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，启用[ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/)并设置[ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/)。可以通过[ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/)为单个点覆盖此行为。这些属性影响格式，而不是存储的数值。

**当系列和点同时设置格式时，哪个生效？**

显式的数据点格式在该点上具有优先权。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组属性如重叠和间隙宽度控制布局，并不是点级别的格式覆盖。

**图表可以包含的系列数量是否有限制？**

Aspose.Slides 并未施加单独的固定系列计数限制。实际限制取决于演示文稿文件的约束、可用内存、渲染时间以及图表可读性。

**当列之间太靠近或太远时应如何调整？**

在相应的父系列组上设置[ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/)。增加该值可扩大簇之间的间距，减小则使簇更紧凑。