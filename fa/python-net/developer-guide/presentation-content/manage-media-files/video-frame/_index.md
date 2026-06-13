---
title: افزودن ویدیوها به ارائه‌ها در پایتون
linktitle: قاب ویدیو
type: docs
weight: 10
url: /fa/python-net/video-frame/
keywords:
- افزودن ویدیو
- ایجاد ویدیو
- تعبیه ویدیو
- استخراج ویدیو
- بازیابی ویدیو
- قاب ویدیو
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید به صورت برنامه نویسیافته قاب های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET اضافه و استخراج کنید. راهنمای سریع گام به گام."
---
## **مقدمه**

یک ویدیو به‌خوبی قرار داده شده در یک ارائه می‌تواند پیام شما را قانع‌کننده‌تر کند و سطح تعامل با مخاطبان را افزایش دهد. 

PowerPoint به شما اجازه می‌دهد تا ویدیوها را به یک اسلاید در ارائه اضافه کنید به دو روش:

* افزودن یا تعبیه یک ویدیو محلی (ذخیره شده روی دستگاه شما)
* افزودن یک ویدیو آنلاین (از منبع وبی مانند YouTube).

برای اینکه بتوانید ویدیوها (اشیای ویدیو) را به یک ارائه اضافه کنید، Aspose.Slides کلاس‌های [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) ، [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) و انواع مرتبط دیگر را فراهم می‌کند. 

## **ایجاد قاب ویدیو توکار**

اگر فایل ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک قاب ویدیو ایجاد کنید تا ویدیو را در ارائه خود تعبیه کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) اضافه کنید و مسیر فایل ویدیو را برای تعبیه ویدیو در ارائه پاس بدهید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) اضافه کنید تا یک قاب برای ویدیو ایجاد شود.  
1. ارائه تغییر یافته را ذخیره کنید.  

این کد Python نشان می‌دهد چطور یک ویدیو ذخیره شده به‌صورت محلی را به یک ارائه اضافه کنید:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # اسلاید اول را دریافت می‌کند و یک قاب ویدیو اضافه می‌کند
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # ارائه را روی دیسک ذخیره می‌کند
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

به‌جای آن می‌توانید ویدیو را با پاس دادن مستقیماً مسیر فایل به متد `add_video_frame(x, y, width, height, fname)` اضافه کنید:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **ایجاد قاب ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint 2013 و جدیدتر](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) از ویدیوهای YouTube در ارائه‌ها پشتیبانی می‌کند. اگر ویدیویی که می‌خواهید استفاده کنید به‌صورت آنلاین در دسترس باشد (مثلاً در YouTube)، می‌توانید آن را از طریق لینک وب به ارائه خود اضافه کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء [Video](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/) اضافه کنید و لینک ویدیو را پاس بدهید.  
1. یک تصویر بندانگشتی برای قاب ویدیو تنظیم کنید.  
1. ارائه را ذخیره کنید.  

این کد Python نشان می‌دهد چطور یک ویدیو از وب را به اسلایدی در ارائه PowerPoint اضافه کنید:

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

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته برای قاب‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها به فرمت WebVTT ذخیره می‌شوند و از طریق ویژگی [VideoFrame.caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) در دسترس هستند.

**افزودن زیرنویس به قاب ویدیو**

برای افزودن زیرنویس به یک قاب ویدیو:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
1. یک ویدیو به ارائه اضافه کنید.  
1. یک شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) به یک اسلاید اضافه کنید.  
1. از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) که توسط [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) برگردانده می‌شود برای افزودن یک مسیر زیرنویس WebVTT استفاده کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

کد زیر نشان می‌دهد چطور زیرنویس‌ها را به یک قاب ویدیو اضافه کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # یک مسیر زیرنویس جدید از فایل WebVTT اضافه می‌کند.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) همچنین یک بارگذاری اضافه دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک استریم اضافه کنید.

**استخراج زیرنویس‌ها از یک قاب ویدیو**

برای استخراج زیرنویس‌ها از یک قاب ویدیو:

1. ارائه‌ای که شامل ویدیو است را بارگذاری کنید.  
1. شیء هدف [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) را پیدا کنید.  
1. در مجموعه [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/caption_tracks/) پیمایش کنید.  
1. هر مسیر زیرنویس را در یک فایل `.vtt` ذخیره کنید.  

کد زیر نشان می‌دهد چطور زیرنویس‌ها را از یک قاب ویدیو استخراج کنید:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # مسیر زیرنویس را به یک فایل WebVTT ذخیره می‌کند.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

هر شیء [Captions](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌صورت رشته UTF‑8 در اختیار می‌گذارد.

**حذف زیرنویس‌ها از یک قاب ویدیو**

برای حذف زیرنویس‌ها از یک قاب ویدیو:

1. ارائه‌ای که شامل ویدیو است را بارگذاری کنید.  
1. شیء هدف [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) را دریافت کنید.  
1. مسیرهای زیرنویس را از [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) حذف کنید.  
1. ارائه تغییر یافته را ذخیره کنید.  

کد زیر نشان می‌دهد چطور تمام زیرنویس‌ها را از یک قاب ویدیو حذف کنید:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # تمام زیرنویس‌ها را از قاب ویدیو حذف می‌کند.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

اگر فقط نیاز به حذف یک مسیر زیرنویس دارید، به‌جای متد [clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/clear/) می‌توانید از متدهای [remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove/) یا [remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove_at/) استفاده کنید.

## **استخراج ویدیو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما اجازه می‌دهد ویدیوهای تعبیه‌شده در ارائه‌ها را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید تا ارائه حاوی ویدیو را بارگذاری کنید.  
2. در تمام اشیاء [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) پیمایش کنید.  
3. در تمام اشیاء [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) پیمایش کنید تا یک [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) پیدا کنید.  
4. ویدیو را بر روی دیسک ذخیره کنید.  

این کد Python نشان می‌دهد چطور ویدیو موجود در یک اسلاید ارائه را استخراج کنید:

```python
import aspose.slides as slides

# یک شیء Presentation را که نمایانگر فایل ارائه است ایجاد می‌کند
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای VideoFrame تغییر کنند؟**

شما می‌توانید حالت پخش ([playback mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/play_mode/)) (auto یا on click) و حلقه‌گذاری ([looping](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/play_loop_mode/)) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو باعث افزایش حجم فایل PPTX می‌شود؟**

بله. وقتی یک ویدیوی محلی را تعبیه می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین حجم ارائه متناسب با اندازه فایل افزایش می‌یابد. وقتی یک ویدیو آنلاین را اضافه می‌کنید، تنها یک لینک و تصویر بندانگشتی تعبیه می‌شود، لذا افزایش حجم کمتر است.

**آیا می‌توان ویدیو را در یک VideoFrame موجود بدون تغییر موقعیت و اندازه جایگزین کرد؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/embedded_video/) را داخل قاب تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریو رایج برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) ویدیو تعبیه‌شده را تشخیص داد؟**

بله. یک ویدیو تعبیه‌شده دارای یک [content type](https://reference.aspose.com/slides/fa/python-net/aspose.slides/video/content_type/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره‌سازی روی دیسک.