---
title: تبدیل ارائه‌ها به HTML5 در Python از طریق Java
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
- ذخیره PPT به عنوان HTML5
- ذخیره PPTX به عنوان HTML5
- ذخیره ODP به عنوان HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- پایتون
- جاوا
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای Python از طریق Java. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنیم. این مقاله صادرات پایهٔ HTML5 را بدون افزونه‌های وب اضافی پوشش می‌دهد و همچنین گزینه‌های کنترل انیمیشن‌های اشکال و انتقال اسلایدها را شرح می‌دهد. همچنین مقاله فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمایش اسلاید تولید کنیم و نشان می‌دهد چگونه با پیکربندی چیدمان، نظرات را در سند صادرشده گنجانده شود.

مثال‌ها به Aspose.Slides برای Python از طریق Java و یک محیط اجرایی Java سازگار نیاز دارند. فایل `pres.pptx` (یا `sample.pptx` برای مثال نظرات) را در پوشهٔ کاری فعلی قرار دهید. هر مثال JVM را فقط در صورتی که در حال اجرا نباشد، راه‌اندازی می‌کند.

## **صادرات PowerPoint به HTML5**

از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) با [SaveFormat.Html5](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Html5) برای صادرات ارائه‌ای بدون افزونه‌های وب اضافی استفاده کنید:

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

{{% alert color="info" title="توجه" %}} 
صادرکنندهٔ HTML5 محتوای HTML را برای نمایش در مرورگر ایجاد می‌کند. 
{{% /alert %}}

از [Html5Options](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/) برای پیکربندی صادرات استفاده کنید. با `False` بر روی [setAnimateShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) و [setAnimateTransitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) فراخوانی کنید تا انیمیشن‌های اشکال و انتقال‌های اسلاید را غیرفعال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **صادرات PowerPoint به HTML**

از [SaveFormat.Html](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Html) برای صادرات استاندارد HTML استفاده کنید. برای گزینه‌های بیشتر به [Convert PowerPoint to HTML](/slides/fa/python-java/convert-powerpoint-to-html/) مراجعه کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

در این حالت، محتویات ارائه از طریق SVG به شکل زیر رندر می‌شود:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="هشدار" color="warning" %}} 
صادرات استاندارد HTML محتواهای اسلاید را از طریق SVG رندر می‌کند و گزینه‌های انیمیشن‌ اشکال و انتقال اسلایدهای HTML5 را ارائه نمی‌دهد. 
{{% /alert %}}

## **صادرات PowerPoint به HTML5 در حالت نمایش اسلاید**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمایش اسلاید ارائه می‌شوند. در این حالت، هنگامی که فایل HTML5 تولید‌شده را در یک مرورگر باز می‌کنید، ارائه را در حالت نمایش اسلاید بر روی یک صفحه وب می‌بینید.

این کد Python فرآیند صادرات PowerPoint به نمایش اسلاید HTML5 را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **تبدیل ارائه‌ها به اسناد HTML5 با نظرات**

نظرات در PowerPoint ابزاری است که به کاربران امکان می‌دهد یادداشت یا بازخوردی بر روی اسلایدهای ارائه بگذارند. این ویژگی به‌ویژه در پروژه‌های مشترک مفید است، جایی که چندین نفر می‌توانند پیشنهادها یا نکات خود را به عناصر خاص اسلاید اضافه کنند بدون این که محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد، که پیگیری منبع نظر را آسان می‌کند.

فرض کنید ارائهٔ PowerPoint زیر را در فایل «sample.pptx» ذخیره کرده‌ایم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، به‌راحتی می‌توانید مشخص کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا خیر. برای این کار، پارامترهای نمایش نظرات را به متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) از کلاس [Html5Options](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/) پاس دهید.

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) و [setCommentsPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) با [CommentsPositions.Right](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Right) استفاده کنید. مثال کد زیر ارائه‌ای را به سند HTML5 تبدیل می‌کند که نظرات به‌صورت راست اسلایدها نمایش داده می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های اشیاء و انتقال‌های اسلاید در HTML5 اجرا شوند؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) و [انتقال‌های اسلاید](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید در کجا قرار داد؟**

بله، نظرات می‌توانند در HTML5 اضافه شوند و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) برای یادداشت‌ها و نظرات، به‌مثال به سمت راست اسلاید، موقعیت‌یابی شوند.

**آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند برای دلایل امنیتی یا CSP رد کنم؟**

بله، یک [تنظیم](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، پیوندهای ابرمتنی که شامل فراخوانی‌های JavaScript هستند را نادیده بگیرید. این کار آن پیوندها را حذف می‌کند؛ اما به‌تنهایی تضمین نمی‌کند تمام اسکریپت‌های تولید‑شدهٔ HTML5 با سیاست امنیت محتوا (CSP) سایت مطابقت داشته باشند.