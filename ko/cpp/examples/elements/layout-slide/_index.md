---
title: 레이아웃 슬라이드
type: docs
weight: 20
url: /ko/cpp/examples/elements/layout-slide/
keywords:
- 코드 예제
- 레이아웃 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 마스터 레이아웃 슬라이드: PPT, PPTX 및 ODP 프레젠테이션을 위한 C++ 예제로 슬라이드 레이아웃, 플레이스홀더 및 마스터를 선택, 적용 및 사용자 지정합니다."
---
이 문서에서는 C++용 Aspose.Slides의 **Layout Slides** 사용 방법을 보여줍니다. 레이아웃 슬라이드는 일반 슬라이드가 상속받는 디자인과 서식을 정의합니다. 레이아웃 슬라이드를 추가, 액세스, 복제 및 제거할 수 있으며, 사용되지 않는 레이아웃 슬라이드를 정리하여 프레젠테이션 크기를 줄일 수 있습니다.

## **레이아웃 슬라이드 추가**

재사용 가능한 서식을 정의하기 위해 사용자 지정 레이아웃 슬라이드를 만들 수 있습니다. 예를 들어, 이 레이아웃을 사용하는 모든 슬라이드에 표시되는 텍스트 상자를 추가할 수 있습니다.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // 빈 레이아웃 유형과 사용자 지정 이름으로 레이아웃 슬라이드를 생성합니다.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // 레이아웃 슬라이드에 텍스트 상자를 추가합니다.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // 이 레이아웃을 사용하여 두 개의 슬라이드를 추가합니다; 두 슬라이드 모두 레이아웃의 텍스트를 상속합니다.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** 레이아웃 슬라이드는 개별 슬라이드의 템플릿 역할을 합니다. 공통 요소를 한 번 정의하고 여러 슬라이드에서 재사용할 수 있습니다.

> 💡 **Note 2:** 레이아웃 슬라이드에 도형이나 텍스트를 추가하면 해당 레이아웃을 기반으로 하는 모든 슬라이드가 이 공유 콘텐츠를 자동으로 표시합니다.  
> 아래 스크린샷은 동일한 레이아웃 슬라이드에서 텍스트 상자를 상속받은 두 개의 슬라이드를 보여줍니다.

![레이아웃 콘텐츠를 상속하는 슬라이드](layout-slide-result.png)

## **레이아웃 슬라이드 액세스**

레이아웃 슬라이드는 인덱스 또는 레이아웃 유형(예: `Blank`, `Title`, `SectionHeader` 등)으로 액세스할 수 있습니다.

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 인덱스로 레이아웃 슬라이드에 접근합니다.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // 유형으로 레이아웃 슬라이드에 접근합니다.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **레이아웃 슬라이드 제거**

더 이상 필요하지 않은 경우 특정 레이아웃 슬라이드를 제거할 수 있습니다.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 유형으로 레이아웃 슬라이드를 가져와서 제거합니다.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **사용되지 않는 레이아웃 슬라이드 제거**

프레젠테이션 크기를 줄이기 위해 일반 슬라이드에서 사용되지 않는 레이아웃 슬라이드를 제거할 수 있습니다.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 어떤 슬라이드에서도 참조되지 않는 모든 레이아웃 슬라이드를 자동으로 제거합니다.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **레이아웃 슬라이드 복제**

`AddClone` 메서드를 사용하여 레이아웃 슬라이드를 복제할 수 있습니다.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // 유형으로 기존 레이아웃 슬라이드를 가져옵니다.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // 레이아웃 슬라이드를 레이아웃 슬라이드 컬렉션의 끝에 복제합니다.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Summary:** 레이아웃 슬라이드는 슬라이드 전반에 걸쳐 일관된 서식을 관리하는 강력한 도구입니다. Aspose.Slides는 레이아웃 슬라이드의 생성, 관리 및 최적화에 대한 완전한 제어를 제공합니다.