---
title: تحويل عروض PowerPoint إلى فيديو في .NET
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/net/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض التقديمي إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض التقديمي إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو في .NET. استكشف عينة كود C# وتقنيات الأتمتة لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint أو OpenDocument إلى فيديو، ستحصل على:

**تحسين إمكانية الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، مزودة بمشغلات فيديو افتراضيًا، مما يجعل من الأسهل للمستخدمين فتح أو تشغيل مقاطع الفيديو مقارنةً بتطبيقات العروض التقديمية التقليدية.

**وصول أوسع:** تتيح لك مقاطع الفيديو الوصول إلى جمهور أكبر وعرض المعلومات بشكل أكثر جاذبية. تشير الدراسات والإحصاءات إلى أن الأشخاص يفضلون مشاهدة واستهلاك محتوى الفيديو على غيره، مما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="primary" %}} 
اطلع على **محول PowerPoint إلى فيديو عبر الإنترنت**[**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/video) لأنه يقدم تنفيذًا حيًا وفعالًا للعملية الموضحة هنا.
{{% /alert %}} 

في Aspose.Slides for .NET، نفّذنا دعمًا لتحويل العروض التقديمية إلى فيديو.

* استخدم Aspose.Slides for .NET لتوليد إطارات من شرائح العرض بمعدل إطارات محدد (FPS).
* ثم استخدم أداة طرف ثالث مثل ffmpeg لتجميع هذه الإطارات في فيديو.

## **تحويل عرض PowerPoint إلى فيديو**

1. استخدم أمر `dotnet add package` لإضافة Aspose.Slides ومكتبة FFMpegCore إلى مشروعك:
   * نفّذ `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * نفّذ `dotnet add package FFMpegCore --version 4.8.0`
2. حمّل ffmpeg من [here](https://ffmpeg.org/download.html).
3. يتطلب FFMpegCore تحديد المسار إلى ffmpeg الذي تم تنزيله (مثلاً، المستخرج إلى "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. شغِّل كود تحويل PowerPoint إلى فيديو.

هذا الكود C# يوضح كيفية تحويل عرض تقديمي (يحتوي على شكل وتأثيري حركة) إلى فيديو:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // سيستخدم ملفات الفيمبك التي استخرجناها إلى C:\tools\ffmpeg في وقت سابق.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف شكلًا مبتسمًا ثم حركه.
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

    // تكوين مجلد ملفات الفيمبك. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // تحويل الإطارات إلى فيديو webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **تأثيرات الفيديو**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for .NET، يمكنك تطبيق تأثيرات فيديو مختلفة لتحسين جودة المخرجات البصرية. تسمح لك هذه التأثيرات بالتحكم في مظهر الشرائح في الفيديو النهائي عبر إضافة انتقالات سلسة، وحركات، وعناصر بصرية أخرى. يشرح هذا القسم خيارات تأثيرات الفيديو المتاحة ويظهر كيفية تطبيقها.

{{% alert color="primary" %}} 
انظر:
- [تحسين عروض PowerPoint بالحركات في C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [حركة الشكل](https://docs.aspose.com/slides/net/shape-animation/)
- [تطبيق تأثيرات الشكل في PowerPoint باستخدام C#](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

تجعل الحركات والانتقالات عروض الشرائح أكثر جذبًا وإثارة — وتؤدي نفس الوظيفة للفيديوهات. لنضف شريحة وانتقالًا آخر إلى الكود للعرض السابق:
```c#
 // أضف شكلًا مبتسمًا وقم بتحريكه.
 // ...

 // أضف شريحة جديدة وانتقالًا متحركًا.
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```


يدعم Aspose.Slides أيضًا حركات النص. في هذا المثال، نقوم بتحريك الفقرات على الكائنات بحيث تظهر واحدة تلو الأخرى، مع تأخير ثانية واحدة بينها:
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة النص والحركات.
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

    // تكوين مجلد ملفات ffmpeg الثنائية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // تحويل الإطارات إلى فيديو webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **فئات تحويل الفيديو**

لتنفيذ مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides for .NET الفئتين [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` يتيح لك تحديد حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) وقيمة FPS (الإطارات في الثانية) عبر المُنشئ الخاص به. إذا مررت كائن عرض تقديمي، سيُستخدم `Presentation.SlideSize` الخاص به ويُولد حركات يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

