---
title: تحريك الشكل
type: docs
weight: 60
url: /ar/net/shape-animation/
keywords:
- شكل
- تحريك
- تأثير
- إضافة تأثيرات
- الحصول على تأثيرات
- استخراج تأثيرات
- تطبيق التحريك
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "تطبيق تحريك PowerPoint في C# أو .NET"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [الرسوم البيانية](/slides/ar/net/animated-charts/). إنها تضفي حياةً على العروض التقديمية أو مكوّناتها. 

## **لماذا تستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* تسليط الضوء على النقاط الهامة
* زيادة الاهتمام أو المشاركة لدى الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض

يقدم PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن الفضاء الاسمي [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/)،
* توفر Aspose.Slides أكثر من **150 تأثير رسوم متحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

يتيح Aspose.Slides لـ .NET تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها.
3. إضافة `مستطيل` من النوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. تعيين خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. حفظ العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C# كيفية تطبيق تأثير `Fade` على AutoShape وتعيين رسوم المتحركة النصية إلى القيمة *By 1st Level Paragraphs*:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // يضيف AutoShape جديد مع النص
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.Timeline.MainSequence;

    // يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل حسب الفقرات من المستوى الأول
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // حفظ ملف PPTX إلى القرص
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/net/aspose.slides.iparagraph). راجع [**النص المتحرك**](/slides/ar/net/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها.
3. إضافة أو الحصول على عنصر [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) في الشريحة. 
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. حفظ العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C# كيفية تطبيق تأثير `Fly` على إطار صورة:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    // تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يضيف تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء مثيل من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها.
3. إضافة `مستطيل` من النوع [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. إضافة `Bevel` [IAutoShape] (عند النقر على هذا العنصر، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل الـ Bevel.
6. إنشاء مسار مخصص `UserPath`.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. حفظ العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود C# كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```c#
// ينشئ فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // يضيف تأثير الرسوم المتحركة PathFootball.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "زر".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات للزر.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // ينشئ مسار مستخدم مخصص. سيُحرك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر للحركة لأن المسار المُنشأ فارغ.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

تظهر الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يُظهر لك الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // يحصل على التسلسل الرئيسي للرسوم المتحركة للشريحة.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // يحصل على أول شكل في الشريحة الأولى.
    IShape shape = firstSlide.Shapes[0];

    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان لل shape في شريحة عادية عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسة، وتم إضافة تأثيرات رسوم متحركة لهذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تشمل فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![Slide shape animation effect](slide-shape-animation.png)

كما نفترض أن تأثير **Split** مُطبق على العنصر النائب للتذييل في شريحة **التخطيط**.

![Layout shape animation effect](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **الرئيسية**.

![Master shape animation effect](master-shape-animation.png)

يعرض لك الكود النموذجي التالي كيفية استخدام طريقة `GetBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) للوصول إلى العناصر النائبة لل shapes والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شرائح التخطيط والرئيسية.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة الرئيس.
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


```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يتيح Aspose.Slides لـ .NET تعديل خصائص التوقيت لتأثير الرسوم المتحركة.

هذا هو لوحة توقيت الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing):
- توقيت PowerPoint **Start** في قائمة السحب المنسدلة يتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- توقيت PowerPoint **Duration** يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الرسوم لإكمال دورة واحدة. 
- توقيت PowerPoint **Delay** يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- توقيت PowerPoint **Repeat** في قائمة السحب المنسدلة يتطابق مع الخصائص التالية: 
  * خاصية [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) التي تصف *العدد* المرات التي يتكرر فيها التأثير؛
  * علم [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) الذي يحدد ما إذا كان التأثير يتكرر حتى نهاية الشريحة؛
  * علم [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) الذي يحدد ما إذا كان التأثير يتكرر حتى النقر التالي.
- خانة الاختيار **Rewind when done playing** في توقيت PowerPoint تتطابق مع خاصية [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/).

هذه هي الطريقة لتغيير خصائص توقيت Effect:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

يعرض لك هذا الكود C# العملية:
```c#
 // ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
 using (Presentation pres = new Presentation("AnimExample_out.pptx"))
 {
     // يحصل على التسلسل الرئيسي للشريحة.
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // يحصل على أول تأثير في التسلسل الرئيسي.
     IEffect effect = sequence[0];

     // يغيّر TriggerType للتأثير ليبدأ عند النقر
     effect.Timing.TriggerType = EffectTriggerType.OnClick;

     // يغيّر مدة التأثير
     effect.Timing.Duration = 3f;

     // يغيّر TriggerDelayTime للتأثير
     effect.Timing.TriggerDelayTime = 0.5f;

     // إذا كانت قيمة Repeat للتأثير هي "none"
     if (effect.Timing.RepeatCount == 1f)
     {
         // يغيّر Repeat للتأثير إلى "Until Next Click"
         effect.Timing.RepeatUntilNextClick = true;
     }
     else
     {
         // يغيّر Repeat للتأثير إلى "Until End of Slide"
         effect.Timing.RepeatUntilEndSlide = true;
     }

     // يفعل خيار Rewind للتأثير
         effect.Timing.Rewind = true;
     
     // يحفظ ملف PPTX إلى القرص
     pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
 }
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص لتمكينك من العمل مع الأصوات في تأثيرات الرسوم المتحركة: 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض لك هذا الكود C# كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يحصل على التسلسل الرئيسي للشريحة.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// يحصل على أول تأثير في التسلسل الرئيسي
	IEffect firstEffect = sequence[0];

	// يتحقق من أن التأثير لا يحتوي على صوت
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// يضيف صوتًا للتأثير الأول
		firstEffect.Sound = effectSound;
	}

	// يحصل على أول تسلسل تفاعلي للشريحة.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// يعيّن علم إيقاف الصوت السابق للتأثير
	interactiveSequence[0].StopPreviousSound = true;

	// يكتب ملف PPTX إلى القرص
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الـ [Sound] المدمج في كل تأثير رسوم متحركة. 

يعرض لك هذا الكود C# كيفية استخراج الصوت المدمج في تأثير الرسوم المتحركة:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
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

يتيح Aspose.Slides لـ .NET تعديل خاصية After animation لتأثير الرسوم المتحركة.

![example1_image](shape-after-animation.png)

قائمة السحب المنسدلة **After animation** في PowerPoint تتطابق مع الخصائص التالية: 

- خاصية [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) التي تصف نوع After animation :
  * PowerPoint **More Colors** يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)؛
  * PowerPoint **Don't Dim** يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (نوع After animation الافتراضي)؛
  * PowerPoint **Hide After Animation** يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)؛
  * PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)؛
- خاصية [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) التي تُعرّف تنسيق لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). إذا قمت بتغيير النوع إلى آخر، سيُمسح لون After animation.

يعرض لك هذا الكود C# كيفية تغيير تأثير After animation:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغيّر نوع الرسوم المتحركة اللاحقة إلى اللون
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // يحدد لون التعتيم بعد الرسوم المتحركة
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // يحفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتمكينك من العمل مع كتبة *Animate text* في تأثير الرسوم المتحركة:

- خاصية [IEffect.AnimateTextType] التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  * كل النص مرة واحدة ([AnimateTextType.AllAtOnce] النوع)
  * كلمة بكلمة ([AnimateTextType.ByWord] النوع)
  * حرف بحرف ([AnimateTextType.ByLetter] النوع)
- خاصية [IEffect.DelayBetweenTextParts] التي تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تشير إلى نسبة مئوية من مدة التأثير، والقيمة السالبة تشير إلى التأخير بالثواني.

هذه هي الطريقة لتغيير خصائص Animate text في Effect:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين خاصية [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) إلى القيمة [BuildType.AsOneObject] لإيقاف وضع التحريك *By Paragraphs*.
3. تعيين قيم جديدة لخصائص [IEffect.AnimateTextType] و[IEffect.DelayBetweenTextParts].
4. حفظ ملف PPTX المعدل.

يعرض لك هذا الكود C# العملية:
```c#
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // يغيّر نوع تحريك النص للتأثير إلى "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.DelayBetweenTextParts = 20f;

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض على الويب؟**

استخدم [Export to HTML5](/slides/ar/net/export-to-html5/) وقم بتمكين [الخيارات](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) المسؤولة عن رسوم [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) . HTML عادي لا يعرض رسومات الشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) ما يغطي ما. النتيجة المرئية تحددها مجموعهما. (هذا سلوك PowerPoint العام؛ نموذج التأثيرات والأشكال في Aspose.Slides يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/net/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات معينة بطريقة مختلفة. يُنصح باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.