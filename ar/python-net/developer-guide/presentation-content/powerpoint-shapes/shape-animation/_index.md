---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام Python
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسوم متحركة للأشكال في عروض PowerPoint وعروض OpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. تميز!"
---

الرسوم المتحركة هي تأثيرات مرئية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/python-net/animated-charts/). إنها تضيف الحياة إلى العروض التقديمية أو مكوّناتها. 

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* تأكيد النقاط المهمة
* زيادة الاهتمام أو المشاركة لدى الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض

يوفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) ،
* توفر Aspose.Slides أكثر من **150 تأثيرًا للرسوم المتحركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع النص**

تتيح Aspose.Slides للـ Python عبر .NET تطبيق الرسوم المتحركة على النص داخل الشكل. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) . 
4. إضافة نص إلى `IAutoShape.TextFrame` .
5. الحصول على تسلسل رئيسي من التأثيرات.
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) . 
7. ضبط خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType` .
8. كتابة العرض التقديمي إلى القرص كملف PPTX .

يعرض هذا الكود Python كيفية تطبيق تأثير `Fade` على AutoShape وتعيين تحريك النص إلى قيمة *By 1st Level Paragraphs* :
```python
import aspose.slides as slides

# ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # يضيف AutoShape جديدًا مع نص
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = sld.timeline.main_sequence

    # يضيف تأثير الرسوم المتحركة Fade إلى الشكل
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # يُحرك نص الشكل حسب الفقرات من المستوى الأول
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # يحفظ ملف PPTX على القرص
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```


{{%  alert color="primary"  %}} 

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيقها على [Paragraph] واحد. راجع [**Animated Text**](/slides/ar/python-net/animated-text/).

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) على الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) .
6. كتابة العرض التقديمي إلى القرص كملف PPTX .

يعرض هذا الكود Python كيفية تطبيق تأثير `Fly` على إطار صورة :
```python
import aspose.slides as slides
import aspose.pydrawing as draw


# ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    # تحميل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # يضيف إطار صورة إلى الشريحة
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = pres.slides[0].timeline.main_sequence

    # يضيف تأثير التحليق من اليسار إلى إطار الصورة
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # حفظ ملف PPTX على القرص
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تطبيق الرسوم المتحركة على الشكل**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) . 
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (عند النقر على هذا الكائن، يتم تشغيل الرسوم المتحركة).
5. إنشاء تسلسل من التأثيرات على شكل الـ Bevel.
6. إنشاء مسار مخصص `UserPath` .
7. إضافة أوامر للانتقال إلى `UserPath` .
8. كتابة العرض التقديمي إلى القرص كملف PPTX .

يعرض هذا الكود Python كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل :
```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# ينشئ فئة عرض تقديمي تمثل ملف PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # ينشئ تأثير PathFootball للشكل الموجود من الصفر.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # يضيف تأثير الرسوم المتحركة PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # ينشئ نوعًا من "زر".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # ينشئ تسلسلًا من التأثيرات للزر.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # ينشئ مسار مستخدم مخصص. سيتم نقل كائننا فقط بعد النقر على الزر.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # يضيف أوامر للتحريك لأن المسار الذي تم إنشاؤه فارغ.
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

تظهر الأمثلة التالية كيفية استخدام طريقة `get_effects_by_shape` من الفئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات الرسوم المتحركة إلى الأشكال في عروض PowerPoint. يوضح الكود النموذجي التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx` .
```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # يحصل على التسلسل الرئيسي للرسوم المتحركة للشريحة.
    sequence = first_slide.timeline.main_sequence

    # يحصل على الشكل الأول في الشريحة الأولى.
    shape = first_slide.shapes[0]

    # يحصل على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```


**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات رسوم متحركة إلى هذه العناصر النائبة، فستُعرض جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة تحتوي فقط على شكل تذييل بنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير رسوم متحركة لشكل الشريحة](slide-shape-animation.png)

كما نفترض أن تأثير **Split** تم تطبيقه على عنصر النائب في تذييل شريحة **التخطيط**.

