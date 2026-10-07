---
title: 管理 Python 中演示文稿的图表数据系列
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
description: "了解如何在使用 Aspose.Slides for Python via Java 的演示文稿中管理图表系列、数据点、工作簿单元格、格式设置、重叠、间隙宽度和负值。"
---
## **概述**

图表将其绘制的数据存储在图表数据工作簿中。一个[ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/)表示一组相关值，系列中的每个[ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/)对应一个或多个工作簿单元格。[ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/)对象提供系列共享的标签或分组值。系列名称、类别和点值因此连接到[ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/)对象，而不是仅作为显示文本存储。

对于典型的类别图，默认工作簿使用第0行存放系列名称，第0列存放类别名称，其余单元格存放系列值。传递给[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell)的工作表、行和列索引采用零基计数。这种布局在创建带有默认数据的图表时很有用，但不要假设每个已有图表都使用它。对于已加载的演示文稿，在更改工作簿值之前，请检查系列、类别和数据点所引用的单元格。

图表设置有三种不同的作用域：

- 系列级别设置，例如[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)，为该系列中的所有点提供默认外观。
- 数据点级别设置，例如[ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)，覆盖该点的系列外观。
- 组设置适用于属于同一[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/)的兼容系列。当需要设置重叠或间隙宽度等选项时，通过[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup)访问该组。

当未显式设置点或系列填充时，图表样式和主题决定自动外观。当同时存在系列和点的格式设置时，点的格式设置优先于该点的系列格式。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap)报告2D图表中条形或柱形的重叠程度，范围为-100%到100%。它是对父系列组中设置的只读投影。使用[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap)可以更新该组中所有兼容系列。此选项适用于显示分组条形或柱形的图表类型；对组合图中不相关的系列组没有影响。

下面的示例为包含第一个系列的组设置重叠：

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

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

使用[ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat)设置整个系列的默认填充。如果某个点已经具有显式填充，其[ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat)设置会覆盖该点的系列填充。

下面的示例为第一个系列应用纯蓝色填充：

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

系列名称存储在图表数据工作簿中，通常显示在图例中。在为聚簇柱形图创建的默认工作簿中，单元格B1位于第0行第1列，包含第一个系列的名称。下面示例中的命名变量明确了该结构：

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

您也可以更新[ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName)已引用的单元格。这种方法避免了对现有图表中特定行列的假设：

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

### **创建由多个单元格组成的系列名称**

当产品名称和报告期间分别存储在不同工作簿单元格中时，复合系列名称非常有用。例如，您可以将B1中的`Product A`与C1中的`2026`组合为单个系列名称，同时保持两部分与其源单元格的链接。

使用[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection)检索名称范围，然后将该集合传递给[ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add)。`skipHiddenCells`参数决定是否包含隐藏单元格：`True`排除，`False`包含。本示例使用`False`来包含名称范围内的所有单元格。

下面的示例创建一个包含一个系列和两个数据点的演示文稿。单元格B1:C1仅提供系列名称；A2:A3提供类别标签，B2:B3提供数值。

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

生成的系列名称为`Product A 2026`，两单元格值之间有一个空格。图例将其显示为两个列的单一条目。下图展示了结果：

![带有北部和南部值以及复合系列名称 Product A 2026 的柱形图](composite_series_name.png)

## **获取自动系列填充颜色**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor)返回根据系列索引和图表样式计算的颜色。这是系列填充未显式定义时使用的颜色。调用该方法仅读取计算出的颜色，不会分配新的填充。

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

## **为图表系列设置负值反转填充颜色**

对于条形、柱形和气泡系列，[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative)可以在负值时使用不同的填充。将常规系列填充设为实色，启用反转，并通过[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)分配负值颜色。负数在工作簿中保持不变，仅改变显示颜色。

下面的示例用一个系列替换默认图表数据。工作表第0行包含系列名称，第0列包含类别名称，第1列包含数值：

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

您可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点启用反转。下例中，系列的反转被禁用，仅为选中的点启用，并为该点分配负值以便显示效果：

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

要使某一点为空而不删除其他点，请将其对应的工作簿单元格设为`None`。对于柱形图，绘制的数值可通过[ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue)获取。数据点仍保留在同一类别位置，但图表会根据空值设置将其视为空白。

下面的示例仅清除第一个系列的第二个点：

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

散点图使用单独的X和Y单元格，气泡图还使用大小单元格。仅清除表示您想移除的值的单元格。不要在想保留其他点时调用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)，因为该方法会移除该系列的所有数据点。

## **控制空单元格的显示方式**

