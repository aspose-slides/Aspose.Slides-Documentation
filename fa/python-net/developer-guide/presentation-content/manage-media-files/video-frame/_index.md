---
title: افزودن ویدئوها به ارائه‌ها در پایتون
linktitle: قاب ویدئو
type: docs
weight: 10
url: /fa/python-net/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- دریافت ویدئو
- قاب ویدئو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه به صورت برنامه نویسی ویدئوها را به اسلایدهای PowerPoint و OpenDocument اضافه و استخراج کنید با استفاده از Aspose.Slides برای Python از طریق .NET. راهنمای سریع گام به گام."
---
## **مقدمه**

یک ویدئوی به‌موقع در ارائه می‌تواند پیام شما را قانع‌کننده‌تر کرده و سطح تعامل با مخاطبان را افزایش دهد.  

PowerPoint به شما امکان می‌دهد ویدئوها را به یک اسلاید در ارائه به دو روش اضافه کنید:

* افزودن یا جاسازی یک ویدئوی محلی (ذخیره‌شده بر روی دستگاه شما)
* افزودن یک ویدئوی آنلاین (از منبع وبی مانند YouTube).

برای امکان افزودن ویدئو (شیء ویدئو) به یک ارائه، Aspose.Slides کلاس‌های [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/)، [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) و انواع مرتبط دیگر را فراهم می‌کند. 

## **ایجاد قاب ویدئوی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک قاب ویدئو ایجاد کنید تا ویدئو را در ارائه جاسازی کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) اضافه کنید و مسیر فایل ویدئو را برای جاسازی ویدئو در ارائه منتقل کنید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) اضافه کنید تا یک قاب برای ویدئو ایجاد شود.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

این کد Python نشان می‌دهد چگونه یک ویدئوی محلی را به یک ارائه اضافه کنید:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # اسلاید اول را می‌گیرد و یک قاب ویدئو اضافه می‌کند
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # ارائه را بر روی دیسک ذخیره می‌کند
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

به‌طور جایگزین می‌توانید با عبور مستقیم مسیر فایل به متد `add_video_frame(x, y, width, height, fname)` ویدئو را اضافه کنید:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **ایجاد قاب ویدئویی با ویدئو از منبع وب**

نسخه‌های جدیدتر Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) پشتیبانی از ویدئوهای آنلاین در ارائه‌ها را دارند. اگر ویدئویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) اضافه کنید و لینک ویدئو را منتقل کنید.  
1. یک تصویر کوچک (thumbnail) برای قاب ویدئو تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد Python نشان می‌دهد چگونه یک ویدئوی وب را به اسلایدی در ارائهٔ PowerPoint اضافه کنید:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # یک VideoFrame اضافه می‌کند
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # تصویر بندانگشتی را بارگذاری می‌کند
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **قاب ویدئویی را برش دهید**

Aspose.Slides به شما امکان می‌دهد با تنظیم مقادیر `trim-from-start` و `trim-from-end` از طریق [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_start/) و [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_end/) بخشی از ویدئو را که پخش می‌شود کنترل کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند و مشخص می‌کنند چه مقدار زمان از ابتدای و انتهای ویدئو صرف‌نظر شود. این تنظیمات فقط رفتار پخش را در ارائه تغییر می‌دهند؛ دادهٔ باینری ویدئوی جاسازی‌شده را قطع یا تغییر نمی‌دهند.

**تنظیمات برش**

برای ایجاد یک قاب ویدئویی و تنظیم مقادیر برش آن:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) به ارائه اضافه کنید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.  
1. مقادیر `trim-from-start` و `trim-from-end` را از طریق [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_start/) و [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_end/) تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر اولین ۲٫۵ ثانیه و آخرین یک ثانیهٔ یک ویدئوی جاسازی‌شده را در طول پخش نادیده می‌گیرد:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**خواندن تنظیمات برش**

برای بررسی تنظیمات برش موجود، یک ارائه را بارگذاری کنید، یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) را در میان اشکال اسلاید اول پیدا کنید و مقادیر را از طریق [VideoFrame.trim_from_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_start/) و [VideoFrame.trim_from_end](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/trim_from_end/) بخوانید.

