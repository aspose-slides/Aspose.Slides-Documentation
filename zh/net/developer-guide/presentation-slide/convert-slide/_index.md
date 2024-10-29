---
title: 转换幻灯片
type: docs
weight: 41
url: /zh/net/convert-slide/
keywords: 
- 将幻灯片转换为图像
- 将幻灯片导出为图像
- 将幻灯片保存为图像
- 幻灯片转图像
- 幻灯片转PNG
- 幻灯片转JPEG
- 幻灯片转位图
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "在C#或.NET中将PowerPoint幻灯片转换为图像（位图、PNG或JPG）"
---

Aspose.Slides for .NET 允许您将幻灯片（在演示文稿中）转换为图像。这些是支持的图像格式：BMP、PNG、JPG（JPEG）、GIF等。

要将幻灯片转换为图像，请执行以下操作：

1. 首先，使用以下方式设置转换参数和要转换的幻灯片对象：
   * [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) 接口或
   * [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) 接口。

2. 其次，通过使用 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法将幻灯片转换为图像。

## **关于位图和其他图像格式**

在 .NET 中， [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) 是一种允许您处理由像素数据定义的图像的对象。您可以使用此类的实例以多种格式（BMP、JPG、PNG 等）保存图像。

{{% alert title="信息" color="info" %}}

Aspose 最近开发了一个在线 [文本到 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}

## **将幻灯片转换为位图并将图像保存为PNG格式**

以下C#代码演示了如何将演示文稿的第一张幻灯片转换为位图对象，然后将图像保存为PNG格式：

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // 将演示文稿中的第一张幻灯片转换为位图对象
    using (IImage image = pres.Slides[0].GetImage())
    {
        // 将图像保存为PNG格式
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="提示" color="primary" %}} 

您可以将幻灯片转换为位图对象，然后直接在某处使用该对象。或者，您可以将幻灯片转换为位图，然后将图像保存为JPEG或您喜欢的任何其他格式。

{{% /alert %}}  

## **使用自定义大小将幻灯片转换为图像**

您可能需要获取特定大小的图像。使用 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 的重载，您可以将幻灯片转换为具有特定尺寸（长度和宽度）的图像。

以下示例代码演示了如何使用C#中的 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法进行转换：

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // 将演示文稿中的第一张幻灯片转换为具有指定大小的位图
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // 将图像保存为JPEG格式
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **将带有注释和评论的幻灯片转换为图像**

一些幻灯片包含注释和评论。

Aspose.Slides 提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) 和 [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)——让您可以控制将演示文稿幻灯片呈现为图像的方式。两个接口都拥有 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) 接口，该接口允许您在将幻灯片转换为图像时添加幻灯片上的注释和评论。

{{% alert title="信息" color="info" %}} 

使用 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) 接口，您可以指定所需的注释和评论在结果图像中的位置。

{{% /alert %}} 

以下C#代码演示了带有注释和评论的幻灯片的转换过程：

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // 创建渲染选项
    IRenderingOptions options = new RenderingOptions();

    // 设置页面上注释的位置
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // 设置页面上评论的位置 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // 设置评论输出区域的宽度
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // 设置评论区域的颜色
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // 将演示文稿的第一张幻灯片转换为位图对象
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // 将图像保存为GIF格式
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="注意" color="warning" %}} 

在任何幻灯片转换为图像的过程中， [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) 属性不能设置为 BottomFull（以指定注释的位置），因为注释的文本可能很大，这意味着它可能无法适合指定的图像大小。

{{% /alert %}} 

## **使用ITiffOptions将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) 接口为您提供了对结果图像的更多控制（在参数方面）。使用此接口，您可以为结果图像指定大小、分辨率、调色板和其他参数。

以下C#代码演示了一个转换过程，其中ITiffOptions用于输出黑白图像，分辨率为300dpi，大小为2160 × 2800：

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // 根据索引获取幻灯片
    ISlide slide = pres.Slides[0];

    // 创建TiffOptions对象
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // 设置未找到源字体时使用的字体
    options.DefaultRegularFont = "Arial Black";

    // 设置页面上注释的位置 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // 设置像素格式（黑白）
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // 设置分辨率
    options.DpiX = 300;
    options.DpiY = 300;

    // 将幻灯片转换为位图对象
    using (IImage image = slide.GetImage(options))
    {
        // 将图像保存为BMP格式
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将单个演示文稿中的所有幻灯片转换为图像。基本上，您可以将整个演示文稿转换为图像。

以下示例代码演示了如何将演示文稿中的所有幻灯片转换为图像（C#）：

```csharp
// 指定输出目录的路径
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // 一张一张地将演示文稿渲染为图像数组
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // 指定隐藏幻灯片的设置（不渲染隐藏幻灯片）
        if (pres.Slides[i].Hidden)
            continue;

        // 将幻灯片转换为位图对象
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // 为图像创建文件名
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // 将图像保存为JPEG格式
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```