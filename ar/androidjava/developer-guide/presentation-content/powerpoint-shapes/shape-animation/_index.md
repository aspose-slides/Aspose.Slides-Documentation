---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية على Android
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
- إضافة رسم متحرك
- الحصول على رسم متحرك
- استخراج رسم متحرك
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسم متحرك
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides لنظام Android عبر Java. تميز!"
---
## **المقدمة**

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [الرسوم البيانية](https://docs.aspose.com/slides/ar/androidjava/animated-charts/). إنها تضيف الحياة إلى العروض التقديمية أو مكوناتها.

## **لماذا تستخدم الرسوم المتحركة في العروض التقديمية؟**

* التحكم في تدفق المعلومات
* إبراز النقاط المهمة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يقدم PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* يوفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة داخل مساحة الاسم `Aspose.Slides.Animation`،
* يوفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفسها (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع نص**

يسمح Aspose.Slides لنظام Android عبر Java بتطبيق الرسوم المتحركة على النص داخل الشكل.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape) .
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) .
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape) .
7. ضبط الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType` .
8. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود Java كيفية تطبيق تأثير `Fade` على AutoShape وتعيين الرسوم المتحركة للنص إلى القيمة *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير Fade للرسوم المتحركة إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل وفقًا للفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // حفظ ملف PPTX على القرص
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على فقرة واحدة [Paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph). راجع [**النص المتحرك**](/slides/ar/androidjava/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe) على الشريحة.
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/pictureframe) .
6. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود Java كيفية تطبيق تأثير `Fly` على إطار صورة:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تمثل ملف عرض تقديمي.
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

    // يضيف تأثير Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX على القرص
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق الرسوم المتحركة على شكل**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape) .
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على الشكل Bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود Java كيفية تطبيق تأثير `PathFootball` (path football) على شكل:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// ينشئ فئة عرض تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // يضيف تأثير PathFootBall للرسوم المتحركة
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "الزر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // ينشئ مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للتحريك بما أن المسار المُنشأ فارغ.
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

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل**

الأمثلة التالية توضح كيفية استخدام طريقة `getEffectsByShape` من الواجهة [ISequence](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للرسوم المتحركة للشريحة.
    // يحصل على الشكل الأول في الشريحة الأولى.
    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    IShape shape = firstSlide.getShapes().get_Item(0);
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**مثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسية، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل خلال العرض، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة فيها فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير حركة شكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب في التذييل في شريحة **layout**.

![تأثير حركة شكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب في التذييل في شريحة **master**.

![تأثير حركة شكل الماستر](master-shape-animation.png)

الكود التالي يوضح كيفية استخدام طريقة `getBasePlaceholder` من الواجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/) للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والماستر.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// احصل على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// احصل على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة الماستر.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

يسمح Aspose.Slides لنظام Android عبر Java بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint](shape-animation.png)

هذه هي المقابلات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IEffect#getTiming--) :

- يطابق القائمة المنسدلة **Start** في PowerPoint الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- يطابق **Duration** في PowerPoint الخاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITiming#getDuration--) . مدة تأثير الرسوم المتحركة (بالثواني) هي إجمالي الوقت الذي يستغرقه إكمال دورة واحدة.
- يطابق **Delay** في PowerPoint الخاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

هذه هي طريقة تغيير خصائص توقيت التأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط قيم جديدة للخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IEffect#getTiming--) التي تحتاجها.
3. حفظ ملف PPTX المعدل.

يظهر هذا الكود Java العملية:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // يحصل على التأثير الأول في التسلسل الرئيسي.
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

- [setSound(IAudio value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت لتأثير الرسوم المتحركة**

يظهر هذا الكود Java كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يفحص التأثير للبحث عن "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على التسلسل التفاعلي الأول للشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علامة "Stop previous sound" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على مرجع شريحة عبر الفهرس الخاص بها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الخاصية [setSound(IAudio value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المدمجة في كل تأثير رسوم متحركة.

يظهر هذا الكود Java كيفية استخراج الصوت المدمج في تأثير الرسوم المتحركة:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تمثل ملف عرض تقديمي.
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

يسمح Aspose.Slides لنظام Android عبر Java بتغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير ما بعد الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![لوحة تأثير ما بعد الرسوم المتحركة](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تتطابق مع هذه الخصائص:

- الخاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation :
  * يطابق PowerPoint **More Colors** النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * يطابق عنصر **Don't Dim** في PowerPoint النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (نوع الرسوم المتحركة الافتراضي بعد) ;
  * يطابق عنصر **Hide After Animation** النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * يطابق عنصر **Hide on Next Mouse Click** النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- الخاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تحدد تنسيق لون After animation. تعمل هذه الخاصية بالتزامن مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/afteranimationtype/#Color). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون After animation.

يظهر هذا الكود Java كيفية تغيير تأثير After animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ فئة عرض تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغير نوع after animation إلى Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يحدد لون after animation المخفف
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يكتب ملف PPTX على القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *Animate text* لتأثير الرسوم المتحركة:

- الخاصية [setAnimateTextType(int value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) النوع)
  - كلمة بكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/animatetexttype/#ByWord) النوع)
  - حرف بحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/animatetexttype/#ByLetter) النوع)
- الخاصية [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) التي تضبط تأخيرًا بين أجزاء النص المتحركة (كلمات أو حروف). القيمة الموجبة تحدد نسبة مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

هذه هي طريقة تغيير خصائص تحريك النص للتأثير:

1. [Apply](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط الخاصية [setBuildType(int value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/buildtype/#AsOneObject) لإلغاء وضع *By Paragraphs*.
3. ضبط قيم جديدة للخاصيتين [setAnimateTextType(int value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) و [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. حفظ ملف PPTX المعدل.

يظهر هذا الكود Java العملية:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التأثير الأول في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // يغيّر نوع تحريك النص للتأثير إلى "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // يضبط التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20f);

    // يكتب ملف PPTX على القرص
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

### كيف يمكنني التأكد من حفظ الرسوم المتحركة عند نشر العرض على الويب؟

[Export to HTML5](/slides/ar/androidjava/export-to-html5/) وتفعيل الـ[options](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/) المسؤولة عن [shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[transition](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) للرسوم المتحركة. HTML العادي لا يُشغل رسوم الشرائح، بينما HTML5 يفعل ذلك.

### كيف يؤثر تغيير ترتيب z-order (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟

ترتيب الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getZOrderPosition--) ما يغطي ماذا. النتيجة المرئية تُحدَّد بجمعهما. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

### هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/androidjava/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات معينة بشكل مختلف. يوصى باختبار التأثيرات التي تستخدمها مع إصدار المكتبة.