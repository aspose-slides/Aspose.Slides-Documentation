---
title: دریافت بازخوانی‌های هشدار برای جایگزینی فونت در .NET
type: docs
weight: 120
url: /fa/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- بازخوانی هشدار
- جایگزینی فونت
- فرآیند رندر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه بازخوانی‌های هشدار برای جایگزینی فونت در Aspose.Slides برای .NET دریافت کنید و ارائه‌های PowerPoint و OpenDocument را به‌دقت نمایش دهید."
---
## **مقدمه**

Aspose.Slides برای .NET به شما امکان دریافت بازخوانی‌های هشدار برای جایگزینی فونت را می‌دهد زمانی که فونت مورد نیاز در حین رندر بر روی دستگاه موجود نیست. این بازخوانی‌ها به تشخیص مشکلات فونت‌های گمشده یا غیرقابل دسترس کمک می‌کنند.

## **فعال‌سازی بازخوانی‌های هشدار**

Aspose.Slides برای .NET APIهای ساده‌ای برای دریافت بازخوانی‌های هشدار هنگام رندر اسلایدهای ارائه فراهم می‌کند. برای پیکربندی بازخوانی‌های هشدار این مراحل را دنبال کنید:

1. یک کلاس بازخوانی سفارشی ایجاد کنید که اینترفیس [IWarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.warnings/iwarningcallback/) را پیاده‌سازی می‌کند تا هشدارها را مدیریت کند.
1. بازخوانی هشدار را با استفاده از کلاس‌های گزینه مانند [RenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/)، [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/)، و سایر موارد تنظیم کنید.
1. یک ارائه را بارگذاری کنید که از فونتی استفاده می‌کند که بر روی دستگاه هدف موجود نیست.
1. یک تصویر بندانگشتی اسلاید ایجاد کنید یا ارائه را برای مشاهده اثر صادر کنید.

**کلاس بازخوانی هشدار سفارشی:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// خروجی مثال:
//
// Font will be substituted from XYZ to {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**ایجاد تصویر بندانگشتی اسلاید:**

```c#
// یک بازخوانی هشدار تنظیم کنید تا هشدارهای مربوط به فونت را در حین رندر اسلاید پردازش کند.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// یک تصویر بندانگشتی برای هر اسلاید در ارائه تولید کنید.
foreach (var slide in presentation.Slides)
{
    // تصویر بندانگشتی اسلاید را با استفاده از گزینه‌های رندر مشخص شده دریافت کنید.
    using var image = slide.GetImage(options);
    // ...
}
```

**صادرات به فرمت PDF:**

```c#
// یک بازخوانی هشدار تنظیم کنید تا هشدارهای مربوط به فونت را در حین خروجی PDF پردازش کند.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// ارائه را به صورت PDF صادر کنید.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**صادرات به فرمت HTML:**

```c#
// یک بازخوانی هشدار تنظیم کنید تا هشدارهای مربوط به فونت را در حین خروجی HTML پردازش کند.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// ارائه را از مسیر فایل مشخص شده بارگذاری کنید.
using var presentation = new Presentation("sample.pptx");

// ارائه را به فرمت HTML صادر کنید.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```