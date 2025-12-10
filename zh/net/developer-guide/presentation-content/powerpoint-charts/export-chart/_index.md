---
title: 在 .NET 中导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/net/export-chart/
keywords:
- 图表
- 图表转图像
- 图表作为图像
- 提取图表图像
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 导出演示文稿图表，支持 PPT 和 PPTX 格式，并将报告流程简化到任何工作流。"
---

## **获取图表图片**
Aspose.Slides for .NET 提供了提取特定图表图像的支持。以下示例展示了如何操作。
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


## **常见问题**

**我可以将图表导出为矢量（SVG）而不是光栅图像吗？**

是的。图表是一种形状，其内容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)保存为 SVG。

**如何在像素级别设置导出图表的精确大小？**

使用允许指定大小或比例的图像渲染重载——库支持使用给定的尺寸/比例渲染对象。

**导出后如果标签和图例中的字体显示不正确，我该怎么办？**

[加载所需字体](/slides/zh/net/custom-font/) 并通过[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) 进行加载，以确保图表渲染保留度量和文本外观。

**导出是否遵循 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），从而保持图表的外观。

**在哪里可以找到除图表图像之外的可用渲染/导出功能？**

请参阅 [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[文档](/slides/zh/net/convert-powerpoint/) 的导出章节，了解输出目标（[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/)、等）以及相关的渲染选项。