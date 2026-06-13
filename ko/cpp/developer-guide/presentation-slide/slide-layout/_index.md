---
title: C++에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/cpp/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 표시 여부
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 개의 내용
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 내용
- 캡션이 있는 그림
- 제목 및 수직 텍스트
- 수직 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 레이아웃을 관리하고 사용자 정의합니다. 레이아웃 유형, 자리표시자 제어 및 바닥글 표시 여부를 C++ 코드 예제를 통해 살펴보세요."
---
## **소개**

슬라이드 레이아웃은 슬라이드의 콘텐츠에 대한 자리표시자 상자와 서식 배치를 정의합니다. 어떤 자리표시자를 사용할 수 있는지와 그 위치를 제어합니다. 슬라이드 레이아웃을 사용하면 간단한 것이든 복잡한 것이든 프레젠테이션을 빠르고 일관되게 디자인할 수 있습니다. PowerPoint에서 가장 일반적인 슬라이드 레이아웃 중 일부는 다음과 같습니다:

**제목 슬라이드 레이아웃** – 제목과 부제목을 위한 두 개의 텍스트 자리표시자를 포함합니다.

**제목 및 내용 레이아웃** – 상단에 작은 제목 자리표시자가 있고, 그 아래에 텍스트, 글머리표, 차트, 이미지 등 주요 콘텐츠를 위한 더 큰 자리표시자가 있습니다.

**빈 레이아웃** – 자리표시자가 전혀 없어, 슬라이드를 처음부터 자유롭게 디자인할 수 있습니다.

슬라이드 레이아웃은 슬라이드 마스터의 일부이며, 슬라이드 마스터는 프레젠테이션의 레이아웃 스타일을 정의하는 최상위 슬라이드입니다. 레이아웃 슬라이드는 슬라이드 마스터를 통해 유형, 이름 또는 고유 ID로 접근하고 수정할 수 있습니다. 또는 프레젠테이션 내에서 특정 레이아웃 슬라이드를 직접 편집할 수 있습니다.

Aspose.Slides for Android에서 슬라이드 레이아웃을 작업하려면 다음을 사용할 수 있습니다:
- [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스 아래의 [get_LayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_layoutslides/) 및 [get_Masters](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_masters/)와 같은 메서드
- [ILayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/), 및 [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslideheaderfootermanager/)와 같은 형식

{{% alert title="Info" color="info" %}}
마스터 슬라이드 작업에 대해 자세히 알아보려면 [Slide Master](/slides/ko/cpp/slide-master/) 문서를 확인하세요.
{{% /alert %}}

## **프레젠테이션에 슬라이드 레이아웃 추가**

슬라이드의 모양과 구조를 사용자 정의하려면 프레젠테이션에 새로운 레이아웃 슬라이드를 추가해야 할 수 있습니다. Aspose.Slides for Android를 사용하면 특정 레이아웃이 이미 존재하는지 확인하고, 필요하면 새 레이아웃을 추가한 뒤 해당 레이아웃을 기반으로 슬라이드를 삽입할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterlayoutslidecollection/)에 접근합니다.
3. 원하는 레이아웃 슬라이드가 컬렉션에 이미 존재하는지 확인합니다. 존재하지 않으면 필요한 레이아웃 슬라이드를 추가합니다.
4. 새 레이아웃 슬라이드를 기반으로 빈 슬라이드를 추가합니다.
5. 프레젠테이션을 저장합니다.

다음 C++ 코드는 PowerPoint 프레젠테이션에 슬라이드 레이아웃을 추가하는 방법을 보여줍니다:

