---
title: تحريك نص PowerPoint في PHP
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/php-java/animated-text/
keywords:
- نص متحرك
- رسوم متحركة للنص
- فقرة متحركة
- رسوم متحركة للفقرة
- تأثير حركة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java، مع أمثلة كود سهلة المتابعة ومُحسّنة."
---

## **إضافة تأثيرات الحركة إلى الفقرات**

قمنا بإضافة طريقة [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئة [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence). تسمح لك هذه الطريقة بإضافة تأثيرات الحركة إلى فقرة واحدة. يوضح لك هذا المثال البرمجي كيفية إضافة تأثير حركة إلى فقرة واحدة:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # اختيار الفقرة لإضافة تأثير
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # إضافة تأثير الحركة Fly إلى الفقرة المحددة
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **الحصول على تأثيرات الحركة للفقرات**

قد ترغب في معرفة تأثيرات الحركة المضافة إلى فقرة—على سبيل المثال، في سيناريو معين، تريد الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

يسمح Aspose.Slides for PHP via Java بالحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا المثال البرمجي كيفية الحصول على تأثيرات الحركة في فقرة:
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


## **الأسئلة الشائعة**

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجها؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن مع مرور الوقت على الشريحة، بينما [الانتقالات](/slides/ar/php-java/slide-transition/) تتحكم في طريقة تغير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول زمني للرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على الرسوم المتحركة للنص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك سترى حالة واحدة فقط من الشريحة دون حركة. للحفاظ على الحركة، استخدم التصدير إلى [فيديو](/slides/ar/php-java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/php-java/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في التخطيطات وسلايدر الماستر؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعله مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي على الشريحة.