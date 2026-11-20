---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با استفاده از پایتون
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/python-java/video-frame/
keywords:
- اضافه کردن ویدیو
- ایجاد ویدیو
- جاسازی ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- فریم ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق Java اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کنند و مخاطب را درگیر کنند. Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیوهای جاسازی‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و لینک‌های به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/)، کلاس [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) و انواع مرتبط دیگر را فراهم می‌کند.

## **ایجاد فریم ویدیوی جاسازی‌شده**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدیو محلی را در اسلاید اول یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌سازد. مختصات و ابعاد فریم بر حسب پوینت است. پایتون بایت‌های ویدیو را از دیسک می‌خواند و JPype آنها را به آرایه بایت جاوا تبدیل می‌کند قبل از اینکه ویدیو به ارائه اضافه شود.

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

همچنین می‌توانید مسیر ویدیو محلی را به‌صورت مستقیم به [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) پاس دهید. این مثال ویدیو را در اسلاید اول یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه قابل دسترسی باقی بماند.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید یک فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند ویدیوی YouTube، لینک داشته باشد.

این مثال لینک ویدیو YouTube و تصویر بندانگشتی آن را به اسلاید اول اضافه می‌کند. شناسه ویدیو را جایگزین کنید تا ویدیوی دیگری استفاده شود. متد [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) درخواست پخش خودکار را می‌کند. دانلود تصویر بندانگشتی و پخش ویدیو به دسترسی به اینترنت نیاز دارد. نمایش‌دهنده ارائه نیز باید از پخش ویدیوهای آنلاین پشتیبانی کند.

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

## **پخش یک ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزار را در حالت تمام‌صفحه پخش کنید تا مخاطبان جزئیات را ببینند. برای فعال‌سازی این رفتار در طول پخش، متد [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) را با `True` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و پخش تمام‌صفحه را فعال می‌نماید. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود داشته باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدیو را کنترل می‌کند. به‌صورت مستقل، [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود، و [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) کنترل می‌کند که آیا تکرار شود یا نه. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدیو نمایشی به ابتدای خود باعث می‌شود که برای ارائه‌دهنده آماده باشد تا دوباره پخش کند. برای بازگرداندن ویدیو به ابتدای خود پس از پایان پخش، متد [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) را با `True` صدا بزنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) را در اسلاید اول پیدا می‌کند و بازگرداندن را فعال می‌سازد. حلقه را غیرفعال می‌کند تا پخش بتواند به‌پایان برسد و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که در اسلاید اول یک فریم ویدیو موجود داشته باشد.

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

