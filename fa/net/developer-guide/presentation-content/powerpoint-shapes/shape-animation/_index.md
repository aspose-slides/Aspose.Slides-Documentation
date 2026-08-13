---
title: اعمال انیمیشن‌های شکل در ارائه‌ها در .NET
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/net/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انیمیشن‌های شکل را در ارائه‌های PowerPoint با Aspose.Slides برای .NET ایجاد و سفارشی کنید. برجسته شوید!"
---
## **معرفی**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](/slides/fa/net/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند. 

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

* کنترل جریان اطلاعات  
* برجسته کردن نکات مهم  
* افزایش علاقه یا مشارکت بین مخاطبان  
* ساده‌تر کردن خواندن یا جذب یا پردازش محتوا  
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه  

PowerPoint گزینه‌ها و ابزارهای بسیاری برای انیمیشن‌ها و اثرهای انیمیشن در دسته‌بندی‌های **ورود**، **خروج**، **تاکید** و **مسیرهای حرکتی** ارائه می‌دهد. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌هایی که برای کار با انیمیشن‌ها نیاز دارید را تحت فضای نام [Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/) فراهم می‌کند،  
* Aspose.Slides بیش از **150 اثر انیمیشن** را تحت شمارشگر [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype) ارائه می‌دهد. این اثرها عملاً همان (یا معادل) اثرهایی هستند که در PowerPoint استفاده می‌شوند.  

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای .NET به شما اجازه می‌دهد انیمیشن را بر روی متن داخل یک شکل اعمال کنید. 

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. از طریق ایندکس، به مرجع یک اسلاید دست پیدا کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه کنید.  
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape/properties/textframe) اضافه کنید.  
5. یک توالی اصلی از اثرها دریافت کنید.  
6. یک اثر انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه کنید.  
7. خاصیت [TextAnimation.BuildType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/textanimation/properties/buildtype) را به مقداری از [BuildType Enumeration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype) تنظیم کنید.  
8. ارائه را به‌صورت یک فایل PPTX روی دیسک ذخیره کنید.  

این کد C# نشان می‌دهد چگونه اثر `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // یک AutoShape جدید با متن اضافه می‌کند
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // سه پاراگراف اضافه می‌کند تا ساختار بر اساس پاراگراف مورد استفاده چیزی برای عبور داشته باشد.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // دنبالهٔ اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = sld.Timeline.MainSequence;

    // اثر انیمیشن Fade را به شکل اضافه می‌کند
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌کند
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 
علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن‌ها را به یک [Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph) واحد نیز اعمال کنید. به [**متن متحرک**](/slides/fa/net/animated-text/) نگاه کنید.
{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. از طریق ایندکس به مرجع یک اسلاید دست پیدا کنید.  
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe) بر روی اسلاید اضافه یا دریافت کنید.  
5. توالی اصلی اثرها را دریافت کنید.  
6. یک اثر انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe) اضافه کنید.  
8. ارائه را به‌صورت یک فایل PPTX روی دیسک ذخیره کنید.  

این کد C# نشان می‌دهد چگونه اثر `Fly` را به یک قاب تصویر (picture frame) اعمال کنید:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation pres = new Presentation())
{
    // تصویر را بارگذاری می‌کند تا در مجموعه تصاویر ارائه اضافه شود
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // یک فریم تصویر به اسلاید اضافه می‌کند
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // دنبالهٔ اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // اثر انیمیشن Fly از سمت چپ را به فریم تصویر اضافه می‌کند
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](http://www.aspose.com/api/net/slides/fa/aspose.slides/) ایجاد کنید.  
2. از طریق ایندکس به مرجع یک اسلاید دست پیدا کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه کنید.  
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/iautoshape) اضافه کنید (هنگامی که این شیء کلیک شود، انیمیشن اجرا می‌شود).  
5. یک توالی از اثرها بر روی شکل Bevel ایجاد کنید.  
6. یک `UserPath` سفارشی ایجاد کنید.  
7. دستورات حرکت به `UserPath` را اضافه کنید.  
8. ارائه را به‌صورت یک فایل PPTX روی دیسک ذخیره کنید.  

