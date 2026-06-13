---
title: تبدیل ارائه‌های PowerPoint به ویدئو در .NET
linktitle: PowerPoint به ویدئو
type: docs
weight: 130
url: /fa/net/convert-powerpoint-to-video/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به ویدئو
- ارائه به ویدئو
- PPT به ویدئو
- PPTX به ویدئو
- PowerPoint به MP4
- ارائه به MP4
- PPT به MP4
- PPTX به MP4
- ذخیره PPT به عنوان MP4
- ذخیره PPTX به عنوان MP4
- صدور PPT به MP4
- صدور PPTX به MP4
- تبدیل ویدئو
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint را به ویدئو در .NET تبدیل کنید. نمونه کد C# و تکنیک‌های خودکارسازی برای بهینه‌سازی گردش کار خود را کشف کنید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint یا OpenDocument خود به ویدئو، شما به دست می‌آورید:

**دسترس‌پذیری بیشتر:** تمام دستگاه‌ها، بدون در نظر گرفتن پلتفرم، به صورت پیش‌فرض دارای پخش‌کننده ویدئو هستند که این باعث می‌شود کاربران به‌جای برنامه‌های سنتی ارائه، راحت‌تر ویدئوها را باز یا پخش کنند.

**دسترسی گسترده‌تر:** ویدئوها به شما امکان می‌دهند تا به جمعیت بزرگ‌تری برسید و اطلاعات را به شکل جذاب‌تری ارائه دهید. نظرسنجی‌ها و آمار نشان می‌دهد که مردم ترجیح می‌دهند محتوای ویدئویی را نسبت به فرم‌های دیگر مشاهده و مصرف کنند، که پیام شما را تاثیرگذارتر می‌سازد.

