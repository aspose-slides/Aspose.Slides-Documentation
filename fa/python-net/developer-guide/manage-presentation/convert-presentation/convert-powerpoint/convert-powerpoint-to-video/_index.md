---
title: تبدیل ارائه‌های PowerPoint به ویدئو در پایتون
linktitle: PowerPoint به ویدئو
type: docs
weight: 130
url: /fa/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint به ویدئو
- تبدیل PowerPoint به ویدئو
- ارائه به ویدئو
- تبدیل ارائه به ویدئو
- PPT به ویدئو
- تبدیل PPT به ویدئو
- PPTX به ویدئو
- تبدیل PPTX به ویدئو
- ODP به ویدئو
- تبدیل ODP به ویدئو
- PowerPoint به MP4
- تبدیل PowerPoint به MP4
- ارائه به MP4
- تبدیل ارائه به MP4
- PPT به MP4
- تبدیل PPT به MP4
- PPTX به MP4
- تبدیل PPTX به MP4
- تبدیل PowerPoint به ویدئو
- تبدیل ارائه به ویدئو
- تبدیل PPT به ویدئو
- تبدیل PPTX به ویدئو
- تبدیل ODP به ویدئو
- تبدیل ویدئو با پایتون
- PowerPoint
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را با استفاده از پایتون به ویدئو تبدیل کنید. کد نمونه و تکنیک‌های خودکارسازی را برای بهینه‌سازی جریان کار خود کشف کنید."
---
## **مقدمه**

با تبدیل ارائه PowerPoint یا OpenDocument به ویدئو، موارد زیر را به دست می‌آورید:

**دسترسی افزایش یافته:** تمام دستگاه‌ها، صرف‌نظر از پلتفرم، به‌صورت پیش‌فرض دارای پلیرهای ویدئویی هستند، بنابراین کاربران راحت‌تر می‌توانند ویدئوها را باز یا پخش کنند نسبت به برنامه‌های ارائه سنتی.

**دسترس گسترده‌تر:** ویدئوها به شما امکان می‌دهند تا به مخاطبان بیشتری برسید و اطلاعات را به شکلی جذاب‌تر ارائه دهید. نظرسنجی‌ها و آمار نشان می‌دهد مردم ترجیح می‌دهند محتواهای ویدئویی را نسبت به دیگر اشکال مصرف کنند، که پیام شما را تأثیرگذارتر می‌کند.