این کد C# نشان می‌دهد چگونه اثر `PathFootball` (مسیر فوتبال) را به یک شکل اعمال کنید:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // اثر PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // اثر انیمیشن PathFootBall را اضافه می‌کند.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // یک نوع "دکمه" ایجاد می‌کند.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // یک دنبالهٔ اثرها برای دکمه ایجاد می‌کند.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // یک مسیر سفارشی کاربر ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه جابه‌جا خواهد شد.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // دستورات جابجایی را اضافه می‌کند چون مسیر ایجاد شده خالی است.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // فایل PPTX را روی دیسک می‌نویسد
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **دریافت اثرهای انیمیشن اعمال‌شده به یک Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `GetEffectsByShape` موجود در رابط [ISequence](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/) برای دریافت تمام اثرهای انیمیشن اعمال‌شده به یک شکل استفاده کنید.  

**مثال 1: دریافت اثرهای انیمیشن اعمال‌شده به یک شکل در اسلاید عادی**

قبلاً یاد گرفته‌اید چگونه اثرهای انیمیشن را به شکل‌ها در ارائه‌های PowerPoint اضافه کنید. کد نمونهٔ زیر نشان می‌دهد چگونه اثرهای اعمال‌شده به اولین شکل در اولین اسلاید عادی در ارائه `AnimExample_out.pptx` را دریافت کنید.
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // دنبالهٔ انیمیشن اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // اولین شکل را در اولین اسلاید دریافت می‌کند.
    IShape shape = firstSlide.Shapes[0];

    // اثرهای انیمیشن اعمال‌شده به شکل را دریافت می‌کند.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**مثال 2: دریافت تمام اثرهای انیمیشن، شامل آنهایی که از نگهدارنده‌ها (placeholders) به ارث برده شده‌اند**

اگر یک شکل در اسلاید عادی دارای نگهدارنده‌هایی باشد که در اسلاید طرح (layout) و/یا اسلاید اصلی (master) قرار دارند، و اثرهای انیمیشن به این نگهدارنده‌ها اضافه شده باشد، تمام اثرهای شکل در طول نمایش اسلاید اجرا می‌شوند، شامل اثرهایی که از نگهدارنده‌ها به ارث رسیده‌اند.  

فرض کنید فایلی از ارائه PowerPoint به نام `sample.pptx` داریم که شامل یک اسلاید است که تنها یک شکل پاورقی با متن "Made with Aspose.Slides" دارد و اثر **Random Bars** بر آن شکل اعمال شده است.  

![Slide shape animation effect](slide-shape-animation.png)

همچنین فرض کنید اثر **Split** بر نگهدارندهٔ پاورقی در اسلاید **layout** اعمال شده است.  

![Layout shape animation effect](layout-shape-animation.png)

و در نهایت، اثر **Fly In** بر نگهدارندهٔ پاورقی در اسلاید **master** اعمال شده است.  

![Master shape animation effect](master-shape-animation.png)

