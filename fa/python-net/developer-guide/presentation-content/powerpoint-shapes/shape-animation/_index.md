---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با Python
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/python-net/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل انیمیشنی
- متن انیمیشنی
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدای افکت
- اعمال انیمیشن
- پاورپوینت
- ارائه
- پایتون
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انیمیشن‌های شکل را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق .NET ایجاد و سفارشی‌سازی کنید. متمایز شوید!"
---
## **معرفی**

انیمیشن‌ها اثرات بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، اشکال یا [نمودارها](/slides/fa/python-net/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا مؤلفه‌های آن جان می‌بخشند. 

## **چرا از انیمیشن‌ها در ارائه‌ها استفاده کنیم؟**

استفاده از انیمیشن‌ها به شما امکان می‌دهد  

* کنترل جریان اطلاعات  
* برجسته کردن نکات مهم  
* افزایش علاقه یا مشارکت مخاطبان  
* آسان‌تر کردن خواندن یا درک یا پردازش محتوا  
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه  

PowerPoint گزینه‌ها و ابزارهای بسیاری برای انیمیشن‌ها و افکت‌های انیمیشنی در دسته‌های **ورود**، **خروج**، **تاکید** و **مسیر حرکت** فراهم می‌کند. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌هایی را که برای کار با انیمیشن‌ها در فضای نام [Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/) نیاز دارید، فراهم می‌کند،  
* Aspose.Slides بیش از **150 افکت انیمیشن** را تحت شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttype/) ارائه می‌دهد. این افکت‌ها اساساً همان (یا معادل) افکت‌های مورد استفاده در PowerPoint هستند.  

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد تا انیمیشن را بر متن داخل یک شکل اعمال کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iautoshape/) اضافه کنید.  
4. متن را به `IAutoShape.TextFrame` اضافه کنید.  
5. یک توالی اصلی از افکت‌ها دریافت کنید.  
6. یک افکت انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iautoshape/) اضافه کنید.  
7. ویژگی `TextAnimation.BuildType` را به مقداری از شمارش‌گر `BuildType` تنظیم کنید.  
8. ارائه را به عنوان یک فایل PPTX روی دیسک بنویسید.  

