---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 TIFF
titlelink: PowerPoint 转 TIFF
type: docs
weight: 90
url: /zh/cpp/convert-powerpoint-to-tiff/
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
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 轻松将 PowerPoint (PPT, PPTX) 演示文稿转换为高质量的 TIFF 图像，并附有代码示例。"
---
## **简介**

TIFF (**Tagged Image File Format**) 是一种广泛使用的无损光栅图像格式，以其卓越的质量和对图形细节的完整保留而闻名。设计师、摄影师和桌面出版人员常常选择 TIFF 来保持图像的图层、色彩准确性和原始设置。

使用 Aspose.Slides，您可以轻松地将 PowerPoint 幻灯片 (PPT, PPTX) 和 OpenDocument 幻灯片 (ODP) 直接转换为高质量的 TIFF 图像，确保您的演示文稿保持最高的视觉保真度。

## **将演示文稿转换为 TIFF**

使用 [Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 方法，提供自 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类，您可以快速将整个 PowerPoint 演示文稿转换为 TIFF。生成的 TIFF 图像对应默认的幻灯片尺寸。

此 C++ 代码演示如何将 PowerPoint 演示文稿转换为 TIFF：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 实例化表示演示文件 (PPT, PPTX, ODP 等) 的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **将演示文稿转换为黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/) 类中，方法 [set_BwConversionMode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) 允许您指定在将彩色幻灯片或图像转换为黑白 TIFF 时使用的算法。请注意，仅当 [set_CompressionType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) 方法设置为 `CCITT4` 或 `CCITT3` 时，此设置才生效。

假设我们有一个名为 "sample.pptx" 的文件，其包含以下幻灯片：

![演示文稿幻灯片](slide_black_and_white.png)

此 C++ 代码演示如何将彩色幻灯片转换为黑白 TIFF：

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

结果：

![黑白 TIFF](TIFF_black_and_white.png)

## **将演示文稿转换为具有自定义尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 图像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/) 中提供的方法设置所需的值。例如，方法 [set_ImageSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/set_imagesize/) 允许您定义生成图像的尺寸。

此 C++ 代码演示如何将 PowerPoint 演示文稿转换为具有自定义尺寸的 TIFF 图像：

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 实例化表示演示文件 (PPT, PPTX, ODP 等) 的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// 设置压缩类型。
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
压缩类型:
    Default - 指定默认的压缩方案 (LZW)。
    None - 指定不使用压缩。
    CCITT3
    CCITT4
    LZW
    RLE
*/

// 深度取决于压缩类型，且不能手动设置。

// 设置图像 DPI。
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// 设置图像尺寸。
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// 使用指定尺寸将演示文稿保存为 TIFF。
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **将演示文稿转换为具有自定义像素格式的 TIFF**

使用来自 [TiffOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/) 类的 [set_PixelFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) 方法，您可以为生成的 TIFF 图像指定首选的像素格式。

此 C++ 代码演示如何将 PowerPoint 演示文稿转换为具有自定义像素格式的 TIFF 图像：

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 实例化表示演示文件 (PPT, PPTX, ODP 等) 的 Presentation 类。
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat 包含以下值（如文档所述）：
    Format1bppIndexed - 每像素 1 位，索引颜色。
    Format4bppIndexed - 每像素 4 位，索引颜色。
    Format8bppIndexed - 每像素 8 位，索引颜色。
    Format24bppRgb    - 每像素 24 位，RGB。
    Format32bppArgb   - 每像素 32 位，ARGB。
*/

// 使用指定的图像尺寸将演示文稿保存为 TIFF。
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
查看 Aspose 的 [免费 PowerPoint 转海报转换器](https://products.aspose.app/slides/zh/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常见问题**

### 我可以将单个幻灯片而不是整个 PowerPoint 演示文稿转换为 TIFF 吗？

是的。Aspose.Slides 允许您将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片分别转换为 TIFF 图像。

### 在将演示文稿转换为 TIFF 时，幻灯片数量是否有限制？

没有，Aspose.Slides 不对幻灯片数量施加任何限制。您可以将任意大小的演示文稿转换为 TIFF 格式。

### 在将幻灯片转换为 TIFF 时，PowerPoint 动画和转场效果会被保留吗？

不会，TIFF 是静态图像格式。因此，动画和转场效果不会被保留；仅导出幻灯片的静态快照。