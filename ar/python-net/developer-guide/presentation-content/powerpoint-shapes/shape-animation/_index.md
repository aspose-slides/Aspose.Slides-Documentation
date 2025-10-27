---
title: تطبيق تحريكات الأشكال في العروض التقديمية باستخدام بايثون
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/python-net/shape-animation/
keywords:
- شكل
- تحريك
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
description: "اكتشف كيفية إنشاء وتخصيص تحريكات الأشكال في عروض PowerPoint وعروض OpenDocument باستخدام Aspose.Slides for Python عبر .NET. تميز!"
---

التحريكات هي تأثيرات بصرية يمكن تطبيقها على النصوص، الصور، الأشكال، أو [المخططات](/slides/ar/python-net/animated-charts/). إنها تضيف الحياة إلى العروض التقديمية أو مكوّناتها. 

## **لماذا نستخدم التحريكات في العروض التقديمية؟**

باستخدام التحريكات، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط الهامة
* زيادة الاهتمام أو المشاركة لدى جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه القراء أو المشاهدين إلى الأجزاء المهمة في العرض

يوفر PowerPoint العديد من الخيارات والأدوات للتحريكات وتأثيرات التحريك عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **التحريكات في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع التحريكات ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)،
* توفر Aspose.Slides أكثر من **150 تأثير تحريك** ضمن تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي في الأساس نفس التأثيرات (أو المكافئة) المستخدمة في PowerPoint.

## **تطبيق تحريك على مربع النص**