این کد پایتون نشان می‌دهد چگونه افکت `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # یک AutoShape جدید با متن اضافه می‌کند
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # توالی اصلی اسلاید را دریافت می‌کند.
    sequence = sld.timeline.main_sequence

    # افکت انیمیشن Fade را به شکل اضافه می‌کند
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌کند
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن به متن، می‌توانید انیمیشن‌ها را به یک [Paragraph](https://reference.aspose.com/slides/fa/python-net/aspose.slides.iparagraph/) واحد نیز اعمال کنید. به [**متن انیمیشنی**](/slides/fa/python-net/animated-text/) مراجعه کنید.

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) را در اسلاید اضافه کنید یا دریافت کنید.  
4. توالی اصلی افکت‌ها را دریافت کنید.  
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) اضافه کنید.  
6. ارائه را به عنوان فایل PPTX روی دیسک بنویسید.  

این کد پایتون نشان می‌دهد چگونه افکت `Fly` را به یک قاب تصویر اعمال کنید:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است.
with slides.Presentation() as pres:
    # تصویر را برای افزودن به مجموعه تصاویر ارائه بارگذاری می‌کند
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # یک قاب تصویر به اسلاید اضافه می‌کند
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # توالی اصلی اسلاید را دریافت می‌کند.
    sequence = pres.slides[0].timeline.main_sequence

    # افکت انیمیشن Fly از سمت چپ را به قاب تصویر اضافه می‌کند
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # فایل PPTX را روی دیسک ذخیره می‌کند
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iautoshape/) اضافه کنید.  
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iautoshape/) اضافه کنید (زمانی که این شیء کلیک می‌شود، انیمیشن اجرا می‌شود).  
5. یک توالی از افکت‌ها بر روی شکل Bevel ایجاد کنید.  
6. یک `UserPath` سفارشی ایجاد کنید.  
7. دستورات برای حرکت به `UserPath` اضافه کنید.  
8. ارائه را به عنوان فایل PPTX روی دیسک بنویسید.  

این کد پایتون نشان می‌دهد چگونه افکت `PathFootball` (path football) را به یک شکل اعمال کنید:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# یک نمونه از کلاس Presentation که نمایانگر یک فایل PPTX است
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # افکت انیمیشن PathFootBall را اضافه می‌کند.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # یک نوع "دکمه" ایجاد می‌کند.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # توالی‌ای از افکت‌ها برای دکمه ایجاد می‌کند.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # یک مسیر کاربری سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک روی دکمه حرکت خواهد کرد.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # دستورات حرکت را اضافه می‌کند زیرا مسیر ایجاد شده خالی است.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # فایل PPTX را بر روی دیسک می‌نویسد
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **دریافت افکت‌های انیمیشن اعمال شده بر Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `get_effects_by_shape` کلاس [Sequence](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/sequence/) برای دریافت تمام افکت‌های انیمیشن اعمال شده بر یک شکل استفاده کنید.

**مثال ۱: دریافت افکت‌های انیمیشن اعمال شده بر یک شکل در اسلاید عادی**

قبلاً یاد گرفتید چگونه افکت‌های انیمیشن را به اشکال در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال شده بر اولین شکل در اولین اسلاید عادی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # توالی اصلی انیمیشن اسلاید را دریافت می‌کند.
    sequence = first_slide.timeline.main_sequence

    # اولین شکل در اولین اسلاید را دریافت می‌کند.
    shape = first_slide.shapes[0]

    # افکت‌های انیمیشن اعمال شده به شکل را دریافت می‌کند.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**مثال ۲: دریافت تمام افکت‌های انیمیشن، شامل آنهایی که از Placeholderها به ارث رسیده‌اند**

اگر یک شکل در اسلاید عادی دارای Placeholderهایی باشد که در اسلاید layout و/یا اسلاید master قرار دارند و افکت‌های انیمیشن به این Placeholderها اضافه شده باشد، تمام افکت‌های شکل در طول نمایش اسلاید اجرا می‌شوند، شامل آنهایی که از Placeholderها به ارث رسیده‌اند.

فرض کنید فایلی از ارائه PowerPoint به نام `sample.pptx` داریم که شامل یک اسلاید با فقط یک شکل پاورقی با متن «Made with Aspose.Slides» است و افکت **Random Bars** بر شکل اعمال شده است.

![اثر انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید افکت **Split** بر Placeholder پاورقی در اسلاید **layout** اعمال شده است.

![اثر انیمیشن شکل لایه‌بندی](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر Placeholder پاورقی در اسلاید **master** اعمال شده است.

![اثر انیمیشن شکل مستر](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `get_base_placeholder` کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) برای دسترسی به Placeholderهای شکل استفاده کنید و افکت‌های انیمیشن اعمال شده بر شکل پاورقی را دریافت کنید، شامل آنهایی که از Placeholderهای موجود در اسلایدهای layout و master به ارث رسیده‌اند.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # دریافت افکت‌های انیمیشن شکل در اسلاید عادی.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # دریافت افکت‌های انیمیشن جای‌نگهدار در اسلاید layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # دریافت افکت‌های انیمیشن جای‌نگهدار در اسلاید master.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **تغییر ویژگی‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد ویژگی‌های Timing یک افکت انیمیشن را تغییر دهید.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

این‌ها مطابقت‌های بین Timing در PowerPoint و ویژگی‌های `Effect.Timing` است:

- گزینهٔ کشویی **Start** در Timing PowerPoint با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/effecttriggertype/) مطابقت دارد. 
- **Duration** در Timing PowerPoint با ویژگی `Effect.Timing.Duration` مطابقت دارد. مدت زمان یک انیمیشن (به ثانیه) کل زمان تکمیل یک چرخهٔ انیمیشن است. 
- **Delay** در Timing PowerPoint با ویژگی `Effect.Timing.TriggerDelayTime` مطابقت دارد. 

به این صورت می‌توانید ویژگی‌های Timing افکت را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.  
2. مقادیر جدیدی برای ویژگی‌های `Effect.Timing` که نیاز دارید تنظیم کنید.  
3. فایل PPTX اصلاح‌شده را ذخیره کنید.  

```python
import aspose.slides as slides

# یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # توالی اصلی اسلاید را دریافت می‌کند.
    sequence = pres.slides[0].timeline.main_sequence

    # اولین افکت توالی اصلی را دریافت می‌کند.
    effect = sequence[0]

    # نوع TriggerType افکت را به شروع با کلیک تغییر می‌دهد
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # مدت زمان افکت را تغییر می‌دهد
    effect.timing.duration = 3

    # زمان تاخیر TriggerDelayTime افکت را تغییر می‌دهد
    effect.timing.trigger_delay_time = 0.5

    # فایل PPTX را بر روی دیسک ذخیره می‌کند
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **صدای افکت انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در افکت‌های انیمیشن ارائه می‌دهد: 

- `sound`  
- `stop_previous_sound`  

### **اضافه کردن صدای افکت انیمیشن**

این کد پایتون نشان می‌دهد چگونه صدا به افکت انیمیشن اضافه کنید و هنگام شروع افکت بعدی آن را متوقف کنید:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # صدای مورد را به مجموعه صداهای ارائه اضافه می‌کند
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # توالی اصلی اسلاید را دریافت می‌کند.
    sequence = first_slide.timeline.main_sequence

    # اولین افکت توالی اصلی را دریافت می‌کند
    first_effect = sequence[0]

    # وضعیت "بدون صدا" را برای افکت بررسی می‌کند
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # صدا را به اولین افکت اضافه می‌کند
        first_effect.sound = effect_sound

    # اولین توالی تعاملی اسلاید را دریافت می‌کند.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # پرچم "Stop previous sound" افکت را تنظیم می‌کند
    interactive_sequence[0].stop_previous_sound = True

    # فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج صدای افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. توالی اصلی افکت‌ها را دریافت کنید.  
