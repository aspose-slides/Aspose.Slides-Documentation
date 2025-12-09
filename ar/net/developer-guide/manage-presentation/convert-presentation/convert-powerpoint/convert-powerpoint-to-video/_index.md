---
title: تحويل عروض PowerPoint إلى فيديو في .NET
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/net/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض إلى MP4
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
description: "تعلم كيفية تحويل عروض PowerPoint إلى فيديو في .NET. اكتشف مثال على كود C# وتقنيات الأتمتة لتبسيط سير عملك."
---

## **نظرة عامة**

عن طريق تحويل عرض PowerPoint أو OpenDocument إلى فيديو، ستحصل على:

**زيادة إمكانية الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، تزود بتطبيقات تشغيل الفيديو بشكل افتراضي، مما يجعل من الأسهل على المستخدمين فتح مقاطع الفيديو أو تشغيلها مقارنةً بتطبيقات العروض التقليدية.

**وصول أوسع:** تتيح لك مقاطع الفيديو الوصول إلى جمهور أكبر وتقديم المعلومات بصورة أكثر جذبًا. تشير الاستطلاعات والإحصاءات إلى أن الأشخاص يفضلون مشاهدة واستهلاك محتوى الفيديو على أشكال أخرى، مما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="primary" %}} 

تحقق من [**محول PowerPoint إلى فيديو على الإنترنت**](https://products.aspose.app/slides/video) لأنه يوفر تنفيذًا مباشرًا وفعالًا للعملية الموضحة هنا.

{{% /alert %}} 

في Aspose.Slides لـ .NET، قمنا بتنفيذ دعم لتحويل العروض إلى فيديو.

* استخدم Aspose.Slides لـ .NET لإنشاء إطارات من شرائح العرض بمعدل إطارات محدد (FPS).
* ثم استخدم أداة طرف ثالث مثل ffmpeg لتجميع هذه الإطارات في فيديو.

## **تحويل عرض PowerPoint إلى فيديو**

1. استخدم أمر `dotnet add package` لإضافة Aspose.Slides ومكتبة FFMpegCore إلى مشروعك:
   * نفّذ `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * نفّذ `dotnet add package FFMpegCore --version 4.8.0`
2. حمّل ffmpeg من [هنا](https://ffmpeg.org/download.html).
3. تتطلب FFMpegCore تحديد مسار ffmpeg الذي تم تنزيله (مثلاً، مستخرج إلى "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. شغّل كود تحويل PowerPoint إلى فيديو.

يعرض هذا الكود بلغة C# كيفية تحويل عرض (يحتوي على شكل وتأثيري حركة) إلى فيديو:
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // سيستخدم ملفات FFmpeg الثنائية التي استخرجناها إلى C:\tools\ffmpeg مسبقًا.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة شكل ابتسامة ثم تحريكه.
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

    // تكوين مجلد ملفات ffmpeg الثنائية. راجع هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // تحويل الإطارات إلى فيديو بصيغة webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **تأثيرات الفيديو**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides لـ .NET، يمكنك تطبيق تأثيرات فيديو مختلفة لتحسين الجودة البصرية للناتج. تسمح لك هذه التأثيرات بالتحكم في مظهر الشرائح في الفيديو النهائي بإضافة انتقالات سلسة، وحركات، وعناصر بصرية أخرى. يوضح هذا القسم خيارات تأثيرات الفيديو المتاحة وكيفية تطبيقها.

{{% alert color="primary" %}} 

انظر:
- [تعزيز عروض PowerPoint بالحركات في C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [حركة الشكل](https://docs.aspose.com/slides/net/shape-animation/)
- [تطبيق تأثيرات الشكل في PowerPoint باستخدام C#](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

تجعل الحركات والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتفعل نفس الشيء للفيديوهات. لنضيف شريحة أخرى وانتقالًا إلى الكود للعرض السابق:
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


يدعم Aspose.Slides أيضًا حركات النص. في هذا المثال، نحرك الفقرات على الكائنات لتظهر واحدة تلو الأخرى، مع تأخير ثانية واحدة بينها:
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

لتمكين مهام تحويل PowerPoint إلى فيديو، توفر Aspose.Slides لـ .NET الفئات [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` يتيح لك ضبط حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) وقيمة FPS (عدد الإطارات في الثانية) عبر المُنشئ الخاص به. إذا مررت كائن عرض، سيُستخدم `Presentation.SlideSize` الخاص به ويولد حركات يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

عند توليد الحركات، يتم تشغيل حدث `NewAnimation` لكل حركة لاحقة، وهو يتضمن معاملًا من نوع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). تمثل هذه الفئة مشغلًا لحركة فردية.

