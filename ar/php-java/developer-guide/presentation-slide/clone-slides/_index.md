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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides لِـ PHP. اتبع أمثلة الشيفرة الواضحة لأتمتة إنشاء ملفات PPT في ثوانٍ وإزالة العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو مماثلة لشيء ما. Aspose.Slides for PHP via Java يجعل من الممكن أيضًا عمل نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تم فتحه. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for PHP via Java، (مجموعة من [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) objects) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) توفر الطريقتين [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) و[insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) بالإشارة إلى مجموعة الشرائح التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) ومرّر الشريحة التي تريد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. احفظ ملف العرض التقديمي المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.
```php
  # إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي
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


## **استنساخ شريحة إلى موضع آخر داخل عرض تقديمي**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone):

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. احصل على كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection) بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) ومرّر الشريحة التي تريد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone).
1. احفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.
```php
  # إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي الهدف الذي ستُضاف إليه الشريحة.
1. احصل على كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection) بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) التي يُظهرها كائن Presentation للعرض التقديمي الهدف.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) ومرّر الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن فئة Presentation للـ PPTX الهدف (حيث ستُستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # حفظ العرض التقديمي الهدف إلى القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **استنساخ شريحة إلى موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. احصل على الفئة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) بالإشارة إلى مجموعة Slides التي يُظهرها كائن Presentation للعرض التقديمي الهدف.
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) ومرّر الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#insertClone).
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الهدف.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن فئة Presentation للـ PPTX الهدف (حيث ستُستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # حفظ العرض التقديمي الهدف إلى القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **استنساخ شريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. الطريقة [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/) تتوقع شريحة رئيسية من العرض الهدف بدلاً من العرض المصدر. لاستنساخ الشريحة مع الرئيسية، يرجى اتباع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) الذي يحتوي على العرض التقديمي الهدف الذي ستُستنسخ إليه الشريحة.
1. وصول إلى الشريحة التي ستُستنسخ مع الشريحة الرئيسية.
1. أنشئ كائنًا من الفئة [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection) بالإشارة إلى مجموعة Masters التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض الهدف.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) التي يُظهرها كائن [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection) ومرّر الشريحة الرئيسية من العرض المصدر لتستنسخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. أنشئ كائنًا من الفئة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) بتعيين الإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض الهدف.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getSlides) ومرّر الشريحة من العرض المصدر لتستنسخها والشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone).
1. احفظ ملف العرض التقديمي الهدف المعدل.

في المثال أدناه، قمنا باستنساخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الهدف باستخدام شريحة رئيسية من الشريحة المصدر.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # إنشاء كائن فئة Presentation للعرض التقديمي الهدف (حيث ستُستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
      # شريحة رئيسية
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ شريحة الماستر المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترز في الـ
      # العرض التقديمي الهدف
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ شريحة الماستر المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترز في الـ
      # العرض التقديمي الهدف
      $iSlide = $masters->addClone($SourceMaster);
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الماستر المطلوب إلى نهاية الـ
      # مجموعة الشرائح في العرض التقديمي الهدف
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # حفظ العرض التقديمي الهدف إلى القرص
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **استنساخ شريحة في نهاية قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في قسم مختلف، استخدم طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection/#addClone) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java يتيح استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # حفظ العرض التقديمي الهدف إلى القرص
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب في ذلك، قم بـ[إزالتها](/slides/ar/php-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط وتنسيقه والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل دفتر عمل مضمن كـ OLE)، يتم الحفاظ على هذا الارتباط كـ[كائن OLE](/slides/ar/php-java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [قسم](/slides/ar/php-java/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.