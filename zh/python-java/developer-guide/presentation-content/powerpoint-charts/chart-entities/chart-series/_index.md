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

图表可以将其绘制的数值存储在工作簿单元格中或直接作为数字文字。一个[ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/)表示一组相关的数值，每个[ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/)表示该系列中的一个点。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。在使用默认数据创建的图表中，系列名称、类别和点值使用来自图表工作簿的[ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/)对象。

对于典型的类别图，默认工作簿使用第0行存放系列名称，第0列存放类别名称，其余单元格用于系列数值。传递给[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell)的工作表、行和列索引是从零开始的。当您使用默认数据创建图表时，此布局很有用，但不要假设每个现有图表都使用它。对于已加载的演示文稿，在更改工作簿数值之前，请检查系列、类别和数据点引用的单元格。

图表设置有三种不同的范围：

- 系列级别设置，例如[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)，为单个系列中的所有点提供默认外观。
- 数据点级别设置，例如[ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)，会覆盖系列的外观，仅针对单个点。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置诸如重叠或间隙宽度等选项时，可通过[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup)访问该组。

当未设置显式的点或系列填充时，图表样式和主题决定自动外观。当系列和点的格式同时存在时，点的格式优先适用于该点。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **使用数字文字设置系列值**

当系列值来自应用程序数据或计算且不需要工作表单元格引用时，使用数字文字。 在为每个点的[getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue)结果通过[setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble)赋值之前，先调用带有[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals)的[setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues)。

集合设置控制该系列中所有点值的源类型。每个点值的[getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType)方法报告所选类型；通过集合设置更改它。使用`Worksheet`时，使用[getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell)访问引用的单元格。使用`DoubleLiterals`时，使用[getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble)或`setAsLiteralDouble`直接读取或写入数字。

以下示例创建一个具有默认系列和类别的柱形图，然后为其第一系列的现有点分配计算得到的 10、20 等数值。它保存演示文稿，重新打开，并打印存储的数值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

点值源类型与[ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType)分开，后者标识图表的内部或外部工作簿配置。使用数字文字本身并不会移除嵌入的工作簿。在本例中，工作簿仍用于类别标签、系列名称以及其他系列。查看[图表工作簿](/slides/zh/python-java/chart-workbook/)以了解工作簿管理。

对于散点图和气泡图，使用[setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues)和[setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues)选择[getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue)和[getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue)的源。气泡图还使用[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes)为[getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize)选择源。在为相应的值分配数字之前，将每个适用的源设置为`DoubleLiterals`，并通过该值的`setAsLiteralDouble`方法写入。

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap)报告 2D 图表中条形或柱形的重叠程度，范围从 -100% 到 100%。它是父系列组上设置的只读投影。使用[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap)可更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

以下示例为包含第一系列的组设置重叠：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

使用[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)为整个系列设置默认填充。如果点已经具有显式填充，其[ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)设置会覆盖该点的系列填充。

以下示例为第一系列应用纯蓝色填充：

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

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格 B1 位于第0行第1列，包含第一系列的名称。下面示例中的命名变量明确了该结构：

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

您也可以更新由[ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName)已经引用的单元格。此方法避免了对现有图表中行列位置的假设：

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

### **从多个单元格创建带名称的系列**

当产品名称和报告期间分别存放在不同工作簿单元格时，复合系列名称非常有用。例如，您可以将 B1 中的 `Product A` 与 C1 中的 `2026` 合并为一个系列名称，同时保持两部分都链接到各自的源单元格。

使用[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection)检索名称范围，然后将该集合传递给[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add)。`skipHiddenCells` 参数决定是否包括隐藏单元格：`True` 排除，`False` 包含。此示例使用 `False` 包含名称范围内的所有单元格。

以下示例创建一个包含一个系列和两个数据点的演示文稿。单元格 B1:C1 仅提供系列名称；A2:A3 提供类别标签，B2:B3 提供数值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # 这两个单元格提供系列名称。
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # 单独的单元格提供类别和数值数据点。
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

生成的系列名称为 `Product A 2026`，两单元格值之间有空格。图例将其显示为同一列的单条目。下图展示了结果：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色，并不会分配新的填充。

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

