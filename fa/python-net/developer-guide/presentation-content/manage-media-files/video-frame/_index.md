---
title: مدیریت فریم‌های ویدئویی در ارائه‌ها با پایتون
linktitle: فریم ویدئویی
type: docs
weight: 10
url: /fa/python-net/video-frame/
keywords:
- افزودن ویدئو
- ایجاد ویدئو
- جاسازی ویدئو
- استخراج ویدئو
- دریافت ویدئو
- فریم ویدئویی
- منبع وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید به‌صورت برنامه‌نویسی فریم‌های ویدئویی را در اسلایدهای PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Python از طریق .NET اضافه و استخراج کنید. راهنمای سریع گام‌به‌گام."
---
## **مقدمه**

ویدیوها می‌توانند به توضیح ایده‌ها و جذب مخاطب کمک کنند. Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد فریم‌های ویدئویی را به اسلایدها اضافه کنید، تنظیمات پخش را تنظیم کنید، زیرنویس‌ها را مدیریت کنید و داده‌های ویدئویی جاسازی‌شده را استخراج کنید.

PowerPoint از ویدیوهای محلی و لینک‌های به ویدیوهای آنلاین، مانند ویدیوهای YouTube، پشتیبانی می‌کند.

برای نمایش داده‌های ویدئویی و فریم‌های ویدئویی، Aspose.Slides کلاس [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/)، کلاس [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) و سایر انواع مرتبط را فراهم می‌کند.

## **ایجاد فریم ویدئویی جاسازی‌شده**

اگر فایل ویدئویی که می‌خواهید به اسلاید خود اضافه کنید به صورت محلی ذخیره شده باشد، می‌توانید فریم ویدئویی ایجاد کنید تا ویدیو را در ارائه خود جاسازی کنید.

این مثال یک ویدئوی محلی را در اولین اسلاید یک ارائه موجود جاسازی می‌کند و نتیجه را ذخیره می‌کند. مختصات و ابعاد فریم بر حسب نقطه هستند. جریان تا پایان ذخیره‌سازی باز می‌ماند زیرا [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) آن را قفل نگه می‌دارد در حالی که ارائه از آن استفاده می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

همچنین می‌توانید مسیر ویدئوی محلی را مستقیماً به [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) پاس بدهید. این مثال ویدئو را در اولین اسلاید یک ارائه جدید جاسازی می‌کند. ویدئو باید تا زمان ذخیره‌سازی ارائه در دسترس باقی بماند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد فریم ویدئویی با ویدئو از منبع وب**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) از ویدیوهای آنلاین در ارائه‌ها پشتیبانی می‌کند. می‌توانید فریم ویدئویی ایجاد کنید که به یک ویدئوی آنلاین، مانند یک ویدئوی YouTube، لینک داشته باشد.

این مثال یک لینک ویدئوی YouTube و تصویر بندانگشتی آن را به اولین اسلاید اضافه می‌کند. شناسه ویدئو را جایگزین کنید تا از ویدئوی دیگری استفاده کنید. تنظیم [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) درخواست پخش خودکار را دارد. دانلود تصویر بندانگشتی و پخش ویدئو به دسترسی به اینترنت نیاز دارد. نمایشگر ارائه نیز باید از پخش آنلاین ویدئو پشتیبانی کند.

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

## **پخش ویدئو در حالت تمام‌صفحه**

در یک ارائه آموزشی، می‌توانید یک نمایش نرم‌افزاری را در حالت تمام‌صفحه پخش کنید تا مخاطب جزئیات را ببیند. برای فعال کردن این رفتار هنگام پخش، [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) را به `True` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و پخش تمام‌صفحه را فعال می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که فریم ویدئویی موجود در اولین اسلاید باشد.

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

پخش تمام‌صفحه نحوه نمایش ویدئو را کنترل می‌کند. به‌ طور مستقل، [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) تعیین می‌کند که آیا به‌ طور خودکار یا با کلیک شروع شود و [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) مشخص می‌کند که آیا تکرار شود. برای انتخاب رفتار شروع، حالت پخش را به [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) تنظیم کنید. مثال تنظیمات شروع و حلقه موجود را حفظ می‌کند.

## **بازگرداندن ویدئو پس از پخش**

