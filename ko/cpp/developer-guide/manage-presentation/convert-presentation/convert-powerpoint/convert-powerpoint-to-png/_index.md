---
title: C++에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/cpp/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for C++를 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 뒤 별도의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 스케일로 렌더링, 스케일 증가, 픽셀 단위로 출력 크기 지정, 그리고 그라디언트 렌더링 스타일 선택을 보여줍니다.

## **PowerPoint를 PNG로 변환**

프레젠테이션을 [프레젠테이션](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스 로드하고, [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 액세서를 통해 슬라이드에 접근합니다. 예제에서는 매개변수 없이 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 를 사용해 모든 슬라이드를 썸네일로 렌더링합니다. 그런 다음 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 에 [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) 를 사용해 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 오버로드는 0.2 스케일로 렌더링합니다. 예를 들어, 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래에 표시된 대로 스케일 계수 또는 명시적인 이미지 크기를 사용하는 오버로드를 사용하십시오.
{{% /alert %}}

## **PowerPoint를 PNG로 변환 (사용자 지정 차원)**

수평 및 수직 스케일 계수를 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 에 전달하여 렌더링 크기를 제어합니다. 이 예제에서는 두 계수가 모두 2이며, 따라서 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지가 됩니다. 동일한 스케일 계수는 슬라이드의 종횡비를 유지합니다. 각 이미지에는 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 를 사용해 PNG 형식으로 저장합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **PowerPoint를 PNG로 변환 (사용자 지정 크기)**

픽셀 단위로 출력 크기를 지정하려면 스케일 계수 대신 크기를 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 에 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 결과를 [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) 로 저장합니다. 이미지가 늘어나는 것을 방지하려면 슬라이드의 종횡비와 일치하는 크기를 선택하십시오.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만, 내보낸 PNG에서의 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 보인다고 가정해 보십시오. [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) 의 [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) 메서드를 사용하여 그라디언트가 렌더링되는 방식을 선택할 수 있습니다.

응용 프로그램 작업 디렉터리에 [gradient-styles.pptx](gradient-styles.pptx) 를 다운로드하고 배치하십시오. 첫 번째 슬라이드에는 두 개의 선형 그라디언트가 있습니다: 상단은 청록색에서 주황색으로, 하단은 파란색에서 노란색으로 변합니다. 각 그라디언트는 0%와 100%에 두 개의 정지점을 가집니다.

다음 예제는 이 프레젠테이션을 로드하고 [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) 을 사용해 동일한 첫 번째 슬라이드를 두 모드 모두에서 렌더링합니다.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

아래 이미지들은 동일한 슬라이드의 출력 결과를 보여주며, 각 이미지에 두 개의 그라디언트가 모두 포함됩니다:

| Default | PowerPointUI |
| --- | --- |
| ![기본값으로 렌더링된 청록색-주황색 및 파란색-노란색 그라디언트](gradient-Default.png) | ![PowerPointUI로 렌더링된 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 나오고, `PowerPointUI`는 중간 색상이 더 어둡게 나옵니다. 차이는 그라디언트의 색상과 정지점에 따라 달라집니다.

`Default`는 표준 Aspose.Slides 출력이 요구에 맞을 때 선택하십시오. PowerPoint와 외관을 일치시키는 것이 우선일 때는 `PowerPointUI`를 사용해 보세요. 두 출력 결과를 원하는 결과와 비교하십시오; 어느 모드도 보편적으로 더 우수하다고 할 수 없습니다.

## **FAQ**

**슬라이드 전체가 아니라 차트나 그림과 같은 특정 도형을 내보내려면 어떻게 해야 하나요?**  
Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/cpp/shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원됩니까?**  
예. 각 스레드 혹은 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오; [스레드 간에 단일 인스턴스를 공유하지 마십시오](/slides/ko/cpp/multithreading/).

**PNG로 내보낼 때 평가판 제한은 무엇입니까?**  
평가 모드에서는 출력 이미지에 워터마크가 추가되고 라이선스가 적용될 때까지 [다른 제한](/slides/ko/cpp/licensing/)이 적용됩니다.