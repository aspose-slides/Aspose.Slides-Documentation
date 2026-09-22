---
title: ذخیره ارائه‌ها در .NET
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/net/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- .NET
- C#
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در C# با Aspose.Slides برای .NET به فایل‌ها یا جریان‌ها ذخیره کنید و خروجی PPTX و گزارش پیشرفت را پیکربندی کنید."
---
## **بررسی کلی**

پس از ایجاد یک ارائه یا [یک ارائه موجود را باز کنید](/slides/fa/net/open-presentation/)، از روش [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای .NET می‌تواند یک ارائه را به صورت فایل یا جریان در قالب‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها ذخیره کند. بخش‌های زیر عملیات ذخیره‌سازی استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در یک فایل، مسیر خروجی و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) را به روش [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) پاس دهید. مقدار فرمت تعیین می‌کند که Aspose.Slides چه نوع فایلی ایجاد می‌کند.

مثال زیر یک ارائه ایجاد کرده و آن را به‌عنوان فایل PPTX ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation;

// در اینجا محتویات ارائه را اضافه یا تغییر دهید.
presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **ذخیره ارائه‌ها در فرمت اصلی آن‌ها**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های تازه ایجاد شده، و تمایز بین فرمت‌های منبع و خروجی، به مطلب [Determine the Original Presentation Format](/slides/fa/net/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه پردازش دسته‌ای، ممکن است فرمت ورودی از پیش شناخته شده نباشد. پس از بارگذاری یک فایل، فرمت اصلی آن را از ویژگی [IPresentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/sourceformat/) بخوانید. مقدار حاصل [SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/sourceformat/) را به [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/tosaveformat/) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) به‌دست آید و سپس از [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) برای نوشتن ارائه تغییر یافته استفاده کنید.

مثال کامل زیر هر فایل را در یک پوشه ورودی پردازش می‌کند، عنوان آن را به‌روزرسانی می‌کند و با همان فرمایی که بارگذاری شده است در پوشه خروجی ذخیره می‌نماید:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/tosaveformat/) فرمت‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و PowerPoint XML را به فرمت‌های ذخیره‌سازی مربوطه‌شان نگاشت می‌کند. این متد صرفاً فرمت‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر هدفمند نشده است. پاس دادن یک مقدار [SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/sourceformat/) پشتیبانی‌نشده یا نامعتبر منجر به ایجاد یک [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) می‌شود.

فایل‌های Legacy PPT، PPS و POT از همان کانتینر باینری استفاده می‌کنند. هنگامی که چنین ارائه‌ای از یک جریان بدون پسوند فایل بارگذاری می‌شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر حفظ این زیرنوع‌های قدیمی لازم باشد، نام فایل یا داده‌های متادیتای اصلی را به‌صورت جداگانه نگه‌دارید و هنگام انتخاب نام و فرمت خروجی از آن استفاده کنید.

## **ذخیره ارائه‌ها در جریان‌ها**

برای نوشتن یک ارائه بدون وابستگی به مسیر نهایی فایل، یک [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) را به روش [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) پاس دهید. این رویکرد زمانی مفید است که خروجی باید از یک سرویس وب برگردانده شود، در پایگاه داده ذخیره گردد یا در حافظه پردازش شود.

مثال زیر یک ارائه جدید را در یک جریان فایل ذخیره می‌کند:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

می‌توانید نمایی که PowerPoint هنگام باز کردن اولین بار ارائه ذخیره‌شده نشان می‌دهد، مشخص کنید. قبل از ذخیره، ویژگی [ViewProperties.LastView](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/lastview/) را به مقدار یک [ViewType](https://reference.aspose.com/slides/fa/net/aspose.slides/viewtype/) تنظیم کنید.

مثال زیر نمای Slide Master را به‌عنوان نمای اولیه پیکربندی می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

برای ایجاد یک فایل PPTX که با پروفایل Strict استاندارد Office Open XML سازگار باشد، یک نمونه از [PptxOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/) ایجاد کنید و ویژگی [Conformance](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/conformance/) آن را به `Conformance.Iso29500_2008_Strict` تنظیم کنید. سپس گزینه‌ها را به روش [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) پاس دهید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک آرشیو ZIP استاندارد اندازه فشرده و غیر فشرده هر ورودی، اندازه کل آرشیو و تعداد ورودی‌ها را محدود می‌کند. از آنجا که یک فایل PPTX یک آرشیو ZIP است، یک ارائه بسیار بزرگ می‌تواند از این محدودیت‌ها فراتر رود. افزونه‌های ZIP64 این محدودیت‌ها را افزایش می‌دهند.

از ویژگی [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/zip64mode/) برای کنترل این‌که آیا Aspose.Slides افزونه‌های ZIP64 را می‌نویسد یا نه استفاده کنید:

- `IfNecessary` فقط زمانی که ارائه از محدودیت‌های استاندارد ZIP فراتر برود، ZIP64 را به کار می‌برد. این حالت پیش‌فرض است.
- `Never` افزونه‌های ZIP64 را غیرفعال می‌کند.
- `Always` همیشه افزونه‌های ZIP64 را می‌نویسد.

مثال زیر همیشه برای ارائه خروجی افزونه‌های ZIP64 را فعال می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
اگر `Zip64Mode` روی `Never` تنظیم شود و ارائه نتواند در محدودیت‌های استاندارد ZIP جای بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) پرتاب می‌کند.
{{% /alert %}}

