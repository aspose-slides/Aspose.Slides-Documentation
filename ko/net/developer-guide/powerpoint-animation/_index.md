---
title: .NET에서 PowerPoint 프레젠테이션을 애니메이션으로 향상시키기
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/net/powerpoint-animation/
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
- PowerPoint 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시킬 수 있는 인사이트를 제공합니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위한 것이므로, 제작 과정에서 시각적 외관과 인터랙티브 동작이 항상 고려됩니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 관객에게 매력적으로 만드는 데 중요한 역할을 합니다. Aspose.Slides for .NET은 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:
- 다양한 유형의 PowerPoint 애니메이션 효과를 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용할 수 있습니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 맞춤형 애니메이션을 생성합니다.

Aspose.Slides for .NET에서는 다양한 애니메이션 효과를 도형에 적용할 수 있습니다. 텍스트, 그림, OLE 개체 및 표를 포함한 슬라이드의 모든 요소가 도형으로 간주되므로, 슬라이드의 어떤 요소에도 애니메이션 효과를 적용할 수 있습니다.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/) 네임스페이스는 PowerPoint 애니메이션을 다루기 위한 클래스를 제공합니다.

## **애니메이션 효과**

Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특수 효과를 포함합니다. 전체 효과 목록은 [EffectType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttype) 열거형에서 확인할 수 있습니다.

또한 다음과 결합하여 사용할 수 있습니다:
- [ColorEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/seteffect)

## **사용자 지정 애니메이션**

Aspose.Slides에서 **사용자 지정 애니메이션**을 직접 만들 수 있습니다. 여러 행동을 결합하여 새로운 사용자 지정 애니메이션을 만들면 됩니다.

[Behaviour](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/behavior) 은 모든 PowerPoint 애니메이션 효과의 기본 구성 요소입니다. 모든 애니메이션 효과는 본질적으로 하나의 전략으로 구성된 행동 집합입니다. 행동을 하나의 사용자 지정 애니메이션으로 결합한 뒤 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 행동을 추가하면 또 다른 사용자 지정 애니메이션이 됩니다. 예를 들어, 애니메이션에 반복 행동을 추가하면 몇 번 반복하도록 할 수 있습니다.

[Animation Point](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/point) 은 행동을 적용해야 하는 지점을 의미합니다.

## **애니메이션 타임라인**

[Sequence](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/sequence) 은 특정 도형에 적용된 애니메이션 효과들의 컬렉션입니다.

[Timeline](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/animationtimeline) 은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진이며, 이전 버전에서는 다양한 우회 방법 없이 애니메이션 효과를 적용하기 어려웠습니다. 타임라인은 기존 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션에 대한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 오직 하나의 애니메이션 타임라인만 존재할 수 있습니다.

## **대화형 애니메이션**

[Trigger](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttriggertype) 를 사용하면 사용자 작업(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작할 수 있습니다. 트리거는 최신 버전의 PowerPoint에서 도입되었습니다.

## **도형 애니메이션**

Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" %}} 
자세히 읽기 [**모양 애니메이션에 대한 정보**](/slides/ko/net/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 도형에 사용하는 것과 동일한 클래스를 사용해야 합니다. 다만 PowerPoint 애니메이션은 차트 카테고리 또는 차트 시리즈에만 적용될 수 있습니다. 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" %}} 
자세히 읽기 [**애니메이션 차트에 대한 정보**](/slides/ko/net/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

애니메이션 텍스트 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" %}} 
자세히 읽기 [**애니메이션 텍스트에 대한 정보**](/slides/ko/net/animated-text/).
{{% /alert %}}

## **FAQ**

### PDF로 내보낼 때 애니메이션이 유지되나요?

아니요. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/net/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/net/export-to-html5/), [애니메이션 GIF](/slides/ko/net/convert-powerpoint-to-animated-gif/), 또는 [비디오](/slides/ko/net/convert-powerpoint-to-video/)로 내보내세요.

### 애니메이션 프레젠테이션을 비디오로 변환하고 프레임 속도와 크기를 제어할 수 있나요?

예. 프레젠테이션을 프레임으로 [렌더링](/slides/ko/net/convert-powerpoint-to-video/)한 뒤 ffmpeg 등으로 비디오로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

### ODP(또는 PPTX)와 작업할 때 애니메이션이 그대로 유지되나요?

PPT, PPTX 및 ODP는 [읽기](/slides/ko/net/open-presentation/)와 [쓰기](/slides/ko/net/save-presentation/)를 모두 지원하지만, 형식 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하세요.