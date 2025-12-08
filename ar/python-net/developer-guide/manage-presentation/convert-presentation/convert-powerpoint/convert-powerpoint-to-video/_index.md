---
title: تحويل عروض PowerPoint إلى فيديو باستخدام Python
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint إلى فيديو
- تحويل PowerPoint إلى فيديو
- العرض التقديمي إلى فيديو
- تحويل العرض التقديمي إلى فيديو
- PPT إلى فيديو
- تحويل PPT إلى فيديو
- PPTX إلى فيديو
- تحويل PPTX إلى فيديو
- ODP إلى فيديو
- تحويل ODP إلى فيديو
- PowerPoint إلى MP4
- تحويل PowerPoint إلى MP4
- العرض التقديمي إلى MP4
- تحويل العرض التقديمي إلى MP4
- PPT إلى MP4
- تحويل PPT إلى MP4
- PPTX إلى MP4
- تحويل PPTX إلى MP4
- تحويل PowerPoint إلى فيديو
- تحويل العرض التقديمي إلى فيديو
- تحويل PPT إلى فيديو
- تحويل PPTX إلى فيديو
- تحويل ODP إلى فيديو
- تحويل فيديو Python
- PowerPoint
- Python
- Aspose.Slides
description: "تعرّف على كيفية تحويل عروض PowerPoint وOpenDocument إلى فيديو باستخدام Python. اكتشف عينة الشيفرة وتقنيات الأتمتة لتبسيط سير عملك."
---

## **نظرة عامة**

من خلال تحويل عرض PowerPoint أو OpenDocument إلى فيديو، تحصل على:

**تحسين الوصول:** جميع الأجهزة، بغض النظر عن النظام الأساسي، مزودة بمشغلات فيديو بشكل افتراضي، مما يجعل من الأسهل على المستخدمين فتح أو تشغيل الفيديوهات مقارنةً بتطبيقات العروض التقليدية.

**نطاق أوسع:** تمكنك الفيديوهات من الوصول إلى جمهور أكبر وتقديم المعلومات بتنسيق أكثر جاذبية. وتشير الاستطلاعات والإحصاءات إلى أن الناس يفضلون مشاهدة واستهلاك المحتوى الفيديوي على غيره، مما يجعل رسالتك أكثر تأثيرًا.

{{% alert color="primary" %}} 

اطلع على [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/video) لأنه يقدم تنفيذًا مباشرًا وفعالًا للعملية الموضحة هنا.

{{% /alert %}} 

في [Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)، قمنا بتنفيذ دعم لتحويل العروض إلى فيديو.

* استخدم Aspose.Slides for Python لتوليد إطارات من شرائح العرض بمعدل إطارات محدد (FPS).
* بعد ذلك، استخدم أداة طرف ثالث مثل ffmpeg لتجميع هذه الإطارات في فيديو.

## **تحويل عرض PowerPoint إلى فيديو**

