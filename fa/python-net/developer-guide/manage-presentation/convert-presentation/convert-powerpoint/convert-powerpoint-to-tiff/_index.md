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
description: "آموزش نحوه تبدیل آسان ارائه‌های PowerPoint (PPT, PPTX) و OpenDocument (ODP) به تصاویر TIFF با کیفیت بالا با استفاده از Aspose.Slides برای Python از طریق .NET. راهنمای گام به گام همراه با مثال‌های کد."
---
## **مقدمه**

TIFF (**Tagged Image File Format**) یک فرمت تصویر رستر بی‌ضایعی است که به دلیل کیفیت بالای خود و حفظ دقیق گرافیک‌ها به‌طور گسترده‌ای استفاده می‌شود. طراحان، عکاسان و ناشران دسکتاپ اغلب برای نگهداری لایه‌ها، دقت رنگ و تنظیمات اصلی تصویرهای خود، TIFF را انتخاب می‌کنند.

با استفاده از Aspose.Slides می‌توانید اسلایدهای PowerPoint (PPT, PPTX) و اسلایدهای OpenDocument (ODP) را به‌صورت مستقیم به تصاویر TIFF با کیفیت بالا تبدیل کنید و اطمینان حاصل کنید که ارائه‌های شما حداکثر وضوح بصری را حفظ می‌کند.

## **تبدیل یک ارائه به TIFF**

با استفاده از متد [save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/#methods) ارائه‌شده توسط کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌توانید به‌سرعت یک ارائهٔ کامل PowerPoint را به TIFF تبدیل کنید. تصاویر TIFF تولید شده مطابق با اندازهٔ پیش‌فرض اسلاید خواهند بود.

این کد Python نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به TIFF تبدیل کنیم:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
with slides.Presentation("presentation.pptx") as presentation:
    # ذخیرهٔ ارائه به صورت TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **تبدیل یک ارائه به TIFF سیاه‑و‑سفید**

خاصیت [bw_conversion_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) به شما اجازه می‌دهد الگوریتم مورد استفاده هنگام تبدیل اسلاید یا تصویر رنگی به TIFF سیاه‑و‑سفید را مشخص کنید. توجه داشته باشید که این تنظیم فقط زمانی اعمال می‌شود که خاصیت [compression_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/compression_type/) روی `CCITT4` یا `CCITT3` تنظیم شده باشد.

فرض کنید فایلی به نام "sample.pptx" با اسلاید زیر داریم:

![یک اسلاید ارائه](slide_black_and_white.png)

این کد Python نشان می‌دهد چگونه اسلاید رنگی را به TIFF سیاه‑و‑سفید تبدیل کنیم:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

نتیجه:

![TIFF سیاه‑و‑سفید](TIFF_black_and_white.png)

## **تبدیل یک ارائه به TIFF با اندازهٔ دلخواه**

اگر به یک تصویر TIFF با ابعاد خاص نیاز دارید، می‌توانید مقادیر دلخواه خود را با استفاده از ویژگی‌های موجود در [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) تنظیم کنید. به‌عنوان مثال، خاصیت [image_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/image_size/) به شما اجازه می‌دهد اندازهٔ تصویر خروجی را تعریف کنید.

این کد Python نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به تصاویر TIFF با اندازهٔ سفارشی تبدیل کنیم:

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

    # تنظیم اندازهٔ تصویر.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # ذخیرهٔ ارائه به صورت TIFF با اندازهٔ مشخص شده.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **تبدیل یک ارائه به TIFF با قالب پیکسل سفارشی**

با استفاده از خاصیت [pixel_format](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/pixel_format/) در کلاس [TiffOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/tiffoptions/) می‌توانید قالب پیکسل دلخواه خود را برای تصویر TIFF خروجی مشخص کنید.

این کد Python نشان می‌دهد چگونه یک ارائهٔ PowerPoint را به یک تصویر TIFF با قالب پیکسل سفارشی تبدیل کنیم:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه (PPT، PPTX، ODP و غیره) است.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # ذخیرهٔ ارائه به صورت TIFF با اندازهٔ تصویر مشخص شده.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}
نرم‌افزار رایگان تبدیل PowerPoint به پوستر Aspose را بررسی کنید: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **سؤالات متداول**

**آیا می‌توانم به‌جای تبدیل کل ارائه، اسلاید فردی را به TIFF تبدیل کنم؟**

بله. Aspose.Slides به شما اجازه می‌دهد اسلایدهای منفرد از ارائه‌های PowerPoint و OpenDocument را به‌صورت جداگانه به تصاویر TIFF تبدیل کنید.

**آیا محدودیتی برای تعداد اسلایدها هنگام تبدیل یک ارائه به TIFF وجود دارد؟**

خیر، Aspose.Slides هیچ محدودیتی برای تعداد اسلایدها اعمال نمی‌کند. می‌توانید ارائه‌های با هر اندازه‌ای را به فرمت TIFF تبدیل کنید.

**آیا انیمیشن‌ها و افکت‌های انتقال در اسلایدها هنگام تبدیل به TIFF حفظ می‌شوند؟**

خیر، TIFF یک فرمت تصویر ثابت است. بنابراین انیمیشن‌ها و افکت‌های انتقال حفظ نمی‌شوند؛ فقط عکس‌های ثابت از اسلایدها استخراج می‌شود.