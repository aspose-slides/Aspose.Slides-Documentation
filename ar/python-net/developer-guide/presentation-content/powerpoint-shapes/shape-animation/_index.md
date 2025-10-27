---
title: تطبيق حركات الأشكال في العروض التقديمية باستخدام بايثون
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: اكتشف كيفية إنشاء وتخصيص حركات الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. تميز!
---

الحركات هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](/slides/ar/python-net/animated-charts/). إنها تضيف الحياة إلى العروض التقديمية أو مكوناتها. 

## **لماذا تستخدم الحركات في العروض التقديمية؟**

باستخدام الحركات، يمكنك 

* التحكم في تدفق المعلومات
* تأكيد النقاط المهمة
* زيادة الاهتمام أو المشاركة بين الجمهور
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

PowerPoint يقدم العديد من الخيارات والأدوات للحركات وتأثيرات الحركات عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الحركات في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الحركات ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) ،
* توفر Aspose.Slides أكثر من **150 تأثير حركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي في الأساس نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق حركة على مربع النص**

Aspose.Slides للبايثون عبر .NET تتيح إمكانية تطبيق حركة على النص داخل الشكل. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `مستطيل` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) .
4. إضافة نص إلى `IAutoShape.TextFrame`.
5. الحصول على تسلسل رئيسي للتأثيرات.
6. إضافة تأثير حركة إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) .
7. ضبط الخاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. حفظ العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `Fade` على AutoShape وتعيين تحريك النص إلى قيمة *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

إضافة إلى تطبيق الحركات على النص، يمكنك أيضًا تطبيق الحركات على [فقرة] واحدة. راجع [**النص المتحرك**](/slides/ar/python-net/animated-text/).

{{% /alert %}} 

## **تطبيق حركة على إطار الصورة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) على الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير حركة إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) .
6. حفظ العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `Fly` على إطار صورة:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تطبيق حركة على الشكل**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. إضافة `مستطيل` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) .
4. إضافة `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (عند النقر على هذا الكائن، يتم تشغيل الحركة).
5. إنشاء تسلسل للتأثيرات على شكل الـ bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. حفظ العرض إلى القرص كملف PPTX.

هذا الكود بايثون يوضح كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على تأثيرات الحركة المطبقة على الشكل**

توضح الأمثلة التالية كيفية استخدام طريقة `get_effects_by_shape` من فئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) للحصول على جميع تأثيرات الحركة المطبقة على شكل.

**المثال 1: الحصول على تأثيرات الحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الحركة إلى الأشكال في عروض PowerPoint. يوضح الكود التالي كيفية الحصول على التأثيرات المطبقة على أول شكل في أول شريحة عادية في العرض `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**المثال 2: الحصول على جميع تأثيرات الحركة، بما في ذلك تلك الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو شريحة القالب، وتم إضافة تأثيرات حركة إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما في ذلك تلك الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint اسمه `sample.pptx` يحتوي على شريحة واحدة فيها فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير حركة شكل الشريحة](slide-shape-animation.png)

ولنفرض أيضًا أن تأثير **Split** تم تطبيقه على عنصر النائب في شريحة **التخطيط**.

