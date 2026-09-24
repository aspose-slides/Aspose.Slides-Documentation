---
title: 在 Python 中管理演示文稿的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/python-java/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 系列名称
- 数据点
- 工作簿单元格
- 系列间隙
- 负值
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个 [ChartSeries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/) 表示一组相关值，系列中的每个 [ChartDataPoint](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/) 引用一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartcategory/) 对象提供系列共享的标签或分组值。因此，系列名称、类别和数据点值连接到 [ChartDataCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatacell/) 对象，而不是仅作为显示文本存储。

对于典型的类别图表，默认工作簿使用第 0 行存放系列名称，第 0 列存放类别名称，其余单元格存放系列数值。传递给 [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/#getCell) 的工作表、行和列索引均为零基。此布局在创建使用默认数据的图表时很有用，但不要假设每个现有图表都使用该布局。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点引用的单元格。

图表设置具有三种不同的范围：

- 系列级别设置，例如 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getFormat)，为同一系列的所有点提供默认外观。
- 数据点级别设置，例如 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getFormat)，覆盖该点的系列外观。
- 组设置适用于属于同一 [ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/) 的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点的系列格式。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getOverlap) 报告 2D 图表中条形或柱形的重叠程度，范围为 -100% 到 100%。它是对父系列组设置的只读投影。使用 [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setOverlap) 可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图表中不相关的系列组没有影响。

以下示例为包含第一个系列的组设置重叠：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # 新图表包含示例系列、类别和数值。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![The series overlap](series_overlap.png)

## **更改系列填充颜色**

使用 [ChartSeries.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getFormat) 可为整个系列设置默认填充。如果某个点已经具有显式填充，则其 [ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getFormat) 设置会覆盖该点的系列填充。

以下示例为第一个系列应用实心蓝色填充：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![The color of the series](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一个系列的名称。下面示例中的已命名变量明确了该结构：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

您也可以更新由 [ChartSeries.getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getName) 已引用的单元格。这种方式避免了对现有图表中特定行列的假设：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![The series name](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) 返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算后的颜色，不会分配新填充。

以下示例打印每个默认系列的自动颜色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

默认图表样式的示例输出：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

确切颜色取决于图表样式和主题。

## **为图表系列设置负值填充颜色**

对于条形、柱形和气泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setInvertIfNegative) 可在负值时使用不同的填充。将常规系列填充设为实心，启用反转，并通过 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 指定负值颜色。工作簿中的负数保持不变，仅改变显示颜色。

以下示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含类别名称，第 1 列包含数值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![The inverted solid fill color](inverted_solid_fill_color.png)

您可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单个点启用反转。以下示例在系列层面禁用反转，仅为选定点启用，并为该点分配负值以便观察效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **清除特定数据点的值**

要使某一点为空而不删除其他点，可将其对应的工作簿单元格设为 `None`。对于柱形图，绘制的数值可通过 [ChartDataPoint.getValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getValue) 获取。数据点仍保持在相同的类别位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一个系列的第二个点：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

散点图使用独立的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除代表您要删除的数值的单元格。不要在想保留其他点时调用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示方式**

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知数值。调用 [ChartDataCell.setValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatacell/#setValue) 并传入 `None` 可将单元格设为空。数值零始终保持为零，不受空单元格设置影响。

使用 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDisplayBlanksAs) 选择图表如何显示空单元格。此设置作用于整个图表，改变空白的绘制方式，而不会用零或插值填充空工作簿单元格。

以下自包含示例创建一个包含单系列的折线图，清除第 3 天的数值，并分别以每种模式保存同一图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/) 使用工作表 0，第 0 列存放类别标签，第 1 列存放数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # 将第 3 天真正留空，同时保留其类别和数据点。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每个输出文件在保存前存储对应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只需一种版本，请在保存演示文稿前指定所需模式，避免遍历所有模式。

下面的比较展示了三个文件中相同的数据。第 3 天在工作簿中均为空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较三种模式。条形和柱形图没有连线跨越缺失类别，因此 `Span` 无法产生如上所示的连接段；缺失的柱形和零高度的柱形也可能看起来相似。同样，仅有标记的散点图没有连线。不要期望每种图表类型都产生三种截然不同的结果；请检查您使用的图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对该组调用一次 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setGapWidth) 即可。较大的值会在簇之间创建更多空间，较小的值则使簇更紧密。

以下示例更改间隙宽度并仅保存最终演示文稿：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![The gap width](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/) 枚举表示的图表类型均使用图表数据，但它们的系列并不全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用 X 和 Y 值，气泡图还增加气泡大小。请使用与系列类型相匹配的数据点创建方法。诸如重叠和间隙宽度的选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/) 包含共享组级绘图设置的兼容系列。组合图表可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的每个系列。

**新创建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addChart) 会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载方法创建不带默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点值引用 [ChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/) 中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相关的值单元格设为 `None`，即可保留该点的类别位置作为空点。仅在需要删除该系列所有点时才使用 [ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除了类别，请更新每个系列，使其数值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型以及通过 [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDisplayBlanksAs) 配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据含义相匹配的设置。请参阅 [控制空单元格的显示方式](#control-the-display-of-empty-cells) 了解完整示例和可视化比较。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用 [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setInvertIfNegative) 并设置 [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) 返回的颜色。您也可以通过 [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) 为单独的点覆盖此行为。这些方法影响格式，而不改变存储的数值。

**当系列和点都被格式化时，哪个格式生效？**

显式的数据点格式对该点具有优先权。其他点继续使用显式的系列格式，或在系列格式未定义时使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表所能容纳的系列数量是否有限制？**

Aspose.Slides 并未施加单独的固定系列计数限制。实际使用中，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了实用的上限。

**当柱形太靠近或太远时应该怎么做？**

对相应的父系列组调用 [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大数值可扩大簇之间的间距，减小数值则使簇更靠近。