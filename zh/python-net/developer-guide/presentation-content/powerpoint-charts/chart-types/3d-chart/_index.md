---
title: 使用 Python 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/python-net/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中创建 3D 图表。通过 Python 示例调整旋转、高度比例、图表深度和系列之间的间距。"
---
## **概述**

Aspose.Slides for Python via .NET 允许您通过 [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) 属性自定义 3D 图表的视图。本文演示如何调整旋转、高度比例、深度、直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

下面的示例创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 并使用 [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) 在其首张幻灯片上添加一个堆叠的 3D 柱形图。它用包含三个值的两个系列替换了默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) 和 [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) 属性分别将图表的旋转设置为 40 度和 270 度。[depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) 将其深度设置为宽度的 150%，而 [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) 则启用直角坐标轴而非透视。最终的演示文稿包含了具有这些 3D 视图设置的填充图表。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **对 3D 图表表面应用图片填充**

您可以分别为 3D 图表的 [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/)、[back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) 和 [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) 填充。将表面的 [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设置为 `PICTURE` 并分配图像。要在表面上仅放置一份图像并填满整个表面，请同时将 [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) 和表面的 [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) 设置为 `STRETCH`。

将 [arrow.png](arrow.png) 保存到工作目录。示例旋转图表并提高垂直轴的最大值，以便在柱形之间可以看到地板。它将幻灯片克隆两次，然后在每张幻灯片的不同表面上应用箭头。三个图表共享相同的数据、视角和背景。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint 将三张幻灯片显示如下。

| 侧墙 | 背墙 | 地板 |
| --- | --- | --- |
| ![沿侧墙指向图表的箭头](side-wall.png) | ![横向指向背墙的箭头](back-wall.png) | ![横向指向柱之间地板的箭头](floor.png) |

## **调整 3D 图表的高度比例**

使用 [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) 将 3D 图表的高度设置为其宽度的百分比。此操作会在不改变幻灯片上图表对象大小的前提下，修改 3D 场景的比例。

下面的示例创建一个默认数据的 [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 图表：三系列、四类别。它分别以 50%、100% 和 200% 的高度比例保存三个演示文稿。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中完全相同，唯一变化的是高度百分比。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

以下图片使用 Microsoft PowerPoint 从生成的演示文稿中导出。较小的百分比会产生更平坦的场景，而更大的百分比会在同一图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适应场景。

| 高度：50% | 高度：100% | 高度：200% |
| --- | --- | --- |
| ![高度设为宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设为宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设为宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些属性控制图表的不同方面：

| 属性 | 作用 |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D 场景的高度占宽度的百分比。 |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | 幻灯片上图表对象的高度（单位：磅）。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D 场景的深度占宽度的百分比。 |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 沿深度轴的系列间距，占标记宽度的百分比。 |

高度设置影响 3D 柱形和条形图（包括圆柱、圆锥和金字塔变体），以及 3D 折线、面积、饼图和曲面图。上表使用经过验证的 `COLUMN_3D` 类型。此设置不会改变 2D `CLUSTERED_COLUMN` 图表或 `BUBBLE_WITH_3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/python-net/chart-formatting/)。

## **调整系列之间的间距**

使用 [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) 可控制 3D 图表中数据系列沿深度轴的间距，表达为标记宽度的百分比。取值范围为 **0 到 500**（含）：`0` 移除间距，较大的值会增加间距。对固定的图表深度来说，增大间距会使标记在深度轴上变得更细。

通过 [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) 访问所属组。此设置对该组中的所有系列生效，而不仅仅是用于访问它的系列。[ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) 为只读属性，反映父组的设置。

此设置影响 3D 柱形和条形图（包括其圆柱、圆锥和金字塔变体），以及 3D 折线和面积图。外观取决于系列是沿深度排列、聚集还是堆叠。若要直观比较不同系列之间的间距，请使用 [ChartType.COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)。

这些属性控制图表的不同方面：

| 属性 | 作用 |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | 沿深度轴的系列间距，占标记宽度的百分比。 |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | 相邻柱或条形簇之间的间距，占柱或条形宽度的百分比。 |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 整体图表深度，占图表宽度的百分比。 |

下面的自包含示例使用默认图表数据（包含三系列和四类别）。它保存两个演示文稿，数据、旋转、间距宽度和图表深度相同，仅更改了间距深度。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

以下图片使用 Microsoft PowerPoint 从生成的演示文稿中导出。

| 间距深度：0% | 间距深度：500% |
| --- | --- |
| ![沿深度轴系列之间无间距的 3D 柱形图](gap_depth_0.png) | ![沿深度轴系列之间间距为 500% 的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚集的圆柱图中，第一系列以圆柱条形开始。示例在每次更改前后读取 [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) 和 [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/)。

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| 对第一系列的更改 | `type` | `bar_3d_shape` |
| --- | --- | --- |
| 创建图表 | `CLUSTERED_CYLINDER` | `CYLINDER` |
| 将 `type` 设置为 `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| 将 `bar_3d_shape` 设置为 `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

将形状设为 `BOX` 也会把系列类型更改为 `CLUSTERED_COLUMN_3D`。如果您的代码根据系列类型分支，请在更改形状后读取 `series.type`。在赋值前缓存的值仍会选择 `CLUSTERED_CONE` 分支。

![PowerPoint 对比图，左至右显示第一系列分别为圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。要获取精确、最新的列表，请查看已安装版本 API 参考中的 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 成员。

**我能获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 将图表导出为图像，或 [render the entire slide](/slides/zh/python-net/convert-powerpoint-to-png/) 为 PNG、JPEG 等格式。这在需要光栅预览或将图表嵌入文档、仪表盘或网页而不依赖 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能受数据量和视觉复杂度影响。为获得最佳效果，请尽量减少 3D 效果的使用，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出尺寸（分辨率和尺寸）设定为匹配目标显示或打印需求。