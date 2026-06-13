---
title: حذف اسلایدها از ارائه‌ها در PHP
linktitle: حذف اسلاید
type: docs
weight: 30
url: /fa/php-java/remove-slide-from-presentation/
keywords:
- حذف اسلاید
- حذف اسلاید
- حذف اسلاید استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "به راحتی اسلایدها را از ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java حذف کنید. نمونه‌های کد واضح دریافت کنید و جریان کاری خود را ارتقا دهید."
---
## **مقدمه**

اگر یک اسلاید (یا محتویات آن) بیش از حد شود، می‌توانید آن را حذف کنید. Aspose.Slides کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را ارائه می‌دهد که شامل [SlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) است؛ این مجموعه مخزنی برای تمام اسلایدهای یک ارائه است. با استفاده از اشاره‌گرها (مرجع یا اندیس) برای یک شیء شناخته‌شدهٔ [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) می‌توانید اسلاید موردنظر برای حذف را تعیین کنید.

## **حذف اسلاید بر اساس ارجاع**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلایدی که می‌خواهید حذف کنید را از طریق شناسه یا اندیس آن به‌دست آورید.
1. اسلاید ارجاع داده شده را از ارائه حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک اسلاید را از طریق ارجاع آن حذف کنید:

```php
  # یک شی Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
  $pres = new Presentation("demo.pptx");
  try {
    # یک اسلاید را از طریق ایندکس آن در مجموعه اسلایدها دسترسی می‌یابد
    $slide = $pres->getSlides()->get_Item(0);
    # یک اسلاید را از طریق ارجاع آن حذف می‌کند
    $pres->getSlides()->remove($slide);
    # ارائهٔ تغییر یافته را ذخیره می‌کند
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **حذف اسلاید بر اساس اندیس**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) ایجاد کنید.
1. اسلاید را از ارائه از طریق موقعیت اندیس آن حذف کنید.
1. ارائهٔ تغییر یافته را ذخیره کنید.

این کد PHP نشان می‌دهد چگونه یک اسلاید را از طریق اندیس آن حذف کنید:

```php
  # یک شی Presentation را ایجاد می‌کند که نمایانگر یک فایل ارائه است
  $pres = new Presentation("demo.pptx");
  try {
    # اسلاید را از طریق ایندکس آن حذف می‌کند
    $pres->getSlides()->removeAt(0);
    # ارائهٔ تغییر یافته را ذخیره می‌کند
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) را (از کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) ) ارائه می‌کند تا بتوانید اسلایدهای طرح‌بندی ناخواسته و استفاده‌نشده را حذف کنید. این کد PHP نشان می‌دهد چگونه یک اسلاید طرح‌بندی را از یک ارائهٔ PowerPoint حذف کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف اسلایدهای اصلی استفاده‌نشده**

Aspose.Slides متد [removeUnusedMasterSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) را (از کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) ) ارائه می‌کند تا بتوانید اسلایدهای اصلی ناخواسته و استفاده‌نشده را حذف کنید. این کد PHP نشان می‌دهد چگونه یک اسلاید اصلی را از یک ارائهٔ PowerPoint حذف کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **پرسش‌های متداول**

**بعد از حذف یک اسلاید، ایندکس‌های اسلایدها چه اتفاقی می‌افتند؟**

پس از حذف، [مجموعه](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) مجدداً ایندکس می‌شود: هر اسلاید پس از آن یک موقعیت به سمت چپ جابه‌جا می‌شود، بنابراین شماره‌های ایندکس قبلی منسوخ می‌گردند. اگر به یک مرجع ثابت نیاز دارید، به‌جای ایندکس از شناسهٔ دائمی هر اسلاید استفاده کنید.

**ID اسلاید متفاوت از ایندکس آن است و آیا با حذف اسلایدهای همجوار تغییر می‌کند؟**

بله. ایندکس موقعیت اسلاید است و با اضافه یا حذف اسلایدها تغییر می‌کند. شناسهٔ اسلاید یک شناسهٔ پایدار است و هنگام حذف اسلایدهای دیگر تغییر نمی‌کند.

**حذف یک اسلاید چطور بر بخش‌های اسلایدها تأثیر می‌گذارد؟**

اگر اسلاید در یک بخش قرار داشت، آن بخش فقط یک اسلاید کمتر خواهد داشت. ساختار بخش به‌هم نمی‌خورد؛ اگر بخشی خالی شد، می‌توانید [حذف یا بازسازی بخش‌ها](/slides/fa/php-java/slide-section/) را انجام دهید.

**یادداشت‌ها و نظرهای متصل به اسلاید پس از حذف آن چه می‌شود؟**

[یادداشت‌ها](/slides/fa/php-java/presentation-notes/) و [نظرها](/slides/fa/php-java/presentation-comments/) به آن اسلاید خاص وابسته هستند و همراه با آن حذف می‌شوند. محتواهای اسلایدهای دیگر تحت‌تأثیر قرار نمی‌گیرند.

**حذف اسلایدها با پاک‌سازی طرح‌ها/اصلی‌های استفاده‌نشده چه تفاوتی دارد؟**

حذف اسلایدها اسلایدهای معمولی خاصی را از مجموعه حذف می‌کند. پاک‌سازی طرح‌ها/اصلی‌های استفاده‌نشده اسلایدهای طرح یا اصلی را که هیچ اسلایدی به آن‌ها ارجاع نمی‌دهد حذف می‌کند، حجم فایل را کم می‌کند بدون این که محتوای اسلایدهای باقی‌مانده تغییر یابد. این دو عملیات مکمل هستند: معمولاً ابتدا اسلایدها را حذف کنید، سپس پاک‌سازی را انجام دهید.