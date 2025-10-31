---
title: إضافة مقاطع فيديو إلى العروض التقديمية بلغة بايثون
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
- إطار الفيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. دليل سريع عملي."
---

يمكن لمقطع فيديو موضوع بشكل جيد في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستوى التفاعل مع جمهورك.

يتيح لك PowerPoint إضافة مقاطع فيديو إلى شريحة في عرض تقديمي بطريقتين:
* إضافة أو تضمين فيديو محلي (محفوظ على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتمكينك من إضافة مقاطع فيديو (كائنات فيديو) إلى عرض تقديمي، توفر Aspose.Slides الواجهة [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) والواجهة [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي ترغب في إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) وتمرير مسار ملف الفيديو لتضمينه في العرض التقديمي.
4. إضافة كائن [IVideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ivideoframe/) لإنشاء إطار للفيديو.
5. حفظ العرض التقديمي المعدل.

يوضح لك هذا الكود بلغة بايثون كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # يحصل على الشريحة الأولى ويضيف إطار فيديو
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # يحفظ العرض التقديمي على القرص
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى الطريقة `add_video_frame(x, y, width, height, fname)`:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا عبر الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابطه على الويب.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة كائن [IVideo](https://reference.aspose.com/slides/python-net/aspose.slides/ivideo/) وتمرير رابط الفيديو.
4. تعيين صورة مصغرة لإطار الفيديو.
5. حفظ العرض التقديمي.

يوضح لك هذا الكود بلغة بايثون كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التكرار عبر جميع كائنات [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) .
3. التكرار عبر جميع كائنات [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) .
4. حفظ الفيديو على القرص.

يوضح لك هذا الكود بلغة بايثون كيفية استخراج الفيديو من شريحة عرض تقديمي:

```python
import aspose.slides as slides

# ينشئ كائن Presentation الذي يمثل ملف عرض تقديمي 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). هذه الخيارات متاحة عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عند تضمين فيديو محلي، يتم تضمين البيانات الثنائية في المستند، لذا ينمو حجم العرض التقديمي بنسبة حجم الملف. عند إضافة فيديو عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون زيادة الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع محتوى](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه على القرص.