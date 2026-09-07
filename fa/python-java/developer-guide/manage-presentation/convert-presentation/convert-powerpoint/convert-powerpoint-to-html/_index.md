---
title: تبدیل ارائه‌های پاورپوینت به HTML در پایتون با جاوا
linktitle: پاورپوینت به HTML
type: docs
weight: 30
url: /fa/python-java/convert-powerpoint-to-html/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ذخیره پاورپوینت به عنوان HTML
- ذخیره ارائه به عنوان HTML
- ذخیره اسلاید به عنوان HTML
- ذخیره PPT به عنوان HTML
- ذخیره PPTX به عنوان HTML
- صدور PPT به HTML
- صدور PPTX به HTML
- پایتون
- جاوا
- Aspose.Slides
description: "پاورپوینت ارائه‌ها را به HTML در پایتون با جاوا تبدیل کنید. از Aspose.Slides برای خروجی‌گیری فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **نمای کلی**

Aspose.Slides for Python via Java می‌تواند ارائه‌های PowerPoint را بدون نیاز به Microsoft PowerPoint به فرم‌ HTML ذخیره کند. تبدیل پایه شامل یک بارگذاری [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) و فراخوانی [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) با [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) است. هنگامی که نیاز به کنترل چیدمان، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع پیوست‌دار دارید، از [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی خروجی HTML تمرکز دارد:

- خروجی کل ارائه یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، واکنش‌گرا یا مبتنی بر SVG.
- افزودن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- تعبیه قلم‌ها یا ذخیرهٔ فایل‌های قلم به‌صورت جداگانه.
- انتخاب نحوهٔ نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به طور پیش‌فرض، خروجی HTML یک سند HTML خودکفا تولید می‌کند که بیشتر منابع درون‌ریز هستند. این برای اشتراک‌گذاری یک فایل راحت است، اما می‌تواند اندازهٔ خروجی را افزایش دهد. برای انتشار وب، استفاده از منابع خارجی، کاهش DPI تصویر و تعبیهٔ تنها قلم‌هایی که به‌اطمینان در محیط هدف موجود نیستند را در نظر بگیرید.

## **تبدیل ارائه به HTML**

برای خروجی یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Html) ذخیره کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

هر مثال `presentation.pptx` را از پوشهٔ کاری جاری بارگذاری می‌کند. قبل از اجرا، Aspose.Slides for Python via Java و یک زمان‌اجرای Java سازگار را نصب کنید. JVM یک‌بار برای هر فرآیند Python راه‌اندازی می‌شود.

این مثال یک فایل HTML می‌نویسد. شیء ارائه در بلوک `finally` حذف می‌شود، که پس از خروجی‌گیری دستگیره‌های فایل و منابع رندر را آزاد می‌کند.

## **پیکربندی خروجی HTML**

[HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) کلاس اصلی پیکربندی برای خروجی HTML است. تنظیمات رایج شامل:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): افزودن یادداشت‌ها، نظرات، جزوه‌ها یا سایر اطلاعات چیدمان.
- [setHtmlFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setHtmlFormatter): تغییر ساختار سند HTML یا واگذاری قالب‌بندی به یک کنترل‌کننده.
- [setSlideImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlideImageFormat): تغییر نحوهٔ نمایش اسلایدها، مثلاً به صورت SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setPicturesCompression): کنترل DPI تصویر و اندازهٔ خروجی.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): نگه داشتن یا حذف داده‌های تصویر برش‌خورده.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): سازگار کردن محتوای SVG خروجی با محفظهٔ خود.
- [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): شامل کردن اسلایدهای مخفی در صورت نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نشان می‌دهند تا بتوانید فقط گزینه‌های مورد نیاز جریان کاری خود را ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

بازنویسی [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) که شمارهٔ اسلایدها را می‌پذیرد، از موقعیت‌های 1‑Based استفاده می‌کند. حلقهٔ زیر هر اسلاید را در فایلی HTML جداگانه ذخیره می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحهٔ HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) ایجاد کنید و آن را به هر فراخوانی [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmlformatter/) فراهم می‌کند. هنگامی که صفحهٔ خروجی باید بهتر با عرض مرورگر سازگار شود، از آن استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

