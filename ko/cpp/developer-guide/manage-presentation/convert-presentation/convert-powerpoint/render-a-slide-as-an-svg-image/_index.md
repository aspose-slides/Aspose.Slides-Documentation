---
title: C++에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- SVG 내보내기 옵션
- 대화형 SVG
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "C++에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용하여 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로, 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides for C++는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 이미지 및 SVG 요소가 작성되는 방식을 제어할 수 있게 합니다.

Use [SVGOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **슬라이드를 SVG로 내보내기**

Create a [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [ISlide::get_SlideNumber](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/get_slidenumber/) rather than the loop index. You can also export an individual shape with [IShape::WriteAsSvg](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/writeassvg/) when a slide viewer or web page needs only that shape.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/) controls SVG rendering. For text frames, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_useframesize/) includes the text frame in the rendering area, and [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_useframerotation/) determines whether the frame rotation is applied. Set [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) to `true` when text must be rendered without ligatures.

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

## **텍스트 및 글꼴 제어**

### **전체 텍스트 벡터화**

Set [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

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

### **외부 글꼴 처리 방식 선택**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

## **내장 이미지 크기 축소**

Use [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_picturescompression/) to reduce the resolution of embedded pictures, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) to omit cropped source areas, and [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_jpegquality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **도형 및 텍스트에 안정적인 ID 할당**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshapeformattingcontroller/) to set [ISvgShape::set_Id](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshape/set_id/) for each SVG shape. To set [ISvgTSpan::set_Id](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgtspan/set_id/) values on text `tspan` elements as well, implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assign either controller with [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

The following controller uses [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_officeinteropshapeid/), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

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

## **SVG 이벤트 핸들러 추가**

In an [ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshapeformattingcontroller/), call [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/isvgshape/seteventhandler/) with a [SvgEvent](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) and define the JavaScript function in the page or SVG document that hosts the result.

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

## **FAQ**

**언제 [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 를 [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgexternalfontshandling/) 대신 사용해야 합니까?**

[SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) 는 모든 텍스트가 글꼴에 의존하지 않아야 할 때 사용합니다. [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgexternalfontshandling/) 는 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 때 사용합니다.

**SVG를 더 작게 만들기 위한 가장 좋은 방법은 무엇입니까?**

먼저 내장 이미지를 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 연결된 글꼴 파일을 선택합니다. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화는 각각 다른 품질 및 크기 균형을 가지므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있습니까?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.