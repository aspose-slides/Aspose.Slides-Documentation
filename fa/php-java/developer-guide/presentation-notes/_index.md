---
title: مدیریت یادداشت‌های ارائه در PHP
linktitle: یادداشت‌های ارائه
type: docs
weight: 110
url: /fa/php-java/presentation-notes/
keywords:
- یادداشت
- اسلاید یادداشت
- افزودن یادداشت
- حذف یادداشت
- استایل یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای PHP از طریق Java سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را ارتقا دهید."
---
## **بررسی کلی**

Aspose.Slides از حذف اسلایدهای یادداشت از یک ارائه پشتیبانی می‌کند. در این مطلب، این ویژگی را معرفی خواهیم کرد، شامل نحوه حذف یادداشت‌ها و نحوه اعمال سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما امکان حذف یادداشت‌ها از هر اسلاید و همچنین اعمال استایل به یادداشت‌های موجود را می‌دهد. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در یک ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌گونه که در مثال زیر نشان داده شده است حذف شوند:

```php
  # یک شیء Presentation نمونه می‌سازد که نمایانگر یک فایل ارائه است
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # حذف یادداشت‌های اسلاید اول
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # ذخیره‌سازی ارائه بر روی دیسک
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌گونه که در مثال زیر نشان داده شده است حذف شوند:

```php
  # یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # حذف یادداشت‌های تمام اسلایدها
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # ذخیره‌سازی ارائه بر روی دیسک
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اضافه کردن سبک به یادداشت‌ها**
[getNotesStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) متد به کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterNotesSlide) اضافه شده است. این خصوصیت سبک متن یادداشت را تعیین می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```php
  # یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # دریافت سبک متن MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تنظیم گلوله نمادیک برای پاراگراف‌های سطح اول
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**کدام موجودیت API دسترسی به یادداشت‌های یک اسلاید خاص را فراهم می‌کند؟**

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی می‌یابند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslidemanager/) و یک [متد](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslidemanager/getnotesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر هیچ یادداشتی وجود نداشته باشد.

**آیا در پشتیبانی از یادداشت‌ها در نسخه‌های مختلف PowerPoint که کتابخانه با آن‌ها کار می‌کند، تفاوتی وجود دارد؟**

کتابخانه هدف‌گذاری خود را بر روی دامنه وسیعی از فرمت‌های Microsoft PowerPoint (از نسخه 97 به بعد) و ODP قرار داده است؛ یادداشت‌ها در این فرمت‌ها بدون وابستگی به یک نسخه نصب‌شده از PowerPoint پشتیبانی می‌شوند.