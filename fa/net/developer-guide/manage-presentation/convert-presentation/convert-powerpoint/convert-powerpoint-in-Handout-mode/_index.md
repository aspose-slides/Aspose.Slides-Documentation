---
title: تبدیل ارائه‌های PowerPoint به حالت Handout در .NET
linktitle: حالت Handout
type: docs
weight: 150
url: /fa/net/convert-powerpoint-in-handout-mode/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- حالت Handout
- تحویل
- PowerPoint
- ارائه
- PPT
- PPTX
- .NET
- C#
- Aspose.Slides
description: "ارائه‌ها را به Handout در .NET تبدیل کنید. تعداد اسلایدها در هر صفحه را تنظیم کنید، یادداشت‌ها را حفظ کنید، با Aspose.Slides به PDF یا تصاویر خروجی دهید، به همراه نمونه کد C#. رایگان امتحان کنید."
---
## **مقدمه**

Aspose.Slides به شما اجازه می‌دهد ارائه‌ها را به فرمت‌های خروجی که حالت Handout را پشتیبانی می‌کنند، تبدیل کنید. در این حالت، چندین اسلاید در یک صفحه چین‌گذاری می‌شوند که برای چاپ مواد ارائه در کنفرانس‌ها، سمینارها و رویدادهای مشابه مفید است.

حالت Handout از طریق ویژگی `SlidesLayoutOptions` تنظیم می‌شود که در [IPdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ihtmloptions/)، و [ITiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/itiffoptions/) موجود است. برای تعریف چیدمان handout، از شیء [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handoutlayoutingoptions/) استفاده کنید.

برای تنظیم ابعاد صفحه handout و جهت آن قبل از خروجی، به [Notes Page Size](/slides/fa/net/notes-size/) مراجعه کنید.

## **صادرات حالت Handout**

برای صادر کردن یک ارائه در حالت Handout، ویژگی `SlidesLayoutOptions` را برای گزینه‌های خروجی هدف تنظیم کرده و یک نمونه [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handoutlayoutingoptions/) که تعداد اسلایدها در هر صفحه و پارامترهای نمایش مربوطه را تعریف می‌کند، اختصاص دهید.

در زیر یک مثال کد نشان داده شده است که نحوه تبدیل یک ارائه به PDF در حالت Handout را نشان می‌دهد.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک ارائه را بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// گزینه‌های خروجی را تنظیم کنید.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new HandoutLayoutingOptions
    {
        Handout = HandoutType.Handouts4Horizontal,  // ۴ اسلاید در یک صفحه به صورت افقی
        PrintSlideNumbers = true,                   // شماره اسلایدها را چاپ کنید
        PrintFrameSlide = true,                     // یک چهارچوب اطراف اسلایدها چاپ کنید
        PrintComments = false                       // بدون نظرات
    }
};

// ارائه را با طرح انتخابی به PDF خروجی دهید.
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="warning" %}} 
به یاد داشته باشید که ویژگی `SlidesLayoutOptions` فقط برای برخی فرمت‌های خروجی مانند PDF، HTML، TIFF و هنگام رندر به عنوان تصویر در دسترس است.
{{% /alert %}} 

## **سوالات متداول**

### حداکثر تعداد تصاویر کوچک اسلاید در هر صفحه در حالت Handout چقدر است؟

Aspose.Slides از [پیش‌تنظیم‌ها](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handouttype/) تا ۹ تصویر کوچک در هر صفحه با ترتیب افقی یا عمودی پشتیبانی می‌کند: 1، 2، 3، 4 (افقی/عمودی)، 6 (افقی/عمودی) و 9 (افقی/عمودی).

### آیا می‌توانم یک شبکه سفارشی، مانند 5 یا 8 اسلاید در هر صفحه، تعریف کنم؟

خیر. تعداد و ترتیب تصاویر کوچک به طور کامل توسط شمارشگر [HandoutType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handouttype/) کنترل می‌شود؛ چیدمان‌های دلخواه پشتیبانی نمی‌شوند.

### آیا می‌توانم اسلایدهای مخفی را در خروجی Handout گنجانده کنم؟

بله. گزینه `ShowHiddenSlides` را در تنظیمات خروجی برای فرمت هدف فعال کنید، مانند [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/)، یا [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/).