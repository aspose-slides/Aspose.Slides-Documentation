---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام .NET
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
description: "اكتشف كيفية إنشاء وتخصيص رسوم متحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. تميز!"
---
## **المقدمة**

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/net/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* تأكيد النقاط الهامة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يقدم PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الأسماء [Aspose.Slides.Animation](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/)‎.
* توفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effecttype)‎. هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

تتيح Aspose.Slides لـ .NET تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء نسخة من الفئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)‎.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape)‎. 
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/properties/textframe)‎.
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape)‎.
7. تعيين الخاصية [TextAnimation.BuildType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/textanimation/properties/buildtype)‎ إلى القيمة من تعداد [BuildType Enumeration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype)‎.
8. حفظ العرض التقديمي على القرص كملف PPTX.

هذا الكود C# يوضح لك كيفية تطبيق تأثير `Fade` على AutoShape وتعيين حركة النص إلى القيمة *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // يضيف ثلاثة فقرات حتى يكون لدى بناء الفقرة حسب الفقرة شيء للانتقال خلاله.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // يحصل على التسلسل الرئيسي للشفرة.
    ISequence sequence = sld.Timeline.MainSequence;

    // يضيف تأثير Fade للرسوم المتحركة إلى الشكل
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يُحرك نص الشكل حسب فقرات المستوى الأول
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // يحفظ ملف PPTX على القرص
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

بجانب تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides/iparagraph). راجع [**Animated Text**](/slides/ar/net/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من الفئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)‎.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe)‎ على الشريحة. 
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ipictureframe)‎.
8. حفظ العرض التقديمي على القرص كملف PPTX.

هذا الكود C# يوضح لك كيفية تطبيق تأثير `Fly` على إطار صورة:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation())
{
    // حمّل الصورة لتضاف إلى مجموعة صور العرض التقديمي
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // يحصل على التسلسل الرئيسي للشفرة.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يضيف تأثير Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // احفظ ملف PPTX على القرص
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء نسخة من الفئة [Presentation](http://www.aspose.com/api/net/slides/ar/aspose.slides/)‎.
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape)‎. 
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape)‎ (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل الـ Bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. حفظ العرض التقديمي على القرص كملف PPTX.

هذا الكود C# يوضح لك كيفية تطبيق تأثير `PathFootball` (path football) على شكل:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ كائن Presentation يمثل ملف عرض تقديمي.
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

    // ينشئ مسار مستخدم مخصص. سيتحرك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر للتحريك لأن المسار المُنشأ فارغ.
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

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

تظهر الأمثلة التالية كيفية استخدام طريقة `GetEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/isequence/)‎ للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح لك الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

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

**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات الرسوم المتحركة إلى هذه العناصر النائبة، فإن جميع تأثيرات الشكل ستُعرض أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تحتوي فقط على شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير الرسوم المتحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أنه تم تطبيق تأثير **Split** على العنصر النائب للتذييل في شريحة **التخطيط**.

![تأثير الرسوم المتحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **القالب**.

![تأثير الرسوم المتحركة لشكل القالب](master-shape-animation.png)

يعرض لك الكود النموذجي التالي كيفية استخدام طريقة `GetBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)‎ للوصول إلى عناصر النائب الخاصة بالشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شرائح التخطيط والقالب.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة القالب.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

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
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تتيح Aspose.Slides لـ .NET تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![لوحة توقيت الرسوم المتحركة](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effect/properties/timing)‎:
- قائمة السحب للأسفل **Start** في توقيت PowerPoint تتطابق مع الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/properties/triggertype)‎. 
- **Duration** في توقيت PowerPoint يتطابق مع الخاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/properties/duration)‎. مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الرسوم لتكمل دورة واحدة. 
- **Delay** في توقيت PowerPoint يتطابق مع الخاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/properties/triggerdelaytime)‎. 
- قائمة السحب للأسفل **Repeat** تتطابق مع هذه الخصائص: 
  * الخاصية [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatcount)‎ التي تصف *عدد* مرات تكرار التأثير؛
  * العلم [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilendslide)‎ الذي يحدد ما إذا كان التأثير يتكرر حتى نهاية الشريحة؛
  * العلم [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/repeatuntilnextclick)‎ الذي يحدد ما إذا كان التأثير يتكرر حتى النقر التالي.
- صندوق الاختيار **Rewind when done playing** في توقيت PowerPoint يتطابق مع الخاصية [Effect.Timing.Rewind](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itiming/rewind/)‎. 

هذه هي طريقة تغيير خصائص توقيت التأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة للخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effect/properties/timing)‎ التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

