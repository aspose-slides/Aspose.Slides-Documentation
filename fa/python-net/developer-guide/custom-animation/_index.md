---
title: ایجاد و اصلاح رفتارهای سفارشی انیمیشن در پایتون
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/python-net/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکت
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد، بررسی و اصلاح رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای پایتون از طریق .NET."
---
## **بررسی کلی**

رفتارهای سفارشی انیمیشن به شما امکان می‌دهند عملیات‌های منفرد داخل یک اثر انیمیشن را کنترل کنید، مانند تغییر رنگ، چرخاندن یک شکل، یا دنبال کردن مسیری قابل ویرایش. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را پیکربندی کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید، و اطمینان حاصل کنید که ویژگی‌های آن‌ها پس از ذخیره و باز کردن مجدد یک ارائه حفظ می‌شوند.

برای افکت‌های پیش‌تعریف‌شده و محرک‌های کلیک، به [انیمیشن شکل](/slides/fa/python-net/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به‌صورت **Timeline → Sequence → Effect → Behaviors** سازمان‌دهی می‌شود:

- [timeline] اسلاید شامل دنباله اصلی و دنباله‌های تعاملی است. (https://reference.aspose.com/slides/fa/python-net/aspose.slides/baseslide/timeline/)
- یک [Sequence] شامل افکت‌هاست که ممکن است به اشکال مختلف هدف بگیرند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/)
- یک [Effect] شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی افکت را شناسایی می‌کند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/)
- [Effect.behaviors] عملیات‌های اجرای افکت را شامل می‌شود: تغییر رنگ، جابجایی، چرخش، تنظیم ویژگی و غیره. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effect/behaviors/)

## **ایجاد رفتارهای منفرد**

برای ایجاد یک افکت و دسترسی به مجموعهٔ [behaviors] آن از [Sequence.add_effect] استفاده کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌طور خودکار پر کند. هنگام گسترش پیش‌تنظیم، عملیات آن را نگه دارید یا هنگام جایگزینی عمدی از [clear] استفاده کنید. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behaviorcollection/clear/)

[BehaviorFactory] هشت نوع رفتار را که در زیر نشان داده شده‌اند، می‌سازد. حرکت در بخش [ساخت مسیر حرکت] توضیح داده شده است. هر مثال ساخت یک برنامهٔ کامل است؛ مثال‌های ویرایشی بعدی فایل خروجی مورد استفاده را بیان می‌کنند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behaviorfactory/)

### **چرخش**

از [create_rotation_effect] برای ایجاد یک چرخش استفاده کنید. [by] زاویه نسبی بر حسب درجه را مشخص می‌کند؛ [from_address] و [to] نقاط انتهایی را تعیین می‌کنند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/rotationeffect/by/)

مثال با یک افکت Spin شروع می‌شود، عملیات پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و برای آن دو‑ثانیه زمان می‌گذارد. زاویهٔ نسبی ۹۰ درجه یک چرخش چهار‑قسمتی نسبت به جهت اولیهٔ شکل را نشان می‌دهد، بنابراین نیازی به زاویهٔ شروع صریح نیست.

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

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایش چرخش در ادامه از این فایل استفاده می‌کنند.

### **مقیاس**

از [create_scale_effect] با درصدهای X/Y استفاده کنید: [from_address] و [to] اندازهٔ شروع و پایان را توصیف می‌کنند، در حالی که [by] تغییر نسبی را توصیف می‌کند. در اینجا ۱۰۰ به معنای اندازهٔ اصلی است. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/scaleeffect/from_address/)

مثال ابعاد هر دو محور را از ۱۰۰٪ به ۱۲۵٪ در دو ثانیه افزایش می‌دهد. استفاده از درصدهای مساوی افقی و عمودی نسبت شکل را حفظ می‌کند؛ درصدهای متفاوت موجب کشیدگی یک محور می‌شود.

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

