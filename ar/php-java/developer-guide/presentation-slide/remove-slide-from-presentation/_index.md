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
description: "قم بإزالة الشرائح بسهولة من عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. احصل على أمثلة شفرة واضحة وعزز سير عملك."
---

إذا أصبحت الشريحة (أو محتواها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تُغلف [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في عرض تقديمي. باستخدام المؤشرات (مرجع أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة شريحة بواسطة المرجع**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
1. إزالة الشريحة المرجعية من العرض التقديمي.
1. حفظ العرض التقديمي المعدل. 

يعرض هذا الكود PHP طريقة إزالة شريحة عبر مرجعها:
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


## **إزالة شريحة بواسطة الفهرس**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. إزالة الشريحة من العرض التقديمي عبر موقع الفهرس الخاص بها.
1. حفظ العرض التقديمي المعدل. 

يعرض هذا الكود PHP طريقة إزالة شريحة عبر فهرسها:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # يزيل شريحة عبر فهرسها
    $pres->getSlides()->removeAt(0);
    # يحفظ العرض التقديمي المعدل
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) لتتيح لك حذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يعرض هذا الكود PHP طريقة إزالة شريحة تخطيط من عرض PowerPoint:
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


## **إزالة شرائح القالب الرئيسي غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) لتتيح لك حذف شرائح القالب الرئيسي غير المرغوب فيها وغير المستخدمة. يعرض هذا الكود PHP طريقة إزالة شريحة قالب رئيسي من عرض PowerPoint:
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


## **الأسئلة المتكررة**

**ماذا يحدث لمؤشرات الشرائح بعد حذف شريحة؟**

بعد الحذف، تعيد [collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) فهرستها: كل شريحة تالية تنحرف إلى اليسار بموقع واحد، لذا تصبح أرقام الفهارس السابقة غير صالحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم معرف الشريحة المستمر بدلاً من فهرسها.

**هل معرف الشريحة يختلف عن مؤشرها، وهل يتغير عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة وسيتغير عندما تُضاف أو تُحذف شرائح. معرف الشريحة هو معرف مستمر ولا يتغير عندما تُحذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، فإن ذلك القسم سيحتوي على شريحة أقل. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/php-java/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرتبطة بشريحة عند حذفها؟**

[الملاحظات](/slides/ar/php-java/presentation-notes/) و[التعليقات](/slides/ar/php-java/presentation-comments/) مرتبطة بتلك الشريحة المحددة وتُحذف معها. المحتوى على الشرائح الأخرى لا يتأثر.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/القوالب الرئيسية غير المستخدمة؟**

الحذف يزيل الشرائح العادية المحددة من المجموعة. تنظيف التخطيطات/القوالب الرئيسية غير المستخدمة يزيل الشرائح التي لا يشير إليها شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً احذف أولاً، ثم قم بالتنظيف.