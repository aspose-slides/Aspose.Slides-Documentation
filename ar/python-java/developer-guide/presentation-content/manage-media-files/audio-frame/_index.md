---
title: إدارة إطارات الصوت في العروض التقديمية باستخدام Python
linktitle: إطار صوت
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
- Python
- Aspose.Slides
description: "تضمين الصوت في الشرائح، تغيير أيقونة الصوت، تكوين التشغيل، إدارة ترجمات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides لـ Python عبر Java."
---
## **نظرة عامة**

تتيح لك إطارات الصوت تشغيل ملف صوتي على الشريحة. باستخدام Aspose.Slides for Python via Java، يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، تعديل طريقة التشغيل، وإرفاق ترجمات. يمكنك أيضًا استرداد الصوت المعيّن لانتقال الشريحة.

## **إنشاء إطارات صوتية**

أضف البايتات من `audio.wav` إلى مجموعة الصوت في العرض، ثم استخدم [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) لتضمين مقطع صوتي محلي على الشريحة الأولى. الإحداثيين الأولين يحددان موضع الإطار على الشريحة، والقيمتين التاليتين تحددان عرضه وارتفاعه بالنقاط. تستدعي هذه المثال [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) لتشغيل المقطع تلقائيًا وتستدعي [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) لاختيار إعداد الصوت العالي.

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

## **تغيير صورة إطارة الصوت المصغرة**

افتراضيًا، تعرض إطارة الصوت أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض باستخدام [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) واضبطها على صورة الإطار باستخدام [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). يستخدم المثال ملف JPEG كصورة مصغرة للمقطع الصوتي المضمّن.

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

    audio_data = Path("audio.wav").read_bytes()
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

تتحكم **خيارات الصوت** في PowerPoint في متى يبدأ المقطع، ومدى صوته، وسلوكه أثناء عرض الشرائح.

![خيارات الصوت في PowerPoint لإطار صوتي](audio_frame_0.png)

| التحكم في PowerPoint | طريقة Aspose.Slides for Python via Java |
| --- | --- |
| تشغيل | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| إعداد مستوى الصوت | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| تشغيل عبر الشرائح | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| التكرار حتى الإيقاف | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| إخفاء أثناء العرض | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| إعادة تشغيل بعد التشغيل | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| ظهور تدريجي | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| اختفاء تدريجي | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| قص وقت بدء الصوت | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| قص وقت نهاية الصوت | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| شريط مستوى الصوت | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

يقوم المثال بالعثور على أول إطار صوتي في الشريحة الأولى، ويستدعي [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) لتشغيل المقطع بنقرة، ويختار إعداد الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. تبقى الأيقونة مخفية أثناء العرض، ويُعيد المقطع تشغيل نفسه بعد الانتهاء.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # تشغيل عند النقر بصوت منخفض، عبر الشرائح، بدون التكرار.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # إخفاء الإطار أثناء عرض الشرائح وإعادة تشغيله بعد التشغيل.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

للمقاطع التي تزيد مدتها عن 3.5 ثوانٍ، يتخطى هذا المثال الثواني 1.5 الأولى و2 الثانية الأخيرة. تستخدم [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) المدة التي تُحذف من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الإزاحة من المدة الكاملة للمقطع. يتم إضاءة المقطع المتقصى تدريجيًا خلال 200 مللي ثانية وإخماده خلال 500 مللي ثانية. جميع الطرق الأربعة تقبل القيم بالمللي ثانية.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # قص 1.5 ثانية من البداية و2 ثانية من النهاية.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # تعيين ظهور تدريجي إلى 200 مللي ثانية واختفاء تدريجي إلى 500 مللي ثانية.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لضبط مستوى الصوت إلى نسبة مئوية معينة، استخدم [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). يضبط هذا المثال أول إطار صوتي في الشريحة الأولى إلى 85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **إدارة ترجمات الصوت**

توفر كل إطار صوتي إمكانية الوصول إلى مسارات الترجمات من خلال [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). استخدم المجموعة لإرفاق ترجمات WebVTT بالمقطع، أو تصدير المسارات الموجودة، أو إزالتها.

### **إضافة ترجمات صوتية**

يقوم المثال بتضمين مقطع صوتي على الشريحة الأولى ويستخدم [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) لإرفاق مسار WebVTT محلي. يُزوّد المعامل الأول تسمية المسار، ويحدّد المعامل الثاني ملف الترجمات الزمني.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # إضافة مسار ترجمة جديد من ملف WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استخراج ترجمات صوتية**

يصدّر هذا المثال كل مسار ترجمة مرفق بإطار صوتي على الشريحة الأولى. يكتب البايتات التي تُرجعها [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) إلى ملف WebVTT ويستخدم المعرف الذي تُرجعه [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) كاسم للملف بحيث يكون لكل مسار مخرج منفصل.

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
                # احفظ مسار الترجمة كملف .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **إزالة ترجمات صوتية**

استخدم [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) لحذف مسار فردي. يستخدم المثال [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) لإزالة جميع الترجمات من أول إطار صوتي في الشريحة الأولى مع الحفاظ على المقطع.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **البحث عن سطر في ترجمات الصوت**

للبحث عن سطر في ترجمات الصوت على الشريحة الأولى، ابحث في النص الذي تُرجعه [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) في الذاكرة. في إشارة WebVTT نصية، يحتوي سطر التوقيت على `-->`، وتتبعه سطور الترجمات، وينتهي الإشارة بسطر فارغ. يطبع هذا المثال تسمية المسار وكل سطر ترجمة يحتوي على كلمة “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **استخراج الصوت**

يمكن لانتقال الشريحة أن يحتوي على صوت خاص به. لاسترجاعه، استدعِ [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) على انتقال الشريحة. يصل المثال إلى البايتات التي تُرجعها [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) ويطبع عدد البايتات. إذا لم يكن للشفرة الأولى صوت انتقال، يطبع رسالة بدلاً من ذلك.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس المقطع الصوتي عبر شرائح متعددة دون نسخه؟**

نعم. أضف المقطع مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) الخاص بالعرض ومرّر كائن الصوت نفسه إلى [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوتي موجود؟**

نعم. للصوت المرتبط، استخدم [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) لتوجيهه إلى الملف البديل. للصوت المضمّن، اختر مقطعًا آخر من مجموعة الصوت في العرض باستخدام [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). كلا الطريقتين تحافظان على الإطار الحالي.

**هل يغيّر القص بيانات الصوت المخزنة في العرض؟**

لا. تقوم [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) و[setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) بتحديد حدود التشغيل. لا يزال بإمكانك استرجاع المقطع الكامل عبر [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).