---
title: تبدیل ارائه‌ها به HTML5 در JavaScript
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/nodejs-java/export-to-html5/
keywords:
- پاورپوینت به HTML5
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را به HTML5 واکنش‌گرا با Aspose.Slides برای Node.js صادر کنید. قالب‌بندی، انیمیشن‌ها و تعامل را حفظ می‌کند."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این شامل خروجی پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی و همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال‌های اسلاید می‌شود. مقاله همچنین فرآیند استاندارد خروجی PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید و نشان می‌دهد چگونه می‌توانید نظرات را در سند صادر شده با تنظیم چیدمان آنها گنجانید.

## **خروجی PowerPoint به HTML5**

این کد JavaScript نشان می‌دهد چگونه ارائه را بدون افزونه‌های وب و وابستگی‌ها به HTML5 صادر کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
در این حالت، HTML تمیزی دریافت می‌کنید. 
{{% /alert %}}

ممکن است بخواهید تنظیمات انیمیشن‌های شکل و انتقال‌های اسلاید را به این شکل مشخص کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **خروجی PowerPoint به HTML**

این کد JavaScript فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
    }
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

{{% alert title="نکته" color="warning" %}} 
هنگامی که از این روش برای خروجی PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG نمی‌توانید استایل‌ها را اعمال کنید یا عناصر خاصی را انیمیت کنید. 
{{% /alert %}}

## **خروجی PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** امکان تبدیل ارائه PowerPoint به سند HTML5 را فراهم می‌کند که در آن اسلایدها در حالت نمای اسلاید نمایش داده می‌شوند. در این حالت، وقتی فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه در حالت نمای اسلاید بر روی صفحه وب مشاهده می‌شود. 

این کد JavaScript فرآیند خروجی PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران امکان می‌دهند یادداشت یا بازخوردی بر روی اسلایدهای ارائه بنویسند. این ویژگی به‌ویژه در پروژه‌های مشترک مفید است، جایی که افراد مختلف می‌توانند پیشنهادات یا نکات خود را به عناصر خاص اسلاید اضافه کنند بدون آنکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد که پیگیری منبع آن را آسان می‌کند.

فرض کنید ارائه PowerPoint زیر در فایل «sample.pptx» ذخیره شده باشد.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

وقتی یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به سادگی مشخص کنید که آیا نظرات ارائه در سند خروجی گنجانده شوند یا نه. برای این کار باید پارامترهای نمایش نظرات را در ویژگی `notes_comments_layouting` از کلاس [Html5Options](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/) تنظیم کنید.

مثال کد زیر ارائه را به سند HTML5 با نظرات نمایش داده شده در سمت راست اسلایدها تبدیل می‌کند.
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **پرسش‌های متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال‌های اسلاید در HTML5 اجرا شوند یا نه؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/setanimateshapes/) و [slide transitions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/setanimatetransitions/) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید در کجا قرار داد؟**

بله، نظرات می‌توانند در HTML5 اضافه شوند و از طریق [layout settings](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) برای یادداشت‌ها و نظرات، به‌عنوان مثال در سمت راست اسلاید، موقعیت‌یابی شوند.

**آیا می‌توانم لینک‌هایی که از JavaScript فراخوانی می‌کنند را به دلایل امنیتی یا CSP نادیده بگیرم؟**

بله، یک [setting](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) وجود دارد که به شما امکان می‌دهد هنگام ذخیره‌سازی، پیوندهای دارای فراخوانی JavaScript را نادیده بگیرید. این کار به پیروی از سیاست‌های امنیتی سخت کمک می‌کند.