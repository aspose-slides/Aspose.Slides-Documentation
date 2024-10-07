---
title: رسوم متحركة للشكل
type: docs
weight: 60
url: /net/shape-animation/
keywords: 
- رسوم متحركة في باوربوينت
- تأثير الرسوم المتحركة
- تطبيق الرسوم المتحركة
- عرض باوربوينت
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "تطبيق الرسوم المتحركة في باوربوينت باستخدام C# أو .NET"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/net/animated-charts/). إنها تضفي الحياة على العروض التقديمية أو مكوناتها.

### **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

من خلال استخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يوفر باوربوينت العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول** و**الخروج** و**التأكيد** و**مسارات الحركة**.

### **الرسوم المتحركة في Aspose.Slides**

* يوفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة اسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/).
* يوفر Aspose.Slides أكثر من **150 تأثير رسوم متحركة** تحت التعداد [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). هذه التأثيرات هي في الأساس نفس (أو مكافئ) التأثيرات المستخدمة في باوربوينت.

## **تطبيق الرسوم المتحركة على مربع النص**

يسمح Aspose.Slides لـ .NET بتطبيق الرسوم المتحركة على النص في شكل. 

1. أنشئ مثيلًا من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف `مستطيل` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. أضف النص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. احصل على تسلسل التأثيرات الرئيسي.
6. أضف تأثير الرسوم المتحركة إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. قم بتعيين خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) إلى القيمة من [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. سجل العرض التقديمي على القرص كملف PPTX.

يوضح هذا الكود C# كيفية تطبيق تأثير `تلاشي` على AutoShape وتعيين رسوم متحركة النص إلى القيمة *بـ 1st Level Paragraphs*:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // يضيف AutoShape جديدة مع نص
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "الفقرة الأولى \nالفقرة الثانية \nالفقرة الثالثة";

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.Timeline.MainSequence;

    // يضيف تأثير الرسوم المتحركة Fade للشكل
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يقوم بتحريك نص الشكل وفقًا للفقرتين من المستوى الأول
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // احفظ ملف PPTX على القرص
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على فقرة واحدة [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). انظر [**النص المتحرك**](/slides/net/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على صورة**

1. أنشئ مثيلًا من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) في الشريحة. 
5. احصل على التسلسل الرئيسي للتأثيرات.
6. أضف تأثير الرسوم المتحركة إلى [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. سجل العرض التقديمي على القرص كملف PPTX.

يوضح هذا الكود C# كيفية تطبيق تأثير `Fly` على إطار الصورة:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    // تحميل الصورة التي سيتم إضافتها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار الصورة إلى الشريحة
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يضيف تأثير الرسوم المتحركة Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // احفظ ملف PPTX على القرص
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **تطبيق الرسوم المتحركة على الشكل**

1. أنشئ مثيلًا من فئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف `مستطيل` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. أضف [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (عندما يتم النقر على هذا العنصر، يتم تشغيل الرسوم المتحركة).
5. أنشئ تسلسلًا من التأثيرات على الشكل ذو التأثير السطحي.
6. أنشئ `UserPath` مخصص.
7. أضف أوامر للتحرك إلى `UserPath`.
8. سجل العرض التقديمي على القرص كملف PPTX.

يوضح هذا الكود C# كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // يُنشئ تأثير PathFootball لشكل موجود من الصفر.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("مربع نص متحرك");

    // يضيف تأثير الرسوم المتحركة PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // يُنشئ نوعًا من "الزر".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // يُنشئ تسلسلًا من التأثيرات للزر.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // يُنشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر للتحرك نظرًا لأن المسار الذي تم إنشاؤه فارغ.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // يكتب ملف PPTX على القرص
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على الشكل**

يمكنك أن تقرر أن تعرف جميع تأثيرات الرسوم المتحركة المطبقة على شكل واحد. 

يوضح هذا الكود C# كيفية الحصول على جميع التأثيرات المطبقة على شكل معين:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // يحصل على أول شكل في الشريحة.
    IShape shape = firstSlide.Shapes[0];

    // يحصل على جميع تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("الشكل " + shape.Name + " لديه " + shapeEffects.Length + " تأثيرات رسوم متحركة.");
}
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يسمح Aspose.Slides لـ .NET بتغيير خصائص توقيت تأثير الرسوم المتحركة.

هذا هو لوحة توقيت الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت باوربوينت وخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):
- قائمة السحب **Start** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- **Duration** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي المستغرق لإكمال الدورة الكاملة للرسوم المتحركة.
- **Delay** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- قائمة السحب **Repeat** في توقيت باوربوينت تتطابق مع هذه الخصائص: 
  * خاصية [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) التي تصف *عدد* مرات تكرار التأثير؛
  * العلامة [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) التي تحدد ما إذا كان سيتم تكرار التأثير حتى نهاية الشريحة؛
  * العلامة [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) التي تحدد ما إذا كان سيتم تكرار التأثير حتى النقرة التالية.
- مربع الاختيار **Rewind when done playing** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) . 

