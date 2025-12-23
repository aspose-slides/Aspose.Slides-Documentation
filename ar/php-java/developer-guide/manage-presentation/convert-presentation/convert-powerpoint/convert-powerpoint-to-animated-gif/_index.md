---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحرك في PHP
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "حوّل عروض PowerPoint التقديمية (PPT, PPTX) بسهولة إلى GIF متحرك باستخدام Aspose.Slides للـ PHP عبر Java. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

هذا المثال البرمجي يوضح كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
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


سيتم إنشاء الـ GIF المتحرك بواسطة المعلمات الافتراضية. 

{{% alert title="نصيحة" color="primary" %}} 

إذا كنت ترغب في تخصيص معلمات الـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). راجع المثال البرمجي أدناه.

{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**
هذا المثال البرمجي يوضح كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// حجم GIF الناتج

    $gifOptions->setDefaultDelay(2000);// المدة التي ستظهر فيها كل شريحة حتى يتم الانتقال إلى التالية

    $gifOptions->setTransitionFps(35);// زيادة عدد الإطارات لتقوية جودة انتقال الحركة

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="معلومات" color="info" %}}

قد ترغب في تجربة محول مجاني [نص إلى GIF](https://products.aspose.app/slides/text-to-gif) تم تطويره بواسطة Aspose. 

{{% /alert %}}

## **الأسئلة المتكررة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط المفقودة أو [تكوين خطوط بديلة](/slides/ar/php-java/powerpoint-fonts/). سيقوم Aspose.Slides بالبديل، لكن قد يختلف المظهر. للعلامة التجارية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

**هل يمكنني إضافة علامة مائية على إطارات الـ GIF؟**

نعم. [أضف كائن/شعار شبه شفاف](/slides/ar/php-java/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.