---
title: تطبيق الرسوم المتحركة للأشكال في العروض التقديمية باستخدام بايثون
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/python-net/shape-animation/
keywords:
- شكل
- رسوم متحركة
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
description: "اكتشف كيفية إنشاء وتخصيص الرسوم المتحركة للأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. برز!"
---

الرسوم المتحركة هي تأثيرات بصرية يمكن تطبيقها على النصوص أو الصور أو الأشكال أو [المخططات](/slides/ar/python-net/animated-charts/). إنها تعطي الحياة للعروض التقديمية أو مكوناتها. 

## **لماذا استخدام الرسوم المتحركة في العروض التقديمية؟**

باستخدام الرسوم المتحركة، يمكنك 

* التحكم في تدفق المعلومات
* التأكيد على النقاط المهمة
* زيادة الاهتمام أو المشاركة بين جمهورك
* جعل المحتوى أسهل للقراءة أو الاستيعاب أو المعالجة
* جذب انتباه قرائك أو مشاهديك إلى الأجزاء المهمة في العرض

PowerPoint يوفر العديد من الخيارات والأدوات للرسوم المتحركة وتأثيراتها عبر فئات **الدخول**، **الخروج**، **التأكيد**، و**مسارات الحركة**. 

## **الرسوم المتحركة في Aspose.Slides**

* توفر Aspose.Slides الفئات والأنواع التي تحتاجها للعمل مع الرسوم المتحركة ضمن مساحة الاسم [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)،
* توفر Aspose.Slides أكثر من **150 تأثير حركة** ضمن تعداد [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). هذه التأثيرات هي أساسًا نفس التأثيرات (أو ما يعادلها) المستخدمة في PowerPoint.

## **تطبيق حركة على TextBox**

يتيح Aspose.Slides للبايثون عبر .NET تطبيق حركة على النص داخل الشكل. 

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) من نوع `مستطيل`.
4. إضافة نص إلى `IAutoShape.TextFrame`.
5. الحصول على التسلسل الرئيسي للتأثيرات.
6. إضافة تأثير حركة إلى [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
7. ضبط خاصية `TextAnimation.BuildType` إلى القيمة من تعداد `BuildType`.
8. حفظ العرض التقديمي على القرص كملف PPTX.

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

بالإضافة إلى تطبيق الرسوم المتحركة على النص، يمكنك أيضًا تطبيق الرسوم المتحركة على [Paragraph] واحدة. راجع **النص المتحرك** [/slides/python-net/animated-text/].

{{% /alert %}} 

## **تطبيق حركة على PictureFrame**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة أو الحصول على [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) على الشريحة. 
4. الحصول على التسلسل الرئيسي للتأثيرات.
5. إضافة تأثير حركة إلى [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. حفظ العرض التقديمي على القرص كملف PPTX.

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

## **تطبيق حركة على Shape**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) من نوع `مستطيل`. 
4. إضافة [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) من نوع `Bevel` (عند النقر على هذا الكائن، تُشغل الحركة).
5. إنشاء تسلسل للتأثيرات على شكل الـ Bevel.
6. إنشاء مسار مخصص `UserPath`.
7. إضافة أوامر للتحرك إلى `UserPath`.
8. حفظ العرض التقديمي على القرص كملف PPTX.

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

## **الحصول على تأثيرات الحركة المطبقة على Shape**

الأمثلة التالية توضح كيفية استخدام طريقة `get_effects_by_shape` من فئة [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) للحصول على جميع تأثيرات الحركة المطبقة على شكل.

**مثال 1: الحصول على تأثيرات الحركة المطبقة على شكل في شريحة عادية**

في السابق، تعلمت كيفية إضافة تأثيرات الحركة إلى الأشكال في عروض PowerPoint. يُظهر الكود التالي كيفية الحصول على التأثيرات المطبقة على الشكل الأول في الشريحة العادية الأولى في ملف العرض `AnimExample_out.pptx`.

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

**مثال 2: الحصول على جميع تأثيرات الحركة، بما في ذلك تلك الموروثة من النوافذ المحجزة**

إذا كان الشكل في شريحة عادية يحتوي على نوافذ محجزة في شريحة التخطيط أو الشريحة الرئيسة، وتم إضافة تأثيرات حركة لهذه النوافذ، فستُشغل جميع تأثيرات الشكل أثناء العرض، بما في ذلك الموروثة من النوافذ.

لنفترض أن لدينا ملف عرض PowerPoint `sample.pptx` يحتوي على شريحة واحدة بها فقط شكل تذييل بالنص "Made with Aspose.Slides" وتم تطبيق تأثير **Random Bars** على الشكل.

![Slide shape animation effect](slide-shape-animation.png)

ولنفرض أيضًا أن تأثير **Split** تم تطبيقه على نافذة التذييل في شريحة **التخطيط**.

![Layout shape animation effect](layout-shape-animation.png)

وأخيرًا، تم تطبيق تأثير **Fly In** على نافذة التذييل في شريحة **الرئيسة**.

![Master shape animation effect](master-shape-animation.png)

الكود التالي يوضح كيفية استخدام طريقة `get_base_placeholder` من فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للوصول إلى نوافذ الشكل والحصول على تأثيرات الحركة المطبقة على شكل التذييل، بما في ذلك الموروثة من النوافذ الموجودة في شريحة التخطيط والرئيسة.

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

## **تغيير خصائص توقيت تأثير الحركة**

يتيح Aspose.Slides للبايثون عبر .NET تغيير خصائص توقيت تأثير الحركة.

هذه هي لوحة توقيت الحركة في Microsoft PowerPoint:

![example1_image](shape-animation.png)

هذه هي المقابلات بين توقيت PowerPoint وخصائص `Effect.Timing`:

- قائمة **Start** في PowerPoint تتطابق مع خاصية [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).
- **Duration** في PowerPoint تتطابق مع خاصية `Effect.Timing.Duration`. مدة الحركة (بالثواني) هي الوقت الكلي الذي تستغرقه الحركة لإكمال دورة واحدة.
- **Delay** في PowerPoint تتطابق مع خاصية `Effect.Timing.TriggerDelayTime`.

كيفية تغيير خصائص توقيت التأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الحركة.
2. ضبط القيم الجديدة لخصائص `Effect.Timing` التي تحتاجها. 
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

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع الأصوات في تأثيرات الحركة:

- `sound`
- `stop_previous_sound`

### **إضافة صوت لتأثير الحركة**

هذا الكود يوضح كيفية إضافة صوت لتأثير الحركة وإيقافه عندما يبدأ التأثير التالي:

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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. الحصول على التسلسل الرئيسي للتأثيرات. 
4. استخراج الـ `sound` المضمن لكل تأثير حركة. 

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

يتيح Aspose.Slides لل.NET تغيير خاصية "After animation" لتأثير الحركة.

هذه هي لوحة تأثير الحركة والقائمة الموسعة في Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

قائمة **After animation** في PowerPoint تتطابق مع هذه الخصائص:

- خاصية `after_animation_type` التي تصف نوع "After animation":
  * **More Colors** في PowerPoint يتطابق مع نوع [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).
  * **Don't Dim** يتطابق مع نوع [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (الافتراضي).
  * **Hide After Animation** يتطابق مع نوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).
  * **Hide on Next Mouse Click** يتطابق مع نوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/).
