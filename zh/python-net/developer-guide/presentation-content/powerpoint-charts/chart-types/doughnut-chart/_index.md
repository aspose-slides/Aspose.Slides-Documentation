---
title: 饼图
type: docs
weight: 30
url: /zh/python-net/doughnut-chart/
keywords: "饼图, 中心间隙, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 的 PowerPoint 演示文稿中指定饼图的中心间隙"
---

## **在饼图中指定中心间隙**
为了指定饼图中孔的大小，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
- 在幻灯片上添加饼图。
- 指定饼图中孔的大小。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了饼图中孔的大小。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # 将演示文稿写入磁盘
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```