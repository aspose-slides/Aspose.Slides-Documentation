---
title: تبدیل ارائه‌ها به HTML5 در .NET
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای .NET. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides for .NET به HTML5 تبدیل کنید. این مقاله به صادرات پایه، کنترل انیمیشن‌های اشکال و انتقالات اسلاید، و چیدمان نظرات می‌پردازد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG صادرات استاندارد HTML مقایسه می‌کند.

## **صادرات PowerPoint به HTML5**

مثال زیر یک ارائه را از دایرکتوری کاری بارگذاری می‌کند و به فرمت HTML5 ذخیره می‌نماید. این مثال از تنظیمات پیش‌فرض صادرات استفاده می‌کند؛ مثال بعدی نشان می‌دهد چگونه پخش انیمیشن را به‌صورت صریح کنترل کنید. مسیر ورودی را با مسیر ارائه خود جایگزین کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="Note" %}}
علاوه بر سند HTML، صادرات فایل‌های CSS و JavaScript پشتیبان برای استایل اسلاید، انیمیشن‌ها، افکت‌ها و ناوبری می‌نویسد. این فایل‌ها را همراه سند HTML هنگام جابه‌جایی یا انتشار خروجی نگه دارید. صفحه تولید‌شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آنها ناوبری اسلاید و انیمیشن‌ها اجرا نمی‌شوند.
{{% /alert %}}

برای صادرات بدون پخش انیمیشن‌های اشکال یا انتقالات اسلاید، [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) را در [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) به `false` تنظیم کنید. این تنظیمات مستقل هستند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. مثال زیر ارائه را با هر دو نوع انیمیشن غیرفعال در صفحه تولید‌شده صادر می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **صادرات PowerPoint به HTML**

صادرات استاندارد HTML از روش رندر متفاوتی استفاده می‌کند: محتوای اسلاید به‌صورت SVG درون یک صفحه HTML نمایش داده می‌شود. مثال زیر ارائه را به سند HTML تبدیل می‌کند با استفاده از این روش رندر.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

نحو ساده‌شده زیر ساختار صفحه تولید‌شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن جایگزین محتوای واقعی را نشان می‌دهد و خروجی صادراتی واقعی نیست.

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
صادرات مبتنی بر SVG اشکال PowerPoint را به‌عنوان عناصر HTML جداگانه در دسترس قرار نمی‌دهد. زمانی که به گزینه‌های انیمیشن شکل و انتقال اسلاید نیاز دارید، از صادرات HTML5 استفاده کنید.
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

صادرات HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال هر دو [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) را فعال می‌کند تا نمای اسلاید صادرشده بتواند اثرات را از ارائه منبع پخش کند.

از ارائه‌ای استفاده کنید که از قبل شامل انیمیشن‌های شکل و انتقالات اسلاید باشد تا اثر این تنظیمات را ببینید. فعال‌سازی آن‌ها اثر جدیدی به اسلایدهایی که هیچ انیمیشنی ندارند اضافه نمی‌کند. پس از صادرات، سند HTML5 تولید‌شده را در مرورگری باز کنید که فایل‌های پشتیبان آن در دسترس باشند.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **تبدیل ارائه به سند HTML5 با نظرات**

می‌توانید نظرات موجود اسلاید را در خروجی HTML5 بگنجانید تا خوانندگان بازخورد را در کنار محتوای اسلاید مشاهده کنند. مثال در این بخش انتظار دارد ارائه منبع شامل نظرات باشد، همان‌طور که در زیر نشان داده شده است. این مثال آن نظرات را صادر می‌کند؛ نظرات جدیدی ایجاد نمی‌کند.

![دو نظر روی اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) را به خصوصیت [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) از [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) اختصاص دهید. [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) را به `Right` از شمارش‌گر [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) تنظیم کنید تا نظرات در سمت راست هر اسلاید قرار گیرند.

مثال زیر ارائه را با این چیدمان نظر به HTML5 صادر می‌کند. ارائه‌ای بدون نظرات متنی برای نمایش نخواهد داشت.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **نادیده‌گرفتن پیوندهای JavaScript هنگام صادرات**

فرض کنید `hyperlinks.pptx` شامل متنی پیونددار با هدف `javascript:alert('Hello')` و یک پیوند معمولی `https://example.com/` باشد. برای نادیده‌گرفتن پیوند JavaScript هنگام صادرات، [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) را به `true` تنظیم کنید. مقدار پیش‌فرض `false` است، بنابراین این پیوندها تا وقتی گزینه فعال نشود فیلتر نمی‌شوند.

مثال زیر ارائه را از دایرکتوری کاری بارگذاری می‌کند و با استفاده از [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) صادر می‌نماید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

فایل صادرشده پیوند JavaScript را حذف می‌کند اما متن آن و پیوند HTTPS معمولی را حفظ می‌کند. ارائه منبع دست نخورده می‌ماند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ تمام اسکریپت‌ها یا سایر محتوای فعال را حذف نمی‌کند و تضمینی برای سازگاری با CSP نمی‌دهد. برای مثال، خروجی HTML5 هنوز شامل اسکریپت‌های ناوبری اسلاید و انیمیشن‌هاست.

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقالات اسلاید در HTML5 اجرا شوند یا نه؟**

بله، صادرات HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شوند و از طریق [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) برای یادداشت‌ها و نظرات، به‌عنوان مثال در سمت راست اسلاید، موقعیت‌یابی شوند.

**آیا می‌توانم پیوندهایی که JavaScript فراخوانی می‌کنند را برای امنیت یا دلایل CSP صرف‌نظر کنم؟**

بله، تنظیم [SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) به شما امکان می‌دهد هنگام ذخیره‌سازی پیوندهای دارای فراخوانی JavaScript را نادیده بگیرید. مقدار پیش‌فرض `false` است. برای مثال ساده HTML، HTML5 و PDF به [نادیده‌گرفتن پیوندهای JavaScript هنگام صادرات](/slides/fa/net/export-to-html5/#exclude-javascript-hyperlinks-during-export) مراجعه کنید تا دامنه فیلتر را ببینید. این تنظیم JavaScript مورد استفاده در مرورگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.