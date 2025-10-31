---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام بايثون
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/python-net/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة تحريك
- الحصول على تحريك
- استخراج تحريك
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق تحريك
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتخصيص رسومات متحركة للأشكال في عروض PowerPoint وعروض OpenDocument التقديمية باستخدام Aspose.Slides للبايثون عبر .NET. ابق مميزًا!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [الرسوم البيانية](/slides/ar/python-net/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها.

## **لماذا نستخدم الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك  

* التحكم في تدفق المعلومات  
* تأكيد النقاط الهامة  
* زيادة الاهتمام أو المشاركة بين الجمهور  
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة  
* جذب انتباه القراء أو المشاهدين إلى الأجزاء الهامة في العرض  

توفر PowerPoint العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**.

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة تحت مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/).  
* توفر Aspose.Slides أكثر من **150 تأثيرًا متحركًا** تحت تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي في الأساس نفس التأثيرات المستخدمة في PowerPoint.

## **تطبيق الرسوم المتحركة على مربع النص**

يسمح Aspose.Slides للبايثون عبر .NET بتطبيق الرسوم المتحركة على النص داخل شكل.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. إضافة نص إلى `IAutoShape.TextFrame`.  
5. الحصول على التسلسل الرئيسي للتأثيرات.  
6. إضافة تأثير رسوم متحركة إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. ضبط خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.  
8. كتابة العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `Fade` على AutoShape وتعيين تحريك النص إلى قيمة *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # إضافة AutoShape جديدة مع نص
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # الحصول على التسلسل الرئيسي للشرائح.
    sequence = sld.timeline.main_sequence

    # إضافة تأثير تلاشي (Fade) إلى الشكل
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # تحريك نص الشكل وفقًا للفقرة من المستوى الأول
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

إلى جانب تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيقها على [Paragraph](/slides/ar/python-net/aspose.slides/iparagraph/). راجع **النص المتحرك** [/slides/python-net/animated-text/].

{{% /alert %}} 

