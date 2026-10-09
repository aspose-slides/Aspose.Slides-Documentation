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
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة بايثون عبر Java. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وجذب الجمهور. تتيح لك Aspose.Slides for Python via Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المضمنة.

يدعم PowerPoint مقاطع الفيديو المحلية والروابط إلى مقاطع الفيديو على الإنترنت، مثل مقاطع فيديو YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، توفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مضمّن**

إذا كان ملف الفيديو الذي تريد إضافته إلى شريحتك مخزنًا محليًا، يمكنك إنشاء إطار فيديو لتضمين الفيديو في العرض التقديمي.

هذا المثال يضمّن فيديو محلي على الشريحة الأولى من عرض تقديمي موجود ويحفظ النتيجة. إحداثيات الإطار وأبعاده بالنقاط. يقرأ Python بايتات الفيديو من القرص، ويحول JPype تلك البايتات إلى مصفوفة بايتات Java قبل إضافة الفيديو إلى العرض التقديمي.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). هذا المثال يضمّن الفيديو على الشريحة الأولى من عرض تقديمي جديد. يجب أن يظل الفيديو متاحًا حتى يتم حفظ العرض التقديمي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إنشاء إطار فيديو مع فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) مقاطع الفيديو عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط بفيديو عبر الإنترنت، مثل فيديو YouTube.

هذا المثال يضيف رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. طريقة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) تطلب التشغيل التلقائي. تنزيل الصورة المصغرة وتشغيل الفيديو يتطلب اتصالًا بالإنترنت. يجب أن يدعم عارض العرض التقديمي تشغيل الفيديو عبر الإنترنت أيضًا.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تشغيل فيديو بوضع ملء الشاشة**

في عرض تقديمي تدريبي، يمكنك تشغيل توضيح البرمجيات في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) مع `True` لتمكين هذا السلوك أثناء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) على الشريحة الأولى، ويفعل تشغيل ملء الشاشة. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود على الشريحة الأولى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يشرف تشغيل ملء الشاشة على طريقة عرض الفيديو. بشكل مستقل، تتحكم طريقة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) فيما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم طريقة [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) فيما إذا كان يعيد التشغيل. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والاحتفال الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تقديمي تدريبي، إعادة فيديو التوضيح إلى بدايته يجعله جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) مع `True` لإرجاع الفيديو إلى بدايته بعد انتهاء التشغيل.

هذا المثال يفتح عرضًا تقديميًا، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) على الشريحة الأولى، ويفعل الإرجاع. يعطل التكرار حتى يكتمل التشغيل ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي عرض الإدخال على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود على الشريحة الأولى.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الإرجاع يعيد الفيديو إلى بدايته دون تشغيله مرة أخرى. وعلى العكس، استدعاء [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) مع `True` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلًا عندما تريد أن ينتهي الفيديو ويبقى جاهزًا لإعادة التشغيل. تتحكم طريقة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) بشكل مستقل في بدء التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في وقت بدء التشغيل. اضبط وضع التشغيل بعد ضبط إعداد التكرار كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **قص إطار فيديو**

استخدم [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) لتخطي جزء من البداية أو النهاية أثناء تشغيل الفيديو. القيمتان بالملي ثانية. يغير القص إعدادات التشغيل دون تعديل بيانات الفيديو المضمّنة.

**إعدادات القص**

هذا المثال يضمّن فيديو محلي ويتخطى أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديوًا أطول من 3.5 ثانية لتبقى شريحة قابلة للتشغيل.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**قراءة إعدادات القص**

هذا المثال يطبع قيم القص لأول إطار فيديو على الشريحة الأولى بالملي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لن يُطبع شيء. المثال السابق ينتج القيم 2500 و1000.

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

## **إدارة تعليقات الفيديو**

تسمح لك Aspose.Slides بإدارة التعليقات المغلقة لإطارات الفيديو في عروض PowerPoint. تُحفظ التعليقات بتنسيق WebVTT وتُعرَض عبر طريقة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**إضافة تعليقات توضيحية إلى إطار فيديو**

هذا المثال يضمّن فيديو محلي ويضيف مسار تعليق WebVTT معنون بـ English. يجب أن تتطابق طوابع الوقت للتعليق مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وتعليقاته.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpime.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # أضف مسار توضيحات جديد من ملف WebVTT.
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الفئة [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) توفر أيضًا حملًا زائدًا يتيح لك إضافة تعليقات من تدفق بيانات.

**استخراج التعليقات التوضيحية من إطار فيديو**

هذا المثال يحفظ جميع مسارات التعليق من إطارات الفيديو على الشريحة الأولى كملفات WebVTT منفصلة. الأرقام المتسلسلة تحافظ على تمييز الملفات الناتجة. يُظهر وحدة التحكم عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

كل كائن [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) يُظهر معرف التعليق، التسمية، البيانات الثنائية، ونص التعليق كسلسلة UTF-8.

**إزالة التعليقات التوضيحية من إطار فيديو**

هذا المثال يزيل جميع التعليقات من إطار الفيديو في أول موضع شكل على الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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
        # إزالة جميع التعليقات التوضيحية من إطار الفيديو.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

إذا كنت تحتاج إلى إزالة مسار تعليق واحد فقط، استخدم طرق [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) بدلًا من [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **استخراج فيديو من شريحة**

إلى جانب إضافة الفيديوهات إلى الشرائح، تتيح لك Aspose.Slides استخراج الفيديوهات المضمّنة في العروض التقديمية.

هذا المثال يستخرج الفيديوهات المضمّنة من كل شريحة إلى ملفات ثنائية رقمية منفصلة. تُهمل الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مضمّنة. تُظهر وحدة التحكم نوع MIME لكل فيديو وإجمالي العدد. يستخدم الإخراج الامتداد العام `.bin`؛ غيّره بما يتطابق مع نوع الوسائط المُبلغ عنه عند الحاجة.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (تلقائي أو عند النقر) و[looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). تتوفر هذه الخيارات عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تضمن فيديو محلي، تُضمّن البيانات الثنائية في المستند، وبالتالي يزداد حجم العرض التقديمي نسبةً لحجم الملف. عند ربط فيديو على الإنترنت وإضافة صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة عادةً أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) داخل الإطار مع الحفاظ على هندسة الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المضمّن؟**

نعم. يحتوي الفيديو المضمّن على [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.