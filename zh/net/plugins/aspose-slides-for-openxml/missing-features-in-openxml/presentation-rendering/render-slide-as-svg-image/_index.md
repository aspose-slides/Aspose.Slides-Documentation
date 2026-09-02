---
title: 将幻灯片渲染为 SVG 图像
type: docs
weight: 50
url: /zh/net/render-slide-as-svg-image/
---
SVG——可扩展矢量图形（Scalable Vector Graphics）的缩写，是一种用于渲染二维图像的标准图形类型或格式。SVG 将图像以 XML 中的矢量形式存储，并包含定义其行为或外观的细节。

SVG 是少数能够在以下方面满足极高标准的图像格式：可伸缩性、交互性、性能、可访问性、可编程性等。基于这些原因，它在 Web 开发中被广泛使用。

您可能在以下场景中使用 SVG 文件：

- 当您计划以非常大的尺寸打印演示文稿时。SVG 图像可以无限放大到任意分辨率或尺寸。您可以在不牺牲质量的前提下多次调整 SVG 图像的大小。
- 当您希望在不同的介质或平台上使用幻灯片中的图表和图形时。大多数阅读器都能解析 SVG 文件。
- 当您需要尽可能最小的图像尺寸时。与其他格式的高分辨率等效图像相比，SVG 文件通常更小，尤其是基于位图的格式（JPEG 或 PNG）。

Aspose.Slides for .NET 允许您将演示文稿中的幻灯片导出为 **SVG** 图像。要从任意幻灯片生成 SVG 图像，请执行以下操作：

- 创建 Presentation 类的实例。
- 遍历演示文稿中的所有幻灯片。
- 通过 FileStream 将每张幻灯片写入其独立的 SVG 文件。

{{% alert color="info" %}} 

您可以尝试我们的[免费网络应用](https://products.aspose.app/slides/zh/conversion/ppt-to-svg)，其中实现了 Aspose.Slides for .NET 的 PPT 转 SVG 转换功能。

{{% /alert %}} 

下面的 C# 示例代码演示了如何使用 Aspose.Slides 将 PPT 转换为 SVG：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```