---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 TIFF
titlelink: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/net/convert-powerpoint-to-tiff/
keywords:
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿 转 TIFF
- 幻灯片 转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- 将 PPT 保存为 TIFF
- 将 PPTX 保存为 TIFF
- 导出 PPT 为 TIFF
- 导出 PPTX 为 TIFF
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松将 PowerPoint（PPT、PPTX）演示文稿转换为高质量的 TIFF 图像。提供 C# 代码示例。"
---
## **介绍**

TIFF (**Tagged Image File Format**) 是一种广泛使用的无损光栅图像格式，以其卓越的质量和对图形细节的完整保留而闻名。设计师、摄影师和桌面出版人员通常选择 TIFF 来保持图像的图层、颜色精度和原始设置。

使用 Aspose.Slides，您可以轻松地将 PowerPoint 幻灯片（PPT、PPTX）和 OpenDocument 幻灯片（ODP）直接转换为高质量的 TIFF 图像，确保您的演示文稿保持最高的视觉保真度。

## **将演示文稿转换为 TIFF**

使用 [Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 方法，由 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类提供，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应默认幻灯片尺寸。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为 TIFF：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // 将演示文稿保存为 TIFF。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **将演示文稿转换为黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/) 类中，属性 [BwConversionMode](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/bwconversionmode/) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，此设置仅在 [CompressionType](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/compressiontype/) 属性设置为 `CCITT4` 或 `CCITT3` 时才生效。

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/bwconversionmode/) 是一个导出级别的设置，用于为完整的 TIFF 图像选择像素转换算法。要定义在黑白显示模式下单个形状的呈现方式，请使用 [IShape.BlackWhiteMode](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/blackwhitemode/)。有关示例，请参阅 [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假设我们有一个名为 “sample.pptx” 的文件，其中包含以下幻灯片：

![演示文稿幻灯片](slide_black_and_white.png)

下面的 C# 代码演示了如何将彩色幻灯片转换为黑白 TIFF：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

结果如下：

![黑白 TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/) 中提供的属性来设置所需的值。例如，属性 [ImageSize](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/imagesize/) 允许您定义生成图像的大小。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义尺寸的 TIFF 图像：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 设置压缩类型.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    压缩类型：
        Default - 指定默认的压缩方案（LZW）。
        None - 指定不使用压缩。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度取决于压缩类型，不能手动设置。

    // 设置图像 DPI。
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 设置图像大小。
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 将演示文稿保存为具有指定大小的 TIFF。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **将演示文稿转换为自定义像素格式的 TIFF**

通过使用来自 [TiffOptions](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions) 类的 [PixelFormat](https://reference.aspose.com/slides/zh/net/aspose.slides.export/tiffoptions/pixelformat/) 属性，您可以为生成的 TIFF 图像指定首选的像素格式。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义像素格式的 TIFF 图像：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat 包含以下值（如文档所述）：
        Format1bppIndexed - 每像素 1 位，索引颜色。
        Format4bppIndexed - 每像素 4 位，索引颜色。
        Format8bppIndexed - 每像素 8 位，索引颜色。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    // 将演示文稿保存为具有指定图像大小的 TIFF。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？**

是的。Aspose.Slides 允许您单独将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片转换为 TIFF 图像。

**在将演示文稿转换为 TIFF 时，幻灯片数量有限制吗？**

没有，Aspose.Slides 对幻灯片数量没有任何限制。您可以将任意大小的演示文稿转换为 TIFF 格式。

**在将幻灯片转换为 TIFF 时，PowerPoint 动画和转场效果会被保留吗？**

不会，TIFF 是静态图像格式。因此，动画和转场效果不会被保留；仅导出幻灯片的静态快照。