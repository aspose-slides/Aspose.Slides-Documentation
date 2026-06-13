---
title: تبدیل ارائه‌های PowerPoint در حالت Handout در .NET
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/net/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- Handout
- PowerPoint
- ارائه
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "ارائه‌ها را به Handout در .NET تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را حفظ کنید، با Aspose.Slides به PDF یا تصویر صادر کنید، همراه با نمونه کد C#. به صورت رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌ها را به قالب‌های خروجی که حالت Handout را پشتیبانی می‌کنند، تبدیل کنید. در این حالت، چندین اسلاید بر روی یک صفحه چیده می‌شوند که برای چاپ مواد ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

حالت Handout از طریق ویژگی `SlidesLayoutOptions` پیکربندی می‌شود که در [IPdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ihtmloptions/)، و [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) در دسترس است. برای تعریف چیدمان Handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید.

## **صادر کردن حالت Handout**

برای صادر کردن یک ارائه در حالت Handout، ویژگی `SlidesLayoutOptions` را برای گزینه‌های خروجی هدف تنظیم کنید و یک نمونه از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handoutlayoutingoptions/) را اختصاص دهید که تعداد اسلایدها در هر صفحه و پارامترهای نمایش مرتبط را تعریف می‌کند.

در زیر یک مثال کد نشان می‌دهد که چگونه یک ارائه را به PDF در حالت Handout تبدیل کنید.

```c#
// بارگذاری یک ارائه.
using var presentation = new Presentation("sample.pptx");

// تنظیم گزینه‌های خروجی.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // ۴ اسلاید در یک صفحه به صورت افقی
        PrintSlideNumbers = true,                   // چاپ شماره اسلایدها
        PrintFrameSlide = true,                     // چاپ قاب دور اسلایدها
        PrintComments = false                       // بدون نظرات
    }
};

// صادر کردن ارائه به PDF با چیدمان انتخاب شده.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
به خاطر داشته باشید که ویژگی `SlidesLayoutOptions` فقط برای برخی قالب‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سؤالات متداول**

**حداکثر تعداد تصاویر بندانگشتی اسلاید در هر صفحه در حالت Handout چقدر است؟**

Aspose.Slides از [presets](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handouttype/) تا حداکثر ۹ تصویر بندانگشتی در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: ۱، ۲، ۳، ۴ (افقی/عمودی)، ۶ (افقی/عمودی) و ۹ (افقی/عمودی).

**آیا می‌توانم یک شبکه سفارشی، مانند ۵ یا ۸ اسلاید در هر صفحه، تعریف کنم؟**

خیر. تعداد و ترتیب تصاویر بندانگشتی به‌طور دقیق توسط شمارش‌گر [HandoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handouttype/) کنترل می‌شود؛ چینش‌های دلخواه پشتیبانی نمی‌شوند.

**آیا می‌توانم اسلایدهای پنهان را در خروجی Handout گنجانده کنم؟**

بله. گزینه `ShowHiddenSlides` را در تنظیمات خروجی برای قالب هدف، مانند [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) فعال کنید.