---
title: 3D 图表
type: docs
url: /zh/python-net/3d-chart/
keywords: "3d 图表, rotationX, rotationY, depthpercent, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中为 PowerPoint 演示文稿设置 3D 图表的 rotationX、rotationY 和 depthpercents"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for Python via .NET 提供了一个简单的 API 来设置这些属性。以下文章将帮助您设置不同的属性，如 X、Y 旋转、**DepthPercents**等。示例代码应用于设置上述属性。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建一个 Presentation 类的实例
with slides.Presentation() as presentation:
            
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 添加带有默认数据的图表
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # 设置图表数据工作表的索引
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

    # 设置 Rotation3D 属性
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # 获取第二个系列
    series = chart.chart_data.series[1]

    # 填充系列数据
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # 设置重叠值
    series.parent_series_group.overlap = 100         

    # 将演示文稿写入磁盘
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```