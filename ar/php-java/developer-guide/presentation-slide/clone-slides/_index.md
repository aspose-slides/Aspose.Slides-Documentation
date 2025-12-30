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
description: "قم باستنساخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides للـ PHP. اتبع أمثلة الشيفرة الواضحة لتلقائيًا إنشاء ملفات PPT في ثوانٍ وإلغاء الحاجة إلى العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مكررة من شيء ما. Aspose.Slides for PHP via Java يتيح أيضاً إمكانية إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض آخر مفتوح. عملية استنساخ الشرائح تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق محتملة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides for PHP via Java، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) ) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) توفر طريقتي [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقاً للخطوات الواردة أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إنشاء نسخة من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – في العرض التقديمي) إلى نهاية العرض التقديمي.
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
إذا كنت تريد استنساخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي ولكن في موقع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. إنشاء النسخة بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها بالإضافة إلى الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – في العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.
```php
  # إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر للشرائح.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. إنشاء نسخة من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) التي يُظهرها كائن العرض التقديمي للوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن فئة Presentation للملف PPTX الوجهة (حيث ستُستنسخ الشريحة)
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في موقع محدد:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر للشرائح.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. إنشاء نسخة من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُظهرها كائن العرض التقديمي للوجهة.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر بالإضافة إلى الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الوجهة.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # إنشاء كائن فئة Presentation لملف PPTX الوجهة (حيث ستُستنسخ الشريحة)
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
إذا كنت بحاجة إلى استنساخ شريحة ذات شريحة رئيسية (master) من عرض تقديمي واستخدامها في عرض تقديمي آخر، عليك أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. ثم استخدم تلك الشريحة الرئيسية لاستنساخ الشريحة ذات الشريحة الرئيسية. طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض التقديمي الوجهة وليس من المصدر. لتنفيذ استنساخ الشريحة مع شريحة رئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر للشرائح.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة للشرائح.
1. الوصول إلى الشريحة التي سيتم استنساخها مع شريحة رئيسية.
1. إنشاء نسخة من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) بالإشارة إلى مجموعة Masters التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) وتمرير الشريحة الرئيسية من ملف PPTX المصدر لاستنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. إنشاء نسخة من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) بتعيين المرجع إلى مجموعة الشرائح التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر للاستنساخ والشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة ذات شريحة رئيسية (تقع في الفهرس صفر للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة رئيسية من الشريحة المصدر.
```php
  # إنشاء كائن فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # إنشاء كائن فئة Presentation للعرض التقديمي الوجهة (حيث ستُستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
      # الشريحة الرئيسية
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترز في الـ
      # العرض التقديمي الوجهة
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترز في الـ
      # العرض التقديمي الوجهة
      $iSlide = $masters->addClone($SourceMaster);
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية الـ
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
إذا كنت تريد استنساخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) التي يُظهرها واجهة [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). Aspose.Slides for PHP via Java يجعل من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة في القسم الثاني من نفس العرض التقديمي.

القطعة البرمجية التالية توضح كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # حفظ العرض التقديمي الوجهة إلى القرص
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [إزالتها](/slides/ar/php-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المضمّنة. إذا كان المخطط مرتبطاً بمصدر خارجي (مثل مصنف OLE مضمّن)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/php-java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة في فهرس شريحة محدد ووضعها في [قسم](/slides/ar/php-java/slide-section/) مختار. إذا لم يكن القسم الهدف موجوداً، أنشئه أولاً ثم انقل الشريحة إليه.