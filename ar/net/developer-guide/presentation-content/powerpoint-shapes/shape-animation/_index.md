---
title: تطبيق رسومات المتحركة للأشكال في العروض التقديمية في .NET
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/net/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسم متحرك
- الحصول على رسم متحرك
- استخراج رسم متحرك
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسم متحرك
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إضافة، وفحص، وتخصيص رسوم المتحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides for .NET."
---
## **نظرة عامة**

للعمل مع السلوكيات الفردية داخل تأثير أو تحرير أجزاء مسار الحركة، راجع [Custom Animation](/slides/ar/net/custom-animation/).

تمثل Aspose.Slides for .NET الرسوم المتحركة للشرائح كـ تأثيرات في مخطط زمني للشرائح. يحتوي التأثير على شكل هدف، ونوع الرسوم المتحركة والأنواع الفرعية، ومشغل، وإعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

يحتوي المخطط الزمني على نوعين من التسلسلات:

- التسلسل **الرئيسي** يُشغَّل أثناء تقدم الشريحة.
- التسلسل **التفاعلي** يبدأ عندما يتم النقر على الشكل المشغِّل.

نظرًا لأن صناديق النصوص، والصور، والرسوم البيانية، والجداول، وغيرها من كائنات الشرائح تُنفّذ [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، يمكنك استخدام طريقة [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) نفسها لمعظم محتوى الشرائح. تُدرج التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttype/) .

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشفرة واستدعِ [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) مع شكل الهدف، ونوع التأثير، والنوع الفرعي، والمشغل. لتأثير يبدأ عندما يتم النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون المشغل هو ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة في `shape-animations.pptx`.

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

المشغل يتحكم في متى يبدأ التأثير:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) ينتظر النقر في التسلسل الرئيسي، أو النقر على الشكل المشغِّل في تسلسل تفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttriggertype/) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو رسم بياني أو أي نوع آخر من الأشكال، مرّر هذا الكائن إلى [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) بدلاً من `targetShape`. للحصول على خيارات التجميع الخاصة بالرسوم البيانية، راجع [Animated Charts](/slides/ar/net/animated-charts/).

## **قراءة الرسوم المتحركة للأشكال**

استخدم [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/geteffectsbyshape/) عندما تعرف شكل الهدف. لتفحص كل تأثير، عدّ التسلسل الرئيسي وكل تسلسل تفاعلي. العدّ يجنّب الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدّد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/geteffectsbyshape/). لا تفترض أن [IShapeCollection.Item](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/item/) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن لعنصر نائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط والشريحة الرئيسة. تُعيد [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) ذلك العنصر النائب الأصلي، أو `null` إذا لم يكن هناك أصل.

في عرض الشرائح المثال التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، و**Split** في شريحة التخطيط، و**Fly In** في الشريحة الرئيسة.

![تأثير حركة التذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على الشريحة الرئيسة](master-shape-animation.png)

المثال التالي يبني بنية العنصر النائب بنفسه. يضيف تأثيرات إلى عنصر نائب رئيسي، وعنصر نائب تخطيط، والعنصر النائب المقابل على شريحة عادية. يتم التحقق من كل استدعاء لـ [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getbaseplaceholder/) قبل استخدام الشكل المرجع.

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

تُطابق نافذة حوار **Timing** في PowerPoint خصائص [ITiming](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/).

![حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **البدء** يطابق [ITiming.TriggerType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/triggertype/).
- **المدة** يطابق [ITiming.Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/duration/)، بالثواني.
- **التأخير** يطابق [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/triggerdelaytime/)، بالثواني.
- **التكرار** يطابق [ITiming.RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount/)، أو [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick/)، أو [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide/) .
- **إعادة التشغيل عند الانتهاء** يطابق [ITiming.Rewind](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/rewind/) .

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المرتجع من [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/)، ويحفظ النتيجة. الحفاظ على مرجع [IEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/) المرتجع يجنّب فهرس مجموعة غير ضروري.

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

استخدم وضع تكرار واحد عن قصد. الجمع بين عدد تكرار وعلامة "حتى" قد ينتج نتائج مربكة في مشغّلات مختلفة. عند تغيير أوضاع التكرار، اضبط [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick/) و[ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide/) قبل [ITiming.RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount/)، لأن ضبط أي من العلامتين يغيّر وضع التكرار النشط أيضًا.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة الإشارة إلى صوت مضمّن عبر [IEffect.Sound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/stopprevioussound/) يخبر التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع وجود ملف صوت محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كالصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/)، لذا لا يلزم فهرس تسلسل.

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

