---
title: تحويل عروض PowerPoint إلى فيديو في Python
linktitle: PowerPoint إلى فيديو
type: docs
weight: 130
url: /ar/python-java/convert-powerpoint-to-video/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى فيديو
- العرض إلى فيديو
- PPT إلى فيديو
- PPTX إلى فيديو
- PowerPoint إلى MP4
- العرض إلى MP4
- PPT إلى MP4
- PPTX إلى MP4
- حفظ PPT كـ MP4
- حفظ PPTX كـ MP4
- تصدير PPT إلى MP4
- تصدير PPTX إلى MP4
- تحويل الفيديو
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى فيديو MP4 باستخدام Python عبر Java. إنشاء إطارات باستخدام Aspose.Slides وترميزها باستخدام FFmpeg، بما في ذلك الحركات والانتقالات."
---
## **نظرة عامة**

تحويل عرض PowerPoint أو عرض OpenDocument إلى فيديو يسمح للمشاهدين بمشاهدة المحتوى في مشغل فيديو دون فتح تطبيق العروض التقديمية. تقوم Aspose.Slides for Python via Java بتحويل الحركات والانتقالات في العرض إلى إطارات صور. ثم يقوم مُشفّر منفصل، مثل FFmpeg، بدمج تلك الإطارات في ملف فيديو.

{{% alert color="info" title="ملاحظة" %}}
جرّب محوّل [PowerPoint إلى فيديو](https://products.aspose.app/slides/ar/video) عبر الإنترنت لتشاهد عملية التحويل عمليًا.
{{% /alert %}}

## **تحويل PowerPoint إلى فيديو**

يتضمن التحويل مرحلتين: إنشاء إطارات PNG بمعدل إطارات مختار، ثم تشفير تسلسل الصور إلى MP4. استخدم نفس معدل الإطارات في المرحلتين للحفاظ على توقيت الحركات.

قبل تشغيل المثال:

1. أعد إعداد [Aspose.Slides for Python via Java](/slides/ar/python-java/installation/).
2. نزّل [FFmpeg](https://ffmpeg.org/download.html) وتأكد من أن ملف التنفيذ متاح في `PATH`. يستخدم المثال نسخة تحتوي على مُشفّر `libx264`.
3. شغّل شفرة Python التالية في دليل يمكن الكتابة فيه.

ينشئ المثال شكلاً مبتسمًا مع حركات دخول وخروج، يُولّد الإطارات بمعدل 30 إطارًا في الثانية، ويستدعي FFmpeg لإنشاء `output.mp4`. يمنع دليل الإطارات الجديد تضمين إطارات من تشغيلات سابقة في الفيديو.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

لتحويل ملف موجود، قم بتهيئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) بمساره وتجاهل عبارات إنشاء الشكل وإنشاء الحركة.

يقرأ أمر FFmpeg تسلسل [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) مرقم، يضيف حشو للأبعاد الفردية لتصبح مزدوجة، ويكتب فيديو H.264 بصيغة البكسل `yuv420p`. يمنع خيار `-n` الكتابة فوق ملف الإخراج الموجود. تبقى ملفات PNG المُولّدة في دليل الإطارات؛ احذفها عندما لا تعود بحاجة إليها.

{{% alert color="info" title="ملاحظة" %}}
هذا المثال يشفر إطارات الصور فقط. لا يضيف سردًا صوتيًا أو صوت عرض مضمّن إلى الفيديو الناتج.
{{% /alert %}}

## **تأثيرات الفيديو**

تتحكم الحركات في كيفية ظهور كائنات الشريحة أو تحركها أو اختفائها. تتحكم الانتقالات في التغيير بين الشرائح. أضف هذه التأثيرات قبل إنشاء إطارات الفيديو.

اطلع على [PowerPoint Animation](/slides/ar/python-java/powerpoint-animation/)، [Shape Animation](/slides/ar/python-java/shape-animation/)، [Shape Effects](/slides/ar/python-java/shape-effect/)، و[Slide Transitions](/slides/ar/python-java/slide-transition/).

### **إضافة انتقال شريحة**

المثال المستقل التالي ينشئ عرضًا يتضمن شريحتين. الشريحة الثانية لديها خلفية بنفسجية وانتقال دفع. احفظ العرض، ثم استخدمه كمدخل للمثال الخاص بإنشاء الإطارات أعلاه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تحريك الفقرات**

يمكن أن يظهر النص فقرة بفقرة. ينشئ هذا المثال ثلاث فقرات مع تأثيرات دخول تلاشي متسلسلة، كل واحدة متأخرة ثانية واحدة بعد السابقة. استخدم ملف `paragraphs.pptx` المحفوظ كمدخل لمثال تحويل الفيديو.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **فئات تحويل الفيديو**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationanimationsgenerator/) يولد أحداث الحركات للشرائح. إن إنشاؤه من عرضٍ يستخدم حجم شريحة العرض للإطارات. استخدم [setDefaultDelay](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) لتكوين التأخير الافتراضي بالميلليثانية.

