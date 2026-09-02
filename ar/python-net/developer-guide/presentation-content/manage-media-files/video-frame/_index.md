---
title: إضافة مقاطع فيديو إلى العروض التقديمية في بايثون
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET. دليل سريع لكيفية التنفيذ."
---
## **مقدمة**

يمكن أن يجعل الفيديو المناسب في العرض التقديمي رسالتك أكثر إقناعًا ويزيد من مستوى التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) وأنواع أخرى ذات صلة. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. احصل على إشارة إلى الشريحة من خلال فهرستها. 
1. أضف كائن [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) ومرّر مسار ملف الفيديو لتضمينه مع العرض التقديمي. 
1. أضف كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) لإنشاء إطار للفيديو.  
1. احفظ العرض التقديمي المعدل. 

هذا الكود بلغة Python يوضح لك كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # يحصل على الشريحة الأولى ويضيف إطار فيديو
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # يحفظ العرض التقديمي إلى القرص
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

تدعم الإصدارات الأحدث من Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الويب (مثل YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر الرابط الخاص به.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. احصل على إشارة إلى الشريحة من خلال فهرستها. 
1. أضف كائن [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) ومرّر الرابط إلى الفيديو.
1. عيّن صورة مصغرة لإطار الفيديو. 
1. احفظ العرض التقديمي. 

هذا الكود بلغة Python يوضح لك كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # يضيف إطار فيديو
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # يحمل الصورة المصغرة
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تقليم إطار الفيديو**

تتيح لك Aspose.Slides التحكم في الجزء الذي يُشغل من الفيديو عن طريق تعيين قيم trim-from-start وtrim-from-end من خلال [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_start/) و[VideoFrame.trim_from_end](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_end/). تُحدّد القيم بالملي ثانية وتحدد مقدار الوقت الذي يُتخطى من بداية الفيديو ونهايته على التوالي. هذه الإعدادات تغير طريقة تشغيل الفيديو في العرض التقديمي؛ ولا تقص أو تعدل البيانات الثنائية للفيديو المضمّن.

**ضبط إعدادات التقليم**

لإنشاء إطار فيديو وضبط إعدادات التقليم الخاصة به:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. أضف كائن [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) إلى العرض التقديمي.
1. أضف كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) إلى شريحة.
1. عيّن قيم trim-from-start وtrim-from-end عبر [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_start/) و[VideoFrame.trim_from_end](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_end/) .
1. احفظ العرض التقديمي المعدل.

مثال الكود التالي يتخطى الثانيتين والنصف الأولى والثانية الأخيرة من الفيديو المضمّن أثناء التشغيل:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**قراءة إعدادات التقليم**

لفحص إعدادات التقليم الحالية، حمّل عرضًا تقديميًا، وابحث عن كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) بين الأشكال في الشريحة الأولى، واقرأ القيم عبر [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_start/) و[VideoFrame.trim_from_end](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/trim_from_end/) .

مثال الكود التالي يجد أول إطار فيديو في الشريحة الأولى ويعرض إعدادات تقليمه بالملي ثانية:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **إدارة التسميات التوضيحية للفيديو**

تتيح لك Aspose.Slides إدارة التسميات التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزَّن التسميات بتنسيق WebVTT وتُعرض عبر الخاصية [VideoFrame.caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/) .

**إضافة تسميات توضيحية إلى إطار الفيديو**

لإضافة تسميات توضيحية إلى إطار فيديو:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) .
1. أضف فيديو إلى العرض التقديمي.
1. أضف كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) إلى شريحة.
1. استخدم [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) التي تُرجعها الخاصية [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/) لإضافة مسار تسميات WebVTT.
1. احفظ العرض التقديمي المعدل.

الكود التالي يوضح لك كيفية إضافة تسميات توضيحية إلى إطار فيديو:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # يضيف مسار تسميات جديد من ملف WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

توفّر فئة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) أيضًا نسخة محسّنة تسمح لك بإضافة تسميات من دفق بيانات.

**استخراج التسميات التوضيحية من إطار الفيديو**

لاستخراج التسميات التوضيحية من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. ابحث عن كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) المستهدف.
1. تنقّ عبر مجموعة [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/) .
1. احفظ كل مسار تسميات في ملف `.vtt`.

الكود التالي يوضح لك كيفية استخراج التسميات التوضيحية من إطار فيديو:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # يحفظ مسار التسميات إلى ملف WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

كل كائن [Captions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captions/) يُظهر معرف التسمية، والعنوان، والبيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات التوضيحية من إطار الفيديو**

لإزالة التسميات التوضيحية من إطار فيديو:

1. حمّل العرض التقديمي الذي يحتوي على الفيديو.
1. احصل على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) المستهدف.
1. أزل مسارات التسميات من [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) .
1. احفظ العرض التقديمي المعدل.

الكود التالي يوضح لك كيفية إزالة جميع التسميات التوضيحية من إطار فيديو:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # النوع: slides.VideoFrame

    # يزيل جميع التسميات من إطار الفيديو.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طريقتي [remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove/) أو [remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove_at/) بدلاً من [clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/clear/) .

## **استخراج الفيديو من الشريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، تتيح لك Aspose.Slides استخراج الفيديوهات المضمّنة في العروض التقديمية.

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. تنقّ عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/) .
3. تنقّ عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) . 
4. احفظ الفيديو على القرص.

هذا الكود بلغة Python يوضح لك كيفية استخراج الفيديو من شريحة في عرض PowerPoint:

```python
import aspose.slides as slides

# يجري إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **الأسئلة المتداولة**

**ما هي معايير تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/play_loop_mode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تدمج فيديوًا محليًا، تُضمّن البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يُدمج رابط وصورة مصغرة فقط، لذا يكون الزيادة في الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على أبعاد الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مضمّن؟**

نعم. يحتوي الفيديو المضمّن على [نوع محتوى](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.