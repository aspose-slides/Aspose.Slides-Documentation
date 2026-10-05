---
title: تبدیل ارائه‌ها به HTML5 در جاوااسکریپت
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/nodejs-java/export-to-html5/
keywords:
- PowerPoint به HTML5
- OpenDocument به HTML5
- ارائه به HTML5
- اسلاید به HTML5
- PPT به HTML5
- PPTX به HTML5
- ODP به HTML5
- ذخیره PPT به HTML5
- ذخیره PPTX به HTML5
- ذخیره ODP به HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای Node.js. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides برای Node.js از طریق Java به HTML5 تبدیل کنید. این مقاله استخراج پایه، کنترل انیمیشن‌های شکل و انتقال اسلایدها، و چیدمان نظرات را پوشش می‌دهد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG در خروجی استاندارد HTML مقایسه می‌کند.

## **صادرات PowerPoint به HTML5**

مثال زیر یک ارائه را از پوشه کاری بارگذاری کرده و آن را در قالب HTML5 ذخیره می‌کند. این مثال از تنظیمات پیش‌فرض صادرات استفاده می‌کند؛ مثال بعدی نشان می‌دهد که چگونه پخش انیمیشن را به‌صورت صریح کنترل کنید. مسیر ورودی را با مسیر ارائه‌ی خود جایگزین کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
علاوه بر سند HTML، خروجی فایل‌های CSS و JavaScript پشتیبانی کننده برای استایل اسلایدها، انیمیشن‌ها، افکت‌ها و ناوبری می‌نویسد. این فایل‌ها را همراه با سند HTML هنگام جابجایی یا انتشار خروجی نگه دارید. صفحه‌ی تولید شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آن‌ها، ناوبری اسلایدها و انیمیشن‌ها کار نمی‌کنند.
{{% /alert %}}

برای خروجی گرفتن بدون پخش انیمیشن‌های شکل یا انتقال اسلایدها، مقدار `false` را به [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) در [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) پاس دهید. این تنظیمات مستقل هستند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. مثال ارائه را با هر دو نوع انیمیشن غیرفعال در صفحه‌ی تولید شده صادر می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **صادرات PowerPoint به HTML**

صادرات استاندارد HTML از روش رندرینگ متفاوتی استفاده می‌کند: محتوای اسلاید با SVG داخل یک صفحه HTML نمایش داده می‌شود. مثال زیر یک ارائه را با استفاده از این روش رندرینگ به سند HTML تبدیل می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

نشانه‌گذاری ساده‌سازی شده زیر ساختار صفحه‌ی تولید شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن جایگزین محتوا را نشان می‌دهد و خروجی واقعی صادرات نیست.

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
صادرات مبتنی بر SVG اشکال PowerPoint را به‌عنوان عناصر جداگانه HTML نمایش نمی‌دهد. وقتی به گزینه‌های انیمیشن شکل و انتقال اسلاید که در این مقاله نشان داده شده‌اند نیاز دارید، از صادرات HTML5 استفاده کنید.
{{% /alert %}}

## **صادرات PowerPoint به نمایش اسلاید HTML5**

صادرات HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال هر دو [setAnimateShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و [setAnimateTransitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) را فعال می‌کند تا نمای اسلاید صادر شده بتواند افکت‌های ارائه منبع را پخش کند.

از ارائه‌ای استفاده کنید که قبلاً شامل انیمیشن‌های شکل و انتقال اسلاید باشد تا اثر این تنظیمات را ببینید. فعال‌سازی آن‌ها اثر جدیدی به اسلایدهایی که هیچ‌کدام ندارند اضافه نمی‌کند. پس از خروجی، سند HTML5 تولید شده را در مرورگری که فایل‌های پشتیبانی آن در دسترس هستند باز کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

می‌توانید نظرات موجود اسلاید را در خروجی HTML5 گنجانید تا خوانندگان بتوانند بازخورد را همراه با محتوای اسلاید ببینند. مثال در این بخش انتظار دارد که ارائه منبع شامل نظرات باشد، همان‌طور که در زیر نشان داده شده است. این نظرات را صادر می‌کند؛ نظرات جدیدی ایجاد نمی‌کند.

![دو نظر در اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) را به متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) از [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) پاس دهید. از [setCommentsPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) برای انتخاب `Right` از enumeration [CommentsPositions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentspositions/) استفاده کنید تا نظرات را در سمت راست هر اسلاید قرار دهید.

مثال زیر ارائه را با این چیدمان نظر به HTML5 صادر می‌کند. ارائه‌ای بدون نظرات متن نظری برای نمایش نخواهد داشت.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);

const html5Options = new aspose.slides.Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

تصویر زیر سند HTML5 صادر شده را نشان می‌دهد که نظرات در کنار اسلاید نمایش داده شده‌اند.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **حذف پیوندهای JavaScript هنگام خروجی**

فرض کنید `hyperlinks.pptx` شامل متنی پیوندی با هدف `javascript:alert('Hello')` و یک پیوند عادی `https://example.com/` باشد. برای حذف پیوند JavaScript هنگام خروجی، مقدار `true` را به [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) پاس دهید. مقدار پیش‌فرض `false` است، بنابراین این پیوندها فیلتر نمی‌شوند مگر اینکه گزینه را فعال کنید.

مثال زیر ارائه را از پوشه کاری بارگذاری کرده و با استفاده از [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) صادر می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const html5Options = new aspose.slides.Html5Options();
html5Options.setSkipJavaScriptLinks(true);

const presentation = new aspose.slides.Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

فایل صادر شده پیوند JavaScript را حذف می‌کند در حالی که متن آن و پیوند عادی HTTPS را حفظ می‌کند. ارائه منبع بدون تغییر باقی می‌ماند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ تمام اسکریپت‌ها یا دیگر محتوای فعال را حذف نمی‌کند و همچنین تضمین‌کننده‌ی سازگاری با CSP نیست. برای مثال، خروجی HTML5 هنوز اسکریپت‌هایی برای ناوبری اسلاید و انیمیشن‌ها شامل می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال اسلایدها در HTML5 پخش شوند؟**  
بله، خروجی HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateShapes-boolean-) و [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**  
بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شوند و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setSlidesLayoutOptions-aspose.slides.ISlidesLayoutOptions-) به‌عنوان مثال به سمت راست اسلاید موقعیت‌یابی شوند.

**آیا می‌توانم پیوندهایی که JavaScript را فراخوانی می‌کنند برای امنیت یا دلایل CSP حذف کنم؟**  
بله، تنظیم [setSkipJavaScriptLinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) به شما اجازه می‌دهد تا پیوندهای حاوی فراخوانی JavaScript را هنگام ذخیره‌سازی نادیده بگیرید. مقدار پیش‌فرض `false` است. برای مثال خروجی HTML5 و دامنه فیلتر، به [حذف پیوندهای JavaScript هنگام خروجی](/slides/fa/nodejs-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) مراجعه کنید. این تنظیم JavaScript مورد استفاده در نمایشگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.