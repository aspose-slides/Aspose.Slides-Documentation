---
title: C++에서 프레젠테이션 효율적으로 병합
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/cpp/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하고 워크플로를 간소화합니다."
---
## **개요**

Aspose.Slides를 사용하면 하나의 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션에 병합할 수 있습니다. 이 문서에서는 전체 프레젠테이션 또는 선택된 슬라이드를 병합하는 방법, 병합 시 슬라이드 마스터 또는 특정 레이아웃을 사용하는 방법, 다른 슬라이드 크기를 가진 프레젠테이션을 처리하는 방법, 병합된 슬라이드를 프레젠테이션 섹션에 추가하는 방법을 설명합니다. 또한 연사 메모, 댓글, 비밀번호로 보호된 원본 파일, 스레드 사용과 관련된 실용적인 참고 사항도 다룹니다.

## **프레젠테이션 병합**

하나의 프레젠테이션을 다른 프레젠테이션에 병합하면 슬라이드가 하나의 프레젠테이션으로 결합되어 하나의 파일이 됩니다. 

{{% alert title="Info" color="info" %}}
대부분의 프레젠테이션 프로그램(PowerPoint 또는 OpenOffice)에는 사용자가 이러한 방식으로 프레젠테이션을 결합할 수 있는 기능이 없습니다. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/ko/cpp/)는 다양한 방법으로 프레젠테이션을 병합할 수 있게 해줍니다. 모양, 스타일, 텍스트, 서식, 댓글, 애니메이션 등을 모두 유지하면서 품질이나 데이터 손실에 대한 우려 없이 프레젠테이션을 병합할 수 있습니다. 

**또한 보기**

