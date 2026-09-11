---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از Python از طریق Java
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/python-java/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدا افکت
- اعمال انیمیشن
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس‌از‑انیمیشن و متن‌های انیمیشنی را با Aspose.Slides برای Python از طریق Java اضافه، بررسی و سفارشی‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via Java نمایانگر انیمیشن‌های اسلاید به‌عنوان افکت‌ها در جدول زمانی اسلاید است. یک افکت شامل یک شکل هدف، نوع و زیرنوع انیمیشن، یک تحریک‌کننده، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- **دنباله تعاملی** زمانی شروع می‌شود که شکل تحریک‌کننده‌اش کلیک شود.

چون جعبه‌های متن، تصاویر، نمودارها، جداول و سایر اشیای اسلاید از کلاس [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث می‌برند، برای اکثر محتوای اسلاید از همان متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) استفاده می‌کنید. افکت‌های موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن‌های شکل**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و با متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) شکل هدف، نوع افکت، زیرنوع و تحریک‌کننده را پاس دهید. برای افکتی که با کلیک روی شکل دیگر شروع می‌شود، یک دنباله تعاملی ایجاد کنید که تحریک‌کننده آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد کرده و نتیجه را در فایل `shape-animations.pptx` ذخیره می‌کند.

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

تحریک‌کننده تعیین می‌کند که افکت کی شروع شود:

