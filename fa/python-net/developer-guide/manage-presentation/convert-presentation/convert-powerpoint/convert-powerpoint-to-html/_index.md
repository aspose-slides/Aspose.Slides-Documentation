---
title: تبدیل ارائه‌های PowerPoint به HTML در Python
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/python-net/convert-powerpoint-to-html/
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
- ذخیره PowerPoint به عنوان HTML
- ذخیره ارائه به عنوان HTML
- ذخیره اسلاید به عنوان HTML
- ذخیره PPT به عنوان HTML
- ذخیره PPTX به عنوان HTML
- صادرات PPT به HTML
- صادرات PPTX به HTML
- پایتون
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در Python. از Aspose.Slides برای صادر کردن فایل‌های PPT و PPTX، اسلایدهای منتخب، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **مرور کلی**

Aspose.Slides برای Python از طریق .NET می‌تواند ارائه‌های PowerPoint را به‌عنوان HTML بدون استفاده از Microsoft PowerPoint ذخیره کند. تبدیل پایه شامل یک بار بارگذاری یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) و یک فراخوانی `save` با [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) است. هنگامی که نیاز به کنترل چیدمان خروجی، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع پیوندی دارید، از [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی صادرات HTML متمرکز است:

- صادرات یک ارائه کامل یا اسلایدهای منتخب.
- تولید HTML با طرح ثابت، واکنش‌گرا یا مبتنی بر SVG.
- گنجاندن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- جاسازی قلم‌ها یا ذخیره فایل‌های قلم به‌صورت جداگانه.
- انتخاب نحوه نوشتن و ارجاع به منابع و فایل‌های رسانه‌ای خارجی.

به‌صورت پیش‌فرض، صادرات HTML یک سند HTML خودمستقل تولید می‌کند که اکثر منابع درون‌برداری می‌شوند. این برای به‌اشتراک‌گذاری یک فایل مناسب است، اما می‌تواند اندازه خروجی را افزایش دهد. برای انتشار در وب، استفاده از منابع خارجی، کاهش DPI تصویر و تنها جاسازی قلم‌هایی که به‌طور قابل اعتماد در محیط هدف وجود ندارند را مدنظر داشته باشید.

## **تبدیل یک ارائه به HTML**

برای صادرات یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/saveformat/) ذخیره کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

این مثال یک فایل HTML می‌نویسد. عبارت `with` شیء ارائه را پس از صادرات آزاد می‌کند و دستگیره‌های فایل و منابع رندرینگ را رها می‌سازد.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) کلاس پیکربندی اصلی برای صادرات HTML است. تنظیمات رایج شامل:

- `slides_layout_options`: افزودن یادداشت‌ها، نظرات، جزوه‌ها یا سایر اطلاعات چیدمان.
- `html_formatter`: تغییر ساختار سند HTML یا واگذاری قالب‌بندی به یک کنترل‌کننده.
- `slide_image_format`: تغییر نحوه نمایش اسلایدها، برای مثال به‌صورت SVG.
- `pictures_compression`: کنترل DPI تصویر و اندازه خروجی.
- `delete_pictures_cropped_areas`: نگه‌داری یا حذف داده‌های تصویر برش‌خورده.
- `svg_responsive_layout`: سازگار کردن محتوای SVG خروجی با محفظه‌اش.
- `show_hidden_slides`: شامل کردن اسلایدهای مخفی در صورت نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نمایش می‌دهند تا بتوانید تنها گزینه‌های مورد نیاز گردش کار خود را ترکیب کنید.

## **تبدیل اسلایدهای منتخب به HTML**

روش `save` که شماره‌های اسلاید را می‌پذیرد، موقعیت‌های اسلاید را بر پایه شماره ۱ استفاده می‌کند. حلقه زیر هر اسلاید را در یک فایل HTML جداگانه ذخیره می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز داشته باشد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونه [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) ایجاد کرده و به هر فراخوانی `save` پاس می‌دهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmlformatter/) فراهم می‌کند. هنگامی که صفحه صادراتی باید بهتر با عرض مرورگر سازگار شود، از آن استفاده کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

برای چیدمان واکنش‌گرای مبتنی بر SVG، `svg_responsive_layout` را روی [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) تنظیم کنید. این گزینه زمانی مفید است که محتوای اسلاید به‌صورت نشانه‌گذاری SVG مقیاس‌پذیر صادر شود.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **گنجاندن یادداشت‌های گوینده و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) از طریق `html_options.slides_layout_options` برای گنجاندن یادداشت‌های گوینده یا نظرات استفاده کنید. یادداشت‌ها و نظرات به‌صورت پیش‌فرض پنهان هستند مگر این‌که موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائه منبع شامل یادداشت‌های گوینده باشد:

