---
title: مدیریت صدا در ارائه‌ها با استفاده از پایتون
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/python-net/audio-frame/
keywords:
- افزودن صدا
- جاسازی صدا
- فریم صوتی
- فایل صوتی
- ویژگی‌های صوتی
- استخراج صدا
- بازیابی صدا
- تغییر صدا
- گزینه‌های پخش
- حالت پخش
- پخش در سراسر اسلایدها
- حلقه تا توقف
- مخفی کردن هنگام نمایش
- پس‌گردانی پس از پخش
- حجم صدا
- تصویر پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "به راحتی فریم‌های صوتی را در PPT، PPTX و ODP با Aspose.Slides برای پایتون از طریق .NET اضافه، استخراج و مدیریت کنید. مثال‌های کد را بررسی کنید و ارائه‌های خود را امروز ارتقا دهید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. نحوه اضافه کردن صداهای جاسازی‌شده به اسلایدها، سفارشی‌سازی تصویر بندانگشتی فریم صوتی، پیکربندی گزینه‌های پخش مانند حجم، حلقه‌دار کردن، مخفی کردن، برش و مدت زمان‌های محو شدن، و استخراج صدایی که در انتقال‌های نمایش اسلایدها استفاده می‌شود را نشان می‌دهد.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای Python از طریق .NET به شما اجازه می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به‌صورت فریم‌های صوتی در اسلایدها جاسازی می‌شوند. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. جریان فایل صوتی که می‌خواهید در اسلاید جاسازی کنید را بارگذاری کنید.  
4. فریم صوتی جاسازی‌شده (شامل فایل صوتی) را به اسلاید اضافه کنید.  
5. مقادیر [PlayMode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioplaymodepreset) و `Volume` ارائه‌شده توسط شیء [IAudioFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/) را تنظیم کنید.  
6. ارائه اصلاح‌شده را ذخیره کنید.  

این کد Python نشان می‌دهد که چگونه یک فریم صوتی جاسازی‌شده را به اسلاید اضافه کنید:

