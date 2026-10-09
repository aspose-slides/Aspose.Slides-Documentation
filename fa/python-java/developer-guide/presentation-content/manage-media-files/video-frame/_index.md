---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از پایتون
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/python-java/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید که به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java اضافه و استخراج کنید. راهنمای سريع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای Python از طریق Java به شما امکان افزودن فریم‌های ویدیو به اسلایدها، تنظیم تنظیمات پخش، مدیریت زیرنویس‌ها و استخراج داده‌های ویدیو تعبیه‌شده را می‌دهد.

PowerPoint از ویدیوهای محلی و لینک‌های ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) ، کلاس [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم ویدیو توکار**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائه موجود تعبیه می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب نقطه (points) هستند. Python بایت‌های ویدیو را از دیسک می‌خواند و JPype آن‌ها را به آرایه بایت جاوا تبدیل می‌کند قبل از اینکه ویدیو به ارائه اضافه شود.

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

همچنین می‌توانید مسیر ویدیو محلی را مستقیماً به [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) پاس دهید. این مثال ویدیو را در اسلاید اول یک ارائه جدید تعبیه می‌کند. ویدیو باید تا زمان ذخیره ارائه قابل دسترسی بماند.

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

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) در ارائه‌ها از ویدیوهای آنلاین پشتیبانی می‌کند. می‌توانید فریم ویدیویی ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، لینک داشته باشد.

این مثال لینک ویدیو YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. شناسه ویدیو را تغییر دهید تا ویدیو دیگری استفاده شود. متد [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) پخش خودکار را درخواست می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی اینترنت دارد. نمایشگر ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید نمایش نرم‌افزار را به صورت تمام‌صفحه پخش کنید تا مخاطبان جزئیات را ببینند. با فراخوانی [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) با مقدار `True` این رفتار را در حین پخش فعال کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌سازد. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیوی موجود باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) تصمیم می‌گیرد که آیا ویدیو به‌صورت خودکار یا با کلیک شروع شود و [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) تعیین می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. این مثال تنظیمات شروع و حلقهٔ موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو نمایش به ابتدای خود باعث می‌شود که برای ارائه‌دهنده آماده‌ی پخش دوباره باشد. با فراخوانی [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) با مقدار `True` ویدیو را پس از پایان پخش به ابتدای خود برمی‌گردانید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه را غیرفعال می‌کند تا پخش بتواند به پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود باشد.

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

بازگرداندن ویدیو را به ابتدای خود برمی‌گرداند بدون اینکه دوباره شروع شود. در مقابل، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) با مقدار `True` پخش را به‌صورت خودکار تکرار می‌کند. هنگامیکه می‌خواهید ویدیو به پایان برسد و آمادهٔ پخش دوباره باشد، حلقه را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) به‌صورت مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک شروع شود؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را تعیین کند. حالت پخش را پس از تنظیم حلقه تنظیم کنید، همان‌گونه که در مثال نشان داده شده است. بازگرداندن به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) کار می‌کند.

## **قلم‌برداری فریم ویدیو**

از [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) برای حذف بخشی از ابتدا یا انتهای ویدیو در حین پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. قلم‌برداری تنظیمات پخش را بدون تغییر داده‌های ویدیو تعبیه‌شده تغییر می‌دهد.

**تنظیمات قلم‌برداری**

این مثال یک ویدیو محلی را تعبیه می‌کند و در حین پخش اولین ۲٫۵ ثانیه و آخرین یک ثانیه را حذف می‌کند. از ویدیویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

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

**خواندن تنظیمات قلم‌برداری**

این مثال مقادیر قلم‌برداری فریم اولین ویدیو در اسلاید اول را بر حسب میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان مدیریت زیرنویس‌های بسته (Closed Captions) برای فریم‌های ویدیو در ارائه‌های PowerPoint را می‌دهد. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را تعبیه می‌کند و یک مسیر زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌سنجی زیرنویس باید با ویدیو منطبق باشد. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

    # افزودن مسیر زیرنویس جدید از یک فایل WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) همچنین یک overload فراهم می‌کند که به شما امکان افزودن زیرنویس‌ها از یک جریان (stream) را می‌دهد.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس از فریم‌های ویدیو در اسلاید اول را به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. اعداد ترتیبی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌عنوان یک رشته UTF-8 ارائه می‌دهد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیویی در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌نماید. فرض می‌شود که اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدیو باشد.

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
        # حذف تمام زیرنویس‌ها از فریم ویدیو.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

اگر نیاز به حذف تنها یک مسیر زیرنویس دارید، به‌جای [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما امکان استخراج ویدیوهای تعبیه‌شده در ارائه‌ها را می‌دهد.

این مثال ویدیوهای تعبیه‌شده را از هر اسلاید استخراج می‌کند و به فایل‌های باینری جداگانه و شماره‌دار ذخیره می‌نماید. ویدیوهای لینک‌شده نادیده گرفته می‌شوند زیرا داده تعبیه‌شده‌ای ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به پسوند متناسب با نوع رسانه گزارش‌شده تغییر دهید.

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

## **سوالات متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدیو تغییر کنند؟**

شما می‌توانید [حالت پخش](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (خودکار یا با کلیک) و [حلقه‌یابی](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدیو بر اندازهٔ فایل PPTX تأثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را تعبیه می‌کنید، داده‌های باینری در سند گنجانده می‌شوند، بنابراین اندازهٔ ارائه به نسبت اندازهٔ فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین لینک می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه دادهٔ ویدیو، بنابراین افزایش اندازه معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدئویی موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) را داخل فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو تعبیه‌شده را تعیین کرد؟**

بله. یک ویدیو تعبیه‌شده دارای [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) است که می‌توانید آن را بخوانید و استفاده کنید، به عنوان مثال هنگام ذخیره‌سازی آن بر روی دیسک.