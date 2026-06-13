---
title: JavaScript를 사용해 PowerPoint 프레젠테이션을 애니메이션으로 강화
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/nodejs-java/powerpoint-animation/
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
- 맞춤 애니메이션
- 도형 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 도형
- 애니메이션 OLE 객체
- 애니메이션 이미지
- 애니메이션 표
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides for Java를 사용하여 PowerPoint 애니메이션을 처리합니다. 이 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 인사이트를 제공합니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위한 것이므로, 시각적 모양과 상호 작용 동작은 항상 고려됩니다.

**PowerPoint animation**은 프레젠테이션을 시각적으로 매력적이고 눈에 띄게 만들기 위해 중요한 역할을 합니다. Aspose.Slides for Node.js via Java은 PowerPoint 프레젠테이션에 애니메이션을 추가할 수 있는 다양한 옵션을 제공합니다:
- 모양, 차트, 표, OLE 객체 및 기타 프레젠테이션 요소에 다양한 종류의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 모양에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 사용하여 애니메이션 효과를 제어합니다.
- 사용자 정의 애니메이션을 생성합니다.

Aspose.Slides for Node.js via Java에서는 다양한 애니메이션 효과를 모양에 적용할 수 있습니다. 텍스트, 그림, OLE 객체, 표 등 슬라이드의 모든 요소가 모양으로 간주되므로 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

## **애니메이션 효과**
Aspose.Slides는 **150+ 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom 효과와 같은 기본 애니메이션 효과 및 OLEObjectShow, OLEObjectOpen과 같은 특정 애니메이션 효과를 포함합니다. 전체 애니메이션 효과 목록은 [**EffectType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttype/) 열거형에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과들은 다음과 같이 조합하여 사용할 수 있습니다:
- [ColorEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SetEffect)

## **맞춤 애니메이션**
Aspose.Slides에서 자체 **맞춤 애니메이션**을 만들 수 있습니다. 여러 동작을 결합하여 새로운 맞춤 애니메이션을 만들면 이를 달성할 수 있습니다.

[**Behavior**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Behavior)는 모든 PowerPoint 애니메이션 효과의 기본 구성 요소입니다. 모든 애니메이션 효과는 실제로 하나의 전략으로 구성된 동작 집합입니다. 동작을 맞춤 애니메이션으로 결합한 후 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션 효과에 새로운 동작을 추가하면 또 다른 맞춤 애니메이션이 됩니다. 예를 들어, 애니메이션에 반복 동작을 추가하여 몇 번 반복하도록 할 수 있습니다.

[**Animation Point**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Point)는 동작이 적용되어야 하는 지점입니다.

## **애니메이션 타임라인**
[**Sequence**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Sequence)는 특정 모양에 적용되는 애니메이션 효과의 집합입니다.

[**Timeline**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AnimationTimeLine)는 특정 슬라이드에 사용되는 Sequence 집합입니다. 이는 PowerPoint 2002부터 제공되는 애니메이션 엔진입니다. 이전 PowerPoint 버전에서는 애니메이션 효과를 프레젠테이션에 추가하기가 어려웠으며, 다양한 우회 방법만 가능했습니다. Timeline은 기존 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션을 위한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 하나의 애니메이션 타임라인만 있을 수 있습니다.

## **대화형 애니메이션**
[**Trigger**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/EffectTriggerType)는 사용자 동작(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작하도록 합니다. 트리거는 최신 PowerPoint 버전에서만 추가되었습니다.

## **도형 애니메이션**
Aspose.Slides는 실제로 텍스트, 사각형, 선, 프레임, OLE 객체 등인 도형에 애니메이션을 적용할 수 있도록 합니다.

{{% alert color="primary" %}} 
자세히 보기 [**도형 애니메이션에 대해**](/slides/ko/nodejs-java/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**
애니메이션 차트를 만들려면 도형에 사용하는 동일한 클래스를 사용해야 합니다. 그러나 PowerPoint 애니메이션은 차트 카테고리 또는 차트 시리즈에만 적용할 수 있습니다. 카테고리 요소 또는 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**애니메이션 차트에 대해**](/slides/ko/nodejs-java/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**
애니메이션 텍스트 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}} 
자세히 보기 [**애니메이션 텍스트에 대해**](/slides/ko/nodejs-java/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 보존되나요?**

아니요. PDF는 정적 포맷이므로 애니메이션 및 [slide transitions](/slides/ko/nodejs-java/slide-transition/)이 재생되지 않습니다. 동작이 필요하면 대신 [HTML5](/slides/ko/nodejs-java/export-to-html5/), [animated GIF](/slides/ko/nodejs-java/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/nodejs-java/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. [프레젠테이션을 프레임으로 렌더링](/slides/ko/nodejs-java/convert-powerpoint-to-video/)하고 이를 비디오(e.g., ffmpeg 사용)로 인코딩하여 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(단순히 PPTX가 아니라) 작업 시 애니메이션이 그대로 유지되나요?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/nodejs-java/open-presentation/)와 [쓰기](/slides/ko/nodejs-java/save-presentation/)를 지원하지만, 형식 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 실제 샘플로 중요한 사례를 검증하십시오.