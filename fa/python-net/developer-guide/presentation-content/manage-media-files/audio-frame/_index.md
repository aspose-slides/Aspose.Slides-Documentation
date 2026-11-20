---
title: مدیریت فریم‌های صوتی در ارائه‌ها با پایتون
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/python-net/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر کوچک
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صوتی
- استخراج صدا
- WebVTT
- Python
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، نماد صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides برای پایتون از طریق .NET استخراج کنید."
---
## **بررسی کلی**

یک فریم صوتی به شما امکان می‌دهد صدا را روی اسلاید پخش کنید. با Aspose.Slides برای Python از طریق .NET می‌توانید یک کلیپ صوتی را جاسازی کنید، تصویری که نمایانگر آن است را انتخاب کنید، تنظیمات پخش را تغییر دهید و زیرنویس‌ها را اضافه کنید. همچنین می‌توانید صدایی که به یک انتقال اسلاید اختصاص داده شده است را بازیابی کنید.

## **ایجاد فریم‌های صوتی**

از [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) برای جاسازی یک کلیپ صوتی محلی در اسلاید اول استفاده کنید. دو مختصه اول موقعیت فریم را روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را بر حسب پوینت تنظیم می‌کند. این مثال [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) را برای شروع خودکار کلیپ و [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) را بر روی پیش‌تنظیم «بلند» تنظیم می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر تصویر بندانگشت فریم صوتی**

به‌صورت پیش‌فرض، یک فریم صوتی یک آیکون بلندگو را نمایش می‌دهد. برای نمایش یک تصویر بندانگشت سفارشی، با استفاده از [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) تصویری را به ارائه اضافه کنید و آن را به ویژگی [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) فریم اختصاص دهید. این مثال از یک فایل JPEG به‌عنوان تصویر بندانگشت برای یک کلیپ صوتی جاسازی‌شده استفاده می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر گزینه‌های پخش صدا**

کنترل‌های **Audio Options** در PowerPoint تعیین می‌کنند که کلیپ چه زمانی شروع شود، صدای آن چقدر باشد و در طول نمایش اسلاید چگونه رفتار کند.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| کنترل PowerPoint | ویژگی Aspose.Slides |
| --- | --- |
| شروع | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| پیش‌تنظیم صدا | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| پخش در سراسر اسلایدها | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| حلقه تا توقف | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| پنهان کردن در طول نمایش | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| بازپخش پس از پخش | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| محو شدن به آرامی (Fade In) | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| محو شدن به آرامی (Fade Out) | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| برش زمان شروع صدا | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| برش زمان انتهای صدا | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| نوار تنظیم صدا | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

این مثال اولین فریم صوتی را در اسلاید اول پیدا می‌کند، [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) را برای شروع پخش با کلیک تنظیم می‌کند و پیش‌تنظیم صدا «کم» را انتخاب می‌نماید. کلیپ در سراسر اسلایدها ادامه می‌یابد در حالی که حلقه‌ٔ آن غیرفعال است. آیکون در طول نمایش مخفی می‌ماند و پس از پخش، کلیپ به‌صورت خودکار به نقطهٔ آغاز باز می‌گردد.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

برای کلیپی که طول آن بیش از ۳٫۵ ثانیه است، این مثال ۱٫۵ ثانیهٔ اولیه و ۲ ثانیهٔ انتهایی را حذف می‌کند. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) مدت زمان حذف‌شده از انتهای کلیپ را تعیین می‌کند. برای به‌دست آوردن زمان انتهایی که در PowerPoint نشان داده می‌شود، این مقدار را از مدت کلیپ کامل کم کنید. کلیپ برش‌خورده با ۲۰۰ میلی‌ثانیه به‌صورت محو (Fade In) ورودی می‌شود و با ۵۰۰ میلی‌ثانیه از حالت محو (Fade Out) خارج می‌گردد. چهار ویژگی مذکور مقادیرشان برحسب میلی‌ثانیه است.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

برای تنظیم حجم پخش به درصد خاصی، از [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) استفاده کنید. این مثال حجم اولین فریم صوتی را در اسلاید اول به ۸۵٪ تنظیم می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت زیرنویس‌های صوتی**

هر فریم صوتی یک مجموعهٔ [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) دارد. می‌توانید از آن برای افزودن زیرنویس‌های WebVTT به کلیپ، استخراج مسیرهای موجود یا حذف آن‌ها استفاده کنید.

### **افزودن زیرنویس صوتی**

این مثال یک کلیپ صوتی را در اسلاید اول جاسازی می‌کند و با استفاده از [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) یک مسیر محلی WebVTT را اضافه می‌نماید. آرگومان اول برچسب مسیر را فراهم می‌کند و آرگومان دوم فایلی که شامل زیرنویس‌های زمان‌بندی‌شده است را شناسایی می‌کند.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویس متصل به یک فریم صوتی در اسلاید اول را استخراج می‌کند. دادهٔ باینری مسیر ([binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/)) را به یک فایل WebVTT می‌نویسد و از [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) به‌عنوان نام فایل استفاده می‌کند تا هر مسیر خروجی جداگانه‌ای داشته باشد.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) یا [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) برای حذف یک مسیر خاص استفاده کنید. این مثال با استفاده از [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) تمام زیرنویس‌های موجود در اولین فریم صوتی اسلاید اول را حذف می‌کند و در عین حال کلیپ صوتی را حفظ می‌نماید.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **یافتن خطی در زیرنویس‌های صوتی**

برای یافتن یک خط در زیرنویس‌های صوتی اسلاید اول، محتویات هر مسیر را با استفاده از [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) در حافظه می‌خوانید. در یک cue متنی ساده WebVTT، خط زمان‌بندی شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی cue را پایان می‌دهد. این مثال برچسب مسیر و هر خط زیرنویس حاوی واژه «café» را چاپ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **استخراج صدا**

یک انتقال اسلاید می‌تواند صدای اختصاصی خود را داشته باشد. برای بازیابی آن، ویژگی [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) انتقال را می‌خوانید. مثال دادهٔ باینری صدا ([binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/)) را دسترسی پیدا می‌کند و اندازهٔ آن را به بایت می‌نویسد. اگر اسلاید اول صدای انتقال نداشته باشد، به‌جای آن پیغامی چاپ می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **سوالات متداول**

**آیا می‌توانم همان کلیپ صوتی را در چندین اسلاید بدون ایجاد نسخهٔ تکراری استفاده کنم؟**

بله. کلیپ را یک‌بار به [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) ارائه اضافه کنید و همان شیء صوتی را برای هر اسلاید به [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) پاس دهید.

**آیا می‌توانم صدا را در یک فریم صوتی موجود جایگزین کنم؟**

بله. برای صداهای پیوندی، مقدار [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) را به مسیر فایل جایگزین تغییر دهید. برای صداهای جاسازی‌شده، یک کلیپ دیگر از مجموعهٔ صداهای ارائه را به [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) اختصاص دهید. هر دو روش فریم موجود را حفظ می‌کنند.

**آیا برش صدا دادهٔ صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

خیر. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) و [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) فقط مرزهای پخش را تنظیم می‌کنند. شما همچنان می‌توانید کلیپ کامل را از [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) بازیابی کنید.