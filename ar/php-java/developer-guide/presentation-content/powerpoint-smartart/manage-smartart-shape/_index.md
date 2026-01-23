---
title: إدارة رسومات SmartArt في العروض التقديمية باستخدام PHP
linktitle: رسومات SmartArt
type: docs
weight: 20
url: /ar/php-java/manage-smartart-shape/
keywords:
- كائن SmartArt
- رسم SmartArt
- نمط SmartArt
- لون SmartArt
- إنشاء SmartArt
- إضافة SmartArt
- تحرير SmartArt
- تغيير SmartArt
- الوصول إلى SmartArt
- نوع تخطيط SmartArt
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أتمتة إنشاء وتحرير وتنسيق رسومات SmartArt في PowerPoint باستخدام PHP عبر Aspose.Slides، مع أمثلة شفرة مختصرة وإرشادات مركزة على الأداء."
---

## **إنشاء شكل SmartArt**
Aspose.Slides for PHP via Java يوفر API لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة باستخدام رقم الفهرس الخاص بها.
1. [إضافة شكل SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) عن طريق تعيين [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType) لها.
1. حفظ العرض التقديمي المعدل كملف PPTX.
```php
  # إنشاء فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # حفظ العرض التقديمي
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: تم إضافة شكل SmartArt إلى الشريحة**|

## **الوصول إلى شكل SmartArt على شريحة**
سيتم استخدام الشيفرة التالية للوصول إلى أشكال SmartArt المضافة في شريحة العرض التقديمي. في الشيفرة النموذجية سنقوم بتصفح كل شكل داخل الشريحة والتحقق مما إذا كان شكلًا من [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى نسخة من [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # تجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى شكل SmartArt بنوع تخطيط محدد**
سيساعدك الشيفرة النموذجية التالية على الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام رقم الفهرس الخاص بها.
1. تصفح كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. التحقق من شكل SmartArt بنوع LayoutType معين وتنفيذ ما يلزم بعد ذلك.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من تخطيط SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تغيير نمط شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل SmartArt.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام رقم الفهرس الخاص بها.
1. تصفح كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بنمط معين.
1. تعيين النمط الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.
```php
  # إنشاء فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من نمط SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # تغيير نمط SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # حفظ العرض التقديمي
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط معدل**|

## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. ستقوم الشيفرة النموذجية التالية بالوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام رقم الفهرس الخاص بها.
1. تصفح كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان كذلك.
1. العثور على شكل SmartArt بنمط لون معين.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض التقديمي.
```php
  # إنشاء فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من نوع لون SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # تغيير نوع لون SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # حفظ العرض التقديمي
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**الشكل: شكل SmartArt مع نمط لون معدل**|

## **FAQ**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذا يمكنك تطبيق [الرسوم المتحركة القياسية](/slides/ar/php-java/powerpoint-animation/) عبر API الرسوم المتحركة (الدخول، الخروج، التأكيد، مسارات الحركة) مثل باقي الأشكال.

**كيف يمكنني العثور على SmartArt معين في شريحة إذا لم أعرف معرّفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل باستخدام تلك القيمة—هذه طريقة موصى بها لتحديد الشكل المستهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [معالجة المجموعة](/slides/ar/php-java/group/).

**كيف أحصل على صورة لـ SmartArt محدد (مثلاً للمعاينة أو التقرير)؟**

قم بتصدير صورة مصغرة/صورة للشكل؛ يمكن للمكتبة [إنشاء صورة مصغرة للشكل](/slides/ar/php-java/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيبقى مظهر SmartArt محفوظًا عند تحويل العرض التقديمي بالكامل إلى PDF؟**

نعم. تستهدف محرك العرض الدقة العالية عند [تصدير PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، مع مجموعة من الخيارات للجودة والتوافق.