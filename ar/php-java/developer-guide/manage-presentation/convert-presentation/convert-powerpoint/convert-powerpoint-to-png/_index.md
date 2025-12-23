---
title: تحويل شرائح PowerPoint إلى PNG في PHP
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/php-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- PHP
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للـ PHP عبر Java، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا. 

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تعتبر الحجم مشكلة، يُعد PNG تنسيق صورة أفضل من JPEG. 

{{% alert title="Tip" color="primary" %}} قد ترغب في استكشاف محولات PowerPoint إلى PNG المجانية من Aspose **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) تحت الواجهة [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. استخدم الطريقة [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم الطريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

يوضح لك هذا الكود PHP كيفية تحويل عرض PowerPoint إلى PNG:
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة. 

يعرض هذا الكود العملية الموصوفة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة `width` و `height` لـ `ImageSize`. 

يظهر لك هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور: 
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل معين فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/php-java/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، ولكن [لا تشارك](/slides/ar/php-java/multithreading/) كائن عرض واحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/php-java/licensing/) حتى يتم تطبيق ترخيص.