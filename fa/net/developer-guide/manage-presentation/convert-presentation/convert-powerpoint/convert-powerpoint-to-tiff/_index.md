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
description: "آموزش تبدیل آسان ارائه‌های PowerPoint (PPT، PPTX) به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای .NET. مثال‌های کد C#."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بی‌لفظ و پرکاربرد است که به دلیل کیفیت فوق‌العاده و حفظ جزئیات گرافیک شناخته می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب TIFF را برای نگه‌داری لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر انتخاب می‌کنند.

با استفاده از Aspose.Slides، می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) خود را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر صحت بصری را حفظ می‌کنند. 

## **تبدیل ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌توانید به سرعت یک ارائهٔ کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده با اندازه پیش‌فرض اسلاید مطابقت دارند.

این کد C# نحوهٔ تبدیل یک ارائه PowerPoint به TIFF را نشان می‌دهد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // ارائه را به صورت TIFF ذخیره کنید.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **تبدیل ارائه به TIFF سیاه‑سفید**

ویژگی [BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که ویژگی [CompressionType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="نکته" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعریف نحوهٔ نمایش یک شکل جداگانه هنگام فعال بودن حالت نمایش سیاه‑سفید، از [IShape.BlackWhiteMode](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/blackwhitemode/) استفاده کنید. برای مثال‌ها به [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.
{{% /alert %}}

فرض کنید فایلی به نام «sample.pptx» با اسلاید زیر داشته باشیم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C# نحوهٔ تبدیل اسلاید رنگی به TIFF سیاه‑سفید را نشان می‌دهد:

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

![TIFF سیاه‑سفید](TIFF_black_and_white.png)

## **تبدیل ارائه به TIFF با اندازهٔ سفارشی**

اگر به تصویری TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از ویژگی‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) تنظیم کنید. به عنوان مثال، ویژگی [ImageSize](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) به شما امکان می‌دهد اندازهٔ تصویر تولید شده را تعریف کنید.

این کد C# نحوهٔ تبدیل یک ارائه PowerPoint به تصاویر TIFF با اندازهٔ سفارشی را نشان می‌دهد:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // تنظیم نوع فشرده‌سازی.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض را تعیین می‌کند (LZW).
        None - بدون فشرده‌سازی است.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق وابسته به نوع فشرده‌سازی است و نمی‌تواند به‌صورت دستی تنظیم شود.

    // تنظیم DPI تصویر.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // تنظیم اندازه تصویر.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // ذخیره ارائه به صورت TIFF با اندازهٔ مشخص شده.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تبدیل ارائه به TIFF با قالب پیکسل تصویر سفارشی**

با استفاده از ویژگی [PixelFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF تولید شده مشخص کنید.

این کد C# نحوهٔ تبدیل یک ارائه PowerPoint به تصویر TIFF با قالب پیکسل سفارشی را نشان می‌دهد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat شامل مقادیر زیر است (طبق مستندات):
        Format1bppIndexed - 1 بیت در هر پیکسل، شاخصی.
        Format4bppIndexed - 4 بیت در هر پیکسل، شاخصی.
        Format8bppIndexed - 8 بیت در هر پیکسل، شاخصی.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    // ذخیره ارائه به صورت TIFF با اندازهٔ تصویر مشخص شده.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="نکته" color="info" %}}
به مبدل رایگان PowerPoint به پوستر Aspose نگاه کنید: [مبدل رایگان PowerPoint به پوستر](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **پرسش‌های متداول**

**آیا می‌توانم یک اسلاید جداگانه را به‌جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانهٔ ارائه‌های PowerPoint و OpenDocument را به‌صورت مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شود.