{{% alert color="primary" %}} 
از [**مبدل آنلاین PowerPoint به ویدئو**](https://products.aspose.app/slides/fa/video) بازدید کنید؛ زیرا پیاده‌سازی زنده و مؤثری از فرآیندی که در اینجا توضیح داده شده است، ارائه می‌دهد.
{{% /alert %}} 

در [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/fa/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)، پشتیبانی از تبدیل ارائه‌ها به ویدئو را پیاده‌سازی کردیم.

* از Aspose.Slides for Python برای تولید فریم‌ها از اسلایدهای ارائه با نرخ فریم مشخص (FPS) استفاده کنید.
* سپس، با ابزار شخص ثالثی مانند ffmpeg این فریم‌ها را به یک ویدئو ترکیب کنید.

## **تبدیل ارائه PowerPoint به ویدئو**

1. با استفاده از دستور pip install، Aspose.Slides for Python را به پروژه خود اضافه کنید: `pip install aspose-slides==24.4.0`
2. ffmpeg را از [اینجا](https://ffmpeg.org/download.html) دانلود کنید یا از طریق مدیر بسته نصب کنید.
3. مطمئن شوید ffmpeg در `PATH` قرار دارد. در غیر این صورت، ffmpeg را با مسیر کامل باینری اجرا کنید (مثلاً `C:\ffmpeg\ffmpeg.exe` در ویندوز یا `/opt/ffmpeg/ffmpeg` در لینوکس).
4. کد تبدیل PowerPoint به ویدئو را اجرا کنید.

این کد پایتون نشان می‌دهد چگونه یک ارائه (شامل یک شکل و دو افکت انیمیشن) را به ویدئو تبدیل کنیم:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **افکت‌های ویدئویی**

هنگام تبدیل یک ارائه PowerPoint به ویدئو با Aspose.Slides for Python می‌توانید انواع افکت‌های ویدئویی را برای بهبود کیفیت بصری خروجی اعمال کنید. این افکت‌ها به شما امکان می‌دهند ظاهر اسلایدها را در ویدئوی نهایی با اضافه کردن انتقال‌های نرم، انیمیشن‌ها و سایر عناصر بصری کنترل کنید. این بخش گزینه‌های افکت ویدئویی موجود را توضیح می‌دهد و نحوه اعمال آن‌ها را نشان می‌دهد.

{{% alert color="primary" %}} 
به [PowerPoint Animation](https://docs.aspose.com/slides/fa/python-net/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/fa/python-net/shape-animation/) و [Shape Effect](https://docs.aspose.com/slides/fa/python-net/shape-effect/) مراجعه کنید.
{{% /alert %}} 

انیمیشن‌ها و انتقال‌ها اسلایدشوها را جذاب‌تر می‌کنند — و همین کار را برای ویدئوها نیز انجام می‌دهند. بیایید یک اسلاید دیگر و یک انتقال به کد ارائه قبلی اضافه کنیم:

```python
import aspose.pydrawing as drawing

# اضافه کردن یک شکل لبخند و انیمیشن کردن آن.
# ...

# Add a new slide and an animated transition.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python همچنین از انیمیشن متن پشتیبانی می‌کند. در این مثال، پاراگراف‌ها را روی اشیاء انیمیشن می‌کنیم تا یک‌دام بعد از دیگری ظاهر شوند، با تاخیر یک ثانیه‌ای بین هر کدام:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # اضافه کردن متن و انیمیشن‌ها.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # تبدیل فریم‌ها به ویدئو.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **کلاس‌های تبدیل ویدئو**

برای انجام وظایف تبدیل PowerPoint به ویدئو، Aspose.Slides for Python کلاس [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/presentationenumerableframesgenerator/) را ارائه می‌دهد.

`PresentationEnumerableFramesGenerator` به شما امکان می‌دهد اندازه فریم ویدئو (که بعدها ساخته خواهد شد) و مقدار FPS (فریم در ثانیه) را از طریق سازنده‌اش تنظیم کنید. اگر یک نمونه از ارائه را به آن پاس دهید، `Presentation.SlideSize` آن استفاده می‌شود.

برای اینکه تمام انیمیشن‌ها در یک ارائه به‌صورت همزمان پخش شوند، از متد `PresentationEnumerableFramesGenerator.enumerate_frames` استفاده کنید. این متد مجموعه‌ای از اسلایدها را می‌گیرد و به‌صورت ترتیبی [EnumerableFrameArgs](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/enumerableframeargs/) را برمی‌گرداند. سپس، با `EnumerableFrameArgs.get_frame()` هر فریم ویدئویی را به‌دست می‌آورید.

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

سپس فریم‌های تولید شده می‌توانند به یک ویدئو ترکیب شوند. برای جزئیات بیشتر، بخش [Convert PowerPoint to Video](https://docs.aspose.com/slides/fa/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) را ببینید.

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

هنگام تبدیل یک ارائه PowerPoint به ویدئو با Aspose.Slides for Python، مهم است بدانید کدام انیمیشن‌ها و افکت‌ها در خروجی پشتیبانی می‌شوند. Aspose.Slides طیف گسترده‌ای از افکت‌های ورودی، خروجی و تأکیدی رایج مانند محو شدن، پرواز، زوم و چرخش را پشتیبانی می‌کند. با این حال، برخی از انیمیشن‌های پیشرفته یا سفارشی ممکن است به‌طور کامل حفظ نشوند یا در ویدئوی نهایی به‌صورت متفاوت ظاهر شوند. این بخش انیمیشن‌ها و افکت‌های پشتیبانی‌شده را فهرست می‌کند.

**ورودی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fade** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Fly In** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Float In** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Split** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wipe** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shape** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wheel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Random Bars** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Grow & Turn** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Zoom** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Swivel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Bounce** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

**تأکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Color Pulse** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Teeter** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Spin** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Grow/Shrink** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Desaturate** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Darken** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Lighten** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Transparency** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Object Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Complementary Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Line Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fill Color** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |

**خروجی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fade** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Fly Out** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Float Out** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Split** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wipe** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shape** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Random Bars** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shrink & Turn** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Zoom** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Swivel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Bounce** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Arcs** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Turns** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shapes** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Loops** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Custom Path** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

## **افکت‌های انتقال اسلاید پشتیبانی‌شده**

افکت‌های انتقال اسلاید نقش مهمی در ایجاد تغییرات نرم و بصری جذاب بین اسلایدها در یک ویدئو ایفا می‌کنند. Aspose.Slides for Python از انواع افکت‌های انتقال رایج پشتیبانی می‌کند تا جریان و سبک ارائه اصلی شما در هنگام تبدیل حفظ شود. این بخش به افکت‌های انتقال پشتیبانی‌شده در فرایند تبدیل می‌پردازد.

**ظریف**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fade** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Push** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Pull** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Wipe** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Split** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Reveal** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Random Bars** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Shape** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Uncover** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Cover** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Flash** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Strips** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

**هیجان‌انگیز**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Drape** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Curtains** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Wind** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Prestige** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fracture** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Crush** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Peel Off** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Page Curl** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Airplane** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Origami** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Dissolve** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Checkerboard** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Blinds** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Clock** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Ripple** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Honeycomb** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Glitter** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Vortex** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Shred** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Switch** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Flip** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Gallery** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Cube** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Doors** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Box** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Comb** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Zoom** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Random** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |

**محتوای پویا**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Ferris Wheel** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |
| **Conveyor** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Rotate** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Orbit** | ![پشتیبانی نمی‌شود](x.png) | ![پشتیبانی می‌شود](v.png) |
| **Fly Through** | ![پشتیبانی می‌شود](v.png) | ![پشتیبانی می‌شود](v.png) |

## **پرسش‌های متداول**

**آیا می‌توان ارائه‌های دارای رمز عبور را تبدیل کرد؟**

بله، Aspose.Slides for Python امکان کار با ارائه‌های رمزنگاری‌شده را فراهم می‌کند. هنگام پردازش چنین فایل‌هایی، باید رمز عبور صحیح را ارائه دهید تا کتابخانه بتواند به محتوای ارائه دسترسی پیدا کند.

**آیا Aspose.Slides for Python برای استفاده در راه‌حل‌های ابری پشتیبانی می‌شود؟**

بله، Aspose.Slides for Python می‌تواند در برنامه‌ها و سرویس‌های ابری یکپارچه شود. این کتابخانه برای کار در محیط‌های سرور طراحی شده و عملکرد بالا و مقیاس‌پذیری لازم برای پردازش دسته‌ای فایل‌ها را تضمین می‌کند.

**آیا محدودیتی در اندازه ارائه‌ها هنگام تبدیل وجود دارد؟**

Aspose.Slides for Python قادر به پردازش ارائه‌هایی با هر اندازه‌ای است. با این حال، هنگام کار با فایل‌های بسیار بزرگ ممکن است به منابع سیستم اضافی نیاز باشد و گاهی توصیه می‌شود تا عملکرد بهتر، ارائه را بهینه‌سازی کنید.