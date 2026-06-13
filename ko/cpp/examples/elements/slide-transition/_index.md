---
title: 슬라이드 전환
type: docs
weight: 110
url: /ko/cpp/examples/elements/slide-transition/
keywords:
- 코드 예제
- 슬라이드 전환
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 전환을 마스터하세요: PPT, PPTX 및 ODP 프레젠테이션을 위한 C++ 예제로 효과와 지속 시간을 추가, 사용자 정의 및 순서 지정합니다."
---
이 문서는 **Aspose.Slides for C++**를 사용하여 슬라이드 전환 효과와 타이밍을 적용하는 방법을 보여줍니다.

## **슬라이드 전환 추가**
첫 번째 슬라이드에 페이드 전환 효과를 적용합니다.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // 페이드 전환을 적용합니다.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **슬라이드 전환 접근**
슬라이드에 현재 할당된 전환 유형을 읽습니다.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // 전환 유형에 접근합니다.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **슬라이드 전환 제거**
전환 유형을 `None`으로 설정하여 모든 전환 효과를 제거합니다.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // 전환을 없애려면 None으로 설정합니다.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **전환 지속 시간 설정**
자동으로 다음 슬라이드로 넘어가기 전에 슬라이드가 표시되는 기간을 지정합니다.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // 밀리초 단위.

    presentation->Dispose();
}
```