کد زیر اولین قاب ویدئویی را در اسلاید اول پیدا می‌کند و تنظیمات برش آن را بر حسب میلی‌ثانیه گزارش می‌دهد:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **مدیریت زیرنویس‌های ویدئو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای قاب‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق ویژگی [VideoFrame.caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) در دسترس هستند.

**افزودن زیرنویس به یک قاب ویدئویی**

برای افزودن زیرنویس به یک قاب ویدئویی:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک ویدئو به ارائه اضافه کنید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.  
1. از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) که توسط [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) برگردانده می‌شود استفاده کنید تا یک ردیف زیرنویس WebVTT اضافه کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس به یک قاب ویدئویی اضافه کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # یک ردیف زیرنویس جدید از یک فایل WebVTT اضافه می‌کند.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) همچنین یک overload دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از یک قاب ویدئویی**

برای استخراج زیرنویس‌ها از یک قاب ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.  
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) هدف را پیدا کنید.  
1. در مجموعهٔ [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) iterate کنید.  
1. هر ردیف زیرنویس را در یک فایل `.vtt` ذخیره کنید.  

کد زیر نشان می‌دهد چگونه زیرنویس‌ها را از یک قاب ویدئویی استخراج کنید:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # ردیف زیرنویس را در یک فایل WebVTT ذخیره می‌کند.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

هر شیء [Captions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captions/) شناسهٔ زیرنویس، برچسب، دادهٔ باینری و متن زیرنویس را به‌صورت رشتهٔ UTF‑8 ارائه می‌دهد.

**حذف زیرنویس‌ها از یک قاب ویدئویی**

برای حذف زیرنویس‌ها از یک قاب ویدئویی:

1. ارائه‌ای که شامل ویدئو است را بارگذاری کنید.  
1. شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) هدف را دریافت کنید.  
1. ردیف‌های زیرنویس را از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) حذف کنید.  
1. ارائهٔ اصلاح‌شده را ذخیره کنید.  

کد زیر نشان می‌دهد چگونه تمام زیرنویس‌ها را از یک قاب ویدئویی حذف کنید:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # نوع: slides.VideoFrame

    # تمام زیرنویس‌ها را از قاب ویدئو حذف می‌کند.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

اگر می‌خواهید فقط یک ردیف زیرنویس را حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/clear/) از متدهای [remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove/) یا [remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove_at/) استفاده کنید.

## **استخراج ویدئو از اسلاید**

علاوه بر افزودن ویدئو به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدئوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) برای بارگذاری ارائهٔ حاوی ویدئو ایجاد کنید.  
2. در تمام اشیای [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) تکرار کنید.  
3. در تمام اشیای [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) جستجو کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) پیدا کنید.  
4. ویدئو را بر روی دیسک ذخیره کنید.  

این کد Python نشان می‌دهد چگونه ویدئوی موجود در اسلاید یک ارائه را استخراج کنید:

```python
import aspose.slides as slides

# یک شیء Presentation ایجاد می‌کند که فایل ارائه را نمایندگی می‌کند 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدئو می‌توانند برای یک VideoFrame تغییر کنند؟**  
شما می‌توانید حالت پخش ([playback mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/play_mode/)) (خودکار یا با کلیک) و حلقه شدن ([looping](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/play_loop_mode/)) را از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) کنترل کنید.

**آیا افزودن یک ویدئو باعث افزایش اندازه فایل PPTX می‌شود؟**  
بله. هنگامی که یک ویدئوی محلی را جاسازی می‌کنید، دادهٔ باینری در سند گنجانده می‌شود، بنابراین اندازهٔ ارائه به نسبت حجم فایل افزایش می‌یابد. وقتی یک ویدئوی آنلاین اضافه می‌کنید، فقط یک لینک و تصویر کوچک جاسازی می‌شود، بنابراین افزایش اندازه کمتر است.

**آیا می‌توانم ویدئوی موجود در یک VideoFrame را بدون تغییر موقعیت و اندازه آن جایگزین کنم؟**  
بله. می‌توانید محتوای ویدئویی ([video content](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/embedded_video/)) را داخل قاب تعویض کنید در حالی که هندسهٔ شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روز‌رسانی رسانه در یک طرح موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**  
بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/content_type/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.