برای چیدمان واکنش‌گرا بر پایه SVG، متد [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) را با مقدار `True` صدا بزنید. این زمانی مفید است که محتوای اسلاید به صورت نشانه‌گذاری SVG قابل مقیاس باشد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **افزودن یادداشت‌های گوینده و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) از طریق [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) برای شامل‌کردن یادداشت‌های گوینده یا نظرات استفاده کنید. به‌طور پیش‌فرض یادداشت‌ها و نظرات مخفی هستند مگر اینکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائهٔ منبع دارای یادداشت‌های گوینده باشد:

![اسلاید با یادداشت‌های گوینده در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را به‌همراه یادداشت‌های گوینده زیر اسلاید صادر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

HTML خروجی شامل ناحیهٔ یادداشت‌ها خواهد بود:

![خروجی HTML با اسلاید و یادداشت‌های گوینده](HTML_with_notes.png)

برای خروجی نظرات، متد [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) را صدا بزنید، برای مثال با [CommentsPositions.Right](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Right) یا [CommentsPositions.Bottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Bottom). اگر فقط به نظرات نیاز دارید، [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) را حذف کنید. اگر به هر دو نیاز دارید، هر دو متد را فراخوانی کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

خروجی HTML می‌تواند تصاویر اسلاید را فشرده کند تا اندازهٔ خروجی کاهش یابد. مقدار موردنظر را به [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setPicturesCompression) از [PicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturescompression/) پاس دهید وقتی به کیفیت تصویر بالاتری نیاز دارید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

به‌طور پیش‌فرض، نواحی برش‌خوردهٔ تصاویر ممکن است از خروجی حذف شوند. تنها زمانی داده‌های برش‌خورده را نگه‌دارید که کاربران باید بتوانند این بخش‌های مخفی تصویر را بازیابی یا بررسی کنند. نگه‌داشتن آن می‌تواند اندازهٔ HTML را افزایش دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **افزودن CSS**

برای استایل‌سازی ساده، یک رشتهٔ CSS را به [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) پاس دهید. این کار سند HTML پیرامونی را تغییر می‌دهد در حالی که Aspose.Slides به رندر محتوای اسلاید ادامه می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

برای افزودن سرصفحهٔ سفارشی سند، یک فایل CSS پیوندی یا نشانه‌گذاری سفارشی دور اسلایدها و اشکال، از یک کنترل‌کننده قالب‌بندی سفارشی از طریق یک پروکسی رابط JPype استفاده کنید و آن را به [HtmlFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmlformatter/) با [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmlformatter/#createCustomFormatter) پاس دهید.

## **تعبیهٔ قلم‌ها**

اگر محیط هدف ممکن است قلم‌های ارائه را نداشته باشد، با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/embedallfontshtmlcontroller/) قلم‌ها را در HTML تعبیه کنید. تعبیهٔ قلم‌ها وفاداری بصری را بهبود می‌بخشد اما اندازهٔ خروجی را افزایش می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

قلم‌ها را تنها زمانی حذف کنید که مطمئن باشید مرورگرها یا سیستم‌های هدف آن‌ها را قبلاً فراهم کرده‌اند. برای قلم‌های برند یا کمتر رایج، تعبیه معمولاً ایمن‌تر است.

## **ذخیرهٔ منابع به‌صورت خارجی**

HTML خودکفا جابجایی آسان دارد، اما منابع Base64 تعبیه‌شده می‌توانند فایل را بزرگ کنند. اگر برنامهٔ شما به فایل‌های تصویر خارجی نیاز دارد، یک کنترل‌کنندهٔ پیوند منابع از طریق پروکسی رابط JPype پیاده‌سازی کنید و آن را به سازندهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) پاس دهید.

هنگام بیرونی‌سازی منابع، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی سیستم‌فایلی که برنامهٔ شما فایل‌های تصویر، قلم، صدا یا ویدیو تولید شده را در آن می‌نویسد.
- مسیر URL که مرورگر از داخل سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

## **خروجی فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoplayerhtmlcontroller/) ویدیو و صدا را خروجی می‌دهد و HTMLی می‌نویسد که می‌تواند در مرورگر پخش شود. سازندهٔ آن شامل:

- `path`: پوشه‌ای که فایل‌های رسانه‌ای تولید شده در آن نوشته می‌شود.
- `fileName`: نام فایل HTML در حال تولید.
- `baseUri`: پیشوند URI مطلق که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