[PresentationPlayer](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationplayer/) يعيّن عينات الحركات المولّدة بمعدل الإطارات الممرّر إلى مُنشئه. سجّل استدعاءً رجعيًا في Python عبر JPype باستخدام [setFrameTick](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationplayer/#setFrameTick)، ثم استدعِ [run](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationanimationsgenerator/#run) لتوليد الإطارات. يستخدم المثال الأول عداده الخاص الصفري بحيث تتطابق أسماء الملفات مع تسلسل إدخال FFmpeg.

لحالات حركة فردية، سجّل استدعاءً رجعيًا باستخدام [setNewAnimation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation). يتلقى الاستدعاء لاعب حركة يمكن وضعه عند زمن مختار. المثال التالي يحفظ أول وآخر إطار من كل حركة مولّدة بأسماء ملفات فريدة:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **الحركات والتأثيرات المدعومة**

تلخّص الجداول التالية الدعم المقدم في مقالة التحويل للـ Java. يمكنك معاينة الإطارات المولّدة عندما يستخدم العرض تأثيرات غير مدعومة.

**الدخول**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly In** | Yes | Yes |
| **Float In** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Wheel** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Grow & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**التأكيد**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | No | Yes |
| **Color Pulse** | No | Yes |
| **Teeter** | Yes | Yes |
| **Spin** | Yes | Yes |
| **Grow/Shrink** | No | Yes |
| **Desaturate** | No | Yes |
| **Darken** | No | Yes |
| **Lighten** | No | Yes |
| **Transparency** | No | Yes |
| **Object Color** | No | Yes |
| **Complementary Color** | No | Yes |
| **Line Color** | No | Yes |
| **Fill Color** | No | Yes |

**الخروج**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | No | Yes |
| **Fade** | Yes | Yes |
| **Fly Out** | Yes | Yes |
| **Float Out** | Yes | Yes |
| **Split** | Yes | Yes |
| **Wipe** | Yes | Yes |
| **Shape** | Yes | Yes |
| **Random Bars** | Yes | Yes |
| **Shrink & Turn** | No | Yes |
| **Zoom** | Yes | Yes |
| **Swivel** | Yes | Yes |
| **Bounce** | Yes | Yes |

**مسارات الحركة**:

| نوع الحركة | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | Yes | Yes |
| **Arcs** | Yes | Yes |
| **Turns** | Yes | Yes |
| **Shapes** | Yes | Yes |
| **Loops** | Yes | Yes |
| **Custom Path** | Yes | Yes |

## **الأسئلة المتكررة**

**هل تنشئ Aspose.Slides ملف MP4 مباشرةً؟**

لا. تقوم Aspose.Slides بتوليد إطارات العرض. استخدم مُشفّر فيديو مثل FFmpeg لدمجها في ملف MP4.

**لماذا يتم تشغيل الفيديو أسرع أو أبطأ مما هو متوقع؟**

استخدم نفس FPS لتوليد الإطارات ومدخل المشفّر. عدم التطابق يغيّر مدة تشغيل تسلسل الصور.

**هل يمكنني تحويل عرض محمي بكلمة مرور؟**

نعم. زوّد كلمة المرور الصحيحة عند [تحميل العرض المحمي](/slides/ar/python-java/password-protected-presentation/)، ثم ولّد الإطارات من المحتوى المحمّل.

**هل يحافظ هذا سير العمل على صوت العرض؟**

الأمثلة تصدر إطارات صور فقط، لذا يكون الفيديو الناتج صامتًا. لتضمين الصوت، قدّم مسار صوت منفصل أثناء تشفير الفيديو.

**كيف يمكنني تقليل استهلاك القرص المؤقت؟**

استخدم حجم إطار أصغر أو FPS أقل، واحذف ملفات PNG المؤقتة بعد الانتهاء من الترميز بنجاح. تحقق من جودة الفيديو الناتج عند تعديل أي من الإعدادين.