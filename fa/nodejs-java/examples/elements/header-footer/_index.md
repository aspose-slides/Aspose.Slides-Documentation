---
title: سرصفحه و پاورقی
type: docs
weight: 220
url: /fa/nodejs-java/examples/elements/header-footer/
keywords:
- نمونه کد
- سرصفحه
- پاورقی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "سربرگ‌ها و پاورقی‌های اسلاید را با Aspose.Slides برای Node.js کنترل کنید: تاریخ‌ها، شماره اسلایدها و متن‌های سفارشی را در قالب‌های PPT، PPTX و ODP با مثال‌های JavaScript اضافه کنید."
---
این مقاله نشان می‌دهد چگونه پاورقی‌ها را اضافه کرده و جای‌متن تاریخ و زمان را به‌روزرسانی کنید با استفاده از **Aspose.Slides for Node.js via Java**.

## **افزودن پاورقی**
متن را به ناحیهٔ پاورقی یک اسلاید اضافه کنید و آن را قابل مشاهده کنید.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **به‌روزرسانی تاریخ و زمان**
جای‌متن تاریخ و زمان را در یک اسلاید اصلاح کنید.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```