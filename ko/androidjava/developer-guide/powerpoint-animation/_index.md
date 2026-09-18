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
- 인터랙티브 애니메이션
- 맞춤형 애니메이션
- 모양 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 모양
- 애니메이션 OLE 개체
- 애니메이션 이미지
- 애니메이션 표
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조합니다."
---
## **소개**

프레젠테이션은 무언가를 제시하기 위한 것이므로, 제작 과정에서 시각적 모습과 인터랙티브 동작을 항상 고려합니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 관객에게 매력적으로 만드는 데 중요한 역할을 합니다. Aspose.Slides는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 모양, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 종류의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 모양에 여러 PowerPoint 애니메이션 효과를 사용할 수 있습니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 사용자 지정 애니메이션을 생성합니다.

Aspose.Slides에서는 다양한 애니메이션 효과를 모양에 적용할 수 있습니다. 텍스트, 그림, OLE 개체 및 표를 포함한 슬라이드의 모든 요소는 모양으로 간주되므로, 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

## **애니메이션 효과**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 효과를 포함합니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effecttype/) 클래스에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 다음 동작과 결합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SetEffect)

## **사용자 지정 애니메이션**

동작 및 편집 가능한 모션 경로를 생성, 검사 및 수정하는 전체 Java 예제는 [Custom Animation](/slides/ko/java/custom-animation/)을 참조하십시오.

Aspose.Slides에서 자체 **사용자 지정 애니메이션**을 만들 수 있습니다. 이는 여러 동작을 결합하여 새로운 사용자 지정 애니메이션을 만들면 달성할 수 있습니다.

[Behavior](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/behavior/)은 PowerPoint 애니메이션 효과의 구성 요소입니다. 동작을 결합하여 효과를 사용자 지정하거나, 미리 정의된 효과를 확장하기 위해 동작을 추가합니다. 반복은 별도의 반복 동작이 아니라 타이밍 설정을 통해 구성됩니다.

[Animation Point](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/point/)은 동작이 적용되어야 하는 지점을 의미합니다.

## **애니메이션 타임라인**

[Sequence](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/sequence/)은 서로 다른 모양을 대상으로 할 수 있는 애니메이션 효과들의 컬렉션입니다.

[Timeline](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/animationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진입니다. 이전 버전의 PowerPoint에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 어려웠으며 다양한 해결 방법을 사용해야 했습니다. 타임라인은 PowerPoint 애니메이션에 대한 보다 명확한 객체 모델을 제공합니다. 슬라이드당 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **인터랙티브 애니메이션**

[Trigger](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/effecttriggertype/)를 사용하면 버튼 클릭과 같은 사용자 동작을 정의하여 특정 애니메이션을 시작할 수 있습니다.

## **모양 애니메이션**

Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등을 포함한 모양에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 읽기 [**모양 애니메이션에 대해**](/slides/ko/androidjava/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 모양과 동일한 클래스를 사용해야 합니다. 그러나 PowerPoint 애니메이션은 차트 범주 또는 차트 시리즈에만 적용할 수 있습니다. 범주 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 읽기 [**애니메이션 차트에 대해**](/slides/ko/androidjava/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

텍스트를 애니메이션할 뿐만 아니라 단락에도 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 읽기 [**애니메이션 텍스트에 대해**](/slides/ko/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 유지됩니까?**

아니요. PDF는 정적 형식이므로 애니메이션과 [slide transitions](/slides/ko/androidjava/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/androidjava/export-to-html5/), [animated GIF](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/androidjava/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션이 적용된 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. [프레젠테이션을 프레임으로 렌더링](/slides/ko/androidjava/convert-powerpoint-to-video/)하고 이를 비디오(e.g., ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 과정에서 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(단순히 PPTX가 아니라) 작업 시 애니메이션이 유지됩니까?**

PPT, PPTX, ODP는 [읽기](/slides/ko/androidjava/open-presentation/)와 [쓰기](/slides/ko/androidjava/save-presentation/)를 지원하지만, 이는 애니메이션이 유지된다는 보장을 의미하지 않습니다. ODP로 변환할 때 사용자 지정 애니메이션 데이터가 손실될 수 있습니다. 예제와 형식 호환성 확인 방법은 [Custom Animation for Java](/slides/ko/java/custom-animation/)를 참고하십시오.