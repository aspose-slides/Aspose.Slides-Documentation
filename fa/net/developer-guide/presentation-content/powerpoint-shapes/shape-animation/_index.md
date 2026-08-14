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
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
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
description: "یاد بگیرید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن انیمیشن‌دار را با Aspose.Slides برای .NET اضافه، بررسی و سفارشی‌سازی کنید."
---
## **نمای کلی**

Aspose.Slides برای .NET انیمیشن‌های اسلاید را به عنوان افکت‌ها در یک جدول زمانی اسلاید نشان می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- **دنباله تعاملی** زمانی که شکل محرک آن کلیک شود آغاز می‌شود.

به دلیل اینکه جعبه‌های متن، تصویرها، نمودارها، جدول‌ها و سایر اشیای اسلاید [IShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/) را پیاده‌سازی می‌کنند، برای اکثر محتوای اسلاید از همان روش [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن‌های شکل**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و با فراخوانی [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) شکل هدف، نوع افکت، زیرنوع و محرک را مشخص کنید. برای افکتی که هنگام کلیک روی شکل دیگر شروع می‌شود، یک دنباله تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

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

محرک تعیین می‌کند افکت کی شروع شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) برای کلیک در دنباله اصلی یا کلیک روی شکل محرک در دنباله تعاملی صبر می‌کند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) همزمان با افکت قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/effecttriggertype/) پس از اتمام افکت قبلی آغاز می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به جای `targetShape` همان شیء را به [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) پاس دهید. برای گزینه‌های گروه‌بندی خاص نمودار، به [نمودارهای انیمیشن‌دار](/slides/fa/net/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

وقتی شکل هدف را می‌دانید، از [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/geteffectsbyshape/) استفاده کنید. برای بررسی تمام افکت‌ها، هر دنباله اصلی و هر دنباله تعاملی را پیمایشی کنید. پیمایش از این‌گونه فرض جلوگیری می‌کند که یک دنباله حتماً افکتی در اندیس `0` داشته باشد.

مثال زیر یک شکل با افکت‌های دنباله اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به آن شکل را دریافت می‌کند و سپس تمام دنباله‌های اسلاید را پیمایش می‌نماید.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع مکان‌گیر یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/geteffectsbyshape/) را فراخوانی کنید. فرض نکنید که [IShapeCollection.Item](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/item/) در اندیس `0` همیشه شیء موردنظر است.

## **کار با افکت‌های مکان‌گیر به ارث‌برده‌شده**

یک مکان‌گیر در اسلاید عادی می‌تواند رفتار انیمیشن را از مکان‌گیر متناظر در اسلاید چیدمان و اسلاید مستر به ارث ببرد. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) آن مکان‌گیر والد را برمی‌گرداند یا وقتی والد وجود نداشته باشد `null` می‌شود.

در ارائهٔ مثال زیر، پاورقی در اسلاید عادی دارای **Random Bars**، در اسلاید چیدمان **Split** و در اسلاید مستر **Fly In** دارد.

![اثر انیمیشن پاورقی در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن مکان‌گیر پاورقی در اسلاید چیدمان](layout-shape-animation.png)

![اثر انیمیشن مکان‌گیر پاورقی در اسلاید مستر](master-shape-animation.png)

مثال بعدی خود ساختار سلسله‌مراتبی مکان‌گیرها را می‌سازد. افکت‌ها به یک مکان‌گیر مستر، یک مکان‌گیر چیدمان و مکان‌گیر متناظر در اسلاید عادی اضافه می‌شود. قبل از استفاده از هر شکل بازگردانده‌شده توسط [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/getbaseplaceholder/) بررسی می‌شود.

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

دیالوگ **Timing** در پاورپوینت به ویژگی‌های [ITiming](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/) نگاشت می‌یابد.

