---
title: Java에서 애니메이션으로 PowerPoint 프레젠테이션 향상
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/java/powerpoint-animation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 인사이트를 제공합니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위해 만들어지기 때문에, 제작 과정에서 시각적 디자인과 인터랙티브 동작이 항상 고려됩니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 시청자를 끌어들이는 데 중요한 역할을 합니다. Aspose.Slides는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 유형의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용할 수 있습니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 맞춤형 애니메이션을 생성합니다.

## **애니메이션 효과**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특수 효과를 포함합니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttype/) 클래스에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 다음 동작과 조합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SetEffect)

## **맞춤형 애니메이션**
동작 및 편집 가능한 움직임 경로를 생성, 검사 및 수정하는 전체 Java 예제는 [Custom Animation](/slides/ko/java/custom-animation/)를 참조하십시오.

Aspose.Slides에서 자체 **맞춤형 애니메이션**을 만들 수 있습니다. 이는 여러 동작을 조합하여 새로운 맞춤형 애니메이션을 만드는 방식으로 구현됩니다.

[Behavior](https://reference.aspose.com/slides/ko/java/com.aspose.slides/behavior/)은 PowerPoint 애니메이션 효과의 구성 요소입니다. 동작을 결합하여 효과를 사용자 지정하거나, 동작을 추가해 미리 정의된 효과를 확장할 수 있습니다. 반복은 별도의 repeat 동작이 아니라 타이밍 설정을 통해 구성됩니다.

[Animation Point](https://reference.aspose.com/slides/ko/java/com.aspose.slides/point/)은 동작이 적용되어야 하는 지점을 의미합니다.

## **애니메이션 타임라인**
[Sequence](https://reference.aspose.com/slides/ko/java/com.aspose.slides/sequence/)은 다양한 도형을 대상으로 할 수 있는 애니메이션 효과들의 컬렉션입니다.

[Timeline](https://reference.aspose.com/slides/ko/java/com.aspose.slides/animationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진입니다. 이전 버전의 PowerPoint에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 까다롭고 다양한 우회 방법을 사용해야 했습니다. 타임라인은 PowerPoint 애니메이션에 대해 보다 명확한 객체 모델을 제공합니다. 슬라이드당 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **대화형 애니메이션**
[Trigger](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttriggertype/)을 사용하면 버튼 클릭과 같은 사용자 작업을 정의하여 특정 애니메이션을 시작할 수 있습니다.

## **도형 애니메이션**
Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**도형 애니메이션에 대해**](/slides/ko/java/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**
애니메이션 차트를 만들려면 도형에 사용하는 동일한 클래스를 사용해야 합니다. 그러나 PowerPoint 애니메이션은 차트의 카테고리 또는 시리즈에만 적용할 수 있습니다. 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 차트에 대해**](/slides/ko/java/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**
텍스트를 애니메이션하는 것 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 텍스트에 대해**](/slides/ko/java/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 유지되나요?**

아니요. PDF는 정적 형식이므로 애니메이션 및 [슬라이드 전환](/slides/ko/java/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/java/export-to-html5/), [animated GIF](/slides/ko/java/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/java/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. [프레젠테이션을 프레임으로 렌더링](/slides/ko/java/convert-powerpoint-to-video/)한 후 비디오(예: ffmpeg 사용)로 인코딩하면 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(또는 PPTX가 아닌)와 작업할 때 애니메이션이 그대로 유지되나요?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/java/open-presentation/)와 [쓰기](/slides/ko/java/save-presentation/)를 지원하지만, 이는 애니메이션 보존을 보장하지 않습니다. ODP로 변환할 때 맞춤형 애니메이션 데이터가 손실될 수 있습니다. 형식 호환성을 확인하는 방법과 예제는 [Custom Animation](/slides/ko/java/custom-animation/)을 참조하십시오.