### **رنگ**

از [create_color_effect] برای تغییر پر کردن از آبی به نارنجی استفاده کنید. [from_address] و [to] رنگ‌ها هستند؛ [by] افست رنگ است. [Behavior.properties] ویژگی انیمیشن‌شده را شناسایی می‌کند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/coloreffect/from_address/)

پر کردن جامد شکل با رنگ آبی مقداردهی اولیه می‌شود که با رنگ شروع انیمیشن مطابقت دارد. انتخاب ویژگی رنگ‑پر کردن به رفتار می‌گوید کدام بخش از شکل تغییر کند؛ تنها نقاط رنگی همان ویژگی را مشخص نمی‌کنند. اثر ذخیره‌شده توصیف‌کنندهٔ انتقال دو‑ثانیه‌ای به رنگ نارنجی است.

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

### **فیلتر**

از [create_filter_effect] برای انتخاب یک پاک‌کن (wipe) استفاده کنید. [type]، [subtype] و [reveal] به ترتیب فیلتر، جهت و اینکه شکل را نشان بدهد یا مخفی کند، مشخص می‌کنند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/filtereffect/type/)

این مثال یک پاک‌کن دو‑ثانیه‌ای که شکل را با جهت راست آشکار می‌کند، پیکربندی می‌کند. تنظیمات فیلتر متعلق به رفتار داخل افکت هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم، پیکربندی می‌شوند.

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

### **ویژگی**

از [create_property_effect] برای انیمیشن شفافیت (opacity) استفاده کنید. [from_address]، [to] و [by] رشته‌هایی هستند که با [value_type] و [calc_mode] تفسیر می‌شوند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/propertyeffect/value_type/)

در اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی نمایانگر تغییر از ۲۵٪ شفافیت به شفافیت کامل هستند. درون‌یابی خطی توصیف‌کنندهٔ تغییر تدریجی بین این مقادیر است. هنگام انتقال این مثال به ویژگی دیگر، یک نوع مقدار و مقادیر انتهایی مناسب آن ویژگی را انتخاب کنید.

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

### **تنظیم (Set)**

از [create_set_effect] برای تعیین قابلیت مشاهده (visibility) از طریق [to] استفاده کنید. یک رفتار set بین نقاط انتهایی درونی‌سازی نمی‌کند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/seteffect/to/)

مثال ویژگی visibility را انتخاب می‌کند و رشتهٔ `visible` را هنگام اجرای رفتار اختصاص می‌دهد. مستطیل در این ارائهٔ حداقلی از پیش قابل مشاهده است، بنابراین این انتساب به تنهایی شاید تغییر بصری واضحی ندهد. چنین عملیاتی به‌عنوان بخشی از یک افکت بزرگتر که زمان مخفی/نمایش شکل را نیز کنترل می‌کند، مفید است.

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

### **دستورات (Command)**

از [create_command_effect] استفاده کنید و [type]، [command_string] و [shape_target] را پیکربندی کنید. یک فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [add_audio_frame_embedded] تعبیه می‌کند و یک دستور play به فریم صوتی پیوست می‌شود. (https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/)

فریم صوتی هم هدف افکت است و هم هدف دستور. این اتصال درخواست play را به ضبط تعبیه‌شده مرتبط می‌کند؛ یک رشتهٔ دستور به‌تنهایی شیء رسانه‌ای مورد کنترل را مشخص نمی‌کند. افکت برای شروع در زمان کلیک در طول اسلایدشو تنظیم می‌شود.

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

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ اما ضبط را پخش نمی‌کند. برای پخش نیاز به یک پخش‌کنندهٔ اسلایدشو دارید که از این دستور و هدف رسانه‌ای آن پشتیبانی کند.

## **مدیریت مجموعهٔ رفتارها**

