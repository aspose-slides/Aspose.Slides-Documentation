---
title: 将 PowerPoint 转换为 PNG 以 C#
linktitle: 将 PowerPoint 转换为 PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords:
- PowerPoint 转 PNG
- ppt 转 PNG
- pptx 转 PNG
- odp 转 PNG
- PowerPoint 转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- ODP 转 PNG
- C#
- Csharp
- Aspose.Slides for .NET
description: 在 C# 中将 PowerPoint 演示文稿转换为 PNG。 在 C# 中将 PPT 转换为 PNG。 在 C# 中将 PPTX 转换为 PNG。 在 C# 中将 ODP 转换为 PNG。
---

## **概述**

本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 PNG 格式。 内容包括以下主题。

- [在 C# 中将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPT 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PPTX 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 ODP 转换为 PNG](#convert-powerpoint-to-png)
- [在 C# 中将 PowerPoint 幻灯片转换为图像](#convert-powerpoint-to-png)

## **C# PowerPoint 转 PNG**

有关将 PowerPoint 转换为 PNG 的 C# 示例代码，请参见下面的部分，即 [将 PowerPoint 转换为 PNG](#convert-powerpoint-to-png)。 代码可以在 Presentation 对象中加载多种格式，如 PPT、PPTX 和 ODP，然后将其幻灯片缩略图保存为 PNG 格式。 其他类似的 PowerPoint 转图像转换，如 JPG、BMP、TIFF 和 SVG，已在这些文章中讨论。

- [C# PowerPoint 转 JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint 转 TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint 转 SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **关于 PowerPoint 转 PNG 转换**

PNG（可移植网络图形）格式不如 JPEG（联合图像专家组）流行，但仍然非常流行。

**用例：** 当您有一个复杂的图像而且大小不是问题时，PNG 是比 JPEG 更好的图像格式。

{{% alert title="提示" color="primary" %}} 您可能希望查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**： [PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。 它们是本文所描述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

请按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 接口的幻灯片对象。
3. 使用 [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法获取每个幻灯片的缩略图。
4. 使用 [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) 方法将幻灯片缩略图保存为 PNG 格式。

这段 C# 代码演示了如何将 PowerPoint 演示文稿转换为 PNG。 Presentation 对象可以加载 PPT、PPTX、ODP 等，然后将演示文稿对象中的每个幻灯片转换为 PNG 格式或其他图像格式。

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

## **以自定义尺寸转换 PowerPoint 为 PNG**

如果您想获得特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这决定了生成缩略图的尺寸。

这段 C# 代码演示了所述操作：

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

## **以自定义大小转换 PowerPoint 为 PNG**

如果您想获得特定大小的 PNG 文件，可以为 `imageSize` 传递您首选的 `width` 和 `height` 参数。

这段代码演示了如何在指定图像大小的情况下将 PowerPoint 转换为 PNG：

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