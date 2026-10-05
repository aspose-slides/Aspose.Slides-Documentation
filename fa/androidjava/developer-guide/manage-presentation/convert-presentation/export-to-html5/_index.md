---
title: تبدیل ارائه‌ها به HTML5 در اندروید
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای اندروید از طریق Java به HTML5 واکنش‌گرا صادر کنید. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان ارائه‌های PowerPoint را با استفاده از Aspose.Slides برای Android از طریق Java به HTML5 تبدیل کرد. این مقاله به صادرات پایه، کنترل انیمیشن‌های شکل و انتقال‌های اسلاید، و چیدمان نظرات می‌پردازد. همچنین خروجی HTML5 را با خروجی مبتنی بر SVG صادرات استاندارد HTML مقایسه می‌کند.

## **صادرات PowerPoint به HTML5**

مثال زیر یک ارائه را از پوشه کاری بارگذاری می‌کند و آن را در قالب HTML5 ذخیره می‌نماید. این مثال از تنظیمات پیش‌فرض صادرات استفاده می‌کند؛ مثال بعدی نشان می‌دهد که چگونه می‌توان پخش انیمیشن را به‌صورت صریح کنترل کرد. مسیر ورودی را با مسیر ارائه خود جایگزین کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html5);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
علاوه بر سند HTML، صادرات فایل‌های CSS و JavaScript پشتیبانی‌کننده برای استایل اسلاید، انیمیشن‌ها، افکت‌ها و ناوبری را می‌نویسد. هنگام جابه‌جایی یا انتشار خروجی، این فایل‌ها را همراه با سند HTML نگه دارید. صفحه تولید شده همچنین jQuery و Anime.js را از CDNهای عمومی بارگذاری می‌کند؛ بدون آن‌ها ناوبری اسلاید و انیمیشن‌ها اجرا نمی‌شوند.
{{% /alert %}}

برای صادرات بدون پخش انیمیشن‌های شکل یا انتقال‌های اسلاید، در [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) مقدار `false` را به [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) پاس بدهید. این تنظیمات مستقل هستند، بنابراین می‌توانید یکی را فعال و دیگری را غیرفعال کنید. مثال زیر ارائه را با هر دو نوع انیمیشن غیرفعال در صفحه تولید شده صادر می‌کند.

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

