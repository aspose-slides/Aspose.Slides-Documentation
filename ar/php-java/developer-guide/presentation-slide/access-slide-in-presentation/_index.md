---
title: الوصول إلى شرائح العرض التقديمي في PHP
linktitle: الوصول إلى الشريحة
type: docs
weight: 20
url: /ar/php-java/access-slide-in-presentation/
keywords:
- الوصول إلى الشريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية الوصول إلى شرائح العروض التقديمية وإدارتها في PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. عزّز الإنتاجية باستخدام أمثلة الشيفرة."
---

Aspose.Slides يسمح لك بالوصول إلى الشرائح بطريقتين: عن طريق الفهرس أو عن طريق المعرف.

## **Access a Slide by Index**

جميع الشرائح في العرض التقديمي تُرتب رقمياً بناءً على موضع الشريحة بدءاً من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية عبر الفهرس 1؛ وهكذا.

الفئة Presentation التي تمثل ملف عرض تقديمي تعرض جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). يوضح هذا الكود PHP طريقة الوصول إلى شريحة عبر فهرسها:
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # الوصول إلى شريحة باستخدام فهرس الشريحة
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **Access a Slide by ID**

كل شريحة في العرض التقديمي لها معرف فريد. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (المُعرّفة في الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) لاستهداف هذا المعرف. يوضح هذا الكود PHP كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-):
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # يحصل على معرف الشريحة
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # يصل إلى الشريحة عبر معرفها
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```


## **Change the Slide Position**

Aspose.Slides يتيح لك تغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن تصبح الشريحة الأولى هي الشريحة الثانية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) عبر فهرسها
1. ضبط موضع جديد للشريحة عبر الخاصية [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-).
1. حفظ العرض التقديمي المعدَّل.

يوضح هذا الكود PHP عملية نقل الشريحة في الموضع 1 إلى الموضع 2:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Presentation.pptx");
  try {
    # يحصل على الشريحة التي سيتم تغيير موضعها
    $sld = $pres->getSlides()->get_Item(0);
    # يضبط الموضع الجديد للشريحة
    $sld->setSlideNumber(2);
    # يحفظ العرض التقديمي المعدل
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


أصبحت الشريحة الأولى هي الثانية؛ والشريحة الثانية أصبحت الأولى. عندما تغير موضع شريحة، يتم تعديل الشرائح الأخرى تلقائياً.


## **Set the Slide Number**

باستخدام الخاصية [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (المُعرّفة في الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. هذه العملية تعيد حساب أرقام الشرائح الأخرى.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على رقم الشريحة.
1. ضبط رقم الشريحة.
1. حفظ العرض التقديمي المعدَّل.

يوضح هذا الكود PHP عملية ضبط رقم الشريحة الأولى إلى 10:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # يحصل على رقم الشريحة
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # يضبط رقم الشريحة
    $pres->setFirstSlideNumber(10);
    # يحفظ العرض التقديمي المعدل
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


إذا رغبت في تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # يحدد الرقم للشريحة الأولى في العرض التقديمي
    $presentation->setFirstSlideNumber(0);
    # يعرض أرقام الشرائح لجميع الشرائح
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # يخفي رقم الشريحة الأولى
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # يحفظ العرض التقديمي المعدل
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**Does the slide number a user sees match the collection’s zero-based index?**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثال، 10) ولا يجب أن يطابق الفهرس؛ العلاقة تُتحكم فيها بإعداد [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) للعرض التقديمي.

**Do hidden slides affect indexing?**

نعم. الشريحة المخفية تظل في المجموعة وتُؤخذ في حساب الفهرسة؛ "مخفية" تشير إلى العرض، ليس إلى موضعها في المجموعة.

**Does a slide’s index change when other slides are added or removed?**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.