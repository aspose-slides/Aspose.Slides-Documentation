---
title: 在 .NET 中自定义演示文稿的甜甜圈图
linktitle: 甜甜圈图
type: docs
weight: 30
url: /zh/net/doughnut-chart/
keywords:
- 甜甜圈图
- 中心间隙
- 孔径
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中创建和自定义甜甜圈图，支持 PowerPoint 格式的动态演示文稿。"
---

## **指定甜甜圈图的中心间隙**
为了指定甜甜圈图中孔的大小，请按以下步骤操作：

- 实例化[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类。
- 在幻灯片上添加甜甜圈图。
- 指定甜甜圈图中孔的大小。
- 将演示文稿写入磁盘。

在下面的示例中，我们已设置甜甜圈图中孔的大小。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// 将演示文稿写入磁盘
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**我可以创建具有多个环的多层甜甜圈吗？**

可以。向单个甜甜圈图添加多个系列——每个系列都会成为一个单独的环。环的顺序由系列在集合中的顺序决定。

**是否支持“爆炸”甜甜圈（分离切片）？**

支持。存在 Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 并且数据点上有爆炸属性；您可以分离单个切片。

**如何获取甜甜圈图的图像（PNG/SVG）用于报告？**

图表是形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 或导出为 [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)。