---
title: صدا
type: docs
weight: 70
url: /fa/python-net/examples/elements/audio/
keywords:
- صدا
- قاب صوتی
- افزودن صدا
- دستیابی به صدا
- حذف صدا
- پخش صدا
- مثال‌های کد
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کار با صدا در Python با استفاده از Aspose.Slides: افزودن، جایگزینی، استخراج و برش صداها، تنظیم حجم و پخش برای اسلایدها و اشکال در PowerPoint و OpenDocument."
---
نحوهٔ افزودن قاب‌های صوتی و کنترل پخش با **Aspose.Slides for Python via .NET** را نشان می‌دهد. مثال‌های زیر عملیات پایهٔ صوتی را نشان می‌دهند.

## **افزودن یک قاب صوتی**

مثال کد زیر یک قاب صوتی را به اسلاید ارائه اضافه می‌کند.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **دستیابی به یک قاب صوتی**

این کد اولین قاب صوتی را از اسلاید بازیابی می‌کند.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **حذف یک قاب صوتی**

قاب صوتی اضافه شده‌ی قبلی را حذف کنید.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم که شکل اول یک AudioFrame است.
        audio_frame = slide.shapes[0]

        # قاب صوتی را حذف کنید.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم پخش صوتی**

قاب صوتی را طوری پیکربندی کنید که به‌صورت خودکار هنگام نمایش اسلاید پخش شود.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # فرض می‌کنیم که شکل اول یک AudioFrame است.
        audio_frame = slide.shapes[0]

        # به‌صورت خودکار هنگام نمایش اسلاید پخش شود.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```