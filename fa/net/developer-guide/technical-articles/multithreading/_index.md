---
title: اجرای چندنخی در Aspose.Slides برای .NET
linktitle: چندنخی
type: docs
weight: 310
url: /fa/net/multithreading/
keywords:
- چندنخی
- چندین رشته
- کار موازی
- تبدیل اسلایدها
- اسلایدها به تصویر
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "چندنخی Aspose.Slides برای .NET عملکرد پردازش PowerPoint و OpenDocument را بهبود می‌بخشد. بهترین روش‌ها برای گردش کار کارآمد ارائه را کشف کنید."
---
## **مقدمه**

در حالی که کار موازی با ارائه‌ها (علاوه بر تجزیه/بارگذاری/کپی) ممکن است و اکثر اوقات همه چیز به‌خوبی پیش می‌رود، احتمال کمی وجود دارد که هنگام استفاده از کتابخانه در چندین رشته نتایج نادرست دریافت کنید.

به شدت توصیه می‌کنیم که **نه** از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) در محیط چند‌رشته‌ای استفاده کنید زیرا ممکن است منجر به خطاهای غیرقابل پیش‌بینی یا شکست‌هایی شود که به سادگی قابل تشخیص نیستند.

بارگذاری، ذخیره‌سازی و/یا کپی‌برداری از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) در چندین رشته **نه** امن است. چنین عملیاتی **نه** پشتیبانی می‌شود. اگر نیاز به انجام چنین وظایفی دارید، باید عملیات را به‌صورت موازی با استفاده از چندین فرآیند تک‌رشته‌ای انجام دهید و هر یک از این فرآیندها باید از نمونهٔ ارائهٔ خود استفاده کند.

## **تبدیل اسلایدهای ارائه به تصویرها به‌صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائهٔ PowerPoint را به تصاویر PNG به‌صورت موازی تبدیل کنیم. چون استفادهٔ یک نمونهٔ `Presentation` در چندین رشته ناامن است، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به تصاویر تبدیل می‌کنیم، به‌طوری که هر ارائه در یک رشتهٔ جداگانه استفاده شود. نمونه کد زیر نشان می‌دهد چگونه این کار را انجام دهیم.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // اسلاید i را به یک ارائه جداگانه استخراج کنید.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // اسلاید را در یک تسک جداگانه به تصویر تبدیل کنید.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **سوالات متداول**

**آیا نیاز است در هر رشته تنظیم مجوز را فراخوانی کنم؟**

نه. کافی است یک‌بار قبل از شروع رشته‌ها در هر فرآیند/دامنهٔ برنامه تنظیم شود. اگر [تنظیم مجوز](/slides/fa/net/licensing/) ممکن است به‌صورت همزمان فراخوانی شود (مثلاً در زمان مقداردهی تنبل)، آن فراخوانی را همگام‌سازی کنید چون متد تنظیم مجوز به‌تنهایی ایمن برای رشته‌ها نیست.

**آیا می‌توانم اشیاء `Presentation` یا `Slide` را بین رشته‌ها منتقل کنم؟**

انتقال اشیاء «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته یک نمونهٔ مستقل استفاده کنید یا پیشاپیش ارائه‌ها/کانتینرهای اسلاید جداگانه برای هر رشته بسازید. این روش مطابق با توصیه کلی برای عدم اشتراک یک نمونهٔ ارائه بین رشته‌ها است.

**آیا ایمن است که خروجی به فرمت‌های مختلف (PDF، HTML، تصویر) را موازی‌سازی کنم به‌شرط اینکه هر رشته یک نمونهٔ `Presentation` خود داشته باشد؟**

بله. با استفاده از نمونه‌های مستقل و مسیرهای خروجی جداگانه، چنین کارهایی معمولاً به‌درستی موازی می‌شوند؛ از اشتراک اشیاء ارائه یا جریان‌های I/O مشترک اجتناب کنید.

**در مورد تنظیمات فونت سراسری (پوشه‌ها، جایگزینی‌ها) در محیط چند‌رشته‌ای چه کار باید کرد؟**

تمام تنظیمات فونت سراسری را قبل از شروع رشته‌ها مقداردهی کنید و در طول کار موازی آن‌ها را تغییر ندهید. این کار از بروز مسابقات دسترسی به منابع فونت مشترک جلوگیری می‌کند.