هذا هو كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) التي تحتاجها. 
3. احفظ ملف PPTX المعدل.

يوضح هذا الكود C# العملية:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يحصل على أول تأثير للتسلسل الرئيسي.
    IEffect effect = sequence[0];

    // يغير نوع التأثير TriggerType ليبدأ عند النقر
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // يغير مدة التأثير
    effect.Timing.Duration = 3f;

    // يغير TriggerDelayTime للتأثير
    effect.Timing.TriggerDelayTime = 0.5f;

    // إذا كانت قيمة تكرار التأثير هي "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // يغير تكرار التأثير إلى "حتى النقرة التالية"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // يغير تكرار التأثير إلى "حتى نهاية الشريحة"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // يقوم بتفعيل إعادة التشغيل للتأثير
    effect.Timing.Rewind = true;
    
    // يحفظ ملف PPTX على القرص
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **صوت تأثير الرسوم المتحركة**

يوفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **إضافة صوت تأثير الرسوم المتحركة**

يوضح هذا الكود C# كيفية إضافة صوت تأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// يضيف الصوت إلى مجموعة الأصوات في العرض التقديمي
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يحصل على التسلسل الرئيسي للشريحة.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// يحصل على أول تأثير للتسلسل الرئيسي
	IEffect firstEffect = sequence[0];

	// يتحقق من التأثير لـ "بدون صوت"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// يضيف صوتًا للتأثير الأول
		firstEffect.Sound = effectSound;
	}

	// يحصل على أول تسلسل تفاعلي للشريحة.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// يحدد علم "إيقاف الصوت السابق"
	interactiveSequence[0].StopPreviousSound = true;

	// يكتب ملف PPTX على القرص
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. احصل على التسلسل الرئيسي للتأثيرات. 
4. استخراج [الصوت](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) المضمن في كل تأثير رسوم متحركة. 

يوضح هذا الكود C# كيفية استخراج الصوت المضمن في تأثير رسوم متحركة:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
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

يسمح Aspose.Slides لـ .NET بتغيير خاصية بعد الرسوم المتحركة لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تتطابق قائمة السحب **بعد الرسوم المتحركة** في باوربوينت مع هذه الخصائص: 

- خاصية [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) التي تصف نوع الرسوم المتحركة بعد التأثير :
  * تتطابق **ألوان أكثر** في باوربوينت مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * تتطابق قائمة **لا تظلم** مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (نوع الرسوم المتحركة الافتراضي بعد التأثير) ;
  * تتطابق قائمة **إخفاء بعد الرسوم المتحركة** مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * تتطابق قائمة **الإخفاء عند النقر بالماوس التالي** مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- خاصية [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) التي تحدد تنسيق لون ما بعد الرسوم المتحركة. تعمل هذه الخاصية مع نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) . إذا قمت بتغيير النوع إلى آخر، فسيتم مسح لون الرسوم المتحركة بعد التأثير.

يوضح هذا الكود C# كيفية تغيير تأثير الرسوم المتحركة بعد:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير للتسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغير نوع الرسوم المتحركة بعد التأثير إلى لون
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // يقوم بتعيين لون التعتيم بعد الرسوم المتحركة
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // يكتب ملف PPTX على القرص
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **تحريك النص**

يوفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *تحريك النص* لتأثير الرسوم المتحركة:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - دفعة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
  - كلمة بكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
  - حرف بحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو حروف). تحدد القيمة الإيجابية النسبة المئوية لمدة التأثير. تحدد القيمة السلبية التأخير بالثواني.

هذه هي كيفية تغيير خصائص تأثير تحريك النص:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين خاصية [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) لإيقاف وضع الرسوم المتحركة *حسب الفقرات*.
3. تعيين قيم جديدة لخصائص [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) و[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) .
4. احفظ ملف PPTX المعدل.

يوضح هذا الكود C# العملية:

```c#
// يقوم بإنشاء مثيل لفئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير للتسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغير نوع الرسوم المتحركة للنص التأثير إلى "ككل جسم"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // يغير نوع تحريك النص التأثير إلى "كلمة بكلمة"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // يعين التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.DelayBetweenTextParts = 20f;

    // يكتب ملف PPTX على القرص
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```