للعمل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)، تستخدم الخاصية [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (التي تعطي المدة الكاملة للحركة) والطريقة [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). يتم تعيين كل موضع حركة ضمن النطاق *0 إلى المدة*، ثم تُعيد طريقة `GetFrame` صورة Bitmap تمثل حالة الحركة في ذلك الزمن.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة شكل ابتسامة وتحريكه.
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

            animationPlayer.SetTimePosition(0);          // حالة الرسوم المتحركة الأولية.
            Bitmap bitmap = animationPlayer.GetFrame();  // صورة bitmap لحالة الرسوم المتحركة الأولية.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // الحالة النهائية للرسوم المتحركة.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // الإطار الأخير للرسوم المتحركة.
            lastBitmap.Save("last.png");
        };
    }
}
```


لجعل جميع الحركات في عرض ما تُشغل مرة واحدة، تُستخدم فئة [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). تأخذ هذه الفئة كائنًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) وقيمة FPS للتأثيرات في المُنشئ، ثم تستدعي حدث `FrameTick` لجميع الحركات لتشغيلها:
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


ثم يمكن تجميع الإطارات المُولدة لإنتاج فيديو. راجع قسم [Convert a PowerPoint Presentation to Video](/slides/ar/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **الحركات والتأثيرات المدعومة**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides لـ .NET، من المهم معرفة أي الحركات والتأثيرات مدعومة في الناتج. يدعم Aspose.Slides مجموعة واسعة من تأثيرات الدخول، الخروج، والتأكيد الشائعة مثل التلاشي، التحليق، التكبير، والدوران. ومع ذلك، قد لا تُحافظ بعض الحركات المتقدمة أو المخصصة بالكامل أو قد تظهر بشكل مختلف في الفيديو النهائي. يوضح هذا القسم الحركات والتأثيرات المدعومة.

**دخول**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق داخل** | ![supported](v.png) | ![supported](v.png) |
| **طفو داخل** | ![supported](v.png) | ![supported](v.png) |
| **تقسيم** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **عجلة** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **نمو وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **تدوير** | ![supported](v.png) | ![supported](v.png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |

**تأكيد**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبضة** | ![not supported](x.png) | ![supported](v.png) |
| **نبضة لون** | ![not supported](x.png) | ![supported](v.png) |
| **تمايل** | ![supported](v.png) | ![supported](v.png) |
| **دوران** | ![supported](v.png) | ![supported](v.png) |
| **نمو/تصغير** | ![not supported](x.png) | ![supported](v.png) |
| **إزالة تشبع** | ![not supported](x.png) | ![supported](v.png) |
| **تغميق** | ![not supported](x.png) | ![supported](v.png) |
| **تفتيح** | ![not supported](x.png) | ![supported](v.png) |
| **شفافية** | ![not supported](x.png) | ![supported](v.png) |
| **لون الكائن** | ![not supported](x.png) | ![supported](v.png) |
| **لون مكمل** | ![not supported](x.png) | ![supported](v.png) |
| **لون الخط** | ![not supported](x.png) | ![supported](v.png) |
| **لون التعبئة** | ![not supported](x.png) | ![supported](v.png) |

**خروج**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **تحليق خارج** | ![supported](v.png) | ![supported](v.png) |
| **طفو خارج** | ![supported](v.png) | ![supported](v.png) |
| **تقسيم** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![supported](v.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **تصغير وتدوير** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **تدوير** | ![supported](v.png) | ![supported](v.png) |
| **ارتداد** | ![supported](v.png) | ![supported](v.png) |

**مسارات الحركة**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![supported](v.png) | ![supported](v.png) |
| **أقواس** | ![supported](v.png) | ![supported](v.png) |
| **دورات** | ![supported](v.png) | ![supported](v.png) |
| **أشكال** | ![supported](v.png) | ![supported](v.png) |
| **حلقات** | ![supported](v.png) | ![supported](v.png) |
| **مسار مخصص** | ![supported](v.png) | ![supported](v.png) |

## **تأثيرات انتقال الشرائح المدعومة**

تلعب تأثيرات انتقال الشرائح دورًا مهمًا في إنشاء تغييرات سلسة وجذابة بين الشرائح في الفيديو. يدعم Aspose.Slides لـ .NET مجموعة متنوعة من تأثيرات الانتقال الشائعة للمساعدة في الحفاظ على تدفق وأسلوب العرض الأصلي. يوضح هذا القسم أي من تأثيرات الانتقال مدعومة أثناء عملية التحويل.

**دقيقة**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **تحول** | ![not supported](x.png) | ![supported](v.png) |
| **تلاشي** | ![supported](v.png) | ![supported](v.png) |
| **دفع** | ![supported](v.png) | ![supported](v.png) |
| **سحب** | ![supported](v.png) | ![supported](v.png) |
| **مسح** | ![supported](v.png) | ![supported](v.png) |
| **تقسيم** | ![supported](v.png) | ![supported](v.png) |
| **كشف** | ![not supported](x.png) | ![supported](v.png) |
| **أشرطة عشوائية** | ![supported](v.png) | ![supported](v.png) |
| **شكل** | ![not supported](x.png) | ![supported](v.png) |
| **كشف جزئي** | ![not supported](x.png) | ![supported](v.png) |
| **تغطية** | ![supported](v.png) | ![supported](v.png) |
| **وميض** | ![supported](v.png) | ![supported](v.png) |
| **شرائط** | ![supported](v.png) | ![supported](v.png) |

**مثير**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **سقوط** | ![not supported](x.png) | ![supported](v.png) |
| **تغطية** | ![not supported](x.png) | ![supported](v.png) |
| **ستائر** | ![not supported](x.png) | ![supported](v.png) |
| **رياح** | ![not supported](x.png) | ![supported](v.png) |
| **هيبة** | ![not supported](x.png) | ![supported](v.png) |
| **كسرة** | ![not supported](x.png) | ![supported](v.png) |
| **سحق** | ![not supported](x.png) | ![supported](v.png) |
| **قشر** | ![not supported](x.png) | ![supported](v.png) |
| **تجعيد الصفحة** | ![not supported](x.png) | ![supported](v.png) |
| **طائرة** | ![not supported](x.png) | ![supported](v.png) |
| **أوريغامي** | ![not supported](x.png) | ![supported](v.png) |
| **ذوبان** | ![supported](v.png) | ![supported](v.png) |
| **لوح شطرنج** | ![not supported](x.png) | ![supported](v.png) |
| **ستائر أعمدة** | ![not supported](x.png) | ![supported](v.png) |
| **ساعة** | ![supported](v.png) | ![supported](v.png) |
| **تموج** | ![not supported](x.png) | ![supported](v.png) |
| **خلية عسل** | ![not supported](x.png) | ![supported](v.png) |
| **بريق** | ![not supported](x.png) | ![supported](v.png) |
| **دوامة** | ![not supported](x.png) | ![supported](v.png) |
| **تمزيق** | ![not supported](x.png) | ![supported](v.png) |
| **تبديل** | ![not supported](x.png) | ![supported](v.png) |
| **قلب** | ![not supported](x.png) | ![supported](v.png) |
| **معرض** | ![not supported](x.png) | ![supported](v.png) |
| **مكعب** | ![not supported](x.png) | ![supported](v.png) |
| **أبواب** | ![not supported](x.png) | ![supported](v.png) |
| **صندوق** | ![not supported](x.png) | ![supported](v.png) |
| **مشط** | ![not supported](x.png) | ![supported](v.png) |
| **تكبير** | ![supported](v.png) | ![supported](v.png) |
| **عشوائي** | ![not supported](x.png) | ![supported](v.png) |

**محتوى ديناميكي**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **تحريك** | ![not supported](x.png) | ![supported](v.png) |
| **عجلة فيريس** | ![supported](v.png) | ![supported](v.png) |
| **نظام ناقل** | ![not supported](x.png) | ![supported](v.png) |
| **دوران** | ![not supported](x.png) | ![supported](v.png) |
| **مدار** | ![not supported](x.png) | ![supported](v.png) |
| **تحليق عبر** | ![supported](v.png) | ![supported](v.png) |

## **الأسئلة الشائعة**

**هل يمكن تحويل العروض التي محمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides لـ .NET العمل مع العروض المحمية بكلمة مرور. عند معالجة هذه الملفات، يجب تقديم كلمة المرور الصحيحة حتى تتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides لـ .NET الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides لـ .NET في التطبيقات والخدمات السحابية. صُممت المكتبة للعمل في بيئات الخادم، مما يضمن أداءً عاليًا وقابلية توسعة لمعالجة دفعات الملفات.

**هل هناك قيود على حجم العروض أثناء التحويل؟**

يمكن لـ Aspose.Slides لـ .NET معالجة عروض بحجم شبه غير محدود. ومع ذلك، عند التعامل مع ملفات كبيرة جدًا قد تحتاج إلى موارد نظام إضافية، ويُنصَح أحيانًا بتحسين العرض لتحسين الأداء.