{{% alert color="primary" %}} 
به **[مبدل آنلاین PowerPoint به Video**](https://products.aspose.app/slides/fa/video) نگاه کنید زیرا اجرای زنده و مؤثر فرآیندی که در اینجا شرح شده را ارائه می‌دهد.
{{% /alert %}} 

در Aspose.Slides برای .NET، ما پشتیبانی از تبدیل ارائه‌ها به ویدئو را پیاده‌سازی کرده‌ایم.

* از Aspose.Slides برای .NET برای تولید فریم‌ها از اسلایدهای ارائه با نرخ فریم مشخص (FPS) استفاده کنید.  
* سپس از ابزاری شخص ثالث مانند ffmpeg برای ترکیب این فریم‌ها به یک ویدئو بهره بگیرید.

## **تبدیل یک ارائه PowerPoint به ویدئو**

1. از فرمان `dotnet add package` برای افزودن Aspose.Slides و کتابخانه FFMpegCore به پروژه خود استفاده کنید:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دریافت کنید.
3. FFMpegCore نیاز دارد مسیر ffmpeg دانلود شده (مثلاً استخراج شده در "C:\tools\ffmpeg") را مشخص کنید:  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. کد تبدیل PowerPoint‑to‑video را اجرا کنید.

این کد C# نشان می‌دهد چگونه یک ارائه (شامل یک شکل و دو اثر انیمیشن) را به ویدئو تبدیل کنیم:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // از باینری‌های FFmpeg که قبلاً به C:\tools\ffmpeg استخراج کرده‌ایم استفاده می‌کند.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک شکل خنده اضافه می‌کند و سپس آن را انیمیشن می‌دهد.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // پوشه باینری‌های ffmpeg را پیکربندی کنید. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // فریم‌ها را به یک ویدئوی webm تبدیل کنید.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **افکت‌های ویدئو**

هنگام تبدیل یک ارائه PowerPoint به ویدئو با Aspose.Slides برای .NET، می‌توانید افکت‌های ویدئویی مختلفی را برای بهبود کیفیت بصری خروجی اعمال کنید. این افکت‌ها به شما امکان می‌دهند ظاهر اسلایدها را در ویدئوی نهایی با افزودن انتقال‌های صاف، انیمیشن‌ها و سایر عناصر بصری کنترل کنید. این بخش گزینه‌های افکت ویدئویی موجود را توضیح می‌دهد و نشان می‌دهد چگونه آن‌ها را اعمال کنید.

{{% alert color="primary" %}} 
مشاهده کنید:
- [تقویت ارائه‌های PowerPoint با انیمیشن‌ها در C#](https://docs.aspose.com/slides/fa/net/powerpoint-animation/)
- [انیمیشن شکل](https://docs.aspose.com/slides/fa/net/shape-animation/)
- [اعمال افکت‌های شکل در PowerPoint با C#](https://docs.aspose.com/slides/fa/net/shape-effect/)
{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها اسلایدشوها را جذاب‌تر می‌سازند — و برای ویدئوها هم همین‌طور عمل می‌کنند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:

```c#
// یک شکل خنده اضافه کنید و آن را انیمیشن کنید.
// ...

// یک اسلاید جدید اضافه کنید و یک انتقال انیمیشنی اعمال کنید.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides همچنین از انیمیشن‌های متنی پشتیبانی می‌کند. در این مثال، پاراگراف‌های شیء را به‌صورت متوالی با یک ثانیه تأخیر بین هر کدام انیمیشن می‌کنیم:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // متن و انیمیشن‌ها را اضافه کنید.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // پوشه باینری‌های ffmpeg را پیکربندی کنید. این صفحه را ببینید: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // فریم‌ها را به یک ویدئوی webm تبدیل کنید.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **کلاس‌های تبدیل ویدئو**

برای فعال‌سازی وظایف تبدیل PowerPoint به ویدئو، Aspose.Slides برای .NET کلاس‌های [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/net/aspose.slides.export/presentationanimationsgenerator/) و [PresentationPlayer](https://reference.aspose.com/slides/fa/net/aspose.slides.export/presentationplayer/) را فراهم می‌کند.

`PresentationAnimationsGenerator` به شما اجازه می‌دهد تا اندازه فریم برای ویدئو (که بعداً ساخته می‌شود) و مقدار FPS (فریم بر ثانیه) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را پاس دهید، `Presentation.SlideSize` آن به‌کار گرفته می‌شود و انیمیشن‌هایی را تولید می‌کند که [PresentationPlayer](https://reference.aspose.com/slides/fa/net/aspose.slides.export/presentationplayer/) استفاده می‌کند.

هنگامی که انیمیشن‌ها تولید می‌شوند، برای هر انیمیشن بعدی یک رویداد `NewAnimation` فعال می‌شود که شامل پارامتر [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipresentationanimationplayer/) است. این کلاس نمایانگر یک پلیر برای یک انیمیشن منفرد است.

برای کار با [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipresentationanimationplayer/)، از ویژگی [Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipresentationanimationplayer/duration/) (که مدت زمان کامل انیمیشن را می‌دهد) و متد [SetTimePosition](https://reference.aspose.com/slides/fa/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) استفاده می‌کنید. هر موقعیت انیمیشن در بازه *0 تا duration* تنظیم می‌شود و سپس متد `GetFrame` یک Bitmap نشان‌دهنده وضعیت انیمیشن در آن لحظه زمانی برمی‌گرداند.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک شکل خنده اضافه کنید و آن را انیمیشن کنید.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // وضعیت اولیه انیمیشن.
            Bitmap bitmap = animationPlayer.GetFrame();  // نقشه بیت وضعیت اولیه انیمیشن.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // وضعیت نهایی انیمیشن.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // آخرین فریم انیمیشن.
            lastBitmap.Save("last.png");
        };
    }
}
```

برای پخش همزمان تمام انیمیشن‌های یک ارائه، کلاس [PresentationPlayer](https://reference.aspose.com/slides/fa/net/aspose.slides.export/presentationplayer/) استفاده می‌شود. این کلاس یک نمونه از [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/net/aspose.slides.export/presentationanimationsgenerator/) و مقدار FPS را در سازنده‌اش می‌گیرد و سپس برای تمام انیمیشن‌ها رویداد `FrameTick` را فراخوانی می‌کند تا آن‌ها را پخش کند:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

سپس فریم‌های تولید‌شده می‌توانند ترکیب شده و ویدئویی ساخته شود. بخش [تبدیل یک ارائه PowerPoint به ویدئو](/slides/fa/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

هنگام تبدیل یک ارائه PowerPoint به ویدئو با Aspose.Slides برای .NET، مهم است بدانید کدام انیمیشن‌ها و افکت‌ها در خروجی پشتیبانی می‌شوند. Aspose.Slides طیف گسترده‌ای از افکت‌های ورودی، خروجی و تأکیدی رایج مانند محو شدن، پرواز، بزرگ‌نمایی و چرخش را پشتیبانی می‌کند. با این حال، برخی از انیمیشن‌های پیشرفته یا سفارشی ممکن است به‌طور کامل حفظ نشوند یا در ویدئوی نهایی متفاوت ظاهر شوند. این بخش به تشریح انیمیشن‌ها و افکت‌های پشتیبانی‌شده می‌پردازد.

**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fade** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Fly In** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Float In** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Split** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Wipe** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Shape** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Wheel** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Random Bars** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Grow & Turn** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Zoom** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Swivel** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Bounce** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |

**تأکیدی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Color Pulse** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Teeter** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Spin** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Grow/Shrink** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Desaturate** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Darken** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Lighten** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Transparency** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Object Color** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Complementary Color** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Line Color** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fill Color** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |

**خروجی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fade** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Fly Out** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Float Out** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Split** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Wipe** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Shape** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Random Bars** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Shrink & Turn** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Zoom** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Swivel** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Bounce** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Arcs** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Turns** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Shapes** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Loops** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Custom Path** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |

## **افکت‌های انتقال اسلاید پشتیبانی‌شده**

افکت‌های انتقال اسلاید نقش مهمی در ایجاد تغییرات روان و جذاب بین اسلایدها در یک ویدئو ایفا می‌کنند. Aspose.Slides برای .NET مجموعه‌ای از افکت‌های انتقال رایج را پشتیبانی می‌کند تا جریان و سبک ارائه اصلی شما حفظ شود. این بخش به افکت‌های انتقالی که در فرآیند تبدیل پشتیبانی می‌شوند، می‌پردازد.

**ملایم**:

| نوع انتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fade** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Push** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Pull** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Wipe** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Split** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Reveal** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Random Bars** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Shape** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Uncover** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Cover** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Flash** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Strips** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |

**هیجان‌انگیز**:

| نوع انتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Drape** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Curtains** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Wind** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Prestige** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fracture** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Crush** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Peel Off** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Page Curl** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Airplane** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Origami** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Dissolve** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Checkerboard** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Blinds** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Clock** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Ripple** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Honeycomb** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Glitter** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Vortex** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Shred** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Switch** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Flip** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Gallery** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Cube** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Doors** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Box** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Comb** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Zoom** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Random** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |

**محتوای دینامیک**:

| نوع انتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Ferris Wheel** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |
| **Conveyor** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Rotate** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Orbit** | ![پشتیبانی نشده](x.png) | ![پشتیبانی شد](v.png) |
| **Fly Through** | ![پشتیبانی شد](v.png) | ![پشتیبانی شد](v.png) |

## **سوالات متداول**

**آیا می‌توان ارائه‌های محافظت‌شده با رمز عبور را تبدیل کرد؟**

بله، Aspose.Slides برای .NET امکان کار با ارائه‌های محافظت‌شده با رمز عبور را دارد. هنگام پردازش این فایل‌ها باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides برای .NET پشتیبانی از استفاده در راه‌حل‌های ابری را دارد؟**

بله، Aspose.Slides برای .NET می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سروری طراحی شده است و عملکرد بالا و مقیاس‌پذیری برای پردازش دسته‌ای فایل‌ها را تضمین می‌کند.

**آیا محدودیتی در اندازه ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides برای .NET می‌تواند ارائه‌های تقریباً با هر اندازه‌ای را مدیریت کند. با این حال، هنگام کار با فایل‌های بسیار بزرگ، ممکن است منابع سیستمی بیشتری مورد نیاز باشد و گاهی توصیه می‌شود که برای بهبود عملکرد، ارائه را بهینه‌سازی کنید.