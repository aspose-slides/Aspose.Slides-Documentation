---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه با PHP
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/php-java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در PHP تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides برای PHP به PDF یا تصویر صادر کنید، با کد نمونه. آن را به‌صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که چگونگی نمایش چندین اسلاید روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و دیگر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.

برای تنظیم ابعاد و جهت صفحه جزوه قبل از استخراج، به [Notes Page Size](/slides/fa/php-java/notes-size/) مراجعه کنید.

## **صدور حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته در یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در زیر یک مثال کد نشان می‌دهد که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```php
// یک ارائه را بارگذاری کنید.
$presentation = new Presentation("sample.pptx");

// گزینه‌های خروجی را تنظیم کنید.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید به‌صورت افقی در یک صفحه
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // شماره اسلایدها را چاپ کنید
$slidesLayoutOptions->setPrintFrameSlide(true);                      // یک قاب دور اسلایدها چاپ کنید
$slidesLayoutOptions->setPrintComments(false);                       // بدون نظر

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// ارائه را با چیدمان انتخاب‌شده به PDF صادر کنید.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="هشدار" %}}
به‌خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی قالب‌های خروجی نظیر PDF، HTML، TIFF و هنگام رندر به‌صورت تصویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویرهای کوچک اسلاید در هر صفحه در حالت Handout چیست؟**

Aspose.Slides از [presetها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند ۵ یا ۸ اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به‌صورت دقیق توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات استخراج برای قالب هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.