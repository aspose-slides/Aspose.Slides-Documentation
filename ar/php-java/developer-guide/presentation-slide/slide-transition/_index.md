---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام PHP
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/php-java/slide-transition/
keywords:
- انتقال شريحة
- إضافة انتقال شريحة
- تطبيق انتقال شريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides للـ PHP عبر Java، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

تتيح Aspose.Slides للـ PHP عبر Java أيضًا للمطورين إدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش التحكم في انتقالات الشرائح بسهولة كبيرة باستخدام Aspose.Slides للـ PHP عبر Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بعرض مثال على استخدام Aspose.Slides للـ PHP عبر Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات.

## **إضافة انتقال شريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المتاحة في Aspose.Slides للـ PHP عبر Java عبر تعداد TransitionType.
3. حفظ ملف العرض التقديمي المعدل.
```php
  # إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # تطبيق انتقال من نوع دائرة على الشريحة 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # تطبيق انتقال من نوع مشط على الشريحة 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # حفظ العرض التقديمي على القرص
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير أبسط وأكثر تحكمًا، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال المتاحة في Aspose.Slides للـ PHP عبر Java.
3. يمكنك أيضًا تعيين الانتقال إلى التقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
4. إذا تم تمكين انتقال الشريحة إلى التقدم عند النقر، فسيتقدم الانتقال فقط عندما ينقر أحدهم الفأرة. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد الوقت، سيتقدم الانتقال تلقائيًا بعد مرور الوقت المحدد.
5. حفظ العرض التقديمي المعدل كملف عرض تقديمي.
```php
  # إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # تطبيق انتقال من نوع دائرة على الشريحة 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # ضبط وقت الانتقال إلى 3 ثوانٍ
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # تطبيق انتقال من نوع مشط على الشريحة 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # ضبط وقت الانتقال إلى 5 ثوانٍ
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # تطبيق انتقال من نوع تكبير على الشريحة 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # ضبط وقت الانتقال إلى 7 ثوانٍ
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # حفظ العرض التقديمي على القرص
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **انتقال Morph**
{{% alert color="primary" %}} 

الآن تدعم Aspose.Slides للـ PHP عبر Java [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/IMorphTransition). تمثل هذه الخاصية الانتقال Morph الجديد الذي تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يسمح لك انتقال Morph بتحريك سلس من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال Morph. لاستخدامه بشكل فعال، تحتاج إلى شريحتين تشتركان على كائن واحد على الأقل. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

المقتطف البرمجي التالي يوضح كيفية إضافة نسخة من الشريحة تحتوي على نص إلى العرض وتعيين انتقال [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) إلى الشريحة الثانية.
```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **أنواع انتقال Morph**
تم إضافة تعداد جديد [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). يمثل أنواعًا مختلفة من انتقالات Morph للشرائح.

يحتوي تعداد TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للانقسام.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمة بكلمة حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

المقتطف البرمجي التالي يوضح كيفية تعيين انتقال Morph إلى الشريحة وتغيير نوع Morph:
```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **تعيين تأثيرات الانتقال**
يدعم Aspose.Slides للـ PHP عبر Java تعيين تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين وغيرها. لتعيين تأثير الانتقال، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- حفظ العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).

في المثال أدناه، قمنا بتعيين تأثيرات الانتقال.
```php
  # إنشاء نسخة من فئة Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # تعيين التأثير
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # حفظ العرض التقديمي على القرص
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **الأسئلة الشائعة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. قم بتعيين [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (مثلًا: بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت والتكرار (مثلًا: [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), بالإضافة إلى بيانات وصفية مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) و [setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتهيئة نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ يتم تخزين الانتقالات لكل شريحة، لذا فإن تطبيق نفس النوع على جميع الشرائح يعطي نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال الحالي المحدد على شريحة؟**

افحص [transition settings](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة واقرأ [transition type](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/)؛ هذه القيمة تخبرك بالضبط أي تأثير تم تطبيقه.