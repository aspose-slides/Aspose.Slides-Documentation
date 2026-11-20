---
title: إدارة إطارات الفيديو في العروض التقديمية باستخدام بايثون
linktitle: إطار الفيديو
type: docs
weight: 10
url: /ar/python-java/video-frame/
keywords:
- إضافة فيديو
- إنشاء فيديو
- دمج فيديو
- استخراج فيديو
- استرجاع فيديو
- إطار فيديو
- مصدر ويب
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إضافة واستخراج إطارات الفيديو برمجياً في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر Java. دليل سريع خطوة بخطوة."
---
## **المقدمة**

يمكن للفيديوهات أن تساعد في شرح الأفكار وإشراك الجمهور. يتيح Aspose.Slides for Python عبر Java إضافة إطارات فيديو إلى الشرائح، وضبط إعدادات التشغيل، وإدارة التسميات التوضيحية، واستخراج بيانات الفيديو المدمجة.

يدعم PowerPoint الفيديوهات المحلية والروابط إلى الفيديوهات على الإنترنت، مثل فيديوهات YouTube.

لتمثيل بيانات الفيديو وإطارات الفيديو، يوفر Aspose.Slides الفئة [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) والفئة [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) وأنواع أخرى ذات صلة.

## **إنشاء إطار فيديو مدمج**

إذا كان ملف الفيديو الذي تريد إضافته إلى الشريحة مخزنًا محليًا، يمكنك إنشاء إطار فيديو لدمج الفيديو في العرض التقديمي.

يُدمج هذا المثال فيديو محليًا في الشريحة الأولى من عرض تقديمي موجود ويُحفظ النتيجة. إحداثيات الإطار وأبعاده تُقاس بالنقاط. يقرأ Python بايتات الفيديو من القرص، وتقوم JPype بتحويلها إلى مصفوفة بايتات Java قبل إضافة الفيديو إلى العرض التقديمي.

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

يمكنك أيضًا تمرير مسار الفيديو المحلي مباشرة إلى الدالة [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). يدمج هذا المثال الفيديو في الشريحة الأولى من عرض تقديمي جديد. يجب أن يبقى الفيديو قابلًا للوصول حتى يتم حفظ العرض التقديمي.

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

## **إنشاء إطار فيديو باستخدام فيديو من مصدر ويب**

يدعم Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) الفيديوهات عبر الإنترنت في العروض التقديمية. يمكنك إنشاء إطار فيديو يربط بفيديو على الإنترنت، مثل فيديو YouTube.

يضيف هذا المثال رابط فيديو YouTube وصورة مصغرة إلى الشريحة الأولى. استبدل معرف الفيديو لاستخدام فيديو آخر. تطلب طريقة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) التشغيل التلقائي. تحميل الصورة المصغرة وتشغيل الفيديو يتطلب الوصول إلى الإنترنت. يجب أن يدعم عارض العرض التقديمي تشغيل الفيديو عبر الإنترنت.

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

## **تشغيل فيديو في وضع ملء الشاشة**

في عرض تدريب، يمكنك تشغيل عرض توضيحي للبرنامج في وضع ملء الشاشة حتى يتمكن الجمهور من رؤية التفاصيل. استدعِ الدالة [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) مع القيمة `True` لتمكين هذا السلوك أثناء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) في الشريحة الأولى، ويُفعّل التشغيل بملء الشاشة. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يتحكم تشغيل ملء الشاشة في طريقة عرض الفيديو. بشكل مستقل، تتحكم الدالة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) في ما إذا كان يبدأ تلقائيًا أو عند النقر، وتتحكم الدالة [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) في ما إذا كان يتكرر. لاختيار سلوك البدء، اضبط وضع التشغيل إلى [VideoPlayModePreset.Auto أو VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). يحافظ المثال على إعدادات البدء والتكرار الحالية.

## **إرجاع الفيديو إلى البداية بعد التشغيل**

في عرض تدريب، إعادة فيديو العرض التوضيحي إلى بدايته تجعل الفيديو جاهزًا للمقدم لتشغيله مرة أخرى. استدعِ الدالة [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) مع القيمة `True` لإرجاع الفيديو إلى البداية بعد انتهاء التشغيل.

يفتح هذا المثال عرضًا تقديميًا، يجد أول [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) في الشريحة الأولى، ويُفعّل الإرجاع. يقوم بتعطيل التكرار بحيث يمكن الانتهاء من التشغيل ويضبط التشغيل للبدء عند النقر. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل تحتوي على إطار فيديو موجود في الشريحة الأولى.

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

