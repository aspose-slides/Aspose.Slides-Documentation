---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با پایتون
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/python-net/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "بیاموزید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس‌از‑انیمیشن و متن متحرک را با Aspose.Slides برای پایتون از طریق .NET اضافه، بررسی و سفارشی‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides for Python via .NET انیمیشن‌های اسلاید را به‌عنوان افکت‌ها در خط زمان اسلاید نمایش می‌دهد. یک افکت دارای شکل هدف، نوع و زیرنوع انیمیشن، محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس‌از‑انیمیشن است.

خط زمان دو نوع توالی دارد:

- توالی **اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- توالی **تعاملی** زمانی که شکل محرک آن کلیک شود، شروع می‌شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishape/) را دارند، برای بیشتر محتوای اسلاید از همان روش [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **افزودن انیمیشن به اشکال**

برای افزودن انیمیشن، توالی اصلی اسلاید را دریافت کنید و روش [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) را با شکل هدف، نوع افکت، زیرنوع و محرک صدا بزنید. برای افکتی که هنگام کلیک بر شکل دیگر شروع می‌شود، یک توالی تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌نماید.

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

محرک زمان شروع یک افکت را کنترل می‌کند:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) در توالی اصلی برای کلیک یا در توالی تعاملی برای کلیک بر شکل محرک منتظر می‌ماند.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) با افکت قبلی شروع می‌شود.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) هنگامی که افکت قبلی به پایان می‌رسد، شروع می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به‌جای `target_shape` آن شیء را به [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) پاس می‌دهید. برای گزینه‌های گروه‌بندی خاص نمودار، به [نمودارهای متحرک](/slides/fa/python-net/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

هنگامی که شکل هدف را می‌دانید، از [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) استفاده کنید. برای بررسی هر افکت، در توالی اصلی و تمام توالی‌های تعاملی پیمایش کنید. این تکرار از فرض وجود افکت در ایندکس `0` جلوگیری می‌کند.

مثال زیر شکلی با افکت‌های توالی‑اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به آن شکل را دریافت می‌کند و سپس از تمام توالی‌های موجود در اسلاید عبور می‌کند.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع نگهدارنده‌جا یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) را فراخوانی کنید. فرض نکنید که شکل در ایندکس `0` همواره شیء موردنظر است.

## **کار با افکت‌های نگهدارنده‌جان به‌ارث رسیده**

یک نگهدارنده‌جا در اسلاید عادی می‌تواند رفتار انیمیشن را از نگهدارنده‌جای متناظر در اسلاید طرح‌بندی و اسلاید مستر به ارث ببرد. [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) آن نگهدارنده‌جای والد را بازمی‌گرداند یا زمانی که والد وجود نداشته باشد، `None` برمی‌گرداند.

در ارائهٔ مثال زیر، پاورقی در اسلاید عادی دارای **Random Bars**، در اسلاید طرح‌بندی **Split** و در اسلاید مستر **Fly In** است.

![اثر انیمیشن پاورقی در اسلاید عادی](slide-shape-animation.png)
![اثر انیمیشن نگهدارنده‌جای پاورقی در اسلاید طرح‌بندی](layout-shape-animation.png)
![اثر انیمیشن نگهدارنده‌جای پاورقی در اسلاید مستر](master-shape-animation.png)

مثال بعدی سلسله‌مراتبی نگهدارنده‌جا را خودش می‌سازد. افکت‌ها را به یک نگهدارنده‌جای مستر، یک نگهدارنده‌جای طرح‌بندی و نگهدارنده‌جای متناظر در اسلاید عادی اضافه می‌کند. هر فراخوانی به [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) قبل از استفاده از شکل بازگردانده‌شده بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

پنجرهٔ **Timing** در پاورپوینت به ویژگی‌های [Timing](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/) نگاشت دارد.

![پنجرهٔ زمان‌بندی پاورپوینت برای یک افکت انیمیشن](shape-animation.png)

- **شروع** به [Timing.trigger_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/trigger_type/) نگاشت دارد.
- **مدت** به [Timing.duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/duration/) نگاشت دارد، بر حسب ثانیه.
- **تاخیر** به [Timing.trigger_delay_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/trigger_delay_time/) نگاشت دارد، بر حسب ثانیه.
- **تکرار** به [Timing.repeat_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_count/)، [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_next_click/) یا [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) نگاشت دارد.
- **بازپخش پس از اتمام** به [Timing.rewind](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/rewind/) نگاشت دارد.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده‌شده توسط [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه‌داشتن ارجاع به [Effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/) بازگردانده‌شده از یک ایندکس مجموعهٔ غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌صورت عمدی استفاده کنید. ترکیب تعداد تکرار با پرچم «تا» می‌تواند نتایج گیجی در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_next_click/) و [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) را قبل از [Timing.repeat_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_count/) تنظیم کنید، زیرا تنظیم هر یک از پرچم‌ها حالت فعال تکرار را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند از طریق [Effect.sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/sound/) به صوت جاسازی‌شده ارجاع دهد. [Effect.stop_previous_sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/stop_previous_sound/) به افکت می‌گوید صدای آغاز شده توسط افکت قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار یک فایل صوتی محلی به نام `animation-sound.wav` را دارد. دو افکت ایجاد می‌کند، آن فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را طوری پیکربندی می‌کند که صدا را متوقف کند. این مثال از اشیای بازگردانده‌شده توسط [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) استفاده می‌کند، بنابراین نیاز به ایندکس توالی نیست.

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

