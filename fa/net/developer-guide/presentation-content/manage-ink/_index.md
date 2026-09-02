---
title: مدیریت اشیاء جوهر ارائه در .NET
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/net/manage-ink/
keywords:
- جوهر
- شیء جوهر
- رد جوهر
- مدیریت جوهر
- رسم جوهر
- نقاشی
- صادرات جوهر
- رندرینگ جوهر
- پنهان کردن جوهر
- IInkOptions
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint، ویرایش ردها و ویژگی‌های قلم‌مو، و کنترل ظاهر جوهر هنگام صادرات PDF، HTML، SVG، TIFF و تصاویر با Aspose.Slides برای .NET."
---
## **مقدمه**

PowerPoint ویژگی جوهر (Ink) را فراهم می‌کند که امکان رسم خطوط آزادانه را به شما می‌دهد. می‌توانید از جوهر برای برجسته‌سازی اشیاء دیگر، نمایش اتصالات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده کنید.

فضای نام [Aspose.Slides.Ink](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/) شامل کلاس‌ها و اینترفیس‌های مورد نیاز برای کار با اشیاء جوهر است. برای مثال، اینترفیس [IInk](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iink/) نمایانگر یک شیء جوهر روی اسلاید است.

## **تفاوت بین اشیاء عادی و اشیاء جوهر**

اشیاء در یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایان می‌شوند. در ساده‌ترین شکل، یک shape یک ظرف است که ناحیه خود (قاب) را به همراه ویژگی‌هایی مانند اندازه ظرف، شکل و پس‌زمینه تعریف می‌کند. برای اطلاعات بیشتر به [قالب‌بندی چیدمان شکل](https://docs.aspose.com/slides/fa/net/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما هنگامی که PowerPoint یک شیء جوهر را مدیریت می‌کند، تمام ویژگی‌های قاب شیء (مستثنی از اندازه) نادیده گرفته می‌شوند. اندازه ناحیهٔ ظرف توسط ویژگی‌های استاندارد [IShape.Width](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/width/) و [IShape.Height](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/height/) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردهای جوهر**

یک رد جوهر یک عنصر پایه‌ای است که مسیر قلم را هنگام نوشتن جوهر دیجیتال ثبت می‌کند. یک رد، دنباله‌ای از نقاط متصل را ذخیره می‌کند.

ساده‌ترین روش کدگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری شبیه به این تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم‌مو برای رسم**

قلم‌مو برای رسم خطوطی که نقاط یک رد جوهر را به هم متصل می‌کند، استفاده می‌شود. قلم‌مو دارای رنگ و اندازهٔ اختصاصی خود است که توسط ویژگی‌های [IInkBrush.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iinkbrush/color/) و [IInkBrush.Size](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iinkbrush/size/) تعریف می‌شود.

### **تنظیم رنگ قلم‌مو جوهر**

این کد C# نشان می‌دهد که چگونه رنگ یک قلم‌مو جوهر را تنظیم کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **تنظیم اندازه قلم‌مو جوهر**

این کد C# نشان می‌دهد که چگونه اندازه یک قلم‌مو جوهر را تنظیم کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

به‌طور کلی، عرض و ارتفاع یک قلم‌مو با هم برابر نیستند، بنابراین PowerPoint اندازهٔ قلم‌مو را نمایش نمی‌دهد (بخش مربوطه به رنگ خاکستری نشان داده می‌شود). وقتی عرض و ارتفاع قلم‌مو برابر شوند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را بازبینی می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

ظرف (قاب) اندازهٔ قلم‌موها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر قبلی مراجعه کنید).

بنابراین برای تعیین ناحیهٔ مشاهده‌پذیر کل شیء جوهر، باید اندازهٔ قلم‌موهای ردهای آن در نظر گرفته شود. در اینجا، شیء هدف (رد متن دست‌نویس) به اندازهٔ ظرف (قاب) مقیاس شده است. وقتی اندازهٔ ظرف تغییر می‌کند، اندازهٔ قلم‌مو ثابت می‌ماند و برعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی را برای اشیاء متنی اعمال می‌کند:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام استخراج و رندرینگ**

Aspose.Slides اینترفیس [IInkOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/) را برای کنترل نحوهٔ نمایش اشیاء جوهر در خروجی استخراج‌شده یا رندر شده فراهم می‌کند. می‌توانید از ویژگی‌های آن برای مخفی‌کردن کامل جوهر یا تغییر نحوهٔ تفسیر عملیات ماسک قلم‌مو جوهر استفاده کنید.

گزینه‌های جوهر از طریق گزینه‌های استخراج یا رندرینگ برای چندین نوع خروجی در دسترس هستند:

