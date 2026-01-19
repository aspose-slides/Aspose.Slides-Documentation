---
title: تحويل عروض PowerPoint إلى فيديو باستخدام Python
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint إلى فيديو
- تحويل PowerPoint إلى فيديو
- العرض إلى فيديو
- تحويل العرض إلى فيديو
- PPT إلى فيديو
- تحويل PPT إلى فيديو
- PPTX إلى فيديو
- تحويل PPTX إلى فيديو
- ODP إلى فيديو
- تحويل ODP إلى فيديو
- PowerPoint إلى MP4
- تحويل PowerPoint إلى MP4
- العرض إلى MP4
- تحويل العرض إلى MP4
- PPT إلى MP4
- تحويل PPT إلى MP4
- PPTX إلى MP4
- تحويل PPTX إلى MP4
- تحويل PowerPoint إلى فيديو
- تحويل العرض إلى فيديو
- تحويل PPT إلى فيديو
- تحويل PPTX إلى فيديو
- تحويل ODP إلى فيديو
- تحويل الفيديو باستخدام Python
- PowerPoint
- Python
- Aspose.Slides
description: "تعلم كيفية تحويل عروض PowerPoint و OpenDocument إلى فيديو باستخدام Python. اكتشف عينات التعليمات البرمجية وتقنيات الأتمتة لتبسيط سير العمل."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint أو OpenDocument إلى فيديو، ستحصل على:

**زيادة إمكانية الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، تكون مزودة بمشغلات فيديو بشكل افتراضي، مما يجعل من الأسهل للمستخدمين فتح أو تشغيل الفيديوهات مقارنةً بتطبيقات العروض التقليدية.

**نطاق أوسع:** تمكنك الفيديوهات من الوصول إلى جمهور أكبر وتقديم المعلومات بطريقة أكثر جذبًا. تشير الاستطلاعات والإحصاءات إلى أن الناس يفضلون مشاهدة واستهلاك محتوى الفيديو على غيره، ما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="primary" %}} 

تحقق من [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/video) لأنه يوفر تنفيذًا حيًا وفعّالًا للعملية الموضحة هنا.

{{% /alert %}} 

في [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)، قمنا بدمج دعم تحويل العروض إلى فيديو.

* استخدم Aspose.Slides for Python لتوليد إطارات من شرائح العرض بمعدل إطارات محدد (FPS).
* ثم، استخدم أداة طرف ثالث مثل ffmpeg لتجميع هذه الإطارات في فيديو.

## **تحويل عرض PowerPoint إلى فيديو**

