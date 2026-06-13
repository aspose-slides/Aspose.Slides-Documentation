---
title: "تبدیل ارائه‌های PowerPoint به حالت جزوه در Android"
linktitle: "حالت جزوه"
type: docs
weight: 150
url: /fa/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- "تبدیل PowerPoint"
- "تبدیل ارائه"
- "حالت جزوه"
- "جزوه"
- PPT
- PPTX
- PowerPoint
- "ارائه"
- Android
- Java
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در Java تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را حفظ کنید، با Aspose.Slides برای Android به PDF یا تصاویر صادر کنید، همراه با کد نمونه. رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد تنظیم کنید که چند اسلاید بر روی یک صفحه ظاهر شوند، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در رابط‌های [IPdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihtmloptions/), و [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) فعال کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار گیرند و سایر پارامترهای نمایش.

در زیر یک مثال کد نشان داده شده است که چگونگی تبدیل یک ارائه به PDF در حالت Handout را نشان می‌دهد.

```java
// یک ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
	// گزینه‌های خروجی را تنظیم کنید.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // چاپ شماره اسلایدها
	slidesLayoutOptions.setPrintFrameSlide(true);                     // چاپ قاب دور اسلایدها
	slidesLayoutOptions.setPrintComments(false);                      // بدون نظرات

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// ارائه را به PDF با طرح انتخاب‌شده صادر کنید.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" %}} 
به یاد داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به‌عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصویرهای کوچک اسلاید در هر صفحه در حالت Handout چیست؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) حداکثر تا 9 تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند 5 یا 8 اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به‌صورت کامل توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات صادرات برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) فعال کنید.