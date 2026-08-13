---
title: "Android에서 애니메이션을 사용하여 PowerPoint 프레젠테이션 강화"
linktitle: "PowerPoint 애니메이션"
type: docs
weight: 150
url: /ko/androidjava/powerpoint-animation/
keywords:
- "애니메이션 추가"
- "애니메이션 업데이트"
- "애니메이션 변경"
- "애니메이션 제거"
- "애니메이션 관리"
- "애니메이션 제어"
- "애니메이션 효과"
- "PowerPoint 애니메이션"
- "애니메이션 타임라인"
- "인터랙티브 애니메이션"
- "맞춤형 애니메이션"
- "도형 애니메이션"
- "애니메이션 차트"
- "애니메이션 텍스트"
- "애니메이션 도형"
- "애니메이션 OLE 객체"
- "애니메이션 이미지"
- "애니메이션 표"
- "PowerPoint"
- "프레젠테이션"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조합니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위해 만들어지기 때문에, 시각적 모습과 인터랙티브 동작은 항상 고려됩니다.

**PowerPoint 애니메이션**은 프레젠테이션을 시청자에게 눈에 띄고 매력적으로 만들기 위해 중요한 역할을 합니다. Aspose.Slides for Android via Java는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 다양한 유형의 PowerPoint 애니메이션 효과를 모양, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 적용합니다.
- 하나의 모양에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 사용하여 애니메이션 효과를 제어합니다.
- 맞춤형 애니메이션을 생성합니다.

Aspose.Slides for Android via Java에서는 다양한 애니메이션 효과를 모양에 적용할 수 있습니다. 텍스트, 이미지, OLE 개체, 표 등 슬라이드의 모든 요소가 모양으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

## **애니메이션 효과**

Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom 효과와 같은 기본 애니메이션 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 애니메이션 효과를 포함합니다. 전체 애니메이션 효과 목록은 [**EffectType**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effecttype/) 열거형에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 아래와 같이 조합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SetEffect)

## **맞춤형 애니메이션**

Aspose.Slides에서 **맞춤형 애니메이션**을 직접 만들 수 있습니다. 여러 동작을 결합하여 새로운 맞춤형 애니메이션을 만들면 이를 구현할 수 있습니다.

[**Behavior**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Behavior)은 모든 PowerPoint 애니메이션 효과의 구성 단위입니다. 모든 애니메이션 효과는 실제로 하나의 전략으로 구성된 동작 집합입니다. 동작을 맞춤형 애니메이션으로 결합한 뒤 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새 동작을 추가하면 또 다른 맞춤형 애니메이션이 됩니다. 예를 들어, 애니메이션에 반복 동작을 추가하면 몇 번 반복하도록 만들 수 있습니다.

[**Animation Point**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Point)은 동작을 적용해야 하는 지점을 의미합니다.

## **애니메이션 타임라인**

[**Sequence**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Sequence)은 특정 모양에 적용되는 애니메이션 효과들의 집합입니다.

[**Timeline**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/AnimationTimeLine)은 특정 슬라이드에서 사용되는 Sequence들의 집합입니다. 이는 PowerPoint 2002부터 제공되는 애니메이션 엔진입니다. 이전 PowerPoint 버전에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 어려웠으며, 다양한 우회 방법으로만 가능했습니다. Timeline은 기존 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션을 위한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **인터랙티브 애니메이션**

[**Trigger**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/EffectTriggerType)은 사용자 동작(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작하도록 할 수 있습니다. Trigger는 최신 PowerPoint 버전에만 추가되었습니다.

## **모양 애니메이션**

Aspose.Slides는 실제 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 모양에 애니메이션을 적용할 수 있게 합니다.

{{% alert color="info" %}} 
자세히 보기 [**모양 애니메이션에 대하여**](/slides/ko/androidjava/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 모양에 사용되는 동일한 클래스를 사용해야 합니다. 다만, PowerPoint 애니메이션은 차트 범주나 차트 시리즈에만 적용할 수 있습니다. 또한 범주 요소나 시리즈 요소에 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" %}} 
자세히 보기 [**애니메이션 차트에 대하여**](/slides/ko/androidjava/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

애니메이션 텍스트 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" %}} 
자세히 보기 [**애니메이션 텍스트에 대하여**](/slides/ko/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

### PDF로 내보낼 때 애니메이션이 유지됩니까?

아니요. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/androidjava/slide-transition/)이 재생되지 않습니다. 움직임이 필요하다면 대신 [HTML5](/slides/ko/androidjava/export-to-html5/), [애니메이션 GIF](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/), 또는 [비디오](/slides/ko/androidjava/convert-powerpoint-to-video/)로 내보내세요.

### 애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?

예. 프레젠테이션을 [프레임으로 렌더링](/slides/ko/androidjava/convert-powerpoint-to-video/)하여 비디오(예: ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

### ODP(또는 PPTX) 작업 시 애니메이션이 그대로 유지됩니까?

PPT, PPTX 및 ODP는 [읽기](/slides/ko/androidjava/open-presentation/)와 [쓰기](/slides/ko/androidjava/save-presentation/)를 지원하지만, 형식 차이로 인해 일부 효과가 약간 다르게 표시되거나 동작할 수 있습니다. 중요한 사례는 실제 샘플로 검증하십시오.