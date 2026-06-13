---
title: بخش
type: docs
weight: 90
url: /fa/php-java/examples/elements/section/
keywords:
- بخش
- بخش اسلاید
- افزودن بخش
- دسترسی به بخش
- حذف بخش
- تغییر نام بخش
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در PHP با Aspose.Slides: ایجاد، تغییر نام، ترتیب‌گذاری آسان، انتقال اسلایدها بین بخش‌ها و کنترل نمایش برای PPT، PPTX و ODP."
---
نمونه‌هایی برای مدیریت بخش‌های ارائه—اضافه کردن، دسترسی، حذف و تغییر نام آن‌ها به‌صورت برنامه‌نویسی با استفاده از **Aspose.Slides for PHP via Java**.

## **افزودن یک بخش**

یک بخش ایجاد کنید که از یک اسلاید خاص شروع می‌شود.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // اسلایدی را که شروع بخش را نشان می‌دهد مشخص کنید.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **دسترسی به یک بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // دسترسی به یک بخش با ایندکس.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **حذف یک بخش**

یک بخش که قبلاً اضافه شده است را حذف کنید.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // بخش را حذف کنید.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تغییر نام یک بخش**

نام یک بخش موجود را تغییر دهید.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```