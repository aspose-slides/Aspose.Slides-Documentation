---
title: Python via Java를 사용한 PowerPoint 텍스트 애니메이션
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/python-java/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 동적 애니메이션 텍스트를 만들고, 따라하기 쉬운 최적화된 Python 코드 예제를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 애니메이션 텍스트를 다루는 방법을 설명합니다. 개별 단락에 애니메이션 효과를 적용하고 텍스트 프레임 안의 단락에 이미 할당된 효과를 검색하는 방법을 다룹니다. 프레젠테이션에서 단락 수준 애니메이션을 추가하고 기존 단락 애니메이션 효과를 검사하는 API 메서드에 중점을 둡니다.

## **단락에 애니메이션 효과 추가**

[addEffect](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/#addEffect) 메서드와 [Sequence](https://reference.aspose.com/slides/ko/python-java/aspose.slides/sequence/) 클래스를 사용하면 단일 단락에 애니메이션 효과를 추가할 수 있습니다. 다음 샘플 코드는 단일 단락에 애니메이션 효과를 추가하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # 효과를 추가할 단락을 선택합니다.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 선택한 단락에 Fly 애니메이션 효과를 추가합니다.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **단락의 애니메이션 효과 가져오기**

단락에 추가된 애니메이션 효과를 확인하고자 할 수 있습니다. 예를 들어, 다른 단락이나 도형에 동일한 효과를 적용하려는 경우가 있습니다.

Aspose.Slides for Python via Java를 사용하면 텍스트 프레임(도형) 안에 포함된 모든 단락에 적용된 애니메이션 효과를 가져올 수 있습니다. 다음 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **FAQ**

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 결합하여 사용할 수 있나요?**

텍스트 애니메이션은 슬라이드 내 개체의 동작을 시간에 따라 제어하고, [transitions](/slides/ko/python-java/slide-transition/)는 슬라이드가 전환되는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있으며, 재생 순서는 애니메이션 타임라인과 전환 설정에 따라 결정됩니다.

**PDF 또는 이미지로 내보낼 때 텍스트 애니메이션이 유지되나요?**

아니요. PDF와 래스터 이미지는 정적인 형태이므로 움직임 없이 슬라이드의 한 상태만 표시됩니다. 움직임을 유지하려면 [video](/slides/ko/python-java/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/python-java/export-to-html5/) 내보내기를 사용하세요.

**레이아웃 및 슬라이드 마스터에서도 텍스트 애니메이션이 작동하나요?**

레이아웃/마스터 개체에 적용된 효과는 슬라이드에 상속되지만, 타이밍 및 슬라이드 수준 애니메이션과의 상호 작용은 최종 슬라이드 시퀀스에 따라 달라집니다.