## **ذخیره ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

برای خروجی PPTX می‌توانید با تنظیم ویژگی [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/compressionlevel/) سرعت ذخیره‌سازی را در مقابل اندازه فایل تعادل کنید. شمارۀ [CompressionLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.export/compressionlevel/) این مقادیر را فراهم می‌آورد:

- `None` داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- `Level1` سریع‌ترین فشرده‌سازی را ارائه می‌دهد اما بزرگ‌ترین خروجی فشرده را تولید می‌کند.
- `Level2` تا `Level5` به‌تدریج خروجی کوچکتر را نسبت به سرعت ذخیره‌سازی ترجیح می‌دهند.
- `Level6` تعادل بین سرعت ذخیره‌سازی و اندازه فایل را برقرار می‌کند. این سطح پیش‌فرض است.
- `Level7` و `Level8` بیشتر به خروجی کوچک‌تر نسبت به سرعت ذخیره‌سازی تمایل دارند.
- `Level9` قوی‌ترین فشرده‌سازی را ارائه می‌دهد و بیشترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

زمانی که یک ارائه به‌عنوان PPTX ذخیره می‌شود، ویژگی [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pptxoptions/refreshthumbnail/) کنترل‌کننده تصویر بندانگشتی سند است:

- `true` در طول عملیات ذخیره تصویر بندانگشتی را دوباره تولید می‌کند. این مقدار پیش‌فرض است.
- `false` تصویر بندانگشتی موجود را حفظ می‌کند. اگر ارائه هیچ تصویر بندانگشتی نداشته باشد، Aspose.Slides تصویر جدیدی تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر بندانگشتی ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
غیرفعال کردن به‌روزرسانی تصویر بندانگشتی می‌تواند زمان مورد نیاز برای ذخیره یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **گزارش به‌روزرسانی‌های پیشرفت به‌صورت درصدی**

برای نظارت بر عملیات ذخیره، اینترفیس [IProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/) را پیاده‌سازی کنید و پیاده‌سازی را به ویژگی [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.export/isaveoptions/progresscallback/) اختصاص دهید. سپس Aspose.Slides متد [IProgressCallback.Reporting](https://reference.aspose.com/slides/fa/net/aspose.slides/iprogresscallback/reporting/) را با مقادیر پیشرفت در طول فرآیند خروجی فراخوانی می‌کند.

مثال زیر پیشرفت خروجی PDF را در کنسول گزارش می‌دهد:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose یک ابزار رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) فراهم می‌کند که با استفاده از API Aspose.Slides ساخته شده است. این ابزار اسلایدهای انتخاب‌شده را از یک ارائه به‌صورت فایل‌های جداگانه PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **سوالات متداول**

**آیا Aspose.Slides از ذخیره‌سازی افزایشی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و تنها قسمت‌های تغییر یافته را به‌روز نمی‌کند.

**آیا چندین رشته می‌توانند همزمان همان نمونه Presentation را ذخیره کنند؟**

خیر. یک نمونه [Presentation](/slides/fa/net/multithreading/) **thread‑safe** نیست. هر نمونه باید فقط از یک رشته در یک زمان دست‌رسی و ذخیره شود.

**وقتی یک ارائه را ذخیره می‌کنم، چه اتفاقی برای لینک‌های فراگیر و فایل‌های لینک‌داده‌شده به‌صورت خارجی می‌افتد؟**

[Hyperlinks](/slides/fa/net/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌داده‌شده به‌صورت خارجی را کپی نمی‌کند، بنابراین ارائه ذخیره‌شده باید همچنان بتواند به مکان‌های آن‌ها دسترسی داشته باشد.

**آیا می‌توانم متادیتای سند مانند نویسنده، عنوان، شرکت و تاریخ إنشاء را ذخیره کنم؟**

بله. قبل از ذخیره، ویژگی‌های مناسب [document properties](/slides/fa/net/presentation-properties/) را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.