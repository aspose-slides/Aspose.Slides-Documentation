---
title: 使用 Python 在演示文稿中自定义环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/python-net/doughnut-chart/
keywords:
- 环形图
- 中心间隙
- 孔径大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中创建和自定义环形图，支持 PowerPoint 和 OpenDocument 格式，实现动态演示文稿。"
---

## **在环形图中指定中心间隙**
为了指定环形图中孔的大小，请按以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
- 在幻灯片上添加环形图。
- 指定环形图中孔的大小。
- 将演示文稿写入磁盘。

下面的示例中，我们已设置环形图中孔的大小。

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

## **FAQ**

**我可以创建具有多层环的多环形图吗？**

可以。向单个环形图添加多个系列——每个系列都会形成一个独立的环。环的顺序由系列在集合中的顺序决定。

**是否支持“爆炸”环形图（分离的切片）？**

可以。存在一个 **Exploded Doughnut**[chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)以及数据点的爆炸属性；您可以分离单个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

环形图是一个形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)或导出为 [SVG image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)。