---
title: 将演示文稿幻灯片转换为 C++ 图像
linktitle: 幻灯片转图像
type: docs
weight: 41
url: /zh/cpp/convert-slide/
keywords:
- 转换幻灯片
- 导出幻灯片
- 幻灯片转图像
- 将幻灯片保存为图像
- 幻灯片转 EMF
- 幻灯片转 PNG
- 幻灯片转 JPEG
- 幻灯片转位图
- 幻灯片转 TIFF
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PPT、PPTX 和 ODP 演示文稿中的幻灯片转换为 PNG、JPEG、GIF、TIFF、EMF 等图像格式。"
---
## **简介**

Aspose.Slides for C++ 可以将 PowerPoint 和 OpenDocument 演示文稿中的单个幻灯片渲染为 PNG、JPEG、GIF、TIFF 等图像格式。

要将幻灯片转换为图像，请按以下步骤操作：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类加载演示文稿。
2. 选择要渲染的幻灯片。
3. 如有必要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/) 类配置渲染。
4. 调用 [ISlide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/getimage/) 方法。它返回一个 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象。
5. 调用 [IImage::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/save/) 方法，并使用 [ImageFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imageformat/) 值指定输出格式。

## **将幻灯片转换为 PNG 图像**

最简单的转换使用默认渲染设置。生成的 [IImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimage/) 对象可以在内存中处理或保存到文件。

以下 C++ 示例渲染第一张幻灯片并将其保存为 PNG 图像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **使用自定义尺寸将幻灯片转换为图像**

使用接受 [Size](https://reference.aspose.com/slides/zh/cpp/system.drawing/size/) 值的 [ISlide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/getimage/) 重载，以精确的像素尺寸渲染幻灯片。

以下示例创建 1820 × 1040 JPEG 图像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **将带有备注和批注的幻灯片转换为图像**

默认情况下，幻灯片图像不包含备注或批注。将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/) 对象分配给 [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) 方法，以控制备注和批注的显示位置。

以下示例在幻灯片下方放置截断的备注，并在右侧放置批注：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
对于幻灯片到图像的转换，请勿将 [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) 方法设置为 [BottomFull](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notespositions/)。备注的文字可能超出固定图像尺寸的容纳范围。请改用 [BottomTruncated](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notespositions/)。
{{% /alert %}}

## **使用 TIFF 选项将幻灯片转换为图像**

[TiffOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/tiffoptions/) 类允许您控制渲染的 TIFF 图像的大小、分辨率及其他属性。

以下示例将第一张幻灯片渲染为 2160 × 2880、300 DPI 的 TIFF 图像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **将所有幻灯片转换为图像**

遍历幻灯片集合，将整个演示文稿转换为一系列图像。除非显式跳过，否则会包括隐藏幻灯片。

以下示例以水平和垂直缩放因子 2 渲染每张幻灯片为 JPEG 图像：

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **创建增强型图元文件（EMF）输出**

增强型图元文件（EMF）在需要将基于矢量的图形与 Microsoft Office 或其他支持 Windows 图元文件的 Windows 应用程序交换时非常有用。与基于像素的图像不同，EMF 能保留矢量绘图操作，可在不损失锐度的情况下缩放。然而，EMF 主要是面向支持 Windows 图元文件的应用程序的兼容格式，而非通用的交换格式。此外，复杂的幻灯片内容（如位图图像和某些效果）可能会以栅格化元素的形式存储在矢量图元文件容器中。

### **导出幻灯片为 EMF**

[ISlide::WriteAsEmf](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/writeasemf/) 方法将 [ISlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/) 写入目标流的 EMF 格式。以下示例加载演示文稿，选择第一张幻灯片，并将其写入 EMF 文件流：

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

调用方拥有传递给 [ISlide::WriteAsEmf](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/writeasemf/) 的流，并必须关闭或释放该流。Aspose.Slides 在流的当前位置写入数据并保持流打开。

### **将 SVG 图像转换为 EMF 并添加到演示文稿**

使用 [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/writeasemf/) 将 SVG 内容转换为 EMF。生成的字节可通过 [IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/) 添加到演示文稿，并使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides.ishapecollection/addpictureframe/) 放置在幻灯片上。

以下示例从 SVG 标记创建 [SvgImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/svgimage/)，将其转换为内存中的 EMF，将该图元文件插入第一张幻灯片，并保存演示文稿：

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/zh/cpp/aspose.slides/isvgimage/writeasemf/) 不会获取目标流的所有权。写入后，流位置位于生成数据的末端。示例调用 [MemoryStream::ToArray](https://reference.aspose.com/slides/zh/cpp/system.io/memorystream/toarray/) 获取完整缓冲区，而不受当前流位置的影响，然后将该字节数组传递给 [IImageCollection::AddImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iimagecollection/addimage/)。在消费者读取完毕之前保持流打开，之后再关闭。

EMF 生成功能在 Aspose.Slides for C++ 支持的操作系统上可用，但在缺少字体或本机图形依赖项的平台上渲染可能会有所差异。请安装源内容使用的字体或配置合适的替代方案，遵循 Aspose.Slides for C++ 的 [平台要求](/slides/zh/cpp/system-requirements/)，并在目标 EMF 消费应用中验证结果。Linux 和 macOS 应用通常对显示和编辑 Windows 图元文件的支持有限或不一致。

## **彩色表情符号渲染**

{{% alert title="Note" color="info" %}}
在将演示文稿幻灯片转换为图像时正确渲染彩色表情符号，必须在执行转换的系统上安装并可用演示文稿中使用的表情符号字体。例如，若演示文稿使用 **Segoe UI Emoji** 且该字体缺失，输出图像中的表情符号可能会以单色显示。
{{% /alert %}}

## **常见问题**

**Aspose.Slides 是否支持渲染带有动画的幻灯片？**

不支持。[ISlide::GetImage](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/getimage/) 方法渲染幻灯片的静态图像，并不导出动画。

**隐藏的幻灯片可以导出为图像吗？**

可以。隐藏的幻灯片可以像普通幻灯片一样渲染。请在处理循环中包含它们，如上例所示。

**幻灯片图像中会保留阴影和其他效果吗？**

会。Aspose.Slides 在幻灯片图像中渲染阴影、透明度以及其他受支持的图形效果。