---
title: تطبيق رسومات متحركة للأشكال في العروض التقديمية بلغة .NET
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/net/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وفحص وتخصيص الرسوم المتحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides لـ .NET."
---
## **نظرة عامة**

Aspose.Slides for .NET تمثل الرسوم المتحركة للشرائح كـ تأثيرات في جدول زمني للشرائح. يحتوي كل تأثير على الشكل المستهدف، ونوع الرسوم المتحركة وتحت النوع، ومُشغل، وإعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

الجدول الزمني يحتوي على نوعين من التسلسلات:

- **التسلسل الرئيسي** يُشغل مع تقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على الشكل المشغل.

نظرًا لأن صناديق النصوص، والصور، والرسوم البيانية، والجداول، وغيرها من كائنات الشريحة تُنفّذ الواجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، يمكنك استخدام نفس الطريقة [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) لمعظم محتوى الشرائح. يتم سرد التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشفرة وادعُ الطريقة [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) مع الشكل المستهدف، نوع التأثير، تحت النوع، والمُشغل. لتأثير يبدأ عندما يتم النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون مُشغله ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المُشغل يتحكم في متى يبدأ التأثير:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) ينتظر نقرة في التسلسل الرئيسي، أو نقرة على الشكل المشغل في تسلسل تفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو رسم بياني أو أي نوع شكل آخر، مرّر ذلك الكائن إلى [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) بدلاً من `targetShape`. لخيارات تجميع خاصة بالرسوم البيانية، راجع [Animated Charts](/slides/ar/net/animated-charts/).

## **قراءة رسومات متحركة للأشكال**

استخدم [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/geteffectsbyshape/) عندما تكون على علم بالشكل المستهدف. لتفقد كل تأثير، عدّ التسلسل الرئيسي وكل تسلسل تفاعلي. العدّ يضمن عدم الافتراض بوجود تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً يحتوي على تأثيرات في التسلسل الرئيسي والتفاعلي، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدّ كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدّد الشكل أولًا بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعي [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/geteffectsbyshape/). لا تفترض أن [IShapeCollection.Item](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/item/) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العنصر النائب الموروث**

يمكن للعنصر النائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط أو الشريحة الرئيسية. تُعيد الطريقة [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) ذلك العنصر النائب الأب، أو `null` إذا لم يكن موجودًا أب.

في عرض البرزنتيشن التالي، يحتوي التذييل على **Random Bars** على الشريحة العادية، **Split** على شريحة التخطيط، و**Fly In** على الشريحة الرئيسية.

![تأثير رسوم متحركة للتذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير رسوم متحركة للعنصر النائب للتذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير رسوم متحركة للعنصر النائب للتذييل على الشريحة الرئيسية](master-shape-animation.png)

المثال التالي يبني هيكلية العناصر النائبة بنفسه. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب تخطيط، والعنصر النائب المقابل على شريحة عادية. يتم فحص كل استدعاء لـ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) قبل استخدام الشكل المرتجع.

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

## **تغيير توقيت الرسوم المتحركة**

حوار **Timing** في PowerPoint يربط بخصائص [ITiming](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/).

![حوار توقيت PowerPoint لتأثير رسوم متحركة](shape-animation.png)

- **Start** يطابق [ITiming.TriggerType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** يطابق [ITiming.Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/duration/)، بالثواني.
- **Delay** يطابق [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/triggerdelaytime/)، بالثواني.
- **Repeat** يطابق [ITiming.RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount/)، أو [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick/)، أو [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** يطابق [ITiming.Rewind](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/rewind/).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المرتجع من [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/)، ويحفظ النتيجة. الحفاظ على مرجع [IEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/) المرتجع يمنع الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضعية تكرار واحدة فقط عمدًا. الجمع بين عدد التكرارات وعلامة "حتى" يمكن أن ينتج نتائج مربكة في مشغّلات مختلفة. عند تغيير أوضاع التكرار، اضبط [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick/) و[ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide/) قبل [ITiming.RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount/)، لأن ضبط أيٍّ من العلامتين يغيّر وضعية التكرار النشطة أيضًا.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة أن يشير إلى صوت مضمّن عبر [IEffect.Sound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/sound/). تُخبر الطريقة [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/stopprevioussound/) التأثير بإيقاف الصوت الذي 시작ه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع وجود ملف صوت محلي باسم `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/)، لذا لا يُطلب فهرس تسلسل.

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

### **استخراج أصوات التأثير المدمجة**

المثال التالي يتوقع وجود عرض تقديمي محلي باسم `presentation-with-animation-sounds.pptx`. يفحص كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت تأثير مضمّن إلى مجلد `extracted-animation-sounds`. يتم اختيار الامتداد بناءً على نوع MIME الصوتي الذي تُعيده [IAudio.ContentType](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudio/contenttype/).

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

للكائنات الصوتية الكبيرة، استخدم [IAudio.GetStream](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudio/getstream/) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم ما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات ما بعد الرسوم المتحركة](shape-after-animation.png)

يُدعم تعداد [AfterAnimationType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/) ترك الشكل دون تغيير، أو تغيير لونه، أو إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقر التالي. عندما يكون النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)، اضبط أيضًا [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/afteranimationcolor/).

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوك ما بعد الرسوم المتحركة عبر كائن التأثير المرتجع، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/) يمسح إعداد لون ما بعد الرسوم المتحركة.

## **تحريك النص**

تحريك النص لديه تحكمان مرتبطان:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itextanimation/buildtype/) يتحكم فيما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/animatetexttype/) يتحكم فيما إذا كان النص يظهر بالكامل، كلمةً كلمةً، أو حرفًا بحرف. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/delaybetweentextparts/) يحدّد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ والقيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype/) يعطل بناء الفقرة بحسب الفقرة بحيث يُطبّق ضبط الكلمة على كامل إطار النص.

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

لبناء صندوق النص وفقًا للفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype/) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثيرها الخاص، استخدم تحميل [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) الذي يقبل [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/). راجع [Animated Text](/slides/ar/net/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- الحفظ إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن التشغيل النهائي يتحكم فيه عارض العرض.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [HTML5 export](/slides/ar/net/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/net/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- بالنسبة إلى HTML5، فعّل [Html5Options.AnimateShapes](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animateshapes/) وعند الحاجة [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animatetransitions/).
- تصيير الفيديو يدعم العديد من تأثيرات الدخول، التأكيد، الخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من جدول [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/net/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحاسمة مع نسخة Aspose.Slides المستهدفة.
- قد تُحفظ التأثيرات المخصصة المتقدمة أو التي تم استيرادها من تنسيقات عرض أخرى في الملف ولكن يتم عرضها بصورة مختلفة في PowerPoint أو HTML5 أو الفيديو. احقق من النتيجة المصدّرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا يظهر تأثير في PowerPoint ولكنه غير موجود في PDF؟**

PDF تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة أو انتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما تحتاج إلى إبقاء الحركة.

**لماذا يُشغل تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلًا من حفظ سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو يتم تقريبها. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل إلى الأمام أو الخلف يغيّر ترتيب الرسوم المتحركة؟**

لا. ترتيب Z للأشكال يتحكم في التراكب، بينما ترتيب التسلسل والمُشغلات يتحكمان في تشغيل الرسوم المتحركة. غير المخطط الزمني إذا كنت بحاجة إلى ترتيب تشغيل مختلف.