بازگرداندن ویدیو را به ابتدای خود برمی‌گرداند بدون اینکه دوباره شروع شود. برعکس، فراخوانی [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) با `True` پخش را به‌صورت خودکار تکرار می‌کند. زمانی که می‌خواهید ویدیو به‌پایان برسد و آماده پخش مجدد بماند، حلقه را غیرفعال نگه دارید. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) به‌صورت مستقل کنترل می‌کند که شروع به‌صورت خودکار یا با کلیک باشد؛ این مثال از [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. حالت پخش را پس از تنظیم حلقه تنظیم کنید، همان‌طور که در مثال نشان داده شده است. بازگرداندن به‌صورت مستقل از [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) عمل می‌کند.

## **قاطع کردن فریم ویدیو**

از [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) و [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) استفاده کنید تا بخشی از ابتدای یا انتهای ویدیو را در حین پخش صرف نظر کنید. هر دو مقدار به میلی‌ثانیه است. قاطع کردن تنظیمات پخش را بدون تغییر داده‌های ویدیو جاسازی‌شده تغییر می‌دهد.

**تنظیمات قاطع کردن**

این مثال یک ویدیو محلی را جاسازی می‌کند و در حین پخش، ۲٫۵ ثانیه اول و یک ثانیه آخر را صرف نظر می‌کند. از ویدیویی بلندتر از ۳٫۵ ثانیه استفاده کنید تا یک بخش قابل پخش باقی بماند.

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

**خواندن تنظیمات قاطع کردن**

این مثال مقادیر قاطع کردن فریم ویدیو اول در اسلاید اول را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیو نداشته باشد، هیچ‌چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق متد [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) در دسترس قرار می‌گیرند.

### **افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را جاسازی می‌کند و یک ردیف زیرنویس WebVTT با برچسب English اضافه می‌کند. زمان‌بندی زیرنویس‌ها باید با ویدیو مطابقت داشته باشد. ارائه ذخیره‌شده شامل هر دو ویدیو و زیرنویس‌های آن است.

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

    # افزودن یک ردیف زیرنویس جدید از یک فایل WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) همچنین یک overload ارائه می‌دهد که به شما امکان افزودن زیرنویس‌ها از یک جریان (stream) را می‌دهد.

### **استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام ردیف‌های زیرنویس را از فریم‌های ویدیو در اسلاید اول به‌عنوان فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد ردیف‌های استخراج‌شده را گزارش می‌دهد. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت یک رشته UTF-8 نشان می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اسلاید اول حذف می‌کند و نتیجه را ذخیره می‌سازد. فرض می‌کند که اسلاید و شکل وجود دارند و شکل یک فریم ویدیو است.

```python
import jpway
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

اگر فقط یک ردیف زیرنویس را می‌خواهید حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) از متدهای [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) استفاده کنید.

### **جستجوی زیرنویس‌های ویدیو**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) کل ردیف WebVTT را به‌همراه هدر، خطوط زمان‌بندی و متن زیرنویس برمی‌گرداند. می‌توانید در حافظه زیرنویس‌ها را جستجو کنید تا عبارت و زمان‌بندی آن را پیدا کنید. برای مثال، یک ردیف انگلیسی در اسلاید ۲ ممکن است متن زیر را داشته باشد.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

این مثال `captioned_media.pptx` را باز می‌کند و از [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) برای خواندن ردیف‌های هر فریم ویدیو سطح بالایی در هر اسلاید استفاده می‌کند. در یک cue متنی ساده، خط زمان‌بندی شامل `-->` است و یک خط خالی cue را خاتمه می‌دهد. برای هر زیرنویسی که شامل «café» به هر حالت حروف باشد، مثال شماره اسلاید، برچسب ردیف، خط زمان‌بندی اصلی و کل زیرنویس را چاپ می‌کند.

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

جستجوی «café» یک تطبیق برای ردیف نمونه تولید می‌کند. جستجو هدر ردیف را مستثنی می‌کند و تنظیم زمان‌بندی و شکست خط‌ها را در خروجی حفظ می‌کند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیو به اسلایدها، Aspose.Slides امکان استخراج ویدیوهای جاسازی‌شده در ارائه‌ها را فراهم می‌کند.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به‌صورت فایل‌های باینری جداگانه و شماره‌دار استخراج می‌کند. ویدیوهای لینک‌شده نادیده گرفته می‌شوند چون داده‌ی جاسازی‌شده ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به نوع رسانه گزارش‌شده تغییر دهید.

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

## **FAQ**

**کدام پارامترهای پخش ویدیو می‌توانند برای یک فریم ویدیو تغییر کنند؟**

می‌توانید [حالت پخش](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (خودکار یا با کلیک) و [حلقه](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) را کنترل کنید. این گزینه‌ها از طریق متدهای شیء [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن یک ویدیو بر حجم فایل PPTX تاثیر می‌گذارد؟**

بله. وقتی یک ویدیو محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه به نسبت حجم فایل افزایش می‌یابد. وقتی به یک ویدیو آنلاین لینک می‌دهید و تصویر بندانگشتی اضافه می‌کنید، ارائه لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه داده‌های ویدیو، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانم ویدیو را در یک فریم ویدیوی موجود بدون تغییر موقعیت و اندازه‌اش جایگزین کنم؟**

بله. می‌توانید [محتوای ویدیو](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) را داخل فریم تعویض کنید در حالی که هندسه شکل را حفظ می‌کنید؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدیو جاسازی‌شده را تعیین کرد؟**

بله. یک ویدیو جاسازی‌شده دارای [نوع محتوا](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.