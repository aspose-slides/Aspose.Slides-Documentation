---
title: 将 PowerPoint 转换为 TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-to-tiff/
keywords: "将 PowerPoint 演示文稿转换为 TIFF, PowerPoint 转 TIFF, PPT 转 TIFF, PPTX 转 TIFF, C++, CPP, Aspose.Slides"
description: "在 C++ 中将 PowerPoint 演示文稿转换为 TIFF"
---

**TIFF**（标记图像文件格式）是一种无损光栅和高质量图像格式。专业人士使用 TIFF 进行设计、摄影和桌面出版等工作。例如，如果您希望在设计或图像中保留图层和设置，则可以将工作另存为 TIFF 图像文件。

Aspose.Slides 允许您将 PowerPoint 中的幻灯片直接转换为 TIFF。

{{% alert title="提示" color="primary" %}}

您可以查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **将 PowerPoint 转换为 TIFF**

使用 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类提供的 [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 方法，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应于幻灯片的默认大小。

以下 C++ 代码演示如何将 PowerPoint 转换为 TIFF：

```c++
// 文档目录的路径。
String dataDir = GetDataPath();

// 实例化表示演示文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// 将演示文稿另存为 TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **将 PowerPoint 转换为黑白 TIFF**

在 Aspose.Slides 23.10 中，Aspose.Slides 向 [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) 类添加了一个新属性 ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/))，允许您指定将彩色幻灯片或图像转换为黑白 TIFF 时遵循的算法。请注意，此设置仅在 [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) 属性设置为 `CCITT4` 或 `CCITT3` 时应用。

以下 C++ 代码演示如何将彩色幻灯片或图像转换为黑白 TIFF：

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **将 PowerPoint 转换为具有自定义大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以通过 [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) 提供的属性定义您首选的尺寸。例如，通过 [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 属性，您可以为生成的图像设置大小。

以下 C++ 代码演示如何将 PowerPoint 转换为具有自定义大小的 TIFF 图像：

```c++
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示演示文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// 实例化 TiffOptions 类
auto opts = System::MakeObject<TiffOptions>();

// 设置压缩类型
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

// 设置图像 DPI
opts->set_DpiX(200);
opts->set_DpiY(100);

// 设置图像大小
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// 将演示文稿保存为具有指定大小的 TIFF
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **将 PowerPoint 转换为具有自定义图像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) 类下的 [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) 属性，您可以为生成的 TIFF 图像指定首选的像素格式。

以下 C++ 代码演示如何将 PowerPoint 转换为具有自定义像素格式的 TIFF 图像：

```c++
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示演示文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat 包含以下值（如文档中所示）：
Format1bppIndexed; // 1 位每像素，索引。
Format4bppIndexed; // 4 位每像素，索引。
Format8bppIndexed; // 8 位每像素，索引。
Format24bppRgb; // 24 位每像素，RGB。
Format32bppArgb; // 32 位每像素，ARGB。
*/

// 将演示文稿保存为具有指定大小的 TIFF
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```