```cpp
// PowerPoint 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // 프레젠테이션에 모든 레이아웃 유형이 포함되지 않은 경우입니다.
    // 프레젠테이션 파일에는 Blank 및 Custom 레이아웃 유형만 포함되어 있습니다.
    // 그러나 사용자 정의 유형의 레이아웃 슬라이드에는 인식 가능한 이름이 있을 수 있습니다,
    // 예를 들어 "Title", "Title and Content" 등과 같이 레이아웃 슬라이드 선택에 사용할 수 있습니다.
    // 또한 자리표시자 도형 유형 집합에 의존할 수 있습니다.
    // 예를 들어, Title 슬라이드에는 Title 자리표시자 유형만 있어야 하며, 이와 같이 적용됩니다.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// 추가된 레이아웃 슬라이드를 사용하여 빈 슬라이드를 추가합니다.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// 프레젠테이션을 디스크에 저장합니다.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **사용되지 않는 레이아웃 슬라이드 제거**

Aspose.Slides는 [Compress](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/) 클래스의 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 메서드를 제공하여 원하지 않거나 사용되지 않은 레이아웃 슬라이드를 삭제할 수 있습니다.

다음 C++ 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **슬라이드 레이아웃에 자리표시자 추가**

Aspose.Slides는 레이아웃 슬라이드에 새로운 자리표시자를 추가할 수 있는 [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) 메서드를 제공합니다.

이 매니저는 다음 자리표시자 유형에 대한 메서드를 포함합니다:

| PowerPoint 자리표시자 | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutplaceholdermanager/) Method |
| ---------------------- | ------------------------------------------------------------ |
| ![내용](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![내용 (수직)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![텍스트](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![텍스트 (수직)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![그림](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![차트](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![표](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![스마트아트](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![미디어](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![온라인 이미지](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

다음 C++ 코드는 빈 레이아웃 슬라이드에 새로운 자리표시자 도형을 추가하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();

// Blank 레이아웃 슬라이드를 가져옵니다.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// 레이아웃 슬라이드의 자리표시자 관리자를 가져옵니다.
auto placeholderManager = layout->get_PlaceholderManager();

// Blank 레이아웃 슬라이드에 다양한 자리표시자를 추가합니다.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Blank 레이아웃을 사용하여 새 슬라이드를 추가합니다.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![레이아웃 슬라이드의 자리표시자](add_placeholders.png)

## **레이아웃 슬라이드의 바닥글 표시 여부 설정**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 지정 텍스트와 같은 바닥글 요소는 슬라이드 레이아웃에 따라 표시되거나 숨겨질 수 있습니다. Aspose.Slides for Android를 사용하면 이러한 바닥글 자리표시자의 표시 여부를 제어할 수 있습니다. 특정 레이아웃에서는 바닥글 정보를 표시하고, 다른 레이아웃은 깔끔하고 최소한으로 유지하고 싶을 때 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 레이아웃 슬라이드 참조를 가져옵니다.
3. 슬라이드 바닥글 자리표시자를 표시하도록 설정합니다.
4. 슬라이드 번호 자리표시자를 표시하도록 설정합니다.
5. 날짜‑시간 자리표시자를 표시하도록 설정합니다.
6. 프레젠테이션을 저장합니다.

다음 C++ 코드는 슬라이드 바닥글의 표시 여부를 설정하고 관련 작업을 수행하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **슬라이드의 자식 바닥글 표시 여부 설정**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 지정 텍스트와 같은 바닥글 요소는 모든 레이아웃 슬라이드에 일관성을 보장하기 위해 마스터 슬라이드 수준에서 제어될 수 있습니다. Aspose.Slides for Android는 마스터 슬라이드에서 이러한 바닥글 자리표시자의 표시 여부와 내용을 설정하고 이러한 설정을 모든 자식 레이아웃 슬라이드에 전파하도록 지원합니다. 이 접근 방식은 프레젠테이션 전체에 일관된 바닥글 정보를 보장합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스로 마스터 슬라이드에 대한 참조를 가져옵니다.
3. 마스터와 모든 자식 바닥글 자리표시자를 표시하도록 설정합니다.
4. 마스터와 모든 자식 슬라이드 번호 자리표시자를 표시하도록 설정합니다.
5. 마스터와 모든 자식 날짜‑시간 자리표시자를 표시하도록 설정합니다.
6. 프레젠테이션을 저장합니다.

다음 C++ 코드는 이 작업을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇인가요?**

마스터 슬라이드는 전체 테마와 기본 서식을 정의하고, 레이아웃 슬라이드는 다양한 콘텐츠 유형에 대한 특정 자리표시자 배치를 정의합니다.

**한 프레젠테이션의 레이아웃 슬라이드를 다른 프레젠테이션으로 복사할 수 있나요?**

예, 한 프레젠테이션의 레이아웃 슬라이드 컬렉션에서 [get_LayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_layoutslides/) 메서드로 접근 가능한 레이아웃 슬라이드를 복제하고, `AddClone` 메서드를 사용하여 다른 프레젠테이션에 삽입할 수 있습니다.

**슬라이드에서 아직 사용 중인 레이아웃 슬라이드를 삭제하면 어떻게 되나요?**

슬라이드에서 아직 사용 중인 레이아웃 슬라이드를 삭제하려고 하면 Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/cpp/aspose.slides/pptxeditexception/)을 발생시킵니다. 이를 방지하려면 사용되지 않은 레이아웃 슬라이드만 안전하게 제거하는 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)를 사용하십시오.