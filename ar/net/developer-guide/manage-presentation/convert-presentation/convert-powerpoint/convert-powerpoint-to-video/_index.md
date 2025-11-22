---
title: تحويل عروض PowerPoint إلى فيديو باستخدام C#
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/net/convert-powerpoint-to-video/
keywords:
- PowerPoint إلى فيديو
- تحويل PowerPoint إلى فيديو
- العرض إلى فيديو
- تحويل العرض إلى فيديو
- PPT إلى فيديو
- تحويل PPT إلى فيديو
- PPTX إلى فيديو
- تحويل PPTX إلى فيديو
- ODP إلى فيديو
- تحويل ODP إلى فيديو
- PowerPoint إلى MP4
- تحويل PowerPoint إلى MP4
- العرض إلى MP4
- تحويل العرض إلى MP4
- PPT إلى MP4
- تحويل PPT إلى MP4
- PPTX إلى MP4
- تحويل PPTX إلى MP4
- تحويل PowerPoint إلى فيديو
- تحويل العرض إلى فيديو
- تحويل PPT إلى فيديو
- تحويل PPTX إلى فيديو
- تحويل ODP إلى فيديو
- تحويل فيديو C#
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية تحويل عروض PowerPoint وOpenDocument إلى فيديو باستخدام C#. اكتشف عينة الشيفرة وتقنيات الأتمتة لتبسيط سير العمل."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint أو عرض OpenDocument إلى فيديو، ستحصل على:

**زيادة إمكانية الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، مزودة بمشغلات فيديو بشكل افتراضي، مما يجعل من السهل على المستخدمين فتح أو تشغيل الفيديوهات مقارنةً بتطبيقات العروض التقليدية.

**وصول أوسع:** الفيديوهات تتيح لك الوصول إلى جمهور أكبر وتقديم المعلومات بصيغة أكثر جاذبية. تشير الاستطلاعات والإحصائيات إلى أن الناس يفضلون مشاهدة واستهلاك محتوى الفيديو على الصيغ الأخرى، مما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="primary" %}} 
تحقق من [**محول PowerPoint إلى فيديو على الإنترنت**](https://products.aspose.app/slides/video) لأنه يوفر تطبيقًا حيًا وفعّالًا للعملية الموضحة هنا.
{{% /alert %}} 

في Aspose.Slides for .NET، قدمنا دعمًا لتحويل العروض إلى فيديو.

* استخدم Aspose.Slides for .NET لإنشاء إطارات من شرائح العرض بمعدل إطارات محدد (FPS).
* ثم استخدم أداة طرف ثالث مثل ffmpeg لتجميع هذه الإطارات في فيديو.

## **تحويل عرض PowerPoint إلى فيديو**

1. استخدم أمر `dotnet add package` لإضافة Aspose.Slides ومكتبة FFMpegCore إلى مشروعك:
   * نفّذ `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * نفّذ `dotnet add package FFMpegCore --version 4.8.0`
2. حمّل ffmpeg من [هنا](https://ffmpeg.org/download.html).
3. يتطلب FFMpegCore تحديد مسار ffmpeg المحمّل (مثال: المستخرج إلى "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. شغّل كود تحويل PowerPoint إلى فيديو.

هذا الكود C# يوضح كيفية تحويل عرض (يحتوي على شكل وتأثيري حركة) إلى فيديو:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // سيستخدم ملفات تنفيذية FFmpeg التي استخرجناها إلى C:\tools\ffmpeg في وقت سابق.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف شكل ابتسامة ثم احركه.
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

    // قم بتكوين مجلد ملفات FFmpeg التنفيذية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // حوّل الإطارات إلى فيديو webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **تأثيرات الفيديو**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for .NET، يمكنك تطبيق تأثيرات فيديو مختلفة لتحسين الجودة البصرية للمخرجات. تسمح لك هذه التأثيرات بالتحكم في مظهر الشرائح في الفيديو النهائي عبر إضافة انتقالات سلسة، وحركات، وعناصر بصرية أخرى. يشرح هذا القسم خيارات تأثيرات الفيديو المتاحة ويظهر كيفية تطبيقها.

{{% alert color="primary" %}} 
اطلع على:
- [تحسين عروض PowerPoint بالحركات في C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [حركة الشكل](https://docs.aspose.com/slides/net/shape-animation/)
- [تطبيق تأثيرات الشكل في PowerPoint باستخدام C#](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

الحركات والانتقالات تجعل عروض الشرائح أكثر تشويقًا وإثارة — وتفعل الشيء نفسه للفيديوهات. لنضيف شريحة وانتقال آخر إلى الكود للعرض السابق:
```c#
// أضف شكل ابتسامة وقم بتحريكه.
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

    // إضافة نص وحركات.
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

    // قم بتكوين مجلد ملفات تنفيذية ffmpeg. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // حوّل الإطارات إلى فيديو webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **فئات تحويل الفيديو**

لتمكين مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides for .NET الفئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` تتيح لك تحديد حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) وقيمة FPS (الإطارات في الثانية) عبر المُنشئ الخاص بها. إذا مررت كائن عرض، سيتم استخدام `Presentation.SlideSize` ويولد حركات يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

عند توليد الحركات، يتم تشغيل حدث `NewAnimation` لكل حركة تالية، ويتضمن معاملًا من نوع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). تمثل هذه الفئة مشغلًا لحركة فردية.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)، تستخدم الخاصية [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (التي تعطي المدة الكاملة للحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). يتم تعيين كل موضع حركة ضمن النطاق *0 إلى Duration*، ثم تُرجع طريقة `GetFrame` صورة Bitmap تمثل حالة الحركة في تلك النقطة الزمنية.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // أضف شكل ابتسامة وقم بتحريكه.
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

            animationPlayer.SetTimePosition(0);          // حالة الحركة الأولية.
            Bitmap bitmap = animationPlayer.GetFrame();  // صورة bitmap لحالة الحركة الأولية.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // الحالة النهائية للحركة.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // الإطار الأخير للحركة.
            lastBitmap.Save("last.png");
        };
    }
}
```


لجعل جميع الحركات في عرض ما تُشغَل في آن واحد، تُستَخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). هذه الفئة تستقبل كائن [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) وقيمة FPS للتأثيرات في المُنشئ، ثم تستدعي حدث `FrameTick` لكل الحركات لتشغيلها:
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


