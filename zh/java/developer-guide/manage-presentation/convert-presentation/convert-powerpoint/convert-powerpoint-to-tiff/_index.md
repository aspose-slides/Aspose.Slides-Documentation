---
title: 将 PowerPoint 转换为 TIFF
type: docs
weight: 90
url: /zh/java/convert-powerpoint-to-tiff/
keywords: "将 PowerPoint 演示文稿转换为 TIFF, PowerPoint 转 TIFF, PPT 转 TIFF, PPTX 转 TIFF, Java, Aspose.Slides"
description: "在 Java 中将 PowerPoint 演示文稿转换为 TIFF"

---

**TIFF**（标记图像文件格式）是一种无损的光栅和高质量图像格式。专业人士使用 TIFF 进行设计、摄影和桌面出版。例如，如果您想在设计或图像中保留图层和设置，您可能希望将您的工作保存为 TIFF 图像文件。 

Aspose.Slides 允许您将 PowerPoint 中的幻灯片直接转换为 TIFF。 

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose 的 [免费的 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **将 PowerPoint 转换为 TIFF**

使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类暴露的 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应于幻灯片的默认大小。 

以下 Java 代码向您展示如何将 PowerPoint 转换为 TIFF：

```java
// 实例化表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");
try {
    // 将演示文稿保存为 TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将 PowerPoint 转换为黑白 TIFF**

在 Aspose.Slides 23.10 中，Aspose.Slides 为 [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) 类添加了一个新属性 ([BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-))，允许您指定将彩色幻灯片或图像转换为黑白 TIFF 时所遵循的算法。请注意，此设置仅在 [CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) 属性设置为 `CCITT4` 或 `CCITT3` 时应用。

以下 Java 代码向您展示如何将彩色幻灯片或图像转换为黑白 TIFF：

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **将 PowerPoint 转换为具有自定义大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以通过 [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) 中提供的属性定义您的首选数字。例如，使用 [ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) 属性，可以为生成的图像设置大小。 

以下 Java 代码向您展示如何将 PowerPoint 转换为具有自定义大小的 TIFF 图像：

```java
// 实例化表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");
try {
    // 实例化 TiffOptions 类
    TiffOptions opts = new TiffOptions();
    
    // 设置压缩类型
    // 可能的值包括：
    // Default - 指定默认压缩方案（LZW）。
    // None - 指定无压缩。
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // 深度 - 取决于压缩类型，不能手动设置。
    
    // 设置图像 DPI
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // 设置图像大小
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // 将演示文稿保存为指定大小的 TIFF
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **将 PowerPoint 转换为具有自定义图像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) 类下的 [PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) 属性，您可以为生成的 TIFF 图像指定您的首选像素格式。 

以下 Java 代码向您展示如何将 PowerPoint 转换为具有自定义像素格式的 TIFF 图像：

```java
// 实例化表示演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat 包含以下值（如文档中所述）：
     * Format1bppIndexed; // 每个像素 1 位，索引。
     * Format4bppIndexed; // 每个像素 4 位，索引。
     * Format8bppIndexed; // 每个像素 8 位，索引。
     * Format24bppRgb;    // 每个像素 24 位，RGB。
     * Format32bppArgb;   // 每个像素 32 位，ARGB。
     */
    
    // 将演示文稿保存为指定图像大小的 TIFF
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```