### **استخراج صداهای جاسازی‌شدهٔ افکت**

مثال زیر انتظار یک ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` را دارد. هر دو توالی اصلی و تعاملی را اسکن کرده و تمام صداهای افکت جاسازی‌شده را در پوشهٔ `extracted-animation-sounds` می‌نویسد. پسوند از نوع MIME صوتی که توسط [Audio.content_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audio/content_type/) ارائه می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.get_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audio/get_stream/) استفاده کنید و جریان را به‌جای بارگذاری کل شیء در یک آرایه بایت، به فایل کپی کنید.

## **تنظیم رفتار پس‌از‑انیمیشن**

گزینه **After animation** تعیین می‌کند پس از پایان افکت، چه اتفاقی برای شکل می‌افتد.

![پنجرهٔ گزینه‌های افکت پاورپوینت نشان‌دهنده تنظیمات After animation](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) امکان نگه‌داشتن شکل بدون تغییر، تغییر رنگ آن، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی را پشتیبانی می‌کند. هنگامی که نوع [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) باشد، باید [Effect.after_animation_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/after_animation_color/) نیز تنظیم شود.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس‌از‑انیمیشن آن را از طریق شیء افکت بازگردانده‌شده تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) تنظیم رنگ پس‌از‑انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.build_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/textanimation/build_type/) تعیین می‌کند پاراگراف‌ها به‌صورت همزمان یا به‌صورت سطح‑پاراگرافی ظاهر شوند.
- [Effect.animate_text_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/animate_text_type/) تعیین می‌کند متن به‌صورت یکجا، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/delay_between_text_parts/) تأخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تأخیر بر حسب ثانیه.

مثال مستقل زیر کلمات موجود در یک جعبهٔ متن را انیمیشن می‌دهد. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/buildtype/) ساختن پاراگراف به‌پارگراف را غیرفعال می‌کند تا تنظیم کلمه برای تمام چارچوب متن اعمال شود.

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

برای ساختن جعبهٔ متن به‌صورت پاراگرافی، [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/buildtype/) (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف واحد با افکت مخصوص به آن، از overload [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) که یک [IParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iparagraph/) می‌پذیرد، استفاده کنید. برای مثال‌های سطح‑پاراگراف به [Animated Text](/slides/fa/python-net/animated-text/) مراجعه کنید.

## **یادداشت‌های صادرات و سازگاری**

- ذخیره به قالب PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را اجرا نمی‌کنند. هنگام نیاز به نمایش حرکت، از [HTML5 export](/slides/fa/python-net/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/python-net/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.animate_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_shapes/) را فعال کنید و در صورت نیاز [Html5Options.animate_transitions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_transitions/) را نیز فعال نمایید.
- رندر ویدئو بسیاری از افکت‌های ورودی، تأکید، خروج و مسیر حرکت رایج را پشتیبانی می‌کند، اما همه افکت‌های پاورپوینت پشتیبانی نمی‌شوند. [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) فعلی را بررسی کنید و ارائه‌های حساس را با نسخه هدف Aspose.Slides خود تست کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های وارد شده از دیگر فرمت‌های ارائه ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدئو به‌صورت متفاوتی رندر شوند. خروجی صادرشده را اعتبارسنجی کنید نه فقط بر نام افکت تکیه کنید.

## **سوالات متداول**

**چرا یک انیمیشن در پاورپوینت نمایش داده می‌شود اما در PDF نمایش داده نمی‌شود؟**

PDF یک قالب ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. هنگام نیاز به حفظ حرکت، به HTML5، GIF متحرک یا ویدئو صادرات کنید.

**چرا یک افکت در ویدئو به‌صورت متفاوتی اجرا می‌شود؟**

صادرات ویدئو انیمیشن‌ها را رندر می‌کند به‌جای این‌که رفتار اصلی پاورپوینت را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اعمال می‌شوند. جدول افکت‌های پشتیبانی‌شده را بررسی کنید و قبل از استفاده در تولید، ارائهٔ واقعی را تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب z‑shape فقط همپوشانی را کنترل می‌کند، در حالی که ترتیب توالی و محرک‌ها پخش انیمیشن را کنترل می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، خط زمان را تغییر دهید.