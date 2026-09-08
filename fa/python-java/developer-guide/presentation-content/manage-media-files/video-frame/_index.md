---
title: "مدیریت فریم‌های ویدئویی در ارائه‌ها با استفاده از پایتون"
linktitle: "فریم ویدئو"
type: docs
weight: 10
url: /fa/python-java/video-frame/
keywords:
- "افزودن ویدئو"
- "ایجاد ویدئو"
- "جاسازی ویدئو"
- "استخراج ویدئو"
- "بازیابی ویدئو"
- "فریم ویدئو"
- "منبع وب"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Aspose.Slides"
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java اضافه و استخراج کنید. راهنمای سریع قدم‌به‑قدم."
---
## **مقدمه**

یک ویدیو به‌درستی در یک ارائه می‌تواند پیام شما را قوی‌تر کرده و سطح تعامل با مخاطبان را افزایش دهد.

PowerPoint به شما اجازه می‌دهد ویدیوها را به یک اسلاید در یک ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدیو محلی (نگهداری شده روی دستگاه شما)
* افزودن یک ویدیو آنلاین (از منبع وبی مانند YouTube).

برای افزودن ویدیوها (اشیاء ویدیو) به یک ارائه، Aspose.Slides کلاس‌های [Video](https://reference.aspose.com/slides/fa/python-java/aspose.slides/video/)، [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم‌های ویدئوی جاسازی‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدئو ایجاد کنید تا ویدئو را در ارائه خود جاسازی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-java/aspose.slides/video/) اضافه کنید و داده‌های فایل ویدئو را برای جاسازی ویدئو در ارائه پاس کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) اضافه کنید تا فریمی برای ویدئو ایجاد شود.
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک ویدئوی ذخیره‌شده به‌صورت محلی را به یک ارائه اضافه کنید:

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

به‌علاوه، می‌توانید با پاس کردن مسیر فایل ویدئو مستقیماً به متد [addVideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#addVideoFrame) یک ویدئو اضافه کنید:

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

## **ایجاد فریم‌های ویدئوی با ویدئو از منابع وب**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدئوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدئویی که می‌خواهید استفاده کنید به‌صورت آنلاین موجود باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) اضافه کنید و لینک به ویدئو را پاس کنید.
1. یک تصویر بندانگشتی برای فریم ویدئو تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک ویدئو از وب را به یک اسلاید در یک ارائه PowerPoint اضافه کنید:

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

    # بارگذاری تصویر بندانگشتی.
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

## **برش یک فریم ویدئویی**

Aspose.Slides به شما امکان می‌دهد با تنظیم مقادیر trim-from-start و trim-from-end از طریق [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setTrimFromEnd) تعیین کنید که کدام بخش از ویدئو پخش شود. هر دو مقدار بر حسب میلی‌ثانیه مشخص می‌شوند و زمان حذف‌شده از ابتدای و انتهای ویدئو را تعریف می‌کنند. این تنظیمات پخش ویدئو را در ارائه تغییر می‌دهد؛ آنها ویدئوی جاسازی‌شده را قطع یا به‌صورت دیگری تغییر نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک فریم ویدئویی و تنظیم برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-java/aspose.slides/video/) به ارائه اضافه کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.
1. مقادیر trim-from-start و trim-from-end را از طریق [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setTrimFromEnd) تنظیم کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

مثال کد زیر اولین ۲٫۵ ثانیه و آخرین یک ثانیه یک ویدئوی جاسازی‌شده را در هنگام پخش حذف می‌کند:

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

**خواندن تنظیمات برش**

برای بازرسی تنظیمات برش موجود، یک ارائه را بارگذاری کنید، شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) را در میان اشکال اسلاید اول پیدا کنید، و مقادیر را از طریق [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#getTrimFromStart) و [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#getTrimFromEnd) بخوانید.

مثال کد زیر اولین فریم ویدئویی را در اسلاید اول پیدا می‌کند و تنظیمات برش آن را برحسب میلی‌ثانیه گزارش می‌دهد:

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

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#getCaptionTracks) قابل دسترسی هستند.

**افزودن زیرنویس به یک فریم ویدئویی**

برای افزودن زیرنویس به یک فریم ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
1. یک ویدئو به ارائه اضافه کنید.
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.
1. از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) که توسط [getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#getCaptionTracks) بازگردانده می‌شود، برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را به یک فریم ویدئویی اضافه کنید:

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

    # افزودن مسیر زیرنویس جدید از یک فایل WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) همچنین یک بارگذاری اضافه دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از یک فریم ویدئویی**

برای استخراج زیرنویس‌ها از یک فریم ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) هدف را پیدا کنید.
1. از مسیرهای زیرنویس در [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) پیمایش کنید.
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک فریم ویدئویی استخراج کنید:

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
                # ذخیره مسیر زیرنویس به یک فایل WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

هر شیء [Captions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF-8 ارائه می‌دهد.

**حذف زیرنویس‌ها از یک فریم ویدئویی**

برای حذف زیرنویس‌ها از یک فریم ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) هدف را دریافت کنید.
1. مسیرهای زیرنویس را از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) حذف کنید.
1. ارائه اصلاح‌شده را ذخیره کنید.

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک فریم ویدئویی حذف کنید:

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
        # حذف تمام زیرنویس‌ها از فریم ویدئویی.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

اگر نیاز به حذف تنها یک مسیر زیرنویس دارید، به‌جای [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدئو از اسلایدها**

علاوه بر افزودن ویدئوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدئوهای جاسازی‌شده در ارائه‌ها را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید تا ارائه حاوی ویدئو را بارگذاری کنید.
2. از تمام اشیاء [Slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) پیمایش کنید.
3. از تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) پیدا کنید.
4. ویدئو را بر روی دیسک ذخیره کنید.

این کد Python نشان می‌دهد چگونه ویدئوی موجود در یک اسلاید ارائه را استخراج کنید:

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

## **سؤال‌های متداول**

**کدام پارامترهای پخش ویدئو برای VideoFrame قابل تغییر هستند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setPlayMode) (خودکار یا عند کلیک) و [حلقه‌پذیری](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setPlayLoopMode) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر اندازه فایل PPTX تأثیر می‌گذارد؟**

بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه متناسب با حجم فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین را اضافه می‌کنید، یک لینک و یک تصویر بندانگشتی جاسازی می‌شوند، لذا افزایش حجم کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/#setEmbeddedVideo) را درون فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/video/#getContentType) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.