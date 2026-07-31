---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه با استفاده از جاوااسکریپت
linktitle: حالت جزوه
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
description: "ارائه‌ها را به جزوه‌ها تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides برای Node.js به PDF یا تصاویر صادر کنید، همراه با کد نمونه. به‌صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به انواع فرمت‌ها را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که پیکربندی کنید چند اسلاید بر روی یک صفحه نمایش داده شوند، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/), و [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) فعال کنید.

## **صادرات حالت جزوه**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار می‌گیرند و سایر پارامترهای نمایش را تنظیم می‌کند.

در زیر نمونه کدی آورده شده است که نشان می‌دهد چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```js
// بارگذاری یک ارائه.
let presentation = new asposeSlides.Presentation("sample.pptx");

// تنظیم گزینه‌های صادر کردن.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 اسلاید بر روی یک صفحه به صورت افقی
slidesLayoutOptions.setPrintSlideNumbers(true);                                // چاپ شماره اسلایدها
slidesLayoutOptions.setPrintFrameSlide(true);                                  // چاپ یک قاب دور اسلایدها
slidesLayoutOptions.setPrintComments(false);                                   // بدون نظرات

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// صادر کردن ارائه به PDF با چیدمان انتخابی.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
در نظر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی از قالب‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصاویر در دسترس است.
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصویر بندانگشتی اسلاید در هر صفحه در حالت Handout چیست؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) تا 9 تصویر بندانگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای بندانگشتی به‌صورت دقیق توسط شمارنده [HandoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. از متد `setShowHiddenSlides` در تنظیمات خروجی برای قالب هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/), یا [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) استفاده کنید.