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
- ذخیره PPT به صورت HTML5
- ذخیره PPTX به صورت HTML5
- ذخیره ODP به صورت HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- اندروید
- جاوا
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای اندروید از طریق جاوا. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **بررسی کلی**

این مقاله نحوه تبدیل ارائه‌های PowerPoint به HTML5 با استفاده از Aspose.Slides را توضیح می‌دهد. در آن به صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی، و همچنین گزینه‌های کنترل انیمیشن‌های شکل و تغییرات اسلاید پرداخته می‌شود. مقاله همچنین فرآیند استاندارد خروجی PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید، و نشان می‌دهد چطور می‌توان با تنظیم چیدمان، نظرات را در سند صادر شده گنجاند.

## **صادرات PowerPoint به HTML5**

این کد Java نحوه صادرات یک ارائه به HTML5 بدون افزونه‌های وب و وابستگی‌ها را نشان می‌دهد:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
در این حالت، HTML تمیزی دریافت می‌کنید. 
{{% /alert %}}

اگر بخواهید تنظیمات انیمیشن‌های شکل و تغییرات اسلاید را به این روش مشخص کنید:

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

## **صادرات PowerPoint به HTML**

این کد Java فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

در این حالت، محتوای ارائه با استفاده از SVG به شکلی مانند زیر رندر می‌شود:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="توجه" color="warning" %}} 
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندرینگ SVG، نمی‌توانید سبک‌ها را اعمال کنید یا عناصر خاص را انیمیت کنید. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** امکان تبدیل یک ارائه PowerPoint به سند HTML5 را فراهم می‌کند که در آن اسلایدها به صورت نمای اسلاید نمایش داده می‌شوند. در این حالت، هنگام باز کردن فایل HTML5 حاصل در مرورگر، ارائه در حالت نمای اسلاید بر روی صفحه وب دیده می‌شود. 

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

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند نکات یا بازخورد خود را بر روی اسلایدهای ارائه بگذارند. این ویژگی به‌ویژه در پروژه‌های مشترک مفید است، جایی که افراد مختلف می‌توانند پیشنهادات یا توضیحات خود را به عناصر خاص اسلاید اضافه کنند بدون آنکه محتوی اصلی را تغییر دهند. هر نظر نام نویسنده را نمایش می‌دهد و ردیابی صاحب نظر را آسان می‌کند.

فرض کنیم ارائه PowerPoint زیر را در فایل «sample.pptx» ذخیره کرده‌ایم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

زمانی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، به‌راحتی می‌توانید تعیین کنید که آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار، باید پارامترهای نمایش نظرات را در متد `getNotesCommentsLayouting` کلاس [Html5Options](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات در سمت راست اسلایدها نمایش داده می‌شوند.
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **سوالات متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و تغییرات اسلاید در HTML5 اجرا شوند یا خیر؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [slide transitions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید در کجا قرار داد؟**

بله، می‌توان نظرات را در HTML5 اضافه کرد و از طریق [layout settings](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) برای یادداشت‌ها و نظرات، موقعیت آنها (مثلاً در سمت راست اسلاید) را تعیین کرد.

**آیا می‌توانم لینک‌هایی که JavaScript فراخوانی می‌کنند را برای دلایل امنیتی یا CSP حذف کنم؟**

بله، یک [setting](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) وجود دارد که اجازه می‌دهد در زمان ذخیره‌سازی، پیوندهای حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این کار به رعایت سیاست‌های امنیتی سخت کمک می‌کند.