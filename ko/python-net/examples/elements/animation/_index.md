---
title: 애니메이션
type: docs
weight: 100
url: /ko/python-net/examples/elements/animation/
keywords:
- 애니메이션
- 애니메이션 추가
- 애니메이션 접근
- 애니메이션 제거
- 애니메이션 시퀀스
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용한 Python에서 슬라이드 애니메이션을 마스터하고, 효과, 타이밍 및 트리거를 추가, 편집, 제거하여 PPT, PPTX 및 ODP 형식의 동적 프레젠테이션을 만들 수 있습니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 간단한 애니메이션을 만들고 순서를 관리하는 방법을 보여줍니다.

## **애니메이션 추가**

클릭 시 트리거되는 페이드 효과를 적용하기 위해 사각형 모양을 생성합니다.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # 페이드 인 효과를 추가합니다.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **애니메이션 접근**

슬라이드 타임라인에서 첫 번째 애니메이션 효과를 가져옵니다.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 애니메이션 효과에 접근합니다.
        effect = slide.timeline.main_sequence[0]
```

## **애니메이션 제거**

시퀀스에서 애니메이션 효과를 제거합니다.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # 주 시퀀스에 최소 하나의 효과가 포함되어 있다고 가정합니다.
        effect = slide.timeline.main_sequence[0]

        # 효과를 제거합니다.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **애니메이션 순서 지정**

다중 효과를 추가하고 애니메이션이 발생하는 순서를 보여줍니다.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```