| خروجی | ویژگی گزینه‌های جوهر |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/inkoptions/) |
| تصویر اسلاید | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/inkoptions/) |

دو تنظیم زیر از طریق این ویژگی‌ها در دسترس هستند:

- [`HideInk`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/hideink/) تعیین می‌کند که آیا اشیاء جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض آن `false` است.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) تعیین می‌کند که آیا عملیات ماسک به عنوان شفافیت تفسیر شود یا نه. مقدار پیش‌فرض `true` است؛ برای استفاده از عملیات ROP مقدار را به `false` تغییر دهید.

### **پنهان‌سازی اشیاء جوهر در خروجی PDF**

به‌صورت پیش‌فرض، اشیاء جوهر هنگام استخراج قابل مشاهده‌اند. وقتی به خروجی بدون حاشیه‌نویسی یا محتوای جوهر نیاز دارید، ویژگی [IInkOptions.HideInk](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/hideink/) را به `true` تنظیم کنید.

مثال C# زیر یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیاء جوهر مخفی می‌شوند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **پنهان‌سازی اشیاء جوهر هنگام رندر اسلاید به عنوان تصویر**

برای پنهان‌کردن اشیاء جوهر هنگام رندر اسلایدها به صورت تصاویر بیت‌مپ، [RenderingOptions.InkOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/inkoptions/) را پیکربندی کنید و گزینه‌های رندر را به متد [ISlide.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/getimage/) پاس دهید.

مثال C# زیر اسلاید اول را به تصویر PNG بدون اشیاء جوهر رندر می‌کند:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **کنترل رندر ماسک جوهر**

ویژگی [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) نحوهٔ تفسیر عملیات ماسک را هنگام رندر قلم‌موهای جوهر کنترل می‌کند. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP این ویژگی را به `false` تنظیم کنید.

مثال C# زیر یک اسلاید را به SVG صادر می‌کند و برای عملیات ماسک جوهر از رندر مبتنی بر ROP استفاده می‌کند:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

همین تنظیم می‌تواند از طریق [TiffOptions.InkOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/tiffoptions/inkoptions/) هنگام صادرات یک ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب اینکه جوهر مخفی یا حفظ شود**

هنگامی که فایل استخراج‌شده باید نسخهٔ پاکی از ارائه حاشیه‌دار باشد (مثلاً نسخهٔ نهایی برای توزیع بدون علامت‌گذاری‌های بازبینی)، ویژگی [IInkOptions.HideInk](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/hideink/) را به `true` تنظیم کنید.

در صورتی که حاشیه‌نویسی‌های جوهر بخشی از محتوای موردنظر باشد (مانند نظرات بازبینی، یادداشت‌های دست‌نویس، برجسته‌سازی‌ها یا نقاشی‌ها)، مقدار پیش‌فرض `false` را نگه دارید. این اجازه می‌دهد برنامه‌ها خروجی‌های بازبینی و نهایی را از یک ارائه بدون تغییر اشیاء جوهر منبع تولید کنند.

## **سوالات متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**

بله. رد را از [IInk.Traces](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iink/traces/) دریافت کنید، سپس قلم‌موهای آن را با [IInkTrace.Brush](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iinktrace/brush/) تغییر دهید. می‌توانید رنگ ([IInkBrush.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iinkbrush/color/)) و اندازه ([IInkBrush.Size](https://reference.aspose.com/slides/fa/net/aspose.slides.ink/iinkbrush/size/)) قلم‌مو را تنظیم کنید.

**آیا مخفی‌کردن جوهر منبع ارائه را تغییر می‌دهد؟**

خیر. ویژگی [IInkOptions.HideInk](https://reference.aspose.com/slides/fa/net/aspose.slides.export/iinkoptions/hideink/) تنها بر نتیجهٔ رندر یا استخراج تأثیر می‌گذارد؛ اشیاء جوهر در ارائه منبع حذف یا تغییر نمی‌یابند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های استخراج یا رندرینگ مربوطه که در جدول بالا آمده‌اند، پیکربندی کنید.

**مطالعهٔ بیشتر**

* برای آشنایی کلی با اشکال، به بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/net/powerpoint-shapes/) مراجعه کنید.
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/net/shape-effective-properties/#get-effective-font-height-value) نگاه کنید.
* برای جزئیات استخراج PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/net/convert-powerpoint-to-pdf/) مراجعه کنید.
* برای جزئیات استخراج HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/net/convert-powerpoint-to-html/) نگاه کنید.
* برای جزئیات استخراج SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/net/render-a-slide-as-an-svg-image/) مراجعه کنید.
* برای جزئیات استخراج TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/net/convert-powerpoint-to-tiff/) نگاه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/net/convert-slide/) مراجعه کنید.