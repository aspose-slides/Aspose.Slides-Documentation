---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 TIFF
titlelink: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/net/convert-powerpoint-to-tiff/
keywords:
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 TIFF
- 演示文稿转 TIFF
- 幻灯片转 TIFF
- PPT 转 TIFF
- PPTX 转 TIFF
- 将 PPT 保存为 TIFF
- 将 PPTX 保存为 TIFF
- 导出 PPT 为 TIFF
- 导出 PPTX 为 TIFF
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松将 PowerPoint（PPT、PPTX）演示文稿转换为高质量的 TIFF 图像。C# 代码示例。"
---

## **概述**

TIFF（**Tagged Image File Format**）是一种广泛使用的无损栅格图像格式，以其卓越的质量和对图形的细致保真而闻名。设计师、摄影师和桌面出版人员通常选择 TIFF 来保留图像中的图层、颜色准确性和原始设置。

使用 Aspose.Slides，您可以轻松地将 PowerPoint 幻灯片（PPT、PPTX）和 OpenDocument 幻灯片（ODP）直接转换为高质量的 TIFF 图像，确保演示文稿保持最大的视觉保真度。

## **将演示文稿转换为 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类提供的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应默认幻灯片尺寸。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为 TIFF：
```cs
// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // 将演示文稿保存为 TIFF。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```


## **将演示文稿转换为黑白 TIFF**

[TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) 类中的属性 [BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，仅当 [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) 属性设置为 `CCITT4` 或 `CCITT3` 时，此设置才生效。

假设我们有一个名为 "sample.pptx" 的文件，其包含以下幻灯片：

![A presentation slide](slide_black_and_white.png)

下面的 C# 代码演示了如何将彩色幻灯片转换为黑白 TIFF：
```cs
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


结果：

![Black-and-White TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) 中提供的属性设置所需的值。例如，[ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) 属性允许您定义生成图像的尺寸。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义尺寸的 TIFF 图像：
```cs
// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 设置压缩类型。
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

    // 位深取决于压缩类型，无法手动设置。

    // 设置图像 DPI。
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 设置图像尺寸。
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 将演示文稿保存为指定尺寸的 TIFF。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```


## **将演示文稿转换为具有自定义像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) 类中的 [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) 属性，您可以为生成的 TIFF 图像指定首选的像素格式。

下面的 C# 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义像素格式的 TIFF 图像：
```cs
// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat 包含以下值（如文档所述）：
        Format1bppIndexed - 每像素 1 位，索引。
        Format4bppIndexed - 每像素 4 位，索引。
        Format8bppIndexed - 每像素 8 位，索引。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    // 将演示文稿保存为指定图像尺寸的 TIFF。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```


{{% alert title="Tip" color="primary" %}}
了解 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？**

可以。Aspose.Slides 允许您将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片分别转换为 TIFF 图像。

**在将演示文稿转换为 TIFF 时，幻灯片数量是否有限制？**

没有，Aspose.Slides 对幻灯片数量没有任何限制。您可以将任意规模的演示文稿转换为 TIFF 格式。

**在将幻灯片转换为 TIFF 时，PowerPoint 动画和转场效果是否会被保留？**

不会，TIFF 是一种静态图像格式。因此，动画和转场效果不会被保留；仅导出幻灯片的静态快照。