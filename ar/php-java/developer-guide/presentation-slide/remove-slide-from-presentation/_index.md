---
title: إزالة الشريحة من العرض التقديمي
type: docs
weight: 30
url: /php-java/remove-slide-from-presentation/
keywords: "إزالة الشريحة، حذف الشريحة، باوربوينت، عرض تقديمي، جافا، Aspose.Slides"
description: "إزالة الشريحة من باوربوينت بواسطة المرجع أو الفهرس"

---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تحتوي على [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/)، والتي هي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (المرجع أو الفهرس) لكائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي ترغب في إزالتها.

## **إزالة الشريحة بواسطة المرجع**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة التي تريد إزالتها من خلال معرفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المعدل.

هذا الشيفرة PHP توضح لك كيفية إزالة شريحة من خلال مرجعها:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # الوصول إلى شريحة من خلال فهرسها في مجموعة الشرائح
    $slide = $pres->getSlides()->get_Item(0);
    # إزالة شريحة من خلال مرجعها
    $pres->getSlides()->remove($slide);
    # حفظ العرض التقديمي المعدل
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **إزالة الشريحة بواسطة الفهرس**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. إزالة الشريحة من العرض التقديمي من خلال موضع فهرسها.
1. حفظ العرض التقديمي المعدل.

هذا الشيفرة PHP توضح لك كيفية إزالة شريحة من خلال فهرسها:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    # إزالة شريحة من خلال فهرس الشريحة
    $pres->getSlides()->removeAt(0);
    # حفظ العرض التقديمي المعدل
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **إزالة الشريحة التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) للسماح لك بحذف الشرائح التخطيط غير المرغوب فيها وغير المستخدمة. هذا الشيفرة PHP توضح لك كيفية إزالة شريحة تخطيط من عرض تقديمي باوربوينت:

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

## **إزالة شريحة الماستر غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوب فيها وغير المستخدمة. هذا الشيفرة PHP توضح لك كيفية إزالة شريحة ماستر من عرض تقديمي باوربوينت:

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