![دیالوگ Timing در پاورپوینت برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [ITiming.TriggerType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/triggertype/) نگاشت می‌شود.
- **Duration** به [ITiming.Duration](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/duration/) به ثانیه‌ها نگاشت می‌شود.
- **Delay** به [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/triggerdelaytime/) به ثانیه‌ها نگاشت می‌شود.
- **Repeat** به [ITiming.RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount/)، [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick/) یا [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide/) نگاشت می‌شود.
- **Rewind when done playing** به [ITiming.Rewind](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/rewind/) نگاشت می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از شیء بازگردانده شده توسط [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع به [IEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/) از ایجاد ایندکس غیرضروری در مجموعه جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت عمدی استفاده کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند نتایج گیج‌کننده‌ای در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilnextclick/) و [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatuntilendslide/) را تنظیم کنید و سپس [ITiming.RepeatCount](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itiming/repeatcount/) را تنظیم کنید، زیرا تنظیم هر کدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صداهای جاسازی‌شده را از طریق [IEffect.Sound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/sound/) ارجاع دهد. [IEffect.StopPreviousSound](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/stopprevioussound/) به یک افکت می‌گوید صداهای شروع‌شده توسط افکت قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر یک فایل صوتی محلی به نام `animation-sound.wav` را انتظار دارد. دو افکت ایجاد می‌کند، آن فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیائی که توسط [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) برگردانده می‌شوند استفاده می‌شود، بنابراین نیازی به اندیس دنباله نیست.

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

### **استخراج صداهای جاسازی‌شدهٔ افکت**

مثال زیر یک ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` را انتظار دارد. دنباله‌های اصلی و تعاملی را اسکن می‌کند و هر صدای افکت جاسازی‌شده را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند از نوع MIME صدا که توسط [IAudio.ContentType](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudio/contenttype/) بازگردانده می‌شود انتخاب می‌گردد.

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

برای اشیای صوتی بزرگ، به‌جای بارگذاری کامل شیء در یک آرایه بایت، از [IAudio.GetStream](https://reference.aspose.com/slides/fa/net/aspose.slides/iaudio/getstream/) استفاده کنید و جریان را به یک فایل کپی کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان افکت، چه اتفاقی برای شکل می‌افتد.

![دیالوگ گزینه‌های افکت پاورپوینت که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) از باقی‌ماندهٔ شکل بدون تغییر، تغییر رنگ، مخفی‌سازی پس از انیمیشن یا مخفی‌سازی در کلیک بعدی پشتیبانی می‌کند. وقتی نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) باشد، همچنین باید [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/afteranimationcolor/) تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء افکت بازگردانده‌شده تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/afteranimationtype/) باعث پاک‌شدن تنظیم رنگ پس‌انیمیشن می‌شود.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/itextanimation/buildtype/) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت سطح پاراگراف ظاهر شوند.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/animatetexttype/) تعیین می‌کند متن به‌صورت یکجا، کلمه به کلمه یا حرف به حرف ظاهر شود. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/ieffect/delaybetweentextparts/) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت یک درصد از مدت افکت است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات یک جعبهٔ متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype/) ساخت پاراگراف به‌صورت پاراگرافی را غیرفعال می‌کند تا تنظیم کلمه برای کل فریم متن اعمال شود.

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

برای ساخت یک جعبهٔ متن به‌صورت پاراگرافی، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/buildtype/) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گیری یک پاراگراف تنها با افکت مختص به خود، از overload متد [ISequence.AddEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.animation/isequence/addeffect/) که یک [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [متن انیمیشن‌دار](/slides/fa/net/animated-text/) مراجعه کنید.

## **صادر کردن و نکات سازگاری**

- ذخیره به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصویرهای ثابت انیمیشن را پخش نمی‌کنند. هنگامی که خروجی باید حرکت را نشان دهد، از [صدور به HTML5](/slides/fa/net/export-to-html5/)، GIF انیمیشن‌دار یا [تبدیل به ویدئو](/slides/fa/net/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.AnimateShapes](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animateshapes/) را فعال کنید و در صورت نیاز [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/html5options/animatetransitions/) را نیز فعال نمایید.
- رندر ویدئویی بسیاری از افکت‌های ورود، تأکید، خروج و مسیر حرکت رایج را پشتیبانی می‌کند، اما تمام افکت‌های پاورپوینت پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/net/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های حیاتی را با نسخهٔ هدف Aspose.Slides خود تست نمایید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از فرمت‌های ارائهٔ دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدئو به‌صورت متفاوت رندر شوند. نتیجهٔ صادرشده را اعتبارسنجی کنید نه تنها بر پایهٔ نام افکت.

## **سؤالات متداول**

**چرا یک انیمیشن در پاورپوینت ظاهر می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. هنگام نیاز به حفظ حرکت، به HTML5، GIF انیمیشن‌دار یا ویدئو صادر کنید.

**چرا یک افکت در ویدئو به‌صورت متفاوتی اجرا می‌شود؟**

صدور ویدئو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی پاورپوینت را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نشده یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و قبل از استفادهٔ تولیدی ارائهٔ واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب z‑order شکل تنها تداخل را کنترل می‌کند، در حالی که ترتیب دنباله و محرک‌ها ترتیب پخش انیمیشن را تعیین می‌کنند. اگر به ترتیب پخش متفاوت نیاز دارید، جدول زمان‌بندی را تغییر دهید.