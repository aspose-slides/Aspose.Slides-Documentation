---
title: إدارة الصوت في العروض باستخدام بايثون
linktitle: إطار الصوت
type: docs
weight: 10
url: /ar/python-net/audio-frame/
keywords:
- إضافة صوت
- تضمين صوت
- إطار صوت
- ملف صوت
- خصائص صوت
- استخراج صوت
- استرجاع صوت
- تغيير صوت
- خيارات تشغيل
- وضع تشغيل
- تشغيل عبر الشرائح
- تكرار حتى التوقف
- إخفاء أثناء العرض
- إعادة التدوير بعد التشغيل
- مستوى صوت
- الصورة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف، استخرج وادارة إطارات الصوت بسهولة في ملفات PPT و PPTX و ODP باستخدام Aspose.Slides لبايثون عبر .NET. استكشف أمثلة الشيفرة وحسّن عروضك التقديمية اليوم."
---

## **إنشاء أطر الصوت**

تسمح لك Aspose.Slides for Python عبر .NET بإضافة ملفات صوتية إلى الشرائح. يتم تضمين ملفات الصوت في الشرائح كأطر صوتية. 

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة عبر الفهرس الخاص بها.
3. حمّل تدفق ملف الصوت الذي تريد تضمينه في الشريحة.
4. أضف إطار الصوت المضمن (الذي يحتوي على ملف الصوت) إلى الشريحة.
5. قم بتعيين [PlayMode](https://reference.aspose.com/slides/python-net/aspose.slides/audioplaymodepreset) و`Volume` المعروضين بواسطة كائن [IAudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) .
6. احفظ العرض التقديمي المعدل.

يُظهر لك هذا الكود بلغة Python كيفية إضافة إطار صوت مضمّن إلى شريحة:
```python
import aspose.slides as slides

# إنشاء كائن من فئة العرض التقديمي التي تمثل ملف عرض تقديمي
with slides.Presentation() as pres:
    # جلب الشريحة الأولى
    sld = pres.slides[0]

    # تحميل ملف صوت wav إلى دفق
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # إضافة إطار الصوت
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # تعيين وضع التشغيل ومستوى الصوت للملف الصوتي
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # حفظ ملف PowerPoint إلى القرص
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير صورة مصغرة لإطار الصوت**

عند إضافة ملف صوتي إلى عرض تقديمي، يظهر الصوت كإطار يحتوي على صورة افتراضية قياسية (انظر الصورة في القسم أدناه). يمكنك تغيير الصورة المصغرة لإطار الصوت (حدد الصورة التي تفضلها).

يُظهر لك هذا الكود بلغة Python كيفية تغيير الصورة المصغرة أو صورة المعاينة لإطار الصوت:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة إطار صوت إلى الشريحة بموقع وحجم محددين.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # إضافة صورة إلى موارد العرض.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # تعيين الصورة لإطار الصوت.
        audioFrame.picture_format.picture.image = audioImage
        
        #حفظ العرض المعدل إلى القرص
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير خيارات تشغيل الصوت**

تسمح لك Aspose.Slides for Python عبر .NET بتغيير الخيارات التي تتحكم في تشغيل الصوت أو خصائصه. على سبيل المثال، يمكنك تعديل مستوى صوت الصوت، ضبط تشغيل الصوت بشكل متكرر، أو حتى إخفاء أيقونة الصوت.

لوحة **Audio Options** في Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) الخصائص:
- **Start** قائمة منسدلة تتطابق مع خاصية [AudioFrame.play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) .
- **Volume** تتطابق مع خاصية [AudioFrame.volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) .
- **Play Across Slides** تتطابق مع خاصية [AudioFrame.play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) .
- **Loop until Stopped** تتطابق مع خاصية [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) .
- **Hide During Show** تتطابق مع خاصية [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) .
- **Rewind after Playing** تتطابق مع خاصية [AudioFrame.rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) .

خيارات **Editing** في PowerPoint التي تتطابق مع خصائص Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/) الخصائص:
- **Fade In** تتطابق مع خاصية [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) .
- **Fade Out** تتطابق مع خاصية [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) .
- **Trim Audio Start Time** تتطابق مع خاصية [AudioFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) .
- قيمة **Trim Audio End Time** تساوي مدة الصوت ناقص قيمة خاصية [AudioFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) .

يتطابق **Volume controll** في PowerPoint على لوحة التحكم الصوتية مع خاصية [AudioFrame.volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) . يتيح لك تعديل مستوى الصوت كنسبة مئوية.

هذه هي طريقة تغيير خيارات تشغيل الصوت:
1. [إنشاء](#create-audio-frame) أو الحصول على إطار الصوت.
2. حدد قيمًا جديدة لخصائص إطار الصوت التي تريد تعديلها.
3. احفظ ملف PowerPoint المعدل.

يُظهر لك هذا الكود بلغة Python عملية تعديل خيارات الصوت:
```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # جلب شكل AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # ضبط وضع التشغيل لتشغيل عند النقر
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # ضبط مستوى الصوت إلى منخفض
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # ضبط تشغيل الصوت عبر الشرائح
    audioFrame.play_across_slides = True

    # إلغاء تفعيل التكرار للصوت
    audioFrame.play_loop_mode = False

    # إخفاء AudioFrame أثناء العرض التقديمي
    audioFrame.hide_at_showing = True

    # إعادة تشغيل الصوت من البداية بعد الانتهاء
    audioFrame.rewind_audio = True

    # حفظ ملف PowerPoint على القرص
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```


يُظهر هذا المثال بلغة Python كيفية إضافة إطار صوت جديد مع صوت مضمّن، قصه، وتعيين مدّات التلاشي:
```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # تعيين إزاحة بدء التقليم إلى 1.5 ثانية
    audio_frame.trim_from_start = 1500.0
    # تعيين إزاحة نهاية التقليم إلى 2 ثانية
    audio_frame.trim_from_end = 2000.0

    # تعيين مدة التلاشي عند الدخول إلى 200 مللي ثانية
    audio_frame.fade_in_duration = 200.0
    # تعيين مدة التلاشي عند الخروج إلى 500 مللي ثانية
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```


يعرض مقتطف الشيفرة التالي كيفية استرجاع إطار صوت مع صوت مضمّن وتعيين مستوى صوته إلى 85٪:
```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # الحصول على شكل إطار صوتي
    audio_frame = pres.slides[0].shapes[0]

    # تعيين مستوى صوت الإطار إلى 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```


## **استخراج الصوت**

تسمح لك Aspose.Slides for Python عبر .NET باستخراج الصوت المستخدم في انتقالات عرض الشرائح. على سبيل المثال، يمكنك استخراج الصوت المستخدم في شريحة معينة.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الصوت.
2. احصل على مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى انتقالات عرض الشرائح لتلك الشريحة.
4. استخراج الصوت كبيانات بايت.

يُظهر لك هذا الكود بلغة Python كيفية استخراج الصوت المستخدم في شريحة:
```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # الوصول إلى الشريحة المطلوبة
    slide = pres.slides[0]  

    # الحصول على تأثيرات الانتقال للعرض التقديمي للشريحة
    transition = slide.slide_show_transition

    # استخراج الصوت كمصفوفة بايت
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```


## **الأسئلة الشائعة**

**هل يمكنني إعادة استخدام ملف الصوت نفسه عبر شرائح متعددة دون زيادة حجم الملف؟**

نعم. أضف الصوت مرة واحدة إلى مجموعة [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) المشتركة في العرض التقديمي وأنشئ أطر صوتية إضافية تشير إلى ذلك الأصل الموجود. هذا يمنع تكرار بيانات الوسائط ويحافظ على حجم العرض تحت السيطرة.

**هل يمكنني استبدال الصوت في إطار صوت موجود دون إعادة إنشاء الشكل؟**

نعم. بالنسبة لصوت مرتبط، حدّث [link path](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) للإشارة إلى الملف الجديد. بالنسبة لصوت مضمّن، استبدل كائن [embedded audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) بآخر من مجموعة [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) في العرض التقديمي. يظل تنسيق الإطار ومعظم إعدادات التشغيل بدون تغيير.

**هل يغيّر التقليم البيانات الصوتية الأساسية المخزنة في العرض التقديمي؟**

لا. يقتصر التقليم على تعديل حدود التشغيل فقط. تظل بايتات الصوت الأصلية دون تغيير ويمكن الوصول إليها من خلال الصوت المضمّن أو مجموعة الصوت في العرض التقديمي.