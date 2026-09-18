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
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
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
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن انیمیشن‌دار را با Aspose.Slides برای Python از طریق Java."
---
## **بررسی کلی**

برای کار با رفتارهای تک‌تک داخل یک افکت یا ویرایش بخش‌های مسیر حرکتی، به [انیمیشن سفارشی](/slides/fa/python-java/custom-animation/) مراجعه کنید.

Aspose.Slides برای Python از طریق Java انیمیشن‌های اسلاید را به‌عنوان افکت‌ها در جدول زمانی اسلاید نشان می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- **دنباله تعاملی** زمانی که شکل محرک آن کلیک شود، شروع می‌شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید از [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث می‌برند، برای اکثر محتوای اسلاید از همان متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) استفاده می‌کنید. افکت‌های موجود در کلاس [EffectType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **افکت‌های انیمیشن شکل‌ها را اضافه کنید**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) را همراه با شکل هدف، نوع افکت، زیرنوع و محرک صدا بزنید. برای افکتی که هنگام کلیک بر روی شکل دیگری آغاز می‌شود، یک دنباله تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌نماید.

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

محرک زمان شروع افکت را تعیین می‌کند:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effecttriggertype/#OnClick) برای کلیک در دنباله اصلی یا کلیک بر روی شکل محرک در دنباله تعاملی صبر می‌کند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effecttriggertype/#WithPrevious) همراه با افکت قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effecttriggertype/#AfterPrevious) پس از اتمام افکت قبلی آغاز می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگر، به جای `target_shape` همان شیء را به [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) بدهید. برای گزینه‌های گروه‌بندی خاص نمودار، به [نمودارهای انیمیشن‌دار](/slides/fa/python-java/animated-charts/) مراجعه کنید.

## **افکت‌های انیمیشن شکل‌ها را بخوانید**

وقتی شکل هدف را می‌دانید از [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#getEffectsByShape) استفاده کنید. برای بررسی هر افکت، هر دنباله اصلی و هر دنباله تعاملی را پیمایش کنید. پیمایش این‌گونه از فرض وجود افکتی در اندیس `0` جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های دنباله اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار شکل را می‌گیرد و سپس تمام دنباله‌های اسلاید را پیمایش می‌کند.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع جای‌نگهدار یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#getEffectsByShape) را فراخوانی کنید. فرض نکنید که [ShapeCollection.get_Item](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#get_Item) در اندیس `0` همیشه شیء مورد نظر است.

## **کار با افکت‌های جای‌نگهدار ارث‌برده**

یک جای‌نگهدار در اسلاید عادی می‌تواند رفتار انیمیشن را از جای‌نگهدار متناظر در اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. متد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) آن جای‌نگهدار والد را برمی‌گرداند یا `None` زمانی که والد وجود نداشته باشد.

در ارائه مثال زیر، پاصفحه (footer) در اسلاید عادی دارای **Random Bars**، در اسلاید طرح‌بندی **Split** و در اسلاید اصلی **Fly In** دارد.

![اثر انیمیشن پاصفحه در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن پاصفحه در اسلاید طرح‌بندی](layout-shape-animation.png)

