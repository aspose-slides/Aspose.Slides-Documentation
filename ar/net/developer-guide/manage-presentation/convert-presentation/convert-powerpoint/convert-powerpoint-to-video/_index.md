---
title: تحويل باوربوينت إلى فيديو
type: docs
weight: 130
url: /net/convert-powerpoint-to-video/
keywords: "تحويل باوربوينت, PPT, PPTX, عرض تقديمي, فيديو, MP4, PPT إلى فيديو, PPT إلى MP4, C#, Csharp, .NET, Aspose.Slides"
description: "تحويل باوربوينت إلى فيديو في C# أو .NET"
---

من خلال تحويل عرض باوربوينت الخاص بك إلى فيديو، ستحصل على

* **زيادة في الوصول:** جميع الأجهزة (بغض النظر عن النظام الأساسي) مزودة بمشغلات فيديو بشكل افتراضي مقارنة بتطبيقات فتح العروض التقديمية، مما يجعل من السهل على المستخدمين فتح أو تشغيل الفيديوهات.
* **وصول أوسع:** عبر الفيديوهات، يمكنك الوصول إلى جمهور كبير وتهدف إليهم بمعلومات قد تبدو مملة بخلاف ذلك في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون الفيديوهات ويستهلكونها أكثر من أشكال المحتوى الأخرى، ويفضلون عادةً هذا النوع من المحتوى.

{{% alert color="primary" %}} 