![اسلاید با یادداشت‌های گوینده در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را همراه با یادداشت‌های گوینده زیر اسلاید صادر می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

HTML صادر شده شامل ناحیه یادداشت‌ها می‌شود:

![خروجی HTML با اسلاید و یادداشت‌های گوینده](HTML_with_notes.png)

برای صادرات نظرات، `comments_position` را تنظیم کنید، برای مثال به `CommentsPositions.RIGHT` یا `CommentsPositions.BOTTOM`. اگر فقط به نظرات نیاز دارید، `notes_position` را حذف کنید. اگر هم‌زمان به هر دو نیاز دارید، هر دو خصوصیت را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

صادرات HTML می‌تواند تصاویر اسلاید را فشرده کند تا اندازه خروجی کاهش یابد. وقتی به کیفیت تصویر بالاتر نیاز دارید، `pictures_compression` را به مقداری از [PicturesCompression](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/picturescompression/) تنظیم کنید.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

به‌صورت پیش‌فرض، نواحی برش‌خورده تصویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط زمانی نگه‌دارید که کاربران باید قادر به بازیابی یا بررسی این قسمت‌های مخفی تصویر باشند. نگه‌داری آن می‌تواند اندازه HTML را افزایش دهد.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **افزودن CSS**

برای استایل‌گذاری ساده، یک رشته CSS را به [HtmlFormatter](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmlformatter/) پاس دهید. این کار سند HTML پیرامونی را تغییر می‌دهد در حالی که Aspose.Slides به رندر محتوای اسلاید ادامه می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

برای افزودن سرصفحه سفارشی سند، یک فایل CSS پیوندی یا نشانه‌گذاری سفارشی اطراف اسلایدها و شکل‌ها، از یک کنترل‌کننده قالب‌بندی سفارشی استفاده کنید و آن را با `create_custom_formatter` به [HtmlFormatter](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmlformatter/) پاس دهید.

## **جاسازی قلم‌ها**

اگر محیط هدف ممکن است قلم‌های ارائه را نصب نداشته باشد، قلم‌ها را با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/embedallfontshtmlcontroller/) در HTML جاسازی کنید. جاسازی کیفیت بصری را بهبود می‌بخشد اما اندازه خروجی را افزایش می‌دهد.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

یک قلم را فقط وقتی حذف کنید که مطمئن باشید مرورگرها یا سیستم‌های هدف آن را در اختیار دارند. برای قلم‌های برندی یا کمتر شایع، معمولاً جاسازی امن‌تر است.

## **پیوند فایل‌های قلم به‌جای جاسازی آن‌ها**

برای کاهش اندازه فایل HTML، می‌توانید داده‌های قلم را در فایل‌های WOFF جداگانه بنویسید و قوانین `@font-face` را به HTML اضافه کنید. این کار نیاز به یک کنترل‌کننده دارد که نحوه نوشتن داده‌های قلم را در هنگام صادرات سفارشی‌سازی کند. در Python از طریق .NET، این کنترل‌کننده را در یک اسمبلی کمکی .NET کوچک پیاده‌سازی کنید، در Python بارگذاری کنید و شیء کمکی را با `create_custom_formatter` به [HtmlFormatter](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmlformatter/) پاس دهید.

هنگام استخراج قلم‌ها به‌صورت خارجی، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی در سیستم فایل که فایل‌های WOFF تولید شده در آن نوشته می‌شود.
- مسیر URL که در سند HTML ظاهر می‌شود و مرورگر برای بارگذاری آن فایل‌های قلم از آن استفاده می‌کند.

فایل HTML و فایل‌های قلم تولید شده را تا زمان نهایی شدن مسیرهای استقرار همراه نگه‌دارید. اگر فایل‌ها به مکان دیگری استقرار پیدا کردند، پیشوند URL را طوری تنظیم کنید که با مسیر URL استقرار منطبق باشد.

## **ذخیره منابع به‌صورت خارجی**

HTML خودمستقل جابجایی آسانی دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامه شما به فایل‌های تصویر، قلم، صدا یا ویدئوی خارجی نیاز دارد، یک کنترل‌کننده لینک/جاسازی سفارشی استفاده کنید و آن را به سازنده [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) پاس دهید.

هنگام استخراج منابع به‌صورت خارجی، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی در سیستم فایل که برنامه شما تصویرها، قلم‌ها، صداها یا ویدئوهای تولید شده را در آن می‌نویسد.
- مسیر URL که مرورگر از سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

