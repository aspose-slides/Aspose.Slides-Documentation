---
title: تبدیل اسلایدهای ارائه به تصاویر SVG در پایتون
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
- گزینه‌های خروجی SVG
- PowerPoint
- ارائه
- پایتون
- Aspose.Slides
description: "صادرات اسلایدهای PowerPoint به‌عنوان تصاویر SVG در پایتون و کنترل قلم‌ها، متن و تصاویر با Aspose.Slides."
---
## **مرور کلی**

SVG یک فرمت تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش‌گرهای اسلاید، گردش‌های دسترسی‌پذیری و پردازش پس از پردازش خودکار بسیار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد که نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده برای استفاده تعاملی باشد.

## **صادرات یک اسلاید به‌صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به‌صورت یک فایل SVG جداگانه صادر می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

نام فایل از [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) استفاده می‌کند به‌جای شاخص حلقه. همچنین می‌توانید یک شکل جداگانه را با [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) صادر کنید وقتی نمایش‌گر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) فریم متنی را در ناحیه رندر گنجانده و [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا خیر. هنگامی که متن باید بدون لیگچرها رندر شود، [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) را روی `True` تنظیم کنید.

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

## **کنترل متن و قلم‌ها**

هنگام صادرات اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به‌عنوان متن باقی بماند یا به گرافیک‌های برداری تبدیل شود و اینکه قلم‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم را در SVG صادر شده برقرار کنید.

### **بردارسازی تمام متن**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) را روی `True` تنظیم کنید تا تمام متن اسلاید به‌صورت گرافیک برداری نوشته شود. این وابستگی‌های قلم را حذف کرده و نتیجه بصری را در مرورگرها سازگارتر می‌کند، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نخواهد بود.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **انتخاب نحوهٔ پردازش قلم‌های خارجی**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. `ADD_LINKS_TO_FONT_FILES` را انتخاب کنید تا به فایل‌های قلم جداگانه ارجاع داده شود، `EMBED` برای گنجاندن داده‌های قلم در SVG، یا `VECTORIZE` برای رندر متن‌های استفاده‌کننده از قلم‌های خارجی به‌عنوان گرافیک. قبل از گنجاندن قلم‌ها، مجوزهای قلم را بررسی کنید.

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

## **کاهش اندازه تصویر جاسازی‌شده**

از [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) برای حذف نواحی برش‌خورده منبع، و [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازه فایل را به‌قیمت کاهش شفافیت تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهند.

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

## **کنترل وضوح رستر‌سازی متافایل**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) حد پایین وضوح رستر‌سازی متافایل‌ها را در زمان صادرات SVG تعیین می‌کند. از آن برای تعادل بین جزئیات و اندازه فایل وقتی یک تصویر EMF یا WMF رستر می‌شود، استفاده کنید. این مقدار یک DPI جهانی برای SVG تعریف نمی‌کند و باعث نمی‌شود هر شیء در اسلاید به تصویر رستری تبدیل شود.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را با سه وضوح رستر‌سازی مختلف از طریق [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) صادر می‌کند. تمام تنظیمات صادرات دیگر یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ این‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستر‌سازی متافایل DPI | ابعاد PNG جاسازی‌شده | اندازهٔ فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را با همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در 72 DPI پیکسل‌دار قابل مشاهده‌اند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که اندازهٔ فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً باعث بهبود هر جزئیات یا تغییر هر تصویر صادرشده نمی‌شود.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) کنترل کاهش وضوح تصویر را دارد و می‌تواند اثر تغییر وضوح رستر‌سازی متافایل را پنهان کند. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) کنترل کیفیت رمزگذاری JPEG را دارد، نه وضوح رستر‌سازی متافایل.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) به‌جای [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

وقتی تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) استفاده کنید. وقتی فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود، از [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خورده تصویر و انتخاب لینک به فایل‌های قلم هنگامی که محیط هدف می‌تواند آن‌ها را ارائه دهد، شروع کنید. نتیجه را تست کنید زیرا وضوح تصویر پایین‌تر، کیفیت JPEG کمتر و متن برداری‌شده هر کدام تضادهای کیفیت و اندازه متفاوتی دارند.