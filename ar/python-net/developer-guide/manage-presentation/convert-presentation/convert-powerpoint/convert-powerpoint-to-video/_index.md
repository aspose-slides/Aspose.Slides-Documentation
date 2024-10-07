---
title: تحويل PowerPoint إلى فيديو
type: docs
weight: 130
url: /python-net/convert-powerpoint-to-video/
keywords: "تحويل PowerPoint, PPT, PPTX, تقديم, فيديو, MP4, PPT إلى فيديو, PPT إلى MP4, Python, Aspose.Slides"
description: "تحويل PowerPoint إلى فيديو باستخدام Python"
---

من خلال تحويل عرض PowerPoint الخاص بك إلى فيديو، ستحصل على 

* **زيادة في الوصول:** جميع الأجهزة (بغض النظر عن النظام) مزودة بلاعب فيديو بشكل افتراضي مقارنة بتطبيقات فتح العروض التقديمية، لذا يجد المستخدمون أنه من الأسهل فتح أو تشغيل الفيديوهات.
* **وصول أكبر:** من خلال الفيديوهات، يمكنك الوصول إلى جمهور كبير واستهدافهم بمعلومات قد تبدو مملة في عرض تقديمي. تشير معظم الاستطلاعات والإحصائيات إلى أن الناس يشاهدون ويستهلكون الفيديوهات أكثر من أشكال المحتوى الأخرى، ويفضلون عمومًا مثل هذا المحتوى.

{{% alert color="primary" %}} 