برای بحث کامل درباره لینک‌کردن تصویرها، به [Export Presentations to HTML with Externally Linked Images](/slides/fa/python-net/exporting-presentations-to-html-with-externally-linked-images/) مراجعه کنید.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/videoplayerhtmlcontroller/) فایل‌های ویدئو و صدا را صادر می‌کند و HTMLی می‌نویسد که می‌تواند آنها را در مرورگر پخش کند. سازنده آن شامل:

- `path`: دایرکتوری که فایل‌های رسانه‌ای تولید شده در آن نوشته می‌شوند.
- `file_name`: نام فایل HTML که تولید می‌شود.
- `base_uri`: پیشوند URI مطلق مورد استفاده در لینک‌های HTML به فایل‌های رسانه‌ای.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به دایرکتوری رسانه‌ها در دیسک اشاره کند، در حالی که `base_uri` باید همان مسیر را از دید مرورگر نشان دهد. برای پیش‌نمایش محلی می‌توانید یک URI `file:///` از دایرکتوری رسانه‌ها بسازید. برای برنامه مستقر، از URL مطلق پوشه رسانه‌های منتشر شده استفاده کنید.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

از مسیرهای خروجی که برای هر کار صادراتی منحصربه‌فرد هستند استفاده کنید، به‌ویژه در برنامه‌های سروری. مسیرهای خروجی مشترک می‌توانند باعث نوشتن روی فایل‌های تبدیل‌های مختلف شوند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر DPI بالاتر در `pictures_compression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه‌داری نواحی برش‌خورده می‌توانند دقت را ارتقا دهند ولی معمولاً اندازه خروجی را افزایش می‌دهند.

برای تبدیل دسته‌ای:

- هر نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را به‌سرعت آزاد کنید.
- برای کارهای مختلف از مسیرهای خروجی جداگانه استفاده کنید.
- قلم‌های رایج را مگر آنکه دقت نیاز داشته باشد، جاسازی نکنید.
- DPI تصویر را وقتی HTML برای پیش‌نمایش یا تصاویر بندانگشتی است، کاهش دهید.
- ارائه منبع، HTML تولید شده و منابع خارجی را تا زمان نهایی شدن مسیرهای استقرار همراه نگه‌دارید.

## **سؤالات متداول**

**آیا پیوندهای فرا‌نشی در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ارائه به HTML صادر می‌شوند و وقتی URL هدف معتبر باشد، قابل کلیک هستند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های متفاوت را با نمونه‌های ارائه جداگانه، جریان‌های جداگانه و مسیرهای خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمای چندنخی](/slides/fa/python-net/multithreading/) مراجعه کنید.

**آیا شیء Presentation ایمن برای استفاده در چند رشته است؟**

خیر. یک نمونه [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) باید در یک رشته بارگذاری، تغییر، ذخیره و آزاد شود. برای کار موازی، یک نمونه مستقل برای هر رشته یا فرآیند ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را به‌صورت مستقیم در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه‌داری نواحی برش‌خورده تصویر نیز اندازه را افزایش می‌دهند. از منابع خارجی استفاده کنید، قلم‌های رایج را از جاسازی حذف کنید و `pictures_compression` را وقتی خروجی کوچکتر مهم‌تر از حداکثر دقت است، کاهش دهید.

**چرا اندازه قلم PowerPoint مانند 24 pt در HTML به‌صورت 17.999819 pt نمایش داده می‌شود؟**

این به‌دلیل استفاده از مدل‌های DPI متفاوت بین PowerPoint و HTML است. PowerPoint اندازه متن را بر پایهٔ نقاط تایپوگرافی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایهٔ پیکسل‌های CSS با مدل 96 DPI است. هنگام تبدیل، اندازه قلم بین این دو سیستم ترجمه می‌شود و ممکن است اختلاف گرد کردن کوچکی ایجاد شود.

این مقادیر نشان‌دهندهٔ تغییر واقعی در اندازه ظاهری قلم نیستند؛ تنها اثر جانبی ریاضی تبدیل معیارهای متنی بین PowerPoint و HTML هستند.

**چگونه باید base_uri را برای صادرات رسانه‌ها انتخاب کنم؟**

`base_uri` را از دید مرورگر انتخاب کنید و به‌عنوان URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از مسیر خروجی با `Path(media_directory).as_uri() + "/"` استخراج کنید. برای استقرار، از URL مطلق پوشه رسانه‌های منتشر شده استفاده کنید. مسیر سیستم‌فایلی `path` و `base_uri` مرورگر نیازی به داشتن همان رشته ندارند، اما باید به همان مکان منبع اشاره کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل کنم؟**

بله. زمانی که اسلایدهای مخفی باید صادر شوند، `show_hidden_slides = True` را بر روی [HtmlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/htmloptions/) تنظیم کنید.