---
title: 슬라이드
type: docs
weight: 10
url: /ko/net/examples/elements/slide/
keywords:
- 슬라이드
- 슬라이드 추가
- 슬라이드 접근
- 슬라이드 인덱스
- 슬라이드 복제
- 슬라이드 순서 변경
- 슬라이드 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드를 제어합니다: PPT, PPTX 및 ODP 프레젠테이션용 C#를 사용하여 슬라이드 생성, 복제, 순서 변경, 크기 조정, 배경 설정 및 전환 적용."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 슬라이드를 작업하는 방법을 보여주는 일련의 예제를 제공합니다. `Presentation` 클래스를 사용하여 슬라이드를 추가, 액세스, 복제, 순서 변경 및 제거하는 방법을 배울 수 있습니다.

아래 각 예제에는 간단한 설명과 C# 코드 스니펫이 포함됩니다.

## **슬라이드 추가**

새 슬라이드를 추가하려면 먼저 레이아웃을 선택해야 합니다. 이 예제에서는 `Blank` 레이아웃을 사용하여 프레젠테이션에 빈 슬라이드를 추가합니다.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // 각 슬라이드는 레이아웃을 기반으로 하며, 레이아웃 자체는 마스터 슬라이드를 기반으로 합니다.
    // 새 슬라이드를 만들기 위해 Blank 레이아웃을 사용합니다.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // 선택한 레이아웃을 사용하여 새 빈 슬라이드를 추가합니다.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **참고:** 각 슬라이드 레이아웃은 마스터 슬라이드에서 파생되며, 마스터 슬라이드는 전체 디자인 및 플레이스홀더 구조를 정의합니다. 아래 이미지에서는 PowerPoint에서 마스터 슬라이드와 해당 레이아웃이 어떻게 구성되는지 보여줍니다.

![마스터 및 레이아웃 관계](master-layout-slide.png)

## **인덱스로 슬라이드 액세스**

슬라이드의 인덱스를 사용하여 슬라이드에 접근하거나, 참조를 기반으로 슬라이드의 인덱스를 찾을 수 있습니다. 이는 슬라이드를 반복하거나 특정 슬라이드를 수정할 때 유용합니다.

```csharp
static void AccessSlide()
{
    // 기본적으로 프레젠테이션은 빈 슬라이드 하나로 생성됩니다.
    using var presentation = new Presentation();

    // 또 다른 빈 슬라이드를 추가합니다.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 인덱스로 슬라이드에 접근합니다.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // 레퍼런스로부터 슬라이드 인덱스를 가져온 다음, 인덱스로 접근합니다.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **슬라이드 복제**

이 예제에서는 기존 슬라이드를 복제하는 방법을 보여줍니다. 복제된 슬라이드는 슬라이드 컬렉션의 끝에 자동으로 추가됩니다.

```csharp
static void CloneSlide()
{
    // 기본적으로 프레젠테이션에는 빈 슬라이드가 하나 포함됩니다.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 첫 번째 슬라이드를 복제합니다; 복제된 슬라이드는 프레젠테이션 끝에 추가됩니다.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // 복제된 슬라이드의 인덱스는 1입니다 (프레젠테이션에서 두 번째 슬라이드).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **슬라이드 순서 변경**

슬라이드 중 하나를 새로운 인덱스로 이동시켜 순서를 변경할 수 있습니다. 여기서는 복제된 슬라이드를 첫 번째 위치로 이동합니다.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // 첫 번째 슬라이드의 복제본을 추가합니다 (기본적으로 생성됨).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // 복제된 슬라이드를 첫 번째 위치로 이동합니다 (다른 슬라이드가 아래로 이동).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **슬라이드 제거**

슬라이드를 제거하려면 해당 슬라이드를 참조한 뒤 `Remove`를 호출하면 됩니다. 이 예제에서는 두 번째 슬라이드를 추가하고 원본 슬라이드를 제거하여 새 슬라이드만 남깁니다.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // 기본 첫 번째 슬라이드 외에 새 빈 슬라이드를 추가합니다.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // 첫 번째 슬라이드를 제거합니다; 새로 추가된 슬라이드만 남게 됩니다.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```