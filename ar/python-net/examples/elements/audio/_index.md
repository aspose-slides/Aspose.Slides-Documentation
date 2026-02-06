---
title: الصوت
type: docs
weight: 70
url: /ar/python-net/examples/elements/audio/
keywords:
- صوت
- إطار صوت
- إضافة صوت
- الوصول إلى صوت
- إزالة صوت
- تشغيل صوت
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع الصوت في Python باستخدام Aspose.Slides: إضافة، استبدال، استخراج، وتقليم الأصوات، ضبط مستوى الصوت والتشغيل للشرائح والأشكال في PowerPoint و OpenDocument."
---
يوضح كيفية دمج إطارات الصوت والتحكم في تشغيلها باستخدام **Aspose.Slides for Python via .NET**. تُظهر الأمثلة التالية عمليات الصوت الأساسية.

## **إضافة إطار صوت**

مثال الشيفرة أدناه يضيف إطار صوت على شريحة العرض.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى إطار صوت**

هذا الشيفرة تسترجع أول إطار صوت من الشريحة.

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

## **إزالة إطار صوت**

احذف إطار الصوت المضاف مسبقًا.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # افتراض أن الشكل الأول هو AudioFrame.
        audio_frame = slide.shapes[0]

        # إزالة إطار الصوت.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط تشغيل الصوت**

قم بتكوين إطار الصوت ليُشغَل تلقائيًا عندما تظهر الشريحة.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو AudioFrame.
        audio_frame = slide.shapes[0]

        # تشغيل تلقائي عندما تظهر الشريحة.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```