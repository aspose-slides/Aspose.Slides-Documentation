---
title: 使用 JavaScript 将 PowerPoint 演示文稿转换为 TIFF
titlelink: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js，通过 JavaScript 示例代码，轻松将 PowerPoint（PPT、PPTX）演示文稿转换为高质量的 TIFF 图像。"
---
## **介绍**

TIFF (**Tagged Image File Format**) 是一种广泛使用的无损光栅图像格式，以其卓越的质量和对图形细节的完整保留而闻名。设计师、摄影师和桌面出版人员通常选择 TIFF，以在图像中保持图层、颜色精度和原始设置。

使用 Aspose.Slides，您可以轻松地将 PowerPoint 幻灯片（PPT、PPTX）和 OpenDocument 幻灯片（ODP）直接转换为高质量的 TIFF 图像，确保您的演示文稿保持最高的视觉保真度。

## **将演示文稿转换为 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类提供的 [save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应默认的幻灯片大小。

以下 JavaScript 代码演示了如何将 PowerPoint 演示文稿转换为 TIFF：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // 将演示文稿保存为 TIFF。
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **将演示文稿转换为黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类中，方法 [setBwConversionMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，此设置仅在 [setCompressionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) 方法设置为 `CCITT4` 或 `CCITT3` 时生效。

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 是一个导出级别的设置，用于为完整的 TIFF 图像选择像素转换算法。要定义在黑白显示模式下单个形状的呈现方式，请使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/#setBlackWhiteMode)。有关示例，请参阅 [Control Black-and-White Rendering for Shapes](/slides/zh/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假设我们有一个名为 "sample.pptx" 的文件，其包含以下幻灯片：

![演示文稿幻灯片](slide_black_and_white.png)

以下 JavaScript 代码演示了如何将彩色幻灯片转换为黑白 TIFF：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

结果：

![黑白 TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为自定义大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 中提供的方法设置所需的数值。例如，[setImageSize](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#setImageSize) 方法允许您定义生成图像的大小。

以下 JavaScript 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义大小的 TIFF 图像：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // 设置压缩类型。
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    压缩类型：
        Default - 指定默认的压缩方案（LZW）。
        None - 指定不使用压缩。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 颜色深度由像素格式控制（见下例）；CCITT3 和 CCITT4 始终产生每像素 1 位。

    // 设置图像 DPI。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 设置图像尺寸。
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 使用指定尺寸将演示文稿保存为 TIFF。
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **将演示文稿转换为具有自定义像素格式的 TIFF**

使用来自 [TiffOptions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/) 类的 [setPixelFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) 方法，您可以为生成的 TIFF 图像指定首选的像素格式。

以下 JavaScript 代码演示了如何将 PowerPoint 演示文稿转换为具有自定义像素格式的 TIFF 图像：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 实例化表示演示文稿文件（PPT、PPTX、ODP 等）的 Presentation 类。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat 包含以下值（如文档所述）：
        Format1bppIndexed - 每像素 1 位，索引模式。
        Format4bppIndexed - 每像素 4 位，索引模式。
        Format8bppIndexed - 每像素 8 位，索引模式。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    /// 将演示文稿保存为具有指定图像尺寸的 TIFF。
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
查看 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

**我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？**

可以。Aspose.Slides 允许您将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片分别转换为 TIFF 图像。

**在将演示文稿转换为 TIFF 时，幻灯片数量有限制吗？**

没有，Aspose.Slides 对幻灯片数量没有任何限制。您可以将任何规模的演示文稿转换为 TIFF 格式。

**在将幻灯片转换为 TIFF 时，PowerPoint 动画和过渡效果会被保留吗？**

不会，TIFF 是一种静态图像格式。因此，动画和过渡效果不会被保留；仅导出幻灯片的静态快照。