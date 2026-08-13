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
- ذخیره PPT به HTML5
- ذخیره PPTX به HTML5
- ذخیره ODP به HTML5
- صادرات PPT به HTML5
- صادرات PPTX به HTML5
- صادرات ODP به HTML5
- .NET
- C#
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای .NET. حفظ قالب‌بندی، انیمیشن‌ها و تعامل‌پذیری."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه می‌توانید ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله پوشش‌دهندهٔ صادرات پایهٔ HTML5 و همچنین گزینه‌های کنترل انیمیشن‌های شکل و انتقال اسلایدها است. همچنین فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه می‌توان خروجی HTML5 را در حالت نمای اسلاید تولید کرد و نحوهٔ اضافه کردن نظرات به سند صادراتی را از طریق پیکربندی چیدمان آنها به نمایش می‌گذارد.

## **خروجی‌گیری PowerPoint به HTML5**

این کد C# نشان می‌دهد چگونه یک ارائه را به HTML5 صادر کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
علاوه بر سند HTML، خروجی فایل‌های پشتیبانی‌شده‌ای که به آنها ارجاع می‌دهد را نیز می‌نویسد: `pres.css`، `master.css`، `animation.js`، `effects.js` و `navigation.js`. صفحهٔ تولیدشده همچنین jQuery و Anime.js را از CDN‌های عمومی بارگذاری می‌کند؛ بدون این کتابخانه‌ها ناوبری اسلاید و انیمیشن‌ها اجرا نمی‌شوند. 
{{% /alert %}}

ممکن است مایل باشید تنظیمات انیمیشن‌های شکل و انتقال اسلایدها را به این صورت مشخص کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **خروجی‌گیری PowerPoint به HTML**

این کد C# فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Note" color="warning" %}} 
هنگامی که این روش را برای خروجی‌گیری PowerPoint به HTML استفاده می‌کنید، به دلیل رندر شدن با SVG، قادر به اعمال سبک‌ها یا انیمیشن دادن به عناصر خاص نخواهید بود. 
{{% /alert %}}

## **خروجی‌گیری PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائهٔ PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها به صورت نمای اسلاید نمایش داده می‌شوند. در این حالت، هنگام باز کردن فایل HTML5 حاصل در مرورگر، ارائه در حالت نمای اسلاید بر روی صفحه وب ظاهر می‌شود. 

این کد C# فرآیند خروجی‌گیری PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت‌ها یا بازخورد خود را بر روی اسلایدهای ارائه اضافه کنند. این قابلیت به‌ویژه در پروژه‌های مشترک مفید است، جایی که افراد متعدد می‌توانند پیشنهادها یا نکات خود را به عناصر خاص اسلاید اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد که رهگیری اینکه چه کسی نظر را оставил آسان می‌شود.

فرض کنید ارائهٔ PowerPoint زیر را در فایل «sample.pptx» ذخیره کرده‌ایم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگامی که یک ارائهٔ PowerPoint را به سند HTML5 تبدیل می‌کنید، می‌توانید به‌راحتی تعیین کنید آیا نظرات موجود در ارائه در سند خروجی گنجانده شوند یا نه. برای این کار باید پارامترهای نمایش نظرات را در ویژگی `NotesCommentsLayouting` از کلاس [Html5Options](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند به‌طوری که نظرات به سمت راست اسلایدها نمایش داده می‌شوند.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **سؤال‌های متداول**

### آیا می‌توانم کنترل کنم که انیمیشن‌های شیء و انتقال اسلایدها در HTML5 اجرا شوند یا نه؟

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [shape animations](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animateshapes/) و [slide transitions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animatetransitions/) فراهم می‌کند.

### آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آنها را نسبت به اسلاید کجا قرار داد؟

بله، نظرات می‌توانند در HTML5 اضافه شوند و از طریق [layout settings](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/notescommentslayouting/) برای نوت‌ها و نظرات، به‌مثال به سمت راست اسلاید، موقعیت‌یابی شوند.

### آیا می‌توانم لینک‌هایی که JavaScript را فراخوانی می‌کنند به دلایل امنیتی یا CSP رد کنم؟

بله، یک [setting](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) وجود دارد که به شما اجازه می‌دهد هنگام ذخیره‌سازی، لینک‌های حاوی فراخوانی‌های JavaScript را نادیده بگیرید. این کار به رعایت سیاست‌های امنیتی سخت کمک می‌کند.