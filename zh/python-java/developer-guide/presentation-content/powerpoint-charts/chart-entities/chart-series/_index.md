---
title: 管理演示文稿中的图表数据系列（Python）
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

图表将绘制的数据存储在图表数据工作簿中。一个[ChartSeries](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/)表示一组相关值，系列中的每个[ChartDataPoint](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/)引用一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。因此，系列名称、分类和点值连接到[ChartDataCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的分类图，默认工作簿使用第 0 行存放系列名称，第 0 列存放分类名称，其余单元格存放系列数值。传递给[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/#getCell)的工作表、行和列索引是从零开始的。此布局在创建默认数据的图表时很有用，但不要假设所有现有图表都使用它。对于已加载的演示文稿，请在更改工作簿值之前检查系列、分类和数据点引用的单元格。

图表设置有三个不同的作用域：

- 系列级设置，例如[ChartSeries.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getFormat)，为一个系列中的所有点提供默认外观。
- 数据点级设置，例如[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getFormat)，覆盖该点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，可通过[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getParentSeriesGroup)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当系列和点两者都有格式时，点的格式优先。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getOverlap)报告 2D 图表中条形或柱形的重叠程度，范围为 -100 到 100%。它是对父系列组设置的只读投影。使用[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setOverlap)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一系列的组设置重叠：

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

    # 新图表包含示例系列、分类和数值。
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getFormat)为整个系列设置默认填充。如果某个点已经有显式填充，其[ChartDataPoint.getFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getFormat)设置会覆盖该点的系列填充。

下面的示例为第一系列应用纯蓝填充：

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

![系列颜色](series_color.png)

## **更改系列名称**

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚类柱形图创建的默认工作簿中，单元格 B1 位于第 0 行第 1 列，包含第一系列的名称。下面示例中的命名变量明确了该结构：

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

您也可以更新已由[ChartSeries.getName](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getName)引用的单元格。此方法避免在现有图表中假设特定的行和列：

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

![系列名称](series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor)返回根据系列索引和图表样式计算的颜色。该颜色在系列填充未显式定义时使用。调用此方法仅读取计算出的颜色，不会分配新填充。

下面的示例打印每个默认系列的自动颜色：

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

## **为图表系列设置负值填充颜色反转**

对于条形、柱形和气泡系列，使用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setInvertIfNegative)可以为负值显示不同的填充。将常规系列填充设为实色，启用反转，并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)分配负值颜色。工作簿中的负数保持不变，仅显示颜色变化。

下面的示例用一个系列替换默认图表数据。工作表第 0 行包含系列名称，第 0 列包含分类名称，第 1 列包含数值：

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

![反转实色填充颜色](inverted_solid_fill_color.png)

您可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点启用反转。在下面的示例中，系列的反转被禁用，仅对选定点启用，并为该点分配负值以便看到效果：

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

要使某一点为空而不删除其他点，可将其对应的工作簿单元格设为`None`。对于柱形图，绘制的数值可通过[ChartDataPoint.getValue](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#getValue)获取。数据点仍保持在相同的分类位置，但图表会根据空白值设置将其视为空白。

下面的示例仅清除第一系列中的第二个点：

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

散点图使用独立的 X 和 Y 单元格，气泡图还使用尺寸单元格。仅清除表示您想删除的数值的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会移除集合中的所有数据点。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，表示为条形或柱形宽度的百分比。与重叠一样，它属于父系列组而不是单个系列。对组调用一次[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。数值越大，簇之间的空间越大；数值越小，簇越密集。

下面的示例更改间隙宽度并仅保存最终演示文稿：

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

![间隙宽度](gap_width.png)

## **常见问题**

**哪些图表类型支持数据系列？**

由[ChartType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/charttype/)枚举表示的所有图表类型都使用图表数据，但它们的系列并非全部具有相同的值结构或设置。例如，分类图使用分类和数值，散点图使用 X 和 Y 值，气泡图则添加气泡大小。使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过一个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addChart)会创建示例系列、分类和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和分类集合。还有重载方法可创建不含默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、分类标签和数据点值引用[ChartDataWorkbook](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，保持分类行和系列值行对齐，以便每个点在预期的分类下绘制。

**如何只清除一个点而不是整条系列？**

将相关的值单元格设为`None`，以保留该点的分类位置作为空点。仅在想要删除该系列所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除分类，请更新每个系列，使其值仍与分类集合对齐。

**空点如何显示？**

结果取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chart/#setDisplayBlanksAs)配置的值。支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据含义相匹配的设置。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#setInvertIfNegative)并设置[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)返回的颜色。您可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点覆盖此行为。这些方法影响格式，而不是存储的数值。

**当系列和点都被格式化时，哪个格式生效？**

显式的数据点格式对该点优先。其他点继续使用显式的系列格式，或在未定义系列格式时使用自动图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级格式覆盖。

**图表能包含的系列数量是否有限制？**

Aspose.Slides 并未设置固定的系列数量上限。实际上，演示文稿文件的限制、可用内存、渲染时间以及图表可读性决定了实用的上限。

**当列之间太靠近或太远时应如何调整？**

对相应的父系列组调用[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大数值可以扩大簇之间的间距，减小数值则可以使簇更靠近。