---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام Java
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/java/shape-animation/
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
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص والصور والأشكال أو [المخططات](https://docs.aspose.com/slides/java/animated-charts/). إنها تضفي الحياة على العروض التقديمية أو مكوّناتها. 

## **لماذا تستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 
* ضبط تدفق المعلومات
* تأكيد النقاط الهامة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القرّاء أو المشاهدين إلى أجزاء مهمة في العرض

يُوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثيرًا متحركًا** ضمن تعداد [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). هذه التأثيرات هي نفسها (أو ما يعادلها) التي تُستخدم في PowerPoint.

## **تطبيق الرسوم المتحركة على صندوق نص**

يتيح Aspose.Slides for Java تطبيق الرسوم المتحركة على النص داخل شكل.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) من نوع `rectangle`.
4. أضف نصًا إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. احصل على تسلسل رئيسي من التأثيرات.
6. أضف تأثيرًا متحركًا إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
7. عيّن الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. اكتب العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود Java كيفية تطبيق تأثير `Fade` على AutoShape وتعيين الرسوم المتحركة للنص إلى القيمة *By 1st Level Paragraphs*:
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل وفق الفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 
بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) واحد. راجع [**نص متحرك**](/slides/ar/java/animated-text/).
{{% /alert %}} 

## **تطبيق الرسوم المتحركة على إطار صورة**

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) على الشريحة.
4. احصل على التسلسل الرئيسي للتأثيرات.
5. أضف تأثيرًا متحركًا إلى [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. اكتب العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود Java كيفية تطبيق تأثير `Fly` على إطار صورة:
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    // حمّل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يضيف تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق الرسوم المتحركة على شكل**

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) من نوع `rectangle`.
4. أضف `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) (عند النقر على هذا الكائن يتم تشغيل الرسوم المتحركة).
5. أنشئ تسلسلًا من التأثيرات على شكل الـ Bevel.
6. أنشئ `UserPath` مخصصًا.
7. أضف أوامر للتحرك إلى `UserPath`.
8. اكتب العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود Java كيفية تطبيق تأثير `PathFootball` (path football) على شكل:
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء تأثير PathFootball للشكل الحالي من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // يضيف تأثير الرسوم المتحركة PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "زر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للتحريك لأن المسار المخلق فارغ.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

تظهر الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint التقديمية. يوضح الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للرسوم المتحركة للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على الشكل الأول في الشريحة الأولى.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من عناصر الحجز (placeholders)**

إذا كان الشكل على شريحة عادية يحتوي على عناصر حجز (placeholders) موجودة على شريحة التخطيط و/أو الشريحة الرئيسية، وتم إضافة تأثيرات الرسوم المتحركة إلى هذه العناصر، فستُعرض جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من عناصر الحجز.

لنفترض أن لدينا ملف عرض PowerPoint باسم `sample.pptx` يحتوي على شريحة واحدة تضم فقط شكل تذييل نصه "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.
![تأثير الرسوم المتحركة للشكل في الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** مطبق على عنصر الحجز في شريحة التخطيط.
![تأثير Split مطبق على عنصر الحجز في شريحة التخطيط](layout-shape-animation.png)

وأخيرًا، تأثير **Fly In** مطبق على عنصر الحجز في الشريحة الرئيسية.
![تأثير Fly In مطبق على عنصر الحجز في الشريحة الرئيسية](master-shape-animation.png)

يعرض الكود النموذجي التالي كيفية استخدام طريقة `getBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للوصول إلى عناصر حجز الشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر الموجودة على شرائح التخطيط والرئيسية.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// احصل على تأثيرات الرسوم المتحركة للشكل على الشريحة العادية.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// احصل على تأثيرات الرسوم المتحركة لعناصر الحجز على شريحة التخطيط.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// احصل على تأثيرات الرسوم المتحركة لعناصر الحجز على الشريحة الرئيسية.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
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

يتيح Aspose.Slides for Java تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:
![لوحة توقيت الرسوم المتحركة](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :
- قائمة **Start** المنسدلة في توقيت PowerPoint تتطابق مع الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--).
- توقيت PowerPoint **Duration** يتطابق مع الخاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.
- توقيت PowerPoint **Delay** يتطابق مع الخاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

هذه هي طريقة تغيير خصائص توقيت التأثير:
1. استخدم [Apply](#apply-animation-to-shape) أو احصل على تأثير الرسوم المتحركة.
2. عيّن قيمًا جديدة للخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) التي تحتاجها.
3. احفظ ملف PPTX المعدل.
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على التأثير الأول في التسلسل الرئيسي.
    IEffect effect = sequence.get_Item(0);

    // يغيّر TriggerType للتأثير لتبدأ عند النقر
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // يغيّر مدة التأثير
    effect.getTiming().setDuration(3f);

    // يغيّر TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5f);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة:
- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض هذا الكود Java كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يفحص التأثير للتأكد من عدم وجود صوت
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على التسلسل التفاعلي الأول للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علامة "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/).
2. احصل على مرجع الشريحة عبر فهرستها.
3. احصل على التسلسل الرئيسي للتأثيرات.
4. استخرج [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المدمج في كل تأثير رسومي.

يعرض هذا الكود Java كيفية استخراج الصوت المدمج في تأثير الرسوم المتحركة:
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // يستخرج صوت التأثير كمصفوفة بايت
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **بعد الرسوم المتحركة**

يتيح Aspose.Slides for Java تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:
![لوحة تأثير الرسوم المتحركة والقائمة الموسعة](shape-after-animation.png)

قائمة **After animation** المنسدلة في تأثير PowerPoint تتطابق مع هذه الخصائص:
- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation :
  * PowerPoint **More Colors** يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color);
  * عنصر PowerPoint **Don't Dim** يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (النوع الافتراضي);
  * عنصر PowerPoint **Hide After Animation** يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * عنصر PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تحدد تنسيق لون After animation. تعمل هذه الخاصية بالتوازي مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيتم مسح لون After animation.

يعرض هذا الكود Java كيفية تغيير تأثير After animation:
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع الحركة اللاحقة إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يضبط لون التعتيم بعد الحركة
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:
- خاصية [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  * الكل مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) النوع)
  * حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) النوع)
  * حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) النوع)
- خاصية [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تحدد نسبة من مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي طريقة تغيير خصائص تحريك النص في التأثير:
1. استخدم [Apply](#apply-animation-to-shape) أو احصل على تأثير الرسوم المتحركة.
2. عيّن الخاصية [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضع الرسوم المتحركة *By Paragraphs*.
3. عيّن قيمًا جديدة للخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. احفظ ملف PPTX المعدل.
```java
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغيّر نوع النص المتحرك للتأثير إلى "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان الحفاظ على الرسوم المتحركة عند نشر العرض على الويب؟**

يجب استخدام [Export to HTML5](/slides/ar/java/export-to-html5/) وتفعيل [options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) المسؤولة عن الرسوم المتحركة لـ [shape](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و [transition](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML العادي لا يشغل الرسوم المتحركة للشرائح، بينما HTML5 يقوم بذلك.

**كيف يؤثر تغيير ترتيب z-order (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) ما يغطي ما. النتيجة المرئية تُحدد بتواصلهما. (هذه هي سلوكيات PowerPoint العامة؛ نموذجffects-and-shapes في Aspose.Slides يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

عمومًا، [animations are supported](/slides/ar/java/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات محددة بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها مع إصدار المكتبة.