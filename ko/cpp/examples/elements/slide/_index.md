---
title: 슬라이드
type: docs
weight: 10
url: /ko/cpp/examples/elements/slide/
keywords:
- 코드 예제
- 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드를 제어합니다: PPT, PPTX 및 ODP 프레젠테이션을 위해 C++로 슬라이드를 생성, 복제, 재정렬, 크기 조정, 배경 설정 및 전환을 적용합니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 슬라이드 작업을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 액세스, 복제, 재정렬 및 제거하는 방법을 배울 수 있습니다.

아래 각 예제는 간략한 설명과 C++ 코드 스니펫을 포함합니다.

## **Add a Slide**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Note:** 각 슬라이드 레이아웃은 마스터 슬라이드에서 파생되며, 마스터 슬라이드는 전체 디자인 및 자리표시자 구조를 정의합니다. 아래 이미지는 PowerPoint에서 마스터 슬라이드와 해당 레이아웃이 어떻게 구성되는지 보여줍니다.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

슬라이드의 인덱스를 사용하여 슬라이드에 액세스하거나, 참조를 기반으로 슬라이드의 인덱스를 찾을 수 있습니다. 이는 특정 슬라이드를 반복하거나 수정할 때 유용합니다.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 다른 빈 슬라이드를 추가합니다.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // 인덱스로 슬라이드에 접근합니다.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // 참조에서 슬라이드 인덱스를 얻은 다음 인덱스로 접근합니다.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clone a Slide**

이 예제는 기존 슬라이드를 복제하는 방법을 보여줍니다. 복제된 슬라이드는 슬라이드 컬렉션의 끝에 자동으로 추가됩니다.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reorder Slides**

슬라이드 하나를 새 인덱스로 이동시켜 순서를 변경할 수 있습니다. 여기서는 복제된 슬라이드를 첫 번째 위치로 이동합니다.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Remove a Slide**

슬라이드를 제거하려면 해당 슬라이드를 참조하고 `Remove`를 호출하면 됩니다. 이 예제에서는 두 번째 슬라이드를 추가한 후 원본을 제거하여 새 슬라이드만 남깁니다.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```