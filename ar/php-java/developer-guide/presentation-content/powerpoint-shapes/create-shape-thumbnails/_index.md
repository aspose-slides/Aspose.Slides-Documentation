---
title: إنشاء صور مصغرة للأشكال
type: docs
weight: 70
url: /php-java/create-shape-thumbnails/
---


## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides لـ PHP عبر Java لإنشاء ملفات العروض التقديمية حيث تتوافق كل صفحة مع شريحة. يمكن عرض الشرائح عن طريق فتح ملفات العرض باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض الصور. في مثل هذه الحالات، يساعدهم Aspose.Slides لـ PHP عبر Java في إنشاء صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنوضح كيفية إنشاء صور مصغرة للشرائح في مواقف مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل شريحة بأبعاد محددة من المستخدم.
- إنشاء صورة مصغرة في حدود مظهر الشكل.

## **إنشاء صور مصغرة للأشكال من الشرائح**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides لـ PHP عبر Java، قم بما يلي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--) من الشريحة المرجعية على المقياس الافتراضي.
1. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

يعرض لك هذا الرمز النموذجي كيفية إنشاء صورة مصغرة لشكل من شريحة:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف العرض
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة كاملة الحجم
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # حفظ الصورة على القرص بتنسيق PNG
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

## **إنشاء صور مصغرة للأشكال مع عامل مقياس محدد من المستخدم**
لإنشاء صورة مصغرة لشكل شريحة باستخدام Aspose.Slides لـ PHP عبر Java، قم بما يلي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة للشكل](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-) من الشريحة المرجعية بأبعاد محددة من المستخدم.
1. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

يعرض لك هذا الرمز النموذجي كيفية إنشاء صورة مصغرة للشكل بناءً على عامل مقياس محدد:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف العرض
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة كاملة الحجم
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # حفظ الصورة على القرص بتنسيق PNG
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

## **إنشاء صورة مصغرة لأبعاد الشكل**
تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة في حدود مظهر الشكل. تأخذ في الاعتبار جميع تأثيرات الشكل. تكون صورة الشكل المصغرة المولدة مقيدة بحدود الشريحة. لإنشاء صورة مصغرة لشكل شريحة ضمن حدود مظهره، قم بما يلي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. احفظ صورة المصغرة بتنسيق الصورة المفضل لديك.

يعتمد هذا الرمز النموذجي على الخطوات أعلاه:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف العرض
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # إنشاء صورة كاملة الحجم
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # حفظ الصورة على القرص بتنسيق PNG
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