- خاصية `after_animation_color` التي تحدد تنسيق لون "After animation". تعمل هذه الخاصية بالتزامن مع نوع [COLOR]. إذا قمت بتغيير النوع إلى آخر، سيتم مسح لون "After animation".

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

توفر Aspose.Slides هذه الخصائص للسماح لك بالعمل مع كتلة *Animate text* لتأثير الحركة:

- `animate_text_type` التي تصف نوع تحريك النص للتأثير. يمكن تحريك نص الشكل:
  - كله مرة واحدة ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
  - حسب الكلمة ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
  - حسب الحرف ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
- `delay_between_text_parts` يحدد تأخيرًا بين أجزاء النص المتحركة (الكلمات أو الحروف). القيمة الإيجابية تمثل نسبة مئوية من مدة التأثير. القيمة السالبة تمثل التأخير بالثواني.

كيفية تغيير خصائص تحريك النص للتأثير:

1. [تطبيق](#apply-animation-to-shape) أو الحصول على تأثير الحركة.
2. ضبط خاصية `build_type` إلى قيمة [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) لإلغاء وضع **By Paragraphs**.
3. ضبط القيم الجديدة لكل من `animate_text_type` و `delay_between_text_parts`.
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

## **FAQ**

**كيف يمكنني ضمان حفظ الرسوم المتحركة عند نشر العرض على الويب؟**

استخدم [Export to HTML5](/slides/ar/python-net/export-to-html5/) وفعل الخيارات المسؤولة عن [shape](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) و[transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) للرسوم المتحركة. HTML العادي لا يشغل رسومات الحركة، بينما HTML5 يفعل ذلك.

**كيف يؤثر تغيير ترتيب الطبقات (z-order) للأشكال على الحركة؟**

الرسوم المتحركة وترتيب الرسم مستقلان: يتحكم التأثير في توقيت ونوع الظهور/الاختفاء، بينما يحدد [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) ما يغطي ما. النتيجة المرئية تعتمد على الجمع بينهما. (هذا السلوك العام في PowerPoint؛ نموذج Aspose.Slides للرسوم المتحركة والأشكال يتبع نفس المنطق.)

**هل هناك قيود عند تحويل الرسوم المتحركة إلى فيديو لبعض التأثيرات؟**

بشكل عام، **الرسوم المتحركة مدعومة** [/slides/python-net/convert-powerpoint-to-video/]، لكن قد تُعرض حالات نادرة أو تأثيرات معينة بشكل مختلف. يُنصح باختبار التأثيرات التي تستخدمها ومعرفة نسخة المكتبة.