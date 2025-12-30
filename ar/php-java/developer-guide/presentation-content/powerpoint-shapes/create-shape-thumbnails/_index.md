---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في PHP
linktitle: مصغرات الشكل
type: docs
weight: 70
url: /ar/php-java/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- عرض الشكل
- رسم الشكل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java - إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يمكنك استخدام Aspose.Slides for PHP via Java لإنشاء ملفات عروض تقديمية تكون كل صفحة فيها شريحة. يمكن عرض الشرائح بفتح ملفات العروض باستخدام Microsoft PowerPoint. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في هذه الحالات، تساعدهم Aspose.Slides for PHP via Java على إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنظهر كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل لشرائح بأبعاد يتم تعريفها من قبل المستخدم.
- إنشاء صورة مصغرة لشكل داخل حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for PHP via Java، نفّذ ما يلي:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرفها أو مؤشرها.
1. [احصل على صورة المصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) للشفرة المرجعية على المقياس الافتراضي.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

هذا المثال البرمجي يوضح لك كيفية إنشاء صورة مصغرة لشكل من شريحة:
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # حفظ الصورة إلى القرص بصيغة PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء صورة مصغرة بمعامل تحجيم يُحدده المستخدم**
لإنشاء صورة مصغرة للشكل في شريحة باستخدام Aspose.Slides for PHP via Java، نفّذ ما يلي:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرفها أو مؤشرها.
1. [احصل على صورة المصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) للشفرة المرجعية بأبعاد يحددها المستخدم.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

هذا المثال البرمجي يوضح لك كيفية إنشاء صورة مصغرة للشكل بناءً على معامل تحجيم محدد:
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بمقياس كامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # حفظ الصورة إلى القرص بصيغة PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء صورة مصغرة لمظهر الشكل بناءً على حدوده**
هذه الطريقة لإنشاء صور مصغرة للأشكال تسمح للمطورين بإنشاء صورة مصغرة ضمن حدود مظهر الشكل. إنها تأخذ في الاعتبار جميع تأثيرات الشكل. تكون الصورة المصغرة لل shape مقيدة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدوده الظاهرية، نفّذ ما يلي:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع أي شريحة باستخدام معرفها أو مؤشرها.
1. احصل على صورة المصغرة للشفرة المرجعية بحدود الشكل كمظهر.
1. احفظ صورة المصغرة بالتنسيق المفضل لديك.

هذا المثال البرمجي يعتمد على الخطوات المذكورة أعلاه:
```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بمقاس كامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # حفظ الصورة إلى القرص بصيغة PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**ما هي تنسيقات الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كرسوم متجهة SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) عن طريق حفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود Shape و Appearance عند تقديم صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/php-java/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كخفي؟ هل سيظل يُعرض كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تقديمه؛ علم الإخفاء يؤثر على عرض الشرائح ولكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/php-java/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/php-java/font-substitution/)) لتجنب الاعتماد على الخطوط البديلة غير المرغوب فيها وإعادة تدفق النص.