بعد ذلك يمكن تجميع الإطارات المُولَّدة لإنتاج فيديو. راجع قسم [Convert a PowerPoint Presentation to Video](/slides/ar/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **الحركات والتأثيرات المدعومة**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for .NET، من المهم معرفة أي الحركات والتأثيرات تُدعم في المخرج. يدعم Aspose.Slides مجموعة واسعة من تأثيرات الدخول والخروج والتأكيد الشائعة مثل التلاشي، والطيران، والتقريب، والدوران. ومع ذلك، قد لا تُحفظ بعض الحركات المتقدمة أو المخصصة بالكامل أو قد تظهر بشكل مختلف في الفيديو النهائي. يوضح هذا القسم الحركات والتأثيرات المدعومة.

**الدخول**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

**التأكيد**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

**الخروج**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **تأثيرات انتقال الشرائح المدعومة**

تلعب تأثيرات الانتقال بين الشرائح دورًا مهمًا في إنشاء تغييرات سلسة وجذابة بصريًا بين الشرائح في الفيديو. يدعم Aspose.Slides for .NET مجموعة متنوعة من تأثيرات الانتقال الشائعة للمساعدة في الحفاظ على تدفق وأسلوب العرض الأصلي. يسلط هذا القسم الضوء على تأثيرات الانتقال المدعومة أثناء عملية التحويل.

**دقيق**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
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

**مثير**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
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

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة المتكررة**

**هل يمكن تحويل العروض التي محمية بكلمة مرور؟**

نعم، Aspose.Slides for .NET يدعم العمل مع العروض المحمية بكلمة مرور. عند معالجة هذه الملفات، يجب توفير كلمة المرور الصحيحة لتمكين المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides for .NET الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides for .NET في التطبيقات والخدمات السحابية. تم تصميم المكتبة للعمل في بيئات الخوادم، مما يضمن أداءً عاليًا وقابلية توسع لمعالجة دفعات الملفات.

**هل هناك حدود لحجم العروض أثناء التحويل؟**

يمكن لـ Aspose.Slides for .NET التعامل مع عروض بحجم شبه لا نهائي. ومع ذلك، عند العمل مع ملفات كبيرة جدًا، قد يحتاج الأمر إلى موارد نظام إضافية، ويوصى أحيانًا بتحسين العرض لزيادة الأداء.