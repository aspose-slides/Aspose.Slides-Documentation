---
title: نمایش اسلایدهای ارائه به‌عنوان تصاویر SVG در پایتون
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های صادرات SVG
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌عنوان تصاویر SVG در پایتون صادر کنید و با Aspose.Slides بر فونت‌ها، متن و تصاویر کنترل داشته باشید."
---
## **بررسی کلی**

SVG یک فرمت تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلاید، جریان‌های کاری دسترسی‌پذیری و پردازش پس از تولید خودکار به‌خوبی کار می‌کند. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما اجازه می‌دهد نحوه نوشتن متن، فونت‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، در مرورگرهای مختلف قابل پیش‌بینی یا آماده برای استفاده تعاملی باشد.

## **صادرات اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید، یک اسلاید را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید از یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

نام فایل از [Slide.slide_number](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/slide_number/) استفاده می‌کند نه از شاخص حلقه. همچنین می‌توانید یک شکل منفرد را با [Shape.write_as_svg](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) صادر کنید زمانی که یک نماینده اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای قاب‌های متنی، [SVGOptions.use_frame_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/use_frame_size/) قاب متن را در ناحیه رندرینگ شامل می‌شود و [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) تعیین می‌کند آیا چرخش قاب اعمال شود یا نه. وقتی متن باید بدون لیگاتور رندر شود، [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) را به `True` تنظیم کنید.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **کنترل متن و فونت‌ها**

### **وکتوریزه کردن تمام متن**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/vectorize_text/) را به `True` تنظیم کنید تا تمام متن اسلاید به‌صورت گرافیک‌های برداری نوشته شود. این کار وابستگی‌های فونتی را حذف کرده و نتیجهٔ بصری را در مرورگرهای مختلف یکپارچه‌تر می‌کند، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نیست.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **انتخاب نحوهٔ پردازش فونت‌های خارجی**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) برای فونت‌هایی که به‌صورت خارجی بارگذاری می‌شوند، از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده می‌کند. `ADD_LINKS_TO_FONT_FILES` را برای ارجاع به فایل‌های فونت جداگانه انتخاب کنید، `EMBED` برای گنجاندن داده‌های فونت در SVG، یا `VECTORIZE` برای رندر کردن فقط متنی که از فونت‌های خارجی استفاده می‌کند به‌صورت گرافیک. قبل از گنجاندن فونت‌ها، مجوزهای فونتی را بررسی کنید.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **کاهش اندازهٔ تصویر جاسازی‌شده**

از [SVGOptions.pictures_compression](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/pictures_compression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) برای حذف نواحی بریده‌شدهٔ منبع، و [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/jpeg_quality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازهٔ فایل را با هزینه‌ای در انسجام تصویر یا داده‌های تصویری نگهداری‌شده کاهش می‌دهند.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **سؤالات متداول**

**کی باید از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/vectorize_text/) به‌جای [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgoptions/vectorize_text/) استفاده کنید زمانی که تمام متن باید مستقل از فونت‌ها باشد. از [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنید زمانی که فقط متنی که از فونت‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین روش برای کوچک کردن یک SVG چیست؟**

ابتدا با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی بریده‌شدهٔ تصویر، و انتخاب فایل‌های فونت پیوندی (linked) زمانی که محیط هدف می‌تواند آنها را سرو کند، شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کیفیت کمتر JPEG و متن وکتوریزه‌شده هرکدام تعادل متفاوتی بین کیفیت و اندازه دارند.