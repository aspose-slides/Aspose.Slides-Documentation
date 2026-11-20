---
title: إدارة إطارات الفيديو في العروض التقديمية بلغة Python
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/python-net/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- تضمين فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: 'تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Python عبر .NET. دليل سريع خطوة بخطوة.'
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. يتيح Aspose.Slides لـ Python عبر .NET إمكانية إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المدمجة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات على الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزناً محلياً، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

هذا المثال يدمج فيديو محلي في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدات النقاط. يبقى التيار مفتوحاً حتى يكتمل الحفظ لأن [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) يحافظ على القفل أثناء استخدام العرض التقديمي له.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضاً تمرير مسار الفيديو المحلي مباشرة إلى [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). هذا المثال يدمج الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحاً حتى يتم حفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) يدعم الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط بفيديو على الإنترنت، مثل فيديو YouTube.

هذا المثال يضيف رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. إعداد [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) يطلب تشغيلاً تلقائياً. تحميل الصورة المصغرة وتشغيل الفيديو يتطلب اتصالاً بالإنترنت. يجب أن يدعم عارض العرض التقديمي تشغيل الفيديو عبر الإنترنت.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **تشغيل فيديو بوضع ملء الشاشة**

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. اضبط [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) على `True` لتفعيل هذا السلوك أثناء التشغيل.

هذا المثال يفتح عرضاً تقديمياً، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) في الشريحة الأولى، ويفعّل تشغيل ملء الشاشة. يجب أن يحتوي العرض المدخل على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

تشغيل ملء الشاشة يتحكم في طريقة عرض الفيديو. بشكل مستقل، يتحكم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ما إذا كان يبدأ تلقائياً أو عند النقر، ويتحكم [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ما إذا كان يتكرر. لاختيار سلوك البداية، اضبط وضع التشغيل إلى [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إعادة تشغيل الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إعادة الفيديو التوضيحي إلى بدايته يجعله جاهزاً للمقدم لتشغيله مرة أخرى. اضبط [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) على `True` لإعادة الفيديو إلى البداية بعد انتهاء التشغيل.

هذا المثال يفتح عرضاً تقديمياً، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) في الشريحة الأولى، ويفعّل إرجاع التشغيل. يعطل التكرار حتى يكتمل التشغيل ويضبط التشغيل على البدء عند النقر. يجب أن يحتوي العرض المدخل على شريحة واحدة على الأقل بها إطار فيديو موجود في الشريحة الأولى.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

إرجاع التشغيل يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، تمكين [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) يكرر التشغيل تلقائياً. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويظل جاهزاً للإعادة. يتحكم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) بشكل مستقل في بدء التشغيل تلقائياً أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) لتسمح للمقدم بتحديد متى يبدأ التشغيل. اضبط وضع التشغيل بعد إعداد التكرار كما هو موضح في المثال. يعمل إرجاع التشغيل بشكل مستقل عن [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **تقليم إطار فيديو**

استخدم [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) و[VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم كلاهما بالمليثوان. يغير التقليم إعدادات التشغيل دون تعديل بيانات الفيديو المدمجة.

**ضبط إعدادات التقليم**

هذا المثال يدمج فيديو محلي ويتخطى أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية لضمان بقاء جزء قابل للتشغيل.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**قراءة إعدادات التقليم**

هذا المثال يطبع قيم التقليم لأول إطار فيديو في الشريحة الأولى بالمليثوان. يجب أن يحتوي العرض على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **إدارة تسميات الفيديو**

Aspose.Slides يسمح لك بإدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ التسميات بتنسيق WebVTT وتُظهر عبر الخاصية [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **إضافة تسميات إلى إطار فيديو**

هذا المثال يدمج فيديو محلي ويضيف مسار تسميات WebVTT يحمل اسم English. يجب أن تتطابق طوابع الوقت للتسميات مع الفيديو. يتضمن العرض المحفوظ كلًا من الفيديو وتسمياته.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

فئة [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) توفر أيضًا تحميلًا مفرطًا يتيح لك إضافة تسميات من تيار.

### **استخراج التسميات من إطار فيديو**

هذا المثال يحفظ جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. الأرقام المتسلسلة تحافظ على تميز ملفات الإخراج. يرسل وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض على شريحة واحدة على الأقل.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

كل كائن [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) يُظهر معرف التسيمة، التسمية، البيانات الثنائية، ونص التسيمة كسلسلة UTF-8.

### **إزالة التسميات من إطار فيديو**

هذا المثال يزيل جميع التسميات من إطار الفيديو في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

إذا احتجت إلى إزالة مسار تسيمة واحد فقط، استخدم الطرقتين [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) أو [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) بدلاً من [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **بحث عن تسميات الفيديو**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) تُرجع المسار الكامل لـ WebVTT، بما في ذلك الرأس، سطور التوقيت، ونص التسيمة. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على هذه الإشارة:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

هذا المثال يفتح `captioned_media.pptx` ويقرأ [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) لكل إطار فيديو من المستوى العلوي في كل شريحة. لكل إشارة نصية عادية، ي寻找 سطر التوقيت الذي يحتوي على `-->` ويجمع أسطر التسميات حتى السطر الفارغ التالي أو نهاية المسار. يبحث في نص التسيمة عن “café” بغض النظر عن حالة الأحرف ويطبع رقم الشريحة، تسمية المسار، سطر التوقيت الأصلي، والتسيمة بالكامل لكل مطابقة.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

المسار النموذجي ينتج مطابقة واحدة. “Café” في الرأس خارج نص التسيمة، ويُحافظ الإخراج على إعداد التوقيت والسطرين.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

إلى جانب إضافة الفيديوهات إلى الشرائح، يسمح Aspose.Slides لك باستخراج الفيديوهات المدمجة في العروض التقديمية.

هذا المثال يستخرج الفيديوهات المدمجة من كل شريحة إلى ملفات ثنائية منفصلة مرقمة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مدمجة. يطبع وحدة التحكم نوع MIME لكل فيديو والعدد الإجمالي. يستخدم الإخراج الامتداد العام `.bin`؛ يمكن تغييره ليتطابق مع نوع الوسائط المُبلغ عنه عند الحاجة.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار الفيديو؟**  
يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**  
نعم. عندما تدمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما ترتبط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادة ما يكون الزيادة أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موضعه وحجمه؟**  
نعم. يمكنك تبديل [محتوى الفيديو](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**  
نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.