## **تطبيق الرسوم المتحركة على PictureFrame**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) في الشريحة.  
4. الحصول على التسلسل الرئيسي للتأثيرات.  
5. إضافة تأثير رسوم متحركة إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. كتابة العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `Fly` على إطار صورة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation() as pres:
    # تحميل الصورة لإضافتها إلى مجموعة صور العرض التقديمي
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # إضافة إطار صورة إلى الشريحة
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # الحصول على التسلسل الرئيسي للشرحة.
    sequence = pres.slides[0].timeline.main_sequence

    # إضافة تأثير التحليق من اليسار (Fly) إلى إطار الصورة
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق الرسوم المتحركة على Shape**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. إضافة `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (عند النقر على هذا الكائن يُشغل الرسوم المتحركة).  
5. إنشاء تسلسل من التأثيرات على شكل الـ bevel.  
6. إنشاء `UserPath` مخصص.  
7. إضافة أوامر للتحرك لأن المسار المُنشأ فارغ.  
8. كتابة العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `PathFootball` على شكل:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن من فئة Presentation يمثل ملف PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # إنشاء تأثير PathFootball للشكل الموجود من الصفر.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # إضافة تأثير PathFootball للرسوم المتحركة.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # إنشاء نوع من "الزر".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # إنشاء تسلسل من التأثيرات للزر.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # إنشاء مسار مخصص للمستخدم. سيتم تحريك كائننا فقط بعد النقر على الزر.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # إضافة أوامر للتحرك لأن المسار المُنشأ فارغ.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على تأثيرات الرسوم المتحركة المطبقة على Shape**

الأمثلة التالية توضح كيفية استخدام طريقة `get_effects_by_shape` من فئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) للحصول على جميع تأثيرات الرسوم المتحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الرسوم المتحركة المطبقة على شكل في شريحة عادية**

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # الحصول على التسلسل الرئيسي للرسوم المتحركة للشرحة.
    sequence = first_slide.timeline.main_sequence

    # الحصول على الشكل الأول في الشريحة الأولى.
    shape = first_slide.shapes[0]

    # الحصول على تأثيرات الرسوم المتحركة المطبقة على الشكل.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**المثال 2: الحصول على جميع تأثيرات الرسوم المتحركة، بما في ذلك الموروثة من العناصر النائبة**

إذا كان شكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات رسومية لهذه العناصر النائبة، فستُشغل جميع تأثيرات الشكل أثناء العرض، بما في ذلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف PowerPoint `sample.pptx` يحتوي على شريحة واحدة بها شكل تذييل نصه "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير رسم متحرك لشكل شريحة](/slides/ar/python-net/shape-animation.png)

لنفترض أيضًا أن تأثير **Split** تم تطبيقه على العنصر النائب للتذييل في شريحة **التخطيط**.

![تأثير رسم متحرك لشكل التخطيط](/slides/ar/python-net/layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على العنصر النائب للتذييل في شريحة **القالب**.

![تأثير رسم متحرك لشكل القالب](/slides/ar/python-net/master-shape-animation.png)

الكود التالي يوضح كيفية استخدام طريقة `get_base_placeholder` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للوصول إلى العناصر النائبة والحصول على تأثيرات الرسوم المتحركة المطبقة على شكل التذييل، بما في ذلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والقالب:

```python
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```python
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

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **تغيير خصائص توقيت تأثير الرسوم المتحركة**

يسمح Aspose.Slides للبايثون عبر .NET بتغيير خصائص التوقيت لتأثير الرسوم المتحركة.

هذه هي لوحة توقيت الرسوم المتحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص `Effect.Timing`:

- قائمة **Start** في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- **Duration** في PowerPoint تتطابق مع خاصية `Effect.Timing.Duration`. مدة الرسوم المتحركة (بالثواني) هي الوقت الكلي لإكمال دورة واحدة.  
- **Delay** في PowerPoint تتطابق مع خاصية `Effect.Timing.TriggerDelayTime`.  

كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق]#apply-animation-to-shape أو الحصول على تأثير الرسوم المتحركة.  
2. ضبط القيم الجديدة لخصائص `Effect.Timing` المطلوبة.  
3. حفظ ملف PPTX المعدل.

الكود التالي يوضح العملية:

```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # الحصول على التسلسل الرئيسي للشرحة.
    sequence = pres.slides[0].timeline.main_sequence

    # الحصول على التأثير الأول في التسلسل الرئيسي.
    effect = sequence[0]

    # تغيير TriggerType للتأثير لتبدأ عند النقر.
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # تغيير مدة التأثير.
    effect.timing.duration = 3

    # تغيير TriggerDelayTime للتأثير.
    effect.timing.trigger_delay_time = 0.5

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **صوت تأثير الرسوم المتحركة**

توفر Aspose.Slides الخصائص التالية للعمل مع الأصوات في تأثيرات الرسوم المتحركة:

- `sound`
- `stop_previous_sound`

### **إضافة صوت لتأثير الرسوم المتحركة**

هذا الكود بايثون يوضح كيفية إضافة صوت لتأثير الرسوم المتحركة وإيقافه عندما يبدأ التأثير التالي:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # إضافة صوت إلى مجموعة الأصوات في العرض التقديمي
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # الحصول على التسلسل الرئيسي للشرحة.
    sequence = first_slide.timeline.main_sequence

    # الحصول على التأثير الأول في التسلسل الرئيسي
    first_effect = sequence[0]

    # التحقق من عدم وجود صوت للتأثير.
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # إضافة صوت للتأثير الأول
        first_effect.sound = effect_sound

    # الحصول على التسلسل التفاعلي الأول للشرحة.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # تعيين علامة "إيقاف الصوت السابق" للتأثير
    interactive_sequence[0].stop_previous_sound = True

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج صوت تأثير الرسوم المتحركة**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. الحصول على التسلسل الرئيسي للتأثيرات.  
4. استخراج `sound` المدمج في كل تأثير رسومي.

هذا الكود بايثون يوضح كيفية استخراج الصوت المدمج في تأثير رسومي:

