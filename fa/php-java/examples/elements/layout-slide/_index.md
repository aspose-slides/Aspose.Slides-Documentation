---
title: اسلاید چیدمان
type: docs
weight: 20
url: /fa/php-java/examples/elements/layout-slide/
keywords:
- اسلاید چیدمان
- افزودن اسلاید چیدمان
- دسترسی به اسلاید چیدمان
- حذف اسلاید چیدمان
- اسلاید چیدمان استفاده‌نشده
- کلون اسلاید چیدمان
- مثال‌های کد
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "از PHP برای مدیریت اسلایدهای چیدمان با Aspose.Slides استفاده کنید: ایجاد، اعمال، کلون، تغییر نام و سفارشی‌سازی نگهدارنده‌ها و تم‌ها در ارائه‌ها برای PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه با **Layout Slides** در Aspose.Slides for PHP via Java کار کنید. یک layout slide طراحی و قالب‌بندی‌ای را تعریف می‌کند که اسلایدهای معمولی از آن ارث می‌برند. می‌توانید layout slides را اضافه، دسترسی، کلون و حذف کنید و همچنین موارد استفاده‌نشدۀ آن‌ها را پاک کنید تا حجم ارائه کاهش یابد.

## **افزودن یک Layout Slide**

می‌توانید یک layout slide سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کنید. برای مثال، ممکن است یک جعبه متن اضافه کنید که در تمام اسلایدهای استفاده‌کننده از این layout نمایش داده شود.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // یک اسلاید چیدمان با نوع چیدمان Blank و نام سفارشی ایجاد کنید.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نکته 1:** Layout slides مانند قالب برای اسلایدهای فردی عمل می‌کنند. می‌توانید عناصر مشترک را یک‌بار تعریف کرده و در اسلایدهای متعدد باز استفاده کنید.

> 💡 **نکته 2:** وقتی اشکال یا متن را به یک layout slide اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن layout به‌صورت خودکار محتوای مشترک را نمایش می‌دهند.
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن از یک layout slide واحد ارث می‌برند.

![اسلایدهای ارث‌بری محتوا از Layout](layout-slide-result.png)


## **دسترسی به یک Layout Slide**

Layout slides می‌توانند با ایندکس یا نوع layout (مثلاً `Blank`، `Title`، `SectionHeader` و غیره) دسترسی پیدا کنند.

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // دسترسی بر اساس ایندکس.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // دسترسی بر اساس نوع چیدمان.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک Layout Slide**

اگر یک layout slide دیگر نیازی به آن ندارید می‌توانید آن را حذف کنید.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // دریافت یک اسلاید چیدمان بر اساس نوع و حذف آن.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف Layout Slides استفاده‌نشده**

برای کاهش حجم ارائه، ممکن است بخواهید layout slideهایی را که توسط هیچ اسلاید معمولی استفاده نمی‌شوند حذف کنید.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // به طور خودکار تمام اسلایدهای چیدمان که توسط هیچ اسلایدی ارجاع نشده‌اند حذف می‌کند.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **کلون یک Layout Slide**

می‌توانید یک layout slide را با استفاده از متد `addClone` تکثیر کنید.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // دریافت یک اسلاید چیدمان موجود بر اساس نوع.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // کلون کردن اسلاید چیدمان به انتهای مجموعه اسلایدهای چیدمان.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **خلاصه:** Layout slides ابزارهای قدرتمندی برای مدیریت قالب‌بندی یکدست در سراسر اسلایدها هستند. Aspose.Slides امکان کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی layout slides را فراهم می‌کند.