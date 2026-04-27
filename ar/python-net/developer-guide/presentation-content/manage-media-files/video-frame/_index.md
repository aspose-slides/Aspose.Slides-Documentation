---
title: إضافة مقاطع فيديو إلى العروض التقديمية باستخدام بايثون
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
description: "تعرّف على كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. دليل سريع خطوة بخطوة."
---
يمكن للفيديو الموضوع بشكل مناسب في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك. 

يسمح PowerPoint لك بإضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة فيديو محلي أو تضمينه (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/)، الفئة [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) وأنواع أخرى ذات صلة. 

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع الشريحة عبر فهرسها.  
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي.  
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل.  

يعرض هذا الكود Python كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # الحصول على الشريحة الأولى وإضافة إطار فيديو
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # حفظ العرض التقديمي إلى القرص
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى الدالة `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال رابط الويب الخاص به. 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. الحصول على مرجع الشريحة عبر فهرسها.  
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/) وتمرير الرابط إلى الفيديو.  
1. تعيين صورة مصغرة لإطار الفيديو.  
1. حفظ العرض التقديمي.  

يعرض هذا الكود Python كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # يضيف إطار فيديو
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # يحمّل الصورة المصغرة
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة تسميات الفيديو**

تتيح Aspose.Slides لك إدارة التسميات المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بتنسيق WebVTT وتُعرض عبر الخاصية [VideoFrame.caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/). 

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/).  
1. إضافة فيديو إلى العرض التقديمي.  
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) إلى شريحة.  
1. استخدام مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) التي تُرجعها الخاصية [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/) لإضافة مسار تسمية WebVTT.  
1. حفظ العرض التقديمي المعدل.  

يعرض الكود التالي كيفية إضافة تسميات إلى إطار فيديو:

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

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/) أيضًا تجاوزًا يسمح لك بإضافة تسميات من تدفق بيانات.  

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
1. العثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) الهدف.  
1. iterating عبر مجموعة [caption_tracks](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/caption_tracks/).  
1. حفظ كل مسار تسمية إلى ملف `.vtt`.  

يعرض الكود التالي كيفية استخراج التسميات من إطار فيديو:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # يحفظ مسار التسمية إلى ملف WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

كل كائن [Captions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captions/) يُظهر معرف التسمية، التسمية، البيانات الثنائية، ونص التسمية كسلسلة UTF-8.  

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.  
1. الحصول على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) الهدف.  
1. إزالة مسارات التسميات من مجموعة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/).  
1. حفظ العرض التقديمي المعدل.  

يعرض الكود التالي كيفية إزالة جميع التسميات من إطار فيديو:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # يزيل جميع التسميات من إطار الفيديو.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طريقتي [remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove/) أو [remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/remove_at/) بدلاً من [clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/captionscollection/clear/).  

## **استخراج الفيديو من الشريحة**

إلى جانب إضافة الفيديوهات إلى الشرائح، تتيح Aspose.Slides لك استخراج الفيديوهات المضمنة في العروض التقديمية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لتحميل العرض التقديمي المحتوي على الفيديو.  
2. iterating عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/).  
3. iterating عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) للعثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/).  
4. حفظ الفيديو إلى القرص.  

يعرض هذا الكود Python كيفية استخراج الفيديو من شريحة عرض تقديمي:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار VideoFrame؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/play_loop_mode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/).  

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، تُدرج البيانات الثنائية في المستند، لذلك يزداد حجم العرض التقديمي بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون الزيادة في الحجم أصغر.  

**هل يمكن استبدال الفيديو في إطار VideoFrame موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.  

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمن؟**

نعم. للفيديو المضمن [نوع محتوى](https://reference.aspose.com/slides/ar/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.