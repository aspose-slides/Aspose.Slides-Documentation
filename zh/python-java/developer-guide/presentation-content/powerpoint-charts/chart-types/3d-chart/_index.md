---
title: 使用 Python 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/python-java/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中创建 3D 图表。通过 Python 示例调整旋转、 高度比例、 图表深度以及系列之间的间距。"
---
## **概述**

Aspose.Slides for Python via Java 允许您通过 [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) 方法自定义 3D 图表的视图。本文演示如何调整旋转、 高度比例、 深度、 直角坐标轴以及系列之间的间距，然后将演示文稿保存为 PPTX 格式。

## **设置 3D 图表的旋转和深度**

以下示例创建一个 [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 并使用 [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) 在其第一张幻灯片上添加一个堆叠的 3D 柱形图。它用两个系列（每个系列包含三个值）替换默认的系列和类别。工作表索引 `0` 标识图表的第一个数据工作表；第 `0` 行保存系列名称，第 `0` 列保存类别标签。

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) 和 [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) 方法分别将图表的旋转设置为 40 度和 270 度。[setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) 将深度设置为宽度的 150%，而 [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) 启用直角坐标轴而非透视。生成的演示文稿包含了这些 3D 视图设置的图表。

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

## **调整 3D 图表的高度比例**

使用 [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) 将 3D 图表的高度设为宽度的百分比。这样可以在不改变幻灯片上图表对象大小的情况下调整 3D 场景的比例。

下面的示例创建一个带有默认数据（三个系列和四个类别）的 [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 图表。它分别以 50%、100% 和 200% 的高度比例保存三个演示文稿。图表的位置、宽度和高度保持不变。数据、旋转、深度、系列间距和格式在所有文件中完全相同，唯一变化的是高度百分比。

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

以下图像展示了等效 .NET 示例中相同高度设置的效果，图像由 Microsoft PowerPoint 导出。较小的百分比会产生更平坦的场景，较大的百分比会在同一图表对象内产生更高的场景。PowerPoint 可能会相应调整坐标轴刻度间隔和标签位置以适配场景。

| 高度: 50% | 高度: 100% | 高度: 200% |
| --- | --- | --- |
| ![高度设置为宽度 50% 的 3D 柱形图](height_percent_50.png) | ![高度设置为宽度 100% 的 3D 柱形图](height_percent_100.png) | ![高度设置为宽度 200% 的 3D 柱形图](height_percent_200.png) |

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D 场景的高度占宽度的百分比。 |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | 幻灯片上图表对象的高度（单位：磅）。 |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D 场景的深度占宽度的百分比。 |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比，控制系列在深度轴上的间距。 |

此高度设置影响 3D 柱形图和条形图（包括圆柱、圆锥和金字塔变体），以及 3D 折线图、面积图、饼图和曲面图。上面的比较使用了已验证的 `Column3D` 类型。该设置不会改变 2D `ClusteredColumn` 图表或 `BubbleWith3D` 图表的外观；这些名称是 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类的成员。有关其他图表外观设置，请参阅 [Chart Formatting](/slides/zh/python-java/chart-formatting/)。

## **调整系列之间的间隙**

使用 [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) 控制 3D 图表中数据系列在深度轴上的距离，取值为标记宽度的百分比。取值范围为 **0 到 500**（含），`0` 表示取消间隙，值越大间距越宽。固定图表深度时，增大间隙会使标记在深度轴上显得更细。

通过 [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) 访问所在组。该设置会应用于组内的所有系列，而不仅仅是用于访问的那个系列。[ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) 返回深度间隙并反映父组的设置。

此设置影响 3D 柱形图和条形图（包括圆柱、圆锥和金字塔变体），以及 3D 折线图和面积图。外观取决于系列是按深度排列、聚集还是堆叠。要直观比较不同系列之间的间隙，请使用来自 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类的 `ChartType.Column3D`。

这些方法控制图表的不同方面：

| 方法 | 作用 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | 按标记宽度的百分比，控制系列在深度轴上的间距。 |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | 按柱/条宽度的百分比，控制相邻柱或条簇之间的间距。 |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 整体图表深度占宽度的百分比。 |

以下示例使用默认图表数据（包含三个系列和四个类别），保存两个演示文稿，数据、旋转、间隙宽度和图表深度保持相同，仅更改间隙深度。

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

以下图像展示了等效 .NET 示例中相同间隙深度设置的效果，图像由 Microsoft PowerPoint 导出。

| 间隙深度: 0% | 间隙深度: 500% |
| --- | --- |
| ![深度轴上系列之间没有间隙的 3D 柱形图](gap_depth_0.png) | ![深度轴上系列之间存在 500% 间隙的 3D 柱形图](gap_depth_500.png) |

## **更改 3D 系列类型和条形形状**

在聚集柱形圆柱图中，第一系列的条形默认是圆柱形。示例在每次更改前后打印 [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) 和 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) 返回的整数值。下表给出对应的常量名称。

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

| 对第一系列的更改 | 系列类型 | 条形形状 |
| --- | --- | --- |
| 创建图表 | `ClusteredCylinder` | `Cylinder` |
| 将系列类型设置为 `ClusteredCone` | `ClusteredCone` | `Cone` |
| 将条形形状设置为 `Box` | `ClusteredColumn3D` | `Box` |

将形状设置为 `Box` 同时会将系列类型改为 `ClusteredColumn3D`。如果代码中根据系列类型进行分支，请在更改形状后再次调用 `series.getType()`；在赋值前缓存的值仍会指向 `ClusteredCone` 分支。

![PowerPoint 对比图，展示左至右第一系列分别为圆柱、圆锥和矩形柱形](series-shapes.png)

## **常见问题**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 类公开的相关 3D 类型。欲获取完整、最新的列表，请查看所安装版本 API 参考中的 [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) 成员。

**我可以获取 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以使用 [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) 将图表导出为图像，或使用 [render the entire slide](/slides/zh/python-java/convert-powerpoint-to-png/) 将整张幻灯片渲染为 PNG、JPEG 等格式。这在需要光栅预览或将图表嵌入文档、仪表板或网页而不依赖 PowerPoint 时非常实用。

**构建和渲染大型 3D 图表的性能如何？**

性能受数据量和视觉复杂度影响。为获得最佳效果，请尽量减少 3D 效果的使用，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将输出分辨率和尺寸设定为符合目标显示或打印需求的适当大小。