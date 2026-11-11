---
title: تبدیل ارائه‌های PowerPoint در حالت Handout برای Android
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- برگه‌دست‌نویس
- PPT
- PPTX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ارائه‌ها را به برگه‌های دست‌نویس در Java تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides برای Android به PDF یا تصاویر استخراج کنید، همراه با نمونه کد. آن را به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد برگه‌های دست‌نویس برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که نحوه نمایش چند اسلاید بر روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در اینترفیس‌های [IPdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihtmloptions/), و [ITiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itiffoptions/) فعال کنید.

برای تنظیم ابعاد و جهت‌گیری صفحه برگه دست‌نویس قبل از خروجی، به [اندازه صفحه یادداشت‌ها](/slides/fa/androidjava/notes-size/) مراجعه کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار می‌گیرد و سایر پارامترهای نمایش را مشخص می‌کند.

در زیر یک مثال کد آورده شده است که نشان می‌دهد چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```java
import com.aspose.slides.*;

// یک ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.pptx");
try {
	// گزینه‌های خروجی را تنظیم کنید.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ۴ اسلاید افقی در یک صفحه
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // چاپ شماره اسلایدها
	slidesLayoutOptions.setPrintFrameSlide(true);                     // چاپ یک چهارچوب دور اسلایدها
	slidesLayoutOptions.setPrintComments(false);                      // بدون توضیح

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// ارائه را با چیدمان انتخابی به PDF صادر کنید.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
به‌خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصاویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویر کوچک اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) تا 9 تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به‌طور دقیق توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/handouttype/) کنترل می‌شود؛ طرح‌بندی‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout شامل کنم؟**

بله. با استفاده از متد `setShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tiffoptions/) اسلایدهای مخفی را فعال کنید.