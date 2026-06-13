---
title: 애니메이션
type: docs
weight: 100
url: /ko/net/examples/elements/animation/
keywords:
- 애니메이션
- 애니메이션 추가
- 애니메이션 액세스
- 애니메이션 제거
- 애니메이션 순서
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 애니메이션 예제를 탐색하세요: C#를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에 효과와 전환을 추가, 순서 지정 및 사용자 지정합니다."
---
이 문서는 **Aspose.Slides for .NET**을 사용하여 간단한 애니메이션을 만들고 순서를 관리하는 방법을 보여줍니다.

## **애니메이션 추가**
직사각형 모양을 만든 다음 클릭 시 트리거되는 페이드 효과를 적용합니다.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // 페이드 효과.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **애니메이션 액세스**
슬라이드 타임라인에서 첫 번째 애니메이션 효과를 검색합니다.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 첫 번째 애니메이션 효과에 액세스합니다.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **애니메이션 제거**
시퀀스에서 애니메이션 효과를 제거합니다.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 효과를 제거합니다.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **애니메이션 순서 지정**
여러 효과를 추가하고 애니메이션이 발생하는 순서를 보여줍니다.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```