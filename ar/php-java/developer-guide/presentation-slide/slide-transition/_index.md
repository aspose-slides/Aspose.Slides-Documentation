---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام PHP
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/php-java/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف كيفية تخصيص انتقالات الشرائح في Aspose.Slides for PHP عبر Java، مع إرشادات خطوة بخطوة لعروض PowerPoint و OpenDocument."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

تتيح Aspose.Slides for PHP عبر Java أيضًا للمطورين إدارة أو تخصيص تأثيرات انتقال الشرائح. في هذا الموضوع، سنناقش التحكم في انتقالات الشرائح بسهولة كبيرة باستخدام Aspose.Slides for PHP عبر Java.

{{% /alert %}} 

لتسهيل الفهم، قمنا بعرض استخدام Aspose.Slides for PHP عبر Java لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال مختلفة على الشرائح، بل أيضًا تخصيص سلوك هذه التأثيرات.

## **إضافة انتقال الشريحة**
لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for PHP عبر Java من خلال تعداد TransitionType.
3. كتابة ملف العرض التقديمي المعدل.
```php
  # إنشاء مثيل فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # تطبيق انتقال بنوع دائرة على الشريحة 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # تطبيق انتقال بنوع مشط على الشريحة 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # حفظ العرض التقديمي إلى القرص
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **إضافة انتقال شريحة متقدم**
في القسم السابق، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل هذا التأثير البسيط أفضل ومتحكمًا فيه، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
2. تطبيق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تقدمها Aspose.Slides for PHP عبر Java.
3. يمكنك أيضًا تعيين الانتقال إلى التقدم عند النقر، بعد فترة زمنية محددة أو كلاهما.
4. إذا تم تمكين انتقال الشريحة للتقدم عند النقر، فإن الانتقال سيتقدم فقط عندما ينقر أحدهم الفأرة. علاوة على ذلك، إذا تم تعيين خاصية Advance After Time، فإن الانتقال سيتقدم تلقائيًا بعد مرور الوقت المحدد للتقدم.
5. كتابة العرض التقديمي المعدل كملف عرض تقديمي.
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # تطبيق انتقال بنوع دائرة على الشريحة 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # تحديد مدة الانتقال بـ 3 ثوانٍ
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # تطبيق انتقال بنوع مشط على الشريحة 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # تحديد مدة الانتقال بـ 5 ثوانٍ
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # تطبيق انتقال بنوع تكبير على الشريحة 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # تحديد مدة الانتقال بـ 7 ثوانٍ
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **انتقال Morph**
{{% alert color="primary" %}} 

تدعم Aspose.Slides for PHP عبر Java الآن [Morph Transition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/). إنها تمثل انتقاليًّا جديدًا تم تقديمه في PowerPoint 2019.

{{% /alert %}} 

يسمح لك انتقال Morph بتحريك حركة سلسة من شريحة إلى أخرى. يصف هذا المقال المفهوم وكيفية استخدام انتقال Morph. لاستخدام انتقال Morph بشكل فعّال، ستحتاج إلى شريحتين تتشاركان على الأقل كائنًا واحدًا. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

يظهر المقتطف البرمجي التالي كيفية إضافة نسخة من الشريحة مع بعض النص إلى العرض التقديمي وتعيين انتقال من نوع [morph type](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionType) إلى الشريحة الثانية.
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
تم إضافة تعداد جديد [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/TransitionMorphType). يمثل أنواعًا مختلفة من انتقال شريحة Morph.

يحتوي تعداد TransitionMorphType على ثلاثة أعضاء:

- ByObject: سيتم تنفيذ انتقال Morph مع اعتبار الأشكال ككائنات غير قابلة للتقسيم.
- ByWord: سيتم تنفيذ انتقال Morph بنقل النص كلمةً كلمةً حيثما أمكن.
- ByChar: سيتم تنفيذ انتقال Morph بنقل النص حرفًا بحرف حيثما أمكن.

يظهر المقتطف البرمجي التالي كيفية تعيين انتقال Morph إلى الشريحة وتغيير نوع Morph:
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
تدعم Aspose.Slides for PHP عبر Java تعيين تأثيرات الانتقال مثل من الأسود، من اليسار، من اليمين، إلخ. لتعيين تأثير الانتقال، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة.
- تعيين تأثير الانتقال.
- كتابة العرض التقديمي كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/).

في المثال المعطى أدناه، قمنا بتعيين تأثيرات الانتقال.
```php
  # إنشاء مثيل من فئة Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # تعيين التأثير
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # حفظ العرض التقديمي إلى القرص
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. قم بتعيين [speed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setspeed/) للانتقال باستخدام إعداد [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) (مثلاً بطيء/متوسط/سريع).

**هل يمكنني إرفاق صوت بانتقال وجعله يتكرر؟**

نعم. يمكنك تضمين صوت للانتقال والتحكم في سلوكه عبر إعدادات مثل وضع الصوت وإعادة التكرار (مثل [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundloop/), بالإضافة إلى بيانات وصفية مثل [setSoundIsBuiltIn](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) و[setSoundName](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**ما هي أسرع طريقة لتطبيق نفس الانتقال على كل شريحة؟**

قم بتكوين نوع الانتقال المطلوب في إعدادات انتقال كل شريحة؛ يتم تخزين الانتقالات لكل شريحة، لذا فإن تطبيق نفس النوع على جميع الشرائح يوفر نتيجة متسقة.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

افحص [إعدادات الانتقال](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة واقرأ [نوع الانتقال](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/settype/); القيمة التي تُظهرها تخبرك بالضبط أي تأثير تم تطبيقه.