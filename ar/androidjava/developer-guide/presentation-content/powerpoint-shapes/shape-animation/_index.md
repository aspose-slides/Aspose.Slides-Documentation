---
title: تطبيق رسومات متحركة للأشكال في العروض التقديمية على Android
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
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف تنشئ وتخصص رسومات متحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Android عبر Java. تميز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](https://docs.aspose.com/slides/androidjava/animated-charts/). هي تضيف حياة إلى العروض التقديمية أو مكوناتها.

## **لماذا تستخدم الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات  
* تسليط الضوء على النقاط المهمة  
* زيادة الاهتمام أو المشاركة بين الجمهور  
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة  
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض التقديمي  

يُقدِّم PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* تُوفِّر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة الاسم `Aspose.Slides.Animation`،  
* تُوفِّر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** تحت تعداد [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

يُتيح Aspose.Slides لنظام Android عبر Java تطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.  
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) من نوع `rectangle`.  
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. الحصول على تسلسل رئيسي للتأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
7. ضبط الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.  
8. حفظ العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود Java يُظهر كيفية تطبيق تأثير `Fade` على AutoShape وضبط الرسوم المتحركة للنص إلى القيمة *By 1st Level Paragraphs*:
```java
// ينشئ كلاس عرض تقديمي يمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // يحصل على التسلسل الرئيسي للشفرة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير الحركة Fade للشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل حسب الفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // حفظ ملف PPTX إلى القرص
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 
بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [فقرة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). راجع [**النص المتحرك**](/slides/ar/androidjava/animated-text/).
{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر الفهرس.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) على الشريحة.  
4. الحصول على التسلسل الرئيسي للتأثيرات.  
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).  
6. حفظ العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود Java يُظهر كيفية تطبيق تأثير `Fly` على إطار الصورة:
```java
// ينشئ كلاس عرض تقديمي يمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    // تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
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

    // يضيف تأثير الحركة Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ ملف PPTX إلى القرص
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر الفهرس.  
3. إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) من نوع `rectangle`.  
4. إضافة `Bevel` إلى [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).  
5. إنشاء تسلسل من التأثيرات على الشكل المائل.  
6. إنشاء `UserPath` مخصص.  
7. إضافة أوامر للتحرك إلى `UserPath`.  
8. حفظ العرض التقديمي إلى القرص كملف PPTX.  

هذا الكود Java يُظهر كيفية تطبيق تأثير `PathFootball` (path football) على شكل:
```java
// إنشاء كلاس Presentation يمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // إنشاء تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // يضيف تأثير الرسوم المتحركة PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // إنشاء نوع من "الزر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // إنشاء تسلسل من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للتحريك لأن المسار الذي تم إنشاؤه فارغ.
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


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

تُظهر الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الشكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint التقديمية. يُظهر الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للرسوم المتحركة للشفرة.
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


**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان هناك شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسية، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تتضمن فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير الرسوم المتحركة لشكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **التخطيط**.

![تأثير الرسوم المتحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **الرئيسية**.

![تأثير الرسوم المتحركة لشكل الشريحة الرئيسية](master-shape-animation.png)

الكود النموذجي التالي يُظهر كيفية استخدام طريقة `getBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحتَي التخطيط والرئيسية.
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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

يُتيح Aspose.Slides لنظام Android عبر Java تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:
![example1_image](shape-animation.png)

هذه هي التطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--):

- قائمة **Start** المنسدلة في توقيت PowerPoint تطابق الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- توقيت PowerPoint **Duration** يطابق الخاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.
- توقيت PowerPoint **Delay** يطابق الخاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

هذه هي طريقة تغيير خصائص توقيت التأثير:

1. إما [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. قم بتعيين قيم جديدة للخصائص [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) التي تحتاجها.  
3. احفظ ملف PPTX المعدل.  

هذا الكود Java يُظهر العملية:
```java
// ينشئ كائنًا من فئة Presentation يمثل ملف عرض تقديمي.
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

    // يغيّر TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5f);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **صوت تأثير الرسوم المتحركة**

Aspose.Slides يوفر هذه الخصائص للسماح لك بالتعامل مع الأصوات في تأثيرات الرسوم المتحركة:

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

هذا الكود Java يُظهر كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة الأصوات في العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق من عدم وجود صوت في التأثير
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على أول تسلسل تفاعلي للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علم "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر الفهرس.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المضمن في كل تأثير رسوم متحركة.  

هذا الكود Java يُظهر كيفية استخراج الصوت المضمّن في تأثير الرسوم المتحركة:
```java
// ينشئ فئة عرض تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشرحة.
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

يُتيح Aspose.Slides لنظام Android عبر Java تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:
![example1_image](shape-after-animation.png)

قائمة PowerPoint **After animation** المنسدلة تطابق هذه الخصائص:

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation :
  * PowerPoint **More Colors** يطابق النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** يطابق النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع After animation الافتراضي);
  * PowerPoint **Hide After Animation** يطابق النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** يطابق النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تعرف تنسيق لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون After animation.

هذا الكود Java يُظهر كيفية تغيير تأثير After animation:
```java
// ينشئ فئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع AfterAnimation إلى Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يضبط لون AfterAnimation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تحريك النص**

Aspose.Slides يوفر هذه الخصائص للسماح لك بالتعامل مع جزء *Animate text* في تأثير الرسوم المتحركة:

- خاصية [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) النوع)
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) النوع)
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) النوع)
- خاصية [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) التي تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تمثل نسبة مدة التأثير. القيمة السالبة تمثل التأخير بالثواني.

هذه هي طريقة تغيير خصائص تحريك النص في التأثير:

1. إما [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.  
2. ضبط الخاصية [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) لإيقاف وضع *By Paragraphs*.  
3. ضبط قيم جديدة للخصائص [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) و[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. احفظ ملف PPTX المعدل.  

هذا الكود Java يُظهر العملية:
```java
// ينشئ فئة عرض تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع تحريك النص في التأثير إلى "ككائن واحد"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغيّر نوع تحريك النص في التأثير إلى "حسب الكلمة"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض على الويب؟**

[Export to HTML5](/slides/ar/androidjava/export-to-html5/) وتفعيل الـ[options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) المسؤولة عن رسومات [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML العادي لا يشغّل رسوم الشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب Z (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**

ترتيب الرسوم المتحركة ورسمها مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد ترتيب Z ما يغطي ما. النتيجة المرئية تُحدد بتواصيهم. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم‑الأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، تُدعم الرسوم المتحركة [/slides/androidjava/convert-powerpoint-to-video/], لكن قد تُعرض بعض الحالات النادرة أو التأثيرات المحددة بشكل مختلف. يفضَّل اختبار التأثيرات المستخدمة وإصدار المكتبة.