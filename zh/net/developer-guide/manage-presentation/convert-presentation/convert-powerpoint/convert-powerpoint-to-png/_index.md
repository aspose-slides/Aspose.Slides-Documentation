---
title: 将 PowerPoint 幻灯片转换为 PNG（.NET）
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
description: "使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿快速转换为高质量 PNG 图像，确保精确、自动化的结果。"
---

## **概述**

本文介绍了如何使用 C# 将 PowerPoint 演示文稿转换为 PNG 格式。内容包括以下主题。

- [在 C# 中将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPT 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPTX 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 ODP 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PowerPoint 幻灯片转换为图像](#convert-powerpoint-to-png)

## **C# PowerPoint 转 PNG**

有关将 PowerPoint 转换为 PNG 的 C# 示例代码，请参阅下方章节，即 [将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)。代码可以在 Presentation 对象中加载 PPT、PPTX、ODP 等多种格式，然后将幻灯片缩略图保存为 PNG 格式。其他类似的 PowerPoint 到图像的转换（如 JPG、BMP、TIFF、SVG）在以下文章中有说明。

- [C# PowerPoint 转 JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint 转 SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **关于 PowerPoint 转 PNG 的转换**

PNG（Portable Network Graphics）格式虽然没有 JPEG（Joint Photographic Experts Group）那样流行，但仍然非常受欢迎。

**使用场景：** 当图片复杂且尺寸不是问题时，PNG 比 JPEG 更适合作为图像格式。

{{% alert title="Tip" color="primary" %}} 您可以尝试 Aspose 免费的 **PowerPoint 转 PNG 转换器**：[PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本文所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 接口下的幻灯片对象。 
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

如果希望按特定比例获取 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这决定了生成的缩略图尺寸。

下面的 C# 代码演示了上述操作：
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

如果希望按特定大小获取 PNG 文件，可以为 `imageSize` 传入自定义的 `width` 和 `height` 参数。

下面的代码展示了如何在指定图像大小的情况下将 PowerPoint 转换为 PNG：
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

**如何仅导出特定形状（例如图表或图片），而不是整个幻灯片？**

Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/net/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

可以，但请勿在多个线程之间共享同一个 Presentation 实例。每个线程或进程应使用独立的实例。

**导出为 PNG 时试用版有什么限制？**

评估模式会在输出图像上添加水印，并在使用许可证之前执行 [其他限制](/slides/zh/net/licensing/)。