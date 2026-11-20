---
title: إدارة إطارات الصوت في العروض التقديمية باستخدام Python
linktitle: إطار صوتي
type: docs
weight: 10
url: /ar/python-net/audio-frame/
keywords:
- صوت
- إطار صوت
- صورة مصغرة
- إضافة صوت
- خصائص الصوت
- خيارات الصوت
- استخراج الصوت
- WebVTT
- Python
- Aspose.Slides
description: "تضمين الصوت في الشرائح، تغيير أيقونة الصوت، تكوين التشغيل، إدارة تسميات WebVTT، واستخراج أصوات انتقال الشرائح باستخدام Aspose.Slides للـ Python عبر .NET."
---
## **نظرة عامة**

إطار صوتي يتيح لك تشغيل صوت على شريحة. مع Aspose.Slides للـ Python عبر .NET، يمكنك تضمين مقطع صوتي، اختيار الصورة التي تمثله، تعديل التشغيل، وإرفاق التسميات التوضيحية. يمكنك أيضًا استرداد صوت مرتبط بانتقال الشريحة.

## **إنشاء إطارات صوتية**

استخدم [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) لتضمين مقطع صوتي محلي على الشريحة الأولى. الإحداثيان الأولان يحددان موضع الإطار على الشريحة، والقيمتان التاليان تحددان العرض والارتفاع، جميعها بوحدات النقاط. يحدد هذا المثال [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) لتشغيل المقطع تلقائيًا و [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) إلى إعداد الصوت العالي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير صورة الإطار الصوتي**

بشكل افتراضي، يعرض الإطار الصوتي أيقونة مكبر صوت. لعرض صورة مصغرة مخصصة، أضف صورة إلى العرض التقديمي باستخدام [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) وعينها لخاصية [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) للإطار. يستخدم المثال ملف JPEG كصورة مصغرة لمقطع صوتي مضمّن.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير خيارات تشغيل الصوت**

تتحكم عناصر **Audio Options** في PowerPoint في متى يبدأ المقطع، ومدى صوته، وكيفية تصرفه خلال عرض الشرائح.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| تحكم PowerPoint | خاصية Aspose.Slides |
| --- | --- |
| ابدأ | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| إعداد مستوى الصوت | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| تشغيل عبر الشرائح | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| تكرار حتى الإيقاف | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| إخفاء أثناء العرض | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| إعادة للأمام بعد التشغيل | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| تلاشي الدخول | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| تلاشي الخروج | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| تقليم بدء الصوت | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| تقليم نهاية الصوت | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| شريط مستوى الصوت | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

يجد المثال الإطار الصوتي الأول على الشريحة الأولى، ويضبط [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) لتشغيل المقطع عند النقر، ويختار إعداد الصوت المنخفض. يستمر المقطع عبر الشرائح مع تعطيل التكرار. تظل الأيقونة مخفية أثناء العرض، ويعيد المقطع تشغيله من البداية بعد الانتهاء.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

للمقطع الذي يزيد طوله عن 3.5 ثانية، يتخطى هذا المثال الثواني الأولى 1.5 والثانية الأخيرة 2. يقيس [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) المدة التي يجب حذفها من نهاية المقطع. للحصول على وقت النهاية المعروض في PowerPoint، اطرح هذا الإزاحة من المدة الكاملة للمقطع. يتلاشى المقطع المُقَصَّى خلال 200 مللي ثانية ويتلاشى الخروج خلال 500 مللي ثانية. جميع الخصائص الأربعة تأخذ قيمًا بالمللي ثانية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

لتعيين مستوى تشغيل الصوت بنسبة مئوية محددة، استخدم [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). يحدد المثال الإطار الصوتي الأول على الشريحة الأولى إلى 85٪.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة تسميات الصوت**

كل إطار صوتي يحتوي على مجموعة [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). استخدمها لإرفاق تسميات WebVTT بالمقطع، أو تصدير المسارات الموجودة، أو إزالتها.

### **إضافة تسميات صوتية**

يضمّن المثال مقطع صوتي على الشريحة الأولى ويستخدم [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) لإرفاق مسار WebVTT محلي. يُعطي الوسيط الأول تسمية المسار، والوسيط الثاني يحدد الملف الذي يحتوي على التسميات الزمنية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج تسميات الصوت**

يصدّر هذا المثال كل مسار تسميات مرفق بإطار صوتي على الشريحة الأولى. يكتب البيانات الثنائية للمسار [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) إلى ملف WebVTT ويستخدم [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) كاسم للملف بحيث يكون لكل مسار مخرج منفصل.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **إزالة تسميات الصوت**

استخدم [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) أو [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) لحذف مسار فردي. يستخدم المثال [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) لإزالة جميع التسميات من الإطار الصوتي الأول على الشريحة الأولى مع الحفاظ على المقطع.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **العثور على سطر في تسميات الصوت**

للعثور على سطر في تسميات الصوت على الشريحة الأولى، اقرأ [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) لكل مسار في الذاكرة. في إشارة WebVTT نصية عادية، يحتوي سطر التوقيت على `-->`، وتلي ذلك سطور التسميات، وينتهي الإشارة بسطر فارغ. يطبع المثال تسمية المسار وكل سطر تسميات يحتوي على كلمة “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **استخراج الصوت**

يمكن أن يحتوي انتقال الشريحة على صوت خاص به. لاسترداده، اقرأ خاصية [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) للانتقال. يصل المثال إلى البيانات الثنائية [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) للصوت ويطبع حجمه بالبايت. إذا لم تكن الشريحة الأولى تحتوي على صوت للانتقال، يطبع رسالة بدلاً من ذلك.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام نفس المقطع الصوتي عبر شرائح متعددة دون تكراره؟**

نعم. أضف المقطع مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) الخاصة بالعرض التقديمي، ثم مرر كائن الصوت نفسه إلى [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) لكل شريحة.

**هل يمكنني استبدال الصوت في إطار صوتي موجود؟**

نعم. بالنسبة لصوت مرتبط، حدّث [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) للإشارة إلى ملف الاستبدال. بالنسبة لصوت مضمّن، عيّن مقطعًا آخر من مجموعة الأصوات في العرض التقديمي إلى [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). كلا الطريقتين تحافظان على الإطار الحالي.

**هل يؤثر التقليم على بيانات الصوت المخزنة في العرض التقديمي؟**

لا. يحدد كل من [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) و[trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) حدود تشغيل المقطع. لا يزال بإمكانك استرداد المقطع الكامل من [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).