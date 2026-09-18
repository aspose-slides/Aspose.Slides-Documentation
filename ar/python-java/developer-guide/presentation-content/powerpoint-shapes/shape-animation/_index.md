---
title: تطبيق رسوم متحركة للأشكال في العروض التقديمية باستخدام Python عبر Java
linktitle: رسوم متحركة للأشكال
type: docs
weight: 60
url: /ar/python-java/shape-animation/
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
- Java
- Aspose.Slides
description: "تعرف على كيفية إضافة، وفحص، وتخصيص رسوم متحركة للأشكال، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides للغة Python عبر Java."
---
## **نظرة عامة**

للعمل مع السلوكيات الفردية داخل التأثير أو تعديل أقسام مسار الحركة، راجع [الرسوم المتحركة المخصصة](/slides/ar/python-java/custom-animation/).

يمثل Aspose.Slides for Python عبر Java الرسوم المتحركة للشرائح كـ Effects في خط زمني للشرائح. يحتوي Effect على شكل هدف، ونوع ورسوم متحركة فرعية، ومحفّز، وإعدادات توقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

يحتوي الخط الزمني على نوعين من التسلسلات:

- **التسلسل الرئيسي** يُشغَل مع تقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على شكل المحفّز الخاص به.

نظرًا لأن صناديق النصوص والصور والمخططات والجداول وغيرها من كائنات الشريحة تستمد من [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، تستخدم طريقة [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) نفسها لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في فئة [EffectType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttype/).

## **إضافة رسوم متحركة للأشكال**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشفرة واستدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) مع شكل الهدف، ونوع التأثير، والنوع الفرعي، والمحفّز. بالنسبة لتأثير يبدأ عند النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون محفّزه ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الرسوم المتحركة ويحفظ النتيجة في `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المحفّز يتحكم بموعد بدء Effect:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#OnClick) ينتظر النقر في التسلسل الرئيسي، أو النقر على شكل المحفّز في تسلسل تفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو أي نوع شكل آخر، مرّر ذلك الكائن إلى [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) بدلاً من `target_shape`. لخيارات تجميع خاصة بالمخططات، راجع [الرسوم المتحركة للمخططات](/slides/ar/python-java/animated-charts/).

## **قراءة رسوم متحركة للأشكال**

استخدم [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#getEffectsByShape) عندما تعرف الشكل الهدف. لتفحص كل Effect، عدّ التسلسل الرئيسي وكل تسلسل تفاعلي. العد يضمن عدم افتراض وجود Effect في الفهرس `0`.

المثال التالي ينشئ شكلًا يحتوي على Effects في التسلسل الرئيسي والتفاعلي، يحصل على Effects التي تستهدف الشكل، ثم يعدّ كل التسلسلات على الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

إذا كنت تحتاج فقط Effects لشكل واحد، حدد الشكل أولًا بالاسم أو نوع العنصر النائب أو أي خاصية ثابتة أخرى؛ ثم استدعِ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#getEffectsByShape). لا تفترض أن [ShapeCollection.get_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#get_Item) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن لعنصر نائب على شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل على شريحة التخطيط وشريحة القالب. تُعيد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) ذلك العنصر النائب الأصلي، أو `None` إذا لم يكن هناك أصل.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** على الشريحة العادية، و**Split** على شريحة التخطيط، و**Fly In** على شريحة القالب.

![تأثير حركة التذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة القالب](master-shape-animation.png)

المثال التالي يستخدم هيكلية عناصر نائب من عرض تقديمي جديد. يضيف Effects إلى عنصر نائب القالب، وعنصر نائب التخطيط، والعنصر النائب المقابل على شريحة عادية. يتم التحقق من كل استدعاء لـ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) قبل استخدام الشكل المرتجع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير توقيت الرسوم المتحركة**

يطابق مربع حوار PowerPoint **Timing** خصائص [Timing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/).

![مربع حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يطابق [Timing.getTriggerType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** يطابق [Timing.getDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getDuration) بالثواني.
- **Delay** يطابق [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getTriggerDelayTime) بالثواني.
- **Repeat** يطابق [Timing.getRepeatCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatCount)، أو [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilNextClick)، أو [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** يطابق [Timing.getRewind](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRewind).

هذا المثال المستقل يضيف Effect، يغيّر توقيته عبر الكائن المرتجع من [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect)، ويحفظ النتيجة. الحفاظ على مرجع [Effect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/) المرتجع يجنّب فهرس مجموعة غير ضروري.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

استخدم وضع تكرار واحد فقط بنية. دمج عدد تكرارات مع علامة "until" قد ينتج عنه نتائج مربكة في مشغّلات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatUntilNextClick) و[Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) قبل [Timing.setRepeatCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatCount)، لأن ضبط أي علامة يغيّر وضع التكرار النشط أيضًا.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة أن يشير إلى صوت مضمّن عبر [Effect.getSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getSound). تُخبر [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#setStopPreviousSound) التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى Effect**

المثال التالي يتوقع ملف صوتي محلي اسمه `animation-sound.wav`. ينشئ تأثيرين، يضمّن ذلك الملف كصوت للتأثير الأول، ويُكوّن التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect)، لذا لا يُحتاج إلى فهرس تسلسل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استخراج أصوات Effects المضمّنة**

المثال التالي يتوقع عرض تقديمي محلي اسمه `presentation-with-animation-sounds.pptx`. يمسح كل من التسلسلات الرئيسية والتفاعلية ويكتب كل صوت Effect مضمّن إلى الدليل `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي الذي يُعيده [Audio.getContentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

للكائنات الصوتية الكبيرة، استخدم [Audio.getStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audio/#getStream) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم بما يحدث للشكل بعد انتهاء Effect.

![مربع حوار خيارات Effect في PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

تدعم فئة [AfterAnimationType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/) ترك الشكل دون تغيير، أو تغيير لونه، أو إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/#Color)، اضبط أيضًا [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getAfterAnimationColor).

هذا المثال المستقل ينشئ Effect، يعيّن سلوك ما بعد الرسوم المتحركة عبر كائن Effect المرتجع، ويحفظ النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/#Color) يُزيل إعداد لون ما بعد الرسوم المتحركة.

## **تحريك النص**

لتحريك النص تحكمان مرتبطان:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textanimation/#getBuildType) يحدد ما إذا كانت الفقرات تظهر معًا أو مستوى بالفقرة.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getAnimateTextType) يحدد ما إذا كان النص يظهر مرة واحدة، كلمةً كلمةً، أو حرفًا بحرف. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getDelayBetweenTextParts) يضبط التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة Effect؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل مربع نص. [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/buildtype/#AsOneObject) يلغِي بناء الفقرة بفقرة بحيث يُطبّق إعداد الكلمة على الإطار النصي بأكمله.

```python
import jpace
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لبناء مربع نص فقرةً بفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لتوجيه فقرة واحدة بتأثيرها الخاص، استخدم نسخة [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) التي تقبل كائنًا من نوع [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/). راجع [النص المتحرك](/slides/ar/python-java/animated-text/) لأمثلة على مستوى الفقرة.

## **التصدير وملاحظات التوافق**

- حفظ إلى PPT أو PPTX يحافظ على نموذج الرسوم المتحركة، لكن تشغيله النهائي يتحكم فيه عارض العرض.
- لا تقوم ملفات PDF والصور الثابتة بتشغيل الرسوم المتحركة. استخدم [تصدير HTML5](/slides/ar/python-java/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/python-java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- لـ HTML5، فعل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) وعند الحاجة [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من [الرسوم المتحركة والتأثيرات المدعومة](/slides/ar/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحفظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف ولكن تُعرض بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة الشائعة**

**لماذا يظهر تأثير الرسوم المتحركة في PowerPoint لكنه غير ظاهر في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغَل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب حفظ الحركة.

**لماذا يُشغَل Effect بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلاً من تخزين السلوك الأصلي من PowerPoint. بعض التأثيرات المتقدمة غير مدعومة أو مُقربة. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل يغيّر نقل شكل للأمام أو للخلف ترتيب رسوماته المتحركة؟**

لا. يتحكم ترتيب Z للشكل في التراكب، بينما يتحكم ترتيب التسلسل والمحفّزات في تشغيل الرسوم المتحركة. غيّر الخط الزمني إذا كنت بحاجة إلى ترتيب تشغيل مختلف.