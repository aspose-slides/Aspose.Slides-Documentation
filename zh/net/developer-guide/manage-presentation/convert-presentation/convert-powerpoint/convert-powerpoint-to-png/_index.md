---
title: 将 PowerPoint 幻灯片转换为 PNG（.NET）
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿快速转换为高质量 PNG 图像，确保精准、自动化的结果。"
---

## **概述**

本文说明如何使用 C# 将 PowerPoint 演示文稿转换为 PNG 格式。它涵盖以下主题。

- [在 C# 中将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPT 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPTX 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 ODP 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PowerPoint 幻灯片转换为图像](#convert-powerpoint-to-png)

## **C# PowerPoint 转 PNG**

有关将 PowerPoint 转换为 PNG 的 C# 示例代码，请参阅下面的部分，即 [Convert PowerPoint to PNG](#convert-powerpoint-to-png)。该代码可以在 Presentation 对象中加载多种格式，如 PPT、PPTX 和 ODP，然后将其幻灯片缩略图保存为 PNG 格式。其他类似的 PowerPoint 到图像的转换，如 JPG、BMP、TIFF 和 SVG，在以下文章中讨论。

- [C# PowerPoint 转 JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint 转 SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **关于 PowerPoint 转 PNG 转换**

PNG（可移植网络图形）格式不如 JPEG（联合图像专家组）流行，但它仍然非常受欢迎。

**使用场景：** 当您拥有复杂图像且尺寸不是问题时，PNG 比 JPEG 更适合作为图像格式。

{{% alert title="提示" color="primary" %}} 您可能想要查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**：[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本文所述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

执行以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取幻灯片对象，使用 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 接口。 
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法获取每个幻灯片的缩略图。 
4. 使用 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) 方法将幻灯片缩略图保存为 PNG 格式。 

此 C# 代码演示如何将 PowerPoint 演示文稿转换为 PNG。Presentation 对象可以加载 PPT、PPTX、ODP 等，然后将演示文稿中的每个幻灯片转换为 PNG 格式或其他图像格式。
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

如果您想获取特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定生成的缩略图的尺寸。 

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

如果您想获取特定大小的 PNG 文件，可以为 `imageSize` 传入首选的 `width` 和 `height` 参数。 

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

**如何仅导出特定形状（例如图表或图片）而不是整张幻灯片？**

Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/net/create-shape-thumbnails/); 您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的，但请 [不要共享](/slides/zh/net/multithreading/) 单个 Presentation 实例跨线程使用。每个线程或进程使用单独的实例。

**导出为 PNG 时试用版有什么限制？**

评估模式会在输出图像上添加水印，并在未应用许可证前强制执行 [其他限制](/slides/zh/net/licensing/)。