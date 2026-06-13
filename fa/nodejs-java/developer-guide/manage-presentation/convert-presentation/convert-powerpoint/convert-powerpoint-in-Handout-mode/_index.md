---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه با استفاده از جاوااسکریپت
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "تبدیل ارائه‌ها به جزوه‌ها. تنظیم تعداد اسلایدها در هر صفحه، حفظ یادداشت‌ها، خروجی به PDF یا تصاویر با Aspose.Slides برای Node.js، به همراه کد نمونه. به‌صورت رایگان امتحان کنید."
---
## **معرفی**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌های چاپی در حالت Handout. این حالت به شما اجازه می‌دهد تنظیم کنید که چند اسلاید بر روی یک صفحه ظاهر شوند، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `setSlidesLayoutOptions` در کلاس‌های [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/)، و [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) فعال کنید.

## **صادرات در حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار گیرند و سایر پارامترهای نمایش را تنظیم می‌کند.

در زیر یک مثال کد آمده است که نشان می‌دهد چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```js
// یک ارائه را بارگیری کنید.
let presentation = new asposeSlides.Presentation("sample.pptx");

// تنظیم گزینه‌های خروجی.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
slidesLayoutOptions.setPrintSlideNumbers(true);                                // چاپ شماره اسلایدها
slidesLayoutOptions.setPrintFrameSlide(true);                                  // چاپ قاب دور اسلایدها
slidesLayoutOptions.setPrintComments(false);                                   // بدون نظرات

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// صادر کردن ارائه به PDF با چینش انتخابی.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
به خاطر داشته باشید که متد `setSlidesLayoutOptions` فقط برای برخی از فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است. 
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصویر بند انگشتی اسلایدها در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) تا ۹ تصویر بند انگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای بند انگشتی به‌صورت دقیق توسط شمارش [HandoutType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. از متد `setShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tiffoptions/) استفاده کنید.