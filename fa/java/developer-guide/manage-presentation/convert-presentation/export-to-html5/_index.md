---
title: تبدیل ارائه‌ها به HTML5 در Java
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
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای Java. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله به صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی می‌پردازد و همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال اسلایدها ارائه می‌دهد. همچنین فرآیند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید و نشان می‌دهد چگونه نظرات را در سند صادر شده با تنظیم چیدمان آن گنجانده شود.

## **صدور PowerPoint به HTML5**

این کد Java نشان می‌دهد که چگونه یک ارائه را به HTML5 بدون افزونه‌های وب و وابستگی‌ها صادر کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
در این حالت، HTML تمیز دریافت می‌کنید. 
{{% /alert %}}

اگر بخواهید تنظیمات انیمیشن‌های شکل و انتقال اسلایدها را به این شکل مشخص کنید:

```java
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

## **صدور PowerPoint به HTML**

این کد Java فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```java
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
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر با SVG، نمی‌توانید استایل‌ها را اعمال کنید یا عناصر خاص را انیمیشن دهید. 
{{% /alert %}}

## **صدور PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد ارائه PowerPoint را به یک سند HTML5 تبدیل کنید که در آن اسلایدها در حالت نمای اسلاید نمایش داده می‌شوند. در این حالت، وقتی فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید روی صفحه وب می‌بینید.

این کد Java فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```java
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

## **تبدیل ارائه‌ها به مستندات HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت‌ها یا بازخوردهایی را بر روی اسلایدهای ارائه بگذارند. این ویژگی به‌ویژه در پروژه‌های همکاری گروهی مفید است، جایی که افراد مختلف می‌توانند پیشنهادات یا نکات خود را به عناصر خاص اسلاید اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد و پیگیری اینکه چه کسی نظردهی کرده آسان می‌شود.

فرض کنید ارائه PowerPoint زیر در فایل "sample.pptx" ذخیره شده است.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به یک سند HTML5 تبدیل می‌کنید، می‌توانید به‌راحتی مشخص کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شود یا نه. برای این کار، باید پارامترهای نمایش نظرات را در متد `getNotesCommentsLayouting` کلاس [Html5Options](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به یک سند HTML5 تبدیل می‌کند که نظرات در سمت راست اسلایدها نمایش داده می‌شوند.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

سند "output.html" در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **سؤالات متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های شیء و انتقال اسلایدها در HTML5 اجرا شوند؟**
بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [انتقال اسلایدها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

**آیا پشتیبانی از خروجی نظرات وجود دارد و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟**
بله، نظرات می‌توانند در HTML5 اضافه شوند و از طریق [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) برای یادداشت‌ها و نظرات، موقعیت‌یابی شوند (به عنوان مثال، در سمت راست اسلاید).

**آیا می‌توانم پیوندهایی که JavaScript را فراخوانی می‌کنند برای دلایل امنیتی یا CSP حذف کنم؟**
بله، یک [تنظیم](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این به رعایت سیاست‌های امنیتی سخت کمک می‌کند.