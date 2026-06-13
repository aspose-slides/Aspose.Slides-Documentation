---
title: تبدیل ارائه‌های پاورپوینت در حالت جزوه با استفاده از C++
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در C++ تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides به PDF یا تصاویر خروجی بگیرید، همراه با کد نمونه. به‌صورت رایگان امتحان کنید."
---
## **معرفی**

Aspose.Slides امکان تبدیل ارائه‌ها به فرمت‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد تا نحوه نمایش چند اسلاید بر روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `set_SlidesLayoutOptions` در رابط‌های [IPdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ihtmloptions/)، و [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) فعال کنید.

## **صادرات حالت جزوه**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چند اسلاید بر روی یک صفحه قرار می‌گیرند و سایر پارامترهای نمایش را تنظیم می‌کند.

در زیر یک مثال کد نشان داده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نمایش می‌دهد.

```cpp
// یک ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// گزینه‌های خروجی را تنظیم کنید.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // چاپ شماره اسلایدها
slidesLayoutOptions->set_PrintFrameSlide(true);                      // چاپ یک قاب اطراف اسلایدها
slidesLayoutOptions->set_PrintComments(false);                       // بدون نظرات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// ارائه را با چیدمان انتخابی به PDF صادر کنید.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
به یاد داشته باشید که متد `set_SlidesLayoutOptions` فقط برای برخی از فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویر بندانگشتی اسلایدها در هر صفحه در حالت Handout چند عدد است؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) تا 9 تصویر بندانگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی مانند 5 یا 8 اسلاید در هر صفحه تعریف کنم؟**

خیر. تعداد و ترتیب تصویر بندانگشتی‌ها به‌صورت کامل توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) کنترل می‌شود؛ طرح‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟**

بله. از متد `set_ShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف استفاده کنید، مانند [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/).