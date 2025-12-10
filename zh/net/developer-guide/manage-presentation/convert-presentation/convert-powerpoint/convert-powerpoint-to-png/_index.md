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
description: "使用 Aspose.Slides for .NET 快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保结果精确且自动化。"
---

## **概述**

本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 PNG 格式。内容包括以下主题。

- [将 PowerPoint 转换为 PNG (C#)](#convert-powerpoint-to-png)
- [将 PPT 转换为 PNG (C#)](#convert-powerpoint-to-png)
- [将 PPTX 转换为 PNG (C#)](#convert-powerpoint-to-png)
- [将 ODP 转换为 PNG (C#)](#convert-powerpoint-to-png)
- [将 PowerPoint 幻灯片转换为图像 (C#)](#convert-powerpoint-to-png)

## **在 .NET 中将 PowerPoint 转换为 PNG**

有关将 PowerPoint 转换为 PNG 的 C# 示例代码，请参见下面的章节，即 [将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)。代码可以在 Presentation 对象中加载 PPT、PPTX、ODP 等多种格式，然后将幻灯片缩略图保存为 PNG 格式。其他类似的 PowerPoint 转图像转换（如 JPG、BMP、TIFF、SVG）在以下文章中讨论。

- [C# PowerPoint 转 JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint 转 SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **关于 PowerPoint 转 PNG 转换**

PNG（Portable Network Graphics）格式的流行度不及 JPEG（Joint Photographic Experts Group），但仍然非常常用。

**使用场景：** 当您需要处理复杂图像且对文件大小没有限制时，PNG 比 JPEG 更合适。

{{% alert title="Tip" color="primary" %}} 您可以尝试 Aspose 免费的 **PowerPoint 转 PNG 转换器**：[PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本文所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 接口对应的幻灯片对象。 
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法获取每张幻灯片的缩略图。 
4. 使用 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) 方法将幻灯片缩略图保存为 PNG 格式。 

此 C# 代码演示了如何将 PowerPoint 演示文稿转换为 PNG。Presentation 对象可以加载 PPT、PPTX、ODP 等格式，然后将演示文稿中的每张幻灯片转换为 PNG 或其他图像格式。
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果希望按特定比例获取 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，以决定生成的缩略图尺寸。

以下 C# 代码演示了上述操作：
```c#
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


## **使用自定义大小将 PowerPoint 转换为 PNG**

如果希望按特定尺寸获取 PNG 文件，可以为 `imageSize` 传入期望的 `width` 和 `height` 参数。

以下代码展示了在指定图像大小的情况下将 PowerPoint 转换为 PNG 的方法：
```c#
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

**如何仅导出特定形状（例如图表或图片），而不是整张幻灯片？**

Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/net/create-shape-thumbnails/)，您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

可以，但请 [不要在多个线程之间共享](/slides/zh/net/multithreading/) 同一个 Presentation 实例。每个线程或进程应使用独立的实例。

**导出为 PNG 时试用版有哪些限制？**

评估模式会在输出图像上添加水印，并在授权前执行 [其他限制](/slides/zh/net/licensing/)。