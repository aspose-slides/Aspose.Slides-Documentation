---
title: 圖表
type: docs
weight: 60
url: /zh-hant/net/examples/elements/chart/
keywords:
- 圖表
- 新增圖表
- 存取圖表
- 移除圖表
- 更新圖表
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 精通圖表：建立、格式化、綁定資料，並以 C# 範例將圖表匯出為 PPT、PPTX 與 ODP。"
---
以下示範如何在 **Aspose.Slides for .NET** 中新增、存取、移除和更新不同類型的圖表。以下程式碼片段展示了基本的圖表操作。

## **新增圖表**

此方法會在第一張投影片中新增一個簡單的面積圖表。

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 在第一張投影片新增一個簡單的面積圖表。
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **存取圖表**

建立圖表後，您可以透過圖形集合取得它。

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // 存取投影片上的第一個圖表。
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **移除圖表**

以下程式碼會從投影片中移除圖表。

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // 移除圖表。
    slide.Shapes.Remove(chart);
}
```

## **更新圖表資料**

您可以變更圖表的屬性，例如標題。

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // 變更圖表標題。
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```