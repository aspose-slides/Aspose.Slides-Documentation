---
title: "تبدیل ارائه‌های PowerPoint در حالت Handout با استفاده از Java"
linktitle: "حالت Handout"
type: docs
weight: 150
url: /fa/java/convert-powerpoint-in-Handout-mode/
keywords:
- "تبدیل PowerPoint"
- "تبدیل ارائه"
- "حالت توزیع"
- "توزیع"
- PPT
- PPTX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ارائه‌ها را به توزیع‌ها در Java تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را حفظ کنید، با Aspose.Slides به PDF یا تصاویر صادر کنید، با مثال کد Java. امتحان کنید رایگان."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را به فرمت‌های خروجی که حالت Handout را پشتیبانی می‌کنند، تبدیل کنید. در این حالت، اسلایدهای متعدد بر روی یک صفحه چیده می‌شوند که برای چاپ مطالب ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

حالت Handout از طریق متد `setSlidesLayoutOptions` پیکربندی می‌شود که در [IPdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihtmloptions/), و [ITiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itiffoptions/) موجود است. برای تعریف چینش Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید.

## **صدور در حالت Handout**

برای صادر کردن یک ارائه در حالت Handout، متد `setSlidesLayoutOptions` را برای گزینه‌های صادرات هدف تنظیم کنید و نمونه‌ای از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handoutlayoutingoptions/) را که تعداد اسلایدها در هر صفحه و پارامترهای نمایش مرتبط را تعریف می‌کند، اختصاص دهید.

در ادامه یک مثال کد نشان می‌دهد که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```java
// یک ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
    // تنظیم گزینه‌های صادرات.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 اسلاید در یک صفحه به صورت افقی
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // چاپ شماره اسلایدها
    slidesLayoutOptions.setPrintFrameSlide(true);                     // چاپ یک قاب اطراف اسلایدها
    slidesLayoutOptions.setPrintComments(false);                      // بدون نظرات

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // صادر کردن ارائه به PDF با قالب انتخاب شده.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" %}} 
به خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی از فرمت‌های خروجی مانند PDF، HTML، TIFF، و هنگام رندر به عنوان تصاویر در دسترس است.
{{% /alert %}} 

## **پرسش‌های متداول**

**حداکثر تعداد تصاویر کوچک اسلاید در هر صفحه در حالت Handout چیست؟**

Aspose.Slides پیش‌تنظیماتی تا حداکثر ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی را پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک جدول سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصاویر کوچک به‌طور دقیق توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/handouttype/) کنترل می‌شود؛ چینش‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات صادرات برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tiffoptions/) فعال کنید.