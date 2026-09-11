---
title: تطبيق حركات الأشكال في العروض باستخدام Python عبر Java
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/python-java/shape-animation/
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
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة، فحص، وتخصيص حركات الأشكال، التوقيت، الأصوات، سلوك ما بعد الحركة، والنص المتحرك باستخدام Aspose.Slides لPython عبر Java."
---
## **نظرة عامة**

Aspose.Slides for Python via Java تمثل حركات الشرائح كـ تأثيرات في خط زمني للشرائح. لكل تأثير شكل مستهدف، نوع حركة فرعي، مشغل، إعدادات توقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الحركة.

يحتوي الخط الزمني على نوعين من السلاسل:

- **السلسلة الرئيسية** تُشغل عندما تتقدم الشريحة.
- **السلسلة التفاعلية** تبدأ عندما يُنقر على الشكل المشغل.

نظرًا لأن صناديق النصوص، الصور، المخططات، الجداول، وغيرها من كائنات الشريحة تُشتق من [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، يمكنك استخدام نفس طريقة [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في الفئة [EffectType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttype/) .

## **إضافة حركات الشكل**

لإضافة حركة، احصل على السلسلة الرئيسية للشرحة واستدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) مع الشكل المستهدف، نوع التأثير، النوع الفرعي، والمشغل. لتأثير يبدأ عندما يُنقر على شكل آخر، أنشئ سلسلة تفاعلية تكون مشغلها ذلك الشكل الآخر.

المثال التالي ينشئ كلا نوعي الحركات ويحفظ النتيجة في `shape-animations.pptx`.

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

المشغل يتحكم متى يبدأ التأثير:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#OnClick) ينتظر نقرة في السلسلة الرئيسية، أو نقرة على الشكل المشغل في سلسلة تفاعلية.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو مخطط أو أي نوع شكل آخر، مرّر ذلك الكائن إلى [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) بدلاً من `target_shape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [Animated Charts](/slides/ar/python-java/animated-charts/).

## **قراءة حركات الشكل**

استخدم [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#getEffectsByShape) عندما تعرف الشكل المستهدف. لتفقد كل تأثير، عدّ السلسلة الرئيسية وكل سلسلة تفاعلية. العد يمنع الافتراض بأن السلسلة تحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً يحتوي على تأثيرات في السلسلة الرئيسية وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدّ كل سلسلة على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدّد الشكل أولاً بالاسم أو نوع العنصر النائب أو خاصية ثابتة أخرى؛ ثم استدعِ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#getEffectsByShape). لا تفترض أن [ShapeCollection.get_Item](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#get_Item) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العناصر النائبة الموروثة**

يمكن للعنصر النائب في شريحة عادية أن يرث سلوك الحركة من العنصر النائب المقابل في شريحة التخطيط والشريحة الرئيسية. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) تُعيد ذلك العنصر النائب الأب، أو `None` إذا لم يكن هناك أب.

في عرض المثال التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، **Split** في شريحة التخطيط، و**Fly In** في الشريحة الرئيسية.

![تأثير حركة التذييل في الشريحة العادية](slide-shape-animation.png)

![تأثير حركة العنصر النائب للتذييل في شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة العنصر النائب للتذييل في الشريحة الرئيسية](master-shape-animation.png)

المثال التالي يستخدم تسلسل هرمي للعناصر النائبة من عرض جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، عنصر نائب تخطيط، والعنصر النائب المقابل في شريحة عادية. كل استدعاء لـ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) يتم التحقق منه قبل استخدام الشكل المعاد.

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

## **تغيير توقيت الحركة**

حوار **Timing** في PowerPoint يطابق خصائص [Timing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/).

![حوار توقيت PowerPoint لتأثير حركة](shape-animation.png)

