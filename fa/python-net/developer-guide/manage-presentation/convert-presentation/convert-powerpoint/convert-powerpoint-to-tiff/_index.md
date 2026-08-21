---
title: تبدیل ارائه‌های PowerPoint به TIFF در Python
titlelink: PowerPoint به TIFF
type: docs
weight: 90
url: /fa/python-net/convert-powerpoint-to-tiff/
keywords:
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- PowerPoint به TIFF
- OpenDocument به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ODP به TIFF
- Python
- Aspose.Slides
description: "یاد بگیرید که چگونه به راحتی ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Python از طریق .NET تبدیل کنید. راهنمای گام‌به‌گام همراه با مثال‌های کد گنجانده شده."
---
## **معرفی**

TIFF (**فرمت فایل تصویر برچسب‌دار**) یک فرمت تصویر رستر با کیفیت بالا و بدون فقدان است که به دلیل حفظ جزئیات گرافیک شهرت دارد. طراحان، عکاسان و ناشران دسکتاپ اغلب برای نگهداری لایه‌ها، دقت رنگ و تنظیمات اصلی تصاویر از TIFF استفاده می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT، PPTX) و اسلایدهای OpenDocument (ODP) را به راحتی به تصاویر TIFF با کیفیت تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما بیشترین صحت بصری را حفظ می‌کنند.

## **تبدیل یک ارائه به TIFF**

با استفاده از روش [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/#methods) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌توانید به سرعت یک ارائه کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF حاصل مطابق با اندازه پیش‌فرض اسلاید هستند.

این کد Python نشان می‌دهد چگونه یک ارائه PowerPoint را به TIFF تبدیل کنید:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
with slides.Presentation("presentation.pptx") as presentation:
    # ذخیرهٔ ارائه به صورت TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **تبدیل یک ارائه به TIFF سیاه‑سفید**

ویژگی [bw_conversion_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) به شما اجازه می‌دهد الگوریتم استفاده‌شده هنگام تبدیل یک اسلاید یا تصویر رنگی به TIFF سیاه‑سفید را مشخص کنید. توجه داشته باشید این تنظیم فقط زمانی اعمال می‌شود که ویژگی [compression_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/compression_type/) بر روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

{{% alert color="info" title="نکته" %}}

[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) یک تنظیم سطح خروجی است که الگوریتم تبدیل پیکسل برای کل تصویر TIFF را انتخاب می‌کند. برای تعیین نحوه نمایش یک شکل جداگانه هنگام فعال بودن حالت نمایش سیاه‑سفید، از [Shape.black_white_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/black_white_mode/) استفاده کنید. برای مثال‌ها به [کنترل رندر سیاه‑سفید برای اشکال](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) مراجعه کنید.

{{% /alert %}}

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد Python نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑سفید تبدیل کنید:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

نتیجه:

![TIFF سیاه‑سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازه سفارشی**

اگر به تصویر TIFF با ابعاد خاصی نیاز دارید، می‌توانید مقادیر مورد نظر خود را با ویژگی‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) تنظیم کنید. برای مثال، ویژگی [image_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/image_size/) به شما امکان تعریف اندازه تصویر خروجی را می‌دهد.

این کد Python نشان می‌دهد چگونه یک ارائه PowerPoint را به تصاویر TIFF با اندازه سفارشی تبدیل کنید:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # تنظیم نوع فشرده‌سازی.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # تنظیم DPI تصویر.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # تنظیم اندازه تصویر.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص‌شده.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **تبدیل یک ارائه به TIFF با فرمت پیکسل تصویر سفارشی**

با استفاده از ویژگی [pixel_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/pixel_format/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) می‌توانید فرمت پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد Python نشان می‌دهد چگونه یک ارائه PowerPoint را به تصویر TIFF با فرمت پیکسل سفارشی تبدیل کنید:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat شامل مقادیر زیر است (همان‌طور که در مستندات ذکر شده):
        FORMAT_1BPP_INDEXED - 1 بیت برای هر پیکسل، ایندکس‌دار.
        FORMAT_4BPP_INDEXED - 4 بیت برای هر پیکسل، ایندکس‌دار.
        FORMAT_8BPP_INDEXED - 8 بیت برای هر پیکسل، ایندکس‌دار.
        FORMAT_24BPP_RGB    - 24 بیت برای هر پیکسل، RGB.
        FORMAT_32BPP_ARGB   - 32 بیت برای هر پیکسل، ARGB.
    """

    # ذخیرهٔ ارائه به صورت TIFF با فرمت پیکسلی مشخص‌شده.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="نکته" color="info" %}}

به مبدل **رایگان PowerPoint به پوستر** Aspose در [اینجا](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online) نگاهی بیندازید.

{{% /alert %}}

## **سوالات متداول**

**آیا می‌توانم تنها یک اسلاید را به‌جای کل ارائه PowerPoint به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما امکان می‌دهد اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به صورت مستقل به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید هر اندازه ارائه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال PowerPoint هنگام تبدیل اسلایدها به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ تنها تصویرهای ایستا از اسلایدها استخراج می‌شوند.