[BehaviorCollection] از [add]، [insert]، [remove] و [remove_at] پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌بندی را اضافه می‌نماید، آن را قبل از چرخش جابجا می‌کند و چرخش را حذف می‌کند. حذف و اضافه‌کردن همان شیء موقعیت ذخیره‌شده را بدون ایجاد یک کپی تغییر می‌دهد. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/behaviorcollection/)

دنبالهٔ ویرایش‌ها مجموعه را از rotation–scale به scale–rotation، سپس به scale تنها تغییر می‌دهد. شاخص‌ها به مجموعهٔ جاری اشاره دارند، بنابراین حذف از شاخص جدید چرخش پس از ترتیب‌دهی مجدد استفاده می‌کند. شمارش نهایی تأیید می‌کند کدام رفتار ذخیره خواهد شد.

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

خروجی `ScaleEffect` است: فقط مقیاس‌بندی باقی می‌ماند. ترتیب مجموعه به‌تنهایی زمان‌بندی رفتارها را پشت‑سرهم انجام نمی‌دهد. هنگام جایگزینی تمام عملیات‌ها، مجموعه را پاک کنید.

## **پیکربندی زمان‌بندی رفتار**

[Behavior.timing]، مستقل از [Effect.timing]، [Timing] را نشان می‌دهد. زمان‌بندی افکت زمان‌بندی افکت enclosing را برنامه‌ریزی می‌کند؛ زمان‌بندی رفتار عملیاتی داخل آن را توصیف می‌کند.

### **تنظیم مدت، تأخیر، تکرار و شتاب**

`rotation.pptx` را باز کنید و [duration] و [trigger_delay_time] را بر حسب ثانیه تنظیم کنید، سپس [repeat_count] را پیکربندی کنید. [accelerate] و [decelerate] کسری از مدت هستند؛ مجموع آن‌ها حداکثر ۱ باشد. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/timing/duration/)

ورودی فایل همان فایلی است که در مثال چرخش ساخته شد و اولین رفتار آن چرخش شناخته شده است. این مثال تنها زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ ۹۰ درجه دست نخورده می‌ماند. جداسازی زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی انیمیشن آسان می‌کند.

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

رفتار دو ثانیه مدت، نیم ثانیه تأخیر و تعداد تکرار ۳ دارد. ۲۰٪ اول و آخر مدت برای شتاب و کاه‌شتاب استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [repeat_duration]، [repeat_until_end_slide] و [repeat_until_next_click] هستند؛ فقط یکی را انتخاب کنید نه همه به‌هم. [auto_reverse] پس از عبور پیشرو، انیمیشن را به‌عقب پخش می‌کند. شتاب و کاه‌شتاب برای تغییرات پیوسته اعمال می‌شود، نه برای انتساب‌های گسسته یا دستورات.

## **ساخت مسیر حرکت**

از [create_motion_effect] برای ساخت حرکت استفاده کنید. [from_address]، [to] و [by] مختصات یا افست‌های درصدی را توصیف می‌کنند. برای یک مسیر قابل ویرایش، یک [MotionPath] ایجاد کنید و به [MotionEffect.path] اختصاص دهید. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/motionpath/)

[MotionCommandPathType] عملیات را انتخاب می‌کند:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | موقعیت شروع را تنظیم می‌کند. |
| LINE_TO | One | در یک بخش مستقیم تا نقطهٔ انتهایی حرکت می‌کند. |
| CURVE_TO | Three | یک منحنی درجهٔ سه با دو نقطهٔ کنترل و نقطهٔ انتهایی دنبال می‌کند. |
| CLOSE_LOOP | None | به موقعیت شروع بازمی‌گردد. |
| END | None | مسیر را خاتمه می‌دهد. |

[MotionPathPointsType] ویژگی‌های ویرایش نقطه‌ها را توصیف می‌کند، مانند نقطهٔ گوشه یا صاف. این جایگزین نوع فرمان نیست. برای مثال منحنی زیر از نوع نقطهٔ منحنی، و برای بخش‌های مستقیم از نوع نقطهٔ گوشه استفاده کنید.

