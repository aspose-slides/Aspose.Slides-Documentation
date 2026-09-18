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
- اضافه کردن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- اضافه کردن اثر
- دریافت اثر
- استخراج اثر
- صدای اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن متحرک را با Aspose.Slides برای پایتون از طریق .NET اضافه، بررسی و سفارشی‌سازی کنید."
---
## **نمای کلی**

آشنایی با رفتارهای فردی داخل یک اثر یا ویرایش بخش‌های مسیر حرکتی، به [Custom Animation](/slides/fa/python-net/custom-animation/) مراجعه کنید.

Aspose.Slides برای Python از طریق .NET انیمیشن‌های اسلاید را به‌عنوان اثرها در زمان‌بندی اسلاید نمایش می‌دهد. یک اثر دارای شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

خط زمان دو نوع دنباله دارد:

- **دنباله اصلی** هنگام پیشرفت اسلاید پخش می‌شود.
- **دنباله تعاملی** زمانی که شکل محرک آن کلیک شود، شروع می‌شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جداول و سایر اشیاء اسلاید [IShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishape/) را پیاده‌سازی می‌کنند، برای بیشتر محتوای اسلاید از همان متد [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) فهرست شده‌اند.

## **اضافه‌کردن انیمیشن به شکل‌ها**

برای افزودن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و متد [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) را با شکل هدف، نوع اثر، زیرنوع و محرک فراخوانی کنید. برای اثری که هنگام کلیک یک شکل دیگر شروع می‌شود، یک دنباله تعاملی ایجاد کنید که محرکش همان شکل دیگر باشد.

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

محرک مشخص می‌کند اثر کی شروع شود:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) برای کلیک در دنباله اصلی یا کلیک روی شکل محرک در دنباله تعاملی صبر می‌کند.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) همراه با اثر قبلی شروع می‌شود.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) پس از پایان اثر قبلی شروع می‌شود.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، به جای `target_shape` همان شی را به [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) پاس بدهید. برای گزینه‌های گروه‌بندی مخصوص نمودارها، به [Animated Charts](/slides/fa/python-net/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

هنگامی که شکل هدف را می‌دانید از [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) استفاده کنید. برای بررسی هر اثر، از میان دنباله اصلی و تمام دنباله‌های تعاملی عبور کنید. تکرار از این فرض جلوگیری می‌کند که دنباله در ایندکس `0` حتماً حاوی اثر باشد.

مثال زیر یک شکل با اثرهای دنباله اصلی و تعاملی ایجاد می‌کند، اثرهایی که هدفشان این شکل است را دریافت می‌کند و سپس از تمام دنباله‌های موجود بر روی اسلاید عبور می‌کند.

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

اگر فقط به اثرهای یک شکل نیاز دارید، ابتدا شکل را بر اساس نام، نوع جای‌گیر یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) را فراخوانی کنید. فرض نکنید شکل در ایندکس `0` همیشه شی مورد نظر است.

## **کار با اثرهای ارث‌برده‌ی جای‌گیر**

یک جای‌گیر در اسلاید عادی می‌تواند رفتار انیمیشن را از جای‌گیر متناظر در اسلاید چیدمان و اسلاید مادر به ارث ببرد. [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) آن جای‌گیر والد را برمی‌گرداند یا `None` اگر والد وجود نداشته باشد.

در ارائه مثال زیر، پاورقی دارای **Random Bars** در اسلاید عادی، **Split** در اسلاید چیدمان و **Fly In** در اسلاید مادر است.

![اثر انیمیشن پاورقی در اسلاید عادی](slide-shape-animation.png)

![اثر انیمیشن پاورقی در اسلاید چیدمان](layout-shape-animation.png)

![اثر انیمیشن پاورقی در اسلاید مادر](master-shape-animation.png)

مثال بعدی ساختار سلسله‌مراتبی جای‌گیرها را خود می‌سازد. اثرهایی به یک جای‌گیر مادر، یک جای‌گیر چیدمان و جای‌گیر متناظر در اسلاید عادی اضافه می‌کند. هر فراخوانی به [Shape.get_base_placeholder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_base_placeholder/) قبل از استفاده از شکل بازگردانده شده بررسی می‌شود.

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

دیالوگ **Timing** در پاورپوینت به ویژگی‌های [Timing](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/) نگاشت دارد.

![دیالوگ Timing پاورپوینت برای یک اثر انیمیشن](shape-animation.png)

- **Start** به [Timing.trigger_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/trigger_type/) نگاشت دارد.
- **Duration** به [Timing.duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/duration/) (به ثانیه) نگاشت دارد.
- **Delay** به [Timing.trigger_delay_time](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/trigger_delay_time/) (به ثانیه) نگاشت دارد.
- **Repeat** به [Timing.repeat_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_count/)، [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_next_click/) یا [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) نگاشت دارد.
- **Rewind when done playing** به [Timing.rewind](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/rewind/) نگاشت دارد.

