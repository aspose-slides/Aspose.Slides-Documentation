---
title: 在 .NET 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/net/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿 转 PNG
- 幻灯片 转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精准、自动化的结果。"
---
## **概览**

本文介绍如何使用 Aspose.Slides for .NET 将演示文稿幻灯片转换为 PNG 图像。您可以加载 PPT、PPTX、ODP 等格式的演示文稿，渲染每张幻灯片，并将其保存为单独的 PNG 图像。

下面的示例演示了渲染缩略图、设置缩放因子、指定像素输出尺寸以及选择渐变渲染样式。

## **将 PowerPoint 转换为 PNG**

使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类加载演示文稿，并通过 [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 集合访问其幻灯片。示例使用不带参数的 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 渲染每张幻灯片以创建缩略图。然后调用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 并使用 [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 将每个渲染的幻灯片保存为 PNG 图像。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
无参数的 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 重载以 0.2 的比例进行渲染。例如，尺寸为 720 × 540 点的幻灯片会生成 144 × 108 像素的缩略图。要控制输出尺寸，请使用带有缩放因子或显式图像大小的重载，如下所示。
{{% /alert %}}

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

将水平和垂直缩放因子传递给 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 以控制渲染尺寸。在本例中，两者均为 2，因此尺寸为 720 × 540 点的幻灯片会生成 1440 × 1080 像素的图像。相等的缩放因子会保留幻灯片的宽高比。每张图像使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 以 PNG 格式保存。

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

要以像素指定输出尺寸，请传递尺寸而不是缩放因子给 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/)。此示例将每张幻灯片渲染为 960 × 720 像素，并使用 [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) 保存结果。请选择与幻灯片宽高比匹配的尺寸，以避免图像拉伸。

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **选择渐变渲染样式**

假设幻灯片包含渐变填充，但导出的 PNG 中的过渡色比 PowerPoint 中显示的更浅或有所不同。您可以使用 [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) 属性的 [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) 来选择渐变的渲染方式。

下载 [gradient-styles.pptx](gradient-styles.pptx) 并将其放置在应用程序的工作目录中。其第一张幻灯片包含两个线性渐变：顶部从青色到橙色，底部从蓝色到黄色。每个渐变都有两个止点，分别位于 0% 和 100%。

以下示例加载此演示文稿，并使用 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 以两种模式渲染相同的第一张幻灯片。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| Default | PowerPointUI |
| --- | --- |
| ![使用 Default 渲染的青色到橙色和蓝色到黄色渐变](gradient-Default.png) | ![使用 PowerPointUI 渲染的相同渐变](gradient-PowerPointUI.png) |

在此示例中，`Default` 产生较浅的中间颜色，而 `PowerPointUI` 产生较暗的中间颜色。差异取决于渐变中的颜色和止点。

当标准 Aspose.Slides 输出满足需求时请选择 `Default`。当您优先匹配 PowerPoint 中的外观时，请尝试 `PowerPointUI`。将两种输出与预期结果进行比较；没有哪种模式是普遍优选的。

## **常见问题**

**如何导出特定形状（如图表或图片），而不是整个幻灯片？**

Aspose.Slides 支持[为单个形状生成缩略图](/slides/zh/net/create-shape-thumbnails/)，允许您将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的。为每个线程或进程使用单独的演示文稿实例；[不要在多个线程之间共享单个实例](/slides/zh/net/multithreading/)。

**导出为 PNG 时评估模式有哪些限制？**

评估模式会在输出图像上添加水印，并在应用许可证之前施加[其他限制](/slides/zh/net/licensing/)。