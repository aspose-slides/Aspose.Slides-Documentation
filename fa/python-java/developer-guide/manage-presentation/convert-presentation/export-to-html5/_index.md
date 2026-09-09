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
- صدور PPT به HTML5
- صدور PPTX به HTML5
- صدور ODP به HTML5
- پایتون
- جاوا
- Aspose.Slides
description: "صادر کردن ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای پایتون از طریق جاوا. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله صادرات پایه HTML5 را بدون افزونه‌های وب اضافی، گزینه‌های کنترل انیمیشن شکل‌ها و انتقال اسلایدها را پوشش می‌دهد. همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد که چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید و نشان می‌دهد که چگونه می‌توانید نظرات را در سند صادر شده با پیکربندی چیدمان آن‌ها درج کنید.

مثال‌ها نیاز به Aspose.Slides for Python via Java و یک زمان‌اجرای Java سازگار دارند. فایل `pres.pptx` (یا `sample.pptx` برای مثال نظرات) را در پوشه کاری جاری قرار دهید. هر مثال JVM را فقط در صورتی که قبلاً در حال اجرا نباشد، راه‌اندازی می‌کند.

## **صادر کردن پاورپوینت به HTML5**

از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) همراه با [SaveFormat.Html5](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/#Html5) برای صادرات یک ارائه بدون افزونه‌های وب اضافی استفاده کنید:

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
صادرکننده HTML5 محتوای HTML را برای مشاهده در مرورگر ایجاد می‌کند. 
{{% /alert %}}

از [Html5Options](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/) برای پیکربندی صادرات استفاده کنید. با فراخوانی [setAnimateShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) و [setAnimateTransitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) با مقدار `False` می‌توانید انیمیشن شکل‌ها و انتقال اسلایدها را غیرفعال کنید:

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

## **صادر کردن پاورپوینت به HTML**

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

در این حالت، محتوای ارائه از طریق SVG به شکل زیر رندر می‌شود:

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
صادرات استاندارد HTML محتوا را از طریق SVG رندر می‌کند و گزینه‌های انیمیشن شکل‌ها و انتقال اسلایدهای HTML5 را فراهم نمی‌کند. 
{{% /alert %}}

## **صادر کردن پاورپوینت به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید نمایش داده می‌شوند. در این حالت، هنگامی که فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را به صورت نمای اسلاید در یک صفحه وب می‌بینید. 

این کد Python فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

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

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت‌ها یا بازخوردهای خود را روی اسلایدهای ارائه بگذارند. این ویژگی بویژه در پروژه‌های مشارکتی مفید است، جایی که افراد مختلف می‌توانند پیشنهادات یا توضیحاتی را به عناصر خاص اسلاید اضافه کنند بدون این‌که محتوای اصلی تغییر کند. هر نظر نام نویسنده را نشان می‌دهد، که ردیابی منبع نظر را آسان می‌کند.

فرض کنیم ارائه PowerPoint زیر در فایل «sample.pptx» ذخیره شده باشد.

![دو نظر در اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به سادگی تعیین کنید آیا نظرات ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، پارامترهای نمایش نظرات را به متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) از کلاس [Html5Options](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/) پاس دهید.

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) و [setCommentsPosition](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) همراه با [CommentsPositions.Right](https://reference.aspose.com/slides/fa/python-java/aspose.slides/commentspositions/#Right) استفاده کنید. مثال کد زیر یک ارائه را به سند HTML5 با نظرات نمایش داده شده در سمت راست اسلایدها تبدیل می‌کند.

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

سند «output.html» در تصویر زیر نمایش داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های شیء و انتقال اسلایدها در HTML5 اجرا شوند؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) و [slide transitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) فراهم می‌کند.

**آیا می‌توان نظرات را صادر کرد و آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، می‌توانید نظرات را در HTML5 اضافه کنید و آن‌ها را (به‌عنوان مثال، در سمت راست اسلاید) از طریق [layout settings](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) برای یادداشت‌ها و نظرات موقعیت‌دهی کنید.

**آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند به دلایل امنیتی یا CSP حذف کنم؟**

بله، یک [setting](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این کار این پیوندها را حذف می‌کند؛ اما به‌تنهایی تضمین نمی‌کند که تمام اسکریپت‌های تولید شده HTML5 مطابق با سیاست امنیت محتوا (CSP) سایت باشند.