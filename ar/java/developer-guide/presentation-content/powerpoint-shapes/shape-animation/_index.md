---
title: تحريك الشكل
type: docs
weight: 60
url: /java/shape-animation/
keywords: "تحريك باوربوينت، تأثير التحريك، تطبيق التحريك، عرض باوربوينت، جافا، Aspose.Slides لجافا"
description: "تطبيق تحريك باوربوينت في جافا"
---

التحريكات هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](https://docs.aspose.com/slides/java/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها.

### **لماذا نستخدم التحريكات في العروض التقديمية؟**

باستخدام التحريكات، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل في القراءة أو الاستيعاب أو المعالجة
* جذب انتباه قرائك أو مشاهدينك إلى الأجزاء المهمة في العرض التقديمي

يوفر باوربوينت العديد من الخيارات والأدوات للتحريكات وتأثيرات التحريك عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

### **التحريكات في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع التحريكات تحت مساحة الأسماء `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثير تحريك** تحت تعداد [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). هذه التأثيرات هي أساساً نفس التأثيرات المستخدمة في باوربوينت.

## **تطبيق التحريك على TextBox**

تسمح لك Aspose.Slides لجافا بتطبيق التحريك على النص في شكل.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) "مستطيل". 
4. أضف نصًا إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. احصل على تسلسل رئيسي من التأثيرات.
6. أضف تأثير تحريك إلى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape). 
7. قم بتعيين خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. قم بكتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الرمز جافا كيفية تطبيق تأثير `Fade` على AutoShape وضبط تحريك النص إلى قيمة *By 1st Level Paragraphs*:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديدة مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("الفقرة الأولى \nالفقرة الثانية \n الفقرة الثالثة");

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير Fade إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل حسب فقرات المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // يحفظ ملف PPTX إلى القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

بجانب تطبيق التحريكات على النص، يمكنك أيضًا تطبيق التحريكات على [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) واحدة. انظر [**نص متحرك**](/slides/java/animated-text/).

{{% /alert %}} 

## **تطبيق التحريك على PictureFrame**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) على الشريحة. 
4. احصل على التسلسل الرئيسي من التأثيرات.
5. أضف تأثير تحريك إلى [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. قم بكتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الرمز جافا كيفية تطبيق تأثير `Fly` على إطار الصورة:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    // يقوم بتحميل الصورة المراد إضافتها في مجموعة الصور
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

    // يضيف تأثير Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX إلى القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق التحريك على الشكل**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) "مستطيل". 
4. أضف [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) "Bevel" (عند النقر على هذا الكائن، يتم تشغيل التحريك).
5. أنشئ تسلسل التأثيرات على شكل bevel.
6. أنشئ `UserPath` مخصص.
7. أضف أوامر للتحرك إلى `UserPath`.
8. اكتب العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الرمز جافا كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // ينشئ تأثير PathFootball لشكل موجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("نص متحرك");

    // يضيف تأثير التحريك PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "الزر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسل التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

    // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // يضيف أوامر للتحرك نظرًا لأن المسار الذي تم إنشاؤه فارغ.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على تأثيرات التحريك المطبقة على الشكل**

يمكنك أن تقرر معرفة جميع تأثيرات التحريك المطبقة على شكل واحد.

يعرض هذا الرمز جافا كيفية الحصول على جميع التأثيرات المطبقة على شكل محدد:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول شكل على الشريحة.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // يحصل على جميع تأثيرات التحريك المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("يحتوي الشكل " + shape.getName() + " على " + shapeEffects.length + " تأثيرات تحريك.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير خصائص توقيت تأثير التحريك**

تسمح لك Aspose.Slides لجافا بتغيير خصائص توقيت تأثير التحريك.

هذه هي لوحة توقيت التحريك في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي العلاقات بين توقيت باوربوينت وخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :

- قائمة السقوط الخاصة بتوقيت باوربوينت **بدء** تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) . 
- **المدة** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) . مدة التحريك (بالثواني) هي الوقت الإجمالي المستغرق لإكمال التحريك دورة واحدة. 
- **التأخير** في توقيت باوربوينت تتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) . 

هذه هي كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التحريك.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) التي تحتاجها. 
3. احفظ ملف PPTX المعدل.

يعرض هذا الكود الجافا العملية:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence.get_Item(0);

    // يغير نوع تأثير TriggerType ليبدأ عند النقر
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // يغير مدة التأثير
    effect.getTiming().setDuration(3f);

    // يغير TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5f);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صوت تأثير التحريك**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات التحريك: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **إضافة صوت تأثير التحريك**

يعرض هذا الرمز الجافا كيفية إضافة صوت تأثير التحريك وإيقافه عند بدء التأثير التالي:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوت إلى مجموعة الصوت في العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق من التأثير لعدم وجود صوت
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على أول تسلسل تفاعلي للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يحدد علامة تأثير "إيقاف الصوت السابق"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صوت تأثير التحريك**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. احصل على التسلسل الرئيسي من التأثيرات.
4. استخرج [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المدمج في كل تأثير تحريك. 

يعرض هذا الرمز الجافا كيفية استخراج الصوت المدمج في تأثير التحريك:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
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

## **بعد التحريك**

تسمح لك Aspose.Slides لجافا بتغيير خاصية بعد التحريك لتأثير التحريك.

هذه هي لوحة تأثير التحريك والقائمة الممتدة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تتطابق قائمة **بعد التحريك** في باوربوينت مع هذه الخصائص: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) الخاصية التي تصف نوع بعد التحريك :
  * تتطابق خاصية **ألوان إضافية** في باوربوينت مع نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) ؛
  * تتطابق خاصية **لا تخفف** مع عنصر قائمة [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (افتراضي بعد نوع التحريك)؛
  * تتطابق خاصية **إخفاء بعد التحريك** مع عنصر [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ؛
  * تتطابق خاصية **إخفاء عند النقر بالماوس التالي** مع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) نوع؛
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) الخاصية التي تحدد تنسيق لون بعد التحريك. تعمل هذه الخاصية بالتعاون مع نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) . إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون بعد التحريك.

يعرض هذا الرمز الجافا كيفية تغيير تأثير بعد التحريك:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغير نوع بعد التحريك إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يحدد لون مقلل بعد التحريك
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *تحريك النص* لتأثير التحريك:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) النوع)
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) النوع)
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) النوع)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) تحدد التأخير بين أجزاء النص المتحركة (الكلمات أو الأحرف). تحدد القيمة الإيجابية نسبة تأثير المدة. تحدد القيمة السلبية التأخير بالثواني.

هذه هي كيفية تغيير خصائص تأثير تحريك النص:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التحريك.
2. تعيين خاصية [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) إلى قيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضع تحريك *حسب الفقرات*.
3. تعيين قيم جديدة لخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. احفظ ملف PPTX المعدل.

يعرض هذا الرمز الجافا العملية:

```java
// يقوم بإنشاء فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغير نوع تأثير النص ليكون "ككل كائن"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغير نوع تأثير تحريك النص إلى "حسب الكلمة"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يحدد التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```