### **استخراج أصوات التأثيرات المضمنة**

المثال التالي يتوقع وجود عرض تقديمي محلي اسمه `presentation-with-animation-sounds.pptx`. يفحص كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت تأثير مضمّن إلى مجلد `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي الذي تُبثه [IAudio.ContentType](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudio/contenttype/).

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

للكائنات الصوتية الكبيرة، استخدم [IAudio.GetStream](https://reference.aspose.com/slides/ar/net/aspose.slides/iaudio/getstream/) وانسخ الدفق إلى ملف بدلًا من تحميل الكائن بالكامل إلى مصفوفة بايتات.

## **تحديد سلوك ما بعد الرسوم المتحركة**

الخيار **After animation** يتحكم فيما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يوضح إعدادات After animation](shape-after-animation.png)

يدعم تعداد [AfterAnimationType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/) ترك الشكل دون تغيير، تغيير لونه، إخفاؤه بعد الرسوم المتحركة، أو إخفاؤه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)، اضبط أيضًا [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/afteranimationcolor/) .

هذا المثال المستقل ينشئ تأثيرًا، يضبط سلوك ما بعد الرسوم المتحركة عبر كائن التأثير المرتجع، ويحفظ النتيجة.

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

لتحريك النص هناك تحكمان مرتبطان:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itextanimation/buildtype/) يتحكم فيما إذا كانت الفقرات تظهر معًا أو بمستوى الفقرة.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/animatetexttype/) يتحكم فيما إذا كان النص يظهر دفعة واحدة، بالكلمة، أو بالحرف. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/delaybetweentextparts/) يحدد التأخير بين الكلمات أو الحروف. القيمة الإيجابية هي نسبة مئوية من مدة التأثير؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype/) يُعطل البناء وفقًا لكل فقرة بحيث ينطبق إعداد الكلمة على إطار النص بأكمله.

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

لبناء صندوق نص حسب الفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype/) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثيرها الخاص، استخدم نسخة overload من [ISequence.AddEffect](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/addeffect/) التي تقبل كائنًا من نوع [IParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph/). راجع [Animated Text](/slides/ar/net/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ الملف إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن تشغيله النهائي يتحكم فيه عارض العروض.
- PDF والصور الثابتة لا تشغِّل الرسوم المتحركة. استخدم [HTML5 export](/slides/ar/net/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/net/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- لتصدير HTML5، فعل [Html5Options.AnimateShapes](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animateshapes/) وعند الحاجة [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animatetransitions/) .
- يدعم تصيّر الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسارات الحركة الشائعة، لكن ليس كل تأثير في PowerPoint مدعوم. تحقق من جدول [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/net/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف لكن تُعرض بطريقة مختلفة في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا يظهر تأثير في PowerPoint لكنه غير ظاهر في PDF؟**

PDF تنسيق ثابت، لذا لا تُشغَّل الرسوم المتحركة ولا انتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُشغَّل تأثير بصورة مختلفة في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلًا من تخزين السلوك الأصلي لـ PowerPoint. بعض التأثيرات المتقدمة غير مدعومة أو تُقرب من شكلها الأصلي. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل إلى أمام أو خلف يغيّر ترتيب الرسوم المتحركة؟**

لا. يتحكم ترتيب z للشكلة في التراكب، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الرسوم المتحركة. عدّل المخطط الزمني إذا كنت بحاجة إلى ترتيب تشغيل مختلف.