[슬라이드 복제](https://docs.aspose.com/slides/ko/cpp/clone-slides/)*.* 
{{% /alert %}}

### **병합할 수 있는 항목**

Aspose.Slides를 사용하면 다음을 병합할 수 있습니다.

* 전체 프레젠테이션. 모든 슬라이드가 하나의 프레젠테이션에 포함됩니다.
* 특정 슬라이드. 선택한 슬라이드만 하나의 프레젠테이션에 포함됩니다.
* 동일한 형식(PPT → PPT, PPTX → PPTX 등) 및 서로 다른 형식(PPT → PPTX, PPTX → ODP 등)의 프레젠테이션을 서로 병합합니다. 

{{% alert title="Note" color="warning" %}} 
프레젠테이션 외에도 Aspose.Slides는 다음 파일을 병합할 수 있습니다.

* [이미지](https://products.aspose.com/slides/ko/cpp/merger/image-to-image/), 예: [JPG → JPG](https://products.aspose.com/slides/ko/cpp/merger/jpg-to-jpg/) 또는 [PNG → PNG](https://products.aspose.com/slides/ko/cpp/merger/png-to-png/)
* 문서, 예: [PDF → PDF](https://products.aspose.com/slides/ko/cpp/merger/pdf-to-pdf/) 또는 [HTML → HTML](https://products.aspose.com/slides/ko/cpp/merger/html-to-html/)
* 서로 다른 두 파일, 예: [이미지 → PDF](https://products.aspose.com/slides/ko/cpp/merger/image-to-pdf/) 또는 [JPG → PDF](https://products.aspose.com/slides/ko/cpp/merger/jpg-to-pdf/) 또는 [TIFF → PDF](https://products.aspose.com/slides/ko/cpp/merger/tiff-to-pdf/). 
{{% /alert %}}

### **병합 옵션**

다음 옵션을 적용하여

* 출력 프레젠테이션의 각 슬라이드가 고유한 스타일을 유지하도록 하거나
* 모든 슬라이드에 동일한 스타일을 적용하도록 할 수 있습니다. 

프레젠테이션을 병합하려면 Aspose.Slides가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 메서드([ISlideCollection](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide_collection) 인터페이스)를 사용합니다. `AddClone` 메서드에는 병합 프로세스 매개변수를 정의하는 여러 구현이 있습니다. 모든 Presentation 객체는 [Slides](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) 컬렉션을 가지고 있으므로, 슬라이드를 병합하려는 프레젠테이션에서 `AddClone` 메서드를 호출하면 됩니다. 

`AddClone` 메서드는 소스 슬라이드의 복제본인 `ISlide` 객체를 반환합니다. 출력 프레젠테이션의 슬라이드는 단순히 소스 슬라이드의 복사본이므로, 원본 프레젠테이션에 영향을 주지 않고 결과 슬라이드에 스타일이나 서식 옵션, 레이아웃 등을 적용할 수 있습니다. 

## **프레젠테이션 병합** 

Aspose.Slides는 슬라이드가 레이아웃과 스타일을 유지하도록 하면서(slide retain their layouts and styles) 결합할 수 있는 [**AddClone (ISlide)**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) 메서드를 제공합니다(기본 매개변수). 

다음 C++ 코드가 프레젠테이션을 병합하는 방법을 보여줍니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **슬라이드 마스터와 함께 프레젠테이션 병합**

Aspose.Slides는 슬라이드 마스터 프레젠테이션 템플릿을 적용하면서 슬라이드를 결합할 수 있는 [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) 메서드를 제공합니다. 이를 통해 필요에 따라 출력 프레젠테이션의 슬라이드 스타일을 변경할 수 있습니다. 

다음 C++ 코드가 해당 작업을 시연합니다.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
슬라이드 마스터의 레이아웃은 자동으로 결정됩니다. 적절한 레이아웃을 결정할 수 없는 경우 `AddClone` 메서드의 `allowCloneMissingLayout` 불리언 매개변수를 true로 설정하면 소스 슬라이드의 레이아웃이 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d)이 발생합니다. 
{{% /alert %}}

출력 프레젠테이션의 슬라이드에 다른 레이아웃을 적용하려면 병합 시 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) 메서드를 사용하십시오. 

## **프레젠테이션에서 특정 슬라이드 병합**

여러 프레젠테이션에서 특정 슬라이드만 병합하면 맞춤형 슬라이드 덱을 만들 수 있습니다. Aspose.Slides C++는 필요한 슬라이드만 선택하여 가져올 수 있게 해줍니다. API는 원본 슬라이드의 서식, 레이아웃 및 디자인을 그대로 보존합니다.

다음 C++ 코드는 새 프레젠테이션을 생성하고 두 다른 프레젠테이션에서 제목 슬라이드를 추가한 뒤 파일로 저장합니다.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 위 코드에서 선언되었습니다.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **슬라이드 레이아웃과 함께 프레젠테이션 병합**

다음 C++ 코드는 프레젠테이션에서 슬라이드를 결합하면서 원하는 슬라이드 레이아웃을 적용하여 하나의 출력 프레젠테이션을 만드는 방법을 보여줍니다.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

{{% alert title="Note" color="warning" %}} 
다른 슬라이드 크기를 가진 프레젠테이션은 병합할 수 없습니다. 
{{% /alert %}}

두 프레젠테이션 중 하나의 크기를 다른 프레젠테이션에 맞게 조정한 후에야 병합할 수 있습니다. 

다음 샘플 코드는 이 작업을 시연합니다.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **프레젠테이션 섹션에 슬라이드 병합**

다음 C++ 코드는 특정 슬라이드를 프레젠테이션 섹션에 병합하는 방법을 보여줍니다.

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

슬라이드는 섹션 끝에 추가됩니다. 

{{% alert title="Tip" color="info" %}}
Aspose는 [무료 Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG → JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG → PNG 이미지를 병합하고, [포토 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

### 병합 시 연사 메모가 보존되나요?

예. 슬라이드를 복제하면 Aspose.Slides는 메모, 서식 및 애니메이션을 포함한 모든 슬라이드 요소를 그대로 전달합니다.

### 댓글 및 댓글 작성자가 전달되나요?

댓글은 슬라이드 콘텐츠의 일부로 복사되며, 댓글 작성자 라벨도 결과 프레젠테이션의 댓글 객체로 보존됩니다.

### 원본 프레젠테이션이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?

[LoadOptions::set_Password](https://reference.aspose.com/slides/ko/cpp/aspose.slides/loadoptions/set_password/)를 사용해 [/slides/ko/cpp/password-protected-presentation/](/slides/ko/cpp/password-protected-presentation/) 경로에서 비밀번호와 함께 열어야 합니다. 로드 후 해당 슬라이드를 보호되지 않은 대상 파일(또는 보호된 파일)로 안전하게 복제할 수 있습니다.

### 병합 작업은 스레드 안전한가요?

같은 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/cpp/multithreading/)에서 사용하지 마십시오. 권장 규칙은 “문서 하나당 스레드 하나”이며, 서로 다른 파일은 별도 스레드에서 병렬 처리할 수 있습니다.