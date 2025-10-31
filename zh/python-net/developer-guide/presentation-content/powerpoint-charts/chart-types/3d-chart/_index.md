---
title: 用 Python 在演示文稿中自定义 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/python-net/3d-chart/
keywords:
- 3d 图表
- 旋转
- 深度
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 创建和自定义 3-D 图表，支持 PPT、PPTX 和 ODP 文件——立即提升您的演示效果。"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for Python via .NET 提供了简便的 API 来设置这些属性。下面的示例将帮助您设置 X、Y 旋转、**DepthPercents** 等不同属性。示例代码演示了上述属性的设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加带默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
            
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 添加带默认数据的图表
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # 设置图表数据表的索引
    defaultWorksheetIndex = 0

    # 获取图表数据工作表
    fact = chart.chart_data.chart_data_workbook

    # 添加系列
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # 添加类别
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # 设置 Rotation3D 属性
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 获取第二个图表系列
    series = chart.chart_data.series[1]

    # 现在填充系列数据
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 设置 OverLap 值
    series.parent_series_group.overlap = 100         

    # 将演示文稿写入磁盘
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**哪些图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持列形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 枚举公开的相关 3D 类型。要获取准确、最新的列表，请查阅您所使用版本的 API 参考中的 [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) 成员。

**我可以获得 3D 图表的光栅图像用于报告或网页吗？**

可以。您可以通过 [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) 将图表导出为图像，或将整个幻灯片[渲染为 PNG 或 JPEG 等格式](/slides/zh/python-net/convert-powerpoint-to-png/)。这在需要像素级预览或将图表嵌入文档、仪表板或网页而不依赖 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量减少 3D 效果，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将输出分辨率和尺寸设置为适合目标显示或打印需求的大小。