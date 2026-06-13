---
title: تبدیل ارائه‌ها به HTML5 در پایتون
linktitle: صادرات به HTML5
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
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- صادرات HTML5
- صادرات ارائه
- صادرات اسلاید
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای پایتون از طریق .NET. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی، و همچنین گزینه‌های کنترل انیمیشن‌های شکل و انتقال اسلاید را پوشش می‌دهد. همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، نحوه تولید خروجی HTML5 در حالت نمایش اسلاید را توضیح می‌دهد و نشان می‌دهد چگونه می‌توانید با پیکربندی چیدمان آن‌ها، نظرات را در سند صادر شده گنجانید.

## **صادرات PowerPoint به HTML5**

این کد پایتون نشان می‌دهد که چگونه یک ارائه را بدون افزونه‌های وب و وابستگی‌ها به HTML5 صادر کنید:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 
در این حالت، HTML تمیز دریافت می‌کنید. 
{{% /alert %}}

اگر می‌خواهید تنظیمات انیمیشن‌های شکل و انتقال اسلاید را به این روش مشخص کنید:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **صادرات PowerPoint به HTML**

این کد پایتون فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
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

{{% alert title="Note" color="warning" %}} 
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG، نمی‌توانید استایل‌ها را اعمال کنید یا عناصر خاص را انیمیت کنید. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید نمایش داده می‌شوند. در این حالت، وقتی فایل HTML5 تولید شده را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید روی یک صفحه وب می‌بینید. 

این کد پایتون فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # صادرات ارائه‌ای شامل انتقال اسلایدها، انیمیشن‌ها و انیمیشن شکل‌ها به HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # ذخیرهٔ ارائه
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت یا بازخوردی بر روی اسلایدهای ارائه بگذارند. آن‌ها به‌ویژه در پروژه‌های مشترک مفید هستند، جایی که چندین نفر می‌توانند پیشنهادات یا توضیحات خود را به عناصر خاص اسلاید اضافه کنند بدون این‌که محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد، که پیگیری اینکه چه کسی نظر را گذاشت را آسان می‌کند.

فرض کنید یک ارائه PowerPoint به نام فایل "sample.pptx" داریم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

زمانی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به‌سادگی تعیین کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، باید پارامترهای نمایش نظرات را در خصوصیت `notes_comments_layouting` از کلاس [Html5Options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات به‌صورت راست‌چین نسبت به اسلایدها نمایش داده می‌شوند.
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های شیء و انتقال‌های اسلاید در HTML5 اجرا شوند؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال‌سازی [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_shapes/) و [انتقال‌های اسلاید](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_transitions/) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، می‌توان نظرات را در HTML5 اضافه کرد و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/notes_comments_layouting/) برای یادداشت‌ها و نظرات، آن‌ها را (مثلاً به سمت راست اسلاید) موقعیت‌دهی کرد.

**آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند برای دلایل امنیتی یا CSP حذف کنم؟**

بله، یک [تنظیم](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/skip_java_script_links/) وجود دارد که به شما امکان می‌دهد در زمان ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این کار به رعایت سیاست‌های امنیتی سخت کمک می‌کند.