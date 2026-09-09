---
title: تبدیل ارائه‌های PowerPoint به HTML در Python از طریق Java
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/python-java/convert-powerpoint-to-html/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ذخیره PowerPoint به صورت HTML
- ذخیره ارائه به صورت HTML
- ذخیره اسلاید به صورت HTML
- ذخیره PPT به صورت HTML
- ذخیره PPTX به صورت HTML
- صدور PPT به HTML
- صدور PPTX به HTML
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در Python از طریق Java. از Aspose.Slides برای صدور فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، فونت‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via Java می‌تواند ارائه‌های PowerPoint را بدون نیاز به Microsoft PowerPoint به HTML ذخیره کند. تبدیل پایه شامل یک بارگذاری [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) و یک فراخوانی [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) با استفاده از [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) است. وقتی نیاز به کنترل طرح خروجی، فونت‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع مرتبط دارید، از [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی صادرات HTML تمرکز دارد:

- صادرات کل ارائه یا اسلایدهای انتخابی.
- تولید HTML با طرح ثابت، واکنش‌گرا یا مبتنی بر SVG.
- گنجاندن یادداشت‌های سخنران و نظرات.
- کنترل کیفیت تصویر و داده‌های تصاویر برش‌خورده.
- تعبیه فونت‌ها یا ذخیرهٔ فایل‌های فونت به‌صورت جداگانه.
- انتخاب نحوهٔ نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌صورت پیش‌فرض، صادرات HTML یک سند HTML خودکفا تولید می‌کند که در آن اکثر منابع جاسازی شده‌اند. این روش برای به‌اشتراک‌گذاری یک فایل مناسب است، اما می‌تواند حجم خروجی را افزایش دهد. برای انتشار وب، منابع خارجی، DPI تصویر کمتر و فقط تعبیهٔ فونت‌هایی که به‌طور قابل اعتمادی در محیط هدف موجود نیستند را درنظر بگیرید.

## **تبدیل ارائه به HTML**

برای صادرات یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگیری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Html) ذخیره کنید.

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

هر مثال `presentation.pptx` را از پوشهٔ کاری فعلی بارگیری می‌کند. قبل از اجرا، Aspose.Slides for Python via Java و یک زمان اجرای Java سازگار را نصب کنید. JVM یک‌بار برای هر پردازش Python راه‌اندازی می‌شود.

این مثال یک فایل HTML می‌نویسد. شئ ارائه در بلاک `finally` از بین می‌رود، که پس از صادرات، دستگیره‌های فایل و منابع رندر را آزاد می‌کند.

## **پیکربندی صادرات HTML**

[HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) کلاس اصلی پیکربندی برای صادرات HTML است. تنظیمات رایج شامل موارد زیر می‌شود:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): افزودن یادداشت‌ها، نظرات، جزوات یا سایر اطلاعات طرح.
- [setHtmlFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setHtmlFormatter): تغییر ساختار سند HTML یا واگذاری فرمت‌دهی به یک کنترل‌کننده.
- [setSlideImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlideImageFormat): تغییر نحوهٔ نمایش اسلایدها، مثلاً به‌صورت SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setPicturesCompression): کنترل DPI تصویر و حجم خروجی.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): نگه داشتن یا حذف داده‌های تصاویر برش‌خورده.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): سازگار کردن محتوای SVG خروجی با ظرف خود.
- [setShowHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): شامل کردن اسلایدهای مخفی هنگام نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نمایش می‌دهند تا بتوانید تنها گزینه‌هایی را که جریان کاری‌تان نیاز دارد ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

متد overload `Presentation.save` که شماره اسلایدها را می‌پذیرد، موقعیت‌های اسلاید را به‌صورت 1‑based در نظر می‌گیرد. حلقهٔ زیر هر اسلاید را در یک فایل HTML جداگانه ذخیره می‌کند.

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

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحهٔ HTML برای هر اسلاید نیاز داشته باشد. اگر هر اسلاید باید همان طرح را داشته باشد، یک شیء [HtmlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/) ایجاد کنید و آن را به هر فراخوانی [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس بدهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmlformatter/) فراهم می‌کند. زمانی که صفحهٔ خروجی باید بهتر به عرض مرورگر سازگار شود، از آن استفاده کنید.

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

برای طرح واکنش‌گرا مبتنی بر SVG، `HtmlOptions.setSvgResponsiveLayout` را با مقدار `True` فراخوانی کنید. این گزینه زمانی مفید است که محتوای اسلاید به‌صورت علامت‌گذاری SVG مقیاس‌پذیر صادر می‌شود.

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

