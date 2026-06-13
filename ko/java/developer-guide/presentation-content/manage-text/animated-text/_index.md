---
title: Java에서 PowerPoint 텍스트 애니메이션
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/java/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 동적인 애니메이션 텍스트를 만들고, 쉽게 따라 할 수 있는 최적화된 Java 코드 예제를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 개별 단락에 애니메이션 효과를 적용하고 텍스트 프레임의 단락에 이미 할당된 효과를 가져오는 방법을 설명합니다. 프레젠테이션에서 단락 수준 애니메이션을 추가하고 기존 단락 애니메이션 효과를 검사하는 데 사용되는 API 메서드에 중점을 둡니다.

## **단락에 애니메이션 효과 추가**

우리는 [**addEffect()**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 메서드를 [**Sequence**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Sequence) 및 [**ISequence**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISequence) 클래스에 추가했습니다. 이 메서드를 사용하면 단일 단락에 애니메이션 효과를 추가할 수 있습니다. 다음 샘플 코드는 단일 단락에 애니메이션 효과를 추가하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // 효과를 추가할 단락 선택
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 선택한 단락에 Fly 애니메이션 효과 추가
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **단락의 애니메이션 효과 가져오기**

단락에 추가된 애니메이션 효과를 확인하고 싶을 수 있습니다—예를 들어, 한 시나리오에서는 해당 효과를 다른 단락이나 도형에 적용하려고 하기 때문에 단락의 애니메이션 효과를 가져오고자 합니다. Aspose.Slides for Java는 텍스트 프레임(도형) 내에 포함된 단락에 적용된 모든 애니메이션 효과를 가져올 수 있도록 합니다. 다음 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```

## **FAQ**

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 결합할 수 있나요?**

텍스트 애니메이션은 슬라이드에서 객체의 동작을 시간에 따라 제어하고, [전환](/slides/ko/java/slide-transition/)은 슬라이드가 변경되는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있으며, 재생 순서는 애니메이션 타임라인과 전환 설정에 의해 결정됩니다.

**PDF나 이미지로 내보낼 때 텍스트 애니메이션이 유지되나요?**

아니요. PDF와 래스터 이미지는 정적이므로 슬라이드의 움직임 없이 단일 상태만 표시됩니다. 움직임을 유지하려면 [비디오](/slides/ko/java/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/java/export-to-html5/) 형식으로 내보내세요.

**텍스트 애니메이션이 레이아웃 및 슬라이드 마스터에서도 작동하나요?**

레이아웃/마스터 객체에 적용된 효과는 슬라이드에 상속되지만, 타이밍 및 슬라이드 수준 애니메이션과의 상호 작용은 슬라이드의 최종 시퀀스에 따라 달라집니다.