---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية في .NET
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/net/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص والصور والأشكال أو [المخططات](/slides/ar/net/animated-charts/). إنها تضيف الحيوية إلى العروض التقديمية أو مكوناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 
* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض التقديمي

توفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* Aspose.Slides توفر الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الأسماء [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/).
* Aspose.Slides توفر أكثر من **150 تأثير رسوم متحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع نص**

تتيح Aspose.Slides لـ .NET إمكانية تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. إضافة `مستطيل` من النوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. ضبط خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

هذا الكود C# يوضح كيفية تطبيق تأثير `Fade` على AutoShape وضبط الرسوم المتحركة للنص إلى القيمة *By 1st Level Paragraphs*:
```c#
// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // يحصل على التسلسل الرئيسي للشرائح.
    ISequence sequence = sld.Timeline.MainSequence;

    // يضيف تأثير Fade للرسوم المتحركة إلى الشكل
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل باستخدام فقرات المستوى الأول
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // حفظ ملف PPTX إلى القرص
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph) مفرد. راجع [**النص المتحرك**](/slides/ar/net/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على إطار صورة**

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) على الشريحة. 
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

هذا الكود C# يوضح كيفية تطبيق تأثير `Fly` على إطار صورة:
```c#
// إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    // تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // إضافة إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // الحصول على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // إضافة تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. الحصول على مرجع الشريحة من خلال فهرستها.
3. إضافة `مستطيل` من النوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (عند النقر على هذا الكائن يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على الشكل Bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

هذا الكود C# يوضح كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // ينشئ تأثير PathFootball للشكل الحالي من البداية.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // يضيف تأثير التحريك PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا ما من "زر".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات للزر.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // ينشئ مسارًا مخصصًا للمستخدم. سيتحرك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر الحركة لأن المسار المخلق فارغ.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

توضح الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود العيني التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض التقديمي `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // يحصل على تسلسل الرسوم المتحركة الرئيسي للشريحة.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // يحصل على الشكل الأول في الشريحة الأولى.
    IShape shape = firstSlide.Shapes[0];

    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان هناك شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسة، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تضم فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير حركة شكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على عنصر نائب التذييل في شريحة **التخطيط**.

![تأثير حركة شكل التخطيط](layout-shape-animation.png)

وأخيرًا، أن تأثير **Fly In** تم تطبيقه على عنصر نائب التذييل في شريحة **الرئيس**.

![تأثير حركة شكل الرئيس](master-shape-animation.png)

يظهر الكود العيني التالي كيفية استخدام طريقة `GetBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للوصول إلى العناصر النائبة للأشكال والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شرائح التخطيط والرئيس.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على تأثيرات الرسوم المتحركة للشكل على الشريحة العادية.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // الحصول على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة التخطيط.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // الحصول على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة الرئيس.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```

```cs
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
التسلسل الرئيسي لتأثيرات الشكل:
تحليق أسفل
تقسيم عمودي داخل
أشرطة عشوائية أفقية
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تتيح Aspose.Slides لـ .NET إمكانية تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

- قائمة **Start** المنسدلة في توقيت PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- توقيت PowerPoint **Duration** يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه لإكمال دورة واحدة. 
- توقيت PowerPoint **Delay** يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- قائمة **Repeat** المنسدلة في توقيت PowerPoint تتطابق مع هذه الخصائص: 
  * خاصية [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) التي تصف *عدد* مرات تكرار التأثير؛
  * علم [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) الذي يحدد ما إذا كان التأثير يتكرر حتى نهاية الشريحة؛
  * علم [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) الذي يحدد ما إذا كان التأثير يتكرر حتى النقر التالي.
- مربع الاختيار **Rewind when done playing** في توقيت PowerPoint يتطابق مع خاصية [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

هذه هي الطريقة لتغيير خصائص توقيت التأثير:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

هذا الكود C# يوضح العملية:
```c#
// إنشاء كائن من فئة Presentation يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يحصل على التأثير الأول في التسلسل الرئيسي.
    IEffect effect = sequence[0];

    // يغيّر TriggerType الخاص بالتأثير لتبدأ عند النقر
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // يغيّر Duration الخاص بالتأثير
    effect.Timing.Duration = 3f;

    // يغيّر TriggerDelayTime الخاص بالتأثير
    effect.Timing.TriggerDelayTime = 0.5f;

    // إذا كانت قيمة Repeat للتأثير هي "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // يغيّر Repeat الخاص بالتأثير إلى "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // يغيّر Repeat الخاص بالتأثير إلى "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // يفعل Rewind الخاص بالتأثير
        effect.Timing.Rewind = true;
    
    // يحفظ ملف PPTX إلى القرص
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص لتسمح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة:
- خاصية [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- خاصية [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **إضافة صوت لتأثير الرسوم المتحركة**

هذا الكود C# يوضح كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يحصل على التسلسل الرئيسي للشريحة.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// يحصل على التأثير الأول في التسلسل الرئيسي
	IEffect firstEffect = sequence[0];

	// يتحقق من التأثير لعدم وجود صوت
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// يضيف صوتًا للتأثير الأول
		firstEffect.Sound = effectSound;
	}

	// يحصل على التسلسل التفاعلي الأول للشريحة.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// يضبط علامة "إيقاف الصوت السابق" للتأثير
	interactiveSequence[0].StopPreviousSound = true;

	// يكتب ملف PPTX إلى القرص
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **استخراج صوت لتأثير الرسوم المتحركة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرستها. 
3. الحصول على التسلسل الرئيس للتأثيرات. 
4. استخراج [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) المضمن لكل تأثير رسوم متحركة. 

هذا الكود C# يوضح كيفية استخراج الصوت المضمن في تأثير الرسوم المتحركة:
```c#
// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // يستخرج صوت التأثير في مصفوفة بايت
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **بعد الرسوم المتحركة**

تتيح Aspose.Slides لـ .NET إمكانية تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تتطابق مع هذه الخصائص:
- خاصية [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) التي تصف نوع After animation :
  * PowerPoint **More Colors** يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) .
  * PowerPoint **Don't Dim** يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (نوع After animation الافتراضي) ;
  * PowerPoint **Hide After Animation** يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- خاصية [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) التي تحدد تنسيق لون After animation. تعمل هذه الخاصية بالتنسيق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون After animation.

هذا الكود C# يوضح كيفية تغيير تأثير After animation:
```c#
// ينشئ كائن فئة Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغيّر نوع الحركة اللاحقة إلى Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // يعيّن لون إضاءة الحركة اللاحقة
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // يحفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتسمح لك بالعمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:
- خاصية [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - الكل مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
  - كلمة بكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
  - حرف بحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
- خاصية [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تحدد نسبة مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي الطريقة لتغيير خصائص Effect Animate text:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين خاصية [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) لإلغاء وضعية التحريك *By Paragraphs*.
3. تعيين قيم جديدة لخصائص [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) و[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. حفظ ملف PPTX المعدل.

هذا الكود C# يوضح العملية:
```c#
// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغيّر نوع تحريك النص في التأثير إلى "كائن واحد"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // يغيّر نوع تحريك النص في التأثير إلى "كلمة بكلمة"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // يحدد التأخير بين الكلمات إلى 20٪ من مدة التأثير
    firstEffect.DelayBetweenTextParts = 20f;

    // يحفظ ملف PPTX إلى القرص
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**

[Export to HTML5](/slides/ar/net/export-to-html5/) وتفعيل الـ [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) المسؤولة عن رسوم المتحركة للـ [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). HTML العادي لا يشغل رسوم المتحركة للشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب z-order (ترتيب الطبقة) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) ما يغطي ما. النتيجة المرئية تُحدد بتكوينهما معًا. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للتأثيرات والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

عمومًا، [الدعم للرسوم المتحركة](/slides/ar/net/convert-powerpoint-to-video/) موجود، لكن قد تُعرض بعض الحالات النادرة أو التأثيرات المحددة بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.