قد ترغب في التحقق من [**محول باوربوينت إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه تنفيذ مباشر وفعال للعملية الموصوفة هنا.

{{% /alert %}} 

## **تحويل باوربوينت إلى فيديو باستخدام Aspose.Slides**

في [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/)، نفذنا دعمًا لتحويل العروض التقديمية إلى فيديو.

* استخدم Aspose.Slides لإنشاء مجموعة من الإطارات (من شرايح العرض التقديمي) تت corresponde لمعدل إطارات معين (الإطارات في الثانية).
* استخدم أداة طرف ثالث مثل FFMpegCore (ffmpeg) لإنشاء فيديو استنادًا إلى الإطارات.

### **تحويل باوربوينت إلى فيديو**

1. استخدم أمر إضافة حزمة dotnet لإضافة Aspose.Slides ومكتبة FFMpegCore إلى مشروعك:
   * قم بتشغيل `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * قم بتشغيل `dotnet add package FFMpegCore --version 4.8.0`
2. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html).
3. يتطلب FFMpegCore أن تحدد المسار إلى ffmpeg الذي قمت بتنزيله (على سبيل المثال، مستخرج إلى "C:\tools\ffmpeg"): `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. قم بتشغيل الكود لتحويل باوربوينت إلى فيديو.

يوضح هذا الكود C# كيفية تحويل عرض تقديمي (يحتوي على صورة وتأثيرين متحركين) إلى فيديو:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // سنستخدم ملفات FFmpeg التي استخرجناها إلى "c:\tools\ffmpeg" سابقًا
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // يضيف شكل ابتسامة ثم يتحرك به
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
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

    // تكوين مجلد ملفات ffmpeg. انظر هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // تحويل الإطارات إلى فيديو webm
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **تأثيرات الفيديو**

يمكنك تطبيق الرسوم المتحركة على العناصر الموجودة على الشرائح واستخدام الانتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على هذه المقالات: [رسوم متحركة في باوربوينت](https://docs.aspose.com/slides/net/powerpoint-animation/)، [رسوم متحركة للأشكال](https://docs.aspose.com/slides/net/shape-animation/)، و[تأثير الأشكال](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات العروض التقديمية أكثر جاذبية واهتمامًا - وتفعل الشيء نفسه للفيديوهات. دعونا نضيف شريحة أخرى وانتقال إلى الكود الخاص بالعرض التقديمي السابق:

```c#
// يضيف شكل ابتسامة ويتحرك به

// ...

// يضيف شريحة جديدة وانتقال متحرك

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا نقوم بتحريك الفقرات على العناصر، والتي ستظهر واحدة تلو الأخرى (مع تأخير مضبوط على ثانية واحدة):

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // يضيف نصوص ورسوم متحركة
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("تحويل عرض باوربوينت مع نص إلى فيديو"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("فقرة تلو الأخرى"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // تحويل الإطارات إلى فيديو
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
    // تكوين مجلد ملفات ffmpeg. انظر هذه الصفحة: https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // تحويل الإطارات إلى فيديو webm
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **فئات تحويل الفيديو**

للسماح لك بتنفيذ مهام تحويل باوربوينت إلى فيديو، يوفر Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) و[PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) الكلاسات.

تسمح لك PresentationAnimationsGenerator بتعيين حجم الإطار للفيديو (الذي سيتم إنشاؤه لاحقًا) من خلال المُنشئ الخاص بها. إذا قمت بتمرير إصدار من العرض التقديمي، سيتم استخدام `Presentation.SlideSize` وتولد الرسوم المتحركة التي يستخدمها [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). 

عندما يتم إنشاء الرسوم المتحركة، يتم إنشاء حدث `NewAnimation` لكل رسم متحرك لاحق، وهو يحمل المعامل [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). الأخير هو فئة تمثل مشغلًا لرسم متحرك منفصل.

للتعامل مع [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/)، تُستخدم الخاصيتان [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (المدة الكاملة للرسوم المتحركة) و[SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) الطريقة. يتم تعيين كل موضع رسم متحرك ضمن النطاق *0 إلى المدة*، ثم ستعيد دالة `GetFrame` صورة Bitmap التي تتوافق مع حالة الرسوم المتحركة في تلك اللحظة.

```c#
using (Presentation presentation = new Presentation())
{
    // يضيف شكل ابتسامة ويتحرك به
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"مدة الرسوم المتحركة الإجمالية: {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // حالة الرسوم المتحركة الأولية
            Bitmap bitmap = animationPlayer.GetFrame(); // صورة حالة الرسوم المتحركة الأولية

            animationPlayer.SetTimePosition(animationPlayer.Duration); // الحالة النهائية للرسوم المتحركة
            Bitmap lastBitmap = animationPlayer.GetFrame(); // آخر إطار للرسوم المتحركة
            lastBitmap.Save("last.png");
        };
    }
}
```

لجعل جميع الرسوم المتحركة في عرض تقديمي تلعب مرة واحدة، يتم استخدام [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) الفئة. تأخذ هذه الفئة مثيلًا من [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) وFPS للتأثيرات في مُنشئها ثم تستدعي حدث `FrameTick` لكل الرسوم المتحركة للحصول على تشغيلها:

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

ثم يمكن تجميع الإطارات المولدة لإنتاج فيديو. انظر قسم [تحويل باوربوينت إلى فيديو](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**


**دخول**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **ظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دخول** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طفو** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو دوران** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |


**تأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **نبض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبض اللون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **توازن** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو/انكماش** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تخفيف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تعتيم** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **إنارة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون العنصر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون تكميلي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون الخط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون التعبئة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**خروج**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **خرج** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طفو** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انكماش دوران** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدوير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تدويرات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوائر** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **تأثيرات الانتقال بين الشرائح المدعومة**

**خفيفة**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **تحول** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دفع** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **سحب** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **كشف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **كشف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تغطية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **فلاش** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شرائط** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مثيرة**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **سقوط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ستارة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ستائر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **رياح** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **هيبة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تشقق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **سحق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تقشر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **حافة الصفحة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **طائرة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أوريغامي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **لوحة شطرنج** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ستائر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ساعة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تموج** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شخللة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تألق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **دوامة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تمزيق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تبديل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تقلب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **معرض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مكعب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أبواب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **صندوق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مشط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عشوائي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**محتوى ديناميكي**:

| نوع الرسوم المتحركة | Aspose.Slides | باوربوينت |
|---|---|---|
| **تدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **عجلة فيريس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **حزام ناقل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مدار** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **التحليق من خلال** | ![مدعوم](v.png) | ![مدعوم](v.png) |