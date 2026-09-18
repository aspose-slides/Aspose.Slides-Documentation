---
title: اعمال انیمیشن‌های شکل در ارائه‌ها در .NET
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/net/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن متحرک را با Aspose.Slides برای .NET اضافه، بررسی و سفارشی کنید."
---
## **نمای کلی**

برای کار با رفتارهای فردی داخل یک افکت یا ویرایش بخش‌های مسیر حرکت، به [انیمیشن سفارشی](/slides/fa/net/custom-animation/) مراجعه کنید.

Aspose.Slides for .NET انیمیشن‌های اسلاید را به عنوان افکت‌ها در یک خط زمانی اسلاید نمایش می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

خط زمانی شامل دو نوع توالی است:

- **توالی اصلی** هنگام پیشروی اسلاید اجرا می‌شود.
- **توالی تعاملی** زمانی که شکل محرک آن کلیک شود، شروع می‌شود.

به دلیل اینکه جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را دارند، برای اکثر محتوای اسلاید از همان متد [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **اضافه کردن انیمیشن‌های شکل**

برای افزودن یک انیمیشن، توالی اصلی اسلاید را دریافت کنید و متد [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) را با شکل هدف، نوع افکت، زیرنوع و محرک فراخوانی کنید. برای افکتی که هنگام کلیک بر روی شکل دیگر شروع می‌شود، یک توالی تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

محرک تعیین می‌کند که یک افکت کی آغاز شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) در توالی اصلی برای کلیک منتظر می‌ماند یا در توالی تعاملی برای کلیک روی شکل محرک.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) همراه با افکت قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) پس از اتمام افکت قبلی شروع می‌شود.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، به جای `targetShape` آن شیء را به [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) پاس دهید. برای گزینه‌های گروه‌بندی ویژه نمودار، به [نمودارهای انیمیشن‌دار](/slides/fa/net/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

زمانی که شکل هدف را می‌دانید، از [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/geteffectsbyshape/) استفاده کنید. برای بررسی همه افکت‌ها، توالی اصلی و هر توالی تعاملی را پیمایش کنید. پیمایش از این‌که فرض شود توالی در اندیس `0` دارای افکت است جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های توالی اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به شکل را دریافت می‌کند و سپس هر توالی را در اسلاید پیمایش می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع جای‌نگهدار یا ویژگی ثابت دیگر شناسایی کنید؛ سپس [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/geteffectsbyshape/) را فراخوانی کنید. فرض نکنید [IShapeCollection.Item](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/item/) در اندیس `0` همیشه شیء موردنظر است.

## **کار با افکت‌های جای‌نگهدار ارث‌برده**

یک جای‌نگهدار در اسلاید عادی می‌تواند رفتار انیمیشن را از جای‌نگهدار متناظر در اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) آن جای‌نگهدار والد را برمی‌گرداند یا زمانی که والد وجود نداشته باشد `null` می‌شود.

در ارائه مثال زیر، پانویس دارای **Random Bars** در اسلاید عادی، **Split** در اسلاید طرح‌بندی و **Fly In** در اسلاید اصلی است.

![تاثیر انیمیشن فوتر در اسلاید عادی](slide-shape-animation.png)

![تاثیر انیمیشن فوتر در اسلاید طرح‌بندی](layout-shape-animation.png)

![تاثیر انیمیشن فوتر در اسلاید اصلی](master-shape-animation.png)

مثال بعدی سلسله مراتب جای‌نگهدار را خود می‌سازد. افکت‌هایی به یک جای‌نگهدار اصلی، یک جای‌نگهدار طرح‌بندی و جای‌نگهدار متناظر در اسلاید عادی اضافه می‌کند. هر فراخوانی به [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) قبل از استفاده از شکل برگشتی بررسی می‌شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **تغییر زمان‌بندی انیمیشن**

پنجره زمان‌بندی **Timing** در PowerPoint به ویژگی‌های [ITiming](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/) نگاشت می‌شود.

