---
title: "تبدیل ارائه‌های پاورپوینت در حالت جزوه با استفاده از JavaScript"
linktitle: "حالت جزوه"
type: docs
weight: 150
url: /fa/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌ها را به جزوه تبدیل کنید. اسلایدها را در هر صفحه تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides برای Node.js به PDF یا تصاویر خروجی دهید، همراه با کد نمونه. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که نحوه نمایش چندین اسلاید بر روی یک صفحه را تنظیم کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) فعال کنید.

برای تنظیم ابعاد و جهت‌گیری صفحه جزوه قبل از خروجی، به [Notes Page Size](/slides/fa/nodejs-java/notes-size/) مراجعه کنید.

## **صادر کردن حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرار گرفته در یک صفحه و سایر پارامترهای نمایش را تعیین می‌کند.

در زیر یک نمونه کد نشان داده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نمایش می‌دهد.

```js
const asposeSlides = require("aspose.slides.via.java");

// Load a presentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
slidesLayoutOptions.setPrintSlideNumbers(true);                                // چاپ شماره اسلایدها
slidesLayoutOptions.setPrintFrameSlide(true);                                  // چاپ قاب اطراف اسلایدها
slidesLayoutOptions.setPrintComments(false);                                   // بدون کامنت

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warning" %}}
در نظر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به‌صورت تصویر در دسترس است.
{{% /alert %}} 

## **پرسش‌های متداول**

**حداکثر تعداد تصاویر کوچک اسلاید در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) پشتیبانی می‌کند که تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی را فراهم می‌آورند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصاویر کوچک به‌صورت کامل توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. از متد `setShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) استفاده کنید.