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
- سبک یادداشت
- یادداشت‌های اصلی
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "یادداشت‌های ارائه را با Aspose.Slides برای PHP از طریق Java سفارشی کنید. به‌صورت یکپارچه با یادداشت‌های PowerPoint و OpenDocument کار کنید تا بهره‌وری خود را افزایش دهید."
---
## **نمای کلی**

Aspose.Slides امکان حذف اسلایدهای یادداشت را از یک ارائه فراهم می‌کند. در این مقاله، این ویژگی را معرفی می‌کنیم، از جمله نحوه حذف یادداشت‌ها و اعمال یک سبک به اسلایدهای یادداشت در یک ارائه. Aspose.Slides به شما اجازه می‌دهد یادداشت‌ها را از هر اسلاید حذف کنید و همچنین استایل‌گذاری بر روی یادداشت‌های موجود انجام دهید. توسعه‌دهندگان می‌توانند یادداشت‌ها را به روش‌های زیر حذف کنند:

- حذف یادداشت‌ها از یک اسلاید خاص در ارائه.
- حذف یادداشت‌ها از تمام اسلایدهای یک ارائه.

برای خواندن یا تغییر ابعاد صفحه یادداشت‌ها، تغییر جهت و بررسی رفتار صادرات، به [اندازه صفحه یادداشت‌ها](/slides/fa/php-java/notes-size/) مراجعه کنید.

## **حذف یادداشت‌ها از یک اسلاید**
یادداشت‌های یک اسلاید خاص می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # حذف یادداشت‌های اسلاید اول
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # ذخیرهٔ ارائه در دیسک
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حذف یادداشت‌ها از یک ارائه**
یادداشت‌های تمام اسلایدهای یک ارائه می‌توانند همان‌طور که در مثال زیر نشان داده شده است، حذف شوند:

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # حذف یادداشت‌های تمام اسلایدها
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # ذخیرهٔ ارائه در دیسک
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **اضافه کردن سبک یادداشت‌ها**
متد [getNotesStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) از کلاس [MasterNotesSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/MasterNotesSlide) دسترسی به سبک متن یادداشت‌ها را فراهم می‌کند. پیاده‌سازی در مثال زیر نشان داده شده است.

```php
  # یک شی Presentation ایجاد کنید که نمایانگر یک فایل ارائه است
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # دریافت سبک متن MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تنظیم گلوله نماد برای پاراگراف‌های سطح اول
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

یادداشت‌ها از طریق مدیر یادداشت‌های اسلاید دسترسی پیدا می‌کنند: اسلاید دارای یک [NotesSlideManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslidemanager/) و یک [متد](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notesslidemanager/getnotesslide/) است که شیء یادداشت‌ها را برمی‌گرداند، یا `null` اگر یادداشتی وجود نداشته باشد.

**آیا تفاوت‌هایی در پشتیبانی از یادداشت‌ها بین نسخه‌های PowerPoint که کتابخانه با آن‌ها کار می‌کند وجود دارد؟**

این کتابخانه هدف‌گذاری بر طیف گسترده‌ای از فرمت‌های Microsoft PowerPoint (97 تا جدیدتر) و ODP را دارد؛ یادداشت‌ها در این فرمت‌ها بدون نیاز به نصب نسخه‌ای از PowerPoint پشتیبانی می‌شوند.