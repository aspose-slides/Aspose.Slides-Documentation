---
title: استنساخ شرائح العرض التقديمي في PHP
linktitle: استنساخ الشرائح
type: docs
weight: 35
url: /ar/php-java/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "قم بنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides for PHP. اتبع أمثلة الكود الواضحة لدينا لأتمتة إنشاء العروض التقديمية خلال ثوانٍ وإزالة العمل اليدوي."
---
## **المقدمة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة طبق الأصل من شيء ما. تجعل Aspose.Slides for PHP via Java من الممكن إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض الحالي أو أي عرض آخر مفتوح. عملية استنساخ الشرائح تنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides for PHP via Java، (مجموعة من كائنات [Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Slide)) التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) توفر طريقتي [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) و [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation).
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) بالإشارة إلى مجموعة الشرائح التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) وتمرير الشريحة المراد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone).
1. حفظ ملف العرض المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض) إلى نهاية العرض.

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # حفظ العرض التقديمي المعدل إلى القرص
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **استنساخ شريحة إلى موقع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone):

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation).
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection) بالإشارة إلى مجموعة [Slides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) وتمرير الشريحة المراد استنساخها مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone).
1. حفظ العرض المعدل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض) إلى الفهرس 1 – الموضع 2 – من العرض.

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    $slds = $pres->getSlides();
    # استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # حفظ العرض التقديمي المعدل إلى القرص
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض الذي سيتم استنساخ الشريحة منه.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض الهدف الذي ستُضاف إليه الشريحة.
1. الحصول على كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection) بالإشارة إلى مجموعة [Slides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) التي يوفرها كائن Presentation الخاص بالعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) وتمرير الشريحة من العرض المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone).
1. حفظ ملف العرض الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض المصدر) إلى نهاية العرض الهدف.

```php
  # إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # حفظ العرض التقديمي الوجهة إلى القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ شريحة إلى موقع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في موقع محدد:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض الذي ستُضاف إليه الشريحة.
1. الحصول على فئة [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) بالإشارة إلى مجموعة الشرائح التي يوفرها كائن Presentation الخاص بالعرض الهدف.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) وتمرير الشريحة من العرض المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#insertClone).
1. حفظ ملف العرض الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض المصدر) إلى الفهرس 1 (الموضع 2) من العرض الهدف.

```php
  # إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # حفظ العرض التقديمي الوجهة إلى القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ شريحة في موقع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. ثم استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. طريقة [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) تتوقع شريحة رئيسية من العرض الهدف وليس من العرض المصدر. لاستنساخ الشريحة مع رئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) التي تحتوي على العرض الهدف الذي ستُستنسخ إليه الشريحة.
1. الوصول إلى الشريحة المراد استنساخها مع الشريحة الرئيسية.
1. إنشاء كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/MasterSlideCollection) بالإشارة إلى مجموعة Masters التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) الخاص بالعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) التي يوفرها كائن [MasterSlideCollection] وتمرير الشريحة الرئيسية من العرض المصدر لتستنسخ كمعامل إلى طريقة [addClone].
1. إنشاء كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSlides) بالإشارة إلى مجموعة Slides التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) الخاص بالعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) التي يوفرها كائن [SlideCollection] وتمرير الشريحة من العرض المصدر لتستنسخها مع الشريحة الرئيسية كمعامل إلى طريقة [addClone].
1. حفظ ملف العرض الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة مع رئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الهدف باستخدام رئيسية من الشريحة المصدر.

```php
  # إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    $destPres = new Presentation();
    try {
      # إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
      # الشريحة الرئيسية
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
      # العرض التقديمي الهدف
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
      # العرض التقديمي الهدف
      $iSlide = $masters->addClone($SourceMaster);
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
      # مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # حفظ العرض التقديمي الوجهة إلى القرص
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ شريحة في نهاية قسم محدد**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض ولكن في قسم مختلف، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection/#addClone) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SlideCollection). تجعل Aspose.Slides for PHP via Java من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدخال الشريحة المستنسخة في قسم محدد.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # حفظ العرض التقديمي الوجهة إلى القرص
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **التأكد من تطابق حجم الشريحة**

عند استنساخ الشرائح إلى عرض آخر، تأكد من أن عرض الوجهة له نفس حجم الشريحة مثل المصدر. إذا اختلف حجم الشرائح، لا تقوم Aspose.Slides بتحجيم الأشكال المستنسخة تلقائيًا—تبقى إحداثياتها وأبعادها الأصلية، ما قد يؤدي إلى عدم محاذاة المحتوى أو امتداده خارج حدود الشريحة.

يمكنك ضبط حجم شريحة العرض الهدف ليتطابق مع المصدر قبل استنساخ الرئيسة والشريحة:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

قم بذلك قبل استنساخ الرئيسة والشريحة.

## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب فيها، [احذفها](/slides/ar/php-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المضمَّنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمّن)، يتم الحفاظ على هذا الارتباط ككائن [OLE](/slides/ar/php-java/manage-ole/). بعد النقل بين الملفات، تأكد من توفر البيانات وسلوك التحديث.

**هل يمكن التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة معين ووضعها في [قسم](/slides/ar/php-java/slide-section/) محدد. إذا لم يكن القسم الهدف موجودًا، أنشئه أولًا ثم انقل الشريحة إليه.