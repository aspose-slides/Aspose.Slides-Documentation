---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه با استفاده از PHP
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- پاورپوینت
- ارائه
- PHP
- Aspose.Slides
description: "تبدیل ارائه‌ها به جزوه‌ها در PHP. تنظیم اسلایدها در هر صفحه، حفظ یادداشت‌ها، خروجی به PDF یا تصویر با Aspose.Slides برای PHP، با کد نمونه. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد چگونگی نمایش چند اسلاید بر روی یک صفحه را تنظیم کنید، که برای کنفرانس‌ها، سمینارها و رویدادهای دیگر مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته روی یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در ادامه یک مثال کد نشان داده می‌شود که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```php
// بارگذاری یک ارائه.
$presentation = new Presentation("sample.pptx");

// تنظیم گزینه‌های خروجی.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // چاپ شماره اسلایدها
$slidesLayoutOptions->setPrintFrameSlide(true);                      // چاپ یک قاب دور اسلایدها
$slidesLayoutOptions->setPrintComments(false);                       // بدون نظرات

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// خروجی گرفتن ارائه به PDF با چیدمان انتخاب شده.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
به خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی، مانند PDF، HTML، TIFF، و هنگام رندر به‌عنوان تصویر، در دسترس است.
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصویر بندانگشتی اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides پرفیک‌های [presets](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) تا 9 تصویر بندانگشتی در هر صفحه را با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند 5 یا 8 اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصاویر بندانگشتی به‌طور کامل توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.