عند توليد الحركات، يُطلق حدث `NewAnimation` لكل حركة لاحقة، ويتضمن معلمة من نوع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). تمثل هذه الفئة مشغّلًا لحركة فردية.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)، تستخدم الخاصية [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (التي تعطي المدة الكاملة للحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). يتم ضبط كل موضع حركة ضمن النطاق *0 إلى المدة*، ثم تُعيد طريقة `GetFrame` صورة Bitmap تمثّل حالة الحركة في ذلك الوقت.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف شكلًا مبتسمًا وقم بتحريكه.
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

            animationPlayer.SetTimePosition(0);          // الحالة الأولية للرسوم المتحركة.
            Bitmap bitmap = animationPlayer.GetFrame();  // صورة الحالة الأولية للرسوم المتحركة.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // الحالة النهائية للرسوم المتحركة.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // الإطار الأخير للرسوم المتحركة.
            lastBitmap.Save("last.png");
        };
    }
}
```


لجعل جميع الحركات في عرض تقديمي تُلعب في آنٍ واحد، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). تأخذ هذه الفئة كائنًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) وقيمة FPS للEffects في المُنشئ، ثم تُستدعي حدث `FrameTick` لجميع الحركات لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المُولدة لإنتاج فيديو. راجع قسم [Convert a PowerPoint Presentation to Video](/slides/ar/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **الحركات والتأثيرات المدعومة**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for .NET، من المهم معرفة أي الحركات والتأثيرات مدعومة في المخرجات. يدعم Aspose.Slides مجموعة واسعة من تأثيرات الدخول، الخروج، والتأكيد مثل التلاشي، الانزلاق، التكبير، والدوران. ومع ذلك، قد لا تُحافظ بعض الحركات المتقدمة أو المخصصة على شكلها الكامل أو قد تظهر بصورة مختلفة في الفيديو النهائي. يوضح هذا القسم الحركات والتأثيرات المدعومة.

**دخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**تأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **تأثيرات انتقال الشريحة المدعومة**

تلعب تأثيرات انتقال الشريحة دورًا مهمًا في إنشاء تغييرات سلسة وجذابة بصريًا بين الشرائح في الفيديو. يدعم Aspose.Slides for .NET مجموعة متنوعة من تأثيرات الانتقال الشائعة للمساعدة في الحفاظ على تدفق وأسلوب العرض الأصلي. يسلط هذا القسم الضوء على التأثيرات المدعومة أثناء عملية التحويل.

**خفيفة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**ممتعة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**محتوى ديناميكي**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

**هل من الممكن تحويل العروض التقديمية المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides for .NET العمل مع العروض التقديمية المحمية بكلمة مرور. عند معالجة such files، تحتاج إلى توفير كلمة المرور الصحيحة لكي يتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides for .NET الاستخدام في الحلول السحابية؟**

نعم، يمكن دمج Aspose.Slides for .NET في التطبيقات والخدمات السحابية. تم تصميم المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسيع للمعالجة الدفعية للملفات.

**هل هناك أي حدود لحجم العروض التقديمية أثناء التحويل؟**

يستطيع Aspose.Slides for .NET معالجة عروض تقديمية بأي حجم عمليًا. ومع ذلك، عند التعامل مع ملفات كبيرة جدًا، قد تكون هناك حاجة لموارد نظام إضافية، وفي بعض الأحيان يُنصح بتحسين العرض لتقليل استهلاك الموارد.