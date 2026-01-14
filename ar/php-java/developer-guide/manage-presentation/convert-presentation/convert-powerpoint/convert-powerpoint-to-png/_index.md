---
title: تحويل شرائح PowerPoint إلى PNG في PHP
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/php-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- عرض تقديمي إلى PNG
- شريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- PHP
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للـ PHP عبر Java، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا مثل JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا. 

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تشكل الحجم مشكلة، يكون PNG تنسيق صورة أفضل من JPEG. 

{{% alert title="Tip" color="primary" %}} قد ترغب في الاطلاع على محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ مباشر للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) ضمن الفئة [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. استخدم طريقة [Slide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) لحفظ الصورة المصغرة للشرائح بتنسيق PNG.

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

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك ضبط القيم `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة. 

يعرض هذا الشيفرة العملية الموضحة:
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

يعرض هذا الشيفرة كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور: 
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

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/php-java/create-shape-thumbnails/); يمكنك تصيير الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، ولكن يجب [عدم مشاركة](/slides/ar/php-java/multithreading/) كائن presentation واحد عبر الخيوط. استخدم كائنًا منفصلًا لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويطبق [قيودًا أخرى](/slides/ar/php-java/licensing/) حتى يتم تطبيق ترخيص.