![اثر انیمیشن پاصفحه در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از یک سلسله مراتب جای‌نگهدار در یک ارائه جدید استفاده می‌کند. افکت‌ها به یک جای‌نگهدار اصلی، یک جای‌نگهدار طرح‌بندی و جای‌نگهدار متناظر در اسلاید عادی اضافه می‌شوند. قبل از استفاده از شکل بازگردانده شده، هر بار از [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getBasePlaceholder) بررسی می‌شود.

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

پنجره **Timing** در PowerPoint به خصوصیات کلاس [Timing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/) نگاشت می‌شود.

![پنجره Timing در PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [Timing.getTriggerType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getTriggerType) نگاشت می‌شود.
- **Duration** به [Timing.getDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getDuration) (بر حسب ثانیه) نگاشت می‌شود.
- **Delay** به [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getTriggerDelayTime) (بر حسب ثانیه) نگاشت می‌شود.
- **Repeat** به [Timing.getRepeatCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilNextClick) یا [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) نگاشت می‌شود.
- **Rewind when done playing** به [Timing.getRewind](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#getRewind) نگاشت می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگشتی توسط [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع [Effect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/) بازگشتی از ایجاد ایندکس‌گذاری ناخواسته جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت هدفمند استفاده کنید. ترکیب شمارش تکرار با پرچم «until» می‌تواند نتایج گیج‌کننده‌ای در نمایش‌گرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatUntilNextClick) و [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) را تنظیم کنید و سپس [Timing.setRepeatCount](https://reference.aspose.com/slides/fa/python-java/aspose.slides/timing/#setRepeatCount) را صدا بزنید، زیرا تنظیم هر کدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای افکت**

یک افکت انیمیشن می‌تواند به صوتی جاسازی‌شده از طریق [Effect.getSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getSound) ارجاع دهد. متد [Effect.setStopPreviousSound](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#setStopPreviousSound) به افکت می‌گوید صوتی را که توسط افکت قبلی شروع شده است، متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایل صوتی محلی با نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، آن فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و دومین افکت را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیایی که توسط [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) بازگردانده می‌شوند استفاده می‌کند، بنابراین نیازی به ایندکس دنباله نیست.

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

### **استخراج صداهای جاسازی‌شده در افکت**

مثال زیر انتظار دارد ارائه محلی با نام `presentation-with-animation-sounds.pptx` موجود باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و تمام صداهای افکت جاسازی‌شده را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی که توسط [Audio.getContentType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audio/#getContentType) بازگردانده می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.getStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audio/#getStream) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کل شیء در آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام افکت چه اتفاقی برای شکل می‌افتد.

![پنجره گزینه‌های افکت PowerPoint که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

کلاس [AfterAnimationType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/) امکان نگه داشتن شکل بدون تغییر، تغییر رنگ، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی را فراهم می‌کند. هنگامی که نوع برابر [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/#Color) است، همچنین [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getAfterAnimationColor) تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء افکت بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/python-java/aspose.slides/afteranimationtype/#Color) تنظیم رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textanimation/#getBuildType) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت سطح پاراگراف ظاهر شوند.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getAnimateTextType) تعیین می‌کند متن به‌صورت یکجا، به‌صورت واژه یا به‌صورت حرف ظاهر شود. متد [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/effect/#getDelayBetweenTextParts) تاخیر بین واژه‌ها یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر واژه‌های یک جعبه متن را انیمیشن می‌کند. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/python-java/aspose.slides/buildtype/#AsOneObject) ساختن بر اساس پاراگراف را غیرفعال می‌کند تا تنظیم واژه برای تمام قاب متن اعمال شود.

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

برای ساختن جعبه متن به‌صورت پاراگرافی، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف قرار دادن یک پاراگراف به‌صورت تک‌تک با افکت مخصوص خود، از متد overload [Sequence.addEffect](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sequence/#addEffect) که یک [Paragraph](https://reference.aspose.com/slides/fa/python-java/aspose.slides/paragraph/) می‌گیرد، استفاده کنید. برای مثال‌های سطح پاراگراف به [نوشته‌های انیمیشن‌دار](/slides/fa/python-java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره به قالب PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را پخش نمی‌کنند. وقتی خروجی باید حرکت را نشان دهد، از [صادرات به HTML5](/slides/fa/python-java/export-to-html5/)، GIF انیمیشن‌دار یا [تبدیل به ویدیو](/slides/fa/python-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، متد [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateShapes) را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/html5options/#setAnimateTransitions) را تنظیم کنید.
- رندر ویدیو بسیاری از افکت‌های ورودی، تأکیدی، خروجی و مسیر حرکتی رایج را پشتیبانی می‌کند، اما همه افکت‌های PowerPoint پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های مهم را با نسخه Aspose.Slides هدف‌تان تست کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های واردشده از فرمت‌های دیگر ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. نتیجهٔ صادرشده را اعتبارسنجی کنید نه تنها بر پایهٔ نام افکت.

## **سؤالات متداول**

**چرا یک انیمیشن در PowerPoint دیده می‌شود اما در PDF نیست؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. وقتی نیاز به حفظ حرکت است، به HTML5، GIF انیمیشن‌دار یا ویدیو صادر شوید.

**چرا یک افکت در ویدیو به‌صورت متفاوتی اجرا می‌شود؟**

صادر به ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را مرور کنید و قبل از استفادهٔ تولیدی، ارائه واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به‌سوی جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب لایهٔ Z شکل فقط پوشش همپوشانی را کنترل می‌کند، در حالی که ترتیب دنباله و محرک‌ها ترتیب پخش انیمیشن را تعیین می‌کنند. اگر به ترتیب پخش متفاوت نیاز دارید، جدول زمان را تغییر دهید.