具体颜色取决于图表样式和主题。

## **为图表系列设置反转填充颜色**

对于条形、柱形和气泡系列，使用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative)可以在负值时显示不同的填充。将常规系列填充设为实色，启用反转，并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)为负值指定颜色。负数在工作簿中保持不变，仅改变其显示颜色。

以下示例用一个系列替换默认图表数据。工作表第0行包含系列名称，第0列包含类别名称，第1列包含数值：

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

您也可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点启用反转。下例中，系列禁用反转，仅为选定点启用，并为该点分配负值，以便效果可见：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为 `None`。对于柱形图，绘制值可通过[ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue)获取。数据点仍保留在相同的类别位置，但图表会根据空值设置将其视为空白。

以下示例仅清除第一系列的第二个点：

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

散点图使用单独的 X 和 Y 单元格，气泡图还使用大小单元格。仅清除表示要删除的数值的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会移除集合中的所有数据点。

## **控制空单元格的显示方式**

隐藏的包含数值的单元格与空单元格是不同的情况。要包含或排除隐藏行列中的数据，请参见[Include Data from Hidden Rows and Columns](/slides/zh/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含 `0` 的单元格表示已知的数值。调用[ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue)并传入 `None` 可使单元格为空。数值零始终保持为零，不受空单元格设置的影响。

使用[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs)选择图表如何显示空单元格。该设置适用于整个图表，会改变空白的绘制方式，但不会用零或插值填充空工作簿单元格。

以下自包含示例创建一个包含一系列的折线图，清除第 3 天的值，并使用每种模式分别保存同一图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)使用工作表 0，列 0 为类别标签，列 1 为数值；第 0 行保存系列名称。最终数据为 `10, 20, empty, 30, 40`。

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

    # 保持第3天真正为空，同时保留其类别和数据点。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每个输出文件在保存前会记录对应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 和 `empty_cells_Span.pptx`。若只需一种版本，请在保存演示文稿前设置所需模式并仅保存一次，而不是遍历所有模式。

下图比较了三个文件中的相同数据。第 3 天在工作簿中始终为空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可见效果取决于图表类型。折线图便于比较三种模式。条形和柱形图没有线条可在缺失类别之间连接，因此 `Span` 无法产生上图所示的连接段；缺失的柱子和零高度柱子看起来也可能相似。同理，仅使用标记的散点图也没有连接线。不要期望每种图表类型都能得到三种截然不同的结果；请检查您使用的图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，以条形或柱形宽度的百分比表示。与重叠类似，它属于父系列组而非单个系列。对组调用一次[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)即可。数值越大，簇之间的间距越宽；数值越小，簇越密集。

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

## **FAQ**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并不全部拥有相同的数值结构或设置。例如，类别图使用类别和数值，散点图使用 X 和 Y 数值，气泡图还会添加气泡大小。请使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表是否包含默认数据？**

是的。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载创建不含默认数据的图表。

**图表对象如何与工作簿单元格关联？**

系列名称、类别标签和数据点数值引用[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，请保持类别行和系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整条系列？**

将相关的值单元格设为 `None`，以保留点的类别位置为空点。仅在希望删除该系列所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除了类别，请更新所有系列，使它们的数值仍与类别集合保持对齐。

**空点如何显示？**

结果取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs)配置的值。受支持的图表可以将空白显示为间隙、零值或连接相邻点。请选择与演示文稿中缺失数据意义相符的设置。有关完整示例和视觉比较，请参见[控制空单元格的显示方式](#control-the-display-of-empty-cells)。

**负值如何格式化？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative)并设置通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)返回的颜色。您可以使用[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点覆盖此行为。这些方法影响格式，而不是存储的数值。

**当系列和点同时被格式化时，哪种格式生效？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不属于点级别的格式覆盖。

**图表可以包含多少系列有上限吗？**

Aspose.Slides 并未设置单独的固定系列计数上限。实际限制取决于演示文件的约束、可用内存、渲染时间以及图表的可读性。

**当列之间太靠近或太远时应如何调整？**

对相应的父系列组调用[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大值可扩大簇之间的间距，减小值则使簇更紧凑。