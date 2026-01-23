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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. عزز الإنتاجية باستخدام أمثلة التعليمات البرمجية."
---

Aspose.Slides تتيح لك الوصول إلى الشرائح بطريقتين: عن طريق الفهرس وعن طريق المعرف.

## **الوصول إلى شريحة عن طريق الفهرس**

جميع الشرائح في عرض تقديمي مُرتبة رقمياً بناءً على موقع الشريحة بدءًا من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية عبر الفهرس 1؛ إلخ.

تُظهر فئة Presentation، التي تمثّل ملف عرض تقديمي، جميع الشرائح كمجموعة [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) (مجموعة من كائنات [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)). يوضح لك هذا الكود PHP كيفية الوصول إلى شريحة عبر فهرسها:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # يصل إلى شريحة باستخدام فهرس الشريحة
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **الوصول إلى شريحة عن طريق المعرف**

كل شريحة في عرض تقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (المُعرّفة في فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) لاستهداف ذلك المعرف. يوضح لك هذا الكود PHP كيفية توفير معرّف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-):
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


## **تغيير موضع الشريحة**

تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن تصبح الشريحة الأولى هي الشريحة الثانية.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة (الذي تريد تغيير موضعه) عبر فهرسه
1. تعيين موضع جديد للشريحة عبر طريقة [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#setSlideNumber) .
1. حفظ العرض التقديمي المعدل.

يعرض لك هذا الكود PHP عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:
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


أصبحت الشريحة الأولى هي الشريحة الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عندما تقوم بتغيير موضع شريحة، يتم تعديل باقي الشرائح تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام طريقة [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (المُعرّفة في فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) يمكنك تحديد رقم جديد للشريحة الأولى في عرض تقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. الحصول على رقم الشريحة.
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

يعرض لك هذا الكود PHP عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:
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


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وتصفية ترقيم الشريحة الأولى) بهذه الطريقة:
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # يضبط رقم الشريحة الأولى في العرض التقديمي
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


## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة تعسفية (مثل 10) ولا يلزم أن يطابق الفهرس؛ العلاقة تتحكم فيها إعداد [رقم الشريحة الأولى](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) في العرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. تظل الشريحة المخفية في المجموعة وتُؤخذ في الاعتبار عند الفهرسة؛ "مخفي" يعني عدم العرض، وليس موضعه في المجموعة.

**هل يتغير فهرس الشريحة عندما يتم إضافة أو إزالة شرائح أخرى؟**

نعم. دائمًا ما يعكس الفهرس الترتيب الحالي للشرائح ويُعاد حسابه عند عمليات الإدراج أو الحذف أو النقل.