4. `sound` جاسازی‌شده در هر افکت انیمیشن را استخراج کنید.  

این کد پایتون نشان می‌دهد چگونه صدای جاسازی‌شده در یک افکت انیمیشن را استخراج کنید:

```python
import aspose.slides as slides

# یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # توالی اصلی اسلاید را دریافت می‌کند.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # صدای افکت را به‌صورت آرایه بایت استخراج می‌کند
        audio = effect.sound.binary_data
```

## **بعد از انیمیشن**

Aspose.Slides برای .NET به شما امکان می‌دهد ویژگی After animation یک افکت انیمیشن را تغییر دهید.

![example1_image](shape-after-animation.png)

گزینهٔ کشویی **After animation** در افکت PowerPoint با این ویژگی‌ها مطابقت دارد: 

- ویژگی `after_animation_type` که نوع After animation را توصیف می‌کند:
  * گزینهٔ **More Colors** در PowerPoint با نوع [COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * گزینهٔ **Don't Dim** در PowerPoint با نوع [DO_NOT_DIM](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) (نوع پیش‌فرض after animation) مطابقت دارد؛
  * گزینهٔ **Hide After Animation** در PowerPoint با نوع [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * گزینهٔ **Hide on Next Mouse Click** در PowerPoint با نوع [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
- ویژگی `after_animation_color` که فرمت رنگ after animation را تعریف می‌کند. این ویژگی همراه با نوع [COLOR](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/afteranimationtype/) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ after animation پاک می‌شود.

این کد پایتون نشان می‌دهد چگونه یک افکت after animation را تغییر دهید:

```python
import aspose.slides as slides

# یک نمونه از کلاس ارائه که نمایانگر یک فایل ارائه است
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # اولین افکت توالی اصلی را دریافت می‌کند
    first_effect = first_slide.timeline.main_sequence[0]

    # نوع after animation را به Color تغییر می‌دهد
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # رنگ پس‌انیمیشن را تنظیم می‌کند
    first_effect.after_animation_color.color = Color.alice_blue

    # فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بلوک *Animate text* یک افکت انیمیشن ارائه می‌دهد:

- `animate_text_type` که نوع متن انیمیشنی افکت را توصیف می‌کند. متن شکل می‌تواند به صورت زیر انیمیشن شود:
  - همه به‌صورت همزمان ([ALL_AT_ONCE](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animatetexttype/) نوع)
  - به‌صورت کلمه به کلمه ([BY_WORD](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animatetexttype/) نوع)
  - به‌صورت حرف به حرف ([BY_LETTER](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/animatetexttype/) نوع)
- `delay_between_text_parts` تاخیر بین بخش‌های متن انیمیشنی (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصد مدت اثر را مشخص می‌کند. مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.

به این صورت می‌توانید ویژگی‌های Animate text افکت را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.  
2. ویژگی `build_type` را به مقدار [AS_ONE_OBJECT](https://reference.aspose.com/slides/fa/python-net/aspose.slides.animation/buildtype/) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.  
3. مقادیر جدیدی برای ویژگی‌های `animate_text_type` و `delay_between_text_parts` تعیین کنید.  
4. فایل PPTX اصلاح‌شده را ذخیره کنید.  

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # اولین افکت توالی اصلی را دریافت می‌کند
    first_effect = first_slide.timeline.main_sequence[0]

    # نوع انیمیشن متن افکت را به "As One Object" تغییر می‌دهد
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # نوع انیمیشن متن افکت را به "By word" تغییر می‌دهد
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # تاخیر بین کلمات را به 20% مدت افکت تنظیم می‌کند
    first_effect.delay_between_text_parts = 20

    # فایل PPTX را روی دیسک می‌نویسد
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

[صدور به HTML5](/slides/fa/python-net/export-to-html5/) و فعال‌سازی [گزینه‌ها](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/) مسئول انیمیشن‌های [شکل](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_shapes/) و [انتقال](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/html5options/animate_transitions/) است. HTML ساده انیمیشن‌های اسلاید را اجرا نمی‌کند، در حالی که HTML5 این کار را انجام می‌دهد.

**تغییر ترتیب z-order (ترتیب لایه) اشکال چگونه بر انیمیشن تأثیر می‌گذارد؟**

انیمیشن و ترتیب رسم مستقل هستند: یک افکت زمان‌بندی و نوع ظاهر شدن/محو شدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/z_order_position/) تعیین می‌کند چه چیزی چه چیزی را می‌پوشاند. نتیجهٔ قابل مشاهده ترکیب این دو است. (این رفتار کلی PowerPoint است؛ مدل افکت‌ها و اشکال Aspose.Slides همان منطق را دنبال می‌کند.)

**آیا محدودیتی هنگام تبدیل انیمیشن‌ها به ویدیو برای برخی افکت‌ها وجود دارد؟**

به طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/python-net/convert-powerpoint-to-video/)، اما در موارد نادر یا برای افکت‌های خاص ممکن است به شکل متفاوتی رندر شوند. توصیه می‌شود با افکت‌هایی که استفاده می‌کنید و با نسخهٔ کتابخانه تست کنید.