مختصات مسیر نسبت به ابعاد اسلاید نرمال می‌شوند: جابه‌جایی X برابر ۰٫۲۵ نشان‌دهندهٔ یک‌چهارم عرض اسلاید است، نه ۰٫۲۵ پوینت. Y مثبت به سمت پایین است. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی افست‌ها را نسبت به موقعیت جاری نشان می‌دهند. این جدا از [origin] است که چارچوب مرجع مسیر را انتخاب می‌کند، و [path_edit_mode] که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند.

### **ساخت مسیر مستقیم**

یک رفتار حرکت با نقطهٔ شروع، یک بخش مستقیم و یک دستور پایان ایجاد کنید. [MotionPath.add] نوع فرمان، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

دستور شروع (0, 0) را تعیین می‌کند و خط به (0.25, 0) پایان می‌یابد، یعنی جابه‌جایی افقی یک‌چهارم عرض اسلاید. دستور پایان هیچ نقطه‌ای ندارد. پس از اختصاص مسیر، افزودن رفتار حرکت به افکت، این مسیر را به مستطیل متصل می‌کند.

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

`motion.pptx` شامل یک رفتار حرکت با سه دستور مسیر است. مثال‌های ویرایشی زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسه مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. فرمان مطلق در (0.3, 0.1) پایان می‌یابد؛ فرمان نسبی (0.1, 0.1) به موقعیت جاری (0.2, 0) افزوده می‌شود.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، افست X و Y را به موقعیت جاری اضافه کنید تا نقطهٔ انتها به دست آید؛ برای خط مطلق، نقطهٔ انتها را مستقیماً بخوانید. تغییر پرچم بدون تبدیل مختصات مسیری متفاوت توصیف می‌کند.

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

هر کدام از مسیرها را به یک رفتار حرکت اختصاص دهید تا در ارائه استفاده شود. آرگومان بولی نهایی، برای آن فرمان مختصات نسبی را انتخاب می‌کند.

### **جایگزینی خط با منحنی**

`motion.pptx` را باز کنید و فرمان خط آن را با یک منحنی درجهٔ سه جایگزین کنید. ابتدا دو نقطهٔ کنترل را بدهید، سپس نقطهٔ انتهایی.

موقعیت شروع توسط فرمان قبلی تأمین می‌شود. دو نقطهٔ اول منحنی را شکل می‌دهند؛ نقطهٔ سوم مقصد نهایی است؛ این‌ها سه نقطهٔ متوالی مقصد نیستند. به‌روزرسانی همزمان نوع فرمان، نوع ویرایش نقطه و آرایهٔ نقاط، بخش را با هندسهٔ جدید سازگار نگه می‌دارد.

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

مسیر در `curve.pptx` هنوز سه فرمان دارد؛ فرمان میانی اکنون یک منحنی تعریف می‌کند.

## **بررسی و ویرایش مسیر ذخیره‌شده**

هر [MotionCmdPath] نقاط، نوع فرمان، نوع نقاط و اینکه نسبی باشد یا نه را نشان می‌دهد. مثال‌های زیر از مسیر سه‑فرمانی شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی دلخواه، اثر موردنظر را پیدا کنید و پیش از ویرایش بر مبنای شاخص، نوع فرمان و تعداد نقاط را بررسی کنید.

### **خواندن فرمان‌ها و مختصات**

مسیر را بدون تغییر بخوانید. دستورات end و close‑loop نیازی به نقطه ندارند، بنابراین یک آرایهٔ `None` را در نظر بگیرید.

خروجی هر فرمان را همراه با پرچم مختصات نسبی پیش از فهرست کردن نقاطش نشان می‌دهد. این امکان را می‌دهد تا قبل از ویرایش مسیر، نقطهٔ انتها را از یک افست تشخیص دهید. یک منحنی سه نقطه را فهرست می‌کند؛ در حالی که خط مستقیم در این فایل تنها یک نقطه دارد.

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