در یک ارائه آموزشی، بازگرداندن ویدئوی نمایشی به ابتدای آن باعث می‌شود که برای ارائه‌دهنده آماده پخش دوباره باشد. برای بازگرداندن ویدئو به ابتدای آن پس از اتمام پخش، [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) را به `True` تنظیم کنید.

این مثال یک ارائه را باز می‌کند، اولین [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) را در اولین اسلاید پیدا می‌کند و بازگرداندن را فعال می‌کند. حلقه‌گذاری را غیرفعال می‌کند تا پخش بتواند تمام شود و پخش را برای شروع با کلیک تنظیم می‌کند. ارائه ورودی باید حداقل یک اسلاید داشته باشد که فریم ویدئویی موجود در اولین اسلاید باشد.

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

بازگرداندن ویدئو را به ابتدای آن برمی‌گرداند بدون این که دوباره شروع شود. در مقابل، فعال‌سازی [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) پخش را به‌ صورت خودکار تکرار می‌کند. وقتی می‌خواهید ویدئو به پایان برسد و برای پخش دوباره آماده بماند، حلقه‌گذاری را غیرفعال نگه دارید. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) به‌ طور مستقل شروع خودکار یا با کلیک را کنترل می‌کند؛ این مثال از [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) استفاده می‌کند تا ارائه‌دهنده زمان شروع پخش را کنترل کند. همان‌طور که در مثال نشان داده شده، حالت پخش پس از تنظیم حلقه تنظیم می‌شود. بازگرداندن به‌ طور مستقل از [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) کار می‌کند.

## **برش فریم ویدئویی**

از [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) و [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) برای حذف بخشی از ابتدای یا انتهای ویدئو هنگام پخش استفاده کنید. هر دو مقدار بر حسب میلی‌ثانیه هستند. برش تنظیمات پخش را بدون تغییر داده‌های ویدئوی جاسازی‌شده تغییر می‌دهد.

**تنظیمات برش**

این مثال یک ویدئوی محلی را جاسازی می‌کند و در هنگام پخش اولین ۲٫۵ ثانیه و آخرین یک ثانیه را حذف می‌کند. از ویدئویی طولانی‌تر از ۳٫۵ ثانیه استفاده کنید تا بخش قابل پخش باقی بماند.

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

**خواندن تنظیمات برش**

این مثال مقادیر برش اولین فریم ویدئویی در اولین اسلاید را به میلی‌ثانیه چاپ می‌کند. ارائه باید حداقل یک اسلاید داشته باشد. اگر آن اسلاید فریم ویدئویی نداشته باشد، هیچ چیزی چاپ نمی‌شود. مثال قبلی مقادیر ۲۵۰۰ و ۱۰۰۰ را تولید می‌کند.

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

## **مدیریت زیرنویس‌های ویدئویی**

Aspose.Slides به شما امکان می‌دهد زیرنویس‌های بسته برای فریم‌های ویدئویی در ارائه‌های PowerPoint را مدیریت کنید. زیرنویس‌ها در فرمت WebVTT ذخیره می‌شوند و از طریق ویژگی [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) در دسترس هستند.

### **اضافه کردن زیرنویس‌ها به فریم ویدئویی**

این مثال یک ویدئوی محلی را جاسازی می‌کند و یک مسیر زیرنویس WebVTT با عنوان English اضافه می‌کند. زمان‌بندهای زیرنویس باید با ویدئو مطابقت داشته باشند. ارائه ذخیره‌شده شامل هر دو ویدئو و زیرنویس‌های آن است.

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

کلاس [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) همچنین یک overload دارد که به شما اجازه می‌دهد زیرنویس‌ها را از یک جریان اضافه کنید.

### **استخراج زیرنویس‌ها از فریم ویدئویی**

این مثال تمام مسیرهای زیرنویس را از فریم‌های ویدئویی در اولین اسلاید به‌ صورت فایل‌های جداگانه WebVTT ذخیره می‌کند. شماره‌های متوالی باعث می‌شوند فایل‌های خروجی متمایز بمانند. کنسول تعداد مسیرهای استخراج‌شده را گزارش می‌کند. ارائه باید حداقل یک اسلاید داشته باشد.

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

هر شیء [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) شناسه زیرنویس، برچسب، داده‌های باینری و متن زیرنویس را به‌ عنوان رشته UTF-8 نمایش می‌دهد.