![تأثير حركة شكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر النائب في شريحة **القالب الرئيسي**.

![تأثير حركة شكل القالب الرئيسي](master-shape-animation.png)

الكود التالي يوضح كيفية استخدام طريقة `get_base_placeholder` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للوصول إلى عناصر النائب والحصول على تأثيرات الحركة المطبقة على شكل التذييل، بما في ذلك تلك الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والقالب.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
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

## **تغيير خصائص توقيت تأثير الحركة**

Aspose.Slides للبايثون عبر .NET تتيح لك تغيير خصائص توقيت تأثير الحركة.

هذه هي لوحة توقيت الحركة في Microsoft PowerPoint:

![صورة مثال1](shape-animation.png)

العلاقات بين توقيت PowerPoint وخصائص `Effect.Timing`:

- قائمة السقوط **Start** في توقيت PowerPoint تتطابق مع الخاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- قائمة **Duration** تتطابق مع الخاصية `Effect.Timing.Duration`. مدة الحركة (بالثواني) هي الوقت الإجمالي الذي تستغرقه الحركة لإكمال دورة واحدة. 
- قائمة **Delay** تتطابق مع الخاصية `Effect.Timing.TriggerDelayTime`. 

هكذا تغيّر خصائص توقيت التأثير:

1. تطبيق (Apply) أو الحصول على تأثير الحركة.
2. ضبط القيم الجديدة للخصائص `Effect.Timing` التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **صوت تأثير الحركة**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع الأصوات في تأثيرات الحركة: 

- `sound`
- `stop_previous_sound`

### **إضافة صوت لتأثير الحركة**

هذا الكود بايثون يوضح كيفية إضافة صوت لتأثير الحركة وإيقافه عندما يبدأ التأثير التالي:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج صوت تأثير الحركة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الـ `sound` المضمن في كل تأثير حركة. 

هذا الكود بايثون يوضح كيفية استخراج الصوت المضمن في تأثير الحركة:

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **بعد الحركة**

Aspose.Slides لل.NET تتيح لك تغيير خاصية After animation لتأثير الحركة.

هذه هي لوحة تأثير الحركة والقائمة الموسعة في Microsoft PowerPoint:

![صورة مثال1](shape-after-animation.png)

قائمة السقوط **After animation** في PowerPoint تتطابق مع هذه الخصائص: 

- الخاصية `after_animation_type` التي تصف نوع الحركة بعد الانتهاء :
  * PowerPoint **More Colors** يتطابق مع النوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
  * PowerPoint **Don't Dim** يتطابق مع النوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (نوع الحركة بعد الانتهاء الافتراضي)؛
  * PowerPoint **Hide After Animation** يتطابق مع النوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
  * PowerPoint **Hide on Next Mouse Click** يتطابق مع النوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
- الخاصية `after_animation_color` التي تحدد تنسيق لون الحركة بعد الانتهاء. هذه الخاصية تعمل بالتزامن مع النوع [COLOR]. إذا غيرت النوع إلى آخر، سيتم مسح لون الحركة بعد الانتهاء.

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **تحريك النص**

توفر Aspose.Slides هذه الخصائص لتتيح لك العمل مع كتلة *تحريك النص* في تأثير الحركة:

- خاصية `animate_text_type` التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - كلمة بكلمة ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
  - حرف بحرف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) النوع)
- خاصية `delay_between_text_parts` التي تحدد التأخير بين أجزاء النص المتحركة (الكلمات أو الحروف). القيمة الإيجابية تحدد نسبة مئوية من مدة التأثير. القيمة السلبية تحدد التأخير بالثواني.

هكذا تغير خصائص تحريك النص في التأثير:

1. تطبيق أو الحصول على تأثير الحركة.
2. ضبط الخاصية `build_type` إلى القيمة [AS_ONE_OBJECT] لإيقاف وضع التحريك *حسب الفقرات*.
3. ضبط القيم الجديدة للخصائص `animate_text_type` و`delay_between_text_parts`.
4. حفظ ملف PPTX المعدل.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **الأسئلة الشائعة**

**كيف يمكنني التأكد من حفظ الحركات عند نشر العرض على الويب؟**

[تصدير إلى HTML5](/slides/ar/python-net/export-to-html5/) وتفعيل [الخيارات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) المسؤولة عن [حركة الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[حركة الانتقالات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). HTML العادي لا يشغّل حركات الشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الحركة؟**

الحركة وترتيب الرسم مستقلان: التحكم في التوقيت ونوع الظهور/الاختفاء يحدده التأثير، بينما يحدد [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) ما يغطي ما. النتيجة المرئية تتحدد بتكوينهما معًا. (هذا هو سلوك PowerPoint العام؛ نموذج Aspose.Slides لتأثيرات الأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الحركات إلى فيديو لبعض التأثيرات؟**

بشكل عام، [الحركات مدعومة](/slides/ar/python-net/convert-powerpoint-to-video/)، لكن بعض الحالات النادرة أو التأثيرات المحددة قد تُعرض بصورة مختلفة. يُنصح باختبار التأثيرات المستخدمة ومع نسخة المكتبة.