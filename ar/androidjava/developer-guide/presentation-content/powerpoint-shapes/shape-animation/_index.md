---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية على Android
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/androidjava/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسومات متحركة
- الحصول على الرسوم المتحركة
- استخراج الرسوم المتحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق الرسوم المتحركة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسوم متحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java. كن مميزًا!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](https://docs.aspose.com/slides/androidjava/animated-charts/). إنها تضيف الحياة إلى العروض التقديمية أو مكوّناتها.

## **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات  
* تسليط الضوء على النقاط المهمة  
* زيادة الاهتمام أو المشاركة لدى الجمهور  
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة  
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض التقديمي  

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الأسماء `Aspose.Slides.Animation`،  
* توفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). وهذه التأثيرات هي في الأساس نفس التأثيرات (أو المكافئة) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على صندوق نص**

تسمح Aspose.Slides لنظام Android عبر Java بتطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) من نوع `rectangle`.  
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. الحصول على التسلسل الرئيسي للتأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
7. تعيين خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.  
8. حفظ العرض التقديمي إلى القرص كملف PPTX.  

يعرض هذا الكود Java كيفية تطبيق تأثير `Fade` على AutoShape وتعيين رسومات النص إلى *حسب الفقرات من المستوى الأول*:
```java
// ينشئ كائنًا من فئة العرض التقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديدًا مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // يحصل على التسلسل الرئيسي للشرائح.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل وفقًا للفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // حفظ ملف PPTX إلى القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيقها على [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) منفرد. راجع [**النص المتحرك**](/slides/ar/androidjava/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) على الشريحة.  
4. الحصول على التسلسل الرئيسي للتأثيرات.  
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).  
6. حفظ العرض التقديمي إلى القرص كملف PPTX.  

```java
// يخلق مثيلاً من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    // تحميل صورة لتضاف إلى مجموعة صور العرض التقديمي
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف إطار صورة إلى الشريحة
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // يحصل على التسلسل الرئيسي للشرائح.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يضيف تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ ملف PPTX إلى القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) من نوع `rectangle`.  
4. إضافة `Bevel` إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).  
5. إنشاء تسلسل من التأثيرات على شكل الـ Bevel.  
6. إنشاء مسار مخصص `UserPath`.  
7. إضافة أوامر للتحرك إلى `UserPath`.  
8. حفظ العرض التقديمي إلى القرص كملف PPTX.  

```java
// إنشاء كائن من فئة Presentation يمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء تأثير PathFootball للشكل الحالي من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // إضافة تأثير PathFootBall للرسوم المتحركة
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // إنشاء نوع ما من "زر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // إنشاء تسلسل من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // إضافة أوامر للحركة لأن المسار الذي تم إنشاؤه فارغ.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // كتابة ملف PPTX إلى القرص
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

تُظهر الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات رسوم متحركة إلى الأشكال في عروض PowerPoint. يوضح كود العينة التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض التقديمي `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على تسلسل الرسوم المتحركة الرئيسي للشرحة.
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

إذا كان هناك شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة القالب و/أو شريحة الرئيس، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض تقديمي PowerPoint باسم `sample.pptx` يحتوي على شريحة واحدة بها شكل تذييل فقط يحتوي على النص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير الرسوم المتحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على عنصر النائب في تذييل شريحة **التخطيط**.

![تأثير الرسوم المتحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر النائب في تذييل شريحة **الرئيس**.

![تأثير الرسوم المتحركة لشكل الرئيس](master-shape-animation.png)

يظهر كود العينة التالي كيفية استخدام طريقة `getBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للوصول إلى العناصر النائبة والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة على شريحة التخطيط والشريحة الرئيس.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// الحصول على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// الحصول على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// الحصول على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة الرئيس.
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


الناتج:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تسمح Aspose.Slides لنظام Android عبر Java بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

![لوحة توقيت الرسوم المتحركة](shape-animation.png)

هذه هي المقابلات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- قائمة **Start** المنسدلة في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- **Duration** في PowerPoint يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). مدة الرسوم المتحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.  
- **Delay** في PowerPoint يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

وهكذا يتم تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. تعيين القيم الجديدة للخصائص في [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) التي تحتاجها.  
3. حفظ ملف PPTX المعدل.  

```java
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي.
    IEffect effect = sequence.get_Item(0);

    // يغيّر نوع TriggerType للتأثير ليبدأ عند النقر
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // يغيّر مدة التأثير
    effect.getTiming().setDuration(3f);

    // يغيّر وقت تأخير TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5f);

    // يحفظ ملف PPTX إلى القرص
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

يظهر هذا الكود Java كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشرحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق من عدم وجود صوت في التأثير
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على التسلسل التفاعلي الأول للشرحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علم "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **استخراج صوت لتأثير الرسوم المتحركة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمن لكل تأثير رسوم متحركة.  

```java
// ينشئ كائنًا من فئة العرض التقديمي تمثل ملف عرض تقديمي.
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

تسمح Aspose.Slides لنظام Android عبر Java بتغيير خاصية After animation لتأثير الرسوم المتحركة.

![لوحة تأثير الرسوم المتحركة](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تتطابق مع هذه الخصائص:

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation:
  * **More Colors** في PowerPoint يتطابق مع نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color)؛
  * **Don't Dim** يتطابق مع نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (النوع الافتراضي)؛
  * **Hide After Animation** يتطابق مع نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation)؛
  * **Hide on Next Mouse Click** يتطابق مع نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick).  
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تُعرِّف تنسيق لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيتم مسح لون After animation.

```java
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع الرسوم المتحركة بعد العرض إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يضبط لون التعتيم بعد الرسوم المتحركة
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:

- خاصية [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - كلَها مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce))  
  - حسب الكلمات ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord))  
  - حسب الأحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter))  
- خاصية [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) التي تحدد تأخيرًا بين أجزاء النص المتحرك (كلمات أو أحرف). القيمة الموجبة تُحدِّد النسبة المئوية لمدة التأثير. القيمة السالبة تُحدِّد التأخير بالثواني.

هكذا يمكنك تغيير خصائص تحريك النص في التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. تعيين خاصية [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) إلى قيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضع *By Paragraphs*.  
3. تعيين القيم الجديدة للخصائص [setAnimateTextType(int value)] و[setDelayBetweenTextParts(float value)].  
4. حفظ ملف PPTX المعدل.  

```java
// ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغيّر نوع تحريك النص للتأثير إلى "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**

استخدم [تصدير إلى HTML5](/slides/ar/androidjava/export-to-html5/) وقم بتمكين [الخيارات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) المسؤولة عن الرسوم المتحركة للأشكال و الانتقالات. لا تقوم HTML العادية بتشغيل الرسوم المتحركة للشرائح، بينما تدعم HTML5 ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد ترتيب الطبقات ما يغطي ما. النتيجة المرئية تُحدد بتكوينهما معًا. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للتأثيرات والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، يتم دعم [الرسوم المتحركة](/slides/ar/androidjava/convert-powerpoint-to-video/)، لكن قد يتم عرض بعض الحالات النادرة أو التأثيرات المحددة بطريقة مختلفة. يُنصح باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.