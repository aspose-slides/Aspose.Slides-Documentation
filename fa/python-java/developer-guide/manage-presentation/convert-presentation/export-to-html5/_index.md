---
title: تبدیل ارائه‌ها به HTML5 در پایتون از طریق جاوا
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/python-java/export-to-html5/
keywords:
- PowerPoint به HTML5
- OpenDocument به HTML5
- ارائه به HTML5
- اسلاید به HTML5
- PPT به HTML5
- PPTX به HTML5
- ODP به HTML5
- ذخیره PPT به صورت HTML5
- ذخیره PPTX به صورت HTML5
- ذخیره ODP به صورت HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- پایتون
- جاوا
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را به HTML5 واکنش‌گرا با Aspose.Slides برای پایتون از طریق جاوا صادر کنید. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ می‌کند."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides for Python via Java به HTML5 تبدیل کنید. این مقاله صادرات اصلی، کنترل انیمیشن‌های شکل و انتقال اسلایدها و طرح‌بندی نظرات را پوشش می‌دهد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG صادرات استاندارد HTML مقایسه می‌کند.

نمونه‌ها به Aspose.Slides for Python via Java و یک ران‌تایم جاوا سازگار نیاز دارند. ارائه‌های ورودی را در پوشه کاری فعلی قرار دهید. هر نمونه JVM را فقط در صورتی که قبلاً در حال اجرا نباشد، راه‌اندازی می‌کند.

## **صادرات PowerPoint به HTML5**

مثال زیر یک ارائه را از پوشه کاری بارگذاری کرده و در قالب HTML5 ذخیره می‌کند. این مثال از تنظیمات پیش‌فرض صادرات استفاده می‌کند؛ مثال بعدی نشان می‌دهد چگونه پخش انیمیشن را به‌طور صریح کنترل کنید. مسیر ورودی را با مسیر ارائه خود جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
علاوه بر سند HTML، صادرات فایل‌های CSS و JavaScript پشتیبانی‌کننده برای استایل اسلایدها، انیمیشن‌ها، افکت‌ها و ناوبری را می‌نویسد. این فایل‌ها را همراه سند HTML هنگام جابجایی یا انتشار خروجی نگه دارید. صفحه تولید شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آن‌ها ناوبری اسلاید و انیمیشن‌ها اجرا نمی‌شوند.
{{% /alert %}}

برای خروجی گرفتن بدون پخش انیمیشن‌های شکل یا انتقال اسلایدها، مقدار `False` را به [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) در [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) پاس دهید. این تنظیمات مستقل‌اند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. نمونه ارائه را با هر دو نوع انیمیشن غیرفعال شده در صفحه تولیدی صادر می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **صادرات PowerPoint به HTML**

استاندارد صادرات HTML از رویکرد رندر متفاوتی استفاده می‌کند: محتوای اسلاید به‌صورت SVG در داخل صفحه HTML نمایش داده می‌شود. مثال زیر یک ارائه را با استفاده از این رویکرد به سند HTML تبدیل می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

مارکاپ ساده‌شده زیر ساختار صفحه تولید شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن نگهدارنده بیانگر آن محتواست و خروجی واقعی صادرات نیست.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
صادرات مبتنی بر SVG اشکال PowerPoint را به‌عنوان عناصر HTML جداگانه در دسترس قرار نمی‌دهد. زمانی که به گزینه‌های انیمیشن شکل و انتقال اسلاید که در این مقاله نشان داده شده نیاز دارید، از صادرات HTML5 استفاده کنید.
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

صادرات HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال هر دو [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) را فعال می‌کند تا نمای اسلاید صادر شده بتواند افکت‌های ارائه منبع را پخش کند.

از ارائه‌ای استفاده کنید که از پیش شامل انیمیشن‌های شکل و انتقال اسلاید باشد تا اثر این تنظیمات را ببینید. فعال کردن آن‌ها افکت جدیدی به اسلایدهایی که هیچ افکتی ندارند اضافه نمی‌کند. پس از صادرات، سند HTML5 تولید شده را با مرورگری که فایل‌های پشتیبانی‌کننده در دسترس هستند باز کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تبدیل ارائه به سند HTML5 با نظرات**

می‌توانید نظرات موجود در اسلایدها را در خروجی HTML5 گنجانده تا خوانندگان بازخورد را در کنار محتوای اسلاید مشاهده کنند. مثال در این بخش انتظار دارد ارائه منبع شامل نظرات باشد، همان‌طور که در ادامه نشان داده شده است. این مثال آن نظرات را صادر می‌کند؛ نظرات جدیدی ایجاد نمی‌کند.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) را به متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) از کلاس [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) پاس دهید. از [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) برای انتخاب `Right` از شمارنده [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) استفاده کنید تا نظرات در سمت راست هر اسلاید قرار گیرند.

مثال زیر ارائه را با این طرح‌بندی نظرات به HTML5 صادر می‌کند. ارائه‌ای بدون نظرات متنی برای نمایش نخواهد داشت.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

تصویر زیر سند HTML5 صادر شده را با نظراتی که در کنار اسلاید نمایش داده می‌شوند نشان می‌دهد.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **حذف پیوندهای JavaScript هنگام صادرات**

فرض کنید `hyperlinks.pptx` شامل متن پیوندی با هدف `javascript:alert('Hello')` و یک پیوند عادی `https://example.com/` باشد. برای حذف پیوند JavaScript هنگام صادرات، مقدار `True` را به [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) پاس دهید. مقدار پیش‌فرض `False` است، بنابراین این پیوندها فیلتر نمی‌شوند مگر اینکه گزینه را فعال کنید.

مثال زیر ارائه را از پوشه کاری بارگذاری کرده و با استفاده از [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) صادر می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

فایل صادر شده پیوند JavaScript را حذف می‌کند در حالی که متن آن و پیوند HTTPS عادی حفظ می‌شوند. ارائه منبع بدون تغییر می‌ماند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ تمام اسکریپت‌ها یا سایر محتواهای فعال را حذف نمی‌کند و همچنین تضمینی برای رعایت CSP نیست. به‌عنوان مثال، خروجی HTML5 همچنان شامل اسکریپت‌های ناوبری اسلاید و انیمیشن‌ها است.

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیا و انتقال اسلایدها در HTML5 اجرا شوند یا نه؟**

بله، صادرات HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) و [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید در چه موقعیتی قرار داد؟**

بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شوند و از طریق [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) (مثلاً به سمت راست اسلاید) موقعیت‌یابی شوند.

**آیا می‌توانم پیوندهایی که جاوااسکریپت فراخوانی می‌کنند به دلایل امنیتی یا CSP حذف کنم؟**

بله، تنظیم [setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) به شما امکان می‌دهد هنگام ذخیره‌سازی پیوندهای دارای فراخوانی‌های JavaScript را نادیده بگیرید. مقدار پیش‌فرض `False` است. برای مثال یک نمونه صادرات HTML5 و دامنه فیلتر را در [حذف پیوندهای JavaScript هنگام صادرات](/slides/fa/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) ببینید. این تنظیم اسکریپت‌های استفاده‌شده توسط نمایشگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.