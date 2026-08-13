---
title: تطبيق أنيمشنات الأشكال في العروض التقديمية باستخدام Java
linktitle: أنيمشن الشكل
type: docs
weight: 60
url: /ar/java/shape-animation/
keywords:
- شكل
- أنيمشن
- تأثير
- شكل متحرك
- نص متحرك
- إضافة أنيمشن
- الحصول على أنيمشن
- استخراج أنيمشن
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق أنيمشن
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص أنيمشنات الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides for Java. تميز!"
---
## **المقدمة**

الأنيمشنات هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [الرسوم البيانية](https://docs.aspose.com/slides/ar/java/animated-charts/). تمنح حياة للعرض التقديمي أو مكوّناته. 

## **لماذا نستخدم الأنيمشنات في العروض التقديمية؟**

باستخدام الأنيمشنات، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يقدم PowerPoint العديد من الخيارات والأدوات للأنيمشنات وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الأنيمشنات في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الأنيمشنات ضمن مساحة الاسم `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثير أنيمشن** ضمن تعداد [EffectType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effecttype). هذه التأثيرات هي في الأساس نفس التأثيرات (أو المعادلة لها) المستخدمة في PowerPoint.

## **تطبيق أنيمشن على مربع نص**

تسمح Aspose.Slides for Java بتطبيق أنيمشن على النص داخل الشكل. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape). 
4. إضافة نص إلى [IAutoShape.TextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير أنيمشن إلى [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape). 
7. تعيين الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود بلغة Java كيفية تطبيق تأثير `Fade` على AutoShape وتعيين أنيمشن النص إلى القيمة *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// ينشئ كائن عرض تقديمي يمثل ملف عرض تقديمي.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // يضيف AutoShape جديد مع نص
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // يضيف تأثير الأنيمشن Fade إلى الشكل
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // يحرك نص الشكل حسب الفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

إلى جانب تطبيق الأنيمشنات على النص، يمكنك أيضًا تطبيق الأنيمشنات على فقرة واحدة [Paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph). راجع [**النص المتحرك**](/slides/ar/java/animated-text/).

{{% /alert %}} 

## **تطبيق أنيمشن على PictureFrame**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe) في الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير أنيمشن إلى [PictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/pictureframe).
6. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود بلغة Java كيفية تطبيق تأثير `Fly` على إطار صورة:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
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

    // يضيف تأثير الأنيمشن Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تطبيق أنيمشن على شكل**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape). 
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape) (عند النقر على هذا الكائن يُشغل الأنيمشن).
5. إنشاء تسلسل من التأثيرات على شكل الـ bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود بلغة Java كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// إنشاء فئة عرض تقديمي تمثل ملف PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // يضيف تأثير الأنيمشن PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // ينشئ نوعًا من "زر".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // ينشئ تسلسلًا من التأثيرات لهذا الزر.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // ينشئ مسار مستخدم مخصص. سيتحرك كائننا فقط بعد النقر على الزر.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // يضيف أوامر للحركة لأن المسار المُنشأ فارغ.
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

## **الحصول على تأثيرات الأنيمشن المطبقة على شكل**

تُظهر الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من واجهة [ISequence](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isequence/) للحصول على جميع تأثيرات الأنيمشن المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الأنيمشن المطبقة على شكل في شريحة عادية**

في الوقت السابق، تعلمت كيفية إضافة تأثيرات الأنيمشن إلى الأشكال في عروض PowerPoint. يُظهر الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للأنيمشن للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على الشكل الأول في الشريحة الأولى.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // يحصل على تأثيرات الأنيمشن المطبقة على الشكل.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**المثال 2: الحصول على جميع تأثيرات الأنيمشن، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات أنيمشن إلى هذه العناصر النائبة، فستُشغل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` به شريحة واحدة تحتوي فقط على شكل تذييل بنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير أنيمشن شكل الشريحة](slide-shape-animation.png)

لنفترض أيضًا أن تأثير **Split** قد تم تطبيقه على العنصر النائب للتذييل في شريحة **التخطيط**.

![تأثير أنيمشن شكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **القالب**.

![تأثير أنيمشن شكل القالب](master-shape-animation.png)

يعرض الكود التالي كيفية استخدام طريقة `getBasePlaceholder` من واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) للوصول إلى العناصر النائبة للشكل والحصول على تأثيرات الأنيمشن المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والقالب.