صادرات استاندارد HTML از رویکرد رندر متفاوتی استفاده می‌کند: محتوای اسلاید توسط SVG داخل یک صفحه HTML نمایش داده می‌شود. مثال زیر ارائه را به یک سند HTML تبدیل می‌کند که از این رویکرد رندر استفاده می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.save("pres.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

نشانه‌گذاری ساده‌سازی شده زیر ساختار صفحه تولید شده را نشان می‌دهد. عنصر SVG شامل محتوای رندر شده اسلاید است؛ متن جایگزین نمایانگر آن محتوا است و خروجی صادر شده واقعی نیست.

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
صادرات مبتنی بر SVG اشکال PowerPoint را به عنوان عناصر HTML جداگانه در دسترس قرار نمی‌دهد. هنگامی که به گزینه‌های انیمیشن شکل و انتقال اسلاید نیاز دارید، از صادرات HTML5 استفاده کنید.
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

صادرات HTML5 صفحه‌ای برای مشاهده و ناوبری اسلایدهای ارائه در مرورگر تولید می‌کند. این مثال هم [setAnimateShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و هم [setAnimateTransitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) را فعال می‌کند تا نمای اسلاید صادر شده بتواند افکت‌های موجود در ارائه منبع را پخش کند.

از یک ارائه‌ای استفاده کنید که از پیش شامل انیمیشن‌های شکل و انتقال‌های اسلاید باشد تا اثر این تنظیمات را ببینید. فعال‌سازی آن‌ها افکت‌های جدیدی به اسلایدهایی که هیچ‌یک ندارند اضافه نمی‌کند. پس از صادرات، سند HTML5 تولید شده را در مرورگری که فایل‌های پشتیبان آن در دسترس است باز کنید.

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

## **تبدیل ارائه به یک سند HTML5 با نظرات**

می‌توانید نظرات موجود اسلاید را در خروجی HTML5 گنجانده و به خوانندگان اجازه دهید تا بازخورد را کنار محتوای اسلاید مشاهده کنند. مثال در این بخش انتظار دارد که ارائه منبع شامل نظرات باشد، همان‌طور که در زیر نشان داده شده است. این نظرات صادر می‌شوند؛ نظرات جدیدی ایجاد نمی‌شود.

![دو نظر در اسلاید ارائه](two_comments_pptx.png)

یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) را به روش [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) از [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) پاس بدهید. برای انتخاب `Right` از شمارنده [CommentsPositions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentspositions/) از طریق متد [setCommentsPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setCommentsPosition-int-) استفاده کنید تا نظرات را در سمت راست هر اسلاید قرار دهید.

مثال زیر ارائه را با این چیدمان نظرات به HTML5 صادر می‌کند. ارائه‌ای بدون نظرات متنی برای نمایش نخواهد داشت.

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

تصویر زیر سند HTML5 صادر شده را نشان می‌دهد که نظرات در کنار اسلاید نمایش داده می‌شوند.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **حذف پیوندهای JavaScript هنگام صادرات**

فرض کنید `hyperlinks.pptx` حاوی متنی پیوندی با هدف `javascript:alert('Hello')` و یک پیوند معمولی `https://example.com/` باشد. برای حذف پیوند JavaScript هنگام صادرات، مقدار `true` را به [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) پاس بدهید. مقدار پیش‌فرض `false` است، بنابراین این پیوندها فیلتر نمی‌شوند مگر این که گزینه را فعال کنید.

مثال زیر ارائه را از پوشه کاری بارگذاری می‌کند و با استفاده از [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) صادر می‌نماید:

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

فایل صادر شده پیوند JavaScript را حذف می‌کند در حالی که متن آن و پیوند HTTPS معمولی حفظ می‌شوند. ارائه منبع تغییر نمی‌کند.

این گزینه پیوندهای JavaScript را فیلتر می‌کند؛ اسکریپت‌ها یا سایر محتواهای فعال را حذف نمی‌کند و تضمین‌کنندهٔ سازگاری با CSP نیست. به‌عنوان مثال، خروجی HTML5 هنوز اسکریپت‌های مورد نیاز برای ناوبری و انیمیشن‌های اسلاید را شامل می‌شود.

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که آیا انیمیشن‌های شیء و انتقال‌های اسلاید در HTML5 پخش شوند یا نه؟**

بله، صادرات HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

**آیا نظرات پشتیبانی می‌شوند و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**

بله، نظرات موجود می‌توانند در خروجی HTML5 گنجانده شده و از طریق [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) برای یادداشت‌ها و نظرات (به عنوان مثال، در سمت راست اسلاید) موقعیت‌یابی شوند.

**آیا می‌توانم پیوندهایی را که JavaScript فراخوانی می‌کنند برای امنیت یا دلایل CSP حذف کنم؟**

بله، تنظیم [setSkipJavaScriptLinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) به شما امکان می‌دهد تا هنگام ذخیره‌سازی پیوندهای دارای فراخوانی JavaScript را حذف کنید. مقدار پیش‌فرض `false` است. برای مثال، به بخش [Exclude JavaScript Hyperlinks During Export](/slides/fa/androidjava/export-to-html5/#exclude-javascript-hyperlinks-during-export) برای یک مثال صادرات HTML5 و دامنه فیلتر مراجعه کنید. این تنظیم اسکریپت‌های استفاده‌شده توسط مرورگر HTML5 برای ناوبری و انیمیشن‌ها را حذف نمی‌کند.