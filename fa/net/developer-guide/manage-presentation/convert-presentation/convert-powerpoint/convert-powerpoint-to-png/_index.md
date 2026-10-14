---
title: تبدیل اسلایدهای PowerPoint به PNG در .NET
linktitle: PowerPoint به PNG
type: docs
weight: 30
url: /fa/net/convert-powerpoint-to-png/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به‌صورت PNG
- ذخیره PPTX به‌صورت PNG
- صدور PPT به PNG
- صدور PPTX به PNG
- .NET
- C#
- Aspose.Slides
description: "ارائه‌های PowerPoint را به‌سرعت به تصاویر PNG با کیفیت بالا تبدیل کنید با Aspose.Slides برای .NET، به‌طوری که نتایج دقیق و خودکار تضمین شوند."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه اسلایدهای ارائه را به تصویرهای PNG با استفاده از Aspose.Slides برای .NET تبدیل کنید. می‌توانید ارائه‌ها را در فرمت‌هایی مانند PPT، PPTX و ODP بارگذاری کنید، هر اسلاید را رندر کنید و به‌عنوان تصویر PNG جداگانه ذخیره کنید.

مثال‌های زیر نحوه رندرینگ تصویرهای بندانگشتی، تنظیم عوامل مقیاس، مشخص کردن ابعاد خروجی به پیکسل و انتخاب سبک رندرینگ شیب‌دار را نشان می‌دهند.

## **تبدیل پاورپوینت به PNG**

یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری کنید و اسلایدهای آن را از طریق مجموعه [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) دسترسی پیدا کنید. این مثال هر اسلاید را با استفاده از [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) بدون پارامتر برای ایجاد تصویر بندانگشت رندر می‌کند. سپس [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) را با [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) صدا می‌زند تا هر اسلاید رندر شده به عنوان تصویر PNG ذخیره شود.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
بارگذاری بدون پارامتر [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) با مقیاس 0.2 رندر می‌کند. به عنوان مثال، اسلایدی با اندازه 720 × 540 نقطه تصویر بندانگشت 144 × 108 پیکسل تولید می‌کند. برای کنترل ابعاد خروجی، از بارگذاری‌های با عوامل مقیاس یا اندازه تصویر صریح که در زیر نشان داده شده استفاده کنید.
{{% /alert %}}

## **تبدیل پاورپوینت به PNG با ابعاد سفارشی**

عوامل مقیاس افقی و عمودی را به [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) پاس می‌دهید تا ابعاد رندر شده کنترل شود. در این مثال، هر دو عامل برابر 2 هستند، بنابراین اسلایدی با اندازه 720 × 540 نقطه تصویر 1440 × 1080 پیکسل تولید می‌کند. عوامل مقیاس برابر نسبت عرض به ارتفاع اسلاید را حفظ می‌کنند. هر تصویر با استفاده از [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) در قالب PNG ذخیره می‌شود.
```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **تبدیل پاورپوینت به PNG با اندازه سفارشی**

برای مشخص کردن ابعاد خروجی به پیکسل، به جای عوامل مقیاس، یک اندازه را به [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) پاس می‌دهید. این مثال هر اسلاید را با ابعاد 960 × 720 پیکسل رندر می‌کند و نتیجه را با [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) ذخیره می‌نماید. ابعادی را انتخاب کنید که نسبت عرض به ارتفاع اسلاید را حفظ کنند تا از کشیده شدن تصویر جلوگیری شود.
```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **انتخاب یک سبک رندرینگ شیب‌دار**

فرض کنید اسلایدی شامل پرکردن‌های گرادیان باشد، اما انتقال‌ها در PNG صادر شده روشن‌تر یا به‌طوری متفاوت نسبت به آنچه در پاورپوینت می‌بینید به نظر برسد. می‌توانید از خاصیت [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) در [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) برای انتخاب نحوه رندرینگ گرادیان‌ها استفاده کنید.

فایل [gradient-styles.pptx](gradient-styles.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اولین اسلاید آن حاوی دو گرادیان خطی است: از فیروزه‌ای به نارنجی در بالا و از آبی به زرد در پایین. هر گرادیان دو ایستگاه دارد، در 0٪ و 100٪.

مثال زیر این ارائه را بارگذاری می‌کند و همان اسلاید اول را در هر دو حالت با [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) رندر می‌نماید.
```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

تصاویر زیر خروجی اسلاید یکسان را نشان می‌دهند، با هر دو گرادیان در هر تصویر:

| Default | PowerPointUI |
| --- | --- |
| ![گرادیان‌های فیروزه‌ای‑به‑نارنجی و آبی‑به‑زرد رندر شده با Default](gradient-Default.png) | ![همان گرادیان‌ها رندر شده با PowerPointUI](gradient-PowerPointUI.png) |

در این مثال، `Default` رنگ‌های میانی روشن‌تری تولید می‌کند، در حالی که `PowerPointUI` رنگ‌های میانی تیره‌تری تولید می‌کند. تفاوت به رنگ‌ها و ایستگاه‌های موجود در گرادیان بستگی دارد.

`Default` را هنگامی که خروجی استاندارد Aspose.Slides نیازهای شما را برآورده می‌کند انتخاب کنید. `PowerPointUI` را وقتی که اولویت شما تطبیق ظاهر در پاورپوینت است، امتحان کنید. هر دو خروجی را با نتایج مورد نظر خود مقایسه کنید؛ هیچ‌یک از حالت‌ها به‌صورت کلی برتر نیستند.

## **پرسش‌های متداول**

**چگونه می‌توانم یک شکل خاص، مانند نمودار یا تصویر، را به‌جای کل اسلاید صادر کنم؟**

Aspose.Slides از [ساخت تصویرهای بندانگشتی برای اشکال منفرد](/slides/fa/net/create-shape-thumbnails/) پشتیبانی می‌کند که به شما امکان رندر یک شکل به‌صورت تصویر PNG را می‌دهد.

**آیا تبدیل موازی در سرور پشتیبانی می‌شود؟**

بله. برای هر رشته یا فرایند یک نمونه جداگانه ارائه استفاده کنید؛ [یک نمونه را بین رشته‌ها به اشتراک نگذارید](/slides/fa/net/multithreading/).

**محدودیت‌های ارزیابی هنگام صادر کردن به PNG چیست؟**

حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمان فعال‌سازی لایسنس [محدودیت‌های دیگر](/slides/fa/net/licensing/) را اعمال می‌نماید.