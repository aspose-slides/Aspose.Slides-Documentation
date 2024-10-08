---
title: 导出图表
type: docs
weight: 90
url: /zh/net/export-chart/
keywords:
- 图表
- 图表图像
- 提取图表图像
- PowerPoint
- 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中从 PowerPoint 演示文稿获取图表图像"
---

## **获取图表图像**
Aspose.Slides for .NET 提供了提取特定图表图像的支持。以下是示例代码。

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```