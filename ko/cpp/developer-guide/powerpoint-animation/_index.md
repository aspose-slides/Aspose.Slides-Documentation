---
title: C++에서 애니메이션을 사용하여 PowerPoint 프레젠테이션 향상
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
- 대화형 애니메이션
- 사용자 정의 애니메이션
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
description: "Aspose.Slides for C++에서 고급 애니메이션 효과를 추가하고 제어하여 동적인 PowerPoint 및 OpenDocument 프레젠테이션을 만드는 방법을 배웁니다."
---
## **소개**

프레젠테이션은 무언가를 보여주기 위한 것이므로, 제작 과정에서 시각적인 모습과 인터랙티브한 동작을 항상 고려합니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 시청자에게 몰입감을 주는 데 중요한 역할을 합니다. Aspose.Slides는 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다.

- 도형, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 유형의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 도형에 여러 PowerPoint 애니메이션 효과를 사용합니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 사용자 정의 애니메이션을 생성합니다.

Aspose.Slides에서는 다양한 애니메이션 효과를 도형에 적용할 수 있습니다. 텍스트, 그림, OLE 개체 및 표를 포함한 슬라이드의 모든 요소가 도형으로 간주되므로, 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

[Aspose::Slides::Animation](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/) 네임스페이스는 PowerPoint 애니메이션 작업을 위한 클래스를 제공합니다.

## **애니메이션 효과**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원합니다. 여기에는 Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 효과가 포함됩니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttype/) 열거형에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 다음 동작과 결합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/seteffect/)

## **사용자 정의 애니메이션**

전체 C++ 예제로 동작 및 편집 가능한 모션 경로를 생성, 검사 및 수정하는 방법은 [Custom Animation](/slides/ko/cpp/custom-animation/)을 참조하십시오.

Aspose.Slides에서는 **사용자 정의 애니메이션**을 생성할 수 있습니다. 이는 여러 동작을 결합하여 새로운 사용자 정의 애니메이션을 만들면 가능합니다.

[Behavior](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/behavior/)은 PowerPoint 애니메이션 효과의 구성 요소입니다. 동작을 결합해 효과를 맞춤화하거나, 미리 정의된 효과를 확장하기 위해 동작을 추가합니다. 반복은 별도의 반복 동작이 아니라 타이밍 설정을 통해 구성됩니다.

[Animation Point](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/point/)은 동작이 적용되어야 하는 지점을 의미합니다.

## **애니메이션 타임라인**
[Sequence](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/sequence/)은 서로 다른 도형을 대상으로 할 수 있는 애니메이션 효과들의 컬렉션입니다.

[IAnimationTimeLine](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ianimationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진이며, 이전 버전에서는 애니메이션 효과를 추가하기가 어려워 다양한 우회 방법을 사용해야 했습니다. 타임라인은 PowerPoint 애니메이션에 대한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 하나의 애니메이션 타임라인만 존재할 수 있습니다.

## **대화형 애니메이션**
[Trigger](https://reference.aspose.com/slides/ko/cpp/aspose.slides.animation/effecttriggertype/)를 사용하면 버튼 클릭과 같은 사용자 동작을 정의하여 특정 애니메이션을 시작시킬 수 있습니다.

## **도형 애니메이션**
Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**도형 애니메이션에 대해**](/slides/ko/cpp/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**
애니메이션 차트를 만들려면 도형과 동일한 클래스를 사용해야 합니다. 다만 PowerPoint 애니메이션은 차트 범주 또는 차트 계열에만 적용될 수 있습니다. 범주 요소 또는 계열 요소에 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 차트에 대해**](/slides/ko/cpp/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**
텍스트를 애니메이션하는 것 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 텍스트에 대해**](/slides/ko/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF로 내보낼 때 애니메이션이 보존되나요?**

아니요. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/cpp/slide-transition/)이 재생되지 않습니다. 모션이 필요하다면 [HTML5](/slides/ko/cpp/export-to-html5/), [animated GIF](/slides/ko/cpp/convert-powerpoint-to-animated-gif/) 또는 [video](/slides/ko/cpp/convert-powerpoint-to-video/)로 내보내세요.

**애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?**

예. 프레젠테이션을 [프레임으로 렌더링](/slides/ko/cpp/convert-powerpoint-to-video/)한 뒤 ffmpeg 등으로 비디오를 인코딩하면 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**ODP에서도 애니메이션이 유지되나요 (PPTX뿐 아니라)?**

PPT, PPTX 및 ODP는 [읽기](/slides/ko/cpp/open-presentation/)와 [쓰기](/slides/ko/cpp/save-presentation/)를 지원하지만, 애니메이션 보존을 보장하지는 않습니다. ODP로 변환할 때 사용자 정의 애니메이션 데이터가 손실될 수 있습니다. 형식 호환성을 확인하는 예제와 가이드는 [Custom Animation](/slides/ko/cpp/custom-animation/)을 참고하세요.