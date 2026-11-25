---
title: "使用 Python 在演示文稿中自定义 3D 图表"
linktitle: "3D 图表"
type: docs
url: /zh/python-java/3d-chart/
keywords:
- "3D 图表"
- "旋转"
- "深度"
- "PowerPoint"
- "演示文稿"
- "Python"
- "Java"
- "Aspose.Slides"
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 Python 示例调整旋转、 高度比例、 图表深度以及系列间距。"
---
## **概述**

Aspose.Slides for Python via Java 允许您通过 [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) 方法自定义 3D 图表的视图。本文演示如何调整旋转、 高度比例、 深度、 直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

以下示例创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)，并使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用两个包含各三个值的系列替换了默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；行 `0` 保存系列名称，列 `0` 保存类别标签。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) 和 [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) 将其深度设为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) 则启用直角坐标轴而非透视。生成的演示文稿包含具有这些 3D 视图设置的填充图表。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **为 3D 图表表面应用图片填充**

3D 图表有三个表面可独立填充： [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall)、[back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) 和 [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor)。将表面的 [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 设置为 `Picture` 并分配图像。将 [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) 和表面的 [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) 都设为 `Stretch`，即可让图像的单个副本跨越整个表面。

将 [arrow.png](arrow.png) 保存到工作目录。示例旋转图表并提升垂直轴的最大值，以便在柱形之间看到地面。随后它将幻灯片克隆两次，并在每张幻灯片上将箭头应用到不同的表面。所有三个图表保持相同的数据、视角和背景。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint 显示如下三张幻灯片。

| 侧壁 | 背壁 | 地面 |
| --- | --- | --- |
| ![箭头指向沿侧壁的图表](side-wall.png) | ![箭头指向横跨背壁向右](back-wall.png) | ![箭头指向横跨柱子之间的地面向右](floor.png) |

## **调整 3D 图表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) 将 3D 图表的高度设为其宽度的百分比。这样可以在不改变幻灯片上图表对象大小的情况下改变 3D 场景的比例。

下面的示例创建一个带有默认数据的 [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 图表：三个系列和四个类别。它分别以 50%、100% 和 200% 的高度比例保存三个演示文稿。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中都相同，唯一变化的是高度百分比。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的图像展示了相同高度设置在等效 .NET 示例中的效果，图像均由 Microsoft PowerPoint 导出。较小的百分比会产生更平的场景，较大的百分比会在同一图表对象内产生更高的场景。PowerPoint 可能还会调整坐标轴刻度间隔和标签位置以适配场景。

| 高度: 50% | 高度: 100% | 高度: 200% |
| --- | --- | --- |
| ![3D 柱形图高度设为宽度的 50%](height_percent_50.png) | ![3D 柱形图高度设为宽度的 100%](height_percent_100.png) | ![3D 柱形图高度设为宽度的 200%](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 场景的高度占宽度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | 幻灯片上图表对象的高度（以点为单位）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 场景的深度占宽度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比表示的系列在深度轴上的间距。 |

高度设置影响 3D 柱形和条形图，包括圆柱、圆锥和金字塔变体，以及 3D 折线、面积、饼图和曲面图。上述比较使用经验证的 `Column3D` 类型。此设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/python-java/chart-formatting/)。

## **调整系列之间的间隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) 控制 3D 图表中数据系列在深度轴上的距离，以标记宽度的百分比表示。取值范围为 **0 到 500**（含），`0` 表示没有间隙，数值越大间距越大。在固定的图表深度下，增大间隙会使标记在深度轴上变得更细。

通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问该组。此设置适用于该组中的所有系列，而不仅仅是用于访问它的系列。 [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形和条形图，包括其圆柱、圆锥和金字塔变体，以及 3D 折线和面积图。外观取决于系列是按深度、聚类还是堆叠排列。若要清晰比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类的 `ChartType.Column3D`。

这些方法控制图表的不同方面：

| 方法 | 效果 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比表示的系列在深度轴上的间距。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 按柱或条宽度的百分比表示的相邻柱或条簇之间的间距。 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 整体图表深度占图表宽度的百分比。 |

下面的完整示例使用默认图表数据（包含三个系列和四个类别），并保存两个演示文稿，数据、旋转、间隙宽度和图表深度相同，仅间隙深度不同。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的图像展示了相同间隙深度设置在等效 .NET 示例中的效果，图像均由 Microsoft PowerPoint 导出。

| 间隙深度: 0% | 间隙深度: 500% |
| --- | --- |
| ![3D 柱形图在深度轴上没有系列间隙](gap_depth_0.png) | ![3D 柱形图在深度轴上存在 500% 间隙](gap_depth_500.png) |

## **更改 3D 系列类型和柱形外观**

在聚类圆柱图中，第一系列默认使用圆柱形柱。示例在每次更改前后打印由 [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) 和 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) 返回的整数值。表格给出了对应的常量名称。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 对第一系列的更改 | 系列类型 | 柱形外观 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将柱形外观设为 `Box` | `ClusteredColumn3D` | `Box` |

将外观设为 `Box` 也会将系列类型更改为 `ClusteredColumn3D`。如果代码根据系列类型分支，请在更改外观后调用 `series.getType()`。在赋值前缓存的值仍会选择 `ClusteredCone` 分支。

![PowerPoint 比较显示左至右的第一系列分别为圆柱、圆锥和矩形柱](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类公开的相关 3D 类型。欲获取准确、最新的列表，请在已安装版本的 API 参考中查阅 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) 将图表导出为图像，或将整个幻灯片 [渲染为 PNG 等格式](/slides/zh/python-java/convert-powerpoint-to-png/)。这在需要光栅预览或将图表嵌入文档、仪表盘或网页且不依赖 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出设为适合目标显示或打印需求的分辨率和尺寸。