![پنجره زمان‌بندی PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **شروع** به [ITiming.TriggerType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/triggertype/) نگاشت می‌شود.
- **مدت** به [ITiming.Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/duration/) نگاشت می‌شود، بر حسب ثانیه.
- **تاخیر** به [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/triggerdelaytime/) نگاشت می‌شود، بر حسب ثانیه.
- **تکرار** به [ITiming.RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount/)، [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick/) یا [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide/) نگاشت می‌شود.
- **بازگردانی پس از اتمام** به [ITiming.Rewind](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/rewind/) نگاشت می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء برگشتی توسط [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع برگشتی [IEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/) از نیاز به شاخص مجموعه غیرضروری جلوگیری می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

یک حالت تکرار را به‌طور عمدی استفاده کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند در مشاهده‌گرهای مختلف نتایج گیج‌کننده‌ای تولید کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick/) و [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide/) را تنظیم کنید و سپس [ITiming.RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount/) را تنظیم کنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صوت جاسازی‌شده را از طریق [IEffect.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/sound/) ارجاع دهد. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/stopprevioussound/) به افکت می‌گوید صوتی که توسط افکت قبلی آغاز شده است را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار یک فایل صوتی محلی به نام `animation-sound.wav` را دارد. دو افکت ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیائی که توسط [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) برگردانده می‌شوند استفاده می‌شود، بنابراین نیازی به شاخص توالی نیست.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **استخراج صداهای جاسازی‌شده افکت**

مثال زیر انتظار یک ارائه محلی به نام `presentation-with-animation-sounds.pptx` را دارد. هر دو توالی اصلی و تعاملی را اسکن می‌کند و هر صدای افکت جاسازی‌شده را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی ارائه‌شده توسط [IAudio.ContentType](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudio/contenttype/) انتخاب می‌شود.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

برای اشیای صوتی بزرگ، از [IAudio.GetStream](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کل شیء در یک آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان افکت، شکل چه کاری انجام دهد.

![پنجره گزینه‌های افکت PowerPoint نمایش تنظیمات After animation](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) امکان باقی‌مانده‌گی شکل بدون تغییر، تغییر رنگ آن، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی را فراهم می‌کند. وقتی نوع برابر با [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) باشد، باید همچنین [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/afteranimationcolor/) تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء برگشتی تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itextanimation/buildtype/) تعیین می‌کند که پاراگراف‌ها به‌صورت همزمان یا به‌صورت سطح پاراگراف ظاهر شوند.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/animatetexttype/) تعیین می‌کند که متن به‌صورت یکجا، کلمه به کلمه یا حرف به حرف ظاهر شود. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/delaybetweentextparts/) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تاخیر بر حسب ثانیه.

مثال زیر به‌صورت مستقل کلمات داخل یک جعبه متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype/) ساخت پاراگراف به پاراگراف را غیر فعال می‌کند تا تنظیم کلمه برای کل قاب متن اعمال شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

برای ساخت یک جعبه متن بر حسب پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype/) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف واحد با افکت اختصاصی، از overload [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) که یک [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [متن انیمیشن‌دار](/slides/fa/net/animated-text/) مراجعه کنید.

## **یادداشت‌های خروجی و سازگاری**

- ذخیره به‌صورت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط برنامه مشاهده‌کننده ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را اجرا نمی‌کنند. هنگام نیاز به نمایش حرکت، از [خروجی HTML5](/slides/fa/net/export-to-html5/)، GIF متحرک یا [تبدیل به ویدیو](/slides/fa/net/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.AnimateShapes](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animateshapes/) را فعال کنید و در صورت نیاز [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animatetransitions/) را نیز فعال کنید.
- رندر ویدیو بسیاری از افکت‌های ورود، تأکیدی، خروج و مسیر حرکت رایج را پشتیبانی می‌کند، اما هر افکت PowerPoint پشتیبانی نمی‌شود. جدول افکت‌ها و انیمیشن‌های پشتیبانی‌شده فعلی را بررسی کنید و ارائه‌های مهم را با نسخه هدف Aspose.Slides خود تست کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از فرمت‌های دیگر ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. نتیجه خروجی را اعتبارسنجی کنید نه فقط بر اساس نام افکت.

## **سوالات متداول**

**چرا یک انیمیشن در PowerPoint ظاهر می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقالات اسلاید اجرا نمی‌شوند. وقتی حرکت باید حفظ شود، به HTML5، GIF متحرک یا ویدیو خروجی بدهید.

**چرا یک افکت در ویدیو به‌صورت متفاوتی اجرا می‌شود؟**

خروجی ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تقریبی پیاده‌سازی می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و قبل از استفاده تولیدی ارائه واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب z‑order شکل فقط بر هم‌پوشانی تأثیر می‌گذارد، در حالی که ترتیب توالی و محرک‌ها بر پخش انیمیشن کنترل دارند. اگر نیاز به ترتیب پخش متفاوت دارید، خط زمان را تغییر دهید.