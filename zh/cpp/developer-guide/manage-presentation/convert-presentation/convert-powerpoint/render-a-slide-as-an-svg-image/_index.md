---
title: 在 C++ 中将演示文稿幻灯片渲染为 SVG 图像
linktitle: 幻灯片转 SVG
type: docs
weight: 50
url: /zh/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 转 SVG
- 演示文稿 转 SVG
- 幻灯片 转 SVG
- PPT 转 SVG
- PPTX 转 SVG
- SVG 导出选项
- 交互式 SVG
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "在 C++ 中将 PowerPoint 幻灯片导出为 SVG 图像，并使用 Aspose.Slides 控制字体、文本、图像、ID 和事件。"
---
## **概述**

SVG 是一种基于 XML 的可伸缩图像格式，适用于网页发布、幻灯片查看器、无障碍工作流和自动后处理。Aspose.Slides for C++ 将每张幻灯片导出为单独的 SVG 文件，并允许您控制文本、字体、图片和 SVG 元素的写入方式。

Use [SVGOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **导出幻灯片为 SVG**

Create a [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [ISlide::get_SlideNumber](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/get_slidenumber/) rather than the loop index. You can also export an individual shape with [IShape::WriteAsSvg](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/writeassvg/) when a slide viewer or web page needs only that shape.

## **配置 SVG 输出**

[SVGOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/) controls SVG rendering. For text frames, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_useframesize/) includes the text frame in the rendering area, and [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determines whether the frame rotation is applied. Set [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) to `true` when text must be rendered without ligatures.

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

### **矢量化所有文本**

Set [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

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

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

Use [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_picturescompression/) to reduce the resolution of embedded pictures, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) to omit cropped source areas, and [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_jpegquality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **为形状和文本分配稳定的 ID**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgshapeformattingcontroller/) to set [ISvgShape::set_Id](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgshape/set_id/) for each SVG shape. To set [ISvgTSpan::set_Id](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgtspan/set_id/) values on text `tspan` elements as well, implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assign either controller with [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

The following controller uses [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_officeinteropshapeid/), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

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

In an [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgshapeformattingcontroller/), call [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/isvgshape/seteventhandler/) with a [SvgEvent](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) and define the JavaScript function in the page or SVG document that hosts the result.

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

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **常见问题**

**何时应该使用 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 而不是 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgexternalfontshandling/)？**

Use [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) when all text must be independent of fonts. Use [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**怎样才能让 SVG 更小？**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**导出后我可以修改 SVG 元素吗？**

Yes. Assign IDs through a formatting controller, then select the matching SVG elements in your post-processing tool or browser script.