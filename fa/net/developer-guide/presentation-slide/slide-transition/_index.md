---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با .NET
linktitle: انتقال اسلاید
type: docs
weight: 90
url: /fa/net/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "انتقال‌های اسلاید را اعمال کنید، پیشروی خودکار اسلایدها را پیکربندی کنید و اثرات Morph و سایر اثرات انتقال را با Aspose.Slides برای .NET سفارشی کنید."
---
## **بررسی کلی**

انتقالات اسلاید نحوه نمایش اسلایدها در یک نمایش اسلاید را کنترل می‌کند. با Aspose.Slides برای .NET می‌توانید یک اثر انتقال برای هر اسلاید انتخاب کنید، پیشروی را با کلیک ماوس یا زمان‌سنج تنظیم کنید و گزینه‌های خاص هر اثر را تنظیم نمایید. این مقاله از مثال‌های C# برای اعمال انتقال‌ها، تنظیم دقیق مدت زمان انتقال، مدیریت زمان‌بندی اسلاید و ایجاد انتقال Morph بین دو اسلاید استفاده می‌کند. مثال‌ها همچنین نشان می‌دهند که چگونه تنظیمات را در یک فایل PPTX ذخیره کنید.

## **افزودن انتقال اسلاید**

برای اعمال یک انتقال، یک ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید و به ویژگی [SlideShowTransition](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/slideshowtransition/) اسلاید دسترسی پیدا کنید. مقدار [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/type/) آن را به یکی از مقادیر enumeration  [TransitionType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitiontype/) تنظیم کنید و سپس ارائه را ذخیره نمایید.

مثال زیر یک انتقال Circle را برای اولین اسلاید و یک انتقال Comb را برای اسلاید دوم اعمال می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **افزودن انتقال پیشرفته اسلاید**

می‌توانید مدت زمان مانده بودن اسلاید بر روی صفحه و این که آیا کلیک ماوس نمایش اسلاید را پیش می‌برد یا نه را پیکربندی کنید. خصوصیات زیر رفتار را کنترل می‌کنند:

- [AdvanceOnClick](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceonclick/) امکان پیشروی با کلیک ماوس را برای بیننده فراهم می‌کند.
- [AdvanceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceafter/) پیشرفت خودکار را فعال می‌کند.
- [AdvanceAfterTime](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceaftertime/) تاخیر پیشرفت خودکار را بر حسب میلی‌ثانیه مشخص می‌سازد.

هر دو پیشرفت با کلیک و زمان‌سنج را فعال کنید تا بیننده بتواند با کلیک پیش برود یا منتظر زمان‌سنج بماند. برای استفاده فقط از زمان‌سنج، مقدار [AdvanceOnClick](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceonclick/) را به `false` تنظیم کنید. تاخیر زمان‌سنج فقط زمان پیشرفت نمایش اسلاید را تعیین می‌کند؛ مدت زمان اثر بصری انتقال را تعیین نمی‌کند.

این مثال اثرهای متفاوتی را به اولین سه اسلاید اختصاص می‌دهد و پیشرفت خودکار را پس از ۳، ۵ و ۷ ثانیه به ترتیب فعال می‌کند. کلیک‌های ماوس نیز می‌توانند این اسلایدها را پیش ببرند. از فایلی به نام `input.pptx` با حداقل سه اسلاید استفاده کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

برای بررسی اینکه آیا پیشرفت زمان‌دار فعال است، مقدار [AdvanceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceafter/) را بخوانید. تنها وجود یک تاخیر ذخیره‌شده، نشانه فعال بودن زمان‌سنج نیست.

مثال بعدی فایل ذخیره‌شده در بالا را باز می‌کند، هر زمان‌سنج فعال را گزارش می‌دهد و پیشرفت خودکار را برای اسلایدهایی که تاخیر بیش از دو ثانیه دارند غیرفعال می‌کند. برای آن اسلایدها کلیک ماوس فعال می‌شود و تنظیمات به‌روز شده ذخیره می‌شوند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **کنترل دقیق زمان‌بندی انتقال**

از [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/duration/) برای تعیین دقیق طول یک اثر انتقال بر حسب میلی‌ثانیه استفاده کنید. ویژگی [SlideShowTransition](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/slideshowtransition/) اسلاید این تنظیمات را از طریق [ISlideShowTransition](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/) افشا می‌کند:

