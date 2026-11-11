---
title: رندر اسلایدهای ارائه به‌صورت تصاویر SVG در پایتون از طریق جاوا
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
## **نمای کلی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش‌دهندگان اسلاید، گردش‌های دسترسی‌پذیری و پردازش خودکار پس‌پردازش به‌خوبی کار می‌کند. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادرشده باید فشرده، پیش‌بینی‌شدنی در مرورگرها و آماده استفاده تعاملی باشد.

## **صادرات یک اسلاید به SVG**

یک [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) به یک جریان بنویسید. مثال‌ها به یک فایل `presentation.pptx` موجود نیاز دارند. هر مثال در صورت لزوم JVM را راه‌اندازی کرده و جریان‌های خروجی را می‌بندد. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) صادر کنید وقتی که یک نمایش‌دهنده اسلاید یا صفحه وب تنها به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) فریم متن را در ناحیه رندر شامل می‌شود و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) تعیین می‌کند آیا چرخش فریم اعمال شود یا نه. وقتی متن باید بدون لیگچر رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) را به `True` تنظیم کنید.

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

## **کنترل بریده‌گیری انتهای خط در سر تیرها**

SVG 1.1 تنظیمی برای تعیین نقطه قطع خط زیر سر تیر ندارد. به‌صورت پیش‌فرض، Aspose.Slides طول خط صادرشده را کوتاه می‌کند تا Stroke از مارکر بیرون نزند. با فراخوانی [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) و مقدار `True`، Stroke تا نقطهٔ انتهایی اصلی خط کشیده می‌شود. این تنظیم فقط بر خروجی SVG تأثیر می‌گذارد؛ موقعیت و طول خط در اسلاید ثابت می‌ماند.

مثال سر تیرهای مثلثی و الماسی را بر روی خطوط ۲ و ۱۰ پیکسل عرض می‌کشد. همان اسلاید دو بار صادر می‌شود؛ فقط گزینهٔ بریده‌گیری تغییر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

مقایسهٔ سر تیر مثلثی بر روی خط ۱۰‑پیکسل را نشان می‌دهد. وقتی بریده‌گیری فعال باشد، نوک تیز است. وقتی غیرفعال باشد، Stroke از سمت‌های مورب مارکر بیرون زده و یک انتهای مسطح ایجاد می‌کند.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

در خطوط دیگر مثال، Stroke بیرون‌زده بر روی سر تیر مثلثی ۲‑پیکسل کمتر دیده می‌شود. الماس پر شده انتهای Stroke را در هر دو عرض می‌پوشاند.

## **کنترل متن و قلم‌ها**

هنگام صادرات اسلایدها به SVG، می‌توانید تصمیم بگیرید که آیا متن به‌عنوان متن باقی بماند یا به گرافیک‌های برداری تبدیل شود و قلم‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کنند تا تعادل بین یکپارچگی بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادرشده را برقرار کنید.

### **برداری‌سازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) را به `True` تنظیم کنید تا تمام متن اسلاید به گرافیک‌های برداری نوشته شود. این وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرها یکنواخت‌تر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نیست.

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

### **انتخاب نحوهٔ مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) از یک مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای شامل کردن داده‌های قلم در SVG، یا `Vectorize` را برای رندر متن‌های استفاده‌کننده از قلم‌های خارجی به صورت گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای آن‌ها را بررسی کنید.

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

## **کاهش اندازهٔ تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) برای کاهش وضوح تصاویر جاسازی‌شده، از [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) برای حذف نواحی برش‑خوردهٔ منبع، و از [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازهٔ پرونده را به‌قیمت کاهش دقت تصویر یا حذف داده‌های تصویر کاهش می‌دهند.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) حد پایین‌ترین وضوح برای رستری‌سازی متافایل‌ها هنگام خروجی SVG را تعیین می‌کند. از آن برای تعادل بین جزئیات و اندازهٔ پرونده هنگام رستری‌سازی تصویر EMF یا WMF استفاده کنید. این مقدار DPI کلی برای SVG تعریف نمی‌کند و تمام اشیاء اسلاید را مجبور به تبدیل به تصویر رستری نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط قطری نزدیک به‌هم است. مثال زیر اولین اسلاید را در سه وضوح رستری‌سازی مختلف از طریق [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) صادر می‌کند. سایر تنظیمات صادرات همان‌مانند باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیست.

| وضوح رستری‌سازی متافایل (DPI) | ابعاد PNG جاسازی‌شده | حجم پرونده SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در ۷۲ DPI پیکسل‌گذاری قابل ملاحظه‌ای دارند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که حجم پرونده SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا همهٔ تصاویر صادرشده را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را پنهان کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) کنترل کیفیت رمزگذاری JPEG را دارد، نه وضوح رستری‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از یک کنترل‌کنندهٔ قالب‌بندی پایتون که از طریق `jpype.JProxy` ثبت می‌شود برای اختصاص مقدارهای [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) به اشکال و مقدارهای [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) به عناصر `tspan` متن استفاده کنید. این پروکسی را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید.

کنترل‌کنندهٔ زیر از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) که برای طول عمر شکل ثابت است، و شمارندهٔ تکرارپذیر برای بخش‌های متنی آن استفاده می‌کند. این ایده‌آل برای پردازش پس از صادرات ارائهٔ بدون تغییر است.

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

در یک کنترل‌کنندهٔ قالب‌بندی پایتون، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) و مقدار [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) یک هندلر جاوااسکریپت به شکل صادرشده اضافه کنید. کنترل‌کننده را از طریق `jpype.JProxy` ثبت کنید و با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) اختصاص دهید. تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع جاوااسکریپت ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان نمایش اسلایدها، بهبود دسترسی و سایر گردش‌های کاری تعاملی SVG را فراهم می‌کند.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) وقتی که فقط متن‌های استفاده‌کننده از قلم‌های خارجی باید به گرافیک تبدیل شوند.

**بهترین روش برای کوچک کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب پرونده‌های قلم پیوندی (در صورتی که محیط هدف بتواند آن‌ها را سرویس دهد) شروع کنید. نتیجه را تست کنید چون کاهش وضوح تصویر، کاهش کیفیت JPEG و برداری‌سازی متن هرکدام تبادل‌های متفاوتی بین کیفیت و اندازه دارند.

**آیا می‌توان پس از صادرات، عناصر SVG را اصلاح کرد؟**

بله. شناسه‌ها را از طریق یک کنترل‌کنندهٔ قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابقت‌دار را در ابزار پس از پردازش یا اسکریپت مرورگر خود انتخاب کنید.