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
description: "أتمتة إنشاء وتحرير وتنسيق SmartArt في PowerPoint باستخدام PHP و Aspose.Slides، مع أمثلة شفرة مختصرة وإرشادات تركّز على الأداء."
---

## **إنشاء شكل SmartArt**
قدمت Aspose.Slides لـ PHP عبر Java واجهة برمجة تطبيقات لإنشاء أشكال SmartArt. لإنشاء شكل SmartArt في شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرستها.
1. [إضافة شكل SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه إلى [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. حفظ العرض المعدل كملف PPTX.
```php
  # إنشاء كائن فئة Presentation
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
سيُستخدم الشيفرة التالية للوصول إلى أشكال SmartArt المُضافة إلى شريحة العرض. في مثال الشيفرة سنتنقل عبر كل شكل داخل الشريحة ونتحقق مما إذا كان شكلًا من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). إذا كان الشكل من نوع SmartArt فسنقوم بتحويله إلى نسخة من [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).
```php
  # تحميل العرض التقديمي المرغوب
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArtEx
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


## **الوصول إلى شكل SmartArt بنوع تخطيط معين**
ستساعد الشيفرة النموذجية التالية في الوصول إلى شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) بنوع LayoutType معين. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. التحقق من شكل SmartArt بنوع LayoutType معين وإجراء ما يلزم بعد ذلك.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArtEx
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

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. العثور على شكل SmartArt بنمط معين.
1. تعيين النمط الجديد لشكل SmartArt.
1. حفظ العرض.
```php
  # إنشاء كائن فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # الانتقال عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArtEx
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
|**الشكل: تم تغيير نمط شكل SmartArt**|

## **تغيير نمط لون شكل SmartArt**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل SmartArt. ستقوم الشيفرة النموذجية التالية بالوصول إلى شكل SmartArt بنمط لون معين وتغيير نمطه.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض الذي يحتوي على شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
1. استعراض كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
1. العثور على شكل SmartArt بنمط لون معين.
1. تعيين نمط اللون الجديد لشكل SmartArt.
1. حفظ العرض.
```php
  # إنشاء كائن فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArtEx
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
|**الشكل: تم تغيير نمط لون شكل SmartArt**|

## **الأسئلة المتكررة**

**هل يمكنني تحريك SmartArt ككائن واحد؟**

نعم. SmartArt هو شكل، لذلك يمكنك تطبيق [حركات قياسية](/slides/ar/php-java/powerpoint-animation/) عبر واجهة برمجة تطبيقات الحركات (دخول، خروج، تأكيد، مسارات حركة) مثل باقي الأشكال.

**كيف يمكنني العثور على SmartArt محدد في شريحة إذا لم أكن أعرف معرفه الداخلي؟**

قم بتعيين واستخدام النص البديل (AltText) وابحث عن الشكل بقيمة ذلك النص—هذه طريقة موصى بها لتحديد الشكل الهدف.

**هل يمكنني تجميع SmartArt مع أشكال أخرى؟**

نعم. يمكنك تجميع SmartArt مع أشكال أخرى (صور، جداول، إلخ) ثم [التعامل مع المجموعة](/slides/ar/php-java/group/).

**كيف أحصل على صورة لـ SmartArt معين (مثلاً للمعاينة أو التقرير)؟**

تصدير صورة مصغرة/صورة للشكل؛ المكتبة يمكنها [رسم الأشكال الفردية](/slides/ar/php-java/create-shape-thumbnails/) إلى ملفات نقطية (PNG/JPG/TIFF).

**هل سيُحافظ على مظهر SmartArt عند تحويل العرض بالكامل إلى PDF؟**

نعم. محرك العرض يهدف إلى أعلى دقة عند [تصدير PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، مع مجموعة من خيارات الجودة والتوافق.