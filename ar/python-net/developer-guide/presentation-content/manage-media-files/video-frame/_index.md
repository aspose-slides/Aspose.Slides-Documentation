---
title: إطار الفيديو
type: docs
weight: 10
url: /ar/python-net/video-frame/
keywords: "إضافة فيديو، إنشاء إطار فيديو، استخراج فيديو، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة إطار فيديو إلى عرض PowerPoint في بايثون"
---

يمكن أن يجعل الفيديو الموضوع بشكل جيد في العرض رسالتك أكثر جذبًا ويزيد من مستويات التفاعل مع جمهورك.

تسمح لك PowerPoint بإضافة مقاطع فيديو إلى الشريحة في العرض بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع الفيديو (كائنات الفيديو) إلى العرض، توفر Aspose.Slides واجهة [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) وواجهة [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) وأنواع ذات صلة أخرى.

## **إنشاء إطار فيديو مضمن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمين الفيديو مع العرض.
1. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض المعدل.

يوضح لك كود بايثون هذا كيفية إضافة فيديو مخزن محليًا إلى عرض:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # يحصل على الشريحة الأولى ويضيف إطار فيديو
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # يحفظ العرض على القرص
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

بدلاً من ذلك، يمكنك إضافة فيديو عن طريق تمرير مسار ملفه مباشرة إلى طريقة `add_video_frame(x, y, width, height, fname)`:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

تدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثل YouTube)، يمكنك إضافته إلى عرضك من خلال رابط الويب الخاص به.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة كائن [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو.
1. حفظ العرض.

يوضح لك كود بايثون هذا كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # يضيف إطار فيديو
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # تحميل الصورة المصغرة
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الفيديو من الشريحة**

بجانب إضافة مقاطع الفيديو إلى الشرائح، يسمح لك Aspose.Slides باستخراج مقاطع الفيديو المدمجة في العروض.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحميل العرض الذي يحتوي على الفيديو.
2. تكرار جميع كائنات [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. تكرار جميع كائنات [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).
4. حفظ الفيديو على القرص.

يوضح لك كود بايثون هذا كيفية استخراج الفيديو من شريحة عرض:

```python
import aspose.slides as slides

# ينشئ كائن Presentation يمثل ملف عرض
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```