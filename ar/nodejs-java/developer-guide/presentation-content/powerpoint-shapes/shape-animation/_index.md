---
title: رسوم متحركة للشكّل
type: docs
weight: 60
url: /ar/nodejs-java/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- إضافة تأثيرات
- الحصول على تأثيرات
- استخراج تأثيرات
- تطبيق الرسوم المتحركة
- PowerPoint
- عرض تقديمي
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "تطبيق الرسوم المتحركة في PowerPoint باستخدام JavaScript"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/nodejs-java/animated-charts/). إنها تضفي حياةً على العروض التقديمية أو مكوناتها.

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك

* التحكم في تدفق المعلومات
* إبراز النقاط المهمة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل قراءةً أو استيعابًا أو معالجةً
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها ضمن فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم `Aspose.Slides.Animation`،
* توفر Aspose.Slides أكثر من **150 تأثير حركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype). هذه التأثيرات هي نفسها (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على TextBox**

يسمح Aspose.Slides for Node.js via Java لك بتطبيق الرسوم المتحركة على النص داخل الشكل.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) من النوع `rectangle`.
4. أضف النص باستخدام [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. احصل على التسلسل الرئيسي للتأثيرات.
6. أضف تأثير حركة إلى [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).
7. استدعِ طريقة `TextAnimation.setBuildType` مع القيمة من تعداد `BuildType`.
8. احفظ العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود Javascript كيفية تطبيق تأثير `Fade` على AutoShape وتعيين حركة النص إلى القيمة *By 1st Level Paragraphs*:
```javascript
// يقوم بإنشاء فئة عرض تقديمي تمثل ملف عرض تقديمي.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // يضيف AutoShape جديد مع النص
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // يحصل على التسلسل الرئيسي للشرائح.
    var sequence = sld.getTimeline().getMainSequence();
    // يضيف تأثير التحويل Fade إلى الشكل
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // يحرك نص الشكل وفق الفقرات من المستوى الأول
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // يحفظ ملف PPTX إلى القرص
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 

إلى جانب تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيقها على [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph) واحد. راجع [**النص المتحرك**](/slides/ar/nodejs-java/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة عبر فهرسها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) في الشريحة.
4. احصل على التسلسل الرئيسي للتأثيرات.
5. أضف تأثير حركة إلى [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe).
6. احفظ العرض التقديمي إلى القرص كملف PPTX.

يعرض هذا الكود Javascript كيفية تطبيق تأثير `Fly` على إطار الصورة:
```javascript
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي.
var pres = new aspose.slides.Presentation();
try {
    // تحميل صورة لإضافتها إلى مجموعة صور العرض التقديمي
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف إطار صورة إلى الشريحة
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // يحصل على التسلسل الرئيسي للشرائح.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // يضيف تأثير التحليق من اليسار إلى إطار الصورة
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // يحفظ ملف PPTX إلى القرص
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تطبيق الرسوم المتحركة على Shape**

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. احصل على مرجع شريحة عبر فهرسها.
3. أضف [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) من النوع `rectangle`.
4. أضف [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) من النوع `Bevel` (عند النقر على هذا الكائن، تُشغَّل الرسوم المتحركة).
5. أنشئ تسلسلًا للتأثيرات على شكل الـ Bevel.
6. أنشئ `UserPath` مخصصًا.
7. أضف أوامر التحرك إلى `UserPath`.
8. احفظ العرض التقديمي إلى القرص كملف PPTX.

هذا الكود Javascript يوضح كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:
```javascript
// إنشاء فئة Presentation تمثل ملف PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // إنشاء تأثير PathFootball للشكل الموجود من الصفر.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // يضيف تأثير الرسوم المتحركة PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // إنشاء نوع من "زر".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // إنشاء تسلسل من التأثيرات لهذا الزر.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // إنشاء مسار مستخدم مخصص. سيتم تحريك كائننا فقط بعد النقر على الزر.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // يضيف أوامر الحركة لأن المسار المُنشأ فارغ.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

تُظهر الأمثلة التالية كيفية استخدام طريقة `getEffectsByShape` من فئة [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات حركة إلى الأشكال في عروض PowerPoint. يعرض الكود التالي كيفية الحصول على التأثيرات المطبقة على أول شكل في أول شريحة عادية في العرض `AnimExample_out.pptx`.
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // يحصل على تسلسل الرسوم المتحركة الرئيسي للشريحة.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // يحصل على الشكل الأول في الشريحة الأولى.
    var shape = firstSlide.getShapes().get_Item(0);

    // يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك الموروثة من العناصر النائبة**

إذا كان هناك شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الرئيسة، وتم إضافة تأثيرات حركة إلى هذه العناصر النائبة، فستُشغل جميع تأثيرات الشكل أثناء العرض، بما في ذلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` به شريحة واحدة تحتوي فقط على شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![Slide shape animation effect](slide-shape-animation.png)

ولتكن أيضًا تأثير **Split** مطبقًا على عنصر النائب في شريحة **layout**.

![Layout shape animation effect](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر النائب في شريحة **master**.

![Master shape animation effect](master-shape-animation.png)

يعرض الكود التالي كيفية استخدام طريقة `getBasePlaceholder` من فئة [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) للوصول إلى عناصر النائب والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والشريحة الرئيسة.
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// الحصول على تأثيرات الرسوم المتحركة للشكل على الشريحة العادية.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// الحصول على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة التخطيط.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// الحصول على تأثيرات الرسوم المتحركة للعنصر النائب على شريحة الرئيسة.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


الإخراج:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // طيران, أسفل
Type: 134, subtype: 45            // انقسام, داخل عمودي
Type: 126, subtype: 22            // أشرطة عشوائية, أفقي
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يسمح Aspose.Slides for Node.js via Java لك بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--):

- قائمة **Start** المنسدلة في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--).
- **Duration** في PowerPoint يتطابق مع خاصية [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--). مدة الحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الحركة لإكمال دورة واحدة.
- **Delay** في PowerPoint يتطابق مع خاصية [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

كيفية تغيير خصائص توقيت التأثير:

1. [طبق](#apply-animation-to-shape) أو احصل على تأثير الحركة.
2. عيّن قيمًا جديدة للخصائص في [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) التي تحتاجها.
3. احفظ ملف PPTX المعدَّل.

يعرض هذا الكود Javascript العملية:
```javascript
// ينشئ كائن فئة عرض تقديمي يمثل ملف عرض تقديمي.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // يحصل على التسلسل الرئيسي للشرائح.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // يحصل على التأثير الأول في التسلسل الرئيسي.
    var effect = sequence.get_Item(0);
    // يغيّر نوع TriggerType للتأثير ليبدأ عند النقر
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // يغيّر مدة (Duration) التأثير
    effect.getTiming().setDuration(3.0);
    // يغيّر TriggerDelayTime للتأثير
    effect.getTiming().setTriggerDelayTime(0.5);
    // يحفظ ملف PPTX إلى القرص
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides الخصائص التالية للعمل مع الأصوات في تأثيرات الرسوم المتحركة:

- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **إضافة صوت تأثير الرسوم المتحركة**

هذا الكود Javascript يوضح كيفية إضافة صوت لتأثير الحركة وإيقافه عندما يبدأ التأثير التالي:
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // يحصل على التسلسل الرئيسي للشريحة.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // يحصل على التأثير الأول في التسلسل الرئيسي
    var firstEffect = sequence.get_Item(0);
    // يفحص التأثير للتحقق من عدم وجود صوت
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // يضيف صوتًا للتأثير الأول
        firstEffect.setSound(effectSound);
    }
    // يحصل على التسلسل التفاعلي الأول للشريحة.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // يضبط علامة "إيقاف الصوت السابق" للتأثير
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // يكتب ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. احصل على مرجع شريحة عبر فهرسها.
3. احصل على التسلسل الرئيسي للتأثيرات.
4. استخرج الصوت المدمج في كل تأثير باستخدام [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-).

هذا الكود Javascript يوضح كيفية استخراج الصوت المدمج في تأثير الحركة:
```javascript
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // يحصل على التسلسل الرئيسي للشريحة.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // يستخرج صوت التأثير كمصفوفة بايت
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **بعد الحركة**

يسمح Aspose.Slides for Node.js via Java لك بتغيير خاصية **After animation** لتأثير الحركة.

هذه هي لوحة تأثير الحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تتطابق مع الخصائص التالية:

- طريقة [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) التي تصف نوع الـ After animation؛
  * **More Colors** في PowerPoint يتطابق مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color)؛
  * العنصر **Don't Dim** يتطابق مع النوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (النوع الافتراضي)؛
  * العنصر **Hide After Animation** يتطابق مع النوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation)؛
  * العنصر **Hide on Next Mouse Click** يتطابق مع النوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick)؛
