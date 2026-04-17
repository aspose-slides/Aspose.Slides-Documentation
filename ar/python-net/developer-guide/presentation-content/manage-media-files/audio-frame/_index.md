---
title: إدارة الصوت في العروض التقديمية باستخدام Python
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/python-net/audio-frame/
keywords:
- إضافة صوت
- دمج صوت
- إطار صوت
- ملف صوت
- خصائص الصوت
- استخراج صوت
- استرجاع صوت
- تغيير صوت
- خيارات تشغيل
- وضع تشغيل
- تشغيل عبر الشرائح
- تكرار حتى الإيقاف
- إخفاء أثناء العرض
- إرجاع بعد التشغيل
- حجم الصوت
- صورة افتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف، استخرج وأدر إطارات الصوت بسهولة في PPT و PPTX و ODP باستخدام Aspose.Slides للـ Python عبر .NET. استكشف أمثلة الشيفرة وحسّن عروضك التقديمية اليوم."
---
## **إنشاء إطارات صوتية**

Aspose.Slides for Python via .NET يسمح لك بإضافة ملفات صوتية إلى الشرائح. تُدمج ملفات الصوت في الشرائح كإطارات صوتية. 

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. تحميل تدفق ملف الصوت الذي تريد دمجه في الشريحة.
4. إضافة إطار الصوت المدمج (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. تعيين [PlayMode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioplaymodepreset) و `Volume` المعروضة بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/) .
6. حفظ العرض التقديمي المعدل.

هذا الكود بلغة Python يوضح لك كيفية إضافة إطار صوتي مدمج إلى شريحة:

```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي الذي يمثل ملف عرض تقديمي
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # تحميل ملف الصوت wav إلى تدفق
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # إضافة إطار الصوت
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # تعيين وضع التشغيل وحجم الصوت للصوت
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # كتابة ملف PowerPoint إلى القرص
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير صورة إطارات الصوت المصغرة**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير صورة الإطار المصغرة (استخدام الصورة التي تفضلها).

هذا الكود بلغة Python يوضح لك كيفية تغيير صورة مصغرة أو صورة معاينة لإطار الصوت:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # يضيف إطار صوتي إلى الشريحة بموقع وحجم محددين.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # يضيف صورة إلى موارد العرض التقديمي.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # يضع الصورة لإطار الصوت.
        audioFrame.picture_format.picture.image = audioImage
        
        #يحفظ العرض التقديمي المعدل إلى القرص
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغيير خيارات تشغيل الصوت**

Aspose.Slides for Python via .NET يسمح لك بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل حجم الصوت، ضبط تشغيل الصوت بصورة متكررة، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

خيارات **Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/) :

- قائمة **Start** المنسدلة تتطابق مع خاصية [AudioFrame.play_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** يتطابق مع خاصية [AudioFrame.volume](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** يتطابق مع خاصية [AudioFrame.play_across_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** يتطابق مع خاصية [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** يتطابق مع خاصية [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** يتطابق مع خاصية [AudioFrame.rewind_audio](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/rewind_audio/) 

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/) :

- **Fade In** يتطابق مع خاصية [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** يتطابق مع خاصية [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** يتطابق مع خاصية [AudioFrame.trim_from_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/trim_from_start/) 
- قيمة **Trim Audio End Time** تساوي مدة الصوت ناقص قيمة خاصية [AudioFrame.trim_from_end](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/trim_from_end/) 

تحكم **Volume** في لوحة التحكم الصوتية في PowerPoint يتطابق مع خاصية [AudioFrame.volume_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/volume_value/) . يتيح لك تعديل حجم الصوت بالنسبة المئوية.

هذه هي الطريقة لتغيير خيارات تشغيل الصوت:

1. [Сreate](#create-audio-frame) أو الحصول على إطار الصوت.
2. تعيين القيم الجديدة للخصائص التي تريد تعديلها في إطار الصوت.
3. حفظ ملف PowerPoint المعدل.

هذا الكود بلغة Python يوضح عملية تعديل خيارات الصوت:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # الحصول على شكل AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # تعيين وضع التشغيل ليعمل عند النقر
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # تعيين مستوى الصوت إلى منخفض
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # تعيين الصوت للتشغيل عبر الشرائح
    audioFrame.play_across_slides = True

    # تعطيل التكرار للصوت
    audioFrame.play_loop_mode = False

    # إخفاء AudioFrame أثناء عرض الشرائح
    audioFrame.hide_at_showing = True

    # إعادة تشغيل الصوت من البداية بعد التشغيل
    audioFrame.rewind_audio = True

    # حفظ ملف PowerPoint إلى القرص
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

هذا المثال بلغة Python يوضح كيفية إضافة إطار صوتي جديد مع صوت مدمج، قصه، وتعيين مدد التلاشي:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # تعيين إزاحة بداية القطع إلى 1.5 ثانية
    audio_frame.trim_from_start = 1500.0
    # تعيين إزاحة نهاية القطع إلى 2 ثانية
    audio_frame.trim_from_end = 2000.0

    # تعيين مدة التلاشي التدريجي إلى 200 مللي ثانية
    audio_frame.fade_in_duration = 200.0
    # تعيين مدة التلاشي التدريجي إلى 500 مللي ثانية
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

العينة البرمجية التالية توضح كيفية استرجاع إطار صوتي مع صوت مدمج وتعيين مستوى الصوت إلى 85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # الحصول على شكل إطار صوتي
    audio_frame = pres.slides[0].shapes[0]

    # تعيين مستوى الصوت إلى 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة تسميات الصوت**

Aspose.Slides يسمح لك بإضافة تسميات مغلقة إلى إطار صوتي عبر الخاصية [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/caption_tracks/) . تُعيد هذه الخاصية كائنًا من نوع [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) ، والذي يتيح لك إضافة مسارات WebVTT، التكرار عبر المسارات الموجودة، وإزالتها عند الحاجة.

**إضافة تسميات صوتية**

استخدم الخاصية [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/caption_tracks/) لإرفاق مسار أو أكثر إلى إطار صوتي. في المثال التالي، يُضاف ملف صوتي إلى شريحة، ثم يتم تحميل مسار تسمية جديد من ملف `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # إضافة مسار تسمية جديد من ملف WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**استخراج تسميات الصوت**

