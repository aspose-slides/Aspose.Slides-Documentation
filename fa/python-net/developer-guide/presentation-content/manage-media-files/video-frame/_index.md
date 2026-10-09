---
title: مدیریت فریم‌های ویدیو در ارائه‌ها با پایتون
linktitle: فریم ویدیو
type: docs
weight: 10
url: /fa/python-net/video-frame/
keywords:
- افزودن ویدیو
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
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدیو را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها کمک کرده و مخاطب را درگیر کنند. Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد فریم‌های ویدیو را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدیوهای جاسازی‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و پیوندهای به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدیو و فریم‌های ویدیو، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) ، کلاس [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) و سایر انواع مرتبط را ارائه می‌دهد.

## **ایجاد فریم ویدیو جاسازی‌شده**

اگر فایلی ویدیویی که می‌خواهید به اسلاید خود اضافه کنید به‌صورت محلی ذخیره شده باشد، می‌توانید یک فریم ویدیو ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدیو محلی را در اولین اسلاید یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌نماید. مختصات و ابعاد فریم بر حسب پوینت است. جریان باز می‌ماند تا پایان ذخیره‌سازی زیرا [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) آن را در حالت قفل نگه می‌دارد در حالی که ارائه از آن استفاده می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید مسیر ویدیو محلی را به طور مستقیم به [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) پاس کنید. این مثال ویدیو را در اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدیو باید تا زمان ذخیره‌سازی ارائه در دسترس بماند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد فریم ویدیو با ویدیو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید یک فریم ویدیو ایجاد کنید که به یک ویدیو آنلاین، مانند یک ویدیو YouTube، پیوند می‌دهد.

این مثال پیوند ویدیو YouTube و تصویر بندانگشتی آن را به اولین اسلاید اضافه می‌کند. شناسه ویدیو را برای استفاده از ویدیوی دیگری جایگزین کنید. تنظیم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) درخواست پخش خودکار را دارد. بارگیری تصویر بندانگشتی و پخش ویدیو نیاز به دسترسی به اینترنت دارد. نمایشگر ارائه نیز باید از پخش ویدیو آنلاین پشتیبانی کند.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **پخش ویدیو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) را به `True` تنظیم کنید تا این رفتار را در حین پخش فعال کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌نماید. ارائه ورودی باید حداقل یک اسلاید حاوی فریم ویدیو موجود در اولین اسلاید داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

پخش تمام‌صفحه کنترل می‌کند که ویدیو چگونه نمایش داده شود. به طور مستقل، [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) تعیین می‌کند که آیا به‌صورت خودکار یا با کلیک شروع شود، و [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) تعیین می‌کند که آیا تکرار شود. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگردانی ویدیو پس از پخش**

در یک ارائه آموزشی، بازگرداندن یک ویدیوی نمایش به ابتدای آن باعث می‌شود برای ارائه‌دهنده آماده باشد تا دوباره پخش شود. [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) را به `True` تنظیم کنید تا پس از پایان پخش ویدیو به ابتدا برگردد.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و بازگردانی را فعال می‌کند. حلقه‌سازی غیرفعال می‌شود تا پخش بتواند به پایان برسد و پخش بر روی کلیک تنظیم می‌شود. ارائه ورودی باید حداقل یک اسلاید حاوی فریم ویدیو موجود در اولین اسلاید داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

