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
- ذخیره PPT به عنوان HTML5
- ذخیره PPTX به عنوان HTML5
- ذخیره ODP به عنوان HTML5
- صادر کردن PPT به HTML5
- صادر کردن PPTX به HTML5
- صادر کردن ODP به HTML5
- .NET
- C#
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای .NET. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این راهنما به خروجی پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی می‌پردازد و همچنین گزینه‌هایی برای کنترل انیمیشن‌های اشکال و انتقال اسلایدها را ارائه می‌دهد. مقاله همچنین فرآیند استاندارد خروجی PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمایش اسلاید تولید کنید و نشان می‌دهد چگونه می‌توانید با پیکربندی چیدمان، نظرات را در سند صادرشده گنجانده کنید.

## **صادرات PowerPoint به HTML5**

این کد C# نشان می‌دهد که چگونه یک ارائه را بدون افزونه‌های وب و وابستگی‌ها به HTML5 صادر کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
در این حالت، یک HTML تمیز دریافت می‌کنید. 
{{% /alert %}}

اگر می‌خواهید تنظیمات انیمیشن‌های اشکال و انتقال اسلایدها را به این شکل مشخص کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **صادرات PowerPoint به HTML**

این کد C# فرآیند استاندارد خروجی PowerPoint به HTML را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

{{% alert title="توجه" color="warning" %}} 
هنگامی که از این روش برای خروجی PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG قادر نخواهید بود سبک‌ها را اعمال کنید یا عناصر خاصی را انیمیت کنید. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها به صورت نمای اسلاید نمایش داده می‌شوند. در این حالت، وقتی فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید بر روی یک صفحه وب می‌بینید.

این کد C# فرآیند خروجی PowerPoint به نمایش اسلاید HTML5 را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **تبدیل ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران امکان می‌دهند یادداشت‌ها یا بازخورد خود را روی اسلایدهای ارائه بنویسند. این ویژگی به ویژه در پروژه‌های همکاری‌محور مفید است، به‌طوری‌که افراد مختلف می‌توانند پیشنهادات یا نکات خود را به عناصر خاص اسلاید اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد و ردیابی منبع آن را آسان می‌کند.

فرض کنید ارائه PowerPoint زیر در فایل «sample.pptx» ذخیره شده است.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائه PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به راحتی مشخص کنید که آیا نظرات ارائه در سند خروجی گنجانده شوند یا نه. برای انجام این کار، باید پارامترهای نمایش نظرات را در ویژگی `NotesCommentsLayouting` کلاس [Html5Options](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/) تعیین کنید.

کد نمونه زیر ارائه را به سند HTML5 تبدیل می‌کند که نظرات در سمت راست اسلایدها نمایش داده می‌شوند.

```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند HTML5 خروجی](two_comments_html5.png)

## **سؤالات متداول**

**آیا می‌توانم کنترل کنم که انیمیشن‌های اشیاء و انتقال اسلایدها در HTML5 اجرا شوند یا نه؟**

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های اشکال](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animateshapes/) و [انتقال اسلایدها](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animatetransitions/) فراهم می‌کند.

**آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید در کجا قرار داد؟**

بله، می‌توان نظرات را در HTML5 اضافه کرد و با استفاده از [تنظیمات چیدمان](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/notescommentslayouting/) برای یادداشت‌ها و نظرات، موقعیت آنها (مثلاً در سمت راست اسلاید) را تعیین نمود.

**آیا می‌توانم لینک‌هایی که جاوااسکریپت فراخوانی می‌کنند را برای دلایل امنیتی یا CSP رد کنم؟**

بله، تنظیمی وجود دارد که با استفاده از [این گزینه](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) امکان نادیده‌گیری پیوندهایی که دارای فراخوانی‌های JavaScript هستند در هنگام ذخیره‌سازی را فراهم می‌کند. این ویژگی به تطبیق با سیاست‌های امنیتی سخت کمک می‌کند.