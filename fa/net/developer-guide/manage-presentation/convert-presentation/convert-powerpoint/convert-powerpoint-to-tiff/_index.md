---
title: تبدیل ارائه‌های PowerPoint به TIFF در .NET
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/net/convert-powerpoint-to-tiff/
keywords:
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صادرات PPT به TIFF
- صادرات PPTX به TIFF
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه به سادگی ارائه‌های PowerPoint (PPT, PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای .NET تبدیل کنید. مثال‌های کد C#."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویری رستر بدون اتلاف و پرکاربرد است که به‌خاطر کیفیت استثنایی و حفظ دقیق گرافیک‌ها شناخته شده است. طراحان، عکاسان و ناشرین دسکتاپ اغلب برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود، از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما بیشترین دقت بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [ذخیره](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌توانید به‌سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید‑شده مطابق با اندازه اسلاید پیش‌فرض هستند.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // ارائه را به صورت TIFF ذخیره کنید.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **تبدیل یک ارائه به TIFF سیاه‑وسفید**

خاصیت [BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده‌شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑وسفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که خاصیت [CompressionType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف چگونگی نمایش یک شکل منفرد وقتی حالت نمایش سیاه‑وسفید فعال است، از [IShape.BlackWhiteMode](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/blackwhitemode/) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/slides/fa/net/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام «sample.pptx» داریم که اسلاید زیر را شامل می‌شود:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C# نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑وسفید تبدیل کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

نتیجه:

![TIFF سیاه‑وسفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویری با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از خاصیت‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) تنظیم کنید. به‌عنوان مثال، خاصیت [ImageSize](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) به شما اجازه می‌دهد اندازه تصویر خروجی را تعریف کنید.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // نوع فشرده‌سازی را تنظیم کنید.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - عدم فشرده‌سازی را مشخص می‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌توان آن را به صورت دستی تنظیم کرد.

    // DPI تصویر را تنظیم کنید.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // اندازه تصویر را تنظیم کنید.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // ارائه را به صورت TIFF با اندازه مشخص ذخیره کنید.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از خاصیت [PixelFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions) می‌توانید فرمت پیکسل مورد نظر خود را برای تصویر TIFF خروجی تعیین کنید.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویری TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
        Format1bppIndexed - ۱ بیت در هر پیکسل، ایندکسی.
        Format4bppIndexed - ۴ بیت در هر پیکسل، ایندکسی.
        Format8bppIndexed - ۸ بیت در هر پیکسل، ایندکسی.
        Format24bppRgb    - ۲۴ بیت در هر پیکسل، RGB.
        Format32bppArgb   - ۳۲ بیت در هر پیکسل، ARGB.
    */

    // ارائه را به صورت TIFF با اندازه تصویر مشخص ذخیره کنید.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
به مبدل رایگان Aspose برای تبدیل PowerPoint به پوستر نگاه کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم به‌جای تبدیل تمام ارائه PowerPoint به TIFF، فقط یک اسلاید منفرد را تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا هنگام تبدیل یک ارائه به TIFF محدودیتی برای تعداد اسلایدها وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. شما می‌توانید هر اندازه‌ای ارائه را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط snapshots ثابت از اسلایدها صادر می‌شوند.