يتيح Aspose.Slides for Python عبر .NET تطبيق تحريك على النص داخل الشكل. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` من نوع [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. إضافة نص إلى `IAutoShape.TextFrame`.
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير تحريك إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
7. ضبط الخاصية `TextAnimation.BuildType` على القيمة من تعداد `BuildType`.
8. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود بايثون كيفية تطبيق تأثير `Fade` على AutoShape وتعيين تحريك النص إلى قيمة *By 1st Level Paragraphs*:

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

بالإضافة إلى تطبيق التحريكات على النص، يمكنك أيضًا تطبيق التحريكات على [فقرة](/slides/ar/python-net/animated-text/) واحدة. راجع [**النص المتحرك**](/slides/ar/python-net/animated-text/).

{{% /alert %}} 

## **تطبيق تحريك على PictureFrame**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) في الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير تحريك إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود بايثون كيفية تطبيق تأثير `Fly` على إطار صورة:

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

## **تطبيق تحريك على شكل**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة `rectangle` من نوع [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. إضافة `Bevel` من نوع [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (عند النقر على هذا الكائن، يتم تشغيل التحريك).
5. إنشاء تسلسل للتأثيرات على شكل الـ bevel.
6. إنشاء `UserPath` مخصص.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. كتابة العرض إلى القرص كملف PPTX.

يظهر هذا الكود بايثون كيفية تطبيق تأثير `PathFootball` (مسار كرة القدم) على شكل:

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

## **الحصول على تأثيرات التحريك المطبقة على الشكل**

تُظهر الأمثلة التالية كيفية استخدام طريقة `get_effects_by_shape` من فئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) للحصول على جميع تأثيرات التحريك المطبقة على شكل.

**مثال 1: الحصول على تأثيرات التحريك المطبقة على شكل في شريحة عادية**

سابقًا، تعلمت كيفية إضافة تأثيرات التحريك إلى الأشكال في عروض PowerPoint. يُظهر الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في العرض `AnimExample_out.pptx`.

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

**مثال 2: الحصول على جميع تأثيرات التحريك، بما فيها الموروثة من العناصر النائبة**

إذا كان الشكل في شريحة عادية يحتوي على عناصر نائبة موجودة في شريحة التخطيط و/أو الشريحة الأم، وتم إضافة تأثيرات تحريك إلى هذه العناصر النائبة، فسيتم تشغيل جميع تأثيرات الشكل أثناء عرض الشرائح، بما فيها الموروثة من العناصر النائبة.

لنفترض أن لدينا ملف عرض PowerPoint اسمه `sample.pptx` يحتوي على شريحة واحدة بها شكل تذييل فقط يحمل النص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![تأثير تحريك شكل الشريحة](slide-shape-animation.png)

ولنفرض أن تأثير **Split** تم تطبيقه على عنصر النائب في شريحة **التخطيط**.

![تأثير تحريك شكل التخطيط](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على عنصر النائب في شريحة **الماستر**.

![تأثير تحريك شكل الماستر](master-shape-animation.png)

يُظهر الكود التالي كيفية استخدام طريقة `get_base_placeholder` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للوصول إلى العناصر النائبة والحصول على تأثيرات التحريك المطبقة على شكل التذييل، بما فيها الموروثة من العناصر النائبة الموجودة في شريحة التخطيط والماستر.

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

الناتج:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **تغيير خصائص توقيت تأثير التحريك**

يتيح Aspose.Slides for Python عبر .NET تغيير خصائص توقيت تأثير التحريك.

هذه هي لوحة توقيت التحريك في Microsoft PowerPoint:

![مثال1_صورة](shape-animation.png)

هذه هي المطابقات بين توقيت PowerPoint وخصائص `Effect.Timing`:

- قائمة **Start** المنسدلة في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- **Duration** في PowerPoint تتطابق مع خاصية `Effect.Timing.Duration`. مدة التحريك (بالثواني) هي الوقت الإجمالي الذي يستغرقه التحريك لإكمال دورة واحدة. 
- **Delay** في PowerPoint تتطابق مع خاصية `Effect.Timing.TriggerDelayTime`. 

كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التحريك.
2. ضبط القيم الجديدة لخصائص `Effect.Timing` التي تحتاجها. 
3. حفظ ملف PPTX المعدل.

يُظهر الكود التالي العملية:

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

## **صوت تأثير التحريك**

توفر Aspose.Slides الخصائص التالية للعمل مع الأصوات في تأثيرات التحريك: 

- `sound`
- `stop_previous_sound`

### **إضافة صوت لتأثير التحريك**

يُظهر هذا الكود بايثون كيفية إضافة صوت لتأثير التحريك وإيقافه عندما يبدأ التأثير التالي:

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

### **استخراج صوت تأثير التحريك**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الخاصية `sound` المتضمنة في كل تأثير تحريك. 

يُظهر الكود التالي كيفية استخراج الصوت المتضمن في تأثير التحريك:

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

## **بعد التحريك**

يتيح Aspose.Slides for .NET تغيير خاصية **After animation** لتأثير التحريك.

هذه هي لوحة تأثير التحريك والقائمة الموسعة في Microsoft PowerPoint:

![مثال1_صورة](shape-after-animation.png)

قائمة **After animation** المنسدلة في PowerPoint تتطابق مع هذه الخصائص: 

- الخاصية `after_animation_type` التي تصف نوع **After animation** :
  * **More Colors** في PowerPoint تتطابق مع النوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
  * العنصر **Don't Dim** في PowerPoint يتطابق مع النوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (النوع الافتراضي)؛
  * العنصر **Hide After Animation** يتطابق مع النوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
  * العنصر **Hide on Next Mouse Click** يتطابق مع النوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/)؛
- الخاصية `after_animation_color` التي تحدد تنسيق لون **After animation**. تعمل هذه الخاصية بالتزامن مع النوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون **After animation**.

يُظهر الكود التالي كيفية تغيير تأثير **After animation**:

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

توفر Aspose.Slides الخصائص التالية للعمل مع كتلة **Animate text** في تأثير التحريك:

- `animate_text_type` التي تصف نوع تحريك النص في التأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )،
  - حسب الكلمات ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )،
  - حسب الأحرف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )،
- `delay_between_text_parts` التي تحدد التأخير بين أجزاء النص المتحركة (الكلمات أو الأحرف). القيمة الموجبة تحدد نسبة مئوية من مدة التأثير. القيمة السالبة تحدد التأخير بالثواني.

طريقة تغيير خصائص **Animate text** في التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير التحريك.
2. ضبط الخاصية `build_type` على القيمة [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) لإلغاء وضع **By Paragraphs**.
3. ضبط القيم الجديدة للخصائص `animate_text_type` و `delay_between_text_parts`.
4. حفظ ملف PPTX المعدل.

يُظهر الكود التالي العملية:

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

**كيف يمكنني التأكد من الحفاظ على التحريكات عند نشر العرض على الويب؟**

استخدام [Export to HTML5](/slides/ar/python-net/export-to-html5/) وتفعيل الـ[خيارات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) المسؤولة عن تحريكات [الأشكال](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[الانتقالات](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). HTML العادي لا يشغل تحريكات الشرائح، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على التحريكات؟**

التحريك وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) ما يغطي ما. النتيجة المرئية تُحدد بتواصلهما. (هذا هو السلوك العام في PowerPoint؛ نموذج Aspose.Slides للأنماط والتحريكات يتبع نفس المنطق.)

**هل هناك قيود عند تحويل التحريكات إلى فيديو لبعض التأثيرات؟**

بشكل عام، [التحريكات مدعومة](/slides/ar/python-net/convert-powerpoint-to-video/)، لكن قد تُعرض حالات نادرة أو تأثيرات معينة بشكل مختلف. يوصى باختبار التأثيرات التي تستخدمها ومع نسخة المكتبة.