```python
import aspose.slides as slides

# نمونه‌سازی یک کلاس ارائه که نمایانگر یک فایل ارائه است
with slides.Presentation() as pres:
    # اسلاید اول را دریافت می‌کند
    sld = pres.slides[0]

    # فایل صوتی wav را به‌عنوان جریان بارگذاری می‌کند
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # فریم صوتی را اضافه می‌کند
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # حالت پخش و حجم صدا را تنظیم می‌کند
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # فایل PowerPoint را در دیسک ذخیره می‌کند
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر تصویر بندانگشتی فریم صوتی**

هنگامی که یک فایل صوتی را به یک ارائه اضافه می‌کنید، صدا به‌صورت فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (به تصویر در بخش زیر مراجعه کنید). می‌توانید تصویر بندانگشتی فریم صوتی را به تصویر دلخواه خود تغییر دهید.  

این کد Python نشان می‌دهد که چگونه تصویر بندانگشتی یا پیش‌نمایش فریم صوتی را تغییر دهید:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # یک فریم صوتی را به اسلاید اضافه می‌کند با موقعیت و اندازه مشخص.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # یک تصویر را به منابع ارائه اضافه می‌کند.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # تصویر فریم صوتی را تنظیم می‌کند.
        audioFrame.picture_format.picture.image = audioImage
        
        #ارائهٔ اصلاح‌شده را در دیسک ذخیره می‌کند
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر گزینه‌های پخش صوتی**

Aspose.Slides برای Python از طریق .NET به شما اجازه می‌دهد گزینه‌هایی را که رفتار پخش صدا یا ویژگی‌های آن را کنترل می‌کنند، تغییر دهید. برای مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به‌صورت حلقه‌ای پخش کنید یا حتی نماد صدا را مخفی کنید.

پنل **Audio Options** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**Audio Options** در PowerPoint که با ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارد:

- **Start** فهرست کشویی با خاصیت [AudioFrame.play_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/play_mode/) مطابقت دارد  
- **Volume** با خاصیت [AudioFrame.volume](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/volume/) مطابقت دارد  
- **Play Across Slides** با خاصیت [AudioFrame.play_across_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/play_across_slides/) مطابقت دارد  
- **Loop until Stopped** با خاصیت [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/play_loop_mode/) مطابقت دارد  
- **Hide During Show** با خاصیت [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/hide_at_showing/) مطابقت دارد  
- **Rewind after Playing** با خاصیت [AudioFrame.rewind_audio](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/rewind_audio/) مطابقت دارد  

گزینه‌های **Editing** در PowerPoint که با ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارد:

- **Fade In** با خاصیت [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/fade_in_duration/) مطابقت دارد  
- **Fade Out** با خاصیت [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/fade_out_duration/) مطابقت دارد  
- **Trim Audio Start Time** با خاصیت [AudioFrame.trim_from_start](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/trim_from_start/) مطابقت دارد  
- **Trim Audio End Time** مقدار برابر با مدت زمان صدا منهای مقدار [AudioFrame.trim_from_end](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/trim_from_end/) است  

کنترل **Volume** در پنل کنترل صدا در PowerPoint به خاصیت [AudioFrame.volume_value](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/volume_value/) مربوط می‌شود. این امکان را می‌دهد تا حجم صدا را به‌صورت درصدی تغییر دهید.

این‌ها مراحل تغییر گزینه‌های پخش صدا هستند:

1. [Create](#create-audio-frame) یا دریافت فریم صوتی.  
2. مقادیر جدیدی برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، تنظیم کنید.  
3. فایل پاورپوینت اصلاح‌شده را ذخیره کنید.  

این کد Python یک عملیات را نشان می‌دهد که در آن گزینه‌های صدا تنظیم می‌شوند:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # فریم AudioFrame را دریافت می‌کند
    audioFrame = pres.slides[0].shapes[0]

    # حالت Play mode را به پخش با کلیک تنظیم می‌کند
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # حجم صدا را به Low تنظیم می‌کند
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # صدا را برای پخش در سراسر اسلایدها تنظیم می‌کند
    audioFrame.play_across_slides = True

    # حلقه صدا را غیرفعال می‌کند
    audioFrame.play_loop_mode = False

    # فریم AudioFrame را در طول نمایش اسلایدها مخفی می‌کند
    audioFrame.hide_at_showing = True

    # پس از پخش صدا را به ابتدا باز می‌گرداند
    audioFrame.rewind_audio = True

    # فایل PowerPoint را در دیسک ذخیره می‌کند
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

این مثال Python نشان می‌دهد چگونه یک فریم صوتی جدید با صداهای جاسازی‌شده اضافه، برش داده و مدت زمان‌های محو شدن را تنظیم کنید:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # تنظیم افست شروع برش به 1.5 ثانیه
    audio_frame.trim_from_start = 1500.0
    # تنظیم افست پایان برش به 2 ثانیه
    audio_frame.trim_from_end = 2000.0

    # تنظیم مدت زمان fade-in به 200 میلی‌ثانیه
    audio_frame.fade_in_duration = 200.0
    # تنظیم مدت زمان fade-out به 500 میلی‌ثانیه
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صداهای جاسازی‌شده بازیابی شده و حجم آن را به ۸۵٪ تنظیم کنید:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # یک فریم صوتی را دریافت می‌کند
    audio_frame = pres.slides[0].shapes[0]

    # حجم صدا را به 85% تنظیم می‌کند
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته به فریم صوتی را از طریق ویژگی [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/caption_tracks/) اضافه کنید. این ویژگی یک [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) برمی‌گرداند که به شما امکان می‌دهد ردیاب‌های WebVTT را اضافه، از میان ردیاب‌های موجود عبور کنید و در صورت لزوم آن‌ها را حذف کنید.

**Add Audio Captions**

از ویژگی [caption_tracks](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/caption_tracks/) برای پیوست یک یا چند ردیاب زیرنویس به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس یک ردیاب زیرنویس جدید از یک فایل `.vtt` بارگذاری می‌شود.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # یک ردیاب زیرنویس جدید را از یک فایل WebVTT اضافه کنید.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extract Audio Captions**

می‌توانید از میان ردیاب‌های زیرنویس مرتبط با فریم صوتی عبور کنید و آن‌ها را به‌صورت فایل‌های `.vtt` ذخیره نمایید. هر ردیاب زیرنویس داده‌های باینری و شناسه منحصر به‌فرد خود را در اختیار می‌گذارد که می‌توان هنگام استخراج زیرنویس‌ها از آن استفاده کرد.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # ردیاب زیرنویس را به عنوان یک فایل .vtt ذخیره کنید.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Remove Audio Captions**

برای حذف زیرنویس‌ها از فریم صوتی، از متدهای ارائه‌شده توسط [CaptionsCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/) مانند [clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/clear/)، [remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove/)، یا [remove_at](https://reference.aspose.com/slides/fa/python-net/aspose.slides/captionscollection/remove_at/) استفاده کنید. مثال زیر تمام ردیاب‌های زیرنویس را از یک فریم صوتی حذف می‌کند.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # نوع: slides.AudioFrame

    # تمام ردیاب‌های زیرنویس را از فریم صوتی حذف کنید.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج صدا**
Aspose.Slides برای Python از طریق .NET به شما امکان می‌دهد صداهایی را که در انتقال‌های نمایش اسلاید استفاده می‌شوند استخراج کنید. برای مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کرده و ارائه حاوی صدا را بارگذاری کنید.  
2. مرجع اسلاید مربوطه را از طریق شاخص آن دریافت کنید.  
3. به انتقال‌های اسلاید برای اسلاید دسترسی پیدا کنید.  
4. صدا را به‌صورت داده بایتی استخراج کنید.  

این کد Python نشان می‌دهد چگونه صدا استفاده‌شده در یک اسلاید را استخراج کنید:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # به اسلاید مورد نظر دسترسی می‌یابد
    slide = pres.slides[0]  

    # تأثیرات انتقال اسلاید نمایش را برای اسلاید دریافت می‌کند
    transition = slide.slide_show_transition

    #صوت را به آرایه بایت استخراج می‌کند
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **پرسش‌های متداول**

**آیا می‌توانم همان دارایی صوتی را در اسلایدهای متعدد بدون افزایش حجم فایل دوباره استفاده کنم؟**

بله. صدا را یک‌بار به [audio collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/audios/) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی که به آن دارایی ارجاع می‌دهند ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را کنترل می‌پذیرد.

**آیا می‌توانم صدای موجود در یک فریم صوتی را بدون ایجاد شکل جدید جایگزین کنم؟**

بله. برای صدای پیوندی، مسیر [link path](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/link_path_long/) را به فایل جدید تغییر دهید. برای صدای جاسازی‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/embedded_audio/) را با دیگری از [audio collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/audios/) ارائه عوض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش دست نخورده باقی می‌مانند.

**آیا برش تغییرات در داده‌های صوتی زیرین ذخیره‌شده در ارائه ایجاد می‌کند؟**

نه. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صوتی بدون تغییر باقی می‌مانند و از طریق صداهای جاسازی‌شده یا مجموعه صوتی ارائه در دسترس هستند.