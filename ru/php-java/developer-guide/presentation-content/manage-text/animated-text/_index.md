---
title: Анимированный текст
type: docs
weight: 60
url: /php-java/animated-text/
keywords: "Анимированный текст в PowerPoint"
description: "Анимированный текст в PowerPoint с помощью Java"
---

## Добавление эффектов анимации к абзацам

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). Этот метод позволяет добавлять эффекты анимации к отдельному абзацу. Этот пример кода показывает, как добавить эффект анимации к отдельному абзацу:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # выбрать абзац для добавления эффекта
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # добавить эффект анимации "Лететь" к выбранному абзацу
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## Получение эффектов анимации в абзацах

Вы можете решить узнать об эффектах анимации, добавленных к абзацу — например, в одном из сценариев вы хотите получить эффекты анимации в абзаце, потому что планируете применить эти эффекты к другому абзацу или фигуре.

Aspose.Slides для PHP через Java позволяет вам получить все эффекты анимации, примененные к абзацам, содержащимся в текстовом фрейме (фигуре). Этот пример кода показывает, как получить эффекты анимации в абзаце:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Абзац \"" . $paragraph->getText() . "\" имеет эффект " . $effects[0]->getType() . ".");
      }
    }
  } finally {
    $pres->dispose();
  }
```