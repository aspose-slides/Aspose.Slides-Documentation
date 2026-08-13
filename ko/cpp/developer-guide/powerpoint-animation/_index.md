---
title: C++에서 애니메이션을 사용하여 PowerPoint 프레젠테이션 강화
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
- 인터랙티브 애니메이션
- 맞춤 애니메이션
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
description: "Aspose.Slides for C++에서 고급 애니메이션 효과를 추가하고 제어하는 방법을 배우고, 동적인 PowerPoint 및 OpenDocument 프레젠테이션을 만들 수 있습니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위해 만들어지기 때문에, 시각적 모습과 인터랙티브 동작이 항상 고려됩니다.

**PowerPoint 애니메이션**은 프레젠테이션을 시각적으로 매력적이고 눈에 띄게 만들기 위해 중요한 역할을 합니다. Aspose.Slides for C++는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다.

- 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 적용합니다.
- 애니메이션 타임라인을 사용해 애니메이션 효과를 제어합니다.
- 사용자 정의 애니메이션을 생성합니다.

Aspose.Slides for C++에서는 도형에 다양한 애니메이션 효과를 적용할 수 있습니다. 슬라이드의 모든 요소(텍스트, 이미지, OLE 개체, 표 등)는 도형으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation) **namespace**는 PowerPoint 애니메이션을 다루는 클래스를 제공합니다.
## **애니메이션 효과**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom와 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특수 효과를 포함합니다. 전체 애니메이션 효과 목록은 [**EffectType**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 열거형에서 확인할 수 있습니다.

또한 이러한 애니메이션 효과는 다음과 같이 조합해서 사용할 수 있습니다.

- [ColorEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.set_effect)

## **맞춤 애니메이션**
Aspose.Slides에서 **맞춤 애니메이션**을 직접 만들 수 있습니다. 여러 동작을 결합하여 새로운 맞춤 애니메이션을 만들면 됩니다.

[**Behavior**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.behavior)는 모든 PowerPoint 애니메이션 효과의 구성 요소입니다. 모든 애니메이션 효과는 실제로 하나의 전략으로 구성된 동작 집합입니다. 동작을 한 번 결합해 맞춤 애니메이션을 만든 후 다른 프레젠테이션에서도 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 동작을 추가하면 또 다른 맞춤 애니메이션이 됩니다. 예를 들어 반복 동작을 추가하면 애니메이션이 여러 번 반복됩니다.

[**Animation Point**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.point)는 동작이 적용되어야 하는 지점을 의미합니다.

## **애니메이션 타임라인**
[**Sequence**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.sequence)은 특정 도형에 적용되는 애니메이션 효과들의 컬렉션입니다.

[**AnimationTimeLine**](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.animation.animation_time_line)은 특정 슬라이드에서 사용되는 Sequence 집합입니다. PowerPoint 2002부터 도입된 애니메이션 엔진이며, 이전 버전에서는 다양한 우회 방법을 사용해야 했습니다. 타임라인은 기존 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션을 위한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 **하나의** 애니메이션 타임라인만 가질 수 있습니다.

## **인터랙티브 애니메이션**
[**EffectTriggerType**](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81)을 사용하면 사용자 행동(예: 버튼 클릭)을 정의해 특정 애니메이션을 시작시킬 수 있습니다. 트리거는 최신 PowerPoint 버전에서만 지원됩니다.

## **도형 애니메이션**
Aspose.Slides는 텍스트, 사각형, 선, 프레임, OLE 개체 등 실제 도형에 애니메이션을 적용할 수 있게 해줍니다.

{{% alert color="info" %}} 
더 읽어보기 [**도형 애니메이션에 대해**](/slides/ko/cpp/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**
애니메이션 차트를 만들 때는 도형에 사용하는 것과 동일한 클래스를 사용합니다. 다만 차트 범주나 차트 시리즈에만 PowerPoint 애니메이션을 적용할 수 있습니다. 범주 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" %}} 
더 읽어보기 [**애니메이션 차트에 대해**](/slides/ko/cpp/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**
텍스트 자체뿐만 아니라 단락에도 애니메이션을 적용할 수 있습니다.

{{% alert color="info" %}} 
더 읽어보기 [**애니메이션 텍스트에 대해**](/slides/ko/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### PDF로 내보낼 때 애니메이션이 유지되나요?

아니요. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/cpp/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 [HTML5](/slides/ko/cpp/export-to-html5/), [애니메이션 GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/) 또는 [비디오](/slides/ko/cpp/convert-powerpoint-to-video/)로 내보내세요.

### 애니메이션 프레젠테이션을 비디오로 변환하면서 프레임 레이트와 프레임 크기를 제어할 수 있나요?

네. 프레젠테이션을 프레임 단위로 [렌더링](/slides/ko/cpp/convert-powerpoint-to-video/)한 뒤 ffmpeg와 같은 도구로 비디오로 인코딩하면 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

### ODP(또는 PPTX가 아닌) 파일에서도 애니메이션이 그대로 유지되나요?

PPT, PPTX, ODP 모두 [읽기](/slides/ko/cpp/open-presentation/)와 [쓰기](/slides/ko/cpp/save-presentation/)를 지원하지만 형식 차이 때문에 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하시기 바랍니다.