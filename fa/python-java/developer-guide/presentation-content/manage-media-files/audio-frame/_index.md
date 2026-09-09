---
title: مدیریت صدا در ارائه‌ها با پایتون
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/python-java/audio-frame/
keywords:
- صوت
- فریم صوتی
- تصویر بندانگشتی
- افزودن صوت
- ویژگی‌های صوت
- گزینه‌های صوت
- استخراج صدا
- پایتون
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای پایتون از طریق جاوا- مثال‌های کد برای جاسازی، برش، حلقه‌گذاری و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با فریم‌های صوتی در Aspose.Slides کار کنید. نشان می‌دهد چگونه صوت جاسازی‌شده را به اسلایدها اضافه کنید، تصویر پیش‌نمایش فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، تکرار، مخفی‌سازی، برش و مدت زمان‌های محو شدن را تنظیم کنید و صوت استفاده‌شده در انتقال‌های نمایش اسلایدها را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای Python از طریق Java به شما اجازه می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به عنوان فریم‌های صوتی در اسلایدها جاسازی می‌شوند. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع به اسلاید را بر اساس شاخص آن دریافت کنید.
3. فایل صوتی که می‌خواهید در اسلاید جاسازی کنید را بخوانید.
4. فریم صوتی جاسازی‌شده (شامل فایل صوتی) را به اسلاید اضافه کنید.
5. از متدهای [setPlayMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayMode) و [setVolume](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolume) که توسط شیء [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) ارائه می‌شوند استفاده کنید.
6. ارائه‌ی اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک فریم صوتی جاسازی‌شده به اسلاید اضافه شود:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر تصویر بندانگشتی فریم صوتی**

هنگامی که یک فایل صوتی را به ارائه اضافه می‌کنید، صوت به صورت فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (به تصویر در بخش زیر مراجعه کنید). می‌توانید تصویر پیش‌نمایش فریم صوتی را به تصویری از انتخاب خود تغییر دهید.

این کد Python نشان می‌دهد چگونه تصویر بندانگشتی یا پیش‌نمایش فریم صوتی را تغییر دهید:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تغییر گزینه‌های پخش صوت**

Aspose.Slides برای Python از طریق Java به شما اجازه می‌دهد گزینه‌هایی که کنترل پخش صوت یا ویژگی‌های آن را تنظیم می‌کنند، تغییر دهید. به عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صوت را به صورت حلقه‌ای پخش کنید یا حتی نماد صوت را مخفی کنید.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

گزینه‌های **Audio Options** در PowerPoint که با ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارند:

- فهرست کشویی **Start** با متد [setPlayMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayMode) مطابقت دارد
- **Volume** با متد [setVolume](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolume) مطابقت دارد
- **Play Across Slides** با متد [setPlayAcrossSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) مطابقت دارد
- **Loop until Stopped** با متد [setPlayLoopMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayLoopMode) مطابقت دارد
- **Hide During Show** با متد [setHideAtShowing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setHideAtShowing) مطابقت دارد
- **Rewind after Playing** با متد [setRewindAudio](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setRewindAudio) مطابقت دارد

گزینه‌های **Editing** در PowerPoint که با ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارند:

- **Fade In** با متد [setFadeInDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setFadeInDuration) مطابقت دارد
- **Fade Out** با متد [setFadeOutDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setFadeOutDuration) مطابقت دارد
- **Trim Audio Start Time** با متد [setTrimFromStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setTrimFromStart) مطابقت دارد
- مقدار **Trim Audio End Time** برابر است با طول کل صوت منهای مقداری که توسط متد [setTrimFromEnd](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setTrimFromEnd) تنظیم می‌شود

کنترل **Volume** در پنل کنترل صوت PowerPoint با متد [setVolumeValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolumeValue) مطابقت دارد. این متد به شما امکان می‌دهد حجم صوت را به صورت درصد تغییر دهید.

این روش برای تغییر گزینه‌های پخش صوت است:

