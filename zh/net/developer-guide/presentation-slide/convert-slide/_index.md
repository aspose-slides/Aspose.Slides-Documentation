---
title: 在 .NET 中将演示文稿幻灯片转换为图像
linktitle: 幻灯片转图像
type: docs
weight: 41
url: /zh/net/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中将 PPT、PPTX 和 ODP 幻灯片转换为图像——快速、高质量渲染并提供清晰的代码示例。"
---

## **概述**

Aspose.Slides for .NET 使您能够轻松地将 PowerPoint 和 OpenDocument 演示文稿幻灯片转换为各种图像格式，包括 BMP、PNG、JPG（JPEG）、GIF 等。

要将幻灯片转换为图像，请按以下步骤操作：

1. 定义所需的转换设置并使用以下方式选择要导出的幻灯片：
    - [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) 接口，或
    - [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/) 接口。
2. 调用 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 方法生成幻灯片图像。

在 .NET 中， [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) 是一个对象，允许您使用像素数据处理图像。您可以使用该类的实例将图像保存为多种格式（BMP、JPG、PNG 等）。

## **将幻灯片转换为位图并以 PNG 保存图像**

您可以将幻灯片转换为位图对象并直接在应用程序中使用。或者，您也可以先将幻灯片转换为位图，然后将图像保存为 JPEG 或其他首选格式。

以下 C# 代码演示如何将演示文稿的第一张幻灯片转换为位图对象并以 PNG 格式保存图像：
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 将演示文稿中的第一张幻灯片转换为位图。
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // 将图像保存为 PNG 格式。
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```


## **将幻灯片转换为自定义尺寸的图像**

您可能需要获取特定尺寸的图像。使用 [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) 的重载，您可以将幻灯片转换为具有特定宽度和高度的图像。

以下示例代码演示如何实现：
```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 将演示文稿中的第一张幻灯片转换为具有指定尺寸的位图。
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // 将图像保存为 JPEG 格式。
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```


## **将带有备注和批注的幻灯片转换为图像**

某些幻灯片可能包含备注和批注。

Aspose.Slides 提供了两个接口——[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) 和 [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions/)，允许您控制将演示文稿幻灯片渲染为图像的方式。这两个接口都包含 `SlidesLayoutOptions` 属性，您可以使用它在将幻灯片转换为图像时配置备注和批注的渲染方式。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 类，您可以指定在生成的图像中备注和批注的首选位置。

以下 C# 代码演示如何将带有备注和批注的幻灯片转换为图像：
```cs
float scaleX = 2;
float scaleY = scaleX;

// 加载演示文稿文件。
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // 创建渲染选项。
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // 设置备注的位置。
            CommentsPosition = CommentsPositions.Right,      // 设置批注的位置。
            CommentsAreaWidth = 500,                         // 设置批注区域的宽度。
            CommentsAreaColor = Color.AntiqueWhite           // 设置批注区域的颜色。
        }
    };

    // 将演示文稿的第一张幻灯片转换为图像。
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // 将图像保存为 GIF 格式。
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```


{{% alert title="注意" color="warning" %}} 

在任何幻灯片转图像的转换过程中，不能将 [NotesPosition](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 属性设为 `BottomFull`（用于指定备注位置），因为备注文本可能过大，导致无法适配指定的图像尺寸。

{{% /alert %}} 

## **使用 TIFF 选项将幻灯片转换为图像**

[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions/) 接口通过允许您指定尺寸、分辨率、颜色调色板等参数，提供了对生成的 TIFF 图像更精细的控制。

以下 C# 代码演示了一个使用 TIFF 选项将图像输出为 300 DPI、尺寸为 2160 × 2800 的黑白图像的转换过程：
```cs
// 加载演示文稿文件。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 获取演示文稿中的第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 配置输出 TIFF 图像的设置。
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // 设置图像尺寸。
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // 设置像素格式（黑白）。
        DpiX = 300,                                        // 设置水平分辨率。
        DpiY = 300                                         // 设置垂直分辨率。
    };

    // 使用指定的选项将幻灯片转换为图像。
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // 以 TIFF 格式保存图像。
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```


## **将所有幻灯片转换为图像**

Aspose.Slides 允许您将演示文稿中的所有幻灯片转换为图像，从而实现将整个演示文稿转化为一系列图像。

以下示例代码演示如何在 C# 中将演示文稿的所有幻灯片转换为图像：
```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // 逐张幻灯片渲染演示文稿为图像。
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // 控制隐藏幻灯片（不渲染隐藏的幻灯片）。
        if (presentation.Slides[i].Hidden)
            continue;

        // 将幻灯片转换为图像。
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // 以 JPEG 格式保存图像。
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```


## **常见问题**

**1. Aspose.Slides 是否支持渲染带有动画的幻灯片？**

不支持，`GetImage` 方法仅保存幻灯片的静态图像，不包含动画。

**2. 隐藏的幻灯片可以导出为图像吗？**

可以，隐藏的幻灯片可以像普通幻灯片一样进行处理，只需确保它们包含在处理循环中。

**3. 图像可以保存带有阴影和特效吗？**

可以，Aspose.Slides 在将幻灯片保存为图像时支持渲染阴影、透明度及其他图形效果。