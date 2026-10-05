---
title: تبدیل ارائه‌ها به HTML5 در جاوا
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/java/export-to-html5/
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
- جاوا
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای جاوا. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides for Java به HTML5 تبدیل کنید. این مقاله به صادرات پایه، کنترل انیمیشن‌های اشکال و انتقال اسلاید، و چیدمان نظرات می‌پردازد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG صادرات HTML استاندارد مقایسه می‌کند.

## **صادرات PowerPoint به HTML5**

مثال زیر یک ارائه را از پوشه کاری بارگذاری کرده و آن را در قالب HTML5 ذخیره می‌کند. این مثال از تنظیمات پیش‌فرض صادرات استفاده می‌کند؛ مثال بعدی نشان می‌دهد چگونه پخش انیمیشن‌ها را به صورت صریح کنترل کنیم. مسیر ورودی را با مسیر ارائه خود جایگزین کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="نکته" %}}
علاوه بر سند HTML، صادرات فایل‌های CSS و JavaScript پشتیبان برای استایل اسلایدها، انیمیشن‌ها، افکت‌ها و ناوبری می‌نویسد. این فایل‌ها را همراه با سند HTML هنگام انتقال یا انتشار خروجی نگه دارید. صفحه تولید شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آن‌ها ناوبری اسلاید و انیمیشن‌ها اجرا نمی‌شوند.
{{% /alert %}}

برای صادرات بدون پخش انیمیشن‌های اشکال یا انتقالات اسلاید، مقدار `false` را به [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) در [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) پاس دهید. این تنظیمات مستقلاً عمل می‌کنند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. مثال زیر ارائه را با هر دو نوع انیمیشن غیرفعال در صفحه تولید شده صادر می‌کند.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(false);
html5Options.setAnimateTransitions(false);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **صادرات PowerPoint به HTML**

صادرات استاندارد HTML از رویکرد رندرینگ متفاوتی استفاده می‌کند: محتوای اسلاید توسط SVG داخل یک صفحه HTML نمایان می‌شود. مثال زیر یک ارائه را با استفاده از این رویکرد رندرینگ به سند HTML تبدیل می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

نماد ساده‌سازی شده زیر ساختار صفحه تولید شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن جایگزین نمایانگر آن محتواست و خروجی واقعی صادرات نیست.

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
صادرات مبتنی بر SVG، اشکال PowerPoint را به عنوان عناصر HTML جداگانه در دسترس قرار نمی‌دهد. وقتی به گزینه‌های انیمیشن اشکال و انتقال اسلاید که در این مقاله نشان داده شده نیاز دارید، از صادرات HTML5 استفاده کنید.
{{% /alert %}}

## **صادرات PowerPoint به نمایش اسلاید HTML5**

صادرات HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال همزمان [setAnimateShapes](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [setAnimateTransitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) را فعال می‌کند تا نمای اسلاید صادرشده بتواند افکت‌های موجود در ارائه منبع را اجرا کند.

از ارائه‌ای استفاده کنید که قبلاً شامل انیمیشن‌های اشکال و انتقالات اسلاید باشد تا اثر این تنظیمات را ببینید. فعال‌سازی این گزینه‌ها اثر جدیدی به اسلایدهایی که هیچ انیمیشنی ندارند اضافه نمی‌کند. پس از صادرات، سند HTML5 تولید شده را در مرورگری که فایل‌های پشتیبان آن در دسترس هستند باز کنید.

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setAnimateShapes(true);
html5Options.setAnimateTransitions(true);

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

می‌توانید نظرات موجود در اسلایدها را در خروجی HTML5 گنجانید تا خوانندگان بتوانند بازخورد را در کنار محتوای اسلاید مشاهده کنند. مثال در این بخش انتظار دارد ارائه منبع شامل نظرات باشد، همان‌طور که در زیر نشان داده شده است. این مثال این نظرات را صادر می‌کند؛ نظرات جدیدی ایجاد نمی‌کند.

![دو نظر روی اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) را به متد [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) در [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) پاس دهید. با استفاده از [setCommentsPosition](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) مقدار `Right` را از شمارش‑نام [CommentsPositions](https://reference.aspose.com/slides/java/com.aspose.slides/commentspositions/) برگزینید تا نظرات در سمت راست هر اسلاید قرار گیرند.

مثال زیر ارائه را با این چیدمان نظرات به HTML5 صادر می‌کند. ارائه‌ای بدون نظرات هیچ متن نظارتی برای نمایش نخواهد داشت.

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **استثنا کردن پیوندهای JavaScript هنگام صادرات**

فرض کنید `hyperlinks.pptx` شامل متنی پیوندی با هدف `javascript:alert('Hello')` و یک پیوند عادی `https://example.com/` باشد. برای استثنا کردن پیوند JavaScript در هنگام صادرات، مقدار `true` را به [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) پاس دهید. مقدار پیش‌فرض `false` است، بنابراین این پیوندها فیلتر نمی‌شوند مگر آنکه این گزینه را فعال کنید.

مثال زیر ارائه را از پوشه کاری بارگذاری کرده و با استفاده از [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) صادر می‌کند:

```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();
html5Options.setSkipJavaScriptLinks(true);

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5Options);
} finally {
    presentation.dispose();
}
```

فایل صادرشده پیوند JavaScript را حذف می‌کند در حالی که متن آن و پیوند HTTPS عادی حفظ می‌شود. ارائه منبع دست نخورده می‌ماند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ تمام اسکریپت‌ها یا سایر محتوای فعال را حذف نمی‌کند و تضمین‌کننده انطباق با CSP نیست. برای مثال، خروجی HTML5 هنوز شامل اسکریپت‌های مورد نیاز برای ناوبری اسلاید و انیمیشن‌ها است.

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های شیء و انتقالات اسلاید در HTML5 اجرا شوند؟**

بله، صادرات HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [slide transitions](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شوند و از طریق [layout settings](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) برای یادداشت‌ها و نظرات به مکان دلخواه (مثلاً سمت راست اسلاید) قرار گیرند.

**آیا می‌توانم پیوندهایی که JavaScript فراخوانی می‌کنند را برای امنیت یا دلایل CSP حذف کنم؟**

بله، تنظیم [setSkipJavaScriptLinks](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) به شما اجازه می‌دهد که پیوندهای دارای فراخوانی JavaScript را در زمان ذخیره‌سازی نادیده بگیرید. مقدار پیش‌فرض `false` است. برای مثال یک صادرات HTML5 و محدوده فیلتر به ‎[استثنا کردن پیوندهای JavaScript هنگام صادرات](/slides/fa/java/export-to-html5/#exclude-javascript-hyperlinks-during-export)‎ مراجعه کنید. این تنظیم JavaScript مورد استفاده توسط نمایشگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.