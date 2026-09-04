---
title: صدا
type: docs
weight: 70
url: /fa/python-java/examples/elements/audio/
keywords:
- مثال کد
- صدا
- قاب صوتی
- افزودن صدا
- دسترسی به صدا
- حذف صدا
- پخش صدا
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "از Aspose.Slides برای Python از طریق Java برای افزودن، دسترسی، حذف و پیکربندی قاب‌های صوتی در ارائه‌های PowerPoint و OpenDocument استفاده کنید."
---
این مقاله نشان می‌دهد که چگونه قاب‌های صوتی را جاسازی کرده و کنترل پخش را با استفاده از **Aspose.Slides for Python via Java** انجام دهید. مثال‌های زیر عملیات پایه‌ای صوتی را نشان می‌دهند.

پکیج را همان‌طور که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده است، نصب کنید. هر مثال قبل از شروع JVM `asposeslides` را وارد می‌کند، سپس پس از اجرا شدن JVM API را وارد می‌گردد.

## **افزودن یک قاب صوتی**

یک قاب صوتی خالی را وارد کنید که بعداً می‌تواند داده‌های صوتی جاسازی‌شده را نگه دارد.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # یک قاب صوتی خالی ایجاد کنید (صدا بعداً جاسازی خواهد شد).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **دسترسی به یک قاب صوتی**

این کد اولین قاب صوتی موجود در اسلاید را دریافت می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # دسترسی به اولین قاب صوتی در اسلاید.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **حذف یک قاب صوتی**

قاب صوتی که پیشتر اضافه شده بود را حذف کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # حذف قاب صوتی.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **تنظیم پخش صوتی**

قاب صوتی را طوری پیکربندی کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # به صورت خودکار هنگام ظاهر شدن اسلاید پخش شود.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```