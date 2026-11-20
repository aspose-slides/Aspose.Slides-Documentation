---
title: مدیریت فریم‌های صوتی در ارائه‌ها با Python
linktitle: فریم صوتی
type: docs
weight: 10
url: /fa/python-java/audio-frame/
keywords:
- صدا
- فریم صوتی
- تصویر بند انگشتی
- اضافه کردن صدا
- ویژگی‌های صدا
- گزینه‌های صوتی
- استخراج صدا
- پایتون
- Aspose.Slides
description: "صدا را در اسلایدها جاسازی کنید، نماد صوتی را تغییر دهید، پخش را پیکربندی کنید، زیرنویس‌های WebVTT را مدیریت کنید و صداهای انتقال اسلاید را با Aspose.Slides for Python via Java استخراج نمایید."
---
## **نمای کلی**

یک فریم صوتی به شما امکان می‌دهد صدایی را روی اسلاید پخش کنید. با Aspose.Slides for Python via Java می‌توانید یک قطعه صوتی را درج کنید، تصویری که نشان‌دهنده آن است را انتخاب کنید، تنظیمات پخش را تنظیم کنید و زیرنویس‌ها را اضافه کنید. همچنین می‌توانید صدای اختصاص داده شده به یک انتقال اسلاید را بازیابی کنید.

## **ایجاد فریم‌های صوتی**

بایت‌های فایل `audio.wav` را به مجموعه صوتی ارائه اضافه کنید، سپس از [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) برای درج یک قطعه صوتی محلی در اسلاید اول استفاده کنید. دو مختصهٔ اول موقعیت فریم را روی اسلاید تعیین می‌کند و دو مقدار بعدی عرض و ارتفاع آن را بر حسب نقطه تنظیم می‌کند. این مثال از [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) برای شروع خودکار قطعه و از [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) برای انتخاب تنظیم صدای پیش‌فرض استفاده می‌کند.

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

## **تغییر تصویر بند انگشتی فریم صوتی**

به‌طور پیش‌فرض، یک فریم صوتی یک نماد بلندگو را نمایش می‌دهد. برای نمایش تصویر بند انگشتی سفارشی، یک تصویر را با [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) به ارائه اضافه کنید و با [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) آن را بر روی تصویر فریم تنظیم کنید. این مثال از یک JPEG به‌عنوان تصویر بند انگشتی برای یک قطعه صوتی جاسازی‌شده استفاده می‌کند.

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

    audio_data = Path("audio.wav").read_bytes()
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

کنترل‌های **Audio Options** در PowerPoint تعیین می‌کنند که یک قطعه چه زمانی شروع شود، چه صدایی داشته باشد و در طول نمایش اسلایدها چگونه رفتار کند.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| کنترل PowerPoint | متد Aspose.Slides for Python via Java |
| --- | --- |
| شروع | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| تنظیم صدای پیش‌فرض | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| پخش در طول اسلایدها | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| حلقه تا توقف | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| مخفی در حین نمایش | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| بازگردان پس از پخش | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| محو شدن در آغاز | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| محو شدن در پایان | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| برش زمان شروع صدا | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| برش زمان پایان صدا | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| اسلایدر حجم | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

این مثال اولین فریم صوتی را در اسلاید اول پیدا می‌کند، با [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) پخش را با کلیک شروع می‌کند و تنظیم صدای کم را انتخاب می‌کند. قطعه در طول اسلایدها ادامه می‌یابد و حلقه‌گذاری غیرفعال است. نماد در حین نمایش مخفی می‌ماند و پس از پخش، صدا دوباره به‌سر شروع می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # پخش با کلیک با حجم کم، در تمام اسلایدها، بدون حلقه.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # پنهان کردن فریم در طول نمایش اسلاید و بازگرداندن پس از پخش.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

برای قطعه‌ای طولانی‌تر از ۳٫۵ ثانیه، این مثال ۱٫۵ ثانیهٔ اول و ۲ ثانیهٔ آخر را حذف می‌کند. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) مدت زمانی که از انتهای قطعه حذف می‌شود را دریافت می‌کند. برای به‌دست آوردن زمان انتهایی نشان‌داده‌شده در PowerPoint، این مقدار را از مدت کل قطعه کم کنید. قطعهٔ برش‌خورده با ۲۰۰ میلی‌ثانیه محو می‌شود و با ۵۰۰ میلی‌ثانیه از بین می‌رود. تمام چهار روش مقادیر را بر حسب میلی‌ثانیه می‌پذیرند.

