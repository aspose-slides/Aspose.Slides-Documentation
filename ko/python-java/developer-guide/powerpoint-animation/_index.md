---
title: Python을 사용해 Java에서 PowerPoint 프레젠테이션에 애니메이션 추가
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/python-java/powerpoint-animation/
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
- Python
- Java
- Aspose.Slides
description: "Python을 통해 Java에서 Aspose.Slides가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 통찰을 제공합니다."
---
## **소개**

프레젠테이션을 만들 때 시각적 외관과 인터랙티브 동작 모두가 고려됩니다.

**PowerPoint animation**은 프레젠테이션을 눈에 띄고 시청자에게 매력적으로 만드는 데 중요한 역할을 합니다. Aspose.Slides는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 다양한 종류의 PowerPoint 애니메이션 효과를 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 맞춤형 애니메이션을 생성합니다.

Aspose.Slides에서는 다양한 애니메이션 효과를 도형에 적용할 수 있습니다. 텍스트, 그림, OLE 개체 및 표를 포함한 슬라이드의 모든 요소가 도형으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

## **애니메이션 효과**
Aspose.Slides는 **150+ 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 애니메이션 효과와 OLEObjectShow, OLEObjectOpen과 같은 특수 효과를 포함합니다. 전체 애니메이션 효과 목록은 [EffectType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttype/) 열거형에서 확인할 수 있습니다.

또한, 다음 애니메이션 효과들을 위에 나열된 것과 함께 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/seteffect/)

## **맞춤형 애니메이션**
Aspose.Slides에서 자신만의 **맞춤형 애니메이션**을 만들 수 있습니다. 여러 동작을 결합하여 새로운 맞춤형 애니메이션을 만들 수 있습니다.

[Behavior](https://reference.aspose.com/slides/ko/python-java/aspose.slides/behavior/)은 모든 PowerPoint 애니메이션 효과의 기본 요소입니다. 각 애니메이션 효과는 단일 전략으로 결합된 동작 집합으로 구성됩니다. 동작을 맞춤형 애니메이션으로 결합하면 한 번만 만들고 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 동작을 추가하면 또 다른 맞춤형 애니메이션이 생성됩니다. 예를 들어, 반복 동작을 추가하여 애니메이션을 여러 번 반복하도록 할 수 있습니다.

[Point](https://reference.aspose.com/slides/ko/python-java/aspose.slides/point/)은 동작을 적용해야 하는 지점을 나타냅니다.

## **애니메이션 타임라인**
[Sequence](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/)은 특정 도형에 적용되는 애니메이션 효과들의 컬렉션입니다.

[AnimationTimeLine](https://reference.aspose.com/slides/ko/python-java/aspose.slides/animationtimeline/)은 특정 슬라이드에 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진을 나타냅니다. 이전 PowerPoint 버전에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 어려워 해결책이 필요했습니다. 타임라인은 기존 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션에 대한 더 명확한 객체 모델을 제공합니다. 슬라이드당 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **인터랙티브 애니메이션**
[EffectTriggerType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/effecttriggertype/)을 사용하면 특정 애니메이션을 시작하는 사용자 행동(예: 버튼 클릭)을 정의할 수 있습니다. 트리거는 최신 PowerPoint 버전에서만 추가되었습니다.

## **도형 애니메이션**
Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 및 기타 요소를 나타낼 수 있는 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [도형 애니메이션에 대해](/slides/ko/python-java/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**
애니메이션 차트를 만들려면 도형에 사용하는 것과 동일한 클래스를 사용합니다. 하지만 PowerPoint 애니메이션은 차트 범주 또는 차트 시리즈에만 적용할 수 있습니다. 범주 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [애니메이션 차트에 대해](/slides/ko/python-java/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**
텍스트에 애니메이션을 적용하는 것 외에도, 단락에도 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [애니메이션 텍스트에 대해](/slides/ko/python-java/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 유지됩니까?**

아니오. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/python-java/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/python-java/export-to-html5/), [animated GIF](/slides/ko/python-java/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/python-java/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. [프레젠테이션을 프레임으로 렌더링](/slides/ko/python-java/convert-powerpoint-to-video/)하고 비디오(예: ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(또는 PPTX)와 작업할 때도 애니메이션이 그대로 유지됩니까?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/python-java/open-presentation/)와 [쓰기](/slides/ko/python-java/save-presentation/)를 지원하지만, 포맷 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하십시오.