---
title: Android에서 애니메이션으로 PowerPoint 프레젠테이션 향상
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/androidjava/powerpoint-animation/
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
- 맞춤형 애니메이션
- 도형 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 도형
- 애니메이션 OLE 개체
- 애니메이션 이미지
- 애니메이션 표
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android용 Java에서 Aspose.Slides가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요는 주요 기능을 강조합니다."
---
## **Introduction**

프레젠테이션은 무언가를 보여주기 위해 제작되므로 시각적 모습과 대화형 동작을 항상 고려합니다.

**PowerPoint 애니메이션**은 프레젠테이션을 시각적으로 눈에 띄고 매력적으로 만들기 위해 중요한 역할을 합니다. Aspose.Slides for Android via Java는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 유형의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 사용해 애니메이션 효과를 제어합니다.
- 사용자 정의 애니메이션을 생성합니다.

Aspose.Slides for Android via Java에서는 도형에 다양한 애니메이션 효과를 적용할 수 있습니다. 슬라이드의 모든 요소(텍스트, 그림, OLE 개체, 표 등)가 도형으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.


## **Animation Effects**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom 효과와 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 효과를 포함합니다. 전체 효과 목록은 [**EffectType**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effecttype/) 열거형에서 확인할 수 있습니다.

또한 이러한 애니메이션 효과는 다음과 같이 조합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SetEffect)


## **Custom Animation**
Aspose.Slides에서 **사용자 정의 애니메이션**을 만들 수 있습니다.  
여러 동작을 조합하여 새로운 사용자 정의 애니메이션을 만들면 됩니다.

[**Behavior**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Behavior)은 PowerPoint 애니메이션 효과의 구성 요소입니다. 모든 애니메이션 효과는 실제로 하나의 전략으로 구성된 동작 집합입니다. 동작을 한 번 결합해 사용자 정의 애니메이션을 만든 후 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 동작을 추가하면 또 다른 사용자 정의 애니메이션이 됩니다. 예를 들어, 애니메이션에 반복 동작을 추가해 몇 번 반복하도록 할 수 있습니다.

[**Animation Point**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Point)는 동작을 적용해야 하는 지점을 나타냅니다.


## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Sequence)은 특정 도형에 적용되는 애니메이션 효과들의 모음입니다.

[**Timeline**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AnimationTimeLine)은 특정 슬라이드에서 사용되는 Sequence 집합입니다. PowerPoint 2002부터 도입된 애니메이션 엔진으로, 이전 버전에서는 다양한 우회 방법을 사용해야 했던 애니메이션 효과 추가를 보다 명확한 객체 모델로 제공하기 위해 AnimationSettings 클래스를 대체했습니다. 한 슬라이드에는 하나의 애니메이션 타임라인만 가질 수 있습니다.


## **Interactive Animation**
[**Trigger**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/EffectTriggerType)는 사용자 행동(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작하도록 합니다. 트리거는 최신 PowerPoint 버전에서만 지원됩니다.


## **Shape Animation**
Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 실제로는 도형인 모든 요소에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Shape Animation**](/slides/ko/androidjava/shape-animation/).
{{% /alert %}}


## **Animated Charts**
애니메이션 차트를 만들 때도 도형과 동일한 클래스를 사용합니다. 그러나 차트 범주나 차트 시리즈에만 PowerPoint 애니메이션을 적용할 수 있습니다. 범주 요소나 시리즈 요소에 애니메이션 효과를 적용할 수도 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Animated Charts**](/slides/ko/androidjava/animated-charts/).
{{% /alert %}}


## **Animated Text**
애니메이션 텍스트뿐만 아니라 단락에도 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**About Animated Text**](/slides/ko/androidjava/animated-text/).
{{% /alert %}}


## **FAQ**

**Will animations be preserved when exporting to PDF?**

아니요. PDF는 정적인 형식이므로 애니메이션과 [slide transitions](/slides/ko/androidjava/slide-transition/)이 재생되지 않습니다. 모션이 필요하면 [HTML5](/slides/ko/androidjava/export-to-html5/), [animated GIF](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/) 또는 [video](/slides/ko/androidjava/convert-powerpoint-to-video/) 로 내보내세요.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

예. 프레젠테이션을 [프레임으로 렌더링](/slides/ko/androidjava/convert-powerpoint-to-video/)한 뒤 ffmpeg 등으로 비디오로 인코딩하면 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/androidjava/open-presentation/)와 [쓰기](/slides/ko/androidjava/save-presentation/)를 지원하지만, 포맷 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 사례는 실제 샘플로 검증하세요.