```python
from pathlib import Path

import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # برش 1.5 ثانیه از ابتدا و 2 ثانیه از انتها.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # تنظیم محو شدن ورودی به 200 میلی‌ثانیه و محو شدن خروجی به 500 میلی‌ثانیه.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای تنظیم حجم پخش به درصد خاص، از [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) استفاده کنید. این مثال اولین فریم صوتی را در اسلاید اول به ۸۵٪ تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **مدیریت زیرنویس‌های صوتی**

هر فریم صوتی دسترسی به مسیرهای زیرنویس خود را از طریق [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) فراهم می‌کند. از این مجموعه برای پیوست زیرنویس‌های WebVTT به قطعه، استخراج مسیرهای موجود یا حذف آن‌ها استفاده کنید.

### **افزودن زیرنویس صوتی**

این مثال یک قطعه صوتی را در اسلاید اول درج می‌کند و با [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) یک مسیر WebVTT محلی را پیوست می‌نماید. آرگومان اول برچسب مسیر را می‌دهد و آرگومان دوم فایلی که حاوی زیرنویس‌های زمان‌دار است را مشخص می‌کند.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # یک مسیر زیرنویس جدید از یک فایل WebVTT اضافه کنید.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **استخراج زیرنویس‌های صوتی**

این مثال هر مسیر زیرنویس پیوست‌شده به فریم صوتی در اسلاید اول را صادر می‌کند. بایت‌های بازگردانده‌شده توسط [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) در یک فایل WebVTT نوشته می‌شوند و شناسهٔ بازگردانده‌شده توسط [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) به‌عنوان نام فایل استفاده می‌شود تا هر مسیر خروجی جداگانه داشته باشد.

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
                # ذخیره مسیر زیرنویس به عنوان فایل .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **حذف زیرنویس‌های صوتی**

از [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) یا [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) برای حذف یک مسیر خاص استفاده کنید. این مثال با [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) تمام زیرنویس‌ها را از اولین فریم صوتی در اسلاید اول حذف می‌کند و در عین حال قطعه را حفظ می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **یافتن خطی در زیرنویس‌های صوتی**

برای یافتن خطی در زیرنویس‌های صوتی اسلاید اول، متن بازگردانده‌شده توسط [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) را در حافظه جستجو کنید. در یک cue متنی ساده WebVTT، خط زمان شامل `-->` است، خطوط زیرنویس پس از آن می‌آیند و یک خط خالی cue را خاتمه می‌دهد. این مثال برچسب مسیر و هر خط زیرنویس حاوی «café» را چاپ می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **استخراج صدا**

یک انتقال اسلاید می‌تواند صدای خود را داشته باشد. برای دریافت آن، بر روی انتقال اسلاید [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) را فراخوانی کنید. این مثال بایت‌های بازگردانده‌شده توسط [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) را دریافت کرده و تعداد بایت‌ها را چاپ می‌کند. اگر اسلاید اول صدای انتقال نداشته باشد، به‌جای آن پیام مربوطه را چاپ می‌کند.

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آیا می‌توانم همان قطعه صوتی را در چندین اسلاید بدون تکرار استفاده کنم؟**

بله. قطعه را یک‌بار به [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) ارائه اضافه کنید و همان شی صوتی را برای هر اسلاید به [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) پاس دهید.

**آیا می‌توانم صدا را در یک فریم صوتی موجود جایگزین کنم؟**

بله. برای صدای لینک‌شده، از [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) برای اشاره به فایل جایگزین استفاده کنید. برای صدای جاسازی‌شده، با [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) یک قطعه دیگر از مجموعه صوتی ارائه انتخاب کنید. هر دو روش فریم موجود را حفظ می‌کنند.

**آیا برش زمان صدا داده‌های صوتی ذخیره‌شده در ارائه را تغییر می‌دهد؟**

نه. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) و [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) مرزهای پخش را تعیین می‌کنند. هنوز می‌توانید قطعهٔ کامل را از [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) دریافت کنید.