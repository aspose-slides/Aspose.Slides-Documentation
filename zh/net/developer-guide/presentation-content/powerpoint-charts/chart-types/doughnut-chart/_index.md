---
title: 环形图
type: docs
weight: 30
url: /zh/net/doughnut-chart/
keywords: "环形图, 中心间隙, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 演示文稿中使用 C# 或 .NET 指定环形图的中心间隙"
---

## **指定环形图的中心间隙**
为了指定环形图中孔的大小，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
- 在幻灯片上添加环形图。
- 指定环形图中孔的大小。
- 将演示文稿写入磁盘。

在下面的示例中，我们已经设置了环形图中孔的大小。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// 将演示文稿写入磁盘
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **常见问题**

**我可以创建具有多个环的多层环形图吗？**

是的。向单个环形图添加多个系列——每个系列都会成为一个单独的环。环的顺序由系列在集合中的顺序决定。

**是否支持“爆炸”环形图（分离切片）？**

是的。存在一种 Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)，并且数据点上有 explosion 属性；您可以分离各个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一个形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)，或将图表导出为 [SVG image](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)。