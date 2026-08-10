---
title: C++에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/cpp/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- 잉크 내보내기
- 잉크 렌더링
- 잉크 숨기기
- IInkOptions
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 잉크 개체를 관리하고, 트레이스와 브러시 속성을 편집하며, PDF, HTML, SVG, TIFF 및 이미지 내보내기 동안 잉크 모양을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하거나, 연결 및 프로세스를 나타내며, 슬라이드의 특정 항목에 주의를 끌 때 사용할 수 있습니다.

[Aspose.Slides.Ink](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/) 네임스페이스에는 잉크 개체 작업에 필요한 클래스와 인터페이스가 들어 있습니다. 예를 들어, [IInk](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iink/) 인터페이스는 슬라이드상의 잉크 개체를 나타냅니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 Shape 개체로 표시됩니다. 가장 단순한 형태의 Shape는 개체 자체(프레임)의 영역을 정의하는 컨테이너이며, 컨테이너 크기, 모양, 배경과 같은 속성을 포함합니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/cpp/shape-manipulations/#access-layout-formats-for-shape) 을 참조하십시오.

그러나 PowerPoint가 잉크 개체를 처리할 때는 프레임(컨테이너)의 모든 속성을 무시하고 크기만 사용합니다. 컨테이너 영역의 크기는 표준 [IShape::get_Width](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_width/) 및 [IShape::get_Height](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_height/) 메서드에 의해 결정됩니다.

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 작성할 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 시퀀스를 저장합니다.

가장 단순한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다.

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시는 자체 색상과 크기를 가지며, 이는 [IInkBrush::get_Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iinkbrush/get_color/) 및 [IInkBrush::get_Size](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iinkbrush/get_size/) 메서드로 접근합니다.

### **잉크 브러시 색상 설정**

다음 C++ 코드는 잉크 브러시의 색상을 설정하는 방법을 보여 줍니다:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **잉크 브러시 크기 설정**

다음 C++ 코드는 잉크 브러시의 크기를 설정하는 방법을 보여 줍니다:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

일반적으로 브러시의 너비와 높이는 일치하지 않으며, 이 경우 PowerPoint에서는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됨). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 개체의 높이를 늘리고 주요 차원을 살펴보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며 항상 선 두께가 0이라고 가정합니다(이전 이미지를 참조).

따라서 전체 잉크 개체의 가시 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서는 대상 개체(손글씨 텍스트 트레이스)가 컨테이너(프레임)의 크기에 맞게 스케일링되었습니다. 컨테이너 크기가 변경되면 브러시 크기는 그대로 유지되고, 반대로도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 개체에도 유사한 동작을 적용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 모양 제어**

Aspose.Slides는 [IInkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/) 인터페이스를 제공하여 내보내기 또는 렌더링된 출력에서 잉크 개체가 어떻게 표시될지 제어할 수 있습니다. 이 인터페이스의 메서드를 사용해 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산 해석 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 형식에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 메서드 |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| 슬라이드 이미지 | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

이 메서드들을 통해 사용할 수 있는 두 가지 설정은 다음과 같습니다:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_hideink/) 은 잉크 개체를 출력에 포함시킬지 여부를 결정합니다. 기본값은 `false` 입니다.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 은 잉크 브러시를 렌더링할 때 마스크 연산을 불투명도로 해석할지 여부를 결정합니다. 기본값은 `true`이며, `false` 로 설정하면 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 개체 숨기기**

기본적으로 잉크 개체는 내보내기 시 보입니다. 손글씨 주석이나 기타 잉크 콘텐츠 없이 깔끔한 출력을 원한다면 `true` 로 [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_hideink/) 을 호출하십시오.

다음 C++ 예제는 모든 잉크 개체를 숨긴 채 프레젠테이션을 PDF 로 내보냅니다:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **슬라이드를 이미지로 렌더링할 때 잉크 개체 숨기기**

슬라이드를 비트맵 이미지로 렌더링할 때 잉크 개체를 숨기려면 [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) 를 구성하고 해당 렌더링 옵션을 [ISlide::GetImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/getimage/) 메서드에 전달하십시오.

다음 C++ 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 개체를 제외합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **잉크 마스크 렌더링 제어**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) 메서드는 잉크 브러시를 렌더링할 때 마스크 연산을 어떻게 해석할지 제어합니다. 기본값은 `true`이며 불투명도를 사용합니다. `false` 로 호출하면 ROP 연산을 사용합니다.

다음 C++ 예제는 슬라이드를 SVG 로 내보내고 잉크 마스크 연산에 ROP 기반 렌더링을 적용합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

같은 설정은 프레젠테이션을 내보내거나 슬라이드를 TIFF 로 렌더링할 때 [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) 를 통해 적용할 수 있습니다.

### **잉크를 숨길지 보존할지 선택**

주석이 포함된 프레젠테이션의 정리된 버전을 내보내야 하는 경우(예: 배포용 최종 사본) `true` 로 [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_hideink/) 을 사용하십시오.

잉크 주석이 의도된 콘텐츠의 일부인 경우(리뷰 코멘트, 손글씨 메모, 강조 표시 또는 그림 등) 기본값인 `false` 로 두어 잉크를 그대로 표시하십시오. 이렇게 하면 동일한 프레젠테이션에서 소스 잉크 개체를 수정하지 않고도 별도의 리뷰 및 최종 출력물을 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예 가능합니다. [IInk::get_Traces](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iink/get_traces/) 로 트레이스를 가져온 다음 해당 트레이스의 [IInkTrace::get_Brush](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iinktrace/get_brush/) 를 변경하십시오. 브러시에서 [IInkBrush::set_Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iinkbrush/set_color/) 및 [IInkBrush::set_Size](https://reference.aspose.com/slides/ko/cpp/aspose.slides.ink/iinkbrush/set_size/) 를 호출하면 됩니다.

**잉크를 숨기면 원본 프레젠테이션이 변경되나요?**

아니요. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/iinkoptions/set_hideink/) 은 렌더링 혹은 내보내기 결과에만 영향을 미치며, 원본 프레젠테이션의 잉크 개체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

위 표에 나열된 PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지 형식에 대해 잉크 옵션을 구성할 수 있습니다.

**추가 자료**

* 일반적인 Shape에 대해 알아보려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/cpp/powerpoint-shapes/) 섹션을 참조하십시오.
* 유효값에 대해 자세히 보려면 [Shape Effective Properties](https://docs.aspose.com/slides/ko/cpp/shape-effective-properties/#get-effective-font-height-value) 를 살펴보세요.
* PDF 내보내기에 대해서는 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/cpp/convert-powerpoint-to-pdf/) 를 참고하십시오.
* HTML 내보내기에 대해서는 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/cpp/convert-powerpoint-to-html/) 를 참고하십시오.
* SVG 내보내기에 대해서는 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/cpp/render-a-slide-as-an-svg-image/) 를 참고하십시오.
* TIFF 내보내기에 대해서는 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/cpp/convert-powerpoint-to-tiff/) 를 참고하십시오.
* 슬라이드 이미지 렌더링에 대해서는 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/cpp/convert-slide/) 를 참고하십시오.