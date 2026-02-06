---
title: فيديو
type: docs
weight: 80
url: /ar/python-net/examples/elements/video/
keywords:
- فيديو
- إطار فيديو
- إضافة فيديو
- الوصول إلى فيديو
- إزالة فيديو
- تشغيل الفيديو
- أمثلة على التعليمات البرمجية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع الفيديو في Python باستخدام Aspose.Slides: الإدراج، الاستبدال، القص، تعيين إطارات الملصق وخيارات التشغيل، وتصدير العروض التقديمية إلى PPT و PPTX و ODP."
---
يعرض كيفية دمج إطارات الفيديو وضبط خيارات التشغيل باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة إطار فيديو**

إدراج إطار فيديو فارغ إلى الشريحة.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة إطار فيديو.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى إطار فيديو**

استرداد أول إطار فيديو تمت إضافته إلى الشريحة.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # الوصول إلى أول إطار فيديو على الشريحة.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **إزالة إطار فيديو**

حذف إطار فيديو من الشريحة.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو إطار فيديو.
        video_frame = slide.shapes[0]

        # إزالة إطار الفيديو.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ضبط تشغيل الفيديو**

تكوين الفيديو لتشغيله تلقائيًا عند عرض الشريحة.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # بافتراض أن الشكل الأول هو إطار فيديو.
        video_frame = slide.shapes[0]

        # تكوين الفيديو لتشغيله تلقائيًا.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```