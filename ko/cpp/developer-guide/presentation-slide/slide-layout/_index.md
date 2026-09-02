---
title: C++에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/cpp/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리 표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 푸터 가시성
- 제목 슬라이드
- 제목 및 콘텐츠
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 세로 텍스트
- 세로 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 레이아웃을 적용하고, 생성하며, 수정하고, 자리 표시자를 추가하고, 사용되지 않은 레이아웃을 제거하며, 푸터 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리 표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 유지하면서 각 슬라이드에 고유한 내용을 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **Title Slide**: 제목 및 부제목 자리 표시자를 포함합니다.
- **Title and Content**: 제목 자리 표시자와 일반용 콘텐츠 자리 표시자를 포함합니다.
- **Blank**: 콘텐츠 자리 표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션에는 세 가지 관련 수준이 있습니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/)는 테마, 공유 서식, 배경 및 공통 개체를 정의합니다.
1. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/)는 마스터에 속하고 자리 표시자의 특정 배치를 정의합니다.
1. A [일반 슬라이드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/)는 하나의 레이아웃을 사용하고 해당 슬라이드에 입력된 내용을 저장합니다.

일반 슬라이드는 레이아웃으로부터 테마와 서식을 상속받으며, 레이아웃은 마스터로부터 상속받습니다. 일반 슬라이드에 직접 설정된 값은 해당 레벨에서 상속된 값을 덮어씁니다. 일반 슬라이드가 생성될 때, 해당 슬라이드의 자리 표시자 도형은 선택된 레이아웃에서 생성되며, 그 자리 표시자에 입력된 내용은 일반 슬라이드에 속합니다.

레이아웃을 만들기 전에 필요한 자리 표시자를 추가하십시오. 레이아웃에 나중에 다른 자리 표시자를 추가해도 기존 일반 슬라이드에 자동으로 해당 자리 표시자 도형이 추가되지는 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃에서 상속된 서식이나 기존 자리 표시자 기하학을 변경하면 해당 레이아웃에 의존하는 모든 슬라이드가 업데이트될 수 있습니다. 이미 사용 중인 레이아웃을 편집하기 전에 종속 슬라이드를 확인하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드가 아직 사용 중인 레이아웃은 제거할 수 없습니다. 먼저 해당 레이아웃의 종속 슬라이드를 다른 레이아웃으로 재할당하거나 사용되지 않는 레이아웃만 제거하십시오.

이 계층 구조의 최상위 수준에 대한 자세한 내용은 [슬라이드 마스터](/slides/ko/cpp/slide-master/)를 참조하세요.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따를 때 레이아웃 유형을 사용하십시오. 레이아웃 이름은 사용자가 편집 가능하고 현지화될 수 있으므로, 원본 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 떨어집니다.

다음 예제는 첫 번째 마스터에서 **Title and Content**를 찾습니다. 해당 레이아웃이 없으면 의도적으로 **Blank**로 대체합니다. 두 번째 null 검사는 프레젠테이션에 사용자 정의 레이아웃만 포함될 수 있기 때문에 필요합니다. 선택된 레이아웃은 [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/set_layoutslide/) 메서드를 통해 첫 번째 일반 슬라이드에 적용됩니다.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

슬라이드의 레이아웃을 변경해도 슬라이드에 직접 추가된 일반 도형은 제거되지 않습니다. 그러나 자리 표시자 위치, 상속된 서식 및 기존 자리 표시자와 새 레이아웃 간의 대응 관계가 변경될 수 있으므로, 크게 다른 레이아웃 간 전환 시 출력물을 검사하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성은 별개의 작업입니다. 이전 예제는 기존 레이아웃을 선택했을 뿐 생성하지는 않았습니다. 레이아웃을 생성하려면 대상 마스터의 레이아웃 컬렉션에 대해 [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterlayoutslidecollection/add/) 메서드를 호출하십시오.

다음 예제는 항상 `Report Title and Content`라는 이름의 새 **Title and Content** 레이아웃을 추가하고, 이를 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

