---
title: نمایس اسلایدهای ارائه به‌صورت تصاویر SVG در پایتون از طریق جاوا
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های صادرات SVG
- SVG تعاملی
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌عنوان تصاویر SVG در پایتون از طریق جاوا صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **مرور کلی**

SVG یک قالب تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلاید، جریان‌های کاری دسترس‌پذیری و پردازش پس از تولید خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادرشده باید فشرده، در مرورگرهای مختلف پیش‌بینی‌پذیر یا آماده استفاده تعاملی باشد.

## **صادرات یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و با استفاده از [Slide.writeAsSvg](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) آن را به یک جریان بنویسید. مثال‌ها به یک فایل `presentation.pptx` موجود نیاز دارند. هر مثال در صورت نیاز JVM را راه‌اندازی می‌کند و جریان‌های خروجی خود را می‌بندد. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getSlideNumber) استفاده می‌کند نه از شاخص حلقه. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) صادر کنید وقتی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای چارچوب‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setUseFrameSize) چارچوب متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند آیا چرخش چارچوب اعمال شود یا نه. هنگامیکه متن باید بدون لیگاتورهای قلم رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) را روی `True` تنظیم کنید.

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

### **همه متن‌ها را برداری کنید**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setVectorizeText) را روی `True` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های برداری نوشته شود. این کار وابستگی به قلم‌ها را حذف می‌کند و نتیجه بصری را بین مرورگرها یکنواخت‌تر می‌کند، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نیست.

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

### **نحوه پردازش قلم‌های خارجی را انتخاب کنید**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG یا `Vectorize` را برای رندر متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به‌صورت گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای آن‌ها را بررسی کنید.

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

## **کاهش اندازه تصویر توکار**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر توکار، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی بریده‌شده منبع تصویر و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات اندازه فایل را با هزینهٔ کاهش وفاداری تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهد.

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

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از یک کنترل‌گر قالب‌بندی پایتون که از طریق `jpype.JProxy` ثبت شده است، برای اختصاص مقادیر [SvgShape.setId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgshape/#setId) به اشکال و مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgtspan/#setId) به عناصر `tspan` متن استفاده کنید. پراکسی را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید.

کنترل‌گر زیر از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getOfficeInteropShapeId) استفاده می‌کند، که برای طول عمر شکل ثابت است، و یک شمارندهٔ قابل تکرار برای بازه‌های متنی آن. این کار شناسه‌های تولیدشده را برای پردازش پس از انتشار یک ارائهٔ تغییرن‌نافته مناسب می‌سازد.

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

## **اضافه کردن هندلرهای رویداد SVG**

در یک کنترل‌گر قالب‌بندی پایتون، با یک مقدار [SvgEvent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgevent/) به [SvgShape.setEventHandler](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgshape/#setEventHandler) فراخوانی کنید تا یک هندلر JavaScript به یک شکل صادرشده اضافه شود. کنترل‌گر را از طریق `jpype.JProxy` ثبت کنید و با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید. تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحه میزبان می‌تواند تابع JavaScript را که توسط هندلر ارجاع داده می‌شود، تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان مشاهده اسلاید، بهبود دسترس‌پذیری و دیگر جریان‌های کاری SVG تعاملی را فراهم می‌کند.

## **پرسش‌های متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setVectorizeText) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgoptions/#setVectorizeText) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) زمانی استفاده کنید که فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به گرافیک تبدیل شوند.

**بهترین روش برای کوچک کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر توکار، حذف نواحی بریده‌شده تصویر و انتخاب فایل‌های قلم پیوندی زمانی که محیط هدف می‌تواند آن‌ها را سرویس‌دهی کند، شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و متن برداری هر کدام تعادل متفاوتی بین کیفیت و اندازه دارند.

**آیا می‌توانم عناصر SVG صادرشده را پس از صادرات تغییر دهم؟**

بله. شناسه‌ها را از طریق یک کنترل‌گر قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابقت‌دار را در ابزار پس از پردازش یا اسکریپت مرورگر خود انتخاب کنید.