![تأثير رسوم متحركة لشكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر النائب في تذييل شريحة **القالب**.

![تأثير رسوم متحركة لشكل القالب](master-shape-animation.png)

يظهر الكود النموذجي التالي كيفية استخدام طريقة `get_base_placeholder` من الفئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للوصول إلى عناصر النائب للشكل والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والقالب .
```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # الحصول على تأثيرات الرسوم المتحركة للشكل في الشريحة العادية.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # الحصول على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة التخطيط.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # الحصول على تأثيرات الرسوم المتحركة للعنصر النائب في شريحة القالب.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```


الإخراج:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```


## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

تتيح Aspose.Slides للـ Python عبر .NET تغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي العلاقات بين توقيت PowerPoint وخصائص `Effect.Timing` :

- القائمة المنسدلة **Start** في PowerPoint Timing تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) .
- **Duration** في PowerPoint Timing يتطابق مع خاصية `Effect.Timing.Duration` . مدة الرسوم المتحركة (بالثواني) هي إجمالي الوقت الذي تستغرقه الرسوم المتحركة لإكمال دورة واحدة. 
- **Delay** في PowerPoint Timing يتطابق مع خاصية `Effect.Timing.TriggerDelayTime` . 

بهذا الشكل يمكنك تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط قيم جديدة لخصائص `Effect.Timing` التي تحتاجها. 
3. احفظ ملف PPTX المعدل.

يعرض هذا الكود Python العملية :
```python
import aspose.slides as slides

# ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = pres.slides[0].timeline.main_sequence

    # يحصل على التأثير الأول في التسلسل الرئيسي.
    effect = sequence[0]

    # يغيّر TriggerType للتأثير لجعله يبدأ عند النقر
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # يغيّر مدة التأثير
    effect.timing.duration = 3

    # يغيّر TriggerDelayTime للتأثير
    effect.timing.trigger_delay_time = 0.5

    # يحفظ ملف PPTX على القرص
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```


## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع الأصوات في تأثيرات الرسوم المتحركة: 

- `sound`
- `stop_previous_sound`

### **إضافة صوت لتأثير الرسوم المتحركة**

يعرض هذا الكود Python كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي :
```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # يضيف صوتًا إلى مجموعة أصوات العرض التقديمي
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = first_slide.timeline.main_sequence

    # يحصل على التأثير الأول في التسلسل الرئيسي
    first_effect = sequence[0]

    # يتحقق من أن التأثير لا يحتوي على صوت
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # يضيف صوتًا للتأثير الأول
        first_effect.sound = effect_sound

    # يحصل على أول تسلسل تفاعلي في الشريحة.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # يضبط علامة "إيقاف الصوت السابق" للتأثير
    interactive_sequence[0].stop_previous_sound = True

    # يحفظ ملف PPTX على القرص
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```


### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الصوت `sound` المضمن في كل تأثير رسوم متحركة. 

يعرض هذا الكود Python كيفية استخراج الصوت المضمن في تأثير الرسوم المتحركة :
```python
import aspose.slides as slides

# ينشئ كائنًا من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # يحصل على التسلسل الرئيسي للشريحة.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # يستخرج صوت التأثير كمصفوفة بايت
        audio = effect.sound.binary_data
```


## **بعد الرسوم المتحركة**

تتيح Aspose.Slides للـ .NET تغيير خاصية After animation لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة منسدلة **After animation** في PowerPoint تتطابق مع هذه الخصائص: 

- خاصية `after_animation_type` التي تصف نوع بعد الرسوم المتحركة :
  * **More Colors** في PowerPoint يتطابق مع نوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * **Don't Dim** في PowerPoint يتطابق مع نوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (نوع بعد الرسوم المتحركة الافتراضي) ;
  * **Hide After Animation** في PowerPoint يتطابق مع نوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** في PowerPoint يتطابق مع نوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
- خاصية `after_animation_color` التي تحدد تنسيق لون بعد الرسوم المتحركة. تعمل هذه الخاصية بالتزامن مع نوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) . إذا غيرت النوع إلى نوع آخر، سيتم مسح لون بعد الرسوم المتحركة.

يعرض هذا الكود Python كيفية تغيير تأثير بعد الرسوم المتحركة :
```python
import aspose.slides as slides

# ينشئ فئة عرض تقديمي تمثل ملف عرض تقديمي
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # يحصل على التأثير الأول في التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # يغيّر نوع الحركة بعد الرسوم المتحركة إلى اللون
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # يحدد لون التعتيم بعد الرسوم المتحركة
    first_effect.after_animation_color.color = Color.alice_blue

    # يحفظ ملف PPTX على القرص
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```


## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع قسم *تحريك النص* في تأثير الرسوم المتحركة :

- `animate_text_type` التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل :
  - كلّها مرة واحدة ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الكلمات ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - حسب الحرف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
- `delay_between_text_parts` تحدد تأخيرًا بين أجزاء النص المتحركة (كلمات أو أحرف). القيمة الموجبة تحدد نسبة مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

بهذا الشكل يمكنك تغيير خصائص تحريك النص في التأثير :

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الرسوم المتحركة.
2. ضبط خاصية `build_type` إلى القيمة [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) لإيقاف وضع التحريك *By Paragraphs*.
3. ضبط قيم جديدة لخصائص `animate_text_type` و `delay_between_text_parts` .
4. احفظ ملف PPTX المعدل.

يعرض هذا الكود Python العملية :
```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # يحصل على التأثير الأول في التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # يغيّر نوع تحريك النص للتأثير إلى "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # يغيّر نوع تحريك النص للتأثير إلى "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # يحدد التأخير بين الكلمات إلى 20٪ من مدة التأثير
    first_effect.delay_between_text_parts = 20

    # يحفظ ملف PPTX على القرص
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان حفظ الرسوم المتحركة عند نشر العرض التقديمي على الويب؟**

[التصدير إلى HTML5](/slides/ar/python-net/export-to-html5/) وتفعيل [الخيارات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) المسؤولة عن الرسوم المتحركة للأشكال ([shape](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/)) والانتقالات ([transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)). لا يقوم HTML العادي بتشغيل رسوم المتحركة للشرائح، في حين يدعم HTML5 ذلك.

**كيف يؤثر تغيير ترتيب الـ z-order (ترتيب الطبقات) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد ترتيب الـ z-order ما يغطي ما. النتيجة المرئية تُحدَّد بتواصلهما. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، يتم دعم [الرسوم المتحركة](/slides/ar/python-net/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات محددة بطريقة مختلفة. يوصى باختبار التأثيرات المستخدمة وإصدار المكتبة.