---
title: 图表
type: docs
weight: 60
url: /zh/net/examples/elements/chart/
keywords:
- 图表
- 添加图表
- 访问图表
- 删除图表
- 更新图表
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 精通图表：创建、格式化、绑定数据，并使用 C# 示例将图表导出为 PPT、PPTX 和 ODP。"
---
示例展示了使用 **Aspose.Slides for .NET** 添加、访问、删除和更新不同图表类型。下面的代码片段演示了基本的图表操作。

## **添加图表**

此方法向第一张幻灯片添加一个简单的面积图表。

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 在第一张幻灯片上添加一个简单的面积图表。
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **访问图表**

创建图表后，您可以通过形状集合检索它。

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // 访问幻灯片上的第一个图表。
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **删除图表**

下面的代码从幻灯片中删除图表。

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // 删除图表。
    slide.Shapes.Remove(chart);
}
```

## **更新图表数据**

您可以更改图表属性，例如标题。

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // 更改图表标题。
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```