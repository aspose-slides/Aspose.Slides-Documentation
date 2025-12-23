---
title: Анимация текста PowerPoint в PHP
linktitle: Анимированный текст
type: docs
weight: 60
url: /ru/php-java/animated-text/
keywords:
- анимированный текст
- анимация текста
- анимированный абзац
- анимация абзаца
- эффект анимации
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создайте динамический анимированный текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for PHP via Java, используя простые, оптимизированные примеры кода."
---

## **Добавление анимационных эффектов к абзацам**

Мы добавили метод [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) в классы [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) и [**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). Этот метод позволяет добавить анимационные эффекты к отдельному абзацу. В этом примере кода показано, как добавить анимационный эффект к отдельному абзацу:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # выбрать абзац для добавления эффекта
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # добавить анимационный эффект Fly к выбранному абзацу
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Получение анимационных эффектов абзацев**

Возможно, вам потребуется узнать, какие анимационные эффекты добавлены к абзацу — например, в одном случае вы хотите получить анимационные эффекты абзаца, чтобы применить их к другому абзацу или фигуре.

Aspose.Slides for PHP via Java позволяет получить все анимационные эффекты, применённые к абзацам, содержащимся в текстовом фрейме (фигуре). В этом примере кода показано, как получить анимационные эффекты в абзаце:
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


## **Часто задаваемые вопросы**

**Чем анимация текста отличается от переходов между слайдами, и можно ли их комбинировать?**

Анимация текста управляет поведением объекта во времени на слайде, тогда как [переходы](/slides/ru/php-java/slide-transition/) контролируют, как меняются слайды. Они независимы и могут использоваться совместно; порядок воспроизведения определяется временной шкалой анимации и настройками переходов.

**Сохраняется ли анимация текста при экспорте в PDF или изображения?**

Нет. PDF и растровые изображения статичны, поэтому вы увидите единственное состояние слайда без движения. Чтобы сохранить анимацию, используйте экспорт в [видео](/slides/ru/php-java/convert-powerpoint-to-video/) или [HTML](/slides/ru/php-java/export-to-html5/).

**Работает ли анимация текста в макетах и главном слайде?**

Эффекты, применённые к объектам макета/главного шаблона, наследуются слайдами, однако их временные параметры и взаимодействие с анимациями уровня слайда зависят от окончательной последовательности на слайде.