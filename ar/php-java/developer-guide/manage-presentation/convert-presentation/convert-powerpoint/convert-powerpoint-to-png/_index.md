---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/php-java/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG, PPT إلى PNG, PPTX إلى PNG, java, Aspose.Slides for PHP عبر Java
description: تحويل عرض PowerPoint إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (صور الشبكة المحمولة) ليس شائعًا مثل JPEG (مجموعة خبراء التصوير المشتركة)، ولكنه لا يزال شائعًا للغاية.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في الاطلاع على محولات **PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ مباشر للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

قم بتنفيذ الخطوات التالية:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) تحت واجهة [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide).
3. استخدم طريقة [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

يعرض هذا الكود PHP كيفية تحويل عرض PowerPoint إلى PNG:

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

## **تحويل PowerPoint إلى PNG مع أبعاد مخصصة**

إذا كنت ترغب في الحصول على ملفات PNG حول مقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

يوضح هذا الكود العملية الموصوفة:

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

## **تحويل PowerPoint إلى PNG مع حجم مخصص**

إذا كنت ترغب في الحصول على ملفات PNG حول حجم معين، يمكنك تمرير قيم `width` و `height` المفضلة لديك لـ `ImageSize`.

يوضح هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور:

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