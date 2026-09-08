---
title: مدیریت صدا در ارائه‌ها با استفاده از Python
linktitle: قاب صدا
type: docs
weight: 10
url: /fa/python-java/audio-frame/
keywords:
- صدا
- قاب صدا
- تصویر بندکمک
- افزودن صدا
- ویژگی‌های صدا
- گزینه‌های صدا
- استخراج صدا
- پایتون
- Aspose.Slides
description: "ایجاد و کنترل فریم‌های صوتی در Aspose.Slides برای Python از طریق Java—نمونه‌های کد برای جاسازی، برش، حلقه‌زدن و پیکربندی پخش در ارائه‌های PPT، PPTX و ODP."
---
## **نمای کلی**

این مقاله نحوه کار با فریم‌های صوتی در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه صداهای جاسازی‌شده را به اسلایدها اضافه کنید، تصویر پیش‌نمایش فریم صوتی را سفارشی کنید، گزینه‌های پخش مانند حجم، حلقه‌زدن، مخفی‌کردن، برش و مدت زمان محو شدن را پیکربندی کنید و صداهای مورد استفاده در انتقال‌های نمایش اسلاید را استخراج کنید.

## **ایجاد فریم‌های صوتی**

Aspose.Slides برای Python via Java به شما اجازه می‌دهد فایل‌های صوتی را به اسلایدها اضافه کنید. فایل‌های صوتی به‌عنوان فریم‌های صوتی در اسلایدها جاسازی می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.
3. فایل صوتی مورد نظر خود را که می‌خواهید در اسلاید جاسازی کنید، بخوانید.
4. فریم صوتی جاسازی‌شده (دارای فایل صوتی) را به اسلاید اضافه کنید.
5. متدهای [setPlayMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayMode) و [setVolume](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolume) که توسط شیء [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) ارائه می‌شوند را تنظیم کنید.
6. ارائه اصلاح‌شده را ذخیره کنید.

این کد Python نشان می‌دهد چگونه یک فریم صوتی جاسازی‌شده به اسلاید اضافه کنید:

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

## **تغییر تصویر پیش‌نمایش فریم صوتی**

زمانی که یک فایل صوتی را به ارائه اضافه می‌کنید، صدا به‌صورت فریمی با تصویر پیش‌فرض استاندارد ظاهر می‌شود (نگاه کنید به تصویر در بخش زیر). می‌توانید تصویر پیش‌نمایش فریم صوتی را تغییر دهید (تصویر دلخواه خود را تنظیم کنید).

این کد Python نشان می‌دهد چگونه تصویر بند‑کمک یا پیش‌نمایش فریم صوتی را تغییر دهید:

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

## **تغییر گزینه‌های پخش صدا**

Aspose.Slides برای Python via Java امکان تغییر گزینه‌هایی که رفتار یا ویژگی‌های پخش صدا را کنترل می‌کنند، فراهم می‌کند. به‌عنوان مثال می‌توانید حجم صدا را تنظیم کنید، صدا را به‌صورت حلقه‌ای پخش کنید یا حتی نماد صدا را مخفی کنید.

پنل **گزینه‌های صدا** در Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

**گزینه‌های صدا** PowerPoint که به ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارند:

- فهرست کشویی **Start** متناظر با متد [setPlayMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayMode) است
- **Volume** متناظر با متد [setVolume](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolume) است
- **Play Across Slides** متناظر با متد [setPlayAcrossSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) است
- **Loop until Stopped** متناظر با متد [setPlayLoopMode](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setPlayLoopMode) است
- **Hide During Show** متناظر با متد [setHideAtShowing](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setHideAtShowing) است
- **Rewind after Playing** متناظر با متد [setRewindAudio](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setRewindAudio) است

گزینه‌های **ویرایش** PowerPoint که به ویژگی‌های [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) در Aspose.Slides مطابقت دارند:

- **Fade In** متناظر با متد [setFadeInDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setFadeInDuration) است
- **Fade Out** متناظر با متد [setFadeOutDuration](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setFadeOutDuration) است
- **Trim Audio Start Time** متناظر با متد [setTrimFromStart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setTrimFromStart) است
- مقدار **Trim Audio End Time** برابر است با مدت زمان صدا منهای مقدار متد [setTrimFromEnd](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setTrimFromEnd)

کنترل **حجم** در پنل کنترل صدا در PowerPoint متناظر با متد [setVolumeValue](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setVolumeValue) است. این متد به شما اجازه می‌دهد حجم صدا را به‌صورت درصد تغییر دهید.

این نحوه تغییر گزینه‌های پخش صدا است:

1. [Сreate](#create-audio-frames) کنید یا فریم صوتی را دریافت کنید.
2. مقادیر جدید را برای ویژگی‌های فریم صوتی که می‌خواهید تنظیم کنید، تعیین کنید.
3. فایل PowerPoint اصلاح‌شده را ذخیره کنید.

این کد Python عملی را نشان می‌دهد که در آن گزینه‌های صدا تنظیم می‌شوند:

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
        # پخش با کلیک با حجم پایین، در تمام اسلایدها، بدون حلقه‌زدن.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # پنهان کردن فریم در هنگام نمایش اسلاید و عقب‌گرد پس از پخش.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

این مثال Python نشان می‌دهد چگونه فریم صوتی جدیدی با صدا جاسازی‌شده اضافه کنید، آن را برش دهید و مدت زمان محو شدن را تنظیم کنید:

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

    # از ابتدا 1.5 ثانیه و از انتها 2 ثانیه را برش بزنید.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # محو شدن ورودی را به 200 میلی‌ثانیه و محو شدن خروجی را به 500 میلی‌ثانیه تنظیم کنید.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نمونه کد زیر نشان می‌دهد چگونه یک فریم صوتی با صدا جاسازی‌شده دریافت کنید و حجم آن را به 85٪ تنظیم کنید:

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

## **مدیریت کپشن‌های صوتی**

Aspose.Slides به شما اجازه می‌دهد زیرنویس‌های بسته‌شده به فریم صوتی را از طریق متد [getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#getCaptionTracks) اضافه کنید. این متد یک [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) برمی‌گرداند که به شما امکان می‌دهد مسیرهای کپشن WebVTT اضافه کنید، در مسیرهای موجود پیمایش کنید و در صورت لزوم آن‌ها را حذف کنید.

**افزودن کپشن‌های صوتی**

از متد [getCaptionTracks](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#getCaptionTracks) برای اتصال یک یا چند مسیر کپشن به فریم صوتی استفاده کنید. در مثال زیر، یک فایل صوتی به اسلاید اضافه می‌شود و سپس مسیر کپشن جدیدی از یک فایل `.vtt` بارگذاری می‌شود.

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

    # یک مسیر کپشن جدید از فایل WebVTT اضافه کنید.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**استخراج کپشن‌های صوتی**

می‌توانید در مسیرهای کپشن مرتبط با فریم صوتی پیمایش کنید و آن‌ها را به‌صورت فایل‌های `.vtt` ذخیره کنید. هر مسیر کپشن داده‌های باینری و شناسهٔ یکتا خود را ارائه می‌دهد که می‌توان هنگام استخراج کپشن از آن استفاده کرد.

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
                # کپشن را به عنوان یک فایل .vtt ذخیره کنید.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**حذف کپشن‌های صوتی**

برای حذف کپشن‌ها از فریم صوتی، از متدهای ارائه‌شده توسط [CaptionsCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/) مانند [clear](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#clear)، [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/captionscollection/#removeAt) استفاده کنید. مثال زیر تمام مسیرهای کپشن را از فریم صوتی حذف می‌کند.

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

## **استخراج صدا**

Aspose.Slides برای Python via Java امکان استخراج صدایی که در انتقال‌های نمایش اسلاید استفاده می‌شود را فراهم می‌کند. به‌عنوان مثال می‌توانید صدای استفاده‌شده در یک اسلاید خاص را استخراج کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید و ارائه‌ای که حاوی صدا است را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق شاخص آن دریافت کنید.
3. به [slideshow transitions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslide/#getSlideShowTransition) برای اسلاید دسترسی پیدا کنید.
4. صدا را به‌صورت داده بایت استخراج کنید.

این کد Python نشان می‌دهد چگونه صدای استفاده‌شده در یک اسلاید را استخراج کنید:

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

## **سؤالات متداول**

**آیا می‌توانم همان منبع صوتی را در چندین اسلاید بدون افزایش حجم فایل استفاده کنم؟**

بله. صدا را یک بار به [audio collection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAudios) مشترک ارائه اضافه کنید و فریم‌های صوتی اضافی که به آن منبع ارجاع می‌دهند ایجاد کنید. این کار از تکرار داده‌های رسانه‌ای جلوگیری کرده و اندازهٔ ارائه را تحت کنترل نگه می‌دارد.

**آیا می‌توانم صدا را در یک فریم صوتی موجود بدون ایجاد دوبارهٔ شکل جایگزین کنم؟**

بله. برای صدای لینک‌شده، مسیر [link path](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setLinkPathLong) را به‌روز کنید تا به فایل جدید اشاره کند. برای صدای جاسازی‌شده، شیء [embedded audio](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/#setEmbeddedAudio) را با شیء دیگری از [audio collection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getAudios) ارائه تعویض کنید. قالب‌بندی فریم و اکثر تنظیمات پخش بدون تغییر باقی می‌مانند.

**آیا برش صدا داده‌های صوتی زیرین را که در ارائه ذخیره شده‌اند تغییر می‌دهد؟**

نه. برش فقط مرزهای پخش را تنظیم می‌کند. بایت‌های اصلی صدا دست‌نخورده می‌مانند و از طریق صداهای جاسازی‌شده یا مجموعهٔ صداهای ارائه قابل دسترسی هستند.