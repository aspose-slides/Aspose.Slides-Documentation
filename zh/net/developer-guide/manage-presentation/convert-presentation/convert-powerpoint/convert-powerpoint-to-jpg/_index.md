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
- 将演示文稿保存为 JPG
- 将幻灯片保存为 JPG
- 将 PPT 保存为 JPG
- 将 PPTX 保存为 JPG
- 导出 PPT 为 JPG
- 导出 PPTX 为 JPG
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中将 PowerPoint（PPT、PPTX）幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---

## **概述**

将 PowerPoint 和 OpenDocument 演示文稿转换为 JPG 图像有助于共享幻灯片、优化性能以及将内容嵌入网站或应用程序。Aspose.Slides for .NET 允许您将 PPTX、PPT 和 ODP 文件转换为高质量的 JPEG 图像。本文档说明了不同的转换方法。

使用这些功能，您可以轻松实现自定义演示文稿查看器，并为每张幻灯片创建缩略图。如果您希望保护幻灯片免于复制或在只读模式下演示演示文稿，这将非常有用。Aspose.Slides 允许您将整个演示文稿或特定幻灯片转换为图像格式。

## **将演示文稿幻灯片转换为 JPG 图像**

以下是将 PPT、PPTX 或 ODP 文件转换为 JPG 的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 类型的幻灯片对象。
1. 使用 [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) 方法创建幻灯片的图像。
1. 对图像对象调用 [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) 方法。将输出文件名和图像格式作为参数传入。

{{% alert color="primary" %}} 
**注意:** PPT、PPTX 或 ODP 转 JPG 的转换方式与 Aspose.Slides .NET API 中转换为其他格式的方式不同。对于其他格式，通常使用 [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) 方法。然而，针对 JPG 转换，需要使用 [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) 方法。
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 创建具有指定比例的幻灯片图像。
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // 将图像以 JPEG 格式保存到磁盘。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **使用自定义尺寸将幻灯片转换为 JPG**

要更改生成的 JPG 图像的尺寸，您可以将尺寸传入 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) 方法。这样可以生成具有特定宽度和高度值的图像，确保输出满足分辨率和宽高比的要求。这种灵活性在为 Web 应用、报告或文档生成图像时尤为有用，因为这些场景需要精确的图像尺寸。
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 创建指定尺寸的幻灯片图像。
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // 将图像以 JPEG 格式保存到磁盘。
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **在将幻灯片保存为图像时渲染评论**

Aspose.Slides for .NET 提供了一个功能，允许您在将演示文稿的幻灯片转换为 JPG 图像时渲染评论。此功能对于保留 PowerPoint 演示文稿中协作者添加的注释、反馈或讨论特别有用。启用此选项后，评论将出现在生成的图像中，便于在无需打开原始演示文稿文件的情况下查看和共享反馈。

假设我们有一个名为 “sample.pptx” 的演示文稿文件，其中包含带有评论的幻灯片：

![带有评论的幻灯片](slide_with_comments.png)

以下 C# 代码在保留评论的同时将幻灯片转换为 JPG 图像：
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // 为幻灯片评论设置选项。
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

![带有评论的 JPG 图像](image_with_comments.png)

## **另请参阅**

查看将 PPT、PPTX 或 ODP 转换为图像的其他选项，例如：

- [将 PowerPoint 转换为 GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/)
- [将 PowerPoint 转换为 PNG](/slides/zh/net/convert-powerpoint-to-png/)
- [将 PowerPoint 转换为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [将 PowerPoint 转换为 SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
想了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，请尝试以下免费在线转换器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

![免费在线 PPTX 转 JPG 转换器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG to PNG 图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid)，等等。 

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。欲了解更多信息，请参阅以下页面：convert [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；convert [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；convert [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，convert [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；convert [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，convert [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。
{{% /alert %}}

## **常见问题**

**此方法是否支持批量转换？**

是的，Aspose.Slides 支持在一次操作中批量将多个幻灯片转换为 JPG。

**转换是否支持 SmartArt、图表和其他复杂对象？**

是的，Aspose.Slides 渲染所有内容，包括 SmartArt、图表、表格、形状等。不过，与 PowerPoint 相比，渲染精度可能会因使用自定义或缺失的字体而略有差异。

**处理的幻灯片数量是否有限制？**

Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。