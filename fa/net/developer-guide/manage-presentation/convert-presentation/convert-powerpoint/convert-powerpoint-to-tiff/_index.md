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
- خروجی PPT به TIFF
- خروجی PPTX به TIFF
- .NET
- C#
- Aspose.Slides
description: "چگونگی تبدیل آسان ارائه‌های PowerPoint (PPT, PPTX) به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای .NET. مثال‌های کد C#."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بدون اتلاف است که به دلیل کیفیت استثنایی و حفظ جزئیات گرافیک‌ها به‌ طور گسترده استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب TIFF را برای نگه‌داشتن لایه‌ها، دقت رنگ و تنظیمات اصلی در تصاویر خود انتخاب می‌کنند.

با استفاده از Aspose.Slides، می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) خود را به‌ راحتی به تصاویر TIFF با کیفیت بالا تبدیل کنید، به‌ طوری که ارائه‌های شما بیشترین وفاداری بصری را حفظ کنند. 

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/)، می‌توانید به‌سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```cs
// یک شی از کلاس Presentation ایجاد کنید که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // ارائه را به‌صورت TIFF ذخیره کنید.
}
```

## **تبدیل یک ارائه به TIFF سیاه و سفید**

ویژگی [BwConversionMode](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/bwconversionmode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) به شما امکان می‌دهد الگوریتم استفاده‌شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه و سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که ویژگی [CompressionType](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/compressiontype/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام "sample.pptx" داریم که اسلاید زیر را شامل می‌شود:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد C# نشان می‌دهد که چگونه اسلاید رنگی را به TIFF سیاه و سفید تبدیل کنید:

```cs
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

![TIFF سیاه و سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از ویژگی‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/) تنظیم کنید. به عنوان مثال، ویژگی [ImageSize](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/imagesize/) به شما اجازه می‌دهد اندازه تصویر نهایی را تعریف کنید.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```cs
// یک شی از کلاس Presentation ایجاد کنید که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // نوع فشرده‌سازی را تنظیم کنید.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    انواع فشرده‌سازی:
        Default - طرح فشرده‌سازی پیش‌فرض (LZW) را مشخص می‌کند.
        None - هیچ فشرده‌سازی‌ای را مشخص نمی‌کند.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // عمق بسته به نوع فشرده‌سازی است و نمی‌توان به‌صورت دستی تنظیم شود.

    // DPI تصویر را تنظیم کنید.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // اندازه تصویر را تنظیم کنید.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // ارائه را به‌صورت TIFF با اندازه مشخص‌شده ذخیره کنید.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از ویژگی [PixelFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/pixelformat/) از کلاس [TiffOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد C# نشان می‌دهد که چگونه یک ارائه PowerPoint را به تصویری TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```cs
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر فایل ارائه (PPT، PPTX، ODP و غیره) است.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات آمده):
        Format1bppIndexed - 1 بیت در هر پیکسل، شاخص‌دار.
        Format4bppIndexed - 4 بیت در هر پیکسل، شاخص‌دار.
        Format8bppIndexed - 8 بیت در هر پیکسل، شاخص‌دار.
        Format24bppRgb    - 24 بیت در هر پیکسل، RGB.
        Format32bppArgb   - 32 بیت در هر پیکسل، ARGB.
    */

    // ارائه را به‌صورت TIFF با اندازه تصویر مشخص‌شده ذخیره کنید.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
ابزار تبدیل رایگان PowerPoint به پوستر Aspose را بررسی کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه PowerPoint، یک اسلاید جداگانه را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به‌ طور مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین، انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ تنها تصویرهای ثابت از اسلایدها صادر می‌شوند.