---
title: نمایش اسلایدهای ارائه به عنوان تصاویر SVG در پایتون از طریق جاوا
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/python-java/render-a-slide-as-an-svg-image/
keywords:
- پاورپوینت به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های صادرات SVG
- SVG تعاملی
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اسلایدهای پاورپوینت را به عنوان تصاویر SVG در پایتون از طریق جاوا صادر کنید و با Aspose.Slides قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را کنترل کنید."
---
## **مرور کلی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلایدها، جریان‌های کار دسترسی‌پذیری و پردازش‌های پس‌زمینه خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌شدنی در مرورگرهای مختلف یا آماده استفاده تعاملی باشد.

## **صادرات یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) به یک جریان بنویسید. مثال‌ها به یک فایل `presentation.pptx` موجود نیاز دارند. هر مثال JVM را در صورت نیاز اجرا می‌کند و جریان‌های خروجی خود را می‌بندد. مثال زیر هر اسلاید در یک ارائه را به یک فایل SVG جداگانه صادر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) صادر کنید وقتی یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند آیا چرخش فریم اعمال شود یا خیر. برای رندر متن بدون لیگچرها، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) را به `True` تنظیم کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **کنترل متن و قلم‌ها**

هنگام صادرات اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به‌عنوان متن باقی می‌ماند یا به گرافیک برداری تبدیل می‌شود و چگونه قلم‌های خارجی گنجانده یا ارجاع داده می‌شوند. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین سازگاری بصری، انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **وکتریزه کردن تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) را به `True` تنظیم کنید تا تمام متن اسلایدها به گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرهای مختلف یکسان‌تر می‌سازد، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **انتخاب نحوه‌ی مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. برای ارجاع به فایل‌های قلم جداگانه `AddLinksToFontFiles` را انتخاب کنید، برای گنجاندن داده‌های قلم در SVG `Embed` را انتخاب کنید یا برای رندر فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به‌صورت گرافیک `Vectorize` را انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای مربوطه را بررسی کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **کاهش حجم تصویر تعبیه‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر تعبیه‌شده، از [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی برش‌خورده منبع، و از [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با هزینه‌ی کاهش وضوح یا داده‌های تصویر نگه‌داشته‌شده کاهش می‌دهند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **کنترل وضوح رستری‌سازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) حد پایین‌ترین وضوح برای رستری‌سازی متافایل‌ها در هنگام صادرات SVG را تنظیم می‌کند. از آن برای تعادل بین جزئیات و حجم فایل زمانی که یک تصویر EMF یا WMF رستری می‌شود، استفاده کنید. این تنظیم یک DPI سراسری برای SVG تعریف نمی‌کند و همهٔ اشیای اسلاید را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل حاوی یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستری‌سازی مختلف از طریق [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) صادر می‌کند. تمام تنظیمات دیگر صادرات یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

در خروجی، EMF به یک PNG تعبیه‌شده در هر SVG تبدیل می‌شود. اندازه‌گیری‌های زیر برای ارائهٔ فراهم‌شده است؛ آنها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستری‌سازی متافایل | ابعاد PNG تعبیه‌شده | اندازه فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسه زیر همان ناحیهٔ رستری تعبیه‌شده را در همان اندازه نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در 72 DPI پیکسل‌پذیری قابل مشاهده دارد و در وضوح‌های بالاتر لبه‌های نرم‌تری دارد، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده را تغییر نمی‌دهد.

![جزئیات بزرگ‌نمایی شدهٔ خطوط قطری در 72، 150 و 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) کاهش وضوح تصویر را کنترل می‌کند و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را پنهان سازد. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به شکل‌ها و متن**

از یک کنترل‌کننده قالب‌بندی پایتون که از طریق `jpype.JProxy` ثبت شده است، برای اختصاص مقادیر به [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) به شکل‌ها و به [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) به عناصر متن `tspan` استفاده کنید. پروکسی را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید.

کنترل‌کننده زیر از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارندهٔ قابل تکرار برای بازه‌های متنی آن دارد. این کار شناسه‌های تولیدشده را برای پردازش پس از انتشار یک ارائهٔ بدون تغییر مناسب می‌سازد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **افزودن هندلرهای رویداد SVG**

در یک کنترل‌کننده قالب‌بندی پایتون، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) و مقدار [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) یک هندلر جاوااسکریپت به یک شکل صادرشده اضافه کنید. کنترل‌کننده را از طریق `jpype.JProxy` ثبت کنید و با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید. تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

صفحهٔ میزبان می‌تواند تابع جاوااسکریپت ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیر ساختن نمایشگرهای اسلاید، بهبودهای دسترسی و سایر گردش‌کارهای تعاملی SVG را فراهم می‌کند.

## **پرسش‌های متداول**

**چه زمانی باید به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) استفاده کنید وقتی تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) استفاده کنید وقتی تنها متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر تعبیه‌شده، حذف نواحی برش‌خورده تصویر و انتخاب فایل‌های قلم پیوندی شروع کنید وقتی محیط هدف می‌تواند آن‌ها را سرویس دهد. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کیفیت پایین JPEG و متن وکتریزه‌شده هر کدام مبادلات متفاوتی بین کیفیت و اندازه دارند.

**آیا می‌توانم پس از صادرات عناصر SVG را اصلاح کنم؟**

بله. شناسه‌ها را از طریق یک کنترل‌کننده قالب‌بندی اختصاص دهید، سپس عناصر SVG مرتبط را در ابزار پردازش پس یا اسکریپت مرورگر خود انتخاب کنید.