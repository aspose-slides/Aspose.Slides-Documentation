---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/net/examples/elements/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 접근
- 슬라이드 전환 제거
- 전환 지속 시간
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 전환을 마스터하세요: PPT, PPTX 및 ODP 프레젠테이션용 C# 예제를 통해 효과와 지속 시간을 추가, 맞춤 설정 및 순서 지정합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 슬라이드 전환 효과와 타이밍을 적용하는 방법을 보여줍니다.

## **슬라이드 전환 추가**
첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 페이드 전환을 적용합니다.
}
```

## **슬라이드 전환 접근**
슬라이드에 현재 할당된 전환 유형을 읽어옵니다.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // 전환 유형에 접근합니다.
    var type = slide.SlideShowTransition.Type;
}
```

## **슬라이드 전환 제거**
전환 유형을 `None`으로 설정하여 모든 전환 효과를 제거합니다.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // 전환을 없애려면 None으로 설정합니다.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **전환 지속 시간 설정**
슬라이드가 자동으로 넘어가기 전에 표시되는 시간을 지정합니다.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // 밀리초 단위
}
```