```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # الحصول على التسلسل الرئيسي للشرحة.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # استخراج صوت التأثير في مصفوفة البايت
        audio = effect.sound.binary_data
```

## **بعد الرسوم المتحركة**

يسمح Aspose.Slides للـ .NET بتغيير خاصية **After animation** لتأثير الرسوم المتحركة.

هذه هي لوحة تأثير الرسوم المتحركة وقائمة السياق الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** في PowerPoint تتطابق مع الخصائص التالية:

- خاصية `after_animation_type` التي تصف نوع الرسوم المتحركة بعد النهاية:
  * **More Colors** في PowerPoint يتطابق مع نوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * **Don't Dim** يتطابق مع نوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). (النوع الافتراضي)  
  * **Hide After Animation** يتطابق مع نوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
  * **Hide on Next Mouse Click** يتطابق مع نوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).  
- خاصية `after_animation_color` التي تحدد تنسيق لون الرسوم المتحركة بعد النهاية. تعمل هذه الخاصية بالتزامن مع النوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). إذا غيرت النوع إلى آخر، سيتم مسح لون الرسوم المتحركة بعد النهاية.

الكود التالي يوضح كيفية تغيير تأثير الرسوم المتحركة بعد النهاية:

```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف PPTX
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # الحصول على التأثير الأول في التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # تغيير نوع الرسوم المتحركة بعد النهاية إلى اللون
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # تعيين لون التعتيم بعد الرسوم المتحركة
    first_effect.after_animation_color.color = Color.alice_blue

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **تحريك النص**

توفر Aspose.Slides الخصائص التالية للعمل مع كتلة *Animate text* في تأثير الرسوم المتحركة:

- `animate_text_type` الذي يصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - جميعًا مرة واحدة ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)).  
  - حسب الكلمة ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)).  
  - حسب الحرف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)).  
- `delay_between_text_parts` يحدد تأخيرًا بين أجزاء النص المتحركة (الكلمات أو الحروف). القيمة الموجبة تمثل نسبة مئوية من مدة التأثير. القيمة السلبية تمثل التأخير بالثواني.

كيفية تغيير خصائص تحريك النص في التأثير:

1. [تطبيق]#apply-animation-to-shape أو الحصول على تأثير الرسوم المتحركة.  
2. ضبط خاصية `build_type` إلى قيمة [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) لإيقاف وضع **By Paragraphs**.  
3. ضبط القيم الجديدة لـ `animate_text_type` و `delay_between_text_parts`.  
4. حفظ ملف PPTX المعدل.

الكود التالي يوضح العملية:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # الحصول على التأثير الأول في التسلسل الرئيسي
    first_effect = first_slide.timeline.main_sequence[0]

    # تغيير نوع تحريك النص إلى "ككائن واحد"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # تغيير نوع تحريك النص إلى "حسب الكلمة"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # تعيين التأخير بين الكلمات إلى 20% من مدة التأثير
    first_effect.delay_between_text_parts = 20

    # حفظ ملف PPTX إلى القرص
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**كيف يمكنني التأكد من الحفاظ على الرسوم المتحركة عند نشر العرض على الويب؟**

استخدم [Export to HTML5](/slides/ar/python-net/export-to-html5/) وفّعل [الخيارات](/slides/ar/python-net/aspose.slides.export/html5options/) المسؤولة عن [animate_shapes](/slides/ar/python-net/aspose.slides.export/html5options/animate_shapes/) و[animate_transitions](/slides/ar/python-net/aspose.slides.export/html5options/animate_transitions/). لا يقوم HTML العادي بتشغيل الرسوم المتحركة للشرائح، بينما HTML5 يقوم بذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الرسوم المتحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](/slides/ar/python-net/aspose.slides/shape/z_order_position/) ما يغطي ما. النتيجة المرئية تُحدَّد بتلك التركيبة. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، [الرسوم المتحركة مدعومة](/slides/ar/python-net/convert-powerpoint-to-video/)، ولكن في حالات نادرة أو لتأثيرات محددة قد تُعرض بصورة مختلفة. يفضَّل اختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.