کد نمونهٔ زیر نشان می‌دهد چگونه از متد `GetBasePlaceholder` موجود در رابط [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) برای دسترسی به نگهدارنده‌های شکل و دریافت اثرهای انیمیشن اعمال‌شده به شکل پاورقی استفاده کنید، شامل اثرهایی که از نگهدارنده‌های موجود در اسلایدهای layout و master به ارث رسیده‌اند.  
```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت اثرهای انیمیشن شکل در اسلاید عادی.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // دریافت اثرهای انیمیشن نگهدارنده در اسلاید طرح‌بندی.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // دریافت اثرهای انیمیشن نگهدارنده در اسلاید اصلی.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغییر ویژگی‌های زمان‌بندی اثر انیمیشن**

Aspose.Slides برای .NET به شما اجازه می‌دهد ویژگی‌های Timing (زمان‌بندی) یک اثر انیمیشن را تغییر دهید.

This is the Animation Timing pane and extended menu in Microsoft PowerPoint:
![example1_image](shape-animation.png)

These are the correspondences between PowerPoint Timing and [Effect.Timing](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effect/properties/timing) properties:
- فهرست کشویی **Start** در زمان‌بندی PowerPoint به ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/properties/triggertype) مطابقت دارد.  
- زمان‌بندی PowerPoint **Duration** با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/properties/duration) مطابقت دارد. مدت زمان یک انیمیشن (بر حسب ثانیه) کل زمان لازم برای تکمیل یک چرخهٔ انیمیشن است.  
- زمان‌بندی PowerPoint **Delay** با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/properties/triggerdelaytime) مطابقت دارد.  
- فهرست کشویی **Repeat** در زمان‌بندی PowerPoint با این ویژگی‌ها مطابقت دارد:  
  * ویژگی [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount) که *تعداد* دفعات تکرار اثر را توصیف می‌کند؛  
  * پرچم [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide) که مشخص می‌کند آیا اثر تا پایان اسلاید تکرار شود؛  
  * پرچم [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick) که مشخص می‌کند آیا اثر تا کلیک بعدی تکرار شود.  
- چک‌باکس **Rewind when done playing** در زمان‌بندی PowerPoint با ویژگی [Effect.Timing.Rewind](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/rewind/) مطابقت دارد.  

این نحوهٔ تغییر ویژگی‌های زمان‌بندی Effect است:
1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.  
2. مقادیر جدیدی برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effect/properties/timing) که نیاز دارید تنظیم کنید.  
3. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد C# عملیات را نشان می‌دهد:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // دنبالهٔ اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // اولین اثر در دنبالهٔ اصلی را دریافت می‌کند.
    IEffect effect = sequence[0];

    // TriggerType اثر را برای شروع با کلیک تغییر می‌دهد
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Duration اثر را تغییر می‌دهد
    effect.Timing.Duration = 3f;

    // TriggerDelayTime اثر را تغییر می‌دهد
    effect.Timing.TriggerDelayTime = 0.5f;

    // اگر مقدار Repeat اثر "none" باشد
    if (effect.Timing.RepeatCount == 1f)
    {
        // مقدار Repeat اثر را به "Until Next Click" تغییر می‌دهد
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // مقدار Repeat اثر را به "Until End of Slide" تغییر می‌دهد
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Rewind اثر را فعال می‌کند
        effect.Timing.Rewind = true;
    
    // فایل PPTX را روی دیسک ذخیره می‌کند
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **صدا در اثر انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در اثرهای انیمیشن فراهم می‌کند:  
- [IEffect.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effect/stopprevioussound/) 

### **افزودن صدا به اثر انیمیشن**

این کد C# نشان می‌دهد چگونه یک صدا به اثر انیمیشن اضافه کنید و هنگام شروع اثر بعدی آن را متوقف کنید:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// صوت را به مجموعهٔ صوتی ارائه اضافه می‌کند
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// دنبالهٔ اصلی اسلاید را دریافت می‌کند.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// اولین اثر در دنبالهٔ اصلی را دریافت می‌کند
	IEffect firstEffect = sequence[0];

	// اثر را برای «بدون صدا» بررسی می‌کند
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// صدا را برای اولین اثر اضافه می‌کند
		firstEffect.Sound = effectSound;
	}

	// دنبالهٔ تعاملی اولین اسلاید را دریافت می‌کند.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// پرچم «توقف صدای قبلی» اثر را تنظیم می‌کند
	interactiveSequence[0].StopPreviousSound = true;

	// فایل PPTX را روی دیسک می‌نویسد
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **استخراج صدا از اثر انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
2. از طریق ایندکس به مرجع یک اسلاید دست پیدا کنید.  
3. توالی اصلی اثرها را دریافت کنید.  
4. صداهای جاسازی‌شده در هر اثر انیمیشن را استخراج کنید.  

این کد C# نشان می‌دهد چگونه صداهای جاسازی‌شده در یک اثر انیمیشن را استخراج کنید:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دنبالهٔ اصلی اسلاید را دریافت می‌کند.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // صداهای اثر را به‌صورت آرایه بایت استخراج می‌کند
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **پس از انیمیشن**

Aspose.Slides برای .NET به شما اجازه می‌دهد ویژگی After animation (پس از انیمیشن) یک اثر انیمیشن را تغییر دهید.

![example1_image](shape-after-animation.png)

فهرست کشویی **After animation** در PowerPoint با این ویژگی‌ها مطابقت دارد:  

- ویژگی [IEffect.AfterAnimationType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/afteranimationtype/) که نوع After animation را توصیف می‌کند:  
  * گزینه **More Colors** در PowerPoint با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛  
  * گزینه **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) مطابقت دارد (نوع پیش‌فرض after animation)؛  
  * گزینه **Hide After Animation** در PowerPoint با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛  
  * گزینه **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛  
- ویژگی [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/afteranimationcolor/) که یک قالب رنگ پس از انیمیشن را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ پس از انیمیشن پاک می‌شود.  

این کد C# نشان می‌دهد چگونه یک اثر after animation را تغییر دهید:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // اولین اثر در دنبالهٔ اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // نوع after animation را به Color تغییر می‌دهد
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // رنگ after animation را تنظیم می‌کند
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // فایل PPTX را روی دیسک می‌نویسد
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **متن‌محرک**

Aspose.Slides این ویژگی‌ها را برای کار با بخش *Animate text* یک اثر انیمیشن فراهم می‌کند:  
- ویژگی [IEffect.AnimateTextType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/animatetexttype/) که نوع Animate text اثر را توصیف می‌کند. متن شکل می‌تواند به صورت زیر انیمیشن شود:  
  * همه به‌یک‌باره ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animatetexttype/) نوع)  
  * به‌صورت کلمه به کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animatetexttype/) نوع)  
  * به‌صورت حرف به حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/animatetexttype/) نوع)  
- ویژگی [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/delaybetweentextparts/) یک تاخیر بین بخش‌های متنی (کلمات یا حروف) انیمیشن تنظیم می‌کند. مقدار مثبت درصد مدت زمان اثر را نشان می‌دهد. مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.  

این نحوهٔ تغییر ویژگی‌های Animate text در Effect است:
1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.  
2. ویژگی [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itextanimation/buildtype/) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype/) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.  
3. مقادیر جدیدی برای ویژگی‌های [IEffect.AnimateTextType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/animatetexttype/) و [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/delaybetweentextparts/) تنظیم کنید.  
4. فایل PPTX اصلاح‌شده را ذخیره کنید.  

این کد C# عملیات را نشان می‌دهد:
```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // اولین اثر در دنبالهٔ اصلی را دریافت می‌کند
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // نوع انیمیشن متن اثر را به «As One Object» تغییر می‌دهد
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // نوع Animate text اثر را به «By word» تغییر می‌دهد
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // تاخیر بین کلمات را به 20٪ از مدت زمان اثر تنظیم می‌کند
    firstEffect.DelayBetweenTextParts = 20f;

    // فایل PPTX را روی دیسک می‌نویسد
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

### چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟

با استفاده از [Export to HTML5](/slides/fa/net/export-to-html5/) و فعال کردن [options](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/) مربوط به انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animateshapes/) و [transition](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animatetransitions/) می‌توانید اطمینان حاصل کنید. HTML ساده انیمیشن‌های اسلاید را پخش نمی‌کند، اما HTML5 این قابلیت را دارد.

### تغییر ترتیب z-order (ترتیب لایه) شکل‌ها چگونه بر انیمیشن تاثیر می‌گذارد؟

ترتیب انیمیشن و ترتیب رسم مستقل از هم هستند: یک اثر زمان‌بندی و نوع ظاهر شدن/ناپدید شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/zorderposition/) تعیین می‌کند کدام شی روی کدام قرار می‌گیرد. نتیجهٔ قابل مشاهده ترکیبی از این دو است. (این رفتار کلی PowerPoint است؛ مدل اثرها و اشکال Aspose.Slides نیز همان منطق را دنبال می‌کند.)

### آیا محدودیت‌هایی هنگام تبدیل انیمیشن‌ها به ویدیو برای برخی اثرها وجود دارد؟

به طور کلی، [animations are supported](/slides/fa/net/convert-powerpoint-to-video/) (انیمیشن‌ها پشتیبانی می‌شوند)، اما در موارد نادر یا برای اثرهای خاص ممکن است به‌صورت متفاوتی رندر شوند. توصیه می‌شود با اثرهای مورد استفاده و نسخهٔ کتابخانه تست انجام دهید.