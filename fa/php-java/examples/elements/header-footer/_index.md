---
title: سرصفحه و پاصفحه
type: docs
weight: 220
url: /fa/php-java/examples/elements/header-footer/
keywords:
- سرصفحه و پاصفحه
- افزودن سرصفحه و پاصفحه
- به‌روزرسانی سرصفحه و پاصفحه
- نمونه کد
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "کنترل سرصفحه‌ها و پاصفحه‌ها در PHP با Aspose.Slides: افزودن یا ویرایش تاریخ/زمان، شماره اسلایدها و متن پاصفحه، نمایش یا مخفی‌سازی نگهدارنده‌ها در قالب‌های PPT، PPTX و ODP."
---
نحوه افزودن فوترها و به‌روزرسانی نگهدارنده‌های تاریخ و زمان را با استفاده از **Aspose.Slides for PHP via Java** نشان می‌دهد.

## **افزودن فوتر**

متن را به ناحیه فوتر یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **به‌روز رسانی تاریخ و زمان**

نگهدارنده تاریخ و زمان را در یک اسلاید تغییر دهید.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```