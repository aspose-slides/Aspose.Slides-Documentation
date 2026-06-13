---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/java/examples/elements/header-footer/
keywords:
- مثال کد
- سرصفحه
- پاورقی
- پاورپوینت
- اسناد باز
- ارائه
- جاوا
- Aspose.Slides
description: "سرصفحه‌ها و پاورقی‌های اسلاید را با Aspose.Slides برای جاوا کنترل کنید: تاریخ‌ها، شماره اسلاید و متن سفارشی را در فرمت‌های PPT، PPTX و ODP با نمونه‌های جاوا اضافه کنید."
---
این مقاله نشان می‌دهد که چگونه پاورقی‌ها را اضافه کرده و جایگیرهای تاریخ و زمان را با استفاده از **Aspose.Slides for Java** به روزرسانی کنید.

## **افزودن پاورقی**
متن را به ناحیه پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

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

## **به روزرسانی تاریخ و زمان**
جایگیر تاریخ و زمان را در یک اسلاید تغییر دهید.

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