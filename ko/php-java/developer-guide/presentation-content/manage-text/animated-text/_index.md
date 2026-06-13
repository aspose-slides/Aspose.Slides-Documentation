---
title: PHP에서 PowerPoint 텍스트 애니메이션
linktitle: 애니메이션 텍스트
type: docs
weight: 60
url: /ko/php-java/animated-text/
keywords:
- 애니메이션 텍스트
- 텍스트 애니메이션
- 애니메이션 단락
- 단락 애니메이션
- 애니메이션 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 동적인 애니메이션 텍스트를 생성하고, 따라하기 쉬운 최적화된 코드 예제를 제공합니다."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 개별 단락에 애니메이션 효과를 적용하고 텍스트 프레임의 단락에 이미 할당된 효과를 가져오는 방법을 설명합니다. 프레젠테이션에서 단락 수준 애니메이션을 추가하고 기존 단락 애니메이션 효과를 검사하는 데 사용되는 API 메서드에 중점을 둡니다.

## **Add Animation Effects to Paragraphs**

우리는 [**addEffect()**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) 메서드를 [**Sequence**](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Sequence) 클래스에 추가했습니다. 이 메서드를 사용하면 단일 단락에 애니메이션 효과를 추가할 수 있습니다. 다음 샘플 코드는 단일 단락에 애니메이션 효과를 추가하는 방법을 보여줍니다:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # 효과를 추가할 단락 선택
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # 선택한 단락에 Fly 애니메이션 효과 추가
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Get Animation Effects of Paragraphs**

단락에 추가된 애니메이션 효과를 확인하려는 경우가 있을 수 있습니다. 예를 들어, 한 상황에서는 해당 효과를 다른 단락이나 도형에 적용하려고 단락의 애니메이션 효과를 가져오고 싶을 수 있습니다.

Java를 통해 PHP용 Aspose.Slides를 사용하면 텍스트 프레임(도형) 내에 포함된 단락에 적용된 모든 애니메이션 효과를 가져올 수 있습니다. 다음 샘플 코드는 단락의 애니메이션 효과를 가져오는 방법을 보여줍니다:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**텍스트 애니메이션은 슬라이드 전환과 어떻게 다르며, 결합할 수 있나요?**

텍스트 애니메이션은 슬라이드에서 객체의 동작을 시간에 따라 제어하고, [전환](/slides/ko/php-java/slide-transition/)은 슬라이드가 전환되는 방식을 제어합니다. 두 기능은 독립적이며 함께 사용할 수 있으며, 재생 순서는 애니메이션 타임라인과 전환 설정에 따라 결정됩니다.

**텍스트 애니메이션이 PDF나 이미지로 내보낼 때 유지되나요?**

아니요. PDF와 래스터 이미지는 정적이므로 슬라이드의 움직임 없이 단일 상태만 표시됩니다. 움직임을 유지하려면 [비디오](/slides/ko/php-java/convert-powerpoint-to-video/) 또는 [HTML](/slides/ko/php-java/export-to-html5/) 형식으로 내보내세요.

**텍스트 애니메이션이 레이아웃 및 슬라이드 마스터에서도 작동하나요?**

레이아웃/마스터 객체에 적용된 효과는 슬라이드에 상속되지만, 해당 타이밍 및 슬라이드 수준 애니메이션과의 상호 작용은 슬라이드의 최종 시퀀스에 따라 달라집니다.