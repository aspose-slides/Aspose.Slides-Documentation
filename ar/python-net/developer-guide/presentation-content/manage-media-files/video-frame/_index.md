---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام Python
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. دليل سريع عملي."
---
## **مقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. تتيح لك Aspose.Slides for Python عبر .NET إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات عبر الإنترنت، مثل فيديوهات YouTube.

To represent video data and video frames, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) class, and other relevant types.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

يقوم هذا المثال بتضمين فيديو محلي في الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بوحدة النقاط. يبقى التدفق مفتوحًا حتى الانتهاء من الحفظ لأن [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) يبقه مقفلًا أثناء استخدام العرض التقديمي له.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). يضيف هذا المثال الفيديو إلى الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يرتبط بفيديو عبر الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرّف الفيديو لاستخدام فيديو آخر. يطلب إعداد [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) تشغيلًا تلقائيًا. تحميل الصورة المصغرة وتشغيل الفيديو يتطلبان اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي تشغيل الفيديو عبر الإنترنت كذلك.

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

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تقديمي تدريبي، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. اضبط [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) إلى `True` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرض تقديمي، ويبحث عن أول [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي عرض التقديم الإدخالي على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، يتحكم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) فيما إذا كان يبدأ تلقائيًا أو عند النقر، ويتحكم [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) فيما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إعادة فيديو العرض التوضيحي إلى بدايته تجعله جاهزًا للمُقدِّم لتشغيله مرة أخرى. اضبط [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) إلى `True` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرض تقديمي، ويبحث عن أول [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) في الشريحة الأولى، ويفعل إرجاع الفيديو. يقوم بتعطيل التكرار حتى يتمكن التشغيل من الانتهاء ويضبط بدء التشغيل عند النقر. يجب أن يحتوي عرض التقديم الإدخالي على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

تعيد الإعادة الفيديو إلى بدايته دون تشغيله مرة أخرى. وعلى النقيض من ذلك، يؤدي تمكين [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) إلى تكرار التشغيل تلقائيًا. ابقِ التكرار معطلًا عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. يتحكم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) بشكل مستقل في البدء التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) بحيث يتحكم المُقدم في موعد بدء التشغيل. اضبط وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. تعمل الإعادة بشكل مستقل عن [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **قص إطار فيديو**

استخدم [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) و[VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. كلا القيمتين بو وحدة الميللي ثانية. يؤدي القص إلى تغيير إعدادات التشغيل دون تعديل بيانات الفيديو المضمنة.

**ضبط إعدادات القص**

يقوم هذا المثال بتضمين فيديو محلي ويتخطى أول 2.5 ثانية والثانية الأخيرة أثناء التشغيل. استخدم فيديوً أطول من 3.5 ثانية لتبقى قطعة قابلة للتشغيل.

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

**قراءة إعدادات القص**

يقوم هذا المثال بطباعة قيم القص لأول إطار فيديو في الشريحة الأولى بوحدة الميللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع شيء. ينتج المثال السابق القيم 2500 و1000.

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

تتيح لك Aspose.Slides إدارة التسميات التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُعرض عبر الخاصية [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**إضافة تسميات إلى إطار فيديو**

يقوم هذا المثال بتضمين فيديو محلي ويضيف مسار تسميات WebVTT مسمى English. يجب أن تتطابق طوابع الوقت للتسميات مع الفيديو. يحتوي العرض التقديمي المحفوظ على الفيديو وتسم.ياته.

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

توفر فئة [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) أيضًا تحميلًا زائدًا يتيح لك إضافة تسميات من تدفق.

**استخراج تسميات من إطار فيديو**

يقوم هذا المثال بحفظ جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تُحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. يوضح الطرفية عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) يُظهر معرّف التسمية، والملصق، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة تسميات من إطار فيديو**

يقوم هذا المثال بإزالة جميع التسميات من إطار الفيديو الموجود في الموقع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

إذا احتجت إلى إزالة مسار تسميات واحد فقط، استخدم طرق [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) أو [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) بدلاً من [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة فيديوهات إلى الشرائح، تتيح لك Aspose.Slides استخراج الفيديوهات المضمنة في العروض التقديمية.

يقوم هذا المثال باستخراج الفيديوهات المضمنة من كل شريحة إلى ملفات ثنائية منفصلة مرقمة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمّنة. يطبع الطرفية نوع MIME لكل فيديو والعدد الإجمالي. يستخدم الناتج الامتداد العام `.bin`؛ غّره ليناسب نوع الوسائط المبلغ عنه عند الحاجة.

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

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بدمج فيديو محلي، تُضمّن البيانات الثنائية في المستند، لذلك يزداد حجم العرض التقديمي بنسبة حجم الملف. عندما تربط بفيديو عبر الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا عادةً ما يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك تبديل [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. يحتوي الفيديو المضمن على [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.