این مثال مستقل یک اثر اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده شده توسط [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه داشتن مرجع [Effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/) بازگردانده شده از یک اندیس‌گذاری غیرضروری جلوگیری می‌کند.

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

به‌طور عمدی از یک حالت تکرار استفاده کنید. ترکیب یک شمارش تکرار با پرچم «until» می‌تواند نتایج گیج‌کننده‌ای در نمایشگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.repeat_until_next_click](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_next_click/) و [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) را تنظیم کنید و سپس [Timing.repeat_count](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/repeat_count/) را تنظیم نمایید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک اثر انیمیشن می‌تواند صداهای تعبیه‌شده را از طریق [Effect.sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/sound/) ارجاع دهد. [Effect.stop_previous_sound](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/stop_previous_sound/) به اثر می‌گوید صداهای شروع‌شده توسط اثر قبلی را متوقف کند.

### **اضافه‌کردن صدا به یک اثر**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` موجود باشد. دو اثر ایجاد می‌کند، آن فایل را به‌عنوان صدا برای اثر اول تعبیه می‌کند و اثر دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیائی که توسط [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) بازگردانده می‌شوند استفاده می‌کند، بنابراین نیازی به اندیس دنباله نیست.

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

### **استخراج صداهای تعبیه‌شده‌ی اثر**

مثال زیر انتظار دارد یک ارائه محلی به نام `presentation-with-animation-sounds.pptx` موجود باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و هر صدای تعبیه‌شده‌ی اثر را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر پایه نوع MIME صوتی که توسط [Audio.content_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audio/content_type/) در معرض قرار می‌گیرد انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.get_stream](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audio/get_stream/) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کل شی در یک آرایهٔ بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام اثر، چه اتفاقی برای شکل می‌افتد.

![دیالوگ گزینه‌های اثر پاورپوینت که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) امکان باقی‌ماندن شکل بدون تغییر، تغییر رنگ آن، مخفی‌کردن آن پس از انیمیشن، یا مخفی‌کردن آن در کلیک بعدی را پشتیبانی می‌کند. وقتی نوع [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) باشد، باید [Effect.after_animation_color](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/after_animation_color/) نیز تنظیم شود.

این مثال مستقل یک اثر ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء اثر بازگردانده تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) مقدار رنگ پس از انیمیشن را پاک می‌کند.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.build_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/textanimation/build_type/) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت سطح پاراگراف ظاهر شوند.
- [Effect.animate_text_type](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/animate_text_type/) تعیین می‌کند متن به‌صورت یک‌باره، به‌صورت کلمه یا به‌صورت حرف ظاهر شود. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/delay_between_text_parts/) تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات داخل یک جعبه متن را انیمیشن می‌کند. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/buildtype/) ساخت پاراگراف به‌پارگراف را غیرفعال می‌کند تا تنظیمات کلمه‌ای برای تمام فریم متن اعمال شود.

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

برای ساخت جعبه متن به‌صورت پاراگراف، [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/buildtype/) (یا سطح دیگری از پاراگراف) را تنظیم کنید. برای هدف‌گیری یک پاراگراف واحد با اثر خاص، از نسخهٔ overload [Sequence.add_effect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/add_effect/) که یک [IParagraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iparagraph/) می‌پذیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/python-net/animated-text/) مراجعه کنید.

## **نکات خروجی و سازگاری**

- ذخیره به‌صورت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نرم‌افزار نمایش ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن پخش نمی‌کنند. وقتی خروجی باید حرکت را نشان دهد، از [HTML5 export](/slides/fa/python-net/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/python-net/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.animate_shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_shapes/) را فعال کنید و در صورت نیاز [Html5Options.animate_transitions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_transitions/) را نیز فعال کنید.
- رندرینگ ویدیو بسیاری از اثرهای ورودی، تأکیدی، خروجی و مسیر-حرکتی رایج را پشتیبانی می‌کند، اما همهٔ اثرهای پاورپوینت پشتیبانی نمی‌شوند. [supported animations and effects](/slides/fa/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) فعلی را بررسی کنید و ارائه‌های مهم را با نسخه هدف Aspose.Slides خود تست کنید.
- اثرهای سفارشی پیشرفته و اثرهای وارد شده از فرمت‌های دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدیو به‌صورت متفاوت رندر شوند. به‌جای اعتماد فقط به نام اثر، نتیجهٔ خروجی را اعتبارسنجی کنید.

## **سوالات متداول**

**چرا یک انیمیشن در پاورپوینت نمایش داده می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. وقتی باید حرکت حفظ شود، به HTML5، GIF متحرک یا ویدیو خروجی بگیرید.

**چرا یک اثر در ویدیو به‌صورت متفاوتی پخش می‌شود؟**

صادرات ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی پاورپوینت را ذخیره کند. برخی اثرهای پیشرفته پشتیبانی نشده یا به‌صورت تخمینی هستند. جدول اثرهای پشتیبانی‌شده را بررسی کنید و پیش از استفادهٔ تولیدی، ارائه واقعی را تست کنید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب z-order شکل تنها روی هم‌پوشانی تأثیر می‌گذارد، در حالی که ترتیب دنباله و محرک‌ها پخش انیمیشن را کنترل می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، زمان‌بندی را تغییر دهید.