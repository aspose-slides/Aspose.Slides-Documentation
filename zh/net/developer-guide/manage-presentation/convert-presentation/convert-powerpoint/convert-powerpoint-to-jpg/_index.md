---
title: 在 .NET 中将 PPT 和 PPTX 转换为 JPG
linktitle: PowerPoint 转 JPG
type: docs
weight: 60
url: /zh/net/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 JPG
- 演示文稿 转 JPG
- 幻灯片 转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- 将 PowerPoint 保存为 JPG
- 将 演示文稿 保存为 JPG
- 将 幻灯片 保存为 JPG
- 将 PPT 保存为 JPG
- 将 PPTX 保存为 JPG
- 将 PPT 导出为 JPG
- 将 PPTX 导出为 JPG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中将 PowerPoint (PPT, PPTX) 幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---
## **介绍**

将 PowerPoint 和 OpenDocument 演示文稿转换为 JPG 图像有助于共享幻灯片、优化性能以及将内容嵌入网站或应用程序。Aspose.Slides for .NET 允许您将 PPTX、PPT 和 ODP 文件转换为高质量的 JPEG 图像。本指南说明了不同的转换方法。

借助这些功能，您可以轻松实现自己的演示文稿查看器并为每张幻灯片创建缩略图。如果您想保护幻灯片不被复制或以只读模式演示演示文稿，这会非常有用。Aspose.Slides 允许您将整个演示文稿或特定幻灯片转换为图像格式。

## **将演示文稿幻灯片转换为 JPG 图像**

以下是将 PPT、PPTX 或 ODP 文件转换为 JPG 的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/zh/net/aspose.slides/islide) 类型的幻灯片对象。
3. 使用 [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/#getimage_5) 方法为幻灯片创建图像。
4. 在图像对象上调用 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/#save_3) 方法。将输出文件名和图像格式作为参数传入。

{{% alert color="info" %}} 
**注意：** PPT、PPTX 或 ODP 转换为 JPG 与 Aspose.Slides .NET API 中转换为其他格式的方式不同。对于其他格式，通常使用 [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/#save_5) 方法。但是，对于 JPG 转换，需要使用 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/zh/net/aspose.slides/iimage/save/#save_3) 方法。
{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 创建指定比例的幻灯片图像。
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // 以 JPEG 格式将图像保存到磁盘。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **使用自定义尺寸将幻灯片转换为 JPG**

要更改生成的 JPG 图像的尺寸，可以通过将尺寸传递给 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/zh/net/aspose.slides/islide/getimage/#getimage_6) 方法来设置图像大小。这样可以生成具有特定宽度和高度值的图像，确保输出满足分辨率和宽高比的要求。此灵活性在为 Web 应用程序、报告或文档生成图像时尤其有用，因为需要精确的图像尺寸。

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 创建指定大小的幻灯片图像。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 以 JPEG 格式将图像保存到磁盘。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **在将幻灯片保存为图像时呈现批注**

Aspose.Slides for .NET 提供了一个功能，允许您在将演示文稿的幻灯片转换为 JPG 图像时呈现批注。此功能对于保留协作者在 PowerPoint 演示文稿中添加的注释、反馈或讨论特别有用。启用此选项后，批注将在生成的图像中可见，便于在无需打开原始演示文稿文件的情况下审阅和共享反馈。

假设我们有一个演示文稿文件 “sample.pptx”，其中的一张幻灯片包含批注：

![带批注的幻灯片](slide_with_comments.png)

以下 C# 代码在保留批注的同时将幻灯片转换为 JPG 图像：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // 设置幻灯片批注的选项。
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // 将第一张幻灯片转换为图像。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

结果：

![带批注的 JPG 图像](image_with_comments.png)

## **另请参阅**

查看将 PPT、PPTX 或 ODP 转换为图像的其他选项，例如：

- [将 PowerPoint 转换为 GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/)
- [将 PowerPoint 转换为 PNG](/slides/zh/net/convert-powerpoint-to-png/)
- [将 PowerPoint 转换为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [将 PowerPoint 转换为 SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
要了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，请尝试以下免费在线转换器：PowerPoint [PPTX 转 JPG](https://products.aspose.app/slides/zh/conversion/pptx-to-jpg) 和 [PPT 转 JPG](https://products.aspose.app/slides/zh/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![免费在线 PPTX 转 JPG 转换器](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/zh/collage)。使用此在线服务，您可以合并 [JPG 转 JPG](https://products.aspose.app/slides/zh/collage/jpg) 或 [PNG 转 PNG](https://products.aspose.app/slides/zh/collage/jpg) 图像，创建 [图片网格](https://products.aspose.app/slides/zh/collage/photo-grid)，等等。

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。更多信息，请参阅以下页面：将 [图像转 JPG](https://products.aspose.com/slides/zh/net/conversion/image-to-jpg/)；将 [JPG 转 图像](https://products.aspose.com/slides/zh/net/conversion/jpg-to-image/)；将 [JPG 转 PNG](https://products.aspose.com/slides/zh/net/conversion/jpg-to-png/) 、将 [PNG 转 JPG](https://products.aspose.com/slides/zh/net/conversion/png-to-jpg/)；将 [PNG 转 SVG](https://products.aspose.com/slides/zh/net/conversion/png-to-svg/) 、将 [SVG 转 PNG](https://products.aspose.com/slides/zh/net/conversion/svg-to-png/)。
{{% /alert %}}

## **常见问题**

### 此方法是否支持批量转换？

是的，Aspose.Slides 允许在一次操作中批量将多张幻灯片转换为 JPG。

### 转换是否支持 SmartArt、图表和其他复杂对象？

是的，Aspose.Slides 会渲染所有内容，包括 SmartArt、图表、表格、形状等。不过，与 PowerPoint 相比，渲染精度可能会略有差异，尤其是使用自定义或缺失的字体时。

### 处理的幻灯片数量是否有限制？

Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。