## **گنجاندن یادداشت‌های سخنران و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) از طریق [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) برای گنجاندن یادداشت‌های سخنران یا نظرات استفاده کنید. به‌طور پیش‌فرض یادداشت‌ها و نظرات مخفی هستند مگر اینکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائهٔ منبع شامل یادداشت‌های سخنران باشد:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

کد زیر محتوی اسلاید را به‌همراه یادداشت‌های سخنران زیر اسلاید صادر می‌کند.

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

HTML صادرشده شامل ناحیهٔ یادداشت‌هاست:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

برای صادرات نظرات، `NotesCommentsLayoutingOptions.setCommentsPosition` را فراخوانی کنید؛ به‌عنوان مثال با [CommentsPositions.Right](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Right) یا [CommentsPositions.Bottom](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Bottom). اگر فقط به نظرات نیاز دارید، `NotesCommentsLayoutingOptions.setNotesPosition` را حذف کنید. اگر به هر دو نیاز دارید، هر دو متد را فراخوانی کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

صادرات HTML می‌تواند تصاویر اسلاید را فشرده کند تا حجم خروجی کاهش یابد. مقدار موردنظر را به `HtmlOptions.setPicturesCompression` از `PicturesCompression` پاس دهید وقتی به کیفیت تصویر بالاتر احتیاج دارید.

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

به‌صورت پیش‌فرض، نواحی برش‌خوردهٔ تصاویر ممکن است از خروجی حذف شوند. فقط زمانی داده‌های برش‌خورده را نگه دارید که کاربران باید بتوانند آن بخش‌های پنهان تصویر را بازیابی یا بررسی کنند. نگه‌داشتن آن‌ها می‌تواند حجم HTML را افزایش دهد.

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

برای استایل ساده، یک رشتهٔ CSS را به `HtmlFormatter.createDocumentFormatter` پاس دهید. این کار ساختار سند HTML پیرامونی را تغییر می‌دهد در حالی که Aspose.Slides همچنان محتوی اسلاید را رندر می‌کند.

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

برای افزودن سرصفحهٔ سفارشی سند، یک فایل CSS مرتبط یا علامت‌گذاری سفارشی اطراف اسلایدها و اشکال، از یک کنترل‌کنندهٔ فرمت‑دهی سفارشی از طریق یک پراکسی رابط JPype استفاده کنید و آن را به `HtmlFormatter` با `HtmlFormatter.createCustomFormatter` پاس دهید.

## **تعبیهٔ فونت‌ها**

اگر محیط هدف ممکن است فونت‌های ارائه را نصب نکرده باشد، فونت‌ها را در HTML با `EmbedAllFontsHtmlController` تعبیه کنید. تعبیه به‌دقت بصری کمک می‌کند اما حجم خروجی را افزایش می‌دهد.

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

فقط وقتی مطمئن هستید مرورگرها یا سیستم‌های هدف فونت‌ها را دارند، از تعبیه صرف‌نظر کنید. برای فونت‌های برند یا کمتر رایج، تعبیه معمولاً امن‌تر است.

## **ذخیرهٔ منابع به‌صورت خارجی**

HTML خودکفا جابه‌جایی آسانی دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامهٔ شما به فایل‌های تصویر خارجی نیاز دارد، یک کنترل‌کنندهٔ پیوند منابع از طریق پراکسی JPype پیاده‌سازی کنید و به سازندهٔ `HtmlOptions` پاس دهید.

هنگام بیرون‌زدن منابع، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی سیستم‑فایل، جایی که برنامه‌تان تصاویر، فونت‌ها، صدا یا ویدئوهای تولیدشده را می‌نویسد.
- مسیر URL، که مرورگر از داخل سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoplayerhtmlcontroller/) ویدئوها و صداها را صادر می‌کند و HTMLی می‌نویسد که می‌تواند آن‌ها را در مرورگر پخش کند. سازندهٔ آن موارد زیر را می‌گیرد:

- `path`: پوشه‌ای که فایل‌های رسانه‌ای تولیدشده در آن نوشته می‌شوند.
- `fileName`: نام فایل HTML تولیدشده.
- `baseUri`: پیشوند URI مطلق که در پیوندهای HTML به فایل‌های رسانه‌ای استفاده می‌شود.