هذا الكود C# يوضح العملية:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // يحصل على التسلسل الرئيسي للشرائح.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence[0];

    // يغير TriggerType للتأثير إلى البدء عند النقر
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // يغير مدة التأثير
    effect.Timing.Duration = 3f;

    // يغير TriggerDelayTime للتأثير
    effect.Timing.TriggerDelayTime = 0.5f;

    // إذا كانت قيمة Repeat للتأثير هي "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // يغير Repeat للتأثير إلى "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // يغير Repeat للتأثير إلى "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // يفعل Rewind للتأثير
        effect.Timing.Rewind = true;
    
    // يحفظ ملف PPTX على القرص
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع الأصوات في تأثيرات الرسوم المتحركة: 
- [IEffect.Sound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effect/sound/)‎ 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effect/stopprevioussound/)‎ 

### **إضافة صوت لتأثير الرسوم المتحركة**

هذا الكود C# يوضح لك كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// يحصل على التسلسل الرئيسي للشرحة.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// يحصل على أول تأثير في التسلسل الرئيسي
	IEffect firstEffect = sequence[0];

	// يفحص ما إذا كان التأثير لا يحتوي على صوت
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// يضيف صوتًا للتأثير الأول
		firstEffect.Sound = effectSound;
	}

	// يحصل على أول تسلسل تفاعلي للشرحة.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// يضبط علم "إيقاف الصوت السابق" للتأثير
	interactiveSequence[0].StopPreviousSound = true;

	// يكتب ملف PPTX إلى القرص
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/)‎.
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج [Sound](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/effect/sound/)‎ المضمن في كل تأثير رسوم متحركة. 

هذا الكود C# يوضح لك كيفية استخراج الصوت المضمن في تأثير الرسوم المتحركة:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // يحصل على التسلسل الرئيسي للشرحة.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // يستخرج صوت التأثير كمصفوفة بايت
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **بعد الرسوم المتحركة**

تتيح Aspose.Slides لـ .NET تغيير خاصية After animation لتأثير الرسوم المتحركة.

![لوحة تأثير الرسوم المتحركة بعد التنفيذ](shape-after-animation.png)

قائمة السحب للأسفل **After animation** في تأثير PowerPoint تتطابق مع هذه الخصائص: 

- الخاصية [IEffect.AfterAnimationType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/afteranimationtype/)‎ التي تصف نوع After animation :
  * **More Colors** في PowerPoint يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)‎;
  * **Don't Dim** في PowerPoint يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)‎ (نوع After animation الافتراضي);
  * **Hide After Animation** في PowerPoint يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)‎;
  * **Hide on Next Mouse Click** في PowerPoint يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)‎;
- الخاصية [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/afteranimationcolor/)‎ التي تحدد صيغة لون After animation. هذه الخاصية تعمل بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/afteranimationtype/)‎. إذا غيرت النوع إلى آخر، سيتم مسح لون After animation.

هذا الكود C# يوضح لك كيفية تغيير تأثير After animation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغير نوع الحركة اللاحقة إلى اللون
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // يضبط لون التعتيم بعد الحركة
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:

- الخاصية [IEffect.AnimateTextType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/animatetexttype/)‎ التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/animatetexttype/)‎ النوع)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/animatetexttype/)‎ النوع)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/animatetexttype/)‎ النوع)
- الخاصية [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/delaybetweentextparts/)‎ التي تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو حروف). القيمة الموجبة تحدد نسبة مئوية من مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي الطريقة التي يمكنك بها تغيير خصائص تحريك النص للتأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين الخاصية [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/itextanimation/buildtype/)‎ إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/buildtype/)‎ لإيقاف وضع التحريك *By Paragraphs*.
3. تعيين قيم جديدة للخصائص [IEffect.AnimateTextType](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/animatetexttype/)‎ و[IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/ar/net/aspose.slides.animation/ieffect/delaybetweentextparts/)‎.
4. حفظ ملف PPTX المعدل.

هذا الكود C# يوضح العملية:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // يغير نوع حركة النص للتأثير إلى "ككائن واحد"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // يغير نوع تحريك النص للتأثير إلى "كلمة بكلمة"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.DelayBetweenTextParts = 20f;

    // يكتب ملف PPTX إلى القرص
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **الأسئلة الشائعة**

### كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض على الويب؟

[Export to HTML5](/slides/ar/net/export-to-html5/) وتفعيل الـ [options](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/) المسؤولة عن الرسوم المتحركة للـ [shape](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animateshapes/) و[transition](https://reference.aspose.com/slides/ar/net/aspose.slides.export/html5options/animatetransitions/). HTML العادي لا يشغل الرسوم المتحركة للشرائح، بينما HTML5 يفعل ذلك.

### كيف يؤثر تغيير ترتيب z (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟

ترتيب الرسوم المتحركة والترسيم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/zorderposition/) ما يغطي ما. النتيجة المرئية تُحدد بتواصلهما. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

### هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟

عامةً، يتم دعم [الرسوم المتحركة](/slides/ar/net/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات معينة بطريقة مختلفة. يُنصح باختبار التأثيرات المستخدمة ومع نسخة المكتبة.