- طريقة [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) التي تحدد تنسيق لون الـ After animation. تعمل هذه الطريقة مع النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color). إذا غيرت النوع إلى آخر، سيُمسح لون الـ After animation.

هذا الكود Javascript يوضح كيفية تغيير تأثير After animation:
```javascript
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // يحصل على التأثير الأول في التسلسل الرئيسي
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // يغيّر نوع After animation إلى اللون
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // يعين لون التعتيم بعد الحركة
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // يكتب ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تحريك النص**

توفر Aspose.Slides الخصائص التالية للعمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) الذي يصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - بالكامل مرة واحدة ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))
  - بالكلمة ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord))
  - بالحرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) يحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الإيجابية تمثل نسبة مدة التأثير. القيمة السلبية تمثل التأخير بالثواني.

كيفية تغيير خصائص تحريك النص في التأثير:

1. [طبق](#apply-animation-to-shape) أو احصل على تأثير الحركة.
2. استدعِ طريقة [setBuildType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) وضعها على القيمة [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject) لإلغاء وضع *By Paragraphs*.
3. عيّن قيمًا جديدة للخاصيتين [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) و[setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. احفظ ملف PPTX المعدَّل.

هذا الكود Javascript يوضح العملية:
```javascript
// ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // يحصل على التأثير الأول في التسلسل الرئيسي
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // يغيّر نوع حركة النص في التأثير إلى "ككائن واحد"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // يغيّر نوع تحريك النص في التأثير إلى "حسب الكلمة"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // يحدد التأخير بين الكلمات إلى 20% من مدة التأثير
    firstEffect.setDelayBetweenTextParts(20.0);
    // يكتب ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض على الويب؟**

استخدم [Export to HTML5](/slides/ar/nodejs-java/export-to-html5/) وفَعّل [الخيارات](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) المسؤولة عن الرسوم المتحركة للـ [shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) و[transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/). لا تقوم HTML العادية بتشغيل الرسوم المتحركة للشرائح، بينما تدعم HTML5 ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**

ترتيب الرسوم المتحركة والرسم مستقلان: تتحكم الخاصية في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) ما يغطي ما. النتيجة المرئية تُحدَّد بتواصلهما. (هذا هو سلوك PowerPoint العام؛ يتبع نموذج Aspose.Slides للرسوم والأشكال نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/nodejs-java/convert-powerpoint-to-video/)، لكن قد تُعالج الحالات النادرة أو التأثيرات المحددة بطريقة مختلفة. يوصى باختبار التأثيرات التي تستخدمها ومع إصدار المكتبة.