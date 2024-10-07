---
title: إدارة شكل سمارت آرت
type: docs
weight: 20
url: /php-java/manage-smartart-shape/
---


## **إنشاء شكل سمارت آرت**
لقد وفرت Aspose.Slides ل PHP عبر Java واجهة برمجة تطبيقات لإنشاء أشكال سمارت آرت. لإنشاء شكل سمارت آرت في شريحة، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. [إضافة شكل سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) عن طريق تعيينه [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. حفظ العرض المعدل كملف PPTX.

```php
  # إنشاء فئة العرض
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل سمارت آرت
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # حفظ العرض
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل سمارت آرت المضاف إلى الشريحة**|

## **الوصول إلى شكل سمارت آرت في الشريحة**
سيتم استخدام الكود التالي للوصول إلى أشكال سمارت آرت المضافة في شريحة العرض. في الكود المصدري، سنتنقل عبر كل شكل داخل الشريحة ونتحقق مما إذا كان شكل [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). إذا كان الشكل من نوع سمارت آرت، فسنجعل ذلك يتم ترميزًا إلى [**سمارت آرت**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

```php
  # تحميل العرض المطلوب
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # ترميز الشكل إلى SmartArtEx
        $smart = $shape;
        echo("اسم الشكل:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى شكل سمارت آرت مع نوع تخطيط معين**
ساعد الكود النموذجي التالي في الوصول إلى شكل [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) مع نوع تخطيط معين: يرجى ملاحظة أنه لا يمكنك تغيير نوع تخطيط سمارت آرت حيث إنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض بشكل سمارت آرت.
1. الحصول على مرجع للشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وترميز الشكل المحدد إلى سمارت آرت إذا كان سمارت آرت.
1. التحقق من شكل سمارت آرت مع نوع تخطيط معين وتنفيذ ما هو مطلوب بعد ذلك.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # ترميز الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من تخطيط سمارت آرت
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("قم بفعل شيء هنا....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تغيير نمط شكل سمارت آرت**
في هذا المثال، سنتعلم كيفية تغيير النمط السريع لأي شكل سمارت آرت.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض بشكل سمارت آرت.
1. الحصول على مرجع للشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وترميز الشكل المحدد إلى سمارت آرت إذا كان سمارت آرت.
1. العثور على شكل سمارت آرت مع نمط معين.
1. تعيين النمط الجديد لشكل سمارت آرت.
1. حفظ العرض.

```php
  # إنشاء فئة العرض
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # ترميز الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من نمط سمارت آرت
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # تغيير نمط سمارت آرت
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # حفظ العرض
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**الشكل: شكل سمارت آرت مع نمط_changed**|

## **تغيير نمط لون شكل سمارت آرت**
في هذا المثال، سنتعلم كيفية تغيير نمط اللون لأي شكل سمارت آرت. في الكود النموذجي التالي، سيتم الوصول إلى شكل سمارت آرت مع نمط لون معين وتغيير نمطه.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض بشكل سمارت آرت.
1. الحصول على مرجع للشريحة الأولى باستخدام فهرسها.
1. التنقل عبر كل شكل داخل الشريحة الأولى.
1. التحقق مما إذا كان الشكل من نوع [سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) وترميز الشكل المحدد إلى سمارت آرت إذا كان سمارت آرت.
1. العثور على شكل سمارت آرت مع نمط لون معين.
1. تعيين نمط اللون الجديد لشكل سمارت آرت.
1. حفظ العرض.

```php
  # إنشاء فئة العرض
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # ترميز الشكل إلى SmartArtEx
        $smart = $shape;
        # التحقق من نوع لون سمارت آرت
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # تغيير نوع لون سمارت آرت
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # حفظ العرض
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**الشكل: شكل سمارت آرت مع نمط لون_changed**|