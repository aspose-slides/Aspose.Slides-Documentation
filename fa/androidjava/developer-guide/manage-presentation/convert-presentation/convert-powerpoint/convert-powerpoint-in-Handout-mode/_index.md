---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه در اندروید
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در جاوا تبدیل کنید. اسلایدها را در هر صفحه تنظیم کنید، یادداشت‌ها را حفظ کنید، با Aspose.Slides برای اندروید به PDF یا تصاویر صادر کنید، همراه با کد نمونه. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که نحوه نمایش چند اسلاید روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در رابط‌های [IPdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipdfoptions/),[IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/),[IHtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihtmloptions/), و [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) فعال کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار می‌گیرد و سایر پارامترهای نمایش را مشخص می‌کند.

در زیر یک مثال کد نشان می‌دهد که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```java
// یک ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
	// تنظیم گزینه‌های خروجی.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
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
به یاد داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **پرسش‌های متداول**

**حداکثر تعداد تصویر کوچک اسلایدها در هر صفحه در حالت Handout چه تعداد است؟**

Aspose.Slides پیش‌تنظیم‌هایی را تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی). برای جزئیات بیشتر به [presets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) مراجعه کنید.

**آیا می‌توانم یک شبکه سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به طور دقیق توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. می‌توانید اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات صادرات برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) فعال کنید.