템플릿에 실제로 추가 재사용 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재한다면 중복을 만들기보다 선택하여 재사용하십시오.

## **레이아웃 슬라이드에 자리 표시자 추가**

[ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 메서드는 레이아웃에 자리 표시자 도형을 추가하기 위한 [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/)를 제공합니다.

| PowerPoint 자리 표시자 | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![Content](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

다음 예제는 **Blank** 레이아웃이 존재하는지 확인하고, 네 개의 자리 표시자를 추가한 뒤 수정된 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도된 것으로, 자리 표시자를 먼저 추가해야 Aspose.Slides가 해당 슬라이드에 대응하는 자리 표시자 도형을 생성할 수 있습니다.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![레이아웃 슬라이드의 자리 표시자](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
상속된 서식이나 기존 레이아웃 자리 표시자의 기하학을 변경하면 종속 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 자리 표시자는 기존 일반 슬라이드에 자동으로 채워지지 않습니다. 프레젠테이션 복사본에서 레이아웃 변경을 테스트하고 모든 종속 슬라이드를 검사하십시오.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

[Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 메서드를 사용하여 일반 슬라이드가 참조하지 않는 레이아웃을 제거하십시오. 이 메서드는 여전히 사용 중인 레이아웃은 그대로 유지합니다.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

특정 레이아웃 하나를 제거하려면 먼저 해당 레이아웃의 [get_HasDependingSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) 메서드 또는 [GetDependingSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/getdependingslides/) 메서드를 사용하십시오. [ILayoutSlide::Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/remove/) 를 호출하기 전에 모든 종속 슬라이드를 재할당하십시오. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxeditexception/) 이 발생합니다.

## **레이아웃 슬라이드에서 푸터 가시성 제어**

레이아웃은 자체 푸터, 슬라이드 번호 및 날짜‑시간 자리 표시자를 갖습니다. 해당 레이아웃의 이러한 자리 표시자를 제어하려면 [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) 메서드를 사용하십시오. 예를 들어 콘텐츠 레이아웃은 푸터를 표시하고 제목 레이아웃은 표시하지 않아야 할 때 유용합니다.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **마스터 및 하위 레이아웃에서 푸터 가시성 제어**

마스터 계층 전체에 일관된 푸터 설정을 적용하려면 [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/get_headerfootermanager/) 메서드를 사용하십시오. [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslideheaderfootermanager/) 의 전파 메서드는 마스터와 해당 종속 레이아웃 슬라이드 및 일반 슬라이드에 적용되며, 단일 일반 슬라이드만 대상으로 하지 않습니다.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇인가요?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 서식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 하나의 재사용 가능한 자리 표시자 배치를 정의합니다. 일반 슬라이드는 이러한 레이아웃을 사용하고 슬라이드별 콘텐츠를 저장합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있나요?**

네. [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/ko/cpp/aspose.slides/igloballayoutslidecollection/addclone/) 메서드를 사용하여 대상 컬렉션에 복제본을 추가하십시오. 프레젠테이션 간 복사 시 원본 레이아웃이 사용하는 글꼴, 테마, 이미지 및 기타 리소스도 확인해야 합니다.

**이미 사용 중인 레이아웃을 수정하면 어떻게 되나요?**

종속 슬라이드는 해당 레이아웃 변경을 상속받으며, 로컬에서 서식이나 객체를 오버라이드하지 않은 경우 일괄적으로 업데이트됩니다. 자리 표시자 기하학 및 상속된 스타일이 많은 슬라이드에 동시에 변경될 수 있으므로, 레이아웃을 편집하기 전에 [GetDependingSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/getdependingslides/) 로 영향을 받는 슬라이드를 식별하십시오.

**여전히 사용 중인 레이아웃을 제거하면 어떻게 되나요?**

Aspose.Slides 가 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxeditexception/) 을 발생시킵니다. 먼저 종속 슬라이드를 다른 레이아웃으로 재할당하거나, [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 를 사용해 참조되지 않은 레이아웃만 제거하십시오.