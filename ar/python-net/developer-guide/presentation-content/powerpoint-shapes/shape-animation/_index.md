---
title: تطبيق حركات الأشكال في العروض التقديمية باستخدام بايثون
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/python-net/shape-animation/
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
- تطبيق الحركة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة، فحص، وتخصيص حركات الأشكال، التوقيت، الأصوات، سلوك ما بعد الحركة، والنص المتحرك باستخدام Aspose.Slides for Python عبر .NET."
---
## **نظرة عامة**

يمثل Aspose.Slides for Python via .NET حركات الشرائح كآثار في جدول زمني للشريحة. يحتوي كل أثر على شكل هدف، نوع حركة وفرعي، مشغّل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الحركة.

يتضمن الجدول الزمني نوعين من التسلسلات:

- **التسلسل الرئيسي** يُشغّل عندما تتقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على شكل المشغّل الخاص به.

نظرًا لأن مربعات النص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة تنفّذ [IShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ishape/)، يمكنك استخدام نفس طريقة [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttype/).

## **إضافة حركات الشكل**

لإضافة حركة، احصل على التسلسل الرئيسي للشرائح واستدعِ [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/) مع شكل الهدف، نوع التأثير، النوع الفرعي، والمشغّل. لتأثير يبدأ عند النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون مشغّله ذلك الشكل الآخر.

المثال التالي ينشئ كلا نوعي الحركة ويحفظ النتيجة في `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

المشغّل يتحكم في وقت بدء التأثير:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttriggertype/) ينتظر النقر في التسلسل الرئيسي، أو النقر على الشكل المشغّل في التسلسل التفاعلي.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttriggertype/) يبدأ مع التأثير السابق.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effecttriggertype/) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة، مخطط، أو نوع آخر من الأشكال، مرّر ذلك الكائن إلى [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/) بدلاً من `target_shape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [Animated Charts](/slides/ar/python-net/animated-charts/).

## **قراءة حركات الشكل**

استخدم [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) عندما تعرف شكل الهدف. لتفقد كل تأثير، كرّر عبر التسلسل الرئيسي وكل تسلسل تفاعلي. التكرار يمنع الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلًا مع تأثيرات في التسلسل الرئيسي وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يكرّر عبر كل تسلسل في الشريحة.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). لا تفترض أن الشكل في الفهرس `0` هو دائمًا الكائن المقصود.

## **التعامل مع تأثيرات العنصر النائب الموروثة**

يمكن للعنصر النائب في شريحة عادية أن يرث سلوك الحركة من العنصر النائب المقابل في شريحة التخطيط والشريحة الرئيسية. تُعيد [Shape.get_base_placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_base_placeholder/) ذلك العنصر النائب الأب، أو `None` إذا لم يكن هناك أب.

في عرض الشرائح المثال التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، **Split** في شريحة التخطيط، و**Fly In** في الشريحة الرئيسية.

![تأثير حركة التذييل في الشريحة العادية](slide-shape-animation.png)
![تأثير حركة عنصر نائب للتذييل في شريحة التخطيط](layout-shape-animation.png)
![تأثير حركة عنصر نائب للتذييل في الشريحة الرئيسية](master-shape-animation.png)

المثال التالي يبني هيكلية العنصر النائب نفسها. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب في التخطيط، والعنصر النائب المقابل في شريحة عادية. يتم فحص كل استدعاء لـ [Shape.get_base_placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_base_placeholder/) قبل استخدام الشكل المُرجع.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير توقيت الحركة**

يتطابق مربع حوار **Timing** في PowerPoint مع خصائص [Timing](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/).

![مربع حوار توقيت PowerPoint لتأثير حركة](shape-animation.png)

- **ابدأ** يتطابق مع [Timing.trigger_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/trigger_type/).
- **المدة** يتطابق مع [Timing.duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/duration/)، بالثواني.
- **التأخير** يتطابق مع [Timing.trigger_delay_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/trigger_delay_time/)، بالثواني.
- **التكرار** يتطابق مع [Timing.repeat_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_count/)، [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_until_next_click/)، أو [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **إعادة التشغيل عند الانتهاء** يتطابق مع [Timing.rewind](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/rewind/).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المُرجع من [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/)، ويحفظ النتيجة. الاحتفاظ بمرجع [Effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/) المُرجع يتجنب فهرس تجميع غير ضروري.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

استخدم وضع تكرار واحد عمدًا. الجمع بين عدد التكرار وعلمية "حتى" قد ينتج نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing.repeat_until_next_click](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_until_next_click/) و[Timing.repeat_until_end_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) قبل [Timing.repeat_count](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/timing/repeat_count/)، لأن ضبط أي من العلمتين يغير وضع التكرار النشط.

