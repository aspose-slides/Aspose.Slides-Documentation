---
title: تحريك نص PowerPoint في PHP
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/php-java/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير حركي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java، مع أمثلة تعليمية مُحسّنة وسهلة المتابعة."
---

## **إضافة تأثيرات الحركية إلى الفقرات**

لقد أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئات [**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence). تسمح لك هذه الطريقة بإضافة تأثيرات الحركية إلى فقرة واحدة. يُظهر لك هذا المثال البرمجي كيفية إضافة تأثير حركي إلى فقرة واحدة:
```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # حدد الفقرة لإضافة تأثير
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # أضف تأثير التحليق (Fly) للفقرة المحددة
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **الحصول على تأثيرات الحركية للفقرات**

قد ترغب في معرفة تأثيرات الحركية المضافة إلى فقرة ما—على سبيل المثال، في حالة معينة قد تريد الحصول على تأثيرات الحركية في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

يتيح لك Aspose.Slides for PHP عبر Java الحصول على جميع تأثيرات الحركية المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يُظهر لك هذا المثال البرمجي كيفية الحصول على تأثيرات الحركية في فقرة:
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

**كيف تختلف تأثيرات النص المتحركة عن انتقالات الشرائح، وهل يمكن دمجها؟**

تتحكم تأثيرات النص المتحركة في سلوك الكائن مع مرور الوقت على الشريحة، بينما [transitions](/slides/ar/php-java/slide-transition/) تتحكم في كيفية تغيير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة خط زمني للتأثيرات وإعدادات الانتقال.

**هل يتم الاحتفاظ بتأثيرات النص المتحركة عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك سترى حالة واحدة من الشريحة دون حركة. للحفاظ على الحركة، استخدم تصدير [video](/slides/ar/php-java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/php-java/export-to-html5/).

**هل تعمل تأثيرات النص المتحركة في التخطيطات وسيد الشريحة؟**

تُورّث التأثيرات المطبقة على كائنات التخطيط/السيد الرئيسي إلى الشرائح، لكن توقيتها وتفاعلها مع تأثيرات مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.