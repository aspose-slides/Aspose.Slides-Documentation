---
title: تبدیل ارائه‌ها به HTML5 در پایتون
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/python-net/export-to-html5/
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
- صادر کردن PPT به HTML5
- صادر کردن PPTX به HTML5
- صادر کردن ODP به HTML5
- پایتون
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را به HTML5 واکنش‌گرا با Aspose.Slides برای پایتون از طریق .NET صادر کنید. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides برای Python از طریق .NET به HTML5 تبدیل کنید. این مقاله به خروجی‌گیری پایه، کنترل انیمیشن‌های اشکال و انتقال‌های اسلاید، و چیدمان نظرات می‌پردازد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG که در خروجی HTML استاندارد استفاده می‌شود، مقایسه می‌کند.

## **صادر کردن PowerPoint به HTML5**

مثال زیر یک ارائه را از دایرکتوری کاری بارگذاری می‌کند و آن را در قالب HTML5 ذخیره می‌سازد. این مثال از تنظیمات پیش‌فرض خروجی استفاده می‌کند؛ مثال بعدی نشان می‌دهد چگونه پخش انیمیشن را به‌صورت صریح کنترل کنیم. مسیر ورودی را با مسیر ارائه خود جایگزین کنید.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
علاوه بر سند HTML، خروجی فایل‌های CSS و JavaScript پشتیبانی‌کننده برای استایل اسلایدها، انیمیشن‌ها، افکت‌ها و ناوبری می‌نویسد. هنگام جابه‌جایی یا انتشار خروجی این فایل‌ها را همراه سند HTML نگه دارید. صفحه تولید شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آن‌ها، ناوبری و انیمیشن‌های اسلاید اجرا نمی‌شوند.
{{% /alert %}}

برای خروجی گرفتن بدون پخش انیمیشن‌های اشکال یا انتقال‌های اسلاید، مقادیر [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) را در [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) به `False` تنظیم کنید. این تنظیمات مستقل هستند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. مثال ارائه را با هر دو نوع انیمیشن غیرفعال‌شده در صفحه تولید شده خروجی می‌گیرد.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **صادر کردن PowerPoint به HTML**

خروجی استاندارد HTML از رویکرد رندرینگ متفاوتی استفاده می‌کند: محتوای اسلاید توسط SVG درون یک صفحه HTML نمایش داده می‌شود. مثال زیر یک ارائه را با استفاده از این رویکرد رندرینگ به سند HTML تبدیل می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

نشان‌گذاری ساده‌شده زیر ساختار صفحه تولید شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن نگهدارنده نشان‌دهنده آن محتواست و خروجی واقعی صادرات نیست.

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
خروجی مبتنی بر SVG اشکال PowerPoint را به عنوان عناصر HTML جداگانه عرضه نمی‌کند. زمانی که به گزینه‌های انیمیشن اشکال و انتقال اسلاید که در این مقاله نشان داده شده نیاز دارید، از خروجی HTML5 استفاده کنید.
{{% /alert %}}

## **صادر کردن PowerPoint به نمای اسلاید HTML5**

خروجی HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال هر دو [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) را فعال می‌کند تا نمای اسلاید خروجی بتواند افکت‌های موجود در ارائه منبع را پخش کند.

از ارائه‌ای استفاده کنید که قبلاً شامل انیمیشن‌های اشکال و انتقال‌های اسلاید باشد تا تأثیر این تنظیمات را ببینید. فعال‌سازی آنها اثر جدیدی به اسلایدهایی که هیچ‌یک ندارند اضافه نمی‌کند. پس از خروجی گرفتن، سند HTML5 تولید شده را در مرورگری که فایل‌های پشتیبانی آن در دسترس هستند باز کنید.

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

می‌توانید نظرات موجود در اسلایدها را در خروجی HTML5 گنجانده تا خوانندگان بازخورد را در کنار محتوای اسلاید مشاهده کنند. مثال در این بخش انتظار دارد که ارائه منبع شامل نظرات باشد، همان‌طور که در ادامه نشان داده شده است. این مثال نظرات را خروجی می‌گیرد؛ نظرات جدیدی ایجاد نمی‌کند.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) به ویژگی [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) از [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) اختصاص دهید. مقدار [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) را از شمارش‌گر [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) به `RIGHT` تنظیم کنید تا نظرات در سمت راست هر اسلاید قرار گیرند.

مثال زیر ارائه را با این چیدمان نظرات به HTML5 خروجی می‌گیرد. ارائه‌ای که نظری نداشته باشد، متن نظری برای نمایش نخواهد داشت.

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

تصویر زیر سند HTML5 خروجی شده را نشان می‌دهد که نظرات در کنار اسلاید نمایش داده شده‌اند.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **به‌جز کردن پیوندهای JavaScript هنگام خروجی‌گیری**

فرض کنید `hyperlinks.pptx` متنی پیوست شده داشته باشد که هدف آن `javascript:alert('Hello')` باشد و همچنین یک پیوند معمولی `https://example.com/`. برای به‌جز کردن پیوند JavaScript هنگام خروجی‌گیری، مقدار [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) را به `True` تنظیم کنید. پیش‌فرض `False` است، بنابراین این پیوندها فیلتر نمی‌شوند مگر اینکه گزینه را فعال کنید.

مثال زیر ارائه را از دایرکتوری کاری بارگذاری کرده و با استفاده از [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) خروجی می‌گیرد:

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

فایل خروجی پیوند JavaScript را حذف می‌کند اما متن آن و پیوند HTTPS معمولی را حفظ می‌کند. ارائه منبع بدون تغییر باقی می‌ماند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ همه اسکریپت‌ها یا سایر محتوای فعال را حذف نمی‌کند و همچنین تضمین‌کننده تطابق با CSP نیست. برای مثال، خروجی HTML5 همچنان شامل اسکریپت‌هایی برای ناوبری اسلاید و انیمیشن‌ها است.

## **سؤال‌های متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال‌های اسلاید در HTML5 پخش شوند یا نه؟**

بله، خروجی HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید در چه موقعیتی قرار داد؟**

بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شوند و از طریق [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) موقعیت‌دهی شوند (برای مثال، به سمت راست اسلاید).

**آیا می‌توانم پیوندهایی که JavaScript را فراخوانی می‌کنند برای امنیت یا دلایل CSP حذف کنم؟**

بله، تنظیم [skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) به شما اجازه می‌دهد هنگام ذخیره‌سازی پیوندهایی که فراخوانی JavaScript دارند را نادیده بگیرید. پیش‌فرض `False` است. برای مثال خروجی HTML5 و دامنه فیلتر، به [Exclude JavaScript Hyperlinks During Export](/slides/fa/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) مراجعه کنید. این تنظیم JavaScript مورد استفاده در نمایشگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.