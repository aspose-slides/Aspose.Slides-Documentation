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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. دليل سريع خطوة بخطوة."
---

يمكن أن يجعل الفيديو الموضوع بشكل جيد في عرض تقديمي رسالتك أكثر إقناعا ويزيد من مستوى التفاعل مع جمهورك. 

PowerPoint يسمح لك بإضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

للسماح لك بإضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides فئة [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) وفئة [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) وغيرها من الأنواع ذات الصلة. 

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزناً محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) وتمرير مسار ملف الفيديو لتضمينه مع العرض التقديمي. 
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) لإنشاء إطار للفيديو.  
1. حفظ العرض التقديمي المعدل. 

يعرض لك هذا الكود بلغة Python كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:
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


بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار الملف مباشرة إلى الطريقة `add_video_frame(x, y, width, height, fname)`:
``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

تدعم إصدارات Microsoft [PowerPoint 2013 وما بعده](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلاً على YouTube)، يمكنك إضافته إلى عرضك التقديمي من خلال رابطه على الويب. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة كائن [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) وتمرير الرابط إلى الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو. 
1. حفظ العرض التقديمي. 

يعرض لك هذا الكود بلغة Python كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:
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


## **استخراج فيديو من الشريحة**

بالإضافة إلى إضافة مقاطع فيديو إلى الشرائح، تتيح لك Aspose.Slides استخراج مقاطع الفيديو المدمجة في العروض التقديمية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو. 
2. التنقل عبر جميع كائنات [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).
3. التنقل عبر جميع كائنات [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/). 
4. حفظ الفيديو إلى القرص.

يعرض لك هذا الكود بلغة Python كيفية استخراج الفيديو من شريحة عرض تقديمي:
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


## **الأسئلة المتكررة**

**ما هي معايير تشغيل الفيديو التي يمكن تغييرها لإطار VideoFrame؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، لذا ينمو حجم العرض التقديمي proporcionalًا لحجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون زيادة الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار VideoFrame الموجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على هندسة الشكل؛ وهذا سيناريو شائع لتحديث الوسائط في تنسيق موجود.

**هل يمكن تحديد نوع المحتوى (MIME) لفيديو مدمج؟**

نعم. للفيديو المدمج [نوع محتوى](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.