| ویژگی | منظور |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/duration/) | مدت زمان خود اثر انتقال را بر حسب میلی‌ثانیه تنظیم می‌کند. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | تاخیر پیشرفت خودکار اسلاید را بر حسب میلی‌ثانیه تنظیم می‌کند. برای فعال‌سازی این زمان‌سنج، [AdvanceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceafter/) را فعال کنید. |
| [Speed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/speed/) | یک دسته سرعت از پیش تعریف شده از [TransitionSpeed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionspeed/) را انتخاب می‌کند: Slow، Medium یا Fast. وقتی مدت زمان دقیق تعیین نشده باشد استفاده می‌شود. |

[Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/duration/) فقط بر اثر انتقال تأثیر دارد؛ مدت زمان باقی ماندن اسلاید بر صفحه را تعیین نمی‌کند. تاخیر پیشرفت خودکار را جداگانه تنظیم کنید. وقتی مدت زمان صریحی تعیین نشود، Aspose.Slides مدت زمان اثر را از نوع انتقال و مقدار [Speed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/speed/) محاسبه می‌کند.

### **اعمال همان مدت زمان به همه اسلایدها**

برای حفظ یکنواختی زمان‌بندی، همان اثر و همان مدت زمان دقیق را به همه اسلایدها اعمال کنید. این مثال `input.pptx` را بارگذاری می‌کند، نوع Fade را از [TransitionType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitiontype/) انتخاب می‌کند و به هر انتقال مدت زمان ۷۵۰ میلی‌ثانیه می‌دهد. به‌طور جداگانه پیشرفت خودکار پس از ۵۰۰۰ میلی‌ثانیه فعال و پیشرفت با کلیک ماوس غیرفعال می‌شود، سپس نتیجه به‌عنوان PPTX ذخیره می‌گردد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // پیکربندی پیشروی خودکار به صورت مستقل از مدت زمان اثر.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **تنظیم مدت زمان‌های متفاوت برای اسلایدهای جداگانه**

اسلایدهای مختلف می‌توانند مدت زمان اثر متفاوتی داشته باشند. به‌عنوان مثال، برای اسلاید عنوان یک انتقال کوتاه و برای اسلاید معرفی بخش یک انتقال طولانی‌تر استفاده کنید. این مثال برای اسلاید اول ۵۰۰ میلی‌ثانیه و برای اسلاید دوم ۱۲۰۰ میلی‌ثانیه تنظیم می‌کند. از فایلی به نام `input.pptx` که حداقل دو اسلاید دارد استفاده کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **هماهنگی انتقال‌ها با خروجی انیمیشنی**

هنگام آماده‌سازی یک [animated GIF](/slides/fa/net/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/fa/net/export-to-html5/) یا [video](/slides/fa/net/convert-powerpoint-to-video/)، قبل از خروجی‌گیری مدت زمان دقیق انتقال‌ها را تنظیم کنید تا با ریتم موردنظر هماهنگ شوند. به‌عنوان مثال، بین صحنه‌ها یک محو شدن ۶۰۰ میلی‌ثانیه‌ای استفاده کنید و تاخیر پیشرفت هر اسلاید را جداگانه تنظیم کنید تا زمان کافی برای روایت یا محتوا باقی بماند.

برای GIF و ویدیو، نرخ فریم خروجی را با مدت زمان اثر هماهنگ کنید: ۶۰۰ میلی‌ثانیه معادل ۱۸ فریم در ۳۰ فریم بر ثانیه است. در HTML5، انتقال‌های انیمیشنی را در تنظیمات خروجی فعال کنید. گزینه‌های پشتیبانی‌شده توسط فرمت خروجی را بررسی کنید و خروجی را پیش‌نمایش کنید تا هماهنگی تأیید شود.

### **خواندن مدت زمان موجود برای یک انتقال**

قبل از تغییر انتقال، مقدار [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/duration/) را بخوانید تا ببینید آیا مقدار صریحی ذخیره شده است یا نه. مقدار `-1` به این معنی است که هیچ مدت زمان صریحی تنظیم نشده؛ مقدار غیرمنفی مدت زمان ذخیره‌شده بر حسب میلی‌ثانیه را نشان می‌دهد. مقدار تنظیم‌نشده محاسبه شده توسط پخش نیست: Aspose.Slides مدت زمان را از نوع انتقال و مقدار [Speed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/speed/) تعیین می‌کند. تنظیم نوع انتقال می‌تواند یک مدت زمان پیش‌فرض ایجاد کند، بنابراین ابتدا تنظیمات اصلی را بررسی کنید.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **انتقال Morph**

