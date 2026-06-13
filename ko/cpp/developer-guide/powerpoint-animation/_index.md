---
title: C++에서 애니메이션으로 PowerPoint 프레젠테이션 강화
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/cpp/powerpoint-animation/
keywords:
- 애니메이션 추가
- 애니메이션 업데이트
- 애니메이션 변경
- 애니메이션 제거
- 애니메이션 관리
- 애니메이션 제어
- 애니메이션 효과
- PowerPoint 애니메이션
- 애니메이션 타임라인
- 대화형 애니메이션
- 사용자 지정 애니메이션
- 도형 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 도형
- 애니메이션 OLE 개체
- 애니메이션 이미지
- 애니메이션 표
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 고급 애니메이션 효과를 추가하고 제어하는 방법을 배워 동적인 PowerPoint 및 OpenDocument 프레젠테이션을 만들 수 있습니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위한 것이므로, 제작 시 시각적 외관과 대화형 동작을 항상 고려합니다.

**PowerPoint animation** 은 프레젠테이션을 눈에 띄고 매력적으로 만들기 위해 중요한 역할을 합니다. Aspose.Slides for C++ 은 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 다양한 종류의 PowerPoint 애니메이션 효과를 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 사용하여 애니메이션 효과를 제어합니다.
- 사용자 지정 애니메이션을 생성합니다.

Aspose.Slides for C++에서는 다양한 애니메이션 효과를 도형에 적용할 수 있습니다. 텍스트, 그림, OLE 개체, 표 등 슬라이드의 모든 요소가 도형으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation) **namespace** 은 PowerPoint 애니메이션 작업을 위한 클래스를 제공합니다.
## **애니메이션 효과**

Aspose.Slides는 **150+ 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom 효과와 같은 기본 애니메이션 효과 및 OLEObjectShow, OLEObjectOpen과 같은 특정 애니메이션 효과를 포함합니다. 전체 애니메이션 효과 목록은 [**EffectType**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 열거형에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 조합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.set_effect)

## **사용자 지정 애니메이션**

Aspose.Slides에서 자체 **사용자 지정 애니메이션**을 생성할 수 있습니다. 여러 동작을 결합하여 새로운 사용자 지정 애니메이션을 만들면 이를 달성할 수 있습니다.

[**Behavior**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.behavior) 은 모든 PowerPoint 애니메이션 효과의 구성 단위입니다. 모든 애니메이션 효과는 실제로 하나의 전략으로 구성된 동작 집합입니다. 동작을 한 번 사용자 지정 애니메이션으로 결합하면 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 동작을 추가하면 또 다른 사용자 지정 애니메이션이 됩니다. 예를 들어, 애니메이션에 반복 동작을 추가하여 몇 번 반복하도록 만들 수 있습니다.

[**Animation Point**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.point) 은 동작을 적용해야 하는 지점을 나타냅니다.

## **애니메이션 타임라인**

[**Sequence**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.sequence) 은 특정 도형에 적용되는 애니메이션 효과의 컬렉션입니다.

[**AnimationTimeLine**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.animation_time_line) 은 특정 슬라이드에서 사용되는 Sequence 집합입니다. PowerPoint 2002 이후로 제공되는 애니메이션 엔진입니다. 이전 PowerPoint 버전에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 어려웠으며, 다양한 우회 방법으로만 가능했습니다. 타임라인은 기존 AnimationSettings 클래스를 대체하여 PowerPoint 애니메이션에 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **대화형 애니메이션**

[**EffectTriggerType**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) 은 특정 애니메이션을 시작하도록 할 사용자 동작(예: 버튼 클릭)을 정의할 수 있게 합니다. 트리거는 최신 PowerPoint 버전에만 추가되었습니다.

## **도형 애니메이션**

Aspose.Slides는 실제로 텍스트, 사각형, 선, 프레임, OLE 개체 등인 도형에 애니메이션을 적용할 수 있도록 합니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Shape Animation**](/slides/ko/cpp/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 도형에 사용하는 동일한 클래스를 사용해야 합니다. 다만, PowerPoint 애니메이션을 차트 범주나 차트 시리즈에만 적용할 수 있습니다. 또한 범주 요소나 시리즈 요소에 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Animated Charts**](/slides/ko/cpp/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

애니메이션 텍스트 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Animated Text**](/slides/ko/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 유지되나요?**

아니요. PDF는 정적 포맷이므로 애니메이션 및 [slide transitions](/slides/ko/cpp/slide-transition/)이 재생되지 않습니다. 움직임이 필요하다면 대신 [HTML5](/slides/ko/cpp/export-to-html5/), [animated GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/cpp/convert-powerpoint-to-video/) 로 내보내십시오.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. [render the presentation as frames](/slides/ko/cpp/convert-powerpoint-to-video/) 로 프레젠테이션을 프레임으로 렌더링한 후 비디오(예: ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션 및 슬라이드 전환이 재생됩니다.

**ODP(단순히 PPTX가 아니라) 작업 시 애니메이션이 그대로 유지되나요?**

PPT, PPTX 및 ODP는 [reading](/slides/ko/cpp/open-presentation/) 및 [writing](/slides/ko/cpp/save-presentation/)을 지원하지만, 포맷 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하십시오.