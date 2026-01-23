---
title: إزالة الشرائح من العروض التقديمية في PHP
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/php-java/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أزل الشرائح بسهولة من عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. احصل على أمثلة شفرة واضحة وعزز سير عملك."
---

إذا أصبحت شريحة (أو محتوياتها) زائدة عن الحاجة، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تحتضن [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام مؤشرات (مرجع أو فهرس) لكائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة شريحة عن طريق المرجع**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. احصل على مرجع الشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. احفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود PHP كيفية إزالة شريحة عبر مرجعها:
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح
    $slide = $pres->getSlides()->get_Item(0);
    # إزالة شريحة عبر مرجعها
    $pres->getSlides()->remove($slide);
    # حفظ العرض التقديمي المعدل
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```



## **إزالة شريحة عن طريق الفهرس**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. إزالة الشريحة من العرض التقديمي عبر موقع الفهرس الخاص بها.
1. احفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود PHP كيفية إزالة شريحة عبر فهرستها:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # يزيل شريحة عبر فهرس الشريحة
    $pres->getSlides()->removeAt(0);
    # يحفظ العرض التقديمي المعدل
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) للسماح لك بحذف تخطيطات الشرائح غير المرغوبة وغير المستخدمة. يوضح لك هذا الكود PHP كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة شرائح الماستر غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوبة وغير المستخدمة. يوضح لك هذا الكود PHP كيفية إزالة شريحة ماستر من عرض PowerPoint:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**ماذا يحدث لمؤشرات الشرائح بعد حذف شريحة؟**

بعد الحذف، تقوم الـ[collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) بإعادة الفهرسة: كل شريحة تالية تتحرك خطوة واحدة إلى اليسار، وبالتالي تصبح أرقام الفهارس السابقة غير صالحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرف الدائم لكل شريحة بدلاً من فهرستها.

**هل معرف الشريحة مختلف عن فهرسها، وهل يتغير عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موقع الشريحة في الترتيب ويتغير عند إضافة أو إزالة شرائح. معرف الشريحة هو معرف دائم ولا يتغير عند حذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة جزءًا من قسم، فإن ذلك القسم سيحتوي على شريحة أقل. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/php-java/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرتبطة بشريحة عند حذفها؟**

[الملاحظات](/slides/ar/php-java/presentation-notes/) و[التعليقات](/slides/ar/php-java/presentation-comments/) مرتبطة بتلك الشريحة المحددة وتُحذف معها. المحتوى على الشرائح الأخرى لا يتأثر.

**ما الفرق بين حذف الشرائح وتنظيف التخطيطات/الماسترات غير المستخدمة؟**

الحذف يزيل شرائح عادية محددة من المجموعة. تنظيف التخطيطات/الماسترات غير المستخدمة يزيل شرائح التخطيط أو الماستر التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً يتم الحذف أولاً، ثم التنظيف.