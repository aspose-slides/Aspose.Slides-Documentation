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
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- Java
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای جاوا. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ کنید."
---
## **مروری**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی را پوشش می‌دهد و همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال‌های اسلاید ارائه می‌کند. همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید و نشان می‌دهد چگونه می‌توانید نظرات را در سند صادر شده با پیکربندی چیدمان آن‌ها درج کنید.

## **صادرات PowerPoint به HTML5**

این کد Java نشان می‌دهد که چگونه یک ارائه را بدون افزونه‌های وب و وابستگی‌ها به HTML5 صادر کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
در این حالت، HTML تمیزی دریافت می‌کنید. 
{{% /alert %}}

ممکن است بخواهید تنظیمات انیمیشن‌های شکل و انتقال‌های اسلایت را به این شکل تعیین کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صادرات PowerPoint به HTML**

این کد Java فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
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
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG، قادر به اعمال استایل‌ها یا انیمیشن عناصر خاص نخواهید بود. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد که یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید ارائه می‌شوند. در این حالت، وقتی فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید بر روی صفحه وب می‌بینید. 

این کد Java فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل ارائه‌ها به اسناد HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران امکان می‌دهند یادداشت‌ها یا بازخوردهای خود را بر روی اسلایدهای ارائه بگذارند. این نظرات به‌ویژه در پروژه‌های تعاملی مفید هستند، جایی که چندین نفر می‌توانند پیشنهادات یا Remarkهای خود را بر روی عناصر خاص اسلاید اضافه کنند بدون آنکه محتوای اصلی تغییر یابد. هر نظر نام نویسنده را نشان می‌دهد، که پیگیری اینکه چه کسی remark را گذاشته آسان می‌شود.

فرض کنید یک ارائه PowerPoint به نام «sample.pptx» ذخیره شده داریم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگام تبدیل یک ارائه PowerPoint به سند HTML5، می‌توانید به راحتی مشخص کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، پارامترهای نمایش نظرات را به روش `setSlidesLayoutOptions` از کلاس [Html5Options](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/) پاس می‌دهید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات به سمت راست اسلایدها نمایش داده می‌شوند.
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **سوالات متداول**

### آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال‌های اسلاید در HTML5 اجرا شوند؟

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [انتقال‌های اسلاید](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

### آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید در کجا قرار داد؟

بله، می‌توان نظرات را در HTML5 اضافه کرد و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) (به عنوان مثال، به سمت راست اسلاید) مکان‌یابی کرد.

### آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند برای دلایل امنیتی یا CSP رد کنم؟

بله، یک [تنظیم](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، لینک‌های دارای فراخوانی JavaScript را نادیده بگیرید. این کار به رعایت سیاست‌های امنیتی سخت کمک می‌کند.