1. استخدم أمر pip install لإضافة Aspose.Slides for Python إلى مشروعك: `pip install aspose-slides==24.4.0`
2. قم بتنزيل ffmpeg من [هنا](https://ffmpeg.org/download.html) أو ثبّته عبر مدير الحزم.
3. تأكد من أن ffmpeg موجود في `PATH`. وإلا، شغِّل ffmpeg باستخدام المسار الكامل إلى الملف التنفيذي (مثال: `C:\ffmpeg\ffmpeg.exe` على Windows أو `/opt/ffmpeg/ffmpeg` على Linux).
4. نفِّذ كود تحويل PowerPoint إلى فيديو.

يُظهر هذا الكود Python كيفية تحويل عرض (يحتوي على شكل وتأثيري تحريك) إلى فيديو:
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

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for Python، يمكنك تطبيق تأثيرات فيديو مختلفة لتحسين الجودة البصرية للمخرجات. تتيح لك هذه التأثيرات التحكم في مظهر الشرائح في الفيديو النهائي عبر إضافة انتقالات سلسة، تحريكات، وعناصر بصرية أخرى. يشرح هذا القسم خيارات تأثيرات الفيديو المتاحة ويظهر كيفية تطبيقها.

{{% alert color="primary" %}} 

اطلع على [تحريك PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/)، [تحريك الشكل](https://docs.aspose.com/slides/python-net/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

تجعل التحريكات والانتقالات العروض أكثر جاذبية وإثارة — وتفعل نفس الشيء للفيديوهات. لنضيف شريحة أخرى وانتقالًا إلى الكود للعرض السابق:
```python
import aspose.pydrawing as drawing

# إضافة شكل بابتسامة وتحريكه.
# ...
# إضافة شريحة جديدة وانتقال متحرك.
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```


يدعم Aspose.Slides for Python أيضًا تحريكات النص. في هذا المثال، نقوم بتحريك الفقرات على الكائنات بحيث تظهر واحدة تلو الأخرى، مع تأخير ثانية واحدة بينهما:
```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة نص وتحريكات.
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

لتمكين مهام تحويل PowerPoint إلى فيديو، يوفر Aspose.Slides for Python الفئة [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

`PresentationEnumerableAnimationsGenerator` يسمح لك بتعيين حجم الإطار للفيديو (الذي سيُنشأ لاحقًا) وقيمة FPS (الإطارات في الثانية) عبر المُنشئ الخاص به. إذا مررت كائن عرض، سيتم استخدام `Presentation.SlideSize` الخاص به.

لجعل جميع التحريكات في عرض تُشغَّل مرة واحدة، استخدم الطريقة `PresentationEnumerableAnimationsGenerator.enumerate_frames`. تأخذ هذه الطريقة مجموعة من الشرائح وتعيد بشكل متسلسل [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). ثم استخدم `EnumerableFrameArgs.get_frame()` للحصول على كل إطار فيديو.
```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```


بعد ذلك يمكن تجميع الإطارات المُولدة في فيديو. لمزيد من التفاصيل، راجع قسم [Convert PowerPoint to Video](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الحركات والتأثيرات المدعومة**

عند تحويل عرض PowerPoint إلى فيديو باستخدام Aspose.Slides for Python، من المهم فهم أي الحركات والتأثيرات المدعومة في المخرجات. يدعم Aspose.Slides مجموعة واسعة من تأثيرات الدخول، الخروج، والتأكيد الشائعة مثل التلاشي، الطيران، التكبير، والدوران. ومع ذلك، قد لا تُحافظ بعض الحركات المتقدمة أو المخصصة بالكامل أو قد تظهر بشكل مختلف في الفيديو النهائي. يوضح هذا القسم الحركات والتأثيرات المدعومة.

**الدخول**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

| نوع الحركة | Aspose.Slides | PowerPoint |
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

| نوع الحركة | Aspose.Slides | PowerPoint |
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

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Arcs** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Turns** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Shapes** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Loops** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Custom Path** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **تأثيرات انتقال الشرائح المدعومة**

تلعب تأثيرات انتقال الشرائح دورًا مهمًا في إنشاء تغييرات سلسة وجذابة بصريًا بين الشرائح في الفيديو. يدعم Aspose.Slides for Python مجموعة متنوعة من تأثيرات الانتقال الشائعة للمساعدة في الحفاظ على تدفق وعرض العرض الأصلي. يوضح هذا القسم أي من تأثيرات الانتقال مدعومة أثناء عملية التحويل.

**دقيق**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

**مثير**:

| نوع الحركة | Aspose.Slides | PowerPoint |
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

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Ferris Wheel** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **Conveyor** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Rotate** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Orbit** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **Fly Through** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **الأسئلة الشائعة**

**هل يمكن تحويل العروض التقديمية المحمية بكلمة مرور؟**

نعم، يتيح Aspose.Slides for Python العمل مع العروض التقديمية المحمية بكلمة مرور. عند معالجة مثل هذه الملفات، تحتاج إلى توفير كلمة المرور الصحيحة حتى يتمكن المكتبة من الوصول إلى محتوى العرض.

**هل يدعم Aspose.Slides for Python الاستخدام في حلول السحابة؟**

نعم، يمكن دمج Aspose.Slides for Python في التطبيقات والخدمات السحابية. صُممت المكتبة للعمل في بيئات الخوادم، مع ضمان أداء عالي وقابلية توسعة لمعالجة دفعات الملفات.

**هل هناك أي حدود لحجم العروض التقديمية أثناء التحويل؟**

يمكن لـ Aspose.Slides for Python التعامل مع العروض التقديمية ذات الحجم الافتراضي تقريبًا. ومع ذلك، قد تتطلب الملفات الكبيرة موارد نظام إضافية، وقد يُنصح أحيانًا بتحسين العرض لتحسين الأداء.