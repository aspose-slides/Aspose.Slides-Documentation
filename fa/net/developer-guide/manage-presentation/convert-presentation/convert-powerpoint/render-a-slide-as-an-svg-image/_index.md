---
title: "نمایش اسلایدهای ارائه به‌صورت تصاویر SVG در .NET"
linktitle: "اسلاید به SVG"
type: docs
weight: 50
url: /fa/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint به SVG"
- "ارائه به SVG"
- "اسلاید به SVG"
- "PPT به SVG"
- "PPTX به SVG"
- "ذخیره PPT به صورت SVG"
- "ذخیره PPTX به صورت SVG"
- "صادرات PPT به SVG"
- "صادرات PPTX به SVG"
- "رندر اسلاید"
- "تبدیل اسلاید"
- "صادرات اسلاید"
- "تصویر برداری"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "یاد بگیرید چگونه اسلایدهای PowerPoint را با استفاده از Aspose.Slides برای .NET به تصاویر SVG رندر کنید. تصاویری با کیفیت بالا با مثال‌های ساده کد C#."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را با استفاده از Aspose.Slides به‌صورت تصاویر SVG رندر کنید. این مقاله قالب SVG و مزایای آن از جمله مقیاس‌پذیری، دسترس‌پذیری و مناسب بودن برای توسعه وب را شرح می‌دهد.

شما با نحوه بارگذاری فایل ارائه، پیمایش اسلایدهای آن و ذخیره هر اسلاید به‌صورت یک فایل SVG جداگانه آشنا خواهید شد. این مقاله به فرمت‌های ارائه PowerPoint و OpenDocument شامل PPT، PPTX، ODP و PPS می‌پردازد و نشان می‌دهد چگونه تبدیل را به‌صورت برنامه‌ای با کلاس `Presentation` و متد `WriteAsSvg` انجام دهید.

## **قالب SVG**
SVG—مخفف Scalable Vector Graphics—یک نوع یا قالب گرافیکی استاندارد برای رندر تصاویر دوبعدی است. SVG تصاویر را به‌صورت بردارها در XML ذخیره می‌کند و جزئیاتی که رفتار یا ظاهر آن‌ها را تعریف می‌کند، شامل می‌شود.

SVG یکی از تعداد کمی از قالب‌های تصویری است که معیارهای بسیار بالایی در زمینه‌های مقیاس‌پذیری، تعامل‌پذیری، کارایی، دسترس‌پذیری، قابلیت برنامه‌نویسی و موارد دیگر را برآورده می‌کند. به همین دلایل، به‌طور گسترده‌ای در توسعه وب استفاده می‌شود.

ممکن است بخواهید از فایل‌های SVG زمانی استفاده کنید که نیاز داشته باشید
- **ارائه خود را در یک *قالب بسیار بزرگ* چاپ کنید.** تصاویر SVG می‌توانند به‌هر رزولوشن یا سطحی مقیاس‌باز شوند. می‌توانید تصاویر SVG را هر تعداد که نیاز دارید بدون کاهش کیفیت تغییر اندازه دهید.
- **از نمودارها و گراف‌های اسلایدهای خود در *رسانه‌ها یا پلتفرم‌های مختلف* استفاده کنید.** اکثر مرورگرها می‌توانند فایل‌های SVG را تفسیر کنند.
- **از *کوچک‌ترین اندازه‌های ممکن برای تصاویر* استفاده کنید.** فایل‌های SVG عموماً نسبت به معادل‌های با رزولوشن بالا در سایر قالب‌ها، به‌ویژه قالب‌های مبتنی بر بیت‌مپ (JPEG یا PNG) کوچکتر هستند.

## **رندر یک اسلاید به‌صورت تصویر SVG**

Aspose.Slides برای .NET به شما امکان می‌دهد اسلایدهای ارائه خود را به‌صورت تصاویر SVG صادر کنید. برای تولید تصاویر SVG این مراحل را دنبال کنید:

*_مراحل: تبدیل PowerPoint به SVG در C#_*

کد نمونه زیر این تبدیل‌ها را با استفاده از .NET توضیح می‌دهد.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>مراحل: تبدیل PowerPoint به SVG در C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>مراحل: تبدیل PPT به SVG در C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>مراحل: تبدیل PPTX به SVG در C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>مراحل: تبدیل ODP به SVG در C#</strong></a>

_مراحل کد:_

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
   * _.ppt_ پسوند برای بارگذاری فایل **PPT** درون کلاس _Presentation_.
   * _.pptx_ پسوند برای بارگذاری فایل **PPTX** درون کلاس _Presentation_.
   * _.odp_ پسوند برای بارگذاری فایل **ODP** درون کلاس _Presentation_.
   * _.pps_ پسوند برای بارگذاری فایل **PPS** درون کلاس _Presentation_.
