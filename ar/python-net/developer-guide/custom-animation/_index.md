---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في بايثون
linktitle: رسوم متحركة مخصصة
type: docs
weight: 151
url: /ar/python-net/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint باستخدام Aspose.Slides لبايثون عبر .NET."
---
## **نظرة عامة**

تسمح سلوكيات الرسوم المتحركة المخصصة لك بالتحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير لون، تدوير شكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء ودمج السلوكيات، تكوين توقيتها، فحص وتعديل الرسوم المتحركة الموجودة، والتحقق من بقاء خصائصها بعد حفظ وإعادة فتح العرض التقديمي.

للتعرف على التأثيرات المعرفة مسبقًا ومحفزات النقر، راجع [Shape Animation](/slides/ar/python-net/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

يتم تنظيم الرسوم المتحركة كـ **Timeline → Sequence → Effect → Behaviors**:

- يحتوي [timeline] الخاص بالشريحة على سلسلته الرئيسية والسلاسل التفاعلية.
- يحتوي [Sequence] على تأثيرات، قد تستهدف أشكالًا مختلفة.
- يحدد [Effect] شكل الهدف، الإعداد المسبق، النوع الفرعي، وتوقيت التأثير.
- يحتوي [Effect.behaviors] على العمليات التي تنفذ التأثير: تغيير اللون، التحريك، التدوير، تعيين خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استخدم [Sequence.add_effect] لإنشاء تأثير والوصول إلى مجموعة [behaviors] الخاصة به. يمكن لمجموعة إعداد مسبق تعبئة هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع الإعداد المسبق، أو استخدم [clear] عندما تستبدلها عمدًا.

[BehaviorFactory] ينشئ الأنواع الثمانية للسلوكيات الموضحة أدناه. يغطي الحركة في [Build a Motion Path](#build-a-motion-path). كل مثال إنشاء هو برنامج كامل؛ تُوضح أمثلة التحرير اللاحقة ملف الإخراج المستخدم.

### **دوران**

استخدم [create_rotation_effect] لإنشاء دوران. [by] يحدد زاوية نسبية بالدرجات؛ [from_address] و [to] يحددان نقطتي النهاية.

يبدأ المثال بتأثير Spin، يستبدل عملياته المسبقة بسلوك دوران واحد، ويعطي ذلك العملية مدة ثانيتين. زاوية نسبية قدرها 90 درجة تمثل ربع دورة من اتجاه الشكل الأولي، لذا لا تحتاج إلى زاوية بداية صريحة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، التوقيت، وأمثلة تحرير الدوران أدناه هذا الملف.

### **تحجيم**

استخدم [create_scale_effect] مع نسب X/Y: [from_address] و [to] يصفان الحجم الابتدائي والنهائي، بينما [by] يصف تغيرًا نسبيًا. هنا، 100 تعني الحجم الأصلي.

يقوم المثال بزيادة البعدين من 100% إلى 125% خلال ثانيتين. استخدام نسب أفقية ورأسية متساوية يحافظ على نسب الشكل؛ نسب مختلفة ستمدد بعدًا أكثر من الآخر.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **لون**

استخدم [create_color_effect] لتغيير التعبئة من الأزرق إلى البرتقالي. [from_address] و [to] هما ألوان؛ [by] هو إزاحة لون. [Behavior.properties] يحدد السمة التي يتم تحريكها.

تُهيأ تعبئة الشكل الصلبة إلى الأزرق، مطابقة للون البداية في الحركة. اختيار سمة تعبئة اللون يُخبر السلوك أي جزء من الشكل يغيّر؛ الألوان النهائية وحدها لا تحدد تلك السمة. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **فلتر**

استخدم [create_filter_effect] لتحديد مسح. [type]، [subtype]، و [reveal] تحدد الفلتر، الاتجاه، وما إذا كان يُظهر أو يُخفي الشكل.

يقوم هذا المثال بإعداد مسح لمدة ثانيتين يُظهر الشكل باستخدام النوع الفرعي باتجاه اليمين. تنتمي إعدادات الفلتر إلى السلوك داخل التأثير، لذا تُضبط بعد إزالة العمليات الأصلية للإعداد المسبق.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **خاصية**

استخدم [create_property_effect] لتحريك الشفافية. [from_address]، [to]، و [by] هي سلاسل تُفسَّر باستخدام [value_type] و [calc_mode]. اختر نقطتي النهاية أو إزاحة نسبية بدلاً من ضبط الثلاثة عشوائيًا.

هنا، السمة المختارة هي الشفافية، والسلاسل الرقمية تمثل تغيرًا من 25% شفافية إلى شفافية كاملة. يصف الاستيفاء الخطي تغيرًا تدريجيًا بين تلك القيم. عند تعديل هذا المثال لسمة أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك السمة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **تعيين**

استخدم [create_set_effect] لتعيين الرؤية عبر [to]. سلوك التعيين لا يستنتج بين نقطتي النهاية.

يختار المثال سمة الرؤية ويعين السلسلة `visible` عند تشغيل السلوك. المستطيل مرئي بالفعل في هذا العرض التقديمي البسيط، لذا قد لا ينتج عن التعيين تغيير بصري واضح بمفرده. هذه العملية مفيدة كجزء من تأثير أكبر يتحكم أيضًا متى يصبح الشكل مخفيًا أو مرئيًا.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **أمر**

استخدم [create_command_effect] وقم بتكوين [type]، [command_string]، و [shape_target]. ضع تسجيل WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال التسجيل باستخدام [add_audio_frame_embedded] وي attaches أمر تشغيل إلى إطار الصوت.

إطار الصوت هو هدف كل من التأثير والأمر. يربط ذلك طلب التشغيل بالتسجيل المدمج؛ السلسلة الأمرية وحدها لا تحدد أي كائن وسائط يتحكم فيه. يُضبط التأثير للبدء عند النقر خلال عرض الشرائح.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

يحفظ الحفظ الأمر في `command.pptx`؛ ولا يشغل التسجيل. يتطلب تشغيله مشغل عروض شرائح يدعم الأمر وهدف وسائطه.

## **إدارة مجموعة السلوكيات**

[BehaviorCollection] تدعم [add]، [insert]، [remove]، و [remove_at]. يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله قبل الدوران، ويزيل الدوران. حذف وإعادة إدراج نفس الكائن يغيّر موقعه المخزن دون إنشاء نسخة.

تغيّر سلسلة التعديلات المجموعة من دوران–تحجيم إلى تحجيم–دوران، ثم إلى تحجيم فقط. تشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة فهرس الدوران الجديد بعد إعادة الترتيب. يؤكد التعداد النهائي أي سلوك سيُحفظ.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

الناتج هو `ScaleEffect`: يبقى فقط التحجيم. ترتيب المجموعة لا يحدد، بحد ذاته، جدولة السلوكيات واحدةً بعد الأخرى. امسح المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

[Behavior.timing] يكشف عن [Timing]، مستقلاً عن [Effect.timing]. يحدد توقيت التأثير الجدول الزمني للتأثير المحيط؛ يصف توقيت السلوك عملية داخل ذلك.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` وحدد [duration] و [trigger_delay_time] بالثواني، ثم اضبط [repeat_count]. [accelerate] و [decelerate] هما أجزاء من المدة؛ احرص على أن لا يتجاوز مجموعهما 1.

الملف المدخل هو الملف الذي أنشئ في مثال الدوران، حيث يُعرف أن السلوك الأول هو دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ يظل زاوية 90 درجة كما هي. إبقاء الزاوية والتوقيت منفصلين يُسهل تعديل الوتيرة دون إعادة بناء الحركة.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

يستخدم السلوك مدة ثانيتين، تأخير نصف ثانية، وتكرار 3 مرات. تُستغل النسبتين الأخيرتين 20% من مدته للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [repeat_duration]، [repeat_until_end_slide]، و [repeat_until_next_click]؛ اختر سياسةً واحدةً بدلاً من تفعيلها جميعًا معًا. [auto_reverse] يشغل الحركة عكسيًا بعد المرور الأمامي. يُطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [create_motion_effect] لإنشاء حركة. توضح [from_address]، [to]، و [by] إحداثيات أو إزاحات قائمة على النسبة المئوية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath] وعيّنه إلى [MotionEffect.path]. يخزن [MotionPath] أوامر المسار.

[MotionCommandPathType] يحدد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MOVE_TO | One | تعيين موضع البدء. |
| LINE_TO | One | التحرك على قطعة مستقيمة إلى نقطتها النهائية. |
| CURVE_TO | Three | اتباع منحنى ثلاثي الحدّ مع نقطتي تحكم ونقطة نهائية. |
| CLOSE_LOOP | None | العودة إلى موضع البدء. |
| END | None | إنهاء المسار. |

[MotionPathPointsType] يصف خصائص تحرير النقاط، مثل نقاط الزاوية أو السلسة. لا يستبدل نوع الأمر. استخدم نوع نقطة منحنى للمثال المنحني أدناه، ونوع نقطة زاوية للقطاعات المستقيمة.

إحداثيات المسار مُعيرة إلى أبعاد الشريحة: إزاحة X قدرها 0.25 تمثل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجب يتجه للأسفل. الأوامر المطلقة تحدد المواقع في نظام إحداثيات المسار؛ الأوامر النسبية تحدد إزاحات من الموقع الحالي. هذا منفصل عن [origin] الذي يختار إطار مرجع المسار، و [path_edit_mode] الذي يتحكم في حركة المسار عند نقل الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، قطعة مستقيمة واحدة، وأمر انتهاء. يأخذ [MotionPath.add] نوع الأمر، نقاطه، نوع النقطة، وعلامة إحداثيات نسبية.

يحدد الأمر الابتدائي (0, 0)، وتنتهي الخط إلى (0.25, 0)، مما يعطي المسار إزاحة أفقية ربع عرض الشريحة. لا يحتوي أمر النهاية على نقاط إحداثية. بمجرد تعيين المسار، يربط إضافة سلوك الحركة إلى التأثير ذلك المسار بالمستطيل.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` يحتوي على سلوك حركة واحد بثلاث أوامر مسار. تُستخدم أمثلة تحرير الملف التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان كائكان للمسار يصفان نفس المسار. الأمر المطلق ينتهي عند (0.3, 0.1)؛ الأمر النسبي يضيف (0.1, 0.1) إلى الموقع الحالي، (0.2, 0).

كلا المسارين يبدأان من نفس الموقع. للخط النسبي، أضف إزاحة X وY إلى الموقع الحالي للحصول على نقطة النهاية؛ للخط المطلق، اقرأ نقطة النهاية مباشرة. تغيير العلامة دون تحويل الإحداثيات سيصف مسارًا مختلفًا.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

عيّن أي مسار إلى سلوك حركة لاستخدامه في عرض تقديمي. تُحدد الوسيطة البوليانية النهائية الإحداثيات النسبية لهذا الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى ثلاثي الحدّ. قدِّم نقطتي التحكم أولاً، ثم نقطة النهاية.

توفر الأمر السابق الموضع الابتدائي. تشكّل النقطتان الأوليان المنحنى، بينما الثالثة هي وجهته؛ ليست ثلاث وجهات متتالية. تحديث نوع الأمر، نوع تحرير النقاط، ومصفوفة النقاط معًا يحافظ على تناسق القطعة مع هندستها الجديدة.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

المسار في `curve.pptx` لا يزال يحتوي على ثلاثة أوامر؛ يأمره الأوسط الآن بتعريف منحنى.

## **فحص وتحرير مسار محفوظ**

كل [MotionCmdPath] يكشف عن [points]، [command_type]، [points_type]، و [is_relative]. تستخدم الأمثلة التالية المسار المعروف ذو الثلاث أوامر في `motion.pptx`. للمدخلات العشوائية، حدّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير بحسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. أوامر النهاية وإغلاق الحلقة لا تحتاج إلى نقاط، لذا استعد لمصفوفة نقاط `None`.

تُظهر النتيجة كل أمر مع علم الإحداثيات النسبية قبل سرد نقاطه. يتيح لك ذلك تمييز نقطة النهاية عن إزاحة قبل تعديل المسار. سيعرض المنحنى ثلاث نقاط، بينما السطر المستقيم في هذا الملف يعرض نقطة واحدة فقط.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

القائمة تحتوي على نقطة بداية، خط مطلق ينتهي عند (0.25, 0)، وأمر انتهاء.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في الملف المدخل، الفهرس 0 هو الأمر الابتدائي والفهرس 1 هو الخط. استبدال النقطة الوحيدة للخط يغيّر وجهته دون تغيير نوع الأمر أو توقيته أو موقعه في المجموعة. لأن الأمر يستخدم إحداثيات مطلقة، تُحدد الزوج الجديد موقعًا بدلاً من إزاحة مضافة.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

الخط في `motion-endpoint.pptx` ينتهي عند (0.4, 0.1)؛ الملف الأصلي لم يتغير.

### **استبدال جزء**

استخدم [insert] و [remove_at] لاستبدال الخط في `motion.pptx`. يسبب الإدراج إزاحة الخط القديم إلى الفهرس 2.

يُظهر هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على الأمر الابتدائي، الخط الجديد، الخط القديم، وأمر النهاية. حذف الفهرس 2 يُزيل الخط القديم ويترك المسار الجديد في مكانه.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

المسار المحفوظ لا يزال يحتوي على ثلاثة أوامر، مع الخط الجديد ينتهي عند (0.2, 0.1) وأمر النهاية في الأخير.

## **تعديل والتحقق من سلوك موجود**

عند عدم معرفة فهرس السلوك، حدده حسب النوع. يفتح هذا المثال `rotation.pptx`، يجد [RotationEffect]، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يسمح فحص النوع للّوب بتخطي السلوكيات التي ليست دورانات. التحميل الثاني يقرأ الملف المحفوظ في كائن عرض تقديمي منفصل، لذا يقارن البيانات المُستقرة بدلاً من القيمة الموجودة في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في السلسلة الرئيسية؛ اختيار سلوك حسب النوع لا يحدّد التأثير الصحيح في عرض تقديمي عشوائي.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

الناتج هو `Rotation preserved: True`. طبق نمط فحص النوع نفسه على سلوكيات أخرى. للتحقق الكامل من الحفظ، قارن شكل الهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم سم tolerance رقمي للقيم العائمة. لعرض تقديمي مع تخطيط رسوم متحركة غير معروف، راجع [Read Shape Animations](/slides/ar/python-net/shape-animation/#read-shape-animations) لتجوال السلاسل الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [BehaviorCollection] هو الترتيب المخزن لعمليات التأثير. ليس قائمة تشغيل ينتظر فيها كل سلوك تلقائيًا السلوك السابق. يحدد التوقيت والتأثير المحيط الجدولة. يمكن للسلوكيات التداخل، وتفاعل العمليات على نفس الخاصية قد يحدث عبر [additive] و [accumulate]. لا تستخدم إعادة ترتيب المجموعة وحدها لجدولة “تحريك، ثم تدوير”؛ استخدم توقيتًا صريحًا أو تأثيرات منفصلة كما هو موضح في [Shape Animation](/slides/ar/python-net/shape-animation/).

يصف [type] و [subtype] الخاص بالتأثير الإعداد المسبق. ليسا وصفًا كاملاً لشجرة سلوكيات محررة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: تغيير الإعداد المسبق قد يُعيد بناء المجموعة ويُهمل عملياتك المخصصة. على سبيل المثال، تغيير تأثير Spin مخصص إلى Fade قد يستبدل سلوك الدوران بسلوكيات تعيين ومستخلص. افحص المجموعة مرة أخرى بعد تغيير الإعداد المسبق أو النوع الفرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد. تستخدم الأمثلة بشكل متعمد أشكالًا مرئية وتستبدل السلوكيات؛ لا يعيدون بناء تنفيذ كل إعداد مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متطابقًا في كل عارض أو مُصدّر. تحقق من البيانات المحفوظة والمخرجات المرسومة بشكل منفصل.

| الصيغة أو الإخراج | ما الذي يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية لهذه الأمثلة. أعد فتحها لتتحقق من شجرة السلوك القابلة للتحرير، ثم اختبر التشغيل في نسخة PowerPoint المستهدفة. |
| PPT | قد يختلف تمثيل الثنائي القديم عن PPTX. اختبر دورة حفظ-إعادة فتح منفصلة وتشغيلها؛ لا تستنتج الدعم لكل تركيبة مخصصة من نجاح إخراج PPTX. |
| PDF, PNG, JPEG، وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل ثابت للشفرة، ليس مسار سلوك قابل للعب أو إطار نهائي للرسوم المتحركة. |
| [HTML5](/slides/ar/python-net/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما تكون رسوم الشكل مفعلة في خيارات التصدير. اختبر التركيبات المخصصة في المتصفح. |
| [Animated GIF](/slides/ar/python-net/convert-powerpoint-to-animated-gif/) | يخزن الإطارات المرسومة، لا السلوكيات القابلة للتحرير أو التفاعل عبر النقر. تحقق من الحركة المرسومة فعليًا. |
| [Video](/slides/ar/python-net/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويُشفرها كفيديو. الدعم محدود إلى [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/python-net/convert-powerpoint-to-video/#supported-animations-and-effects)؛ لا تتحول الأوامر والأحداث التفاعلية إلى جدول زمني قابل للتحرير. |

## **الأسئلة المتكررة**

**لماذا يحتوي تأثيري على سلوكيات قبل أن أضيف أي شيء؟**

إنشاء تأثير معرف مسبقًا قد يُنشئ عملياته الأساسية. افحصها قبل أن تقرر ما إذا كنت ستمد الإعداد المسبق أو تستبدل سلوكياته.

**هل جعل سلوك في البداية يجعله يُشغل أولًا؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلًا عن التوقيت. تحقق من التأخيرات، المدد، والتفاعلات بين العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر النهاية على نقاط؟**

يُشير إلى نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط `None` عند فحص مسار مقروء من ملف.

**هل رحلة ذهابًا وإيابًا ناجحة كافية لتأكيد التشغيل؟**

لا. إعادة الفتح تؤكد حفظ الخصائص التي فحصتها. اختبر مشغل عروض الشرائح أو التصدير المتحرك بشكل منفصل لتأكيد سلوكه البصري.