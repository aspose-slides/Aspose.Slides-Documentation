---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام بايثون
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/python-java/video-frame/
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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجيًا في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر جافا. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن لفيديو موضعه بشكل جيد في عرض تقديمي أن يجعل رسالتك أكثر إقناعًا ويزيد من مستويات التفاعل مع جمهورك.

يسمح لك PowerPoint بإضافة مقاطع الفيديو إلى شريحة في عرض تقديمي بطريقتين:

* إضافة أو تضمين فيديو محلي (مخزن على جهازك)
* إضافة فيديو عبر الإنترنت (من مصدر ويب مثل YouTube).

لتتيح لك إضافة مقاطع الفيديو (كائنات الفيديو) إلى عرض تقديمي، توفر Aspose.Slides فئة [Video](https://reference.aspose.com/slides/ar/python-java/aspose.slides/video/) و[VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) وفئات أخرى ذات صلة.

## **إنشاء إطارات فيديو مدمجة**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في عرضك التقديمي.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرستها.
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/python-java/aspose.slides/video/) وتمرير بيانات ملف الفيديو لتضمين الفيديو في العرض.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) لإنشاء إطار للفيديو.
1. حفظ العرض التقديمي المعدل.

يظهر لك هذا الكود بلغة Python كيفية إضافة فيديو مخزن محليًا إلى عرض تقديمي:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

بدلاً من ذلك، يمكنك إضافة فيديو بتمرير مسار ملفه مباشرة إلى طريقة [addVideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **إنشاء إطارات فيديو باستخدام فيديو من مصادر ويب**

يدعم Microsoft [PowerPoint 2013 والإصدارات الأحدث](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) مقاطع فيديو YouTube في العروض التقديمية. إذا كان الفيديو الذي تريد استخدامه متاحًا على الإنترنت (مثلًا على YouTube)، يمكنك إضافته إلى عرضك التقديمي عبر رابط الويب الخاص به.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة باستخدام فهرستها.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) وتمرير رابط الفيديو.
1. تعيين صورة مصغرة لإطار الفيديو.
1. حفظ العرض التقديمي.

يظهر لك هذا الكود بلغة Python كيفية إضافة فيديو من الويب إلى شريحة في عرض PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # تحميل الصورة المصغرة.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تقليم إطار فيديو**

تتيح لك Aspose.Slides التحكم في الجزء الذي يتم تشغيله من الفيديو من خلال تعيين قيمتي trim-from-start و trim-from-end عبر [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setTrimFromEnd). تُحدد القيمتان بالميليثانية وتحدد مقدار الوقت المتخطى من بداية الفيديو ونهايته، على التوالي. تقوم هذه الإعدادات بتغيير إعدادات تشغيل الفيديو في العرض التقديمي؛ فهي لا تقص أو تعدل بيانات الفيديو الثنائية المضمنة.

**ضبط إعدادات التقليم**

لإنشاء إطار فيديو وضبط إعدادات التقليم الخاصة به:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. إضافة كائن [Video](https://reference.aspose.com/slides/ar/python-java/aspose.slides/video/) إلى العرض.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) إلى شريحة.
1. تعيين قيمتي trim-from-start وtrim-from-end عبر [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. حفظ العرض التقديمي المعدل.

يتخطى مثال الكود التالي الثانية الأولى 2.5 والثانية الأخيرة من الفيديو المدمج أثناء التشغيل:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**قراءة إعدادات التقليم**

لتفحص إعدادات التقليم الحالية، قم بتحميل عرض تقديمي، وابحث عن كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) بين الأشكال على الشريحة الأولى، ثم اقرأ القيم عبر [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#getTrimFromStart) و[VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

يجد مثال الكود التالي أول إطار فيديو على الشريحة الأولى ويبلغ عن إعدادات التقليم الخاصة به بالميليثانية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **إدارة تسميات الفيديو**

تتيح لك Aspose.Slides إدارة النصوص المغلقة لإطارات الفيديو في عروض PowerPoint التقديمية. يتم تخزين العناوين بتنسيق WebVTT وتُعرض عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**إضافة تسميات إلى إطار فيديو**

لإضافة تسميات إلى إطار فيديو:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) .
1. إضافة فيديو إلى العرض.
1. إضافة كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) إلى شريحة.
1. استخدام [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/) التي تُرجعها [getCaptionTracks](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#getCaptionTracks) لإضافة مسار تسمية WebVTT.
1. حفظ العرض التقديمي المعدل.

يظهر لك الكود التالي كيفية إضافة تسميات إلى إطار فيديو:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # إضافة مسار توضيحات جديد من ملف WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

توفر فئة [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/) أيضًا طريقة تتيح لك إضافة تسميات من تدفق.

**استخراج التسميات من إطار فيديو**

لاستخراج التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. العثور على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) المستهدف.
1. التكرار عبر مسارات التسميات في [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/) .
1. حفظ كل مسار تسمية إلى ملف `.vtt` .

يظهر لك الكود التالي كيفية استخراج التسميات من إطار فيديو:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # حفظ مسار التسمية إلى ملف WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

كل كائن [Captions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captions/) يكشف عن معرف التسمية، التسمية، البيانات الثنائية، ونص التسمية كسلسلة UTF-8.

**إزالة التسميات من إطار فيديو**

لإزالة التسميات من إطار فيديو:

1. تحميل العرض التقديمي الذي يحتوي على الفيديو.
1. الحصول على كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) المستهدف.
1. إزالة مسارات التسميات من [CaptionsCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/) .
1. حفظ العرض التقديمي المعدل.

يظهر لك الكود التالي كيفية إزالة جميع التسميات من إطار فيديو:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # إزالة جميع التسميات من إطار الفيديو.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

إذا كنت بحاجة إلى إزالة مسار تسمية واحد فقط، استخدم طرق [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#removeAt) بدلاً من [clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/captionscollection/#clear) .

## **استخراج الفيديو من الشرائح**

بالإضافة إلى إضافة مقاطع الفيديو إلى الشرائح، تسمح لك Aspose.Slides باستخراج مقاطع الفيديو المضمنة في العروض التقديمية.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) لتحميل العرض التقديمي الذي يحتوي على الفيديو.
2. التكرار عبر جميع كائنات [Slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/) .
3. التكرار عبر جميع كائنات [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/) للعثور على [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) .
4. حفظ الفيديو إلى القرص.

يظهر لك هذا الكود بلغة Python كيفية استخراج الفيديو على شريحة من العرض التقديمي:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تعديلها لإطار VideoFrame؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setPlayMode) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setPlayLoopMode) . تتوفر هذه الخيارات عبر خصائص كائن [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) .

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تقوم بتضمين فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي ينمو حجم العرض التقديمي بنسبة حجم الملف. عندما تضيف فيديوًا عبر الإنترنت، يتم تضمين رابط وصورة مصغرة، لذا يكون زيادة الحجم أصغر.

**هل يمكنني استبدال الفيديو في إطار VideoFrame موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/#setEmbeddedVideo) داخل الإطار مع حفظ هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع المحتوى](https://reference.aspose.com/slides/ar/python-java/aspose.slides/video/#getContentType) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.