- `EffectTriggerType.OnClick` برای کلیک در دنباله اصلی یا برای کلیک بر روی شکل تحریک‌کننده در دنباله تعاملی انتظار می‌کشد.
- `EffectTriggerType.WithPrevious` با افکت قبلی شروع می‌شود.
- `EffectTriggerType.AfterPrevious` پس از اتمام افکت قبلی آغاز می‌گردد.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، آن شیء را به‌جای `target_shape` به متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودار، به [Animated Charts](/slides/fa/python-java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

زمانی که شکل هدف را می‌دانید، از [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#getEffectsByShape) استفاده کنید. برای بررسی هر افکت، دنباله اصلی و تمام دنباله‌های تعاملی را پیمایش کنید. پیمایش از این‌که فرض کنید دنباله‌ای در شاخص `0` حتماً افکتی دارد جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های دنباله اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به شکل را دریافت می‌کند و سپس تمام دنباله‌های اسلاید را پیمایش می‌کند.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع محل‌نگهدار یا ویژگی ثابت دیگر شناسایی کنید؛ سپس [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#getEffectsByShape) را فراخوانی کنید. فرض نکنید که [ShapeCollection.get_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#get_Item) در شاخص `0` همیشه شیء موردنظر است.

## **کار با افکت‌های مکان‌نگهدار ارث‌برده‌شده**

یک مکان‌نگهدار در اسلاید عادی می‌تواند رفتار انیمیشنی خود را از مکان‌نگهدار متناظر در اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) آن مکان‌نگهدار والد را برمی‌گرداند یا `None` وقتی والد وجود نداشته باشد.

در ارائه نمونه زیر، فوتر دارای **Random Bars** در اسلاید عادی، **Split** در اسلاید طرح‌بندی و **Fly In** در اسلاید اصلی است.

![اثر انیمیشن فوتر در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن فوتر در اسلاید طرح‌بندی](layout-shape-animation.png)

![اثر انیمیشن فوتر در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از یک سلسله‌مراتب مکان‌نگهدار در یک ارائه جدید استفاده می‌کند. افکت‌ها به یک مکان‌نگهدار اصلی، یک مکان‌نگهدار طرح‌بندی و مکان‌نگهدار متناظر در اسلاید عادی اضافه می‌شود. قبل از استفاده از شکل بازگردانده‌شده، هر بار [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

دیالوگ **Timing** در پاورپوینت به خصوصیات [Timing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/) نگاشته می‌شود.

![دیالوگ Timing در پاورپوینت برای یک افکت انیمیشن](shape-animation.png)

- **شروع** به [Timing.getTriggerType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getTriggerType) نگاشته می‌شود.
- **مدت** به [Timing.getDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getDuration) نگاشته می‌شود (بر حسب ثانیه).
- **تاخیر** به [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getTriggerDelayTime) نگاشته می‌شود (بر حسب ثانیه).
- **تکرار** به [Timing.getRepeatCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilNextClick) یا [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) نگاشته می‌شود.
- **بازگرداندن پس از اتمام پخش** به [Timing.getRewind](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRewind) نگاشته می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده‌شده توسط [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه‌داشتن مرجع بازگردانده‌شده [Effect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/) از ایجاد ایندکس غیرضروری در مجموعه جلوگیری می‌کند.

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

یک حالت تکرار را عاقلانه انتخاب کنید. ترکیب شمارش تکرار با پرچم «تا» می‌تواند در نماشگرهای مختلف نتایج گیج‌کننده‌ای ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatUntilNextClick) و [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) را تنظیم کنید و سپس [Timing.setRepeatCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatCount) را صدا بزنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صداهای جاسازی‌شده را از طریق [Effect.getSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getSound) ارجاع دهد. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#setStopPreviousSound) به افکت می‌گوید که صداهایی که توسط افکت قبلی آغاز شده‌اند را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایل صوتی محلی به نام `animation-sound.wav` وجود داشته باشد. دو افکت ایجاد می‌کند، فایل را به‌عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری تنظیم می‌کند که صدا را متوقف کند. این مثال از اشیائی که توسط [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) بازگردانده می‌شوند استفاده می‌کند، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای جاسازی‌شده افکت**

مثال زیر انتظار دارد ارائه محلی به نام `presentation-with-animation-sounds.pptx` وجود داشته باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و تمام صداهای جاسازی‌شده افکت را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی که توسط [Audio.getContentType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audio/#getContentType) ارائه می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.getStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audio/#getStream) استفاده کنید و به‌جای بارگذاری کل شیء در یک آرایه بایت، جریان را به فایل کپی کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** کنترل می‌کند که پس از اتمام افکت، شکل چه کاری انجام دهد.

![دیالوگ گزینه‌های افکت پاورپوینت نشان دهنده تنظیمات After animation](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/) از باقی‌ماندن شکل به‌همین صورت، تغییر رنگ، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی پشتیبانی می‌کند. زمانی که نوع برابر با [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/#Color) باشد، باید [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getAfterAnimationColor) نیز تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس‌از‑انیمیشن آن را از طریق شیء افکت بازگردانده تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/#Color) باعث پاک‌سازی تنظیم رنگ پس از انیمیشن می‌شود.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textanimation/#getBuildType) تعیین می‌کند که پاراگراف‌ها همزمان یا به‌صورت سطح‑پاراگراف ظاهر شوند.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getAnimateTextType) تعیین می‌کند که متن به‌صورت یکجا، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getDelayBetweenTextParts) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تاخیر بر حسب ثانیه.

مثال مستقل زیر کلمات داخل یک جعبه متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/buildtype/#AsOneObject) ساختن پاراگراف به‌صورت پی در پی را غیرفعال می‌کند تا تنظیم کلمه برای تمام قاب متن اعمال شود.

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

برای ساختن جعبه متن به‌صورت پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح‑پاراگراف دیگری) را تنظیم کنید. برای هدف‌گیری یک پاراگراف منفرد با افکت اختصاصی، از overload متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) که یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) می‌گیرد استفاده کنید. برای مثال‌های سطح‑پاراگراف به [Animated Text](/slides/fa/python-java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره به‌صورت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نرم‌افزار نمایش‌کننده ارائه کنترل می‌شود.
- PDF و تصویرهای ثابت انیمیشن را پخش نمی‌کنند. هنگامی که خروجی باید حرکت را نشان دهد، از [HTML5 export](/slides/fa/python-java/export-to-html5/)، GIF متحرک یا [تبدیل به ویدئو](/slides/fa/python-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) را تنظیم کنید.
- رندر ویدئو بسیاری از افکت‌های ورودی، تأکید، خروجی و مسیر حرکت رایج را پشتیبانی می‌کند، اما تمام افکت‌های پاورپوینت پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های مهم را با نسخه Aspose.Slides هدف خود آزمایش کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از قالب‌های ارائه دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدئو به‌صورت متفاوت رندر شوند. نتیجه صادرات را معتبر‌سنجی کنید نه فقط بر پایه نام افکت.

## **سوالات متداول**

**چرا یک انیمیشن در پاورپوینت نمایش داده می‌شود اما در PDF نه؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. برای حفظ حرکت، به HTML5، GIF متحرک یا ویدئو صادر کنید.

**چرا یک افکت در ویدئو متفاوت پخش می‌شود؟**

صادرات ویدئو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی پاورپوینت را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و قبل از استفاده در تولید، ارائه واقعی را تست کنید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب لایه (z‑order) فقط کنترل هم‌پوشانی را انجام می‌دهد، در حالی که ترتیب دنباله و تحریک‌کننده‌ها پخش انیمیشن را تعیین می‌کنند. اگر به ترتیب پخش متفاوت نیاز دارید، جدول زمان‌بندی را تغییر دهید.