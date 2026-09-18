---
title: .NET에서 PowerPoint 프레젠테이션을 애니메이션으로 강화하기
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
- 인터랙티브 애니메이션
- 맞춤형 애니메이션
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
description: "Aspose.Slides for .NET가 PowerPoint 애니메이션을 처리하는 기능을 탐색하십시오. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 인사이트를 제공합니다."
---
## **소개**

프레젠테이션은 무언가를 전달하기 위한 것이므로, 제작 과정에서 시각적 모양과 인터랙티브 동작이 항상 고려됩니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 시청자를 매료시키는 데 중요한 역할을 합니다. Aspose.Slides for .NET은 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 텍스트, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 유형의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 맞춤형 애니메이션을 생성합니다.

Aspose.Slides for .NET에서는 도형에 다양한 애니메이션 효과를 적용할 수 있습니다. 슬라이드의 모든 요소(텍스트, 그림, OLE 개체, 표 등)는 도형으로 간주되므로 슬라이드의 어떤 요소에도 애니메이션 효과를 적용할 수 있습니다.

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/) 네임스페이스는 PowerPoint 애니메이션을 작업하기 위한 클래스를 제공합니다.

## **애니메이션 효과**

Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 효과를 포함합니다. 전체 애니메이션 효과 목록은 [EffectType](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttype) 열거형에서 확인할 수 있습니다.

또한 이러한 애니메이션 효과는 다음과 함께 조합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/seteffect)

## **맞춤형 애니메이션**

동작 및 편집 가능한 움직임 경로를 생성, 검사 및 수정하는 전체 C# 예제는 [Custom Animation](/slides/ko/net/custom-animation/)을 참고하십시오.

Aspose.Slides에서 **맞춤형 애니메이션**을 직접 만들 수 있습니다. 여러 동작을 결합하여 새로운 맞춤형 애니메이션을 만들면 됩니다.

[Behavior](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/behavior)은 PowerPoint 애니메이션 효과의 구성 요소입니다. 동작을 결합하여 효과를 사용자 정의하거나, 미리 정의된 효과를 확장하기 위해 동작을 추가할 수 있습니다. 반복은 별도의 반복 동작이 아니라 타이밍 설정을 통해 구성됩니다.

[Animation Point](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/point)은 동작이 적용되어야 하는 지점을 의미합니다.

## **애니메이션 타임라인**

[Sequence](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/sequence)은 서로 다른 도형을 대상으로 할 수 있는 애니메이션 효과의 모음입니다.

[Timeline](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/animationtimeline)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. PowerPoint 2002에서 도입된 애니메이션 엔진이며, 이전 버전에서는 애니메이션 효과를 추가하는 것이 어려워 다양한 우회 방법을 사용해야 했습니다. 타임라인은 이전의 AnimationSettings 클래스를 대체하고 PowerPoint 애니메이션에 대한 명확한 객체 모델을 제공하며, 슬라이드당 하나의 애니메이션 타임라인만 가질 수 있습니다.

## **인터랙티브 애니메이션**

[Trigger](https://reference.aspose.com/slides/ko/net/aspose.slides.animation/effecttriggertype)을 사용하면 사용자 행동(예: 버튼 클릭)을 정의하여 특정 애니메이션을 시작할 수 있습니다. 트리거는 최신 버전의 PowerPoint에서 도입되었습니다.

## **도형 애니메이션**

Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등을 포함한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**About Shape Animation**](/slides/ko/net/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 도형에 사용되는 클래스와 동일한 클래스를 사용해야 합니다. 그러나 PowerPoint 애니메이션은 차트 카테고리나 차트 시리즈에만 적용할 수 있습니다. 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**About Animated Charts**](/slides/ko/net/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

텍스트를 애니메이션하는 것 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**About Animated Text**](/slides/ko/net/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 보존됩니까?**

아니요. PDF는 정적 형식이므로 애니메이션 및 [slide transitions](/slides/ko/net/slide-transition/)이 재생되지 않습니다. 움직임이 필요하다면 대신 [HTML5](/slides/ko/net/export-to-html5/), [animated GIF](/slides/ko/net/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/net/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있습니까?**

예. 프레젠테이션을 프레임으로 [render](/slides/ko/net/convert-powerpoint-to-video/)한 후 ffmpeg 등으로 비디오로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP(또는 PPTX가 아닌 형식)로 작업할 때 애니메이션이 그대로 유지됩니까?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/net/open-presentation/)와 [쓰기](/slides/ko/net/save-presentation/)가 지원되지만, 이는 애니메이션 보존을 보장하지는 않습니다. ODP로 변환할 때 맞춤형 애니메이션 데이터가 손실될 수 있습니다. 테스트된 예제와 형식 제한 사항은 [Custom Animation](/slides/ko/net/custom-animation/)을 참고하십시오.