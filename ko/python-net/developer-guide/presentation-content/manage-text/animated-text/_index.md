---
title: Python에서 PowerPoint 텍스트 애니메이션
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/python-net/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 동적인 애니메이션 텍스트를 만들고, 따라하기 쉬운 최적화된 코드 예제를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python을 사용하여 PowerPoint 프레젠테이션에서 텍스트에 애니메이션을 적용하는 방법을 보여줍니다. 개별 단락에 효과를 추가하고, 트리거를 조정하며, 기존 애니메이션 시퀀스를 읽어오는 방법을 배우게 됩니다. 최종적으로 표준 PPTX로 내보내고 PowerPoint에서 올바르게 재생되는 재사용 가능한 텍스트 애니메이션 워크플로를 만들 수 있습니다.

## **단락 애니메이션 효과 추가**

[add_effect](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/add_effect/) 메서드와 [Sequence](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/) 클래스는 단일 단락에 애니메이션 효과를 적용할 수 있게 해줍니다. 아래 샘플 코드는 이를 수행하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # 효과를 추가할 단락을 선택합니다.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 선택한 단락에 Fly 애니메이션 효과를 추가합니다.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **단락 애니메이션 효과 가져오기**

단락에 적용된 애니메이션 효과를 확인하고 싶을 수 있습니다—예를 들어 해당 효과를 다른 단락이나 도형에 복사하려는 경우.

Aspose.Slides for Python을 사용하면 텍스트 프레임(도형) 내 단락에 적용된 모든 애니메이션 효과를 검색할 수 있습니다. 아래 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 함께 사용할 수 있나요?**

텍스트 애니메이션은 슬라이드 내에서 개체의 동작을 시간에 따라 제어하는 반면, [transitions](/slides/ko/python-net/slide-transition/)는 슬라이드가 전환되는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있으며, 재생 순서는 애니메이션 타임라인과 전환 설정에 의해 결정됩니다.

**PDF 또는 이미지로 내보낼 때 텍스트 애니메이션이 유지되나요?**

아니요. PDF와 래스터 이미지는 정적인 것이므로 슬라이드의 정지된 상태만 표시됩니다. 움직임을 유지하려면 [video](/slides/ko/python-net/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/python-net/export-to-html5/) 형식으로 내보내십시오.

**텍스트 애니메이션은 레이아웃 및 슬라이드 마스터에서도 작동하나요?**

레이아웃/마스터 객체에 적용된 효과는 슬라이드에 상속되지만, 해당 타이밍 및 슬라이드 수준 애니메이션과의 상호 작용은 슬라이드의 최종 시퀀스에 따라 달라집니다.