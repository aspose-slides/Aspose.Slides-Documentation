---
title: PHP에서 애니메이션으로 PowerPoint 프레젠테이션 향상
linktitle: PowerPoint 애니메이션
type: docs
weight: 150
url: /ko/php-java/powerpoint-animation/
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
- 셰이프 애니메이션
- 애니메이션 차트
- 애니메이션 텍스트
- 애니메이션 셰이프
- 애니메이션 OLE 개체
- 애니메이션 이미지
- 애니메이션 테이블
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java가 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 프레젠테이션을 향상시키는 주요 기능과 통찰력."
---
## **Introduction**

프레젠테이션은 무언가를 보여주기 위한 것이므로, 생성 시 시각적 외관과 인터랙티브한 동작이 항상 고려됩니다.

**PowerPoint animation**은 프레젠테이션을 눈에 띄고 관객을 끌어들이는 데 중요한 역할을 합니다. Aspose.Slides for PHP via Java은 PowerPoint 프레젠테이션에 애니메이션을 추가하기 위한 다양한 옵션을 제공합니다:

- 셰이프, 차트, 표, OLE 개체 및 기타 프레젠테이션 요소에 다양한 유형의 PowerPoint 애니메이션 효과를 적용합니다.
- 하나의 셰이프에 여러 PowerPoint 애니메이션 효과를 사용할 수 있습니다.
- 애니메이션 타임라인을 활용하여 애니메이션 효과를 제어합니다.
- 사용자 정의 애니메이션을 생성합니다.

Aspose.Slides for PHP via Java에서는 다양한 애니메이션 효과를 셰이프에 적용할 수 있습니다. 텍스트, 그림, OLE 개체 및 표를 포함한 슬라이드의 모든 요소가 셰이프로 간주되므로, 슬라이드의 모든 요소에 애니메이션 효과를 적용할 수 있습니다.

## **Animation Effects**
Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원하며, Bounce, PathFootball, Zoom과 같은 기본 효과와 OLEObjectShow, OLEObjectOpen과 같은 특정 효과가 포함됩니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttype/) 클래스에서 확인할 수 있습니다.

또한, 이러한 애니메이션 효과는 다음 동작과 결합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/SetEffect)

## **Custom Animation**
동작 및 편집 가능한 모션 경로를 생성, 검사 및 수정하는 전체 PHP 예제는 [Custom Animation](/slides/ko/php-java/custom-animation/)을 참고하세요.

Aspose.Slides에서 **custom animations**을 직접 만들 수 있습니다. 이는 여러 동작을 결합하여 새로운 사용자 정의 애니메이션을 만들면 구현됩니다.

[Behavior](https://reference.aspose.com/slides/ko/php-java/aspose.slides/behavior/)은 PowerPoint 애니메이션 효과의 기본 구성 요소입니다. 동작을 결합하여 효과를 사용자 지정하거나, 미리 정의된 효과를 확장하기 위해 동작을 추가할 수 있습니다. 반복은 별도의 repeat 동작이 아니라 타이밍 설정을 통해 구성됩니다.

[Animation Point](https://reference.aspose.com/slides/ko/php-java/aspose.slides/point/)은 동작을 적용해야 할 지점을 의미합니다.

## **Animation Time Line**
[Sequence](https://reference.aspose.com/slides/ko/php-java/aspose.slides/sequence/)은 서로 다른 셰이프를 대상으로 할 수 있는 애니메이션 효과들의 컬렉션입니다.

[Timeline](https://reference.aspose.com/slides/ko/php-java/aspose.slides/animationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. 이는 PowerPoint 2002에 도입된 애니메이션 엔진입니다. 이전 버전의 PowerPoint에서는 프레젠테이션에 애니메이션 효과를 추가하는 것이 어려웠으며 다양한 우회 방법만으로 가능했습니다. 타임라인은 PowerPoint 애니메이션에 대한 보다 명확한 객체 모델을 제공합니다. 하나의 슬라이드에는 하나의 애니메이션 타임라인만 존재할 수 있습니다.

## **Interactive Animation**
[Trigger](https://reference.aspose.com/slides/ko/php-java/aspose.slides/effecttriggertype/)를 사용하면 버튼 클릭과 같은 사용자 동작을 정의하여 특정 애니메이션을 시작할 수 있습니다.

## **Shape Animation**
Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 셰이프에 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**셰이프 애니메이션에 대하여**](/slides/ko/php-java/shape-animation/).
{{% /alert %}}

## **Animated Charts**
애니메이션 차트를 만들려면 셰이프와 동일한 클래스를 사용해야 합니다. 하지만 PowerPoint 애니메이션은 차트 카테고리 또는 차트 시리즈에만 적용할 수 있습니다. 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 차트에 대하여**](/slides/ko/php-java/animated-charts/).
{{% /alert %}}

## **Animated Text**
텍스트에 애니메이션을 적용하는 것 외에도, 단락에도 애니메이션을 적용할 수 있습니다.

{{% alert color="info" title="Note" %}}
자세히 보기 [**애니메이션 텍스트에 대하여**](/slides/ko/php-java/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

아니오. PDF는 정적 포맷이므로 애니메이션과 [slide transitions](/slides/ko/php-java/slide-transition/)가 재생되지 않습니다. 움직임이 필요하면 대신 [HTML5](/slides/ko/php-java/export-to-html5/), [animated GIF](/slides/ko/php-java/convert-powerpoint-to-animated-gif/), 또는 [video](/slides/ko/php-java/convert-powerpoint-to-video/)로 내보내세요.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

예. 프레젠테이션을 [render the presentation as frames](/slides/ko/php-java/convert-powerpoint-to-video/)로 프레임으로 렌더링한 뒤 비디오(e.g., ffmpeg 사용)로 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 중에 애니메이션과 슬라이드 전환이 재생됩니다.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX 및 ODP는 [reading](/slides/ko/php-java/open-presentation/) 및 [writing](/slides/ko/php-java/save-presentation/)을 지원하지만, 이는 애니메이션 보존을 보장하지는 않습니다. ODP로 변환할 때 사용자 정의 애니메이션 데이터가 손실될 수 있습니다. 형식 호환성을 확인하는 예제와 안내는 [Custom Animation](/slides/ko/php-java/custom-animation/)을 참고하십시오.