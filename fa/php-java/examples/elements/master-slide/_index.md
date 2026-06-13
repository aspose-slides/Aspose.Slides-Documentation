---
title: اسلاید اصلی
type: docs
weight: 30
url: /fa/php-java/examples/elements/master-slide/
keywords:
- اسلاید اصلی
- افزودن اسلاید اصلی
- دسترسی به اسلاید اصلی
- حذف اسلاید اصلی
- اسلاید اصلی استفاده‌نشده
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت اسلایدهای اصلی در PHP با Aspose.Slides: ایجاد، ویرایش، کلون و قالب‌بندی تم‌ها، پس‌زمینه‌ها، جای‌دارها برای یکسان‌سازی اسلایدها در PowerPoint و OpenDocument."
---
اسلایدهای اصلی سطوح بالایی سلسله‌مراتب وراثت اسلایدها در PowerPoint را تشکیل می‌دهند. یک **اسلاید اصلی** عناصر طراحی مشترکی مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **اسلایدهای چیدمان** از اسلایدهای اصلی ارث می‌برند و **اسلایدهای عادی** از اسلایدهای چیدمان ارث می‌گیرند.

این مقاله نشان می‌دهد چگونه اسلایدهای اصلی را با استفاده از Aspose.Slides برای PHP از طریق Java ایجاد، اصلاح و مدیریت کنیم.

## **افزودن اسلاید اصلی**

این مثال نشان می‌دهد که چگونه با کلون کردن اسلاید پیش‌فرض، یک اسلاید اصلی جدید ایجاد کنیم.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // کلون کردن اسلاید اصلی پیش‌فرض.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** اسلایدهای اصلی روشی برای اعمال برندینگ یکنواخت یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در اسلاید اصلی اعمال شود، به‌صورت خودکار بر روی اسلایدهای چیدمان و اسلایدهای عادی وابسته بازتاب می‌یابد.

> 💡 **Tip 2:** هر شکل یا قالب‌بندی که به اسلاید اصلی اضافه شود، توسط اسلایدهای چیدمان ارث‌بری می‌شود و به‌نوبت بر تمام اسلایدهای عادی که از آن چیدمان‌ها استفاده می‌کنند اعمال می‌شود. تصویر زیر نشان می‌دهد که چگونه یک جعبه متن اضافه شده در اسلاید اصلی به‌صورت خودکار در اسلاید نهایی رندر می‌شود.

![Master Inheritance Example](master-slide-banner.png)

## **دسترسی به اسلاید اصلی**

می‌توانید با استفاده از متد `Presentation::getMasters` به اسلایدهای اصلی دسترسی پیدا کنید. اینجا نحوه دریافت و کار با آن‌ها آمده است:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // دسترسی به اولین اسلاید اصلی.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف اسلاید اصلی**

اسلایدهای اصلی می‌توانند یا بر اساس شاخص یا بر اساس مرجع حذف شوند.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // حذف بر اساس اندیس.
        $presentation->getMasters()->removeAt(0);

        // یا حذف بر اساس مرجع.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف اسلایدهای اصلی استفاده‌نشده**

برخی ارائه‌ها شامل اسلایدهای اصلی هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // حذف تمام اسلایدهای اصلی استفاده‌نشده (حتی آنهایی که به عنوان Preserve علامت‌گذاری شده‌اند).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** از `removeUnused(true)` برای پاک‌سازی اسلایدهای اصلی استفاده‌نشده و به حداقل رساندن حجم ارائه استفاده کنید.