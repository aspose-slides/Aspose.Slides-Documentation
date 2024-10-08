---
title: تحويل PowerPoint إلى GIF متحرك
type: docs
weight: 65
url: /ar/php-java/convert-powerpoint-to-animated-gif/
keywords: "تحويل PowerPoint إلى GIF متحرك، PPT إلى GIF، PPTX إلى GIF"
description: "تحويل PowerPoint إلى GIF متحرك: PPT إلى GIF، PPTX إلى GIF، باستخدام واجهة برمجة تطبيقات Aspose.Slides."
---

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية ##

هذا الكود النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية. 

{{%  alert  title="نصيحة"  color="primary"  %}} 

إذا كنت تفضل تخصيص المعلمات لـ GIF، يمكنك استخدام فئة [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). انظر الكود النموذجي أدناه.

{{% /alert %}} 

## تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة ##
هذا الكود النموذجي يوضح لك كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات المخصصة:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// حجم GIF الناتج

    $gifOptions->setDefaultDelay(2000);// المدة التي سيتم عرض كل شريحة حتى يتم الانتقال إلى الشريحة التالية

    $gifOptions->setTransitionFps(35);// زيادة FPS لتحسين جودة انتقال الرسوم المتحركة

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="معلومات" color="info" %}}

ربما ترغب في الاطلاع على محول [Text to GIF](https://products.aspose.app/slides/text-to-gif) المجاني الذي طورته Aspose. 

{{% /alert %}}