يمكنك التكرار عبر مسارات التسمية المرتبطة بإطار صوتي وحفظها كملفات `.vtt`. كل مسار تسمية يكشف عن بياناته الثنائية ومعرفه الفريد، الذي يمكن استخدامه عند تصدير التسميات.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # احفظ مسار التسمية كملف .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**إزالة تسميات الصوت**

لإزالة التسميات من إطار صوتي، استخدم الأساليب المتوفرة في [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) مثل [clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/clear/)، [remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove/)، أو [remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove_at/). المثال التالي يزيل جميع مسارات التسمية من إطار صوتي.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # نوع: slides.AudioFrame

    # إزالة جميع مسارات التسمية من إطار الصوت.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الصوت**
Aspose.Slides for Python via .NET يسمح لك باستخراج الصوت المستخدم في انتقالات عروض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. الحصول على مرجع الشريحة المطلوبة عبر فهرسها.
3. الوصول إلى انتقالات العرض المتحرك للشريحة.
4. استخراج الصوت كبيانات بايت.

هذا الكود بلغة Python يوضح لك كيفية استخراج الصوت المستخدم في شريحة:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # الوصول إلى الشريحة المطلوبة
    slide = pres.slides[0]  

    # الحصول على تأثيرات انتقال عرض الشرائح للشريحة
    transition = slide.slide_show_transition

    #استخراج الصوت كمصفوفة بايت
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**هل يمكنني إعادة استخدام نفس ملف الصوت عبر عدة شرائح دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى [audio collection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/audios/) المشتركة في العرض التقديمي وأنشئ إطارات صوتية إضافية تُشير إلى ذلك الأصل. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوتي موجود دون إنشاء الشكل من جديد؟**

نعم. بالنسبة لصوت مرتبط، قم بتحديث [link path](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/link_path_long/) للإشارة إلى الملف الجديد. بالنسبة لصوت مدمج، استبدل كائن [embedded audio](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/embedded_audio/) بآخر من [audio collection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/audios/) الخاصة بالعرض. يظل تنسيق الإطار ومعظم إعدادات التشغيل كما هي.

**هل يؤدي القص إلى تغيير بيانات الصوت الأساسية المخزنة في العرض التقديمي؟**

لا. القص يضبط حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها عبر الصوت المدمج أو مجموعة الصوت في العرض.