---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية في .NET
linktitle: رسوم متحركة للشكل
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
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET. تميّز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/net/animated-charts/). إنها تضفي حياةً على العروض التقديمية أو مكوناتها. 

## **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض التقديمي

يقدم PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/)‎،  
* توفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)‎. هذه التأثيرات هي في الأساس نفس التأثيرات (أو المكافئة) المستخدمة في PowerPoint. 

## **تطبيق الرسوم المتحركة على TextBox**

يتيح Aspose.Slides for .NET تطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء مثال من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‎.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‎.  
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe)‎.  
5. الحصول على تسلسل رئيسي من التأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‎.  
7. تعيين خاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype)‎ إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype)‎.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود C# كيفية تطبيق تأثير `Fade` على AutoShape وتعيين رسوم النص إلى القيمة *By 1st Level Paragraphs*:
```c#
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // يضيف AutoShape جديدًا مع النص
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // يحصل على التسلسل الرئيسي للشرائح.
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
بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph) واحد. راجع [**النص المتحرك**](/slides/ar/net/animated-text/).
{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثال من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‎.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) على الشريحة.  
5. الحصول على التسلسل الرئيسي للتأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe)‎.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود C# كيفية تطبيق تأثير `Fly` على إطار صورة:
```c#
// ينشئ كائنًا من فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    // تحميل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يحصل على التسلسل الرئيسي للشرحة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يضيف تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء مثال من الفئة [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/)‎.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‎.  
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)‎ (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).  
5. إنشاء تسلسل من التأثيرات على شكل Bevel.  
6. إنشاء `UserPath` مخصص.  
7. إضافة أوامر للتحرك إلى `UserPath`.  
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود C# كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```c#
// ينشئ كائنًا من فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // يضيف تأثير الرسوم المتحركة PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "زر".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات للزر.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر للتحريك لأن المسار المُنشأ فارغ.
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

تظهر الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من الواجهة [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/)‎ للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint التقديمية. يُظهر الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // يحصل على التسلسل الرئيسي للرسوم المتحركة للشرائح.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // يحصل على الشكل الأول في الشريحة الأولى.
    IShape shape = firstSlide.Shapes[0];

    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك الموروثة من العناصر النائبة**

إذا كان لل形 في شريحة عادية عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسة، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فإن جميع تأثيرات الشكل ستُعرض أثناء عرض الشرائح، بما في ذلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تضم فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![Slide shape animation effect](slide-shape-animation.png)

ولنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **layout**.

![Layout shape animation effect](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **master**.

![Master shape animation effect](master-shape-animation.png)

يعرض الكود النموذجي التالي كيفية استخدام طريقة `GetBasePlaceholder` من الواجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‎ للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك الموروثة من العناصر النائبة الموجودة على شرائح التخطيط والشرائح الرئيسة.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // الحصول على تأثيرات الرسوم المتحركة لعناصر النائب في شريحة التخطيط.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // الحصول على تأثيرات الرسوم المتحركة لعناصر النائب في شريحة الرئيس.
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

الإخراج:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يتيح Aspose.Slides for .NET تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:
![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing)‎:
- يطابق القائمة المنسدلة **Start** في توقيت PowerPoint خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype)‎.  
- يطابق **Duration** في توقيت PowerPoint خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration)‎. مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الرسوم لإكمال دورة واحدة.  
- يطابق **Delay** في توقيت PowerPoint خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime)‎.  
- يطابق القائمة المنسدلة **Repeat** في توقيت PowerPoint الخصائص التالية:
  * خاصية [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount)‎ التي تصف *عدد* مرات تكرار التأثير؛
  * علم [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide)‎ الذي يحدد ما إذا كان التأثير يتكرر حتى نهاية الشريحة؛
  * علم [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick)‎ الذي يحدد ما إذا كان التأثير يتكرر حتى النقر التالي.  
- يطابق مربع الاختيار **Rewind when done playing** في توقيت PowerPoint خاصية [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/)‎.  

هذه هي طريقة تغيير خصائص توقيت التأثير:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing)‎ التي تحتاجها.  
3. حفظ ملف PPTX المعدل.  

