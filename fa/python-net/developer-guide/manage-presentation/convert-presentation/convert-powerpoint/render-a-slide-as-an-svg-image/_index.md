---
title: رندر اسلایدهای ارائه به‌صورت تصاویر SVG در پایتون
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
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در پایتون صادر کنید و قلم‌ها، متن و تصاویر را با Aspose.Slides کنترل کنید."
---
## **مرور کلی**

SVG یک فرمت تصویری مبتنی بر XML مقیاس‌پذیر است که برای انتشار وب، نمایش‌کنندگان اسلاید، جریان‌های کاری دسترس‌پذیری و پردازش خودکار پس از انتشار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید کم حجم، پیش‌بینی‌پذیر در مرورگرها باشد یا آماده استفاده تعاملی باشد.

## **صادر کردن اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ایجاد کنید، یک اسلاید را انتخاب کنید و آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

نام فایل از [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) به‌جای اندیس حلقه استفاده می‌کند. همچنین می‌توانید یک شکل منفرد را با [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) صادر کنید وقتی نمایش‌دهنده اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) تعیین می‌کند آیا چرخش فریم اعمال شود یا نه. وقتی متن باید بدون لیگچرها رندر شود، [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) را به `True` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرپیکان‌ها**

SVG 1.1 تنظیمی برای فاصله داخلی نشانگر ندارد تا مشخص کند خط تا کجا باید زیر سرپیکان متوقف شود. به‌صورت پیش‌فرض، Aspose.Slides خط صادر شده را کوتاه می‌کند تا پرانتن آن از نشانگر بیرون نیاید. برای رسم خط تا نقطه انتهایی اصلی آن، [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) را به `True` تنظیم کنید. این تنظیم تنها بر خروجی SVG تأثیر می‌گذارد. خط موقعیت و طول خود را در اسلاید حفظ می‌کند.

مثال سرپیکان مثلثی و الماسی را بر روی خطوط با عرض ۲ و ۱۰ نقطه می‌کشد. همان اسلاید را دو بار صادر می‌کند و فقط گزینه برش را تغییر می‌دهد.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

مقایسه سرپیکان مثلثی بر روی خط ۱۰‑نقطه‌ای را نشان می‌دهد. با فعال بودن برش، نوک تیز است. با غیرفعال بودن برش، پرانتن از کناره‌های شیب‌دار نشانگر بیرون می‌آید و یک انتهای صاف باقی می‌گذارد.

![مثلث بزرگ‌شدهٔ ۱۰‑نقطه‌ای با نوک تیز وقتی برش فعال است و انتهای صاف وقتی برش غیرفعال است](line-end-cropping.png)

در خطوط دیگر مثال، پرانتن بیرون‌زدگی کمتر روی مثلث ۲‑نقطه‌ای مشهود است. الماس پر شده انتهای پرانتن را در هر دو عرض می‌پوشاند.

## **کنترل متن و قلم‌ها**

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که متن به صورت متن باقی بماند یا به گرافیک برداری تبدیل شود، و قلم‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین ثبات بصری، انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **برداری‌سازی تمام متن**

برای نوشتن تمام متن اسلاید به‌صورت گرافیک برداری، [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) را به `True` تنظیم کنید. این کار وابستگی‌های قلم را حذف می‌کند و نتیجهٔ بصری را در مرورگرها یکپارچه‌تر می‌کند، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نیست.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **انتخاب نحوهٔ مدیریت قلم‌های خارجی**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. برای ارجاع به فایل‌های قلم جداگانه `ADD_LINKS_TO_FONT_FILES`، برای گنجاندن داده‌های قلم در SVG `EMBED` یا برای رندر فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به‌صورت گرافیک `VECTORIZE` را انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای قلم را تأیید کنید.

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

از [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) برای حذف نواحی برش‌خوردهٔ منبع، و [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات اندازهٔ فایل را با هزینه‌ای برای وفاداری تصویر یا داده‌های تصویر باقی‌مانده کاهش می‌دهند.

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

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) حد پایین‌تری برای وضوح رستر‌سازی متافایل‌ها در هنگام خروجی SVG تعیین می‌کند. از آن برای تعادل بین جزئیات و اندازهٔ فایل زمانی که تصویر EMF یا WMF رستر می‌شود، استفاده کنید. این تنظیم یک DPI سراسری برای SVG تعریف نمی‌کند و همهٔ اشیاء را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید که شامل یک تصویر EMF با خطوط قطری با فاصله نزدیک است. مثال زیر اولین اسلاید آن را در سه وضوح رستر‌سازی مختلف از طریق [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) صادر می‌کند. تمام تنظیمات دیگر خروجی یکسان می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ آن‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستر‌سازی متافایل | ابعاد PNG جاسازی‌شده | اندازهٔ فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسه زیر همان ناحیهٔ رستری جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری پیکسل‌سازی قابل مشاهده‌ای در ۷۲ DPI و لبه‌های نرم‌تری در وضوح‌های بالاتر دارند، در حالی که اندازهٔ فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً همه جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده را تغییر نمی‌دهد.

![جزئیات بزرگ‌شدهٔ خطوط قطری در ۷۲، ۱۵۰ و ۳۰۰ DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) کاهش وضوح تصویر را کنترل می‌کند و می‌تواند اثر تغییر وضوح رستر‌سازی متافایل را پوشش دهد. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رستر‌سازی متافایل.

## **سؤالات متداول**

**چه زمانی باید از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) به جای [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) استفاده کنید وقتی تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) استفاده کنید وقتی فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین راه برای کوچک کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی آغاز کنید وقتی محیط هدف می‌تواند آن‌ها را ارائه دهد. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کیفیت پایین‌تر JPEG و برداری‌سازی متن هر کدام تعادل متفاوتی بین کیفیت و اندازه ایجاد می‌کنند.