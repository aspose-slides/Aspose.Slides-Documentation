---
title: رسوم متحركة للشكل
type: docs
weight: 60
url: /ar/python-net/shape-animation/
keywords: "رسوم متحركة في PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إنشاء رسوم متحركة في PowerPoint باستخدام بايثون"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](/slides/ar/python-net/animated-charts/). إنها تضفي الحياة على العروض التقديمية أو مكوناتها.

### **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل قراءة أو استيعاب أو معالجة
* جذب انتباه قرائك أو مشاهديك إلى أجزاء مهمة في عرض تقديمي

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيرات الرسوم المتحركة عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

### **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)،
* توفر Aspose.Slides أكثر من **150 تأثير رسوم متحركة** تحت تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي في الأساس نفس (أو مكافئة) التأثيرات المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع النص**

تسمح لك Aspose.Slides لـ بايثون عبر .NET بتطبيق الرسوم المتحركة على النص في شكل.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف شكل `مستطيل` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
4. أضف نصاً إلى `IAutoShape.TextFrame`.
5. احصل على تسلسل رئيسي من التأثيرات.
6. أضف تأثير الرسوم المتحركة إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
7. قم بتعيين خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. اكتب العرض التقديمي على القرص كملف PPTX.

يظهر هذا الكود بلغة بايثون كيفية تطبيق تأثير `Fade` على AutoShape وتعيين الرسوم المتحركة للنص إلى قيمة *بواسطة الفقرات من المستوى الأول*:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # يضيف AutoShape جديدة مع نص
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "الفقرة الأولى \nالفقرة الثانية \n الفقرة الثالثة"

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = sld.timeline.main_sequence

    # يضيف تأثير الرسوم المتحركة Fade للشكل
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # يقوم بتحريك نص الشكل بواسطة فقرات المستوى الأول
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # يحفظ ملف PPTX على القرص
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}}

بخلاف تطبيق الرسوم المتحركة على النص، يمكنك أيضاً تطبيق الرسوم المتحركة على [فقرة](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) واحدة. انظر [**النص المتحرك**](/slides/ar/python-net/animated-text/).

{{% /alert %}}

## **تطبيق الرسوم المتحركة على PictureFrame**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف أو احصل على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) في الشريحة.
4. احصل على التسلسل الرئيسي للتأثيرات.
5. أضف تأثير الرسوم المتحركة إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) .
6. اكتب العرض التقديمي على القرص كملف PPTX.

يظهر هذا الكود بلغة بايثون كيفية تطبيق تأثير `Fly` على إطار الصورة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    # تحميل الصورة لإضافتها في مجموعة صور العرض التقديمي
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # يضيف إطار صورة إلى الشريحة
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = pres.slides[0].timeline.main_sequence

    # يضيف تأثير الرسوم المتحركة Fly من اليسار إلى إطار الصورة
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # يحفظ ملف PPTX على القرص
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق الرسوم المتحركة على الشكل**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. أضف شكل `مستطيل` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
4. أضف [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) `Bevel` (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. أنشئ تسلسل تأثيرات على شكل البيفل.
6. أنشئ `UserPath` مخصص.
7. أضف أوامر للحركة إلى `UserPath`.
8. اكتب العرض التقديمي على القرص كملف PPTX.

يظهر هذا الكود بلغة بايثون كيفية تطبيق تأثير `PathFootball` (ممر كرة القدم) على شكل:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ فئة العرض التي تمثل ملف PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # ينشئ تأثير PathFootball لشكل موجود من الصفر.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("مربع نص متحرك")

    # يضيف تأثير الرسوم المتحركة PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # ينشئ نوعاً من "زر".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # ينشئ تسلسل تأثيرات للزر.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # ينشئ مسار مستخدم مخصص. سيتم نقل كائننا فقط بعد النقر على الزر.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # يضيف أوامر للحركة منذ أن المسار الذي تم إنشاؤه فارغ.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # يكتب ملف PPTX على القرص
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على الشكل**

يمكنك أن تقرر معرفة جميع تأثيرات الرسوم المتحركة المطبقة على شكل واحد.

يظهر هذا الكود بلغة بايثون كيفية الحصول على جميع التأثيرات المطبقة على شكل محدد:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = firstSlide.timeline.main_sequence

    # يحصل على أول شكل على الشريحة.
    shape = firstSlide.shapes[0]

    # يحصل على جميع تأثيرات الرسوم المتحركة المطبقة على الشكل.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("الشكل " + shape.name + " لديه " + str(len(shapeEffects)) + " تأثيرات رسوم متحركة.")
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تسمح لك Aspose.Slides لـ بايثون عبر .NET بتغيير خصائص توقيت تأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص `Effect.Timing`:

- قائمة السحب الخاصة بتوقيت PowerPoint **Start** تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) .
- تتوافق **مدة** توقيت PowerPoint مع خاصية `Effect.Timing.Duration`. تستغرق مدة الرسوم المتحركة (بالثواني) الوقت الإجمالي الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة.
- تتوافق **تأخير** توقيت PowerPoint مع خاصية `Effect.Timing.TriggerDelayTime`.