بازگردانی ویدیو را به ابتدای آن برمی‌گرداند بدون اینکه دوباره شروع به پخش کند. در مقابل، فعال‌سازی [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) پخش را به‌صورت خودکار تکرار می‌کند. هنگامیکه می‌خواهید ویدیو به پایان برسد و آماده بازپخش بماند، حلقه را غیرفعال نگه دارید. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) به‌صورت مستقل کنترل می‌کند که پخش به‌صورت خودکار یا با کلیک آغاز شود؛ این مثال از [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. تنظیم حالت پخش پس از تنظیم حلقه انجام می‌شود، همان‌طور که در مثال نشان داده شده است. بازگردانی به‌صورت مستقل از [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) کار می‌کند.

## **قلم زدن (Trim) فریم ویدیو**

از [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) و [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) برای نادیده گرفتن بخشی از ابتدا یا انتهای ویدیو در حین پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه است. قلم زدن تنظیمات پخش را بدون تغییر داده‌های ویدیوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات قلم زدن**

این مثال یک ویدیو محلی را جاسازی می‌کند و دو ثانیه و نیم اول و یک ثانیه آخر را در حین پخش نادیده می‌گیرد. از ویدیویی طولانی‌تر از 3.5 ثانیه استفاده کنید تا بخشی قابل پخش باقی بماند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**خواندن تنظیمات قلم زدن**

این مثال مقادیر قلم زدن فریم ویدیو اول در اولین اسلاید را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدیویی نداشته باشد، هیچ چیز چاپ نمی‌شود. مثال قبلی مقادیر 2500 و 1000 را تولید می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **مدیریت زیرنویس‌های ویدیو**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدیو در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در قالب WebVTT ذخیره می‌شوند و از طریق ویژگی [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) در دسترس هستند.

**افزودن زیرنویس به فریم ویدیو**

این مثال یک ویدیو محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با عنوان English اضافه می‌نماید. زمان‌بندی زیرنویس‌ها باید با ویدیو مطابقت داشته باشد. ارائه ذخیره‌شده هم ویدیو و هم زیرنویس‌های آن را شامل می‌شود.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

کلاس [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) همچنین یک overload ارائه می‌دهد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان (stream) اضافه کنید.

**استخراج زیرنویس‌ها از فریم ویدیو**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدیو در اولین اسلاید به‌صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های متوالی فایل‌های خروجی را متمایز نگه می‌دارند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

هر شیء [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده باینری و متن زیرنویس را به‌عنوان یک رشته UTF-8 در اختیار می‌گذارد.

**حذف زیرنویس‌ها از فریم ویدیو**

این مثال تمام زیرنویس‌ها را از فریم ویدیو در اولین موقعیت شکل در اولین اسلاید حذف کرده و نتیجه را ذخیره می‌کند. فرض می‌شود اسلاید و شکل وجود دارد و شکل یک فریم ویدیو است.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز دارید تنها یک مسیر زیرنویس را حذف کنید، به‌جای [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) از روش‌های [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) یا [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) استفاده کنید.

## **استخراج ویدیو از اسلاید**

به‌جز اضافه کردن ویدیوها به اسلایدها، Aspose.Slides به شما امکان می‌دهد ویدیوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به‌صورت فایل‌های باینری شماره‌گذاری‌شده جداگانه استخراج می‌کند. ویدیوهای پیوندی صرف‌نظر می‌شوند زیرا داده‌های جاسازی‌شده ندارند. کنسول نوع MIME هر ویدیو و تعداد کل را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز می‌توانید آن را به‌گونه‌ای تغییر دهید که با نوع رسانه گزارش‌شده مطابقت داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **پرسش‌های متداول**

**کدام پارامترهای پخش ویدیو می‌توانند برای فریم ویدیو تغییر کنند؟**

می‌توانید [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدیو باعث افزایش حجم فایل PPTX می‌شود؟**

بله. وقتی یک ویدیو محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین حجم ارائه به نسبت اندازه فایل ویدیو افزایش می‌یابد. وقتی به یک ویدیو آنلاین پیوند می‌خورید و تصویر بندانگشتی اضافه می‌کنید، فقط پیوند و تصویر پیش‌نمایش ذخیره می‌شود، نه داده‌های ویدیو، بنابراین معمولاً افزایش حجم کمتر است.

**آیا می‌توان ویدیو موجود در فریم ویدیو را بدون تغییر موقعیت و اندازه آن جایگزین کرد؟**

بله. می‌توانید محتوای [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) را داخل فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این یک سناریوی رایج برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) ویدیو جاسازی‌شده را تعیین کرد؟**

بله. یک ویدیو جاسازی‌شده یک [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) دارد که می‌توانید بخوانید و از آن استفاده کنید، برای مثال هنگام ذخیره‌سازی بر روی دیسک.