فهرست شامل یک نقطهٔ شروع، یک خط مطلق که در (0.25, 0) پایان می‌یابد و یک فرمان end است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقطهٔ خط را برای جابه‌جایی نقطهٔ انتهایی آن جایگزین کنید.

در فایل ورودی، شاخص ۰ فرمان شروع و شاخص ۱ خط است. جایگزینی نقطهٔ تک خط، مقصد آن را بدون تغییر نوع فرمان، زمان‌بندی یا موقعیت در مجموعه تغییر می‌دهد. چون فرمان از مختصات مطلق استفاده می‌کند، جفت جدید موقعیتی را نه یک افست نشان می‌دهد.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

خط در `motion-endpoint.pptx` در (0.4, 0.1) پایان می‌یابد؛ فایل اصلی بدون تغییر باقی می‌ماند.

### **جایگزینی یک بخش**

از [insert] و [remove_at] برای جایگزینی خط در `motion.pptx` استفاده کنید. درج، خط قدیمی را به شاخص ۲ منتقل می‌کند.

این نشان می‌دهد چگونه یک شیء فرمان را به‌جای ویرایش مختصات موجود جایگزین کنیم. پس از درج، مجموعه موقتاً شامل فرمان شروع، خط جدید، خط قدیمی و فرمان end است. حذف شاخص ۲ خط قدیمی را حذف می‌کند و مسیر جدید باقی می‌ماند.

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

مسیر ذخیره‌شده همچنان سه فرمان دارد؛ خط جدید در (0.2, 0.1) پایان می‌یابد و فرمان end در آخر قرار دارد.

## **تغییر و تأیید یک رفتار موجود**

وقتی شاخص رفتار معلوم نیست، آن را بر حسب نوع انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [RotationEffect] را می‌یابد، زاویه را تغییر می‌دهد و مقدار ذخیره‌شده را پس از باز کردن مجدد بررسی می‌کند. (https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/rotationeffect/)

بررسی نوع باعث می‌شود حلقه رفتارهایی که چرخش نیستند را رد کند. بار دوم فایل ذخیره‌شده را در یک شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های ماندگار نه مقدار در حافظه را بررسی می‌کند. این مثال همچنان فرض می‌کند اثر شناخته‌شده اولین اثر در دنبالهٔ اصلی است؛ انتخاب رفتار بر حسب نوع لزوماً اثر صحیح را در یک ارائهٔ دلخواه پیدا نمی‌کند.

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

خروجی `Rotation preserved: True` است. الگوی بررسی نوع را برای سایر رفتارها نیز اعمال کنید. برای یک بررسی کامل حفظ، شکل هدف، اثر، انواع و ترتیب رفتارها، زمان‌بندی و دستورات مسیر را مقایسه کنید. برای مقادیر اعشاری از تحمل عددی استفاده کنید. برای ارائه‌ای با ساختار انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/python-net/shape-animation/#read-shape-animations) برای مرور دنباله‌های اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [BehaviorCollection] همان ترتیب ذخیره‌شدهٔ عملیات‌های یک افکت است. این یک لیست پخش نیست که در آن هر رفتار خودکار منتظر رفتار قبلی باشد. زمان‌بندی و افکت enclosing زمان‌بندی را تعیین می‌کند. رفتارها می‌توانند همپوشانی داشته باشند و عملیات بر روی همان ویژگی ممکن است از طریق [additive] و [accumulate] با هم تعامل داشته باشند. فقط تغییر ترتیب مجموعه برای زمان‌بندی «حرکت، سپس چرخش» کافی نیست؛ از زمان‌بندی صریح یا افکت‌های جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/python-net/shape-animation/) توضیح داده شده است استفاده کنید.