انتقال Morph تغییرات بین اشیاء روی اسلایدهای متوالی را انیمیشن می‌دهد. برای ایجاد یک اثر ساده Morph، یک اسلاید را کپی کنید، شیء‌ای را روی نسخه کپی جابجا یا تغییر اندازه دهید و انتقال Morph را به اسلاید دوم اعمال کنید. این کار اشیاء مربوطه را برای انیمیشن بین حالت اصلی و تغییر یافته فراهم می‌سازد.

مثال زیر یک اسلاید حاوی مستطیل متن ایجاد می‌کند، اسلاید را کپی می‌نماید و موقعیت و اندازه مستطیل را در نسخه کپی تغییر می‌دهد. سپس برای اسلاید دوم از نوع Morph در enumeration [TransitionType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitiontype/) استفاده می‌کند. فایل ذخیره‌شده را در یک نمایشگر پشتیبانی‌کننده Morph باز کنید تا اثر را در حین نمایش اسلاید ببینید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **انواع انتقال Morph**

enumeration  [TransitionMorphType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionmorphtype/) نحوه مطابقت و انیمیشن محتوای Morph را کنترل می‌کند:

- [ByObject](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionmorphtype/) هر شکل را به‌عنوان یک شیء کامل در نظر می‌گیرد.
- [ByWord](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت کلمات (در صورت امکان) انیمیشن می‌دهد.
- [ByChar](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionmorphtype/) متن را با مطابقت کاراکترها (در صورت امکان) انیمیشن می‌دهد.

قبل از دسترسی به ویژگی [Value](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/value/) نوع انتقال را به Morph تنظیم کنید. سپس این مقدار رابط [IMorphTransition](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/imorphtransition/) را فراهم می‌کند که ویژگی [MorphType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/imorphtransition/morphtype/) حالت مطابقت را انتخاب می‌کند.

این مثال ارائه‌ای که در بخش قبلی ایجاد شد را باز می‌کند و اسلاید دوم را برای انیمیشن Morph بر پایه کلمات پیکربندی می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **تنظیم اثرات انتقال**

برخی از انتقال‌ها گزینه‌های اضافی مثل جهت یا این که آیا اثر از یک صفحه سیاه شروع می‌شود را ارائه می‌دهند. گزینه‌های موجود به نوع انتقال انتخاب‌شده در [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/type/) بستگی دارد. ابتدا نوع را تنظیم کنید، سپس از اینترفیس مناسب در [Value](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/value/) استفاده کنید.

مثال زیر یک انتقال Cut را به اسلاید اول `input.pptx` اعمال می‌کند. ویژگی [FromBlack](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) را از طریق [IOptionalBlackTransition](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/ioptionalblacktransition/) تنظیم می‌کند تا انتقال از یک صفحه سیاه شروع شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **سوالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. وقتی به زمان دقیق اثر به میلی‌ثانیه نیاز دارید، از [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/duration/) استفاده کنید. وقتی یک دسته سرعت از پیش تعریف‌شده — [TransitionSpeed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionspeed/) (Slow، Medium یا Fast) — کافی است و مقدار صریحی تنظیم نشده، از [Speed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/speed/) استفاده کنید. این تنظیمات اثر انتقال را مستقل از تاخیر پیشرفت خودکار کنترل می‌کنند.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و آن را حلقهٔ‌ای کنم؟**

بله. صدا تعبیه‌شده را به ویژگی [Sound](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/sound/) اختصاص دهید، [SoundMode](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/soundmode/) را به StartSound از enumeration  [TransitionSoundMode](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionsoundmode/) تنظیم کنید و [SoundLoop](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/soundloop/) را فعال کنید. صدا تا رخداد صوتی بعدی در نمایش اسلاید حلقه می‌زند.

**سریع‌ترین راه برای اعمال همان انتقال به همه اسلایدها چیست؟**

در مجموعه [Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) ارائه حلقه بزنید و برای هر اسلاید مقدار [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/type/) انتقال را به همان مقدار تنظیم کنید. هر تنظیم زمان‌بندی و گزینه اثر را در همان حلقه تنظیم کنید تا رفتار در تمام اسلایدها یکسان بماند.

**چگونه می‌توانم بفهمم که در یک اسلاید چه انتقالي تنظیم شده است؟**

مقدار ویژگی [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/type/) را از [SlideShowTransition](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/slideshowtransition/) اسلاید بخوانید. این مقدار از enumeration  [TransitionType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitiontype/) برگشت داده می‌شود؛ مقدار None به این معنی است که هیچ اثر انتقالی اعمال نشده است.