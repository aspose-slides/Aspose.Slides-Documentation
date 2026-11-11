---
title: 在 C++ 中将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿转 SVG
- 幻灯片转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 C++ 中导出 PowerPoint 幻灯片为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种可伸缩的基于 XML 的图像格式，适用于 Web 发布、幻灯片查看器、可访问性工作流以及自动后处理。Aspose.Slides for C++ 将每张幻灯片导出为单独的 SVG 文件，并让您控制文本、字体、图片和 SVG 元素的写入方式。

当导出的 SVG 必须紧凑、在浏览器之间可预测或适用于交互式使用时，请使用 [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/)。

## **将幻灯片导出为 SVG**

创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)，选择一张幻灯片，并将其写入流。以下示例将演示文稿中的每张幻灯片导出为单独的 SVG 文件。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

文件名使用 [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) 而不是循环索引。当幻灯片查看器或网页只需要某个形状时，您也可以使用 [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) 导出单个形状。

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) 控制 SVG 渲染。对于文本框，[SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) 将文本框包含在渲染区域中，且[SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) 决定是否应用框的旋转。当文本必须在没有连字的情况下渲染时，将[SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) 设置为 `true`。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **控制文本和字体**

将幻灯片导出为 SVG 时，您可以控制文本是保持为文本还是转换为矢量图形，以及外部字体的包含或引用方式。以下选项帮助您在导出的 SVG 中平衡视觉一致性、文本选择以及字体依赖性。

### **矢量化所有文本**

将 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 设置为 `true`，即可将所有幻灯片文本写为矢量图形。这消除了字体依赖，使视觉结果在各浏览器之间更一致，但文本不再可作为 SVG 文本进行选择或搜索。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **选择外部字体的处理方式**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) 使用一个 [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) 值来处理外部加载的字体。选择 `AddLinksToFontFiles` 以引用单独的字体文件，`Embed` 将字体数据嵌入 SVG，或 `Vectorize` 将仅使用外部字体的文本渲染为图形。嵌入字体前请确认字体许可。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **减小嵌入图像大小**

使用 [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) 降低嵌入图片的分辨率，使用 [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) 省略裁剪后的源区域，使用 [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) 控制 JPEG 编码质量。这些设置会以图像保真度或保留图像数据为代价减小文件大小。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **控制元文件栅格化分辨率**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) 设置在 SVG 导出期间对元文件进行栅格化的最低分辨率限制。当对 EMF 或 WMF 图像进行栅格化时，可使用它来平衡细节与文件大小。它并未为 SVG 定义全局 DPI，也不会强制幻灯片上的每个对象都成为栅格图像。

下载 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含一张带有密集对角线的 EMF 图像。以下示例通过 [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/) 将其第一张幻灯片以三种栅格化分辨率导出。所有其他导出设置保持相同，以便对比结果。

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

在输出中，EMF 被转换为每个 SVG 中的一个嵌入 PNG。以下测量值对应提供的演示文稿；它们并非将 DPI 转换为像素尺寸的一般公式。

| 元文件栅格化 DPI | 嵌入 PNG 尺寸 | SVG 文件大小 (字节) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比较显示了相同区域的嵌入栅格在相同放大显示尺寸下的效果。对角线在 72 DPI 时显示可见的像素化，在更高分辨率下边缘更平滑，而 SVG 文件大小随之增长。增加该值并不一定能提升每个细节或改变每个导出图像。

![放大后的对角线细节（72、150 和 300 DPI）](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) 控制图像分辨率降低，可能掩盖更改元文件栅格化分辨率的效果。[SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) 控制 JPEG 编码质量，而非元文件栅格化分辨率。

## **为形状和文本分配稳定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 为每个 SVG 形状设置 [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/)。若还需为文本 `tspan` 元素设置 [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) 值，请实现 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/)。通过 [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) 分配任一控制器。

下面的控制器使用 [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/)，该 ID 在形状生命周期内保持稳定，并为其文本跨度使用可重复计数器。这使生成的 ID 适用于对未更改的演示文稿进行后处理。

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **添加 SVG 事件处理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) 中，调用 [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) 并传入 [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) 值，即可为导出的形状添加 JavaScript 事件处理程序。通过 [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) 分配该控制器，并在承载结果的页面或 SVG 文档中定义 JavaScript 函数。

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

宿主页面可以定义由处理程序引用的 JavaScript 函数。分配 ID 和事件处理程序可支持幻灯片查看器、可访问性增强以及其他交互式 SVG 工作流。

## **常见问题**

**何时应使用 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 而不是 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

当所有文本必须独立于字体时，请使用 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/)。当仅需将使用外部字体的文本转换为图形时，请使用 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)。

**如何使 SVG 更小？**

首先压缩嵌入的图片，删除裁剪的图像区域，并在目标环境能够提供时选择链接字体文件。测试结果，因为降低图像分辨率、降低 JPEG 质量以及矢量化文本各有不同的质量和体积权衡。

**导出后我可以修改 SVG 元素吗？**

可以。通过格式化控制器分配 ID，然后在后处理工具或浏览器脚本中选择匹配的 SVG 元素。