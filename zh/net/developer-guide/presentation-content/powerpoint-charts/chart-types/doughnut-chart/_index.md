---
title: 环形图
type: docs
weight: 30
url: /zh/net/doughnut-chart/
keywords: "环形图, 中心空隙, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中指定 PowerPoint 演示文稿中环形图的中心空隙"
---

## **在环形图中指定中心空隙**
为了指定环形图中孔的大小。请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
- 在幻灯片上添加环形图。
- 指定环形图中孔的大小。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了环形图中孔的大小。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// 将演示文稿写入磁盘
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```