مثال زیر رسانه‌های از پیش تعبیه‌شده در `presentation.pptx` را صادر می‌کند. HTML تولیدشده فقط با نام فایل به فایل‌های رسانه‌ای ارجاع می‌دهد، نسبی به سند HTML؛ بنابراین `path` باید همان پوشه‌ای باشد که فایل HTML نیز در آن قرار می‌گیرد. `baseUri` باید یک URI مطلق باشد: برای پیش‌نمایش محلی، یک URI `file:///` از پوشه خروجی بسازید؛ برای برنامهٔ مستقر، از URL مطلق پوشهٔ منتشرشده استفاده کنید.

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

برای هر کار صادرات، پوشه‌های خروجی یکتا استفاده کنید، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌توانند باعث بازنویسی فایل‌های تبدیل‌های مختلف شوند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و استفاده از حافظه به تعداد اسلایدها، وضوح تصویر، فونت‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده وابسته است. مقادیر DPI تصویر بالاتر که به `HtmlOptions.setPicturesCompression` پاس می‌شوند، فونت‌های جاسازی‌شده، خروجی SVG و نگه‌داشتن نواحی برش‌خورده می‌توانند دقت را افزایش دهند اما معمولاً حجم خروجی را بزرگ می‌کنند.

برای تبدیل دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را بلافاصله پس از استفاده آزاد کنید.
- برای هر کار پوشهٔ خروجی جداگانه استفاده کنید.
- مگر اینکه دقت بصری ضروری باشد، از تعبیهٔ فونت‌های رایج خودداری کنید.
- برای پیش‌نمایش یا تصویرهای بندانگشتی، DPI تصویر را کمتر کنید.
- تا زمانی که مسیرهای انتشار نهایی شوند، ارائهٔ منبع، HTML تولیدشده و منابع خارجی را در کنار هم نگه دارید.

## **سوالات متداول**

**آیا پیوندهای هیپرتکست در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای هیپرتکست ارائه به HTML صادر می‌شوند و وقتی URL هدف معتبر باشد قابل کلیک‌اند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های متفاوت را با نمونه‌های ارائهٔ مستقل، جریان‌های جداگانه و مسیرهای خروجی جداگانه پردازش کنید. برای جزئیات به راهنمای [multithreading guidance](/slides/fa/python-java/multithreading/) مراجعه کنید.

**آیا شیء ارائه مبتنی بر رشته (thread‑safe) است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) باید در یک رشته بارگیری، تغییر، ذخیره و آزاد شود. برای کارهای موازی، یک نمونهٔ مستقل برای هر رشته یا فرآیند ایجاد کنید.

**چرا فایل HTML تولیدشده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. فونت‌های جاسازی‌شده، تصاویر DPI بالا، رسانه‌ها, محتواهای SVG و نگه‌داشتن نواحی برش‌خورده تصویر نیز حجم را افزایش می‌دهند. برای کاهش حجم، از منابع خارجی استفاده کنید، فونت‌های رایج را از تعبیه حذف کنید و مقدار DPI پایین‌تری را به `HtmlOptions.setPicturesCompression` پاس دهید وقتی اندازهٔ کوچکتر مهم‌تر از حداکثر دقت باشد.

**چرا مقدار font‑size در HTML می‌تواند با مقدار PowerPoint متفاوت باشد؟**

صفحهٔ خروجی می‌تواند از سیستم‌های مختصات SVG و تبدیل‌های مقیاس استفاده کند. یک مقدار CSS یا SVG به‌تنهایی اندازهٔ نهایی نمایش داده‌شده را توصیف نمی‌کند. اسلاید رندرشده را در سطح بزرگنمایی مورد نظر مقایسه کنید و در صورت متفاوت بودن، در دسترس بودن فونت را بررسی کنید.

**چگونه باید baseUri را برای صادرات رسانه‌ها انتخاب کنم؟**

`baseUri` را از منظر مرورگر انتخاب کنید و به‌عنوان یک URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از پوشهٔ خروجی با `output_directory.as_uri() + "/"` به‌دست آورید. برای انتشار، از URL مطلق پوشهٔ منتشرشده استفاده کنید. مسیر سیستم‑فایل `path` و `baseUri` مرورگر نیازی به یک رشتهٔ یکسان ندارند، اما باید به همان مکان اشاره کنند و آن مکان باید پوشهٔ حاوی فایل HTML تولیدشده باشد زیرا پیوندهای رسانه‌ای به‌صورت نسبی نسبت به آن نوشته می‌شوند.

**آیا می‌توانم اسلایدهای مخفی را هم شامل کنم؟**

بله. هنگام نیاز به صادرات اسلایدهای مخفی، `HtmlOptions.setShowHiddenSlides` را با مقدار `True` فراخوانی کنید.