قد ترغب في التحقق من [**محول PowerPoint إلى فيديو عبر الإنترنت**](https://products.aspose.app/slides/conversion/ppt-to-word) لأنه يمثل تنفيذًا حيًا وفعالًا للعملية الموصوفة هنا.

{{% /alert %}} 

## **تحويل PowerPoint إلى فيديو في Aspose.Slides**

في [Aspose.Slides 24.4](https://releases.aspose.com/slides/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/)، قمنا بتنفيذ دعم تحويل العروض التقديمية إلى فيديو.

* استخدم Aspose.Slides لإنشاء مجموعة من الإطارات (من شرائح العرض التقديمي) التي تتوافق مع FPS معينة (الإطارات في الثانية)
* استخدم أداة خارجية مثل ffmpeg لإنشاء فيديو بناءً على الإطارات.

### **تحويل PowerPoint إلى فيديو**

1. استخدم أمر تثبيت pip لإضافة Aspose.Slides إلى مشروعك:
   * قم بتشغيل `pip install Aspose.Slides==24.4.0`
2. قم بتنزيل ffmpeg [هنا](https://ffmpeg.org/download.html) أو قم بتثبيته عبر مدير الحزم.
3. تأكد من أن ffmpeg موجود في `PATH`، وإلا قم بتشغيل ffmpeg باستخدام المسار الكامل للثنائي (مثل `C:\ffmpeg\ffmpeg.exe` على Windows أو `/opt/ffmpeg/ffmpeg` على Linux)
4. قم بتشغيل الكود الخاص بتحويل PowerPoint إلى فيديو.

يوضح هذا الكود بلغة Python كيفية تحويل عرض تقديمي (يحتوي على شكل ومؤثرين حركيين) إلى فيديو:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    smile = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)
    effect_in = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.TOP_LEFT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_out = presentation.slides[0].timeline.main_sequence.add_effect(smile, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM_RIGHT, slides.animation.EffectTriggerType.AFTER_PREVIOUS)
    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "smile.webm"]
    subprocess.call(cmd_line)
```

## **مؤثرات الفيديو**

يمكنك تطبيق حركات على العناصر في الشرائح واستخدام انتقالات بين الشرائح.

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على هذه المقالات: [حركة PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-animation/)، [حركة الشكل](https://docs.aspose.com/slides/python-net/shape-animation/)، و[تأثير الشكل](https://docs.aspose.com/slides/python-net/shape-effect/).

{{% /alert %}} 

تجعل الرسوم المتحركة والانتقالات العروض التقديمية أكثر جاذبية وإثارة — وتفعل الشيء نفسه للفيديوهات. دعونا نضيف شريحة أخرى وانتقال إلى الكود الخاص بالعرض التقديمي السابق:

```python
import aspose.pydrawing as drawing
# إضافة شكل مبتسم وتحريكه
# ...
# إضافة شريحة جديدة وانتقال متحرك

new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

يدعم Aspose.Slides أيضًا الرسوم المتحركة للنصوص. لذا قمنا بتحريك الفقرات على العناصر، التي ستظهر واحدة تلو الأخرى (مع تأخير محدد بساعة):

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    # إضافة نصوص ورسوم متحركة
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose Slides for .NET"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("تحويل عرض PowerPoint مع نص إلى فيديو"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("فقرة تلو الأخرى"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = presentation.slides[0].timeline.main_sequence.add_effect(para1, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = presentation.slides[0].timeline.main_sequence.add_effect(para2, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = presentation.slides[0].timeline.main_sequence.add_effect(para3, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # تحويل الإطارات إلى فيديو
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **فئات تحويل الفيديو**

لتتمكن من تنفيذ مهام تحويل PowerPoint إلى فيديو، يوفر Aspose.Slides [PresentationEnumerableAnimationsGenerator](https://reference.aspose.com/slides/python-net/aspose.slides.export/presentationenumerableanimationsgenerator/).

يتيح لك PresentationEnumerableAnimationsGenerator تحديد حجم الإطار الخاص بالفيديو (الذي سيتم إنشاؤه لاحقًا) وقيمة FPS (الإطارات في الثانية) من خلال منشئه. إذا قمت بتمرير مثيل العرض التقديمي، سيتم استخدام `Presentation.SlideSize`.

لجعل جميع الرسوم المتحركة في العرض التقديمي تعمل دفعة واحدة، استخدم طريقة PresentationEnumerableAnimationsGenerator.enumerate_frames. تأخذ هذه الطريقة مجموعة من الشرائح وتسمح بالحصول بشكل تسلسلي على [EnumerableFrameArgs](https://reference.aspose.com/slides/python-net/aspose.slides.export/enumerableframeargs/). ثم، يسمح لك EnumerableFrameArgs.get_frame() بالحصول على إطار الفيديو:

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

ثم يمكن تجميع الإطارات الناتجة لإنتاج فيديو. انظر إلى قسم [تحويل PowerPoint إلى فيديو](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **الرسوم المتحركة المدعومة والتأثيرات**


**دخول**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **ظهور** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التحليق في** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طفو في** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عجلة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو ولف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوارن** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |


**تركيز**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **نبض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **نبض لون** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تأرجح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوران** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **نمو/تصغير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تخفيف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تعتيم** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **إضاءة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شفافية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون العنصر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون مكمل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون خط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **لون ملء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**خروج**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **اختفاء** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **التحليق خارجًا** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **طفو خارجًا** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تصغير وتحويل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوارن** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ارتداد** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مسارات الحركة:**

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **خطوط** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أقواس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تحولات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **أشكال** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دوارات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسار مخصص** | ![مدعوم](v.png) | ![مدعوم](v.png) |

## **تأثيرات الانتقال للشرائح المدعومة**

**خفيفة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **تحول** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تلاشي** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **دفع** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **سحب** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **مسح** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **انقسام** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **كشف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أشرطة عشوائية** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شكل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **كشف** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **غطاء** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **ومضات** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **شرائط** | ![مدعوم](v.png) | ![مدعوم](v.png) |

**مليئة بالإثارة**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **سقوط فوق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تغطية** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ستائر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ريح** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **هيبة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تحطيم** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **دمر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **قش** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **التفاف الصفحة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **طائرة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أوريغامي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ذوبان** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تشكيلة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ستائر** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **ساعة** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **تموج** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **شباك العسل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تألق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **دوامة** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تمزق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تبديل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **قلب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **صالة عرض** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مكعب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **أبواب** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **صندوق** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مشط** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تكبير** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **عشوائي** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |

**محتوى ديناميكي**:

| نوع الرسوم المتحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **بان** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **عجلة فيريس** | ![مدعوم](v.png) | ![مدعوم](v.png) |
| **حزام ناقل** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **تدوير** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **مدار** | ![غير مدعوم](x.png) | ![مدعوم](v.png) |
| **التحليق** | ![مدعوم](v.png) | ![مدعوم](v.png) |