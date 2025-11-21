---
title: 图表
type: docs
weight: 60
url: /zh/net/examples/elements/chart/
keywords:
- 图表示例
- 添加图表
- 访问图表
- 删除图表
- 更新图表
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 C# 和 Aspose.Slides 创建和自定义图表：添加数据、设置系列、坐标轴和标签的格式、更改图表类型并导出——支持 PPT、PPTX 和 ODP。"
---

示例演示如何添加、访问、删除和更新不同类型的图表，使用 **Aspose.Slides for .NET**。下面的代码片段展示了基本的图表操作。

## 添加图表

此方法向第一张幻灯片添加一个简单的面积图。
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // 向第一张幻灯片添加一个简单的柱形图
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## 访问图表

创建图表后，您可以通过形状集合检索它。
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // 访问幻灯片上的第一个图表
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## 删除图表

以下代码从幻灯片中删除图表。
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // 删除图表
    slide.Shapes.Remove(chart);
}
```


## 更新图表数据

您可以更改图表属性，例如标题。
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // 更改图表标题
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
