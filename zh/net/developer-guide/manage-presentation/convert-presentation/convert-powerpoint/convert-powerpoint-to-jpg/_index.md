---
title: 将 PowerPoint 转换为 JPG 的 C#
linktitle: 将 PowerPoint PPT 转换为 JPG
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: 
- 转换 PowerPoint 演示文稿
- JPG
- JPEG
- PowerPoint 转 JPG
- PowerPoint 转 JPEG
- PPT 转 JPG
- PPTX 转 JPG
- PPT 转 JPEG
- PPTX 转 JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "在 C# 或 .NET 中将 PowerPoint 转换为 JPG。将幻灯片保存为 JPG 图像"
---

## **概述**

本文解释了如何使用 C# 将 PowerPoint 演示文稿转换为 JPG 格式。它涵盖以下主题：

- [C# 将 PowerPoint 转换为 JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# 将 PPT 转换为 JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# 将 PPTX 转换为 JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# 将 ODP 转换为 JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# 将 PowerPoint 幻灯片转换为图像](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint 转 JPG**

有关将 PowerPoint 转换为 JPG 的 C# 示例代码，请参见下面的部分，即 [将 PowerPoint 转换为 JPG](#convert-powerpoint-pptpptx-to-jpg)。 该代码可以加载 PPT、PPTX 和 ODP 等多种格式到演示文稿对象中，然后将其幻灯片缩略图保存为 JPG 格式。 其他类似的 PowerPoint 到图像的转换，如 PNG、BMP、TIFF 和 SVG，讨论在这些文章中。

- [C# PowerPoint 转 PNG](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint 转 BMP](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint 转 TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint 转 SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **关于 PowerPoint 转 JPG 转换**
使用 [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/) 您可以将 PowerPoint PPT 或 PPTX 演示文稿转换为 JPG 图像。还可以将 PPT/PPTX 转换为 BMP、PNG 或 SVG。 借助此功能，您可以轻松实现自己的演示文稿查看器，创建每个幻灯片的缩略图。如果您希望保护演示幻灯片不被版权保护，或以只读模式演示演示文稿，这可能很有用。 Aspose.Slides 允许将整个演示文稿或特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可能想尝试这些免费的在线转换器：PowerPoint [PPTX 转 JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT 转 JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) 集合中获取 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 类型的幻灯片对象。
3. 创建每个幻灯片的缩略图，然后将其转换为 JPG。[**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) 方法用于获取幻灯片的缩略图，它返回一个 [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) 对象作为结果。[GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) 方法必须从所需的 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) 类型的幻灯片中调用，结果缩略图的比例传递到该方法中。
4. 获取幻灯片缩略图后，从缩略图对象中调用 [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) 方法。将结果文件名和图像格式传递给该方法。

{{% alert color="primary" %}} 
**注意**: PPT/PPTX 转 JPG 的转换与 Aspose.Slides .NET API 中转换为其他类型的转换不同。对于其他类型，您通常使用 [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5)方法，但在这里您需要 [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) 方法。
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // 创建全尺度图像
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // 将图像以 JPEG 格式保存到磁盘
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **使用自定义尺寸将 PowerPoint PPT/PPTX 转换为 JPG**
要更改生成的缩略图和 JPG 图像的尺寸，可以通过将 *ScaleX* 和 *ScaleY* 值传递到 [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) 方法中来设置它们：

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // 定义尺寸
    int desiredX = 1200;
    int desiredY = 800;

    // 获取 X 和 Y 的缩放值
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // 创建全尺度图像
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // 将图像以 JPEG 格式保存到磁盘
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **在将演示文稿保存为图像时呈现注释**
Aspose.Slides for .NET 提供了一种功能，让您在将演示文稿的幻灯片转换为图像时渲染注释。以下 C# 代码演示了该操作：

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费的拼贴网页应用](https://products.aspose.app/slides/collage)。使用这个在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。

使用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参见以下页面：转换 [图像到 JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/)；转换 [JPG 到图像](https://products.aspose.com/slides/net/conversion/jpg-to-image/)；转换 [JPG 到 PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/)；转换 [PNG 到 SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/)。

{{% /alert %}}

## **另请参见**

查看其他将 PPT/PPTX 转换为图像的选项，例如：

- [PPT/PPTX 转 SVG 转换](/slides/net/render-a-slide-as-an-svg-image/)。