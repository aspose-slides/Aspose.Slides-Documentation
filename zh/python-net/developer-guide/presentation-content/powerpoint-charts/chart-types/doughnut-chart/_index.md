---
title: 使用 Python 在演示文稿中自定义环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/python-net/doughnut-chart/
keywords:
- 环形图
- 中心空隙
- 孔径大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 创建和自定义环形图，支持 PowerPoint 和 OpenDocument 格式的动态演示文稿。"
---

## **指定环形图的中心空隙**
为了指定环形图中孔的大小，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类。
- 在幻灯片上添加环形图。
- 指定环形图中孔的大小。
- 将演示文稿写入磁盘。

在下面的示例中，我们已设置环形图中孔的大小。

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Create an instance of Presentation class
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Write presentation to disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我可以创建具有多个环的多层环形图吗？**

是的。向单个环形图添加多个系列——每个系列都会成为一个单独的环。环的顺序由集合中系列的顺序决定。

**是否支持“爆炸”环形图（分离切片）？**

是的。Aspose.Slides 提供了 Exploded Doughnut [chart type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)以及数据点的爆炸属性；您可以分离单个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一种形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 或将图表导出为 [SVG image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)。