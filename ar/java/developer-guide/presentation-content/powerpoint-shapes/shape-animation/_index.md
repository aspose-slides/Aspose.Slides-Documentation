---
title: تطبيق حركات الأشكال في العروض التقديمية باستخدام Java
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/java/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على الحركة
- استخراج الحركة
- إضافة تأثير
- الحصول على التأثير
- استخراج التأثير
- صوت التأثير
- تطبيق الحركة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص حركات الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ Java. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](https://docs.aspose.com/slides/java/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك
* التحكم في تدفق المعلومات
* تسليط الضوء على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه قرائك أو مشاهديك إلى الأجزاء المهمة في العرض التقديمي

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و **مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة الاسم `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثير حركة** تحت تعداد [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). هذه التأثيرات هي أساسًا نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint. 

## **تطبيق الرسوم المتحركة على صندوق نص**

تسمح Aspose.Slides للغة Java لك بتطبيق الرسوم المتحركة على النص داخل شكل. 

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. الحصول على تسلسل رئيسي للتأثيرات.
6. إضافة تأثير حركة إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
7. تعيين الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود Java كيفية تطبيق تأثير `Fade` على AutoShape وتعيين حركة النص إلى القيمة *By 1st Level Paragraphs*:
```java
// ينشئ كائن فئة العرض الذي يمثل ملف عرض تقديمي.
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

    // يحرك نص الشكل وفقًا لفقارات المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 
بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) واحد. راجع [**النص المتحرك**](/slides/ar/java/animated-text/). 
{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) على الشريحة.
4. الحصول على تسلسل رئيسي للتأثيرات.
5. إضافة تأثير حركة إلى [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود Java كيفية تطبيق تأثير `Fly` على إطار صورة:
```java
// ينشئ كائن فئة العرض الذي يمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    // تحميل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
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

    // يضيف تأثير حركة طيران من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل الـ Bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض لك هذا الكود Java كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```java
// إنشاء فئة Presentation التي تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // يضيف تأثير الرسوم المتحركة PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // إنشاء زر من نوع ما.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // إنشاء تسلسل من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للحركة لأن المسار الذي تم إنشاؤه فارغ.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // يحفظ ملف PPTX على القرص
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

توضح الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من الواجهة [ISequence](https://reference.aspose.com/slides/java/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل. 

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يعرض لك الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للرسوم المتحركة في الشريحة.
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


**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك الموروثة من العناصر النائبة**

إذا كان للشكل في شريحة عادية عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فإن جميع تأثيرات الشكل ستُعرض أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة. 

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تتضمن فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل. 

![تأثير رسوم متحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **layout**. 

![تأثير رسوم متحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **master**. 

![تأثير رسوم متحركة لشكل القالب](master-shape-animation.png)

يعرض لك الكود التالي كيفية استخدام طريقة `getBasePlaceholder` من الواجهة [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شرائح التخطيط والقالب. 
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة القالب.
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


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تسمح Aspose.Slides للغة Java لك بتغيير خصائص التوقيت لتأثير الرسوم المتحركة. 

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint: 
![لوحة توقيت الرسوم المتحركة](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :
- قائمة **Start** المنسدلة في توقيت PowerPoint تتطابق مع الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--).
- توقيت PowerPoint **Duration** يتطابق مع الخاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--). مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.
- توقيت PowerPoint **Delay** يتطابق مع الخاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

هذه هي طريقة تغيير خصائص توقيت التأثير:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. قم بتعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) المطلوبة.
3. احفظ ملف PPTX المعدل.

يعرض لك هذا الكود Java العملية:
```java
// يقوم بإنشاء كائن فئة العرض الذي يمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence.get_Item(0);

    // يغيّر TriggerType للتأثير ليبدأ عند النقر
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

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع الأصوات في تأثيرات الرسوم المتحركة: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض لك هذا الكود Java كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق من أن التأثير ليس له صوت
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على أول تسلسل تفاعلي للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علامة "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الحصول على تسلسل رئيسي للتأثيرات. 
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمن في كل تأثير حركة. 

يعرض لك هذا الكود Java كيفية استخراج الصوت المضمن في تأثير الرسوم المتحركة:
```java
// ينشئ فئة العرض التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // يستخرج صوت التأثير في مصفوفة بايت
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **بعد الرسوم المتحركة**

تسمح Aspose.Slides للغة Java لك بتغيير خاصية After animation لتأثير الرسوم المتحركة. 

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:
![لوحة تأثير الرسوم المتحركة](shape-after-animation.png)

قائمة **After animation** المنسدلة في تأثير PowerPoint تتطابق مع هذه الخصائص:
- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation :
  * PowerPoint **More Colors** يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color).
  * عنصر PowerPoint **Don't Dim** يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع After animation الافتراضي);
  * عنصر PowerPoint **Hide After Animation** يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * عنصر PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تحدد صيغة لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيُمسح لون After animation.

يعرض لك هذا الكود Java كيفية تغيير تأثير After animation:
```java
// ينشئ كائن فئة عرض يمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع الحركة اللاحقة إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يحدد لون التعتيم بعد الحركة
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:
- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType.AllAtOnce] النوع)
  - كلمة بكلمة ([AnimateTextType.ByWord] النوع)
  - حرف بحرف ([AnimateTextType.ByLetter] النوع)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) يحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تحدد نسبة مئوية من مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي الطريقة لتغيير خصائص تحريك النص للتأثير:
1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين الخاصية [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضعية التحريك *By Paragraphs*.
3. تعيين قيم جديدة للخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. احفظ ملف PPTX المعدل.

يعرض لك هذا الكود Java العملية:
```java
// ينشئ كائن فئة عرض يمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع تحريك النص للتأثير إلى "ككائن واحد"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغيّر نوع تحريك النص للتأثير إلى "كلمة بكلمة"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يحدد التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض على الويب؟**

[Export to HTML5](/slides/ar/java/export-to-html5/) وتمكين [options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) المسؤولة عن الرسوم المتحركة للـ [shape](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[transition](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML العادي لا يشغل رسوم المتحركة للشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب z-order (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: التأثير يتحكم في توقيت ونوع الظهور/الاختفاء، بينما [z-order](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getZOrderPosition--) يحدد ما يغطي ما. النتيجة المرئية تُحدَّد بتواكُهما. (هذا هو السلوك العام في PowerPoint؛ نموذج Aspose.Slides للتأثيرات والأشكال يتبع نفس المنطق.)

**هل توجد قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/java/convert-powerpoint-to-video/)، لكن الحالات النادرة أو التأثيرات المحددة قد تُعرض بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها ومع إصدار المكتبة.