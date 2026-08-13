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
description: "یاد بگیرید چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای .NET تبدیل کنید. مثال‌های کد C#."
---
## **معرفی**

TIFF (**فرمت فایل تصویر برچسب‌خورده**) یک فرمت تصویر رستر بدون افت کیفیت است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها به طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشرین دسکتاپ معمولاً برای حفظ لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر خود از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به سادگی به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کند.

## **تبدیل ارائه به TIFF**

با استفاده از متد [ذخیره](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) که در کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) فراهم شده است، می‌توانید به سرعت تمام ارائه PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // ارائه را به فرمت TIFF ذخیره می‌کند.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **تبدیل ارائه به TIFF سیاه‑سفید**

ویژگی [BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم مورد استفاده برای تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید این تنظیم فقط زمانی اعمال می‌شود که ویژگی [CompressionType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام «sample.pptx» با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C# نشان می‌دهد که چگونه اسلاید رنگی را به TIFF سیاه‑سفید تبدیل کنید:

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

## **تبدیل ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با ویژگی‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) تنظیم کنید. به عنوان مثال، ویژگی [ImageSize](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) به شما امکان تعریف اندازه تصویر خروجی را می‌دهد.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // نوع فشرده‌سازی را تنظیم می‌کند.
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

    // عمق بستگی به نوع فشرده‌سازی دارد و نمی‌تواند به‌صورت دستی تنظیم شود.

    // DPI تصویر را تنظیم می‌کند.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // اندازه تصویر را تنظیم می‌کند.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // ارائه را به فرمت TIFF با اندازه مشخص ذخیره می‌کند.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تبدیل ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از ویژگی [PixelFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که فایل ارائه (PPT، PPTX، ODP و غیره) را نمایندگی می‌کند.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده است):
        Format1bppIndexed - 1 بیت در هر پیکسل، نمایه‌دار.
        Format4bppIndexed - 4 بیت در هر پیکسل، نمایه‌دار.
        Format8bppIndexed - 8 بیت در هر پیکسل، نمایه‌دار.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    // ارائه را به فرمت TIFF با اندازه تصویر تعیین شده ذخیره می‌کند.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="نکته" color="info" %}}

نرم‌افزار رایگان تبدیل PowerPoint به پوستر Aspose را امتحان کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **سوالات متداول**

### آیا می‌توانم یک اسلاید منفرد را به جای کل ارائه PowerPoint به TIFF تبدیل کنم؟

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به صورت مستقل به تصاویر TIFF تبدیل کنید.

### آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل ارائه به TIFF وجود دارد؟

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه‌ای از ارائه را به فرمت TIFF تبدیل کنید.

### آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط تصاویر ثابت از اسلایدها صادر می‌شوند.