```java
import com.aspose.slides.*;

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

الإخراج:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **تغيير خصائص توقيت تأثير الأنيمشن**

تسمح Aspose.Slides for Java بتغيير خصائص التوقيت لتأثير الأنيمشن.

هذه هي لوحة توقيت الأنيمشن في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي التطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IEffect#getTiming--) :

- القائمة المنسدلة **Start** في PowerPoint تطابق خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITiming#getTriggerType--). 
- **Duration** في PowerPoint تطابق خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITiming#getDuration--). مدة الأنيمشن (بالثواني) هي الزمن الكلي الذي يستغرقه الأنيمشن لإكمال دورة واحدة. 
- **Delay** في PowerPoint تطابق خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

هذه هي طريقة تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الأنيمشن.
2. تعيين قيم جديدة للخصائص في [Effect.Timing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IEffect#getTiming--) التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

يعرض هذا الكود بلغة Java العملية:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
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

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صوت تأثير الأنيمشن**

توفر Aspose.Slides الخصائص التالية التي تتيح لك العمل مع الأصوات في تأثيرات الأنيمشن: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **إضافة صوت لتأثير الأنيمشن**

يعرض هذا الكود بلغة Java كيفية إضافة صوت لتأثير الأنيمشن وإيقافه عندما يبدأ التأثير التالي:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة الأصوات في العرض التقديمي
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على التسلسل الرئيسي للشريحة.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = sequence.get_Item(0);

    // يتحقق ما إذا كان التأثير لا يحتوي على صوت
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }

    // يحصل على أول تسلسل تفاعلي في الشريحة.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // يضبط علم "Stop previous sound" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **استخراج صوت تأثير الأنيمشن**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج [setSound(IAudio value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) المدمج في كل تأثير أنيمشن. 

يعرض هذا الكود بلغة Java كيفية استخراج الصوت المدمج في تأثير الأنيمشن:

```java
import com.aspose.slides.*;

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

        // يستخرج صوت التأثير في مصفوفة بايت
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **بعد الأنيمشن**

تسمح Aspose.Slides for Java بتغيير خاصية After animation لتأثير الأنيمشن.

هذه هي لوحة تأثير الأنيمشن والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تطابق هذه الخصائص: 

- خاصية [setAfterAnimationType(int value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) التي تصف نوع After animation :
  * **More Colors** في PowerPoint يطابق النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#Color);
  * العنصر **Don't Dim** يطابق النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#DoNotDim) (النوع الافتراضي);
  * العنصر **Hide After Animation** يطابق النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * العنصر **Hide on Next Mouse Click** يطابق النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- خاصية [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) التي تعرف تنسيق لون After animation. تعمل هذه الخاصية مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/java/com.aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيُمسح لون After animation.

يعرض هذا الكود بلغة Java كيفية تغيير تأثير After animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع After animation إلى اللون
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // يضبط لون After animation المخفض
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحريك النص**

توفر Aspose.Slides الخصائص التالية التي تتيح لك العمل مع كتلة *Animate text* في تأثير الأنيمشن:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) الذي يصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/ar/java/com.aspose.slides/animatetexttype/#AllAtOnce))
  - حسب الكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/ar/java/com.aspose.slides/animatetexttype/#ByWord))
  - حسب الحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) يحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تمثل نسبة مدة التأثير. القيمة السالبة تمثل التأخير بالثواني.

هذه هي طريقة تغيير خصائص تحريك النص في التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الأنيمشن.
2. تعيين الخاصية [setBuildType(int value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextanimation/#setBuildType-int-) إلى القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/buildtype/#AsOneObject) لإلغاء وضع *By Paragraphs*.
3. تعيين قيم جديدة للخاصيتين [setAnimateTextType(int value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) و[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. حفظ ملف PPTX المعدل.

يعرض هذا الكود بلغة Java العملية:

```java
import com.aspose.slides.*;

// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // يحصل على أول تأثير في التسلسل الرئيسي
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // يغيّر نوع أنيمشن النص للتأثير إلى "As One Object"
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

## **الأسئلة المتداولة**

### كيف يمكنني التأكد من الحفاظ على الأنيمشنات عند نشر العرض على الويب؟

استخدم [Export to HTML5](/slides/ar/java/export-to-html5/) وفعل الخيارات في [Html5Options](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/) المسؤولة عن أنيمشنات [shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) و[transition](https://reference.aspose.com/slides/ar/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML العادي لا يُشغل أنيمشنات الشرائح، بينما HTML5 يفعل ذلك.

### كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الأنيمشن؟

ترتيب الأنيمشن والرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getZOrderPosition--) ما يغطي ما. النتيجة المرئية تُحدد بتواصلهما. (هذا هو السلوك العام في PowerPoint؛ نموذج Aspose.Slides للأنيمشنات والأشكال يتبع نفس المنطق.)

### هل هناك قيود عند تحويل الأنيمشنات إلى فيديو لبعض التأثيرات؟

بشكل عام، يتم دعم [الأنيمشنات](/slides/ar/java/convert-powerpoint-to-video/)، لكن قد تُعرض بعض الحالات النادرة أو التأثيرات المحددة بطريقة مختلفة. يُنصح بالاختبار مع التأثيرات التي تستخدمها ومع نسخة المكتبة.