2. تمام اسلایدهای ارائه را پیمایش کنید.
3. هر اسلاید را از طریق FileStream به فایل SVG مختص به خود بنویسید.

{{% alert color="primary" %}} 
ممکن است بخواهید [برنامه وب رایگان](https://products.aspose.app/slides/fa/conversion/ppt-to-svg) ما را امتحان کنید که در آن تابع تبدیل PPT به SVG از Aspose.Slides برای .NET پیاده‌سازی شده است.
{{% /alert %}} 

این کد نمونه در C# نشان می‌دهد چگونه PowerPoint را با استفاده از Aspose.Slides به SVG تبدیل کنید: 

``` csharp
// شیء Presentation می‌تواند فرمت‌های PowerPoint مانند PPT، PPTX، ODP و غیره را بارگذاری کند.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **پرسش‌های متداول**

**چرا ممکن است SVG تولید شده در مرورگرهای مختلف متفاوت ظاهر شود؟**

پشتیبانی از ویژگی‌های خاص SVG در موتورهای مرورگر به‌صورت متفاوتی پیاده‌سازی می‌شود. پارامترهای [SVGOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/) به رفع ناسازگاری‌ها کمک می‌کنند.

**آیا امکان صادر کردن نه تنها اسلایدها بلکه اشکال منفرد به SVG وجود دارد؟**

بله. هر [شکل می‌تواند به‌صورت یک SVG جداگانه ذخیره شود](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/)، که برای آیکون‌ها، پیکتوگرام‌ها و استفاده مجدد از گرافیک‌ها مناسب است.

**آیا می‌توان چندین اسلاید را در یک SVG واحد (نوار/سند) ترکیب کرد؟**

سناریوی استاندارد یک اسلاید → یک SVG است. ترکیب چندین اسلاید در یک بوم SVG واحد یک مرحله پس‌پردازشی است که در سطح برنامه انجام می‌شود.

## **موارد مرتبط** 

این مقاله همچنین به این موضوعات می‌پردازد. کدها همانند بالا هستند.

_قالب_: **PowerPoint**
- [کد C# PowerPoint به SVG](#csharp-powerpoint-to-svg)
- [API C# PowerPoint به SVG](#csharp-powerpoint-to-svg)
- [برنامه‌نویسی C# PowerPoint به SVG](#csharp-powerpoint-to-svg)
- [کتابخانه C# PowerPoint به SVG](#csharp-powerpoint-to-svg)
- [ذخیره PowerPoint به SVG با C#](#csharp-powerpoint-to-svg)
- [تولید SVG از PowerPoint با C#](#csharp-powerpoint-to-svg)
- [ایجاد SVG از PowerPoint با C#](#csharp-powerpoint-to-svg)
- [مبدل PowerPoint به SVG با C#](#csharp-powerpoint-to-svg)

_قالب_: **PPT**
- [کد C# PPT به SVG](#csharp-ppt-to-svg)
- [API C# PPT به SVG](#csharp-ppt-to-svg)
- [برنامه‌نویسی C# PPT به SVG](#csharp-ppt-to-svg)
- [کتابخانه C# PPT به SVG](#csharp-ppt-to-svg)
- [ذخیره PPT به SVG با C#](#csharp-ppt-to-svg)
- [تولید SVG از PPT با C#](#csharp-ppt-to-svg)
- [ایجاد SVG از PPT با C#](#csharp-ppt-to-svg)
- [مبدل PPT به SVG با C#](#csharp-ppt-to-svg)

_قالب_: **PPTX**
- [کد C# PPTX به SVG](#csharp-pptx-to-svg)
- [API C# PPTX به SVG](#csharp-pptx-to-svg)
- [برنامه‌نویسی C# PPTX به SVG](#csharp-pptx-to-svg)
- [کتابخانه C# PPTX به SVG](#csharp-pptx-to-svg)
- [ذخیره PPTX به SVG با C#](#csharp-pptx-to-svg)
- [تولید SVG از PPTX با C#](#csharp-pptx-to-svg)
- [ایجاد SVG از PPTX با C#](#csharp-pptx-to-svg)
- [مبدل PPTX به SVG با C#](#csharp-pptx-to-svg)

_قالب_: **ODP**
- [کد C# ODP به SVG](#csharp-odp-to-svg)
- [API C# ODP به SVG](#csharp-odp-to-svg)
- [برنامه‌نویسی C# ODP به SVG](#csharp-odp-to-svg)
- [کتابخانه C# ODP به SVG](#csharp-odp-to-svg)
- [ذخیره ODP به SVG با C#](#csharp-odp-to-svg)
- [تولید SVG از ODP با C#](#csharp-odp-to-svg)
- [ایجاد SVG از ODP با C#](#csharp-odp-to-svg)
- [مبدل ODP به SVG با C#](#csharp-odp-to-svg)