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
- صادر کردن PPT به HTML5
- صادر کردن PPTX به HTML5
- صادر کردن ODP به HTML5
- Android
- Java
- Aspose.Slides
description: "صادر کردن ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای اندروید از طریق Java. حفظ قالب‌بندی، انیمیشن‌ها و تعاملی بودن."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله، صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی را پوشش می‌دهد و همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال اسلایدها ارائه می‌کند. همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد که چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید و نحوه گنجاندن نظرات در سند صادره را از طریق پیکربندی چیدمان آن نشان می‌دهد.

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

ممکن است بخواهید تنظیمات انیمیشن‌های شکل و انتقال اسلایدها را به این روش مشخص کنید:

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
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG، قادر نخواهید بود سبک‌ها را اعمال کنید یا عناصر خاص را متحرک کنید. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید نمایش داده می‌شوند. در این حالت، هنگامی که فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را به صورت نمای اسلاید در صفحه وب می‌بینید. 

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

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت‌ها یا بازخوردهایی بر روی اسلایدهای ارائه بگذارند. این نظرات به‌ویژه در پروژه‌های مشترک مفید هستند، چرا که چندین نفر می‌توانند پیشنهادات یا توضیحات خود را به عناصر خاص اسلایدها اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد، که ردیابی کننده‌ای برای شناختن اینکه چه کسی نظر را گذاشته است، فراهم می‌کند.

فرض کنید ارائه PowerPoint زیر در فایل "sample.pptx" ذخیره شده است.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به سادگی تعیین کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، باید پارامترهای نمایش نظرات را به متد `setSlidesLayoutOptions` از کلاس [Html5Options](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/) پاس دهید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات به سمت راست اسلایدها نمایش داده می‌شوند.
```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

سند "output.html" در تصویر زیر نشان داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **پرسش‌های متداول**

### آیا می‌توانم کنترل کنم که آیا انیمیشن‌های اشیا و انتقال اسلایدها در HTML5 اجرا شوند؟

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [انتقال‌های اسلاید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

### آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید کجا قرار داد؟

بله، می‌توان نظرات را در HTML5 افزود و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) برای یادداشت‌ها و نظرات، آنها را (مثلاً به سمت راست اسلاید) موقعیت‌دهی کرد.

### آیا می‌توانم لینک‌هایی که JavaScript فراخوانی می‌کنند را برای دلایل امنیتی یا CSP رد کنم؟

بله، یک [تنظیم](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) وجود دارد که به شما اجازه می‌دهد در زمان ذخیره‌سازی، پیوندهای حاوی فراخوانی JavaScript را نادیده بگیرید. این به رعایت سیاست‌های امنیتی سخت کمک می‌کند.