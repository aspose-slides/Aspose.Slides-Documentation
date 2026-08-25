---
title: C++를 사용한 프레젠테이션에서 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 100
url: /ko/cpp/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- 섹션 슬라이드 가져오기
- 섹션 슬라이드 처리
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용해 슬라이드 섹션을 관리합니다: PPTX 프레젠테이션에서 섹션 슬라이드를 만들고, 이름을 바꾸고, 순서를 재배열하고, 가져오며, 처리합니다."
---
## **소개**

섹션은 슬라이드 내용을 변경하지 않고 연속된 슬라이드를 명명된 그룹으로 조직합니다. Aspose.Slides for C++를 사용하면 [Presentation::get_Sections](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sections/) 메서드를 통해 섹션을 만들고, 순서를 바꾸고, 이름을 바꾸고, 검사하고, 제거할 수 있습니다.

섹션은 특히 다음과 같은 경우에 유용합니다:

- 큰 프레젠테이션을 논리적 주제나 장으로 나눌 필요가 있을 때;
- 서로 다른 슬라이드 그룹을 다른 협업자에게 할당할 때;
- 슬라이드를 그룹으로 처리, 이동 또는 병합해야 할 때.

그룹화된 슬라이드의 목적을 설명하는 간결한 섹션 이름을 선택하십시오. 섹션은 프레젠테이션 구조의 일부이므로 슬라이드 위치에서 유도하기보다 섹션 API를 사용해 멤버십을 결정하십시오.

## **섹션 만들기 및 관리**

섹션을 만들려면 이름과 시작 슬라이드를 지정하여 [ISectionCollection::AddSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/addsection/) 를 사용합니다. Aspose.Slides는 현재 프레젠테이션의 섹션 구조를 기반으로 해당 섹션에 속하는 슬라이드를 결정합니다.

같은 [ISectionCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/) 를 사용하여 다음 작업도 할 수 있습니다:

- 슬라이드와 함께 섹션을 이동하려면 [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) 를 사용합니다;
- 섹션 정의만 제거하려면 [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/removesection/) 를 사용하며, 이 경우 슬라이드는 유지됩니다;
- 섹션과 해당 슬라이드를 모두 제거하려면 [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/removesectionwithslides/) 를 사용합니다;
- 끝에 빈 섹션을 추가하려면 [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/appendemptysection/) 를 사용합니다.

다음 예제는 두 개의 섹션을 만들고, 그중 하나를 이동한 뒤 슬라이드와 함께 제거하고, 빈 섹션을 추가합니다:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

이러한 작업 후 프레젠테이션에는 `Introduction` 섹션과 해당 슬라이드, 그리고 빈 `Appendix` 섹션이 남습니다. `Results` 섹션과 그 슬라이드는 제거되었습니다.

## **섹션 이름 바꾸기**

섹션 이름을 바꾸려면 [ISection::set_Name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/set_name/) 를 호출합니다. 섹션의 슬라이드와 위치는 그대로 유지됩니다.

다음 예제는 섹션을 만들고 이름을 변경합니다:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **섹션에서 슬라이드 검색**

[Presentation::get_Sections](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sections/) 메서드는 열거할 수 있는 [ISectionCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectioncollection/) 을 반환합니다. 각 [ISection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/) 에 대해 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/getslideslistofsection/) 을 호출하면 현재 해당 섹션에 포함된 슬라이드를 얻을 수 있습니다. 이 메서드는 슬라이드 수, 인덱스 접근 및 열거를 제공하는 [ISectionSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isectionslidecollection/) 을 반환합니다.

다음 예제는 두 개의 채워진 섹션과 하나의 빈 섹션을 만든 뒤 각 섹션의 [name](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/get_name/), [identifier](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/get_sectionid/), [starting slide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/get_startedfromslide/), 슬라이드 수 및 슬라이드 번호를 출력합니다. 인덱스 접근을 사용해 첫 번째 슬라이드를 읽고, 범위 기반 `for` 루프를 사용해 모든 슬라이드를 처리합니다. 빈 섹션의 경우 반환된 컬렉션은 카운트가 0이며, 인덱스 접근은 사용되지 않고 열거도 반복되지 않습니다:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

섹션 멤버십은 프레젠테이션의 섹션 구조에 따라 결정됩니다. [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/get_startedfromslide/) 및 다음 섹션의 시작 슬라이드 등을 기반으로 섹션 범위를 수동으로 계산하지 마십시오.

구조적 편집은 섹션에 대해 반환되는 슬라이드와 슬라이드 번호 모두를 변경할 수 있습니다. 여기에는 슬라이드 순서 재배열, 슬라이드 복제, 섹션과 슬라이드 이동, 슬라이드 삭제, 섹션 삭제가 포함됩니다. 다음 예제는 이러한 변경이 발생할 때마다 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/getslideslistofsection/) 을 호출하여 이전 경계에 대한 가정을 유지하지 않습니다:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

슬라이드나 섹션이 재정렬, 복제, 이동 또는 삭제될 때마다 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/getslideslistofsection/) 을 다시 호출하십시오. 이렇게 하면 이후 처리가 현재 프레젠테이션 구조와 일치합니다.

PPT (PowerPoint 97–2003) 형식은 섹션 메타데이터를 보존하지 않습니다. 섹션을 지원하는 형식(PPTX 등)으로 작업하고, PPT 로 변환하면 이후 열거에 필요한 섹션 구조가 손실됩니다.

## **FAQ**

**PPT (PowerPoint 97–2003) 형식으로 저장할 때 섹션이 보존되나요?**

아니요. PPT 형식은 섹션 메타데이터를 지원하지 않으므로 .ppt 로 저장하면 섹션 그룹화가 손실됩니다.

**전체 섹션을 “숨길” 수 있나요?**

아니요. 섹션 자체에 가시성 상태가 없습니다. 섹션의 내용을 숨기려면 해당 섹션에 포함된 각 슬라이드에 대해 [ISlide::set_Hidden](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/set_hidden/) 를 호출하십시오.

**슬라이드를 포함하는 섹션을 어떻게 찾을 수 있나요?**

[Presentation::get_Sections](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_sections/) 을 열거하고, 각 섹션에 대해 [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/getslideslistofsection/) 를 호출한 뒤 반환된 슬라이드와 목표 슬라이드를 비교하십시오. 비어 있지 않은 섹션의 경우 [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isection/get_startedfromslide/) 은 첫 슬라이드를 반환하고, 빈 섹션의 경우 `nullptr` 을 반환합니다.