## **إضافة واستخراج أصوات الحركة**

يمكن لتأثير الحركة الإشارة إلى صوت مدمج عبر [Effect.sound](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/sound/). يُخبر [Effect.stop_previous_sound](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/stop_previous_sound/) تأثيرًا بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوت محلي باسم `animation-sound.wav`. ينشئ تأثيرين، يدمج ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المُرجعة من [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/)، لذا لا يلزم فهرس تسلسل.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج أصوات التأثير المدمجة**

المثال التالي يتوقع عرضًا محليًا باسم `presentation-with-animation-sounds.pptx`. يقوم بفحص كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت تأثير مدمج إلى الدليل `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي المعروض بواسطة [Audio.content_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

للكائنات الصوتية الكبيرة، استخدم [Audio.get_stream](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audio/get_stream/) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تحديد سلوك ما بعد الحركة**

خيار **After animation** يتحكم ماذا يحدث للشكل بعد انتهاء تأثيره.

![مربع حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

يدعم تعداد [AfterAnimationType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/afteranimationtype/) ترك الشكل كما هو، تغيير لونه، إخفاؤه بعد الحركة، أو إخفاؤه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/afteranimationtype/), اضبط أيضًا [Effect.after_animation_color](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/after_animation_color/).

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوكه ما بعد الحركة عبر كائن التأثير المُرجع، ويحفظ النتيجة.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

تغيير النوع بعيدًا عن [AfterAnimationType.COLOR](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/afteranimationtype/) يمسح إعداد لون ما بعد الحركة.

## **تحريك النص**

تحريك النص يحتوي على تحكمين مرتبطين:

- [TextAnimation.build_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/textanimation/build_type/) يتحكم فيما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [Effect.animate_text_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/animate_text_type/) يتحكم فيما إذا كان النص يظهر دفعة واحدة، بالكلمة، أو بالحرف. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/effect/delay_between_text_parts/) يحدد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ القيمة السلبية هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات في مربع نص. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/buildtype/) يعطل بناء الفقرة بفقرة بحيث ينطبق إعداد الكلمة على كامل إطار النص.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

لبناء مربع نص وفقًا للفقرة، اضبط [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/buildtype/) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثيرها الخاص، استخدم نسخة [Sequence.add_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.animation/sequence/add_effect/) التي تقبل [IParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iparagraph/). راجع [Animated Text](/slides/ar/python-net/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ إلى PPT أو PPTX يحافظ على نموذج الحركة، لكن تشغيله النهائي يتحكم فيه عارض العرض.
- لا تقوم ملفات PDF والصور الثابتة بتشغيل الحركات. استخدم [تصدير HTML5](/slides/ar/python-net/export-to-html5/)، GIF متحرك، أو [تحويل للفيديو](/slides/ar/python-net/convert-powerpoint-to-video/) عندما يجب أن يظهر الناتج الحركة.
- بالنسبة إلى HTML5، فعل [Html5Options.animate_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/html5options/animate_shapes/), وعند الحاجة، [Html5Options.animate_transitions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/html5options/animate_transitions/).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من [الرسوم المتحركة المدعومة والتأثيرات](/slides/ar/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض أخرى في الملف، لكنها تُعرض بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا تظهر حركة في PowerPoint ولكن ليس في PDF؟**

PDF هو تنسيق ثابت، لذلك لا تُشغَّل الحركات وانتقالات الشرائح. صدِّر إلى HTML5، GIF متحرك، أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُشغَّل تأثير بشكل مختلف في الفيديو؟**

يُعيد تصدير الفيديو رسم الحركات بدلاً من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو تُقَرَّب. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل يؤثر نقل الشكل للأمام أو للخلف على ترتيب حركته؟**

لا. يتحكم ترتيب z للشكل في التداخل، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الحركة. غيّر الجدول الزمني إذا كنت بحاجة إلى ترتيب تشغيل مختلف.