1. استخدم أمر pip install لإضافة Aspose.Slides for Python إلى مشروعك: `pip install aspose-slides==24.4.0`
2. حمّل ffmpeg من [هنا](https://ffmpeg.org/download.html) أو ثبّته عبر مدير الحزم.
3. تأكد من أن ffmpeg موجود في `PATH`. وإلا، شغّل ffmpeg باستخدام المسار الكامل للملف التنفيذي (مثلاً `C:\ffmpeg\ffmpeg.exe` على Windows أو `/opt/ffmpeg/ffmpeg` على Linux).
4. شغّل كود تحويل PowerPoint إلى فيديو.

يعرض هذا الكود Python كيفية تحويل عرض (يحتوي على شكل وتأثيرين حركيين) إلى فيديو:
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


## **تأثيرات الفيديو**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for Python، يمكنك تطبيق تأثيرات فيديو مختلفة لتحسين جودة المخرجات البصرية. تتيح لك هذه التأثيرات التحكم في مظهر الشرائح في الفيديو النهائي عن طريق إضافة انتقالات سلسة، ورسوم متحركة، وعناصر بصرية أخرى. يوضح هذا القسم خيارات تأثيرات الفيديو المتاحة وكيفية تطبيقها.

{{% alert color="primary" %}} 

اطلع على [PowerPoint Animation](https://docs.aspose.com/slides/python-net/powerpoint-animation/)، [Shape Animation](https://docs.aspose.com/slides/python-net/shape-animation/)، و[Shape Effect](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات عروض الشرائح أكثر جاذبية وإثارة — وتفعل الشيء نفسه للفيديوهات. لنضيف شريحة أخرى وانتقالًا إلى الكود للعرض السابق:
```python
import aspose.pydrawing as drawing

# أضف شكلاً مبتسمًا وقم بتحريكه.
# ...

# أضف شريحة جديدة وانتقالًا متحركًا.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


يدعم Aspose.Slides for Python أيضًا رسوم متحركة للنص. في هذا المثال، نقوم بتحريك الفقرات على الكائنات لتظهر واحدة تلو الأخرى، مع تأخير ثانية واحدة بينها:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # أضف النص والرسوم المتحركة.
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

    # تحويل الإطارات إلى فيديو.
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```


## **فئات تحويل الفيديو**

لتمكين مهام تحويل PowerPoint إلى فيديو، يوفر Aspose.Slides for Python الفئة [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableframesgenerator/).

`PresentationEnumerableFramesGenerator` تتيح لك تعيين حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) وقيمة FPS (الإطارات في الثانية) من خلال المُنشئ الخاص بها. إذا مررت بمثيل للعرض، سيُستخدم `Presentation.SlideSize` الخاص به.

لجعل جميع الرسوم المتحركة في عرض تُشغَل مرةً واحدة، استخدم الطريقة `PresentationEnumerableFramesGenerator.enumerate_frames`. تأخذ هذه الطريقة مجموعة من الشرائح وتعيد بشكل متسلسل [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). ثم، استخدم `EnumerableFrameArgs.get_frame()` للحصول على كل إطار فيديو.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


بعد ذلك يمكن تجميع الإطارات المُولدة في فيديو. للمزيد من التفاصيل، راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة والتأثيرات المدعومة**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for Python، من المهم معرفة أي الرسوم المتحركة والتأثيرات مُدَعَّمة في المخرجات. يدعم Aspose.Slides مجموعة واسعة من تأثيرات الدخول، الخروج، والتأكيد الشائعة مثل التلاشي، التحليق، التكبير، والدوران. ومع ذلك، قد لا يتم الحفاظ على بعض الرسوم المتحركة المتقدمة أو المخصصة بشكل كامل أو قد تظهر بصورة مختلفة في الفيديو النهائي. يوضح هذا القسم الرسوم المتحركة والتأثيرات المدعومة.

**الدخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fade** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Fly In** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Float In** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Split** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wipe** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shape** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wheel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Random Bars** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Grow & Turn** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Zoom** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Swivel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Bounce** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**التأكيد**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Color Pulse** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Teeter** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Spin** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Grow/Shrink** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Desaturate** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Darken** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Lighten** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Transparency** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Object Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Complementary Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Line Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fill Color** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**الخروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fade** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Fly Out** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Float Out** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Split** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wipe** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shape** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Random Bars** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shrink & Turn** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Zoom** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Swivel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Bounce** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Arcs** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Turns** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shapes** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Loops** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Custom Path** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **تأثيرات انتقال الشرائح المدعومة**

تلعب تأثيرات انتقال الشرائح دورًا مهمًا في إنشاء تغييرات سلسة وجذابة بين الشرائح في الفيديو. يدعم Aspose.Slides for Python مجموعة متنوعة من تأثيرات الانتقال الشائعة للمساعدة في الحفاظ على تدفق وعرض تقديمك الأصلي. يبرز هذا القسم التأثيرات المدعومة أثناء عملية التحويل.

**دقيق**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fade** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Push** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Pull** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Wipe** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Split** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Reveal** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Random Bars** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shape** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Uncover** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Cover** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Flash** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Strips** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مشوق**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Drape** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Curtains** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Wind** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Prestige** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fracture** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Crush** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Peel Off** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Page Curl** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Airplane** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Origami** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Dissolve** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Checkerboard** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Blinds** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Clock** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Ripple** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Honeycomb** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Glitter** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Vortex** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Shred** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Switch** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Flip** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Gallery** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Cube** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Doors** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Box** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Comb** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Zoom** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Random** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**محتوى ديناميكي**:

| نوع الانتقال | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Ferris Wheel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Conveyor** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Rotate** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Orbit** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fly Through** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **الأسئلة الشائعة**

**هل من الممكن تحويل العروض المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides for Python التعامل مع العروض المحمية بكلمة مرور. عند معالجة مثل هذه الملفات، تحتاج إلى توفير كلمة المرور الصحيحة حتى تتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides for Python الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides for Python في التطبيقات والخدمات السحابية. تم تصميم المكتبة للعمل في بيئات الخادم، مما يضمن أداءً عاليًا وقابلية توسعة لمعالجة الملفات على نطاق كبير.

**هل هناك حدود لحجم العروض أثناء التحويل؟**

يستطيع Aspose.Slides for Python التعامل مع عروض بحجم كبير تقريبًا. ومع ذلك، عند العمل مع ملفات ضخمة جدًا قد تحتاج إلى موارد نظام إضافية، ومن الأفضل أحيانًا تحسين العرض لتحسين الأداء.