### **حذف زیرنویس‌ها از فریم ویدئویی**

این مثال تمام زیرنویس‌ها را از فریم ویدئویی در اولین موقعیت شکل در اولین اسلاید حذف می‌کند و نتیجه را ذخیره می‌کند. فرض می‌شود اسلاید و شکل وجود داشته باشند و شکل یک فریم ویدئویی باشد.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

اگر نیاز به حذف فقط یک مسیر زیرنویس دارید، به‌ جای [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/)، از متدهای [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) یا [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) استفاده کنید.

### **جستجوی زیرنویس‌های ویدئو**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) کل مسیر WebVTT را شامل هدر، خطوط زمان‌بندی و متن زیرنویس برمی‌گرداند. به‌ عنوان مثال، یک مسیر انگلیسی در اسلاید ۲ ممکن است این cue را داشته باشد:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

این مثال فایل `captioned_media.pptx` را باز می‌کند و [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) هر فریم ویدئویی سطح بالای هر اسلاید را می‌خواند. برای هر cue متنی ساده، خط زمان‌بندی حاوی `-->` را می‌یابد و خطوط زیرنویس را تا خط خالی بعدی یا انتهای مسیر جمع‌آوری می‌کند. متن زیرنویس را برای واژه «café» بدون توجه به حروف بزرگ/کوچک جستجو می‌کند و شماره اسلاید، برچسب مسیر، خط زمان‌بندی اصلی و کل زیرنویس را برای هر تطبیق چاپ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
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
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

مسیر نمونه یک تطبیق تولید می‌کند. «Café» در هدر خارج از متن زیرنویس است و خروجی تنظیم زمان‌بندی و هر دو خط زیرنویس را حفظ می‌کند.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **استخراج ویدئو از اسلاید**

علاوه بر افزودن ویدیوها به اسلایدها، Aspose.Slides به شما اجازه می‌دهد ویدیوهای جاسازی‌شده در ارائه‌ها را استخراج کنید.

این مثال ویدیوهای جاسازی‌شده را از هر اسلاید به‌ صورت فایل‌های باینری شماره‌دار جداگانه استخراج می‌کند. ویدیوهای لینک‌دار صرف‌نظر می‌شوند زیرا داده جاسازی‌شده‌ای ندارند. کنسول نوع MIME هر ویدئو و مجموع تعداد را چاپ می‌کند. خروجی از پسوند عمومی `.bin` استفاده می‌کند؛ در صورت نیاز آن را به پسوند مناسب با نوع رسانه گزارش‌شده تغییر دهید.

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

## **FAQ**

**کدام پارامترهای پخش ویدئو می‌توانند برای فریم ویدئویی تغییر کنند؟**

می‌توانید [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (خودکار یا با کلیک) و [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) را کنترل کنید. این گزینه‌ها از طریق ویژگی‌های شیء [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) در دسترس هستند.

**آیا افزودن ویدئو بر حجم فایل PPTX تأثیر می‌گذارد؟**

بله. زمانی که یک ویدئوی محلی را جاسازی می‌کنید، داده‌های باینری در سند گنجانده می‌شود، بنابراین اندازه ارائه به‌ نسبت حجم فایل افزایش می‌یابد. وقتی به یک ویدئو آنلاین لینک می‌دهید و یک تصویر بندانگشتی اضافه می‌کنید، ارائه فقط لینک و تصویر پیش‌نمایش را ذخیره می‌کند نه داده‌های ویدئو، بنابراین افزایش حجم معمولاً کمتر است.

**آیا می‌توانم ویدئو را در یک فریم ویدئویی موجود جایگزین کنم بدون اینکه موقعیت و اندازه آن تغییر کند؟**

بله. می‌توانید محتوای [video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) را درون فریم تعویض کنید در حالی که هندسه شکل حفظ می‌شود؛ این سناریوی رایجی برای به‌روزرسانی رسانه در یک چیدمان موجود است.

**آیا می‌توان نوع محتوا (MIME) یک ویدئوی جاسازی‌شده را تعیین کرد؟**

بله. یک ویدئوی جاسازی‌شده دارای یک [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) است که می‌توانید آن را بخوانید و استفاده کنید، برای مثال هنگام ذخیره به دیسک.