包含值的隐藏单元格与空单元格是不同的情况。要包含或排除隐藏工作表行列中的数据，请参阅[Include Data from Hidden Rows and Columns](/slides/zh/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空工作簿单元格表示缺失数据；包含`0`的单元格表示已知数值。调用[ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue)并传入`None`可使单元格为空。数值零始终保持为零，且不受空单元格设置影响。

使用[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs)选择图表如何显示空单元格。此设置适用于整个图表，会改变空白的绘制方式，而不会用零或插值填充空工作簿单元格。

下面的完整示例创建一个包含一个系列的折线图，清除第3天的值，并分别以每种模式保存相同的图表。无需输入文件。[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)使用工作表0，第0列存放类别标签，第1列存放数值；第0行保存系列名称。最终数据为`10, 20, empty, 30, 40`。

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

    # 将第3天真正留空，同时保留其类别和数据点。
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

每个输出文件在保存前存储相应的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`和`empty_cells_Span.pptx`。若只需保存一种版本，只需在保存演示文稿前设定所需模式，而不是遍历所有模式。

下图比较了三种文件中的相同数据。第3天在工作簿中始终为空：

![折线图显示相同数据：Gap 在第3天处断开线段，Zero 将线段降至零，Span 将第2天连接到第4天。](display_blanks_as.png)

可见效果取决于图表类型。折线图能够直观比较三种模式。条形和柱形图没有连线可跨越缺失的类别，因此`Span`无法产生上图所示的连接段；缺失的柱形和零高度柱形也可能看起来相同。类似地，仅有标记的散点图也没有连线。不要期望每种图表类型都产生三种明显不同的结果；请检查所使用图表类型的输出。

## **设置系列间隙宽度**

间隙宽度是相邻条形或柱形簇之间的空间，表示为条形或柱形宽度的百分比。与重叠一样，它属于父系列组而不是单个系列。对组调用一次[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。较大的值会在簇之间创建更多空间，较小的值会使其更密集。

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

## **常见问题解答**

**哪些图表类型支持数据系列？**

所有由[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)枚举表示的图表类型都使用图表数据，但它们的系列并不全部具有相同的值结构或设置。例如，类别图使用类别和数值，散点图使用X和Y值，气泡图则额外使用气泡大小。使用与系列类型匹配的数据点创建方法。重叠和间隙宽度等选项仅适用于兼容的条形或柱形组。

**什么是图表系列组？**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/)包含共享组级绘图设置的兼容系列。组合图可以包含多个组，因此通过某个系列访问的组的更改不一定会影响图表中的所有系列。

**新建的图表会包含默认数据吗？**

会。默认情况下，[ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart)会创建示例系列、类别和数值。您可以编辑这些单元格，或在添加完全自定义的数据集之前清除系列和类别集合。也可以使用重载在创建图表时不生成默认数据。

**图表对象是如何与工作簿单元格关联的？**

系列名称、类别标签和数据点值都引用[ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)中的单元格。更改被引用的单元格会更新相应的图表元素。构建自定义数据时，保持类别行与系列值行对齐，以便每个点绘制在预期的类别下。

**如何只清除一个点而不是整个系列？**

将相应的值单元格设为`None`，即可保留该点的类别位置作为空点。仅在需要删除该系列所有点时才使用[ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear)。如果同时删除了类别，请更新每个系列，使其值仍与类别集合保持对齐。

**空点会如何显示？**

结果取决于图表类型以及通过[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs)配置的值。受支持的图表可以将空白显示为间隙、零值或通过连接相邻点来填补。请选择与演示文稿中缺失数据含义相匹配的设置。完整示例和可视化比较请参见[Control the Display of Empty Cells](#control-the-display-of-empty-cells)。

**负值是如何格式化的？**

对于受支持的条形、柱形和气泡系列，调用[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative)并设置[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor)返回的颜色。您也可以通过[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative)为单个点覆盖此行为。这些方法影响格式，而不改变存储的数值。

**当系列和点都设置了格式时，哪个生效？**

显式的数据点格式在该点上优先。其他点继续使用显式的系列格式，若系列格式未定义，则使用自动的图表样式和主题。组设置（如重叠和间隙宽度）控制布局，不会覆盖点级别的格式。

**图表能够包含的系列数量有限制吗？**

Aspose.Slides 并未设定单独的固定系列计数上限。实际限制受演示文稿文件约束、可用内存、渲染时间以及图表可读性等因素影响。

**当列之间过于靠近或过于分散时该怎么办？**

对相应的父系列组调用[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth)。增大数值可扩大簇之间的间距，减小数值则使簇更紧凑。