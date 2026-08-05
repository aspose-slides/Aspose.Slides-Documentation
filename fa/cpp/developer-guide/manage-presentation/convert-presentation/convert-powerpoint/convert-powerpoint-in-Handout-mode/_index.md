---
title: تبدیل ارائه‌های PowerPoint در حالت جزوه با استفاده از C++
linktitle: حالت جزوه
type: docs
weight: 150
url: /fa/cpp/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت جزوه
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در C++ تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides به PDF یا تصاویر خروجی بگیرید، همراه با نمونه کد. به‌صورت رایگان امتحان کنید."
---
## **معرفی**

Aspose.Slides امکان تبدیل ارائه‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوات برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد که نحوه نمایش چندین اسلاید بر روی یک صفحه را پیکربندی کنید، که برای کنفرانس‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با تنظیم متد `set_SlidesLayoutOptions` در اینترفیس‌های [IPdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ihtmloptions/) و [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) فعال کنید.

## **صادرات حالت Handout**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعیین می‌کند چه تعداد اسلاید بر روی یک صفحه قرار می‌گیرد و سایر پارامترهای نمایش را تنظیم می‌کند.

```cpp
// یک ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید روی یک صفحه به‌صورت افقی
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // چاپ شماره اسلایدها
slidesLayoutOptions->set_PrintFrameSlide(true);                      // چاپ یک قاب دور اسلایدها
slidesLayoutOptions->set_PrintComments(false);                       // بدون نظرات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
به یاد داشته باشید که متد `set_SlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF، و هنگام رندرد کردن به‌صورت تصویر موجود است.
{{% /alert %}} 

## **سوالات متداول**

**حداکثر تعداد تصویرهای کوچک اسلاید در هر صفحه در حالت Handout چیست؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک جدول سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصویرهای کوچک به‌صورت صریح توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای مخفی را در خروجی Handout وارد کنم؟**

بله. از متد `set_ShowHiddenSlides` در تنظیمات خروجی برای فرمت هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) استفاده کنید.