---
title: افزودن بیضی‌ها به ارائه‌ها در PHP
linktitle: بیضی
type: docs
weight: 30
url: /fa/php-java/ellipse/
keywords:
- بیضی
- شکل
- افزودن بیضی
- ایجاد بیضی
- رسم بیضی
- بیضی قالب‌بندی‌شده
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌های بیضی را در Aspose.Slides برای PHP از طریق Java در ارائه‌های PPT و PPTX ایجاد، قالب‌بندی و دستکاری کنید — مثال‌های کد نیز گنجانده شده است."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه می‌توان اشکال بیضی را به اسلایدهای PowerPoint با استفاده از Aspose.Slides افزود. این مقاله ایجاد یک بیضی ساده، ایجاد یک بیضی قالب‌بندی‌شده، و ذخیره ارائه بروز شده به صورت فایل PPTX را پوشش می‌دهد. همچنین به سؤالات مرتبطی مانند کار با موقعیت و اندازه بیضی، کنترل ترتیب لایه‌ها، و اعمال افکت‌های انیمیشن می‌پردازد.

## **ایجاد یک بیضی**
برای افزودن یک بیضی ساده به اسلاید انتخاب شده از ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از ایندکس آن، مرجع یک اسلاید را دریافت کنید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) در دسترس است، اضافه کنید.
- ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک بیضی به اسلاید اول اضافه کرده‌ایم

```php
  # ایجاد نمونهٔ کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع بیضی
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # نوشتن فایل PPTX روی دیسک
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ایجاد یک بیضی قالب‌بندی‌شده**
برای افزودن یک بیضی قالب‌بندی‌شده بهتر به یک اسلاید، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از ایندکس آن، مرجع یک اسلاید را دریافت کنید.
- یک AutoShape از نوع Ellipse را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#addAutoShape) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/) در دسترس است، اضافه کنید.
- نوع پر شدن بیضی را به Solid تنظیم کنید.
- رنگ بیضی را با استفاده از متد `SolidFillColor::setColor` که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) در دسترس است، تنظیم کنید.
- رنگ خطوط بیضی را تنظیم کنید.
- عرض خطوط بیضی را تنظیم کنید.
- ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک بیضی قالب‌بندی‌شده به اسلاید اول ارائه اضافه کرده‌ایم.

```php
  # ایجاد نمونهٔ کلاس Presentation که نمایانگر PPTX است
  $pres = new Presentation();
  try {
    # دریافت اولین اسلاید
    $sld = $pres->getSlides()->get_Item(0);
    # افزودن AutoShape از نوع بیضی
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # اعمال برخی قالب‌بندی‌ها به شکل بیضی
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # اعمال برخی قالب‌بندی‌ها به خط بیضی
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # نوشتن فایل PPTX روی دیسک
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چگونه موقعیت و اندازه دقیق یک بیضی را نسبت به واحدهای اسلاید تنظیم کنم؟**

مختصات و اندازه‌ها معمولاً **بر حسب نقطه** (points) مشخص می‌شوند. برای نتایج پیش‌بینی‌شده، محاسبات خود را بر پایهٔ اندازه اسلاید پایه‌گذاری کنید و قبل از اختصاص مقادیر، میلی‌متر یا اینچ مورد نیاز را به نقطه تبدیل کنید.

**چگونه می‌توانم یک بیضی را بالای یا پایین سایر اشیاء قرار دهم (کنترل ترتیب لایه‌ها)؟**

ترتیب رسم شیء را با بردن آن به جلو یا ارسال به عقب تنظیم کنید. این کار به بیضی امکان می‌دهد تا دیگر اشیاء را پوشش دهد یا اشیائی که زیر آن هستند را آشکار کند.

**چگونه می‌توانم ظاهر یا تأکید یک بیضی را انیمیشن کنم؟**

[اعمال](/slides/fa/php-java/shape-animation/) افکت‌های ورودی، تأکید یا خروجی را به شکل اعمال کنید و ترِیگرها و زمان‌بندی را تنظیم کنید تا زمان و نحوه پخش انیمیشن را سازماندهی کنید.