- **Start** يطابق [Timing.getTriggerType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** يطابق [Timing.getDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getDuration)، بالثواني.
- **Delay** يطابق [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getTriggerDelayTime)، بالثواني.
- **Repeat** يطابق [Timing.getRepeatCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilNextClick)، أو [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** يطابق [Timing.getRewind](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#getRewind).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المعاد من [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect)، ويحفظ النتيجة. الحفاظ على مرجع [Effect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/) المعاد يمنع الحاجة إلى فهرس مجموعة غير ضروري.

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

استخدم وضع تكرار واحد عمدًا. الجمع بين عدد التكرار وعلم "until" يمكن أن ينتج نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatUntilNextClick) و [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) قبل [Timing.setRepeatCount](https://reference.aspose.com/slides/ar/python-java/aspose.slides/timing/#setRepeatCount)، لأن ضبط أي علم يغيّر وضع التكرار النشط.

## **إضافة واستخراج أصوات الحركات**

يمكن لتأثير الحركة أن يشير إلى صوت مدمج عبر [Effect.getSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#setStopPreviousSound) يخبر التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوتي محلي اسمه `animation-sound.wav`. يخلق تأثيرين، يدمج هذا الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المعادة من [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect)، لذا لا حاجة إلى فهرس السلسلة.

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

### **استخراج أصوات التأثيرات المدمجة**

المثال التالي يتوقع عرضًا محليًا اسمه `presentation-with-animation-sounds.pptx`. يفحص كل من السلاسل الرئيسية والتفاعلية ويكتب كل صوت تأثير مدمج إلى المجلد `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي الذي تعطيه [Audio.getContentType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audio/#getContentType).

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

للملفات الصوتية الكبيرة، استخدم [Audio.getStream](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audio/#getStream) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الحركة**

الخيار **After animation** يتحكم فيما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

الفئة [AfterAnimationType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/) تدعم ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الحركة، أو إخفائه عند النقر التالي. عندما يكون النوع [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/#Color)، اضبط أيضًا [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getAfterAnimationColor).

هذا المثال المستقل ينشئ تأثيرًا، يحدد سلوك ما بعد الحركة عبر كائن التأثير المعاد، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/python-java/aspose.slides/afteranimationtype/#Color) يمسح إعداد لون ما بعد الحركة.

## **تحريك النص**

تحريك النص يحتوي على تحكمين مرتبطين:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textanimation/#getBuildType) يتحكم فيما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getAnimateTextType) يتحكم فيما إذا كان النص يظهر دفعة واحدة، كلمةً بكلمة، أو حرفًا بحرف. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/effect/#getDelayBetweenTextParts) يحدد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة التأثير؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات في مربع نص. [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/buildtype/#AsOneObject) يعطل بناء الفقرة‑بـ‑فقرة بحيث يُطبق إعداد الكلمة على كامل إطار النص.

```python
import jpype
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

لبناء مربع نص وفقًا للفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص بها، استخدم نسخة [Sequence.addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) التي تقبل كائن [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/). راجع [Animated Text](/slides/ar/python-java/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- حفظ إلى PPT أو PPTX يحافظ على نموذج الحركة، لكن تشغيله النهائي يتحكم به عارض العرض.
- PDF والصور الثابتة لا تشغل الحركات. استخدم [HTML5 export](/slides/ar/python-java/export-to-html5/)، GIF متحرك، أو [video conversion](/slides/ar/python-java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة في الناتج.
- في HTML5، فعّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateShapes) وعند الحاجة، [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/html5options/#setAnimateTransitions).
- rendering الفيديو يدعم العديد من تأثيرات الدخول، التشديد، الخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير في PowerPoint مدعوم. راجع [supported animations and effects](/slides/ar/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض أخرى قد تُحفظ في الملف لكن تُظهر بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا يظهر تأثير في PowerPoint لكنه لا يظهر في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغل الحركات وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُشغل تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الحركات بدلاً من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو يتم تقريبها. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل نقل الشكل إلى الأمام أو الخلف يغيّر ترتيبه في الحركة؟**

لا. ترتيب الـ z للشكل يتحكم في التراكب، بينما ترتيب السلسلة والمشغلات يتحكمان في تشغيل الحركة. غير الخط الزمني إذا كنت تحتاج إلى ترتيب تشغيل مختلف.