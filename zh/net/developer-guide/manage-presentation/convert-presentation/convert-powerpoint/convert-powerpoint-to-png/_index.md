---
title: 在 .NET 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/net/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿转 PNG
- 幻灯片转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿快速转换为高质量 PNG 图像，确保精准、自动化的结果。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 PNG 图像。它展示了如何加载 PPT、PPTX 和 ODP 等格式的演示文稿文件，将幻灯片渲染为图像，并以 PNG 格式保存结果。

本文还演示了如何通过设置缩放值或指定所需的宽度和高度来自定义生成的 PNG 图像。

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/properties/slides) 集合中获取位于 [ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide) 接口下的幻灯片对象。 
3. 使用 [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 方法以所需的缩放比例渲染每张幻灯片。 
4. 使用 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.ipresentation/save/methods/5) 方法将幻灯片缩略图保存为 PNG 格式。 

以下 C# 代码演示了如何将 PowerPoint 演示文稿转换为 PNG。Presentation 对象可以加载 PPT、PPTX、ODP 等格式，然后该对象中的每张幻灯片都会转换为 PNG 格式或其他图片格式。

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**注意：** 缩放参数 `1f, 1f` 会以幻灯片的完整大小渲染每张幻灯片，因此 720×540 pt 的幻灯片会生成 720×540 px 的图像。无参数的 [GetImage()](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/) 重载则返回更小的预览缩略图。 
{{% /alert %}} 

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果希望获取特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，以确定生成的缩略图尺寸。 

下面的 C# 代码演示了上述操作：

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果希望获取特定尺寸的 PNG 文件，可以为 `imageSize` 传入自定义的 `width` 和 `height` 参数。 

以下代码演示了在指定图像尺寸的情况下将 PowerPoint 转换为 PNG：

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **常见问题**

### 如何仅导出特定形状（例如图表或图片）而不是整张幻灯片？

Aspose.Slides 支持[为单个形状生成缩略图](/slides/zh/net/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

### 服务器上是否支持并行转换？

是的，但请[不要共享](/slides/zh/net/multithreading/) 单个 Presentation 实例于多个线程。每个线程或进程应使用独立的实例。

### 导出为 PNG 时试用版有什么限制？

评估模式会在输出图像上添加水印，并在未应用许可证前强制执行[其他限制](/slides/zh/net/licensing/)。