يعيد الإرجاع الفيديو إلى بدايته دون تشغيله مرة أخرى. بالمقابل، استدعاء الدالة [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) مع القيمة `True` يكرر التشغيل تلقائيًا. أبقِ التكرار معطلاً عندما تريد أن ينتهي الفيديو ويظل جاهزًا لإعادة التشغيل. تتحكم الدالة [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) بشكل مستقل في التشغيل التلقائي أو عند النقر؛ يستخدم هذا المثال [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) بحيث يتحكم المقدم في موعد بدء التشغيل. اضبط وضع التشغيل بعد إعداد التكرار، كما هو موضح في المثال. يعمل الإرجاع بشكل مستقل عن الدالة [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **قص إطار فيديو**

استخدم الدالتين [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) و[VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) لتخطي جزء من بداية أو نهاية الفيديو أثناء التشغيل. القيم بالمللي ثانية. يغيّر القص إعدادات التشغيل دون تعديل بيانات الفيديو المدمجة.

**ضبط إعدادات القص**

يُدمج هذا المثال فيديوًا محليًا ويتخطى أول 2.5 ثانية وآخر ثانية أثناء التشغيل. استخدم فيديو أطول من 3.5 ثوانٍ لتبقى قطعة قابلة للتشغيل.

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

يطبع هذا المثال قيم القص لإطار الفيديو الأول في الشريحة الأولى بالمللي ثانية. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل. إذا لم تحتوي تلك الشريحة على إطار فيديو، لا يُطبع شيء. ينتج المثال القيم 2500 و1000.

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

يتيح Aspose.Slides لك إدارة التسميات التوضيحية المغلقة لإطارات الفيديو في عروض PowerPoint. تُخزن التسميات بصيغة WebVTT وتُتاح عبر الدالة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

### **إضافة تسميات إلى إطار فيديو**

يُدمج هذا المثال فيديوًا محليًا ويضيف مسار تسمية WebVTT بعنوان English. يجب أن تتطابق طوابع الزمن في التسمية مع الفيديو. يتضمن العرض التقديمي المحفوظ كلًا من الفيديو وتسليماته.

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
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # إضافة مسار تسمية جديدة من ملف WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

توفر الفئة [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) أيضًا نسخة زائدة تتيح لك إضافة تسميات من تدفق بيانات.

### **استخراج تسميات من إطار فيديو**

يحفظ هذا المثال جميع مسارات التسميات من إطارات الفيديو في الشريحة الأولى كملفات WebVTT منفصلة. تُحافظ الأرقام المتسلسلة على تمييز ملفات الإخراج. يُبلغ سطر الأوامر عن عدد المسارات المستخرجة. يجب أن يحتوي العرض التقديمي على شريحة واحدة على الأقل.

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

كل كائن [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) يُظهر معرف التسمية، والعنوان، والبيانات الثنائية، والنص كقيمة UTF-8.

### **إزالة التسميات من إطار فيديو**

يُزيل هذا المثال جميع التسميات من إطار الفيديو في الموضع الأول للشكل في الشريحة الأولى ويحفظ النتيجة. يفترض وجود الشريحة والشكل وأن الشكل هو إطار فيديو.

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

إذا كنت تحتاج إلى إزالة مسار تسمية واحد فقط، استخدم الدالتين [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) أو [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) بدلاً من الدالة [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

### **البحث في تسميات الفيديو**

تُعيد الدالة [Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) مسار WebVTT الكامل، بما في ذلك الرأس، وخطوط التوقيت، ونص التسمية. يمكنك البحث في التسميات في الذاكرة لإيجاد عبارة وطابعها الزمني. على سبيل المثال، قد يحتوي مسار إنجليزي على الشريحة 2 على النص التالي.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

يفتح هذا المثال الملف `captioned_media.pptx` ويستخدم الدالة [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) لقراءة مسارات كل إطار فيديو أعلى المستوى في كل شريحة. في Cue نصية عادية، يحتوي خط التوقيت على `-->`، ويُنهي سطر فارغ الـ Cue. لكل تسمية تحتوي على كلمة “café” بأي حالة حرفية، يطبع المثال رقم الشريحة، عنوان المسار، خط التوقيت الأصلي، والتسمية الكاملة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
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
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

ينتج البحث عن “café” تطابقًا واحدًا للمسار النموذجي. يستثني البحث رأس المسار ويحافظ على إعداد التوقيت وفواصل الأسطر في المخرجات.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج فيديو من شريحة**

بالإضافة إلى إضافة الفيديوهات إلى الشرائح، يتيح Aspose.Slides لك استخراج الفيديوهات المدمجة في العروض التقديمية.

يستخرج هذا المثال الفيديوهات المدمجة من كل شريحة إلى ملفات ثنائية مرقمة منفصلة. تُتخطى الفيديوهات المرتبطة لأنها لا تحتوي على بيانات مدمجة. يطبع سطر الأوامر نوع MIME لكل فيديو والعدد الكلي. يستخدم الإخراج الامتداد العام `.bin`؛ غيره ليتطابق مع نوع الوسائط المبلغ عنه عند الحاجة.

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

## **الأسئلة المتكررة**

**ما هي معلمات تشغيل الفيديو التي يمكن تغييرها لإطار الفيديو؟**

يمكنك التحكم في [وضع التشغيل](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (تلقائي أو عند النقر) و[التكرار](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). هذه الخيارات متاحة عبر طرق كائن [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**هل يؤثر إضافة فيديو على حجم ملف PPTX؟**

نعم. عندما تدمج فيديوًا محليًا، تُضمّن البيانات الثنائية في المستند، لذا يزداد حجم العرض التقديمي بما يتناسب مع حجم الملف. عندما ترتبط بفيديو على الإنترنت وتضيف صورة مصغرة، يخزن العرض التقديمي الرابط وصورة المعاينة بدلاً من بيانات الفيديو، لذا يكون الزيادة في الحجم عادة أصغر.

**هل يمكن استبدال الفيديو في إطار فيديو موجود دون تغيير موقعه وحجمه؟**

نعم. يمكنك استبدال [محتوى الفيديو](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) داخل الإطار مع الحفاظ على أبعاد الشكل؛ هذا سيناريو شائع لتحديث الوسائط في تخطيط موجود.

**هل يمكن تحديد نوع المحتوى (MIME) للفيديو المدمج؟**

نعم. يحتوي الفيديو المدمج على [نوع محتوى](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) يمكنك قراءته واستخدامه، على سبيل المثال عند حفظه إلى القرص.