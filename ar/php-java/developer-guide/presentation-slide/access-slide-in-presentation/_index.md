---
title: الوصول إلى الشريحة في العرض التقديمي
type: docs
weight: 20
url: /ar/php-java/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint، الوصول إلى الشريحة، تحرير خصائص الشريحة، تغيير موقع الشريحة، تعيين رقم الشريحة، الفهرس، المعرف، الموقع Java، Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint بواسطة الفهرس أو المعرف أو الموقع. تحرير خصائص الشريحة"
---

يسمح لك Aspose.Slides بالوصول إلى الشرائح بطريقتين: بواسطة الفهرس وبواسطة المعرف.

## **الوصول إلى الشريحة بواسطة الفهرس**

يتم ترتيب جميع الشرائح في العرض التقديمي رقمياً بناءً على موقع الشريحة بدءًا من 0. يمكن الوصول إلى الشريحة الأولى من خلال الفهرس 0؛ ويمكن الوصول إلى الشريحة الثانية من خلال الفهرس 1؛ وهكذا.

تكشف فئة Presentation، التي تمثل ملف العرض التقديمي، عن جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/)). يوضح هذا الرمز PHP كيفية الوصول إلى الشريحة من خلال فهرسها:

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

## **الوصول إلى الشريحة بواسطة المعرف**

لكل شريحة في العرض التقديمي معرف فريد مرتبط بها. يمكنك استخدام طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) (التي تكشف عنها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)) لاستهداف ذلك المعرف. يوضح هذا الرمز PHP كيفية تقديم معرف شريحة صالح والوصول إلى تلك الشريحة من خلال طريقة [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) :

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # الحصول على معرف الشريحة
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # الوصول إلى الشريحة من خلال معرفها
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **تغيير موقع الشريحة**

يسمح لك Aspose.Slides بتغيير موقع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على مرجع الشريحة (التي تريد تغيير موقعها) من خلال فهرسها
1. قم بتعيين موقع جديد للشريحة من خلال خاصية [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/islide/#setSlideNumber-int-) .
1. احفظ العرض التقديمي المعدل.

يوضح هذا الرمز PHP عملية يتم فيها نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("Presentation.pptx");
  try {
    # الحصول على الشريحة التي سيتم تغيير موقعها
    $sld = $pres->getSlides()->get_Item(0);
    # تعيين الموقع الجديد للشريحة
    $sld->setSlideNumber(2);
    # حفظ العرض التقديمي المعدل
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

أصبحت الشريحة الأولى هي الشريحة الثانية؛ وأصبحت الشريحة الثانية هي الشريحة الأولى. عند تغيير موقع الشريحة، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (التي تكشف عنها فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/))، يمكنك تعيين رقم جديد للشريحة الأولى في العرض التقديمي. تؤدي هذه العملية إلى إعادة حساب أرقام الشرائح الأخرى.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على رقم الشريحة.
1. قم بتعيين رقم الشريحة.
1. احفظ العرض التقديمي المعدل.

يوضح هذا الرمز PHP عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # الحصول على رقم الشريحة
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # تعيين رقم الشريحة
    $pres->setFirstSlideNumber(10);
    # حفظ العرض التقديمي المعدل
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # تعيين الرقم للشريحة الأولى في العرض التقديمي
    $presentation->setFirstSlideNumber(0);
    # إظهار أرقام الشرائح لجميع الشرائح
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # إخفاء رقم الشريحة للشريحة الأولى
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # حفظ العرض التقديمي المعدل
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```