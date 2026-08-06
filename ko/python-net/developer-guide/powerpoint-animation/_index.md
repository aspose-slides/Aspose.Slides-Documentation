---
title: Python에서 애니메이션을 사용하여 PowerPoint 프레젠테이션 강화
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
- 맞춤형 애니메이션
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
description: "Aspose.Slides for Python via .NET이 PowerPoint 애니메이션을 처리하는 기능을 살펴보세요. 이 일반 개요에서는 주요 기능을 강조하고 프레젠테이션을 향상시키기 위한 통찰을 제공합니다."
---
## **소개**

프레젠테이션은 정보를 전달하기 위해 설계되므로 시각적 모습과 인터랙티브 동작이 핵심 고려 사항입니다.

**PowerPoint 애니메이션**은 프레젠테이션을 눈에 띄고 흥미롭게 만드는 중요한 역할을 합니다. Aspose.Slides for Python via .NET은 PowerPoint 프레젠테이션에 애니메이션을 추가할 수 있는 다양한 옵션을 제공합니다. 다음을 수행할 수 있습니다:

- 도형, 차트, 표, OLE 개체 및 기타 요소에 다양한 애니메이션 효과 적용
- 하나의 도형에 여러 애니메이션 효과 적용
- 애니메이션 타임라인을 통해 효과 제어
- 사용자 정의 애니메이션 생성

Aspose.Slides for Python via .NET에서는 도형에 애니메이션 효과를 적용할 수 있습니다. 슬라이드의 모든 요소—텍스트, 그림, OLE 개체, 표—가 도형으로 취급되기 때문에 슬라이드의 어떤 요소에도 애니메이션 효과를 적용할 수 있습니다.

[aspose.slides.animation](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/) 네임스페이스는 PowerPoint 애니메이션을 다루는 클래스를 제공합니다.

## **설치**

```bash
pip install aspose.slides
```

## **Python에서 도형에 애니메이션 효과 추가**

애니메이션 효과는 슬라이드의 메인 시퀀스에 존재합니다. 도형을 추가한 다음 `slide.timeline.main_sequence`의 `add_effect`를 호출하고, 효과 유형, 하위 유형, 트리거를 전달합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

저장된 파일에는 첫 번째 슬라이드에 하나의 효과가 포함됩니다: 사각형이 왼쪽에서 날아와 2초 동안 표시되고 발표자가 클릭하면 재생됩니다. 파일을 다시 열어 `slide.timeline.main_sequence`를 읽으면 해당 효과가 반환되므로, 애니메이션은 메모리에서만 존재하지 않고 라운드 트립을 통해 유지됩니다.

## **애니메이션 효과**

Aspose.Slides는 **150개 이상의 애니메이션 효과**를 지원합니다. Bounce, PathFootball, Zoom과 같은 기본 효과는 물론 OLEObjectShow, OLEObjectOpen과 같은 특수 효과도 포함됩니다. 전체 목록은 [EffectType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttype/) 열거형에서 확인할 수 있습니다.

또한 다음 효과와 결합하여 사용할 수 있습니다:

- [ColorEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/seteffect/)

## **사용자 정의 애니메이션**

여러 동작을 하나의 효과로 결합하여 **사용자 정의 애니메이션**을 만들 수 있습니다.

[Behavior](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/behavior/)은 모든 PowerPoint 애니메이션 효과의 기본 빌딩 블록입니다. 각 애니메이션 효과는 본질적으로 하나의 전략이나 타임라인에 배치된 동작 집합입니다. 동작을 한 번 조합해 사용자 정의 애니메이션을 만든 뒤 다른 프레젠테이션에서 재사용할 수 있습니다. 표준 PowerPoint 애니메이션에 새 동작을 추가하면 사용자 정의 애니메이션이 됩니다—예를 들어 반복 동작을 추가해 애니메이션을 여러 번 재생하도록 할 수 있습니다.

[Animation Point](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/point/)은 동작이 적용되는 순간이나 위치(키프레임)를 표시합니다.

## **애니메이션 타임라인**

[Sequence](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/)은 특정 도형에 적용되는 애니메이션 효과들의 컬렉션입니다.

[Timeline](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/animationtimeline/)은 특정 슬라이드에서 사용되는 시퀀스 집합입니다. PowerPoint 2002에서 도입되었습니다. 이전 버전에서는 애니메이션 효과를 추가하기가 어려웠고 종종 우회 방법이 필요했습니다. Timeline은 기존 `AnimationSettings` 클래스를 대체하고 PowerPoint 애니메이션을 위한 더 명확한 객체 모델을 제공합니다. 각 슬라이드에는 하나의 애니메이션 타임라인만 존재할 수 있습니다.

## **상호 작용 애니메이션**

[Trigger](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/)를 사용하면 사용자 동작(예: 버튼 클릭)으로 특정 애니메이션을 시작하도록 정의할 수 있습니다. 트리거는 최신 버전의 PowerPoint에서만 추가되었습니다.

## **도형 애니메이션**

Aspose.Slides를 사용하면 텍스트, 사각형, 선, 프레임, OLE 개체 등 다양한 도형에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}}
More reading [**About Shape Animation**](/slides/ko/python-net/shape-animation/).
{{% /alert %}}

## **애니메이션 차트**

애니메이션 차트를 만들려면 도형에 사용하는 것과 동일한 클래스를 사용합니다. 단, PowerPoint 애니메이션은 차트 카테고리 또는 차트 시리즈에만 적용될 수 있습니다. 개별 카테고리 요소나 시리즈 요소에도 애니메이션 효과를 적용할 수 있습니다.

{{% alert color="primary" %}}
More reading [**About Animated Charts**](/slides/ko/python-net/animated-charts/).
{{% /alert %}}

## **애니메이션 텍스트**

텍스트를 애니메이션하는 것 외에도 단락에 애니메이션을 적용할 수 있습니다.

{{% alert color="primary" %}}
More reading [**About Animated Text**](/slides/ko/python-net/animated-text/).
{{% /alert %}}

## **FAQ**

### PDF로 내보낼 때 애니메이션이 유지되나요?

아니요. PDF는 정적 형식이므로 애니메이션과 [슬라이드 전환](/slides/ko/python-net/slide-transition/)이 재생되지 않습니다. 움직임이 필요하면 [HTML5](/slides/ko/python-net/export-to-html5/), [animated GIF](/slides/ko/python-net/convert-powerpoint-to-animated-gif/), 또는 [비디오](/slides/ko/python-net/convert-powerpoint-to-video/)로 내보내세요.

### 애니메이션 프레젠테이션을 비디오로 변환하고 프레임 레이트와 프레임 크기를 제어할 수 있나요?

네. 프레젠테이션을 프레임으로 [렌더링](/slides/ko/python-net/convert-powerpoint-to-video/)한 뒤 ffmpeg 등으로 비디오를 인코딩하면서 FPS와 해상도를 선택할 수 있습니다. 렌더링 과정에서 애니메이션과 슬라이드 전환이 재생됩니다.

### ODP(단순히 PPTX가 아니라)와 작업할 때도 애니메이션이 그대로 유지되나요?

PPT, PPTX, ODP는 [읽기](/slides/ko/python-net/open-presentation/) 및 [쓰기](/slides/ko/python-net/save-presentation/)를 지원하지만, 포맷 차이로 인해 일부 효과가 약간 다르게 보이거나 동작할 수 있습니다. 중요한 경우 실제 샘플로 검증하세요.