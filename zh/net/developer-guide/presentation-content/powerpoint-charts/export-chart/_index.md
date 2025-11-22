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
Aspose.Slides for .NET 提供了提取特定图表图像的支持。以下示例演示。

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

是的。图表是形状，其内容可以使用 [shape-to-SVG 保存方法](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) 保存为 SVG。

**我如何以像素为单位设置导出图表的精确尺寸？**

使用允许指定尺寸或比例的图像渲染重载——库支持按给定的尺寸/比例渲染对象。

**导出后标签和图例中的字体显示不正确，我该怎么办？**

[加载所需的字体](/slides/zh/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)，以确保图表渲染保留度量和文本外观。

**导出是否遵循 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 渲染器遵循演示文稿的格式（主题、样式、填充、效果），因此图表外观得以保留。

**在哪里可以找到除图表图像之外的可用渲染/导出功能？**

查看 [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[文档](/slides/zh/net/convert-powerpoint/) 的导出章节，获取输出目标（[PDF](/slides/zh/net/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/net/convert-powerpoint-to-xps/)、[HTML](/slides/zh/net/convert-powerpoint-to-html/) 等）以及相关渲染选项。