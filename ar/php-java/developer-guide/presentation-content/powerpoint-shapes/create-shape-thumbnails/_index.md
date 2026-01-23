---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في PHP
linktitle: مصغرات الأشكال
type: docs
weight: 70
url: /ar/php-java/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- عرض الشكل
- تصيير الشكل
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة لأشكال شرائح PowerPoint باستخدام Aspose.Slides for PHP عبر Java – بسهولة إنشاء وتصدير صور مصغرة للعروض التقديمية."
---

## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides for PHP via Java لإنشاء ملفات عروض تقديمية تكون كل صفحة فيها ممثلةً لشريحة. يمكن عرض الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بصورة منفصلة في عارض صور. في مثل هذه الحالات، يساعد Aspose.Slides for PHP via Java على إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنوضح كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل في شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة لشكل ضمن حدود مظهر الشكل.

## **إنشاء صورة مصغرة للشكل من الشريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for PHP via Java، قم بما يلي:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. [الحصول على صورة مصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) من الشريحة المرجعية بالمقياس الافتراضي.
1. حفظ صورة المصغرة بالتنسيق الصورة المفضّل لديك.

يعرض هذا الكود النموذجي كيفية إنشاء صورة مصغرة لشكل من شريحة:
```php
  # إنشاء كائن من فئة Presentation تمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # حفظ الصورة إلى القرص بتنسيق PNG
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


## **إنشاء صورة مصغرة بمعامل قياس يحدده المستخدم**
لإنشاء صورة مصغرة لشكل شريحة باستخدام Aspose.Slides for PHP via Java، قم بما يلي:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. [الحصول على صورة مصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) من الشريحة المرجعية بأبعاد يحددها المستخدم.
1. حفظ صورة المصغرة بالتنسيق الصورة المفضّل لديك.

يعرض هذا الكود النموذجي كيفية إنشاء صورة مصغرة لشكل بناءً على معامل قياس محدد:
```php
  # إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # حفظ الصورة إلى القرص بتنسيق PNG
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


## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تتيح طريقة إنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة ضمن حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. تكون صورة الشكل المصغرة مقيدة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدود مظهره، قم بما يلي:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. حفظ صورة المصغرة بالتنسيق الصورة المفضّل لديك.

يعتمد هذا الكود النموذجي على الخطوات المذكورة أعلاه:
```php
  # إنشاء كائن من فئة Presentation يمثل ملف العرض التقديمي
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة بالحجم الكامل
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # حفظ الصورة إلى القرص بتنسيق PNG
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


## **الأسئلة المتكررة**

**ما هي تنسيقات الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجهة](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) عن طريق حفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود الشكل وحدود المظهر عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/php-java/shape-effect/) (الظلال، الوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيظل يتم إنشاء صورة مصغرة له؟**

يظل الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورته؛ علم الإخفاء يؤثر على عرض الشرائح لكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال المجمعة، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)، و[SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) يمكن حفظه كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/php-java/custom-font/) (أو [تكوين استبدالات الخطوط](/slides/ar/php-java/font-substitution/)) لتجنب التحويلات غير المرغوب فيها وإعادة تدفق النص.