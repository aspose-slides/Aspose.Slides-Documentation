---
title: تبدیل ارائه‌های PowerPoint در حالت Handout با استفاده از PHP
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/php-java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "ارائه‌ها را در PHP به جزوه‌ها تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides برای PHP به PDF یا تصاویر صادر کنید، به همراه کد نمونه. به‌صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که نحوه نمایش چند اسلاید بر روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.

## **صادرات حالت جزوه**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته بر روی یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در زیر نمونه کدی آورده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نشان می‌دهد.

```php
// یک ارائه را بارگذاری کنید.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // چاپ شماره اسلایدها
$slidesLayoutOptions->setPrintFrameSlide(true);                      // چاپ یک قاب دور اسلایدها
$slidesLayoutOptions->setPrintComments(false);                       // بدون نظرات

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
به یاد داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی قالب‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر موجود است.
{{% /alert %}} 

## **پرسش‌های متداول**

**حداکثر تعداد پیش‌نمایش اسلایدها در هر صفحه در حالت Handout چیست؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) تا 9 پیش‌نمایش در هر صفحه با چینش افقی یا عمودی پشتیبانی می‌کند: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) و 9 (horizontal/vertical).

**آیا می‌توانم یک شبکهٔ سفارشی، مانند 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب پیش‌نمایش‌ها به‌صورت کامل توسط کلاس [HandoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/handouttype/) کنترل می‌شود؛ چینش‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی جزوه وارد کنم؟**

بله. اسلایدهای مخفی را با استفاده از متد `setShowHiddenSlides` در تنظیمات خروجی برای قالب هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tiffoptions/) فعال کنید.