---
title: استنساخ الشرائح
type: docs
weight: 35
url: /ar/php-java/clone-slides/
---


## **استنساخ الشرائح في العرض التقديمي**
الاستنساخ هو عملية صنع نسخة طبق الأصل أو صورة عن شيء ما. يتيح Aspose.Slides لـ PHP عبر Java أيضًا إمكانية عمل نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. تقوم عملية استنساخ الشرائح بإنشاء شريحة جديدة يمكن تعديلها بواسطة المطورين بدون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides لـ PHP عبر Java، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)) المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) توفر طرق [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ أنواع الاستنساخ الشريحة المذكورة أعلاه.

## **استنساخ في النهاية داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. قم بإنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) من خلال الإشارة إلى مجموعة الشرائح المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. اتصل بطريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ومرر الشريحة المراد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموقف الأول - الفهرس صفر - من العرض التقديمي) إلى نهاية العرض التقديمي.

```php
  # أنشئ مثيلًا من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # اكتب العرض التقديمي المعدل على القرص
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **استنساخ في موقع آخر داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موقع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. قم بإنشاء مثيل من الفئة من خلال الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. اتصل بطريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ومرر الشريحة المراد استنساخها جنبًا إلى جنب مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر - الموقف 1 - من العرض التقديمي) إلى الفهرس 1 - الموقف 2 - من العرض التقديمي.

```php
  # أنشئ مثيلًا من فئة Presentation التي تمثل ملف عرض تقديمي
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    $slds = $pres->getSlides();
    # استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # اكتب العرض التقديمي المعدل على القرص
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **استنساخ في النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي التي ستستنسخ منها الشريحة.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. قم بإنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) من خلال الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) المكشوفة بواسطة كائن العرض التقديمي للعرض التقديمي الوجهة.
1. اتصل بطريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ومرّر الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

```php
  # أنشئ مثيلًا من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # أنشئ مثيلًا من فئة Presentation لعرض PPTX الوجهة (حيث ستستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # اكتب العرض التقديمي الوجهة على القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ في موقع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في موقع محدد:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي ستستنسخ منه الشريحة.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. قم بإنشاء مثيل من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) من خلال الإشارة إلى مجموعة الشرائح المكشوفة بواسطة كائن العرض التقديمي للعرض التقديمي الوجهة.
1. اتصل بطريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ومرر الشريحة من العرض التقديمي المصدر جنبًا إلى جنب مع الموقع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) .
1. اكتب ملف العرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموقف 2) من العرض التقديمي الوجهة.

```php
  # أنشئ مثيلًا من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # أنشئ مثيلًا من فئة Presentation لعرض PPTX الوجهة (حيث ستستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # اكتب العرض التقديمي الوجهة على القرص
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ في موقع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، تحتاج إلى استنساخ الشريحة الرئيسية المرغوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة أولاً. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. تتوقع [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) وجود شريحة رئيسية من العرض التقديمي الوجهة بدلاً من العرض التقديمي المصدر. من أجل استنساخ الشريحة مع رئيس، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي سيتم استنساخ الشريحة منه.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة التي سيتم استنساخ الشريحة إليها.
1. الوصول إلى الشريحة المراد استنساخها جنبًا إلى جنب مع الشريحة الرئيسية.
1. قم بإنشاء مثيل من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) من خلال الإشارة إلى مجموعة الماستر المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. اتصل بطريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) ومرر الماستر من ملف المصدر ليتم استنساخه كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. أنشئ مثيلًا من فئة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) من خلال تعيين الإشارة إلى مجموعة الشرائح المكشوفة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. اتصل بطريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المكشوفة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) ومرر الشريحة من العرض التقديمي المصدر ليتم استنساخها والماستر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
1. اكتب ملف العرض التقديمي المعدل للوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام ماستر من الشريحة المصدر.

```php
  # أنشئ مثيلًا من فئة Presentation لتحميل ملف العرض التقديمي المصدر
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # أنشئ مثيلًا من فئة Presentation للعرض التقديمي الوجهة (حيث ستستنسخ الشريحة)
    $destPres = new Presentation();
    try {
      # أنشئ ISlide من مجموعة الشرائح في العرض التقديمي المصدر جنبًا إلى جنب مع
      # شريحة رئيسية
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماستر في
      # العرض التقديمي الوجهة
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الماستر في
      # العرض التقديمي الوجهة
      $iSlide = $masters->addClone($SourceMaster);
      # استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الماستر المرغوب إلى نهاية
      # مجموعة الشرائح في العرض التقديمي الوجهة
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # احفظ العرض التقديمي الوجهة على القرص
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **استنساخ في النهاية في قسم محدد**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، فاستعمل طريقة [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) المكشوفة بواسطة واجهة [**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection). يتيح Aspose.Slides لـ PHP عبر Java إمكانيات استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

يظهر الكود التالي كيف يمكنك استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("القسم 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("القسم 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # احفظ العرض التقديمي الوجهة على القرص
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```