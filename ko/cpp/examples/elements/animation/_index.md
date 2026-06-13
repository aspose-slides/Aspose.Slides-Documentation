---
title: 애니메이션
type: docs
weight: 100
url: /ko/cpp/examples/elements/animation/
keywords:
- 코드 예제
- 애니메이션
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 애니메이션 예제를 탐색하세요: C++를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에 효과와 전환을 추가, 순서 지정 및 사용자 정의합니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 간단한 애니메이션을 만들고 시퀀스를 관리하는 방법을 보여줍니다.

## **애니메이션 추가**
사각형 모양을 만든 후 클릭 시 트리거되는 페이드인 효과를 적용합니다.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // 페이드 효과.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **애니메이션 액세스**
슬라이드 타임라인에서 첫 번째 애니메이션 효과를 가져옵니다.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // 첫 번째 애니메이션 효과에 접근합니다.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **애니메이션 제거**
시퀀스에서 애니메이션 효과를 제거합니다.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // 효과를 제거합니다.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **애니메이션 순서 지정**
여러 효과를 추가하고 애니메이션이 발생하는 순서를 시연합니다.

```cpp
static void SequenceAnimations()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

    auto sequence = slide->get_Timeline()->get_MainSequence();
    sequence->AddEffect(shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    sequence->AddEffect(shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```