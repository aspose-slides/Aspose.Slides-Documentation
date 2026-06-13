---
title: Python에서 애니메이션을 사용한 PowerPoint 프레젠테이션 향상
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/python-net/powerpoint-animation/
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
- 커스텀 애니메이션
- 도형 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 도형
- 애니메이션 OLE 개체
- 애니메이션 이미지
- 애니메이션 표
- PowerPoint 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET가 PowerPoint 애니메이션을 처리하는 기능을 탐색하세요. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 통찰을 제공합니다."
---
## **소개**

프레젠테이션은 정보를 전달하도록 설계되었으며, 따라서 시각적 외관과 인터랙티브한 동작이 제작 중 핵심 고려 사항입니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 시청자에게 매력적으로 만드는 중요한 역할을 합니다. Aspose.Slides for Python via .NET은 PowerPoint 프레젠테이션에 애니메이션을 추가할 수 있는 다양한 옵션을 제공합니다. 다음을 수행할 수 있습니다:

- 도형, 차트, 표, OLE 개체 및 기타 요소에 다양한 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 통해 효과를 제어합니다.
- 사용자 지정 애니메이션을 생성합니다.

Aspose.Slides for Python via .NET에서는 애니메이션 효과를 도형에 적용할 수 있습니다. 슬라이드의 모든 요소—텍스트, 그림, OLE 개체 및 표—가 도형으로 취급되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

[aspose.slides.animation](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/) 네임스페이스는 PowerPoint 애니메이션을 다루는 클래스를 제공합니다.

## **애니메이션 효과**

Aspose.Slides는 **150+ 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특수 효과를 포함합니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttype/) 열거형에서 확인할 수 있습니다.

또한 이러한 애니메이션 효과는 다음 효과와 결합할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/seteffect/)

## **사용자 지정 애니메이션**

Aspose.Slides에서 여러 동작을 하나의 효과로 결합하여 **사용자 지정 애니메이션**을 만들 수 있습니다.

[Behavior](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/)은 모든 PowerPoint 애니메이션 효과의 기본 구성 요소입니다. 각 애니메이션 효과는 본질적으로 하나의 전략이나 타임라인에 배열된 동작 집합입니다. 동작을 한 번 조합해 사용자 지정 애니메이션을 만들면 다른 프레젠테이션에서도 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새 동작을 추가하면 사용자 지정 애니메이션이 됩니다—예를 들어 반복 동작을 추가해 애니메이션을 여러 번 재생하도록 할 수 있습니다.

[Animation Point](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/point/)은 동작이 적용되는 순간 또는 위치(키프레임)를 표시합니다.

## **애니메이션 타임라인**

[Sequence](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/)은 특정 도형에 적용된 애니메이션 효과의 집합입니다.

[Timeline](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/animationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스들의 집합입니다. PowerPoint 2002에서 도입되었습니다. 이전 버전의 PowerPoint에서는 애니메이션 효과를 추가하기가 어려워 종종 우회 방법이 필요했습니다. Timeline은 기존 `AnimationSettings` 클래스를 대체하고 PowerPoint 애니메이션을 위한 더 명확한 객체 모델을 제공합니다. 각 슬라이드에는 하나의 애니메이션 타임라인만 있을 수 있습니다.

## **인터랙티브 애니메이션**

[Trigger](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/)를 사용하면 사용자 동작(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작할 수 있습니다. 트리거는 최신 버전의 PowerPoint에만 추가되었습니다.

## **도형 애니메이션**

Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}}
자세히 보기 [**도형 애니메이션에 대해**](/slides/ko/python-net/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 도형에 사용하는 것과 동일한 클래스를 사용합니다. 그러나 PowerPoint 애니메이션은 차트 카테고리 또는 차트 시리즈에만 적용될 수 있습니다. 개별 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="primary" %}}
자세히 보기 [**애니메이션 차트에 대해**](/slides/ko/python-net/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

텍스트를 애니메이션하는 것 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}}
자세히 보기 [**애니메이션 텍스트에 대해**](/slides/ko/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 유지되나요?**

No. PDF는 정적 형식이므로 애니메이션 및 [slide transitions](/slides/ko/python-net/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/python-net/export-to-html5/), [animated GIF](/slides/ko/python-net/convert-powerpoint-to-animated-gif/) 또는 [video](/slides/ko/python-net/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

Yes. 프레젠테이션을 [render the presentation as frames](/slides/ko/python-net/convert-powerpoint-to-video/)하고 이를 비디오(예: ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(단순히 PPTX가 아님)와 작업할 때도 애니메이션이 그대로 유지되나요?**

PPT, PPTX 및 ODP는 [reading](/slides/ko/python-net/open-presentation/) 및 [writing](/slides/ko/python-net/save-presentation/)이 지원되지만 형식 차이로 인해 특정 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하세요.