---
title: 在 Python 中管理图表系列
linktitle: 图表系列
type: docs
url: /zh/python-net/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间距
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 PowerPoint (PPT/PPTX) 中使用 Python 管理图表系列，提供实用代码示例和最佳实践，以增强数据演示效果。"
---

系列是在图表中绘制的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

通过 [IChartSeriesOverlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/) 属性，您可以指定 2D 图表中条形和柱形应重叠多少（范围：-100 到 100）。此属性应用于父系列组的所有系列：这是适当组属性的投影。因此，此属性是只读的。

使用 `parent_series_group.overlap` 读/写属性设置您首选的 `overlap` 值。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 在幻灯片上添加聚簇柱形图。
1. 访问第一个图表系列。
1. 访问图表系列的 `parent_series_group`，并为系列设置首选的重叠值。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码展示了如何为图表系列设置重叠：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 添加图表
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
    series = chart.chart_data.series
    if series[0].overlap == 0:
        # 设置系列重叠
        series[0].parent_series_group.overlap = -30

    # 将演示文件写入磁盘
    presentation.save("SetChartSeriesOverlap_out.pptx", slides.export.SaveFormat.PPTX)
```

## **更改系列颜色**
Aspose.Slides for Python via .NET 允许您以以下方式更改系列的颜色：

1. 创建 `Presentation` 类的实例。
1. 在幻灯片上添加图表。
1. 访问您要更改颜色的系列。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何更改系列的颜色：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[1]
	
	point.explosion = 30
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **更改系列类别的颜色**
Aspose.Slides for Python via .NET 允许您以以下方式更改系列类别的颜色：

1. 创建 `Presentation` 类的实例。
1. 在幻灯片上添加图表。
1. 访问您要更改颜色的系列类别。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何更改系列类别的颜色：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	point = chart.chart_data.series[0].data_points[0]
	
	point.format.fill.fill_type = slides.FillType.SOLID
	point.format.fill.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **更改系列名称** 

默认情况下，图表的图例名称是每列或每行数据上方单元格的内容。 

在我们的示例中（示例图片）， 

* 列是 *系列 1、系列 2* 和 *系列 3*；
* 行是 *类别 1、类别 2、类别 3* 和 *类别 4*。 

Aspose.Slides for Python via .NET 允许您更新或更改图表数据和图例中的系列名称。 

以下 Python 代码展示了如何在图表数据 `ChartDataWorkbook` 中更改系列名称：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    
    seriesCell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    seriesCell.value = "新名称"
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

以下 Python 代码展示了如何通过 `Series` 更改图例中的系列名称：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    
    series.name.as_cells[0].value = "新名称"

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX) 
```

## **设置图表系列填充颜色**

Aspose.Slides for Python via .NET 允许您以这种方式设置图表系列内部的自动填充颜色：

1. 创建 `Presentation` 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，基于您首选的类型（在下面的示例中，我们使用 `ChartType.CLUSTERED_COLUMN`）。
1. 访问图表系列并将填充颜色设置为自动。
1. 将演示文稿保存为 PPTX 文件。

以下 Python 代码展示了如何为图表系列设置自动填充颜色：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 创建聚簇柱形图
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 50, 600, 400)

    # 设置系列填充格式为自动
    for i in range(len(chart.chart_data.series)):
        chart.chart_data.series[i].get_automatic_series_color()

    # 将演示文件写入磁盘
    presentation.save("AutoFillSeries_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置图表系列反转填充颜色**
Aspose.Slides 允许您以这种方式设置图表系列内部的反转填充颜色：

1. 创建 `Presentation` 类的实例。
1. 根据索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，基于您首选的类型（在下面的示例中，我们使用 `ChartType.CLUSTERED_COLUMN`）。
1. 访问图表系列并将填充颜色设置为反转。
1. 将演示文稿保存为 PPTX 文件。

以下 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # 添加新的系列和类别
    chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "系列 1"), chart.type)
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "类别 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "类别 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "类别 3"))

    # 取第一个图表系列并填充其系列数据。
    series = chart.chart_data.series[0]
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))
    seriesColor = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = seriesColor
    series.inverted_solid_fill_color.color = draw.Color.red
    pres.save("SetInvertFillColorChart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置系列为负值时反转**
Aspose.Slides 允许您通过 `ChartDataPoint.invert_if_negative` 属性进行反转。当使用该属性设置反转时，当数据点的值为负时，它的颜色会被反转。 

以下 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400, True)
	series = chart.chart_data.series
	chart.chart_data.series.clear()

	series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -2))
	series[0].data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series[0].invert_if_negative = False

	series[0].data_points[2].invert_if_negative = True

	pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```

## **清除特定数据点的数据**
Aspose.Slides for Python via .NET 允许您以这种方式清除特定图表系列的 `data_points` 数据：

1. 创建 `Presentation` 类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过索引获取图表的引用。
4. 遍历所有图表 `data_points` 并将 `x_value` 和 `y_value` 设置为 null。
5. 清除特定图表系列的所有 `data_points`。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了该操作：

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "TestChart.pptx") as pres:
    sl = pres.slides[0]
    chart = sl.shapes[0]

    for dataPoint in chart.chart_data.series[0].data_points:
        dataPoint.x_value.as_cell.value = None
        dataPoint.y_value.as_cell.value = None

    chart.chart_data.series[0].data_points.clear()

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", slides.export.SaveFormat.PPTX)
```

## **设置系列间隔宽度**
Aspose.Slides for Python via .NET 允许您通过 **`gap_width`** 属性以这种方式设置系列的间隔宽度：

1. 创建 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 添加带有默认数据的图表。
4. 访问任何图表系列。
5. 设置 `gap_width` 属性。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码展示了如何设置系列的间隔宽度：

```py
# 创建空演示文稿 
with slides.Presentation() as presentation:

    # 访问演示文稿的第一张幻灯片
    slide = presentation.slides[0]

    # 添加带有默认数据的图表
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 0, 0, 500, 500)

    # 设置图表数据表的索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 添加系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.type)

    # 添加类别
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "类别 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "类别 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "类别 3"))

    # 取第二个图表系列
    series = chart.chart_data.series[1]

    # 填充系列数据
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 设置 GapWidth 值
    series.parent_series_group.gap_width = 50

    # 将演示文稿保存到磁盘
    presentation.save("GapWidth_out.pptx", slides.export.SaveFormat.PPTX)
```