[type] و [subtype] افکت توصیف‌کنندهٔ پیش‌تنظیم هستند؛ این‌ها توصیف کامل درخت رفتارهای ویرایش‌شده نیستند. پیش‌تنظیم و زیرنوع را قبل از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی و عملیات سفارشی شما را حذف کند. برای مثال، تغییر یک افکت Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، مجموعه را دوباره بررسی کنید. پاک کردن رفتارهای پیش‌تنظیم ممکن است عملیات‌های دیده‌بانی یا مقداردهی اولیه‌ای را که پیش‌تنظیم به آن نیاز دارد، حذف کند. مثال‌ها به‌طور عمدی از اشکال قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌کنند؛ آن‌ها پیاده‌سازی هر پیش‌تنظیم را بازسازی نمی‌کنند.

## **سازگاری قالب‌ها**

درخت رفتار حفظ‌شده تضمین‌کنندهٔ پخش یکسان در هر مرورگر یا رندر کننده خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| قالب یا خروجی | مواردی که باید تأیید شوند |
| --- | --- |
| PPTX | به‌عنوان قالب اصلی برای این مثال‌ها استفاده کنید. پس از باز کردن مجدد، درخت رفتارهای ویرایش‌شده را تأیید کنید، سپس پخش را در نسخهٔ موردنظر PowerPoint بررسی کنید. |
| PPT | نمایندگی باینری قدیمی ممکن است با PPTX متفاوت باشد. یک چرخه ذخیره‑بازکردن و پخش جداگانه را تست کنید؛ از موفقیت خروجی PPTX برای هر ترکیب سفارشی نتیجه‌گیری نکنید. |
| PDF، PNG، JPEG و سایر تصویرهای ایستای اسلاید | شامل یک نمایش ایستای اسلاید هستند، نه یک زمان‌بندی رفتار قابل پخش یا فریم نهایی انیمیشن تضمین‌شده. |
| [HTML5](/slides/fa/python-net/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را هنگام فعال‌سازی انیمیشن شکل در گزینه‌های خروجی پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [GIF متحرک](/slides/fa/python-net/convert-powerpoint-to-animated-gif/) | فریم‌های رندر‌شده را ذخیره می‌کند، نه رفتارهای قابل ویرایش یا تعامل کلیک‑محرک. حرکت رندر شده واقعی را بررسی کنید. |
| [ویدئو](/slides/fa/python-net/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌عنوان ویدئو رمزگذاری می‌کند. پشتیبانی محدود به [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) رندر کننده است؛ دستورات و رویدادهای تعاملی به یک زمان‌بندی قابل ویرایش تبدیل نمی‌شوند. |

## **پرسش‌های متداول**

**چرا اثر من قبل از افزودن هر چیزی شامل رفتارها است؟**

ایجاد یک اثر پیش‌تعریف‌شده می‌تواند عملیات‌های زیرین آن را ایجاد کند. قبل از تصمیم‌گیری برای گسترش پیش‌تنظیم یا جایگزینی رفتارها، آن‌ها را بررسی کنید.

**آیا جابجایی یک رفتار به ابتدای مجموعه باعث می‌شود اولین اجرا شود؟**

لزماً نه. ترتیب مجموعه جایگزین زمان‌بندی نیست. تأخیرها، مدت‌ها و تعاملات بین عملیات‌های یک ویژگی را بررسی کنید.

**چرا یک فرمان end هیچ نقطه‌ای ندارد؟**

این فرمان پایان مسیر را نشان می‌دهد و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از فایل، برای آرایهٔ نقطهٔ `None` بررسی کنید.

**آیا یک دور موفقیت‌آمیز کافی است تا پخش تأیید شود؟**

خیر. باز کردن مجدد فقط حفظ ویژگی‌هایی را که بررسی کردید تأیید می‌کند. برای تأیید رفتار بصری، بازیکن اسلایدشو یا خروجی‌های انیمیشن‌دار را جداگانه تست کنید.