يعرض هذا الكود C# العملية:
```c#
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // يحصل على التسلسل الرئيسي للشرائح.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence[0];

    // يغير TriggerType للتأثير لتبدأ عند النقر
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // يغير مدة التأثير
    effect.Timing.Duration = 3f;

    // يغير TriggerDelayTime للتأثير
    effect.Timing.TriggerDelayTime = 0.5f;

    // إذا كانت قيمة Repeat للتأثير هي "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // يغير Repeat للتأثير إلى "حتى النقر التالي"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // يغير Repeat للتأثير إلى "حتى نهاية الشريحة"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // تشغيل Rewind للتأثير
        effect.Timing.Rewind = true;
    
    // حفظ ملف PPTX إلى القرص
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **صوت تأثير الرسوم المتحركة**

يوفر Aspose.Slides الخصائص التالية لتسمح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة:
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)‎  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/)‎  

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض هذا الكود C# كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// يضيف صوتًا إلى مجموعة الصوتيات في العرض التقديمي
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يحصل على التسلسل الرئيسي للشرائح.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// يحصل على أول تأثير في التسلسل الرئيسي.
	IEffect firstEffect = sequence[0];

	// يتحقق من أن التأثير لا يحتوي على صوت
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// يضيف صوتًا للتأثير الأول
		firstEffect.Sound = effectSound;
	}

	// يحصل على أول تسلسل تفاعلي للشرائح.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// يضبط علامة "إيقاف الصوت السابق" للتأثير
	interactiveSequence[0].StopPreviousSound = true;

	// يحفظ ملف PPTX إلى القرص
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‎.  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)‎ المضمّن في كل تأثير رسوم متحركة.  

يعرض هذا الكود C# كيفية استخراج الصوت المضمّن في تأثير الرسوم المتحركة:
```c#
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يحصل على التسلسل الرئيسي للشرائح.
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

يتيح Aspose.Slides for .NET تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:
![example1_image](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تطابق هذه الخصائص:
- خاصية [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/)‎ التي تصف نوع After animation:
  * يطابق **More Colors** في PowerPoint نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)‎؛
  * يطابق العنصر **Don't Dim** في PowerPoint نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)‎ (نوع After animation الافتراضي)؛
  * يطابق العنصر **Hide After Animation** في PowerPoint نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)‎؛
  * يطابق العنصر **Hide on Next Mouse Click** في PowerPoint نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)‎؛
- خاصية [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/)‎ التي تحدد تنسيق لون After animation. تعمل هذه الخاصية بالتوازي مع نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/)‎. إذا قمت بتغيير النوع إلى آخر، سيُمحى لون After animation.  

يعرض هذا الكود C# كيفية تغيير تأثير After animation:
```c#
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغير نوع الحركة بعد الانتهاء إلى اللون
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // يحدد لون التعتيم بعد الحركة
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // يحفظ ملف PPTX إلى القرص
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **تحريك النص**

يوفر Aspose.Slides الخصائص التالية لتسمح لك بالعمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:
- خاصية [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/)‎ التي تصف نوع Animate text للتأثير. يمكن تحريك نص الشكل:
  * كلّها مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)  
  * كلمة بكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)  
  * حرف بحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) النوع)  
- خاصية [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/)‎ التي تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الإيجابية تحدد نسبة مدة التأثير. القيمة السلبية تحدد التأخير بالثواني.  

هذه هي طريقة تغيير خصائص Effect Animate text:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. تعيين خاصية [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/)‎ إلى قيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) لإيقاف وضعية التحريك *By Paragraphs*.  
3. تعيين قيم جديدة لخاصيتي [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) و[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).  
4. حفظ ملف PPTX المعدل.  

يعرض هذا الكود C# العملية:
```c#
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // يغيّر نوع تحريك النص إلى "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // يعيّن التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.DelayBetweenTextParts = 20f;

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**  
[Export to HTML5](/slides/ar/net/export-to-html5/) وتفعيل [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) المسؤولة عن الرسوم المتحركة لل[shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) و[transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). لا تقوم HTML العادي بتشغيل رسوم الشرائح، في حين أن HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب z-order (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**  
الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) ما يغطي ما. النتيجة الظاهرة تُحدد بتكوينهما معًا. (هذا هو سلوك PowerPoint العام؛ نموذج التأثيرات والأشكال في Aspose.Slides يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**  
بشكل عام، يتم دعم [animations are supported](/slides/ar/net/convert-powerpoint-to-video/)، لكن بعض الحالات النادرة أو التأثيرات المحددة قد تُعرض بشكل مختلف. يُنصح بالاختبار باستخدام التأثيرات التي تستخدمها ومع نسخة المكتبة.