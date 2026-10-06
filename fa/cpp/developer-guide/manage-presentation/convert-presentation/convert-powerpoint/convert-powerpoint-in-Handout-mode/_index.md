---
title: تبدیل ارائه‌های PowerPoint در حالت Handout با C++
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/cpp/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- جزوه
- PPT
- PPTX
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ارائه‌ها را به جزوه‌ها در C++ تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را نگه دارید، با Aspose.Slides به PDF یا تصاویر خروجی بگیرید، همراه با کد نمونه. به‌صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides امکان تبدیل ارائه‌ها به قالب‌های مختلف را فراهم می‌کند، از جمله ایجاد جزوه‌ها برای چاپ در حالت Handout. این حالت به شما اجازه می‌دهد تا تنظیم کنید چند اسلاید بر روی یک صفحه ظاهر شوند، که برای همایش‌ها، سمینارها و سایر رویدادها مفید است. می‌توانید این حالت را با فراخوانی متد `set_SlidesLayoutOptions` در اینترفیس‌های [IPdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ihtmloptions/) و [ITiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/itiffoptions/) فعال کنید.

برای تنظیم ابعاد و جهت صفحه جزوه قبل از خروجی، به [اندازه صفحه یادداشت‌ها](/slides/fa/cpp/notes-size/) مراجعه کنید.

## **صادرات حالت جزوه**

برای پیکربندی حالت Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید که تعداد اسلایدهای قرارگیری در یک صفحه و سایر پارامترهای نمایش را تعیین می‌نماید.

در زیر نمونه کدی آورده شده است که نشان می‌دهد چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک ارائه را بارگذاری کنید.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// گزینه‌های خروجی را تنظیم کنید.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // ۴ اسلاید در یک صفحه به صورت افقی
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // چاپ شماره اسلایدها
slidesLayoutOptions->set_PrintFrameSlide(true);                      // چاپ یک قاب دور اسلایدها
slidesLayoutOptions->set_PrintComments(false);                       // بدون نظرات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// ارائه را با چیدمان انتخاب شده به PDF صادر کنید.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
در نظر داشته باشید که متد `set_SlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به‌صورت تصاویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

### حداکثر تعداد تصاویر کوچک اسلاید در هر صفحه در حالت Handout چقدر است؟

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) حداکثر تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

### آیا می‌توانم یک شبکه سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟

خیر. تعداد و ترتیب تصاویر کوچک به‌طور دقیق توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

### آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟

بله. از متد `set_ShowHiddenSlides` در تنظیمات خروجی برای قالب هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) استفاده کنید.