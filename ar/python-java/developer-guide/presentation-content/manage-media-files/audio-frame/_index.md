---
title: إدارة الصوت في العروض التقديمية باستخدام بايثون
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/python-java/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- بايثون
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides للبايثون عبر جافا — أمثلة على الشيفرة لتضمين، قص، تكرار، وتكوين تشغيل عبر عروض PPT و PPTX و ODP."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع إطارات الصوت في Aspose.Slides. تُظهر كيفية إضافة صوت مضمّن إلى الشرائح، وتخصيص صورة المصغّر لإطار الصوت، وتكوين خيارات التشغيل مثل مستوى الصوت، والتكرار، والإخفاء، والقص، ومدد التلاشي، واستخراج الصوت المستخدم في انتقالات عرض الشرائح.

## **إنشاء إطارات الصوت**

Aspose.Slides for Python via Java يتيح لك إضافة ملفات صوتية إلى الشرائح. تُضمّن ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى شريحة بحسب فهرستها.
3. قراءة ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المضمّن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. استخدام الأسلوبين [setPlayMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayMode) و[setVolume](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolume) المتاحين عبر كائن [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/).
6. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يُظهر لك كيفية إضافة إطار صوت مضمّن إلى شريحة:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير صورة المصغّر لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة معاينة إطار الصوت إلى صورة من اختيارك.

هذا الكود بلغة Python يُظهر لك كيفية تغيير صورة المصغّر أو صورة المعاينة لإطار الصوت:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Python via Java يتيح لك تعديل الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك ضبط مستوى صوت الصوت، أو تعيين الصوت للتكرار، أو حتى إخفاء رمز الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/):

- **Start** قائمة منسدلة تتطابق مع طريقة [setPlayMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** تتطابق مع طريقة [setVolume](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** تتطابق مع طريقة [setPlayAcrossSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** تتطابق مع طريقة [setPlayLoopMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** تتطابق مع طريقة [setHideAtShowing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** تتطابق مع طريقة [setRewindAudio](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setRewindAudio)

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/):

- **Fade In** تتطابق مع طريقة [setFadeInDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** تتطابق مع طريقة [setFadeOutDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** تتطابق مع طريقة [setTrimFromStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحاً منها القيمة المحددة بواسطة طريقة [setTrimFromEnd](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setTrimFromEnd)

تحكم **Volume** في PowerPoint على لوحة تحكم الصوت يتطابق مع طريقة [setVolumeValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolumeValue). يسمح لك بتغيير مستوى الصوت كنسبة مئوية.

هذا هو كيفية تغيير خيارات تشغيل الصوت:

1. [Create](#create-audio-frames) أو الحصول على إطار الصوت.
2. تعيين قيم جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

هذا الكود بلغة Python يُظهر عملية تعديل خيارات الصوت:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # تشغيل عند النقر بحجم صوت منخفض، عبر الشرائح، دون تكرار.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # إخفاء الإطار أثناء عرض الشرائح وإعادة الرجوع بعد التشغيل.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

هذا المثال في Python يُظهر كيفية إضافة إطار صوت جديد مضمّن، قصه، وتعيين مدد التلاشي:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # قص 1.5 ثانية من البداية و 2 ثانية من النهاية.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # اضبط التلاشي الافتتاحي إلى 200 مللي ثانية والتلاشي الختامي إلى 500 مللي ثانية.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

العينة البرمجية التالية تُظهر كيفية استرجاع إطار صوت مضمّن وتعيين مستوى صوته إلى 85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **إدارة تسميات الصوت**

Aspose.Slides يتيح لك إضافة تسميات نصية مغلقة إلى إطار صوت عبر طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#getCaptionTracks). تُرجع هذه الطريقة كائنًا من نوع [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/)، والذي يتيح لك إضافة مسارات تسميات WebVTT، والت iterating عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم طريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#getCaptionTracks) لإرفاق مسار أو أكثر من مسارات التسمية إلى إطار صوت. في المثال التالي، يُضاف ملف صوت إلى شريحة، ثم يتم تحميل مسار تسمية جديد من ملف `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # أضف مسار تسمية توضيحية جديد من ملف WebVTT.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**استخراج تسميات صوتية**

يمكنك iterating خلال مسارات التسمية المرتبطة بإطار صوت وحفظها كملفات `.vtt`. كل مسار تسمية يُظهر بياناته الثنائية ومعرفه الفريد، والذي يمكن استخدامه عند تصدير التسميات.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # احفظ مسار التسمية كملف .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**إزالة تسميات صوتية**

لإزالة التسميات من إطار صوت، استخدم الأساليب المقدمة من [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/)، مثل [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#remove)، أو [removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#removeAt). المثال التالي يزيل جميع مسارات التسمية من إطار صوت.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **استخراج الصوت**

Aspose.Slides for Python via Java يتيح لك استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع إلى الشريحة ذات الصلة بحسب فهرستها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideShowTransition) لتلك الشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود في Python يُظهر لك كيفية استخراج الصوت المستخدم في شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAudios) المشترك في العرض التقديمي وأنشئ إطارات صوت إضافية تشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض التقديمي تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة إلى صوت مرتبط، حدّث [link path](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setLinkPathLong) للإشارة إلى الملف الجديد. بالنسبة إلى صوت مضمّن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setEmbeddedAudio) بآخر من [audio collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAudios) في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل دون تغيير.

**هل يغيّر القص البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. القص يضبط حدود التشغيل فقط. تبقى بايتات الصوت الأصلية دون تعديل وتستطيع الوصول إليها عبر الصوت المضمّن أو مجموعة الصوت في العرض التقديمي.