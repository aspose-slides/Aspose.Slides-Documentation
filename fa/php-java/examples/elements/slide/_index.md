---
title: اسلاید
type: docs
weight: 10
url: /fa/php-java/examples/elements/slide/
keywords:
- اسلاید
- افزودن اسلاید
- دسترسی به اسلاید
- شاخص اسلاید
- کلون اسلاید
- ترتیب مجدد اسلایدها
- حذف اسلاید
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "اسلایدها را در PHP با Aspose.Slides مدیریت کنید: ایجاد، کلون، ترتیب مجدد، مخفی‌کردن، تنظیم پس‌زمینه و اندازه، اعمال انتقال‌ها و صادرات برای PowerPoint و OpenDocument."
---
این مقاله مجموعه‌ای از مثال‌ها را ارائه می‌دهد که نشان می‌دهند چگونه با اسلایدها با استفاده از **Aspose.Slides for PHP via Java** کار کنید. شما می‌آموزید چگونه اسلایدها را با استفاده از کلاس `Presentation` اضافه، دسترسی، کلون، ترتیب داده و حذف کنید.

هر مثال زیر شامل توضیحی کوتاه و سپس یک قطعه کد در PHP است.

## **افزودن اسلاید**

برای افزودن اسلاید جدید، ابتدا باید یک طرح‌بندی (layout) انتخاب کنید. در این مثال، از طرح‌بندی `Blank` استفاده می‌کنیم و یک اسلاید خالی به ارائه اضافه می‌کنیم.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // هر اسلاید بر پایه یک طرح‌بندی است که خود بر پایه یک اسلاید اصلی (master) می‌باشد.
        // از طرح‌بندی Blank برای ایجاد یک اسلاید جدید استفاده کنید.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // یک اسلاید خالی جدید را با استفاده از طرح‌بندی انتخاب شده اضافه کنید.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **نکته:** هر طرح‌بندی اسلاید از یک اسلاید اصلی (master slide) مشتق می‌شود که طراحی کلی و ساختار مکان‌قرارها را تعریف می‌کند. تصویر زیر نشان می‌دهد که اسلایدهای اصلی و طرح‌بندی‌های مرتبط آن‌ها چگونه در PowerPoint سازماندهی شده‌اند.

![Master and Layout Relationship](master-layout-slide.png)

## **دسترسی به اسلایدها بر اساس شاخص**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // دسترسی به اسلاید بر اساس شاخص.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **کلون کردن اسلاید**

```php
function cloneSlide() {
    // به طور پیش‌فرض، ارائه شامل یک اسلاید خالی است.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // کلون اولین اسلاید؛ این اسلاید به انتهای ارائه اضافه می‌شود.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // شاخص اسلاید کلون‌شده 1 است (دومین اسلاید در ارائه).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تغییر ترتیب اسلایدها**

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // اسلاید را به اولین موقعیت منتقل کنید (سایر اسلایدها به پایین جابجا می‌شوند).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف اسلاید**

برای حذف یک اسلاید، به سادگی به آن ارجاع دهید و متد `remove` را صدا بزنید. این مثال اسلایدها را بر اساس شاخص و بر اساس ارجاع حذف می‌کند.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // حذف یک اسلاید بر اساس شاخص.
        $presentation->getSlides()->removeAt(0);

        // حذف یک اسلاید بر اساس ارجاع.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```