---
title: إدارة الصوت في العروض التقديمية باستخدام بايثون
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/python-java/audio-frame/
keywords:
- الصوت
- إطار الصوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- بايثون
- Aspose.Slides
description: "إنشاء والتحكم في إطارات الصوت في Aspose.Slides لـ بايثون عبر Java—أمثلة تعليمية لتضمين الصوت، قصه، تكراره، وتكوين التشغيل عبر عروض PPT و PPTX و ODP."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع إطارات الصوت في Aspose.Slides. تُظهر كيفية إضافة صوت مدمج إلى الشرائح، تخصيص الصورة المصغرة لإطار الصوت، تكوين خيارات التشغيل مثل مستوى الصوت، التكرار، الإخفاء، القطع، ومدد التلاشي، واستخراج الصوت المستخدم في انتقالات عرض الشرائح.

## **إنشاء إطارات الصوت**

تتيح لك Aspose.Slides for Python via Java إضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. قراءة ملف الصوت الذي تريد تضمينه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. ضبط [setPlayMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayMode) و[setVolume](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolume) المعروضين بواسطة كائن [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/) .
6. حفظ العرض التقديمي المعدل.

هذا الكود بايثون يوضح لك كيفية إضافة إطار صوت مدمج إلى شريحة:

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

## **تغيير الصورة المصغرة لإطار الصوت**

عند إضافة ملف صوت إلى عرض تقديمي، يظهر الصوت كإطار بصورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة المعاينة لإطار الصوت (تحديد الصورة المفضلة لديك).

هذا الكود بايثون يوضح لك كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:

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

تتيح لك Aspose.Slides for Python via Java تغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، ضبط تشغيل الصوت بتكرار، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/) :

- **Start** قائمة منسدلة تتطابق مع طريقة [setPlayMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** تتطابق مع طريقة [setVolume](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** تتطابق مع طريقة [setPlayAcrossSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** تتطابق مع طريقة [setPlayLoopMode](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** تتطابق مع طريقة [setHideAtShowing](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** تتطابق مع طريقة [setRewindAudio](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setRewindAudio)

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/) :

- **Fade In** تتطابق مع طريقة [setFadeInDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** تتطابق مع طريقة [setFadeOutDuration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** تتطابق مع طريقة [setTrimFromStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** القيمة تساوي مدة الصوت مطروحاً منها قيمة طريقة [setTrimFromEnd](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setTrimFromEnd)

تحكم **Volume** في PowerPoint على لوحة تحكم الصوت يتطابق مع طريقة [setVolumeValue](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setVolumeValue) . يتيح لك تغيير مستوى الصوت كنسبة مئوية.

إليك خطوات تغيير خيارات تشغيل الصوت:

1. [إنشاء](#create-audio-frames) أو الحصول على إطار الصوت.
2. ضبط القيم الجديدة لخصائص إطار الصوت التي تريد تعديلها.
3. حفظ ملف PowerPoint المعدل.

هذا الكود بايثون يوضح عملية تعديل خيارات الصوت:

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
        # تشغيل عند النقر بحجم منخفض، عبر الشرائح، بدون تكرار.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # إخفاء الإطار أثناء عرض الشرائح وإعادة التدوير بعد التشغيل.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

هذا المثال بايثون يوضح كيفية إضافة إطار صوت جديد مع صوت مدمج، قصه، وضبط مدد التلاشي:

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

    # قص 1.5 ثانية من البداية و2 ثانية من النهاية.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # ضبط التلاشي التدريجي إلى 200 مللي ثانية و التلاشي الخارج إلى 500 مللي ثانية.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

العينة البرمجية التالية توضح كيفية استرجاع إطار صوت مدمج وضبط مستوى صوته إلى 85%:

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

## **إدارة توضيحات الصوت**

تتيح لك Aspose.Slides إضافة توضيحات مغلقة إلى إطار الصوت عبر الطريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#getCaptionTracks) . تُرجع هذه الطريقة مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/)، مما يتيح لك إضافة مسارات توضيحات WebVTT، التكرار عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة توضيحات صوتية**

استخدم الطريقة [getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#getCaptionTracks) لإرفاق مسار توضيح واحد أو أكثر بإطار الصوت. في المثال التالي يُضاف ملف صوت إلى شريحة، ثم يتم تحميل مسار توضيح جديد من ملف `.vtt` .

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

    # إضافة مسار توضيح جديد من ملف WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**استخراج توضيحات صوتية**

يمكنك التكرار عبر مسارات التوضيح المرتبطة بإطار الصوت وحفظها كملفات `.vtt`. كل مسار توضيح يكشف عن بياناته الثنائية ومعرفه الفريد، مما يمكن استخدامه عند تصدير التوضيحات.

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
                # احفظ مسار التوضيح كملف .vtt.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**إزالة توضيحات صوتية**

لإزالة التوضيحات من إطار الصوت، استخدم الطرق المتوفرة في [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/)، مثل [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#remove)، أو [removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#removeAt). المثال التالي يزيل جميع مسارات التوضيح من إطار الصوت.

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

تتيح لك Aspose.Slides for Python via Java استخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى [slideshow transitions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getSlideShowTransition) للشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود بايثون يوضح لك كيفية استخراج الصوت المستخدم في شريحة:

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

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAudios) المشترك في العرض التقديمي وأنشئ إطارات صوت إضافية تشير إلى هذا الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة للصوت المرتبط، حدّث [link path](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setLinkPathLong) للإشارة إلى الملف الجديد. بالنسبة للصوت المدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/#setEmbeddedAudio) بآخر من [audio collection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getAudios) الخاص بالعرض. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يغيّر القطع البيانات الصوتية الأساسية المخزنة في العرض؟**

لا. يقتصر القطع على تعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية كما هي ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض.