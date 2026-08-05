---
title: تبدیل ارائه‌های PowerPoint به حالت Handout با استفاده از Java
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- Handout
- PPT
- PPTX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ارائه‌ها را در Java به Handout تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، به PDF یا تصاویر با Aspose.Slides صادر کنید، همراه با کد نمونه Java. رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را به قالب‌های خروجی که حالت Handout را پشتیبانی می‌کنند، تبدیل کنید. در این حالت، چندین اسلاید بر روی یک صفحه چیده می‌شوند که برای چاپ مواد ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

حالت Handout از طریق متد `setSlidesLayoutOptions` پیکربندی می‌شود که در [IPdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihtmloptions/) و [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) موجود است. برای تعریف چیدمان Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید.

## **صادر کردن در حالت Handout**

برای صادر کردن یک ارائه در حالت Handout، متد `setSlidesLayoutOptions` را برای گزینه‌های صادرات هدف تنظیم کنید و یک نمونه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) که تعداد اسلایدها در هر صفحه و پارامترهای نمایش مرتبط را تعریف می‌کند، اختصاص دهید.

در زیر یک مثال کد نشان داده شده است که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```java
// یک ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // تنظیم گزینه‌های خروجی.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ۴ اسلاید به صورت افقی در یک صفحه
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // چاپ شماره اسلایدها
    slidesLayoutOptions.setPrintFrameSlide(true);                     // چاپ قاب دور اسلایدها
    slidesLayoutOptions.setPrintComments(false);                      // بدون نظرات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // ارائه را با چیدمان انتخابی به PDF صادر کنید.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 

به‌خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی قالب‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.

{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد کوچک‌نمای اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) تا ۹ کوچک‌نمای در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند 5 یا 8 اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب کوچک‌نمای‌ها به‌صورت کامل توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات صادرات برای قالب هدف فعال کنید، مانند [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/).