---
title: تحريك الأشكال
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: "تحريك PowerPoint، تأثير الحركة، تطبيق الحركة، عرض PowerPoint، Java، Aspose.Slides لـ Android عبر Java"
description: "تطبيق حركة PowerPoint في Java"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص والصور والأشكال أو [الرسوم البيانية](https://docs.aspose.com/slides/androidjava/animated-charts/). إنها تضيف الحياة للعروض التقديمية أو مكوناتها.

### **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* تسهيل قراءة المحتوى أو استيعابه أو معالجته
* جذب انتباه القراء أو المشاهدين إلى أجزاء مهمة في العرض التقديمي

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

### **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الأسماء `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثير رسوم متحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو المكافئة) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على صندوق النص**

تسمح Aspose.Slides لـ Android عبر Java بتطبيق الرسوم المتحركة على النص في شكل.

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف [شكل آلي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `مستطيل`.
4. أضف نصًا إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. احصل على تسلسل رئيسي للتأثيرات.
6. أضف تأثير الرسوم المتحركة إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
7. اضبط خاصية `TextAnimation.BuildType` على القيمة من تعداد `BuildType`.
8. اكتب العرض التقديمي على القرص كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية تطبيق تأثير `Fade` على الشكل الآلي وضبط الرسوم المتحركة للنص على قيمة *حسب فقرات المستوى الأول*:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف شكل آلي جديد مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("الفقرة الأولى \nالفقرة الثانية \nالفقرة الثالثة");

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير رسوم متحركة Fade إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل حسب فقرات المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [فقرة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) واحدة. راجع [**النص المتحرك**](/slides/androidjava/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على إطار الصورة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف أو احصل على [إطار صورة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) على الشريحة.
4. احصل على التسلسل الرئيسي للتأثيرات.
5. أضف تأثير الرسوم المتحركة إلى [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. اكتب العرض التقديمي على القرص كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية تطبيق تأثير `Fly` على إطار الصورة:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
Presentation pres = new Presentation();
try {
    // تحميل الصورة ليتم إضافتها في مجموعة صور العرض
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

    // يضيف تأثير الرسوم المتحركة Fly from Left إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX على القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق الرسوم المتحركة على الشكل**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف [شكل آلي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `مستطيل`.
4. أضف [شكل مائل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (عندما يتم النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. أنشئ تسلسل التأثيرات على الشكل المائل.
6. أنشئ `UserPath` مخصص.
7. أضف أوامر للتحرك إلى `UserPath`.
8. اكتب العرض التقديمي على القرص كملف PPTX.

هذا الكود بلغة Java يوضح لك كيفية تطبيق تأثير `PathFootball` (تأثير كرة القدم) على شكل:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // ينشئ تأثير PathFootball لشكل موجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("صندوق نص متحرك");

    // يضيف تأثير الرسوم المتحركة PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "الزر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسل التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للتحرك منذ أن المسار الذي تم إنشاؤه فارغ.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // يكتب ملف PPTX على القرص
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على الشكل**

يمكنك أن تقرر معرفة جميع تأثيرات الرسوم المتحركة المطبقة على شكل واحد.

هذا الكود بلغة Java يوضح لك كيفية الحصول على جميع التأثيرات المطبقة على شكل محدد:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول شكل في الشريحة.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // يحصل على جميع تأثيرات الرسوم المتحركة المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("الشكل " + shape.getName() + " لديه " + shapeEffects.length + " تأثيرات رسوم متحركة.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تسمح Aspose.Slides لـ Android عبر Java بتغيير خصائص توقيت تأثير الرسوم المتحركة.

هذا هو صندوق توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- قائمة السحب لتوقيت PowerPoint **البداية** تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- توقيت PowerPoint **المدة** يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) . مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي يستغرقه التأثير لإكمال دورة واحدة.
- توقيت PowerPoint **التأخير** يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

هذه هي كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين قيم جديدة لخصائص [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) التي تحتاجها.
3. حفظ ملف PPTX المعدل.

يوضح هذا الكود بلغة Java العملية:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence.get_Item(0);

    // يغير TriggerType للتأثير ليبدأ عند النقر
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // يغير مدة التأثير
    effect.getTiming().setDuration(3f);

    // يغير TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5f);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة:

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

يوضح لك هذا الكود بلغة Java كيفية إضافة صوت تأثير الرسوم المتحركة وإيقافه عند بدء التأثير التالي:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف الصوت إلى مجموعة الصوت في العرض
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق من التأثير لـ "لا صوت"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على أول تسلسل تفاعلي للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علم "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX على القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) .
2. احصل على مرجع شريحة من خلال فهرسها. 
3. احصل على التسلسل الرئيسي للتأثيرات. 
4. قم باستخراج [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمن إلى كل تأثير رسوم متحركة.

يوضح لك هذا الكود بلغة Java كيفية استخراج الصوت المضمن في تأثير رسوم متحركة:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
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

تسمح Aspose.Slides لـ Android عبر Java بتغيير خاصية بعد الرسوم المتحركة لتأثير الرسوم المتحركة.

هذا هو صندوق تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تطابق قائمة السحب لتأثير PowerPoint **بعد الرسوم المتحركة** هذه الخصائص:

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع بعد الرسوم المتحركة:
  * يتطابق PowerPoint **ألوان إضافية** مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * يتطابق عنصر القائمة PowerPoint **لا تخفف** مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع بعد الرسوم المتحركة الافتراضي) ;
  * يتطابق عنصر القائمة PowerPoint **اخفاء بعد الرسوم المتحركة** مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * يتطابق عنصر القائمة PowerPoint **اخفاء عند النقر التالي بالماوس** مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تحدد تنسيق اللون بعد الرسوم المتحركة. تعمل هذه الخاصية بالتعاون مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) . إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون بعد الرسوم المتحركة.

يوضح هذا الكود بلغة Java كيفية تغيير تأثير بعد الرسوم المتحركة:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغير نوع بعد الرسوم المتحركة إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يضبط لون التخفيف بعد الرسوم المتحركة
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يكتب ملف PPTX على القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *تحريك النص* لتأثير الرسوم المتحركة:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - جميعها دفعة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) النوع)
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) النوع)
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) النوع)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) يحدد التأخير بين أجزاء النص المتحرك (الكلمات أو الحروف). تشير القيمة الإيجابية إلى نسبة من مدة التأثير. تشير القيمة السلبية إلى التأخير بالثواني.

هذه هي كيفية تغيير خصائص تأثير تحريك النص:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. تعيين خاصية [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) على القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضع الرسوم المتحركة *حسب الفقرات*.
3. تعيين قيم جديدة لخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. حفظ ملف PPTX المعدل.

يوضح هذا الكود بلغة Java العملية:

```java
// يثبت فئة العرض التقديمي التي تمثل ملف تقديم.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغير نوع الرسوم المتحركة للتأثير إلى "ككل واحد"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغير نوع تحريك النص للتأثير إلى "حسب الكلمة"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يكتب ملف PPTX على القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```