---
title: 图表图例
type: docs
url: /python-net/chart-legend/
keywords: "图表图例, 图例字体大小, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "设置 PowerPoint 演示文稿中图表图例的位置和字体大小"
---

## **图例定位**
为了设置图例属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加一个图表。
- 设置图例的属性。
- 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已经为图表图例设置了位置和大小。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建一个 Presentation 类的实例
with slides.Presentation() as presentation:

    # 获取幻灯片的引用
    slide = presentation.slides[0]

    # 在幻灯片上添加一个聚类柱状图
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # 设置图例属性
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # 将演示文稿写入磁盘
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **设置图例的字体大小**
Aspose.Slides for Python via .NET 允许开发人员设置图例的字体大小。请按照以下步骤操作：

- 实例化 `Presentation` 类。
- 创建默认图表。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **设置单个图例的字体大小**
Aspose.Slides for Python via .NET 允许开发人员设置单个图例条目的字体大小。请按照以下步骤操作：

- 实例化 `Presentation` 类。
- 创建默认图表。
- 访问图例条目。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    tf = chart.legend.entries[1].text_format

    tf.portion_format.font_bold = 1
    tf.portion_format.font_height = 20
    tf.portion_format.font_italic = 1
    tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
    tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```