هذه هي كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو احصل على تأثير الرسوم المتحركة.
2. قم بتعيين قيم جديدة لخصائص `Effect.Timing` التي تحتاجها.
3. احفظ ملف PPTX المعدل.

هذا الكود بلغة بايثون يوضح العملية:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = pres.slides[0].timeline.main_sequence

    # يحصل على أول تأثير من التسلسل الرئيسي.
    effect = sequence[0]

    # يغير نوع التأثير TriggerType ليبدأ عند النقر
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # يغير مدة التأثير
    effect.timing.duration = 3

    # يغير TriggerDelayTime للتأثير
    effect.timing.trigger_delay_time = 0.5

    # يحفظ ملف PPTX على القرص
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **صوت تأثير الرسوم المتحركة**

تقدم Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الرسوم المتحركة:

- `sound`
- `stop_previous_sound`

### **إضافة صوت تأثير الرسوم المتحركة**

يظهر هذا الكود بلغة بايثون كيفية إضافة صوت تأثير الرسوم المتحركة وإيقافه عند بدء التأثير التالي:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # يضيف الصوت إلى مجموعة الصوتيات في العرض التقديمي
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = first_slide.timeline.main_sequence

    # يحصل على أول تأثير من التسلسل الرئيسي
    first_effect = sequence[0]

    # يتحقق من التأثير لـ "لا صوت"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # يضيف الصوت للتأثير الأول
        first_effect.sound = effect_sound

    # يحصل على أول تسلسل تفاعلي في الشريحة.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # يحدد علامة "إيقاف الصوت السابق" للتأثير
    interactive_sequence[0].stop_previous_sound = True

    # يكتب ملف PPTX على القرص
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. احصل على التسلسل الرئيسي للتأثيرات.
4. استخراج `sound` المدمج إلى كل تأثير رسوم متحركة.

يظهر هذا الكود بلغة بايثون كيفية استخراج الصوت المدمج في تأثير الرسوم المتحركة:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # استخراج الصوت من التأثير في مصفوفة بايت
        audio = effect.sound.binary_data
```

## **بعد الرسوم المتحركة**

تسمح لك Aspose.Slides لـ .NET بتغيير خاصية بعد الرسوم المتحركة لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

تتطابق قائمة PowerPoint **بعد الرسوم المتحركة** مع الخصائص التالية:

- خاصية `after_animation_type` التي تصف نوع الرسوم المتحركة بعد:
  * تتطابق PowerPoint **الألوان الإضافية** مع النوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * تطابق عنصر القائمة **عدم التعتيم** في PowerPoint مع النوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (نوع الرسوم المتحركة بعد الافتراضي) ;
  * تتطابق عنصر القائمة **إخفاء بعد الرسوم المتحركة** مع النوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * تتطابق عنصر القائمة **إخفاء عند النقر بالفأرة التالية** مع النوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
- خاصية `after_animation_color` التي تحدد تنسيق لون الرسوم المتحركة بعد. تعمل هذه الخاصية بالتعاون مع النوع  [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) . إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون الرسوم المتحركة بعد.

يظهر هذا الكود بلغة بايثون كيفية تغيير تأثير الرسوم المتحركة بعد:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # يحصل على أول تأثير من التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # يغير نوع الرسوم المتحركة بعد إلى لون
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # يحدد لون التعتيم بعد الرسوم المتحركة
    first_effect.after_animation_color.color = Color.alice_blue

    # يكتب ملف PPTX على القرص
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **تحريك النص**

تقدم Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *تحريك النص* لتأثير الرسوم المتحركة:

- `animate_text_type` الذي يصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - جميعًا في آن واحد ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - بواسطة الكلمات ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - بواسطة الحروف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
- `delay_between_text_parts` تحدد تأخيرًا بين أجزاء النص المتحرك (كلمات أو حروف). تحدد القيمة الإيجابية النسبة المئوية لمدة التأثير. تحدد القيمة السلبية التأخير بالثواني.

هذه هي كيفية تغيير خصائص تأثير تحريك النص:

1. [تطبيق](#apply-animation-to-shape) أو احصل على تأثير الرسوم المتحركة.
2. قم بتعيين خاصية `build_type` إلى قيمة [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) لإيقاف وضع الرسوم المتحركة *بواسطة الفقرات*.
3. قم بتعيين قيم جديدة لخصائص `animate_text_type` و`delay_between_text_parts`.
4. احفظ ملف PPTX المعدل.

هذا الكود بلغة بايثون يوضح العملية:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # يحصل على أول تأثير من التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # يغير نوع تأثير الرسوم المتحركة للنص إلى "كشكل واحد"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # يغير نوع تأثير تحريك النص إلى "بواسطة الكلمات"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # يحدد التأخير بين الكلمات إلى 20% من مدة التأثير
    first_effect.delay_between_text_parts = 20

    # يكتب ملف PPTX على القرص
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```