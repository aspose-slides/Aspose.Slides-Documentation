---
title: 将 PowerPoint 转换为 TIFF
type: docs
weight: 90
url: /net/convert-powerpoint-to-tiff/
keywords: "将 PowerPoint 演示文稿转换为 TIFF, PowerPoint 转 TIFF, PPT 转 TIFF, PPTX 转 TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 TIFF。"

---

TIFF (**标签图像文件格式**) 是一种无损光栅图像格式，具有高质量。专业人士使用 TIFF 进行设计、摄影和桌面出版。例如，如果您想保留设计或图像中的图层和设置，可以将您的工作保存为 TIFF 图像文件。

Aspose.Slides 允许您直接将 PowerPoint 中的幻灯片转换为 TIFF。

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **将 PowerPoint 转换为 TIFF**

使用 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类提供的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应于幻灯片的默认大小。

以下 C# 代码演示如何将 PowerPoint 转换为 TIFF：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // 将演示文稿保存为 TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **将 PowerPoint 转换为黑白 TIFF**

在 Aspose.Slides 23.10 中，Aspose.Slides 添加了新的属性 ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) 到 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) 类，以允许您指定将彩色幻灯片或图像转换为黑白 TIFF 时遵循的算法。请注意，此设置仅在 [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) 属性设置为 `CCITT4` 或 `CCITT3` 时应用。

以下 C# 代码演示如何将彩色幻灯片或图像转换为黑白 TIFF：

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **将 PowerPoint 转换为自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以通过 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) 中提供的属性定义您喜欢的尺寸。使用 [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) 属性，您可以为生成的图像设置大小。

以下 C# 代码演示如何将 PowerPoint 转换为具有自定义大小的 TIFF 图像：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // 实例化 TiffOptions 类
    TiffOptions opts = new TiffOptions();

    // 设置压缩类型
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // 压缩类型

    // 默认 - 指定默认压缩方案 (LZW)。
    // 无 - 指定无压缩。
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // 深度取决于压缩类型，无法手动设置。
    // 分辨率单位始终等于“2”（每英寸点数）

    // 设置图像 DPI
    opts.DpiX = 200;
    opts.DpiY = 100;

    // 设置图像大小
    opts.ImageSize = new Size(1728, 1078);

    // 以指定大小将演示文稿保存为 TIFF
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **将 PowerPoint 转换为自定义图像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) 类中的 [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) 属性，您可以为生成的 TIFF 图像指定您喜欢的像素格式。

以下 C# 代码演示如何将 PowerPoint 转换为具有自定义像素格式的 TIFF 图像：

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat 包含以下值（如文档中所述）：
    Format1bppIndexed; // 每像素1位，索引化。
    Format4bppIndexed; // 每像素4位，索引化。
    Format8bppIndexed; // 每像素8位，索引化。
    Format24bppRgb; // 每像素24位，RGB。
    Format32bppArgb; // 每像素32位，ARGB。
    */

    // 以指定图像大小将演示文稿保存为 TIFF
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```