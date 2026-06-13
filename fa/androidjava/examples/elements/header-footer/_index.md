---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/androidjava/examples/elements/header-footer/
keywords:
- نمونه کد
- سرصفحه
- پاورقی
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "کنترل سرعنوان‌ها و پاورقی‌های اسلاید با Aspose.Slides برای اندروید: افزودن تاریخ‌ها، شماره اسلایدها و متن دلخواه در فرمت‌های PPT، PPTX و ODP با مثال‌های جاوا."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کنید و متغیرهای جای‌نگه‌دار تاریخ و زمان را با استفاده از **Aspose.Slides for Android via Java** به‌روزرسانی کنید.

## **افزودن یک پاورقی**

متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی تاریخ و زمان**

متغیر جای‌نگه‌دار تاریخ و زمان را در یک اسلاید اصلاح کنید.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```