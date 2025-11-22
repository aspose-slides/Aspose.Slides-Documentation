---
title: 在 C# 中将 PPT、PPTX 和 ODP 转换为 JPG
linktitle: 将幻灯片转换为 JPG 图像
type: docs
weight: 60
url: /zh/net/convert-powerpoint-to-jpg/
keywords:
- 将 PowerPoint 转换为 JPG
- 将演示文稿转换为 JPG
- 将幻灯片转换为 JPG
- 将 PPT 转换为 JPG
- 将 PPTX 转换为 JPG
- 将 ODP 转换为 JPG
- PowerPoint 转 JPG
- 演示文稿转 JPG
- 幻灯片转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- ODP 转 JPG
- 将 PowerPoint 转换为 JPEG
- 将演示文稿转换为 JPEG
- 将幻灯片转换为 JPEG
- 将 PPT 转换为 JPEG
- 将 PPTX 转换为 JPEG
- 将 ODP 转换为 JPEG
- PowerPoint 转 JPEG
- 演示文稿转 JPEG
- 幻灯片转 JPEG
- PPT 转 JPEG
- PPTX 转 JPEG
- ODP 转 JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "了解如何仅用几行代码将 PowerPoint 和 OpenDocument 演示文稿转换为高质量的 JPEG 图像。优化演示文稿以用于网页、共享和存档。立即阅读完整指南！"
---

## **概述**

将 PowerPoint 和 OpenDocument 演示文稿转换为 JPG 图像有助于共享幻灯片、优化性能以及将内容嵌入网站或应用程序中。Aspose.Slides for .NET 允许您将 PPTX、PPT 和 ODP 文件转换为高质量的 JPEG 图像。本指南解释了不同的转换方法。

借助这些功能，您可以轻松实现自己的演示文稿查看器并为每张幻灯片创建缩略图。如果您希望保护幻灯片不被复制或以只读模式演示演示文稿，这将非常有用。Aspose.Slides 允许您将整个演示文稿或指定的幻灯片转换为图像格式。

## **将演示文稿幻灯片转换为 JPG 图像**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。  
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取类型为 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 的幻灯片对象。  
3. 使用 [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) 方法创建幻灯片的图像。  
4. 在图像对象上调用 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) 方法。将输出文件名和图像格式作为参数传递。

{{% alert color="primary" %}} 

**注意：** 在 Aspose.Slides .NET API 中，PPT、PPTX 或 ODP 转换为 JPG 与转换为其他格式不同。对于其他格式，通常使用 [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5) 方法。但对于 JPG 转换，需要使用 [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) 方法。

{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 创建指定缩放比例的幻灯片图像。
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

若要更改生成的 JPG 图像的尺寸，您可以通过将尺寸传递给 [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6) 方法来设置图像大小。这使您能够生成具有特定宽度和高度的图像，确保输出符合分辨率和宽高比的要求。这种灵活性在为 Web 应用程序、报告或文档生成图像时特别有用，因为此时需要精确的图像尺寸。

```c#
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


## **在将幻灯片保存为图像时渲染批注**

Aspose.Slides for .NET 提供了一个功能，允许在将演示文稿的幻灯片转换为 JPG 图像时渲染批注。此功能对于保留 PowerPoint 演示文稿中协作者添加的注释、反馈或讨论特别有用。通过启用此选项，您可以确保批注在生成的图像中可见，从而更容易在无需打开原始演示文稿文件的情况下审阅和分享反馈。

假设我们有一个演示文稿文件 “sample.pptx”，其中一张幻灯片包含批注：

![包含批注的幻灯片](slide_with_comments.png)

以下 C# 代码在保留批注的情况下将幻灯片转换为 JPG 图像：

```c#
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


结果如下：

![包含批注的 JPG 图像](image_with_comments.png)

## **另请参阅**

请参阅将 PPT、PPTX 或 ODP 转换为图像的其他选项，例如：

- [将 PowerPoint 转换为 GIF](/slides/zh/net/convert-powerpoint-to-animated-gif/)
- [将 PowerPoint 转换为 PNG](/slides/zh/net/convert-powerpoint-to-png/)
- [将 PowerPoint 转换为 TIFF](/slides/zh/net/convert-powerpoint-to-tiff/)
- [将 PowerPoint 转换为 SVG](/slides/zh/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

要了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，请尝试以下免费在线转换器：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![免费在线 PPTX 转 JPG 转换器](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid) 等。

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参阅以下页面：将 [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/) 转换为 JPG；将 [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/) 转换为图像；将 [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/) 转换为 PNG，将 [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/) 转换为 JPG；将 [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/) 转换为 SVG，将 [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/) 转换为 PNG。

{{% /alert %}}

## **常见问题**

**此方法是否支持批量转换？**

是的，Aspose.Slides 允许在一次操作中批量将多个幻灯片转换为 JPG。

**转换是否支持 SmartArt、图表和其他复杂对象？**

是的，Aspose.Slides 渲染所有内容，包括 SmartArt、图表、表格、形状等。然而，与 PowerPoint 相比，渲染精度可能会略有差异，尤其是在使用自定义或缺失字体时。

**处理的幻灯片数量是否有限制？**

Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。