1. [Create](#create-audio-frames) یا فریم صوتی را دریافت کنید.
2. مقادیر جدید برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، تعیین کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد که چگونه گزینه‌های صوتی تنظیم شوند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # پخش با کلیک با حجم کم، در تمام اسلایدها، بدون حلقه‌گذاری.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # پنهان کردن فریم در طول نمایش اسلاید و بازگرداندن پس از پخش.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

این مثال Python نشان می‌دهد چگونه یک فریم صوتی جدید با صوت جاسازی‌شده اضافه شود، آن را برش داده و مدت زمان‌های محو شدن را تنظیم کند:

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
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 1.5 ثانیه را از ابتدا و 2 ثانیه را از انتها برش دهید.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # محو شدن ورودی را به 200 میلی‌ثانیه و خروجی را به 500 میلی‌ثانیه تنظیم کنید.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صوت جاسازی‌شده بازیابی شود و حجم آن به 85٪ تنظیم شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **مدیریت زیرنویس‌های صوتی**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته را به یک فریم صوتی از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#getCaptionTracks) اضافه کنید. این متد یک [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) را برمی‌گرداند که به شما امکان می‌دهد ردیف‌های زیرنویس WebVTT را اضافه، در ردیف‌های موجود پیمایش کنید و در صورت لزوم آن‌ها را حذف کنید.

**Add Audio Captions**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#getCaptionTracks) برای اضافه کردن یک یا چند ردیف زیرنویس به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس ردیف زیرنویس جدیدی از یک فایل `.vtt` بارگذاری می‌شود.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # یک ردیف زیرنویس جدید از فایل WebVTT اضافه کنید.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Extract Audio Captions**

می‌توانید در ردیف‌های زیرنویس مرتبط با یک فریم صوتی پیمایش کنید و آن‌ها را به عنوان فایل‌های `.vtt` ذخیره کنید. هر ردیف زیرنویس داده‌های باینری و شناسه یکتای خود را در اختیار می‌گذارد که هنگام خروجی‌گیری زیرنویس‌ها می‌توان از آن استفاده کرد.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # ردیف زیرنویس را به عنوان فایل .vtt ذخیره کنید.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Remove Audio Captions**

برای حذف زیرنویس‌ها از یک فریم صوتی، از متدهای موجود در [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) مانند [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#removeAt) استفاده کنید. مثال زیر تمام ردیف‌های زیرنویس را از یک فریم صوتی حذف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **استخراج صوت**

Aspose.Slides برای Python از طریق Java به شما اجازه می‌دهد صدای استفاده‌شده در انتقال‌های نمایش اسلاید را استخراج کنید. به عنوان مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که شامل صوت است را بارگذاری کنید.
2. مرجع به اسلاید مربوطه را بر اساس ایندکس آن دریافت کنید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideShowTransition) مربوط به اسلاید دسترسی پیدا کنید.
4. صدای مورد نظر را به‌عنوان داده بایتی استخراج کنید.

این کد Python نشان می‌دهد چگونه صوت استفاده‌شده در یک اسلاید استخراج شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**آیا می‌توانم همان فایل صوتی را در اسلایدهای متعدد بدون افزایش اندازه فایل استفاده کنم؟**

بله. صوت را یک‌بار به **audio collection** مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی که به همان منبع ارجاع می‌دهند ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری می‌کند و اندازه ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدای یک فریم صوتی موجود را بدون ایجاد مجدد شکل جایگزین کنم؟**

بله. برای صدای لینک‌شده، مسیر لینک ([link path](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setLinkPathLong)) را به فایل جدید تغییر دهید. برای صدای جاسازی‌شده، شیء **embedded audio** را با شیء دیگری از **audio collection** ارائه جایگزین کنید. قالب‌بندی فریم و اکثر تنظیمات پخش همان‌طور که هست باقی می‌مانند.

**آیا برش (trim) داده‌های صوتی زیرساختی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

خیر. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صوت دست‌نخورده باقی می‌مانند و از طریق صوت جاسازی‌شده یا **audio collection** ارائه قابل دسترسی هستند.