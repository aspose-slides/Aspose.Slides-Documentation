---
title: نص متحرك
type: docs
weight: 60
url: /php-java/animated-text/
keywords: "نص متحرك في PowerPoint"
description: "نص متحرك في PowerPoint باستخدام Java"
---

## إضافة تأثيرات الرسوم المتحركة إلى الفقرات

لقد أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئتين [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يوضح لك هذا الرمز النموذجي كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # تحديد الفقرة لإضافة التأثير
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # إضافة تأثير رسوم متحركة Fly إلى الفقرة المحددة
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## الحصول على تأثيرات الرسوم المتحركة في الفقرات

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة ما—على سبيل المثال، في سيناريو واحد، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تسمح لك Aspose.Slides لـ PHP عبر Java بالحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة في إطار نص (شكل). يوضح لك هذا الرمز النموذجي كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("الفقرة \"" . $paragraph->getText() . "\" تحتوي على تأثير من نوع " . $effects[0]->getType() . ".");
      }
    }
  } finally {
    $pres->dispose();
  }
```