مثال زیر رسانه‌های از پیش تعبیه‌شده در `presentation.pptx` را خروجی می‌دهد. HTML تولید شده فقط با نام فایل به فایل‌های رسانه‌ای ارجاع می‌دهد؛ این ارجاع نسبت به سند HTML است، بنابراین `path` باید همان پوشه‌ای باشد که فایل HTML هم در آن ذخیره می‌شود. `baseUri` باید یک URI مطلق باشد: برای پیش‌نمایش محلی، یک URI `file:///` از پوشه خروجی بسازید؛ برای برنامهٔ مستقر، از URL مطلق پوشه‌ی منتشرشده استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

از پوشه‌های خروجی که برای هر کار تبدیل منحصر به‌فرد هستند استفاده کنید، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌توانند باعث شوند فایل‌های تبدیل‌های مختلف روی هم بنویسند.

## **کارایی و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های تعبیه‌شده بستگی دارد. مقادیر DPI تصویر بالاتر که به [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setPicturesCompression) پاس می‌شوند، قلم‌های تعبیه‌شده، خروجی SVG و نگه‌داشت نواحی برش‌خورده می‌توانند وفاداری را بهبود بخشند اما معمولاً اندازهٔ خروجی را افزایش می‌دهند.

برای تبدیل دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را بلافاصله حذف کنید.
- برای کارهای مختلف پوشه‌های خروجی جداگانه استفاده کنید.
- از تعبیهٔ قلم‌های عمومی صرف‌نظر کنید مگر اینکه وفاداری نیاز داشته باشد.
- DPI تصویر را هنگام پیش‌نمایش یا تولید تصویرهای کوچک کاهش دهید.
- ارائهٔ منبع، HTML تولید شده و منابع خارجی را تا زمان نهایی شدن مسیرهای استقرار همراه نگه دارید.

## **سوالات متداول**

**آیا پیوندهای هیپرلینک در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ارائه به HTML صادر می‌شوند و زمانی که URL مقصد معتبر باشد قابل کلیک هستند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های جداگانهٔ ارائه، جریان‌های جداگانه و مسیرهای خروجی جداگانه پردازش کنید. راهنمای [multithreading guidance](/slides/fa/python-java/multithreading/) را ببینید.

**آیا شیء ارائه(thread‑safe) است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) باید در یک رشته بارگذاری، اصلاح، ذخیره و حذف شود. برای کار موازی، برای هر رشته یا فرآیند یک نمونه مستقل ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

خروجی پیش‌فرض می‌تواند منابع را مستقیماً در HTML تعبیه کند. قلم‌های تعبیه‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه‌داشت نواحی برش‌خورده تصویر نیز اندازه را افزیش می‌دهند. برای کاهش اندازه از منابع خارجی استفاده کنید، قلم‌های عمومی را از تعبیه حذف کنید و مقدار DPI کمتری را به [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setPicturesCompression) بدهید وقتی خروجی کوچکتر مهم‌تر از حداکثر وفاداری است.

**چرا مقادیر font-size در HTML ممکن است با مقادیر PowerPoint متفاوت باشد؟**

صفحهٔ خروجی ممکن است از سیستم‌های مختصات SVG و تبدیل‌های مقیاس‌بندی استفاده کند. یک مقدار CSS یا SVG font-size به تنهایی اندازهٔ نمایش نهایی را توصیف نمی‌کند. اسلاید رندر شده را در سطح زوم مورد نظر مقایسه کنید و در صورتی که متن ظاهری متفاوت دارد، وجود قلم را بررسی کنید.

**چگونه باید baseUri را برای خروجی رسانه انتخاب کنم؟**

`baseUri` را از دید مرورگر انتخاب کنید و به‌عنوان یک URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از پوشه خروجی به‌صورت `output_directory.as_uri() + "/"` استخراج کنید. برای استقرار، از URL مطلق پوشهٔ منتشرشده استفاده کنید. مسیر سیستم‌فایلی `path` و `baseUri` مرورگر نیازی به یک‌سان بودن ندارند، اما هر دو باید به همان مکان اشاره کنند؛ این مکان باید پوشه‌ای باشد که فایل HTML تولید شده در آن قرار دارد، زیرا لینک‌های رسانه‌ای به صورت نسبی نسبت به آن نوشته می‌شوند.

**آیا می‌توانم اسلایدهای مخفی را شامل کنم؟**

بله. وقتی اسلایدهای مخفی باید خروجی شوند، با `True` به [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) پاس دهید.